using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Repository
    {
        /// <summary>
        /// Returns a list of all employees in the database
        /// </summary>
        /// <returns>list of all employees in the database</returns>
        public List<Employees> GetAllEmployees()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Employees.ToList();
            }
        }

        /// <summary>
        /// Update an employee to database
        /// </summary>
        /// <param name="employee">Employee to update</param>
        public void UpdateEmployee(Employees employee)
        {
            //Edits ReportsTo to match reportsToNavigation
            employee.ReportsTo = employee.ReportsToNavigation.EmployeeId;
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
