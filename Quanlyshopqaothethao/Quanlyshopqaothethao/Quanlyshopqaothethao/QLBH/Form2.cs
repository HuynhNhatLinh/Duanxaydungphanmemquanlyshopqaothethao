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

namespace QLBH
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDN.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin",
                                "Thông Báo");
                return;
            }
            KetNoi dangnhap = new KetNoi();
            SqlCommand cmd = new SqlCommand("sp_NhanVienDangNhap", dangnhap.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tendn", txtTenDN.Text);
            cmd.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Convert.ToInt16(dt.Rows[0]["errcode"]) == 1)
            {
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString(),
                    "Thông Báo");
                txtTenDN.Text = string.Empty;
                txtMatKhau.Text = string.Empty;
                frmMain f = new frmMain();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            
            else
            {
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString(),
                    "Thông Báo");
                txtMatKhau.Text = string.Empty;
                frmdangnhap a= new frmdangnhap();
            }
        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult cc = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Thông Báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
                if (cc == DialogResult.Yes)
                Close();
            else if (cc == DialogResult.No)
                MessageBox.Show("Mời bạn tiếp tục đăng nhập",
                    "Thông Báo");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taotaikhoan ttk=new taotaikhoan();
            this.Hide();
            ttk.ShowDialog();
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            taotaikhoan ttk = new taotaikhoan();
            this.Hide();
            ttk.ShowDialog();
            this.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMK ttk = new QuenMK();
            this.Hide();
            ttk.ShowDialog();
            this.Show();
            this.Close();
        }
    }
}
