using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Core.Models
{
    public class Order : BaseEntity
    {
        public virtual ICollection<OrderItem> Items { get; set; }
        public Order()
        {
            this.Items = new List<OrderItem>();
        }
    }
}
