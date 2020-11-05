using DataAccess;
using Desktop.Commands;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.ViewModels
{
    public class EmployeeInformationViewModel : BaseViewModel
    {
        Repository repository = new Repository();
        public Employees Employee { get; set; }
        public EmployeeParameterCommand UpdateCommand { get; set; }
        public EmployeeInformationViewModel(Employees employee)
        {
            Employee = employee;
            UpdateCommand = new EmployeeParameterCommand(UpdateEmployee);
        }

        public void UpdateEmployee(Employees employee)
        {
            repository.SaveEmployee(employee);
        }
    }
}
