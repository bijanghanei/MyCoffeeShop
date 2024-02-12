using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MyCoffeeShop.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<MenuItem> menuItems = new List<MenuItem>();

            return View();
        }
    }
}
