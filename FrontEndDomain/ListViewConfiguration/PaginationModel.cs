namespace FrontEndDomain.ListViewConfiguration
{
    public class PaginationModel
    {
        public PaginationModel(int currentPage, int totalPages, int pageSize, int totalCount)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public PaginationModel()
        {

        }
        public int CurrentPage { get;  set; } = 1;
        public int TotalPages { get;  set; } = 1;
        public int PageSize { get;  set; } = 10;
        public int TotalCount { get;  set; }
    }
}
