using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;



namespace Tests
{
    [TestClass]
    public class ServiceTests
    {


        [TestMethod]
        public void LanguageFilterTest()
        {
            //ValidationWebService services = new ValidationWebService();

            string text = "Fuck you";
            string expected = "**** you";

           // string result = services.ApplyLanguageFilter(text);

            Assert.AreEqual(expected, text);
        }
    }
}
