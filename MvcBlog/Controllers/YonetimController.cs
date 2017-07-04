using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    using Models;
    //[Authorize(Roles=CustomRoles.Admin + "," + CustomRoles.Yazar)]
    [Authorize(Roles = "Admin")]
    //[Authorize(Roles = "Yazar")]

    public class YonetimController : Controller
    {
        //
        // GET: /Yonetim/
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            ViewBag.Tip = 1;
            return View(context.Makales.ToList());
        }
        public ActionResult MakaleYaz()
        {
            ViewBag.Tip = 1;
            ViewBag.Kategoriler = context.Kategoris.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MakaleYaz(Makale makale, HttpPostedFileBase Resim, string etiketler)
        {
            if (makale != null)
            {
                Kullanici aktif = Session["Kullanici"] as Kullanici;
                makale.YayimTarihi = DateTime.Now;
                makale.MakaleTipID = 1;
                makale.YazarID = aktif.Id;
                makale.KapakResimID = ResimKaydet(Resim, HttpContext);
                context.Makales.Add(makale);
                context.SaveChanges();

                string[] etikets = etiketler.Split(',');
                foreach (string etiket in etikets)
                {
                    Etiket etk = context.Etikets.FirstOrDefault(x => x.Adi.ToLower() == etiket.ToLower().Trim());
                    if (etk == null)
                    {
                        etk = new Etiket();
                        etk.Adi = etiket;
                        context.Etikets.Add(etk);
                        context.SaveChanges();

                        //EtiketYok
                    }
                    makale.Etikets.Add(etk);
                    context.SaveChanges();
                }
            }


            return RedirectToAction("Index");
        }

        public static int ResimKaydet(HttpPostedFileBase Resim, HttpContextBase ctx)
        {
            BlogContext context = new BlogContext();

            int kucukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["kw"]);
            int kucukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["kh"]);
            int ortaWidth = Convert.ToInt32(ConfigurationManager.AppSettings["ow"]);
            int ortaHeight = Convert.ToInt32(ConfigurationManager.AppSettings["oh"]);
            int buyukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["bw"]);
            int buyukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["bh"]);

            string newName = Path.GetFileNameWithoutExtension(Resim.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(Resim.FileName);

            Image orjRes = Image.FromStream(Resim.InputStream);

            Bitmap kucukRes = new Bitmap(orjRes, kucukWidth, kucukHeight);
            Bitmap ortaRes = new Bitmap(orjRes, ortaWidth, ortaHeight);
            Bitmap buyukRes = new Bitmap(orjRes);

            kucukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Kucuk/" + newName));
            ortaRes.Save(ctx.Server.MapPath("~/Content/Resimler/Orta/" + newName));
            buyukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Buyuk/" + newName));

            Kullanici k = (Kullanici)ctx.Session["Kullanici"];

            Resim dbRes = new Resim();
            dbRes.Adi = Resim.FileName;
            dbRes.BuyukResimYol = "/Content/Resimler/Buyuk/" + newName;
            dbRes.OrtaResimYol = "/Content/Resimler/Orta/" + newName;
            dbRes.KucukResimYol = "/Content/Resimler/Kucuk/" + newName;

            dbRes.EklenmeTarihi = DateTime.Now;
            dbRes.EkleyenID = k.Id;

            context.Resims.Add(dbRes);
            context.SaveChanges();

            return dbRes.Id;
        }
        public ActionResult Kategori()
        {
            ViewBag.Tip = 1;
            return View(context.Kategoris.ToList());

        }
        public ActionResult KategoriEkle()
        {
            ViewBag.Tip = 1;
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kat)
        {
            context.Kategoris.Add(kat);
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult KategoriDuzenle(int id)
        {
            ViewBag.Tip = 1;
            return View(context.Kategoris.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult KategoriDuzenle(Kategori kat)
        {
            context.Entry(kat).State = System.Data.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }
        public ActionResult KategoriSil(int id)
        {
            context.Kategoris.Remove(context.Kategoris.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
            return RedirectToAction("Kategori");

        }
        //public class AuthorizeRolesAttribute : AuthorizeAttribute
        //{
        //    public AuthorizeRolesAttribute(params string[] roles): base()
        //    {
        //        Roles = string.Join(",", roles);
        //    }
        //}

        //public static class CustomRoles
        //{
        //    public const string Admin = "Admin";
        //    public const string Yazar = "Yazar";
        //}

        //public class MyController: Controller
        //{
        //    [AuthorizeRoles(CustomRoles.Admin, CustomRoles.Yazar)]
        //    public ActionResult AdminOrYazar()
        //    {
        //        return View();
        //    }
        //}
        [Authorize(Roles = "Admin")]
        public ActionResult Rol()
        {
            return View();
        }
    }
}
