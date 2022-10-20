using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Win32;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Security
{
	namespace Presentation
	{
		public class TerminalUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public TerminalUI()
			{
				
				//This call is required by the Windows Form Designer.
				InitializeComponent();
				
				//Add any initialization after the InitializeComponent() call
				this.txtComputerName.Text = SystemInformation.ComputerName;
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
			internal System.Windows.Forms.TextBox txtComputerName;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.TextBox txtTerminalID;
			internal System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.Button btnSet;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.GroupBox GroupBox1;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TerminalUI));
				this.txtComputerName = new System.Windows.Forms.TextBox();
				this.txtComputerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtComputerName_KeyPress);
				this.Label1 = new System.Windows.Forms.Label();
				this.txtTerminalID = new System.Windows.Forms.TextBox();
				this.Label2 = new System.Windows.Forms.Label();
				this.btnSet = new System.Windows.Forms.Button();
				this.btnSet.Click += new System.EventHandler(btnSet_Click);
				this.btnCancel = new System.Windows.Forms.Button();
				this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
				this.GroupBox1 = new System.Windows.Forms.GroupBox();
				this.SuspendLayout();
				//
				//txtComputerName
				//
				this.txtComputerName.BackColor = System.Drawing.SystemColors.InactiveBorder;
				this.txtComputerName.Location = new System.Drawing.Point(107, 54);
				this.txtComputerName.Name = "txtComputerName";
				this.txtComputerName.Size = new System.Drawing.Size(123, 20);
				this.txtComputerName.TabIndex = 0;
				this.txtComputerName.Text = "";
				//
				//Label1
				//
				this.Label1.Location = new System.Drawing.Point(10, 57);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(88, 15);
				this.Label1.TabIndex = 1;
				this.Label1.Text = "Computer Name";
				//
				//txtTerminalID
				//
				this.txtTerminalID.BackColor = System.Drawing.Color.FromArgb(((byte) (255)), ((byte) (255)), ((byte) (192)));
				this.txtTerminalID.Location = new System.Drawing.Point(107, 20);
				this.txtTerminalID.Name = "txtTerminalID";
				this.txtTerminalID.Size = new System.Drawing.Size(66, 20);
				this.txtTerminalID.TabIndex = 2;
				this.txtTerminalID.Text = "";
				//
				//Label2
				//
				this.Label2.Location = new System.Drawing.Point(10, 23);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(88, 15);
				this.Label2.TabIndex = 3;
				this.Label2.Text = "Terminal ID";
				//
				//btnSet
				//
				this.btnSet.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnSet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.btnSet.Location = new System.Drawing.Point(99, 88);
				this.btnSet.Name = "btnSet";
				this.btnSet.Size = new System.Drawing.Size(66, 31);
				this.btnSet.TabIndex = 4;
				this.btnSet.Text = "Set";
				//
				//btnCancel
				//
				this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.btnCancel.Location = new System.Drawing.Point(166, 88);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(66, 31);
				this.btnCancel.TabIndex = 5;
				this.btnCancel.Text = "Cancel";
				//
				//GroupBox1
				//
				this.GroupBox1.Location = new System.Drawing.Point(2, - 3);
				this.GroupBox1.Name = "GroupBox1";
				this.GroupBox1.Size = new System.Drawing.Size(239, 129);
				this.GroupBox1.TabIndex = 6;
				this.GroupBox1.TabStop = false;
				//
				//TerminalUI
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.ClientSize = new System.Drawing.Size(242, 127);
				this.Controls.Add(this.btnCancel);
				this.Controls.Add(this.btnSet);
				this.Controls.Add(this.Label2);
				this.Controls.Add(this.txtTerminalID);
				this.Controls.Add(this.Label1);
				this.Controls.Add(this.txtComputerName);
				this.Controls.Add(this.GroupBox1);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
				this.Name = "TerminalUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Set Terminal ID";
				this.ResumeLayout(false);
				
			}
			
			#endregion
			private int TerminalID;
			//private string ComputerName;
			private RegistryKey regkey;
			public TerminalUI(int terID)
			{
				InitializeComponent();
				TerminalID = terID;
				this.txtTerminalID.Text = TerminalID.ToString();
				this.txtComputerName.Text = SystemInformation.ComputerName;
				this.txtTerminalID.Focus();
			}
			
			private void btnSet_Click(System.Object sender, System.EventArgs e)
			{
				if (this.txtTerminalID.Text != "")
				{
					TerminalID = System.Convert.ToInt32(this.txtTerminalID.Text);
					regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("TerminalID");
					regkey.SetValue("TerminalID", TerminalID);
					GlobalVariables.gTerminalID = int.Parse( regkey.GetValue("TerminalID").ToString() );
					
					MessageBox.Show("Terminal set.","Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Dispose();
				}
			}
			
			
			
			private void txtComputerName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				this.Dispose();
			}
			
		}
	}
}
