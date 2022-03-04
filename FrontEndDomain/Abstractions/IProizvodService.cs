using FrontEnd.FrontEndDomain;
using FrontEndDomain.ListViewConfiguration;

namespace FrontEndDomain.Abstractions
{
    public interface IProizvodService
    {
        public Task<ListViewModel<Proizvod>> VratiProizvode();
    }
}
