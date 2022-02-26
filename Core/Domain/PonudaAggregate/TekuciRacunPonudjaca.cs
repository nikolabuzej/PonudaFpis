using Core.Domain.BankaAggregate;

namespace Core.Domain.PonudaAggregate
{
    public class TekuciRacunPonudjaca
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string BrojRacuna { get; set; } = String.Empty;
        public Banka Banka { get; set; } = new Banka();

    }
}