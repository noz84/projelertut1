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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        NorthwindEntities con = new NorthwindEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var query = from aa in con.Personellers select new { aa.Adi, aa.Adres, aa.SoyAdi };
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ürünler içerisinde kaç farklı liste fiyatı olduğunu bulup bunları küçükten büyüğe doğru elde etmek.

            var result13 = (from prd in con.Urunlers
                            orderby prd.BirimFiyati
                            select prd.BirimFiyati).Distinct();

            dataGridView1.DataSource = result13.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var numCount = con.Urunlers.Where(n =>n.BirimFiyati>1 && n.BirimFiyati<1000).Count();
            var numCount = con.Urunlers.Where(n => n.BirimFiyati > 1 && n.BirimFiyati < 1000).Max();
            textBox1.Text = numCount.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = con.Urunlers.Where(ogr => ogr.YeniSatis >= 2)
                      .OrderBy(ogr => ogr.YeniSatis);
            dataGridView1.DataSource = query.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dt = Convert.ToDateTime(textBox1.Text);
            var dt1 = Convert.ToDateTime(textBox2.Text);
            //var query = con.Satislars.Where(aa => aa.OdemeTarihi == dt || aa.OdemeTarihi == dt1);

            var ss = from bb in con.Satislars
                     where bb.OdemeTarihi > dt && bb.OdemeTarihi < dt1
                     select bb;



            dataGridView1.DataSource = ss.ToList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int id = Convert.ToInt32(comboBox1.SelectedItem.ToString());

                var veri = (from u in con.Personellers
                            where u.PersonelID == id
                            select u).FirstOrDefault();

                if (veri != null)
                {
                    textBox1.Text = veri.Adi;
                    textBox2.Text = veri.Adres;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var rates = con.Urunlers
                                 .Where(er=>er.UrunAdi=="Chai")
                                 .Average(emp => emp.BirimFiyati);

            textBox1.Text = rates.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var rates = con.Urunlers
                                .Where(er => er.UrunAdi == "Chai")
                                .Max(emp => emp.BirimFiyati);

            textBox1.Text = rates.ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var rates = con.Urunlers
                              .Where(er => er.UrunAdi == "Chai")
                              .Min(emp => emp.BirimFiyati);

            textBox1.Text = rates.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var rates = con.Urunlers
                              .Where(er => er.UrunAdi == "Chai")
                              .Sum(emp => emp.BirimFiyati);

            textBox1.Text = rates.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var rates = con.Urunlers
                            .Where(er => er.UrunAdi == "Chai")
                            .Count();

            textBox1.Text = rates.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            

            

        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox3.Text = "iyi günler cnm";
            MessageBox.Show("hoşgeldiniz cnm ...");
        }
    }
    }

