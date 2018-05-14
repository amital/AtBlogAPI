using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AtBlogAPI.Models
{
    public class BlogContextInitialyzer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext ctx)
        {
            ctx.Blogs.Add(new Blog {CreatedBy = "John", CreationDate = DateTime.Now, Text = "My first blog Entry"});
            ctx.Blogs.Add(new Blog {CreatedBy = "John", CreationDate = DateTime.Now, Text = "My second blog Entry"});
            ctx.Blogs.Add(new Blog {CreatedBy = "Amitai", CreationDate = DateTime.Now, Text = "Hi Look I'm blogging!"});
        }
    }

//    public class BlogDataContext : DbContext
//    {
//    }
}