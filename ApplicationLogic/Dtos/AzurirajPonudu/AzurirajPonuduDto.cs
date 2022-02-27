using Core.Domain.PonudaAggregate;

namespace ApplicationLogic.Dtos.AzurirajPonudu
{
    public class AzurirajPonuduDto
    {

        public Kontakt Kontakt { get; init; } = new();
        public string ZakonskiZastupnik { get; init; } = string.Empty;
        public DateTime DatumPristizanja { get; init; }
        public Guid PonudjacId { get; init; }
        public Guid JavniPozivId { get; init; }
        public Guid InformacijeOIsporuciId { get; init; }
        public StatusPonude Status { get; init; }
        public IEnumerable<AzurirajStavkuDto> StavkeStruktureCene { get; init; } = Enumerable.Empty<AzurirajStavkuDto>();
        public IEnumerable<AzurirajTekuciDto> TekuciRacuniPonudjaca { get; init; } = Enumerable.Empty<AzurirajTekuciDto>();
    }
}
