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
        

        // Node (Düğüm) sınıfı
        public class Node
        {
            public string DersAdi { get; } // Dersin adı
            public string Ogretmen { get; } // Öğretmen adı ya da kimliği
            public string Sinif { get; } // Sınıf adı ya da kimliği
            public string Saat { get; } // Dersin saati
            public string Gun { get; } // Dersin günü
            public List<Edge> Neighbors { get; } // Komşu kenarlar

            public Node(string dersAdi, string ogretmen, string sinif, string saat,string gun)
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
        }

        // Graph Colouring - Çizge renklendirme kodu
        // Çakışmalar key sayesinde algılanır ve bool çıktıya göre labela yazdırılır
        void CheckConflicts(Graph graph)
        {
            bool conflict = false;

            foreach (Node node in graph.Nodes)
            {
                HashSet<string> checkedNodes = new HashSet<string>(); // Kontrol edilen düğümleri saklamak için bir küme

                foreach (Edge edge in node.Neighbors)
                {
                    Node neighborNode = edge.Source == node ? edge.Target : edge.Source;

                    string key = $"{neighborNode.Ogretmen}-{neighborNode.Saat}-{neighborNode.Sinif}-{neighborNode.Gun}"; // Öğretmen, saat ve sınıfı birleştirerek bir anahtar oluştur

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

            

            // Data grid viewe sql tablo sorgusunu çekme 
            // Sql sorgusu buraya girilecek
            string query2 = @"";

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

            //manuel input kısmı
            //Ders ders2 = new Ders("Matematik2", "ogretmen1", "sinif2", "saat1", "gun1");
            //Ders ders3 = new Ders("Matematik4", "ogretmen1", "sinif1", "saat2", "gun1");
            //Ders ders4 = new Ders("Matematik2", "ogretmen1", "sinif2", "saat2", "gun1");

            // Ders örnekleri oluşturalım ve önceki öğretmen, sınıf ve saat nesnelerini kullanarak bu derslere atayalım
            Ders ders1 = new Ders(txders1.Text, ogrt1.Text, sinif1.Text, saat1.Text,gun1.Text);
            Ders ders2 = new Ders(txders2.Text, ogrt2.Text, sinif2.Text, saat2.Text, gun2.Text);
            Ders ders3 = new Ders(txders3.Text, ogrt3.Text, sinif3.Text, saat3.Text, gun3.Text);
            Ders ders4 = new Ders(txders4.Text, ogrt4.Text, sinif4.Text, saat4.Text, gun4.Text);
            Ders ders5 = new Ders(txders5.Text, ogrt5.Text, sinif5.Text, saat5.Text, gun5.Text);


            // Dersleri bir liste içinde toplayalım
            List<Ders> dersler = new List<Ders>();
            dersler.Add(ders1);
            dersler.Add(ders2);
            dersler.Add(ders3);
            dersler.Add(ders4);
            dersler.Add(ders5);

            Graph graph= new Graph();

            // Dersleri çizgeye ekleme ve komşuluk ilişkilerini oluşturma
            foreach (Ders ders in dersler)
            {
                Node node = new Node(ders.DersAdi, ders.DersinOgretmeni, ders.DersinSinifi, ders.DersinSaati,ders.DersinGunu);
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
            listBox1.Items.Clear();
            listBox1.Items.Add(graph.Nodes[0].DersAdi);
            listBox1.Items.Add(graph.Nodes[1].DersAdi);
            listBox1.Items.Add(graph.Nodes[2].DersAdi);
            listBox1.Items.Add(graph.Nodes[3].DersAdi);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
