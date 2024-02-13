using MyCoffeeShop.Core.Contracts;
using MyCoffeeShop.Core.dto;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<MenuItem> menuItemRepository;
        private IRepository<Cart> cartRepository;
        private IRepository<Order> orderRepository;


        public OrderService(IRepository<MenuItem> menuItemRepository,IRepository<Cart> cartRepository, IRepository<Order> orderRepository)
        {
            this.cartRepository = cartRepository;
            this.menuItemRepository = menuItemRepository;
            this.orderRepository = orderRepository;
        }

        public Order CreatOrder(List<CartItemDto> cartItems)
        {
            Order order = new Order();
            cartItems.ForEach(i =>
            {
                OrderItem orderItem = new OrderItem()
                {
                    ItemName = i.ItemName,
                    MenuItemId = i.Id,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    TotalPrice = i.TotalPrice,
                    OrderId = order.Id,
                };
                order.Items.Add(orderItem);
            });
            orderRepository.Insert(order);
            orderRepository.Save();
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAll().ToList();
        }

        public Order GetOrder(string orderId)
        {
            return orderRepository.GetById(orderId);
        }

        public void UpdateOrder(Order order)
        {
            orderRepository.Update(order);
            orderRepository.Save();
        }
    }
}
