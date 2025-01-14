namespace Kino.view
{
    partial class FormNavigation
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
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.panelNavLine = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonEmployers = new System.Windows.Forms.Button();
            this.buttonNewMovie = new System.Windows.Forms.Button();
            this.buttonNewProjection = new System.Windows.Forms.Button();
            this.buttonProjections = new System.Windows.Forms.Button();
            this.buttonReceipts = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelUser = new System.Windows.Forms.Panel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelFormLoader = new System.Windows.Forms.Panel();
            this.panelNavigation.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.panelNavigation.Controls.Add(this.panelNavLine);
            this.panelNavigation.Controls.Add(this.buttonLogout);
            this.panelNavigation.Controls.Add(this.buttonEmployers);
            this.panelNavigation.Controls.Add(this.buttonNewMovie);
            this.panelNavigation.Controls.Add(this.buttonNewProjection);
            this.panelNavigation.Controls.Add(this.buttonProjections);
            this.panelNavigation.Controls.Add(this.buttonReceipts);
            this.panelNavigation.Controls.Add(this.buttonHome);
            this.panelNavigation.Controls.Add(this.panelUser);
            this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavigation.Location = new System.Drawing.Point(0, 0);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(230, 720);
            this.panelNavigation.TabIndex = 0;
            // 
            // panelNavLine
            // 
            this.panelNavLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.panelNavLine.Location = new System.Drawing.Point(3, 216);
            this.panelNavLine.Name = "panelNavLine";
            this.panelNavLine.Size = new System.Drawing.Size(7, 100);
            this.panelNavLine.TabIndex = 8;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Berlin Sans FB Demi", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(0, 670);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(230, 50);
            this.buttonLogout.TabIndex = 7;
            this.buttonLogout.Text = "LOGOUT";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonEmployers
            // 
            this.buttonEmployers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.buttonEmployers.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEmployers.FlatAppearance.BorderSize = 0;
            this.buttonEmployers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmployers.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmployers.ForeColor = System.Drawing.Color.White;
            this.buttonEmployers.Location = new System.Drawing.Point(0, 410);
            this.buttonEmployers.Name = "buttonEmployers";
            this.buttonEmployers.Size = new System.Drawing.Size(230, 50);
            this.buttonEmployers.TabIndex = 6;
            this.buttonEmployers.Text = "EMPLOYERS";
            this.buttonEmployers.UseVisualStyleBackColor = false;
            this.buttonEmployers.Click += new System.EventHandler(this.buttonEmployers_Click);
            this.buttonEmployers.Leave += new System.EventHandler(this.buttonEmployee_Leave);
            // 
            // buttonNewMovie
            // 
            this.buttonNewMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.buttonNewMovie.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewMovie.FlatAppearance.BorderSize = 0;
            this.buttonNewMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewMovie.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewMovie.ForeColor = System.Drawing.Color.White;
            this.buttonNewMovie.Location = new System.Drawing.Point(0, 360);
            this.buttonNewMovie.Name = "buttonNewMovie";
            this.buttonNewMovie.Size = new System.Drawing.Size(230, 50);
            this.buttonNewMovie.TabIndex = 5;
            this.buttonNewMovie.Text = "NEW MOVIE";
            this.buttonNewMovie.UseVisualStyleBackColor = false;
            this.buttonNewMovie.Click += new System.EventHandler(this.buttonNewMovie_Click);
            this.buttonNewMovie.Leave += new System.EventHandler(this.buttonNewMovie_Leave);
            // 
            // buttonNewProjection
            // 
            this.buttonNewProjection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.buttonNewProjection.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewProjection.FlatAppearance.BorderSize = 0;
            this.buttonNewProjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewProjection.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewProjection.ForeColor = System.Drawing.Color.White;
            this.buttonNewProjection.Location = new System.Drawing.Point(0, 310);
            this.buttonNewProjection.Name = "buttonNewProjection";
            this.buttonNewProjection.Size = new System.Drawing.Size(230, 50);
            this.buttonNewProjection.TabIndex = 4;
            this.buttonNewProjection.Text = "NEW PROJECTION";
            this.buttonNewProjection.UseVisualStyleBackColor = false;
            this.buttonNewProjection.Click += new System.EventHandler(this.buttonNewProjection_Click);
            this.buttonNewProjection.Leave += new System.EventHandler(this.buttonNewProjection_Leave);
            // 
            // buttonProjections
            // 
            this.buttonProjections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.buttonProjections.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProjections.FlatAppearance.BorderSize = 0;
            this.buttonProjections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProjections.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjections.ForeColor = System.Drawing.Color.White;
            this.buttonProjections.Location = new System.Drawing.Point(0, 260);
            this.buttonProjections.Name = "buttonProjections";
            this.buttonProjections.Size = new System.Drawing.Size(230, 50);
            this.buttonProjections.TabIndex = 3;
            this.buttonProjections.Text = "PROJECTIONS";
            this.buttonProjections.UseVisualStyleBackColor = false;
            this.buttonProjections.Click += new System.EventHandler(this.buttonProjections_Click);
            this.buttonProjections.Leave += new System.EventHandler(this.buttonProjections_Leave);
            // 
            // buttonReceipts
            // 
            this.buttonReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.buttonReceipts.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonReceipts.FlatAppearance.BorderSize = 0;
            this.buttonReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceipts.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReceipts.ForeColor = System.Drawing.Color.White;
            this.buttonReceipts.Location = new System.Drawing.Point(0, 210);
            this.buttonReceipts.Name = "buttonReceipts";
            this.buttonReceipts.Size = new System.Drawing.Size(230, 50);
            this.buttonReceipts.TabIndex = 2;
            this.buttonReceipts.Text = "RECEIPTS";
            this.buttonReceipts.UseVisualStyleBackColor = false;
            this.buttonReceipts.Click += new System.EventHandler(this.buttonReceipts_Click);
            this.buttonReceipts.Leave += new System.EventHandler(this.buttonReservations_Leave);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Location = new System.Drawing.Point(0, 160);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(230, 50);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "HOME";
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            this.buttonHome.Leave += new System.EventHandler(this.buttonHome_Leave);
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(139)))), ((int)(((byte)(160)))));
            this.panelUser.Controls.Add(this.labelUsername);
            this.panelUser.Controls.Add(this.pictureBoxUser);
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUser.Location = new System.Drawing.Point(0, 0);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(230, 160);
            this.panelUser.TabIndex = 0;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(70, 105);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(87, 19);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "username";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.Image = global::Kino.Properties.Resources.Picture1;
            this.pictureBoxUser.Location = new System.Drawing.Point(80, 24);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(70, 63);
            this.pictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUser.TabIndex = 0;
            this.pictureBoxUser.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.AutoSize = true;
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(1213, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(67, 31);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelFormLoader
            // 
            this.panelFormLoader.BackColor = System.Drawing.Color.Transparent;
            this.panelFormLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFormLoader.Location = new System.Drawing.Point(230, 40);
            this.panelFormLoader.Name = "panelFormLoader";
            this.panelFormLoader.Size = new System.Drawing.Size(1050, 680);
            this.panelFormLoader.TabIndex = 17;
            // 
            // FormNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelFormLoader);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelNavigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNavigation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormNavigation_Load);
            this.panelNavigation.ResumeLayout(false);
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonEmployers;
        private System.Windows.Forms.Button buttonNewMovie;
        private System.Windows.Forms.Button buttonNewProjection;
        private System.Windows.Forms.Button buttonProjections;
        private System.Windows.Forms.Button buttonReceipts;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panelNavLine;
        private System.Windows.Forms.Panel panelFormLoader;
    }
}