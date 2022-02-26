using ApplicationLogic.Abstractions.UseCase;
using ApplicationLogic.Dtos.Ponuda;

namespace ApplicationLogic.UseCases.KreirajPonudu
{
    public class KreirajPonuduZahtev: IRequest
    {
        public PonudaDto PonudaDto { get; init; } = new();
    }
}
