using DataAccess;
using Desktop.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Desktop.Commands
{
    public class SelectEmployeeCommand : ICommand
    {
        Repository repository = new Repository();
        public event EventHandler CanExecuteChanged;
        public MainViewModel ViewModel { get; set; }

        public SelectEmployeeCommand(MainViewModel mainViewModel)
        {
            ViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Employees employee = parameter as Employees;
            ViewModel.SelectedViewModel = new EmployeeInformationViewModel(employee);
        }
    }
}
