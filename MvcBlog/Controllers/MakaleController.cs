using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    public class MakaleController : Controller
    {
        //
        // GET: /Makale/
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TariheGoreListe(int yil, int ay)
        {
            ViewBag.yil = yil;
            ViewBag.ay = ay;
            return View();
        }
        public ActionResult MakaleListele(int yil = 0, int ay = 0)
        {
            var data = context.Makales.Where(x => x.YayimTarihi.Year == yil && x.YayimTarihi.Month == ay);
            return View("MakaleListele", data);
        }

        public ActionResult Detay(int id)
        {

            ViewBag.Kullanici = Session["Kullanici"];

            Makale mk = context.Makales.FirstOrDefault(x => x.Id == id);
            //mk.Goruntulenme++; /*Makale görüntülendiği zaman görüntülenme sayısı bir artacak*/
            //context.SaveChanges();
            return View(mk);
        }

        [HttpPost]
        public ActionResult YorumYaz(Yorum yorum)
        {
            yorum.EklenmeTarihi = DateTime.Now;
            yorum.Baslik = "";
            yorum.Aktif = false;
            context.Yorums.Add(yorum);
            context.SaveChanges();
            return RedirectToAction("Detay", new { id = yorum.MakaleID });
        }
        public string Begen(int id)
        {
            Makale mak = context.Makales.FirstOrDefault(x => x.Id == id);
            mak.Begeni++;
            context.SaveChanges();
            return mak.Begeni.ToString();
        }

        public void Goruntulendi(int id)
        {
            Makale mak = context.Makales.FirstOrDefault(x => x.Id == id);
            mak.Goruntulenme++;
            context.SaveChanges();
        }
    }
}
