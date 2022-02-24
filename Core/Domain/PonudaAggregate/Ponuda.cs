using Core.Domain.BankaAggregate;
using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.JavniPozivAggregate;
using Core.Domain.ProizvodAggregate;
using Core.Extensions;

namespace Core.Domain.PonudaAggregate
{
    public enum StatusPonude { URazmatranju, Prihvacena,  Odbijena };
    public class Ponuda
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Kontakt Kontakt { get; set; } = new();
        public DateTime DatumPristizanja { get; set; } = DateTime.Now;
        public string ZakonskiZastupnik { get; set; } = string.Empty;
        public StatusPonude Status { get; set; }
        public JavniPoziv JavniPoziv { get; set; } = new();
        public InformacijeOIsporuci InformacijeOIsporuci { get; set; } = new();

        private readonly List<StavkaStruktureCene> _stavkeStruktureCene = new();
        public IReadOnlyCollection<StavkaStruktureCene> StavkeStruktureCene => _stavkeStruktureCene;

        private readonly List<TekuciRacunPonudjaca> _tekuciRacuniPonudjaca = new();
        public IReadOnlyCollection<TekuciRacunPonudjaca> TekuciRacuniPonudjaca => _tekuciRacuniPonudjaca;

        public void DodajStavkuStruktureCene(int kolicina, double jedinicnaCenaBezPdv, double jedinicnaCenaSaPdv, Proizvod proizvod)
        {
            _stavkeStruktureCene.Add(new()
            {
                JedinicnaCenaBezPdv = jedinicnaCenaBezPdv,
                JedinicnaCenaSaPdv = jedinicnaCenaSaPdv,
                Proizvod = proizvod
            });
        }
        public void DodajTekuciRacunPonudjaca(int brojRacuna,Banka banka)
        {
            _tekuciRacuniPonudjaca.Add(new()
            {
                Banka = banka,
                BrojRacuna = brojRacuna,
            });
        }
        public void ObrisiStavkuStruktureCene(Guid id)
        {
          var stavka =  _stavkeStruktureCene.FirstOrDefault(x => x.Id == id).EnsureExists();

          _stavkeStruktureCene.Remove(stavka);
        }

        public void ObrisiTekuciRacun(Guid id)
        {
            var racun  = _tekuciRacuniPonudjaca.FirstOrDefault(x => x.Id == id).EnsureExists();

            _tekuciRacuniPonudjaca.Remove(racun);
        }
    }
}