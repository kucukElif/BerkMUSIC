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
        List<LayoutDetail> GetLayoutDetails();
        List<Layout> GetLayouts();
        List<Layout> GetDefault(Expression<Func<Layout, bool>> exp);
        void Add(Layout entity);
        void AddLayoutDestail(LayoutDetail entity);
        void Update(Layout entity);
        void UpdateLayoutDetail(LayoutDetail entity);
        void Remove(Guid id);
        void RemoveDetail(Guid id);


        Layout GetById(Guid id);
        LayoutDetail GetDetailByID(Guid id);
        void RemoveAll(Expression<Func<Layout, bool>> exp);
        bool Any(Expression<Func<Layout, bool>> exp);
    }
}
