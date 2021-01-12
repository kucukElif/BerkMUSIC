using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
  public  class Referance:CoreEntity
    {
        public string Text { get; set; }
        public string Link { get; set; }
        public string Photo { get; set; }

    }
}
