using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class EmploymentTime
    {
        public int EmploymentTimeId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
