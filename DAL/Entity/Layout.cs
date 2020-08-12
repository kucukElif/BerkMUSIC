using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
   public class Layout : CoreEntity
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual LayoutDetail LayoutDetails { get; set; }

    }
}
