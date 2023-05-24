using QLBH.uc;
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
    public partial class taotaikhoan : Form
    {
        KetNoi ll=new KetNoi();
        public taotaikhoan()
        {
            InitializeComponent();
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmdangnhap f = new frmdangnhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
            this.Close();
        }

        private void taotaikhoan_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtgmail.Text) || string.IsNullOrWhiteSpace(textBox1.Text) ||
    string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin",
                                "Thông Báo");
                return;
            }

            SqlCommand cmd = new SqlCommand("SP_taotk", ll.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email",txtgmail.Text);
            cmd.Parameters.AddWithValue("@tendn", textBox1.Text);
            cmd.Parameters.AddWithValue("@mk", textBox2.Text);
            cmd.Parameters.AddWithValue("@mk2", textBox3.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Convert.ToInt16(dt.Rows[0]["errcode"]) == 1)
            {
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString(),
                    "Thông Báo");
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
            }
            else if (Convert.ToInt16(dt.Rows[0]["errcode"]) == 0
                && dt.Rows[0]["errmsg"].ToString() == "Tên đăng nhập đã tồn tại")
            {
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString(),
                    "Thông Báo");
                textBox1.Focus();
            }

            else
            {
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString(),
                    "Thông Báo");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;
                textBox3.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void txtgmail_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
