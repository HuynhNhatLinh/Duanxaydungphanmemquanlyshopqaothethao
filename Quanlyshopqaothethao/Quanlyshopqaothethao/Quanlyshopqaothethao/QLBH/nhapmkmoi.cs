using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLBH
{
    public partial class nhapmkmoi : Form
    {
        string username = QuenMK.to;
        KetNoi cl=  new KetNoi();
        public nhapmkmoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text) {
                SqlCommand cmd = new SqlCommand("sp_taomkmoi", cl.connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mkmoi", textBox1.Text);
                cmd.Parameters.AddWithValue("@tendn", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Tạo mật khẩu mới thành công");
            }
            else
            {
                MessageBox.Show("Lỗi trong quá trình tạo mật khẩu mới vui lòng thử lại");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nhapmkmoi_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmdangnhap f = new frmdangnhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
            this.Close();
        }
    }
}
