namespace Core.Domain.BankaAggregate.Repositories
{
    public interface IBankaRepository
    {
        public Task<Banka> VratiBanku(Guid id);
    }
}
