using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectSQL
    {
        public string conStr { get; set; }
        public ConnectSQL()
        {
            conStr = "workstation id=QL_CuaHangCayCanh.mssql.somee.com;packet size=4096;user id=Nhom13_SQLLogin_1;pwd=s3mb9ie3pk;data source=QL_CuaHangCayCanh.mssql.somee.com;persist security info=False;initial catalog=QL_CuaHangCayCanh;TrustServerCertificate=True;Max Pool Size=200;";
        }
    }
}