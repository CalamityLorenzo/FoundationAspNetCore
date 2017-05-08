using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTests.Client
{
    class ClientEditionFile : IEditionFile
    {
        public ClientEditionFile(int Id, int EditionId, string FileType, string FileFormat, string FileUrl) : this(EditionId, FileType, FileFormat, FileUrl)
        {
            this.Id = Id;
        }

        public ClientEditionFile(int EditionId, string FileType, string FileFormat, string FileUrl)
        {
            this.EditionId = EditionId;
            this.FileType = FileType;
            this.FileFormat = FileFormat;
            this.FileUrl = FileUrl;
        }

        public int EditionId{get;}

        public string FileType{get;}

        public string FileUrl{get;}

        public string FileFormat{get;}

        public int Id{get;}
    }
}
