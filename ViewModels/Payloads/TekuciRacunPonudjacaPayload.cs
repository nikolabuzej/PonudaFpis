using System.ComponentModel.DataAnnotations;

namespace ViewModels.Payloads
{
    public class TekuciRacunPonudjacaPayload
    {
        public Guid Id { get; set; }
        [Required]
        public string BrojRacuna { get; set; } = string.Empty;
        [Required]
        public Guid BankaId { get; set; }
    }
}
