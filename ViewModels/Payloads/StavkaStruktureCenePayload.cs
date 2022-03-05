using System.ComponentModel.DataAnnotations;

namespace ViewModels.Dtos
{
    public class StavkaStruktureCenePayload
    {

        public Guid Id { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public double JedinicnaCenaBezPdv { get; set; }
        [Required]
        public double JedinicnaCenaSaPdv { get; set; }
        [Required]
        public Guid ProizvodId { get; set; }
    }
}
