using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/1" },
                new Image { Id = 2, Url = "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/2" },
                new Image { Id = 3, Url = "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/3" },
                new Image { Id = 4, Url = "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/4" },
                new Image { Id = 5, Url = "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/5" }
            );
        }
    }
}
