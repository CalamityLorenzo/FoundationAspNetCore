using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BooksCatalogueDb.Database;

namespace BooksCatalogueDb.Application
{
    class Edition : IEdition
    {
        public Edition(int BookId, string AltName, DateTime DateReleased, string CoverImg, int PublisherId, string DescriptionText, string Isbn, bool IsFirstEdition, IEnumerable<IEditionFile> Related)
        {
            if (BookId == 0)
                throw new ArgumentOutOfRangeException("A book reference required");

            this.BookId = BookId;
            this.AlternativeName = AltName;
            this.DateReleased = DateReleased;
            this.CoverThumUrl = CoverImg;
            this.PublisherId = PublisherId;
            this.DescriptionText = DescriptionText;
            this.Isbn = Isbn;
            this.IsFirstEdition = IsFirstEdition;
            this.EditionFiles = new List<IEditionFile>(Related);
        }

        internal static EditionDb MapToDb(IEdition edition)
        {
            return new EditionDb
            {
                Id = edition.Id,
                AlternativeName = edition.AlternativeName,
                BookId = edition.BookId,
                CoverThumbUrl = edition.CoverThumUrl,
                DateReleased = edition.DateReleased,
                DescriptionText = edition.DescriptionText,
                PublisherId = edition.PublisherId,
                EditionFiles = EditionFile.MapAllToDb(edition.EditionFiles).ToList()
            };
        }

        public Edition(IBook Book, string AltName, DateTime DateReleased, string CoverImg, int PublisherId, string DescriptionText, string Isbn, bool IsFirstEdition, IEnumerable<IEditionFile> Related)
        {
            if (Book.Id == 0)
                throw new ArgumentOutOfRangeException("A book reference required");

            this.BookId = Book.Id;
            this.AlternativeName = AltName;
            this.DateReleased = DateReleased;
            this.CoverThumUrl = CoverImg;
            this.PublisherId = PublisherId;
            this.DescriptionText = DescriptionText;
            this.IsFirstEdition = IsFirstEdition;
            this.Isbn = Isbn;
            this.EditionFiles = new List<IEditionFile>(Related);
        }

        internal Edition(int Id, int BookId, string AltName, DateTime DateReleased, string CoverImg, int PublisherId, string DescriptionText, string Isbn, bool IsFirstEdition, IEnumerable<IEditionFile> Related) : this(BookId, AltName, DateReleased, CoverImg, PublisherId, DescriptionText, Isbn, IsFirstEdition, Related)
        {
            if (this.Id == 0)
            {
                throw new ArgumentOutOfRangeException("Edition Id required");
            }

            this.Id = Id;
        }


        public int Id { get; }
        public int BookId { get; }
        public string AlternativeName { get; }
        public DateTime DateReleased { get; }
        public string CoverThumUrl { get; }
        public string DescriptionText { get; }
        public IEnumerable<IEditionFile> EditionFiles { get; }
        public bool IsFirstEdition { get; }
        public string Isbn { get; }
        public int PublisherId { get; }

        internal static IEnumerable<IEdition> MapFromDb(ICollection<EditionDb> editions)
        {
            foreach (var item in editions)
            {
                yield return MapFromDb(item);
            }
        }

        internal static IEdition MapFromDb(EditionDb edition)
        {
            return new Edition(edition.BookId, 
                               edition.AlternativeName, 
                               edition.DateReleased, 
                               edition.CoverThumbUrl, 
                               edition.PublisherId,
                               edition.DescriptionText, 
                               edition.Isbn, 
                               edition.IsFirstEdition, 
                               EditionFile.MapFromDb(edition.EditionFiles));
        }
    }
}
