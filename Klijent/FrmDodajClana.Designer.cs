using System.Windows.Forms;

namespace Klijent
{
    partial class FrmDodajClana
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
            this.btnDodajClana = new System.Windows.Forms.Button();
            this.cmbKateg = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBrTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSacuvajIzmene = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDodajClana
            // 
            this.btnDodajClana.Location = new System.Drawing.Point(138, 359);
            this.btnDodajClana.Name = "btnDodajClana";
            this.btnDodajClana.Size = new System.Drawing.Size(134, 47);
            this.btnDodajClana.TabIndex = 21;
            this.btnDodajClana.Text = "Add member";
            this.btnDodajClana.UseVisualStyleBackColor = true;
            // 
            // cmbKateg
            // 
            this.cmbKateg.FormattingEnabled = true;
            this.cmbKateg.Location = new System.Drawing.Point(243, 268);
            this.cmbKateg.Name = "cmbKateg";
            this.cmbKateg.Size = new System.Drawing.Size(248, 24);
            this.cmbKateg.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Category:";
            // 
            // txtBrTel
            // 
            this.txtBrTel.ForeColor = System.Drawing.Color.Gray;
            this.txtBrTel.Location = new System.Drawing.Point(157, 198);
            this.txtBrTel.Name = "txtBrTel";
            this.txtBrTel.Size = new System.Drawing.Size(248, 22);
            this.txtBrTel.TabIndex = 18;
            this.txtBrTel.Text = "npr. 069 4000 122";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(157, 131);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(248, 22);
            this.txtEmail.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email:";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(157, 75);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(248, 22);
            this.txtPrezime.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Surname:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(157, 23);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(248, 22);
            this.txtIme.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // btnSacuvajIzmene
            // 
            this.btnSacuvajIzmene.Location = new System.Drawing.Point(138, 359);
            this.btnSacuvajIzmene.Name = "btnSacuvajIzmene";
            this.btnSacuvajIzmene.Size = new System.Drawing.Size(134, 47);
            this.btnSacuvajIzmene.TabIndex = 22;
            this.btnSacuvajIzmene.Text = "Save changes";
            this.btnSacuvajIzmene.UseVisualStyleBackColor = true;
            this.btnSacuvajIzmene.Visible = false;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(138, 359);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(134, 47);
            this.btnObrisi.TabIndex = 23;
            this.btnObrisi.Text = "Delete member";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Visible = false;
            // 
            // FrmDodajClana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 458);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnSacuvajIzmene);
            this.Controls.Add(this.btnDodajClana);
            this.Controls.Add(this.cmbKateg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBrTel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label1);
            this.Name = "FrmDodajClana";
            this.Text = "Add member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodajClana;
        private System.Windows.Forms.ComboBox cmbKateg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBrTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label1;
        private Button btnSacuvajIzmene;
        private Button btnObrisi;

        public TextBox TxtIme { get => txtIme;set => txtIme = value; }  
        public TextBox TxtPrezime { get => txtPrezime;set => txtPrezime = value; }  
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }  
        public TextBox TxtBrTel { get => txtBrTel; set => txtBrTel = value; }  
        public ComboBox CmbKateg { get => cmbKateg;set => cmbKateg = value; }  
        public Button BtnDodajClana { get => btnDodajClana;set => btnDodajClana = value; }
        public Button BtnSacuvajIzmene { get => btnSacuvajIzmene;set => btnSacuvajIzmene = value; }
        public Button BtnObrisi { get => btnObrisi;set => btnObrisi = value; }
    }
}