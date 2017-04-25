using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksCatalogueDb
{
    public class BooksCatalogueContext : DbContext
    {
        public DbSet<BookDb> Books { get; set; }
        public DbSet<AuthorDb> Authors { get; set; }
        //   public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<GenreDb> Genres { get; set; }

        internal BooksCatalogueContext(DbContextOptions<BooksCatalogueContext> options) : base(options)
        {

        }

        public BooksCatalogueContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookAuthor>()
                .HasKey(o => new { o.BookId, o.AuthorId });
               


            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Book).WithMany(o => o.Authors).HasForeignKey(o => o.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Author).WithMany(o => o.Books).HasForeignKey(o => o.AuthorId);

            modelBuilder.Entity<BookDb>()
                .ToTable("Books");

            modelBuilder.Entity<BookDb>()
                .Property(o => o.OriginalPublisherId).HasColumnName("Id");

            modelBuilder.Entity<BookDb>()
                .HasMany(o => o.Authors).WithOne(o => o.Book).HasForeignKey(o => o.BookId);

            modelBuilder.Entity<AuthorDb>()
                .HasMany(o => o.Books).WithOne(p => p.Author).HasForeignKey(o => o.AuthorId);

            modelBuilder.Entity<AuthorDb>()
                .ToTable("Authors");

            modelBuilder.Entity<Publisher>().ToTable("Publishers");

            modelBuilder.Entity<GenreDb>()
                .ToTable("Genres");
        }
    }
    public class BookDb
    {
        public BookDb()
        {
            this.Authors = new List<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Genre { get; set; }

        public int OriginalPublisherId { get; set; }
        public Publisher OriginalPublisher { get; set; }
        public int YearFirst { get; set; }

        public virtual List<BookAuthor> Authors { get; set; }
    }


    public class BookAuthor
    {
        public int BookId { get; set; }
        public BookDb Book {get;set;}
        public int AuthorId { get; set; }
        public AuthorDb Author { get; set; }
    }

    public class AuthorDb
    {
        public AuthorDb() { this.Books = new List<BookAuthor>(); }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThumbNailUrl { get; set; }
        public int YearOfBirth { get; set; }
        public int? YearOfDeath { get; set; }
        public string Bio { get; set; }
        public List<BookAuthor> Books { get; set; }

    }


    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearStarted { get; set; }
        public string Bio { get; set; }
    }


    public class GenreDb
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
    }



}
