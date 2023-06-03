using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kenbo.UI
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            
            if (Güncelleme)
            {
                txtAd.Text = Musteri.Ad;
                txtSoy.Text = Musteri.Soyad;
                txtTel.Text = Musteri.Telefon;
                txtMail.Text = Musteri.Mail;
                txtAdres.Text = Musteri.Adres;
            }
          
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Musteri Musteri { get; set; } 
        public bool Guncelleme { get; set; } = false;
        public bool Güncelleme { get; private set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(! ErrorControl(txtAd))return;
            if (!ErrorControl(txtSoy)) return;
            if (!ErrorControl(txtTel)) return;
            if (!ErrorControl(txtMail)) return;
            if (!ErrorControl(txtAdres)) return;

            Musteri.Ad = txtAd.Text;
            Musteri.Soyad = txtSoy.Text;
            Musteri.Telefon = txtTel.Text;
            Musteri.Mail = txtMail.Text;
            Musteri.Adres = txtAdres.Text;

            DialogResult =DialogResult.OK;  
        }

        private bool ErrorControl(Control c)
        {
            if (c is TextBox)
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
            if (c is MaskedTextBox)
            {
                if (!((MaskedTextBox)c).MaskFull)
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
