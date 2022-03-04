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

        public async Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber, int pageSize)
        {
            ListViewModel<Ponuda> ponude = await _ponudaService.VratiPonude(pageNumber, pageSize);

            return ponude;
        }

    }
}
