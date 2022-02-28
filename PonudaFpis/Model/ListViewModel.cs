using Core.ListView;

namespace PonudaFpis.Model
{
    public class ListViewModel<T> where T : class
    {
        public ListView<T> Data { get; set; } = new ListView<T>(); 
        public PaginationModel Pagination { get; set; } = new PaginationModel();

    }
}
