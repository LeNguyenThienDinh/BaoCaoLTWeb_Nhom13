using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLAPTRINHWEB_Nhom15.Models;
namespace DoAnLAPTRINHWEB_Nhom15.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap([Bind(Include = "UserName, Password,Email")] UserDangNhap user)
        {
            if ("huit".Equals(user.UserName) && "123456".Equals(user.Password) && "tranhau2607@gmail.com".Equals(user.Email))
            {
                return RedirectToAction("AdminHome", "HomeAdmin", new { area = "Admin" });
            }
            return RedirectToAction("DangNhap", "Login");
        }
	}
}