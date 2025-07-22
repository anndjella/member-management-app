using System.Windows.Forms;

namespace Klijent.UserKontrole
{
    partial class UCDodajDolazak
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbVrstaGrPr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCenaGrPr = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtMesec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGodina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDanOdlaska = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chBoxPlaceno = new System.Windows.Forms.CheckBox();
            this.btnSacuvajDolazak = new System.Windows.Forms.Button();
            this.lblPreostaliBrTer = new System.Windows.Forms.Label();
            this.btnViseDolazaka = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbVrstaGrPr
            // 
            this.cmbVrstaGrPr.FormattingEnabled = true;
            this.cmbVrstaGrPr.Location = new System.Drawing.Point(205, 50);
            this.cmbVrstaGrPr.Name = "cmbVrstaGrPr";
            this.cmbVrstaGrPr.Size = new System.Drawing.Size(205, 24);
            this.cmbVrstaGrPr.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type of group program:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price of group program:";
            // 
            // txtCenaGrPr
            // 
            this.txtCenaGrPr.Enabled = false;
            this.txtCenaGrPr.Location = new System.Drawing.Point(205, 110);
            this.txtCenaGrPr.Name = "txtCenaGrPr";
            this.txtCenaGrPr.ReadOnly = true;
            this.txtCenaGrPr.Size = new System.Drawing.Size(209, 22);
            this.txtCenaGrPr.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtMesec
            // 
            this.txtMesec.Enabled = false;
            this.txtMesec.Location = new System.Drawing.Point(489, 164);
            this.txtMesec.Name = "txtMesec";
            this.txtMesec.ReadOnly = true;
            this.txtMesec.Size = new System.Drawing.Size(110, 22);
            this.txtMesec.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Month:";
            // 
            // txtGodina
            // 
            this.txtGodina.Enabled = false;
            this.txtGodina.Location = new System.Drawing.Point(674, 164);
            this.txtGodina.Name = "txtGodina";
            this.txtGodina.ReadOnly = true;
            this.txtGodina.Size = new System.Drawing.Size(121, 22);
            this.txtGodina.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(605, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Year:";
            // 
            // txtDanOdlaska
            // 
            this.txtDanOdlaska.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDanOdlaska.Location = new System.Drawing.Point(205, 164);
            this.txtDanOdlaska.Name = "txtDanOdlaska";
            this.txtDanOdlaska.Size = new System.Drawing.Size(209, 22);
            this.txtDanOdlaska.TabIndex = 10;
            this.txtDanOdlaska.Text = "e.g.\"12\"";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Enter attendance day:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(443, 53);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 16);
            this.lbl.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Paid?";
            // 
            // chBoxPlaceno
            // 
            this.chBoxPlaceno.AutoSize = true;
            this.chBoxPlaceno.Location = new System.Drawing.Point(205, 224);
            this.chBoxPlaceno.Name = "chBoxPlaceno";
            this.chBoxPlaceno.Size = new System.Drawing.Size(51, 20);
            this.chBoxPlaceno.TabIndex = 13;
            this.chBoxPlaceno.Text = "yes";
            this.chBoxPlaceno.UseVisualStyleBackColor = true;
            // 
            // btnSacuvajDolazak
            // 
            this.btnSacuvajDolazak.Location = new System.Drawing.Point(112, 287);
            this.btnSacuvajDolazak.Name = "btnSacuvajDolazak";
            this.btnSacuvajDolazak.Size = new System.Drawing.Size(188, 61);
            this.btnSacuvajDolazak.TabIndex = 15;
            this.btnSacuvajDolazak.Text = "Save attendance";
            this.btnSacuvajDolazak.UseVisualStyleBackColor = true;
            // 
            // lblPreostaliBrTer
            // 
            this.lblPreostaliBrTer.AutoSize = true;
            this.lblPreostaliBrTer.Location = new System.Drawing.Point(589, 53);
            this.lblPreostaliBrTer.Name = "lblPreostaliBrTer";
            this.lblPreostaliBrTer.Size = new System.Drawing.Size(0, 16);
            this.lblPreostaliBrTer.TabIndex = 16;
            // 
            // btnViseDolazaka
            // 
            this.btnViseDolazaka.Location = new System.Drawing.Point(446, 50);
            this.btnViseDolazaka.Name = "btnViseDolazaka";
            this.btnViseDolazaka.Size = new System.Drawing.Size(188, 61);
            this.btnViseDolazaka.TabIndex = 17;
            this.btnViseDolazaka.Text = "Add multiple attendances";
            this.btnViseDolazaka.UseVisualStyleBackColor = true;
            // 
            // UCDodajDolazak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnViseDolazaka);
            this.Controls.Add(this.lblPreostaliBrTer);
            this.Controls.Add(this.btnSacuvajDolazak);
            this.Controls.Add(this.chBoxPlaceno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtDanOdlaska);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGodina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMesec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCenaGrPr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVrstaGrPr);
            this.Name = "UCDodajDolazak";
            this.Size = new System.Drawing.Size(994, 524);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVrstaGrPr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCenaGrPr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtMesec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGodina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDanOdlaska;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chBoxPlaceno;
        private System.Windows.Forms.Button btnSacuvajDolazak;
        private Label lblPreostaliBrTer;
        private Button btnViseDolazaka;

        public ComboBox  CmbGrPr{ get=>cmbVrstaGrPr; set=>cmbVrstaGrPr=value; }
        public Button  BtnSacuvajDolazak{ get=>btnSacuvajDolazak; set=> btnSacuvajDolazak = value; }
        public Button  BtnViseDolazaka{ get=>btnViseDolazaka; set=> btnViseDolazaka = value; }
        public TextBox  TxtCena{ get=>txtCenaGrPr; set=> txtCenaGrPr = value; }
        public TextBox  TxtMesec{ get=>txtMesec; set=> txtMesec = value; }
        public TextBox  TxtGodina{ get=>txtGodina; set=> txtGodina = value; }
        public TextBox  TxtDan{ get=>txtDanOdlaska; set=> txtDanOdlaska = value; }
        public CheckBox ChBPlaceno{ get=>chBoxPlaceno; set=> chBoxPlaceno = value; }
        public Label LblPreostaliBr{ get=>lbl; set=> lbl = value; }

    }
}
