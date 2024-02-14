﻿using MyCoffeeShop.Core.Contracts;
using MyCoffeeShop.Core.dto;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCoffeeShop.WebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        IOrderService orderService;
        ICartService cartService;
        public OrdersController(IOrderService orderService, ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        [HttpGet]
        [Route("api/orders/allorders")]
        public List<Order> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }
        [HttpGet]
        [Route("api/orders/{Id}")]
        public Order GetOrder(string Id)
        {
            return orderService.GetOrder(Id);
        }



        /* Just for test */

        //[HttpPost]
        //[Route("api/orders/create")]
        //public Order CreateOrder()
        //{
        //    Order order = new Order();
        //    List<CartItemDto> cartItems = cartService.GetCartItems().ToList();
        //    orderService.CreatOrderItems(order,cartItems);
        //    return order;
        //}
    }
}
