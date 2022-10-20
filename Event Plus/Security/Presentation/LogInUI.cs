using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;

namespace Jinisys.Hotel.Security
{
	namespace Presentation
	{
		public class LogInUI : System.Windows.Forms.Form
		{
			
			
			#region " Windows Form Designer generated code "

            public LogInUI()
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
			internal System.Windows.Forms.PictureBox PictureBox1;
			internal System.Windows.Forms.GroupBox GroupBox1;
			internal System.Windows.Forms.TextBox txtUserName;
			internal System.Windows.Forms.TextBox txtPassword;
			internal System.Windows.Forms.Button btnLogin;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.Label Label2;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInUI));
                this.PictureBox1 = new System.Windows.Forms.PictureBox();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.Label1 = new System.Windows.Forms.Label();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnLogin = new System.Windows.Forms.Button();
                this.txtPassword = new System.Windows.Forms.TextBox();
                this.txtUserName = new System.Windows.Forms.TextBox();
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                this.GroupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // PictureBox1
                // 
                this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
                this.PictureBox1.Location = new System.Drawing.Point(3, 3);
                this.PictureBox1.Name = "PictureBox1";
                this.PictureBox1.Size = new System.Drawing.Size(101, 149);
                this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.PictureBox1.TabIndex = 9;
                this.PictureBox1.TabStop = false;
                // 
                // GroupBox1
                // 
                this.GroupBox1.Controls.Add(this.Label2);
                this.GroupBox1.Controls.Add(this.Label1);
                this.GroupBox1.Controls.Add(this.btnCancel);
                this.GroupBox1.Controls.Add(this.btnLogin);
                this.GroupBox1.Controls.Add(this.txtPassword);
                this.GroupBox1.Controls.Add(this.txtUserName);
                this.GroupBox1.Location = new System.Drawing.Point(107, -2);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(182, 154);
                this.GroupBox1.TabIndex = 10;
                this.GroupBox1.TabStop = false;
                // 
                // Label2
                // 
                this.Label2.Location = new System.Drawing.Point(12, 60);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(96, 15);
                this.Label2.TabIndex = 5;
                this.Label2.Text = "Password";
                // 
                // Label1
                // 
                this.Label1.Location = new System.Drawing.Point(12, 18);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(96, 15);
                this.Label1.TabIndex = 4;
                this.Label1.Text = "User Name";
                // 
                // btnCancel
                // 
                this.btnCancel.Location = new System.Drawing.Point(92, 112);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(68, 31);
                this.btnCancel.TabIndex = 3;
                this.btnCancel.Text = "&Cancel";
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnLogin
                // 
                this.btnLogin.Location = new System.Drawing.Point(20, 112);
                this.btnLogin.Name = "btnLogin";
                this.btnLogin.Size = new System.Drawing.Size(68, 31);
                this.btnLogin.TabIndex = 2;
                this.btnLogin.Text = "&Ok";
                this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
                // 
                // txtPassword
                // 
                this.txtPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
                this.txtPassword.Location = new System.Drawing.Point(12, 77);
                this.txtPassword.Name = "txtPassword";
                this.txtPassword.PasswordChar = 'l';
                this.txtPassword.Size = new System.Drawing.Size(155, 20);
                this.txtPassword.TabIndex = 1;
                this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
                // 
                // txtUserName
                // 
                this.txtUserName.Location = new System.Drawing.Point(12, 35);
                this.txtUserName.Name = "txtUserName";
                this.txtUserName.Size = new System.Drawing.Size(155, 20);
                this.txtUserName.TabIndex = 0;
                this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
                // 
                // LogInUI
                // 
                this.ClientSize = new System.Drawing.Size(291, 154);
                this.ControlBox = false;
                this.Controls.Add(this.GroupBox1);
                this.Controls.Add(this.PictureBox1);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "LogInUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Log in";
                this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClosing);
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                this.GroupBox1.ResumeLayout(false);
                this.GroupBox1.PerformLayout();
                this.ResumeLayout(false);

			}
			
			#endregion
			private MySqlConnection localConnection;
			public LogInUI(MySqlConnection con)
			{
				InitializeComponent();
				
				localConnection = con;
			}
			
			
			private UserFacade oUserFacade;
			private Jinisys.Hotel.Security.BusinessLayer.User oUser;
			private new void FormClosing(System.Object sender, System.ComponentModel.CancelEventArgs e)
			{
				
				if (oUser != null)
				{
					e.Cancel = false;
				}
				else
				{
					e.Cancel = true;
				}
				
			}
			private void btnLogin_Click(System.Object sender, System.EventArgs e)
			{
				oUserFacade = new UserFacade(localConnection);
				oUser = new Jinisys.Hotel.Security.BusinessLayer.User();
				oUser.UserId = this.txtUserName.Text;
				oUser.Password = this.txtPassword.Text;
				
				oUserFacade.AuthenticateUser(ref oUser);
				
				
				if (oUser.Authenticated)
				{
					GlobalVariables.goUser = oUser;
                    
                    /* Jerome, April 17, 2008 *******************************
                     * Load Config Variables  *******************************
                     */
                    loadConfigVariables();
                    loadExpiryDate();

					this.Close();
				}
				else
				{
					GlobalVariables.goUser = null;
					
					MessageBox.Show("The system could not log you on." + "\r\n" + "Make sure your User name and Password are correct.","Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					
					this.txtPassword.SelectAll();
				}
				
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				if (MessageBox.Show("Are you sure you want to Exit?","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Application.Exit();
				}
			}
			
			private void txtPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					btnLogin_Click(this.btnLogin, new System.EventArgs());
				}
			}

			private void txtUserName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					if (this.txtPassword.Text == "")
					{
						this.txtPassword.Focus();
						this.txtPassword.SelectAll();
					}
					else
					{
						btnLogin_Click(this.btnLogin, new System.EventArgs());
					}

				}
			}

            private void loadConfigVariables()
            {
                /* Jerome, April 17, 2008 *******************************
                * Load Config Variables  *******************************
                */
                oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);

                try
                {
                    oUserFacade.loadConfigVariables();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading config variables.\r\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


				try
				{
					oUserFacade.loadCountyList();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error loading counties and nationalities.\r\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

            }

            private void loadExpiryDate()
            {
                oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
                try
                {
                    oUserFacade.loadExpiryDate();
                }
                catch (Exception ex)
                {

                }
            }
		}
	}
}
