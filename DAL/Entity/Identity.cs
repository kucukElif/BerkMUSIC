using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
  public  class Identity:CoreEntity
    {
        public string Name { get; set; }
        public string Specifications1 { get; set; }
        public string Specifications2 { get; set; }
        public string Specifications3 { get; set; }
        public string Specifications4 { get; set; }
        public string Objective { get; set; }
        public string ImagePath { get; set; }
    }
}
