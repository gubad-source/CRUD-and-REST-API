using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(new Blog { Id = 1, Title = "T-rex", Content = "Welcome to Jurrasic Park bitches" });
            modelBuilder.Entity<Blog>().HasData(new Blog { Id = 2, Title = "Spinosaurus ", Content = "Welcome to Jurrasic Park bitches" });
            modelBuilder.Entity<Blog>().HasData(new Blog { Id = 3, Title = "Giganotosaurus", Content = "Welcome to Jurrasic Park bitches" });
        }
    }
}
