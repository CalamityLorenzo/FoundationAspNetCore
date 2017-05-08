using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BooksCatalogueDb.BookInterface;

namespace DbTests.Client
{
    public static class ClentExtension
    {
        public static IBook ToClient(this IBook @this)
        {
            return null;
        }

        public static IEdition ToClient(this IEdition @this)
        {
            return new ClientEdition(@this.Id, @this.BookId, @this.Isbn, @this.AlternativeName, @this.CoverThumUrl, @this.DescriptionText, @this.EditionFiles);
        }

        public static IEditionFile ToClient(this IEditionFile @this)
        {
            return new ClientEditionFile(@this.Id, @this.EditionId,  @this.FileType, @this.FileFormat, @this.FileUrl);
        }


    }
}
