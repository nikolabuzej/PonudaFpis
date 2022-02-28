namespace PonudaFpis.Model
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
        public int CurrentPage { get; private set; } = 1;
        public int TotalPages { get; private set; } = 1;
        public int PageSize { get; private set; } = 10;
        public int TotalCount { get; private set; }
    }
}
