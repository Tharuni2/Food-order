using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Food_order.Models
{
    public partial class Menu
    {
        public Menu()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Menuid { get; set; }
        public string MenuName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string FoodCategory { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
