using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTests.Client
{
    class ClientEdition : IEdition
    {
        public int BookId {get;set;}

        public string AlternativeName {get;set;}

        public DateTime DateReleased {get;set;}

        public string CoverThumUrl {get;set;}

        public int PublisherId {get;set;}

        public string DescriptionText {get;set;}

        public bool IsFirstEdition {get;set;}

        public string Isbn {get;set;}

        public IEnumerable<IEditionFile> EditionFiles {get;set;}

        public int Id {get;set;}
    }
}
