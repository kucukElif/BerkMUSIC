using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
   public class NavbarItem : CoreEntity
    {
        public short Quantity { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
