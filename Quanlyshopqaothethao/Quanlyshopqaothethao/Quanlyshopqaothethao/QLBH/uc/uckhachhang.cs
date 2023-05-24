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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLBH.uc
{
    public partial class uckhachhang : UserControl
    {
        public uckhachhang()
        {
            InitializeComponent();
        }
        KetNoi ttkh=new KetNoi();
        //public void timkhachhang()
        //{
        //    dataGridView1_DataSourc=ttkh.laybang("se")
        
        DataTable LoadKhachHang()
        {
            SqlCommand cmd = new SqlCommand("sp_KhachHangSelect", ttkh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable timkhachhang()
        {
            SqlCommand cmd = new SqlCommand("sp_KhachHangByID", ttkh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtid.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        private bool KiemTraThongTin()
        {
            if (txttenkh.Text == "")
            {
                MessageBox.Show("Vui lòng điền họ và tên Khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkh.Focus();
                return false;
            }

            if (txtsdt.Text == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại của Khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsdt.Focus();
                return false;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Vui lòng điền Địa chỉ của Khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return false;
            }
            if (dtpNgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng điền ngày sinh của Khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }
        DataTable NextID()
        {
            SqlCommand cmd = new SqlCommand("sp_NextID", ttkh.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenbang", "KhachHang");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable KhachHangDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_KhachHangDeleteByID", ttkh.connection()); //2
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void uckhachhang_Load(object sender, EventArgs e)
        {
            btnxoa.Enabled = btnthem.Enabled=btnsua.Enabled=button4.Enabled= false;
            dgdulieukhachhang.DataSource = LoadKhachHang();
        }
        //private void timkhachhang_Load(object sender, EventArgs e)
        //{
        //    dgdulieukhachhang.DataSource = timkhachhang();
        //}    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgdulieukhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnxoa.Enabled = button4.Enabled = true;
            DataGridViewRow dr = dgdulieukhachhang.CurrentRow;
            txtidkh.Text = dr.Cells[0].Value.ToString();
            txttenkh.Text = dr.Cells[1].Value.ToString();
            txtdiachi.Text = dr.Cells[2].Value.ToString();
            txtsdt.Text = dr.Cells[3].Value.ToString();
            dtpNgaySinh.Text = dr.Cells[4].Value.ToString();
        }

        private void dgdulieukhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnhienthiall_Click(object sender, EventArgs e)
        {
            dgdulieukhachhang.DataSource = LoadKhachHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgdulieukhachhang.DataSource = timkhachhang();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            
            if (KiemTraThongTin())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ThemKhachHang", ttkh.connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txttenkh.Text;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Text;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = txtsdt.Text;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtdiachi.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Thêm mới khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgdulieukhachhang.DataSource = LoadKhachHang();
                    txtid.Text = string.Empty;
                    txtsdt.Text = string.Empty;
                    txtidkh.Text = string.Empty;
                    txtdiachi.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtidkh.Text == "" || txtidkh.Text == "Thêm mới không cần ID")
            {
                MessageBox.Show("Vui lòng điền ID khách hàng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtid.Focus();
                txtid.SelectAll();
            }
            else if (KiemTraThongTin())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SuaKhachHang", ttkh.connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(txtidkh.Text);
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txttenkh.Text;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Text;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = txtsdt.Text;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtdiachi.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Sửa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgdulieukhachhang.DataSource = LoadKhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            txtidkh.Text = NextID().Rows[0]["ID"].ToString();
            txtsdt.Text = string.Empty;
            txttenkh.Text = string.Empty;
            txtdiachi.Text = string.Empty;
            txttenkh.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = true;
            txttenkh.Focus();
        }
       
        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá Khách hàng '" + txttenkh.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                dt = KhachHangDelete(int.Parse(txtidkh.Text));
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
                dgdulieukhachhang.DataSource = LoadKhachHang();
            }
        }
    }
}
