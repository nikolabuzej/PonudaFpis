using ApplicationLogic.Dtos.AzurirajPonudu;

namespace ApplicationLogic.UseCases.AzurirajPonudu
{
    public class AzurirajPonuduZahtev
    {
        public Guid Id { get; init; }
        public AzurirajPonuduDto PonudaDto { get; init; } = new();
    }
}
