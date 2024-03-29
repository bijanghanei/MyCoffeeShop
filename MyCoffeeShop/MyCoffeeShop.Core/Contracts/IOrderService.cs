﻿using MyCoffeeShop.Core.dto;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCoffeeShop.Core.Contracts
{
    public interface IOrderService
    {
        void CreatOrder(List<CartItemDto> cartItems);
        void UpdateOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrder(string orderId);
    }
}
