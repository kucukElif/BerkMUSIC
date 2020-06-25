using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
   public interface IVideoService
    {

        List<Video> GetActive();
        List<Video> GetDefault(Expression<Func<Video, bool>> exp);
        void Add(Video entity);
        void Update(Video entity);
        void Remove(Guid id);
        Video GetById(Guid id);
        void RemoveAll(Expression<Func<Video, bool>> exp);
        bool Any(Expression<Func<Video, bool>> exp);
    }
}
