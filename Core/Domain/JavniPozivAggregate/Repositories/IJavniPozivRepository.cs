using Core.Abrstractions;

namespace Core.Domain.JavniPozivAggregate.Repositories
{
    public interface IJavniPozivRepository: IRepository<JavniPoziv>
    {
        public Task<JavniPoziv> VratiJavniPoziv(Guid id);
        public Task<IEnumerable<JavniPoziv>> VratiJavnePozive();
    }
}
