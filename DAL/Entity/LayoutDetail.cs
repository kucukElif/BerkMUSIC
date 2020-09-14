using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
   public class LayoutDetail:CoreEntity
    {
        public Guid? LayoutID { get; set; }
        public virtual Layout? Layout { get; set; }
        public Guid FullLayoutID { get; set; }
        public virtual FullLayout? FullLayout { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
