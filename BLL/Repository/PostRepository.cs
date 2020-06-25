using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Repository
{
    public class PostRepository : IPostService
    {
        private readonly AppDbContext context;

        public PostRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Post entity)
        {
            context.Posts.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Post, bool>> exp)
        {
            return context.Posts.Any(exp);
        }

        public List<Post> GetActive()
        {
            return context.Posts.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Post GetById(Guid id)
        {
            return context.Posts.FirstOrDefault(x => x.ID == id);
        }

        public List<Post> GetDefault(Expression<Func<Post, bool>> exp)
        {
            return context.Posts.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Post post = GetById(id);
            post.Status = DAL.Entity.Enum.Status.Deleted;
            Update(post);
        }

        public void RemoveAll(Expression<Func<Post, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(Post entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
