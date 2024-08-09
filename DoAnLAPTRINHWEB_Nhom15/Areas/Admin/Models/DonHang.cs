using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class DonHang
    {
        //[Required(ErrorMessage = "Bắt buộc nhập Mã Sản Phẩm")]
        public int MaDonHang { get; set; }
        public string TenDN { get; set; }
        public string NgayDat { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string ChiTietDiaChi { get; set; }
        public float TongGiaTri { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string TrangThai { get; set; }
    }
}