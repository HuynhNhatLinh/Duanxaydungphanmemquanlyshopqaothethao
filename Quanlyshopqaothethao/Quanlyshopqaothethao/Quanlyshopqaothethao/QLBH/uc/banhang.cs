using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLBH.uc
{
    public partial class banhang : UserControl
    {
        KetNoi kn = new KetNoi();
        cCommonFunction tt = new cCommonFunction();
        
        public banhang()
        {
            InitializeComponent();
        }
        public DataTable HoaDonMaxID()
        {
            SqlCommand cmd = new SqlCommand("sp_HoaDonSelectID", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string autoidhd()
        {
            string _x = "";
            DataTable dt = new DataTable();
            dt = HoaDonMaxID();
            if (dt.Rows.Count == 0)
                _x = "HD000";
            else
                _x = dt.Rows[0]["MaHoaDon"].ToString();
            string kq = "";
            string left = _x.Substring(0, 2).ToString();
            string snew = _x.Substring(2, 3).ToString();
            int i = int.Parse(snew);
            i++;
            if (i < 10)
                kq = "00" + i.ToString();
            if (i >= 10 && i < 100)
                kq = "0" + i.ToString();
            if (i >= 100)
                kq = i.ToString();
            return left + kq;
        }
        public static string mahd = "";
        public static int chon = 0;
        bool check = true;
        public DataTable NhanVienGet()
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVienSelect", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SanPhamGet()
        {
            SqlCommand cmd = new SqlCommand("sp_SanPhamSelect", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable KhachHang()
        {
            SqlCommand cmd = new SqlCommand("sp_KhachHangSelect", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void banhang_Load(object sender, EventArgs e)
        {
            cbbTenKhachHang.DisplayMember = "TenKhachHang";
            cbbTenKhachHang.ValueMember = "ID";
            cbbTenKhachHang.DataSource = KhachHang();

            cbbHangHoa.DisplayMember = "TenSanPham";
            cbbHangHoa.ValueMember = "ID";
            cbbHangHoa.DataSource = SanPhamGet();

            cbbNhanVien.DisplayMember = "TenNhanVien";
            cbbNhanVien.ValueMember = "ID";
            cbbNhanVien.DataSource = NhanVienGet();
            if (lbMaHD.Text == "")
                btnInHD.Enabled=btnLuuHD.Enabled = btnThem.Enabled=btnHuyHD.Enabled= false;
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            lblThanhTien.Text =string.Empty;
            lblSoLuongSanPham.Text = string.Empty;
            lblBangChu.Text = string.Empty;
            dgDanhSach.Rows.Clear();
            lbMaHD.Text = autoidhd();
            btnLuuHD.Enabled = btnThem.Enabled=btnHuyHD.Enabled= true;
            
        }
        public DataTable KhachHangByID(int makh)
        {
            SqlCommand cmd = new SqlCommand("sp_KhachHangByID", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", makh);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SanPhamByID(int mahang)
        {
            SqlCommand cmd = new SqlCommand("sp_SanPhamByID", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", mahang);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void cbbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = KhachHangByID(int.Parse(cbbTenKhachHang.SelectedValue.ToString()));
            txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            txtSoDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
        }

        private void cbbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SanPhamByID(int.Parse(cbbHangHoa.SelectedValue.ToString()));
            //txtDVT.Text = dt.Rows[0]["DonViTinh"].ToString();
            txtDonGia.Text = dt.Rows[0]["GiaBan"].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int tongcong = 0;
            int soluongsp = 0;
            int masp = int.Parse(cbbHangHoa.SelectedValue.ToString());
            string tensp = cbbHangHoa.Text;

            int soluong = int.Parse(txtSoLuong.Text);
            int dongia = int.Parse(txtDonGia.Text);
            int thanhtien = soluong * dongia;
            if (dgDanhSach.Rows.Count == 0)
                dgDanhSach.Rows.Add(masp, tensp, soluong, dongia, thanhtien);
            else
            {
                foreach (DataGridViewRow dr in dgDanhSach.Rows)
                {
                    if (int.Parse(dr.Cells[0].Value.ToString()) == masp)
                        check = false;
                    else
                        check = true;
                }
                if (check == true)
                    dgDanhSach.Rows.Add(masp, tensp, soluong, dongia, thanhtien);
                else
                    MessageBox.Show("Bạn đã chọn sản phẩm này rồi", "Thông báo");
            }
            foreach (DataGridViewRow dr in dgDanhSach.Rows)
            {
                tongcong += int.Parse(dr.Cells[4].Value.ToString());
                soluongsp += int.Parse(dr.Cells[2].Value.ToString());
            }
            lblThanhTien.Text = tongcong + " vnđ";
            lblBangChu.Text = tt.DocTienBangChu(tongcong, " đồng.");
            lblSoLuongSanPham.Text = soluongsp.ToString();
        }
        public DataTable ThemHoaDon(string mahd, DateTime ngaylap, int manv, int makh)
        {
            SqlCommand cmd = new SqlCommand("sp_HoaDonInsert", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mahd", mahd);
            cmd.Parameters.AddWithValue("@ngaylap", ngaylap);
            cmd.Parameters.AddWithValue("@manv", manv);
            cmd.Parameters.AddWithValue("@makh", makh);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ThemChiTietHoaDon(string mahd, int masp, int soluong)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietHoaDonInsert", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mahd", mahd);
            cmd.Parameters.AddWithValue("@masp", masp);
            cmd.Parameters.AddWithValue("@soluong", soluong);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgDanhSach.Rows.Count == 0)
                    MessageBox.Show("Bạn chưa chọn sản phẩm nào", "Thông báo");
                else
                {
                    string mahd = lbMaHD.Text;
                    int manv = int.Parse(cbbNhanVien.SelectedValue.ToString());
                    int makh = int.Parse(cbbTenKhachHang.SelectedValue.ToString());
                    DateTime ngaylap = dtpNgayBan.Value;
                    ThemHoaDon(mahd, ngaylap, manv, makh);

                    for (int i = 0; i < dgDanhSach.Rows.Count; i++)
                    {
                        int mahang = int.Parse(dgDanhSach.Rows[i].Cells[0].Value.ToString());
                        int soluong = int.Parse(dgDanhSach.Rows[i].Cells[2].Value.ToString());
                        ThemChiTietHoaDon(mahd, mahang, soluong);
                    }
                    
                    MessageBox.Show("Tạo hóa đơn thành công", "Thông báo");
                    btnInHD.Enabled = true;
                    btnHuyHD.Enabled=btnLuuHD.Enabled=btnThem.Enabled=false;
                    btnThemHD.Enabled = true;
                    
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }
        }

        private void dtpNgayBan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            dgDanhSach.Rows.Clear();
            lblBangChu.Text= string.Empty;
            lblSoLuongSanPham.Text= string.Empty;
            lblThanhTien.Text= string.Empty;
            lbMaHD.Text= string.Empty;
            btnLuuHD.Enabled=btnThem.Enabled =false;
        }

        private void dgDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        public static string hoadon;
        private void btnInHD_Click(object sender, EventArgs e)
        {
            hoadon = lbMaHD.Text;
            frm.InHoaDon frm = new frm.InHoaDon();
            frm.ShowDialog();
        }
    }
}
