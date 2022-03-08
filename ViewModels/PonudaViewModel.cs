using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;

namespace ViewModels
{
    public class PonudaViewModel : BaseViewModel
    {
        private readonly IPonudaService _ponudaService;

        public PonudaViewModel(IPonudaService ponudaService)
        {
            _ponudaService = ponudaService;
        }

        private ListViewModel<Ponuda> _ponude = new();
        public ListViewModel<Ponuda> Ponude
        {
            get => _ponude;
            set => SetValue(ref _ponude, value);
        }
        public async Task OnInit()
        {
            var ponude = await this.VratiPonude(1, 1);

            Ponude = ponude;
        }
        public async Task NextPage()
        {
           Ponude = await this.VratiPonude(Ponude.Pagination.NextPage, Ponude.Pagination.PageSize);
        }
        public async Task PrevoiusPage()
        {
           Ponude = await this.VratiPonude(Ponude.Pagination.PreviousPage,Ponude.Pagination.PageSize);
        }
        public async Task LastPage()
        {
            Ponude = await this.VratiPonude(Ponude.Pagination.TotalPages, Ponude.Pagination.PageSize);
        }
       
        public async Task NavigateToPage(int pageNumber)
        {
            Ponude = await this.VratiPonude(pageNumber, Ponude.Pagination.PageSize);
        }
        public List<int> CreateSpread()
        {
            return Enumerable.Range(1, Ponude.Pagination.TotalPages).ToList();
        }
        public string GetPageStatus()
        {
            return $"{Ponude.Pagination.CurrentPage}/{Ponude.Pagination.TotalPages}";
        }

        public async Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber, int pageSize)
        {
            ListViewModel<Ponuda> ponude = await _ponudaService.VratiPonude(pageNumber, pageSize);

            return ponude;
        }

    }
}
