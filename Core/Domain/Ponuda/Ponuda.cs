using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Ponuda
{
    public enum StatusPonude { };
    public class Ponuda
    {
        public Guid Id { get; init ; } = Guid.NewGuid();
        public Kontakt Kontakt { get; set; } = new();
        public DateTime DatumPristizanja { get; set; } = DateTime.Now;
        public string ZakonskiZastupnik { get; set; } = string.Empty;
        public StatusPonude Status { get; set; }
        public IEnumerable<StavkaStruktureCene> StavkeStruktureCene { get; private set; } = new List<StavkaStruktureCene>();

    }
}
