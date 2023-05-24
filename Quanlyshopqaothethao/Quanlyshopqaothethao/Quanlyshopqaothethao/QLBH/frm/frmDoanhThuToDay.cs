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
    public partial class frmDoanhThu : Form
    {
        KetNoi ncc=new KetNoi();
        public frmDoanhThu()
        {
            InitializeComponent();
        }
        DataTable LoadDoanhThu()
        {
            SqlCommand cmd = new SqlCommand("sp_TraCuuDoanhThu", ncc.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource= LoadDoanhThu();
            comboBox1.DisplayMember = "ToDay";
            comboBox1.ValueMember = "ID";
        }
    }
}
