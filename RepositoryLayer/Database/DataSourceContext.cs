using DTOs.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Database
{
    public class DataSourceContext:DbContext
    {
        public DataSourceContext(DbContextOptions<DataSourceContext> options):base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID);

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.K. Rowling", Address = "UK" },
                new Author { Id = 2, Name = "George R.R. Martin", Address = "USA" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Harry Potter", Description = "Fantasy novel", Pages = 350, AuthorID = 1 },
                new Book { Id = 2, Name = "Parry Hotter", Description = "Nantasy Fovel", Pages = 450, AuthorID = 1 },
                new Book { Id = 3, Name = "Game of Thrones", Description = "Epic fantasy", Pages = 800, AuthorID = 2 },
                new Book { Id = 4, Name = "Tame of Ghrones", Description = "Fpic Eantasy", Pages = 850, AuthorID = 2 }
            );
        }
    }
}
