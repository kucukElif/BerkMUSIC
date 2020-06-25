using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    public class Post : CoreEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }

    }
}
