using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class PhotoRepository : IPhotoService
    {
        private readonly AppDbContext context;

        public PhotoRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Photo entity)
        {
            context.Photos.Add(entity);
            context.SaveChanges();
        }

        public List<Photo> GetActive()
        {
           return context.Photos.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Photo GetById(Guid id)
        {
            return context.Photos.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            Photo photo = GetById(id);
            photo.Status = DAL.Entity.Enum.Status.Deleted;
            Update(photo);
        }

        public void Update(Photo entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
