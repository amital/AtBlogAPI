using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;

namespace AtBlogAPI.Models
{
    public class BlogContext: DbContext
    {
        public BlogContext() : base("name=AtBlog")
        {
            Database.Log = x => Debug.WriteLine(x);
        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasIndex(p => new {p.TotalVotes, p.CreationDate});
        }

    }
}