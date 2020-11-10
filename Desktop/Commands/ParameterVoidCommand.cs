using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Desktop.Commands
{
    public class ParameterVoidCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action SearchAction { get; set; }

        public ParameterVoidCommand(Action action)
        {
            SearchAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SearchAction.Invoke();
        }
    }
}
