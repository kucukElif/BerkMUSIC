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
    public class DrumRepository : IDrumService
    {
        private readonly AppDbContext context;

        public DrumRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(DrumLesson entity)
        {
            context.DrumLessons.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<DrumLesson, bool>> exp)
        {
            return context.DrumLessons.Any(exp);
        }

        public List<DrumLesson> GetActive()
        {
            return context.DrumLessons.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public DrumLesson GetById(Guid id)
        {
            return context.DrumLessons.FirstOrDefault(x => x.ID == id);
        }

        public List<DrumLesson> GetDefault(Expression<Func<DrumLesson, bool>> exp)
        {
            return context.DrumLessons.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            DrumLesson drumLesson = GetById(id);
            drumLesson.Status = DAL.Entity.Enum.Status.Deleted;
            Update(drumLesson);
        }

        public void RemoveAll(Expression<Func<DrumLesson, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(DrumLesson entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
