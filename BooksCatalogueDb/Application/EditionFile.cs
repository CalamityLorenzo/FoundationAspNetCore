using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using BooksCatalogueDb.Database;

namespace BooksCatalogueDb.Application
{
    class EditionFile : IEditionFile
    {
        public EditionFile(string FileType, string FileUrl, string FileFormat)
        {
            this.FileFormat = FileFormat;
            this.FileType = FileType;
            this.FileUrl = FileUrl;
        }

        public string FileType { get; }

        public string FileUrl { get; }

        public string FileFormat { get; }

        internal static IEnumerable<IEditionFile> MapFromDb(ICollection<EditionFileDb> editionFiles)
        {
            foreach(var item in editionFiles)
            {
                yield return MapFromDb(item);
            }
        }
        internal static IEditionFile MapFromDb(EditionFileDb editionFile)
        {
            return new EditionFile(editionFile.FileType, editionFile.FileUrl, editionFile.FileFormat);
        }
    }
}
