using Core.Domain.PonudaAggregate;

namespace ApplicationLogic.Dtos.Ponuda
{
    public class PonudaDto
    {
        public Kontakt Kontakt { get; init; } = new();
        public string ZakonskiZastupnik { get; init; } = string.Empty;
        public DateTime DatumPristizanja { get; init; }
        public Guid PonudjacId { get; init; }
        public Guid JavniPozivId { get; init; }
        public Guid InformacijeOIsporuciId { get; init; }
        public StatusPonude Status { get; init; }
        public IEnumerable<StavkaStruktureCeneDto> StavkeStruktureCene { get; init; } = Enumerable.Empty<StavkaStruktureCeneDto>();
        public IEnumerable<TekuciRacunPonudjacaDto> TekuciRacuniPonudjaca { get; init; } = Enumerable.Empty<TekuciRacunPonudjacaDto>();

    }
}
