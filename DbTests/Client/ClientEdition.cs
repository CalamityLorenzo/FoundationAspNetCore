using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DbTests.Client
{
    internal class ClientEdition : IEdition
    {
        public ClientEdition(int Id, int BookId, string AlternativeName, DateTime DateReleased, int PublisherId, string CoverThumUrl, string DescriptionText, bool IsFirstEdition, string Isbn, IEnumerable<IEditionFile> EditionFiles) : this(BookId, AlternativeName, DateReleased, PublisherId, CoverThumUrl, DescriptionText, IsFirstEdition, Isbn, EditionFiles)
        {
            this.Id = Id;
        }

        public ClientEdition(int BookId, string AlternativeName, DateTime DateReleased, int PublisherId, string CoverThumUrl, string DescriptionText, bool IsFirstEdition, string Isbn, IEnumerable<IEditionFile> EditionFiles)
        {
            this.BookId = BookId;
            this.AlternativeName = AlternativeName;
            this.DateReleased = DateReleased;
            this.PublisherId = PublisherId;
            this.CoverThumUrl = CoverThumUrl;
            this.DescriptionText = DescriptionText;
            this.IsFirstEdition = IsFirstEdition;
            this.Isbn = Isbn;
            var items = EditionFiles.Select(o => o.ToClient() as ClientEditionFile);
            this.EditionFiles = new List<ClientEditionFile>(items);
        }

        public int BookId {get;}
        public string AlternativeName {get;}
        public DateTime DateReleased {get;}
        public string CoverThumUrl {get;}
        public int PublisherId {get;}
        public string DescriptionText {get;}
        public bool IsFirstEdition {get;}
        public string Isbn {get;}
        public IEnumerable<IEditionFile> EditionFiles { get; }
        public int Id {get;}
    }
}
