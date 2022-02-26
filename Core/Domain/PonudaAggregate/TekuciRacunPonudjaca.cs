using Core.Domain.BankaAggregate;

namespace Core.Domain.PonudaAggregate
{
    public class TekuciRacunPonudjaca
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid PonudaId { get; init; }
        public string BrojRacuna { get; set; } = string.Empty;
        public Banka Banka { get; set; } = new Banka();

    }
}