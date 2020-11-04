using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Repository
    {
        NorthwindContext context = new NorthwindContext();

        public List<Employees> GetAllEmployees()
        {
            return context.Employees.ToList();
        }
    }
}
