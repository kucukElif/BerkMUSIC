using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    public class Post : CoreEntity
    {
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string MainContent { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImagePath { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public int ViewCount { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
