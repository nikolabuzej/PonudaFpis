using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;

namespace ViewModels
{
    public class ProizvodViewModel : BaseViewModel
    {
        private ListViewModel<Proizvod> _proizvodi = new();
        private readonly IProizvodService _proizvodService;

        public ProizvodViewModel(IProizvodService proizvodService)
        {
            _proizvodService = proizvodService;
        }

        public ListViewModel<Proizvod> Proizvodi
        {
            get => _proizvodi;
            set
            {
                SetValue(ref _proizvodi, value);
            }
        }

        public async Task OnInit()
        {
            var proizvodi = await this.VratiProizvode();

            Proizvodi = proizvodi;
        }
        public async Task<ListViewModel<Proizvod>> VratiProizvode()
        {
            var response = await _proizvodService.VratiProizvode();

            return response;
        }

    }
}
