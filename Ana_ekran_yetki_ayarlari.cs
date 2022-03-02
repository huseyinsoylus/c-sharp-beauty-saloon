using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace NGBeauty
{
    public partial class Ana_ekran_yetki_ayarlari : Form
    {
        public Ana_ekran_yetki_ayarlari()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        int yetki_id;
        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ana_ekran_yetki_ayarlari_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=dt1.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kullanicilar_giris_bilgileri";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox_calisan.Items.Add(dr["kullanici_adi"]);

            }
            dr.Close();
            
            cmd.CommandText = "SELECT * FROM kullanici_yetkileri";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox_yetkiler.Items.Add(dr["yetki_adi"]);

            }
            con.Close();
        }

        private void button_yetki_güncelle_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update kullanicilar_giris_bilgileri set yetki_id ="+yetki_id+" where kullanici_adi ='"+comboBox_calisan.SelectedItem.ToString()+"' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Başarılı. ", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();
        }

        private void comboBox_yetkiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=dt1.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kullanici_yetkileri";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
               
                if (dr["yetki_adi"].ToString()==comboBox_yetkiler.SelectedItem.ToString())
                {
                    yetki_id = Convert.ToInt32(dr["yetki_id"]);
                    
                }
            }
            dr.Close();
            con.Close();
        }

        private void yeniYetkiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
