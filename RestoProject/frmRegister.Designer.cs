namespace RestoProject
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblAccountExist = new System.Windows.Forms.Label();
            this.btnSendCode = new System.Windows.Forms.Button();
            this.txtVerifyCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVerifyStatus = new System.Windows.Forms.Label();
            this.btnVerifyCode = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(322, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(325, 198);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(225, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(325, 245);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(225, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(324, 295);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(225, 20);
            this.txtConfirmPassword.TabIndex = 5;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(325, 344);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(225, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(325, 462);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(224, 35);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblAccountExist
            // 
            this.lblAccountExist.AutoSize = true;
            this.lblAccountExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountExist.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAccountExist.Location = new System.Drawing.Point(322, 371);
            this.lblAccountExist.Name = "lblAccountExist";
            this.lblAccountExist.Size = new System.Drawing.Size(146, 15);
            this.lblAccountExist.TabIndex = 9;
            this.lblAccountExist.Text = "Already have an account?";
            this.lblAccountExist.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnSendCode
            // 
            this.btnSendCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendCode.Location = new System.Drawing.Point(25, 81);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.Size = new System.Drawing.Size(75, 23);
            this.btnSendCode.TabIndex = 10;
            this.btnSendCode.Text = "Send Code";
            this.btnSendCode.UseVisualStyleBackColor = true;
            this.btnSendCode.Click += new System.EventHandler(this.btnSendCode_Click);
            // 
            // txtVerifyCode
            // 
            this.txtVerifyCode.Location = new System.Drawing.Point(25, 45);
            this.txtVerifyCode.Name = "txtVerifyCode";
            this.txtVerifyCode.Size = new System.Drawing.Size(156, 20);
            this.txtVerifyCode.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(22, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Code";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // lblVerifyStatus
            // 
            this.lblVerifyStatus.AutoSize = true;
            this.lblVerifyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerifyStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblVerifyStatus.Location = new System.Drawing.Point(187, 48);
            this.lblVerifyStatus.Name = "lblVerifyStatus";
            this.lblVerifyStatus.Size = new System.Drawing.Size(72, 15);
            this.lblVerifyStatus.TabIndex = 13;
            this.lblVerifyStatus.Text = "Unverified";
            // 
            // btnVerifyCode
            // 
            this.btnVerifyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifyCode.Location = new System.Drawing.Point(121, 81);
            this.btnVerifyCode.Name = "btnVerifyCode";
            this.btnVerifyCode.Size = new System.Drawing.Size(75, 23);
            this.btnVerifyCode.TabIndex = 14;
            this.btnVerifyCode.Text = "Verify Code";
            this.btnVerifyCode.UseVisualStyleBackColor = true;
            this.btnVerifyCode.Click += new System.EventHandler(this.btnVerifyCode_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(321, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(321, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(322, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "E-mail";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txtVerifyCode);
            this.panel1.Controls.Add(this.btnSendCode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblVerifyStatus);
            this.panel1.Controls.Add(this.btnVerifyCode);
            this.panel1.Location = new System.Drawing.Point(700, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 124);
            this.panel1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(132, -113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(716, 435);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAccountExist);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRegister";
            this.Text = "frmRegister";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblAccountExist;
        private System.Windows.Forms.Button btnSendCode;
        private System.Windows.Forms.TextBox txtVerifyCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVerifyStatus;
        private System.Windows.Forms.Button btnVerifyCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}