using Core.Domain.BankaAggregate;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.PonudaAggregate
{
    public class TekuciRacunPonudjaca
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid PonudaId { get; init; }
       
        [StringLength(18)]
        [RegularExpression("[0-9]{18}")]
        public string BrojRacuna { get; set; } = string.Empty;

        public Banka Banka { get; set; } = new Banka();

    }
}