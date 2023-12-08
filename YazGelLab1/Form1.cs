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

namespace YazGelLab1
{
    

    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public class SQLConnection
        {

        }

        public class DersSaatleri
        {
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-BDSUH1M\\SQLEXPRESS;Initial Catalog=DbYazlab;Integrated Security=True";

            // SqlConnection oluşturma ve bağlantıyı açma
            connection = new SqlConnection(connectionString);
            connection.Open();

            // SqlConnection oluşturma
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT d.dersad AS DersAdi, \r\n       d.derskod AS DersKodu, \r\n       o.ad AS OgretmenAdi, \r\n       o.soyad AS OgretmenSoyadi\r\nFROM TblDersler d\r\nINNER JOIN TblOgretmen o ON d.sicilno = o.sicilno"; // SQL sorgusu
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    string result = ""; // Veriyi tutmak için bir string oluşturuyoruz

                    while (reader.Read())
                    {
                        string row = ""; // Her bir satır için yeni bir dize oluşturuyoruz

                        // Tüm sütunları sırayla alıp row stringine ekliyoruz
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row += reader[i].ToString() + " ";
                        }

                        // ListBox'a her satırı ayrı bir öğe olarak ekliyoruz
                        listBox1.Items.Add(row);
                    }

                    // TextBox'a değeri yazdırma


                    reader.Close();
                }
                connection.Close();
            }

            // DataGridView'e satırlar ekleme
            dataGridView1.RowHeadersVisible = true;

            dataGridView1.Rows.Add("", "", "", "", ""); // Satır eklemek için her gün için boş sütunlar ekledik
            dataGridView1.Rows.Add("", "", "", "", "");
            dataGridView1.Rows.Add("", "", "", "", "");
            dataGridView1.Rows.Add("", "", "", "", "");
            dataGridView1.Rows.Add("", "", "", "", "");
            dataGridView1.Rows.Add("", "", "", "", "");
            dataGridView1.Rows.Add("", "", "", "", "");
            dataGridView1.Rows[0].HeaderCell.Value = "09:00";
            dataGridView1.Rows[1].HeaderCell.Value = "10:00";
            dataGridView1.Rows[2].HeaderCell.Value = "11:00";
            dataGridView1.Rows[3].HeaderCell.Value = "12:00";
            dataGridView1.Rows[4].HeaderCell.Value = "13:00";
            dataGridView1.Rows[5].HeaderCell.Value = "14:00";
            dataGridView1.Rows[6].HeaderCell.Value = "15:00";
            dataGridView1.Rows[7].HeaderCell.Value = "16:00";
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
