using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Repository
{
    public class FullLayoutService : IFullLayoutService
    {
        private readonly AppDbContext context;

        public FullLayoutService(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(FullLayout entity)
        {
            context.FullLayouts.Add(entity);
            context.SaveChanges();
        }

        public void AddLayoutDetail(LayoutDetail entity)
        {
            context.LayoutDetails.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<FullLayout, bool>> exp)
        {
            return context.FullLayouts.Any(exp);
        }

        public List<FullLayout> GetActive()
        {
            return context.FullLayouts.Where(x => x.Status == DAL.Entity.Enum.Status.Active).OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public FullLayout GetById(Guid id)
        {
            return context.FullLayouts.FirstOrDefault(x => x.ID == id);
        }

        public List<FullLayout> GetDefault(Expression<Func<FullLayout, bool>> exp)
        {
            return context.FullLayouts.Where(exp).ToList();
        }

      
        public LayoutDetail GetLayoutDetail(Guid id)
        {
            return context.LayoutDetails.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            FullLayout fullLayout = GetById(id);
            fullLayout.Status = DAL.Entity.Enum.Status.Deleted;
            Update(fullLayout);
        }

        public void RemoveAll(Expression<Func<FullLayout, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);

            }
        }

        public void Update(FullLayout entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
