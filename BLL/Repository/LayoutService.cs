using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Repository
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext context;

        public LayoutService(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Layout entity)
        {
            context.Layouts.Add(entity);
            context.SaveChanges();
        }
     
        public bool Any(Expression<Func<Layout, bool>> exp)
        {
           return context.Layouts.Any(exp);
        }

        public List<Layout> GetActive()
        {
            return context.Layouts.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }
        public List<FullLayout> GetFullLayout()
        {
            return context.FullLayouts.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

       
        public Layout GetById(Guid id)
        {
            return context.Layouts.Where(x => x.ID == id).FirstOrDefault();
        }

      

        public List<Layout> GetDefault(Expression<Func<Layout, bool>> exp)
        {
            return context.Layouts.Where(exp).ToList();
        }

       


        public void Remove(Guid id)
        {
            Layout layout = GetById(id);
            layout.Status = DAL.Entity.Enum.Status.Deleted;
            Update(layout);
        }

        public void RemoveAll(Expression<Func<Layout, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

      

        public void Update(Layout entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public List<LayoutDetail> GetLayoutDetails()
        {
            return context.LayoutDetails.ToList();
        }

        public List<Layout> GetLayouts()
        {
            return context.Layouts.ToList();
        }

        public void AddLayoutDestail(LayoutDetail entity)
        {

            context.LayoutDetails.Add(entity);
            context.SaveChanges();
        }

        public void UpdateFullLayout(LayoutDetail entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public LayoutDetail GetDetailByID(Guid id)
        {
            return context.LayoutDetails.Where(x => x.ID == id).FirstOrDefault();
        }

        public void RemoveDetail(Guid id)
        {
            LayoutDetail layout = GetDetailByID(id);
            layout.Status = DAL.Entity.Enum.Status.Deleted;
            UpdateFullLayout(layout);
        }
    }
}
