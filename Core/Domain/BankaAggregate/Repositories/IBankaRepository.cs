using Core.Abrstractions;

namespace Core.Domain.BankaAggregate.Repositories
{
    public interface IBankaRepository: IRepository<Banka>
    {
        public Task<Banka> VratiBanku(Guid id);
    }
}
