using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.Application
{
    class Publisher
    {
        public int Id { get; }
        string Name { get; }
        int YearStarted { get; }
        string Bio { get; }

        internal Publisher(int Id, string Name, int YearStarted, string Bio) : this(Name, YearStarted, Bio) {
            this.Id = Id;
        }

        public Publisher( string Name, int YearStarted, string Bio)
        {
            this.Name = Name;
            this.YearStarted = YearStarted;
            this.Bio = Bio;
        }
    }
}
