using ApplicationLogic.Abstractions.UseCase;
using ApplicationLogic.Dtos.Ponuda;

namespace ApplicationLogic.UseCases.AzurirajPonudu
{
    public class AzurirajPonuduZahtev
    {
        public Guid Id { get; init; }
        public PonudaDto PonudaDto { get; init; } = new();
    }
}
