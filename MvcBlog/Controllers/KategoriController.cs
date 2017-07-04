using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class KategoriController : Controller
    {
        //
        // GET: /Kategori/

        BlogContext context = new BlogContext();
        public ActionResult Index(int id)
        {

            return View(id);
        }

        public ActionResult MakaleListele(int id)
        {
            var data = context.Makales.Where(x => x.KategriID == id);
            return View("MakaleListele", data);
        }
    }
}
