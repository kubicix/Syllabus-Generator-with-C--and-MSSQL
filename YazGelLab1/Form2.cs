using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static YazGelLab1.Form1;

namespace YazGelLab1
{
    public partial class Form2 : Form
    {
        SqlConnection connection;
        public string connectionString = "Server=localhost;Database=yazlab1_2;Uid=root;Pwd=kubilay41;";
        public Form2()
        {
            InitializeComponent();
        }
        private void GetDataFromDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM yazlab1_2.dersprogrami;
                    ";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    derstbGrid.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            GetDataFromDatabase();
        }

        private void derstbGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Tıklanan satır var mı kontrolü
            {
                DataGridViewRow row = derstbGrid.Rows[e.RowIndex];

                // DataGridView hücrelerindeki verileri al
                string id = row.Cells["iddersprogrami"].Value.ToString();
                string ders = row.Cells["DersAdi"].Value.ToString();
                string ogretmen = row.Cells["Ogretmen"].Value.ToString();
                string sinif = row.Cells["Sinif"].Value.ToString();
                string saat = row.Cells["Saat"].Value.ToString();
                string gun = row.Cells["Gun"].Value.ToString();

                // TextBox'lara verileri aktar
                id1.Text = id;
                ders1.Text = ders;
                ogrt1.Text = ogretmen;

                // ComboBox'lara verileri aktar
                sinif1.SelectedItem = sinif;
                saat1.SelectedItem = saat;
                gun1.SelectedItem = gun;
            }
        }

        private void tabloBtn_Click(object sender, EventArgs e)
        {
            derstbGrid.Refresh();
            GetDataFromDatabase();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tabloyu temizlemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string connectionString = "Server=localhost;Database=yazlab1_2;Uid=root;Pwd=kubilay41;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string clearQuery = "DELETE FROM dersprogrami";
                        MySqlCommand clearCommand = new MySqlCommand(clearQuery, connection);

                        clearCommand.ExecuteNonQuery();

                        MessageBox.Show("Tablo başarıyla temizlendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DataGridView içeriğini temizle
                        derstbGrid.DataSource = null;
                        derstbGrid.Rows.Clear();
                        derstbGrid.Columns.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE dersprogrami SET DersAdi = @DersAdi, Ogretmen = @Ogretmen, Sinif = @Sinif, Saat = @Saat, Gun = @Gun WHERE iddersprogrami = @Id";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);

                    updateCommand.Parameters.AddWithValue("@DersAdi", ders1.Text);
                    updateCommand.Parameters.AddWithValue("@Ogretmen", ogrt1.Text);
                    updateCommand.Parameters.AddWithValue("@Sinif", sinif1.Text);
                    updateCommand.Parameters.AddWithValue("@Saat", saat1.Text);
                    updateCommand.Parameters.AddWithValue("@Gun", gun1.Text);
                    updateCommand.Parameters.AddWithValue("@Id", id1.Text);

                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Veri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id1.Text))
            {
                DialogResult result = MessageBox.Show("Seçili dersi silmek istediğinize emin misiniz?", "Ders Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Server=localhost;Database=yazlab1_2;Uid=root;Pwd=kubilay41;";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            string deleteQuery = "DELETE FROM dersprogrami WHERE iddersprogrami = @Id";
                            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@Id", int.Parse(id1.Text));

                            int affectedRows = deleteCommand.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Ders başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Veritabanı tablosu güncellendi, DataGridView'i yeniden yükle
                                GetDataFromDatabase();
                            }
                            else
                            {
                                MessageBox.Show("Ders silinemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir ders seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void girdibtn_Click(object sender, EventArgs e)
        {
            string dersAdi = ders1.Text;
            string ogretmen = ogrt1.Text;
            string sinif = sinif1.Text;
            string saat = saat1.Text;
            string gun = gun1.Text;

            if (!string.IsNullOrEmpty(dersAdi) && !string.IsNullOrEmpty(ogretmen) &&
                !string.IsNullOrEmpty(sinif) && !string.IsNullOrEmpty(saat) &&
                !string.IsNullOrEmpty(gun))
            {
                string connectionString = "Server=localhost;Database=yazlab1_2;Uid=root;Pwd=kubilay41;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO dersprogrami (DersAdi, Ogretmen, Sinif, Saat, Gun) VALUES (@DersAdi, @Ogretmen, @Sinif, @Saat, @Gun)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@DersAdi", dersAdi);
                        insertCommand.Parameters.AddWithValue("@Ogretmen", ogretmen);
                        insertCommand.Parameters.AddWithValue("@Sinif", sinif);
                        insertCommand.Parameters.AddWithValue("@Saat", saat);
                        insertCommand.Parameters.AddWithValue("@Gun", gun);

                        int affectedRows = insertCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Yeni ders başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Veritabanı tablosu güncellendi, DataGridView'i yeniden yükle
                            GetDataFromDatabase();
                        }
                        else
                        {
                            MessageBox.Show("Yeni ders eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
