using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Core.Models
{
    public class Cart : BaseEntity
    {
        public virtual ICollection<CartItem> Items { get; set; }
        public Cart() 
        {
            Items = new List<CartItem>();
        }
    }
}
