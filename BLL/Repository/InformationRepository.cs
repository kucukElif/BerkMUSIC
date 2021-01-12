using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
  public  class InformationRepository: IInformationService
    {
        private readonly AppDbContext context;

        public InformationRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Information entity)
        {
            context.Informations.Add(entity);
            context.SaveChanges();
        }

        public List<Information> GetActive()
        {
            return context.Informations.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Information GetById(Guid id)
        {
            return context.Informations.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            Information information = GetById(id);
            information.Status = DAL.Entity.Enum.Status.Deleted;
            Update(information);
        }

        public void Update(Information entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
