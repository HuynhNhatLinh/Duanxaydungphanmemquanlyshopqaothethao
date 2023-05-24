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
    public partial class frmrpsanpham : Form
    {
        public frmrpsanpham()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            Repost.rpSanPham rpt = new Repost.rpSanPham();
            crystalReportViewer2.ReportSource = rpt;
        }
    }
}
