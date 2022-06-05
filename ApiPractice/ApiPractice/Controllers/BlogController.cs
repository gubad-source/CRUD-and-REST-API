using ApiPractice.Contexts;
using ApiPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.Controllers
{
    [Route("api/blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public List<Blog> List()
        {
            return _context.Blogs.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> Detail(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null) {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else
            {
                return blog;
            }
           
        }

        [HttpPost]
        public ActionResult Create([FromBody] Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,[FromBody] Blog blog)
        {
            Blog updatedBlog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (updatedBlog == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else
            {
                updatedBlog.Title = blog.Title;
                updatedBlog.Content = blog.Content;
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Blog removedBlog=_context.Blogs.FirstOrDefault(b => b.Id ==id);
            if (removedBlog == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else
            {
                _context.Blogs.Remove(removedBlog);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }
    }
}
