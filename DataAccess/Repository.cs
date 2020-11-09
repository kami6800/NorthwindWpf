using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Repository
    {
        public List<Employees> GetAllEmployees()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Employees.ToList();
            }
        }

        public void SaveEmployee(Employees employee)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
               context.Entry(employee).State = EntityState.Modified;
                //context.Employees.Update(employee);
                context.Update<Employees>(employee);
                context.SaveChanges();
            }
        }
    }
}
