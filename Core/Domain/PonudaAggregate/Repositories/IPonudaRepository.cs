using Core.Abrstractions;
using Core.ListView;

namespace Core.Domain.PonudaAggregate.Repositories
{
    public interface IPonudaRepository: IRepository<Ponuda>
    {
        public Task<Ponuda> VratiPonudu(Guid id);
        public Task KreirajPonudu(Ponuda ponuda);
        public Task AzurirajPonudu(Ponuda ponuda);
        public Task IzbrisiPonudu(Ponuda ponuda);

        public Task<ListView<Ponuda>> VratiPonude(PaginationParameters parameters);

    } 
}
