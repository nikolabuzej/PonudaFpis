namespace Core.Domain.JavniPozivAggregate.Repositories
{
    public interface IJavniPozivRepository
    {
        public Task<JavniPoziv> VratiJavniPoziv(Guid id);
    }
}
