using FrontEnd.FrontEndDomain;
using FrontEndDomain.ListViewConfiguration;

namespace FrontEndDomain.Abstractions
{
    public interface IPonudaService
    {
        public Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber = 1,int pageSize = 1);
        public Task<Ponuda> VratiPonudu(Guid id);
    }
}
