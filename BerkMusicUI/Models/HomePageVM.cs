using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerkMusicUI.Models
{
    public class HomePageVM
    {
        public List<Identity> Identities { get; set; }
        public List<Layout> Layouts { get; set; }
        public List<NavbarItem> NavbarItems { get; set; }

    }
}
