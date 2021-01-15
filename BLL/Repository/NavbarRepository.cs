using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class NavbarRepository : INavbarService
    {
        private readonly AppDbContext context;

        public NavbarRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(NavbarItem entity)
        {
            context.NavbarItems.Add(entity);
            context.SaveChanges();
        }

        public List<NavbarItem> GetActive()
        {
            return context.NavbarItems.Where(x => x.Status == DAL.Entity.Enum.Status.Active).OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public NavbarItem GetById(Guid id)
        {
            return context.NavbarItems.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            NavbarItem navbar = GetById(id);
            navbar.Status = DAL.Entity.Enum.Status.Deleted;
            Update(navbar);
        }

        public void Update(NavbarItem entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
