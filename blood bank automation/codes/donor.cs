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
    public partial class DonorEkle : Form

    {
        //SqlConnection baglan = new SqlConnection("Data Source=ILAYDA\\SQLEXPRESS;Initial Catalog=KanBankasi;Integrated Security=True");
        baglantiSinifi bgl = new baglantiSinifi();
        private void kaydetsil()
        {
            isimTB.Text = "";
            soyisimTB.Text = "";
            yasTB.Text = "";
            TCnoTB.Text = "";
            telefonTB.Text = "";
            adresTB.Text = "";
            kanGrubuCB.SelectedIndex = -1;
            cinsiyetCB.SelectedIndex = -1;
            key = 0;

        }

        public DonorEkle()
        {
            InitializeComponent();
            donorler();
        }
        private void donorler()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select *From donorEkle", baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            donorEkleDGV.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void kaydetButton_Click(object sender, EventArgs e)
        {
            if (isimTB.Text == "" || soyisimTB.Text == "" || yasTB.Text == "" || TCnoTB.Text == "" || telefonTB.Text == "" || adresTB.Text == "" || kanGrubuCB.SelectedIndex == -1 || cinsiyetCB.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bilgilerinizi tam girin.");
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("insert into donorEkle values('" + isimTB.Text + "', '" + soyisimTB.Text + "', " + yasTB.Text + " , '" + TCnoTB.Text + "' , '" + telefonTB.Text + "' , '" + adresTB.Text + "', '" + kanGrubuCB.SelectedItem.ToString() + "', '" + cinsiyetCB.SelectedItem.ToString() + "')", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Donör Kaydedildi");
                    baglan.Close();
                    kaydetsil();
                    donorler();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
               
            }
            
        }

        private void kapatPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int key = 0;
        private void donorEkleDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indeks = e.RowIndex;
            isimTB.Text = donorEkleDGV.SelectedRows[indeks].Cells[1].Value.ToString();
            soyisimTB.Text = donorEkleDGV.SelectedRows[indeks].Cells[2].Value.ToString();
            yasTB.Text = donorEkleDGV.SelectedRows[indeks].Cells[3].Value.ToString();
            TCnoTB.Text = donorEkleDGV.SelectedRows[indeks].Cells[4].Value.ToString();
            telefonTB.Text = donorEkleDGV.SelectedRows[indeks].Cells[5].Value.ToString();
            adresTB.Text = donorEkleDGV.SelectedRows[indeks].Cells[6].Value.ToString();
            kanGrubuCB.Text = donorEkleDGV.SelectedRows[indeks].Cells[7].Value.ToString();
            cinsiyetCB.Text = donorEkleDGV.SelectedRows[indeks].Cells[8].Value.ToString();
            if (isimTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(donorEkleDGV.SelectedRows[indeks].Cells[0].Value.ToString());
            }
        }
        private void silButton_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek alıcıyı seçiniz.");
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    baglan.Open();
                SqlCommand komut = new SqlCommand("delete from donorEkle where DonorID=" + key + ";", baglan);
                komut.ExecuteNonQuery();
                MessageBox.Show("Donör  silindi");
                baglan.Close();
                kaydetsil();
                donorler();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }
        private void duzenleButton_Click(object sender, EventArgs e)
        {
            if (isimTB.Text == "" || soyisimTB.Text == "" || yasTB.Text == "" || TCnoTB.Text == "" || telefonTB.Text == "" || adresTB.Text == "" || kanGrubuCB.SelectedIndex == -1 || cinsiyetCB.SelectedIndex == -1)
            {
                MessageBox.Show("Silinecek alıcıyı seçiniz.");
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update donorEkle set DonorIsim='" + isimTB.Text + "',DonorSoyisim='" + soyisimTB.Text + "',DonorYas=" + yasTB.Text + ",DonorTCno='" + TCnoTB.Text + "',DonorTelefon='" + telefonTB.Text + "',DonorAdres='" + adresTB.Text + "',DonorKanGrubu='" + kanGrubuCB.SelectedItem.ToString()+ "',DonorCinsiyet='"+cinsiyetCB.SelectedItem.ToString()+"' where DonorID="+key+"", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Donör düzenlendi");
                    baglan.Close();
                    kaydetsil();
                    donorler();


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

        private void label16_Click(object sender, EventArgs e)
        {
            kanStogu ks = new kanStogu();
            ks.Show();
            this.Hide();

        }

        private void label18_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void kanBagısLabel_Click(object sender, EventArgs e)
        {
            kanBagıs kb = new kanBagıs();
            kb.Show();
            this.Hide();
        }

        private void DonorEkle_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kanBagısLabel_Click_1(object sender, EventArgs e)
        {
            kanBagıs kb = new kanBagıs();
            kb.Show();
            this.Close();
        }
    }
}
