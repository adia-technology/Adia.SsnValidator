using System;
using NUnit.Framework;

namespace Adia.SsnValidator.Tests
{
    public class SsnValidatorTests
    {
        private SsnValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new SsnValidator();
        }

        [Test]
        public void GivenCorrectSwissArguments_ShouldRunSwissSsnValidation()
        {
            var result = _validator.Validate("756.4089.0811.50", CountryCode.CH);
            Assert.AreEqual(result, ValidationResult.Valid);
        }

        [Test]
        public void GivenIncorrectCountryCode_ShouldThrowExceptiom()
        {
           Assert.Throws<NotSupportedException>(() => _validator.Validate("756.4089.0811.50", (CountryCode) 100));
        }
    }
}
