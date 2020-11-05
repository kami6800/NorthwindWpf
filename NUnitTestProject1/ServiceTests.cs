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
    }
}