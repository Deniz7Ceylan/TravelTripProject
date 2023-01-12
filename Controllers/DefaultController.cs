using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).ToList();
            return View(degerler);
        }
        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult PartialSliderOne()
        {
            var degerler = c.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult PartialSliderTwo()
        {
            var degerler = c.Blogs.Where(x => x.ID==1).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult PartialTopTen()
        {
            var deger = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialFour()
        {
            var deger = c.Blogs.Take(3).ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialFive()
        {
            var deger = c.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }
    }
}