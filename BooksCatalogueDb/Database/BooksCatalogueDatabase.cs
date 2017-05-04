using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksCatalogueDb.Database
{
    internal class BooksCatalogueContext : DbContext
    {
        public DbSet<BookDb> Books { get; set; }
        public DbSet<AuthorDb> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<GenreDb> Genres { get; set; }
        public DbSet<PublisherDb> Publishers { get; set; }

        public DbSet<EditionDb> Editions { get; set; }
        public DbSet<EditionFileDb> EditionFiles { get; set; }

        internal BooksCatalogueContext(DbContextOptions<BooksCatalogueContext> options) : base(options)
        {

        }

        public BooksCatalogueContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BaseEntity (Base Class) is good for inheritence, but a pain for primary key definitions
            modelBuilder.Entity<BookDb>()
            .HasKey(o => o.Id);

            modelBuilder.Entity<AuthorDb>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<PublisherDb>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<GenreDb>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<EditionDb>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<EditionFileDb>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(o => new { o.BookId, o.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Book).WithMany(o => o.Authors).HasForeignKey(o => o.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Author).WithMany(o => o.Books).HasForeignKey(o => o.AuthorId);

            modelBuilder.Entity<BookDb>()
                .ToTable("Books");
            modelBuilder.Entity<BookDb>()
                .HasOne(o => o.OriginalPublisher).WithMany(o => o.Books).HasForeignKey(o => o.OriginalPublisherId);

            modelBuilder.Entity<BookDb>()
                .Property(o => o.OriginalPublisherId).HasColumnName("OriginalPublisher");

            modelBuilder.Entity<BookDb>()
                .HasMany(o => o.Authors).WithOne(o => o.Book).HasForeignKey(o => o.BookId);

            modelBuilder.Entity<AuthorDb>()
                .ToTable("Authors");
            modelBuilder.Entity<AuthorDb>()
                .HasMany(o => o.Books).WithOne(p => p.Author).HasForeignKey(o => o.AuthorId);

            modelBuilder.Entity<PublisherDb>().
                ToTable("Publishers");

            modelBuilder.Entity<GenreDb>()
                .ToTable("Genres");
            modelBuilder.Entity<EditionDb>()
                .ToTable("Editions");
            modelBuilder.Entity<EditionFileDb>()
                .ToTable("EditionFiles");


            modelBuilder.Entity<EditionDb>()
             .HasOne(o => o.Book).WithMany(o => o.Editions);

            modelBuilder.Entity<EditionFileDb>()
                .HasOne(o => o.Edition).WithMany(o => o.EditionFiles);

        }
    }

    public class BaseEntity
    {
        internal int Id { get; set; }
    }

    public class BookDb : BaseEntity
    {
        // These properties can be 'null' so ensure a value so we don't have to be endless checking
        private string _Synopsis = "";
        public BookDb()
        {
            this.Authors = new List<BookAuthor>();

        }


        public string Name { get; set; }
        public int Genre { get; set; }
        public string Synopsis
        {
            get => _Synopsis;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Synopsis = value;
                }
                else
                {
                    _Synopsis = "";
                }
            }
        }
        public int OriginalPublisherId { get; set; }
        public PublisherDb OriginalPublisher { get; set; }
        public int YearFirst { get; set; }

        public List<BookAuthor> Authors { get; set; }
        public virtual ICollection<EditionDb> Editions { get; set; }
    }

    public class BookAuthor
    {
        public int BookId { get; set; }
        public BookDb Book { get; set; }
        public int AuthorId { get; set; }
        public AuthorDb Author { get; set; }
    }

    public class AuthorDb : BaseEntity
    {
        public AuthorDb() { this.Books = new List<BookAuthor>(); }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThumbNailUrl { get; set; }
        public int YearOfBirth { get; set; }
        public int? YearOfDeath { get; set; }
        public string Bio { get; set; }
        public List<BookAuthor> Books { get; set; }

    }


    public class PublisherDb : BaseEntity
    {
        public string Name { get; set; }
        public int YearStarted { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<BookDb> Books { get; set; }
    }

    public class GenreDb : BaseEntity
    {
        public string GenreName { get; set; }
    }

    public class EditionDb : BaseEntity
    {
        public int BookId { get; set; }
        public BookDb Book { get; set; }
        public string AlternativeName { get; set; }
        public DateTime DateReleased { get; set; }
        public string CoverThumbUrl { get; set; }
        public int PublisherId { get; set; }
        public PublisherDb Publisher { get; set; }
        public string DescriptionText { get; set; }
        public ICollection<EditionFileDb> EditionFiles { get; set; }
    }

    public class EditionFileDb : BaseEntity
    {
        public int EditionId { get; set; }
        public EditionDb Edition { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
    }
}
