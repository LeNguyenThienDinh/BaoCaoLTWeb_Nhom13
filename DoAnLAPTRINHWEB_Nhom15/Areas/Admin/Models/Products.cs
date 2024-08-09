using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class Products
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã Sản Phẩm")]
        public string MaSanPham { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Tên Sản Phẩm")]
        public string TenSanPham { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Giá")]
        public double Gia { get; set; }
        public string MoTa { get; set; }
        [Required(ErrorMessage = "Bắt buộc up Ảnh minh họa")]
        public string Anh { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Mã Loại")]
        public string MaLoai { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Mã Nhà Sản Xuất")]
        public string MaNhaSanXuat { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Số Lượng")]
        public int SanPhamTon { get; set; }
        public int SanPhamDaBan { get; set; }
    }
}