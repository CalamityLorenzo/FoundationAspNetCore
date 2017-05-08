using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTests.Client
{
    internal class ClientBook : IBook
    {
        public ClientBook(int Id, string Name, BookGenre  Genre, int OriginalPublisherId, string Synopsis, int YearFirst)
        {
            this.Id = Id;
        }

        public ClientBook(string Name, BookGenre Genre, int OriginalPublisherId, string Synopsis, int YearFirst)
        {
            this.Name = Name;
            this.Genre = Genre;
            this.OriginalPublisherId = OriginalPublisherId;
            this.Synopsis = Synopsis;
            this.YearFirst = YearFirst;
        }

        public int Id {get;}
        public string Name {get;}
        public BookGenre Genre {get;}
        public int OriginalPublisherId {get;}
        public string OriginalPublisher {get;}
        public string Synopsis {get;}
        public int YearFirst {get;}
    }
}
