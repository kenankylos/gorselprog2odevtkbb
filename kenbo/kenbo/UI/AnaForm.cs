using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kenbo.BL;
using kenbo.UI;
namespace kenbo
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            FrmMusteri frmMusteri = new FrmMusteri()
            {
                Text = "müşteri ekle",
                Musteri = new Musteri() { ID = Guid.NewGuid() },
            };
            var sonuc = frmMusteri.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
               bool b = BLogic.MüşteriEkle(frmMusteri.Musteri);
                if(b)
                {
                    DataSet ds = BLogic.Müşterigetir("");
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void btnMusteriDuzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
        }
    }
}
