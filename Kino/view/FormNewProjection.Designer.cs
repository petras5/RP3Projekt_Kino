namespace Kino.view
{
    partial class FormNewProjection
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.comboBoxMovies = new System.Windows.Forms.ComboBox();
            this.labelHall = new System.Windows.Forms.Label();
            this.comboBoxHalls = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.monthCalendarDate = new System.Windows.Forms.MonthCalendar();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelScreenTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(827, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NEW PROJECTION";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStatus.ForeColor = System.Drawing.Color.LightCoral;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(1032, 38);
            this.labelStatus.TabIndex = 34;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(73, 89);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(97, 23);
            this.labelTitle.TabIndex = 35;
            this.labelTitle.Text = "Movie title";
            // 
            // comboBoxMovies
            // 
            this.comboBoxMovies.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMovies.FormattingEnabled = true;
            this.comboBoxMovies.Location = new System.Drawing.Point(312, 84);
            this.comboBoxMovies.Name = "comboBoxMovies";
            this.comboBoxMovies.Size = new System.Drawing.Size(329, 28);
            this.comboBoxMovies.TabIndex = 36;
            this.comboBoxMovies.SelectedIndexChanged += new System.EventHandler(this.comboBoxMovies_SelectedIndexChanged);
            // 
            // labelHall
            // 
            this.labelHall.AutoSize = true;
            this.labelHall.BackColor = System.Drawing.Color.Transparent;
            this.labelHall.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHall.ForeColor = System.Drawing.Color.White;
            this.labelHall.Location = new System.Drawing.Point(73, 170);
            this.labelHall.Name = "labelHall";
            this.labelHall.Size = new System.Drawing.Size(109, 23);
            this.labelHall.TabIndex = 37;
            this.labelHall.Text = "Theatre hall";
            // 
            // comboBoxHalls
            // 
            this.comboBoxHalls.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHalls.FormattingEnabled = true;
            this.comboBoxHalls.Location = new System.Drawing.Point(312, 165);
            this.comboBoxHalls.Name = "comboBoxHalls";
            this.comboBoxHalls.Size = new System.Drawing.Size(329, 28);
            this.comboBoxHalls.TabIndex = 38;
            this.comboBoxHalls.SelectedIndexChanged += new System.EventHandler(this.comboBoxHalls_SelectedIndexChanged);
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(312, 484);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerTime.TabIndex = 39;
            this.dateTimePickerTime.ValueChanged += new System.EventHandler(this.dateTimePickerTime_ValueChanged);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.BackColor = System.Drawing.Color.Transparent;
            this.labelDate.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(73, 242);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(52, 23);
            this.labelDate.TabIndex = 40;
            this.labelDate.Text = "Date";
            // 
            // monthCalendarDate
            // 
            this.monthCalendarDate.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarDate.Location = new System.Drawing.Point(312, 242);
            this.monthCalendarDate.Name = "monthCalendarDate";
            this.monthCalendarDate.TabIndex = 41;
            this.monthCalendarDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDate_DateChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(75, 486);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(50, 23);
            this.labelTime.TabIndex = 42;
            this.labelTime.Text = "Time";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelPrice.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(73, 543);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(120, 23);
            this.labelPrice.TabIndex = 43;
            this.labelPrice.Text = "Regular price";
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPrice.Location = new System.Drawing.Point(312, 543);
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownPrice.TabIndex = 44;
            this.numericUpDownPrice.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPrice.ValueChanged += new System.EventHandler(this.numericUpDownPrice_ValueChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonAdd.Enabled = false;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Berlin Sans FB Demi", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(807, 556);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(171, 34);
            this.buttonAdd.TabIndex = 45;
            this.buttonAdd.Text = "ADD PROJECTION";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelScreenTitle
            // 
            this.labelScreenTitle.AutoSize = true;
            this.labelScreenTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelScreenTitle.Font = new System.Drawing.Font("Berlin Sans FB Demi", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScreenTitle.ForeColor = System.Drawing.Color.White;
            this.labelScreenTitle.Location = new System.Drawing.Point(72, 27);
            this.labelScreenTitle.Name = "labelScreenTitle";
            this.labelScreenTitle.Size = new System.Drawing.Size(219, 27);
            this.labelScreenTitle.TabIndex = 46;
            this.labelScreenTitle.Text = "Add new projection";
            // 
            // FormNewProjection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1032, 633);
            this.Controls.Add(this.labelScreenTitle);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.monthCalendarDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateTimePickerTime);
            this.Controls.Add(this.comboBoxHalls);
            this.Controls.Add(this.labelHall);
            this.Controls.Add(this.comboBoxMovies);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNewProjection";
            this.Text = "FormNewProjection";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ComboBox comboBoxMovies;
        private System.Windows.Forms.Label labelHall;
        private System.Windows.Forms.ComboBox comboBoxHalls;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.MonthCalendar monthCalendarDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelScreenTitle;
    }
}