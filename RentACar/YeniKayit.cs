using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class YeniKayit : Form
    {
        public YeniKayit()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        public void Kaydet()
        {
            try
            {
                //Burada Textboxlara yazdığımız değerleri değişken içine atadık.
                string id = txtKisiID.Text;
                string tc = txtKisiTC.Text;
                string ad = txtKisiAd.Text;
                string soyad = txtKisiSoyad.Text;
                string kiralananAraba = txtKiralananAraba.Text;
                string kiralamaSuresi = txtKiralamaSuresi.Text;

                //Burada conconnectionString yazdık ve veri tabanı bağlantısını yaptık.
                string connectionString = "Server = DESKTOP-OVE5E20\\SQLEXPRESS; Database = PersonelDB; User = sa4; Password = 123456";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Burada bu fonksiyonun ne iş yapması gerektiğini yazdık
                string command = $"INSERT INTO RentACar VALUES ('{id}', '{tc}', '{ad}', '{soyad}', '{kiralananAraba}', '{kiralamaSuresi}')";
                SqlCommand cmd = new SqlCommand(command, sqlConnection);

                //Veritabanı ile bağlantıyı sağladık ve yeni kayıt yaptık
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Kayıt Başarılı !!!");
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Başarısız !!!");
            }
        }
        private void btnKayitKaydet_Click(object sender, EventArgs e)
        {
            //Burada kaydet fonksiyonumuzu çağırdık ve kaydet butonuna basıldığında Kayıt kaydetme işlemi tamamlanmış oldu.
            Kaydet();
        }
    }
}
