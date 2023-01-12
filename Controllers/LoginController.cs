using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var giris = c.Admins.FirstOrDefault(x=>x.Kullanici == ad.Kullanici && x.Sifre== ad.Sifre);
            if (giris != null)
            {
                FormsAuthentication.SetAuthCookie(giris.Kullanici, false);
                Session["Kullanici"] = giris.Kullanici.ToString();
                return RedirectToAction("Index","Admin");
            }
            else { return View(); }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}