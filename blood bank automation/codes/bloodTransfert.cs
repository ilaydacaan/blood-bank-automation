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
    public partial class KanTransferi : Form

    {
        // SqlConnection baglan = new SqlConnection("Data Source=ILAYDA\\SQLEXPRESS;Initial Catalog=KanBankasi;Integrated Security=True");
        baglantiSinifi bgl = new baglantiSinifi();
        private void kaydetsil()
        {
            isimTB.Text = "";
            soyisimTB.Text = "";
            kanGrupTB.Text="";
            alıcıIDCB.Visible = false;
            uygunlukKontrol.Visible = false;

        }
        public KanTransferi()
        {
            InitializeComponent();
            alıcılar();
            kanUyum();
            stokGuncelle();
           
        }
        private void stokGuncelle()
        {
            
            try
            {
                SqlConnection baglan = new SqlConnection(bgl.Adres);
                baglan.Open();
                int güncelStok = toplamkan - 1;
                SqlCommand komut = new SqlCommand("update KannStogu set KanStogu='" + güncelStok+ "'where KanGrubu='"+kanGrupTB.Text+"';", baglan);
                komut.ExecuteNonQuery();               
                baglan.Close();
                

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void alıcılar()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlCommand komut = new SqlCommand("select  AliciID from AliciEklee", baglan);
            DataTable dt = new DataTable();
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            dt.Columns.Add("AliciID", typeof(int));
            dt.Load(rdr);
            alıcıIDCB.ValueMember = "AliciID";
            alıcıIDCB.DataSource = dt;

            baglan.Close();

        }
        private void kanUyum()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from AliciEklee where AliciID=" + alıcıIDCB.SelectedValue.ToString() + "", baglan);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                isimTB.Text = dr["AliciIsim"].ToString();
                soyisimTB.Text = dr["AliciSoyisim"].ToString();
                kanGrupTB.Text = dr["AliciKanGrubu"].ToString();
            }
            baglan.Close();
        }
        int toplamkan = 0;
        private void kan(string kanGrubuTB)
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from KannStogu where KanGrubu='" + kanGrubuTB + "'", baglan);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                toplamkan = Convert.ToInt32(dr["KanStogu"].ToString());
            }
            baglan.Close();
        }
        private void alıcıIDCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kanUyum();
            kan(kanGrupTB.Text);
            if (toplamkan > 0)
            {
                transferB.Visible = true;
                uygunlukKontrol.Text = "Uygun Kan Bulundu";
            }
            else
            {
                uygunlukKontrol.Text = "Uygun Kan Bulunamadı";
                uygunlukKontrol.Visible= true;
            }

        }
        private void transferB_Click(object sender, EventArgs e)
        {
            if (isimTB.Text == "" || soyisimTB.Text == "" )
            {
                MessageBox.Show("Lütfen bilgilerinizi tam girin.");
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("insert into kanTransferi values('" + isimTB.Text + "', '" + soyisimTB.Text + "',  '" + kanGrupTB.Text +"')" , baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Transfer Başarılı");
                    baglan.Close();             
                    kan(kanGrupTB.Text);
                    stokGuncelle();
                    kaydetsil();

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
        private void donorLabel_Click(object sender, EventArgs e)
        {
            DonorEkle de = new DonorEkle();
            de.Show();
            this.Close();
        }

        private void aliciLabel_Click(object sender, EventArgs e)
        {
            AlıcıEkle ae = new AlıcıEkle();
            ae.Show();
            this.Close();
        }

        private void kanStoguLabel_Click(object sender, EventArgs e)
        {
            kanStogu ks = new kanStogu();
            ks.Show();
            this.Close();
        }

        private void kanTransferiLabel_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Close();
        }

        private void kanBagısLabel_Click(object sender, EventArgs e)
        {
            kanBagıs kb = new kanBagıs();
            kb.Show();
            this.Close();
        }

        private void personelEkleLabel_Click(object sender, EventArgs e)
        {
            PersonelKayıt pk = new PersonelKayıt();
            pk.Show();
            this.Hide();
        }

       
    }
}
