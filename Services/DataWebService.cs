using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Formatting;

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

        public async void SaveEmployee(Employees employee)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"http://localhost:49234/api/Employee/5", employee);
        }
    }
}
