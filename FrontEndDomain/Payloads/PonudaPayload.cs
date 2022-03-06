using FrontEnd.FrontEndDomain;
using System.ComponentModel.DataAnnotations;

namespace FrontEndDomain.Payloads
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
        public List<StavkaStruktureCenePayload> StavkeStruktureCene { get; set; } = Enumerable.Empty<StavkaStruktureCenePayload>().ToList();
        public List<TekuciRacunPonudjacaPayload> TekuciRacuniPonudjaca { get; set; } = Enumerable.Empty<TekuciRacunPonudjacaPayload>().ToList();
    }
}
