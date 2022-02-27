using ApplicationLogic.Abstractions.UseCase;
using Core.Domain.PonudaAggregate;

namespace ApplicationLogic.UseCases.VratiPonudu
{
    public class VratiPonuduOdgovor
    {
        public Ponuda Ponuda { get; init; } = Ponuda.Default();
    }
}
