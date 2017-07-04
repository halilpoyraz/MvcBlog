using System.Web.Mvc;

namespace MvcBlog.Areas.iletisim
{
    public class iletisimAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "iletisim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "iletisim_default",
                "iletisim/{controller}/{action}/{id}",
                new { Controller="Home" , action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
