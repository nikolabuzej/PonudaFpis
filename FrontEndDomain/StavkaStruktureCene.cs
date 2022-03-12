using FrontEndDomain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.FrontEndDomain
{
    public class StavkaStruktureCene
    {
        public Guid Id { get; set; }

        public Guid PonudaId { get; set; }

        [Range(1, 100)]
        public int Kolicina { get; set; } = 1;

        [Range(1, double.MaxValue)]
        public double JedinicnaCenaSaPdv { get; set; } = 1;

        [Range(1, double.MaxValue)]
        public double JedinicnaCenaBezPdv { get; set; } = 1;
        [Required]
        public Proizvod Proizvod { get; set; } = new();

        public bool IsValid(List<ValidationResult> results)
        {
            var isValid = this.Validate(results);
            if (Proizvod.Id == Guid.Empty)
            {
                isValid = false;
                results.Add(new ValidationResult("Proizvod cannot be empty"));
            }

            return isValid;
        }

    }
}