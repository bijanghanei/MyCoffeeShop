using MyCoffeeShop.Core.Contracts;
using MyCoffeeShop.Core.dto;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public Cart CreateCart()
        {
            Cart cart = new Cart();
            CartRepository.Insert(cart);
            CartRepository.Save();

            HttpCookie httpCookie = new HttpCookie(cartSessionName);
            httpCookie.Expires = DateTime.Now.AddDays(1);
            httpCookie.Value = cart.Id;
            HttpContext.Current.Response.Cookies.Add(httpCookie);
            return cart;    
        }

        public void AddToCart(string menuItemId)
        {
            Cart cart = GetCart(true);
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

        public void RemoveFromCart(string cartItemId)
        {
            Cart cart = GetCart(false);
            CartItem cartItem = cart.Items.FirstOrDefault(i => i.Id == cartItemId);
            if (cart != null && cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cart.Items.Remove(cartItem);
                }
                CartRepository.Save();
            }
        }

        public Cart GetCart(bool createIfNull)
        {
            string cookieValue = HttpContext.Current.Request.Cookies.Get(cartSessionName).Value;
            Cart cart = new Cart();

            if (!string.IsNullOrEmpty(cookieValue))
            {
                string cartId = cookieValue;
                if (!string.IsNullOrEmpty(cookieValue))
                {
                    cart = CartRepository.GetById(cartId);
                }
                else
                {
                    if (createIfNull)
                    {
                    cart = CreateCart();
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    cart = CreateCart();
                }
            }
            return cart;
        }

        public List<CartItemDto> GetCartItems()
        {
            Cart cart = GetCart(false);
            if(cart != null)
            {
                List<CartItemDto> cartItems = (from c in cart.Items
                                               join m in MenuItemRepository.GetAll()
                                               on c.MenuItemId equals m.Id
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
