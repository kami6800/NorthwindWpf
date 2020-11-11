using Api.Controllers;
using Entities.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NUnitTestProject1
{
    public class ApiTests
    {
        [Test]
        public void GetAllCustomersTest()
        {
            CustomerController customerController = new CustomerController();

            string result = customerController.Get();

            Assert.IsTrue(result.Count() > 0);
        }

        [Test]
        public void GetAllEmployeesTest()
        {
            EmployeeController controller = new EmployeeController();

            string result = controller.Get();

            Assert.IsTrue(result.Count() > 0);
        }
    }
}