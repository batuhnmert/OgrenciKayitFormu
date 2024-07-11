using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batuogrenci
{
    public partial class Form1 : Form
    {
        List<ogrenci> ogrenciler = new List<ogrenci>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ogrenciEkle(
                textBox1.Text,
                textBox2.Text,
                Convert.ToInt32(textBox3.Text),
                Convert.ToInt32(textBox5.Text),
                Convert.ToInt32(textBox4.Text)
            );
        }



        public void ogrenciEkle(string ad, string soyad, int yas, int ogrno, int matnot)
        {
            ogrenci o = new ogrenci();
            o.Adi = ad;
            o.Soyadi = soyad;
            o.Yas = yas;
            o.OgrenciNo = ogrno;
            o.MatNotu = matnot;

            var isHave = false;
            foreach (ogrenci str in ogrenciler)
            {
                if (str.OgrenciNo.ToString().Contains(textBox5.Text))
                {
                    isHave = true;
                }
            }

            if (isHave)
            {
                MessageBox.Show("Bu Numara İle Bir Öğrenci Kayıtlı.");
            }
            else
            {
                ogrenciler.Add(o);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ogrenciler;
                MessageBox.Show("Öğrenci Başarıyla Eklendi.");
            }
        }
        
        public void noIleBul(int ogrenciNo)
        {
            List <ogrenci> o2 = new List<ogrenci>();
            foreach(ogrenci item in ogrenciler)
            {
                if (item.OgrenciNo.ToString().Contains(ogrenciNo.ToString()))
                {
                    o2.Add(item);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = o2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ogrenciler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            noIleBul(Convert.ToInt32(textBox7.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            int toplam = 0;
            decimal ortalama;
            foreach(ogrenci item in ogrenciler)
            {
                sayac++;
                toplam += item.MatNotu; 
            }
            ortalama = (decimal)(toplam / sayac);
            MessageBox.Show($"Sınıfın Ortalaması: {ortalama.ToString()}");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var ogrencino = textBox7.Text;
            ogrenci delItem = null;

            foreach (ogrenci item in ogrenciler)
            {
                if(item.OgrenciNo.ToString() == ogrencino)
                {
                    delItem = item;
                }
            }

            ogrenciler.Remove(delItem);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ogrenciler;
            MessageBox.Show("Kayıt Başarıyla Silindi.");
        }
    }
}
