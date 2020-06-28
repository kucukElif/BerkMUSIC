using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    public class Photo: CoreEntity
    {
        public string ImagePath { get; set; }
    }
}
