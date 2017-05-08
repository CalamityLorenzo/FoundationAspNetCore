using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BooksCatalogueDb.BookInterface;

namespace DbTests.Client
{
    public static class ClentExtension
    {
        public static IBook ToClient(this IBook @this)
        {
            return null;
        }

        public static IEdition ToClient(this IEdition @this)
        {
            return null;
        }

        public static IEditionFile ToClient(this IEditionFile @this)
        {
            return null;
        }
    }
}
