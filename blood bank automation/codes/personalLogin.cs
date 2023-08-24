using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KanBankasıOtomasyonu
{
    public partial class GirisEkrani : Form
    {
        //SqlConnection baglan = new SqlConnection("Data Source=ILAYDA\\SQLEXPRESS;Initial Catalog=KanBankasi;Integrated Security=True");
        baglantiSinifi bgl = new baglantiSinifi();
        public GirisEkrani()
        {
            InitializeComponent();
        }

        
        

        private void GirisEkrani_kullanıcıAdiTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void GirisEkrani_kullanıcıAdiPanel1_Click(object sender, EventArgs e)
        {
       
        }

        private void GirisEkrani_kullanıcıAdiPanel1_Enter(object sender, EventArgs e)
        {
            kullanıcıAdiTB.Text = "";
        }

        private void GirisEkrani_sifreTextBox1_Enter(object sender, EventArgs e)
        {
            sifreTB.Text = "";

        }

        private void GirisEkrani_kullanıcıAdiTextBox_Leave(object sender, EventArgs e)
        {
            if (kullanıcıAdiTB.Text == " ")
            {
                kullanıcıAdiTB.Text = "Ad Soyad";
            }
        }

        private void GirisEkrani_sifreTextBox1_Leave(object sender, EventArgs e)
        {
            if (sifreTB.Text == "")
            {
                sifreTB.Text = "Şifre";
            }
         }
        

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            this.AcceptButton = GirisEkrani_girisYapButon;

        }

        private void GirisEkrani_cikisPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminB_Click(object sender, EventArgs e)
        {
            adminGiris ag = new adminGiris();
            ag.Show();
            this.Hide();
        }
        bool kontrolet;
        private void GirisEkrani_girisYapButon_Click(object sender, EventArgs e)
        {
            string ad = kullanıcıAdiTB.Text;
           string sifree = sifreTB.Text;

            if (kullanıcıAdiTB.Text == "" || sifreTB.Text == "")
            {
                MessageBox.Show("Lütfen bilgilerinizi tam girin");
            }
            else
            {
                SqlConnection baglan = new SqlConnection(bgl.Adres);
                baglan.Open();

                SqlCommand komut = new SqlCommand("select *from personelKayit  WHERE pAdSoyad='" + kullanıcıAdiTB.Text + "'AND pSifre='" + sifreTB.Text + "'", baglan);
                //komut.Parameters.AddWithValue("@p1", kullanıcıAdiTB.Text);
                //komut.Parameters.AddWithValue("@p2", sifreTB.Text);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read() == true)
                {

                    DonorEkle de = new DonorEkle();
                    de.Show();
                    this.Hide();

                }

                else
                {

                    MessageBox.Show("Hatalı giriş", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kullanıcıAdiTB.Text = "Ad Soyad";
                    sifreTB.Text = "Şifre";
                }
                baglan.Close();
                }
            }  
            
           
        }
       
    }

