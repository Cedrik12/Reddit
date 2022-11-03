using Microsoft.AspNetCore.Mvc;
using Reddit.Models.DAL;
using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using System;

namespace RedditButBetter.Controllers
{
    public class AccueilController : Controller
    {
        UtilisateurDAO dao;
        RedditContext context = new RedditContext();
        public AccueilController(RedditContext context)
        {
            this.context = context;
            dao = new UtilisateurDAO(context);
        }

        public IActionResult Index(string username)
        {
            ViewBag.username = username;

            return View(context.liens.ToList().OrderByDescending(c => c.getvotes()));
        }

        public IActionResult AjoutLien(string username)
        {
            ViewBag.username = username;
            return RedirectToAction("Index", "AjoutLien", new { userid = dao.fetchUserByUsername(username).id, username=username});
        }

        public IActionResult AjoutCommentaire(int lienid, string username, string texte)
        {
                Commentaire commentaire = new Commentaire()
                {
                    text = texte,
                    userid = dao.fetchUserByUsername(username).id,
                    lienid = lienid,
                    date = DateTime.Now,
                };
                context.commentaires.Add(commentaire);
                context.SaveChanges();
            return RedirectToAction("Index", "Accueil", new { username = username });
        }

        public IActionResult UpVote(int lienid, string username, int voted)
        {
            Utilisateur u = dao.fetchUserByUsername(username);
            if (voted == -1)
            {
                Vote v = new Vote()
                {
                    lienid = lienid,
                    upvote = true,
                    userid = u.id
                };
                context.votes.Add(v);
                context.SaveChanges();
            }
            else
            {
                Vote v = context.votes.Where(v => v.lienid == lienid && v.userid == u.id).First();
                v.upvote = true;
                context.votes.Update(v);
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { username = username });
        }

        public IActionResult DownVote(int lienid, string username, int voted)
        {
            Utilisateur u = dao.fetchUserByUsername(username);
            if (voted == -1)
            {
                Vote v = new Vote()
                {
                    lienid = lienid,
                    upvote = false,
                    userid = u.id
                };
                context.votes.Add(v);
                context.SaveChanges();
            }
            else
            {
                Vote v = context.votes.Where(v => v.lienid == lienid && v.userid == u.id).First();
                v.upvote = false;
                context.votes.Update(v);
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { username = username });
        }


        public IActionResult RemoveVote(int lienid, string username)
        {
            Utilisateur u = dao.fetchUserByUsername(username);
            Vote v = context.votes.Where(v => v.lienid == lienid && v.userid == u.id).First();

            context.votes.Remove(v);
            context.SaveChanges();
            return RedirectToAction("Index", new { username = username });
        }
    }
}
