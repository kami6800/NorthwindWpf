//using DataAccess;
using Desktop.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Desktop.Commands
{
    public class SearchCommand : ICommand
    {
        //Repository repository = new Repository();
        public event EventHandler CanExecuteChanged;
        //public MainViewModel ViewModel { get; set; }
        private Action<string> SearchAction { get; set; }

        public SearchCommand(Action<string> action)
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
            SearchAction.Invoke(parameter as string);
        }
    }
}
