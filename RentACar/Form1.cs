using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Burada Kayıt listele formunun açılması için bu kodlar yazılır.
        private void btnKayitListele_Click(object sender, EventArgs e)
        {
            KayitListele kayitListele = new KayitListele();
            kayitListele.Show();
            this.Hide();
        }

        //Uygulamanın kapanması için bu kodlar yazılır
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Yeni Kayıt formunun açılması için bu kodlar yazılır.
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            YeniKayit yeniKayit = new YeniKayit();
            yeniKayit.Show();
            this.Hide();
        }
    }
}
