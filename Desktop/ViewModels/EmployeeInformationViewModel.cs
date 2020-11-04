using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.ViewModels
{
    public class EmployeeInformationViewModel : BaseViewModel
    {
        public Employees Employee { get; set; }
        public EmployeeInformationViewModel(Employees employee)
        {
            Employee = employee;
        }
    }
}
