using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models;
namespace DoAnLAPTRINHWEB_Nhom15.Controllers
{
    public class ProductController : Controller
    {
        ConnectProduct connect = new ConnectProduct();
        // GET: Product
        public ActionResult ShowProduct()
        {
            List<Products> ShowSP = connect.getData();
            return View(ShowSP);
        }
    }
}