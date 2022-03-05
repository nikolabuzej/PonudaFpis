using System.ComponentModel.DataAnnotations;

namespace FrontEnd.FrontEndDomain
{
    public class Kontakt
    {
        [Required]
        public string Ime { get; set; } = string.Empty;
        [Required]
        public string Prezime { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [RegularExpression(@"\+3816([0-6]|9)[0-9]{6}")]
        [Required]
        public string Telefon { get; set; } = string.Empty;
        [Required]
        [RegularExpression("[0-9]{13}")]
        public string Jmbg { get; set; } = string.Empty;
    }
}