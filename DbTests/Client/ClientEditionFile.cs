using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTests.Client
{
    class ClientEditionFile : IEditionFile
    {
        public int EditionId{get;set;}

        public string FileType{get;set;}

        public string FileUrl{get;set;}

        public string FileFormat{get;set;}

        public int Id{get;set;}
    }
}
