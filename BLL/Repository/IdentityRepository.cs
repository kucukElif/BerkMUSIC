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
    public class IdentityRepository : IIdentityService
    {
        private readonly AppDbContext context;

        public IdentityRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Identity entity)
        {
            context.Identities.Add(entity);
            context.SaveChanges();
        }

       

        public List<Identity> GetActive()
        {
            return context.Identities.Where(x => x.Status == DAL.Entity.Enum.Status.Active).OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public Identity GetById(Guid id)
        {
            return context.Identities.FirstOrDefault(x => x.ID == id);
        }

      

        public void Remove(Guid id)
        {
            Identity identity = GetById(id);
            identity.Status = DAL.Entity.Enum.Status.Deleted;
            Update(identity);
        }

      

        public void Update(Identity entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
