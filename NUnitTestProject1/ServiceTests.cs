using NUnit.Framework;
using Services;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LanguageFilterTest()
        {
            ValidationWebService services = new ValidationWebService();

            string text = "Fuck you";
            string expected = "**** you";

            string result = services.ApplyLanguageFilter(text);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PhoneValidationTest()
        {
            ValidationWebService services = new ValidationWebService();
            string validNumber = "+4588888888";
            string invalidNumber = "+45588888888";

            bool valid = services.ValidPhoneNumber(validNumber);
            bool invalid = services.ValidPhoneNumber(invalidNumber);

            Assert.IsTrue(valid);
            Assert.IsFalse(invalid);
        }
    }
}