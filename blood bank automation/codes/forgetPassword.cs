using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace KanBankasıOtomasyonu
{
    public partial class sifremiUnuttum : Form
    {
        public sifremiUnuttum()
        {
            InitializeComponent();
        }
        MailMessage eposta = new MailMessage();
        void mailGonder()
        {
            eposta.From = new MailAddress("kanbankasintp@gmail.com");
            eposta.To.Add(epostaTB.Text.ToString());
            eposta.Subject = konuTB.Text.ToString();
            eposta.Body = "1234";
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("kanbankasintp@gmail.com", "dbmdywsechjjoqin");
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(eposta);
            MessageBox.Show("Mail gönderildi.");
        }

        private void gonderB_Click(object sender, EventArgs e)
        {
            mailGonder();
        }

        private void GirisEkrani_cikisPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
