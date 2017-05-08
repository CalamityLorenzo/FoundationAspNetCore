using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTests.Client
{
    internal class ClientEditionFile : IEditionFile
    {
        public ClientEditionFile(int Id, int EditionId, string FileType, string FileFormat, string FileUrl) : this(EditionId, FileFormat, FileFormat, FileUrl)
        {
            this.Id = Id;
        }

        public ClientEditionFile(int EditionId, string FileType, string FileFormat, string FileUrl)
        {
            this.EditionId = EditionId;
            this.Url = FileUrl;
            this.Type = FileType;
            this.Format = FileFormat;
        }

        public int Id { get; }
        public int EditionId { get; }
        public string Title { get; }
        public string Type { get; }
        public string Url { get; }
        public string Format { get; }
    }
}
