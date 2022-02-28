using Core.ListView;

namespace PonudaFpis.Model
{
    public class ListViewModel<T> where T : class
    {
        public ListView<T> Data { get; set; } = new ListView<T>(); 
        public PaginationParameters Pagination { get; set; } = new PaginationParameters();

    }
}
