using FrontEnd.FrontEndDomain;

namespace FrontEndDomain.Abstractions
{
    public interface IProizvodService
    {
        public Task<IEnumerable<Proizvod>> VratiProizvode();
    }
}
