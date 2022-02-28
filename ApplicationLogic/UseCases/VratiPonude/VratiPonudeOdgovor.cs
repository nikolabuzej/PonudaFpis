using Core.Domain.PonudaAggregate;
using Core.ListView;

namespace ApplicationLogic.UseCases.VratiPonude
{
    public class VratiPonudeOdgovor
    {
        public ListView<Ponuda> Ponude { get; set; } = new();
    }
}
