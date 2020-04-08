namespace Adia.SsnValidator.Validators
{
    internal interface IValidator
    {
        ValidationResult Validate(string ssn);
    }
}
