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
    public class ArrangementRepository : IArrangementService
    {
        private readonly AppDbContext context;

        public ArrangementRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Arrangement entity)
        {
            context.Arrangements.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Arrangement, bool>> exp)
        {
            return context.Arrangements.Any(exp);
        }

        public List<Arrangement> GetActive()
        {
            return context.Arrangements.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Arrangement GetById(Guid id)
        {
            return context.Arrangements.FirstOrDefault(x => x.ID == id);
        }

        public List<Arrangement> GetDefault(Expression<Func<Arrangement, bool>> exp)
        {
            return context.Arrangements.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Arrangement arrangement = GetById(id);
            arrangement.Status = DAL.Entity.Enum.Status.Deleted;
            Update(arrangement);
        }

        public void RemoveAll(Expression<Func<Arrangement, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(Arrangement entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
