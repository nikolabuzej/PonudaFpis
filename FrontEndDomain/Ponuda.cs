

using FrontEndDomain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.FrontEndDomain
{
    public enum StatusPonude { Pristigla, Aktivna, Obradjena };
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

        public Guid Id { get; set; }
        public Kontakt Kontakt { get; set; } = new();
        [Required]
        public DateTime DatumPristizanja { get; set; } = DateTime.Now;
        [Required]
        public string ZakonskiZastupnik { get; set; } = string.Empty;
        [Required]
        public StatusPonude Status { get; set; }
        public JavniPoziv JavniPoziv { get; set; } = new();
        public Ponudjac Ponudjac { get; set; } = new();
        public InformacijeOIsporuci InformacijeOIsporuci { get; set; } = new();

        public List<StavkaStruktureCene> StavkeStruktureCene { get; set; } = Enumerable.Empty<StavkaStruktureCene>().ToList();
        public List<TekuciRacunPonudjaca> TekuciRacuniPonudjaca { get; set; } = Enumerable.Empty<TekuciRacunPonudjaca>().ToList();

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
            StavkaStruktureCene stavka = StavkeStruktureCene.First(s => s.Id == id).EnsureExists();

            stavka.Kolicina = kolicina;
            stavka.JedinicnaCenaBezPdv = jedinicnaCenaBezPdv;
            stavka.JedinicnaCenaSaPdv = jedinicnaCenaSaPdv;
            stavka.Proizvod.Id = proizvod.Id;
            stavka.Proizvod.Ime = proizvod.Ime;

        }
        public void DodajStavkuStruktureCene(int kolicina, double jedinicnaCenaBezPdv, double jedinicnaCenaSaPdv, Proizvod proizvod)
        {
            StavkeStruktureCene.Add(new()
            {
                PonudaId = Id,
                Kolicina = kolicina,
                JedinicnaCenaBezPdv = jedinicnaCenaBezPdv,
                JedinicnaCenaSaPdv = jedinicnaCenaSaPdv,
                Proizvod = proizvod
            });
        }
        public void DodajTekuciRacunPonudjaca(string brojRacuna, Banka banka)
        {
            TekuciRacuniPonudjaca.Add(new()
            {
                PonudaId = Id,
                Banka = banka,
                BrojRacuna = brojRacuna,
            });
        }
        public void AzurirajTekuciRacunPonudjaca(Guid id, string brojRacuna, Banka banka)
        {
            TekuciRacunPonudjaca tekuci = TekuciRacuniPonudjaca.First(t => t.Id == id);
            tekuci.Banka.Id = banka.Id;
            tekuci.Banka.Ime = banka.Ime;
            tekuci.BrojRacuna = brojRacuna;
        }
        public void ObrisiStavkuStruktureCene(Guid id)
        {
            StavkaStruktureCene stavka = StavkeStruktureCene.First(x => x.Id == id);

            StavkeStruktureCene.Remove(stavka);
        }

        public void ObrisiTekuciRacunPonudjaca(Guid id)
        {
            TekuciRacunPonudjaca racun = TekuciRacuniPonudjaca.First(x => x.Id == id);

            TekuciRacuniPonudjaca.Remove(racun);
        }

        public bool IsValid(List<ValidationResult> results)
        {
            this.Validate(results);
            this.Kontakt.Validate(results);

            return !results.Any();
        }
    }
}