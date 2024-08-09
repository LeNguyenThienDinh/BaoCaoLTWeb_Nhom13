using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Models
{
    public class Search_TenSP
    {
        public string tenSP { get; set; }
        public Search_TenSP (string tensp)
        {
            this.tenSP = tenSP;
        }
    }
}