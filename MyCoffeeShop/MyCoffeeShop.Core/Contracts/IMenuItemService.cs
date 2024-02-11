using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Core.Contracts
{
    public interface IMenuItemService
    {
        MenuItem GetItem(string id);
        IQueryable<MenuItem> GetAllItems();
        void CreateItem(MenuItem item);
        void DeleteItem(string Id);
        void UpdateItem(MenuItem item);
    }
}
