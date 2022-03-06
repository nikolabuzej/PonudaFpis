using FrontEnd.FrontEndDomain;
using FrontEndDomain.ListViewConfiguration;
using FrontEndDomain.Payloads;

namespace FrontEndDomain.Abstractions
{
    public interface IPonudaService
    {
        public Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber = 1,int pageSize = 1);
        public Task<Ponuda> VratiPonudu(Guid id);
        public Task<Ponuda> AzurirajPonudu(Guid id,PonudaPayload payload);
    }
}
