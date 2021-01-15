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
    public class VideoRepository : IVideoService
    {
        private readonly AppDbContext context;

        public VideoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Video entity)
        {
            context.Videos.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Video, bool>> exp)
        {
            return context.Videos.Any(exp);
        }

        public List<Video> GetActive()
        {
            return context.Videos.Where(x => x.Status == DAL.Entity.Enum.Status.Active).OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public Video GetById(Guid id)
        {
            return context.Videos.FirstOrDefault(x => x.ID == id);

        }

        public List<Video> GetDefault(Expression<Func<Video, bool>> exp)
        {
            return context.Videos.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Video video = GetById(id);
            video.Status = DAL.Entity.Enum.Status.Deleted;
            Update(video);
        }

        public void RemoveAll(Expression<Func<Video, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(Video entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
