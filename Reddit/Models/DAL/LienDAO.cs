using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using System.Configuration;

namespace Reddit.Models.DAL
{
    public class LienDAO
    {
        private RedditContext context;

        public LienDAO(RedditContext context)
        {
            this.context = context;
        }

        public IList<Lien> getAllLiens()
        {
            return context.liens.ToList();
        }

    }
}
