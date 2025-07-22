using System.Windows.Forms;

namespace Klijent.UserKontrole
{
    partial class UCRacun
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
            this.dgvOdlasci = new System.Windows.Forms.DataGridView();
            this.btnKreirajRacun = new System.Windows.Forms.Button();
            this.lblIme = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDetaljiORacunu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPretraga = new System.Windows.Forms.Label();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.txtUnos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdlasci)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOdlasci
            // 
            this.dgvOdlasci.AllowUserToAddRows = false;
            this.dgvOdlasci.AllowUserToDeleteRows = false;
            this.dgvOdlasci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdlasci.Location = new System.Drawing.Point(24, 64);
            this.dgvOdlasci.MultiSelect = false;
            this.dgvOdlasci.Name = "dgvOdlasci";
            this.dgvOdlasci.ReadOnly = true;
            this.dgvOdlasci.RowHeadersWidth = 51;
            this.dgvOdlasci.RowTemplate.Height = 24;
            this.dgvOdlasci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOdlasci.Size = new System.Drawing.Size(646, 332);
            this.dgvOdlasci.TabIndex = 0;
            this.dgvOdlasci.Visible = false;
            // 
            // btnKreirajRacun
            // 
            this.btnKreirajRacun.Location = new System.Drawing.Point(574, 3);
            this.btnKreirajRacun.Name = "btnKreirajRacun";
            this.btnKreirajRacun.Size = new System.Drawing.Size(172, 56);
            this.btnKreirajRacun.TabIndex = 1;
            this.btnKreirajRacun.Text = "Generate invoice";
            this.btnKreirajRacun.UseVisualStyleBackColor = true;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIme.Location = new System.Drawing.Point(24, 16);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(58, 22);
            this.lblIme.TabIndex = 2;
            this.lblIme.Text = "label1";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(850, 402);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(172, 56);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            // 
            // btnDetaljiORacunu
            // 
            this.btnDetaljiORacunu.Location = new System.Drawing.Point(28, 402);
            this.btnDetaljiORacunu.Name = "btnDetaljiORacunu";
            this.btnDetaljiORacunu.Size = new System.Drawing.Size(184, 64);
            this.btnDetaljiORacunu.TabIndex = 4;
            this.btnDetaljiORacunu.Text = "Show details of the selected invoice";
            this.btnDetaljiORacunu.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblPretraga);
            this.panel1.Controls.Add(this.btnPretraga);
            this.panel1.Controls.Add(this.txtUnos);
            this.panel1.Location = new System.Drawing.Point(218, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 64);
            this.panel1.TabIndex = 9;
            // 
            // lblPretraga
            // 
            this.lblPretraga.AutoSize = true;
            this.lblPretraga.Location = new System.Drawing.Point(9, 3);
            this.lblPretraga.Name = "lblPretraga";
            this.lblPretraga.Size = new System.Drawing.Size(163, 16);
            this.lblPretraga.TabIndex = 6;
            this.lblPretraga.Text = "Search invoices by month:";
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(356, 15);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(87, 41);
            this.btnPretraga.TabIndex = 5;
            this.btnPretraga.Text = "Search";
            this.btnPretraga.UseVisualStyleBackColor = true;
            // 
            // txtUnos
            // 
            this.txtUnos.BackColor = System.Drawing.SystemColors.Control;
            this.txtUnos.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtUnos.Location = new System.Drawing.Point(12, 31);
            this.txtUnos.Name = "txtUnos";
            this.txtUnos.Size = new System.Drawing.Size(313, 22);
            this.txtUnos.TabIndex = 3;
            this.txtUnos.Text = "e.g. \"July\"";
            // 
            // UCRacun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDetaljiORacunu);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.btnKreirajRacun);
            this.Controls.Add(this.dgvOdlasci);
            this.Name = "UCRacun";
            this.Size = new System.Drawing.Size(1132, 539);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdlasci)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOdlasci;
        private System.Windows.Forms.Button btnKreirajRacun;
        private System.Windows.Forms.Label lblIme;
        private Button btnOK;
        private Button btnDetaljiORacunu;
        private Panel panel1;
        private Label lblPretraga;
        private Button btnPretraga;
        private TextBox txtUnos;

        public Button BtnKreirajRacun { get=>btnKreirajRacun; set=>btnKreirajRacun=value; }
        public Button BtnOK { get=>btnOK; set=> btnOK = value; }
        public Button BtnDetaljiORacunu { get=>btnDetaljiORacunu; set=> btnDetaljiORacunu = value; }
        public Label LblIme { get=>lblIme; set=> lblIme = value; }
        public DataGridView DgvOdlasci { get=>dgvOdlasci; set=> dgvOdlasci = value; }
        public Panel Pnl { get=>panel1; set=> panel1 = value; }
        public Button BtnPretraga { get=>btnPretraga; set=> btnPretraga = value; }
        public TextBox TxtUnos { get=>txtUnos; set=> txtUnos = value; }
    }
}
