using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface IPostService
    {
        List<Post> GetActive();
        List<Post> GetDefault(Expression<Func<Post, bool>> exp);
        void Add(Post entity);
        void Update(Post entity);
        void Remove(Guid id);
        Post GetById(Guid id);
        void RemoveAll(Expression<Func<Post, bool>> exp);
        bool Any(Expression<Func<Post, bool>> exp);
    }
}
