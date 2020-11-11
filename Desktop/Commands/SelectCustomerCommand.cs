using Desktop.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Desktop.Commands
{
    public class SelectCustomerCommand : ICommand
    {
        //Repository repository = new Repository();
        public event EventHandler CanExecuteChanged;
        public MainViewModel ViewModel { get; set; }

        public SelectCustomerCommand(MainViewModel mainViewModel)
        {
            ViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Customers customer = parameter as Customers;
            ViewModel.SelectedViewModel = new CustomerInformationViewModel(customer, ViewModel);
        }
    }
}
