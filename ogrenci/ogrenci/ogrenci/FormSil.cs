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
    public partial class FormSil : Form
    {
        public FormSil()
        {
            InitializeComponent();
        }
        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Sil = new OleDbCommand();
        DataSet ds = new DataSet();

        private void button2_Click(object sender, EventArgs e)
        {
            FormAna frmana = new FormAna();
            
            this.Hide();
            frmana.ShowDialog();
        }

        private void FormSil_Load(object sender, EventArgs e)
        {
            ds.Clear();
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogr.accdb";
            Baglanti.Open();

            string Goster = "Select * from ogr";
            OleDbDataAdapter Adaptor = new OleDbDataAdapter(Goster, Baglanti);
            Adaptor.Fill(ds, "ogr");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ogr";

            //Stun isimlerini yeniden adlandırma
            dataGridView1.Columns["ogrno"].HeaderText = "Öğrenci No";




            Baglanti.Close();
            ds.Dispose();
            Adaptor.Dispose();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //form weight heigt sabitleme
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen silmek istediğiniz öğrenci kaydının numarasını seçiniz", "Uyarı");
            }
            else
            {


                DialogResult soru;
                soru = MessageBox.Show("Öğrenci kaydı silinsin mi?", "SİL", MessageBoxButtons.YesNo);
                if (soru == DialogResult.Yes)
                {
                    Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogr.accdb";
                    Baglanti.Open();

                    Sil = Baglanti.CreateCommand();
                    Sil.CommandText = "delete from ogr where [ogrno]='" + textBox1.Text + "'";

                    if (Sil.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Kayıt Silindi", "Silindi");
                        #region
                        ds.Clear();
                        string Goster = "Select * from ogr";
                        OleDbDataAdapter Adaptor = new OleDbDataAdapter(Goster, Baglanti);
                        Adaptor.Fill(ds, "ogr");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "ogr";

                        //Stun isimlerini yeniden adlandırma
                        dataGridView1.Columns["ogrno"].HeaderText = "Öğrenci No";
                        #endregion

                        textBox1.Text = "";
                        textBox1.Focus();




                    }
                    else
                    {
                        MessageBox.Show("Böyle bir öğrenci mevcut değil", "Uyarı");
                    }

                    Baglanti.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Selectedvalue = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[Selectedvalue].Cells["ogrno"].Value.ToString();
        }

        private void FormSil_KeyPress(object sender, KeyPressEventArgs e)
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
