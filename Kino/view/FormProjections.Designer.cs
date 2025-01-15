namespace Kino.view
{
    partial class FormProjections
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.dataGridViewProjections = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MovieTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CinemaHall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelScreenTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjections)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(865, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROJECTIONS";
            this.label1.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStatus.ForeColor = System.Drawing.Color.LightCoral;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(1050, 38);
            this.labelStatus.TabIndex = 35;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewProjections
            // 
            this.dataGridViewProjections.AllowUserToAddRows = false;
            this.dataGridViewProjections.AllowUserToDeleteRows = false;
            this.dataGridViewProjections.AllowUserToResizeRows = false;
            this.dataGridViewProjections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProjections.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProjections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProjections.ColumnHeadersHeight = 40;
            this.dataGridViewProjections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProjections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.MovieTitle,
            this.PDate,
            this.PTime,
            this.CinemaHall,
            this.FreeSeats,
            this.Details});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Berlin Sans FB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProjections.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProjections.EnableHeadersVisualStyles = false;
            this.dataGridViewProjections.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.dataGridViewProjections.Location = new System.Drawing.Point(15, 63);
            this.dataGridViewProjections.Name = "dataGridViewProjections";
            this.dataGridViewProjections.RowHeadersVisible = false;
            this.dataGridViewProjections.RowHeadersWidth = 51;
            this.dataGridViewProjections.RowTemplate.Height = 40;
            this.dataGridViewProjections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjections.Size = new System.Drawing.Size(1023, 534);
            this.dataGridViewProjections.TabIndex = 36;
            this.dataGridViewProjections.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjections_CellClick);
            this.dataGridViewProjections.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjections_CellValueChanged);
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            // 
            // MovieTitle
            // 
            this.MovieTitle.HeaderText = "Movie title";
            this.MovieTitle.MinimumWidth = 6;
            this.MovieTitle.Name = "MovieTitle";
            this.MovieTitle.ReadOnly = true;
            // 
            // PDate
            // 
            this.PDate.HeaderText = "Date";
            this.PDate.MinimumWidth = 6;
            this.PDate.Name = "PDate";
            this.PDate.ReadOnly = true;
            // 
            // PTime
            // 
            this.PTime.HeaderText = "Time";
            this.PTime.MinimumWidth = 6;
            this.PTime.Name = "PTime";
            this.PTime.ReadOnly = true;
            // 
            // CinemaHall
            // 
            this.CinemaHall.HeaderText = "Cinema hall";
            this.CinemaHall.MinimumWidth = 6;
            this.CinemaHall.Name = "CinemaHall";
            this.CinemaHall.ReadOnly = true;
            // 
            // FreeSeats
            // 
            this.FreeSeats.HeaderText = "Free Seats";
            this.FreeSeats.MinimumWidth = 6;
            this.FreeSeats.Name = "FreeSeats";
            // 
            // Details
            // 
            this.Details.HeaderText = "Details";
            this.Details.MinimumWidth = 6;
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Berlin Sans FB Demi", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(15, 620);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(171, 34);
            this.buttonDelete.TabIndex = 37;
            this.buttonDelete.Text = "DELETE SELECTED";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelScreenTitle
            // 
            this.labelScreenTitle.AutoSize = true;
            this.labelScreenTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelScreenTitle.Font = new System.Drawing.Font("Berlin Sans FB Demi", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScreenTitle.ForeColor = System.Drawing.Color.White;
            this.labelScreenTitle.Location = new System.Drawing.Point(15, 22);
            this.labelScreenTitle.Name = "labelScreenTitle";
            this.labelScreenTitle.Size = new System.Drawing.Size(160, 27);
            this.labelScreenTitle.TabIndex = 38;
            this.labelScreenTitle.Text = "All projections";
            // 
            // FormProjections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.labelScreenTitle);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewProjections);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProjections";
            this.Text = "FormProjections";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.DataGridView dataGridViewProjections;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovieTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CinemaHall;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeSeats;
        private System.Windows.Forms.DataGridViewButtonColumn Details;
        private System.Windows.Forms.Label labelScreenTitle;
    }
}