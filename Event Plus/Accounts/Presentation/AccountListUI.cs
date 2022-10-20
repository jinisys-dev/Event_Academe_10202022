using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Microsoft.VisualBasic.CompilerServices;


namespace Jinisys.Hotel.Accounts.Presentation
{
	
		public class AccountListUI : Form
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
			internal System.Windows.Forms.TabControl TabControl1;
			internal System.Windows.Forms.TabPage TabPage1;
			internal System.Windows.Forms.TabPage TabPage2;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.ListView lvwPrivileges;
			internal System.Windows.Forms.ColumnHeader ColumnHeader1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ColumnHeader ColumnHeader3;
			internal System.Windows.Forms.ColumnHeader ColumnHeader4;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader5;
			internal System.Windows.Forms.ColumnHeader ColumnHeader6;
			internal System.Windows.Forms.ColumnHeader ColumnHeader7;
			internal System.Windows.Forms.ColumnHeader ColumnHeader8;
			internal System.Windows.Forms.ListView lvwPrivilegesGroup;
			internal System.Windows.Forms.Button btnSelectGrp;
			internal System.Windows.Forms.Button btnSelectInv;
			internal System.Windows.Forms.Button btnOkInv;
            internal System.Windows.Forms.Button btnOkGrp;
            internal Button btnClose;
			internal System.Windows.Forms.TextBox txtSrchGroup;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                this.TabControl1 = new System.Windows.Forms.TabControl();
                this.TabPage1 = new System.Windows.Forms.TabPage();
                this.btnSelectInv = new System.Windows.Forms.Button();
                this.btnOkInv = new System.Windows.Forms.Button();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.lvwPrivileges = new System.Windows.Forms.ListView();
                this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
                this.TabPage2 = new System.Windows.Forms.TabPage();
                this.btnSelectGrp = new System.Windows.Forms.Button();
                this.btnOkGrp = new System.Windows.Forms.Button();
                this.txtSrchGroup = new System.Windows.Forms.TextBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.lvwPrivilegesGroup = new System.Windows.Forms.ListView();
                this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
                this.btnClose = new System.Windows.Forms.Button();
                this.TabControl1.SuspendLayout();
                this.TabPage1.SuspendLayout();
                this.TabPage2.SuspendLayout();
                this.SuspendLayout();
                // 
                // TabControl1
                // 
                this.TabControl1.Controls.Add(this.TabPage1);
                this.TabControl1.Controls.Add(this.TabPage2);
                this.TabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.TabControl1.Location = new System.Drawing.Point(8, 8);
                this.TabControl1.Name = "TabControl1";
                this.TabControl1.SelectedIndex = 0;
                this.TabControl1.Size = new System.Drawing.Size(528, 384);
                this.TabControl1.TabIndex = 0;
                // 
                // TabPage1
                // 
                this.TabPage1.Controls.Add(this.btnSelectInv);
                this.TabPage1.Controls.Add(this.btnOkInv);
                this.TabPage1.Controls.Add(this.txtSearch);
                this.TabPage1.Controls.Add(this.Label2);
                this.TabPage1.Controls.Add(this.lvwPrivileges);
                this.TabPage1.Location = new System.Drawing.Point(4, 23);
                this.TabPage1.Name = "TabPage1";
                this.TabPage1.Size = new System.Drawing.Size(520, 357);
                this.TabPage1.TabIndex = 0;
                this.TabPage1.Text = "Individual";
                // 
                // btnSelectInv
                // 
                this.btnSelectInv.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSelectInv.Location = new System.Drawing.Point(440, 320);
                this.btnSelectInv.Name = "btnSelectInv";
                this.btnSelectInv.Size = new System.Drawing.Size(72, 28);
                this.btnSelectInv.TabIndex = 216;
                this.btnSelectInv.Text = "Select";
                this.btnSelectInv.Click += new System.EventHandler(this.btnSelectInv_Click);
                // 
                // btnOkInv
                // 
                this.btnOkInv.Location = new System.Drawing.Point(360, 24);
                this.btnOkInv.Name = "btnOkInv";
                this.btnOkInv.Size = new System.Drawing.Size(32, 24);
                this.btnOkInv.TabIndex = 210;
                this.btnOkInv.Text = "Ok";
                this.btnOkInv.Click += new System.EventHandler(this.btnOkInv_Click);
                // 
                // txtSearch
                // 
                this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSearch.Location = new System.Drawing.Point(8, 24);
                this.txtSearch.Name = "txtSearch";
                this.txtSearch.Size = new System.Drawing.Size(348, 20);
                this.txtSearch.TabIndex = 208;
                this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
                // 
                // Label2
                // 
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.Location = new System.Drawing.Point(8, 8);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(329, 23);
                this.Label2.TabIndex = 209;
                this.Label2.Text = "Type word(s) that would match to criteria being searched";
                // 
                // lvwPrivileges
                // 
                this.lvwPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4});
                this.lvwPrivileges.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lvwPrivileges.FullRowSelect = true;
                this.lvwPrivileges.GridLines = true;
                this.lvwPrivileges.Location = new System.Drawing.Point(8, 56);
                this.lvwPrivileges.Name = "lvwPrivileges";
                this.lvwPrivileges.Size = new System.Drawing.Size(504, 256);
                this.lvwPrivileges.TabIndex = 207;
                this.lvwPrivileges.UseCompatibleStateImageBehavior = false;
                this.lvwPrivileges.View = System.Windows.Forms.View.Details;
                this.lvwPrivileges.DoubleClick += new System.EventHandler(this.lvwPrivileges_DoubleClick);
                // 
                // ColumnHeader1
                // 
                this.ColumnHeader1.Text = "Account ID";
                this.ColumnHeader1.Width = 90;
                // 
                // ColumnHeader2
                // 
                this.ColumnHeader2.Text = "Account Name";
                this.ColumnHeader2.Width = 120;
                // 
                // ColumnHeader3
                // 
                this.ColumnHeader3.Text = "Lastname";
                this.ColumnHeader3.Width = 130;
                // 
                // ColumnHeader4
                // 
                this.ColumnHeader4.Text = "Firstname";
                this.ColumnHeader4.Width = 130;
                // 
                // TabPage2
                // 
                this.TabPage2.Controls.Add(this.btnSelectGrp);
                this.TabPage2.Controls.Add(this.btnOkGrp);
                this.TabPage2.Controls.Add(this.txtSrchGroup);
                this.TabPage2.Controls.Add(this.Label1);
                this.TabPage2.Controls.Add(this.lvwPrivilegesGroup);
                this.TabPage2.Location = new System.Drawing.Point(4, 23);
                this.TabPage2.Name = "TabPage2";
                this.TabPage2.Size = new System.Drawing.Size(520, 357);
                this.TabPage2.TabIndex = 1;
                this.TabPage2.Text = "Group";
                // 
                // btnSelectGrp
                // 
                this.btnSelectGrp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSelectGrp.Location = new System.Drawing.Point(440, 320);
                this.btnSelectGrp.Name = "btnSelectGrp";
                this.btnSelectGrp.Size = new System.Drawing.Size(72, 28);
                this.btnSelectGrp.TabIndex = 215;
                this.btnSelectGrp.Text = "Select";
                this.btnSelectGrp.Click += new System.EventHandler(this.btnSelectGrp_Click);
                // 
                // btnOkGrp
                // 
                this.btnOkGrp.Location = new System.Drawing.Point(360, 22);
                this.btnOkGrp.Name = "btnOkGrp";
                this.btnOkGrp.Size = new System.Drawing.Size(32, 24);
                this.btnOkGrp.TabIndex = 214;
                this.btnOkGrp.Text = "Ok";
                this.btnOkGrp.Click += new System.EventHandler(this.btnOkGrp_Click);
                // 
                // txtSrchGroup
                // 
                this.txtSrchGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSrchGroup.Location = new System.Drawing.Point(8, 22);
                this.txtSrchGroup.Name = "txtSrchGroup";
                this.txtSrchGroup.Size = new System.Drawing.Size(348, 20);
                this.txtSrchGroup.TabIndex = 212;
                this.txtSrchGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSrchGroup_KeyPress);
                // 
                // Label1
                // 
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.Location = new System.Drawing.Point(8, 6);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(329, 23);
                this.Label1.TabIndex = 213;
                this.Label1.Text = "Type word(s) that would match to criteria being searched";
                // 
                // lvwPrivilegesGroup
                // 
                this.lvwPrivilegesGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8});
                this.lvwPrivilegesGroup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lvwPrivilegesGroup.FullRowSelect = true;
                this.lvwPrivilegesGroup.GridLines = true;
                this.lvwPrivilegesGroup.Location = new System.Drawing.Point(8, 54);
                this.lvwPrivilegesGroup.Name = "lvwPrivilegesGroup";
                this.lvwPrivilegesGroup.Size = new System.Drawing.Size(504, 256);
                this.lvwPrivilegesGroup.TabIndex = 211;
                this.lvwPrivilegesGroup.UseCompatibleStateImageBehavior = false;
                this.lvwPrivilegesGroup.View = System.Windows.Forms.View.Details;
                this.lvwPrivilegesGroup.DoubleClick += new System.EventHandler(this.lvwPrivilegesGroup_DoubleClick);
                // 
                // ColumnHeader5
                // 
                this.ColumnHeader5.Text = "Account ID";
                this.ColumnHeader5.Width = 90;
                // 
                // ColumnHeader6
                // 
                this.ColumnHeader6.Text = "Account Name";
                this.ColumnHeader6.Width = 120;
                // 
                // ColumnHeader7
                // 
                this.ColumnHeader7.Text = "Lastname";
                this.ColumnHeader7.Width = 130;
                // 
                // ColumnHeader8
                // 
                this.ColumnHeader8.Text = "Firstname";
                this.ColumnHeader8.Width = 130;
                // 
                // btnClose
                // 
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(470, 407);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 191;
                this.btnClose.Text = "C&lose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // AccountListUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(544, 450);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.TabControl1);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "AccountListUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "Account List";
                this.Load += new System.EventHandler(this.AccountListUI_Load);
                this.TabControl1.ResumeLayout(false);
                this.TabPage1.ResumeLayout(false);
                this.TabPage1.PerformLayout();
                this.TabPage2.ResumeLayout(false);
                this.TabPage2.PerformLayout();
                this.ResumeLayout(false);

			}
			
			#endregion
			
			#region "Variables and Constants"
			
            private AccountPrivilegesFacade oAccountPrivilegesFacade;
			private TextBox txtAccntId;
			private TextBox txtName;
			
#endregion
			
			#region "Constructor"
			public AccountListUI( )
			{
				InitializeComponent();
			}

			public AccountListUI(TextBox txtAccId, TextBox txtNme)
			{
				InitializeComponent();
				txtAccntId = txtAccId;
				txtName = txtNme;
			}
			
			#endregion
			
			#region "Events"
			private void AccountListUI_Load(System.Object sender, System.EventArgs e)
			{
				loadData();
			}
			private void btnSelectGrp_Click(System.Object sender, System.EventArgs e)
			{
				try
				{
					this.txtAccntId.Text = this.lvwPrivilegesGroup.SelectedItems[0].Text;
					this.txtName.Text = this.lvwPrivilegesGroup.SelectedItems[0].SubItems[2].Text + " " + this.lvwPrivilegesGroup.SelectedItems[0].SubItems[3].Text;
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			
			private void btnSelectInv_Click(System.Object sender, System.EventArgs e)
			{
				
				try
				{
					this.txtAccntId.Text = this.lvwPrivileges.SelectedItems[0].Text;
					this.txtName.Text = this.lvwPrivileges.SelectedItems[0].SubItems[2].Text + " " + this.lvwPrivileges.SelectedItems[0].SubItems[3].Text;
					this.Close();
					
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			
			private void btnOkGrp_Click(System.Object sender, System.EventArgs e)
			{
				lvwPrivilegesGroup.Focus();
				for (int i = 0; i <= this.lvwPrivilegesGroup.Items.Count - 1; i++)
				{
					if (StringType.StrLike(this.lvwPrivilegesGroup.Items[i].SubItems[2].Text, "*" + this.txtSearch.Text.ToUpper() + "*", CompareMethod.Binary))
					{
						this.lvwPrivilegesGroup.Items[i].Selected = true;
						this.lvwPrivilegesGroup.Items[i].EnsureVisible();
					}
				}
			}
			
			private void btnOkInv_Click(System.Object sender, System.EventArgs e)
			{
				lvwPrivileges.Focus();
				for (int i = 0; i <= this.lvwPrivileges.Items.Count - 1; i++)
				{
					if (StringType.StrLike(this.lvwPrivileges.Items[i].SubItems[2].Text, "*" + this.txtSearch.Text.ToUpper() + "*", CompareMethod.Binary))
					{
						this.lvwPrivileges.Items[i].Selected = true;
						this.lvwPrivileges.Items[i].EnsureVisible();
					}
				}
			}
			
			private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				btnOkInv_Click(null, e);
			}
			
			private void txtSrchGroup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				btnOkGrp_Click(null, e);
			}
			private void lvwPrivileges_DoubleClick(object sender, System.EventArgs e)
			{
				this.btnSelectInv_Click(null, e);
			}
			
			private void lvwPrivilegesGroup_DoubleClick(object sender, System.EventArgs e)
			{
				this.btnSelectGrp_Click(null, e);
			}
			#endregion
				
			#region "Methods"

			private void loadData()
			{
				oAccountPrivilegesFacade = new AccountPrivilegesFacade();
				DataTable dTable = oAccountPrivilegesFacade.getAccounts();
				for (int i = 0; i <= dTable.Rows.Count - 1; i++)
				{
					ListViewItem lst = new ListViewItem(dTable.Rows[i][0].ToString());
					lst.SubItems.Add(dTable.Rows[i][1].ToString());
					lst.SubItems.Add(dTable.Rows[i][3].ToString());
					lst.SubItems.Add(dTable.Rows[i][4].ToString());
					this.lvwPrivileges.Items.Add(lst);
				}
				for (int i = 0; i <= dTable.Rows.Count - 1; i++)
				{
					ListViewItem lst = new ListViewItem(dTable.Rows[i][0].ToString());
					lst.SubItems.Add(dTable.Rows[i][1].ToString());
					lst.SubItems.Add(dTable.Rows[i][3].ToString());
					lst.SubItems.Add(dTable.Rows[i][4].ToString());
					this.lvwPrivilegesGroup.Items.Add(lst);
				}
			}
			
			#endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            
	}
}
