using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectNSX:ConnectSQL
    {
        List<NSX> listnsx = new List<NSX>();
        SqlCommand cmd = new SqlCommand();
        public List<NSX> getData1()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from NhaSanXuat";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var nsx = new NSX();
                        nsx.MaNhaSanXuat = row["MaNhaSanXuat"].ToString();
                        nsx.TenNhaSanXuat = row["TenNhaSanXuat"].ToString();
                        nsx.SoDienThoai = row["SoDienThoai"].ToString();
                        nsx.DiaChi = row["DiaChi"].ToString();
                        nsx.Email = row["Email"].ToString();

                        listnsx.Add(nsx);
                    }
                }
                return listnsx;
            }
            catch
            {
                throw;
            }

        }

        public List<NSX> search(string mnsx)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql;
                    if (mnsx != "")
                        sql = "Select * from NhaSanXuat where MaNhaSanXuat = '" + mnsx + "'";
                    else
                        sql = "Select * from NhaSanXuat";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var nsx = new NSX();
                        nsx.MaNhaSanXuat = row["MaNhaSanXuat"].ToString();
                        nsx.TenNhaSanXuat = row["TenNhaSanXuat"].ToString();
                        nsx.SoDienThoai = row["SoDienThoai"].ToString();
                        nsx.DiaChi = row["DiaChi"].ToString();
                        nsx.Email = row["Email"].ToString();

                        listnsx.Add(nsx);
                    }
                }
                return listnsx;
            }
            catch
            {
                throw;
            }
        }
        //add nsx
        public int AddNSX(NSX nsx)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string strcmd = "select count(*) from NhaSanXuat where MaNhaSanXuat = '" + nsx.MaNhaSanXuat + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strcmd;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();
            if (kt == 0)
            {
                string strcmd2 = "insert into NhaSanXuat values('" + nsx.MaNhaSanXuat + "', N'" + nsx.TenNhaSanXuat + "', '" + nsx.SoDienThoai + "',N'" + nsx.DiaChi + "',N'" + nsx.Email + "')";
                cmd.CommandText = strcmd2;
                rs = cmd.ExecuteNonQuery();
            }
            return rs;
        }
        //---------------delete
        public void XoaNSX(string txtMaNSX)
        {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conStr;
                con.Open();
                string sql = "delete from NhaSanXuat where MaNhaSanXuat = '" + txtMaNSX + "' ";
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
        }
        //public int XoaNSX(string txtMaNSX)
        //    {
        //        SqlConnection con = new SqlConnection();
        //        SqlCommand cmd = new SqlCommand();
        //        con.ConnectionString = conStr;
        //        con.Open();
        //        string sql1 = "select count(*) from NhaSanXuat where MaNhaSanXuat = '" + txtMaNSX + "' ";
        //        cmd.CommandText = sql1;
        //        cmd.Connection = con;
        //        int rs = 0;
        //        int kt = (int)cmd.ExecuteScalar();

        //        if (kt == 0)
        //        {
        //            string sql = "delete from NhaSanXuat where MaNhaSanXuat = '" + txtMaNSX + "' ";
        //            cmd.CommandText = sql;
        //            rs = cmd.ExecuteNonQuery();
        //        }

        //        con.Close();
        //        return rs;
        //    }
        //----------update
        //public int UpdateNSX(NSX nsx)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = conStr;
        //    con.Open();
        //    string sql = "select count(*) from NhaSanXuat where MaNhaSanXuat = '" + nsx.MaNhaSanXuat + "' ";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = sql;
        //    cmd.Connection = con;
        //    int rs = 0;
        //    int kt = (int)cmd.ExecuteScalar();
        //    string mnsx = nsx.MaNhaSanXuat;
        //    if (kt == 0)
        //    {
        //        string sql2 = "update NhaSanXuat set MaNhaSanXuat ='" + nsx.MaNhaSanXuat + "', TenNhaSanXuat = N'" + nsx.TenNhaSanXuat + "',  SoDienThoai = '" + nsx.SoDienThoai + "',DiaChi = N'" + nsx.DiaChi + "',Email =N'" + nsx.Email + "' where MaNhaSanXuat='" + mnsx + "' ";
        //        cmd.CommandText = sql2;
        //        rs = cmd.ExecuteNonQuery();
        //    }


        //    return rs;

        //}
        public void UpdateNSX(NSX nsx)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "update NhaSanXuat set MaNhaSanXuat='" + nsx.MaNhaSanXuat + "',TenNhaSanXuat=N'" + nsx.TenNhaSanXuat + "',SoDienThoai='" + nsx.SoDienThoai + "',DiaChi=N'" + nsx.DiaChi + "',Email=N'"+nsx.Email+"' where MaNhaSanXuat='"+nsx.MaNhaSanXuat+"' ";
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
    }
}