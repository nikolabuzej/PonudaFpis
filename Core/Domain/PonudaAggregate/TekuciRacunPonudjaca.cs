using Core.Domain.BankaAggregate;

namespace Core.Domain.PonudaAggregate
{
    public class TekuciRacunPonudjaca
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public int BrojRacuna { get; set; }
        public Banka Banka { get; set; } = new Banka();

    }
}