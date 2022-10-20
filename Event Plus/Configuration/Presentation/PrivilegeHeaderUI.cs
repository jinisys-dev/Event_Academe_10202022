using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace Presentation
	{
		public class PrivilegeHeaderUI : Maintenance2UI, ClassMaintenanceInterface
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
			internal System.Windows.Forms.GroupBox GroupBox1;
			public System.Windows.Forms.TextBox txtDaysApplied;
			public System.Windows.Forms.Label Label5;
			internal System.Windows.Forms.DateTimePicker dtpToDate;
			internal System.Windows.Forms.DateTimePicker dtpFromDate;
			public System.Windows.Forms.Label Label4;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.TextBox txtDescription;
            public System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnNew;
			public System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnCancel;
            public System.Windows.Forms.TextBox txtPrivilegeID;
            internal GroupBox groupBox2;
            private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grid;
            public Button btnRemove;
            internal Button btnAdd;
            private GroupBox groupBox3;
            internal Button btnSearch;
            internal Panel pnlSearch;
            private Label label6;
            internal Label picClose;
            internal Label Label16;
            internal Label label7;
            internal Button btnCloseSearch;
            internal Button btnFind;
            internal TextBox txtSearch;
            internal Button btnClose;
            private C1.Win.C1FlexGrid.C1FlexGrid gridMain;
            internal Button btnSelect;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivilegeHeaderUI));
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.txtDaysApplied = new System.Windows.Forms.TextBox();
this.Label5 = new System.Windows.Forms.Label();
this.dtpToDate = new System.Windows.Forms.DateTimePicker();
this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
this.Label4 = new System.Windows.Forms.Label();
this.Label3 = new System.Windows.Forms.Label();
this.Label2 = new System.Windows.Forms.Label();
this.txtDescription = new System.Windows.Forms.TextBox();
this.Label1 = new System.Windows.Forms.Label();
this.txtPrivilegeID = new System.Windows.Forms.TextBox();
this.btnDelete = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.groupBox2 = new System.Windows.Forms.GroupBox();
this.grid = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.btnRemove = new System.Windows.Forms.Button();
this.btnAdd = new System.Windows.Forms.Button();
this.groupBox3 = new System.Windows.Forms.GroupBox();
this.btnSelect = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label6 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.label7 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.gridMain = new C1.Win.C1FlexGrid.C1FlexGrid();
this.GroupBox1.SuspendLayout();
this.groupBox2.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
this.groupBox3.SuspendLayout();
this.pnlSearch.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
this.SuspendLayout();
// 
// GroupBox1
// 
this.GroupBox1.Controls.Add(this.txtDaysApplied);
this.GroupBox1.Controls.Add(this.Label5);
this.GroupBox1.Controls.Add(this.dtpToDate);
this.GroupBox1.Controls.Add(this.dtpFromDate);
this.GroupBox1.Controls.Add(this.Label4);
this.GroupBox1.Controls.Add(this.Label3);
this.GroupBox1.Controls.Add(this.Label2);
this.GroupBox1.Controls.Add(this.txtDescription);
this.GroupBox1.Controls.Add(this.Label1);
this.GroupBox1.Controls.Add(this.txtPrivilegeID);
this.GroupBox1.Location = new System.Drawing.Point(209, 0);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(494, 174);
this.GroupBox1.TabIndex = 1;
this.GroupBox1.TabStop = false;
// 
// txtDaysApplied
// 
this.txtDaysApplied.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDaysApplied.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDaysApplied.Location = new System.Drawing.Point(109, 89);
this.txtDaysApplied.MaxLength = 20;
this.txtDaysApplied.Name = "txtDaysApplied";
this.txtDaysApplied.Size = new System.Drawing.Size(57, 20);
this.txtDaysApplied.TabIndex = 4;
// 
// Label5
// 
this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label5.Location = new System.Drawing.Point(21, 93);
this.Label5.Name = "Label5";
this.Label5.Size = new System.Drawing.Size(81, 17);
this.Label5.TabIndex = 68;
this.Label5.Text = "Days applied";
// 
// dtpToDate
// 
this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
this.dtpToDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpToDate.Location = new System.Drawing.Point(110, 146);
this.dtpToDate.Name = "dtpToDate";
this.dtpToDate.Size = new System.Drawing.Size(149, 20);
this.dtpToDate.TabIndex = 6;
// 
// dtpFromDate
// 
this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
this.dtpFromDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpFromDate.Location = new System.Drawing.Point(110, 115);
this.dtpFromDate.Name = "dtpFromDate";
this.dtpFromDate.Size = new System.Drawing.Size(150, 20);
this.dtpFromDate.TabIndex = 5;
// 
// Label4
// 
this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label4.Location = new System.Drawing.Point(19, 149);
this.Label4.Name = "Label4";
this.Label4.Size = new System.Drawing.Size(50, 17);
this.Label4.TabIndex = 64;
this.Label4.Text = "End date";
// 
// Label3
// 
this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label3.Location = new System.Drawing.Point(20, 119);
this.Label3.Name = "Label3";
this.Label3.Size = new System.Drawing.Size(83, 17);
this.Label3.TabIndex = 63;
this.Label3.Text = "Start date";
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(20, 44);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(83, 17);
this.Label2.TabIndex = 62;
this.Label2.Text = "Description";
// 
// txtDescription
// 
this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDescription.Location = new System.Drawing.Point(110, 46);
this.txtDescription.MaxLength = 500;
this.txtDescription.Multiline = true;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(367, 37);
this.txtDescription.TabIndex = 3;
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(21, 18);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(83, 17);
this.Label1.TabIndex = 60;
this.Label1.Text = "Privilege Id";
// 
// txtPrivilegeID
// 
this.txtPrivilegeID.BackColor = System.Drawing.SystemColors.Info;
this.txtPrivilegeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtPrivilegeID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtPrivilegeID.Location = new System.Drawing.Point(110, 15);
this.txtPrivilegeID.MaxLength = 100;
this.txtPrivilegeID.Multiline = true;
this.txtPrivilegeID.Name = "txtPrivilegeID";
this.txtPrivilegeID.Size = new System.Drawing.Size(217, 20);
this.txtPrivilegeID.TabIndex = 2;
this.txtPrivilegeID.TextChanged += new System.EventHandler(this.txtPrivilegeID_TextChanged);
// 
// btnDelete
// 
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(6, 12);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 12;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnNew
// 
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(416, 12);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 16;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnSave
// 
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(486, 12);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 17;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnCancel
// 
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(556, 12);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 18;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// groupBox2
// 
this.groupBox2.Controls.Add(this.grid);
this.groupBox2.Controls.Add(this.btnRemove);
this.groupBox2.Controls.Add(this.btnAdd);
this.groupBox2.Location = new System.Drawing.Point(209, 174);
this.groupBox2.Name = "groupBox2";
this.groupBox2.Size = new System.Drawing.Size(493, 246);
this.groupBox2.TabIndex = 7;
this.groupBox2.TabStop = false;
// 
// grid
// 
this.grid.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
this.grid.Cols = 5;
this.grid.ColumnInfo = resources.GetString("grid.ColumnInfo");
this.grid.ExplorerBar = ((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings)(((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExMove) 
            | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort)));
this.grid.ExtendLastCol = true;
this.grid.FixedCols = 0;
this.grid.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grid.Location = new System.Drawing.Point(6, 46);
this.grid.Name = "grid";
this.grid.NodeClosedPicture = null;
this.grid.NodeOpenPicture = null;
this.grid.OutlineCol = -1;
this.grid.Rows = 1;
this.grid.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grid.Size = new System.Drawing.Size(481, 196);
this.grid.StyleInfo = resources.GetString("grid.StyleInfo");
this.grid.TabIndex = 10;
this.grid.TreeColor = System.Drawing.Color.DarkGray;
this.grid.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grid_AfterEdit);
// 
// btnRemove
// 
this.btnRemove.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnRemove.Location = new System.Drawing.Point(421, 14);
this.btnRemove.Name = "btnRemove";
this.btnRemove.Size = new System.Drawing.Size(66, 26);
this.btnRemove.TabIndex = 9;
this.btnRemove.Text = "&Remove";
this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
// 
// btnAdd
// 
this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnAdd.Location = new System.Drawing.Point(350, 14);
this.btnAdd.Name = "btnAdd";
this.btnAdd.Size = new System.Drawing.Size(66, 26);
this.btnAdd.TabIndex = 8;
this.btnAdd.Text = "&Add";
this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
// 
// groupBox3
// 
this.groupBox3.Controls.Add(this.btnSelect);
this.groupBox3.Controls.Add(this.btnClose);
this.groupBox3.Controls.Add(this.btnSearch);
this.groupBox3.Controls.Add(this.btnDelete);
this.groupBox3.Controls.Add(this.btnCancel);
this.groupBox3.Controls.Add(this.btnNew);
this.groupBox3.Controls.Add(this.btnSave);
this.groupBox3.Location = new System.Drawing.Point(4, 422);
this.groupBox3.Name = "groupBox3";
this.groupBox3.Size = new System.Drawing.Size(698, 49);
this.groupBox3.TabIndex = 11;
this.groupBox3.TabStop = false;
// 
// btnSelect
// 
this.btnSelect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSelect.Location = new System.Drawing.Point(273, 12);
this.btnSelect.Name = "btnSelect";
this.btnSelect.Size = new System.Drawing.Size(66, 31);
this.btnSelect.TabIndex = 14;
this.btnSelect.Text = "Sele&ct";
this.btnSelect.Visible = false;
this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(626, 12);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 19;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSearch
// 
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSearch.Location = new System.Drawing.Point(346, 12);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 15;
this.btnSearch.Text = "&Search";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label6);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.label7);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(229, 161);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 188;
this.pnlSearch.Visible = false;
// 
// label6
// 
this.label6.BackColor = System.Drawing.Color.Transparent;
this.label6.Enabled = false;
this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label6.Location = new System.Drawing.Point(200, 99);
this.label6.Name = "label6";
this.label6.Size = new System.Drawing.Size(48, 47);
this.label6.TabIndex = 6;
// 
// picClose
// 
this.picClose.BackColor = System.Drawing.Color.SteelBlue;
this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.picClose.Location = new System.Drawing.Point(229, 3);
this.picClose.Name = "picClose";
this.picClose.Size = new System.Drawing.Size(18, 16);
this.picClose.TabIndex = 5;
this.picClose.Click += new System.EventHandler(this.picClose_Click);
// 
// Label16
// 
this.Label16.BackColor = System.Drawing.Color.SteelBlue;
this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.Label16.Location = new System.Drawing.Point(1, 1);
this.Label16.Name = "Label16";
this.Label16.Size = new System.Drawing.Size(247, 21);
this.Label16.TabIndex = 0;
this.Label16.Text = " Search";
this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label7
// 
this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label7.Location = new System.Drawing.Point(16, 42);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(141, 15);
this.label7.TabIndex = 4;
this.label7.Text = "Input Search string here";
// 
// btnCloseSearch
// 
this.btnCloseSearch.BackColor = System.Drawing.SystemColors.Control;
this.btnCloseSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCloseSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCloseSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnCloseSearch.Location = new System.Drawing.Point(118, 97);
this.btnCloseSearch.Name = "btnCloseSearch";
this.btnCloseSearch.Size = new System.Drawing.Size(63, 30);
this.btnCloseSearch.TabIndex = 188;
this.btnCloseSearch.Text = "&Close";
this.btnCloseSearch.UseVisualStyleBackColor = false;
this.btnCloseSearch.Click += new System.EventHandler(this.btnCloseSearch_Click);
// 
// btnFind
// 
this.btnFind.BackColor = System.Drawing.SystemColors.Control;
this.btnFind.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnFind.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnFind.Location = new System.Drawing.Point(50, 97);
this.btnFind.Name = "btnFind";
this.btnFind.Size = new System.Drawing.Size(63, 30);
this.btnFind.TabIndex = 187;
this.btnFind.Text = "&Find";
this.btnFind.UseVisualStyleBackColor = false;
this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
// 
// txtSearch
// 
this.txtSearch.BackColor = System.Drawing.SystemColors.Info;
this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F);
this.txtSearch.Location = new System.Drawing.Point(16, 62);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 22);
this.txtSearch.TabIndex = 3;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// gridMain
// 
this.gridMain.ColumnInfo = "1,0,0,0,0,85,Columns:0{Caption:\"ID\";TextAlign:LeftCenter;TextAlignFixed:CenterCen" +
    "ter;}\t";
this.gridMain.ExtendLastCol = true;
this.gridMain.Location = new System.Drawing.Point(6, 5);
this.gridMain.Name = "gridMain";
this.gridMain.Rows.Count = 1;
this.gridMain.Rows.DefaultSize = 17;
this.gridMain.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
this.gridMain.Size = new System.Drawing.Size(197, 414);
this.gridMain.StyleInfo = resources.GetString("gridMain.StyleInfo");
this.gridMain.TabIndex = 189;
this.gridMain.Click += new System.EventHandler(this.gridMain_SelChange);
this.gridMain.RowColChange += new System.EventHandler(this.gridMain_SelChange);
// 
// PrivilegeHeaderUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(708, 478);
this.Controls.Add(this.gridMain);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.groupBox3);
this.Controls.Add(this.groupBox2);
this.Controls.Add(this.GroupBox1);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "PrivilegeHeaderUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Privileges";
this.TextChanged += new System.EventHandler(this.PrivilegeHeaderUI_TextChanged);
this.Load += new System.EventHandler(this.PrivilegeHeaderUI_Load);
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
this.groupBox2.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
this.groupBox3.ResumeLayout(false);
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
this.ResumeLayout(false);

			}
			
			#endregion
			
			#region "VARIABLES"

    		private PrivilegeFacade oPrivilegeFacade;
			private PrivilegeHeader oPrivilegeHeader;
			private DatasetBinder oDataSetBinder;
			private Hashtable oTransactionHash;
			private Sequence oSequence;
            private ControlListener oControlListener;
            private OperationMode mOperationMode;

            #endregion

            #region "CONSTRUCTOR"

            public PrivilegeHeaderUI()
            {
                InitializeComponent();
                oPrivilegeHeader = new PrivilegeHeader();
                oControlListener = new ControlListener();
                mOperationMode = OperationMode.Edit;
            }

			// constructor for Adding Privileges to select guest
			private C1.Win.C1FlexGrid.C1FlexGrid vsGrid;
			public PrivilegeHeaderUI(ref C1.Win.C1FlexGrid.C1FlexGrid grid)
			{
				InitializeComponent();
				oPrivilegeHeader = new PrivilegeHeader();
				oControlListener = new ControlListener();
                mOperationMode = OperationMode.Edit;

				vsGrid = grid;
				this.btnSelect.Visible = true;
			}


            #endregion

            #region "METHODS"

            private void assignEntityValues()
            {
               try
                {
                    oPrivilegeHeader.PrivilegeID = this.txtPrivilegeID.Text;
                    oPrivilegeHeader.Description = this.txtDescription.Text;
                    oPrivilegeHeader.FromDate = dtpFromDate.Value;
                    oPrivilegeHeader.ToDate = dtpToDate.Value;
                    oPrivilegeHeader.DaysApplied = this.txtDaysApplied.Text;
                    oPrivilegeHeader.PrivilegeDetails = new List<PrivilegeDetail>();
                    PrivilegeDetail priv_det=null;
                    for (int i = 0; i < this.grid.Rows - 1; i++)
                    {
                        if (this.grid.GetDataDisplay(i + 1, 0).Trim() != "")
                        {
                            priv_det = new PrivilegeDetail();
                            priv_det.PrivilegeID = this.txtPrivilegeID.Text;
                            priv_det.TransactionCode = this.grid.GetDataDisplay(i + 1, 0).Trim();
                            priv_det.Basis = this.grid.GetDataDisplay(i + 1, 2).Trim();

							// check if Percent Discount is not greater than 100%
							decimal percentOff = decimal.Parse(grid.GetDataDisplay(i + 1, 3).Trim());
							if(percentOff > 100)
								percentOff = 100;

                            priv_det.PercentOff = percentOff;
                            priv_det.AmountOff = decimal.Parse(grid.GetDataDisplay(i + 1, 4).Trim());

                            oPrivilegeHeader.PrivilegeDetails.Add(priv_det);
                        }
                    }
                   
                }
                catch (Exception){}
            }

            ////Load privilege header and apply binding to form
            //private void loadPrivilegeHeader()
            //{
            //    oPrivilegeFacade = new PrivilegeFacade();
            //    oPrivilegeHeader = (PrivilegeHeader)oPrivilegeFacade.loadObject();
            //    if (!Information.IsNothing(oPrivilegeHeader))
            //    {
            //        oDataSetBinder = new DatasetBinder();
            //        object obj = (object)oPrivilegeHeader;
            //        oDataSetBinder.BindControls(this, ref obj, new ArrayList());
            //    }
            //}

            ////Load privilege header to listview
            //private void loadToListPrivilege()
            //{
            //    oPrivilegeFacade = new PrivilegeFacade();
            //    DataTable dTable;
            //    PrivilegeHeader oPriv=(PrivilegeHeader)oPrivilegeFacade.loadObject();
            //    dTable = oPriv.Tables["PrivilegeHeader"];
            //    //	lvwPrivileges.Items.Clear();
            //    for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            //    {
            //        ListViewItem lstItem = new ListViewItem(dTable.Rows[i]["Description"].ToString());
            //        //		this.lvwPrivileges.Items.Add(lstItem);
            //    }
            //    this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].Position = 0;
            //}

            private void loadPrivilegeDetails(string a_privilegeId)
            {
                oPrivilegeFacade = new PrivilegeFacade();
                IList<PrivilegeDetail> _oPrivilegeDetails = oPrivilegeFacade.getPrivilegeDetails(a_privilegeId);

                this.grid.Rows = 1;
                int i = 1;
                foreach (PrivilegeDetail _oPrivilege in _oPrivilegeDetails)
                {
                    this.grid.Rows++;

                    this.grid.SetData(i, 0, _oPrivilege.TransactionCode);
                    this.grid.SetData(i, 1, _oPrivilege.Memo);
                    this.grid.SetData(i, 2, _oPrivilege.Basis);
                    this.grid.SetData(i, 3, _oPrivilege.PercentOff.ToString("N"));
                    this.grid.SetData(i, 4, _oPrivilege.AmountOff.ToString("N"));
                    i++;
                }
            }
            //Get memo with code as a key

            private string getTransactionMemo(string a_code)
            {
                IDictionaryEnumerator Ienum = oTransactionHash.GetEnumerator();
                while (Ienum.MoveNext())
                {
                    if (Ienum.Key.ToString() == a_code)
                    {
                        return Ienum.Value.ToString();
                    }
                }
                return null;
            }

			private string getTransactionCode(string pMemo)
			{
				foreach (TransactionCode _oTransationCode in _oTransactionCodeList)
				{
					if (_oTransationCode.Memo == pMemo)
					{
						return _oTransationCode.TranCode;
					}
				}

				return "";
			}


            private void bindRowToControls()
            {
                //try
                //{
                //    if (this.oControlListener != null)
                //    {
                //        this.oControlListener.StopListen(this);
                //    }

                //    this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].Position = findItemInDataSet(this.gridMain.GetDataDisplay(this.gridMain.Row, 0).Trim());
                //}
                //catch (Exception)
                //{
                //}
                //finally
                //{
                //    if (this.oControlListener != null)
                //    {
                //        this.oControlListener.Listen(this);
                //    }
                //}

                oControlListener.StopListen(this);
                int _row = this.gridMain.Row;
                string _accountId = "";
                try
                {
                    _accountId = this.gridMain.GetDataDisplay(_row, 0);
                }
                catch
                {
                    //_accountId = this.gridMain.GetDataDisplay(1, 0);
                }

                this.txtPrivilegeID.Text = _accountId;

                loadPrivilegeDetails(this.txtPrivilegeID.Text);

                oControlListener.Listen(this);
            }

            //find the selected value
            private int findItemInDataSet(string a_key)
            {
               
                int i = 0;
                foreach (DataRow dr in oPrivilegeHeader.Tables[0].Rows)
                {
                  
                    if (dr["PrivilegeID"].ToString() == a_key)
                    {
                        return i;
                    }
                    else
                    {
                        i++;
                    }
                }
                return 0;
            }

            private bool isSelected(string a_code)
            {
                int i;
                for (i = 0; i < this.grid.Rows - 1; i++)
                {
                    if (grid.GetDataDisplay(i + 1, 0).Trim() == a_code && (i + 1) != this.grid.Row)
                    {
                        return true;
                    }
                }
                return false;
            }

            private bool isRequiredEntriesFilled()
            {
                if (this.txtPrivilegeID.Text.Length == 0 || this.txtDescription.Text.Length == 0 || this.txtDaysApplied.Text.Length == 0)
                {
                    return false;
                }
                if (this.grid.Rows == 1)
                {
                    return false;
                }

                return true;
            }
            //Clear Controls to ready for new transaction

            private void clearForNewTransaction()
            {
                Control ctr;
                foreach (Control tempLoopVar_ctr in this.Controls)
                {
                    ctr = tempLoopVar_ctr;
                    if (ctr is TextBox)
                    {
                        ctr.Text = "";
                    }
                    if (ctr is GroupBox || ctr is Panel)
                    {
                        Control ctr1;
                        foreach (Control tempLoopVar_ctr1 in ctr.Controls)
                        {
                            ctr1 = tempLoopVar_ctr1;
                            if (ctr1 is TextBox)
                            {
                                ctr1.Text = "";
                            }
                        }
                    }
                }
                //	this.lvwPrivilegeDetails.Items.Clear();
            }

            private void set_Enable(bool a_setEnable)
            {
                this.btnRemove.Enabled = a_setEnable;
                this.btnAdd.Enabled = a_setEnable;
            }

            private void cancelTransaction()
            {

            }

            private void setActionButtonStates(bool a_state)
            {
                this.btnSearch.Enabled = a_state;
                this.btnNew.Enabled = a_state;
                this.btnDelete.Enabled = a_state;
                this.btnSave.Enabled = !a_state;
                this.btnCancel.Enabled = !a_state;
            }

            private DataView _dtView;
            private PrivilegeHeader oPriv;
            private void populateDataGrid()
            {
                int i;

                oPrivilegeFacade = new PrivilegeFacade();
                oPriv = new PrivilegeHeader();
                oPriv = (PrivilegeHeader)oPrivilegeFacade.loadObject();
                DataTable dTable = oPriv.Tables["PrivilegeHeader"];
                this.gridMain.Rows.Count = 1;
                _dtView = oPriv.Tables[0].DefaultView;
                _dtView.RowStateFilter = DataViewRowState.OriginalRows;

                foreach (DataRowView dRow in _dtView)
                {
                    i = this.gridMain.Rows.Count;
                    this.gridMain.Rows.Count++;

                    this.gridMain.SetData(i, 0, dRow["PrivilegeID"].ToString());
                }
            }

            private int removePrivilegeDetails()
            {
                try
                {
                    int rowsAffected = 0;
                    string tranCode;
                    oPrivilegeFacade = new PrivilegeFacade();
                    tranCode = this.grid.GetDataDisplay(this.grid.Row, 0);
                    if (this.txtPrivilegeID.Text.Length != 0 || tranCode.Length != 0)
                    {
                        rowsAffected = oPrivilegeFacade.deletePrivilegeDetail(this.txtPrivilegeID.Text, tranCode);

                    }
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

			TransactionCodeFacade _oTransactionCodeFacade;
			IList<TransactionCode> _oTransactionCodeList;
			private void loadTransactionCodes()
			{
				_oTransactionCodeFacade = new TransactionCodeFacade();
				_oTransactionCodeList = new List<TransactionCode>();

				_oTransactionCodeList = _oTransactionCodeFacade.getTransactionCodeList();


				TransactionCodeFacade oTransactionFacade =new TransactionCodeFacade();
				TransactionCode oTransactionCode = (TransactionCode)oTransactionFacade.loadObject();

				DataTable _tempTable = oTransactionCode.Tables[0];

				DataView _dtViewTranCode = _tempTable.DefaultView;
				_dtViewTranCode.RowStateFilter = DataViewRowState.OriginalRows;
				_dtViewTranCode.RowFilter = "AcctSide = 'DEBIT' and TranCode <> '3300' and TranCode <> '6000'";

				//string _comboListTranCode = "";
				string _comboListMemo = "";
				foreach (DataRowView _dRow in _dtViewTranCode)
				{
					//_comboListTranCode += _dRow["TranCode"].ToString() + "|";
					_comboListMemo += _dRow["Memo"].ToString() + "|";
				}


                //Combobox at first column
				//this.grid.set_ColComboList(0, _comboListTranCode);
				this.grid.set_ColComboList(1, _comboListMemo);

                //Combobox basis
                this.grid.set_ColComboList(2, "P|A");

            }

            /********************************************************
            * Purpose:Search the List of DEPARTMENTS starting
            * from the Selected Row down
            * if Not Found then start the Search again from the top
            *********************************************************/

            private void searchItem()
            {
                if (isItemFound(this.gridMain.Row + 1))
                    return;
                if (isItemFound(1))
                    return;
                MessageBox.Show("No Matching Record Found!");
            }

            private bool isItemFound(int startIndex)
            {
                for (int i = startIndex; i < this.gridMain.Rows.Count; i++)
                {
                    if (this.gridMain.GetDataDisplay(i, 0).Contains(this.txtSearch.Text))
                    {
                        this.gridMain.Row = i;
                        return true;
                    }


                }
                return false;
            }

            private void setOperationMode(OperationMode a_OperationMode)
            {
                mOperationMode = a_OperationMode;
            }

            #endregion

            #region ClassMaintenanceInterface Members

            /********************************************************
            * Purpose: Mark existing item as DELETED
            *********************************************************/
            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oPrivilegeFacade = new PrivilegeFacade();
                    oPrivilegeHeader.PrivilegeID = this.txtPrivilegeID.Text;
                    rowsAffected = oPrivilegeFacade.deleteObject( oPrivilegeHeader);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
                finally
                {
                    this.oControlListener.Listen(this);
                }
            }
            /********************************************************
            * Purpose: Insert new item into the database
            *********************************************************/
            public int insert()
            {
                try
                {
                    int rowsAffected = 0;
                    oPrivilegeFacade = new PrivilegeFacade();
                    assignEntityValues();
                    rowsAffected = oPrivilegeFacade.insertObject(oPrivilegeHeader);
                    return rowsAffected;

                }
                catch (Exception)
                {
                    return 0;
                }
            }

            /********************************************************
            * Purpose: Retrieve data from the database
            *********************************************************/

            public bool load()
            {
                try
                {
                    oPrivilegeFacade = new PrivilegeFacade();
                    oPrivilegeHeader = (PrivilegeHeader)oPrivilegeFacade.loadObject();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                finally { this.Text = "Privileges"; }
            }

            /********************************************************
            * Purpose: Update existing item 
            *********************************************************/
            public int update()
            {
                try
                {
                    int rowsAffected = 0;
                    oPrivilegeFacade = new PrivilegeFacade();
                    assignEntityValues();
                    rowsAffected = oPrivilegeFacade.updateObject(oPrivilegeHeader);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

          
            #endregion

            #region "EVENTS"

			private void PrivilegeHeaderUI_Load(System.Object sender, System.EventArgs e)
			{
                this.gridMain.SelChange += new System.EventHandler(this.gridMain_SelChange);

				if (load() == true)
				{
                    oControlListener.StopListen(this);

					if (oPrivilegeHeader != null)
					{
						this.populateDataGrid();
						loadTransactionCodes();

                        if (this.gridMain.Rows.Count > 1)
                        {
                            this.gridMain_SelChange(sender, new EventArgs());
                        }
                        //Control frm = this;
                        //oDataSetBinder = new DatasetBinder();
                        //object obj = (object)oPrivilegeHeader;
                        //oDataSetBinder.BindControls(frm, ref obj, new ArrayList());
					}

					
				}
				set_Enable(true);
				setActionButtonStates(true);

				oControlListener.Listen(this);
			}


            private void btnNew_Click(System.Object sender, System.EventArgs e)
            {               
                oControlListener.StopListen(this);
                oSequence = new Sequence();
                setOperationMode(OperationMode.Add);
                this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse; 
                this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].SuspendBinding();
                this.Text = "Privileges"; // Add extra space to change form text
                clearForNewTransaction();
                this.txtPrivilegeID.Focus();

                this.setActionButtonStates(false);
                set_Enable(true);
            }

            private void btnSave_Click(System.Object sender, System.EventArgs e)
            {
                if (isRequiredEntriesFilled())
                {
                    switch (mOperationMode)
                    {
                        case OperationMode.Add:
                            if (insert() > 0)
                            {
                                MessageBox.Show("Item successfully added.", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //this.populateDataGrid();
                                this.gridMain.Rows.Count++;

                                this.gridMain.SetData(this.gridMain.Rows.Count - 1, 0, oPrivilegeHeader.PrivilegeID);
                                this.gridMain.Row = this.gridMain.Rows.Count - 1;
                                
                                oPrivilegeHeader = new PrivilegeHeader();
                                oPrivilegeHeader = (PrivilegeHeader)oPrivilegeFacade.loadObject();

                                _dtView = oPrivilegeHeader.Tables[0].DefaultView;
                                _dtView.RowStateFilter = DataViewRowState.OriginalRows;
                                
                                this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].ResumeBinding();

                                this.Text = "Privileges";
                                this.setActionButtonStates(true);
                            }
                            else
                            {
                                MessageBox.Show("No rows added", "Database Insert Error");
                            }

                            break;
                        case OperationMode.Edit:
                            if (update() > 0)
                            {
                                MessageBox.Show("Item successfully updated.", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //this.populateDataGrid();
                                this.Text = "Privileges";
                                oPrivilegeHeader = new PrivilegeHeader();
                                oPrivilegeHeader = (PrivilegeHeader)oPrivilegeFacade.loadObject();

                                _dtView = oPrivilegeHeader.Tables[0].DefaultView;
                                _dtView.RowStateFilter = DataViewRowState.OriginalRows;
                                
                                this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].ResumeBinding();
                                this.setActionButtonStates(true);

                            }
                            else
                            {
                                MessageBox.Show("No rows updated", "Database Update Error");
                            }
                            break;
                        default:
                            MessageBox.Show("Invalid operation mode", "Abort operation");
                            break;
                    }
                }
                else
                {
					MessageBox.Show("Please input valid value!", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.txtDescription.Focus();
                    return;
                }
                this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse;
                setOperationMode(OperationMode.Edit);
                //set_Enable(false);
            }

            private void btnCancel_Click(System.Object sender, System.EventArgs e)
            {
                this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].CancelCurrentEdit();
                this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].ResumeBinding();

                int _currentRow = gridMain.Row;
                gridMain.Select(0, 0);
                gridMain.Select(_currentRow, 0);
                
                //loadPrivilegeDetails(txtPrivilegeID.Text);
                this.Text = "Privileges";
                setOperationMode(OperationMode.Edit);
                set_Enable(true);
                setActionButtonStates(true);
                this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDNone;
                this.oControlListener.Listen(this);
            }

            private void txtPrivilegeID_TextChanged(System.Object sender, System.EventArgs e)
            {
                _dtView.RowStateFilter = DataViewRowState.OriginalRows;
                _dtView.RowFilter = "PrivilegeID = '" + this.txtPrivilegeID.Text + "'";

                if (_dtView.Count > 0)
                {
                    DataRowView dtRow = _dtView[0];
                    this.txtDaysApplied.Text = dtRow["daysApplied"].ToString();
                    this.txtDescription.Text = dtRow["description"].ToString();
                    this.dtpFromDate.Value = DateTime.Parse(dtRow["fromDate"].ToString());
                    this.dtpToDate.Value = DateTime.Parse(dtRow["toDate"].ToString());
                }
                
                loadPrivilegeDetails(this.txtPrivilegeID.Text);
            }

            private void lvwPrivileges_SelectedIndexChanged(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void btnDelete_Click(System.Object sender, System.EventArgs e)
            {
                if (MessageBox.Show("Are you certain you want to remove Privilege '" + this.gridMain.GetDataDisplay(this.gridMain.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.oControlListener.StopListen(this);

                    oPrivilegeFacade = new PrivilegeFacade();
                    oPrivilegeHeader.PrivilegeID = this.txtPrivilegeID.Text;

                    if (delete() > 0)
                    {
                        MessageBox.Show("Record has been deleted!");
                    }
                    this.populateDataGrid();
                    this.setActionButtonStates(true);
                    gridMain_SelChange(this, new EventArgs());
                }
            }

            private void PrivilegeHeaderUI_TextChanged(object sender, System.EventArgs e)
            {
                if (this.Text.IndexOf('*') > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse; 
                    setActionButtonStates(false);
                    this.set_Enable(true);
                    this.BindingContext[oPrivilegeHeader.Tables["PrivilegeHeader"]].SuspendBinding();
                }
                else
                {
                    setActionButtonStates(true);
                    //this.set_Enable(false);
                }
            }

            private void txtPAmount_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (!(Char.IsNumber(e.KeyChar) || (int)(e.KeyChar) == 8 || (int)(e.KeyChar) == 46))
                {

                    e.Handled = true;
                }
            }

            private void btnAdd_Click(System.Object sender, System.EventArgs e)
            {
				this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse; 
                this.grid.Rows++;
                if (mOperationMode != OperationMode.Add)
                {
                    this.Text = "Privileges*";
                }
            }

            private void btnRemove_Click(System.Object sender, System.EventArgs e)
            {
                //if (removePrivilegeDetails() > 0)
                //{
                //    this.loadPrivilegeDetails(this.txtPrivilegeID.Text);
                //}
                this.grid.RemoveItem(grid.Row);
                if (mOperationMode != OperationMode.Add)
                {
                    this.Text = "Privileges*";
                }
            }

            private void btnEdit_Click(System.Object sender, System.EventArgs e)
            {
                this.Text = "Privileges*";
                this.setActionButtonStates(true);
            }

            private void picClose_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void btnFind_Click(object sender, EventArgs e)
            {
                searchItem();
            }

            private void btnCloseSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                    searchItem();
            }

            private void gridMain_SelChange(object sender, EventArgs e)
            {
                bindRowToControls();
            }

            private void grid_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
            {
				//if (e.Col == 0)
				//{
				//    if (!isSelected(this.grid.GetDataDisplay(grid.Row, 0).Trim()))
				//    {
				//        this.grid.SetData(this.grid.Row, 1, getTransactionMemo(grid.GetDataDisplay(grid.Row, 0).Trim()));
				//        this.grid.StartEditing(this.grid.Row, 2);
				//    }
				//    else
				//    {
				//        MessageBox.Show("Transaction code already selected!");
				//        this.grid.StartEditing(this.grid.Row, 0);
				//    }
				//}
				if (e.Col == 1)
				{
					string _memo = this.grid.GetDataDisplay(this.grid.Row, 1);
					string _tranCode = getTransactionCode(_memo);
					this.grid.SetData(this.grid.Row, 0, _tranCode);

					this.grid.StartEditing(this.grid.Row, 2);

				}
				else if (e.Col == 2)
				{
					if (this.grid.GetDataDisplay(this.grid.Row, 2).Trim() == "P")
					{
						this.grid.SetData(this.grid.Row, 3, "0");
						this.grid.SetData(this.grid.Row, 4, "0");
						this.grid.StartEditing(this.grid.Row, 3);

					}
					else if (this.grid.GetDataDisplay(this.grid.Row, 2).Trim() == "A")
					{
						this.grid.SetData(this.grid.Row, 4, "0");
						this.grid.SetData(this.grid.Row, 3, "0");
						this.grid.StartEditing(this.grid.Row, 4);
					}
				}
            }

            private void btnSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = true;
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
            }

            #endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			private void btnSelect_Click(object sender, EventArgs e)
			{
				int row = this.vsGrid.Rows.Count;
				this.vsGrid.Rows.Count += 1;

				this.vsGrid.SetData(row, 0, this.txtPrivilegeID.Text);
				this.vsGrid.SetData(row, 1, this.txtDescription.Text);
				this.vsGrid.SetData(row, 2, this.txtDaysApplied.Text);
				this.vsGrid.SetData(row, 3, GlobalVariables.gLoggedOnUser);
				this.vsGrid.SetData(row, 4, string.Format("{0:dd-MMM-yyyy hh:mm tt}", DateTime.Now));

			}



        }
	}
}
