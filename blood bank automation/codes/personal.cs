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
    public partial class PersonelKayıt : Form
    {
        //SqlConnection baglan = new SqlConnection("Data Source=ILAYDA\\SQLEXPRESS;Initial Catalog=KanBankasi;Integrated Security=True");
        baglantiSinifi bgl = new baglantiSinifi();
        public void dene(string a)
        {

        }
        private void kaydetsil()
        {
            isimTB.Text = "";          
            sifreTB.Text = "";           
            int key = 0;
           

        }
        public PersonelKayıt()
        {
            InitializeComponent();
            personeller();

        }
        private void personeller()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select *From personelKayit", baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            personelEkleDGV.DataSource = ds.Tables[0];
            baglan.Close();
        }
        private void kaydetButton_Click(object sender, EventArgs e)
        {
            if (isimTB.Text==""|| sifreTB.Text=="")
            {
                MessageBox.Show("Lütfen personel bilgilerini tam girin.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("insert into personelKayit values('" + isimTB.Text + "','" + sifreTB.Text + "')", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personel Kaydedildi");
                    baglan.Close();
                    kaydetsil();
                    personeller();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int key = 0;
        private void personelEkleDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            isimTB.Text= personelEkleDGV.SelectedRows[0].Cells[1].Value.ToString();           
            sifreTB.Text = personelEkleDGV.SelectedRows[0].Cells[2].Value.ToString();
           
            if (isimTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(personelEkleDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        private void silButton_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek personeli seçiniz.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("delete from personelKayit where pID=" + key + ";", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personel silindi");
                    baglan.Close();
                    kaydetsil();
                    personeller();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }

        }
        private void duzenleButton_Click(object sender, EventArgs e)
        {
            if (isimTB.Text == ""|| sifreTB.Text == "")
            {
                MessageBox.Show("Düzenlenecek personeli seçiniz.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update personelKayit set pAdSoyad='" + isimTB.Text + "',pSifre='" + sifreTB.Text + "' where pID=" + key + "", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personl düzenlendi");
                    baglan.Close();
                    kaydetsil();
                    personeller();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }
        private void kanTransferiLabel_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void aliciLabel_Click_1(object sender, EventArgs e)
        {
            AlıcıEkle ae = new AlıcıEkle();
            ae.Show();
            this.Hide();
        }

        private void kanBagısLabel_Click_1(object sender, EventArgs e)
        {
            kanBagıs kb = new kanBagıs();
            kb.Show();
            this.Hide();
        }

        private void kanStoguLabel_Click_1(object sender, EventArgs e)
        {
            kanStogu ks = new kanStogu();
            ks.Show();
            this.Hide();
        }

        private void donorLabel_Click_1(object sender, EventArgs e)
        {
            DonorEkle de = new DonorEkle();
            de.Show();
            this.Hide();
        }

        private void temizleButton_Click(object sender, EventArgs e)
        {
            kaydetsil();
        }

        private void kanTransferiLabel_Click_1(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();
        }
    }
    }

