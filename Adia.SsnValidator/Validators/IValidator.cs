namespace Adia.SsnValidator.Validators
{
    public interface IValidator
    {
        bool Validate(string ssn);
    }
}