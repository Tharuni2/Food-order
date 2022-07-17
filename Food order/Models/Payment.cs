using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Food_order.Models
{
    public partial class Payment
    {
        public int Paymentid { get; set; }
        public int? Orderid { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PaidBy { get; set; }
        public string Status { get; set; }

        public virtual Order Order { get; set; }
    }
}
