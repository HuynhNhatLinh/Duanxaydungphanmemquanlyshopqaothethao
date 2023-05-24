using QLBH.Repost;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBH.frm
{
    public partial class SanPhambyLSP : Form
    {
        KetNoi ncc = new KetNoi();
        DataTable LoadLoaiSanPham()
        {
            SqlCommand cmd = new SqlCommand("sp_LoaiSPSelect", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public SanPhambyLSP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("[sp_SanPhamSelectByLoaiSP]", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@loai", Convert.ToInt32(comboBox1.SelectedValue));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            da.Fill(dt);
            rpSPbyLSP r= new rpSPbyLSP();
            r.SetDataSource(dt);
            crystalReportViewer1.ReportSource = r;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void SanPhambyLSP_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = LoadLoaiSanPham();
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "ID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            //Repost.rpSPbyLSP rpt = new Repost.rpSPbyLSP();
            //crystalReportViewer1.ReportSource = rpt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
