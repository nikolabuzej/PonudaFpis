using Core.Abrstractions;

namespace Core.Domain.PonudjacAggregate.Repositories
{
    public interface IPonudjacRepository: IRepository<Ponudjac>
    {
        public Task<Ponudjac> VratiPonudjaca(Guid id);
    }
}
