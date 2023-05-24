using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLBH.uc
{
    public partial class ucSanPham : UserControl
    {
        KetNoi kn = new KetNoi();
        DataTable LoadSanPham()
        {
            SqlCommand cmd = new SqlCommand("sp_SanPhamSelect", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable LoadLoaiSanPham()
        {
            SqlCommand cmd = new SqlCommand("sp_LoaiSanphamselect", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable NextID()
        {
            SqlCommand cmd = new SqlCommand("sp_NextID", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenbang", "SanPham");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable SanPhamDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_SanPhamDeleteByID", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable SanPham(int id, string ten,int gianhap, int giaban, int sl,int loaisp,bool status)
        {
            SqlCommand cmd = new SqlCommand("[sp_SanPham]", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tensp", ten);
            cmd.Parameters.AddWithValue("@gianhap", gianhap);
            cmd.Parameters.AddWithValue("@giaban", giaban);
            cmd.Parameters.AddWithValue("@soluong", sl);
            cmd.Parameters.AddWithValue("@loaisp", loaisp);
            cmd.Parameters.AddWithValue("@status", status);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public ucSanPham()
        {
            InitializeComponent();
        }

        private void ucSanPham_Load(object sender, EventArgs e)
        {
            button3.Enabled = button2.Enabled = false;
            dgDuLieu.DataSource = LoadSanPham();
            cbbLoai.DataSource = LoadLoaiSanPham();
            cbbLoai.DisplayMember = "TenLoai";
            cbbLoai.ValueMember = "ID";
        }

        private void dgDuLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = button2.Enabled = true;
            DataGridViewRow dr = dgDuLieu.CurrentRow;
            txtID.Text = dr.Cells[0].Value.ToString();
            txtTen.Text = dr.Cells[1].Value.ToString();
            txtGiaNhap.Text = dr.Cells[2].Value.ToString();
            txtGiaBan.Text = dr.Cells[3].Value.ToString();
            txtSoLuong.Text = dr.Cells[4].Value.ToString();
            cbbLoai.SelectedValue = dr.Cells[5].Value.ToString();
            chkTrangThai.Checked =Convert.ToBoolean( dr.Cells[6].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtID.Text = NextID().Rows[0]["ID"].ToString();
            txtTen.Text = txtGiaNhap.Text = txtGiaBan.Text = txtSoLuong.Text = "";
            txtTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SanPham(int.Parse(txtID.Text), txtTen.Text, int.Parse(txtGiaNhap.Text), 
                int.Parse(txtGiaBan.Text), int.Parse(txtSoLuong.Text), int.Parse(cbbLoai.SelectedValue.ToString()),chkTrangThai.Checked);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            dgDuLieu.DataSource = LoadSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá sản phẩm '" + txtTen.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                dt = SanPhamDelete(int.Parse(txtID.Text));
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
                dgDuLieu.DataSource = LoadSanPham();
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgDuLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
