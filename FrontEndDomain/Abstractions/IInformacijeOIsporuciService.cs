using FrontEnd.FrontEndDomain;

namespace FrontEndDomain.Abstractions
{
    public interface IInformacijeOIsporuciService
    {
        public Task<IEnumerable<InformacijeOIsporuci>> VratiInformacijeOIsporuci();
    }
}
