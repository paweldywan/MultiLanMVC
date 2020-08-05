using MultiLanMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MultiLanMVC.Controllers
{
    public class HomeController : MyController
    {
        // GET: Home    
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Registration r)
        {
            return View(r);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);

            return RedirectToAction("Index", "Home");
        }
    }
}