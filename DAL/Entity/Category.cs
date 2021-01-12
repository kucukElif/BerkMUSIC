using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
 public   class Category:CoreEntity
    {
        public string name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
