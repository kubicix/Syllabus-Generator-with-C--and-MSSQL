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
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Xml.Linq;
using static YazGelLab1.Form1;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace YazGelLab1
{


    public partial class Form1 : Form
    {
        SqlConnection connection;
        DataTable dersProgram = new DataTable();
        // Veritabanı bağlantısı oluştur
        public string connectionString = "Server=localhost;Database=yazlab1_2;Uid=root;Pwd=kubilay41;";
        public Form1()
        {

            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // Node (Düğüm) sınıfı
        public class Node
        {
            public string DersAdi { get; } // Dersin adı
            public string Ogretmen { get; } // Öğretmen adı ya da kimliği
            public string Sinif { get; } // Sınıf adı ya da kimliği
            public string Saat { get; } // Dersin saati
            public string Gun { get; } // Dersin günü
            public List<Edge> Neighbors { get; } // Komşu kenarlar

            public Node(string dersAdi, string ogretmen, string sinif, string saat, string gun)
            {
                DersAdi = dersAdi;
                Ogretmen = ogretmen;
                Sinif = sinif;
                Saat = saat;
                Gun = gun;
                Neighbors = new List<Edge>();
            }

            public void AddNeighbor(Edge edge)
            {
                Neighbors.Add(edge);
            }
        }

        // Edge (Kenar) sınıfı
        public class Edge
        {
            public Node Source { get; } // Kenarın başlangıç düğümü
            public Node Target { get; } // Kenarın bitiş düğümü

            public Edge(Node source, Node target)
            {
                Source = source;
                Target = target;
            }
        }

        // Graph (Çizge) sınıfı
        public class Graph
        {
            public List<Node> Nodes { get; } // Çizgedeki düğümler

            public Graph()
            {
                Nodes = new List<Node>();
            }

            public void AddNode(Node node)
            {
                Nodes.Add(node);
            }

            public void AddEdge(Node source, Node target)
            {
                Edge edge = new Edge(source, target);
                source.AddNeighbor(edge);
                target.AddNeighbor(edge);
            }
            public void Clear()
            {
                Nodes.Clear(); // Tüm düğümleri temizle
                               // Kenarları (edges) da temizlemek isterseniz, Node sınıfında bir List<Edge> tanımlamış olmanız gerekebilir.
                               // Eğer böyle bir yapınız yoksa, kenarları da düğümlerle birlikte bir listeye ekleyerek onları da temizleyebilirsiniz.
                               // Örnek olarak:
                               // foreach (Node node in Nodes)
                               // {
                               //     node.Neighbors.Clear(); // Düğümün komşularını temizle
                               // }
            }
        }

        // Graph Colouring - Çizge renklendirme kodu
        // Çakışmalar key sayesinde algılanır ve bool çıktıya göre labela yazdırılır
        void CheckConflicts(Graph graph)
        {
            bool conflict = false;
            HashSet<string> checkedTeachers = new HashSet<string>(); // Öğretmenleri kontrol etmek için bir küme
            HashSet<string> checkedTeacherSlots = new HashSet<string>(); // Öğretmenlerin gün ve saatlerini kontrol etmek için bir küme

            foreach (Node node in graph.Nodes)
            {
                string teacherKey = $"{node.Ogretmen}-{node.Gun}-{node.Saat}"; // Öğretmen, gün ve saat bilgisini birleştirerek bir anahtar oluştur

                if (checkedTeacherSlots.Contains(teacherKey))
                {
                    conflict = true;
                    break;
                }

                checkedTeacherSlots.Add(teacherKey);

                HashSet<string> checkedNodes = new HashSet<string>(); // Kontrol edilen düğümleri saklamak için bir küme

                string key = $"{node.Saat}-{node.Sinif}-{node.Gun}"; // Saat, sınıf ve günü birleştirerek bir anahtar oluştur

                if (checkedNodes.Contains(key) && checkedTeachers.Contains(node.Ogretmen))
                {
                    conflict = true;
                    break;
                }

                checkedNodes.Add(key);
                checkedTeachers.Add(node.Ogretmen);

                foreach (Edge edge in node.Neighbors)
                {
                    Node neighborNode = edge.Source == node ? edge.Target : edge.Source;

                    string neighborKey = $"{neighborNode.Saat}-{neighborNode.Sinif}-{neighborNode.Gun}"; // Öğretmen, saat, sınıf ve günü birleştirerek bir anahtar oluştur

                    if (key == neighborKey)
                    {
                        conflict = true;
                        break;
                    }
                }

                if (conflict)
                    break;
            }

            // Çakışma durumuna göre label3'ü güncelle
            label3.Text = conflict ? "Çakışma var" : "Çakışma yok";
            ekleBtn.Enabled = true;
        }

        private void GetDataFromDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT Gun, Saat, DersAdi, Ogretmen, Sinif
                        FROM dersprogrami
                        ORDER BY
                          CASE Gun
                            WHEN 'Pazartesi' THEN 1
                            WHEN 'Sali' THEN 2
                            WHEN 'Carsamba' THEN 3
                            WHEN 'Persembe' THEN 4
                            WHEN 'Cuma' THEN 5
                            ELSE 6
                          END,
                          CASE Saat
                            WHEN '09:00' THEN 1
                            WHEN '10:00' THEN 2
                            WHEN '11:00' THEN 3
                            WHEN '12:00' THEN 4
                            WHEN '13:00' THEN 5
                            WHEN '14:00' THEN 6
                            WHEN '15:00' THEN 7
                            WHEN '16:00' THEN 8
                            ELSE 9
                          END;
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



        public class Ders
        {
            public string DersAdi { get; set; }
            public string DersinOgretmeni { get; set; }
            public string DersinSinifi { get; set; }
            public string DersinSaati { get; set; }
            public string DersinGunu { get; set; }

            public Ders(string dersAdi, string dersinOgretmeni, string dersinSinifi, string dersinSaati, string dersinGunu)
            {
                DersAdi = dersAdi;
                DersinOgretmeni = dersinOgretmeni;
                DersinSinifi = dersinSinifi;
                DersinSaati = dersinSaati;
                DersinGunu = dersinGunu;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            GetDataFromDatabase();
            string query2 = @"";

            derstbGrid.RowHeadersVisible = true;
            derstbGrid.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            ekleBtn.Enabled = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {


            // Ders örnekleri oluşturalım ve önceki öğretmen, sınıf ve saat nesnelerini kullanarak bu derslere atayalım
            Ders ders1 = new Ders(txders1.Text, ogrt1.Text, sinif1.Text, saat1.Text, gun1.Text);
            Ders ders2 = new Ders(txders2.Text, ogrt2.Text, sinif2.Text, saat2.Text, gun2.Text);
            Ders ders3 = new Ders(txders3.Text, ogrt3.Text, sinif3.Text, saat3.Text, gun3.Text);
            Ders ders4 = new Ders(txders4.Text, ogrt4.Text, sinif4.Text, saat4.Text, gun4.Text);
            Ders ders5 = new Ders(txders5.Text, ogrt5.Text, sinif5.Text, saat5.Text, gun5.Text);
            Ders ders6 = new Ders(txders6.Text, ogrt6.Text, sinif6.Text, saat6.Text, gun6.Text);
            Ders ders7 = new Ders(txders7.Text, ogrt7.Text, sinif7.Text, saat7.Text, gun7.Text);
            Ders ders8 = new Ders(txders8.Text, ogrt8.Text, sinif8.Text, saat8.Text, gun8.Text);


            // Dersleri bir liste içinde toplamakodu
            List<Ders> dersler = new List<Ders>();
            dersler.Add(ders1);
            dersler.Add(ders2);
            dersler.Add(ders3);
            dersler.Add(ders4);
            dersler.Add(ders5);
            dersler.Add(ders6);
            dersler.Add(ders7);
            dersler.Add(ders8);

            Graph graph = new Graph();

            // Dersleri çizgeye ekleme ve komşuluk ilişkilerini edge metodu ile  oluşturma
            foreach (Ders ders in dersler)
            {
                Node node = new Node(ders.DersAdi, ders.DersinOgretmeni, ders.DersinSinifi, ders.DersinSaati, ders.DersinGunu);
                graph.AddNode(node);

                foreach (Node otherNode in graph.Nodes)
                {
                    // Kendi düğümümüzü kontrol etmiyoruz
                    if (otherNode != node)
                    {
                        // Aynı ders adı, öğretmen, sınıf veya saat özelliklerine sahipse kenar oluştur
                        if (otherNode.DersAdi == node.DersAdi ||
                            otherNode.Ogretmen == node.Ogretmen ||
                            otherNode.Sinif == node.Sinif ||
                            otherNode.Saat == node.Saat || otherNode.Gun == node.Gun)
                        {
                            graph.AddEdge(node, otherNode);
                        }
                    }
                }
            }



            CheckConflicts(graph);
            graph.Clear();
            dersler.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txders1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            // DataTable oluştur
            DataTable dersProgram = new DataTable();

            // Sütunları DataTable'a ekle
            dersProgram.Columns.Add("DersAdi", typeof(string));
            dersProgram.Columns.Add("Ogretmen", typeof(string));
            dersProgram.Columns.Add("Sinif", typeof(string));
            dersProgram.Columns.Add("Saat", typeof(string));
            dersProgram.Columns.Add("Gun", typeof(string));

            // Ders örneklerini DataTable'a ekle
            dersProgram.Rows.Add(txders1.Text, ogrt1.Text, sinif1.Text, saat1.Text, gun1.Text);
            dersProgram.Rows.Add(txders2.Text, ogrt2.Text, sinif2.Text, saat2.Text, gun2.Text);
            dersProgram.Rows.Add(txders3.Text, ogrt3.Text, sinif3.Text, saat3.Text, gun3.Text);
            dersProgram.Rows.Add(txders4.Text, ogrt4.Text, sinif4.Text, saat4.Text, gun4.Text);
            dersProgram.Rows.Add(txders5.Text, ogrt5.Text, sinif5.Text, saat5.Text, gun5.Text);
            dersProgram.Rows.Add(txders6.Text, ogrt6.Text, sinif6.Text, saat6.Text, gun6.Text);
            dersProgram.Rows.Add(txders7.Text, ogrt7.Text, sinif7.Text, saat7.Text, gun7.Text);
            dersProgram.Rows.Add(txders8.Text, ogrt8.Text, sinif8.Text, saat8.Text, gun8.Text);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (DataRow row in dersProgram.Rows)
                    {
                        string insertQuery = "INSERT INTO dersprogrami (DersAdi, Ogretmen, Sinif, Saat, Gun) VALUES (@DersAdi, @Ogretmen, @Sinif, @Saat, @Gun)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@DersAdi", row["DersAdi"]);
                        insertCommand.Parameters.AddWithValue("@Ogretmen", row["Ogretmen"]);
                        insertCommand.Parameters.AddWithValue("@Sinif", row["Sinif"]);
                        insertCommand.Parameters.AddWithValue("@Saat", row["Saat"]);
                        insertCommand.Parameters.AddWithValue("@Gun", row["Gun"]);

                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Veriler başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // veriler gönderildikten sonra dataTable temizle
                    dersProgram.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            ekleBtn.Enabled = false;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        private void tabloBtn_Click(object sender, EventArgs e)
        {
            derstbGrid.Refresh();
            GetDataFromDatabase();
        }
        
    }
}