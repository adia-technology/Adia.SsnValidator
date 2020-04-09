using System;
using Adia.SsnValidator;
using Adia.SsnValidator.Validators;
using NUnit.Framework;

namespace Adia.Ssn.Tests.Validators
{
    public class AhvValidatorTests
    {
        private AhvValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new AhvValidator();
        }

        [TestCase("756.4089.0811.50", ValidationResult.Valid)]
        [TestCase("756.5220.1643.81", ValidationResult.Valid)]
        [TestCase("756.5837.4745.52", ValidationResult.Valid)]
        [TestCase("756.1656.9672.13", ValidationResult.Valid)]
        [TestCase("756.6168.0333.64", ValidationResult.Valid)]
        [TestCase("756.0246.1057.45", ValidationResult.Valid)]
        [TestCase("756.8478.9370.66", ValidationResult.Valid)]
        [TestCase("756.0298.4726.97", ValidationResult.Valid)]
        [TestCase("756.5113.6381.28", ValidationResult.Valid)]
        [TestCase("756.5466.9658.89", ValidationResult.Valid)]
        [TestCase("756.1234.5678.95", ValidationResult.InvalidChecksum)]
        [TestCase("756.5466.965889", ValidationResult.InvalidFormat)]
        [TestCase("755:5466.9658.89", ValidationResult.InvalidFormat)]
        [TestCase("7561656967213", ValidationResult.InvalidFormat)]
        [TestCase("7561234567895", ValidationResult.InvalidFormat)]
        [TestCase("75612345648955", ValidationResult.InvalidFormat)]
        [TestCase("000.4089.0811.50", ValidationResult.InvalidFormat)]
        [TestCase("", ValidationResult.InvalidFormat)]
        public void GivenNonNullAhv_ShouldValidateIt(string ssn, ValidationResult expectedResult)
        {
            var result = _validator.Validate(ssn);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GivenNullAhv_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _validator.Validate(null));
        }
    }
}
