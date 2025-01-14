namespace Kino.view
{
    partial class FormHallSeats
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
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelSelectedSeats = new System.Windows.Forms.Label();
            this.buttonReserve = new System.Windows.Forms.Button();
            this.labelProjectionDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.ForeColor = System.Drawing.Color.LightCoral;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(983, 30);
            this.labelStatus.TabIndex = 33;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSelectedSeats
            // 
            this.labelSelectedSeats.AutoSize = true;
            this.labelSelectedSeats.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectedSeats.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedSeats.ForeColor = System.Drawing.Color.White;
            this.labelSelectedSeats.Location = new System.Drawing.Point(770, 250);
            this.labelSelectedSeats.Name = "labelSelectedSeats";
            this.labelSelectedSeats.Size = new System.Drawing.Size(0, 23);
            this.labelSelectedSeats.TabIndex = 35;
            this.labelSelectedSeats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonReserve
            // 
            this.buttonReserve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonReserve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReserve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReserve.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReserve.ForeColor = System.Drawing.Color.White;
            this.buttonReserve.Location = new System.Drawing.Point(770, 567);
            this.buttonReserve.Name = "buttonReserve";
            this.buttonReserve.Size = new System.Drawing.Size(216, 35);
            this.buttonReserve.TabIndex = 36;
            this.buttonReserve.Text = "RESERVE";
            this.buttonReserve.UseVisualStyleBackColor = false;
            this.buttonReserve.Click += new System.EventHandler(this.buttonReserve_Click);
            // 
            // labelProjectionDetails
            // 
            this.labelProjectionDetails.AutoSize = true;
            this.labelProjectionDetails.BackColor = System.Drawing.Color.Transparent;
            this.labelProjectionDetails.Font = new System.Drawing.Font("Berlin Sans FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectionDetails.ForeColor = System.Drawing.Color.White;
            this.labelProjectionDetails.Location = new System.Drawing.Point(770, 100);
            this.labelProjectionDetails.Name = "labelProjectionDetails";
            this.labelProjectionDetails.Size = new System.Drawing.Size(179, 26);
            this.labelProjectionDetails.TabIndex = 37;
            this.labelProjectionDetails.Text = "Projection Details";
            // 
            // FormHallSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.labelProjectionDetails);
            this.Controls.Add(this.buttonReserve);
            this.Controls.Add(this.labelSelectedSeats);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHallSeats";
            this.Text = "FormHallSeats";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelSelectedSeats;
        private System.Windows.Forms.Button buttonReserve;
        private System.Windows.Forms.Label labelProjectionDetails;
    }
}