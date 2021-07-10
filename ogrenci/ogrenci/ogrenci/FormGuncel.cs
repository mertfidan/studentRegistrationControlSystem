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
    public partial class FormGuncel : Form
    {
        public FormGuncel()
        {
            InitializeComponent();
        }

        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Guncelle = new OleDbCommand();
        DataSet ds = new DataSet();

        private void button2_Click(object sender, EventArgs e)
        {
            
            FormAna frmana = new FormAna();
            
            this.Hide();
            frmana.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Öğrenci seçiniz.", "Uyarı");
            }
            else
            {



                Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogr.accdb";
                Baglanti.Open();
                try
                {
                    Guncelle = Baglanti.CreateCommand();
                    Guncelle.CommandText = "UPDATE ogr SET [ogrno]='" + textBox1.Text + "',[adsoyad]='" + textBox2.Text + "',[okul]='" + textBox4.Text + "',[bolum]='" + textBox5.Text + "',[tip]='" + comboBox1.Text + "',[grup]='" + comboBox2.Text + "',[adres]='" + textBox6.Text + "',[il]='" + comboBox4.Text + "',[ilce]='" + textBox8.Text + "',[kangrup]='" + comboBox8.Text + "',[tel]='" + textBox9.Text + "',[gsm]='" + textBox10.Text + "',[mail]='" + textBox11.Text + "',[sinif]='" + comboBox3.Text + "',[tcseri]='" + textBox12.Text + "',[tcno]='" + textBox13.Text + "',[tckimlikno]='" + textBox14.Text + "',[tcbaba]='" + textBox15.Text + "',[tcana]='" + textBox16.Text + "',[tcdogyer]='" + textBox17.Text + "',[tcdogtar]='" + dateTimePicker1.Text + "',[tcmedenihal]='" + comboBox5.Text + "',[tcil]='" + textBox18.Text + "',[tcilce]='" + textBox19.Text + "',[tcmahalle]='" + textBox20.Text + "',[tcciltno]='" + textBox21.Text + "',[tcailesirano]='" + textBox22.Text + "',[tcsirano]='" + textBox23.Text + "',[tckayitno]='" + textBox24.Text + "',[tcyeri]='" + textBox25.Text + "',[tcnedeni]='" + comboBox6.Text + "',[tcverilis]='" + comboBox4.Text + "'  Where [ogrno]='" + textBox1.Text + "'";

                    if (Guncelle.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Güncelleme İşlemi Başarılı", "Güncellendi");
                        #region
textBox1.Text ="";
textBox2.Text ="";

textBox4.Text ="";
textBox5.Text ="";
comboBox1.Text ="";
comboBox2.Text ="";
textBox6.Text ="";
comboBox4.Text = "";
textBox8.Text ="";
comboBox8.Text ="";
textBox9.Text ="";
textBox10.Text ="";
textBox11.Text ="";
comboBox3.Text ="";
textBox12.Text ="";
textBox13.Text ="";
textBox14.Text ="";
textBox15.Text ="";
textBox16.Text ="";
textBox17.Text ="";
dateTimePicker1.Text="";
comboBox5.Text ="";
textBox18.Text ="";
textBox19.Text ="";
textBox20.Text ="";
textBox21.Text ="";
textBox22.Text ="";
textBox23.Text ="";
textBox24.Text ="";
textBox25.Text ="";
comboBox6.Text ="";
comboBox4.Text = "";
textBox1.Focus();
                        #endregion

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

                }
                    else
                    {
                        MessageBox.Show("Böyle Bir kayıt yok", "Güncellendi");
                    }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işlemi başarısız","Hata");
                MessageBox.Show("Hata : "+hata.ToString());
            }
            Baglanti.Close();

            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Selectedvalue = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[Selectedvalue].Cells["ogrno"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[Selectedvalue].Cells["adsoyad"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[Selectedvalue].Cells["okul"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[Selectedvalue].Cells["bolum"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[Selectedvalue].Cells["tip"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[Selectedvalue].Cells["grup"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[Selectedvalue].Cells["adres"].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[Selectedvalue].Cells["il"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[Selectedvalue].Cells["ilce"].Value.ToString();

            comboBox8.Text = dataGridView1.Rows[Selectedvalue].Cells["kangrup"].Value.ToString();
            textBox9.Text = dataGridView1.Rows[Selectedvalue].Cells["tel"].Value.ToString();
            textBox10.Text = dataGridView1.Rows[Selectedvalue].Cells["gsm"].Value.ToString();
            textBox11.Text = dataGridView1.Rows[Selectedvalue].Cells["mail"].Value.ToString();

            comboBox3.Text = dataGridView1.Rows[Selectedvalue].Cells["sinif"].Value.ToString();
            textBox12.Text = dataGridView1.Rows[Selectedvalue].Cells["tcseri"].Value.ToString();
            textBox13.Text = dataGridView1.Rows[Selectedvalue].Cells["tcno"].Value.ToString();
            textBox14.Text = dataGridView1.Rows[Selectedvalue].Cells["tckimlikno"].Value.ToString();
            textBox15.Text = dataGridView1.Rows[Selectedvalue].Cells["tcbaba"].Value.ToString();
            textBox16.Text = dataGridView1.Rows[Selectedvalue].Cells["tcana"].Value.ToString();
            textBox17.Text = dataGridView1.Rows[Selectedvalue].Cells["tcdogyer"].Value.ToString();

            dateTimePicker1.Text= dataGridView1.Rows[Selectedvalue].Cells["tcdogtar"].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[Selectedvalue].Cells["tcmedenihal"].Value.ToString();

            textBox18.Text = dataGridView1.Rows[Selectedvalue].Cells["tcil"].Value.ToString();
            textBox19.Text = dataGridView1.Rows[Selectedvalue].Cells["tcilce"].Value.ToString();
            textBox20.Text = dataGridView1.Rows[Selectedvalue].Cells["tcmahalle"].Value.ToString();
            textBox21.Text = dataGridView1.Rows[Selectedvalue].Cells["tcciltno"].Value.ToString();
            textBox22.Text = dataGridView1.Rows[Selectedvalue].Cells["tcailesirano"].Value.ToString();
            textBox23.Text = dataGridView1.Rows[Selectedvalue].Cells["tcsirano"].Value.ToString();
            textBox24.Text = dataGridView1.Rows[Selectedvalue].Cells["tckayitno"].Value.ToString();
            textBox25.Text = dataGridView1.Rows[Selectedvalue].Cells["tcyeri"].Value.ToString();

            comboBox6.Text = dataGridView1.Rows[Selectedvalue].Cells["tcnedeni"].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[Selectedvalue].Cells["tcverilis"].Value.ToString();
            
        }

        private void FormGuncel_Load(object sender, EventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
    }

