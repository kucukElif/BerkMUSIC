using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class HomePageVideoRepository : IHomePageVideoService
    {
        private readonly AppDbContext context;

        public HomePageVideoRepository(AppDbContext context )
        {
            this.context = context;
        }
        public void Add(HomePageVideo entity)
        {
            context.HomePageVideos.Add(entity);
            context.SaveChanges();
        }

        public List<HomePageVideo> GetActive()
        {
            return context.HomePageVideos.Where(x => x.Status == DAL.Entity.Enum.Status.Active).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public HomePageVideo GetById(Guid id)
        {
            return context.HomePageVideos.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            HomePageVideo homePageVideo = GetById(id);
            homePageVideo.Status = DAL.Entity.Enum.Status.Deleted;
            context.SaveChanges();
        }
    }
}
