using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Security
{
	namespace Presentation
	{
		public class LockScreenUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public LockScreenUI()
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
			internal System.Windows.Forms.Panel pnlLockScreen;
			internal System.Windows.Forms.TextBox txtUserName;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.Button btnUnLock;
			internal System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.TextBox txtPassword;
			internal System.Windows.Forms.Label lblError;
			internal System.Windows.Forms.PictureBox PictureBox2;
			internal System.Windows.Forms.Label Label3;
			internal System.Windows.Forms.Label Label4;
			internal System.Windows.Forms.Label Label5;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LockScreenUI));
				this.pnlLockScreen = new System.Windows.Forms.Panel();
				base.SizeChanged += new System.EventHandler(LockScreenUI_SizeChanged);
				base.Load += new System.EventHandler(LockScreenUI_Load);
				this.Label2 = new System.Windows.Forms.Label();
				this.txtPassword = new System.Windows.Forms.TextBox();
				this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPassword_KeyPress);
				this.btnUnLock = new System.Windows.Forms.Button();
				this.btnUnLock.Click += new System.EventHandler(btnUnLock_Click);
				this.Label1 = new System.Windows.Forms.Label();
				this.txtUserName = new System.Windows.Forms.TextBox();
				this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserName_KeyPress);
				this.PictureBox2 = new System.Windows.Forms.PictureBox();
				this.lblError = new System.Windows.Forms.Label();
				this.Label3 = new System.Windows.Forms.Label();
				this.Label4 = new System.Windows.Forms.Label();
				this.Label5 = new System.Windows.Forms.Label();
				this.pnlLockScreen.SuspendLayout();
				this.SuspendLayout();
				//
				//pnlLockScreen
				//
				this.pnlLockScreen.BackColor = System.Drawing.SystemColors.Control;
				this.pnlLockScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.pnlLockScreen.Controls.Add(this.Label3);
				this.pnlLockScreen.Controls.Add(this.Label5);
				this.pnlLockScreen.Controls.Add(this.Label2);
				this.pnlLockScreen.Controls.Add(this.txtPassword);
				this.pnlLockScreen.Controls.Add(this.btnUnLock);
				this.pnlLockScreen.Controls.Add(this.Label1);
				this.pnlLockScreen.Controls.Add(this.txtUserName);
				this.pnlLockScreen.Controls.Add(this.PictureBox2);
				this.pnlLockScreen.Controls.Add(this.lblError);
				this.pnlLockScreen.Controls.Add(this.Label4);
				this.pnlLockScreen.Location = new System.Drawing.Point(111, 28);
				this.pnlLockScreen.Name = "pnlLockScreen";
				this.pnlLockScreen.Size = new System.Drawing.Size(465, 280);
				this.pnlLockScreen.TabIndex = 8;
				//
				//Label2
				//
				this.Label2.Location = new System.Drawing.Point(177, 154);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(62, 15);
				this.Label2.TabIndex = 13;
				this.Label2.Text = "Password";
				//
				//txtPassword
				//
				this.txtPassword.BackColor = System.Drawing.Color.White;
				this.txtPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.txtPassword.Location = new System.Drawing.Point(262, 153);
				this.txtPassword.Name = "txtPassword";
				this.txtPassword.PasswordChar = '*';
				this.txtPassword.Size = new System.Drawing.Size(174, 20);
				this.txtPassword.TabIndex = 1;
				this.txtPassword.Text = "";
				this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
				//
				//btnUnLock
				//
				this.btnUnLock.BackColor = System.Drawing.SystemColors.Control;
				this.btnUnLock.Location = new System.Drawing.Point(253, 202);
				this.btnUnLock.Name = "btnUnLock";
				this.btnUnLock.Size = new System.Drawing.Size(84, 31);
				this.btnUnLock.TabIndex = 2;
				this.btnUnLock.Text = "&UnLock";
				//
				//Label1
				//
				this.Label1.Location = new System.Drawing.Point(177, 114);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(62, 15);
				this.Label1.TabIndex = 10;
				this.Label1.Text = "User Name";
				//
				//txtUserName
				//
				this.txtUserName.BackColor = System.Drawing.Color.White;
				this.txtUserName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
				this.txtUserName.Location = new System.Drawing.Point(262, 113);
				this.txtUserName.Name = "txtUserName";
				this.txtUserName.ReadOnly = true;
				this.txtUserName.Size = new System.Drawing.Size(174, 20);
				this.txtUserName.TabIndex = 0;
				this.txtUserName.Text = "";
				this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
				//
				//PictureBox2
				//
				this.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.PictureBox2.Image = (System.Drawing.Image) resources.GetObject("PictureBox2.Image");
				this.PictureBox2.Location = new System.Drawing.Point(- 1, 73);
				this.PictureBox2.Name = "PictureBox2";
				this.PictureBox2.Size = new System.Drawing.Size(151, 206);
				this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
				this.PictureBox2.TabIndex = 10;
				this.PictureBox2.TabStop = false;
				//
				//lblError
				//
				this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.lblError.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.lblError.ForeColor = System.Drawing.Color.Red;
				this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.lblError.Location = new System.Drawing.Point(149, 256);
				this.lblError.Name = "lblError";
				this.lblError.Size = new System.Drawing.Size(316, 24);
				this.lblError.TabIndex = 9;
				this.lblError.Text = "  Application Locked";
				this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				//
				//Label3
				//
				this.Label3.BackColor = System.Drawing.Color.White;
				this.Label3.Font = new System.Drawing.Font("Arial", 9.25F);
				this.Label3.Location = new System.Drawing.Point(8, 30);
				this.Label3.Name = "Label3";
				this.Label3.Size = new System.Drawing.Size(451, 36);
				this.Label3.TabIndex = 11;
				this.Label3.Text = "Application currently locked. Only Administrators and/or Authenticated Users can " + "use this Application.";
				this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				//
				//Label4
				//
				this.Label4.BackColor = System.Drawing.Color.SteelBlue;
				this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.Label4.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
				this.Label4.ForeColor = System.Drawing.Color.White;
				this.Label4.Location = new System.Drawing.Point(- 1, - 1);
				this.Label4.Name = "Label4";
				this.Label4.Size = new System.Drawing.Size(465, 23);
				this.Label4.TabIndex = 12;
				this.Label4.Text = " Folio Plus™ - Hotel Management System";
				this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				//
				//Label5
				//
				this.Label5.BackColor = System.Drawing.Color.White;
				this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.Label5.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
				this.Label5.ForeColor = System.Drawing.Color.White;
				this.Label5.Location = new System.Drawing.Point(- 1, 21);
				this.Label5.Name = "Label5";
				this.Label5.Size = new System.Drawing.Size(465, 54);
				this.Label5.TabIndex = 14;
				this.Label5.Text = "Folio Plus™ - Hotel Management System";
				this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				//
				//LockScreenUI
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.BackColor = System.Drawing.Color.White;
				this.ClientSize = new System.Drawing.Size(673, 336);
				this.Controls.Add(this.pnlLockScreen);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				this.Name = "LockScreenUI";
				this.Text = "Screen Lock";
				this.TopMost = true;
				this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
				this.pnlLockScreen.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			
			#endregion
			
			private Jinisys.Hotel.Security.BusinessLayer.User mUser;
			public LockScreenUI(Jinisys.Hotel.Security.BusinessLayer.User oUser)
			{
				
				//This call is required by the Windows Form Designer.
				InitializeComponent();
				
				//Add any initialization after the InitializeComponent() call
				mUser = oUser;
				this.txtUserName.Text = mUser.UserId;
			}
			
			private void LockScreenUI_SizeChanged(object sender, System.EventArgs e)
			{
				this.pnlLockScreen.Top = this.Height / 2 - pnlLockScreen.Height / 2;
				this.pnlLockScreen.Left = this.Width / 2 - pnlLockScreen.Width / 2;
			}
			
			private int attempt;
			private void btnUnLock_Click(System.Object sender, System.EventArgs e)
			{
				if (mUser != null)
				{
					if (mUser.Password == this.txtPassword.Text)
					{
						this.Close();
					}
					else
					{
						attempt++;
						this.lblError.Text = "  Invalid Password. " + attempt;
					}
				}
			}
			
			private void LockScreenUI_Load(object sender, System.EventArgs e)
			{
				this.txtPassword.Focus();
			}
			
			
			private void txtUserName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					btnUnLock_Click(sender, e);
				}
			}
			
			private void txtPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					btnUnLock_Click(sender, e);
				}
			}
		}
	}
}
