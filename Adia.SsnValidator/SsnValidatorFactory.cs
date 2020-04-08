using System;
using Adia.SsnValidator.Validators;

namespace Adia.SsnValidator
{
    internal class SsnValidatorFactory
    {
        public IValidator Create(CountryCode country)
        {
            switch (country)
            {
                case CountryCode.CH:
                    return new AhvValidator();

                default:
                    throw new NotSupportedException($"The provided country ({country}) is not supported.");
            }
        }
    }
}
