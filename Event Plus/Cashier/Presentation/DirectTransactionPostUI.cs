
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Cashier.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Cashier.DataAccessLayer;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;

using C1.Win.C1FlexGrid;

namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class DirectTransactionPostUI : Jinisys.Hotel.UIFramework.TransactionUI
		{
			
			#region "Instantiations/Variable Declarations"
			//private MySqlConnection localConnection;
			
			private Folio oFolio = new Folio();
			private FolioFacade oFolioFacade = new FolioFacade();
			private MenuItem mnuRefresh;
			internal Button btnBacktoList;
			internal Button btnVoid;
			internal Button btnAdd;
			internal TabControl tabNonGuestTransactions;
			private TabPage tabAll;
			private C1FlexGrid grdAllTransactions;
			internal TabPage tabCharges;
			private C1FlexGrid grdCharges;
			internal TabPage tabPayments;
			private C1FlexGrid grdPayments;
			internal TabPage tabCommission;
			private C1FlexGrid grdCommission;
			internal TabPage tabDisbursement;
			private C1FlexGrid grdDisbursement;
			internal Button btnClose;
			private CheckBox chkCurrentShiftOnly;
			private DateTimePicker dtpTransactionDate;
			private Label label1;
			private Label label2;
			private FolioTransaction oFolioTransaction = new FolioTransaction();
			
			#endregion

			#region " Windows Form Designer generated code "
			
			public DirectTransactionPostUI()
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

            private System.ComponentModel.IContainer components;

            //Required by the Windows Form Designer
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			internal System.Windows.Forms.ContextMenu popUpMenu;
			internal System.Windows.Forms.MenuItem mnuInsert;
			internal System.Windows.Forms.MenuItem MenuItem2;
			internal System.Windows.Forms.MenuItem mnuVoid;
			internal System.Windows.Forms.MenuItem mnuRecall;
			internal System.Windows.Forms.MenuItem MenuItem7;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectTransactionPostUI));
                this.popUpMenu = new System.Windows.Forms.ContextMenu();
                this.mnuInsert = new System.Windows.Forms.MenuItem();
                this.MenuItem2 = new System.Windows.Forms.MenuItem();
                this.mnuVoid = new System.Windows.Forms.MenuItem();
                this.mnuRecall = new System.Windows.Forms.MenuItem();
                this.MenuItem7 = new System.Windows.Forms.MenuItem();
                this.mnuRefresh = new System.Windows.Forms.MenuItem();
                this.btnBacktoList = new System.Windows.Forms.Button();
                this.btnVoid = new System.Windows.Forms.Button();
                this.btnAdd = new System.Windows.Forms.Button();
                this.tabNonGuestTransactions = new System.Windows.Forms.TabControl();
                this.tabAll = new System.Windows.Forms.TabPage();
                this.grdAllTransactions = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.tabCharges = new System.Windows.Forms.TabPage();
                this.grdCharges = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.tabPayments = new System.Windows.Forms.TabPage();
                this.grdPayments = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.tabCommission = new System.Windows.Forms.TabPage();
                this.grdCommission = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.tabDisbursement = new System.Windows.Forms.TabPage();
                this.grdDisbursement = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.btnClose = new System.Windows.Forms.Button();
                this.chkCurrentShiftOnly = new System.Windows.Forms.CheckBox();
                this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.tabNonGuestTransactions.SuspendLayout();
                this.tabAll.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdAllTransactions)).BeginInit();
                this.tabCharges.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdCharges)).BeginInit();
                this.tabPayments.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).BeginInit();
                this.tabCommission.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdCommission)).BeginInit();
                this.tabDisbursement.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdDisbursement)).BeginInit();
                this.SuspendLayout();
                // 
                // popUpMenu
                // 
                this.popUpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuInsert,
            this.MenuItem2,
            this.mnuVoid,
            this.mnuRecall,
            this.MenuItem7,
            this.mnuRefresh});
                // 
                // mnuInsert
                // 
                this.mnuInsert.DefaultItem = true;
                this.mnuInsert.Index = 0;
                this.mnuInsert.Text = "Insert";
                this.mnuInsert.Click += new System.EventHandler(this.mnuInsert_Click);
                // 
                // MenuItem2
                // 
                this.MenuItem2.Index = 1;
                this.MenuItem2.Text = "-";
                // 
                // mnuVoid
                // 
                this.mnuVoid.Index = 2;
                this.mnuVoid.Text = "Void";
                this.mnuVoid.Click += new System.EventHandler(this.mnuVoid_Click);
                // 
                // mnuRecall
                // 
                this.mnuRecall.Index = 3;
                this.mnuRecall.Text = "Recall";
                this.mnuRecall.Click += new System.EventHandler(this.mnuRecall_Click);
                // 
                // MenuItem7
                // 
                this.MenuItem7.Index = 4;
                this.MenuItem7.Text = "-";
                // 
                // mnuRefresh
                // 
                this.mnuRefresh.Index = 5;
                this.mnuRefresh.Text = "Refresh";
                this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
                // 
                // btnBacktoList
                // 
                this.btnBacktoList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.btnBacktoList.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnBacktoList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnBacktoList.Location = new System.Drawing.Point(615, 35);
                this.btnBacktoList.Name = "btnBacktoList";
                this.btnBacktoList.Size = new System.Drawing.Size(66, 31);
                this.btnBacktoList.TabIndex = 89;
                this.btnBacktoList.Text = "Print";
                this.btnBacktoList.Click += new System.EventHandler(this.btnBacktoList_Click);
                // 
                // btnVoid
                // 
                this.btnVoid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.btnVoid.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnVoid.Enabled = false;
                this.btnVoid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnVoid.Location = new System.Drawing.Point(687, 35);
                this.btnVoid.Name = "btnVoid";
                this.btnVoid.Size = new System.Drawing.Size(66, 31);
                this.btnVoid.TabIndex = 91;
                this.btnVoid.Text = "&Void";
                this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
                // 
                // btnAdd
                // 
                this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnAdd.Location = new System.Drawing.Point(473, 35);
                this.btnAdd.Name = "btnAdd";
                this.btnAdd.Size = new System.Drawing.Size(136, 31);
                this.btnAdd.TabIndex = 1;
                this.btnAdd.Text = "&Insert Transaction";
                this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                // 
                // tabNonGuestTransactions
                // 
                this.tabNonGuestTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.tabNonGuestTransactions.Controls.Add(this.tabAll);
                this.tabNonGuestTransactions.Controls.Add(this.tabCharges);
                this.tabNonGuestTransactions.Controls.Add(this.tabPayments);
                this.tabNonGuestTransactions.Controls.Add(this.tabCommission);
                this.tabNonGuestTransactions.Controls.Add(this.tabDisbursement);
                this.tabNonGuestTransactions.Location = new System.Drawing.Point(13, 96);
                this.tabNonGuestTransactions.Multiline = true;
                this.tabNonGuestTransactions.Name = "tabNonGuestTransactions";
                this.tabNonGuestTransactions.SelectedIndex = 0;
                this.tabNonGuestTransactions.Size = new System.Drawing.Size(823, 537);
                this.tabNonGuestTransactions.TabIndex = 103;
                this.tabNonGuestTransactions.SelectedIndexChanged += new System.EventHandler(this.tabSubFolio_SelectedIndexChanged);
                // 
                // tabAll
                // 
                this.tabAll.Controls.Add(this.grdAllTransactions);
                this.tabAll.Location = new System.Drawing.Point(4, 23);
                this.tabAll.Name = "tabAll";
                this.tabAll.Padding = new System.Windows.Forms.Padding(3);
                this.tabAll.Size = new System.Drawing.Size(815, 510);
                this.tabAll.TabIndex = 4;
                this.tabAll.Text = "All         ";
                this.tabAll.UseVisualStyleBackColor = true;
                // 
                // grdAllTransactions
                // 
                this.grdAllTransactions.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
                this.grdAllTransactions.AllowEditing = false;
                this.grdAllTransactions.ColumnInfo = resources.GetString("grdAllTransactions.ColumnInfo");
                this.grdAllTransactions.Cursor = System.Windows.Forms.Cursors.Default;
                this.grdAllTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
                this.grdAllTransactions.Location = new System.Drawing.Point(3, 3);
                this.grdAllTransactions.Name = "grdAllTransactions";
                this.grdAllTransactions.Rows.Count = 1;
                this.grdAllTransactions.Rows.DefaultSize = 17;
                this.grdAllTransactions.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grdAllTransactions.Size = new System.Drawing.Size(809, 504);
                this.grdAllTransactions.StyleInfo = resources.GetString("grdAllTransactions.StyleInfo");
                this.grdAllTransactions.TabIndex = 6;
                this.grdAllTransactions.RowColChange += new System.EventHandler(this.grdAllTransactions_RowColChange);
                // 
                // tabCharges
                // 
                this.tabCharges.Controls.Add(this.grdCharges);
                this.tabCharges.Location = new System.Drawing.Point(4, 23);
                this.tabCharges.Name = "tabCharges";
                this.tabCharges.Padding = new System.Windows.Forms.Padding(3);
                this.tabCharges.Size = new System.Drawing.Size(815, 510);
                this.tabCharges.TabIndex = 0;
                this.tabCharges.Text = "Charges      ";
                this.tabCharges.UseVisualStyleBackColor = true;
                // 
                // grdCharges
                // 
                this.grdCharges.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
                this.grdCharges.AllowEditing = false;
                this.grdCharges.ColumnInfo = resources.GetString("grdCharges.ColumnInfo");
                this.grdCharges.Cursor = System.Windows.Forms.Cursors.Default;
                this.grdCharges.Dock = System.Windows.Forms.DockStyle.Fill;
                this.grdCharges.Location = new System.Drawing.Point(3, 3);
                this.grdCharges.Name = "grdCharges";
                this.grdCharges.Rows.Count = 1;
                this.grdCharges.Rows.DefaultSize = 17;
                this.grdCharges.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grdCharges.Size = new System.Drawing.Size(809, 504);
                this.grdCharges.StyleInfo = resources.GetString("grdCharges.StyleInfo");
                this.grdCharges.TabIndex = 6;
                this.grdCharges.RowColChange += new System.EventHandler(this.grdAllTransactions_RowColChange);
                // 
                // tabPayments
                // 
                this.tabPayments.Controls.Add(this.grdPayments);
                this.tabPayments.Location = new System.Drawing.Point(4, 23);
                this.tabPayments.Name = "tabPayments";
                this.tabPayments.Padding = new System.Windows.Forms.Padding(3);
                this.tabPayments.Size = new System.Drawing.Size(815, 510);
                this.tabPayments.TabIndex = 3;
                this.tabPayments.Text = "Payments     ";
                this.tabPayments.UseVisualStyleBackColor = true;
                // 
                // grdPayments
                // 
                this.grdPayments.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
                this.grdPayments.AllowEditing = false;
                this.grdPayments.ColumnInfo = resources.GetString("grdPayments.ColumnInfo");
                this.grdPayments.Cursor = System.Windows.Forms.Cursors.Default;
                this.grdPayments.Dock = System.Windows.Forms.DockStyle.Fill;
                this.grdPayments.Location = new System.Drawing.Point(3, 3);
                this.grdPayments.Name = "grdPayments";
                this.grdPayments.Rows.Count = 1;
                this.grdPayments.Rows.DefaultSize = 17;
                this.grdPayments.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grdPayments.Size = new System.Drawing.Size(809, 504);
                this.grdPayments.StyleInfo = resources.GetString("grdPayments.StyleInfo");
                this.grdPayments.TabIndex = 6;
                this.grdPayments.RowColChange += new System.EventHandler(this.grdAllTransactions_RowColChange);
                // 
                // tabCommission
                // 
                this.tabCommission.Controls.Add(this.grdCommission);
                this.tabCommission.Location = new System.Drawing.Point(4, 23);
                this.tabCommission.Name = "tabCommission";
                this.tabCommission.Padding = new System.Windows.Forms.Padding(3);
                this.tabCommission.Size = new System.Drawing.Size(815, 510);
                this.tabCommission.TabIndex = 1;
                this.tabCommission.Text = "Commission   ";
                this.tabCommission.UseVisualStyleBackColor = true;
                // 
                // grdCommission
                // 
                this.grdCommission.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
                this.grdCommission.AllowEditing = false;
                this.grdCommission.ColumnInfo = resources.GetString("grdCommission.ColumnInfo");
                this.grdCommission.Cursor = System.Windows.Forms.Cursors.Default;
                this.grdCommission.Dock = System.Windows.Forms.DockStyle.Fill;
                this.grdCommission.Location = new System.Drawing.Point(3, 3);
                this.grdCommission.Name = "grdCommission";
                this.grdCommission.Rows.Count = 1;
                this.grdCommission.Rows.DefaultSize = 17;
                this.grdCommission.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grdCommission.Size = new System.Drawing.Size(809, 504);
                this.grdCommission.StyleInfo = resources.GetString("grdCommission.StyleInfo");
                this.grdCommission.TabIndex = 6;
                this.grdCommission.RowColChange += new System.EventHandler(this.grdAllTransactions_RowColChange);
                // 
                // tabDisbursement
                // 
                this.tabDisbursement.Controls.Add(this.grdDisbursement);
                this.tabDisbursement.Location = new System.Drawing.Point(4, 23);
                this.tabDisbursement.Name = "tabDisbursement";
                this.tabDisbursement.Padding = new System.Windows.Forms.Padding(3);
                this.tabDisbursement.Size = new System.Drawing.Size(815, 510);
                this.tabDisbursement.TabIndex = 2;
                this.tabDisbursement.Text = "Disbursement ";
                this.tabDisbursement.UseVisualStyleBackColor = true;
                // 
                // grdDisbursement
                // 
                this.grdDisbursement.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
                this.grdDisbursement.AllowEditing = false;
                this.grdDisbursement.ColumnInfo = resources.GetString("grdDisbursement.ColumnInfo");
                this.grdDisbursement.Cursor = System.Windows.Forms.Cursors.Default;
                this.grdDisbursement.Dock = System.Windows.Forms.DockStyle.Fill;
                this.grdDisbursement.Location = new System.Drawing.Point(3, 3);
                this.grdDisbursement.Name = "grdDisbursement";
                this.grdDisbursement.Rows.Count = 1;
                this.grdDisbursement.Rows.DefaultSize = 17;
                this.grdDisbursement.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grdDisbursement.Size = new System.Drawing.Size(809, 504);
                this.grdDisbursement.StyleInfo = resources.GetString("grdDisbursement.StyleInfo");
                this.grdDisbursement.TabIndex = 5;
                this.grdDisbursement.RowColChange += new System.EventHandler(this.grdAllTransactions_RowColChange);
                // 
                // btnClose
                // 
                this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(759, 35);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 117;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // chkCurrentShiftOnly
                // 
                this.chkCurrentShiftOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.chkCurrentShiftOnly.AutoSize = true;
                this.chkCurrentShiftOnly.Checked = true;
                this.chkCurrentShiftOnly.CheckState = System.Windows.Forms.CheckState.Checked;
                this.chkCurrentShiftOnly.Location = new System.Drawing.Point(53, 73);
                this.chkCurrentShiftOnly.Name = "chkCurrentShiftOnly";
                this.chkCurrentShiftOnly.Size = new System.Drawing.Size(178, 18);
                this.chkCurrentShiftOnly.TabIndex = 118;
                this.chkCurrentShiftOnly.Text = "Current Shift Transactions Only";
                this.chkCurrentShiftOnly.UseVisualStyleBackColor = true;
                this.chkCurrentShiftOnly.CheckedChanged += new System.EventHandler(this.chkCurrentShiftOnly_CheckedChanged);
                // 
                // dtpTransactionDate
                // 
                this.dtpTransactionDate.Location = new System.Drawing.Point(61, 50);
                this.dtpTransactionDate.Name = "dtpTransactionDate";
                this.dtpTransactionDate.Size = new System.Drawing.Size(200, 20);
                this.dtpTransactionDate.TabIndex = 120;
                this.dtpTransactionDate.ValueChanged += new System.EventHandler(this.dtpTransactionDate_ValueChanged);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(20, 53);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(35, 14);
                this.label1.TabIndex = 119;
                this.label1.Text = "Date :";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label2.Location = new System.Drawing.Point(19, 19);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(212, 19);
                this.label2.TabIndex = 121;
                this.label2.Text = "Direct Transaction Posting";
                // 
                // DirectTransactionPostUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(848, 647);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.dtpTransactionDate);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.btnBacktoList);
                this.Controls.Add(this.chkCurrentShiftOnly);
                this.Controls.Add(this.btnVoid);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnAdd);
                this.Controls.Add(this.tabNonGuestTransactions);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "DirectTransactionPostUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Direct Transaction Post";
                this.Activated += new System.EventHandler(this.DirectTransactionPostUI_Activated);
                this.Load += new System.EventHandler(this.NonGuestTransactionUI_Load);
                this.tabNonGuestTransactions.ResumeLayout(false);
                this.tabAll.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.grdAllTransactions)).EndInit();
                this.tabCharges.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.grdCharges)).EndInit();
                this.tabPayments.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).EndInit();
                this.tabCommission.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.grdCommission)).EndInit();
                this.tabDisbursement.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.grdDisbursement)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

			}
			
			#endregion
			
			private void btnAdd_Click(System.Object sender, System.EventArgs e)
			{

				// this is to trace all folio transactions
				if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
				{
					MessageBox.Show("Can't proceed transaction.\r\nNo Shift/Cash drawer open.\r\n\r\nTo Open Shift/Cash Drawer goto Transactions menu, Cashiering->Open Shift/Cash drawer.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}


				IList<NonGuestTransaction> newTrans = new List<NonGuestTransaction>();

				AddDirectPostTransactionUI postTransactionNonGuestUI = new AddDirectPostTransactionUI("DIRECT POST");
				newTrans = postTransactionNonGuestUI.showDialog(this);

				if (newTrans != null)
				{
					this.dtpTransactionDate_ValueChanged(sender, e);
					//foreach (NonGuestTransaction trans in newTrans)
					//{
					//    this.ilNonGuestTransactions.Add(trans);
					//}

					//loadDataInListView();
				}
			}
			
			
			decimal _balanceAllTrans = 0;
			decimal _balanceCharges = 0;
			//decimal _balancePayments = 0;
			decimal _balanceCommission = 0;
			decimal _balanceDisbursement = 0;

			private void loadDataInListView()
			{
				bool currentShiftOnly = this.chkCurrentShiftOnly.Checked;
                _balanceAllTrans = 0;
                _balanceCharges = 0;
                _balanceCommission = 0;
                _balanceDisbursement = 0;

				try
				{

					this.grdAllTransactions.Rows.Count = 1;
					this.grdCharges.Rows.Count = 1;
					this.grdPayments.Rows.Count = 1;
					this.grdCommission.Rows.Count = 1;
					this.grdDisbursement.Rows.Count = 1;

					//NonGuestTransaction[] _nonGuestTransCopy = new NonGuestTransaction[];
					//ilNonGuestTransactions.CopyTo(_nonGuestTransCopy,0);
					IList<NonGuestTransaction> _nonGuestTransCopy = new List<NonGuestTransaction>();
					foreach (NonGuestTransaction _nonGuestTrans in ilNonGuestTransactions)
					{
						_nonGuestTransCopy.Add(_nonGuestTrans);
					}


					if (currentShiftOnly)
					{
						foreach (NonGuestTransaction _nonGuestTrans in ilNonGuestTransactions)
						{
							if (_nonGuestTrans.ShiftCode != GlobalVariables.gShiftCode)
							{

								_nonGuestTransCopy.Remove(_nonGuestTrans);
							}
						}
					}




					foreach (NonGuestTransaction nonGuestTrans in _nonGuestTransCopy)
					{

						//if (currentShiftOnly &&
						//    nonGuestTrans.ShiftCode == GlobalVariables.gShiftCode &&
						if (nonGuestTrans.TransactionDate.ToShortDateString() == this.dtpTransactionDate.Value.ToShortDateString())
						{

							Row _newRow = this.grdAllTransactions.Rows.Add();

							_newRow[0] = nonGuestTrans.TransactionDate;
							_newRow[1] = nonGuestTrans.PostingDate;
							_newRow[2] = nonGuestTrans.TransactionCode;
							_newRow[3] = nonGuestTrans.Memo;
							_newRow[4] = nonGuestTrans.TransactionSource;
							_newRow[5] = nonGuestTrans.ReferenceNo;
							_newRow[6] = nonGuestTrans.BaseAmount;

							decimal _totalTax = 0;
							_totalTax = nonGuestTrans.GovernmentTax + nonGuestTrans.LocalTax;

							_newRow[7] = _totalTax;
							_newRow[8] = nonGuestTrans.ServiceCharge;
							_newRow[9] = nonGuestTrans.GrossAmount;
							_newRow[10] = nonGuestTrans.Discount;
							_newRow[11] = nonGuestTrans.NetAmount;
							//_newRow[12] = _balanceAllTrans;
							_newRow[15] = nonGuestTrans.updatedBy;
							//_newRow[14] = nonGuestTrans.NetBaseAmount;
							_newRow[16] = nonGuestTrans.TransactionId;


							if (nonGuestTrans.AcctSide == "DEBIT")
							{
                                //for column debit and credit
                                _newRow[12] = nonGuestTrans.NetAmount;
                                _newRow[13] = 0;

								_balanceAllTrans += nonGuestTrans.NetAmount;
								_newRow[14] = _balanceAllTrans;

								if (nonGuestTrans.TransactionCode != "6000")
								{

									Row _chargesRow = this.grdCharges.Rows.Add();

									//assign values to the new Row
									for (int c = 0; c < 17; c++)
									{
										_chargesRow[c] = _newRow[c];
									}
									_balanceCharges += nonGuestTrans.NetAmount;
									_chargesRow[14] = _balanceCharges;

								}
								else
								{
									//cloneItem = (ListViewItem)lvwItem.Clone();
									if (nonGuestTrans.SubAccount == "DISBURSEMENT")
									{
										Row _row = this.grdDisbursement.Rows.Add();
										//assign values to the new Row
										for (int c = 0; c < 17; c++)
										{
											_row[c] = _newRow[c];
										}
										_balanceDisbursement += nonGuestTrans.NetAmount;
										_row[14] = _balanceDisbursement;

									}
									else if (nonGuestTrans.SubAccount == "COMMISSION")
									{
										//cloneItem.SubItems.Add(nonGuestTrans.DriverFirstName + " " + nonGuestTrans.DriverLastName);
										//_newRow[15] = nonGuestTrans.DriverFirstName + " " + nonGuestTrans.DriverLastName;

										Row _row = this.grdCommission.Rows.Add();
										//assign values to the new Row
										for (int c = 0; c < 17; c++)
										{
											_row[c] = _newRow[c];
										}
										_row[17] = nonGuestTrans.DriverFirstName + " " + nonGuestTrans.DriverLastName;


										_balanceCommission += nonGuestTrans.NetAmount;
										_row[14] = _balanceCommission;

									}
								}

							}
							else
							{
                                //for column debit and credit
                                _newRow[12] = 0;
                                _newRow[13] = nonGuestTrans.NetAmount;
                                
                                //ListViewItem cloneItem = (ListViewItem)lvwItem.Clone();

								Row _row = this.grdPayments.Rows.Add();
								for (int c = 0; c < 17; c++)
								{
									_row[c] = _newRow[c];
								}

								_balanceAllTrans -= nonGuestTrans.NetAmount;
								_newRow[14] = _balanceAllTrans;
							}

						}//end outer if

					}// end foreach

				}//en try

				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			
			private void btnVoid_Click(System.Object sender, System.EventArgs e)
			{
				string transactionId = "";
				try
				{
					transactionId = this.selectedGrid.GetDataDisplay(selectedGrid.Row, 16);
				}
				catch
				{
					
				}

				if (transactionId != "")
				{
					NonGuestTransaction voidNonGuestTrans = null;

					DialogResult rsp = MessageBox.Show("Are you sure you want to void this transaction ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (rsp == DialogResult.Yes)
					{
						foreach (NonGuestTransaction nonGuestTrans in ilNonGuestTransactions)
						{
							if (nonGuestTrans.TransactionId == transactionId)
							{
								voidNonGuestTrans = nonGuestTrans;
								break;
							}
						}
						if (voidNonGuestTrans != null)
						{
							oNonGuestTransactionFacade = new NonGuestTransactionFacade();

							try
							{
								oNonGuestTransactionFacade.voidNonGuestTransaction(voidNonGuestTrans);
								this.ilNonGuestTransactions.Remove(voidNonGuestTrans);

							}
							catch (Exception ex)
							{
								MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}


						loadDataInListView();
					}

				}
			}

			private void btnRecall_Click(System.Object sender, System.EventArgs e)
			{
				
			}
			

			#region "POP UP MENU"
			private void mnuInsert_Click(System.Object sender, System.EventArgs e)
			{
				btnAdd_Click(sender, e);
			}
			
			
			private void mnuVoid_Click(System.Object sender, System.EventArgs e)
			{
				btnVoid_Click(sender, e);
			}
			
			private void mnuRecall_Click(System.Object sender, System.EventArgs e)
			{
				btnRecall_Click(sender, e);
			}
			
			
			#endregion
			
			private void listView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Right)
				{
					System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);
					
					popUpMenu.Show((Control)sender, pos);
				}
			}

			private NonGuestTransactionFacade oNonGuestTransactionFacade;
			private IList<NonGuestTransaction> ilNonGuestTransactions;

            private void NonGuestTransactionUI_Load(object sender, EventArgs e)
            {
				this.dtpTransactionDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			private void tabSubFolio_SelectedIndexChanged(object sender, EventArgs e)
			{
				this.btnVoid.Enabled = false;
			}

			private void chkCurrentShift_CheckedChanged(object sender, EventArgs e)
			{
				loadDataInListView();
			}

			private void chkCurrentDate_CheckedChanged(object sender, EventArgs e)
			{
				loadDataInListView();
			}

			private void mnuRefresh_Click(object sender, EventArgs e)
			{
				loadDataInListView();
			}

			C1FlexGrid selectedGrid;
			

			private void btnBacktoList_Click(object sender, EventArgs e)
			{
				//this.MdiParent.Cursor = Cursors.WaitCursor;

				switch (tabNonGuestTransactions.SelectedIndex)
				{ 
					case 0:
						generateNonGuestChargesTransactions();
						generateNonGuestPaymentsTransactions();
						generateNonGuestPaidOutTransactions();
						break;
					case 1:
						generateNonGuestChargesTransactions();
						break;
					case 2:
						generateNonGuestPaymentsTransactions();
						break;
					case 3:
					case 4:
						generateNonGuestPaidOutTransactions();
						break;
				}
				
			}

			private void generateNonGuestChargesTransactions()
			{
				ReportViewer rptViewer = new ReportViewer();
				ReportFacade oReportFacade = new ReportFacade();

				string _reportDate = string.Format("{0:yyyy-MM-dd}", this.dtpTransactionDate.Value);

				rptViewer.rptViewer.ReportSource = oReportFacade.getDateRangeNonGuestChargesTransactions(_reportDate, _reportDate);

				rptViewer.MdiParent = this.MdiParent;
				rptViewer.Show();
			}

			private void generateNonGuestPaymentsTransactions()
			{
				ReportViewer rptViewer = new ReportViewer();
				ReportFacade oReportFacade = new ReportFacade();

				string _reportDate = string.Format("{0:yyyy-MM-dd}", this.dtpTransactionDate.Value);

				rptViewer.rptViewer.ReportSource = oReportFacade.getDateRangeNonGuestPaymentsTransactions(_reportDate, _reportDate);

				rptViewer.MdiParent = this.MdiParent;
				rptViewer.Show();
			}

			private void generateNonGuestPaidOutTransactions()
			{
				ReportViewer rptViewer = new ReportViewer();
				ReportFacade oReportFacade = new ReportFacade();

				string _reportDate = string.Format("{0:yyyy-MM-dd}", this.dtpTransactionDate.Value);


				rptViewer.rptViewer.ReportSource = oReportFacade.getDateRangeNonGuestPaidOutTransactions(_reportDate, _reportDate);

				rptViewer.MdiParent = this.MdiParent;
				rptViewer.Show();
			}


			private void grdAllTransactions_RowColChange(object sender, EventArgs e)
			{
				C1FlexGrid grid = (C1FlexGrid)sender;

				if (grid.Rows.Count > 1)
				{
					this.btnVoid.Enabled = true;

					selectedGrid = grid;
				}
			}

			private void chkCurrentShiftOnly_CheckedChanged(object sender, EventArgs e)
			{
				loadDataInListView();
			}

			private void dtpTransactionDate_ValueChanged(object sender, EventArgs e)
			{
				oNonGuestTransactionFacade = new NonGuestTransactionFacade();
				ilNonGuestTransactions = oNonGuestTransactionFacade.getNonGuestTransactions(this.dtpTransactionDate.Value);

				loadDataInListView();
			}

			private void DirectTransactionPostUI_Activated(object sender, EventArgs e)
			{
				this.WindowState = FormWindowState.Maximized;
			}

			
		}
	}
	
}
