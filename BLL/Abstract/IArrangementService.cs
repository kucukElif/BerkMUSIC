using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
  public  interface IArrangementService
    {
        List<Arrangement> GetActive();
        List<Arrangement> GetDefault(Expression<Func<Arrangement, bool>> exp);
        void Add(Arrangement entity);
        void Update(Arrangement entity);
        void Remove(Guid id);
        Arrangement GetById(Guid id);
        void RemoveAll(Expression<Func<Arrangement, bool>> exp);
        bool Any(Expression<Func<Arrangement, bool>> exp);
    }
}
