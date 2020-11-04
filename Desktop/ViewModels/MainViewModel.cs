using Desktop.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public UpdateViewCommand UpdateView { get; set; }
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { 
                _selectedViewModel = value;
                RaisePropertyChanged("SelectedViewModel");
            }
        }

        public MainViewModel()
        {
            SelectedViewModel = new HRViewModel(this);
            UpdateView = new UpdateViewCommand(this);
        }
    }
}
