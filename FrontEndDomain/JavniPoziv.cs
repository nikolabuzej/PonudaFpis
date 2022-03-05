namespace FrontEnd.FrontEndDomain
{
    public class JavniPoziv
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Ime { get; set; } = string.Empty;
    }
}
