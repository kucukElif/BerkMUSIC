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

        public Layout GetById(Guid id)
        {
            return context.Layouts.FirstOrDefault(x => x.ID == id);
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
    }
}
