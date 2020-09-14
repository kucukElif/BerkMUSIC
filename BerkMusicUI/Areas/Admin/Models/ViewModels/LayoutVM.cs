using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerkMusicUI.Areas.Admin.Models.ViewModels
{
    public class LayoutVM
    {
        public Layout Layout { get; set; }
        public List<LayoutDetail> LayoutDetails { get; set; }
        public List<FullLayout> FullLayouts { get; set; }
        public LayoutDetail LayoutDetail { get; set; }

    }
}
