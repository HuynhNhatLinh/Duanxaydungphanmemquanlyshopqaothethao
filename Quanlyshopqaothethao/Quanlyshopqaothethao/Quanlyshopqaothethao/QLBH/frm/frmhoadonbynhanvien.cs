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

namespace QLBH.frm
{
    public partial class frmhoadonbynhanvien : Form
    {
        KetNoi ncc = new KetNoi();
        public frmhoadonbynhanvien()
        {
            InitializeComponent();
        }
        DataTable LoadNhanVien()
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVienselectall", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmhoadonbynhanvien_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = LoadNhanVien();
            comboBox1.DisplayMember = "TenNhanVien";
            comboBox1.ValueMember = "ID";
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_InHoaDonByNhanVien", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nhanvien", Convert.ToInt32(comboBox1.SelectedValue));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rphoadonbynv r = new rphoadonbynv();
            r.SetDataSource(dt);
            crystalReportViewer1.ReportSource = r;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
