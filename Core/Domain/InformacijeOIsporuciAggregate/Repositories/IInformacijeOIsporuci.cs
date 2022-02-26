namespace Core.Domain.InformacijeOIsporuciAggregate.Repositories
{
    public interface IInformacijeOIsporuci
    {
        public Task<InformacijeOIsporuci> VratiInformacijeOIsporuci(Guid id);
    }
}
