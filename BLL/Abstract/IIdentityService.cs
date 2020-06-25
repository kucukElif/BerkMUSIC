using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface IIdentityService
    {
        List<Identity> GetActive();
     
        void Add(Identity entity);
        void Update(Identity entity);
        void Remove(Guid id);
        Identity GetById(Guid id);
        
    }
}
