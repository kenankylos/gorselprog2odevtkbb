using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kenbo.UI
{
    public partial class FrmSatis : Form
    {
        private object txtID;

        public FrmSatis()
        {
            InitializeComponent();
        }
        public FrmMusteri Musteri { get; set; }

        public Urun Urun { get; set; }

        public Satis Satis { get; set; }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            textID.Text = Satis.ID.ToString();

            txtMusteri.Text = Musteri.ToString();
            txtUrun.Text = Urun.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(nmFiyat.Value == 0)
            {
                errorProvider1.SetError(nmFiyat, "Lütfen fiyat giriniz");
                nmFiyat.Focus();
                return;

            }
            else
            {
                errorProvider1.SetError(nmFiyat, "");
            }

            Satis.Tarih = dtTarih.Value;
            Satis.Fiyat = (double)nmFiyat.Value;



            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }
    }
}
