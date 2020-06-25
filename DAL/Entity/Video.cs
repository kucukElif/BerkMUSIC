using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
   public class Video :CoreEntity
    {
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string VideoPath { get; set; }
    }
}
