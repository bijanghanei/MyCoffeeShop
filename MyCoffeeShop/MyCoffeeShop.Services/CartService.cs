using MyCoffeeShop.Core.Contracts;
using MyCoffeeShop.Core.dto;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCoffeeShop.Services
{
    public class CartService : ICartService
    {
        public const string cartSessionName = "coffeeShopCart";
        private IRepository<MenuItem> MenuItemRepository;
        private IRepository<Cart> CartRepository;

        public CartService(IRepository<MenuItem> menuItemRepository, IRepository<Cart> cartRepository)
        {
            MenuItemRepository = menuItemRepository;
            CartRepository = cartRepository;
        }

        public Cart CreateCart(HttpContextBase httpContext)
        {
            Cart cart = new Cart();
            CartRepository.Insert(cart);
            CartRepository.Save();

            HttpCookie httpCookie = new HttpCookie(cartSessionName,cart.Id);
            httpCookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(httpCookie);

            return cart;    
        }

        public void AddToCart(HttpContextBase httpContext, string menuItemId)
        {
            Cart cart = GetCart(httpContext, true);
            MenuItem menuItem = MenuItemRepository.GetById(menuItemId);
            CartItem cartItem = cart.Items.FirstOrDefault(i => i.MenuItemId == menuItemId);
            if(cartItem == null)
            {
                cartItem = new CartItem()
                {
                    MenuItemId = menuItemId,
                    CartId = cart.Id,
                    Quantity = 1,
                };
                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            CartRepository.Save();
        }

        public void RemoveFromCart(HttpContextBase httpContext, string cartItemId)
        {
            Cart cart = GetCart(httpContext, false);
            CartItem cartItem = cart.Items.FirstOrDefault(i => i.Id == cartItemId);
            if (cart != null && cartItem != null)
            {
                cart.Items.Remove(cartItem);
                CartRepository.Save();
            }
        }

        public Cart GetCart(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(cartSessionName);
            Cart cart = new Cart();

            if (cookie != null)
            {
                string cartId = cookie.Value;
                if (string.IsNullOrEmpty(cookie.Value))
                {
                    cart = CartRepository.GetById(cartId);
                }
                else
                {
                    if (createIfNull)
                    {
                    cart = CreateCart(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    cart = CreateCart(httpContext);
                }
            }
            return cart;
        }

        public List<CartItemDto> GetCartItems(HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext, false);
            if(cart != null)
            {
                List<CartItemDto> cartItems = (from m in MenuItemRepository.GetAll()
                                               join c in cart.Items
                                               on m.Id equals c.MenuItemId
                                               select new CartItemDto() 
                                               { 
                                                   Id = c.MenuItemId,
                                                    ItemName = m.Name,
                                                    UnitPrice = m.Price,
                                                    Quantity = c.Quantity,
                                                    TotalPrice = c.Quantity*m.Price,
                                               }).ToList();
                return cartItems;
            }
            else
            {
                return new List<CartItemDto>();
            }
        }
    }
}
