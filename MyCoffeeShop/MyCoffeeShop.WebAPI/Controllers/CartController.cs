using MyCoffeeShop.Core.Contracts;
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
    public class CartController : ApiController
    {
        ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        // GET api/<controller>
        public IEnumerable<CartItemDto> GetCartItems()
        {
            List<CartItemDto> items = cartService.GetCartItems().ToList();
            return items;
        }

    

    
        //POST api/<controller>/5
        [HttpPost]
        [Route("api/cart/add/{Id}")]
        public IHttpActionResult AddToCart(string Id)
        {
            cartService.AddToCart(Id);
            return Redirect("https://localhost:44374/api/cart");
        }



        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/cart/delete/{Id}")]
        public IHttpActionResult Delete(string Id)
        {
            cartService.RemoveFromCart(Id);
            return Redirect("https://localhost:44374/api/cart");
        }
    }
}