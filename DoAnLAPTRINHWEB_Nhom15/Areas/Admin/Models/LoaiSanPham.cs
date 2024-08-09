using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class LoaiSanPham
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã Loại")]
        public string MaLoai  { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Tên Loại")]
        public string TenLoai { get; set; }

    }
}