using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IAuthor: IBaseEntity
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string ThumbNailUrl { get; }
        int YearOfBirth { get; }
        int? YearOfDeath { get; }
        string Bio { get; }
    }
}
