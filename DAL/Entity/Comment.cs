using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
   public class Comment :CoreEntity
    {
       
        public string Name { get; set; }
        public string MainContent { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
