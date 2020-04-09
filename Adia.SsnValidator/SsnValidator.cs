namespace Adia.SsnValidator
{
    public class SsnValidator
    {
        public ValidationResult Validate(string ssn, CountryCode country)
        {
            var factory = new SsnValidatorFactory();
            var validator = factory.Create(country);
            return validator.Validate(ssn);
        }
    }
}
