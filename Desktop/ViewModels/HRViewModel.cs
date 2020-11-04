using DataAccess;
using Desktop.Commands;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Desktop.ViewModels
{
    public class HRViewModel : BaseViewModel
    {
        //private MainViewModel MainView { get; set; }
        public SelectEmployeeCommand UpdateView { get; set; }
        private Repository repository = new Repository();
        private List<Employees> AllEmployees { get; set; }
        public ObservableCollection<Employees> EmployeeResults { get; set; }

        public HRViewModel(MainViewModel mainView)
        {
            //MainView = mainView;
            UpdateView = new SelectEmployeeCommand(mainView);
            AllEmployees = repository.GetAllEmployees();
            EmployeeResults = new ObservableCollection<Employees>(AllEmployees);
            Search("an");
        }

        public void Search(string searched)
        {
            searched = searched.ToLower();

            List<Employees> results = new List<Employees>();
            results = AllEmployees.Where((x) => {
                string initials = x.FirstName.ToLower().Substring(0, 2) + x.LastName.ToLower().Substring(0, 2);
                return initials.Contains(searched);
                }).ToList();

            List<Employees> results2 = AllEmployees.Where((x) => {
                string fullName = x.FirstName.ToLower() + " " + x.LastName.ToLower();
                string initials = x.FirstName.ToLower().Substring(0, 2) + x.LastName.ToLower().Substring(0, 2);
                return !(initials.Contains(searched)) && fullName.Contains(searched);
            }).ToList();

            foreach(Employees e in results2)
            {
                results.Add(e);
            }

            EmployeeResults = new ObservableCollection<Employees>(results);
        }
    }
}
