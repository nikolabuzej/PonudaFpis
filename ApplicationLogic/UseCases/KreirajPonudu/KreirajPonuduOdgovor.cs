using Core.Domain.PonudaAggregate;

namespace ApplicationLogic.UseCases.KreirajPonudu
{
    public class KreirajPonuduOdgovor 
    { 
        public KreirajPonuduOdgovor(Ponuda ponuda)
        {
            Ponuda = ponuda;
        }
        public KreirajPonuduOdgovor()
        {

        }
        public Ponuda Ponuda { get; init; } = Ponuda.Default();
    }
}
