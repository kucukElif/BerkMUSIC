using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
  public  class DrumLesson: CoreEntity 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

    }
}
