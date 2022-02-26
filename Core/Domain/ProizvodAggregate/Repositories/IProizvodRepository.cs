using Core.Abrstractions;

namespace Core.Domain.ProizvodAggregate.Repositories
{
    public interface IProizvodRepository: IRepository<Proizvod>
    {
        public Task<Proizvod> VratiProizvod(Guid id);
    }
}
