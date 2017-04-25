using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.Application
{
    class Book : IBook
    {
        private string name1;
        private BookGenre genre;
        private string name2;

        public Book(int Id, string Name, BookGenre Genre, int OriginalPublisherId, string OriginalPublisher, int YearFirst) : this(Name, Genre, OriginalPublisherId, OriginalPublisher, YearFirst)
        {
            this.Id = Id;
        }

        public Book(string Name, BookGenre Genre, int OriginalPublisherId, string OriginalPublisher, int YearFirst)
        {
            this.Name = Name;
            this.Genre = Genre;
            this.OriginalPublisherId = OriginalPublisherId;
            this.OriginalPublisher = OriginalPublisher;
            this.YearFirst = YearFirst;
        }

        public int Id { get; }
        public string Name { get; }
        public BookGenre Genre { get; }
        public int OriginalPublisherId { get; }
        public string OriginalPublisher { get; }
        public int YearFirst { get; }

        internal static IBook MapFromDb(BookDb book) => new Book(book.Id, book.Name, (BookGenre)book.Genre, book.OriginalPublisherId, book.OriginalPublisher.Name, book.YearFirst);
        internal static BookDb MapToDb(IBook book) => new BookDb
        {
            Id = book.Id,
            Name = book.Name,
            Genre = (int)book.Genre,
            OriginalPublisherId = book.OriginalPublisherId,
            YearFirst = book.YearFirst
        };
    }
}
