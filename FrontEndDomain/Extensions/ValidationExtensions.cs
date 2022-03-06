using System.ComponentModel.DataAnnotations;

namespace FrontEndDomain.Extensions
{
    public static class ValidationExtensions
    {
        public static bool Validate<T>(this T source, List<ValidationResult> result) where T : class
        {
            result.Clear();
            ValidationContext validationContext = new ValidationContext(source);

            bool reponse = Validator.TryValidateObject(source, validationContext, result, true);

            return reponse;
        }
    }
}
