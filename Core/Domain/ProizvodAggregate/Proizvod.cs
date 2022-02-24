using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.ProizvodAggregate
{
    public class Proizvod
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Ime { get; set; } = string.Empty;
    }
}