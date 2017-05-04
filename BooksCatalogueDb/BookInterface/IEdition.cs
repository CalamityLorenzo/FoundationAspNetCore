using BooksCatalogueDb.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    interface IEdition
    {

         string AlternativeName { get; set; }
         DateTime DateReleased { get; set; }
         string CoverThumUrl { get; set; }
         Publisher Publisher { get; set; }
         string DescriptionText { get; set; }
         IEnumerable<IEditionFile> EditionFiles { get; set; }
    }
}
