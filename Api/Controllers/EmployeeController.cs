using System.Collections.Generic;
using DataAccess;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
         Repository repository = new Repository();

        // GET: api/Employee
        [HttpGet]
        public string Get()
        {
            List<Employees> employees = repository.GetAllEmployees();
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return json;
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employee/5
        [HttpPut("{employee}")]
        public void Put(Employees employee/*, [FromBody]string s/*, [FromBody]Employees employee*/)
        {
            repository.SaveEmployee(employee);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
