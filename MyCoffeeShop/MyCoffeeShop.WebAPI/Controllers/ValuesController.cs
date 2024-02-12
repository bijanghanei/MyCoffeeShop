using MyCoffeeShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MyCoffeeShop.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        IMenuItemService MenuItemService;
        public ValuesController(IMenuItemService menuItemService)
        {
            MenuItemService = menuItemService;
        }

        // GET api/values
        //public List<MenuItem> Get()
        //{
        //    return MenuItemService.GetAllItems().ToList();
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
