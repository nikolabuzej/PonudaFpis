using Core.Abrstractions.Filter;
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
        public static ListView<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize, Filter<T> sortProperty, SortOrder sortOrder)
        {
            int count = source.Count();

            if (sortOrder == SortOrder.desc)
            {
                source = source.OrderByDescending(sortProperty.ToExpression()).
                    Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            else
            {
                source = source.OrderBy(sortProperty.ToExpression()).
                    Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }


            return new ListView<T>(source.ToList(), count, pageNumber, pageSize);
        }

    }
}
