using MyCoffeeShop.Core.Contracts;
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
    }
}
