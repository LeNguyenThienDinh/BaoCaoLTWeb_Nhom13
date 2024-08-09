using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectChiTietDonHang:ConnectSQL
    {
        List<ChiTietDonHang> lstChiTietDonHang = new List<ChiTietDonHang>();
        SqlCommand cmd = new SqlCommand();
        public List<ChiTietDonHang> getData(string MaDonHang)
        {

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = conStr;
                string sql = "select * from DonHang, ChiTietDonHang where DonHang.MaDonHang=ChiTietDonHang.MaDonHang and DonHang.MaDonHang='"+MaDonHang+"'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var ctdh = new ChiTietDonHang();
                    ctdh.MaDonHang = int.Parse(row["MaDonHang"].ToString());
                    ctdh.TenDN = row["TenDN"].ToString();
                    ctdh.NgayDat = row["NgayDat"].ToString();
                    ctdh.Email = row["Email"].ToString();
                    ctdh.HoTen = row["HoTen"].ToString();
                    ctdh.SoDienThoai = row["SoDienThoai"].ToString();
                    ctdh.ChiTietDiaChi = row["ChiTietDiaChi"].ToString();
                    ctdh.TongGiaTri = float.Parse(row["TongGiaTri"].ToString());
                    ctdh.HinhThucThanhToan = row["HinhThucThanhToan"].ToString();
                    ctdh.MaSanPham = row["MaSanPham"].ToString();
                    ctdh.SoLuong = int.Parse(row["SoLuong"].ToString());
                    ctdh.ThanhTien = double.Parse(row["ThanhTien"].ToString());

                    lstChiTietDonHang.Add(ctdh);
                }
            }
            return lstChiTietDonHang;
        }

        public List<ChiTietDonHang> getCTHDByTenDN(string MaDonHang)
        {
            List < ChiTietDonHang > lst= new List<ChiTietDonHang>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = conStr;
                string sql = "select TenSanPham,Anh,SoLuong,ThanhTien from ChiTietDonHang,SanPham where  SanPham.MaSanPham=ChiTietDonHang.MaSanPham and MaDonHang=" + MaDonHang + "";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var ctdh = new ChiTietDonHang();
                    ctdh.TenDN = row["TenSanPham"].ToString();
                    ctdh.HoTen = row["Anh"].ToString();
                    ctdh.SoLuong = int.Parse(row["SoLuong"].ToString());
                    ctdh.ThanhTien = double.Parse(row["ThanhTien"].ToString());

                    lst.Add(ctdh);
                }
            }
            return lst;
        }
        public int themChiTietDonHang(ChiTietDonHang a)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "SET IDENTITY_INSERT ChiTietDonHang ON;";
            sql += "INSERT INTO ChiTietDonHang(MaDonHang,MaSanPham,SoLuong) values('" + a.MaDonHang + "', '" + a.MaSanPham + "', " + a.SoLuong + ");";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            if(rs!=0)
            {
                string sql2 = "exec updateThanhTien_CTDH '" + a.MaSanPham + "';";
                cmd.CommandText = sql2;
                rs = cmd.ExecuteNonQuery();
            }    
            return rs;
        }
    }
}