using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class TaiKhoan:ConnectSQL
    {
        public string TenDN { get; set; }
        public string VaiTro { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string MatKhau { get; set; }
        public string AnhBiaUser { get; set; }

    }
}