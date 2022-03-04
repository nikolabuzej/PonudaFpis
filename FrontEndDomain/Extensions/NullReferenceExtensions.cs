using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndDomain.Extensions
{
    public static class NullReferenceExtensions
    {
        public static T EnsureExists<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            return source;
        }

        public static async Task<T> EnsureExists<T>(this Task<T> source)
        {
            return (await source).EnsureExists();
        }
    }
}
