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
    public partial class frmHoadon : Form
    {
        public frmHoadon()
        {
            InitializeComponent();
        }
        
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rpHoaDon rpt = new rpHoaDon();
            rpt.Refresh();
            rpt.SetParameterValue("@mahd", uc.ucTraCuuHoaDon.mahd);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
