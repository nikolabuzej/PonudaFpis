using Core.Abrstractions;
using Core.ListView;

namespace Core.Domain.ProizvodAggregate.Repositories
{
    public interface IProizvodRepository: IRepository<Proizvod>
    {
        public Task<Proizvod> VratiProizvod(Guid id);
        public Task<ListView<Proizvod>> VratiProizvode(PaginationParameters parameters);
    }
}
