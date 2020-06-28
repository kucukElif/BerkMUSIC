using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface INavbarService
    {

        List<NavbarItem> GetActive();

        void Add(NavbarItem entity);
        void Update(NavbarItem entity);
        void Remove(Guid id);
        NavbarItem GetById(Guid id);

    }
}
