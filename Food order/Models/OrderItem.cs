using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Food_order.Models
{
    public partial class OrderItem
    {
        public int? Orderid { get; set; }
        public int? Menuid { get; set; }
        public decimal? Amount { get; set; }
        public int? NoofServing { get; set; }
        public decimal? Total { get; set; }
        public string Status { get; set; }
        public int ItemId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }
    }
}
