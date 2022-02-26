namespace Core.Domain.JavniPozivAggregate
{
    public class JavniPoziv
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Name { get; init; } = string.Empty;
    }
}
