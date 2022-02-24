using Core.Domain.BankaAggregate;

namespace Core.Domain.PonudaAggregate
{
    public class TekuciRacunPonudjaca
    {
        public int BrojRacuna { get; set; }
        public Banka Banka { get; set; } = new Banka();

    }
}