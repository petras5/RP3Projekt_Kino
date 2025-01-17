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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelStatus = new System.Windows.Forms.Label();
            this.dataGridViewProjections = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MovieTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CinemaHall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservedSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelScreenTitle = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxHallFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjections)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewProjections.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewProjections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProjections.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProjections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewProjections.ColumnHeadersHeight = 40;
            this.dataGridViewProjections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProjections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.MovieTitle,
            this.PDate,
            this.PTime,
            this.CinemaHall,
            this.ReservedSeats,
            this.FreeSeats,
            this.Details});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProjections.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewProjections.EnableHeadersVisualStyles = false;
            this.dataGridViewProjections.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.dataGridViewProjections.Location = new System.Drawing.Point(15, 81);
            this.dataGridViewProjections.Name = "dataGridViewProjections";
            this.dataGridViewProjections.RowHeadersVisible = false;
            this.dataGridViewProjections.RowHeadersWidth = 51;
            this.dataGridViewProjections.RowTemplate.Height = 40;
            this.dataGridViewProjections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjections.Size = new System.Drawing.Size(1023, 516);
            this.dataGridViewProjections.TabIndex = 36;
            this.dataGridViewProjections.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjections_CellClick);
            this.dataGridViewProjections.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjections_CellValueChanged);
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FillWeight = 187.1658F;
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Width = 71;
            // 
            // MovieTitle
            // 
            this.MovieTitle.FillWeight = 85.47237F;
            this.MovieTitle.HeaderText = "Movie title";
            this.MovieTitle.MinimumWidth = 6;
            this.MovieTitle.Name = "MovieTitle";
            this.MovieTitle.ReadOnly = true;
            // 
            // PDate
            // 
            this.PDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PDate.FillWeight = 67.47818F;
            this.PDate.HeaderText = "Date";
            this.PDate.MinimumWidth = 6;
            this.PDate.Name = "PDate";
            this.PDate.ReadOnly = true;
            this.PDate.Width = 81;
            // 
            // PTime
            // 
            this.PTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PTime.FillWeight = 67.47818F;
            this.PTime.HeaderText = "Time";
            this.PTime.MinimumWidth = 6;
            this.PTime.Name = "PTime";
            this.PTime.ReadOnly = true;
            this.PTime.Width = 79;
            // 
            // CinemaHall
            // 
            this.CinemaHall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CinemaHall.FillWeight = 67.47818F;
            this.CinemaHall.HeaderText = "Cinema hall";
            this.CinemaHall.MinimumWidth = 6;
            this.CinemaHall.Name = "CinemaHall";
            this.CinemaHall.ReadOnly = true;
            this.CinemaHall.Width = 136;
            // 
            // ReservedSeats
            // 
            this.ReservedSeats.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ReservedSeats.HeaderText = "Reserved Seats";
            this.ReservedSeats.MinimumWidth = 6;
            this.ReservedSeats.Name = "ReservedSeats";
            this.ReservedSeats.ReadOnly = true;
            this.ReservedSeats.Width = 164;
            // 
            // FreeSeats
            // 
            this.FreeSeats.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FreeSeats.FillWeight = 67.47818F;
            this.FreeSeats.HeaderText = "Free Seats";
            this.FreeSeats.MinimumWidth = 6;
            this.FreeSeats.Name = "FreeSeats";
            this.FreeSeats.Width = 125;
            // 
            // Details
            // 
            this.Details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Details.FillWeight = 157.4491F;
            this.Details.HeaderText = "Details";
            this.Details.MinimumWidth = 6;
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            this.Details.Width = 72;
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
            this.labelScreenTitle.Location = new System.Drawing.Point(15, 38);
            this.labelScreenTitle.Name = "labelScreenTitle";
            this.labelScreenTitle.Size = new System.Drawing.Size(160, 27);
            this.labelScreenTitle.TabIndex = 38;
            this.labelScreenTitle.Text = "All projections";
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(918, 36);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 29);
            this.buttonClear.TabIndex = 42;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilter.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilter.ForeColor = System.Drawing.Color.White;
            this.buttonFilter.Location = new System.Drawing.Point(792, 36);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(120, 29);
            this.buttonFilter.TabIndex = 41;
            this.buttonFilter.Text = "FILTER";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.CustomFormat = "";
            this.dateTimePickerDate.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(355, 36);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(228, 29);
            this.dateTimePickerDate.TabIndex = 40;
            this.dateTimePickerDate.Value = new System.DateTime(2025, 1, 17, 0, 0, 0, 0);
            this.dateTimePickerDate.ValueChanged += new System.EventHandler(this.dateTimePickerDate_ValueChanged);
            // 
            // comboBoxHallFilter
            // 
            this.comboBoxHallFilter.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHallFilter.FormattingEnabled = true;
            this.comboBoxHallFilter.Location = new System.Drawing.Point(665, 36);
            this.comboBoxHallFilter.Name = "comboBoxHallFilter";
            this.comboBoxHallFilter.Size = new System.Drawing.Size(121, 29);
            this.comboBoxHallFilter.TabIndex = 43;
            this.comboBoxHallFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxHallFilter_SelectedIndexChanged);
            this.comboBoxHallFilter.SelectedValueChanged += new System.EventHandler(this.comboBoxHallFilter_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(598, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 27);
            this.label1.TabIndex = 44;
            this.label1.Text = "Hall:";
            // 
            // FormProjections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxHallFilter);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.labelScreenTitle);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewProjections);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProjections";
            this.Text = "FormProjections";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.DataGridView dataGridViewProjections;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelScreenTitle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovieTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CinemaHall;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservedSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeSeats;
        private System.Windows.Forms.DataGridViewButtonColumn Details;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.ComboBox comboBoxHallFilter;
        private System.Windows.Forms.Label label1;
    }
}