namespace Jinisys.Hotel.Security.Presentation
{
    partial class ChangePasswordUI
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
            this.gbxPassword = new System.Windows.Forms.GroupBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lblLoggedTime = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxPassword.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPassword
            // 
            this.gbxPassword.BackColor = System.Drawing.Color.Transparent;
            this.gbxPassword.Controls.Add(this.txtOldPassword);
            this.gbxPassword.Controls.Add(this.lblOldPass);
            this.gbxPassword.Controls.Add(this.Label10);
            this.gbxPassword.Controls.Add(this.txtConfirmPassword);
            this.gbxPassword.Controls.Add(this.txtPassword);
            this.gbxPassword.Controls.Add(this.Label7);
            this.gbxPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPassword.Location = new System.Drawing.Point(13, 192);
            this.gbxPassword.Name = "gbxPassword";
            this.gbxPassword.Size = new System.Drawing.Size(384, 181);
            this.gbxPassword.TabIndex = 187;
            this.gbxPassword.TabStop = false;
            this.gbxPassword.Text = "Change Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtOldPassword.Location = new System.Drawing.Point(139, 46);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = 'l';
            this.txtOldPassword.Size = new System.Drawing.Size(171, 20);
            this.txtOldPassword.TabIndex = 10;
            this.txtOldPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPassword_KeyPress);
            // 
            // lblOldPass
            // 
            this.lblOldPass.BackColor = System.Drawing.Color.Transparent;
            this.lblOldPass.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPass.Location = new System.Drawing.Point(24, 46);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(89, 17);
            this.lblOldPass.TabIndex = 62;
            this.lblOldPass.Text = "Old Password :";
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(24, 110);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(105, 17);
            this.Label10.TabIndex = 60;
            this.Label10.Text = "Re-type Password :";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(139, 108);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = 'l';
            this.txtConfirmPassword.Size = new System.Drawing.Size(171, 20);
            this.txtConfirmPassword.TabIndex = 12;
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPassword_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtPassword.Location = new System.Drawing.Point(139, 78);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = 'l';
            this.txtPassword.Size = new System.Drawing.Size(171, 20);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPassword_KeyPress);
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(24, 80);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(104, 17);
            this.Label7.TabIndex = 58;
            this.Label7.Text = "New Password :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWelcome);
            this.groupBox1.Controls.Add(this.labelWelcome);
            this.groupBox1.Controls.Add(this.lblRoles);
            this.groupBox1.Controls.Add(this.lblLoggedTime);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 171);
            this.groupBox1.TabIndex = 188;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logon Information";
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(67, 33);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(259, 18);
            this.lblWelcome.TabIndex = 70;
            this.lblWelcome.Text = "Welcome";
            // 
            // labelWelcome
            // 
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(13, 33);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(56, 18);
            this.labelWelcome.TabIndex = 69;
            this.labelWelcome.Text = "Welcome";
            // 
            // lblRoles
            // 
            this.lblRoles.BackColor = System.Drawing.Color.Transparent;
            this.lblRoles.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRoles.Location = new System.Drawing.Point(139, 129);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(227, 35);
            this.lblRoles.TabIndex = 68;
            this.lblRoles.Text = "ADMINISTRATORS";
            // 
            // lblLoggedTime
            // 
            this.lblLoggedTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLoggedTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLoggedTime.Location = new System.Drawing.Point(139, 102);
            this.lblLoggedTime.Name = "lblLoggedTime";
            this.lblLoggedTime.Size = new System.Drawing.Size(227, 18);
            this.lblLoggedTime.TabIndex = 67;
            this.lblLoggedTime.Text = "Thu. Feb. 15, 2007 02:40:20 PM";
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(139, 74);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(227, 18);
            this.lblUserName.TabIndex = 66;
            this.lblUserName.Text = "ADMINISTRATOR";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 65;
            this.label3.Text = "Roles :";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 64;
            this.label2.Text = "Logged on date :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "You are logged as :";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(252, 385);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 31);
            this.btnOk.TabIndex = 189;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(326, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 190;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangePasswordUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(412, 429);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxPassword);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.gbxPassword.ResumeLayout(false);
            this.gbxPassword.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbxPassword;
        public System.Windows.Forms.TextBox txtOldPassword;
        public System.Windows.Forms.Label lblOldPass;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.TextBox txtConfirmPassword;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.Label Label7;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblRoles;
        public System.Windows.Forms.Label lblLoggedTime;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label labelWelcome;
        public System.Windows.Forms.Label lblWelcome;
    }
}