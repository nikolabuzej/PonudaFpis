namespace Core.Abrstractions
{
    public interface IUnitOfWork: IDisposable
    {
        public Task SaveChangesAsync();
    }
}
