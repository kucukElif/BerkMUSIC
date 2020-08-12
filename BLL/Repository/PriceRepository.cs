using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class PriceRepository : IPriceService
    {
        private readonly AppDbContext context;

        public PriceRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Price entity)
        {
            context.Prices.Add(entity);
            context.SaveChanges();
        }

        public List<Price> GetActive()
        {
            return context.Prices.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Price GetById(Guid id)
        {
            return context.Prices.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            Price price = GetById(id);
            price.Status = DAL.Entity.Enum.Status.Deleted;
            Update(price);
        }

        public void Update(Price entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
