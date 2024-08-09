using System.Web.Mvc;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "AdminHome", id = UrlParameter.Optional },
                namespaces: new[] { "DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Controllers"}
            );
        }
    }
}