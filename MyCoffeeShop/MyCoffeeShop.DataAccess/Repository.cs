﻿using MyCoffeeShop.Core.Contracts;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DataContext _context;
        private DbSet<T> dbSet;

        public void DeleteById(string Id)
        {
            
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public T GetById(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            
        }
    }
}
