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
    public partial class kanStogu : Form
    {
        //SqlConnection baglan = new SqlConnection("Data Source=ILAYDA\\SQLEXPRESS;Initial Catalog=KanBankasi;Integrated Security=True");
        baglantiSinifi bgl = new baglantiSinifi();
        public kanStogu()
        {
            InitializeComponent();
            bagıs();
            kanStok();
            kan(kanGrubuTB.Text);

        }
        private void kaydetsil()
        {
            isimTB.Text = "";
            soyisimTB.Text = "";
            kanGrubuTB.Text = "";
        }
        private void bagıs()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select *From donorEkle", baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            donorDGV.DataSource = ds.Tables[0];
            baglan.Close();
        }
        int toplamkan;
        private void kan(string kanGrubuTB)
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from KannStogu where KanGrubu='" + kanGrubuTB + "'",baglan);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                 toplamkan = Convert.ToInt32(dr["KanStogu"].ToString());
            }
            baglan.Close();
        }
        private void kanStok()
        {
            SqlConnection baglan = new SqlConnection(bgl.Adres);
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select *From KannStogu", baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            kanStokDGV.DataSource = ds.Tables[0];
            baglan.Close();
        }
        private void bagısYapB_Click(object sender, EventArgs e)
        {
            if (isimTB.Text == "" || soyisimTB.Text == "" || kanGrubuTB.Text=="")
            {
                MessageBox.Show("Donör seçin", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection baglan = new SqlConnection(bgl.Adres);
                    int stok = toplamkan+1;
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update KannStogu set KanStogu='" +stok+ "'where KanGrubu='" + kanGrubuTB.Text +"'", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bağış başarıyla gerçekleşti.");
                    baglan.Close();
                    kaydetsil();
                    bagıs();
                    kanStok();
                    kan(kanGrubuTB.Text);
                  

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
            
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void kanBagısLabell_Click(object sender, EventArgs e)
        {
            kanBagıs kb = new kanBagıs();
            kb.Show();
            this.Hide();
        }

       

        private void donorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            isimTB.Text = donorDGV.SelectedRows[0].Cells[1].Value.ToString();
            soyisimTB.Text = donorDGV.SelectedRows[0].Cells[2].Value.ToString();
            kanGrubuTB.Text = donorDGV.SelectedRows[0].Cells[7].Value.ToString();
            kan(kanGrubuTB.Text);
        }

       
    }
}
