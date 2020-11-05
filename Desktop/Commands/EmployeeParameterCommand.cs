using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Desktop.Commands
{
    public class EmployeeParameterCommand : ICommand
    {
        //Repository repository = new Repository();
        public event EventHandler CanExecuteChanged;
        //public MainViewModel ViewModel { get; set; }
        private Action<Employees> SearchAction { get; set; }

        public EmployeeParameterCommand(Action<Employees> action)
        {
            //ViewModel = mainViewModel;
            SearchAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SearchAction.Invoke(parameter as Employees);
        }
    }
}
