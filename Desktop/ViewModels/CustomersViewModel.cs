using Desktop.Commands;
using Desktop.Views;
using Entities.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Desktop.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        private DataWebService webService = new DataWebService();
        public SelectCustomerCommand SelectCommand { get; set; }
        public SearchCommand SearchCustomersCommand { get; set; }
        public List<Customers> AllCustomers { get; set; }
        public ObservableCollection<Customers> CustomerResults
        {
            get { return _customerResults; }
            set
            {
                _customerResults = value;
                RaisePropertyChanged("CustomerResults");
            }
        }
        private ObservableCollection<Customers> _customerResults;

        public CustomersViewModel(MainViewModel mainView)
        {
            SelectCommand = new SelectCustomerCommand(mainView);
            SearchCustomersCommand = new SearchCommand(Search);
            AllCustomers = webService.GetAllCustomers();
            CustomerResults = new ObservableCollection<Customers>(AllCustomers);
        }

        public void Search(string searched)
        {
            searched = searched.ToLower();
            List<Customers> result = AllCustomers
                .Where(x => x.CustomerId.ToLower().Contains(searched)).ToList();

            CustomerResults = new ObservableCollection<Customers>(result);
        }
    }
}
