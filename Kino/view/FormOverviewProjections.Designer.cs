namespace Kino.view
{
    partial class FormOverviewProjections
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBoxMoviePoster = new System.Windows.Forms.PictureBox();
            this.labelMovieName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.dataGridViewProjections = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTakenSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFreeSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjections)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.ForeColor = System.Drawing.Color.LightCoral;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(979, 30);
            this.labelStatus.TabIndex = 32;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxMoviePoster
            // 
            this.pictureBoxMoviePoster.Location = new System.Drawing.Point(707, 33);
            this.pictureBoxMoviePoster.Name = "pictureBoxMoviePoster";
            this.pictureBoxMoviePoster.Size = new System.Drawing.Size(300, 410);
            this.pictureBoxMoviePoster.TabIndex = 33;
            this.pictureBoxMoviePoster.TabStop = false;
            // 
            // labelMovieName
            // 
            this.labelMovieName.BackColor = System.Drawing.Color.Transparent;
            this.labelMovieName.Font = new System.Drawing.Font("Berlin Sans FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovieName.ForeColor = System.Drawing.Color.White;
            this.labelMovieName.Location = new System.Drawing.Point(25, 33);
            this.labelMovieName.Name = "labelMovieName";
            this.labelMovieName.Size = new System.Drawing.Size(676, 47);
            this.labelMovieName.TabIndex = 34;
            this.labelMovieName.Text = "movie name";
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.White;
            this.labelDescription.Location = new System.Drawing.Point(25, 89);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(656, 168);
            this.labelDescription.TabIndex = 35;
            this.labelDescription.Text = "description";
            // 
            // dataGridViewProjections
            // 
            this.dataGridViewProjections.AllowUserToAddRows = false;
            this.dataGridViewProjections.AllowUserToDeleteRows = false;
            this.dataGridViewProjections.AllowUserToResizeColumns = false;
            this.dataGridViewProjections.AllowUserToResizeRows = false;
            this.dataGridViewProjections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProjections.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewProjections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProjections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProjections.ColumnHeadersHeight = 40;
            this.dataGridViewProjections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProjections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnTime,
            this.ColumnHall,
            this.ColumnTakenSeats,
            this.ColumnFreeSeats});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProjections.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProjections.EnableHeadersVisualStyles = false;
            this.dataGridViewProjections.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.dataGridViewProjections.Location = new System.Drawing.Point(25, 309);
            this.dataGridViewProjections.MultiSelect = false;
            this.dataGridViewProjections.Name = "dataGridViewProjections";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProjections.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewProjections.RowHeadersVisible = false;
            this.dataGridViewProjections.RowHeadersWidth = 51;
            this.dataGridViewProjections.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProjections.RowTemplate.Height = 40;
            this.dataGridViewProjections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjections.Size = new System.Drawing.Size(656, 343);
            this.dataGridViewProjections.TabIndex = 36;
            this.dataGridViewProjections.TabStop = false;
            this.dataGridViewProjections.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjections_CellClick);
            this.dataGridViewProjections.SelectionChanged += new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
            // 
            // ColumnDate
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.MinimumWidth = 6;
            this.ColumnDate.Name = "ColumnDate";
            // 
            // ColumnTime
            // 
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnTime.HeaderText = "Time";
            this.ColumnTime.MinimumWidth = 6;
            this.ColumnTime.Name = "ColumnTime";
            // 
            // ColumnHall
            // 
            this.ColumnHall.HeaderText = "Cinema Hall";
            this.ColumnHall.MinimumWidth = 6;
            this.ColumnHall.Name = "ColumnHall";
            // 
            // ColumnTakenSeats
            // 
            this.ColumnTakenSeats.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnTakenSeats.HeaderText = "Reserved Seats";
            this.ColumnTakenSeats.MinimumWidth = 6;
            this.ColumnTakenSeats.Name = "ColumnTakenSeats";
            this.ColumnTakenSeats.ReadOnly = true;
            this.ColumnTakenSeats.Width = 164;
            // 
            // ColumnFreeSeats
            // 
            this.ColumnFreeSeats.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnFreeSeats.HeaderText = "Free Seats";
            this.ColumnFreeSeats.MinimumWidth = 6;
            this.ColumnFreeSeats.Name = "ColumnFreeSeats";
            this.ColumnFreeSeats.Width = 125;
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(25, 274);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(228, 29);
            this.dateTimePickerDate.TabIndex = 37;
            this.dateTimePickerDate.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerDate.ValueChanged += new System.EventHandler(this.dateTimePickerDate_ValueChanged);
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilter.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilter.ForeColor = System.Drawing.Color.White;
            this.buttonFilter.Location = new System.Drawing.Point(259, 274);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(120, 29);
            this.buttonFilter.TabIndex = 38;
            this.buttonFilter.Text = "FILTER";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(385, 274);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 29);
            this.buttonClear.TabIndex = 39;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // FormOverviewProjections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.dataGridViewProjections);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelMovieName);
            this.Controls.Add(this.pictureBoxMoviePoster);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOverviewProjections";
            this.Text = "FormOverviewProjections";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.PictureBox pictureBoxMoviePoster;
        private System.Windows.Forms.Label labelMovieName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.DataGridView dataGridViewProjections;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHall;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTakenSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFreeSeats;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonClear;
    }
}