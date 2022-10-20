using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Accounts.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class BrowseAccountUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public BrowseAccountUI()
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
			internal System.Windows.Forms.ColumnHeader ColumnHeader4;
			internal System.Windows.Forms.ColumnHeader ColumnHeader5;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.Button btnClose;
			internal System.Windows.Forms.Button btnOK;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.ListView lvwGuestAccounts;
			private TabControl tabAccounts;
			private TabPage tabPage1;
			internal ListView lvwCompanyAccounts;
			internal ColumnHeader columnHeader1;
			internal ColumnHeader columnHeader2;
			private TabPage tabPage2;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseAccountUI));
                this.lvwGuestAccounts = new System.Windows.Forms.ListView();
                this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnOK = new System.Windows.Forms.Button();
                this.tabAccounts = new System.Windows.Forms.TabControl();
                this.tabPage1 = new System.Windows.Forms.TabPage();
                this.tabPage2 = new System.Windows.Forms.TabPage();
                this.lvwCompanyAccounts = new System.Windows.Forms.ListView();
                this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.tabAccounts.SuspendLayout();
                this.tabPage1.SuspendLayout();
                this.tabPage2.SuspendLayout();
                this.SuspendLayout();
                // 
                // lvwGuestAccounts
                // 
                this.lvwGuestAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader4,
            this.ColumnHeader5});
                this.lvwGuestAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lvwGuestAccounts.Font = new System.Drawing.Font("Arial", 8.25F);
                this.lvwGuestAccounts.FullRowSelect = true;
                this.lvwGuestAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                this.lvwGuestAccounts.HideSelection = false;
                this.lvwGuestAccounts.Location = new System.Drawing.Point(3, 3);
                this.lvwGuestAccounts.Name = "lvwGuestAccounts";
                this.lvwGuestAccounts.Size = new System.Drawing.Size(550, 387);
                this.lvwGuestAccounts.TabIndex = 1;
                this.lvwGuestAccounts.UseCompatibleStateImageBehavior = false;
                this.lvwGuestAccounts.View = System.Windows.Forms.View.Details;
                this.lvwGuestAccounts.DoubleClick += new System.EventHandler(this.lvwAccounts_DoubleClick);
                this.lvwGuestAccounts.SelectedIndexChanged += new System.EventHandler(this.lvwAccounts_SelectedIndexChanged);
                // 
                // ColumnHeader4
                // 
                this.ColumnHeader4.Text = "Account ID";
                this.ColumnHeader4.Width = 82;
                // 
                // ColumnHeader5
                // 
                this.ColumnHeader5.Text = "Guest Name";
                this.ColumnHeader5.Width = 450;
                // 
                // txtSearch
                // 
                this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSearch.ForeColor = System.Drawing.Color.Gray;
                this.txtSearch.Location = new System.Drawing.Point(57, 31);
                this.txtSearch.Name = "txtSearch";
                this.txtSearch.Size = new System.Drawing.Size(514, 20);
                this.txtSearch.TabIndex = 2;
                this.txtSearch.Text = "[ INPUT SEARCH STRING HERE ]";
                this.txtSearch.GotFocus += new System.EventHandler(this.txtSearch_GotFocus);
                this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
                this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
                // 
                // Label1
                // 
                this.Label1.Location = new System.Drawing.Point(12, 33);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(43, 16);
                this.Label1.TabIndex = 3;
                this.Label1.Text = "Search";
                // 
                // btnClose
                // 
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(507, 508);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 4;
                this.btnClose.Text = "&Close";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnOK
                // 
                this.btnOK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnOK.Location = new System.Drawing.Point(437, 508);
                this.btnOK.Name = "btnOK";
                this.btnOK.Size = new System.Drawing.Size(66, 31);
                this.btnOK.TabIndex = 4;
                this.btnOK.Text = "&Ok";
                this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
                // 
                // tabAccounts
                // 
                this.tabAccounts.Controls.Add(this.tabPage1);
                this.tabAccounts.Controls.Add(this.tabPage2);
                this.tabAccounts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.tabAccounts.Location = new System.Drawing.Point(11, 74);
                this.tabAccounts.Name = "tabAccounts";
                this.tabAccounts.SelectedIndex = 0;
                this.tabAccounts.Size = new System.Drawing.Size(564, 420);
                this.tabAccounts.TabIndex = 5;
                // 
                // tabPage1
                // 
                this.tabPage1.Controls.Add(this.lvwGuestAccounts);
                this.tabPage1.Location = new System.Drawing.Point(4, 23);
                this.tabPage1.Name = "tabPage1";
                this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
                this.tabPage1.Size = new System.Drawing.Size(556, 393);
                this.tabPage1.TabIndex = 0;
                this.tabPage1.Text = "Guests";
                this.tabPage1.UseVisualStyleBackColor = true;
                // 
                // tabPage2
                // 
                this.tabPage2.Controls.Add(this.lvwCompanyAccounts);
                this.tabPage2.Location = new System.Drawing.Point(4, 23);
                this.tabPage2.Name = "tabPage2";
                this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
                this.tabPage2.Size = new System.Drawing.Size(556, 393);
                this.tabPage2.TabIndex = 1;
                this.tabPage2.Text = "Company";
                this.tabPage2.UseVisualStyleBackColor = true;
                // 
                // lvwCompanyAccounts
                // 
                this.lvwCompanyAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
                this.lvwCompanyAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lvwCompanyAccounts.Font = new System.Drawing.Font("Arial", 8.25F);
                this.lvwCompanyAccounts.FullRowSelect = true;
                this.lvwCompanyAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                this.lvwCompanyAccounts.HideSelection = false;
                this.lvwCompanyAccounts.Location = new System.Drawing.Point(3, 3);
                this.lvwCompanyAccounts.Name = "lvwCompanyAccounts";
                this.lvwCompanyAccounts.Size = new System.Drawing.Size(550, 387);
                this.lvwCompanyAccounts.TabIndex = 2;
                this.lvwCompanyAccounts.UseCompatibleStateImageBehavior = false;
                this.lvwCompanyAccounts.View = System.Windows.Forms.View.Details;
                this.lvwCompanyAccounts.DoubleClick += new System.EventHandler(this.lvwCompanyAccounts_DoubleClick);
                this.lvwCompanyAccounts.SelectedIndexChanged += new System.EventHandler(this.lvwAccounts_SelectedIndexChanged);
                // 
                // columnHeader1
                // 
                this.columnHeader1.Text = "Account ID";
                this.columnHeader1.Width = 82;
                // 
                // columnHeader2
                // 
                this.columnHeader2.Text = "Company Name";
                this.columnHeader2.Width = 450;
                // 
                // BrowseAccountUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(585, 550);
                this.Controls.Add(this.tabAccounts);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.Label1);
                this.Controls.Add(this.txtSearch);
                this.Controls.Add(this.btnOK);
                this.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "BrowseAccountUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "Browse Account";
                this.Load += new System.EventHandler(this.BrowseAccountUI_Load);
                this.tabAccounts.ResumeLayout(false);
                this.tabPage1.ResumeLayout(false);
                this.tabPage2.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();

			}
			
			#endregion
			
			private void txtSearch_GotFocus(object sender, System.EventArgs e)
			{
				if (this.txtSearch.Text == "[ Input Search String Here ]")
				{
					this.txtSearch.Text = "";
				}
			}
			
			
			private MySqlConnection localConnection;
			private string mMode;
			private TextBox mAccountId;
			private TextBox mName;
			public BrowseAccountUI(MySqlConnection connection, string mode, TextBox txtAccountId, TextBox txtName)
			{
				InitializeComponent();
				localConnection = connection;
				mMode = mode;
				mAccountId = txtAccountId;
				mName = txtName;
			}
			
			private Company oCompany;
			private CompanyFacade oCompanyFacade;
			
			private Guest oGuest;
			private GuestFacade oGuestFacade;
			private void BrowseAccountUI_Load(object sender, System.EventArgs e)
			{
				//>> load Company Accounts
				oCompanyFacade = new CompanyFacade();
				oCompany = new Company();
				oCompany = oCompanyFacade.getCompanyAccountsData();

				LoadToListView(oCompany.Tables[0], this.lvwCompanyAccounts);

				//>> load Guest Accounts
				oGuestFacade = new GuestFacade();
				oGuest = new Guest();
				oGuest = oGuestFacade.getGuests();

				LoadToListView(oGuest.Tables[0], this.lvwGuestAccounts);

				switch (mMode.ToUpper())
				{
					case "COMPANY":

						this.tabAccounts.SelectedIndex = 1;
						break;
					case "GUESTS":

						this.tabAccounts.SelectedIndex = 0;
						break;
				}
			}
			
			private void LoadToListView(DataTable dtAccount, ListView lvw)
			{
				DataRow dtRow;

				lvw.Items.Clear();
				foreach (DataRow tempLoopVar_dtRow in dtAccount.Rows)
				{
					dtRow = tempLoopVar_dtRow;
					
					ListViewItem lst = null;
					switch (dtAccount.TableName.ToUpper())
					{
						case "GUESTS":
							
							lst = new ListViewItem(dtRow["AccountID"].ToString());
                            lst.SubItems.Add(dtRow["LastName"] + ", " + dtRow["FirstName"]);
							break;
							
						case "COMPANYACCOUNTS":
							
							lst = new ListViewItem(dtRow["companyid"].ToString());
							lst.SubItems.Add(dtRow["CompanyName"].ToString());
							break;
							
					}

					lvw.Items.Add(lst);
				}
				
			}
			
			private void lvwAccounts_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				ListView lvwSender = (ListView)sender;

				try
				{
					this.mAccountId.Text = lvwSender.SelectedItems[0].Text;
					this.mName.Text = lvwSender.SelectedItems[0].SubItems[1].Text;
					
				}
				catch (Exception)
				{
					
				}
			}
			
			private void btnOK_Click(System.Object sender, System.EventArgs e)
			{
				if (this.mAccountId.Text != "")
				{
					this.Close();
				}
				else
				{
                    MessageBox.Show("Please select an item on the list.", "Void Folio Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			
			private void btnClose_Click(System.Object sender, System.EventArgs e)
			{
				this.mAccountId.Text = "";
				this.mName.Text = "";

				this.Close();
			}
			
			private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{

                    if (tabAccounts.SelectedTab == tabPage1)
                    {
                        this.lvwGuestAccounts.Focus();

                        int _startRow = 0;
                        try
                        {
                            _startRow = this.lvwGuestAccounts.SelectedIndices[0];
                        }
                        catch
                        {
                            _startRow = 0;
                        }

                        DeselectItem(lvwGuestAccounts);

                        for (int i = _startRow + 1; i <= this.lvwGuestAccounts.Items.Count - 1; i++)
                        {
                            if (this.lvwGuestAccounts.Items[i].SubItems[1].Text.Contains(this.txtSearch.Text.ToUpper())) // || this.lvwGuestAccounts.Items[i].Text.Contains(this.txtSearch.Text.ToUpper()))
                            {
                                this.tabAccounts.SelectedIndex = 0;

                                this.lvwGuestAccounts.Focus();
                                this.lvwGuestAccounts.Items[i].Selected = true;
                                this.lvwGuestAccounts.Items[i].EnsureVisible();

                                this.txtSearch.Focus();
                                return;
                            }

                            if (i == lvwGuestAccounts.Items.Count - 1)
                            {
                                MessageBox.Show("Find reached the ending point of the search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        // >> if not found in Guest, look in Company Accounts
                        this.lvwCompanyAccounts.Focus();

                        int _startRow = 0;
                        try
                        {
                            _startRow = this.lvwCompanyAccounts.SelectedIndices[0];
                        }
                        catch
                        {
                            _startRow = 0;
                        }

                        DeselectItem(lvwCompanyAccounts);

                        for (int i = _startRow + 1; i <= this.lvwCompanyAccounts.Items.Count - 1; i++)
                        {
                            if (this.lvwCompanyAccounts.Items[i].SubItems[1].Text.Contains(this.txtSearch.Text.ToUpper())) // || this.lvwCompanyAccounts.Items[i].Text.Contains(this.txtSearch.Text.ToUpper()))
                            {
                                this.tabAccounts.SelectedIndex = 1;

                                this.lvwCompanyAccounts.Focus();
                                this.lvwCompanyAccounts.Items[i].Selected = true;
                                this.lvwCompanyAccounts.Items[i].EnsureVisible();

                                this.txtSearch.Focus();
                                return;
                            }

                            if (i == lvwCompanyAccounts.Items.Count - 1)
                            {
                                MessageBox.Show("Find reached the ending point of the search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
				}
			}
			
			private void DeselectItem(ListView lvw)
			{
                //for (int i = 0; i <= this.lvwGuestAccounts.Items.Count - 1; i++)
                //{
                //    this.lvwGuestAccounts.Items[i].Selected = false;
                //}
                lvw.SelectedIndices.Clear();
			}
			
			private void mnuOk_Click(System.Object sender, System.EventArgs e)
			{
				btnOK_Click(sender, e);
			}
			
			private void mnuSearch_Click(System.Object sender, System.EventArgs e)
			{
				this.txtSearch.Focus();
			}
			
			private void mnuClose_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
			
			private void lvwAccounts_DoubleClick(object sender, System.EventArgs e)
			{
				btnOK_Click(sender, e);
			}

			private void lvwCompanyAccounts_DoubleClick(object sender, EventArgs e)
			{
				btnOK_Click(sender, e);
			}

            private void txtSearch_TextChanged(object sender, EventArgs e)
            {
                DeselectItem(lvwCompanyAccounts);
                DeselectItem(lvwGuestAccounts);
            }
			
		}
	}
}
