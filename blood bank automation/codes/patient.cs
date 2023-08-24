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
    
    public partial class AlıcıEkle : Form
    {
        //SqlConnection baglan = new SqlConnection("Data Source=ILAYDA\\SQLEXPRESS;Initial Catalog=KanBankasi;Integrated Security=True");
        baglantiSinifi bagl = new baglantiSinifi();
        private void kaydetsil()
        {
            isimTB.Text = "";
            soyisimTB.Text = "";
            yasTB.Text = "";
            TCKimlikNoTB.Text ="";
            telefonTB.Text = "";
            adresTB.Text = "";
            kanGrubuCB.SelectedIndex = -1;
            cinsiyetCB.SelectedIndex = -1;
            key = 0;

        }
        public AlıcıEkle()
        {             
            InitializeComponent();
            alıcılar();
        }
        private void alıcılar()
        {
            SqlConnection baglan = new SqlConnection(bagl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select *From AliciEklee", baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            alicilarDGV.DataSource = ds.Tables[0];
            baglan.Close();
            
        }

        private void aliciEkle_KaydetButton_Click(object sender, EventArgs e)
        { if (isimTB.Text == "" || soyisimTB.Text == "" || yasTB.Text == "" || TCKimlikNoTB.Text == "" || telefonTB.Text == "" || adresTB.Text == "" || kanGrubuCB.SelectedIndex == -1 || cinsiyetCB.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bilgilerinizi tam girin.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bagl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("insert into AliciEklee values('"+isimTB.Text+"', '"+soyisimTB.Text+"', "+yasTB.Text+" , '"+TCKimlikNoTB.Text+"' , '"+telefonTB.Text+"' , '"+adresTB.Text+"', '"+kanGrubuCB.SelectedItem.ToString()+"', '"+ cinsiyetCB.SelectedItem.ToString()+"')",baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Alıcı Kaydedildi");
                    baglan.Close();
                    kaydetsil();
                    alıcılar();

                }
                catch (Exception Ex){
                    MessageBox.Show(Ex.Message);

                }
            }
            

        }

        private void aliciEkle_kapatPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int key = 0;
        private void alicilarDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int indeks = e.RowIndex;
            isimTB.Text = alicilarDGV.SelectedRows[0].Cells[1].Value.ToString();
            soyisimTB.Text = alicilarDGV.SelectedRows[0].Cells[2].Value.ToString();
            yasTB.Text = alicilarDGV.SelectedRows[0].Cells[3].Value.ToString();
            TCKimlikNoTB.Text = alicilarDGV.SelectedRows[0].Cells[4].Value.ToString();
            telefonTB.Text = alicilarDGV.SelectedRows[0].Cells[5].Value.ToString();
            adresTB.Text = alicilarDGV.SelectedRows[0].Cells[6].Value.ToString();
            kanGrubuCB.Text = alicilarDGV.SelectedRows[0].Cells[7].Value.ToString();
            cinsiyetCB.Text = alicilarDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (isimTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(alicilarDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void silButton_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek alıcıyı seçiniz.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bagl.Adres);
                    baglan.Open();
                SqlCommand komut = new SqlCommand("delete from AliciEklee where AliciID=" + key +";", baglan);
                komut.ExecuteNonQuery();
                MessageBox.Show("Alıcı silindi");
                baglan.Close();
                kaydetsil();
                alıcılar();
                

                }
                catch (Exception Ex)
                {
                MessageBox.Show(Ex.Message);

                }

            }
        }
        private void düzenleButton_Click(object sender, EventArgs e)
        {
            if (isimTB.Text == "" || soyisimTB.Text == "" || yasTB.Text == "" || TCKimlikNoTB.Text == "" || telefonTB.Text == "" || adresTB.Text == "" || kanGrubuCB.SelectedIndex == -1 || cinsiyetCB.SelectedIndex == -1)
            {
                MessageBox.Show("Düzenlenecek alıcıyı seçiniz.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bagl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update AliciEklee set AliciIsim='" + isimTB.Text + "',AliciSoyisim='" + soyisimTB.Text + "',AliciYas=" + yasTB.Text + ",AliciTCno='" + TCKimlikNoTB.Text + "',AliciTelefon='" + telefonTB.Text + "',AliciAdres='" + adresTB.Text + "',AliciKanGrubu='" + kanGrubuCB.SelectedItem.ToString() + "',AliciCinsiyet='" + cinsiyetCB.SelectedItem.ToString() + "' where AliciID=" + key + "", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Alıcı düzenlendi");
                    baglan.Close();
                    kaydetsil();
                    alıcılar();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }
        private void temizleButton_Click(object sender, EventArgs e)
        {
           kaydetsil();
        }

        private void donorLabel_Click(object sender, EventArgs e)
        {
            DonorEkle de = new DonorEkle();
            de.Show();
            this.Hide();
        }

        private void aliciLabel_Click(object sender, EventArgs e)
        {
            AlıcıEkle ae = new AlıcıEkle();
            ae.Show();
            this.Hide();
        }

        private void kanStoguLabel_Click(object sender, EventArgs e)
        {
            kanStogu ks = new kanStogu();
            ks.Show();
            this.Hide();
        }

        private void kanTransferiLabel_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void kanBagısLabel_Click(object sender, EventArgs e)
        {
            kanBagıs kb = new kanBagıs();
            kb.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
