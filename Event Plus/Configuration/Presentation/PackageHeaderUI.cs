using System.Diagnostics;
using  Jinisys.Hotel.UIFramework;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	
		public class PackageHeaderUI :Maintenance2UI, ClassMaintenanceInterface
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
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.TextBox txtDescription;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.Label Label4;
            public System.Windows.Forms.Label Label5;
			public System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnCancel;
			public System.Windows.Forms.TextBox txtPackageID;
			internal System.Windows.Forms.DateTimePicker dtpFromDate;
			internal System.Windows.Forms.DateTimePicker dtpToDate;
            public System.Windows.Forms.TextBox txtDaysApplied;
            internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.ContextMenu conEdit;
			internal System.Windows.Forms.MenuItem mnuNew;
            internal System.Windows.Forms.MenuItem mnuDelete;
            internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnAdd;
			public System.Windows.Forms.Button btnRemove;
			internal System.Windows.Forms.GroupBox grpMain;
            internal GroupBox groupBox1;
            private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grid;
            private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic gridMain;
            internal Panel pnlSearch;
            private Label label6;
            internal Label picClose;
            internal Label Label16;
            internal Label label7;
            internal Button btnCloseSearch;
            internal Button btnFind;
            internal TextBox txtSearch;
            private GroupBox gbxCommands;
            internal Button btnClose;
            internal Button btnSearch;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageHeaderUI));
this.grpMain = new System.Windows.Forms.GroupBox();
this.txtDaysApplied = new System.Windows.Forms.TextBox();
this.Label5 = new System.Windows.Forms.Label();
this.dtpToDate = new System.Windows.Forms.DateTimePicker();
this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
this.Label4 = new System.Windows.Forms.Label();
this.Label3 = new System.Windows.Forms.Label();
this.Label2 = new System.Windows.Forms.Label();
this.txtDescription = new System.Windows.Forms.TextBox();
this.Label1 = new System.Windows.Forms.Label();
this.txtPackageID = new System.Windows.Forms.TextBox();
this.conEdit = new System.Windows.Forms.ContextMenu();
this.mnuNew = new System.Windows.Forms.MenuItem();
this.mnuDelete = new System.Windows.Forms.MenuItem();
this.btnSave = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnAdd = new System.Windows.Forms.Button();
this.btnRemove = new System.Windows.Forms.Button();
this.groupBox1 = new System.Windows.Forms.GroupBox();
this.grid = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.gridMain = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.btnSearch = new System.Windows.Forms.Button();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label6 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.label7 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.grpMain.SuspendLayout();
this.groupBox1.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
this.pnlSearch.SuspendLayout();
this.gbxCommands.SuspendLayout();
this.SuspendLayout();
// 
// grpMain
// 
this.grpMain.Controls.Add(this.txtDaysApplied);
this.grpMain.Controls.Add(this.Label5);
this.grpMain.Controls.Add(this.dtpToDate);
this.grpMain.Controls.Add(this.dtpFromDate);
this.grpMain.Controls.Add(this.Label4);
this.grpMain.Controls.Add(this.Label3);
this.grpMain.Controls.Add(this.Label2);
this.grpMain.Controls.Add(this.txtDescription);
this.grpMain.Controls.Add(this.Label1);
this.grpMain.Controls.Add(this.txtPackageID);
this.grpMain.Location = new System.Drawing.Point(211, 3);
this.grpMain.Name = "grpMain";
this.grpMain.Size = new System.Drawing.Size(494, 174);
this.grpMain.TabIndex = 1;
this.grpMain.TabStop = false;
// 
// txtDaysApplied
// 
this.txtDaysApplied.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDaysApplied.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDaysApplied.Location = new System.Drawing.Point(111, 91);
this.txtDaysApplied.MaxLength = 20;
this.txtDaysApplied.Name = "txtDaysApplied";
this.txtDaysApplied.Size = new System.Drawing.Size(146, 20);
this.txtDaysApplied.TabIndex = 4;
// 
// Label5
// 
this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label5.Location = new System.Drawing.Point(23, 95);
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
this.dtpToDate.Location = new System.Drawing.Point(111, 148);
this.dtpToDate.Name = "dtpToDate";
this.dtpToDate.Size = new System.Drawing.Size(146, 20);
this.dtpToDate.TabIndex = 6;
// 
// dtpFromDate
// 
this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
this.dtpFromDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpFromDate.Location = new System.Drawing.Point(111, 117);
this.dtpFromDate.Name = "dtpFromDate";
this.dtpFromDate.Size = new System.Drawing.Size(146, 20);
this.dtpFromDate.TabIndex = 5;
// 
// Label4
// 
this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label4.Location = new System.Drawing.Point(22, 151);
this.Label4.Name = "Label4";
this.Label4.Size = new System.Drawing.Size(50, 17);
this.Label4.TabIndex = 64;
this.Label4.Text = "End date";
// 
// Label3
// 
this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label3.Location = new System.Drawing.Point(21, 121);
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
this.txtDescription.MaxLength = 150;
this.txtDescription.Multiline = true;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(370, 39);
this.txtDescription.TabIndex = 3;
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(21, 18);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(83, 17);
this.Label1.TabIndex = 60;
this.Label1.Text = "Package Id";
// 
// txtPackageID
// 
this.txtPackageID.BackColor = System.Drawing.SystemColors.Info;
this.txtPackageID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtPackageID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtPackageID.Location = new System.Drawing.Point(110, 15);
this.txtPackageID.MaxLength = 50;
this.txtPackageID.Multiline = true;
this.txtPackageID.Name = "txtPackageID";
this.txtPackageID.Size = new System.Drawing.Size(129, 20);
this.txtPackageID.TabIndex = 2;
this.txtPackageID.TextChanged += new System.EventHandler(this.txtPackageID_TextChanged);
// 
// conEdit
// 
this.conEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNew,
            this.mnuDelete});
// 
// mnuNew
// 
this.mnuNew.Index = 0;
this.mnuNew.Text = "New Entry";
// 
// mnuDelete
// 
this.mnuDelete.Index = 1;
this.mnuDelete.Text = "Delete Entry";
// 
// btnSave
// 
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSave.Location = new System.Drawing.Point(484, 13);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 15;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnCancel
// 
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnCancel.Location = new System.Drawing.Point(554, 13);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 16;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// btnNew
// 
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnNew.Location = new System.Drawing.Point(414, 13);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 14;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnDelete
// 
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnDelete.Location = new System.Drawing.Point(6, 13);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 12;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
// groupBox1
// 
this.groupBox1.Controls.Add(this.grid);
this.groupBox1.Controls.Add(this.btnRemove);
this.groupBox1.Controls.Add(this.btnAdd);
this.groupBox1.Location = new System.Drawing.Point(211, 183);
this.groupBox1.Name = "groupBox1";
this.groupBox1.Size = new System.Drawing.Size(493, 258);
this.groupBox1.TabIndex = 7;
this.groupBox1.TabStop = false;
// 
// grid
// 
this.grid.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
this.grid.Cols = 5;
this.grid.ColumnInfo = "5,0,0,0,0,85,Columns:0{Caption:\"Trans. Code\";}\t1{Width:137;Caption:\"Memo\";}\t2{Wid" +
    "th:49;Caption:\"Basis\";}\t3{Caption:\"Percent Off\";}\t4{Caption:\"Amount\";}\t";
this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse;
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
this.grid.Size = new System.Drawing.Size(481, 206);
this.grid.StyleInfo = resources.GetString("grid.StyleInfo");
this.grid.TabIndex = 10;
this.grid.TreeColor = System.Drawing.Color.DarkGray;
this.grid.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grid_AfterEdit);
// 
// gridMain
// 
this.gridMain.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.gridMain.Cols = 1;
this.gridMain.ColumnInfo = "1,0,0,0,0,85,Columns:0{Caption:\"Package\";TextAlignFixed:CenterCenter;}\t";
this.gridMain.ExtendLastCol = true;
this.gridMain.FixedCols = 0;
this.gridMain.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.gridMain.Location = new System.Drawing.Point(8, 8);
this.gridMain.Name = "gridMain";
this.gridMain.NodeClosedPicture = null;
this.gridMain.NodeOpenPicture = null;
this.gridMain.OutlineCol = -1;
this.gridMain.Rows = 20;
this.gridMain.Size = new System.Drawing.Size(197, 433);
this.gridMain.StyleInfo = resources.GetString("gridMain.StyleInfo");
this.gridMain.TabIndex = 0;
this.gridMain.TreeColor = System.Drawing.Color.DarkGray;
this.gridMain.SelChange += new System.EventHandler(this.gridMain_SelChange);
// 
// btnSearch
// 
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSearch.Location = new System.Drawing.Point(344, 13);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 13;
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
this.pnlSearch.Location = new System.Drawing.Point(-46, 175);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 18;
this.pnlSearch.Visible = false;
this.pnlSearch.VisibleChanged += new System.EventHandler(this.pnlSearch_VisibleChanged);
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
this.btnCloseSearch.TabIndex = 21;
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
this.btnFind.TabIndex = 20;
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
this.txtSearch.TabIndex = 19;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Location = new System.Drawing.Point(8, 443);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(697, 50);
this.gbxCommands.TabIndex = 11;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(624, 13);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 17;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// PackageHeaderUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(710, 499);
this.Controls.Add(this.gbxCommands);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.gridMain);
this.Controls.Add(this.groupBox1);
this.Controls.Add(this.grpMain);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "PackageHeaderUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Packages";
this.TextChanged += new System.EventHandler(this.PackageHeaderUI_TextChanged);
this.Load += new System.EventHandler(this.PackageHeaderUI_Load);
this.grpMain.ResumeLayout(false);
this.grpMain.PerformLayout();
this.groupBox1.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.gbxCommands.ResumeLayout(false);
this.ResumeLayout(false);

			}
			
			#endregion
			
			#region "Variables and Constants"
		
		    private PackageFacade oPackageFacade;
			private PackageHeader oPackageHeader;

			private Hashtable oTransactionHash;
			private DatasetBinder oDataSetBinder;
			private Sequence oSequence;
			private OperationMode mOperationMode;
            private ControlListener oControlListener;

			#endregion
			
			#region "CONSTRUCTORS"
			public PackageHeaderUI()
			{
				InitializeComponent();
				//oControlListener=new ControlListener();
			}
			#endregion
					
			#region "METHODS"

            /********************************************************
            * Purpose: Set the state of the button
            *********************************************************/
            private void setActionButtonStates(bool a_state)
            {
                this.btnSearch.Enabled = a_state;
                this.btnNew.Enabled = a_state;
                this.btnDelete.Enabled = a_state;
                this.btnSave.Enabled = !a_state;
                this.btnCancel.Enabled = !a_state;
            }

            /********************************************************
            * Purpose: Remove a _package item 
            *********************************************************/
            private int removePackageDetails()
            {
                try
                {
                  int rowsAffected=0;
                  oPackageFacade = new PackageFacade();
                  string  tranCode = this.grid.get_TextMatrix(this.grid.Row,0);

                    if (txtPackageID.Text.Length != 0 || tranCode.Length != 0)
                    {
                        rowsAffected=oPackageFacade.deletePackageDetails(txtPackageID.Text, tranCode);

                       
                    }
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

             private void setOperationMode(OperationMode a_OperationMode)
			{
                mOperationMode = a_OperationMode;
			}

            /********************************************************
            * Purpose: Set Enable/Disable of (Add/Remove Button)
            *********************************************************/
			private void set_Enable(bool a_setEnable)
			{
                this.btnRemove.Enabled = a_setEnable;
                this.btnAdd.Enabled = a_setEnable;
			}
			
            /********************************************************
            * Purpose: Load all _package details and display to grid
            *********************************************************/
            private void loadPackageDetails(string a_packageId)
            {
                //DataTable dTable;
                oPackageFacade = new PackageFacade();
                IList<PackageDetail> _oPackageDetails = oPackageFacade.loadPackageDetails(a_packageId);
                this.grid.Rows = 1;
				foreach (PackageDetail _oPackageDetail in _oPackageDetails)
                {
					int i = this.grid.Rows;

                    this.grid.Rows++;
					this.grid.set_TextMatrix(i , 0, _oPackageDetail.TransactionCode);
					this.grid.set_TextMatrix(i, 1, _oPackageDetail.Memo);
					this.grid.set_TextMatrix(i, 2, _oPackageDetail.Basis);
					this.grid.set_TextMatrix(i, 3, _oPackageDetail.PercentOff.ToString("N"));
					this.grid.set_TextMatrix(i, 4, _oPackageDetail.AmountOff.ToString("N"));
                    
                }
            }
          
           /********************************************************
           * Purpose: Initialize object instance and _package details
           *********************************************************/
			private void assignEntityValues()
			{
				try
				{
				    oPackageHeader.PackageID = this.txtPackageID.Text;
					oPackageHeader.Description = this.txtDescription.Text;
					oPackageHeader.FromDate = dtpFromDate.Value;
					oPackageHeader.ToDate = dtpToDate.Value;
					oPackageHeader.DaysApplied = this.txtDaysApplied.Text;
                    //oPackageHeader.PackageDetails = new List<PackageDetail>();

					IList<PackageDetail> _oPackageDetails = new List<PackageDetail>();
				    PackageDetail pack_det = null;
					for (int i = 0; i <this.grid.Rows-1; i++)
					{
						if (this.grid.get_TextMatrix(i + 1,0).Trim() != "")
						{
							pack_det = new PackageDetail();
							pack_det.PackageID = this.txtPackageID.Text;
                            pack_det.TransactionCode = this.grid.get_TextMatrix(i+1, 0).Trim();
                            pack_det.Basis = this.grid.get_TextMatrix(i + 1, 2).Trim();
                            pack_det.PercentOff = decimal.Parse(grid.get_TextMatrix(i + 1, 3).Trim());
                            pack_det.AmountOff = decimal.Parse(grid.get_TextMatrix(i + 1, 4).Trim());
						    _oPackageDetails.Add(pack_det);
                            
						}
					}
					oPackageHeader.PackageDetails = _oPackageDetails;
				}
				catch (Exception)
				{
					
				}
			}
           /********************************************************
           * Purpose: Populate record to Grid Control
           *********************************************************/
		    private void populateDataGrid()
			{
				oPackageFacade = new PackageFacade();
                PackageHeader oPack=(PackageHeader) oPackageFacade.loadObject();
                DataTable dTable = oPack.Tables["PackageHeader"];
                this.gridMain.Rows = 1;
				for (int i = 0; i <= dTable.Rows.Count - 1; i++)
				{
                    this.gridMain.Rows++;
                    this.gridMain.set_TextMatrix(i + 1, 0, dTable.Rows[i][1].ToString());
				}
				
			}
			
            /********************************************************
            * Purpose: Get the transaction memo
            *********************************************************/
            private string getTransactionMemo(string a_code)
			{
				foreach (TransactionCode _oTransationCode in _oTransactionCodeList)
				{
					if (_oTransationCode.TranCode == a_code)
					{
						return _oTransationCode.Memo;
					}
				}

				return "";
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

            /*********************************************************
             * Purpose: Bind row to form controls
             *********************************************************/
			private void bindRowToControls()
			{
                try
                {
                    this.oControlListener.StopListen(this);
                    this.BindingContext[oPackageHeader.Tables["PackageHeader"]].Position = findItemInDataset(this.gridMain.get_TextMatrix(this.gridMain.Row, 0).Trim());
                }
                catch (Exception){}
                finally
                {
					try
					{
						this.oControlListener.Listen(this);
					}
					catch { }
                }
			}
           /*********************************************************
           * Purpose: Find an item to the database by a specific key
           *********************************************************/
			private int findItemInDataset(string a_key)
			{
			
				int i = 0;
				foreach (DataRow dr in oPackageHeader.Tables[0].Rows)
				{

                    if (dr["Description"].ToString() == a_key)
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
           /*********************************************************
           * Purpose: Return if item is selected
           *********************************************************/
			private bool isSelected(string a_code)
			{
				int i;
				for (i = 0; i < this.grid.Rows-1; i++)
				{
					if (grid.get_TextMatrix(i+1,0).Trim() == a_code && (i+1) != this.grid.Row )
					{
						return true;
					}
				}
				return false;
			}
          /*********************************************************
          * Purpose: Return TRUE if input is valid 
          *********************************************************/
			private bool isRequiredEntriesFilled()
			{
				if (this.txtPackageID.Text == "")
				{
					this.txtPackageID.Focus();
					return false;
				}

				if (this.txtDescription.Text == "")
				{
					this.txtDescription.Focus();
					return false;
				}

				if (this.grid.Rows == 1)
				{
					this.btnAdd.Focus();
					return false;
				}

				if (this.txtDaysApplied.Text == "")
				{
					this.txtDaysApplied.Focus();
					return false;
				}
						
				return true;
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

            private bool isItemFound(int a_startIndex)
            {
                for (int i = a_startIndex; i < this.gridMain.Rows; i++)
                {
                    if (this.gridMain.get_TextMatrix(i, 0).Contains(this.txtSearch.Text))
                    {
                        this.gridMain.Row = i;
                        return true;
                    }


                }
                return false;
            }

			TransactionCodeFacade _oTransactionCodeFacade;
			IList<TransactionCode> _oTransactionCodeList;
			DataView _dtViewTranCode;
            private void loadTransactionCodes()
            {
				_oTransactionCodeFacade = new TransactionCodeFacade();
				_oTransactionCodeList = new List<TransactionCode>();

				_oTransactionCodeList = _oTransactionCodeFacade.getTransactionCodeList();

				DataSet _tempDataSet = (DataSet)_oTransactionCodeFacade.loadObject();
				DataTable _tempTable = _tempDataSet.Tables[0];

				_dtViewTranCode = _tempTable.DefaultView;
				_dtViewTranCode.RowStateFilter = DataViewRowState.OriginalRows;
				_dtViewTranCode.RowFilter = "AcctSide = 'DEBIT' and TranCode <> '3300' and TranCode <> '6000'";

                string _comboListTranCode = "";
				string _comboListMemo = "";
				foreach (DataRowView _dRow in _dtViewTranCode)
				{
					_comboListTranCode += _dRow["TranCode"].ToString() + "|";
					_comboListMemo += _dRow["Memo"].ToString() + "|";
				}

				this.grid.set_ColComboList(0, _comboListTranCode);
				this.grid.set_ColComboList(1, _comboListMemo);

                //Combobox basis
                this.grid.set_ColComboList(2, "P|A");

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
                    int rowsAffected=0;
                    oPackageFacade = new PackageFacade();
                    oPackageHeader.PackageID = this.txtPackageID.Text;
                    rowsAffected=oPackageFacade.deleteObject(ref oPackageHeader);
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
                    int rowsAffected=0;
                    oPackageFacade = new PackageFacade();
                    assignEntityValues();
                    rowsAffected=oPackageFacade.insertObject(ref oPackageHeader);
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
                    oPackageHeader = new PackageHeader();
                    oPackageFacade = new PackageFacade();
                    oPackageHeader = (PackageHeader)oPackageFacade.loadObject();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally { this.Text = "Packages"; }
            }

            /********************************************************
            * Purpose: Update existing item 
            *********************************************************/
            public int update()
            {
                try
                {
                    int rowsAffected=0;
                    oPackageFacade = new PackageFacade();
                    assignEntityValues();
                    rowsAffected=oPackageFacade.updateObject(ref oPackageHeader);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            #endregion

            #region "EVENTS"

			private void btnNew_Click(System.Object sender, System.EventArgs e)
			{
				oControlListener.StopListen(this);
				oSequence = new Sequence();
			    
				setOperationMode(OperationMode.Add);
				this.BindingContext[oPackageHeader.Tables["PackageHeader"]].SuspendBinding();
				this.Text = "Packages "; // Add extra space to change form text
			//	this.txtPackageID.Text = oSequence.GetSequenceId("P-", 12, "seq_Packages");
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
                                 MessageBox.Show("Item successfully added.", "Packages", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                 this.BindingContext[oPackageHeader.Tables["PackageHeader"]].ResumeBinding();
                                 this.populateDataGrid();
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
                               MessageBox.Show("Item successfully updated.", "Packages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                               this.populateDataGrid();
                               this.Text = "Packages";
                               this.BindingContext[oPackageHeader.Tables["PackageHeader"]].ResumeBinding();
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
                    //this.txtDescription.Focus();
                    return;                
                }
                set_Enable(false);
			}

			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
                this.BindingContext[oPackageHeader.Tables["PackageHeader"]].CancelCurrentEdit();
                this.BindingContext[oPackageHeader.Tables["PackageHeader"]].ResumeBinding();

                int _currentRow = gridMain.Row;
                gridMain.Select(0, 0);
                gridMain.Select(_currentRow, 0);
                
                this.Text = "Packages";
				set_Enable(false);
                this.oControlListener.Listen(this);
				
			}
			
			private void txtPAmount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (! (Char.IsNumber(e.KeyChar) || (int)(e.KeyChar) == 8 || (int)(e.KeyChar) == 46) )
				{
                    e.Handled = true;
				}
			}

			private void PackageHeaderUI_Load(System.Object sender, System.EventArgs e)
			{
				if(load()==true)
                {
                 //oControlListener.StopListen(this);
                 if (oPackageHeader != null)
                    {
                        //Load to grid
                        this.populateDataGrid();
                        loadTransactionCodes();

                        Control frm = this;
                        oDataSetBinder = new DatasetBinder();
                        object obj = (object)oPackageHeader;
                        oDataSetBinder.BindControls(frm, ref obj, new ArrayList());
                    }

                    this.setActionButtonStates(true);
                }
				set_Enable(true);
				setActionButtonStates(true);

				oControlListener = new ControlListener();
				oControlListener.Listen(this);
			}
		
			private void txtPackageID_TextChanged(System.Object sender, System.EventArgs e)
			{
				loadPackageDetails(txtPackageID.Text);
			}
			
			private void PackageHeaderUI_TextChanged(object sender, System.EventArgs e)
			{
                if (this.Text.IndexOf('*') > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    setActionButtonStates(false);
                    this.set_Enable(true);
                }
                else
                {
                    setActionButtonStates(true);
                    this.set_Enable(false);
                }
			}

			private void btnDelete_Click(System.Object sender, System.EventArgs e)
			{
                if (MessageBox.Show("Are you certain you want to remove Package '" + this.gridMain.get_TextMatrix(this.gridMain.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.oControlListener.StopListen(this);

                        oPackageFacade = new PackageFacade();
                        oPackageHeader.PackageID = this.txtPackageID.Text;
                        if (delete() > 0)
                        {
                            MessageBox.Show("Record has been deleted!");
                        }
                        this.populateDataGrid();
                        this.setActionButtonStates(true);
                    }
			}

			private void btnAdd_Click(System.Object sender, System.EventArgs e)
			{
                if (mOperationMode.Equals(OperationMode.Add))
                    this.grid.Rows++;
                else
                {
                    this.Text += "*";
                    this.grid.Rows++;
                }
			}
           
			private void btnRemove_Click(System.Object sender, System.EventArgs e)
			{
                if(removePackageDetails() > 0 )
                {
                     this.loadPackageDetails(txtPackageID.Text);
                }
			}
          
            private void grid_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
            {
                if (e.Col == 0)
                {
                    if (!isSelected(this.grid.get_TextMatrix(grid.Row, 0).Trim()))
                    {
                        this.grid.set_TextMatrix(this.grid.Row, 1, getTransactionMemo(grid.get_TextMatrix(grid.Row, 0).Trim()));
                        this.grid.StartEditing(this.grid.Row, 2);
                    }
                    else
                    {
                        MessageBox.Show("Transaction code already selected!");
                        this.grid.StartEditing(this.grid.Row, 0);
                    }
                }
				else if(e.Col == 1)
				{
					string _memo = this.grid.get_TextMatrix(this.grid.Row, 1);
					string _tranCode = getTransactionCode(_memo);
					this.grid.set_TextMatrix(this.grid.Row, 0, _tranCode);

					this.grid.StartEditing(this.grid.Row, 2);
				}
                else if (e.Col == 2)
                {
                    if (this.grid.get_TextMatrix(this.grid.Row, 2).Trim() == "P")
                    {
                        this.grid.set_TextMatrix(this.grid.Row, 3, "0");
                        this.grid.set_TextMatrix(this.grid.Row, 4, "0");
                        this.grid.StartEditing(this.grid.Row, 3);

                    }
                    else if (this.grid.get_TextMatrix(this.grid.Row, 2).Trim() == "A")
                    {
                        this.grid.set_TextMatrix(this.grid.Row, 4, "0");
                        this.grid.set_TextMatrix(this.grid.Row, 3, "0");
                        this.grid.StartEditing(this.grid.Row, 4);
                    }
                }

            }

            private void gridMain_SelChange(object sender, EventArgs e)
            {
                bindRowToControls();
            }

            private void btnSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = true;
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
            }

            private void btnCloseSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void picClose_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void btnFind_Click(object sender, EventArgs e)
            {
                searchItem();

            }

            private void pnlSearch_VisibleChanged(object sender, EventArgs e)
            {
                if (pnlSearch.Visible)
                {
                    this.oControlListener.StopListen(this);
                    this.gbxCommands.Enabled = false;
                }
                else
                {
                    this.oControlListener.Listen(this);
                    this.gbxCommands.Enabled = true;
                }
            }

            private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                    this.searchItem();
            }

			#endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            
           }
	}
	

