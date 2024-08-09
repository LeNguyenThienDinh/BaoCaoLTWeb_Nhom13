using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//ràng buộc
using System.ComponentModel.DataAnnotations;
namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class NSX
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã Nhà Sản Xuất")]
        public string MaNhaSanXuat { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Tên Nhà Sản Xuất")]
        public string TenNhaSanXuat { get; set; }

        [Required(ErrorMessage = "Bắt buộc Nhập Số Điện Thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Địa Chỉ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Email")]
        public string Email { get; set; }

    }
}