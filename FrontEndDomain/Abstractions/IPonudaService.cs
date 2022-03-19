using FrontEnd.FrontEndDomain;
using FrontEndDomain.ListViewConfiguration;
using FrontEndDomain.Payloads;

namespace FrontEndDomain.Abstractions
{
    public interface IPonudaService
    {
        public Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber = 1,
                                                       int pageSize = 2,
                                                       SortProperty sortProperty = SortProperty.DatumPristizanja,
                                                       SortOrder sortOrder = SortOrder.desc);
        public Task<Ponuda> VratiPonudu(Guid id);
        public Task<Ponuda> AzurirajPonudu(Guid id, PonudaPayload payload);
        public Task<Ponuda> KreirajPonudu(PonudaPayload payload);
    }
}
