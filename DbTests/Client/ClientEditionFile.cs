using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTests.Client
{
    internal class ClientEditionFile : IEditionFile
    {
        public ClientEditionFile(int Id, int EditionId, string Type, string Format, string Url) : this(EditionId, Format, Format, Url)
        {
            this.Id = Id;
        }

        public ClientEditionFile(int EditionId, string Type, string Format, string Url)
        {
            this.EditionId = EditionId;
            this.Url = Url;
            this.Type = Type;
            this.Format = Format;
        }

        public int Id { get; }
        public int EditionId { get; }
        public string Title { get; }
        public string Type { get; }
        public string Url { get; }
        public string Format { get; }
    }
}
