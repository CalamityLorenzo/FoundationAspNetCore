using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IBook
    {
        int Id { get; }
        string Name { get; }
        BookGenre Genre { get; }
        int OriginalPublisherId { get; }
        string OriginalPublisher { get; }
        int YearFirst { get; }
    }
}