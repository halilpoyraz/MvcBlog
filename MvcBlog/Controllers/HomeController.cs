using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryWidgetGetir()
        {
            var kat = context.Kategoris.ToList();
            return View(kat);
        }

        public ActionResult PostsWidgetGetir()
        {
            ViewBag.Fresh = context.Makales.OrderByDescending(x => x.YayimTarihi).Take(5);
            ViewBag.Popular = context.Makales.OrderByDescending(x => x.Goruntulenme).Take(5);
            return View();
        }
        public ActionResult TagsWidgetGetir()
        {
            var tags = context.Etikets.ToList();
            return View(tags);
        }

        public ActionResult TumMakalelerGetir()
        {
            var makaleler = context.Makales.ToList();
            return View("MakaleListele", makaleler);
        }
        
    }
}
