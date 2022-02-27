namespace ApplicationLogic.Dtos.AzurirajPonudu
{
    public class AzurirajTekuciDto
    {
        public Guid Id { get; init; }
        public string BrojRacuna { get; init; } = string.Empty;
        public Guid BankaId { get; init; }
    }
}
