using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ogrenci
{
    
    public partial class FormAna : Form
    {
        
    
        
        public FormAna()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
            if (exit == DialogResult.Yes)
            {
                MessageBox.Show("İyi günler", "HOŞÇAKALIN");
                
                Giris frmgiris = new Giris();
                
                this.Hide();
                frmgiris.ShowDialog();

                
                
            }
        }

        public void FormAna_Load(object sender, EventArgs e)
        {

            //gorunmez();
            
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKaydet kaydet = new FormKaydet();
            kaydet.Show();
            this.Hide();
        }

        private void bilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGuncel guncelle = new FormGuncel();
            guncelle.Show();
            this.Hide();
        }

        private void kayıtSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FormSil sil = new FormSil();
            sil.Show();
            this.Hide();
        }

        private void kayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAra ara = new FormAra();
            ara.Show();
            this.Hide();
        }
    //       public void gorunmez()
    //{
    //    kayıtSilToolStripMenuItem.Visible = false;
    //}
    }
}
