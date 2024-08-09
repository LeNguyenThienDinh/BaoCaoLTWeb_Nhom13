using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectLoaiSP:ConnectSQL
    {
        List<LoaiSanPham> listLoaiSP = new List<LoaiSanPham>();
        SqlCommand cmd = new SqlCommand();
        public List<LoaiSanPham> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from LoaiSanPham";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var loai = new LoaiSanPham();
                        loai.MaLoai = row["MaLoai"].ToString();
                        loai.TenLoai = row["TenLoai"].ToString();
                        listLoaiSP.Add(loai);
                    }
                }
                return listLoaiSP;
            }
            catch
            {
                throw;
            }

        }

        public List<LoaiSanPham> search(string txtMaLoai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    
                    con.ConnectionString = conStr;
                    string sql;
                    if(txtMaLoai!="")
                         sql = "Select * from LoaiSanPham where MaLoai = '"+txtMaLoai+"'";
                    else
                        sql = "Select * from LoaiSanPham";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var loai = new LoaiSanPham();
                        loai.MaLoai = row["MaLoai"].ToString();
                        loai.TenLoai = row["TenLoai"].ToString();
                        listLoaiSP.Add(loai);
                    }
                }
                return listLoaiSP;
            }
            catch
            {
                throw;
            }

        }

        public int DelectLoaiSP(string txtMaLoai)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.Open();
            string sql2 = "select count(*) from SanPham where MaLoai = '" + txtMaLoai + "'";
            cmd.CommandText = sql2;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();

            if (kt == 0)
            {
                string sql = "delete from LoaiSanPham where MaLoai = '" + txtMaLoai + "'";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }

            con.Close();
            return rs;
        }

        public int AddLoaiSP(LoaiSanPham loaisp)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "select count(*) from LoaiSanPham where MaLoai = '" + loaisp.MaLoai + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();
            if (kt == 0)
            {
                string sql2 = "insert into LoaiSanPham values('" + loaisp.MaLoai + "',N'" + loaisp.TenLoai + "')";
                cmd.CommandText = sql2;
                rs = cmd.ExecuteNonQuery();
            }
            return rs;
        }

        public int UpdateLoaiSP(LoaiSanPham loaisp)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "select count(*) from SanPham where MaLoai = '" + loaisp.MaLoai + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();
            string ml = loaisp.MaLoai;
            if (kt == 0)
            {
                string sql2 = "update LoaiSanPham set MaLoai ='" + loaisp.MaLoai + "', TenLoai = N'" + loaisp.TenLoai + "' where MaLoai='"+ml+"' ";
                cmd.CommandText = sql2;
                rs = cmd.ExecuteNonQuery();
            }


            return rs;

        }
    }
}