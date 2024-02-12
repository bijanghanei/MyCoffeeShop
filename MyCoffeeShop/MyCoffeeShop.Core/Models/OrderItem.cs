using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Core.Models
{
    public class OrderItem : BaseEntity
    {
        public string ItemName { get; set; }
        public string OrderId { get; set; }
        public string MenuItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
