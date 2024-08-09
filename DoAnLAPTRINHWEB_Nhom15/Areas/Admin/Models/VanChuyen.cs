using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//ràng buộc
using System.ComponentModel.DataAnnotations;
namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class VanChuyen
    {
        //[Required(ErrorMessage = "Bắt buộc nhập Mã Nhà Sản Xuất")]
        public string MaVanChuyen { get; set; }

        //[Required(ErrorMessage = "Bắt buộc nhập Tên Nhà Sản Xuất")]
        public string MaDonHang { get; set; }

        //[Required(ErrorMessage = "Bắt buộc Nhập Số Điện Thoại")]
        public string NgayVanChuyen { get; set; }

        //[Required(ErrorMessage = "Bắt buộc nhập Địa Chỉ")]
        public double ChiPhiVanChuyen { get; set; }
    }
}