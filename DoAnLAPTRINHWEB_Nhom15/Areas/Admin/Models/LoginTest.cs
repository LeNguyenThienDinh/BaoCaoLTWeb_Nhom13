using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class LoginTest:ConnectSQL
    {
        public int LoginTestt(string Username, string email, string password)
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE Email=@Email AND TenDN = @Username AND MatKhau = @Password";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            int result = (int)cmd.ExecuteScalar();
            int kt = 0;
            if (result != 0)
            {

                string query2 = "SELECT COUNT(*) FROM TaiKhoan WHERE  TenDN = @Username and VaiTro='Admin'";
                SqlCommand command2 = new SqlCommand(query2, con);
                command2.Parameters.AddWithValue("@Username", Username);
                kt = (int)command2.ExecuteScalar();
                if (kt == 1)
                    return 1;//Tra ve trang Admin
                else
                    return 2;//Tra ve trang User
            }
            return kt;
        }
    }
}