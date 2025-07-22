using System.Windows.Controls;
using System.Windows.Forms;

namespace Klijent.UserKontrole
{
    partial class UCDetaljiRacuna
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblIznos = new System.Windows.Forms.Label();
            this.lblKrajnjiIznos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPretraga = new System.Windows.Forms.Label();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.txtUnos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 65);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1209, 232);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblIznos
            // 
            this.lblIznos.AutoSize = true;
            this.lblIznos.Location = new System.Drawing.Point(3, 310);
            this.lblIznos.Name = "lblIznos";
            this.lblIznos.Size = new System.Drawing.Size(134, 16);
            this.lblIznos.TabIndex = 1;
            this.lblIznos.Text = "Total invoice amount:";
            this.lblIznos.Visible = false;
            // 
            // lblKrajnjiIznos
            // 
            this.lblKrajnjiIznos.AutoSize = true;
            this.lblKrajnjiIznos.Location = new System.Drawing.Point(3, 359);
            this.lblKrajnjiIznos.Name = "lblKrajnjiIznos";
            this.lblKrajnjiIznos.Size = new System.Drawing.Size(259, 16);
            this.lblKrajnjiIznos.TabIndex = 2;
            this.lblKrajnjiIznos.Text = "Final invoice amount with applied discount:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblPretraga);
            this.panel1.Controls.Add(this.btnPretraga);
            this.panel1.Controls.Add(this.txtUnos);
            this.panel1.Location = new System.Drawing.Point(870, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 134);
            this.panel1.TabIndex = 8;
            // 
            // lblPretraga
            // 
            this.lblPretraga.AutoSize = true;
            this.lblPretraga.Location = new System.Drawing.Point(9, 3);
            this.lblPretraga.Name = "lblPretraga";
            this.lblPretraga.Size = new System.Drawing.Size(174, 16);
            this.lblPretraga.TabIndex = 6;
            this.lblPretraga.Text = "Search attendances by day:";
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(12, 68);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(118, 53);
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
            this.txtUnos.Text = "e.g.\"3\"";
            // 
            // UCDetaljiRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblKrajnjiIznos);
            this.Controls.Add(this.lblIznos);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UCDetaljiRacuna";
            this.Size = new System.Drawing.Size(1234, 554);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblIznos;
        private System.Windows.Forms.Label lblKrajnjiIznos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPretraga;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.TextBox txtUnos;

        public DataGridView DgvDolasci { get=>dataGridView1; set=> dataGridView1=value; }
        public System.Windows.Forms.Label LblIznos { get=>lblIznos; set=> lblIznos = value; }
        public System.Windows.Forms.Label LblKonacniIznos { get=>lblKrajnjiIznos; set=> lblKrajnjiIznos = value; }
        public System.Windows.Forms.Button BtnPretrazi { get=>btnPretraga; set=> btnPretraga = value; }
        public System.Windows.Forms.TextBox TxtUnos { get=>txtUnos; set=> txtUnos = value; }
    }
}
