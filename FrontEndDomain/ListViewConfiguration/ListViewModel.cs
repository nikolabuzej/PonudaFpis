namespace FrontEndDomain.ListViewConfiguration
{
    public class ListViewModel<T> where T : class
    {
        public List<T> Data { get; set; } = new List<T>();
        public PaginationModel Pagination { get; set; } = new PaginationModel();

    }
}
