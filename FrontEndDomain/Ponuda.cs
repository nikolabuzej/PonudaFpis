

using FrontEndDomain.Extensions;

namespace FrontEnd.FrontEndDomain
{
    public enum StatusPonude { URazmatranju, Prihvacena, Odbijena };
    public class Ponuda
    {
        public Ponuda(Kontakt kontakt,
                     DateTime datumPristizanja,
                     string zakonskiZastupnik,
                     StatusPonude status,
                     JavniPoziv javniPoziv,
                     Ponudjac ponudjac,
                     InformacijeOIsporuci informacijeOIsporuci)
        {
            Kontakt = kontakt;
            DatumPristizanja = datumPristizanja;
            ZakonskiZastupnik = zakonskiZastupnik;
            Status = status;
            JavniPoziv = javniPoziv;
            Ponudjac = ponudjac;
            InformacijeOIsporuci = informacijeOIsporuci;
        }
        private Ponuda()
        {

        }
        public static Ponuda Default()
        {
            return new();
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public Kontakt Kontakt { get; set; } = new();
        public DateTime DatumPristizanja { get; set; } = DateTime.Now;
        public string ZakonskiZastupnik { get;set; } = string.Empty;
        public StatusPonude Status { get;  set; }
        public JavniPoziv JavniPoziv { get;  set; } = new();
        public Ponudjac Ponudjac { get;  set; } = new();
        public InformacijeOIsporuci InformacijeOIsporuci { get;  set; } = new();

        private readonly List<StavkaStruktureCene> _stavkeStruktureCene = new();
        public IReadOnlyCollection<StavkaStruktureCene> StavkeStruktureCene => _stavkeStruktureCene;

        private readonly List<TekuciRacunPonudjaca> _tekuciRacuniPonudjaca = new();
        public IReadOnlyCollection<TekuciRacunPonudjaca> TekuciRacuniPonudjaca => _tekuciRacuniPonudjaca;

        public void Update(Kontakt kontakt,
                     DateTime datumPristizanja,
                     string zakonskiZastupnik,
                     StatusPonude status,
                     JavniPoziv javniPoziv,
                     Ponudjac ponudjac,
                     InformacijeOIsporuci informacijeOIsporuci)
        {
            Kontakt = kontakt;
            DatumPristizanja = datumPristizanja;
            ZakonskiZastupnik = zakonskiZastupnik;
            Status = status;
            JavniPoziv = javniPoziv;
            Ponudjac = ponudjac;
            InformacijeOIsporuci = informacijeOIsporuci;
        }
        public void AzurirajStavkuStruktureCene(Guid id, int kolicina, double jedinicnaCenaBezPdv, double jedinicnaCenaSaPdv, Proizvod proizvod)
        {
            StavkaStruktureCene stavka = _stavkeStruktureCene.First(s => s.Id == id).EnsureExists();

            stavka.Kolicina = kolicina;
            stavka.JedinicnaCenaBezPdv = jedinicnaCenaBezPdv;
            stavka.JedinicnaCenaSaPdv = jedinicnaCenaSaPdv;
            stavka.Proizvod = proizvod;

        }
        public void DodajStavkuStruktureCene(int kolicina, double jedinicnaCenaBezPdv, double jedinicnaCenaSaPdv, Proizvod proizvod)
        {
            _stavkeStruktureCene.Add(new()
            {
                PonudaId = Id,
                Kolicina = kolicina,
                JedinicnaCenaBezPdv = jedinicnaCenaBezPdv,
                JedinicnaCenaSaPdv = jedinicnaCenaSaPdv,
                Proizvod = proizvod
            }) ;
        }
        public void DodajTekuciRacunPonudjaca(string brojRacuna, Banka banka)
        {
            _tekuciRacuniPonudjaca.Add(new()
            {
                PonudaId = Id,
                Banka = banka,
                BrojRacuna = brojRacuna,
            });
        }
        public void AzurirajTekuciRacunPonudjaca(Guid id, string brojRacuna, Banka banka)
        {
            TekuciRacunPonudjaca tekuci = _tekuciRacuniPonudjaca.First(t => t.Id == id);
            tekuci.Banka = banka;
            tekuci.BrojRacuna = brojRacuna;
        }
        public void ObrisiStavkuStruktureCene(Guid id)
        {
            StavkaStruktureCene stavka = _stavkeStruktureCene.First(x => x.Id == id);

            _stavkeStruktureCene.Remove(stavka);
        }

        public void ObrisiTekuciRacunPonudjaca(Guid id)
        {
            TekuciRacunPonudjaca racun = _tekuciRacuniPonudjaca.First(x => x.Id == id);

            _tekuciRacuniPonudjaca.Remove(racun);
        }
    }
}