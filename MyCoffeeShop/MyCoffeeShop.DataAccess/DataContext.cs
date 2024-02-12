using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.DataAccess
{
    public class DataContext :DbContext
    {
        DbSet<MenuItem> menuItems { get; set; }
        DbSet<Cart> carts { get; set; }

        DbSet<CartItem> cartItems { get; set; }
        DbSet<Order> orders { get; set; }
        DbSet<OrderItem> orderItems { get; set; }
        public DataContext() : base("DefaultConnection") {}
    }
}
