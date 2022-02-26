namespace Core.Domain.PonudjacAggregate.Repositories
{
    public interface IPonudjacRepository
    {
        public Task<Ponudjac> VratiPonudjaca(Guid id);
    }
}
