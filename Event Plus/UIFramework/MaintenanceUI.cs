using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.UIFramework
{
	public class MaintenanceUI : System.Windows.Forms.Form
	{
		
		
		#region " Windows Form Designer generated code "
		
		public MaintenanceUI()
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
		public System.Windows.Forms.GroupBox GroupBox1;
		public System.Windows.Forms.GroupBox GroupBox2;
		public System.Windows.Forms.DataGrid grdList;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.grdList = new System.Windows.Forms.DataGrid();
			this.GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.grdList).BeginInit();
			this.SuspendLayout();
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.grdList);
			this.GroupBox1.Location = new System.Drawing.Point(2, - 4);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(192, 418);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			//
			//GroupBox2
			//
			this.GroupBox2.Location = new System.Drawing.Point(195, - 4);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(495, 418);
			this.GroupBox2.TabIndex = 1;
			this.GroupBox2.TabStop = false;
			//
			//grdList
			//
			this.grdList.DataMember = "";
			this.grdList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdList.Location = new System.Drawing.Point(5, 10);
			this.grdList.Name = "grdList";
			this.grdList.Size = new System.Drawing.Size(183, 404);
			this.grdList.TabIndex = 0;
			//
			//MaintenanceUI
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(690, 414);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.GroupBox1);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MaintenanceUI";
			this.Text = "MDIMaintenanceUI";
			this.GroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.grdList).EndInit();
			this.ResumeLayout(false);
			
		}
		
		#endregion
		
	}
	
}
