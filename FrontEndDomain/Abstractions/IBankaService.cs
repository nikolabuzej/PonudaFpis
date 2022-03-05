using FrontEnd.FrontEndDomain;

namespace FrontEndDomain.Abstractions
{
    public interface IBankaService
    {
        public Task<IEnumerable<Banka>> VratiBanke();
    }
}
