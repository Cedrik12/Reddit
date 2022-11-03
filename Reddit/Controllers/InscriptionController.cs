using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Reddit.Models.DAL;
using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using static System.Net.Mime.MediaTypeNames;

namespace Reddit.Controllers
{
    public class InscriptionController : Controller
    {
        UtilisateurDAO dao;
        RedditContext context = new RedditContext();
        public InscriptionController(RedditContext context)
        {
            this.context = context;
            dao = new UtilisateurDAO(context);
            
        }
        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult InscriptionUser(string courriel, string username, string pwd)
        {
            List<Utilisateur> users = dao.getAllUsers();
            foreach (Utilisateur u in users)
            {
                if (courriel.Equals(u.email) || username.Equals(u.username))
                {
                    Console.WriteLine("Utilisateur déjà dans la base");

                    return RedirectToAction("Index", "Connexion", new {inscriptionalert = true});
                }
            }
            dao.createNewUser(courriel, pwd, username);
            Console.WriteLine($"User créer! courriel: {courriel}, username: {username}, pwd: {pwd}");
            return RedirectToAction("Index", "Accueil", new { username = username });
        }
    }
}
