using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kenbo.UI
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        public Urun Urun { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtUrun)) return;
            if (!ErrorControl(cbKategori)) return;
            if (!ErrorControl(nmFiyat)) return;
            if (!ErrorControl(nmStok)) return;
            if (!ErrorControl(cbBirim)) return;
            if (!ErrorControl(txtAciklama)) return;

            Urun.Ad = txtUrun.Text;
            Urun.Kategori = cbKategori.Text;
            Urun.Fiyat = (double)nmFiyat.Value;
            Urun.Stok = (double)nmStok.Value;
            Urun.birim = cbBirim.Text;
            Urun.Detay = txtAciklama.Text;



            DialogResult = DialogResult.OK;
        }
        private bool ErrorControl(Control c)
        {
            if (c is TextBox || c is ComboBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı giriş");
                    c.Focus();
                    return false;
                }
                else
                {

                    errorProvider1.SetError(c, "");
                    return true;
                }
            }
            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value == 0)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı giriş");
                    c.Focus();
                    return false;
                }
                else
                {

                    errorProvider1.SetError(c, "");
                    return true;
                }
            }
            return true;
        }
    }
}
