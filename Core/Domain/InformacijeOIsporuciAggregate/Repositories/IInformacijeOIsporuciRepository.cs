using Core.Abrstractions;

namespace Core.Domain.InformacijeOIsporuciAggregate.Repositories
{
    public interface IInformacijeOIsporuciRepository: IRepository<InformacijeOIsporuci>
    {
        public Task<InformacijeOIsporuci> VratiInformacijeOIsporuci(Guid id);
        public Task<IEnumerable<InformacijeOIsporuci>> VratiInformacijeOIsporuci();
    }
}
