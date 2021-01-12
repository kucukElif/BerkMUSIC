using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
   public interface ICommentService
    {
        List<Comment> GetActive();
        List<Comment> GetDefault(Expression<Func<Comment, bool>> exp);
        void Add (Comment entity);
        void Update(Comment entity);
        void Remove(Guid id);
        Comment GetById(Guid id);
        void RemoveAll(Expression<Func<Comment, bool>> exp);
        bool Any(Expression<Func<Comment, bool>> exp);
    }
}
