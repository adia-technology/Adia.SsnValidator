using System;
using Adia.SsnValidator;
using Adia.SsnValidator.Validators;
using NUnit.Framework;

namespace Adia.Ssn.Tests
{
    public class SsnValidatorFactoryTests
    {
        private SsnValidatorFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new SsnValidatorFactory();
        }

        [Test]
        public void SelectCorrectValidatorForCountry()
        {
            var validator = _factory.Create(CountryCode.CH);

            Assert.That(validator, Is.TypeOf(typeof(AhvValidator)));
        }

        [Test]
        public void ThrowExceptionForUnsupportedCountry()
        {
            Assert.Throws<NotSupportedException>(() => _factory.Create((CountryCode) 100));
        }
    }
}