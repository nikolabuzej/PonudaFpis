namespace Core.Domain.InformacijeOIsporuciAggregate
{
    public class InformacijeOIsporuci
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Ime { get; set; } = string.Empty;
    }
}
