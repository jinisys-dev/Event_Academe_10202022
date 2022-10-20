namespace Jinisys.Hotel.Security.Presentation
{
	partial class ResetPasswordUI
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
			this.Label10 = new System.Windows.Forms.Label();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbxPassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxPassword
			// 
			this.gbxPassword.BackColor = System.Drawing.Color.Transparent;
			this.gbxPassword.Controls.Add(this.Label10);
			this.gbxPassword.Controls.Add(this.txtConfirmPassword);
			this.gbxPassword.Controls.Add(this.txtPassword);
			this.gbxPassword.Controls.Add(this.Label7);
			this.gbxPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbxPassword.Location = new System.Drawing.Point(11, 11);
			this.gbxPassword.Name = "gbxPassword";
			this.gbxPassword.Size = new System.Drawing.Size(280, 120);
			this.gbxPassword.TabIndex = 0;
			this.gbxPassword.TabStop = false;
			// 
			// Label10
			// 
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.Location = new System.Drawing.Point(13, 74);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(98, 18);
			this.Label10.TabIndex = 60;
			this.Label10.Text = "Confirm Password";
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
			this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 8.25F);
			this.txtConfirmPassword.Location = new System.Drawing.Point(123, 72);
			this.txtConfirmPassword.MaxLength = 20;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.PasswordChar = '*';
			this.txtConfirmPassword.Size = new System.Drawing.Size(139, 20);
			this.txtConfirmPassword.TabIndex = 2;
			// 
			// txtPassword
			// 
			this.txtPassword.BackColor = System.Drawing.Color.White;
			this.txtPassword.Font = new System.Drawing.Font("Arial", 8.25F);
			this.txtPassword.Location = new System.Drawing.Point(123, 33);
			this.txtPassword.MaxLength = 20;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(139, 20);
			this.txtPassword.TabIndex = 1;
			// 
			// Label7
			// 
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.Location = new System.Drawing.Point(13, 36);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(99, 18);
			this.Label7.TabIndex = 58;
			this.Label7.Text = "New Password";
			// 
			// btnSave
			// 
			this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(154, 143);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 33);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(221, 143);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 33);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ResetPasswordUI
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(300, 194);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbxPassword);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ResetPasswordUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Reset Password";
			this.gbxPassword.ResumeLayout(false);
			this.gbxPassword.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.GroupBox gbxPassword;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.TextBox txtConfirmPassword;
		public System.Windows.Forms.TextBox txtPassword;
		public System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnCancel;
	}
}