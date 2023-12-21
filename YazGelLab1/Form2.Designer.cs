namespace YazGelLab1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.derstbGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sinif1 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.saat1 = new System.Windows.Forms.ComboBox();
            this.ders1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gun1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ogrt1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.id1 = new System.Windows.Forms.TextBox();
            this.idlbl = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.tabloBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.girdibtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.derstbGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // derstbGrid
            // 
            this.derstbGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.derstbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.derstbGrid.Location = new System.Drawing.Point(12, 12);
            this.derstbGrid.Name = "derstbGrid";
            this.derstbGrid.Size = new System.Drawing.Size(656, 426);
            this.derstbGrid.TabIndex = 1;
            this.derstbGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.derstbGrid_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.groupBox1.Controls.Add(this.girdibtn);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.id1);
            this.groupBox1.Controls.Add(this.idlbl);
            this.groupBox1.Controls.Add(this.sinif1);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.saat1);
            this.groupBox1.Controls.Add(this.ders1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.gun1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ogrt1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(674, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 294);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Düzenleme Paneli";
            // 
            // sinif1
            // 
            this.sinif1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sinif1.FormattingEnabled = true;
            this.sinif1.Items.AddRange(new object[] {
            "1033",
            "1036",
            "1040",
            "1041",
            "1044"});
            this.sinif1.Location = new System.Drawing.Point(66, 97);
            this.sinif1.Name = "sinif1";
            this.sinif1.Size = new System.Drawing.Size(100, 21);
            this.sinif1.TabIndex = 66;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label28.Location = new System.Drawing.Point(9, 97);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 20);
            this.label28.TabIndex = 61;
            this.label28.Text = "Sınıf:";
            // 
            // saat1
            // 
            this.saat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.saat1.FormattingEnabled = true;
            this.saat1.Items.AddRange(new object[] {
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00"});
            this.saat1.Location = new System.Drawing.Point(66, 124);
            this.saat1.Name = "saat1";
            this.saat1.Size = new System.Drawing.Size(100, 21);
            this.saat1.TabIndex = 56;
            // 
            // ders1
            // 
            this.ders1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ders1.Location = new System.Drawing.Point(66, 45);
            this.ders1.Name = "ders1";
            this.ders1.Size = new System.Drawing.Size(100, 20);
            this.ders1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(9, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ders:";
            // 
            // gun1
            // 
            this.gun1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gun1.FormattingEnabled = true;
            this.gun1.Items.AddRange(new object[] {
            "Pazartesi\t",
            "Sali\t",
            "Carsamba",
            "Persembe\t",
            "Cuma"});
            this.gun1.Location = new System.Drawing.Point(66, 151);
            this.gun1.Name = "gun1";
            this.gun1.Size = new System.Drawing.Size(100, 21);
            this.gun1.TabIndex = 23;
            this.gun1.Text = "Gün Seçiniz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(5, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Öğrt.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(13, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Gün:";
            // 
            // ogrt1
            // 
            this.ogrt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ogrt1.Location = new System.Drawing.Point(66, 71);
            this.ogrt1.Name = "ogrt1";
            this.ogrt1.Size = new System.Drawing.Size(100, 20);
            this.ogrt1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(7, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Saat:";
            // 
            // id1
            // 
            this.id1.Enabled = false;
            this.id1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.id1.Location = new System.Drawing.Point(66, 19);
            this.id1.Name = "id1";
            this.id1.Size = new System.Drawing.Size(100, 20);
            this.id1.TabIndex = 68;
            // 
            // idlbl
            // 
            this.idlbl.AutoSize = true;
            this.idlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.idlbl.Location = new System.Drawing.Point(26, 19);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(33, 20);
            this.idlbl.TabIndex = 67;
            this.idlbl.Text = "ID:";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.ForeColor = System.Drawing.Color.IndianRed;
            this.btnTemizle.Location = new System.Drawing.Point(11, 71);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(159, 50);
            this.btnTemizle.TabIndex = 70;
            this.btnTemizle.Text = "TABLO TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // tabloBtn
            // 
            this.tabloBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabloBtn.ForeColor = System.Drawing.Color.Black;
            this.tabloBtn.Location = new System.Drawing.Point(11, 19);
            this.tabloBtn.Name = "tabloBtn";
            this.tabloBtn.Size = new System.Drawing.Size(159, 50);
            this.tabloBtn.TabIndex = 69;
            this.tabloBtn.Text = "TABLO YENİLE";
            this.tabloBtn.UseVisualStyleBackColor = true;
            this.tabloBtn.Click += new System.EventHandler(this.tabloBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(11, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 30);
            this.button1.TabIndex = 71;
            this.button1.Text = "GÜNCELLE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(13, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 32);
            this.button2.TabIndex = 72;
            this.button2.Text = "DERSİ SİL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.tabloBtn);
            this.groupBox2.Controls.Add(this.btnTemizle);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(674, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 126);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tablo İşlem Paneli";
            // 
            // girdibtn
            // 
            this.girdibtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girdibtn.ForeColor = System.Drawing.Color.Navy;
            this.girdibtn.Location = new System.Drawing.Point(13, 252);
            this.girdibtn.Name = "girdibtn";
            this.girdibtn.Size = new System.Drawing.Size(157, 32);
            this.girdibtn.TabIndex = 73;
            this.girdibtn.Text = "GİRDİ EKLE";
            this.girdibtn.UseVisualStyleBackColor = true;
            this.girdibtn.Click += new System.EventHandler(this.girdibtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.derstbGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Admin Paneli";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.derstbGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView derstbGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox id1;
        private System.Windows.Forms.Label idlbl;
        private System.Windows.Forms.ComboBox sinif1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox saat1;
        private System.Windows.Forms.TextBox ders1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox gun1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ogrt1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button tabloBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button girdibtn;
    }
}