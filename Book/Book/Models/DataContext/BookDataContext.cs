using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models.Entity;


namespace Book.Models.DataContext
{
    public class BookDataContext:DbContext
    {
        public BookDataContext()
            :base()
        {

        }
        public BookDataContext(DbContextOptions options)
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Book;User Id=sa;Password=query");
            }
            
    }
        public DbSet<Bookk> Books { get; set; }
    }
    
}
