namespace Arac_Kiralama_Otomasyonu
{
    partial class giris
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
            this.tbK_adi = new System.Windows.Forms.TextBox();
            this.tbParola = new System.Windows.Forms.TextBox();
            this.lblK_adi = new System.Windows.Forms.Label();
            this.lblParola = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbK_adi
            // 
            this.tbK_adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbK_adi.Location = new System.Drawing.Point(202, 27);
            this.tbK_adi.Name = "tbK_adi";
            this.tbK_adi.Size = new System.Drawing.Size(167, 30);
            this.tbK_adi.TabIndex = 0;
            // 
            // tbParola
            // 
            this.tbParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbParola.Location = new System.Drawing.Point(202, 83);
            this.tbParola.Name = "tbParola";
            this.tbParola.PasswordChar = '*';
            this.tbParola.Size = new System.Drawing.Size(167, 30);
            this.tbParola.TabIndex = 1;
            // 
            // lblK_adi
            // 
            this.lblK_adi.AutoSize = true;
            this.lblK_adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblK_adi.Location = new System.Drawing.Point(28, 27);
            this.lblK_adi.Name = "lblK_adi";
            this.lblK_adi.Size = new System.Drawing.Size(151, 25);
            this.lblK_adi.TabIndex = 2;
            this.lblK_adi.Text = "Kullanıcı Adı : ";
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblParola.Location = new System.Drawing.Point(86, 86);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(93, 25);
            this.lblParola.TabIndex = 3;
            this.lblParola.Text = "Parola : ";
            // 
            // btnGiris
            // 
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Location = new System.Drawing.Point(202, 141);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(167, 34);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 235);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.lblParola);
            this.Controls.Add(this.lblK_adi);
            this.Controls.Add(this.tbParola);
            this.Controls.Add(this.tbK_adi);
            this.Name = "giris";
            this.Text = "KULLANCI GİRİŞ";
            this.Load += new System.EventHandler(this.giris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbK_adi;
        private System.Windows.Forms.TextBox tbParola;
        private System.Windows.Forms.Label lblK_adi;
        private System.Windows.Forms.Label lblParola;
        private System.Windows.Forms.Button btnGiris;
    }
}

