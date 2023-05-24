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
    public partial class ucloaisanpham : UserControl
    {
        public ucloaisanpham()
        {
            InitializeComponent();
        }
        KetNoi lsp= new KetNoi();
        DataTable LoadLoaiSanPham()
        {
            SqlCommand cmd = new SqlCommand("sp_LoaiSanphamSelect", lsp.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable NextID()
        {
            SqlCommand cmd = new SqlCommand("sp_NextID", lsp.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenbang", "LoaiSanPham");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable SanPhamDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_LoaiSanPhamDeleteByID", lsp.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable LoaiSanPham(int id, string loaisp,bool status)
        {
            SqlCommand cmd = new SqlCommand("[sp_LoaiSanPham]", lsp.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ten", loaisp);
            cmd.Parameters.AddWithValue("@status", status);
            //cmd.Parameters.AddWithValue("@chon", chon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Text = NextID().Rows[0]["ID"].ToString();
            txtloaisp.Text = "";
            ckbtt.Checked= false;
            txtloaisp.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ucLoaiSanPham_Load(object sender, EventArgs e)
        {
            btnsua.Enabled = btnxoa.Enabled = false;
            dgdulieuloaisp.DataSource = LoadLoaiSanPham();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void dgdulieuloaisp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewRow dr = dgdulieuloaisp.CurrentRow;
        //    txtid.Text = dr.Cells[0].Value.ToString();
        //    txtloaisp.Text = dr.Cells[1].Value.ToString();
        //    ckbtt.Checked = Convert.ToBoolean(dr.Cells[2].Value);
        //}

        private void ckbtt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ucloaisp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgdulieuloaisp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnxoa.Enabled = btnsua.Enabled = true;
            DataGridViewRow dr = dgdulieuloaisp.CurrentRow;
            txtid.Text = dr.Cells[0].Value.ToString();
            txtloaisp.Text = dr.Cells[1].Value.ToString();
            ckbtt.Checked = Convert.ToBoolean(dr.Cells[2].Value);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá sản phẩm '" + txtloaisp.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                dt = SanPhamDelete(int.Parse(txtid.Text));
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
                dgdulieuloaisp.DataSource = LoadLoaiSanPham();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtloaisp.Focus();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = LoaiSanPham(int.Parse(txtid.Text), txtloaisp.Text, ckbtt.Checked);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString(),
                "Thông Báo");
            dgdulieuloaisp.DataSource = LoadLoaiSanPham();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
