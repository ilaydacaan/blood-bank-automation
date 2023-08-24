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
    public partial class AcilisEkranı : Form
    {
        public AcilisEkranı()
        {
            InitializeComponent();
        }

        private void AcilisEkranı_Load(object sender, EventArgs e)
        {
            AcilisEkranı_Zamanlayıcı.Start();
        }
        int ilerleme = 1;
        private void AcilisEkranı_ProgressBar_Click(object sender, EventArgs e)
        {
        }
        private void AcilisEkranı_Zamanlayıcı_Tick(object sender, EventArgs e)
        {
            
            AcilisEkranı_Zamanlayıcı.Interval=50;
            AcilisEkranı_ProgressBar.Value = ilerleme;
            ilerleme++;
            if (ilerleme > 100)
            {
                AcilisEkranı_Zamanlayıcı.Stop();
                this.Hide();
                GirisEkrani ge = new GirisEkrani();
                ge.ShowDialog();

            }

        }

        private void AcilisEkrani_Gifi_Click(object sender, EventArgs e)
        {

        }
    }
}
