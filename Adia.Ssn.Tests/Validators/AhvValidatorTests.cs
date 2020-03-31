using Adia.SsnValidator.Validators;
using NUnit.Framework;

namespace Adia.Ssn.Tests.Validators
{
    [TestFixture]
    public class AhvValidatorTests
    {
        private AhvValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new AhvValidator();
        }

        [Test]
        [TestCase("756.4089.0811.50", true)]
        [TestCase("756.5220.1643.81", true)]
        [TestCase("756.5837.4745.52", true)]
        [TestCase("756.1656.9672.13", true)]
        [TestCase("756.6168.0333.64", true)]
        [TestCase("756.0246.1057.45", true)]
        [TestCase("756.8478.9370.66", true)]
        [TestCase("756.0298.4726.97", true)]
        [TestCase("756.5113.6381.28", true)]
        [TestCase("756.5466.9658.89", true)]
        [TestCase("7561656967213", true)]
        [TestCase("756.1234.5678.95", false)]
        [TestCase("7561234567895", false)]
        [TestCase("75612345648955", false)]

        public void ValidateAhvNumberAsExpected(string ssn, bool expectedResult)
        {
            var result = _validator.Validate(ssn);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}