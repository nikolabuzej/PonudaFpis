using FrontEndDomain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.FrontEndDomain
{ 
    public class TekuciRacunPonudjaca
    {
        public Guid Id { get; set; }
        public Guid PonudaId { get; set; }
       
        [StringLength(18)]
        [RegularExpression("[0-9]{18}")]
        [Required]
        public string BrojRacuna { get; set; } = string.Empty;

        [Required]
        public Banka Banka { get; set; } = new Banka();

        public bool IsValid(List<ValidationResult> results)
        {
            var isValid = this.Validate(results);
            
            if(Banka.Id == Guid.Empty)
            {
                isValid = false;
                results.Add(new ValidationResult("Banka cannot be empty"));
            }

            return isValid;
        }

    }
}