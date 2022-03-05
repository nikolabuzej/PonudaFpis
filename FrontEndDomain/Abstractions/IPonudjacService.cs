using FrontEnd.FrontEndDomain;

namespace FrontEndDomain.Abstractions
{
    public interface IPonudjacService
    {
        public Task<IEnumerable<Ponudjac>> VratiPonudjace();
    }
}
