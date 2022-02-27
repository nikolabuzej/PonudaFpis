using ApplicationLogic.Abstractions.UseCase;
using Core.Domain.PonudaAggregate;
using Core.Domain.PonudaAggregate.Repositories;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.VratiPonudu
{
    public class VratiPonuduSlucajKoriscenja : IUseCase<VratiPonuduZahtev, VratiPonuduOdgovor>
    {
        private readonly IPonudaRepository _ponudaRepository;

        public VratiPonuduSlucajKoriscenja(IPonudaRepository ponudaRepository)
        {
            _ponudaRepository = ponudaRepository;
        }

        public async Task<VratiPonuduOdgovor> ExecuteAsync(VratiPonuduZahtev request)
        {
            Ponuda ponuda = await _ponudaRepository.VratiPonudu(request.Id).EnsureExists();

            return new() { Ponuda = ponuda };
        }
    }
}
