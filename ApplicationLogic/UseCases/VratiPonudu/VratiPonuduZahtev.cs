using ApplicationLogic.Abstractions.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.VratiPonudu
{
    public class VratiPonuduZahtev: IRequest
    {
        public Guid Id { get; init; }
    }
}
