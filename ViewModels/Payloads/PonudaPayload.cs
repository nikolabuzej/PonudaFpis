using FrontEnd.FrontEndDomain;
using System.ComponentModel.DataAnnotations;
using ViewModels.Dtos;

namespace ViewModels.Payloads
{
    public class PonudaPayload
    {
        public Kontakt Kontakt { get; set; } = new();
        [Required]
        public string ZakonskiZastupnik { get; set; } = string.Empty;
        [Required]
        public DateTime DatumPristizanja { get; set; }
        [Required]
        public Guid PonudjacId { get; set; }
        [Required]
        public Guid JavniPozivId { get; set; }
        [Required]
        public Guid InformacijeOIsporuciId { get; set; }
        [Required]
        public StatusPonude Status { get; set; }
        public IEnumerable<StavkaStruktureCenePayload> StavkeStruktureCene { get; set; } = Enumerable.Empty<StavkaStruktureCenePayload>();
        public IEnumerable<TekuciRacunPonudjacaPayload> TekuciRacuniPonudjaca { get; set; } = Enumerable.Empty<TekuciRacunPonudjacaPayload>();
    }
}
