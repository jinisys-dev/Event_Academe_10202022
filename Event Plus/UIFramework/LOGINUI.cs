using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.UIFramework
{
	namespace Presentation
	{
		public class LOGINUI : System.Windows.Forms.Form
		{
			
			
			#region " Windows Form Designer generated code "
			
			public LOGINUI()
			{
				
				//This call is required by the Windows Form Designer.
				InitializeComponent();
				
				//Add any initialization after the InitializeComponent() call
				
			}
			
			//Form overrides dispose to clean up the component list.
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (!(components == null))
					{
						components.Dispose();
					}
				}
				base.Dispose(disposing);
			}
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			public System.Windows.Forms.TextBox txtUsername;
			public System.Windows.Forms.TextBox txtPassword;
			public System.Windows.Forms.Button btnLogin;
			public System.Windows.Forms.Button btnCancel;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.GroupBox GroupBox1;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.txtUsername = new System.Windows.Forms.TextBox();
				this.txtPassword = new System.Windows.Forms.TextBox();
				this.Label1 = new System.Windows.Forms.Label();
				this.Label2 = new System.Windows.Forms.Label();
				this.btnLogin = new System.Windows.Forms.Button();
				this.btnCancel = new System.Windows.Forms.Button();
				this.GroupBox1 = new System.Windows.Forms.GroupBox();
				this.GroupBox1.SuspendLayout();
				this.SuspendLayout();
				//
				//txtUsername
				//
				this.txtUsername.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.txtUsername.Location = new System.Drawing.Point(168, 32);
				this.txtUsername.Name = "txtUsername";
				this.txtUsername.Size = new System.Drawing.Size(168, 20);
				this.txtUsername.TabIndex = 0;
				this.txtUsername.Text = "";
				//
				//txtPassword
				//
				this.txtPassword.Location = new System.Drawing.Point(168, 72);
				this.txtPassword.Name = "txtPassword";
				this.txtPassword.PasswordChar = Microsoft.VisualBasic.Strings.ChrW(42);
				this.txtPassword.Size = new System.Drawing.Size(168, 20);
				this.txtPassword.TabIndex = 1;
				this.txtPassword.Text = "";
				//
				//Label1
				//
				this.Label1.BackColor = System.Drawing.Color.Transparent;
				this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.Label1.Location = new System.Drawing.Point(168, 16);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(80, 16);
				this.Label1.TabIndex = 2;
				this.Label1.Text = "Username";
				this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				//
				//Label2
				//
				this.Label2.BackColor = System.Drawing.Color.Transparent;
				this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.Label2.Location = new System.Drawing.Point(168, 56);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(80, 16);
				this.Label2.TabIndex = 3;
				this.Label2.Text = "Password";
				this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				//
				//btnLogin
				//
				this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((byte) (0)), ((byte) (0)), ((byte) (0)), ((byte) (0)));
				this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.btnLogin.Location = new System.Drawing.Point(168, 104);
				this.btnLogin.Name = "btnLogin";
				this.btnLogin.TabIndex = 4;
				this.btnLogin.Text = "Ok";
				//
				//btnCancel
				//
				this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((byte) (0)), ((byte) (0)), ((byte) (0)), ((byte) (0)));
				this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnCancel.Location = new System.Drawing.Point(256, 104);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.TabIndex = 5;
				this.btnCancel.Text = "Cancel";
				//
				//GroupBox1
				//
				this.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
				this.GroupBox1.Controls.Add(this.txtPassword);
				this.GroupBox1.Controls.Add(this.Label1);
				this.GroupBox1.Controls.Add(this.Label2);
				this.GroupBox1.Controls.Add(this.btnCancel);
				this.GroupBox1.Controls.Add(this.btnLogin);
				this.GroupBox1.Location = new System.Drawing.Point(0, - 3);
				this.GroupBox1.Name = "GroupBox1";
				this.GroupBox1.Size = new System.Drawing.Size(366, 153);
				this.GroupBox1.TabIndex = 6;
				this.GroupBox1.TabStop = false;
				//
				//LOGINUI
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.BackColor = System.Drawing.SystemColors.ControlLightLight;
				this.ClientSize = new System.Drawing.Size(366, 150);
				this.ControlBox = false;
				this.Controls.Add(this.txtUsername);
				this.Controls.Add(this.GroupBox1);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "LOGINUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Log-in";
				this.GroupBox1.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			
			#endregion
		}
	}
	
}
