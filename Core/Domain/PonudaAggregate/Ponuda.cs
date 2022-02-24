using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.JavniPozivAggregate;

namespace Core.Domain.PonudaAggregate
{
    public enum StatusPonude { };
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

    }
}