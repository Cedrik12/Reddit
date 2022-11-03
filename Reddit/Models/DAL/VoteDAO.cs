using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using System.Configuration;

namespace Reddit.Models.DAL
{
    public class VoteDAO
    {

        private RedditContext context;

        public VoteDAO(RedditContext context)
        {
            this.context = context;
        }

        public IList<Vote> getAllVote()
        {
            return context.votes.ToList();
        }
    }
}
