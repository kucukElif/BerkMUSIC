using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
  public  interface IHomePageVideoService
    {
        List<HomePageVideo> GetActive();
        void Add(HomePageVideo entity);
        HomePageVideo GetById(Guid id);
        void Remove(Guid id);
    }
}
