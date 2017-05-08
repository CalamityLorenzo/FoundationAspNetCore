using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BooksCatalogueDb.BookInterface;

namespace DbTests.Client
{
    public static class ClentExtension
    {
        internal static ClientBook ToClient(this IBook @this)
        {
            return new ClientBook(@this.Id, @this.Name, @this.Genre, @this.OriginalPublisherId, @this.Synopsis, @this.YearFirst);
        }

        internal static ClientEdition ToClient(this IEdition @this)
        {
            return new ClientEdition(@this.Id, @this.BookId, @this.AlternativeName, @this.DateReleased, @this.PublisherId, @this.CoverThumUrl, @this.DescriptionText, @this.IsFirstEdition, @this.Isbn, @this.EditionFiles);
        }

        internal static ClientEditionFile ToClient(this IEditionFile @this)
        {
            return new ClientEditionFile(@this.Id, @this.EditionId, @this.Type, @this.Format, @this.Url);
        }


    }
}
