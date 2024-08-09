using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models;
namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Controllers
{
    //--ttt
    public class HomeAdminController : Controller
    {
        //
        ConnectProduct pro = new ConnectProduct();
        List<Products> listProduct = new List<Products>();

        ConnectLoaiSP loai = new ConnectLoaiSP();
        List<LoaiSanPham> lstLoai = new List<LoaiSanPham>();

        ConnectDonHang donhang = new ConnectDonHang();
        List<DonHang> lstDonHang = new List<DonHang>();

        ConnectNSX proNSX = new ConnectNSX();
        List<NSX> listNSX = new List<NSX>();

        ConnectVanChuyen vanchuyen = new ConnectVanChuyen();
        List<VanChuyen> listvanchuyen = new List<VanChuyen>();

        ConnectChiTietDonHang chitietdonhang = new ConnectChiTietDonHang();
        List<ChiTietDonHang> listchitietdonhang = new List<ChiTietDonHang>();

        ConnectTaiKhoan connectTaiKhoan = new ConnectTaiKhoan();
        List<TaiKhoan> listTaiKhoan = new List<TaiKhoan>();
        // GET: /Admin/HomeAdmin/
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult ShowProduct()
        {
            listProduct = pro.getData();
            ViewBag.TongSP = listProduct.Count;
            return View(listProduct);
        }

        [HttpPost]
        public ActionResult ShowProduct(string txtTenSP, string txtLowPrice, string txtHighPrice)
        {
            listProduct = pro.search(txtTenSP, txtLowPrice, txtHighPrice);
            ViewBag.mess = "";
            if (listProduct.Count == 0)
            {
                ViewBag.mess = "Không tìm thấy!";
            }
            ViewBag.txtTenSP = txtTenSP;
            ViewBag.txtLowPrice = txtLowPrice;
            ViewBag.txtHighPrice = txtHighPrice;
            ViewBag.TongSP = listProduct.Count;
            return View(listProduct);
        }
        //-------
        public ActionResult DeleteProduct(string MaSanPham)
        {
            int rs = pro.DelectProduct(MaSanPham);
            ViewBag.KiemTraXoa = rs;
            return RedirectToAction("ShowProduct");
        }

        //-------
        //Add product

        public ActionResult FormAddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormAddProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                int rs = pro.AddProduct(product);
                ViewBag.rs = rs;
                return RedirectToAction("ShowProduct");
            }
            return View();
        }
        //Sửa product
        public ActionResult FormUpdateProduct(Products products)
        {
            return View(products);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Products pd)
        {
            pro.UpdateProduct(pd);
            return RedirectToAction("ShowProduct");
        }
        //View Loai Sản phẩm
        public ActionResult ShowLoaiSP()
        {
            lstLoai = loai.getData();
            ViewBag.TongLoai = lstLoai.Count();
            return View(lstLoai);
        }
        //Tìm kiếm loại sản phẩm
        [HttpPost]
        public ActionResult ShowLoaiSP(string txtMaLoai)
        {
            lstLoai = loai.search(txtMaLoai);
            ViewBag.mess = "";
            if (lstLoai.Count == 0)
            {
                ViewBag.mess = "Không tìm thấy!";
            }
            ViewBag.txtMaLoai = txtMaLoai;
            ViewBag.TongLoai = lstLoai.Count();
            return View(lstLoai);
        }
        //Xóa Loại Sản phẩm
        public ActionResult DeleteLoaiSP(string txtMaLoai)
        {
            int rs = loai.DelectLoaiSP(txtMaLoai);
            ViewBag.KiemTraXoa = rs;
            return RedirectToAction("ShowLoaiSP");
        }
        //Thêm Loại sản phẩm

        public ActionResult FormAddLoaiSP()
        {
            return View();
        }
        public ActionResult ShowLoaiSP2()
        {
            lstLoai = loai.getData();
            ViewBag.TongLoai = lstLoai.Count();
            return View(lstLoai);
        }
        [HttpPost]
        public ActionResult FormAddLoaiSP(LoaiSanPham loaisp)
        {
            if (ModelState.IsValid)
            {
                int rs = loai.AddLoaiSP(loaisp);
                ViewBag.rs = rs;
                return RedirectToAction("ShowLoaiSP");
            }
            return View();
        }
        // Sửa Loại Sản phẩm
        public ActionResult FormUpdateLoaiSP(LoaiSanPham loaisp)
        {
            return View(loaisp);
        }
        [HttpPost]
        public ActionResult UpdateLoaiSP(LoaiSanPham loaisp)
        {
            loai.UpdateLoaiSP(loaisp);
            return RedirectToAction("ShowLoaiSP");
        }

        //View Đơn Hàng
        public ActionResult ShowDonHang()
        {
            lstDonHang = donhang.getData();
            ViewBag.TongDH = lstDonHang.Count();
            return View(lstDonHang);
        }
        [HttpPost]
        public ActionResult ShowDonHang(string txtMaDH)
        {
            lstDonHang = donhang.search(txtMaDH);
            ViewBag.mess = "";
            if (lstLoai.Count == 0)
            {
                ViewBag.mess = "Không tìm thấy!";
            }
            ViewBag.txtMaDH = txtMaDH;
            ViewBag.TongDH = lstDonHang.Count();
            return View(lstDonHang);
        }
        ///////////// Nhà Sản Xuất/////////////
        public ActionResult ShowNSX()
        {
            listNSX = proNSX.getData1();
            ViewBag.TongSP = listNSX.Count;
            return View(listNSX);
        }
        [HttpPost]
        public ActionResult ShowNSX(string mnsx)
        {
            listNSX = proNSX.search(mnsx);
            ViewBag.mess = "";
            if (listNSX.Count == 0)
            {
                ViewBag.mess = "Không tìm thấy!";
            }
            ViewBag.txtma = mnsx;
            ViewBag.TongSP = listNSX.Count;
            return View(listNSX);
        }
        //--------------add
        public ActionResult FormAddNSX()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormAddNSX(NSX nsx)
        {
            if (ModelState.IsValid)
            {
                int rs = proNSX.AddNSX(nsx);
                ViewBag.rs = rs;
                return RedirectToAction("ShowNSX");
            }
            return View();
        }
        //-------delete nsx
        //public ActionResult DeleteNSX(string txtMaNSX)
        //{
        //    int rs = proNSX.XoaNSX(txtMaNSX);
        //    ViewBag.KiemTraXoa = rs;
        //    return RedirectToAction("ShowNSX");
        //}
        public ActionResult DeleteNSX(string txtMaNSX)
        {
            proNSX.XoaNSX(txtMaNSX);
            return RedirectToAction("ShowNSX");
        }
        //Sửa nsx
        public ActionResult FormUpdateNSX(NSX nsx)
        {
            return View(nsx);
        }
        [HttpPost]
        public ActionResult UpdateNhaSanXuat(NSX nhasanxuat)
        {
            proNSX.UpdateNSX(nhasanxuat);
            return RedirectToAction("ShowNSX");
        }

        


        //-------------Vận CHuyển
        public ActionResult ShowVanChuyen()
        {
            listvanchuyen = vanchuyen.getData();
            ViewBag.TongSP = listvanchuyen.Count;
            return View(listvanchuyen);
        }

        [HttpPost]
        public ActionResult ShowVanChuyen(string txtMaVC)
        {
            listvanchuyen = vanchuyen.search(txtMaVC);
            ViewBag.mess = "";
            if (listvanchuyen.Count == 0)
            {
                ViewBag.mess = "Không tìm thấy!";
            }
            ViewBag.txtMaVC = txtMaVC;
            ViewBag.TongSP = listvanchuyen.Count();
            return View(listvanchuyen);
        }
        //--------Chi Tiết Đơn Hàng
        public ActionResult ShowChiTietDonHang(string MaDonHang)
        {
            listchitietdonhang = chitietdonhang.getData(MaDonHang);
            ViewBag.TongSP = listchitietdonhang.Count;
            return View(listchitietdonhang);
        }
        public ActionResult ShowTaiKhoan()
        {
            listTaiKhoan = connectTaiKhoan.ViewTaiKhoan();
            ViewBag.TongTK = listTaiKhoan.Count();
            return View(listTaiKhoan);
        }

        public ActionResult DeleteTaiKhoan(string TenDN)
        {
            int rs = connectTaiKhoan.deleteTaiKhoan(TenDN);

            return RedirectToAction("ShowTaiKhoan");
        }
        public ActionResult updateTrangThaiDonHang(int MaDH,FormCollection f)
        {
            string trangthai = f["TrangThai"].ToString();
            donhang.updateTrangThaiDonHang(MaDH, trangthai);
            return RedirectToAction("ShowDonHang");
        }
    }
}