using BooksCatalogueDb.BookInterface;
using BooksCatalogueDb.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksCatalogueDb.Application
{
    class Book : IBook
    {
        public Book(int Id, string Name, BookGenre Genre, int OriginalPublisherId, string OriginalPublisher, string Synopsis, int YearFirst, IEnumerable<IEdition> Editions) : this(Name, Genre, OriginalPublisherId, OriginalPublisher, Synopsis, YearFirst, Editions)
        {
            this.Id = Id;
        }

        public Book(string Name, BookGenre Genre, int OriginalPublisherId, string OriginalPublisher, string Synopsis, int YearFirst, IEnumerable<IEdition> Editions) 
        {
            this.Name = Name;
            this.Genre = Genre;
            this.OriginalPublisherId = OriginalPublisherId;
            this.OriginalPublisher = OriginalPublisher;
            this.YearFirst = YearFirst;
            this.Synopsis = Synopsis;
            this.Editions = new List<IEdition>(Editions);
        }

        public int Id { get; }
        public string Name { get; }
        public BookGenre Genre { get; }
        public int OriginalPublisherId { get; }
        public string OriginalPublisher { get; }
        public int YearFirst { get; }
        public string Synopsis { get; }
        public IEnumerable<IEdition> Editions { get; }

        public override string ToString() => $"{Id} : {Name}";

        internal static IBook MapFromDb(BookDb book) => new Book(book.Id, 
                                                                 book.Name, 
                                                                 (BookGenre)book.Genre,
                                                                 book.OriginalPublisherId, 
                                                                 (null== book.OriginalPublisher) ?"":book.OriginalPublisher.Name,
                                                                 book.Synopsis,
                                                                 book.YearFirst, Edition.MapFromDb(book.Editions));

        internal static BookDb MapToDb(IBook book) => new BookDb
        {
            Id = book.Id,
            Name = book.Name,
            Genre = (int)book.Genre,
            OriginalPublisherId = book.OriginalPublisherId,
            YearFirst = book.YearFirst,
            Synopsis = book.Synopsis
        };
        internal static IEnumerable<IBook> MapFromDb(IQueryable<BookDb> books) => books.Select(MapFromDb);
        internal static IEnumerable<BookDb> MapToDb(IEnumerable<IBook> books) => books.Select(MapToDb);
    }
}
