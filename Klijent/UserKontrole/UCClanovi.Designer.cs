using System.Windows.Forms;

namespace Klijent.UserKontrole
{
    partial class UCClanovi
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
            this.dgvClanovi = new System.Windows.Forms.DataGridView();
            this.btnDodajClana = new System.Windows.Forms.Button();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.txtUnosPrezimena = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnPretraga = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnObrisiClana = new System.Windows.Forms.Button();
            this.btnKreirajRacun = new System.Windows.Forms.Button();
            this.btnSviRacuni = new System.Windows.Forms.Button();
            this.btnKreirajDolazak = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanovi)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClanovi
            // 
            this.dgvClanovi.AllowUserToAddRows = false;
            this.dgvClanovi.AllowUserToDeleteRows = false;
            this.dgvClanovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClanovi.Location = new System.Drawing.Point(16, 23);
            this.dgvClanovi.MultiSelect = false;
            this.dgvClanovi.Name = "dgvClanovi";
            this.dgvClanovi.ReadOnly = true;
            this.dgvClanovi.RowHeadersWidth = 51;
            this.dgvClanovi.RowTemplate.Height = 24;
            this.dgvClanovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClanovi.Size = new System.Drawing.Size(765, 298);
            this.dgvClanovi.TabIndex = 0;
            // 
            // btnDodajClana
            // 
            this.btnDodajClana.Location = new System.Drawing.Point(1061, 202);
            this.btnDodajClana.Name = "btnDodajClana";
            this.btnDodajClana.Size = new System.Drawing.Size(147, 76);
            this.btnDodajClana.TabIndex = 1;
            this.btnDodajClana.Text = "Dodaj novog člana";
            this.btnDodajClana.UseVisualStyleBackColor = true;
            // 
            // btnDetalji
            // 
            this.btnDetalji.Location = new System.Drawing.Point(854, 202);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(147, 76);
            this.btnDetalji.TabIndex = 2;
            this.btnDetalji.Text = "Detalji o izabranom članu";
            this.btnDetalji.UseVisualStyleBackColor = true;
            // 
            // txtUnosPrezimena
            // 
            this.txtUnosPrezimena.Location = new System.Drawing.Point(12, 31);
            this.txtUnosPrezimena.Name = "txtUnosPrezimena";
            this.txtUnosPrezimena.Size = new System.Drawing.Size(313, 22);
            this.txtUnosPrezimena.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(12, 68);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(118, 53);
            this.btnPretraga.TabIndex = 5;
            this.btnPretraga.Text = "Pretraži";
            this.btnPretraga.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pretraga članova po prezimenu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPretraga);
            this.panel1.Controls.Add(this.txtUnosPrezimena);
            this.panel1.Location = new System.Drawing.Point(842, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 134);
            this.panel1.TabIndex = 7;
            // 
            // btnObrisiClana
            // 
            this.btnObrisiClana.Location = new System.Drawing.Point(1230, 23);
            this.btnObrisiClana.Name = "btnObrisiClana";
            this.btnObrisiClana.Size = new System.Drawing.Size(147, 76);
            this.btnObrisiClana.TabIndex = 8;
            this.btnObrisiClana.Text = "Obriši člana";
            this.btnObrisiClana.UseVisualStyleBackColor = true;
            // 
            // btnKreirajRacun
            // 
            this.btnKreirajRacun.Location = new System.Drawing.Point(485, 327);
            this.btnKreirajRacun.Name = "btnKreirajRacun";
            this.btnKreirajRacun.Size = new System.Drawing.Size(147, 76);
            this.btnKreirajRacun.TabIndex = 9;
            this.btnKreirajRacun.Text = "Kreiraj račun za izabranog člana";
            this.btnKreirajRacun.UseVisualStyleBackColor = true;
            // 
            // btnSviRacuni
            // 
            this.btnSviRacuni.Location = new System.Drawing.Point(243, 327);
            this.btnSviRacuni.Name = "btnSviRacuni";
            this.btnSviRacuni.Size = new System.Drawing.Size(147, 76);
            this.btnSviRacuni.TabIndex = 10;
            this.btnSviRacuni.Text = "Svi računi izabranog člana";
            this.btnSviRacuni.UseVisualStyleBackColor = true;
            // 
            // btnKreirajDolazak
            // 
            this.btnKreirajDolazak.Location = new System.Drawing.Point(16, 327);
            this.btnKreirajDolazak.Name = "btnKreirajDolazak";
            this.btnKreirajDolazak.Size = new System.Drawing.Size(147, 76);
            this.btnKreirajDolazak.TabIndex = 11;
            this.btnKreirajDolazak.Text = "Kreiraj odlazak za izabranog člana";
            this.btnKreirajDolazak.UseVisualStyleBackColor = true;
            // 
            // UCClanovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnKreirajDolazak);
            this.Controls.Add(this.btnSviRacuni);
            this.Controls.Add(this.btnKreirajRacun);
            this.Controls.Add(this.btnObrisiClana);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.btnDodajClana);
            this.Controls.Add(this.dgvClanovi);
            this.Name = "UCClanovi";
            this.Size = new System.Drawing.Size(1550, 605);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanovi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClanovi;
        private Button btnDodajClana;
        private Button btnDetalji;
        private TextBox txtUnosPrezimena;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnPretraga;
        private Label label1;
        private Panel panel1;
        private Button btnObrisiClana;
        private Button btnKreirajRacun;
        private Button btnSviRacuni;
        private Button btnKreirajDolazak;

        public DataGridView DgvClanovi { get => dgvClanovi; set => dgvClanovi = value; }
        public TextBox TxtUnos { get => txtUnosPrezimena; set => txtUnosPrezimena = value; }
        public Button BtnPretraga { get => btnPretraga; set => btnPretraga = value; }
        public Button BtnDetalji { get => btnDetalji; set => btnDetalji = value; }
        public Button BtnDodaj { get => btnDodajClana; set => btnDodajClana = value; }
        public Button BtnObrisi { get => btnObrisiClana; set => btnObrisiClana = value; }
        public Button BtnKreirajDolazak { get => btnKreirajDolazak; set => btnKreirajDolazak = value; }
        public Button BtnKreirajRacun { get => btnKreirajRacun; set => btnKreirajRacun = value; }
        public Button BtnSviRacuni { get => btnSviRacuni; set => btnSviRacuni = value; }
      //  public Button BtnKreirajDolazak { get => btn; set => btnKreirajDolazak = value; }


    }
}
