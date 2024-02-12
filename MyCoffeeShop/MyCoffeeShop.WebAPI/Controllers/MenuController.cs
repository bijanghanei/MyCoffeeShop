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
        public List<MenuItem> GetMenu()
        {
            List<MenuItem> list = menuService.GetAllItems().ToList();
            return list;
        }

        // GET api/<controller>/5
        public MenuItem GetItem(string Id)
        {
            return menuService.GetItem(Id);
        }


        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}