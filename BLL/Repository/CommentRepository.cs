using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Repository
{
    public class CommentRepository : ICommentService
    {
        private readonly AppDbContext context;

        public CommentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Comment entity)
        {
            context.Comments.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Comment, bool>> exp)
        {
            return context.Comments.Any(exp);
        }

        public List<Comment> GetActive()
        {
            return context.Comments.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Comment GetById(Guid id)
        {
            return context.Comments.FirstOrDefault(x => x.ID == id);
        }

        public List<Comment> GetDefault(Expression<Func<Comment, bool>> exp)
        {
          return  context.Comments.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Comment comment = GetById(id);
            comment.Status = DAL.Entity.Enum.Status.Deleted;
            context.SaveChanges();
        }

        public void RemoveAll(Expression<Func<Comment, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(Comment entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
