using BooksCatalogueDb.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IEdition : IBaseEntity
    {
        int BookId { get; }
        string AlternativeName { get; }
        DateTime DateReleased { get; }
        string CoverThumUrl { get; }
        int PublisherId { get; }
        string DescriptionText { get; }
        bool IsFirstEdition { get; }
        string Isbn { get; }
        IEnumerable<IEditionFile> EditionFiles { get; }
    }
}
