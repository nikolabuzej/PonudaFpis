using System.ComponentModel.DataAnnotations;

namespace Core.Domain.PonudaAggregate
{
    public class Kontakt
    {
        public string Ime { get; init; } = string.Empty;
        public string Prezime { get; init; } = string.Empty;
        [EmailAddress]
        public string Email { get; init; } = string.Empty;
        [RegularExpression(@"\+3816[0-6][0-9][0-9][0-9][0-9][0-9][0-9]")]
        public string Telefon { get; init; } = string.Empty;
        
        [RegularExpression("[0-9]{13}")]
        public string Jmbg { get; init; } = string.Empty;
    }
}