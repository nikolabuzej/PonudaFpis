using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;

namespace ViewModels
{
    public class ProizvodViewModel : BaseViewModel
    {
        private List<Proizvod> _proizvodi = new();
        private readonly IProizvodService _proizvodService;

        public ProizvodViewModel(IProizvodService proizvodService)
        {
            _proizvodService = proizvodService;
        }

        public List<Proizvod> Proizvodi
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

            Proizvodi = proizvodi.ToList();
        }
        public async Task<IEnumerable<Proizvod>> VratiProizvode()
        {
            var response = await _proizvodService.VratiProizvode();

            return response;
        }

    }
}
