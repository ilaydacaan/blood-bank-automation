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
    public partial class kanBagıs : Form
    {
        //SqlConnection baglan = new SqlConnection("Data Source=ILAYDA\\SQLEXPRESS;Initial Catalog=KanBankasi;Integrated Security=True");
        baglantiSinifi bgl = new baglantiSinifi();
        public kanBagıs()
        {
            InitializeComponent();
            personel();
            transfer();
            donor();
        }
        private void personel()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from personelKayit", baglan);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            perosnel.Text = dt.Rows[0][0].ToString();
            baglan.Close();
        }
        private void donor()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from donorEkle", baglan);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Donor.Text = dt.Rows[0][0].ToString();
            baglan.Close();
        }
        private void transfer()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from kanTransferi", baglan);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            transferL.Text = dt.Rows[0][0].ToString();
            baglan.Close();
        }
        private void kapatPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void donorLabel_Click(object sender, EventArgs e)
        {
            DonorEkle de = new DonorEkle();
            de.Show();
            this.Close();
        }

        private void kanTransferiLabel_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void kanBagısLabel_Click(object sender, EventArgs e)
        {

        }

        private void kanStoguLabel_Click(object sender, EventArgs e)
        {
            kanStogu ks = new kanStogu();
            ks.Show();
            this.Close();
        }

        private void aliciLabel_Click(object sender, EventArgs e)
        {
            AlıcıEkle ae = new AlıcıEkle();
            ae.Show();
            this.Close();
        }
    }
}
