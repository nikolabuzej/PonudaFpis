using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ExtensionMethods
    {
        public static T EnsureExists<T>(this T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"{nameof(T)} has not been found");
            }

            return entity;
        }
    }
}
