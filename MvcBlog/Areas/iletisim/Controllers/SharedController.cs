using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Areas.iletisim.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /iletisim/Shared/

        public ActionResult _Layout()
        {
            return View();
        }

    }
}
