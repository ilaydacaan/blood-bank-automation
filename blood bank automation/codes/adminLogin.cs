using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanBankasıOtomasyonu
{
    public partial class adminGiris : Form
    {
        public adminGiris()
        {
            InitializeComponent();
        }

        private void iptalB_Click(object sender, EventArgs e)
        {
            GirisEkrani ge = new GirisEkrani();
            ge.Show();
            this.Hide();
        }
        
        private void GirisEkrani_cikisPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GirisEkrani_girisYapButon_Click(object sender, EventArgs e)
        {
            if (sifreTB.Text == "")
            {
                MessageBox.Show("Admin şifresi giriniz");
            }
            else if (sifreTB.Text =="123")
            {
                PersonelKayıt pk = new PersonelKayıt();
                pk.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş","Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);

                sifreTB.Text = "Şifre";
;            }
        }

        private void sifreTB_Enter(object sender, EventArgs e)
        {
            sifreTB.Text = "";
        }

        private void sifreTB_Leave(object sender, EventArgs e)
        {
            if (sifreTB.Text == "")
            {
                sifreTB.Text = "Şifre";
            }
        }

        private void GirisEkrani_sifremiUnuttumButon_Click(object sender, EventArgs e)
        {
            sifremiUnuttum su = new sifremiUnuttum();
            su.Show();
            this.Hide();
        }
    }
}
