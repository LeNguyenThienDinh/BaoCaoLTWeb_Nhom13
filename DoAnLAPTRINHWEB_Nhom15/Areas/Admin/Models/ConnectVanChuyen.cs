using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectVanChuyen:ConnectSQL
    {
        List<VanChuyen> listVanChuyen = new List<VanChuyen>();
        SqlCommand cmd = new SqlCommand();
        public List<VanChuyen> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from VanChuyen";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var vanchuyen = new VanChuyen();
                        vanchuyen.MaVanChuyen = row["MaVanChuyen"].ToString();
                        vanchuyen.MaDonHang = row["MaDonHang"].ToString();
                        vanchuyen.NgayVanChuyen = row["NgayVanChuyen"].ToString();
                        vanchuyen.ChiPhiVanChuyen = (double)row["ChiPhiVanChuyen"];

                        listVanChuyen.Add(vanchuyen);
                    }
                }
                return listVanChuyen;
            }
            catch
            {
                throw;
            }

        }

        public List<VanChuyen> search(string txtMaVC)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {

                    con.ConnectionString = conStr;
                    string sql;
                    if (txtMaVC != "")
                        sql = "Select * from VanChuyen where MaVanChuyen = '" + txtMaVC + "'";
                    else
                        sql = "Select * from VanChuyen";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var vanchuyen = new VanChuyen();
                        vanchuyen.MaVanChuyen = row["MaVanChuyen"].ToString();
                        vanchuyen.MaDonHang = row["MaDonHang"].ToString();
                        vanchuyen.NgayVanChuyen = row["NgayVanChuyen"].ToString();
                        vanchuyen.ChiPhiVanChuyen = (double)row["ChiPhiVanChuyen"];

                        listVanChuyen.Add(vanchuyen);
                    }
                }
                return listVanChuyen;
            }
            catch
            {
                throw;
            }

        }
    }
}