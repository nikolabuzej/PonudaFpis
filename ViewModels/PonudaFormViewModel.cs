using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.Extensions;
using FrontEndDomain.Payloads;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class PonudaFormViewModel : BaseViewModel
    {
        private readonly IPonudaService _ponudaService;
        private readonly IPonudjacService _ponudjacService;
        private readonly IProizvodService _proizvodService;
        private readonly IInformacijeOIsporuciService _informacijeOIsporuciService;
        private readonly IBankaService _bankaService;
        private readonly IJavniPozivService _javniPozivService;


        private Ponuda _ponuda = Ponuda.Default();
        private List<JavniPoziv> _javniPozivi = Enumerable.Empty<JavniPoziv>().ToList();
        private List<Ponudjac> _ponudjaci = Enumerable.Empty<Ponudjac>().ToList();
        private List<InformacijeOIsporuci> _informacijeOIsporuci = Enumerable.Empty<InformacijeOIsporuci>().ToList();
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
        private List<ValidationResult> _stavkaValidation = Enumerable.Empty<ValidationResult>().ToList();
        private List<ValidationResult> _tekuciValidation = Enumerable.Empty<ValidationResult>().ToList();
        public List<ValidationResult> StavkaValidation
        {
            get => _stavkaValidation;
            set => SetValue(ref _stavkaValidation, value);
        }
        public List<ValidationResult> TekuciValidation
        {
            get => _tekuciValidation;
            set => SetValue(ref _tekuciValidation, value);
        }
        public StavkaStruktureCene StavkaStruktureCene { get; set; } = new();
        public TekuciRacunPonudjaca TekuciRacunPonudjaca { get; set; } = new();

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
            Ponuda = Ponuda.Default();
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
            if (StavkaStruktureCene.IsValid(StavkaValidation))
            {
                StavkaStruktureCene.Proizvod = Proizvodi.FirstOrDefault(p => p.Id == StavkaStruktureCene.Proizvod?.Id);

                Ponuda.StavkeStruktureCene.Add(StavkaStruktureCene);
            }

        }
        public void DodajTekuci()
        {
            if (TekuciRacunPonudjaca.IsValid(TekuciValidation))
            {
                TekuciRacunPonudjaca.Banka = Banke.FirstOrDefault(b => b.Id == TekuciRacunPonudjaca.Banka.Id);
                Ponuda.TekuciRacuniPonudjaca.Add(TekuciRacunPonudjaca);
            }
        }
        public void AzurirajTekuci()
        {
            if (TekuciRacunPonudjaca.Validate(TekuciValidation))
            {
                TekuciRacunPonudjaca.Banka = Banke.FirstOrDefault(b => b.Id == TekuciRacunPonudjaca.Banka.Id);

                Ponuda.AzurirajTekuciRacunPonudjaca(TekuciRacunPonudjaca.Id,
                    TekuciRacunPonudjaca.BrojRacuna,
                    TekuciRacunPonudjaca.Banka);
            }
        }
        public void AzurirajStavku()
        {
            if (StavkaStruktureCene.Validate(StavkaValidation))
            {
                StavkaStruktureCene.Proizvod = Proizvodi.FirstOrDefault(p => p.Id == StavkaStruktureCene.Proizvod.Id);

                Ponuda.AzurirajStavkuStruktureCene(StavkaStruktureCene.Id,
                                                   StavkaStruktureCene.Kolicina,
                                                   StavkaStruktureCene.JedinicnaCenaBezPdv,
                                                   StavkaStruktureCene.JedinicnaCenaSaPdv,
                                                   StavkaStruktureCene.Proizvod);
            }
        }

        public async Task AzurirajPonudu()
        {
            PonudaPayload payload = new()
            {
                DatumPristizanja = Ponuda.DatumPristizanja,
                ZakonskiZastupnik = Ponuda.ZakonskiZastupnik,
                InformacijeOIsporuciId = Ponuda.InformacijeOIsporuci.Id,
                JavniPozivId = Ponuda.JavniPoziv.Id,
                Kontakt = Ponuda.Kontakt,
                PonudjacId = Ponuda.Ponudjac.Id,
                Status = Ponuda.Status,
                StavkeStruktureCene = Ponuda.StavkeStruktureCene.Select(s => new StavkaStruktureCenePayload()
                {
                    Id = s.Id,
                    JedinicnaCenaBezPdv = s.JedinicnaCenaBezPdv,
                    JedinicnaCenaSaPdv = s.JedinicnaCenaSaPdv,
                    Kolicina = s.Kolicina,
                    ProizvodId = s.Proizvod.Id
                }).ToList(),
                TekuciRacuniPonudjaca = Ponuda.TekuciRacuniPonudjaca.Select(t => new TekuciRacunPonudjacaPayload()
                {
                    Id = t.Id,
                    BankaId = t.Banka.Id,
                    BrojRacuna = t.BrojRacuna
                }).ToList()
            };

            Ponuda = await _ponudaService.AzurirajPonudu(Ponuda.Id, payload);
        }
    }
}
