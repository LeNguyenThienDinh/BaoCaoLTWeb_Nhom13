using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models;

namespace DoAnLAPTRINHWEB_Nhom15.Models
{
    public class ConnectGioHang : ConnectSQL
    {
        List<GioHang> lstGioHang = new List<GioHang>();
        public List<GioHang> layGioHang(string TenDN)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "select * from GioHang where TenDN='" + TenDN + "'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach(DataRow row in dt.Rows)
                    {
                        var gh = new GioHang();
                        gh.TenDN = row["TenDN"].ToString();
                        gh.MaSanPham = row["MaSanPham"].ToString();
                        gh.TenSanPham = row["TenSanPham"].ToString();
                        gh.Anh = row["Anh"].ToString();
                        gh.Gia = float.Parse(row["Gia"].ToString());
                        gh.SoLuong = int.Parse(row["SoLuong"].ToString());
                        gh.ThanhTien = double.Parse(row["ThanhTien"].ToString());
                        lstGioHang.Add(gh);
                    }    
                }
                return lstGioHang;
            }
            catch
            {
                throw;
            }
        }
        public int ThemGioHang(string MaSP, string TenDN)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "exec ThemGioHang'" + MaSP + "','" + TenDN + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;

        }
        public int XoaGioHang(string MaSP, string TenDN)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "delete GioHang where TenDN='" + TenDN + "' and MaSanPham='" + MaSP + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;

        }
        public int UpdateSoLuong(string MaSP, string TenDN, int SoLuong)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "exec UpdateSoLuong'" + MaSP + "','" + TenDN + "'," + SoLuong + "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;
        }
        public void XoaTatCaGioHang(string TenDN)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "delete from GioHang where TenDN='"+TenDN+"'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}