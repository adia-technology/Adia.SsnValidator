using System;
using Adia.SsnValidator.Validators;

namespace Adia.SsnValidator
{
    public class SsnValidatorFactory
    {
        public IValidator Create(CountryCode country)
        {
            switch (country)
            {
                case CountryCode.CH:
                    return new AhvValidator();

                default:
                    throw new NotSupportedException("Your country is not supported");
            }
        }
    }
}
