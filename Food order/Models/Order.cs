using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Food_order.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
            Payment = new HashSet<Payment>();
        }

        public int Orderid { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Customerid { get; set; }
        public string OrderStatus { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
