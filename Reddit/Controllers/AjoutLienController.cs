using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Reddit.Models.Entities;
using RedditButBetter.Models.DAL;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Policy;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Reddit.Controllers
{
    public class AjoutLienController : Controller
    {

        private readonly IHostingEnvironment environment;
        RedditContext context;
        public AjoutLienController(RedditContext context, IHostingEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        
        public IActionResult Index(int userid, bool LienAlert, string username)
        {
            ViewBag.userid = userid;
            ViewBag.LienAlert = LienAlert;
            ViewBag.username = username;
            return View();
        }

        public IActionResult RetourAccueil(int userid)
        {
            return RedirectToAction("Index", "Accueil", new { username = context.utilisateurs.Where(u => u.id == userid).First().username });
        }

        public IActionResult AjouterLien(int userid, string title, string description)
        {
            string username = context.utilisateurs.Where(c => c.id == userid).First().username;

            ViewBag.LienAlert = false;
            ViewBag.username = username;
            byte[] bytes = null;
            

            if (title != null)
            {
                    if (!Request.Form.Files.IsNullOrEmpty())
                    {

                        IFormFile f = Request.Form.Files[0];
                        using (var ms = new MemoryStream())
                        {
                            f.CopyTo(ms);
                             bytes = ms.ToArray();
                        }
                    }

                Lien lien = new Lien()
                {
                    title = title,
                    description = description,
                    userid = userid,
                    image = bytes,
                    date = DateTime.Now,
                };
                context.liens.Add(lien);
                context.SaveChanges();

                return RedirectToAction("Index", "Accueil", new { username = username });
            }
            else
            {
                return RedirectToAction("Index", new { userid = userid, LienAlert = true, username = username });
            }
             
        }
    }
}
