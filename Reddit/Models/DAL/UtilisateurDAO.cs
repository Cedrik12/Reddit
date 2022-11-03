using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using System.Data;

namespace Reddit.Models.DAL
{
    public class UtilisateurDAO
    {

        private RedditContext context;
       
        public UtilisateurDAO(RedditContext context)
        {
            this.context = context;
        }

        
        public List<Utilisateur> getAllUsers()
        {
            return context.utilisateurs.ToList();
        }

         public bool VerifyCredentials(string email, string password)
         {
            return context.utilisateurs.Where(c => c.email==email && c.password==password).ToList().Count() > 0 ? true : false;
         }

        public Utilisateur fetchUserByUsername(string username)
        {
            return context.utilisateurs.Where(u => u.username == username).First();
        }

        public void createNewUser(string email, string password, string username)
        {
            Utilisateur user = new Utilisateur()
            {
                username = username,
                email = email,
                password = password
            };

            context.Add<Utilisateur>(user);
            context.SaveChanges();
        }

        public Utilisateur fetchUserByEmail(string email)
        {
            return context.utilisateurs.Where(u => u.email == email).First();
        }    
     }
}
