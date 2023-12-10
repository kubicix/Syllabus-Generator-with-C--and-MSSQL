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
                        string row = ""; // r bir satır için yeni bir dize oluşturuyoruz

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
                //connection.Close();
            }

            // Data grid viewe sql tablo sorgusunu çekme 
            string query2 = @"
                WITH GunlerSiralama AS (
    SELECT 
        Gun,
        ROW_NUMBER() OVER (ORDER BY 
            CASE Gun
                WHEN 'Pazartesi' THEN 1
                WHEN 'Sali' THEN 2
                WHEN 'Çarşamba' THEN 3
                WHEN 'Perşembe' THEN 4
                WHEN 'Cuma' THEN 5
                ELSE 6
            END
        ) AS GunSirasi
    FROM (
        SELECT DISTINCT Gun FROM DersProgrami
    ) AS Gunler
)

SELECT 
    GunlerSiralama.Gun,
    Saatler.Saat,
    TblDersler.dersad AS DersAdi,
    TblOgretmen.ad + ' ' + TblOgretmen.soyad AS OgretmenAdSoyad,
    TblSiniflar.sinifad AS SinifAdi
FROM 
    GunlerSiralama
CROSS JOIN
    (VALUES ('09:00'), ('10:00'), ('11:00'), ('12:00'), ('13:00'), ('14:00'), ('15:00'), ('16:00')) AS Saatler(Saat)
LEFT JOIN 
    DersProgrami ON GunlerSiralama.Gun = DersProgrami.Gun AND Saatler.Saat = CONVERT(VARCHAR(5), DersProgrami.Saat, 108)
LEFT JOIN 
    TblDersler ON DersProgrami.dersno = TblDersler.dersno
LEFT JOIN 
    TblOgretmen ON DersProgrami.sicilno = TblOgretmen.sicilno
LEFT JOIN 
    TblSiniflar ON DersProgrami.sinifno = TblSiniflar.sinifno
ORDER BY 
    GunlerSiralama.GunSirasi, Saatler.Saat;

            ";

            SqlCommand command2 = new SqlCommand(query2, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command2);
            DataTable dataTable = new DataTable();

            try
            {
                
                adapter.Fill(dataTable);

                // DataGridView'e verileri yükleme
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // DataGridView'e satırlar ekleme
            dataGridView1.RowHeadersVisible = true;
            //dataGridView1.Rows.Add("", "", "", "", ""); // Satır eklemek için her gün için boş sütunlar ekledik
            //dataGridView1.Rows.Add("", "", "", "", "");
            //dataGridView1.Rows.Add("", "", "", "", "");
            //dataGridView1.Rows.Add("", "", "", "", "");
            //dataGridView1.Rows.Add("", "", "", "", "");
            //dataGridView1.Rows.Add("", "", "", "", "");
            //dataGridView1.Rows.Add("", "", "", "", "");
            //dataGridView1.Rows[0].HeaderCell.Value = "09:00";
            //dataGridView1.Rows[1].HeaderCell.Value = "10:00";
            //dataGridView1.Rows[2].HeaderCell.Value = "11:00";
            //dataGridView1.Rows[3].HeaderCell.Value = "12:00";
            //dataGridView1.Rows[4].HeaderCell.Value = "13:00";
            //dataGridView1.Rows[5].HeaderCell.Value = "14:00";
            //dataGridView1.Rows[6].HeaderCell.Value = "15:00";
            //dataGridView1.Rows[7].HeaderCell.Value = "16:00";

            // Row başlıklarını gözükür yapma ve row autoSize eklentisi
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
