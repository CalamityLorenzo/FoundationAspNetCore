using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BooksCatalogueDb.Database;

namespace BooksCatalogueDb.Application
{
    class EditionFile : IEditionFile
    {

        internal EditionFile(int Id, int EditionId, string Title, string FileType, string FileUrl, string FileFormat) : this(EditionId, Title, FileType, FileUrl, FileFormat)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException("No Id passed");
            }
            this.Id = Id;
        }

        public EditionFile(Edition Edition, string FileType, string FileUrl, string FileFormat)
        {
            if (Edition.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("We need an edition reference");
            }
            this.EditionId = Edition.Id;
            this.Format = FileFormat;
            this.Type = FileType;
            this.Url = FileUrl;
        }

        public EditionFile(int EditionId, string Title, string FileType, string FileUrl, string FileFormat)
        {
            if (EditionId <= 0)
            {
                throw new ArgumentOutOfRangeException("We need an edition reference");
            }

            this.EditionId = EditionId;
            this.Format = FileFormat;
            this.Type = FileType;
            this.Url = FileUrl;
            this.Title = Title;
        }
        public int Id { get; }
        public int EditionId { get; }
        public string Type { get; }
        public string Url { get; }
        public string Format { get; }
        public string Title { get; }

        internal static IEnumerable<EditionFileDb> MapAllToDb(IEnumerable<IEditionFile> editionFiles)
        {
            return editionFiles.Select(o => EditionFile.MapToDb(o));
        }

        internal static EditionFileDb MapToDb(IEditionFile edFile)
        {
            return new EditionFileDb
            {
                Id = edFile.Id,
                EditionId = edFile.EditionId,
                Format = edFile.Format,
                Type = edFile.Type,
                Url = edFile.Url
            };

        }



        internal static IEnumerable<IEditionFile> MapFromDb(ICollection<EditionFileDb> editionFiles)
        {
            foreach (var item in editionFiles)
            {
                yield return MapFromDb(item);
            }
        }

        internal static IEditionFile MapFromDb(EditionFileDb editionFile)
        {
            return new EditionFile(editionFile.Id, editionFile.EditionId, editionFile.Title, editionFile.Type, editionFile.Url, editionFile.Format);
        }
    }
}
