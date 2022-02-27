namespace ApplicationLogic.Dtos.AzurirajPonudu
{
    public class AzurirajStavkuDto
    {
        public Guid Id { get; init; }
        public int Kolicina { get; init; }
        public double JedinicnaCenaBezPdv { get; init; }
        public double JedinicnaCenaSaPdv { get; init; }
        public Guid ProizvodId { get; init; }
    }
}
