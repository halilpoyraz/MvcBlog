using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Areas.iletisim.Models;

namespace MvcBlog.Areas.iletisim.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /iletisim/Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IletisimModel model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                //body.AppendLine("Rumuz: " + model.NickName);
                body.AppendLine("İsim: " + model.FullName);
                body.AppendLine("Telefon: " + model.Phone);
                body.AppendLine("Eposta: " + model.Email);
                body.AppendLine("Mesaj: " + model.Message);
                Gmail.SendMail(body.ToString());
                ViewBag.Success = true;
            }
            return View();
        } 
    }
}
