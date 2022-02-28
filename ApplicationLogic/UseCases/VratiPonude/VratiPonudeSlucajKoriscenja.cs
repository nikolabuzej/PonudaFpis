using ApplicationLogic.Abstractions.UseCase;
using Core.Domain.PonudaAggregate;
using Core.Domain.PonudaAggregate.Repositories;
using Core.ListView;

namespace ApplicationLogic.UseCases.VratiPonude
{
    public class VratiPonudeSlucajKoriscenja : IUseCase<VratiPonudeZahtev, VratiPonudeOdgovor>
    {
        private readonly IPonudaRepository _ponudaRepository;

        public VratiPonudeSlucajKoriscenja(IPonudaRepository ponudaRepository)
        {
            _ponudaRepository = ponudaRepository;
        }

        public async Task<VratiPonudeOdgovor> ExecuteAsync(VratiPonudeZahtev request)
        {
            ListView<Ponuda>? ponudaList = await _ponudaRepository.VratiPonude(request.Pagination);

            return new() { Ponude = ponudaList };
        }
    }
}
