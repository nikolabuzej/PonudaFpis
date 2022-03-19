using Core.Extensions;
using Core.ListView.Ponuda;
using System.Reflection;

namespace Core.ListView
{
    public class ListView<T> : List<T> where T : class
    {
        public int CurrentPage { get; private set; } = 1;
        public int TotalPages { get; private set; } = 1;
        public int PageSize { get; private set; } = 10;
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public ListView(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public ListView()
        {

        }
        public static ListView<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize, SortProperty sortProperty, SortOrder sortOrder)
        {
            int count = source.Count();
            IQueryable<T> query = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            List<T> items = query.ToList();
            if (sortOrder == SortOrder.asc)
            {
                items = items.OrderBy(x => GetPropertyInfo(sortProperty.ToString()).GetValue(x, null)).ToList();
            }
            else
            {
                items = items.OrderByDescending(x => GetPropertyInfo(sortProperty.ToString()).GetValue(x, null)).ToList();
            }


            return new ListView<T>(items, count, pageNumber, pageSize);
        }

        private static PropertyInfo GetPropertyInfo(string sortProperty)
        {
            var property = typeof(T).GetProperty(sortProperty).EnsureExists();

            return property;
        }
    }
}
