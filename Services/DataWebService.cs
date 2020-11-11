using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Services
{
    public class DataWebService : JsonCommands
    {
        static HttpClient client = new HttpClient();
        public List<Employees> GetAllEmployees()
        {
            string url = "http://localhost:49234/api/employee";
            string json = GetJson(url);
            List<Employees> employees = JsonConvert.DeserializeObject<List<Employees>>(json);
            return employees;
        }

        public List<Customers> GetAllCustomers()
        {
            string url = "http://localhost:49234/api/Customer";
            string json = GetJson(url);
            List<Customers> customers = JsonConvert.DeserializeObject<List<Customers>>(json);
            return customers;
        }

        public List<Orders> GetOrdersByCustomer(string customerId)
        {
            string url = "http://localhost:49234/api/Order/" + customerId;
            string json = GetJson(url);
            List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(json);
            return orders;
        }

        public async Task SaveEmployee(Employees employee)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"http://localhost:49234/api/Employee/5", employee);
        }
    }
}
