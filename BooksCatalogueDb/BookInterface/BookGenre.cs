using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    [Flags]
    public enum BookGenre
    {
        Unknown = 0,
        Satire = 1,
        Drama = 2,
        ActionandAdventure = 4,
        Romance = 8,
        Mystery = 16,
        Horror = 32,
        Childrens = 64,
        Travel = 128,
        Science = 256,
        History = 512,
        Poetry = 1024,
        Fantasy = 2048,
        Journals = 4096,
        ScienceFiction = 8192
    }
}
