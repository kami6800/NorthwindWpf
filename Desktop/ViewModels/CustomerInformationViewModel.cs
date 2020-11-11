using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desktop.ViewModels
{
    public class CustomerInformationViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;
        public Customers Customer { get; set; }
        public List<Orders> SelectedOrders { get; set; }
        public CustomerInformationViewModel(Customers customer, MainViewModel mainVM)
        {
            mainViewModel = mainVM;
            Customer = customer;
            SelectedOrders = customer.Orders.ToList();
            SelectedOrders.Sort((a, b) =>
            {
                if (a.RequiredDate != null && b.RequiredDate != null)
                {
                    return DateTime.Compare((DateTime)b.RequiredDate, (DateTime)a.RequiredDate);
                }
                else return 0;
            });
        }
    }
}
