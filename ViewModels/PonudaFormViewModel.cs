using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;

namespace ViewModels
{
    public class PonudaFormViewModel: BaseViewModel
    {
        private readonly IPonudaService _ponudaService;
        private Ponuda _ponuda = Ponuda.Default();
        private  List<JavniPoziv> _javniPozivi = Enumerable.Empty<JavniPoziv>().ToList();
        private  List<Ponudjac> _ponudjaci = Enumerable.Empty<Ponudjac>().ToList();
        private  List<InformacijeOIsporuci> _informacijeOIsporuci = Enumerable.Empty<InformacijeOIsporuci>().ToList();

        public List<JavniPoziv> JavniPozivi
        {
            get => _javniPozivi;
            set => SetValue(ref _javniPozivi, value);
        }
        public List<Ponudjac> Ponudjaci
        {
            get => _ponudjaci;
            set => SetValue(ref _ponudjaci, value);
        }
        public List<InformacijeOIsporuci> InformacijeOIsporuci
        {
            get => _informacijeOIsporuci;
            set => SetValue(ref _informacijeOIsporuci, value);
        }
        public Ponuda Ponuda
        {
            get => _ponuda;
            set => SetValue(ref _ponuda, value);
        }
        public PonudaFormViewModel(IPonudaService ponudaService)
        {
            _ponudaService = ponudaService;
        }

        public async Task OnInit(Guid id)
        {
            var ponuda = await VratiPonudu(id);
            Ponuda = ponuda;
        }
        public async Task<Ponuda> VratiPonudu(Guid id)
        {
            var response = await _ponudaService.VratiPonudu(id);

            return response;
        }

       
    }
}
