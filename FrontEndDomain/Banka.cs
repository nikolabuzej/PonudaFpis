using System.ComponentModel.DataAnnotations;

namespace FrontEnd.FrontEndDomain
{
    public class Banka
{
    [Required]
    public Guid Id { get; set; }
    public string Ime { get; set; } = string.Empty;
}
}
