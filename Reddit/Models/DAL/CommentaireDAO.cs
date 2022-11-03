using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using RedditButBetter.Models.DAL;
using System.Configuration;

namespace Reddit.Models.DAL
{
    public class CommentaireDAO
    {

        private RedditContext context;

        public CommentaireDAO(RedditContext context)
        {
            this.context = context;
        }

        public IList<Commentaire> getAllCommentaire()
        {
            return context.commentaires.ToList();
        }
    }
}
