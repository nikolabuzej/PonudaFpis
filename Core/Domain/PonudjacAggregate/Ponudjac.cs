namespace Core.Domain.PonudjacAggregate
{
    public class Ponudjac
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Ime { get; init; } = string.Empty;
    }
}
