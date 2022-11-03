using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reddit.Models.DAL;
using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using System.Configuration;

namespace Reddit.Controllers
{
    public class ConnexionController : Controller
    {
        UtilisateurDAO dao;
        RedditContext context = new RedditContext();
        public ConnexionController(RedditContext context)
        {
            this.context = context;
            dao = new UtilisateurDAO(context);
        }

        public IActionResult Index(string username, bool inscriptionalert)
        {
            ViewBag.username = username;
            ViewBag.inscriptionalert = inscriptionalert;
            return View();
        }

        public IActionResult ConnexionUser(string courriel, string pwd)
        {
            ViewBag.inscriptionalert = false;
            if (dao.VerifyCredentials(courriel, pwd))
            {
                ViewBag.connexionalert = false;
                Console.WriteLine("Tester vos credentials " + courriel + pwd);
                string username = dao.fetchUserByEmail(courriel).username;
                ViewBag.username = username;
                return RedirectToAction("Index", "Accueil", new { username = username }) ;
                //return RedirectToAction("display");
            }
            ViewBag.connexionalert = true;
            return View("index");
        }
        public IActionResult RecentConnexion(string username)
        {
            return RedirectToAction("Index", "Accueil", new { username = username });
        }
    }
}
