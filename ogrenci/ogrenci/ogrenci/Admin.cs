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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        OleDbConnection Baglanti = new OleDbConnection();

        private void button2_Click(object sender, EventArgs e)
        {
            Giris frmgiris = new Giris();
            frmgiris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogr.accdb";
            Baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from admin where Kadi='" + textBox1.Text + "' and Sifre='" + textBox2.Text + "'", Baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                if (textBox1.Text.ToString() == okuyucu["Kadi"].ToString())
                {
                    if (textBox2.Text.ToString() == okuyucu["Sifre"].ToString())
                    {
                        
                        MessageBox.Show("Giriş Başarılı\nHoşgeldiniz");
                        FormAna frmana = new FormAna();
                        frmana.kayıtSilToolStripMenuItem.Visible = true;

                        this.Hide();
                        frmana.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre hatalı !", ":Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre hatalı !", ":Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre hatalı !", ":Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Baglanti.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
