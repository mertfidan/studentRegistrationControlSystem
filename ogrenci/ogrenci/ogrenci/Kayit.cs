using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ogrenci
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Ekle = new OleDbCommand();
        DataSet ds = new DataSet();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Tüm alanları doldurmalısınız", "Uyarı");
            }
            else
            {

                if (textBox3.Text!=textBox4.Text)
                {
                    MessageBox.Show("Şifreler Uyuşmuyor", "Şifre Tekrar Hatası");
                }
                else
                {

                Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogr.accdb";
                Baglanti.Open();
                try
                {
                    Ekle = Baglanti.CreateCommand();
                    Ekle.CommandText = "INSERT into kullanici ([Adsoyad],[Kadi],[Sifre],[Email]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')";

                    if (Ekle.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Kayıt Başarıyla Gerçekleştirildi", "Kayıt Başarılı");
                        Giris frmgiris = new Giris();
                        frmgiris.Show();
                        this.Hide();

                        #region
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox1.Focus();
                        #endregion
                        
                    }


                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bu kullanıcı mevcut", "Hata");
                    //MessageBox.Show("Hata : " + hata.ToString());
                }

                Baglanti.Close();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris frmgiris = new Giris();
            
            this.Hide();
            frmgiris.ShowDialog();
        }

        private void Kayit_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
