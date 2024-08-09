using DoAnLAPTRINHWEB_Nhom15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models;
using DoAnLAPTRINHWEB_Nhom15.Models;
using System.Data;

namespace DoAnLAPTRINHWEB_Nhom15.Controllers
{
 
    public class HomePageController : Controller
    {
        //
        // GET: /HomePage/
        ConnectProduct pro = new ConnectProduct();
        List<Products> listProduct = new List<Products>();

        ConnectGioHang connectGH = new ConnectGioHang();
        List<GioHang> listGioHang = new List<GioHang>();

        List<DonHang> listDonHang = new List<DonHang>();
        ConnectDonHang connectDH = new ConnectDonHang();

        List<ChiTietDonHang> listCTDonHang = new List<ChiTietDonHang>();
        ConnectChiTietDonHang connectCTDH = new ConnectChiTietDonHang();

        ConnectTaiKhoan connectTaiKhoan = new ConnectTaiKhoan();
        List<TaiKhoan> listTaiKhoan = new List<TaiKhoan>();

        LoginTest logintest = new LoginTest();
        string txtLoai;
        public ActionResult DangXuat()
        {
            Session.Abandon(); // Xóa toàn bộ session data, hoặc bạn có thể xóa các phần tử cụ thể khỏi session

            return RedirectToAction("PageHome", "HomePage");
        }
        public ActionResult PageHome()
        {
            listProduct = pro.getData().Take(4).ToList();
            return View(listProduct);
        }
        //------------------PRODUCT---------------------
        public ActionResult HomeProduct()
        {
            listProduct = pro.getData();
            ViewBag.SLSP = listProduct.Count();
            return View(listProduct);
        }
        [HttpPost]
        public ActionResult HomeProduct(string txtTenSP)
        {
            listProduct = pro.search(txtTenSP, "","" );

            ViewBag.mess = "";
            if (listProduct.Count == 0)
            {
                ViewBag.mess = "Không tìm thấy!";
            }
            ViewBag.txtTenSP = txtTenSP;
            ViewBag.SLSP = listProduct.Count();
            return View(listProduct);
        }
        public ActionResult ProductByType(string txtType)
        {
            ViewBag.Type = txtType;
            listProduct = pro.ProductByType(txtType);
            ViewBag.SLSP = listProduct.Count();
            return View(listProduct);
        }
        [HttpPost]
        public ActionResult ProductBySelected(string txtPrice)
        {
            string selectedsp = "";
            if (txtPrice == "ASC")
                selectedsp = "Theo giá: Thấp đến cao";
            if (txtPrice == "DESC")
                selectedsp = "Theo giá: Cao đến thấp";
            if (txtPrice == "Default")
                selectedsp = "Mặc định";
            if (txtPrice == "Popular")
                selectedsp = "Phổ biến";
            if (txtPrice == "ByTheMost")
                selectedsp = "Mua nhiều nhất";
            ViewBag.selected = selectedsp;
            string type = ViewBag.Type;
            listProduct = pro.ProductBySelected(txtPrice, type);
            ViewBag.SLSP = listProduct.Count();
            return View(listProduct);
        }

        public ActionResult HomeDetail(string masp)
        {
            ProductDetail a = pro.ChiTietSP(masp);
            ViewBag.MaLoai = pro.getMaLoai(masp).ToString();
            return View(a);
        }
        //------------------ĐĂNG NHẬP---------------------
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string UserName, string Email, string Password)
        {

            int kt = logintest.LoginTestt(UserName, Email, Password);
            if (kt == 1)
            {
                Session["User"] = UserName;
                return RedirectToAction("AdminHome", "Admin/HomeAdmin");
            }
            if (kt == 2)
            {
                Session["User"] = UserName;
                return RedirectToAction("PageHome", "HomePage");
            }
            if (kt == 0)
            {
                Session["User"] = null;
                return RedirectToAction("DangNhap");
            }
            
            //user = new DangNhap(UserName, Email, Password);
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection f)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.Email = f["Email"].ToString();
            tk.HoTen = f["HoTen"].ToString();          
            tk.NgaySinh = f["NgaySinh"].ToString();
            tk.GioiTinh = f["GioiTinh"].ToString();
            tk.SoDienThoai = f["SoDienThoai"].ToString();
            tk.TenDN = f["TenDN"].ToString();
            tk.MatKhau = f["MatKhau"].ToString();
            int rs = connectTaiKhoan.TestDangKy(tk);
            return RedirectToAction("DangNhap");
        }
        public ActionResult ForgotPass()
        {
            return View();
        }

        public ActionResult DiaChi()
        {
            DiaChi dc = new DiaChi();
            string TenDN2 = Session["User"].ToString();
            dc = connectTaiKhoan.ShowDiaChi(TenDN2);
            ViewBag.DiaChi = dc.ChiTietDiaChi;
            ViewBag.DiaChi2 = dc.ChiTietDiaChi2;
            return View();
        }
        [HttpPost]
        public ActionResult DiaChi(FormCollection f)
        {
           string TenDN2 = Session["User"].ToString();
            DiaChi dc = new DiaChi();          

            dc.ChiTietDiaChi = f["ChiTietDiaChi"].ToString();
            dc.ChiTietDiaChi2 = f["ChiTietDiaChi2"].ToString();
            int rs = connectTaiKhoan.AddDiaChi(TenDN2,dc);

            return RedirectToAction("ShowTaiKhoanUser");
        }
        //------------------GIỎ HÀNG---------------------
        public ActionResult HomeGioHang()
        {
            if (Session["User"] == null)
                return RedirectToAction("DangNhap");
            else
            {
                ViewBag.User = Session["User"];
                string TenDN = Session["User"].ToString();
                listGioHang = connectGH.layGioHang(TenDN);
                Session["GioHang"] = listGioHang;
                return View(listGioHang);
            }
        }
        public ActionResult AddGioHang(string MaSP)
        {
            if (Session["User"] == null)
                return RedirectToAction("DangNhap");
            else
            {
                string TenDN = Session["User"].ToString();
                int rs = connectGH.ThemGioHang(MaSP, TenDN);
                return RedirectToAction("HomeProduct");
            }
        }
        public ActionResult DeleteGioHang(string MaSP)
        {
            string TenDN = Session["User"].ToString();
            int rs = connectGH.XoaGioHang(MaSP, TenDN);
            return RedirectToAction("HomeGioHang");
        }
        public ActionResult UpdateSoLuongGH(string MaSP, FormCollection f)
        {
            int SoLuong = int.Parse(f["SoLuong"].ToString());
            string TenDN = Session["User"].ToString();
            int rs = connectGH.UpdateSoLuong(MaSP, TenDN, SoLuong);
            return RedirectToAction("HomeGioHang");
        }

        public ActionResult ViewTongSoLuong()
        {
            ViewBag.TongSL = TongSoLuong();
            return PartialView();
        }
        public int TongSoLuong()
        {
            int tsl = 0;
            var listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tsl = listGioHang.Sum(sp => sp.SoLuong);
            }
            return tsl;
        }

        //------------------ĐẶT HÀNG---------------------
        public ActionResult DatHang(FormCollection f)
        {
            string TenDN = Session["User"].ToString();
            DonHang dh = new DonHang();
            dh.TenDN = TenDN;
            dh.NgayDat = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");//Thay đổi NgayDat Date; trong Database thành DateTime
            string httt = f["thanhtoan"].ToString();
            if (httt == "1")
                dh.HinhThucThanhToan = "Ví điện tử";
            else if (httt == "2")
                dh.HinhThucThanhToan = "Thẻ tín dụng";
            else
                dh.HinhThucThanhToan = "Thanh toán khi nhận hàng";
            dh.ChiTietDiaChi = f["ChiTietDiaChi"].ToString();
            int rs = connectDH.ThemDonHang(TenDN, dh.NgayDat, dh.HinhThucThanhToan,dh.ChiTietDiaChi);
            dh.MaDonHang = connectDH.LayMaDH(TenDN, dh.NgayDat);
            var listGH = Session["GioHang"] as List<GioHang>;
            foreach(var item in listGH)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDonHang = dh.MaDonHang;
                ctdh.MaSanPham = item.MaSanPham;
                ctdh.SoLuong = item.SoLuong;
                int k = connectCTDH.themChiTietDonHang(ctdh);
             
            }
            connectDH.update1DonHang(dh.MaDonHang);
            connectGH.XoaTatCaGioHang(TenDN);
            return RedirectToAction("HomeGioHang");
        }
        //------------------ĐƠN HÀNG---------------------
        public ActionResult ShowDonHangByTenDN(string TenDN)
        {
            TenDN = Session["User"].ToString();
            listDonHang = connectDH.ShowDonHangByTenDN(TenDN);
            ViewBag.TongDH = listDonHang.Count();
            return View(listDonHang);
        }
        public ActionResult ShowCTDonHangByTenDN(string MaDH)
        {
            List<ChiTietDonHang> lstCTDH = new List<ChiTietDonHang>();         
            lstCTDH = connectCTDH.getCTHDByTenDN(MaDH) ;         
            return View(lstCTDH);
        }
        public ActionResult DeleteDonHangByTenDN(int MaDH)
        {
            int rs = connectDH.deleteDonHang(MaDH);
            return RedirectToAction("ShowDonHangByTenDN");
        }
        //------------------USER---------------------
        public ActionResult ShowTaiKhoanUser(string Tendn)
        {
            Tendn = Session["User"].ToString();
            listTaiKhoan = connectTaiKhoan.ShowTaiKhoan(Tendn);
            return View(listTaiKhoan);
        }
        public ActionResult UpdateTaiKhoan(string TenDN, FormCollection f)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.HoTen = f["HoTen"].ToString();
            tk.Email = f["Email"].ToString();
            tk.NgaySinh = f["NgaySinh"].ToString();
            tk.GioiTinh = f["GioiTinh"].ToString();
            tk.SoDienThoai = f["SoDienThoai"].ToString();
            tk.TenDN = Session["User"].ToString();
            int rs = connectTaiKhoan.UpdateTaiKhoan(tk);
            return RedirectToAction("ShowTaiKhoanUser");
        }

        public ActionResult UpdateMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateMatKhau(string TenDN, FormCollection f)
        {
            TenDN = Session["User"].ToString();
            string mk = f["MatKhau"].ToString();
            connectTaiKhoan.updateMatKhau(TenDN,mk);
            return RedirectToAction("ShowTaiKhoanUser");
        }
    }
}