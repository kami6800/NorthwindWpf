﻿//using DataAccess;
using Desktop.Commands;
using Entities.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Desktop.ViewModels
{
    public class HRViewModel : BaseViewModel
    {
        private DataWebService webService = new DataWebService();
        //private MainViewModel MainView { get; set; }
        public SelectEmployeeCommand UpdateView { get; set; }
        public SearchCommand SearchEmployees { get; set; }
        //private Repository repository = new Repository();
        private List<Employees> AllEmployees { get; set; }
        private ObservableCollection<Employees> _employeeResults;
        public ObservableCollection<Employees> EmployeeResults
        {
            get { return _employeeResults; }
            set
            {
                _employeeResults = value;
                RaisePropertyChanged("EmployeeResults");
            }
        }

        public HRViewModel(MainViewModel mainView)
        {
            //MainView = mainView;
            UpdateView = new SelectEmployeeCommand(mainView);
            SearchEmployees = new SearchCommand(Search);
            AllEmployees = webService.GetAllEmployees();
            EmployeeResults = new ObservableCollection<Employees>(AllEmployees);
            //Search("an");
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
                //string region = x.Region==null?"Unknown region" 
                return !(initials.Contains(searched)) && 
                (fullName.Contains(searched) ||
                x.Country.ToLower() == searched ||
                x.Region.ToLower() == searched);
            }).ToList();

            foreach(Employees e in results2)
            {
                results.Add(e);
            }

            EmployeeResults = new ObservableCollection<Employees>(results);
        }
    }
}
