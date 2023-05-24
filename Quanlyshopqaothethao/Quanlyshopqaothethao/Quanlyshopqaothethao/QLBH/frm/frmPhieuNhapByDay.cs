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
    public partial class frmPhieuNhapByDay : Form
    {
        public frmPhieuNhapByDay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rpPhieuNhapByDay rpt = new rpPhieuNhapByDay();
            rpt.Refresh();
            rpt.SetParameterValue("@tungay", dateTimePicker1.Value);
            rpt.SetParameterValue("@denngay", dateTimePicker2.Value);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
