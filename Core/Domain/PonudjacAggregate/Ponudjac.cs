namespace Core.Domain.PonudjacAggregate
{
    public class Ponudjac
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = string.Empty;
    }
}
