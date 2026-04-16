using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Project_PetrolOfis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=DbTestBenzın;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        
        
        void listele()
        {
            //krs95
            bgl.Open();
            SqlCommand kommut = new SqlCommand("SELECT * FROM TBLBENZIN where PETROLTUR = 'Kurşunsuz95'", bgl);
            SqlDataReader dr = kommut.ExecuteReader();
            while (dr.Read())
            {
                lblkursunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                lblkursunsuz95lıtre.Text = dr[4].ToString();
            }
            bgl.Close();

            //krs97
            bgl.Open();
            SqlCommand kommut2 = new SqlCommand("SELECT * FROM TBLBENZIN where PETROLTUR = 'Kurşunsuz97'", bgl);
            SqlDataReader dr2 = kommut2.ExecuteReader();
            while (dr2.Read())
            {
                lblkursunsuz97.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                lblkursunsuz97lıtre.Text = dr2[4].ToString();
            }
            bgl.Close();

            //eudizel
            bgl.Open();
            SqlCommand kommut3 = new SqlCommand("SELECT * FROM TBLBENZIN where PETROLTUR = 'EuroDizel10'", bgl);
            SqlDataReader dr3 = kommut3.ExecuteReader();
            while (dr3.Read())
            {
                lbleurodızel10.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                lbleurodızellıtre.Text = dr3[4].ToString();
            }
            bgl.Close();

            //ypro
            bgl.Open();
            SqlCommand kommut4 = new SqlCommand("SELECT * FROM TBLBENZIN where PETROLTUR = 'YeniProDizel'", bgl);
            SqlDataReader dr4 = kommut4.ExecuteReader();
            while (dr4.Read())
            {
                lblyenıprodızel.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                lblyenıprodızellıtre.Text = dr4[4].ToString();
            }
            bgl.Close();

            //gaz
            bgl.Open();
            SqlCommand kommut5 = new SqlCommand("SELECT * FROM TBLBENZIN where PETROLTUR = 'Gaz'", bgl);
            SqlDataReader dr5 = kommut5.ExecuteReader();
            while (dr5.Read())
            {
                lblgaz.Text = dr5[3].ToString();
                progressBar5.Value = int.Parse(dr5[4].ToString());
                lblgazlıtre.Text = dr5[4].ToString();
            }
            bgl.Close();

            bgl.Open();
            SqlCommand komut6 =new SqlCommand("SELECT*FROM TBLKASA",bgl);
            SqlDataReader dr6 =komut6.ExecuteReader();
            while(dr6.Read())
            {
                lblkasa.Text = dr6[0].ToString();

            }
            bgl.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listele();


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, lıtre, tutar;
            kursunsuz95 = Convert.ToDouble(lblkursunsuz95.Text);
            lıtre=Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * lıtre;
            txtkursunsuz95fıyat.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, lıtre, tutar;
            kursunsuz97 = Convert.ToDouble(lblkursunsuz97.Text);
            lıtre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * lıtre;
            txtkursunsuz97fıyat.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, lıtre, tutar;
            eurodizel = Convert.ToDouble(lbleurodızel10.Text);
            lıtre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eurodizel * lıtre;
            txteurodızelfıyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yeniprodizel, lıtre, tutar;
            yeniprodizel = Convert.ToDouble(lblyenıprodızel.Text);
            lıtre = Convert.ToDouble(numericUpDown4.Value);
            tutar = yeniprodizel * lıtre;
            txtyenıprodızelfıyat.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, lıtre, tutar;
            gaz = Convert.ToDouble(lblgaz.Text);
            lıtre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * lıtre;
            txtgazfıyat.Text = tutar.ToString();
        }

        private void btndepodoldur_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value!=0)
            {
                bgl.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) VALUES (@p1,@p2,@p3,@p4)", bgl);
                komut.Parameters.AddWithValue("@p1",txtplaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz95");
                komut.Parameters.AddWithValue("@p3",numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4",decimal.Parse(txtkursunsuz95fıyat.Text));
                komut.ExecuteNonQuery();
                bgl.Close();
               

                bgl.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE TBLKASA SET MIKTAR=MIKTAR+@p1", bgl);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtkursunsuz95fıyat.Text));
                komut2.ExecuteNonQuery();
                bgl.Close();
               
                bgl.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@p1 where PETROLTUR='Kurşunsuz95'", bgl);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            // Kurşunsuz 97 Satışı
            if (numericUpDown2.Value != 0)
            {
                bgl.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) VALUES (@p1,@p2,@p3,@p4)", bgl);
                komut.Parameters.AddWithValue("@p1", txtplaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz97");
                komut.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(txtkursunsuz97fıyat.Text));
                komut.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE TBLKASA SET MIKTAR=MIKTAR+@p1", bgl);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtkursunsuz97fıyat.Text));
                komut2.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@p1 where PETROLTUR='Kurşunsuz97'", bgl);
                komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut3.ExecuteNonQuery();
                bgl.Close();

                MessageBox.Show("Satış Yapıldı");
                listele();
            }

            // EuroDizel10 Satışı
            if (numericUpDown3.Value != 0)
            {
                bgl.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) VALUES (@p1,@p2,@p3,@p4)", bgl);
                komut.Parameters.AddWithValue("@p1", txtplaka.Text);
                komut.Parameters.AddWithValue("@p2", "EuroDizel10");
                komut.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(txteurodızelfıyat.Text));
                komut.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE TBLKASA SET MIKTAR=MIKTAR+@p1", bgl);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txteurodızelfıyat.Text));
                komut2.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@p1 where PETROLTUR='EuroDizel10'", bgl);
                komut3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                komut3.ExecuteNonQuery();
                bgl.Close();

                MessageBox.Show("Satış Yapıldı");
                listele();
            }

            // YeniProDizel Satışı
            if (numericUpDown4.Value != 0)
            {
                bgl.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) VALUES (@p1,@p2,@p3,@p4)", bgl);
                komut.Parameters.AddWithValue("@p1", txtplaka.Text);
                komut.Parameters.AddWithValue("@p2", "YeniProDizel");
                komut.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(txtyenıprodızelfıyat.Text));
                komut.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE TBLKASA SET MIKTAR=MIKTAR+@p1", bgl);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtyenıprodızelfıyat.Text));
                komut2.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@p1 where PETROLTUR='YeniProDizel'", bgl);
                komut3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut3.ExecuteNonQuery();
                bgl.Close();

                MessageBox.Show("Satış Yapıldı");
                listele();
            }

            // Gaz Satışı
            if (numericUpDown5.Value != 0)
            {
                bgl.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) VALUES (@p1,@p2,@p3,@p4)", bgl);
                komut.Parameters.AddWithValue("@p1", txtplaka.Text);
                komut.Parameters.AddWithValue("@p2", "Gaz");
                komut.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(txtgazfıyat.Text));
                komut.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE TBLKASA SET MIKTAR=MIKTAR+@p1", bgl);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtgazfıyat.Text));
                komut2.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@p1 where PETROLTUR='Gaz'", bgl);
                komut3.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                komut3.ExecuteNonQuery();
                bgl.Close();

                MessageBox.Show("Satış Yapıldı");
                listele();
            }

        }
    }
}
