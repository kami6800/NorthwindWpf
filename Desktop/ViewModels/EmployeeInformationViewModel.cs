//using DataAccess;
using Desktop.Commands;
using Entities.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Desktop.ViewModels
{
    public class EmployeeInformationViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;
        private DataWebService webService = new DataWebService();
        private ValidationWebService validation = new ValidationWebService();
        public EmployeeParameterCommand UpdateCommand { get; set; }
        public ParameterVoidCommand AddEmployeeTimeCommand { get; set; }
        public Employees Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                RaisePropertyChanged("Employee");
            }
        }
        private Employees _employee;
        public List<Employees> AllEmployees { get; set; }
        public ObservableCollection<EmploymentTime> EmploymentTimes { get; set; }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            { 
                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }
        private string _errorMessage;

        public EmployeeInformationViewModel(Employees employee, MainViewModel mainVM)
        {
            Employee = employee;
            AllEmployees = webService.GetAllEmployees();
            EmploymentTimes = new ObservableCollection<EmploymentTime>(Employee.EmploymentTime);
            mainViewModel = mainVM;
            ErrorMessage = "";
            UpdateCommand = new EmployeeParameterCommand(UpdateEmployee);
            AddEmployeeTimeCommand = new ParameterVoidCommand(AddEmptyEmployeeTime);
        }

        public async void UpdateEmployee(Employees employee)
        {
            ErrorMessage = "Saving...";

            employee.EmploymentTime = EmploymentTimes;
            employee.Notes = validation.ApplyLanguageFilter(employee.Notes);
            bool validPhoneNumber = validation.ValidPhoneNumber(employee.HomePhone);

            if (!validPhoneNumber)
            {
                ErrorMessage = "Invalid phone number";
            }
            else
            {
                await webService.SaveEmployee(employee);
                mainViewModel.SelectedViewModel = new HRViewModel(mainViewModel);
            }
        }

        public void AddEmptyEmployeeTime()
        {
            EmploymentTime empty = new EmploymentTime();
            empty.StartDate = DateTime.Now;
            EmploymentTimes.Add(empty);
        }
    }
}
