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
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rpPhieuNhap rpt = new rpPhieuNhap();
            rpt.Refresh();
            rpt.SetParameterValue("@mapn", uc.ucTraCuuphieunhap.mapn);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
