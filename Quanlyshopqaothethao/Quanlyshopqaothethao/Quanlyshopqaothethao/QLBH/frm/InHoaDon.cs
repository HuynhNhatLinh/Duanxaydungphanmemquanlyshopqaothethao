using QLBH.Repost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.frm
{
    public partial class InHoaDon : Form
    {
        public InHoaDon()
        {
            InitializeComponent();
        }
        string hoadon=uc.banhang.hoadon;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rpHoaDon tt = new rpHoaDon();
            tt.Refresh();
            tt.SetParameterValue("@mahd",hoadon);
            crystalReportViewer1.ReportSource = tt;
        }
    }
}
