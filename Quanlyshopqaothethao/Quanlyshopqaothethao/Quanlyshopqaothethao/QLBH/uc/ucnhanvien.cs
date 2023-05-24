using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.uc
{
    public partial class ucnhanvien : UserControl
    {
        KetNoi kh=new KetNoi();
        public ucnhanvien()
        {
            InitializeComponent();
        }
        DataTable LoadNhanVien()
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVienSelect", kh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable timkhachhang()
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVienSelectByID", kh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@ten", textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        private bool KiemTraThongTin()
        {
            if (txttennv.Text == "")
            {
                MessageBox.Show("Vui lòng điền họ và tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttennv.Focus();
                return false;
            }
           
            if (txtsdt.Text == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsdt.Focus();
                return false;
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpNgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng điền ngày sinh của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }

        DataTable NextID()
        {
            SqlCommand cmd = new SqlCommand("sp_NextID", kh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenbang", "NhanVien");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable SanPhamDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVienDeleteByID", kh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable KhachHang(int id, string ten,DateTime ngaysinh, int sdt, int gt, bool status)
        {
            SqlCommand cmd = new SqlCommand("[sp_NhanVien]", kh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tennv", ten);
            cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cmd.Parameters.AddWithValue("@dienthoai", sdt);
            cmd.Parameters.AddWithValue("@gioitinh", gt);
            cmd.Parameters.AddWithValue("@status", status);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucnhanvien_Load(object sender, EventArgs e)
        {
            btnxoa.Enabled = btnthem.Enabled=btnsua.Enabled=button4.Enabled= false;
            dgdulieunv.DataSource = LoadNhanVien();
        }

        private void dgdulieukh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnxoa.Enabled = button4.Enabled = true;
            DataGridViewRow dr = dgdulieunv.CurrentRow;
            txtid.Text = dr.Cells[0].Value.ToString();
            txttennv.Text = dr.Cells[1].Value.ToString();
            dtpNgaySinh.Text = dr.Cells[2].Value.ToString();
            txtsdt.Text = dr.Cells[3].Value.ToString();
            string GioiTinh = Convert.ToString(dr.Cells[4].Value);
            if (GioiTinh.Trim() == "Nam")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            checkBox1.Checked = Convert.ToBoolean(dr.Cells[5].Value);
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnthem_Click(object sender, EventArgs e)
        {
          
            if (KiemTraThongTin())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ThemNhanVien", kh.connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txttennv.Text;
                    if (radioButton1.Checked == true)
                    {
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = radioButton1.Text;
                    }
                    else
                    {
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = radioButton2.Text;
                    }
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Text;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = txtsdt.Text;
                    cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = checkBox1.Checked;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Thêm mới nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgdulieunv.DataSource = LoadNhanVien();
                    txtid.Text = string.Empty;
                    txtsdt.Text = string.Empty;
                    txttennv.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtid.Text == "Thêm mới không cần ID")
            {
                MessageBox.Show("Vui lòng điền ID nhân viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtid.Focus();
                txtid.SelectAll();
            }
            else if (KiemTraThongTin())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SuaNhanVien", kh.connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(txtid.Text);
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txttennv.Text;
                    if (radioButton1.Checked == true)
                    {
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = radioButton1.Text;
                    }
                    else
                    {
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = radioButton2.Text;
                    }
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Text;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = txtsdt.Text;
                    cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = checkBox1.Checked;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Sửa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgdulieunv.DataSource = LoadNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            txttennv.Text= string.Empty;
            txtsdt.Text= string.Empty;
            txtid.Text= string.Empty;
            checkBox1 = new CheckBox();
            radioButton1.Checked=radioButton2.Checked= false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá sản phẩm '" + txttennv.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                dt = SanPhamDelete(int.Parse(txtid.Text));
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
                dgdulieunv.DataSource = LoadNhanVien();
            }
        }

        private void cbbgt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgdulieunv.DataSource = timkhachhang();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgdulieunv.DataSource = LoadNhanVien();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            txtid.Text = NextID().Rows[0]["ID"].ToString();
            txttennv.Text = "";
            txtsdt.Text = string.Empty;
            radioButton1.Checked=false; radioButton2.Checked=false;
            checkBox1.Checked=false;
            txttennv.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = true;
            txttennv.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
