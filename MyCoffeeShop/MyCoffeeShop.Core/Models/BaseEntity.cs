﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public BaseEntity() 
        {
            this.Id = Guid.NewGuid().ToString();
            this.DateTime = DateTime.Now;
        }
    }
}
