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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        OleDbConnection Baglanti = new OleDbConnection();
        private void Giris_Load(object sender, EventArgs e)
        {
            txtkadi.Focus();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogr.accdb";
            Baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kullanici where Kadi='" + txtkadi.Text + "' and Sifre='" + txtsifre.Text + "'", Baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                if (txtkadi.Text.ToString() == okuyucu["Kadi"].ToString())
                {
                    if (txtsifre.Text.ToString() == okuyucu["Sifre"].ToString())
                    {
                        MessageBox.Show("Giriş Başarılı\nHoşgeldiniz");
                        FormAna frmana = new FormAna();

                        //frmana.Load(); 
                        frmana.kayıtSilToolStripMenuItem.Visible = false;

                        
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

        private void kayıtOlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kayit frmkayit = new Kayit();
            frmkayit.Show();
            this.Hide();
        }

        private void adminGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin frmadmin = new Admin();
            frmadmin.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtkadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtkadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void txtsifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
      
       
    }
}
