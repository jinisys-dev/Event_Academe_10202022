using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

using System.Configuration;

namespace Jinisys.Hotel.Security
{
	namespace Presentation
	{
		public class SplashScreenUI : System.Windows.Forms.Form
		{
			
			
			#region " Windows Form Designer generated code "
			
			public SplashScreenUI()
			{
				
				//This call is required by the Windows Form Designer.
				InitializeComponent();


                //Add any initialization after the InitializeComponent() call
                this.txtStat.Visible = false;
                this.btnOk.Visible = true;


                string txt = "Licensed To: \r\n";
                txt += ConfigVariables.gReportOrganization + "\r\n";
                txt += ConfigVariables.gReportAddress1 + "\r\n";
                txt += ConfigVariables.gReportAddress2 + "\r\n";
                txt += ConfigVariables.gReportContactNo + "\r\n\r\n";

                txt += "License Key: " + GlobalVariables.APP_LICENSE_KEY + "\r\n";

                this.txtLicenseInfo.Text = txt;

                this.btnOk.Text = "&Close";
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

            private System.ComponentModel.IContainer components;

            //Required by the Windows Form Designer
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
            internal System.Windows.Forms.PictureBox PictureBox2;
            internal System.Windows.Forms.Label txtStat;
            internal Timer tmrWait;
            private Button btnOk;
			private TextBox txtLicenseInfo;
			internal System.Windows.Forms.Timer tmrSplash;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                this.components = new System.ComponentModel.Container();
                this.tmrSplash = new System.Windows.Forms.Timer(this.components);
                this.tmrWait = new System.Windows.Forms.Timer(this.components);
                this.btnOk = new System.Windows.Forms.Button();
                this.txtLicenseInfo = new System.Windows.Forms.TextBox();
                this.txtStat = new System.Windows.Forms.Label();
                this.PictureBox2 = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
                this.SuspendLayout();
                // 
                // tmrSplash
                // 
                this.tmrSplash.Tick += new System.EventHandler(this.tmrSplash_Tick);
                // 
                // tmrWait
                // 
                this.tmrWait.Interval = 500;
                this.tmrWait.Tick += new System.EventHandler(this.tmrWait_Tick);
                // 
                // btnOk
                // 
                this.btnOk.BackColor = System.Drawing.SystemColors.Control;
                this.btnOk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnOk.Location = new System.Drawing.Point(357, 254);
                this.btnOk.Name = "btnOk";
                this.btnOk.Size = new System.Drawing.Size(68, 32);
                this.btnOk.TabIndex = 11;
                this.btnOk.Text = "&Ok";
                this.btnOk.UseVisualStyleBackColor = false;
                this.btnOk.Visible = false;
                this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
                // 
                // txtLicenseInfo
                // 
                this.txtLicenseInfo.BackColor = System.Drawing.Color.White;
                this.txtLicenseInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.txtLicenseInfo.Location = new System.Drawing.Point(252, 152);
                this.txtLicenseInfo.Multiline = true;
                this.txtLicenseInfo.Name = "txtLicenseInfo";
                this.txtLicenseInfo.ReadOnly = true;
                this.txtLicenseInfo.Size = new System.Drawing.Size(173, 79);
                this.txtLicenseInfo.TabIndex = 1;
                this.txtLicenseInfo.Text = "Jinisys Software, Inc.";
                // 
                // txtStat
                // 
                this.txtStat.AutoEllipsis = true;
                this.txtStat.BackColor = System.Drawing.Color.GhostWhite;
                this.txtStat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtStat.ForeColor = System.Drawing.Color.Black;
                this.txtStat.Image = global::Jinisys.Hotel.Security.Properties.Resources.lbl_bg;
                this.txtStat.Location = new System.Drawing.Point(125, 187);
                this.txtStat.Name = "txtStat";
                this.txtStat.Size = new System.Drawing.Size(245, 14);
                this.txtStat.TabIndex = 2;
                this.txtStat.Text = "Loading Main Screen";
                this.txtStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // PictureBox2
                // 
                this.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.PictureBox2.Image = global::Jinisys.Hotel.Security.Properties.Resources.FP_splash_screen2;
                this.PictureBox2.Location = new System.Drawing.Point(0, 0);
                this.PictureBox2.Name = "PictureBox2";
                this.PictureBox2.Size = new System.Drawing.Size(469, 327);
                this.PictureBox2.TabIndex = 1;
                this.PictureBox2.TabStop = false;
                // 
                // SplashScreenUI
                // 
                this.BackColor = System.Drawing.SystemColors.AppWorkspace;
                this.ClientSize = new System.Drawing.Size(469, 327);
                this.Controls.Add(this.btnOk);
                this.Controls.Add(this.txtLicenseInfo);
                this.Controls.Add(this.txtStat);
                this.Controls.Add(this.PictureBox2);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "SplashScreenUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "SplashScreenUI";
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

			}
			
			#endregion
			
			private string mode;
			private string connectionStr;
			private MySqlConnection myDBCon;
			public SplashScreenUI(string conStr)
			{
				InitializeComponent();

                ConfigurationManager.AppSettings.Get("");

                this.txtLicenseInfo.Visible = false;
                
				if (conStr != "Loaded")
				{
					connectionStr = conStr;
					mode = "";
                    this.tmrWait.Enabled = true;
				}
				else
				{
					mode = conStr;
                    this.tmrWait.Enabled = true;
					//this.tmrSplash.Enabled = true;
				}
			}
			
			
			public void AuthenticateUser()
			{
                try
                {
                    if (connectionStr != "")
                    {
                        myDBCon = new MySqlConnection(connectionStr);
                        
                        myDBCon.Open();
                     
                        if (myDBCon.State == ConnectionState.Open)
                        {
                            GlobalVariables.gPersistentConnection = myDBCon;
                            this.tmrSplash.Enabled = true;
                        }

						MySqlConnection bgWorkerConnection = new MySqlConnection();
						bgWorkerConnection.ConnectionString = connectionStr;
						bgWorkerConnection.Open();

						GlobalVariables.gConnectionForBackGroundWorker = bgWorkerConnection;

                    }
                }
                catch (Exception ex)
                {
                    this.txtStat.ForeColor = System.Drawing.Color.Red;
                    this.txtStat.Text = "Can't connect to Database.";

                    this.tmrSplash.Enabled = false;
                    this.tmrSplash.Dispose();

                    MessageBox.Show("Can't connect to the server. " + "\r\n" + "Error Message: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
			}
			
			private void tmrSplash_Tick(System.Object sender, System.EventArgs e)
			{
                
				try
				{
                    if (mode == "")
                    {
                        AuthenticateUser();
                    }


					if (myDBCon.State == ConnectionState.Connecting)
					{
						if (this.txtStat.Text == "")
						{
							this.txtStat.Text = "Establishing database connection...";
						}
						else
						{
							this.txtStat.Text = "Can't connect to Database.";
						}
					}
					else
					{
						this.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Application.Exit();
				}
				
			}

            private void tmrWait_Tick(object sender, EventArgs e)
            {
                this.txtStat.Text = "Establishing database connection";
				
                tmrSplash.Enabled = true;

                this.tmrWait.Enabled = false;
                this.tmrWait.Dispose();
            }

            private void btnOk_Click(object sender, EventArgs e)
            {
                this.Close();
            }

		}
	}
}
