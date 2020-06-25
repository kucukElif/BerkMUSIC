using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface ILayoutService
    {

        List<Layout> GetActive();
        List<Layout> GetDefault(Expression<Func<Layout, bool>> exp);
        void Add(Layout entity);
        void Update(Layout entity);
        void Remove(Guid id);
        Layout GetById(Guid id);
        void RemoveAll(Expression<Func<Layout, bool>> exp);
        bool Any(Expression<Func<Layout, bool>> exp);
    }
}
