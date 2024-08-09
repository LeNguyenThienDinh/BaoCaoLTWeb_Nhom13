using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectTaiKhoan:ConnectSQL
    {
        List<TaiKhoan> lstTaiKhoan = new List<TaiKhoan>();
        SqlCommand cmd = new SqlCommand();
        public List<TaiKhoan> ViewTaiKhoan()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    
                    con.ConnectionString = conStr;
                    con.Open();
                    string sql = "select * from TaiKhoan where VaiTro='User'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var tk = new TaiKhoan();
                        tk.VaiTro = row["VaiTro"].ToString();
                        tk.Email = row["Email"].ToString();
                        tk.HoTen = row["HoTen"].ToString();
                        DateTime a=DateTime.Parse( row["NgaySinh"].ToString());
                        tk.NgaySinh = a.ToString("dd/MM/yyyy");
                        tk.GioiTinh = row["GioiTinh"].ToString();
                        tk.SoDienThoai = row["SoDienThoai"].ToString();
                        tk.TenDN = row["TenDN"].ToString();
                        tk.MatKhau = row["MatKhau"].ToString();
                        tk.AnhBiaUser = row["AnhBiaUser"].ToString();

                        lstTaiKhoan.Add(tk);
                    }
                    con.Close();
                }
                return lstTaiKhoan;
            }
            catch
            {
                throw;
            }

        }
        
        public int deleteTaiKhoan (string tenDN)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sql = "delete from TaiKhoan where TenDN='"+tenDN+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int maloai = 0;
            maloai = cmd.ExecuteNonQuery();
            con.Close();
            return maloai;
        }
        public List<TaiKhoan> ShowTaiKhoan(string Tendn)
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = conStr;
                string sql = "select * from TaiKhoan where TenDN = '" + Tendn + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var dh = new TaiKhoan();
                    dh.VaiTro = row["VaiTro"].ToString();
                    dh.Email = row["Email"].ToString();
                    dh.HoTen = row["HoTen"].ToString();
                    dh.NgaySinh = row["NgaySinh"].ToString();
                    dh.GioiTinh = row["GioiTinh"].ToString();
                    dh.SoDienThoai = row["SoDienThoai"].ToString();
                    dh.TenDN = row["TenDN"].ToString();
                    dh.MatKhau = row["MatKhau"].ToString();
                    dh.AnhBiaUser = row["AnhBiaUser"].ToString();
                    lstTaiKhoan.Add(dh);
                }
            }
            return lstTaiKhoan;
        }
        public int UpdateTaiKhoan(TaiKhoan taikhoan)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conStr;
                con.Open();
                string sql = "select count(*) from TaiKhoan where TenDN='" + taikhoan + "' and VaiTro='User'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                int rs = 0;
                int kt = (int)cmd.ExecuteScalar();
                string tk = taikhoan.TenDN;
                if (kt == 0)
                {
                    string sql2 = "update TaiKhoan set Email ='" + taikhoan.Email + "', HoTen = N'" + taikhoan.HoTen + "', NgaySinh = N'" + taikhoan.NgaySinh + "', GioiTinh = N'" + taikhoan.GioiTinh + "', SoDienThoai = N'" + taikhoan.SoDienThoai + "' where TenDN='" + tk + "' ";
                    cmd.CommandText = sql2;
                    rs = cmd.ExecuteNonQuery();
                }


                return rs;
            }
            catch
            {
                return 0;
            }

        }
        public void updateMatKhau(string tendn,string MK)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "exec UpdateMK '" + MK + "','"+ tendn + "' " ;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public int TestDangKy(TaiKhoan TaiKhoan)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string strcmd = "select count(*) from TaiKhoan where Email='" + TaiKhoan.Email + "' AND TenDN ='" + TaiKhoan.TenDN + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strcmd;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();
            if (kt == 0)
            {
                string strcmd2 = "insert into TaiKhoan values('User','" + TaiKhoan.Email + "', N'" + TaiKhoan.HoTen + "', '" + TaiKhoan.NgaySinh + "',N'" + TaiKhoan.GioiTinh + "',N'" + TaiKhoan.SoDienThoai + "',N'" + TaiKhoan.TenDN + "',N'" + TaiKhoan.MatKhau + "',null)";
                cmd.CommandText = strcmd2;
                rs = cmd.ExecuteNonQuery();
            }
            return rs;
        }
        public int AddDiaChi(string tenDN, DiaChi diachi)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "insert into DiaChi(TenDN,ChiTietDiaChi,ChiTietDiaChi2) values(N'"+tenDN+"',N'" + diachi.ChiTietDiaChi+ "',N'" + diachi.ChiTietDiaChi2 + "')  ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;        
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;
        }
        public DiaChi ShowDiaChi(string Tendn)
        {
            DiaChi dc = new DiaChi();
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = conStr;
                string sql = "select ChiTietDiaChi,ChiTietDiaChi2 from DiaChi where TenDN = '" + Tendn + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                
                foreach (DataRow row in dt.Rows)
                {
                 
                    dc.ChiTietDiaChi= row["ChiTietDiaChi"].ToString();
                    dc.ChiTietDiaChi2 = row["ChiTietDiaChi2"].ToString();
                    
                }
            }
            return dc;
        }

    }
}