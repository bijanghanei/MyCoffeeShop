using MyCoffeeShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCoffeeShop.Core.Models;

namespace MyCoffeeShop.WebAPI.Controllers
{
    public class MenuController : ApiController
    {
        IMenuItemService menuService;

        public MenuController(IMenuItemService menuService)
        {
            this.menuService = menuService;
        }

        //GET api/<controller>
        public IEnumerable<MenuItem> GetMenu()
        {
            IEnumerable<MenuItem> list = menuService.GetAllItems().ToList();
            return list;
        }

        // GET api/<controller>/5
        public MenuItem GetItem(string Id)
        {
            return menuService.GetItem(Id);
        }


        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateItem(MenuItem item)
        {
            menuService.CreateItem(item);
            return Redirect("https://localhost:44374/api/menu");
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Update(string Id,MenuItem item)
        {
            MenuItem menuItem = menuService.GetItem(Id);
            menuService.UpdateItem(menuItem);
            return Redirect("https://localhost:44374/api/menu");
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(string Id)
        {
            menuService.DeleteItem(Id);
            return Redirect("https://localhost:44374/api/menu");
        }
    }
}