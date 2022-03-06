using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using ViewModels.Payloads;

namespace ViewModels
{
    public class PonudaFormViewModel: BaseViewModel
    {
        private readonly IPonudaService _ponudaService;
        private readonly IPonudjacService _ponudjacService;
        private readonly IProizvodService _proizvodService;
        private readonly IInformacijeOIsporuciService _informacijeOIsporuciService;
        private readonly IBankaService _bankaService;
        private readonly IJavniPozivService _javniPozivService;


        private Ponuda _ponuda = Ponuda.Default();
        private  List<JavniPoziv> _javniPozivi = Enumerable.Empty<JavniPoziv>().ToList();
        private  List<Ponudjac> _ponudjaci = Enumerable.Empty<Ponudjac>().ToList();
        private  List<InformacijeOIsporuci> _informacijeOIsporuci = Enumerable.Empty<InformacijeOIsporuci>().ToList();
        private List<Proizvod> _proizvodi = Enumerable.Empty<Proizvod>().ToList();
        private List<Banka> _banke = Enumerable.Empty<Banka>().ToList();

        public List<Banka> Banke
        {
            get => _banke;
            set => SetValue(ref _banke, value);
        }
        public List<Proizvod> Proizvodi
        {
            get => _proizvodi;
            set => SetValue(ref _proizvodi, value);
        }
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

        public StavkaStruktureCene StavkaStruktureCene { get; set; } = new();
        public TekuciRacunPonudjaca TekuciRacunPonudjaca { get; set; } = new();

        public PonudaPayload PonudaPayload { get; set; } = new();

        public PonudaFormViewModel(IPonudaService ponudaService,
                                   IPonudjacService ponudjacService,
                                   IProizvodService proizvodService,
                                   IInformacijeOIsporuciService informacijeOIsporuciService,
                                   IBankaService bankaService,
                                   IJavniPozivService javniPozivService)
        {
            _ponudaService = ponudaService;
            _ponudjacService = ponudjacService;
            _proizvodService = proizvodService;
            _informacijeOIsporuciService = informacijeOIsporuciService;
            _bankaService = bankaService;
            _javniPozivService = javniPozivService;
        }

        public async Task OnInit(Guid id)
        {
            var ponuda = await VratiPonudu(id);
            Ponuda = ponuda;
            JavniPozivi = (await _javniPozivService.VratiJavnePozive()).ToList();
            Ponudjaci = (await _ponudjacService.VratiPonudjace()).ToList();
            InformacijeOIsporuci = (await _informacijeOIsporuciService.VratiInformacijeOIsporuci()).ToList();
            Proizvodi = (await _proizvodService.VratiProizvode()).Data.ToList();
            Banke = (await _bankaService.VratiBanke()).ToList();
          
        }
        public async Task<Ponuda> VratiPonudu(Guid id)
        {
            var response = await _ponudaService.VratiPonudu(id);

            return response;
        }
        public void DodajStavku()
        {
            StavkaStruktureCene.Proizvod = Proizvodi.FirstOrDefault(p => p.Id == StavkaStruktureCene.Proizvod.Id);

            Ponuda.StavkeStruktureCene.Add(StavkaStruktureCene);
        }
        public void DodajTekuci()
        {
            TekuciRacunPonudjaca.Banka = Banke.FirstOrDefault(b => b.Id == TekuciRacunPonudjaca.Banka.Id);

            Ponuda.TekuciRacuniPonudjaca.Add(TekuciRacunPonudjaca);
        }
       
    }
}
