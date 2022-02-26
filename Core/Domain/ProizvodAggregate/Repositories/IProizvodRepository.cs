namespace Core.Domain.ProizvodAggregate.Repositories
{
    public interface IProizvodRepository
    {
        public Task<Proizvod> VratiProizvod(Guid id);
    }
}
