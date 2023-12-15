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
        //private void RenklendirmeAlgoritmasi(List<Ders> dersler)
        //{
        //    // Çakışma var mı kontrol etmek için iki dersin çakışıp çakışmadığını kontrol eden bir metot
        //    bool CakismaVarMi(Ders ders1, Ders ders2)
        //    {
        //        if (ders1.DersinSaati.SaatDegeri == ders2.DersinSaati.SaatDegeri &&
        //            ders1.DersinSinifi.SinifAdi == ders2.DersinSinifi.SinifAdi &&
        //            ders1.DersinOgretmeni.Ad == ders2.DersinOgretmeni.Ad)
        //        {
        //            return true; // Çakışma var
        //        }
        //        return false; // Çakışma yok
        //    }

        //    // Çakışma kontrolü
        //    for (int i = 0; i < dersler.Count; i++)
        //    {
        //        for (int j = i + 1; j < dersler.Count; j++)
        //        {
        //            if (CakismaVarMi(dersler[i], dersler[j]))
        //            {
        //                // Çakışma var, label2'yi güncelle
        //                label3.Text = "Çakışma var";
        //                return; // Çakışma olduğu için işlemi sonlandır
        //            }
        //        }
        //    }

        //    // Eğer hiç çakışma yoksa label2'yi güncelle
        //    label3.Text = "Çakışma yok";
        //}

        // Node (Düğüm) sınıfı
        public class Node
        {
            public string DersAdi { get; } // Dersin adı
            public string Ogretmen { get; } // Öğretmen adı ya da kimliği
            public string Sinif { get; } // Sınıf adı ya da kimliği
            public string Saat { get; } // Dersin saati
            public List<Edge> Neighbors { get; } // Komşu kenarlar

            public Node(string dersAdi, string ogretmen, string sinif, string saat)
            {
                DersAdi = dersAdi;
                Ogretmen = ogretmen;
                Sinif = sinif;
                Saat = saat;
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
        }

        void CheckConflicts(Graph graph)
        {
            bool conflict = false;

            foreach (Node node in graph.Nodes)
            {
                HashSet<string> checkedNodes = new HashSet<string>(); // Kontrol edilen düğümleri saklamak için bir küme

                foreach (Edge edge in node.Neighbors)
                {
                    Node neighborNode = edge.Source == node ? edge.Target : edge.Source;

                    string key = $"{neighborNode.Ogretmen}-{neighborNode.Saat}-{neighborNode.Sinif}"; // Öğretmen, saat ve sınıfı birleştirerek bir anahtar oluştur

                    if (checkedNodes.Contains(key))
                    {
                        conflict = true;
                        break;
                    }

                    checkedNodes.Add(key);
                }

                if (conflict)
                    break;
            }

            // Çakışma durumuna göre label3'ü güncelle
            label3.Text = conflict ? "Çakışma var" : "Çakışma yok";
        }






        public class Ders
        {
            public string DersAdi { get; set; }
            public string DersinOgretmeni { get; set; }
            public string DersinSinifi { get; set; }
            public string DersinSaati { get; set; }

            public Ders(string dersAdi, string dersinOgretmeni, string dersinSinifi, string dersinSaati)
            {
                DersAdi = dersAdi;
                DersinOgretmeni = dersinOgretmeni;
                DersinSinifi = dersinSinifi;
                DersinSaati = dersinSaati;
            }
        }

        //public class Saat
        //{
        //    public string SaatDegeri { get; set; }

        //    public Saat(string saatDegeri)
        //    {
        //        SaatDegeri = saatDegeri;
        //    }
        //}

        //public class Sinif
        //{
        //    public string SinifAdi { get; set; }

        //    public Sinif(string sinifAdi)
        //    {
        //        SinifAdi = sinifAdi;
        //    }
        //}


        //public class Ogretmen
        //{
        //    public string Ad { get; set; }

        //    public Ogretmen(string ad)
        //    {
        //        Ad = ad;
        //    }
        //}


        

        





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

            //SqlCommand command2 = new SqlCommand(query2, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command2);
            //DataTable dataTable = new DataTable();

            //try
            //{
                
            //    adapter.Fill(dataTable);

            //    // DataGridView'e verileri yükleme
            //    dataGridView1.DataSource = dataTable;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}

            
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Ders, Ogretmen, Sinif ve Saat nesnelerini oluşturalım
            //Ogretmen ogretmen1 = new Ogretmen("Öğretmen 1");
            //Ogretmen ogretmen2 = new Ogretmen("Öğretmen 2");
            //Ogretmen ogretmen3 = new Ogretmen("Öğretmen 3");

            //Saat saat1 = new Saat("09:00");
            //Saat saat2 = new Saat("10:00");
            //Saat saat3 = new Saat("11:00");

            //Sinif sinif1 = new Sinif("Sınıf A");
            //Sinif sinif2 = new Sinif("Sınıf B");
            //Sinif sinif3 = new Sinif("Sınıf C");


            // Ders örnekleri oluşturalım ve önceki öğretmen, sınıf ve saat nesnelerini kullanarak bu derslere atayalım
            Ders ders1 = new Ders("Matematik", "ogretmen1", "sinif1", "saat1");
            Ders ders2 = new Ders("Matematik", "ogretmen1", "sinif2", "saat1");
            Ders ders3 = new Ders("Matematik4", "ogretmen1", "sinif1", "saat2");
            Ders ders4 = new Ders("Matematik2", "ogretmen1", "sinif2", "saat1");


            // Dersleri bir liste içinde toplayalım
            List<Ders> dersler = new List<Ders>();
            dersler.Add(ders1);
            dersler.Add(ders2);
            dersler.Add(ders3);
            dersler.Add(ders4);

            Graph graph= new Graph();

            // Dersleri çizgeye ekleme ve komşuluk ilişkilerini oluşturma
            foreach (Ders ders in dersler)
            {
                Node node = new Node(ders.DersAdi, ders.DersinOgretmeni, ders.DersinSinifi, ders.DersinSaati);
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
                            otherNode.Saat == node.Saat)
                        {
                            graph.AddEdge(node, otherNode);
                        }
                    }
                }
            }



            CheckConflicts(graph);
            listBox1.Items.Clear();
            listBox1.Items.Add(graph.Nodes[0].DersAdi);
            listBox1.Items.Add(graph.Nodes[1].DersAdi);
            listBox1.Items.Add(graph.Nodes[2].DersAdi);
            listBox1.Items.Add(graph.Nodes[3].DersAdi);
        }
    }
}
