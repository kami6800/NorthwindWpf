//using DataAccess;
using Desktop.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Desktop.Commands
{
    public class UpdateViewCommand : ICommand
    {
        //Repository repository = new Repository();
        public event EventHandler CanExecuteChanged;
        public MainViewModel ViewModel { get; set; }

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            ViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch(parameter as string)
            {
                case "HR":
                    ViewModel.SelectedViewModel = new HRViewModel(ViewModel);
                    break;
                case "Orders":
                    ViewModel.SelectedViewModel = new OrdersViewModel();
                    break;
            }
        }
    }
}
