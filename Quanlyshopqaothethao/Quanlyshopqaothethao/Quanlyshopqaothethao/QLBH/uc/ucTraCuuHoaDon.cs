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
    public partial class ucTraCuuHoaDon : UserControl
    {
        KetNoi kn = new KetNoi();
        public ucTraCuuHoaDon()
        {
            InitializeComponent();
        }
        DataTable LoadHoaDon()
        {
            SqlCommand cmd = new SqlCommand("sp_HoaDonSelectAll", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadChiTietHoaDon(string mahd)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietHoaDonByMaHD", kn.connection());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mahd", mahd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void ucTraCuuHoaDon_Load(object sender, EventArgs e)
        {
            dgHoaDon.DataSource = LoadHoaDon();
        }
        public static string mahd = "";

        private void dgchitiethoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgchitiethoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            }

        private void dgHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow dr = dgHoaDon.CurrentRow;
                mahd = dr.Cells[1].Value.ToString();
                frm.frmHoadon frm = new frm.frmHoadon();
                frm.ShowDialog();
            }
            else
            {
                DataGridViewRow dr = dgHoaDon.CurrentRow;
                string mahd = dr.Cells[1].Value.ToString();
                dgchitiethoadon.DataSource = LoadChiTietHoaDon(mahd);
            }
    }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
