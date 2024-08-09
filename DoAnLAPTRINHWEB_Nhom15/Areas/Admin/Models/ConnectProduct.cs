using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnLAPTRINHWEB_Nhom15.Areas.Admin.Models
{
    public class ConnectProduct:ConnectSQL
    {
        ProductDetail a = new ProductDetail();
        List<Products> listProduct = new List<Products>();
        SqlCommand cmd = new SqlCommand();
        public List<Products> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from SanPham";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var product = new Products();
                        product.MaSanPham = row["MaSanPham"].ToString();
                        product.TenSanPham = row["TenSanPham"].ToString();
                        product.Gia = (double)row["Gia"];
                        product.MoTa = row["MoTa"].ToString();
                        product.Anh = row["Anh"].ToString();
                        product.MaLoai = row["MaLoai"].ToString();
                        product.MaNhaSanXuat = row["MaNhaSanXuat"].ToString();
                        product.SanPhamTon = (int)row["SanPhamTon"]; 
                        product.SanPhamDaBan = (int)row["SanPhamDaBan"];

                        listProduct.Add(product);
                    }
                }
                return listProduct;
            }
            catch
            {
                throw;
            }
        }
        public List<Products> search(string txtTenSP, string txtLowPrice, string txtHighPrice)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    double LP = 0;
                    if (txtLowPrice != "")
                        LP = double.Parse(txtLowPrice);
                    double HP = 0;
                    if (txtHighPrice != "")
                        HP = double.Parse(txtHighPrice);
                    con.ConnectionString = conStr;
                    string sql = "";

                    if (txtTenSP == "" && txtLowPrice == "" && txtHighPrice == "")
                        sql = "Select * from SanPham";
                    if (txtTenSP != "" && txtLowPrice != "" && txtHighPrice != "")
                        sql = "Select * from SanPham where TenSanPham LIKE '%" + txtTenSP + "%' and Gia >= " + LP + " and Gia <= " + HP + "";
                    if (txtTenSP != "" && txtLowPrice == "" && txtHighPrice == "")
                        sql = "Select * from SanPham where TenSanPham LIKE '%" + txtTenSP + "%'";
                    if (txtTenSP == "" && txtLowPrice != "" && txtHighPrice != "")
                        sql = "Select * from SanPham where Gia between " + LP + " and " + HP + "";
                    if (txtTenSP != "" && txtLowPrice != "" && txtHighPrice == "")
                        sql = "Select * from SanPham where TenSanPham LIKE '%" + txtTenSP + "%' and Gia >= " + LP + "";
                    if (txtTenSP == "" && txtLowPrice == "" && txtHighPrice != "")
                        sql = "Select * from SanPham where Gia <= " + HP + "";

                    if (txtTenSP != "" && txtLowPrice == "" && txtHighPrice != "")
                        sql = "Select * from SanPham where TenSanPham LIKE '%" + txtTenSP + "%' and  Gia <= " + HP + "";
                    if (txtTenSP == "" && txtLowPrice != "" && txtHighPrice == "")
                        sql = "Select * from SanPham where  Gia >= " + LP + "";

                    if (txtLowPrice != "" && txtHighPrice == "")
                        sql = "Select * from SanPham ORDER BY Gia ASC";
                    if (txtLowPrice == "" && txtHighPrice != "")
                        sql = "Select * from SanPham ORDER BY Gia DESC";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var product = new Products();
                        product.MaSanPham = row["MaSanPham"].ToString();
                        product.TenSanPham = row["TenSanPham"].ToString();
                        product.Gia = (double)row["Gia"];
                        product.MoTa = row["MoTa"].ToString();
                        product.Anh = row["Anh"].ToString();
                        product.MaLoai = row["MaLoai"].ToString();
                        product.MaNhaSanXuat = row["MaNhaSanXuat"].ToString();
                        product.SanPhamTon = (int)row["SanPhamTon"];
                        product.SanPhamDaBan = (int)row["SanPhamDaBan"];
                        listProduct.Add(product);
                    }
                }

                return listProduct;
            }
            catch
            {
                throw;
            }
        }
        //delete 
        public int DelectProduct(string txtMaSanPham)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.Open();
            string sql2 = "select count(*) from ChiTietDonHang where MaSanPham = '" + txtMaSanPham + "'";
            cmd.CommandText = sql2;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();

            if (kt == 0)
            {
                string sql = "delete from SanPham where MaSanPham = '" + txtMaSanPham + "'";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }

            con.Close();
            return rs;
        }
        // add
        public int AddProduct(Products product)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "select count(*) from SanPham where MaSanPham = '" + product.MaSanPham + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();
            if (kt == 0)
            {
                string sql2 = "insert into SanPham values('" + product.MaSanPham + "', N'" + product.TenSanPham + "', " + product.Gia + ", N'" + product.MoTa + "', N'" + product.Anh + "', '" + product.MaLoai + "', '" + product.MaNhaSanXuat + "'," + product.SanPhamTon + ")";
                cmd.CommandText = sql2;
                rs = cmd.ExecuteNonQuery();
            }
            return rs;
        }
        //---------edit
        public int UpdateProduct(Products pd)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.Open();
            string skt2 = "select count(*) from LoaiSanPham where MaLoai='" + pd.MaLoai + "'";
            string skt3 = "select count(*) from NhaSanXuat where MaNhaSanXuat='" + pd.MaNhaSanXuat + "'";
            cmd.CommandText = skt2;
            cmd.Connection = con;
            int kt2 = (int)cmd.ExecuteScalar();
            cmd.CommandText = skt3;
            cmd.Connection = con;
            int kt3 = (int)cmd.ExecuteScalar();
            int rs = 0;
            if (kt2 != 0 && kt3 != 0)
            {
                string sql = "update SanPham set MaSanPham='" + pd.MaSanPham + "', TenSanPham=N'" + pd.TenSanPham + "', Gia=" + pd.Gia + ",MoTa=N'" + pd.MoTa + "',Anh='" + pd.Anh + "',MaLoai='" + pd.MaLoai + "',MaNhaSanXuat='" + pd.MaNhaSanXuat + "',SanPhamTon=" + pd.SanPhamTon + " where MaSanPham ='" + pd.MaSanPham + "' ";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }
            return rs;

        }
        public List<Products> ProductBySelected(string txtPrice, string txtType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "";

                    if (txtType != null)
                    {
                        if (txtPrice == "ASC")
                            sql = "Select * from SanPham where MaLoai='" + txtType + "' ORDER BY Gia ASC";
                        if (txtPrice == "DESC")
                            sql = "Select * from SanPham MaLoai='" + txtType + "' ORDER BY Gia DESC";
                        if (txtPrice == "Default")
                            sql = "Select * from SanPham MaLoai='" + txtType + "'";
                    }
                    else
                    {
                        if (txtPrice == "Popular")
                            sql = "select top 9 * from SanPham ORDER BY SanPhamDaBan desc";
                        if (txtPrice == "ByTheMost")
                            sql = "Select * from SanPham ORDER BY SanPhamDaBan DESC";
                        if (txtPrice == "ASC")
                            sql = "Select * from SanPham ORDER BY Gia ASC";
                        if (txtPrice == "DESC")
                            sql = "Select * from SanPham ORDER BY Gia DESC";
                        if (txtPrice == "Default")
                            sql = "Select * from SanPham";
                    }


                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var product = new Products();
                        product.MaSanPham = row["MaSanPham"].ToString();
                        product.TenSanPham = row["TenSanPham"].ToString();
                        product.Gia = (double)row["Gia"];
                        product.MoTa = row["MoTa"].ToString();
                        product.Anh = row["Anh"].ToString();
                        product.MaLoai = row["MaLoai"].ToString();
                        product.MaNhaSanXuat = row["MaNhaSanXuat"].ToString();
                        product.SanPhamTon = (int)row["SanPhamTon"];
                        product.SanPhamDaBan = (int)row["SanPhamDaBan"];
                        listProduct.Add(product);
                    }
                }

                return listProduct;
            }
            catch
            {
                throw;
            }
        }
        public List<Products> ProductByType(string txtType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from SanPham where MaLoai='"+txtType+"'";

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var product = new Products();
                        product.MaSanPham = row["MaSanPham"].ToString();
                        product.TenSanPham = row["TenSanPham"].ToString();
                        product.Gia = (double)row["Gia"];
                        product.MoTa = row["MoTa"].ToString();
                        product.Anh = row["Anh"].ToString();
                        product.MaLoai = row["MaLoai"].ToString();
                        product.MaNhaSanXuat = row["MaNhaSanXuat"].ToString();
                        product.SanPhamTon = (int)row["SanPhamTon"];
                        product.SanPhamDaBan = (int)row["SanPhamDaBan"];
                        listProduct.Add(product);
                    }
                }

                return listProduct;
            }
            catch
            {
                throw;
            }
        }
        public  ProductDetail ChiTietSP(string txtMaSP)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "select * from ChitietSP where MaSanPham='"+txtMaSP+"'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var p = new ProductDetail();
                        p.MaCT = row["MaCT"].ToString();
                        p.ThuongHieu = row["ThuongHieu"].ToString();
                        p.MaSanPham = row["MaSanPham"].ToString();
                        p.TenSanPham = row["TenSanPham"].ToString();
                        p.Gia = (double)row["Gia"];
                        p.Anh1 = row["Anh1"].ToString();
                        p.Anh2 = row["Anh2"].ToString();
                        p.Anh3 = row["Anh3"].ToString();
                        p.MoTa1 = row["MoTa1"].ToString();
                        p.MoTa2 = row["MoTa2"].ToString();
                        p.MoTa3 = row["MoTa3"].ToString();
                        p.MoTa4 = row["MoTa4"].ToString();
                        a = new ProductDetail(p.MaCT, p.ThuongHieu, p.MaSanPham, p.TenSanPham, p.Gia, p.Anh1, p.Anh2, p.Anh3, p.MoTa1, p.MoTa2, p.MoTa3, p.MoTa4);
                    }
                }

                return a;
            }
            catch
            {
                throw;
            }
        }
        public int getMaLoai(string masp)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sql = "select count(*) from ChitietSP ct, SanPham sp where  ct.MaSanPham=sp.MaSanPham and MaLoai='LSP1' and sp.MaSanPham='"+masp+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int maloai = 0;
            maloai =(int)cmd.ExecuteScalar();
            con.Close();
            return maloai;
        }
    }
}