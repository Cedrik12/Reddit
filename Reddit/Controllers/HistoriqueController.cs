using Microsoft.AspNetCore.Mvc;
using Reddit.Models.DAL;
using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;

namespace Reddit.Controllers
{
    public class HistoriqueController : Controller
    {

        UtilisateurDAO dao;
        RedditContext context = new RedditContext();
        public HistoriqueController(RedditContext context)
        {
            this.context = context;
            dao = new UtilisateurDAO(context);
        }
        public IActionResult Index(string username)
        {
            ViewBag.username = username;

            return View(context.liens.Where(c => c.User.username  == username).ToList().OrderByDescending(l => l.id));
        }


        public IActionResult DeleteLien(int lienid, string username)
        {
            Lien lien = context.liens.Where(c => c.id == lienid).First();
            List<Vote> votes = context.votes.Where(c => c.lienid == lienid).ToList();
            List<Commentaire> commentaires = context.commentaires.Where(c => c.lienid == lienid).ToList();
            context.Remove(lien);
            foreach (Vote vote in votes)
            {
                context.Remove(vote);
            }
            foreach (Commentaire comm in commentaires)
            {
                context.Remove(comm);
            }
            context.SaveChanges();
            
            return RedirectToAction("Index", new {username = username});
        }
    }
}
