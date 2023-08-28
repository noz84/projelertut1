using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nrtlinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindEntities islem = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindEntities islem = new NorthwindEntities();

                          var sonuc= from urun in islem.Urunlers
                                       join tedarikci in islem.Tedarikcilers on urun.TedarikciID equals tedarikci.TedarikciID
                                       select new
                                       {
                                           urun.UrunAdi,
                                           urun.BirimFiyati,
                                           urun.HedefStokDuzeyi,
                                           tedarikci.SirketAdi,
                                           tedarikci.Sehir,
                                           tedarikci.Telefon
                                       };
            dataGridView1.DataSource = sonuc.ToList();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        orderby urun.BirimFiyati
                        select urun;
            dataGridView1.DataSource = sonuc.ToList(); ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        orderby urun.BirimFiyati
                        select urun;
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sonuc = (from urun in islem.Urunlers
                        orderby urun.UrunAdi descending
                        select urun).Take(3);
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        orderby urun.UrunAdi ascending
                        select urun;
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
      var sonuc = from urun in islem.Urunlers
                                       join kategori in islem.Kategorilers on urun.KategoriID equals kategori.KategoriID
                                       select new
                                       {
                                           urun.UrunAdi,
                                           urun.YeniSatis,
                                           urun.HedefStokDuzeyi,
                                           kategori.KategoriAdi,
                                           kategori.Tanimi
                                       };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
        var sonuc  = from urun in islem.Urunlers
                                       join satis in islem.Satis_Detaylaris on urun.UrunID equals satis.UrunID
                                       select new
                                       {
                                           urun.UrunAdi,
                                           urun.YeniSatis,
                                           urun.HedefStokDuzeyi,
                                           satis.İndirim,
                                           satis.Miktar
                                       };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           var sonuc = from personel in islem.Personellers
                                       join satis in islem.Satislars on personel.PersonelID equals satis.PersonelID
                                       select new
                                       {
                                           personel.Adi,
                                           personel.SoyAdi,
                                           personel.Bolge,
                                           satis.SatisTarihi,
                                           satis.SevkBolgesi
                                       };

            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var sonuc = from personel in islem.Personellers
                        join satis in islem.Satislars on
                        personel.PersonelID equals satis.PersonelID
                        group satis by personel.Adi into grup
                        select new
                        {
                            personelAdi = grup.Key,
                            toplamsatis = grup.Count()

                        };
            dataGridView1.DataSource = sonuc.ToList(); 
        }

        private void button10_Click(object sender, EventArgs e)
        {

            //var sonuc = from personel in islem.Personellers
            //            group personel by personel.Adi into grup
            //            select new
            //            {
            //                personelAdi = grup.Key,
            //                toplamsatis = grup.Count()

            //            };
            //var sonuc = from urun in islem.Urunlers
            //            group urun by urun.UrunAdi into grup
            //            select new
            //            {
            //                urun = grup.Key,
            //                enyuksekfiyat = grup.Max(a=>a.BirimFiyati)

            //            };
            //var sonuc = from urun in islem.Urunlers
            //            group urun by urun.UrunAdi into grup
            //            select new
            //            {
            //                urun = grup.Key,
            //                enyuksekfiyat = grup.Min(a => a.BirimFiyati)

            //            };
            //dataGridView1.DataSource = sonuc.ToList();

            var sonuc = from urun in islem.Urunlers
                        group urun by urun.UrunAdi into grup
                        select new
                        {
                            urun = grup.Key,
                            enyuksekfiyat = grup.Sum(a => a.BirimFiyati*10)

                        };
            //var sonuc = from urun in islem.Urunlers
            //            group urun by urun.UrunAdi into grup
            //            select new
            //            {
            //                urun = grup.Key,
            //                enyuksekfiyat = grup.Average
            //                (a => a.BirimFiyati)

            //            };

            //var Sonuc = islem.Musterilers.Where(Musteri => Musteri.Ulke == "Spain").GroupBy(Musteri => Musteri.Sehir);
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var Sonuc = from detay in islem.Satis_Detaylaris
                        group detay by detay.Satislar.SatisTarihi.Value.Year into Grup
                        select new
                        {
                            Gelir = Grup.Sum(Satis => Satis.Miktar * Satis.BirimFiyati),
                            Yil = Grup.Key
                        };
            dataGridView1.DataSource = Sonuc.ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var Sonuc = islem.Musterilers.Where(Musteri => Musteri.Ulke == "Spain" && Musteri.Adres=="aaa");
            dataGridView1.DataSource = Sonuc.ToList();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = islem.Musterilers.Where(x => x.Ulke.Contains(textBox1.Text)).ToList(); 
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        join kategori in islem.Kategorilers on urun.KategoriID equals kategori.KategoriID
                        join  tt in islem.Tedarikcilers on urun.TedarikciID equals tt.TedarikciID
                        select new
                        {
                            urun.UrunAdi,
                            urun.YeniSatis,
                            urun.HedefStokDuzeyi,
                            kategori.KategoriAdi,
                            kategori.Tanimi,
                            tt.SirketAdi,
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }
    }
    }

