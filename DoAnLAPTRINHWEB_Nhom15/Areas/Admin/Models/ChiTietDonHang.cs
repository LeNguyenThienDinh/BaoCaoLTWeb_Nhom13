using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ChiTietDonHang:DonHang
    {
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }

    }
}