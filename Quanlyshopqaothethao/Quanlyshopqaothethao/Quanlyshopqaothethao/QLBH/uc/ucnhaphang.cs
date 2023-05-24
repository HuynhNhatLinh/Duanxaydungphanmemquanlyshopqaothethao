using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.uc
{
    public partial class ucnhaphang : UserControl
    {
        KetNoi pn = new KetNoi();
        cCommonFunction tt = new cCommonFunction();
        public ucnhaphang()
        {
            InitializeComponent();
        }
        public DataTable PhieuNhapMaxID()
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuNhapSelectID", pn.connection());
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
            dt = PhieuNhapMaxID();
            if (dt.Rows.Count == 0)
                _x = "PN000";
            else
                _x = dt.Rows[0]["MaPhieuNhap"].ToString();
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
        public static string mapn = "";
        public static int chon = 0;
        bool check = true;

        public DataTable NhanVienGet()
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVienSelect", pn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SanPhamGet()
        {
            SqlCommand cmd = new SqlCommand("sp_SanPhamSelect", pn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NhaCungCap()
        {
            SqlCommand cmd = new SqlCommand("sp_NhaCungCapSelect", pn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NhaCungCapById(int mancc)
        {
            SqlCommand cmd = new SqlCommand("sp_NhaCungCapByID", pn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", mancc);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SanPhamByID(int mahang)
        {
            SqlCommand cmd = new SqlCommand("sp_SanPhamByID", pn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", mahang);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ThemPhieuNhap(string mahd, DateTime ngaylap, int manv, int makh)
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuNhapInsert", pn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mapn", mahd);
            cmd.Parameters.AddWithValue("@ngaylap", ngaylap);
            cmd.Parameters.AddWithValue("@manv", manv);
            cmd.Parameters.AddWithValue("@mancc", makh);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ThemChiTietPhieuNhap(string mahd, int masp, int soluong)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuNhapInsert", pn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mapn", mahd);
            cmd.Parameters.AddWithValue("@masp", masp);
            cmd.Parameters.AddWithValue("@soluong", soluong);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void ucnhaphang_Load(object sender, EventArgs e)
        {
            cbbTenNhaCC.DisplayMember = "TenNhaCungCap";
            cbbTenNhaCC.ValueMember = "ID";
            cbbTenNhaCC.DataSource = NhaCungCap();

            cbbHangHoa.DisplayMember = "TenSanPham";
            cbbHangHoa.ValueMember = "ID";
            cbbHangHoa.DataSource = SanPhamGet();

            cbbNhanVien.DisplayMember = "TenNhanVien";
            cbbNhanVien.ValueMember = "ID";
            cbbNhanVien.DataSource = NhanVienGet();
            if (lbMaHD.Text == "")
                btnLuuPn.Enabled = btnThem.Enabled = btnHuyPN.Enabled = false;
            //btnInPN.Enabled = false;

        }

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            lblBangChu.Text =string.Empty;
            lblSoLuongSanPham.Text = string.Empty;
            lblThanhTien    .Text = string.Empty;
            dgDanhSach.Rows.Clear();
            lbMaHD.Text = autoidhd();
            btnLuuPn.Enabled = btnThem.Enabled = btnHuyPN.Enabled = true;
            
        }

        private void cbbTenNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = NhaCungCapById(int.Parse(cbbTenNhaCC.SelectedValue.ToString()));
            txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            txtSoDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
        }

        private void cbbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SanPhamByID(int.Parse(cbbHangHoa.SelectedValue.ToString()));
            //txtDVT.Text = dt.Rows[0]["DonViTinh"].ToString();
            txtDonGia.Text = dt.Rows[0]["GiaNhap"].ToString();
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

        private void btnLuuPn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDanhSach.Rows.Count == 0)
                    MessageBox.Show("Bạn chưa chọn sản phẩm nào", "Thông báo");
                else
                {
                    string mapn = lbMaHD.Text;
                    int manv = int.Parse(cbbNhanVien.SelectedValue.ToString());
                    int makh = int.Parse(cbbTenNhaCC.SelectedValue.ToString());
                    DateTime ngaylap = dtpNgayBan.Value;
                    ThemPhieuNhap(mapn, ngaylap, manv, makh);

                    for (int i = 0; i < dgDanhSach.Rows.Count; i++)
                    {
                        int mahang = int.Parse(dgDanhSach.Rows[i].Cells[0].Value.ToString());
                        int soluong = int.Parse(dgDanhSach.Rows[i].Cells[2].Value.ToString());
                        ThemChiTietPhieuNhap(mapn, mahang, soluong);
                    }
                    MessageBox.Show("Tạo Phiếu Nhập thành công", "Thông báo");
                    //btnInPN.Enabled = true;
                    btnHuyPN.Enabled = btnLuuPn.Enabled = btnThem.Enabled = false;
                    btnThemPN.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }
        }

        private void dgDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHuyPN_Click(object sender, EventArgs e)
        {
            dgDanhSach.Rows.Clear();
            lblBangChu.Text = string.Empty;
            lblThanhTien.Text = string.Empty;
            lblSoLuongSanPham.Text = string.Empty;
            lbMaHD.Text = string.Empty;
            btnLuuPn.Enabled=btnThem.Enabled=false;
        }
        public static string hoadon;
        private void btnInPN_Click(object sender, EventArgs e)
        {
            hoadon = lbMaHD.Text;
            frm.InPhieuNhap frm = new frm.InPhieuNhap();
            frm.ShowDialog();
        }
    }
}
