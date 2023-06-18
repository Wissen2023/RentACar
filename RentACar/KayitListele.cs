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
    public partial class KayitListele : Form
    {
        public KayitListele()
        {
            InitializeComponent();
        }

        //Burada bu formdan çıkıp form1'in açılmasını sağladık.
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }


        public void KayitGetir()
        {
            //Burada connectionstring yazdık ve veri tabanı ile bağlantı yaptık
            string connectionString = "Server = DESKTOP-OVE5E20\\SQLEXPRESS; Database = PersonelDB; User = sa4; Password = 123456";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Burada komutu yazdık. Bu komut tüm tabloyu getirir. Ve getirdiği tabloyu datagridview içine aktarır
            string command = "SELECT * FROM RentACar";
            SqlDataAdapter da = new SqlDataAdapter(command, sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtGridW.DataSource = dt;
        }

        private void KayitListele_Load(object sender, EventArgs e)
        {
            KayitGetir();
        }

        void KayitAktar()
        {
            try
            {
                //Buradaki kodlar datagridview içindeki verileri alıp sağdaki textboxların içine aktarır.
                txtKisiID.Text = dtGridW.CurrentRow.Cells[0].Value.ToString();
                txtKisiTC.Text = dtGridW.CurrentRow.Cells[1].Value.ToString();
                txtKisiAd.Text = dtGridW.CurrentRow.Cells[2].Value.ToString();
                txtKisiSoyad.Text = dtGridW.CurrentRow.Cells[3].Value.ToString();
                txtKiralananAraba.Text = dtGridW.CurrentRow.Cells[4].Value.ToString();
                txtKiralamaSuresi.Text = dtGridW.CurrentRow.Cells[5].Value.ToString();
                MessageBox.Show("Kayıt Aktarıldı");
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Aktarılamadı");
            }
        }

        private void btnKayitAktar_Click(object sender, EventArgs e)
        {
            KayitAktar();
        }

        void KayitGuncelle()
        {
            try
            {
                //Buradaki kodlarda seçilen satırdaki idyi alır. Diğer textboxlara yazılan değerleride değişken içine alır.
                string id = dtGridW.CurrentRow.Cells[0].Value.ToString();
                string tc = txtKisiTC.Text;
                string ad = txtKisiAd.Text;
                string soyad = txtKisiSoyad.Text;
                string kiralananAraba = txtKiralananAraba.Text;
                string kiralamasuresi = txtKiralamaSuresi.Text;

                //Burada connectionstring yazdık ve veri tabanı ile bağlantı yaptık
                string connectionString = "Server = DESKTOP-OVE5E20\\SQLEXPRESS; Database = PersonelDB; User = sa4; Password = 123456";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Buradaki kodlar bu fonksiyonun ne iş yapması gerektiğini bizlere gösterir. Burada yeni yazdığımız değerleri güncelleme işlemi yapılır
                string command = $"UPDATE RentACar SET KisiTC = '{tc}', KisiAd = '{ad}', KisiSoyad = '{soyad}', KiraladiğiAraba = '{kiralananAraba}', KiralamSuresi = '{kiralamasuresi}' WHERE KisiID = '{id}'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Kayıt Güncelllendi");
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Güncellenemedi");
            }
        }
        private void btnKayitGuncelle_Click(object sender, EventArgs e)
        {
            KayitGuncelle();
            KayitGetir();
        }

        void KayitSil()
        {
            try
            {
                //Buradaki kodda seçilen satırdaki id'yi alırız ve değişken içine atarız
                string id = dtGridW.CurrentRow.Cells[0].Value.ToString();

                //Burada veritabanı bağlantısı yapılır.
                string connectionString = "Server = DESKTOP-OVE5E20\\SQLEXPRESS; Database = PersonelDB; User = sa4; Password = 123456";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Buradaki kodda veri tabanından kayıt silme işlemi gerçekleşir
                string command = $"DELETE FROM RentACar WHERE KisiID = '{id}'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Kayıt Silindi");
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Silinemedi");
            }
        }
        private void btnKayitSil_Click(object sender, EventArgs e)
        {
            KayitSil();
            KayitGetir();
        }
    }
}
