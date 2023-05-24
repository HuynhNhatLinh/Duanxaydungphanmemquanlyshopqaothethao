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
    public partial class ucnhacungcap : UserControl
    {
        public ucnhacungcap()
        {
            InitializeComponent();
        }
        KetNoi ncc=new KetNoi();
        DataTable LoadNhaCungCap()
        {
            SqlCommand cmd = new SqlCommand("sp_NhaCungCapSelect", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable NextID()
        {
            SqlCommand cmd = new SqlCommand("sp_NextID", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenbang", "NhaCungCap");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable SanPhamDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("[sp_NhaCungCapDeleteByID]", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable NhaCungCap(int id, string nhacc, string diachi, int sdt, bool status)
        {
            SqlCommand cmd = new SqlCommand("[sp_NhaCungCap]", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tennhacc", nhacc);
            cmd.Parameters.AddWithValue("@phone", sdt);
            cmd.Parameters.AddWithValue("@diachi", diachi);
            cmd.Parameters.AddWithValue("@status", status);
            //cmd.Parameters.AddWithValue("@chon", chon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void ucnhacungcap_Load(object sender, EventArgs e)
        {
            button3.Enabled = button2.Enabled = false;
            dgdulieunhacc.DataSource = LoadNhaCungCap();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = NextID().Rows[0]["ID"].ToString();
            txttenncc.Text = "";
            txtsdt.Text =string.Empty;
            //txtid.Text=string.Empty;
            txtdiachi.Text =string.Empty;
            ckbtt.Checked = false;
            txttenncc.Focus();
        }

        private void dgdulieukhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = button3.Enabled = true;
            DataGridViewRow dr = dgdulieunhacc.CurrentRow;
            txtid.Text = dr.Cells[0].Value.ToString();
            txttenncc.Text = dr.Cells[1].Value.ToString();
            txtdiachi.Text = dr.Cells[2].Value.ToString();
            txtsdt.Text = dr.Cells[3].Value.ToString();
            ckbtt.Checked = Convert.ToBoolean(dr.Cells[4].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá nhà cung cấp '" + txttenncc.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                dt = SanPhamDelete(int.Parse(txtid.Text));
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
                dgdulieunhacc.DataSource = LoadNhaCungCap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttenncc.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt =NhaCungCap(int.Parse(txtid.Text), txttenncc.Text,txtdiachi.Text, int.Parse(txtsdt.Text), ckbtt.Checked);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString(),
                "Thông Báo");
            dgdulieunhacc.DataSource = LoadNhaCungCap();
        }
    }
}
