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
    public partial class ucdoimk : UserControl
    {
        KetNoi doimk = new KetNoi();

        public ucdoimk()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucdoimk_Load(object sender, EventArgs e)
        {

        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_DangNhapChangePassword", doimk.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tendn", txttendn.Text);
            cmd.Parameters.AddWithValue("@mkcu", txtmkcu.Text);
            cmd.Parameters.AddWithValue("@mkmoi",txtmkmoi.Text);
            cmd.Parameters.AddWithValue("@xnmkmoi", txtxnmk.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Convert.ToInt16(dt.Rows[0]["errcode"]) == 1)
            {
                MessageBox.Show("Đổi mật khẩu thành công");
                txtmkcu.Text = string.Empty;
                txtmkmoi.Text= string.Empty;
                txttendn.Text = string.Empty;
                txtxnmk.Text = string.Empty;
            }
            else
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMK.Checked)
            {
                txtmkcu.PasswordChar = (char)0;
                txtmkmoi.PasswordChar = (char)0;
                txtxnmk.PasswordChar = (char)0;
            }
            else
            {
                txtmkcu.PasswordChar = '*';
                txtmkmoi.PasswordChar = '*';
                txtxnmk.PasswordChar = '*';
            }
        }

        private void txtmkmoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtxnmk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}