using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BooksCatalogueDb.Application
{
    class Author : IAuthor
    {
        internal Author(int Id, string FirstName, string LastName, string ThumbNailUrl, int YearOfBirth, int? YearOfDeath, string Bio) : this(FirstName, LastName, ThumbNailUrl, YearOfBirth, YearOfDeath, Bio)
        {
            this.Id = Id;
        }

        public Author(string FirstName, string LastName, string ThumbNailUrl, int YearOfBirth, int? YEarOfDeath, string Bio)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ThumbNailUrl = ThumbNailUrl;
            this.YearOfBirth = YearOfBirth;
            this.YearOfDeath = YEarOfDeath;
            this.Bio = Bio;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string ThumbNailUrl { get; }
        public int YearOfBirth { get; }
        public int? YearOfDeath { get; }
        public string Bio { get; }

        public override string ToString() => $"{Id} : {FirstName} {LastName} : {YearOfBirth}";
        
        internal static IAuthor MapFromDb(AuthorDb author) => new Author(
                                    author.Id,
                                    author.FirstName,
                                    author.LastName,
                                    author.ThumbNailUrl,
                                    author.YearOfBirth,
                                    author.YearOfDeath, author.Bio);

        internal static AuthorDb MapToDb(IAuthor author) => new AuthorDb
        {
            Id = author.Id,
            Bio = author.Bio,
            FirstName = author.FirstName,
            LastName = author.LastName,
            ThumbNailUrl = author.ThumbNailUrl,
            YearOfBirth = author.YearOfBirth,
            YearOfDeath = author.YearOfDeath
        };


    }


}
