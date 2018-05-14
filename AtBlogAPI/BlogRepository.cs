using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtBlogAPI.Models.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        public IList<Blog> GetTopPosts()
        {
            return DbSet.OrderByDescending(b => b.TotalVotes)
                        .ThenByDescending(b=>b.CreationDate)
                        .ToList();
        }
    }
}