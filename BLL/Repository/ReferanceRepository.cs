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
    public class ReferanceRepository : IReferanceService
    {
        private readonly AppDbContext context;

        public ReferanceRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Referance entity)
        {
            context.Referances.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Referance, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public List<Referance> GetActive()
        {
            return context.Referances.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Referance GetById(Guid id)
        {
            return context.Referances.FirstOrDefault(x => x.ID == id);
        }

        public List<Referance> GetDefault(Expression<Func<Referance, bool>> exp)
        {
            return context.Referances.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Referance referance = GetById(id);
            referance.Status = DAL.Entity.Enum.Status.Deleted;
            Update(referance);
        }

        public void Update(Referance entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
