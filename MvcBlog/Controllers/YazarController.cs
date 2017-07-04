using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{

    public class YazarController : Controller
    {
        //
        // GET: /Yazar/
        BlogContext context = new BlogContext();
        public ActionResult Index(Guid id)
        {
            return View(id);
        }
        public ActionResult MakaleListele (Guid id)
        {
            var data = context.Makales.Where(x => x.YazarID == id);
            return View("MakaleListele", data);
        }

    }
}
