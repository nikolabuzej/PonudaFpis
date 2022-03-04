namespace FrontEnd.FrontEndDomain
{
    public class Proizvod
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Ime { get; set; } = string.Empty;
    }
}