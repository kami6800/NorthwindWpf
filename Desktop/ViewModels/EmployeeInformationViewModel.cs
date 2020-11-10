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
        public EmployeeParameterCommand UpdateCommand { get; set; }
        public ParameterVoidCommand AddEmployeeTimeCommand { get; set; }
        //public Employees Boss { get; set; }

            public ObservableCollection<EmploymentTime> EmploymentTimes { get; set; }

        public EmployeeInformationViewModel(Employees employee, MainViewModel mainVM)
        {
            Employee = employee;
            AllEmployees = webService.GetAllEmployees();
            EmploymentTimes = new ObservableCollection<EmploymentTime>(Employee.EmploymentTime);
            mainViewModel = mainVM;
            UpdateCommand = new EmployeeParameterCommand(UpdateEmployee);
            AddEmployeeTimeCommand = new ParameterVoidCommand(AddEmptyEmployeeTime);
        }

        public async void UpdateEmployee(Employees employee)
        {
            employee.EmploymentTime = EmploymentTimes;
            employee.Notes = validation.ApplyLanguageFilter(employee.Notes);

            await webService.SaveEmployee(employee);
            mainViewModel.SelectedViewModel = new HRViewModel(mainViewModel);
        }

        public void AddEmptyEmployeeTime()
        {
            EmploymentTime empty = new EmploymentTime();
            empty.StartDate = DateTime.Now;
            EmploymentTimes.Add(empty);
        }
    }
}
