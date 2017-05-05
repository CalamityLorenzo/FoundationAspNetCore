using BooksCatalogueDb.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IEdition
    {
         string AlternativeName { get; }
         DateTime DateReleased { get; }
         string CoverThumUrl { get; }
         string Publisher { get; }
         int PublisherId { get; }
         string DescriptionText { get; }
         IEnumerable<IEditionFile> EditionFiles { get; }
    }
}
