using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace QLBH
{
    public partial class QuenMK : Form
    {
        //string ramdamCode;
        public static string to;
        public QuenMK()
        {
            InitializeComponent();
        }

        private void QuenMK_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                //string from = "huynhnhatlinhn360@gmail.com"; // địa chỉ email của người gửi
                //string pass = "123"; // mật khẩu đăng nhập
                //string to = txtemail.Text; // địa chỉ email của người nhận
                //string subject = "Admin Gửi Mã Reset mật khẩu"; // tiêu đề email
                //string body = "Mã đăng nhập của bạn là " + ramdamCode; // nội dung email

                //MailMessage message = new MailMessage(from, to, subject, body);
                //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); // địa chỉ máy chủ SMTP và cổng
                //smtpClient.EnableSsl = true; // kích hoạt SSL (Secure Sockets Layer) để bảo mật thông tin
                //smtpClient.Credentials = new NetworkCredential(from, pass); // thông tin xác thực

                //smtpClient.Send(message);
                //MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn. Vui lòng kiểm tra hộp thư đến.");
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show("Gửi email thất bại: " + ex.Message);
            //}
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //if(ramdamCode==(txtmasn.Text).ToString())
            //{
                //to = txtemail.Text;
              
                //nhapmkmoi kkk=new nhapmkmoi();
                //kkk.ShowDialog();
            //}
            //else
            //{
                //MessageBox.Show("Code không hợp lệ");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //frmdangnhap f = new frmdangnhap();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            //this.Close();
        }
    }
}
