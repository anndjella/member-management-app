namespace SERVER
{
    partial class FrmServer
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
            this.btnPokreniServer = new System.Windows.Forms.Button();
            this.btnZaustaviServer = new System.Windows.Forms.Button();
            this.lblStatusServera = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPokreniServer
            // 
            this.btnPokreniServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPokreniServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPokreniServer.Location = new System.Drawing.Point(52, 47);
            this.btnPokreniServer.Name = "btnPokreniServer";
            this.btnPokreniServer.Size = new System.Drawing.Size(115, 74);
            this.btnPokreniServer.TabIndex = 0;
            this.btnPokreniServer.Text = "Pokreni server";
            this.btnPokreniServer.UseVisualStyleBackColor = true;
            this.btnPokreniServer.Click += new System.EventHandler(this.btnPokreniServer_Click);
            // 
            // btnZaustaviServer
            // 
            this.btnZaustaviServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZaustaviServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaustaviServer.Location = new System.Drawing.Point(52, 180);
            this.btnZaustaviServer.Name = "btnZaustaviServer";
            this.btnZaustaviServer.Size = new System.Drawing.Size(115, 74);
            this.btnZaustaviServer.TabIndex = 1;
            this.btnZaustaviServer.Text = "Zaustavi server";
            this.btnZaustaviServer.UseVisualStyleBackColor = true;
            this.btnZaustaviServer.Visible = false;
            this.btnZaustaviServer.Click += new System.EventHandler(this.btnZaustaviServer_Click);
            // 
            // lblStatusServera
            // 
            this.lblStatusServera.AutoSize = true;
            this.lblStatusServera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusServera.ForeColor = System.Drawing.Color.Red;
            this.lblStatusServera.Location = new System.Drawing.Point(261, 135);
            this.lblStatusServera.Name = "lblStatusServera";
            this.lblStatusServera.Size = new System.Drawing.Size(160, 25);
            this.lblStatusServera.TabIndex = 2;
            this.lblStatusServera.Text = "Server je ugašen";
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(468, 327);
            this.Controls.Add(this.lblStatusServera);
            this.Controls.Add(this.btnZaustaviServer);
            this.Controls.Add(this.btnPokreniServer);
            this.Name = "FrmServer";
            this.Text = "SERVER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPokreniServer;
        private System.Windows.Forms.Button btnZaustaviServer;
        private System.Windows.Forms.Label lblStatusServera;
    }
}