namespace ApplicationLogic.Dtos.Ponuda
{
    public class StavkaStruktureCeneDto
    {
        public int Kolicina { get; init; }
        public double JedinicnaCenaBezPdv { get; init; }
        public double JedinicnaCenaSaPdv { get; init; }
        public Guid ProizvodId { get; init; }
    }
}
