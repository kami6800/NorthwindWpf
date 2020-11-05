using System;
using System.Collections.Generic;
using Desktop.Interfaces;

namespace Entities.Models
{
    public partial class Employees : ObservableObject
    {
        public Employees()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
            EmploymentTime = new HashSet<EmploymentTime>();
            InverseReportsToNavigation = new HashSet<Employees>();
            Orders = new HashSet<Orders>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        private string _firstName;
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }

        public virtual Employees ReportsToNavigation { get; set; }
        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual ICollection<EmploymentTime> EmploymentTime { get; set; }
        public virtual ICollection<Employees> InverseReportsToNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
