using Book.Models.DataContext;
using Book.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        #region IndexAndDetails
        public IActionResult Index()
        {
            var db = new BookDataContext();
            List<Bookk>bookk = db.Books.ToList();
            return View(bookk);
        }
        public IActionResult Details(int id)
        {
            var db = new BookDataContext();
            Bookk bookk = db.Books.FirstOrDefault(p => p.Id == id);
            if (bookk == null)
            {
                return NotFound();
            }
            return View(bookk);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bookk bookk)
        {
            if (ModelState.IsValid)
            {
                bookk.Count = 1;
                var db = new BookDataContext();

               var sameBook= db.Books.FirstOrDefault(p => p.Author == bookk.Author && p.Genre == bookk.Genre && p.Price == bookk.Price);
               if(sameBook != null)
                {
                    sameBook.Count += bookk.Count;
                }
                else
                {
                    bookk.Count = 1;
                    db.Books.Add(bookk);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookk);
        }
        #endregion

        #region Delete
        //there is problem in Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var db = new BookDataContext();
            Bookk bookk = db.Books.FirstOrDefault(p => p.Id == id);
            if (bookk == null)
            {
                return NotFound();
            }
            return View(bookk);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var db = new BookDataContext();
            Bookk bookk = db.Books.FirstOrDefault(p => p.Id == id);
            
            if (bookk == null)
            {
                return NotFound();
            }

            try
            {
                bookk.Count = 1;
               var oneBook = db.Books.FirstOrDefault(p => p.Count == bookk.Count);
                if (oneBook != null)
                {
                    db.Books.Remove(bookk);
                }
                else
                {
                    oneBook.Count -= bookk.Count;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return View(bookk);
            }
          
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var db = new BookDataContext();
            Bookk bookk = db.Books.FirstOrDefault(p => p.Id == id);
            if (bookk == null)
            {
                return NotFound();
            }
            return View(bookk);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Bookk bookk)
        {
            if(id != bookk.Id)
            {
                return BadRequest();
            }
            var db = new BookDataContext();
            Bookk bookk1 = db.Books.FirstOrDefault(p => p.Id == id);
            if (bookk1 == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                bookk1.Author = bookk.Author;
                bookk1.Genre = bookk.Genre;
                bookk1.Price = bookk.Price;

       
                db.SaveChanges();
              return  RedirectToAction("Index");
            }
            return View(bookk1);
        }
        #endregion

      public IActionResult Practice(string title,string content)
        {
            string info = $"{title}: {content}";
            return Json(info);
        }
    }
}
