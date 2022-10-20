using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
using Jinisys.Hotel.Utilities.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Configuration;

namespace Jinisys.Hotel.Utilities.Presentation
{
	    public class BackUpUI : Form
		{
			
			#region " Windows Form Designer generated code "
	        
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
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.ComboBox cboDatabase;
			internal System.Windows.Forms.SaveFileDialog sfdSave;
			internal System.Windows.Forms.Button btnBackUp;
            internal Button btnClose;
			internal System.Windows.Forms.GroupBox GroupBox1;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUpUI));
                this.cboDatabase = new System.Windows.Forms.ComboBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.sfdSave = new System.Windows.Forms.SaveFileDialog();
                this.btnBackUp = new System.Windows.Forms.Button();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.btnClose = new System.Windows.Forms.Button();
                this.GroupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // cboDatabase
                // 
                this.cboDatabase.Location = new System.Drawing.Point(10, 41);
                this.cboDatabase.Name = "cboDatabase";
                this.cboDatabase.Size = new System.Drawing.Size(256, 22);
                this.cboDatabase.TabIndex = 0;
                // 
                // Label1
                // 
                this.Label1.Location = new System.Drawing.Point(10, 23);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(104, 16);
                this.Label1.TabIndex = 1;
                this.Label1.Text = "Select Database:";
                // 
                // btnBackUp
                // 
                this.btnBackUp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnBackUp.Location = new System.Drawing.Point(96, 80);
                this.btnBackUp.Name = "btnBackUp";
                this.btnBackUp.Size = new System.Drawing.Size(98, 31);
                this.btnBackUp.TabIndex = 3;
                this.btnBackUp.Text = "&Create BackUp";
                this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
                // 
                // GroupBox1
                // 
                this.GroupBox1.Controls.Add(this.btnClose);
                this.GroupBox1.Controls.Add(this.btnBackUp);
                this.GroupBox1.Location = new System.Drawing.Point(0, -3);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(272, 123);
                this.GroupBox1.TabIndex = 4;
                this.GroupBox1.TabStop = false;
                // 
                // btnClose
                // 
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(200, 80);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 4;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // BackUpUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(272, 121);
                this.Controls.Add(this.Label1);
                this.Controls.Add(this.cboDatabase);
                this.Controls.Add(this.GroupBox1);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "BackUpUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Database Backup";
                this.Load += new System.EventHandler(this.BackUpUI_Load);
                this.GroupBox1.ResumeLayout(false);
                this.ResumeLayout(false);

			}
			
			#endregion

            #region Variables 
            private BackUpFACADE oBackUpFacade;
			private BackUp oBackUp;
            #endregion

            #region Constructor
            public BackUpUI()
			{
			    oBackUp = new BackUp();
				InitializeComponent();
            }
            #endregion

            #region Events

            private void btnBackUp_Click(System.Object sender, System.EventArgs e)
            {
                try
                {
                    if (this.cboDatabase.Text != "")
                    {
                        sfdSave.Filter = "SQL |*.sql |Text File|*.txt";
                        if (!System.Convert.ToBoolean(sfdSave.ShowDialog(this) == DialogResult.Cancel))
                        {
                            StreamReader strReader = new StreamReader(Application.StartupPath + "\\backup.bat");
                            string strorig = strReader.ReadToEnd();
                            string str;
                            str = string.Copy(strorig);
                            str = str.Replace("%dbname%", this.cboDatabase.Text);
                            str = str.Replace("%fname%", this.sfdSave.FileName);
                            //str = str.Replace("%user%", this.cboDatabase.Text);
                            //str = str.Replace("%password%", this.cboDatabase.Text);
                            //str = str.Replace("%host%", this.cboDatabase.Text);

                            //MessageBox.Show(str);
                            strReader.Close();
                            StreamWriter strWriter = new StreamWriter(Application.StartupPath + "\\backup.bat");
                            strWriter.Write(str);
                            strWriter.Close();
                            System.Diagnostics.Process.Start(Application.StartupPath + "\\backup.bat");
                            System.Threading.Thread.Sleep(2000);
                            strWriter = new StreamWriter(Application.StartupPath + "\\backup.bat");
                            strWriter.Write(strorig);
                            strWriter.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select a database to back-up!", "No Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void BackUpUI_Load(System.Object sender, System.EventArgs e)
            {
                if (load() == true)
                {
                    if (oBackUp.Databases.Count > 0)
                    {
                        for (int idx = 0; idx <= oBackUp.Databases.Count - 1; idx++)
                        {
                            this.cboDatabase.Items.Add(oBackUp.Databases[idx]);
                        }
                    }
                }
            }

            #endregion

            #region Methods

                private bool load()
                {
                    try
                    {
                        oBackUpFacade = new BackUpFACADE();
                        oBackUp.Databases = oBackUpFacade.GetDatabases();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

            #endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
	}
	

