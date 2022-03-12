using Core.Extensions;
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
        public static ListView<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize, string sortProperty, SortOrder sortOrder)
        {
            int count = source.Count();
            IQueryable<T> query = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            if (!string.IsNullOrEmpty(sortProperty))
            {
                if (sortOrder == SortOrder.asc)
                {
                    query = query.OrderBy(x => GetPropertyInfo(sortProperty).GetValue(x, null));
                }
                else
                {
                    query = query.OrderByDescending(x => GetPropertyInfo(sortProperty).GetValue(x, null));
                }
            }

            List<T> items = query.ToList();

            return new ListView<T>(items, count, pageNumber, pageSize);
        }

        private static PropertyInfo GetPropertyInfo(string sortProperty)
        {
            return typeof(T).GetProperty(sortProperty).EnsureExists();
        }
    }
}
