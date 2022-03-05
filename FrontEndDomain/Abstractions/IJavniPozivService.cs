using FrontEnd.FrontEndDomain;

namespace FrontEndDomain.Abstractions
{
    public interface IJavniPozivService
    {
        public Task<IEnumerable<JavniPoziv>> VratiJavnePozive();
    }
}
