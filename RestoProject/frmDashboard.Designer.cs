namespace RestoProject
{
    partial class frmDashboard
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.LightGray;
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnEmployees);
            this.pnlSidebar.Controls.Add(this.btnInventory);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pnlProfile);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(260, 561);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(22, 320);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(217, 34);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(22, 268);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(217, 34);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(22, 217);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(217, 34);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(22, 163);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(217, 34);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Location = new System.Drawing.Point(22, 108);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(217, 34);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.DimGray;
            this.pnlProfile.Controls.Add(this.label2);
            this.pnlProfile.Controls.Add(this.pictureBox1);
            this.pnlProfile.Controls.Add(this.label1);
            this.pnlProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProfile.Location = new System.Drawing.Point(0, 0);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(260, 89);
            this.pnlProfile.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Position:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RestoProject.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(22, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DimGray;
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(260, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(724, 89);
            this.pnlHeader.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dashboard";
            // 
            // pnlTab
            // 
            this.pnlTab.BackColor = System.Drawing.Color.White;
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(260, 89);
            this.pnlTab.MinimumSize = new System.Drawing.Size(126, 50);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(724, 472);
            this.pnlTab.TabIndex = 5;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "frmDashboard";
            this.Text = "formTheme1";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlTab;
    }
}