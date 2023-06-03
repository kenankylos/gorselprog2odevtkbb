using kenbo.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kenbo.BL
{
    public static class BLogic
    {
        public static bool MüşteriEkle(Musteri m)
        {
            try
            {


                int res = DataLayer.MüşteriEkle(m, dataSet);
                return (res > 0);
            }
            catch ( Exception ex)
            {
                MessageBox.Show("hata oluştu:" + ex.Message);
                return false;
            }
        }

        internal static DataSet Müşterigetir(string filtre)
        {
            try
            {


                DataSet ds = DataLayer.Müşterigetir(filtre);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu:" + ex.Message);
                return null;
            }
            }
        }
}
