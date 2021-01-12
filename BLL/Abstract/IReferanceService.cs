using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
   public interface IReferanceService
    {
        List<Referance> GetActive();
        List<Referance> GetDefault(Expression<Func<Referance, bool>> exp);
        void Add (Referance entity);
        void Update(Referance entity);
        void Remove(Guid id);
        Referance GetById(Guid id);
        bool Any(Expression<Func<Referance, bool>> exp);
    }
}
