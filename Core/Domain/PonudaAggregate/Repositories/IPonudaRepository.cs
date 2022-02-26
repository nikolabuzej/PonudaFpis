namespace Core.Domain.PonudaAggregate.Repositories
{
    public interface IPonudaRepository
    {
        public Task<Ponuda> VratiPonudu(Guid id);
        public Task KreirajPonudu(Ponuda ponuda);
        public Task AzurirajPonudu(Ponuda ponuda);
        public Task IzbrisiPonudu(Guid id);
    } 
}
