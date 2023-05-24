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
    public partial class frmHangTon : Form
    {
        public frmHangTon()
        {
            InitializeComponent();
        }

        private void frmHangTon_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            Repost.RpHangTon rpt = new Repost.RpHangTon();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
