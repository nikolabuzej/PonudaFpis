using ApplicationLogic.Abstractions.UseCase;
using Core.Domain.PonudaAggregate.Repositories;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.IzbrisiPonudu
{
    public class IzbrisiPonuduSlucajKoriscenja : IUseCase<IzbrisiPonuduZahtev>
    {
        private readonly IPonudaRepository _ponudaRepository;

        public IzbrisiPonuduSlucajKoriscenja(IPonudaRepository ponudaRepository)
        {
            _ponudaRepository = ponudaRepository;
        }

        public async Task ExecuteAsync(IzbrisiPonuduZahtev request)
        {
            var ponuda = await _ponudaRepository.VratiPonudu(request.Id).EnsureExists();

            await _ponudaRepository.IzbrisiPonudu(ponuda);
            await _ponudaRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
