namespace FrontEnd.FrontEndDomain
{
    public class JavniPoziv
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Ime { get; init; } = string.Empty;
    }
}
