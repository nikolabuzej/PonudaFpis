using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Ponuda
{
    public class Kontakt
    {
        [Required]
        public string Ime { get; init; } = string.Empty;
        
        [Required]
        public string Prezime { get; init; } = string.Empty;
       
        [EmailAddress]
        public string Email { get; init; } = string.Empty;
       
        [Phone]
        public int Telefon { get; init; }

        [MinLength(13)]
        [MaxLength(13)]
        public string Jmbg { get; init; } = string.Empty;
    }
}
