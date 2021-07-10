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
    public partial class FormAra : Form
    {
        public FormAra()
        {
            InitializeComponent();
        }
        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Ara = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {
            FormAna frmana = new FormAna();
            frmana.Show();
            this.Hide();
        }

        private void FormAra_Load(object sender, EventArgs e)
        {
            //ds.Clear();
            //Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogr.accdb";
            //Baglanti.Open();

            //string Goster = "Select * from ogr";
            //OleDbDataAdapter Adaptor = new OleDbDataAdapter(Goster, Baglanti);
            //Adaptor.Fill(ds, "ogr");
            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "ogr";

            //Stun isimlerini yeniden adlandırma
            //dataGridView1.Columns["ogrno"].HeaderText = "Öğrenci No";




            //Baglanti.Close();
            //ds.Dispose();
            //Adaptor.Dispose();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //form weight heigt sabitleme
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen öğrenci no giriniz", "Uyarı");
            }
            else
            {
              
                    
                    
                    Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=ogr.accdb");
                    da = new OleDbDataAdapter("Select * from ogr where ogrno like '" + textBox1.Text + "%'", Baglanti);
                    ds = new DataSet();
                    Baglanti.Open();
                    da.Fill(ds, "ogr");
                    dataGridView1.DataSource = ds.Tables["ogr"];
                    Baglanti.Close();
                    
                
                
               
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
