using DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLAPTRINHWEB_Nhom15.Controllers
{
    public class TaiKhoanUserController : Controller
    {
        // GET: TaiKhoanUser
        
        public ActionResult ThongTinTaiKhoan()
        {
            return View();
        }
        
    }
}