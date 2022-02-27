using ApplicationLogic.Abstractions.UseCase;
using Core.Domain.PonudaAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.VratiPonudu
{
    public class VratiPonuduOdgovor: IResponse
    {
        public Ponuda Ponuda { get; init; } = Ponuda.Default();
    }
}
