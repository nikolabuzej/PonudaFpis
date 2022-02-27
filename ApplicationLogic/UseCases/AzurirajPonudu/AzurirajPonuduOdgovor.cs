using Core.Domain.PonudaAggregate;

namespace ApplicationLogic.UseCases.AzurirajPonudu
{
    public class AzurirajPonuduOdgovor
    {
        public AzurirajPonuduOdgovor(Ponuda ponuda)
        {
            Ponuda = ponuda;
        }

        public Ponuda Ponuda { get; init; } = Ponuda.Default();
    }
}
