using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AtBlogAPI.Models
{
    public class Repository<T> where T : class //, IDisposable
    {
        private readonly BlogContext _ctx = new BlogContext();

        protected DbSet<T> DbSet { get; set; }
        public Repository()
        {
            DbSet = _ctx.Set<T>();
            _ctx.Database.Log = Console.WriteLine;
        }
        public IList<T> GetAll()
        {
           return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public T Find(params Object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public int SaveChanges()
        {
            return _ctx.SaveChanges();
        }
    }
}