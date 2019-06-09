namespace Arac_Kiralama_Otomasyonu
{
    partial class AracGuncelle
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sigortayok = new System.Windows.Forms.RadioButton();
            this.sigortavar = new System.Windows.Forms.RadioButton();
            this.vites = new System.Windows.Forms.ComboBox();
            this.yakit = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.klimayok = new System.Windows.Forms.RadioButton();
            this.klimavar = new System.Windows.Forms.RadioButton();
            this.renk = new System.Windows.Forms.TextBox();
            this.motorhacim = new System.Windows.Forms.TextBox();
            this.model = new System.Windows.Forms.TextBox();
            this.motorguc = new System.Windows.Forms.TextBox();
            this.marka = new System.Windows.Forms.TextBox();
            this.ucret = new System.Windows.Forms.TextBox();
            this.tork = new System.Windows.Forms.TextBox();
            this.ruhsat = new System.Windows.Forms.TextBox();
            this.plaka = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.muayene = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(213, 688);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 32);
            this.button1.TabIndex = 40;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sigortayok);
            this.groupBox2.Controls.Add(this.sigortavar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(213, 522);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(200, 59);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // sigortayok
            // 
            this.sigortayok.AutoSize = true;
            this.sigortayok.Location = new System.Drawing.Point(112, 23);
            this.sigortayok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sigortayok.Name = "sigortayok";
            this.sigortayok.Size = new System.Drawing.Size(53, 21);
            this.sigortayok.TabIndex = 4;
            this.sigortayok.TabStop = true;
            this.sigortayok.Text = "Yok";
            this.sigortayok.UseVisualStyleBackColor = true;
            // 
            // sigortavar
            // 
            this.sigortavar.AutoSize = true;
            this.sigortavar.Location = new System.Drawing.Point(11, 21);
            this.sigortavar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sigortavar.Name = "sigortavar";
            this.sigortavar.Size = new System.Drawing.Size(51, 21);
            this.sigortavar.TabIndex = 3;
            this.sigortavar.TabStop = true;
            this.sigortavar.Text = "Var";
            this.sigortavar.UseVisualStyleBackColor = true;
            // 
            // vites
            // 
            this.vites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.vites.FormattingEnabled = true;
            this.vites.Items.AddRange(new object[] {
            "OTOMATIK",
            "MANUEL"});
            this.vites.Location = new System.Drawing.Point(213, 425);
            this.vites.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vites.Name = "vites";
            this.vites.Size = new System.Drawing.Size(211, 25);
            this.vites.TabIndex = 37;
            // 
            // yakit
            // 
            this.yakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.yakit.FormattingEnabled = true;
            this.yakit.Items.AddRange(new object[] {
            "LPG",
            "MAZOT",
            "BENZIN"});
            this.yakit.Location = new System.Drawing.Point(213, 375);
            this.yakit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yakit.Name = "yakit";
            this.yakit.Size = new System.Drawing.Size(211, 25);
            this.yakit.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.klimayok);
            this.groupBox1.Controls.Add(this.klimavar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(213, 298);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(200, 57);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // klimayok
            // 
            this.klimayok.AutoSize = true;
            this.klimayok.Location = new System.Drawing.Point(117, 21);
            this.klimayok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.klimayok.Name = "klimayok";
            this.klimayok.Size = new System.Drawing.Size(53, 21);
            this.klimayok.TabIndex = 4;
            this.klimayok.TabStop = true;
            this.klimayok.Text = "Yok";
            this.klimayok.UseVisualStyleBackColor = true;
            // 
            // klimavar
            // 
            this.klimavar.AutoSize = true;
            this.klimavar.Location = new System.Drawing.Point(11, 21);
            this.klimavar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.klimavar.Name = "klimavar";
            this.klimavar.Size = new System.Drawing.Size(51, 21);
            this.klimavar.TabIndex = 3;
            this.klimavar.TabStop = true;
            this.klimavar.Text = "Var";
            this.klimavar.UseVisualStyleBackColor = true;
            // 
            // renk
            // 
            this.renk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.renk.Location = new System.Drawing.Point(213, 263);
            this.renk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.renk.MaxLength = 20;
            this.renk.Name = "renk";
            this.renk.Size = new System.Drawing.Size(211, 23);
            this.renk.TabIndex = 34;
            // 
            // motorhacim
            // 
            this.motorhacim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.motorhacim.Location = new System.Drawing.Point(213, 222);
            this.motorhacim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.motorhacim.Name = "motorhacim";
            this.motorhacim.Size = new System.Drawing.Size(211, 23);
            this.motorhacim.TabIndex = 32;
            // 
            // model
            // 
            this.model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.model.Location = new System.Drawing.Point(213, 98);
            this.model.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.model.MaxLength = 15;
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(211, 23);
            this.model.TabIndex = 31;
            // 
            // motorguc
            // 
            this.motorguc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.motorguc.Location = new System.Drawing.Point(213, 181);
            this.motorguc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.motorguc.Name = "motorguc";
            this.motorguc.Size = new System.Drawing.Size(211, 23);
            this.motorguc.TabIndex = 30;
            // 
            // marka
            // 
            this.marka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.marka.Location = new System.Drawing.Point(213, 52);
            this.marka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.marka.MaxLength = 15;
            this.marka.Name = "marka";
            this.marka.Size = new System.Drawing.Size(211, 23);
            this.marka.TabIndex = 29;
            // 
            // ucret
            // 
            this.ucret.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ucret.Location = new System.Drawing.Point(213, 645);
            this.ucret.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucret.Name = "ucret";
            this.ucret.Size = new System.Drawing.Size(211, 23);
            this.ucret.TabIndex = 28;
            // 
            // tork
            // 
            this.tork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tork.Location = new System.Drawing.Point(213, 598);
            this.tork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tork.Name = "tork";
            this.tork.Size = new System.Drawing.Size(211, 23);
            this.tork.TabIndex = 27;
            // 
            // ruhsat
            // 
            this.ruhsat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ruhsat.Location = new System.Drawing.Point(213, 138);
            this.ruhsat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ruhsat.Name = "ruhsat";
            this.ruhsat.Size = new System.Drawing.Size(211, 23);
            this.ruhsat.TabIndex = 33;
            // 
            // plaka
            // 
            this.plaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.plaka.Location = new System.Drawing.Point(213, 9);
            this.plaka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plaka.MaxLength = 9;
            this.plaka.Name = "plaka";
            this.plaka.Size = new System.Drawing.Size(211, 23);
            this.plaka.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(136, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Plaka";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(95, 428);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Vites Türü";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(96, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Yakıt Türü";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.Location = new System.Drawing.Point(56, 545);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "Trafik Sigortası";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(140, 263);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Renk";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(95, 138);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Ruhsat No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(145, 598);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tork";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.Location = new System.Drawing.Point(140, 647);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "Ücret";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.Location = new System.Drawing.Point(13, 480);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 17);
            this.label13.TabIndex = 16;
            this.label13.Text = "Muayene Bitiş Tarih";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(76, 222);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Motor Hacmi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(84, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Motor Gücü";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(131, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Marka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(131, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(137, 321);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Klima";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 17);
            this.label15.TabIndex = 41;
            // 
            // muayene
            // 
            this.muayene.Location = new System.Drawing.Point(213, 480);
            this.muayene.Name = "muayene";
            this.muayene.Size = new System.Drawing.Size(200, 22);
            this.muayene.TabIndex = 42;
            // 
            // AracGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 741);
            this.Controls.Add(this.muayene);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.vites);
            this.Controls.Add(this.yakit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.renk);
            this.Controls.Add(this.motorhacim);
            this.Controls.Add(this.model);
            this.Controls.Add(this.motorguc);
            this.Controls.Add(this.marka);
            this.Controls.Add(this.ucret);
            this.Controls.Add(this.tork);
            this.Controls.Add(this.ruhsat);
            this.Controls.Add(this.plaka);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AracGuncelle";
            this.Text = "AracGüncelle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AracGuncelle_FormClosed);
            this.Load += new System.EventHandler(this.AracGuncelle_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton sigortayok;
        public System.Windows.Forms.RadioButton sigortavar;
        public System.Windows.Forms.ComboBox vites;
        public System.Windows.Forms.ComboBox yakit;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton klimayok;
        public System.Windows.Forms.RadioButton klimavar;
        public System.Windows.Forms.TextBox renk;
        public System.Windows.Forms.TextBox motorhacim;
        public System.Windows.Forms.TextBox model;
        public System.Windows.Forms.TextBox motorguc;
        public System.Windows.Forms.TextBox marka;
        public System.Windows.Forms.TextBox ucret;
        public System.Windows.Forms.TextBox tork;
        public System.Windows.Forms.TextBox ruhsat;
        public System.Windows.Forms.TextBox plaka;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.DateTimePicker muayene;
    }
}