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

namespace QLBH.uc
{
    public partial class ucTraCuuphieunhap : UserControl
    {
        public ucTraCuuphieunhap()
        {
            InitializeComponent();
        }
        KetNoi kn=new KetNoi();
        DataTable LoadPhieuNhap()
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuNhapSelectAll", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadChiTietPhieuNhap(string mapn)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuNhapByMaHD", kn.connection());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mapn", mapn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucTraCuuphieunhap_Load(object sender, EventArgs e)
        {
           dgPhieuNhap.DataSource= LoadPhieuNhap();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public static string mapn = "";
        private void dgPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs c)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[c.ColumnIndex] is DataGridViewButtonColumn && c.RowIndex >= 0)
            {
                DataGridViewRow dr = dgPhieuNhap.CurrentRow;
                mapn = dr.Cells[1].Value.ToString();
                frm.frmPhieuNhap frm = new frm.frmPhieuNhap();
                frm.ShowDialog();
            }
            else
            {
                DataGridViewRow dr = dgPhieuNhap.CurrentRow;
                string mapn = dr.Cells[1].Value.ToString();
                dgchitietphieunhap.DataSource = LoadChiTietPhieuNhap(mapn);
            }
        }
    }
}
