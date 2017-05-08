using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTests.Client
{
    class ClientEdition : IEdition
    {
        public ClientEdition(int Id, int BookId, string AlternativeName, bool IsFirstEdition, DateTime DateReleased, string Isbn, string CoverThumbUrl, string DescriptionText, int PublishedId, IEnumerable<IEditionFile> EditionFiles): this(BookId, AlternativeName, IsFirstEdition, DateReleased, Isbn, CoverThumbUrl, DescriptionText, PublishedId, EditionFiles)
        {
            this.Id = Id;
        }

        public ClientEdition(int BookId, string AlternativeName, bool IsFirstEdition, DateTime DateReleased, string Isbn, string CoverThumbUrl, string DescriptionText, int PublisherId, IEnumerable<IEditionFile> EditionFiles)
        {
            this.BookId = BookId;
            this.AlternativeName = AlternativeName;
            this.DateReleased = DateReleased;
            this.Isbn = Isbn;
            this.CoverThumUrl = CoverThumUrl;
            this.DescriptionText = DescriptionText;
            this.PublisherId = PublisherId;
            this.EditionFiles = EditionFiles;
            this.IsFirstEdition = IsFirstEdition;
        }

        public int BookId {get;}

        public string AlternativeName {get;}

        public DateTime DateReleased {get;}

        public string CoverThumUrl {get;}

        public int PublisherId {get;}

        public string DescriptionText {get;}

        public bool IsFirstEdition {get;}

        public string Isbn {get;}

        public IEnumerable<IEditionFile> EditionFiles {get;}

        public int Id {get;}
    }
}
