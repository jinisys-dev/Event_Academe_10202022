using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.UIFramework
{
	public class LookUPUI : System.Windows.Forms.Form
	{
		
		
		#region " Windows Form Designer generated code "
		
		public LookUPUI()
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
		public System.Windows.Forms.ListView lvwLookUp;
		public System.Windows.Forms.GroupBox GroupBox1;
		public System.Windows.Forms.Button btnSearch;
		public System.Windows.Forms.TextBox txtSearch;
		public System.Windows.Forms.ComboBox cboCriteria;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Button btnClose;
		public System.Windows.Forms.Button btnSelect;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.lvwLookUp = new System.Windows.Forms.ListView();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cboCriteria = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			//lvwLookUp
			//
			this.lvwLookUp.FullRowSelect = true;
			this.lvwLookUp.GridLines = true;
			this.lvwLookUp.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.lvwLookUp.Location = new System.Drawing.Point(8, 64);
			this.lvwLookUp.Name = "lvwLookUp";
			this.lvwLookUp.Size = new System.Drawing.Size(631, 263);
			this.lvwLookUp.TabIndex = 0;
			this.lvwLookUp.View = System.Windows.Forms.View.Details;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.btnSearch);
			this.GroupBox1.Controls.Add(this.txtSearch);
			this.GroupBox1.Controls.Add(this.cboCriteria);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Location = new System.Drawing.Point(5, 2);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(637, 59);
			this.GroupBox1.TabIndex = 8;
			this.GroupBox1.TabStop = false;
			//
			//btnSearch
			//
			this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((byte) (0)), ((byte) (0)), ((byte) (0)), ((byte) (0)));
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSearch.Location = new System.Drawing.Point(470, 29);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(50, 21);
			this.btnSearch.TabIndex = 8;
			this.btnSearch.Text = "Search";
			//
			//txtSearch
			//
			this.txtSearch.Location = new System.Drawing.Point(176, 29);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(288, 20);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.Text = "";
			//
			//cboCriteria
			//
			this.cboCriteria.Location = new System.Drawing.Point(8, 29);
			this.cboCriteria.Name = "cboCriteria";
			this.cboCriteria.Size = new System.Drawing.Size(160, 21);
			this.cboCriteria.TabIndex = 0;
			//
			//Label1
			//
			this.Label1.Location = new System.Drawing.Point(8, 13);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(144, 16);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Search Criteria";
			//
			//Label2
			//
			this.Label2.Location = new System.Drawing.Point(176, 13);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(256, 16);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Type word(s) that would match to criteria being searched";
			//
			//btnClose
			//
			this.btnClose.BackColor = System.Drawing.Color.FromArgb(((byte) (0)), ((byte) (0)), ((byte) (0)), ((byte) (0)));
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(565, 341);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "Close";
			//
			//btnSelect
			//
			this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((byte) (0)), ((byte) (0)), ((byte) (0)), ((byte) (0)));
			this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSelect.Location = new System.Drawing.Point(485, 341);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.TabIndex = 10;
			this.btnSelect.Text = "SELECT";
			//
			//LookUPUI
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 366);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.lvwLookUp);
			this.Name = "LookUPUI";
			this.Text = "LookUP";
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		
		#endregion
		
	}
	
}
