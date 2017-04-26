using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IBook : IBaseEntity
    {
        string Name { get; }
        BookGenre Genre { get; }
        int OriginalPublisherId { get; }
        string OriginalPublisher { get; }
        string Synopsis { get; }
        int YearFirst { get; }
    }
}