using System.ComponentModel.DataAnnotations;

namespace FrontEnd.FrontEndDomain
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