using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using BooksCatalogueDb.Database;

namespace BooksCatalogueDb.Application
{
    class Edition : IEdition
    {
        public Edition(string AltName, DateTime DateReleased, string CoverImg, string PublisherName, string DescriptionText, IEnumerable<IEditionFile> Related)
        {
            this.AlternativeName = AltName;
            this.DateReleased = DateReleased;
            this.CoverThumUrl = CoverImg;
            this.Publisher= Publisher;
            this.DescriptionText = DescriptionText;
            this.EditionFiles = new List<IEditionFile>(Related);
        }

        public string AlternativeName{get;}

        public DateTime DateReleased{get;}

        public string CoverThumUrl{get;}

        public string DescriptionText{get;}

        public IEnumerable<IEditionFile> EditionFiles{get;}

        public string Publisher { get; }

        public int PublisherId { get; }

        internal static IEnumerable<IEdition> MapFromDb(ICollection<EditionDb> editions)
        {
           foreach(var item in editions)
            {
                yield return MapFromDb(item);
            }
        }
        internal static IEdition MapFromDb(EditionDb edition)
        {
            return new Edition(edition.AlternativeName, edition.DateReleased, edition.CoverThumbUrl, edition.Publisher.Name, edition.DescriptionText, EditionFile.MapFromDb(edition.EditionFiles));
        }
    }
}
