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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBoxMoviePoster = new System.Windows.Forms.PictureBox();
            this.labelMovieName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.dataGridViewProjections = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFreeSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.labelDescription.Size = new System.Drawing.Size(672, 217);
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
            this.dataGridViewProjections.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewProjections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProjections.ColumnHeadersHeight = 40;
            this.dataGridViewProjections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProjections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnTime,
            this.ColumnHall,
            this.ColumnFreeSeats});
            this.dataGridViewProjections.Location = new System.Drawing.Point(25, 309);
            this.dataGridViewProjections.MultiSelect = false;
            this.dataGridViewProjections.Name = "dataGridViewProjections";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProjections.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProjections.RowHeadersVisible = false;
            this.dataGridViewProjections.RowHeadersWidth = 51;
            this.dataGridViewProjections.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProjections.RowTemplate.Height = 24;
            this.dataGridViewProjections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjections.Size = new System.Drawing.Size(656, 343);
            this.dataGridViewProjections.TabIndex = 36;
            this.dataGridViewProjections.TabStop = false;
            this.dataGridViewProjections.SelectionChanged += new System.EventHandler(this.dataGridViewProjections_SelectionChanged);
            // 
            // ColumnDate
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.MinimumWidth = 6;
            this.ColumnDate.Name = "ColumnDate";
            // 
            // ColumnTime
            // 
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnTime.DefaultCellStyle = dataGridViewCellStyle2;
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
            // ColumnFreeSeats
            // 
            this.ColumnFreeSeats.HeaderText = "Free Seats";
            this.ColumnFreeSeats.MinimumWidth = 6;
            this.ColumnFreeSeats.Name = "ColumnFreeSeats";
            // 
            // FormOverviewProjections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1050, 680);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFreeSeats;
    }
}