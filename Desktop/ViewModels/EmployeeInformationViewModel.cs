//using DataAccess;
using Desktop.Commands;
using Entities.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.ViewModels
{
    public class EmployeeInformationViewModel : BaseViewModel
    {
        private DataWebService webService = new DataWebService();
        //Repository repository = new Repository();
        public Employees Employee { get; set; }
        public List<Employees> AllEmployees { get; set; }
        public EmployeeParameterCommand UpdateCommand { get; set; }
        //public Employees Boss { get; set; }

        public EmployeeInformationViewModel(Employees employee)
        {
            Employee = employee;
            UpdateCommand = new EmployeeParameterCommand(UpdateEmployee);
            AllEmployees = webService.GetAllEmployees();

            //Boss = new Employees();
            //Boss.FirstName = "theboss";
        }

        public void UpdateEmployee(Employees employee)
        {
            webService.SaveEmployee(employee);
        }
    }
}
