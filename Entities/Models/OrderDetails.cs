using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get{ return Quantity * UnitPrice; }
        }
    }
}
