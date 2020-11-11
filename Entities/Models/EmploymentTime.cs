using Desktop.Interfaces;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class EmploymentTime : ObservableObject
    {
        public int EmploymentTimeId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            { 
                _startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        private DateTime _startDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }
        private DateTime? _endDate;

        public virtual Employees Employee { get; set; }
    }
}
