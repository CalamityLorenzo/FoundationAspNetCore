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

        internal EditionFile(int Id, int EditionId, string FileType, string FileUrl, string FileFormat) : this(EditionId, FileType, FileUrl, FileFormat)
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
            this.EditionId = EditionId;
            this.FileFormat = FileFormat;
            this.FileType = FileType;
            this.FileUrl = FileUrl;
        }

        public EditionFile(int EditionId, string FileType, string FileUrl, string FileFormat)
        {
            if (EditionId <= 0)
            {
                throw new ArgumentOutOfRangeException("We need an edition reference");
            }

            this.EditionId = EditionId;
            this.FileFormat = FileFormat;
            this.FileType = FileType;
            this.FileUrl = FileUrl;
        }

        internal static IEnumerable<EditionFileDb> MapAllToDb(IEnumerable<IEditionFile> editionFiles)
        {
            return editionFiles.Select(o => EditionFile.MapToDb(o));
        }

        private static EditionFileDb MapToDb(IEditionFile edFile)
        {
            return new EditionFileDb
            {
                Id = edFile.Id,
                EditionId = edFile.EditionId,
                FileFormat = edFile.FileFormat,
                FileType = edFile.FileType,
                FileUrl = edFile.FileUrl
            };

        }

        public int Id { get; }
        public int EditionId { get; }
        public string FileType { get; }
        public string FileUrl { get; }
        public string FileFormat { get; }

        internal static IEnumerable<IEditionFile> MapFromDb(ICollection<EditionFileDb> editionFiles)
        {
            foreach (var item in editionFiles)
            {
                yield return MapFromDb(item);
            }
        }

        internal static IEditionFile MapFromDb(EditionFileDb editionFile)
        {
            return new EditionFile(editionFile.Id, editionFile.FileType, editionFile.FileUrl, editionFile.FileFormat);
        }
    }
}
