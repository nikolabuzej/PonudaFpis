using ApplicationLogic.Abstractions.UseCase;
using Core.Domain.PonudaAggregate.Repositories;

namespace ApplicationLogic.UseCases.KreirajPonudu
{
    public class KreirajPonuduSlucajKoriscenja : IUseCase<KreirajPonuduZahtev, KreirajPonuduOdgovor>
    {
        private readonly IPonudaRepository ponudaRepository;
        public Task<KreirajPonuduOdgovor> ExecuteAsync(KreirajPonuduZahtev request)
        {
            throw new NotImplementedException();
        }
    }
}
