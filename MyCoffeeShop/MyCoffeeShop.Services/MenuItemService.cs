using MyCoffeeShop.Core.Contracts;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Services
{
    public class MenuItemService : IMenuItemService
    {
        private IRepository<MenuItem> repository { get; set; }

        public MenuItemService(IRepository<MenuItem> repository)
        {
            this.repository = repository;
        }

        public MenuItem GetItem(string id)
        {
            return repository.GetById(id);
        }

        public IQueryable<MenuItem> GetAllItems()
        {
            return repository.GetAll();
        }

        public void CreateItem(MenuItem item)
        {
            //MenuItem menuItem = new MenuItem()
            //{
            //    Name = item.Name,
            //    Description = item.Description,
            //    Price = item.Price,
            //    ImageURL = item.ImageURL,
            //};
            repository.Insert(item);
            repository.Save();
        }

        public void DeleteItem(string Id)
        {
            repository.DeleteById(Id);
            repository.Save();
        }

        public void UpdateItem(MenuItem item)
        {
            repository.Update(item);
            repository.Save();
        }
    }
}
