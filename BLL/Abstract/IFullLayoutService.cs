using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
   public interface IFullLayoutService
    {

        List<FullLayout> GetActive();

        //List<FullLayout> ListByLayout(Guid id);
        List<FullLayout> GetDefault(Expression<Func<FullLayout, bool>> exp);
        void Add(FullLayout entity);
        void Update(FullLayout entity);
        void Remove(Guid id);
        void AddLayoutDetail(LayoutDetail entity);
        LayoutDetail GetLayoutDetail(Guid id);

        FullLayout GetById(Guid id);
        void RemoveAll(Expression<Func<FullLayout, bool>> exp);
        bool Any(Expression<Func<FullLayout, bool>> exp);
    }
}
