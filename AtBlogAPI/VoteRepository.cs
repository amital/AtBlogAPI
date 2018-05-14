using System.Linq;

namespace AtBlogAPI.Models.Repository
{
    public class VoteRepository : Repository<Vote>
    {
        public bool VoteExists(int blogId, string votedBy)
        {
            return DbSet.Any(v => v.BlogId == blogId && v.VotedBy == votedBy);
        }
    }
}