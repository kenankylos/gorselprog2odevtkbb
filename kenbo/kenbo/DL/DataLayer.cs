using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kenbo.DL
{
   public static class DataLayer
    {
       static MySqlConnection conn = new MySqlConnection(
            new MySqlConnectionStringBuilder()
            {
                Server = "localhost" ,
                Database = "kenbo" ,
                UserID = "root" ,
                Password = "kestane439" ,
            }.ConnectionString

            );
        private static string filtre;

        public static int MüşteriEkle(Musteri m, int dataSet)
        {
            return MüşteriEkle(m, dataSet, dataSet);
        }

        public static int MüşteriEkle(Musteri m, int dataSet, int dataSet)
        {

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)

                    conn.Close();

              MySqlCommand komut
                    = new MySqlCommand("kenbo_musteriler" , conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id",m.ID);
                komut.Parameters.AddWithValue("@ad", m.Ad);
                komut.Parameters.AddWithValue("@soy", m.Soyad);
                komut.Parameters.AddWithValue("@tel", m.Telefon);
                komut.Parameters.AddWithValue("@mail", m.Mail);
                komut.Parameters.AddWithValue("@adres", m.Adres);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            finally 
            { 
            if (conn.State!= System.Data.ConnectionState.Closed)

                    conn.Close();
            }

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)

                    conn.Close();
                MySqlCommand komut;
                if (string.IsNullOrEmpty(filtre))
                {
                    komut = new MySqlCommand("kenbo_MüşteriHepsi", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    
                }
                else
                {
                    komut = new MySqlCommand("kenbo_MüşteriGetir", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@filtre", filtre);
                }
                DataSet dataSet = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter (komut);
                adp.Fill(dataSet);

                return dataSet;
                
               
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)

                    conn.Close();
            }




        }
    }
}
