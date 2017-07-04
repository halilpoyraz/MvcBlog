using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    public class KullaniciController : Controller
    {
        //
        // GET: /Kullanici/
        BlogContext context = new BlogContext();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(string kullaniciAdi, string Parola)
        {
            if (System.Web.Security.Membership.ValidateUser(kullaniciAdi, Parola))
            {
                FormsAuthentication.RedirectFromLoginPage(kullaniciAdi, true);
                Guid id=(Guid)System.Web.Security.Membership.GetUser(kullaniciAdi).ProviderUserKey;
                Session["Kullanici"] = context.Kullanicis.FirstOrDefault(x => x.Id == id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Ooops! Kullanıcı Adı veya Parola Yanlış";
                return View();
            }
            
        }
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Kullanici kullanici,HttpPostedFileBase Resim,string Parola)
        {
            MembershipUser user = System.Web.Security.Membership.CreateUser(kullanici.Nick, Parola, kullanici.Mail);
            kullanici.Id = (Guid)user.ProviderUserKey;
            Session["Kullanici"] = kullanici;
            kullanici.ResimID = YonetimController.ResimKaydet(Resim, HttpContext);
            kullanici.KayitTarihi = DateTime.Now;
            context.Kullanicis.Add(kullanici);
            context.SaveChanges();
            FormsAuthentication.RedirectFromLoginPage(kullanici.Nick, true);
            Session["Kullanici"] = kullanici;
            return RedirectToAction("Index", "Home");
        }
    }
}
