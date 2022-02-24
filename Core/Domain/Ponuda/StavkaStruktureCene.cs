using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Ponuda
{
    public class StavkaStruktureCene
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public int Kolicina { get; set; }
    }
}
