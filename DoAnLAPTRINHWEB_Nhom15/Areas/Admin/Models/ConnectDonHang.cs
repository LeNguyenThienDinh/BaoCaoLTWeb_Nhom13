using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectDonHang:ConnectSQL
    {
        List<DonHang> lstDonHang = new List<DonHang>();
        SqlCommand cmd = new SqlCommand();
        public List<DonHang> getData()
        {

                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from DonHang";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var dh = new DonHang();
                        dh.MaDonHang = int.Parse(row["MaDonHang"].ToString());
                        dh.TenDN = row["TenDN"].ToString();
                        dh.NgayDat = row["NgayDat"].ToString();
                        dh.Email = row["Email"].ToString();
                        dh.HoTen = row["HoTen"].ToString();
                        dh.SoDienThoai = row["SoDienThoai"].ToString();
                        dh.ChiTietDiaChi = row["ChiTietDiaChi"].ToString();
                        dh.TongGiaTri = float.Parse(row["TongGiaTri"].ToString());
                        dh.HinhThucThanhToan = row["HinhThucThanhToan"].ToString();
                        dh.TrangThai = row["TrangThai"].ToString();


                        lstDonHang.Add(dh);
                    }
                }
                return lstDonHang;

        }
        public List<DonHang> search(string txtMaDH)
        {
                using (SqlConnection con = new SqlConnection())
                {

                    con.ConnectionString = conStr;
                    string sql;
                    if (txtMaDH != "")
                        sql = "select * from DonHang where MaDonHang = '" + txtMaDH + "'";
                    else
                        sql = "Select * from DonHang";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var dh = new DonHang();
                        dh.MaDonHang = int.Parse(row["MaDonHang"].ToString());
                        dh.TenDN = row["TenDN"].ToString();
                        dh.NgayDat = row["NgayDat"].ToString();
                        dh.Email = row["Email"].ToString();
                        dh.HoTen = row["HoTen"].ToString();
                        dh.SoDienThoai = row["SoDienThoai"].ToString();
                        dh.ChiTietDiaChi = row["ChiTietDiaChi"].ToString();
                        dh.TongGiaTri = float.Parse(row["TongGiaTri"].ToString());
                        dh.HinhThucThanhToan = row["HinhThucThanhToan"].ToString();
                        dh.TrangThai = row["TrangThai"].ToString();
                    }
                }
                return lstDonHang;

        }
        public int ThemDonHang(string TenDN,string NgayDat,string PTThanhToan, string ChiTietDiaChi)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "insert into DonHang(TenDN,NgayDat,HinhThucThanhToan,ChiTietDiaChi) values('" + TenDN+"', '"+NgayDat+"', N'"+PTThanhToan+"',N'"+ ChiTietDiaChi + "');";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;
        }
        public int LayMaDH(string TenDN, string NgayDat)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "select MaDonHang From DonHang where TenDN='"+TenDN+"' and NgayDat='"+NgayDat+"'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            int MaDH = int.Parse(result.ToString());
            return MaDH;
        }
        public void update1DonHang(int MaDH)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "exec Update1DonHang " + MaDH + "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public void updateTrangThaiDonHang(int MaDH, string trangThai)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "update DonHang set TrangThai = N'"+trangThai+"' where MaDonHang = "+MaDH+"";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<DonHang> ShowDonHangByTenDN(string TenDN)
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = conStr;
                string sql = "select * from DonHang where TenDN = '" + TenDN + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var dh = new DonHang();
                    dh.MaDonHang = int.Parse(row["MaDonHang"].ToString());
                    dh.TenDN = row["TenDN"].ToString();
                    dh.NgayDat = row["NgayDat"].ToString();
                    dh.Email = row["Email"].ToString();
                    dh.HoTen = row["HoTen"].ToString();
                    dh.SoDienThoai = row["SoDienThoai"].ToString();
                    dh.ChiTietDiaChi = row["ChiTietDiaChi"].ToString();
                    dh.TongGiaTri = float.Parse(row["TongGiaTri"].ToString());
                    dh.HinhThucThanhToan = row["HinhThucThanhToan"].ToString();
                    dh.TrangThai = row["TrangThai"].ToString();
                    lstDonHang.Add(dh);
                }
            }
            return lstDonHang;
        }
        public int deleteDonHang(int MaDH)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "select count(*) from DonHang where TrangThai=N'Đang xử lý' and MaDonHang = " + MaDH + "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int kt = 0;
            int rs = 0;
           kt = (int)cmd.ExecuteScalar();
            if(kt!=0)
            {
                string sql2 = "delete from ChiTietDonHang where MaDonHang="+MaDH+"; ";
                sql2 += "delete from DonHang where MaDonHang="+MaDH+"";
                cmd.CommandText = sql2;
                rs = cmd.ExecuteNonQuery();
                return rs;
            }
            return 0;
        }
    }
}