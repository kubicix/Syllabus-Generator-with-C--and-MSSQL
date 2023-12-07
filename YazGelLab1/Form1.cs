using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazGelLab1
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public class DersSaatleri
        {
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = true;
            // DataGridView'e satırlar ekleme
            

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
