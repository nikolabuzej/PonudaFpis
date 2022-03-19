using Core.ListView;
using Core.ListView.Ponuda;

namespace PonudaFpis.Model
{
    public class PaginationModel
    {
        public PaginationModel(int currentPage, int totalPages, int pageSize, int totalCount, SortProperty sortProperty, SortOrder sortOrder,
            string searchText)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = totalCount;
            SortProperty = sortProperty;
            SortOrder = sortOrder;
            SearchText = searchText;
        }
        public PaginationModel()
        {

        }
        public int CurrentPage { get; private set; } = 1;
        public int TotalPages { get; private set; } = 1;
        public int PageSize { get; private set; } = 10;
        public int TotalCount { get; private set; }
        public SortProperty SortProperty { get; private set; }
        public SortOrder SortOrder { get; private set; }
        public string SearchText { get; private set; } = string.Empty;
    }
}
