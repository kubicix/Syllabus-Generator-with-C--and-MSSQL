namespace YazGelLab1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pzt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pzt,
            this.Sali,
            this.Crs,
            this.Pers,
            this.Cuma});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1197, 236);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Pzt
            // 
            this.Pzt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pzt.HeaderText = "Pazartesi";
            this.Pzt.Name = "Pzt";
            // 
            // Sali
            // 
            this.Sali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sali.HeaderText = "Salı";
            this.Sali.Name = "Sali";
            // 
            // Crs
            // 
            this.Crs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Crs.HeaderText = "Çarşamba";
            this.Crs.Name = "Crs";
            // 
            // Pers
            // 
            this.Pers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pers.HeaderText = "Perşembe";
            this.Pers.Name = "Pers";
            // 
            // Cuma
            // 
            this.Cuma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cuma.HeaderText = "Cuma";
            this.Cuma.Name = "Cuma";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 504);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pzt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sali;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuma;
    }
}

