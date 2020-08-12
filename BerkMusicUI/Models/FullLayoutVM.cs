using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerkMusicUI.Models
{
    public class FullLayoutVM
    {
        public List<LayoutDetail> LayoutDetails { get; set; }
        public Layout Layout { get; set; }
    }
}
