using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ProductDetail
    {

        public string MaCT { get; set; }
        public string ThuongHieu { get; set; }
        public string MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public double Gia { get; set; }
        public string Anh1 { get; set; }
        public string Anh2 { get; set; }
        public string Anh3 { get; set; }
        public string MoTa1 { get; set; }
        public string MoTa2 { get; set; }
        public string MoTa3 { get; set; }
        public string MoTa4 { get; set; }

        public ProductDetail()
        {

        }
        public ProductDetail(string maCT, string thuongHieu, string maSanPham, string tenSanPham, double gia, string anh1, string anh2, string anh3, string moTa1, string moTa2, string moTa3, string moTa4)
        {
            MaCT = maCT;
            ThuongHieu = thuongHieu;
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            Gia = gia;
            Anh1 = anh1;
            Anh2 = anh2;
            Anh3 = anh3;
            MoTa1 = moTa1;
            MoTa2 = moTa2;
            MoTa3 = moTa3;
            MoTa4 = moTa4;
        }
    }


}