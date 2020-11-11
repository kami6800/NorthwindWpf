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
                return context.Employees.Include(x=>x.EmploymentTime).ToList();
            }
        }

        public List<Customers> GetAllCustomers()
        {
            //using(NorthwindContext context = new NorthwindContext())
            //{
            //    return context.Customers.Include(x => x.Orders).ToList();
            //}

            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Customers
                    .Include(x => x.Orders).ThenInclude(x => x.OrderDetails)//.ThenInclude(x => x.Product)
                    .ToList();
            }
        }

        public List<Orders> GetOrdersByCustomer(string customerId)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return context.Orders
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                    .Where(x => x.CustomerId == customerId)
                    .ToList();
            }
        }

        /// <summary>
        /// Update an employee to database
        /// </summary>
        /// <param name="employee">Employee to update</param>
        public void UpdateEmployee(Employees employee)
        {
            //Edits ReportsTo to match reportsToNavigation
            if(employee.ReportsToNavigation!=null)
                employee.ReportsTo = employee.ReportsToNavigation.EmployeeId;

            using (NorthwindContext context = new NorthwindContext())
            {
               context.Entry(employee).State = EntityState.Modified;
                //context.Employees.Update(employee);
                context.Update<Employees>(employee);

                //Loops through each EmploymentTime record to make sure they're saved alongside the employee
                foreach(EmploymentTime e in employee.EmploymentTime)
                {
                    context.EmploymentTime.Update(e);
                }
                context.SaveChanges();
            }
        }
    }
}
