namespace Core.Domain.Ponuda
{
    public enum StatusPonude { };
    public class Ponuda
    {
        public Guid Id { get; init ; } = Guid.NewGuid();
        public Kontakt Kontakt { get; set; } = new();
        public DateTime DatumPristizanja { get; set; } = DateTime.Now;
        public string ZakonskiZastupnik { get; set; } = string.Empty;
        public StatusPonude Status { get; set; }

        private readonly List<StavkaStruktureCene> _stavkeStruktureCene = new();
        public IReadOnlyCollection<StavkaStruktureCene> StavkeStruktureCene => _stavkeStruktureCene;



    }
}
