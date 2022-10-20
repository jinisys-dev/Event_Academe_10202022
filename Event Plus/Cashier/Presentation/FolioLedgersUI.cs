using System.Drawing;
using System.Globalization;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.Reports.Presentation;

namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class FolioLedgersUI : Jinisys.Hotel.UIFramework.TransactionUI
		{
			
			#region "Instantation/ Variable Declarations"
			private MySqlConnection localConnection;
			private ListviewHelper listViewHelper = new ListviewHelper();
			private FolioFacade oFolioFACADE = new FolioFacade();
			private GuestFacade oGuestFACADE = new GuestFacade();
			private ScheduleFacade oScheduleFACADE = new ScheduleFacade();
			private FolioTransactionFacade oFolioTransFACADE = new FolioTransactionFacade();
			private TextBox txtGuest;
			internal Button btnClose;
			internal Label label3;
			internal Label lblHighBalance;
			internal Button btnCreateLetter;
			private C1.Win.C1FlexGrid.C1FlexGrid grdIndividual;
			private C1.Win.C1FlexGrid.C1FlexGrid grdGroup;
			internal Label label4;
			private GroupBox groupBox1;
			private TextBox txtFolioID;
			#endregion

			#region " Windows Form Designer generated code "
			
			public FolioLedgersUI()
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
			internal System.Windows.Forms.TabPage TabPage1;
			internal System.Windows.Forms.TabPage tabGroup;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.TabControl tabFolioLedgerList;
			internal System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.TextBox txtSearchGroup;
			internal System.Windows.Forms.Button btnViewLedger;
			internal System.Windows.Forms.Button btnCheckOut;
			internal System.Windows.Forms.Label Label7;
			internal System.Windows.Forms.Label lblCheckout;
			internal System.Windows.Forms.ContextMenu popUpMenu;
			internal System.Windows.Forms.MenuItem MenuItem2;
			internal System.Windows.Forms.MenuItem mnuViewLedger;
			internal System.Windows.Forms.MenuItem mnuCheckOut;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolioLedgersUI));
                this.tabFolioLedgerList = new System.Windows.Forms.TabControl();
                this.TabPage1 = new System.Windows.Forms.TabPage();
                this.grdIndividual = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.tabGroup = new System.Windows.Forms.TabPage();
                this.grdGroup = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.txtSearchGroup = new System.Windows.Forms.TextBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.lblHighBalance = new System.Windows.Forms.Label();
                this.Label7 = new System.Windows.Forms.Label();
                this.lblCheckout = new System.Windows.Forms.Label();
                this.btnCheckOut = new System.Windows.Forms.Button();
                this.btnViewLedger = new System.Windows.Forms.Button();
                this.popUpMenu = new System.Windows.Forms.ContextMenu();
                this.mnuViewLedger = new System.Windows.Forms.MenuItem();
                this.MenuItem2 = new System.Windows.Forms.MenuItem();
                this.mnuCheckOut = new System.Windows.Forms.MenuItem();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnCreateLetter = new System.Windows.Forms.Button();
                this.label4 = new System.Windows.Forms.Label();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.tabFolioLedgerList.SuspendLayout();
                this.TabPage1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdIndividual)).BeginInit();
                this.tabGroup.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).BeginInit();
                this.SuspendLayout();
                // 
                // tabFolioLedgerList
                // 
                this.tabFolioLedgerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.tabFolioLedgerList.Controls.Add(this.TabPage1);
                this.tabFolioLedgerList.Controls.Add(this.tabGroup);
                this.tabFolioLedgerList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.tabFolioLedgerList.Location = new System.Drawing.Point(9, 49);
                this.tabFolioLedgerList.Name = "tabFolioLedgerList";
                this.tabFolioLedgerList.SelectedIndex = 0;
                this.tabFolioLedgerList.Size = new System.Drawing.Size(830, 551);
                this.tabFolioLedgerList.TabIndex = 0;
                this.tabFolioLedgerList.TabIndexChanged += new System.EventHandler(this.tabFolioLedgerList_TabIndexChanged);
                this.tabFolioLedgerList.SelectedIndexChanged += new System.EventHandler(this.tabFolioLedgerList_SelectedIndexChanged);
                // 
                // TabPage1
                // 
                this.TabPage1.Controls.Add(this.grdIndividual);
                this.TabPage1.Controls.Add(this.txtSearch);
                this.TabPage1.Controls.Add(this.Label1);
                this.TabPage1.Location = new System.Drawing.Point(4, 23);
                this.TabPage1.Name = "TabPage1";
                this.TabPage1.Size = new System.Drawing.Size(822, 524);
                this.TabPage1.TabIndex = 0;
                this.TabPage1.Text = "Individual";
                // 
                // grdIndividual
                // 
                this.grdIndividual.AllowEditing = false;
                this.grdIndividual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.grdIndividual.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
                this.grdIndividual.ColumnInfo = resources.GetString("grdIndividual.ColumnInfo");
                this.grdIndividual.ExtendLastCol = true;
                this.grdIndividual.Font = new System.Drawing.Font("Arial", 8.25F);
                this.grdIndividual.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
                this.grdIndividual.Location = new System.Drawing.Point(10, 48);
                this.grdIndividual.Name = "grdIndividual";
                this.grdIndividual.Rows.DefaultSize = 17;
                this.grdIndividual.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grdIndividual.Size = new System.Drawing.Size(805, 465);
                this.grdIndividual.StyleInfo = resources.GetString("grdIndividual.StyleInfo");
                this.grdIndividual.TabIndex = 2;
                this.grdIndividual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdIndividual_KeyPress);
                this.grdIndividual.DoubleClick += new System.EventHandler(this.grdIndividual_DoubleClick);
                this.grdIndividual.RowColChange += new System.EventHandler(this.grdIndividual_RowColChange);
                // 
                // txtSearch
                // 
                this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSearch.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtSearch.Location = new System.Drawing.Point(117, 15);
                this.txtSearch.Name = "txtSearch";
                this.txtSearch.Size = new System.Drawing.Size(698, 20);
                this.txtSearch.TabIndex = 1;
                this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
                // 
                // Label1
                // 
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label1.Location = new System.Drawing.Point(7, 17);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(106, 15);
                this.Label1.TabIndex = 6;
                this.Label1.Text = "Enter Search String";
                // 
                // tabGroup
                // 
                this.tabGroup.Controls.Add(this.grdGroup);
                this.tabGroup.Controls.Add(this.txtSearchGroup);
                this.tabGroup.Controls.Add(this.Label2);
                this.tabGroup.Location = new System.Drawing.Point(4, 23);
                this.tabGroup.Name = "tabGroup";
                this.tabGroup.Size = new System.Drawing.Size(822, 524);
                this.tabGroup.TabIndex = 1;
                this.tabGroup.Text = "Group";
                // 
                // grdGroup
                // 
                this.grdGroup.AllowEditing = false;
                this.grdGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.grdGroup.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
                this.grdGroup.ColumnInfo = resources.GetString("grdGroup.ColumnInfo");
                this.grdGroup.ExtendLastCol = true;
                this.grdGroup.Font = new System.Drawing.Font("Arial", 8.25F);
                this.grdGroup.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
                this.grdGroup.Location = new System.Drawing.Point(10, 48);
                this.grdGroup.Name = "grdGroup";
                this.grdGroup.Rows.DefaultSize = 17;
                this.grdGroup.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grdGroup.Size = new System.Drawing.Size(805, 468);
                this.grdGroup.StyleInfo = resources.GetString("grdGroup.StyleInfo");
                this.grdGroup.TabIndex = 4;
                this.grdGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdGroup_KeyPress);
                this.grdGroup.DoubleClick += new System.EventHandler(this.grdGroup_DoubleClick);
                this.grdGroup.RowColChange += new System.EventHandler(this.grdGroup_RowColChange);
                // 
                // txtSearchGroup
                // 
                this.txtSearchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtSearchGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSearchGroup.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtSearchGroup.Location = new System.Drawing.Point(117, 15);
                this.txtSearchGroup.Name = "txtSearchGroup";
                this.txtSearchGroup.Size = new System.Drawing.Size(698, 20);
                this.txtSearchGroup.TabIndex = 3;
                this.txtSearchGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchGroup_KeyPress);
                // 
                // Label2
                // 
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label2.Location = new System.Drawing.Point(7, 17);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(107, 15);
                this.Label2.TabIndex = 10;
                this.Label2.Text = "Enter Search String";
                // 
                // label3
                // 
                this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.label3.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label3.Location = new System.Drawing.Point(762, 33);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(77, 14);
                this.label3.TabIndex = 12;
                this.label3.Text = "High Balance";
                // 
                // lblHighBalance
                // 
                this.lblHighBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.lblHighBalance.BackColor = System.Drawing.Color.White;
                this.lblHighBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblHighBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblHighBalance.ForeColor = System.Drawing.Color.Red;
                this.lblHighBalance.Location = new System.Drawing.Point(722, 31);
                this.lblHighBalance.Name = "lblHighBalance";
                this.lblHighBalance.Size = new System.Drawing.Size(29, 18);
                this.lblHighBalance.TabIndex = 11;
                this.lblHighBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // Label7
                // 
                this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.Label7.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label7.Location = new System.Drawing.Point(606, 33);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(110, 14);
                this.Label7.TabIndex = 10;
                this.Label7.Text = "Today\'s Check Out";
                // 
                // lblCheckout
                // 
                this.lblCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.lblCheckout.BackColor = System.Drawing.Color.PaleGreen;
                this.lblCheckout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblCheckout.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblCheckout.Location = new System.Drawing.Point(566, 31);
                this.lblCheckout.Name = "lblCheckout";
                this.lblCheckout.Size = new System.Drawing.Size(29, 18);
                this.lblCheckout.TabIndex = 9;
                this.lblCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // btnCheckOut
                // 
                this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCheckOut.Enabled = false;
                this.btnCheckOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCheckOut.Location = new System.Drawing.Point(682, 610);
                this.btnCheckOut.Name = "btnCheckOut";
                this.btnCheckOut.Size = new System.Drawing.Size(85, 31);
                this.btnCheckOut.TabIndex = 6;
                this.btnCheckOut.Text = "&Check Out";
                this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
                // 
                // btnViewLedger
                // 
                this.btnViewLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnViewLedger.Enabled = false;
                this.btnViewLedger.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnViewLedger.Location = new System.Drawing.Point(591, 610);
                this.btnViewLedger.Name = "btnViewLedger";
                this.btnViewLedger.Size = new System.Drawing.Size(85, 31);
                this.btnViewLedger.TabIndex = 5;
                this.btnViewLedger.Text = "&View Ledger";
                this.btnViewLedger.Click += new System.EventHandler(this.btnViewLedger_Click);
                // 
                // popUpMenu
                // 
                this.popUpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuViewLedger,
            this.MenuItem2,
            this.mnuCheckOut});
                // 
                // mnuViewLedger
                // 
                this.mnuViewLedger.DefaultItem = true;
                this.mnuViewLedger.Index = 0;
                this.mnuViewLedger.Text = "&View Ledger";
                this.mnuViewLedger.Click += new System.EventHandler(this.mnuViewLedger_Click);
                // 
                // MenuItem2
                // 
                this.MenuItem2.Index = 1;
                this.MenuItem2.Text = "-";
                // 
                // mnuCheckOut
                // 
                this.mnuCheckOut.Index = 2;
                this.mnuCheckOut.Text = "&Check Out";
                this.mnuCheckOut.Click += new System.EventHandler(this.mnuCheckOut_Click);
                // 
                // btnClose
                // 
                this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(773, 610);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 7;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnCreateLetter
                // 
                this.btnCreateLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnCreateLetter.Enabled = false;
                this.btnCreateLetter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCreateLetter.Location = new System.Drawing.Point(9, 610);
                this.btnCreateLetter.Name = "btnCreateLetter";
                this.btnCreateLetter.Size = new System.Drawing.Size(85, 31);
                this.btnCreateLetter.TabIndex = 8;
                this.btnCreateLetter.Text = "Create &Letter";
                this.btnCreateLetter.Click += new System.EventHandler(this.btnCreateLetter_Click);
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label4.Location = new System.Drawing.Point(14, 11);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(163, 22);
                this.label4.TabIndex = 13;
                this.label4.Text = "Folio Ledgers List";
                // 
                // groupBox1
                // 
                this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox1.Location = new System.Drawing.Point(14, 36);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(540, 5);
                this.groupBox1.TabIndex = 14;
                this.groupBox1.TabStop = false;
                // 
                // FolioLedgersUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(848, 647);
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.lblHighBalance);
                this.Controls.Add(this.btnCreateLetter);
                this.Controls.Add(this.Label7);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.lblCheckout);
                this.Controls.Add(this.btnViewLedger);
                this.Controls.Add(this.btnCheckOut);
                this.Controls.Add(this.tabFolioLedgerList);
                this.Name = "FolioLedgersUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Folio Ledgers List";
                this.Activated += new System.EventHandler(this.FolioLedgersUI_Activated);
                this.Load += new System.EventHandler(this.FolioLedgerUI_Load);
                this.tabFolioLedgerList.ResumeLayout(false);
                this.TabPage1.ResumeLayout(false);
                this.TabPage1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdIndividual)).EndInit();
                this.tabGroup.ResumeLayout(false);
                this.tabGroup.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

			}
			
			#endregion
			
			private ListViewItemComparer lvwItemComparer = new ListViewItemComparer();
			
			public FolioLedgersUI(MySqlConnection connection)
			{
				InitializeComponent();
				localConnection = connection;
			}
			public FolioLedgersUI(MySqlConnection connection, TextBox txtG, TextBox txtF)
			{
				InitializeComponent();
				localConnection = connection;
				txtGuest = txtG;
				txtFolioID = txtF;
			}
			
			private void FolioLedgerUI_Load(object sender, System.EventArgs e)
			{
				LoadData();
                grdIndividual.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 0);
                grdGroup.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 0);

                //jlo 6-10-10 emm only config
                if (ConfigVariables.gIsEMMOnly == "true")
                {
                    this.tabFolioLedgerList.Controls.Remove(this.TabPage1);
                }
                //jlo
			}
			
			#region "---------------- M E T H O D S --------------------------"
			
			public void LoadData()
			{
				LoadIndividualGuests();
				LoadCompanyList();
			}
			
			public void LoadIndividualGuests()
			{
				int expectedCheckoutCount = 0;
				int highBalanceCount = 0;
				DataTable dtGuest = new DataTable();
				oFolioFACADE = new FolioFacade();
				oFolioTransFACADE = new FolioTransactionFacade();
				//Dim dtRow As DataRow
				dtGuest = oFolioFACADE.GetFolioLedgers("PERSONAL");
				int curProgress = 0;
				ProgressForm progress = new ProgressForm();
				if (dtGuest.Rows.Count > 0)
				{
					int temp_int = dtGuest.Rows.Count;
					progress = new ProgressForm(temp_int, "Loading Guest Ledgers ......");
					progress.Height = 27;
					progress.Show();
				}

				this.grdIndividual.Rows.Count = dtGuest.Rows.Count + 1;
				int i = 1;
				oGuestFACADE = new GuestFacade();
				DataRow drGuest;
				foreach (DataRow tempLoopVar_drGuest in dtGuest.Rows)
				{
					
					drGuest = tempLoopVar_drGuest;

					
					// ------------------------ ROOM ID -------------------------
                    string tempFolioId = "";
                    
                        tempFolioId = drGuest["FolioId"].ToString();
                    
						//Folio _oFolio = oFolioFACADE.GetFolio(tempFolioId);
						Folio _oFolio = new Folio();
						_oFolio.FolioID = tempFolioId;
						_oFolio.FolioType = "INDIVIDUAL";
						_oFolio.CreateSubFolio();

                        //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                        //used a constant parameter to avoid possible error/dependencies, no time to check
                    string currentRoom = oFolioFACADE.GetCurrentRoomOccupied(tempFolioId, "INDIVIDUAL");


					//ListViewItem lst = new ListViewItem(currentRoom);
					this.grdIndividual.SetData(i, 0, currentRoom);

					// ------------------------ GUEST NAME -------------------------
					//lst.SubItems.Add(drGuest["GuestName"].ToString());
					this.grdIndividual.SetData(i, 1, drGuest["GuestName"].ToString());
					// ------------------------ FOLIO ID -------------------------
					//lst.SubItems.Add(tempFolioId);
					this.grdIndividual.SetData(i, 2, tempFolioId);

					// ------------------------ TOTAL CHARGES -------------------------
					decimal charges = 0;
					foreach (SubFolio subF in _oFolio.SubFolios)
					{
						subF.Ledger = oFolioFACADE.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);

						charges += subF.Ledger.Charges;
					}

					//lst.SubItems.Add(charges.ToString("N"));
					this.grdIndividual.SetData(i, 3, charges);

					// ------------------------ TOTAL PAYMENT -------------------------
					decimal payment = 0;
					foreach (SubFolio subF in _oFolio.SubFolios)
					{
						subF.Ledger = oFolioFACADE.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);

						payment += subF.Ledger.PayCash + subF.Ledger.PayCard + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded;
					}

					//lst.SubItems.Add(payment.ToString("N"));
					this.grdIndividual.SetData(i, 4, payment);

					// ------------------------ BALANCE -------------------------
					decimal balance = charges - payment;
					//lst.SubItems.Add(balance.ToString("N"));
					this.grdIndividual.SetData(i, 5, balance);

					// ------------------------ ARRIVAL -------------------------
					//lst.SubItems.Add(string.Format("{0:dd-MMM-yyyy}",DateTime.Parse(drGuest["FromDate"].ToString())));
					this.grdIndividual.SetData(i, 6, drGuest["FromDate"].ToString());
					// ------------------------ DEPARTURE -------------------------
					//lst.SubItems.Add(string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(drGuest["ToDate"].ToString())));
					this.grdIndividual.SetData(i, 7, drGuest["ToDate"].ToString());
					// ------------------------ No Of Guests -------------------------
					//lst.SubItems.Add(drGuest["NoOfGuest"].ToString());
					this.grdIndividual.SetData(i, 8, drGuest["NoOfGuest"].ToString());

					// gets MASTER FOLIO - GROUP NAME
					string masterFolioId = drGuest["MasterFolio"].ToString();
					string groupName = "";
					if (masterFolioId != "" && masterFolioId != "0")
					{
						Folio mFolio = oFolioFACADE.GetFolio(masterFolioId);
						groupName = mFolio.GroupName;
					}
					//lst.SubItems.Add(groupName);
					this.grdIndividual.SetData(i, 9, groupName);


					// EXPECTED CHECK OUT --------------------------------------------
					DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
                   
                    //this.lvwIndividual.Items.Add(lst);
                    DateTime _toDate = DateTime.Parse(drGuest["ToDate"].ToString());
					if (_toDate.ToString("yyyy-MM-dd") == _auditDate.ToString("yyyy-MM-dd"))
					{
						//lst.BackColor = System.Drawing.Color.PaleGreen;
						this.grdIndividual.Rows[i].Style = this.grdIndividual.Styles["expectedCheckOut"];
						expectedCheckoutCount++;
                    }

                    // get Threshold VALUE from db
                    if (balance >= decimal.Parse(drGuest["threshold_value"].ToString()) &&
                        balance > 0)
                    {
                        //lst.ForeColor = System.Drawing.Color.Red;
                        //this.grdIndividual.Rows[i].Style = this.grdIndividual.Styles["highBalance"];
                        this.grdIndividual.Rows[i].StyleNew.ForeColor = Color.Red;
                        highBalanceCount++;
                    }

					i++;
					curProgress++;
					progress.updateProgress(curProgress);
				}
				
				//progress.Close()
				this.lblCheckout.Text = expectedCheckoutCount.ToString();
				this.lblHighBalance.Text = highBalanceCount.ToString();
			}
			
			public void LoadCompanyList()
			{
				highBalanceComp = 0;

				DataTable dtCompany = new DataTable();
				oFolioFACADE = new FolioFacade();
				oFolioTransFACADE = new FolioTransactionFacade();
				//Dim dtRow As DataRow
                dtCompany = oFolioFACADE.GetFolioLedgers("GROUP");

				this.grdGroup.Rows.Count = dtCompany.Rows.Count + 1;
				int i = 1;
				foreach (DataRow drComp in dtCompany.Rows)
				{
					string _folioId = drComp["FolioId"].ToString();

					// ------------------------ GROUP NAME -------------------------
					//ListViewItem lst = new ListViewItem(drComp["GroupName"].ToString());
					this.grdGroup.SetData(i, 0, drComp["GroupName"].ToString());

					// ------------------------ COMPANY -------------------------
					//lst.SubItems.Add(drComp["CompanyName"].ToString());
					this.grdGroup.SetData(i, 1, drComp["CompanyName"].ToString());

					// ------------------------ FOLIO ID -------------------------
					//lst.SubItems.Add(drComp["FolioId"].ToString());
					this.grdGroup.SetData(i, 2, _folioId);

					this.grdGroup.SetData(i, 3, "");
					this.grdGroup.SetData(i, 4, "");
					this.grdGroup.SetData(i, 5, "");
					this.grdGroup.SetData(i, 6, "");
					this.grdGroup.SetData(i, 7, drComp["FromDate"].ToString());
                    this.grdGroup.SetData(i, 8, drComp["ToDate"].ToString());
                    this.grdGroup.SetData(i, 9, "");

					//lst.SubItems.Add("");
					//lst.SubItems.Add("");
					//lst.SubItems.Add("");
					//lst.SubItems.Add("");
					//lst.SubItems.Add("");
					getChildFolios(_folioId, i);
					
					//this.lvwGroup.Items.Add(lst);
					i++;
				}

				int highBal = int.Parse(this.lblHighBalance.Text) + highBalanceComp;
				this.lblHighBalance.Text = highBal.ToString();
			}

			int highBalanceComp = 0;
			private Folio oGroupFolio;
			private void getChildFolios(string GroupFolioId, int pRowIndex)
			{
				oFolioFACADE = new FolioFacade();
				oGroupFolio = oFolioFACADE.GetFolio(GroupFolioId);

				oGroupFolio.ChildFolios = oFolioFACADE.GetChildFolios(GroupFolioId);

				string rooms = "";
				int totalGuest = 0;

				decimal totalCharges = 0;
				decimal totalPayments = 0;
				

				foreach (Folio childFolio in oGroupFolio.ChildFolios)
				{
                    //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                    //used a constant parameter to avoid possible error/dependencies, no time to check
					rooms += oFolioFACADE.GetCurrentRoomOccupied(childFolio.FolioID, "INDIVIDUAL") + "-";
					totalGuest++;

					childFolio.CreateSubFolio();
					foreach (SubFolio childSubF in childFolio.SubFolios)
					{
                        //if (childSubF.SubFolio_Renamed == "B")
                        //{
                            childSubF.Ledger = oFolioFACADE.GetFolioLedger(childSubF.Folio.FolioID, childSubF.SubFolio_Renamed);
                            totalCharges += childSubF.Ledger.Charges;
                            totalPayments += childSubF.Ledger.PayCash + childSubF.Ledger.PayCard + childSubF.Ledger.PayGiftCheque + childSubF.Ledger.BalanceForwarded + childSubF.Ledger.PayCheque;
                        //}
					}

				}

				//lvwItem.SubItems[3].Text = rooms;
				this.grdGroup.SetData(pRowIndex, 3, rooms);

				
				//lvwItem.SubItems[7].Text = totalGuest.ToString();
                //>>TOTAL GUEST COLUMN
				this.grdGroup.SetData(pRowIndex, 9, totalGuest);

				oGroupFolio.CreateSubFolio();
				foreach (SubFolio parentSubF in oGroupFolio.SubFolios)
                {
                    if (parentSubF.SubFolio_Renamed == "A")
                    {
                        try
                        {
                            parentSubF.Ledger = oFolioFACADE.GetFolioLedger(parentSubF.Folio.FolioID, parentSubF.SubFolio_Renamed);

                            totalCharges += parentSubF.Ledger.Charges;
                            totalPayments += parentSubF.Ledger.PayCash + parentSubF.Ledger.PayCard + parentSubF.Ledger.PayGiftCheque + parentSubF.Ledger.BalanceForwarded + parentSubF.Ledger.PayCheque;
                        }
                        catch { }
                    }
				}
				decimal balance = totalCharges - totalPayments;

                if (oGroupFolio.CompanyID.StartsWith("G"))
                {
                    // get Threshold VALUE from db
                    CompanyFacade oCompanyFacade = new CompanyFacade();
                    Company oCompany = new Company();
                    oCompany = oCompanyFacade.getCompanyAccount(oGroupFolio.CompanyID);
                    if (balance > System.Convert.ToDecimal(oCompany.THRESHOLD_VALUE))
                    {
                        //lvwItem.ForeColor = System.Drawing.Color.Red;
                        this.grdGroup.Rows[pRowIndex].Style = this.grdGroup.Styles["highBalance"];
                        highBalanceComp++;
                    }
                }
                else
                {
                    oGuestFACADE = new GuestFacade();
                    Guest oGuest = new Guest();
                    oGuest = oGuestFACADE.getGuestRecord(oGroupFolio.CompanyID);
                    if (balance > System.Convert.ToDecimal(oGuest.THRESHOLD_VALUE))
                    {
                        //lvwItem.ForeColor = System.Drawing.Color.Red;
                        this.grdGroup.Rows[pRowIndex].Style = this.grdGroup.Styles["highBalance"];
                        highBalanceComp++;
                    }
                }

				//lvwItem.SubItems[4].Text = totalCharges.ToString("N");
				this.grdGroup.SetData(pRowIndex, 4, totalCharges);
				//lvwItem.SubItems[5].Text = totalPayments.ToString("N");
				this.grdGroup.SetData(pRowIndex, 5, totalPayments);
				//lvwItem.SubItems[6].Text = balance.ToString("N");
				this.grdGroup.SetData(pRowIndex, 6, balance);

			}
			
			private void txtSearch_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == 13)
				{
					int _row = this.grdIndividual.Row;
					if (_row < 1) 
						return;

					_row++; // to advance cursor to next record
					for (int i = _row; i < this.grdIndividual.Rows.Count; i++)
					{
						if (this.grdIndividual.GetDataDisplay(i, 0).ToUpper().Contains(this.txtSearch.Text) ||
							this.grdIndividual.GetDataDisplay(i, 1).ToUpper().Contains(this.txtSearch.Text) ||
							this.grdIndividual.GetDataDisplay(i, 2).ToUpper().Contains(this.txtSearch.Text))

						{
							this.grdIndividual.Row = i;
							return;
						}
					}

					for (int i = 1; i < this.grdIndividual.Rows.Count; i++)
					{
						if (this.grdIndividual.GetDataDisplay(i, 0).ToUpper().Contains(this.txtSearch.Text) ||
							this.grdIndividual.GetDataDisplay(i, 1).ToUpper().Contains(this.txtSearch.Text) ||
							this.grdIndividual.GetDataDisplay(i, 2).ToUpper().Contains(this.txtSearch.Text))
						{
							this.grdIndividual.Row = i;
							return;
						}
					}

					MessageBox.Show("No matching record found.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			}


			#endregion

			private void txtSearchGroup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == 13)
				{
					int _row = this.grdGroup.Row;
					if (_row < 1)
						return;

					_row++; // to advance cursor to next record
					for (int i = _row; i < this.grdGroup.Rows.Count; i++)
					{
						if (this.grdGroup.GetDataDisplay(i, 0).ToUpper().Contains(this.txtSearchGroup.Text) ||
							this.grdGroup.GetDataDisplay(i, 1).ToUpper().Contains(this.txtSearchGroup.Text) ||
							this.grdGroup.GetDataDisplay(i, 2).ToUpper().Contains(this.txtSearchGroup.Text))
						{
							this.grdGroup.Row = i;
							return;
						}
					}

					for (int i = 1; i < this.grdGroup.Rows.Count; i++)
					{
						if (this.grdGroup.GetDataDisplay(i, 0).ToUpper().Contains(this.txtSearchGroup.Text) ||
							this.grdGroup.GetDataDisplay(i, 1).ToUpper().Contains(this.txtSearchGroup.Text) ||
							this.grdGroup.GetDataDisplay(i, 2).ToUpper().Contains(this.txtSearchGroup.Text))
						{
							this.grdGroup.Row = i;
							return;
						}
					}

					MessageBox.Show("No matching record found.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			
			private void tabFolioLedgerList_TabIndexChanged(object sender, System.EventArgs e)
			{
				this.Text = "Folio Legers List - " + this.tabFolioLedgerList.SelectedTab.Text;
			}
			
			private void btnViewLedger_Click(System.Object sender, System.EventArgs e)
			{
				try
				{
					if (this.tabFolioLedgerList.SelectedIndex == 0)
					{
						int _row = this.grdIndividual.Row;

						if (_row <= 0)
							return;

						try
						{
							string folioId = this.grdIndividual.GetDataDisplay(_row, 2);
							string roomNo = this.grdIndividual.GetDataDisplay(_row, 0);

							FolioFacade _oFolioFacade = new FolioFacade();
							Folio _oFolio = new Folio();
							_oFolio = _oFolioFacade.GetFolio(folioId);

							if (_oFolio.FolioType == "JOINER")
							{
								DialogResult rsp = MessageBox.Show("Guest type is joiner.\r\n\r\nShow Master Folio information?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
								if (rsp == DialogResult.No)
								{
									return; // exit is no
								}
								else
								{
									// proceed if want to view MasterFolio Info
									folioId = _oFolio.MasterFolio;
								}
							}
							


							FolioLedgerUI LedgerUI = new FolioLedgerUI(folioId, roomNo);

							LedgerUI.MdiParent = this.MdiParent;
							LedgerUI.Show();

							this.Close();
						}
						catch (Exception ex)
						{
							MessageBox.Show("Transaction failed.\r\n\r\nError message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}

					else
					{

						int _row = this.grdGroup.Row;
						if (_row <= 0)
							return;


						try
						{
							FolioLedgerUI LedgerUI = new FolioLedgerUI(this.grdGroup.GetDataDisplay(_row, 2));

							LedgerUI.MdiParent = this.MdiParent;
							LedgerUI.Show();

							this.Close();
						}
						catch (Exception ex)
						{
							MessageBox.Show("Transaction failed.\r\nError description: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//try
				//{
				//    if (this.tabFolioLedgerList.SelectedIndex == 0)
				//    {
				//        this.grdIndividual_DoubleClick(sender, e);
				//    }
				//    else
				//    {
				//        this.grdGroup_DoubleClick(sender, e);
				//    }
				//}
				//catch (ArgumentOutOfRangeException)
				//{
				//    MessageBox.Show("Please select an item on the list.", "Folio Ledgers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				//}
				//catch (Exception ex)
				//{
				//    MessageBox.Show(ex.Message, " btnViewLedger_Click Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				//}
			}
			
			
			//private void lvwGroup_DoubleClick(object sender, System.EventArgs e)
			//{
			//    if (this.lvwGroup.SelectedItems.Count <= 0)
			//    {
			//        return;
			//    }

			//    try
			//    {
			//        FolioLedgerUI LedgerUI = new FolioLedgerUI(this.lvwGroup.SelectedItems[0].SubItems[2].Text);

			//        LedgerUI.MdiParent = this.MdiParent;
			//        LedgerUI.Show();

			//        this.Close();
			//    }
			//    catch (Exception ex)
			//    {
			//        MessageBox.Show("Transaction failed.\r\nError description: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//    }
				
			//}
			
			private void btnCheckOut_Click(System.Object sender, System.EventArgs e)
			{
				//dis one
				try
				{
					CheckOutUI CheckOutUI;
					int _row = this.grdGroup.Row;
					if (_row <= 1)
						return;
					
					if (this.tabFolioLedgerList.SelectedIndex == 0)
					{
						Folio oFolioTmp;
						FolioFacade oFolioTmpFacade = new FolioFacade();
						oFolioTmp = oFolioTmpFacade.GetFolio(this.grdIndividual.GetDataDisplay(this.grdIndividual.Row,2));
						if (oFolioTmp.FolioType == "JOINER")
						{
							CheckOutUI = new CheckOutUI(oFolioTmp.FolioID, oFolioTmp.MasterFolio, "JOINER");
						}
						else
						{
							CheckOutUI = new CheckOutUI(this.grdIndividual.GetDataDisplay(this.grdIndividual.Row,2));
						}
						
					}
					else
					{
						CheckOutUI = new CheckOutUI(this.grdGroup.GetDataDisplay(_row,2), this.grdGroup.GetDataDisplay(_row,0));
					}
					
					CheckOutUI.MdiParent = this.MdiParent;
					CheckOutUI.Show();
					
					this.Close();
					
				}
				catch (ArgumentOutOfRangeException)
				{
                    MessageBox.Show("Please select an item on the list.", "Check Out Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, " btnViewLedger_Click Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				}
				
			}
			
			#region "POP UP MENU"
			
			
			
			
			
			private void mnuViewLedger_Click(System.Object sender, System.EventArgs e)
			{
				btnViewLedger_Click(sender, e);
			}
			
			private void mnuCheckOut_Click(System.Object sender, System.EventArgs e)
			{
				btnCheckOut_Click(sender, e);
			}
			#endregion
			
			
			
			
			//private void lvwGroup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			//{
			//    if (e.KeyChar == '\r')
			//    {
			//        this.grdGroup_DoubleClick(sender, e);
			//    }
			//}
			
			private void lvwIndividual_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				this.btnCreateLetter.Enabled = true;
				this.btnViewLedger.Enabled = true;
				this.btnCheckOut.Enabled = true;
			}
			
			//private void lvwIndividual_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
			//{
			//    lvwIndividual.Sorting = SortOrder.None;
			//    this.lvwIndividual.ListViewItemSorter = new ListViewItemComparer(e.Column);
			//    lvwIndividual.Sort();
			//}

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			private void btnCreateLetter_Click(object sender, EventArgs e)
			{
				//this.MdiParent.Cursor = Cursors.WaitCursor;
				try
				{
					int row = this.grdIndividual.Row;

					string folioId = this.grdIndividual.GetDataDisplay(row, 2);

					Folio oFolio = oFolioFACADE.GetFolio(folioId);

					//string accountId = this.grdFolio.get_TextMatrix(row, 15);

					Guest oGuest = new Guest();
					GuestFacade oGuestFacade = new GuestFacade();
					oGuest = oGuestFacade.getGuestRecord(oFolio.AccountID);

					string _roomNo = this.grdIndividual.GetDataDisplay(row, 0);
					string _name = oGuest.LastName + ", " + oGuest.FirstName;
					string _address = oGuest.Street + " " + oGuest.City + ", " + oGuest.Country;
					string _telephone = oGuest.TelephoneNo;
					string _salesExec = oFolio.Sales_Executive;
					double balance = double.Parse(this.grdIndividual.GetDataDisplay(row,5));


					DataTable dtReport = new DataTable("Report");
					dtReport.Columns.Add("room", typeof(System.String));
					dtReport.Columns.Add("name", typeof(System.String));
					dtReport.Columns.Add("address", typeof(System.String));
					dtReport.Columns.Add("telephone", typeof(System.String));
					dtReport.Columns.Add("salesExecutive", typeof(System.String));
					dtReport.Columns.Add("balance", typeof(System.Double));

					DataRow newRow = dtReport.NewRow();
					newRow["room"] = "Room " + _roomNo;
					newRow["name"] = _name;
					newRow["name"] = _name;
					newRow["address"] = _address;
					newRow["telephone"] = _telephone;
					newRow["salesExecutive"] = _salesExec;
					newRow["balance"] = balance;

					dtReport.Rows.Add(newRow);

					Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales.HighBalanceLetter highBalanceLetter = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales.HighBalanceLetter();
					highBalanceLetter.Database.Tables[1].SetDataSource(dtReport);
					highBalanceLetter.Database.Tables[0].SetDataSource(Jinisys.Hotel.Reports.BusinessLayer.CrystalReportAddons.reportHeader());

					ReportViewer rptViewer = new ReportViewer();
					rptViewer.rptViewer.ReportSource = highBalanceLetter;

					rptViewer.MdiParent = this.MdiParent;
					rptViewer.Show();
				}
				catch
				{ }
			}

			private void tabFolioLedgerList_SelectedIndexChanged(object sender, EventArgs e)
			{
				this.btnCreateLetter.Enabled = false;
				this.btnViewLedger.Enabled = false;
				this.btnCheckOut.Enabled = false;
			}

			

			//private void lvwIndividual_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
			//{
			//    e.DrawDefault = true;
			//}

			//private void lvwIndividual_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
			//{
			//    TextFormatFlags flags = TextFormatFlags.Left;

			//    using (StringFormat sf = new StringFormat())
			//    {
			//        // Store the column text alignment, letting it default
			//        // to Left if it has not been set to Center or Right.
			//        switch (e.Header.TextAlign)
			//        {
			//            case HorizontalAlignment.Center:
			//                sf.Alignment = StringAlignment.Center;
			//                flags = TextFormatFlags.NoClipping;
			//                break;
			//            case HorizontalAlignment.Right:
			//                sf.Alignment = StringAlignment.Far;
			//                flags = TextFormatFlags.NoClipping;
			//                break;
			//        }

			//        // Draw the text and background for a subitem with a 
			//        // negative value. 
			//        double subItemValue;
			//        if (e.ColumnIndex > 0 && Double.TryParse(
			//            e.SubItem.Text, NumberStyles.Currency,
			//            NumberFormatInfo.CurrentInfo, out subItemValue) &&
			//            subItemValue < 0)
			//        {
			//            // Unless the item is selected, draw the standard 
			//            // background to make it stand out from the gradient.
			//            if ((e.ItemState & ListViewItemStates.Selected) == 0)
			//            {
			//                e.DrawBackground();
			//            }
			//            else
			//                e.DrawDefault = true;

			//            // Draw the subitem text in red to highlight it. 
			//            e.Graphics.DrawString(e.SubItem.Text,
			//                lvwIndividual.Font, Brushes.Red, e.Bounds, sf);

			//            return;
			//        }

			//        if ((e.ItemState & ListViewItemStates.Selected) == 0)
			//        {
			//            e.DrawBackground();
			//        }
			//        else
			//            e.DrawDefault = true;


			//        // Draw normal text for a subitem with a nonnegative 
			//        // or nonnumerical value.
			//        //e.DrawText(flags);
			//        e.Graphics.DrawString(e.SubItem.Text,
			//                lvwIndividual.Font, Brushes.Black, e.Bounds, sf);
			//    }
			//}

           

			private void grdIndividual_RowColChange(object sender, EventArgs e)
			{
				this.btnCreateLetter.Enabled = true;
				this.btnViewLedger.Enabled = true;
				this.btnCheckOut.Enabled = true;
			}

			private void grdIndividual_DoubleClick(object sender, EventArgs e)
			{
				btnViewLedger_Click(sender, new EventArgs());
			}

			private void grdIndividual_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == 13)
				{
					btnViewLedger_Click(sender, new EventArgs());
				}
			}

			private void grdGroup_DoubleClick(object sender, EventArgs e)
			{
				btnViewLedger_Click(sender, new EventArgs());
			}

			private void grdGroup_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					//this.grdGroup_DoubleClick(sender, e);
					btnViewLedger_Click(sender, new EventArgs());
				}
			}

			private void grdGroup_RowColChange(object sender, EventArgs e)
			{
				this.btnCreateLetter.Enabled = true;
				this.btnViewLedger.Enabled = true;
				this.btnCheckOut.Enabled = true;
			}

			private void FolioLedgersUI_Activated(object sender, EventArgs e)
			{
				this.WindowState = FormWindowState.Maximized;
			}	
		}
	}
	
}
