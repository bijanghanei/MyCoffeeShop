using MyCoffeeShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCoffeeShop.Core.Models;



namespace MyCoffeeShop.WebAPI.Controllers.Api
{
    public class MenuController : ApiController
    {
        private IMenuItemService menuService;

        public MenuController(IMenuItemService menuService)
        {
            this.menuService = menuService;
        }


        public List<MenuItem> GetMenu()
        {
            List<MenuItem> list = menuService.GetAllItems().ToList();
            return list;
        }
    }
}
