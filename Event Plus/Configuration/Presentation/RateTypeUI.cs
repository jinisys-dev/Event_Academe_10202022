/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/


using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	public class RateTypeUI : Jinisys.Hotel.UIFramework.Maintenance2UI, ClassMaintenanceInterface
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
		public System.Windows.Forms.GroupBox GroupBox3;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ComboBox cboRoomTypeCode;
		internal System.Windows.Forms.ComboBox cboRateCode;
		internal System.Windows.Forms.GroupBox gbxCommands;
		internal System.Windows.Forms.Button btnSearch;
		internal System.Windows.Forms.Button btnDelete;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
        internal Panel pnlSearch;
        private Label label5;
        internal Label picClose;
        internal Label Label16;
        internal Label Label6;
        internal Button btnCloseSearch;
        internal Button btnFind;
        internal TextBox txtSearch;
        private NumericUpDown nudRateAmount;
        internal Button btnClose;
		internal NumericUpDown nudBreakfastAmount;
		public Label label7;
		internal ComboBox cboHasBreakfast;
		public Label label3;
        private ComboBox cboRoomID;
        private Label label4;
        private TextBox txtRoomDescription;
		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdRateTypes;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateTypeUI));
this.GroupBox3 = new System.Windows.Forms.GroupBox();
this.txtRoomDescription = new System.Windows.Forms.TextBox();
this.label4 = new System.Windows.Forms.Label();
this.cboRoomID = new System.Windows.Forms.ComboBox();
this.nudRateAmount = new System.Windows.Forms.NumericUpDown();
this.cboRateCode = new System.Windows.Forms.ComboBox();
this.Label2 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.Label14 = new System.Windows.Forms.Label();
this.cboRoomTypeCode = new System.Windows.Forms.ComboBox();
this.nudBreakfastAmount = new System.Windows.Forms.NumericUpDown();
this.label7 = new System.Windows.Forms.Label();
this.cboHasBreakfast = new System.Windows.Forms.ComboBox();
this.label3 = new System.Windows.Forms.Label();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.grdRateTypes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label5 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.GroupBox3.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudRateAmount)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudBreakfastAmount)).BeginInit();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdRateTypes)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// GroupBox3
// 
this.GroupBox3.Controls.Add(this.txtRoomDescription);
this.GroupBox3.Controls.Add(this.label4);
this.GroupBox3.Controls.Add(this.cboRoomID);
this.GroupBox3.Controls.Add(this.nudRateAmount);
this.GroupBox3.Controls.Add(this.cboRateCode);
this.GroupBox3.Controls.Add(this.Label2);
this.GroupBox3.Controls.Add(this.Label1);
this.GroupBox3.Controls.Add(this.Label14);
this.GroupBox3.Controls.Add(this.cboRoomTypeCode);
this.GroupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox3.Location = new System.Drawing.Point(248, -4);
this.GroupBox3.Name = "GroupBox3";
this.GroupBox3.Size = new System.Drawing.Size(303, 307);
this.GroupBox3.TabIndex = 72;
this.GroupBox3.TabStop = false;
// 
// txtRoomDescription
// 
this.txtRoomDescription.BackColor = System.Drawing.SystemColors.ButtonHighlight;
this.txtRoomDescription.Location = new System.Drawing.Point(93, 59);
this.txtRoomDescription.Name = "txtRoomDescription";
this.txtRoomDescription.ReadOnly = true;
this.txtRoomDescription.Size = new System.Drawing.Size(198, 20);
this.txtRoomDescription.TabIndex = 124;
// 
// label4
// 
this.label4.AutoSize = true;
this.label4.ForeColor = System.Drawing.Color.Red;
this.label4.Location = new System.Drawing.Point(100, 233);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(172, 14);
this.label4.TabIndex = 123;
this.label4.Text = "there are hidden object under";
this.label4.Visible = false;
// 
// cboRoomID
// 
this.cboRoomID.BackColor = System.Drawing.SystemColors.Info;
this.cboRoomID.FormattingEnabled = true;
this.cboRoomID.Location = new System.Drawing.Point(93, 31);
this.cboRoomID.Name = "cboRoomID";
this.cboRoomID.Size = new System.Drawing.Size(199, 22);
this.cboRoomID.TabIndex = 122;
this.cboRoomID.SelectedIndexChanged += new System.EventHandler(this.cboRoomID_SelectedIndexChanged);
// 
// nudRateAmount
// 
this.nudRateAmount.DecimalPlaces = 2;
this.nudRateAmount.Location = new System.Drawing.Point(94, 138);
this.nudRateAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
this.nudRateAmount.Name = "nudRateAmount";
this.nudRateAmount.Size = new System.Drawing.Size(96, 20);
this.nudRateAmount.TabIndex = 90;
this.nudRateAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// cboRateCode
// 
this.cboRateCode.BackColor = System.Drawing.SystemColors.Info;
this.cboRateCode.Location = new System.Drawing.Point(93, 93);
this.cboRateCode.Name = "cboRateCode";
this.cboRateCode.Size = new System.Drawing.Size(199, 22);
this.cboRateCode.TabIndex = 89;
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(18, 141);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(72, 17);
this.Label2.TabIndex = 87;
this.Label2.Text = "Rate Amount";
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(18, 95);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(71, 17);
this.Label1.TabIndex = 84;
this.Label1.Text = "Rate Code";
// 
// Label14
// 
this.Label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label14.Location = new System.Drawing.Point(18, 34);
this.Label14.Name = "Label14";
this.Label14.Size = new System.Drawing.Size(71, 17);
this.Label14.TabIndex = 20;
this.Label14.Text = "Room";
// 
// cboRoomTypeCode
// 
this.cboRoomTypeCode.BackColor = System.Drawing.SystemColors.Info;
this.cboRoomTypeCode.Location = new System.Drawing.Point(93, 31);
this.cboRoomTypeCode.Name = "cboRoomTypeCode";
this.cboRoomTypeCode.Size = new System.Drawing.Size(199, 22);
this.cboRoomTypeCode.TabIndex = 88;
// 
// nudBreakfastAmount
// 
this.nudBreakfastAmount.DecimalPlaces = 2;
this.nudBreakfastAmount.Location = new System.Drawing.Point(386, 243);
this.nudBreakfastAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
this.nudBreakfastAmount.Name = "nudBreakfastAmount";
this.nudBreakfastAmount.Size = new System.Drawing.Size(97, 20);
this.nudBreakfastAmount.TabIndex = 121;
this.nudBreakfastAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// label7
// 
this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label7.Location = new System.Drawing.Point(311, 245);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(73, 17);
this.label7.TabIndex = 120;
this.label7.Text = "Amount";
// 
// cboHasBreakfast
// 
this.cboHasBreakfast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboHasBreakfast.Items.AddRange(new object[] {
            "N",
            "Y"});
this.cboHasBreakfast.Location = new System.Drawing.Point(386, 215);
this.cboHasBreakfast.Name = "cboHasBreakfast";
this.cboHasBreakfast.Size = new System.Drawing.Size(54, 22);
this.cboHasBreakfast.TabIndex = 119;
// 
// label3
// 
this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label3.Location = new System.Drawing.Point(311, 217);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(73, 17);
this.label3.TabIndex = 118;
this.label3.Text = "Breakfast";
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(3, 309);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(548, 47);
this.gbxCommands.TabIndex = 187;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(476, 10);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 190;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(201, 10);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 186;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(6, 10);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 4;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(339, 10);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 8;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(270, 10);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 5;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(408, 10);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 9;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// grdRateTypes
// 
this.grdRateTypes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdRateTypes.BackColorSel = System.Drawing.SystemColors.Info;
this.grdRateTypes.Cols = 4;
this.grdRateTypes.ColumnInfo = resources.GetString("grdRateTypes.ColumnInfo");

this.grdRateTypes.ExtendLastCol = true;
this.grdRateTypes.FixedCols = 0;
this.grdRateTypes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdRateTypes.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdRateTypes.ForeColorSel = System.Drawing.Color.Black;
this.grdRateTypes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdRateTypes.Location = new System.Drawing.Point(3, 1);
this.grdRateTypes.Name = "grdRateTypes";
this.grdRateTypes.NodeClosedPicture = null;
this.grdRateTypes.NodeOpenPicture = null;
this.grdRateTypes.OutlineCol = -1;
this.grdRateTypes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdRateTypes.Size = new System.Drawing.Size(241, 308);
this.grdRateTypes.StyleInfo = resources.GetString("grdRateTypes.StyleInfo");
this.grdRateTypes.TabIndex = 189;
this.grdRateTypes.TreeColor = System.Drawing.Color.DarkGray;
this.grdRateTypes.Click += new System.EventHandler(this.grdRateTypes_Click);
this.grdRateTypes.RowColChange += new System.EventHandler(this.grdRateTypes_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label5);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.Label6);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(-9, 106);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 190;
this.pnlSearch.Visible = false;
this.pnlSearch.VisibleChanged += new System.EventHandler(this.pnlSearch_VisibleChanged);
// 
// label5
// 
this.label5.BackColor = System.Drawing.Color.Transparent;
this.label5.Enabled = false;
this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label5.Location = new System.Drawing.Point(200, 99);
this.label5.Name = "label5";
this.label5.Size = new System.Drawing.Size(48, 47);
this.label5.TabIndex = 6;
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
// Label6
// 
this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.Label6.Location = new System.Drawing.Point(16, 42);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(141, 15);
this.Label6.TabIndex = 4;
this.Label6.Text = "Input Search string here";
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
this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F);
this.txtSearch.Location = new System.Drawing.Point(16, 62);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 22);
this.txtSearch.TabIndex = 3;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// RateTypeUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(555, 362);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.GroupBox3);
this.Controls.Add(this.grdRateTypes);
this.Controls.Add(this.gbxCommands);
this.Controls.Add(this.nudBreakfastAmount);
this.Controls.Add(this.label7);
this.Controls.Add(this.cboHasBreakfast);
this.Controls.Add(this.label3);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.MinimizeBox = false;
this.Name = "RateTypeUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Rate Type";
this.Closing += new System.ComponentModel.CancelEventHandler(this.RateTypeUI_Closing);
this.TextChanged += new System.EventHandler(this.RateTypeUI_TextChanged);
this.Load += new System.EventHandler(this.RateTypeUI_Load);
this.GroupBox3.ResumeLayout(false);
this.GroupBox3.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudRateAmount)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudBreakfastAmount)).EndInit();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdRateTypes)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.ResumeLayout(false);

		}
		
		#endregion

        #region " VARIABLES " 

        enum OperationMode { ADD, EDIT };
        private OperationMode mOperationMode;

        private DatasetBinder oDataSetBinder;
        private ControlListener oControlListener;

        private RateType oRateType;
        private RateTypeFacade oRateTypeFacade;
        private RateCodeFacade oRateCodeFacade;
        private RoomTypeFacade oRoomTypeFacade;
        private RoomFacade oRoomFacade;
        #endregion

        #region " CONSTRUCTORS "

        public RateTypeUI()
        {
            InitializeComponent();

            oDataSetBinder = new DatasetBinder();
            oControlListener = new ControlListener();
        }

        #endregion

        #region " METHODS "
		
		public bool load()
        {
            try
            {
                oRateTypeFacade = new RateTypeFacade();
                oRoomFacade = new RoomFacade();
			    oRateType = new RateType();
			    oRateType = (RateType)oRateTypeFacade.loadObject();
                oRoom = oRoomFacade.getRoomList("");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
		
        public bool populateDataGrid(DataTable a_RateType)
        {
            int i = 0;
            try
            {
                this.grdRateTypes.Rows = 1;

                foreach (DataRow dRow in a_RateType.Rows)
                {
                    i = this.grdRateTypes.Rows;
                    this.grdRateTypes.Rows++;

                    this.grdRateTypes.set_TextMatrix(i, 0, dRow["roomtypecode"].ToString());
                    this.grdRateTypes.set_TextMatrix(i, 1, dRow["roomId"].ToString());
                    this.grdRateTypes.set_TextMatrix(i, 2, dRow["ratecode"].ToString());
                    this.grdRateTypes.set_TextMatrix(i, 3, dRow["rateamount"].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Populating Data Grid.");
                return false;
            }
        }

		private bool bindRowToControls()
		{
			try
			{
                if (hasChanges())
                {
                    //if (MessageBox.Show("Save changes made to Rate Type '" + this.cboRateCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (MessageBox.Show("Save changes made to Rate Type '" + this.cboRoomID.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        this.BindingContext[oRateType.Tables[0]].CancelCurrentEdit();
                        this.Text = "Rate Types";
                    }
                }


				oControlListener.StopListen(this);
				this.BindingContext[oRateType.Tables[0]].Position = findItemInDataset(this.grdRateTypes.get_TextMatrix(this.grdRateTypes.Row, 1), this.grdRateTypes.get_TextMatrix(this.grdRateTypes.Row, 2));
                
                foreach (Room _room in oRoom)
                {
                    if (_room.RoomId == cboRoomID.Text)
                    {
                        this.txtRoomDescription.Text = _room.RoomDescription;
                        cboRoomTypeCode.Text = _room.RoomTypecode;
                        break;
                    }
                }

                //cboRoomTypeCode.Text = this.grdRateTypes.get_TextMatrix(this.grdRateTypes.Row, 0);
                
                return true;
			}
			catch (Exception)
			{
                return false;
			}
			finally
			{
                if (this.pnlSearch.Visible == false)
                {
                    oControlListener.Listen(this);
                }
			}
		}


        /********************************************************
           * Purpose: Insert new item into the database
           *********************************************************/
        public int insert()
        {
            try
            {
                int rowsAdded = 0;
                oRateTypeFacade = new RateTypeFacade();
                rowsAdded = oRateTypeFacade.insertObject(ref oRateType);
                return rowsAdded;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /********************************************************
           * Purpose: Update existing item 
           *********************************************************/
        public int update()
        {
            try
            {
                int rowsAffected = 0;
                oRateTypeFacade = new RateTypeFacade();
                rowsAffected = oRateTypeFacade.updateObject(ref oRateType);
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }

        }

		private bool assignEntityValues()
		{
			oRateType.RoomTypeCode = this.cboRoomTypeCode.Text;
            oRateType.RoomID = this.cboRoomID.Text;
            //changed for picc
            //jlo 9-16-10
            //oRateType.RoomID = cboRoomID.SelectedValue.GetType().GetProperty("RoomId").GetValue(cboRoomID.SelectedValue, null).ToString();
			oRateType.RateCode = this.cboRateCode.Text;
			oRateType.RateAmount = this.nudRateAmount.Value;
            oRateType.CreatedBy = GlobalVariables.gLoggedOnUser;
			oRateType.UpdatedBy = GlobalVariables.gLoggedOnUser;
			oRateType.HotelID = GlobalVariables.gHotelId;

			oRateType.HasBreakfast = this.cboHasBreakfast.Text;
			oRateType.BreakfastAmount = this.nudBreakfastAmount.Value ;
            return true;
		}
	
		
        /********************************************************
            * Purpose: Mark existing item as DELETED
            *********************************************************/
        public int delete()
        {
            try
            {
                int rowsAffected = 0;
                oRateTypeFacade = new RateTypeFacade();
                assignEntityValues();
                rowsAffected = oRateTypeFacade.deleteObject(ref oRateType );
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /********************************************************
            * Purpose: Set the state of the button
            *********************************************************/
        private void setActionButtonStates(bool state)
        {
            this.btnSearch.Enabled = state;
            this.btnNew.Enabled = state;
            this.btnDelete.Enabled = state;
            this.btnSave.Enabled = !state;
            this.btnCancel.Enabled = !state;
        }

        /*********************************************************
           * Purpose: Check if control has a valid value
           *********************************************************/
        private bool isRequiredEntriesFilled()
        {
            if (this.cboRoomTypeCode.Text.Trim().Length > 0 &&
                this.cboRateCode.Text.Trim().Length > 0 && 
                this.nudRateAmount.Text.Trim().Length >0 &&
                this.cboRoomID.Text.Trim().Length > 0)

            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Method: searchItem()
        // Description: Search the List of Currency Codes starting 
        // from the Selected Row down
        // if Not Found then start the Search again from the top..
        private void searchItem()
        {
            bool isFound = false;

            if (!this.txtSearch.Text.Equals(""))
            {
                int i = 0;
                for (i = this.grdRateTypes.Row + 1; i <= this.grdRateTypes.Rows - 1; i++)
                {
                    if ( this.grdRateTypes.get_TextMatrix(i, 1).ToUpper().Contains( this.txtSearch.Text.ToUpper() )
                        ||
                        this.grdRateTypes.get_TextMatrix(i, 2).ToUpper().Contains( this.txtSearch.Text.ToUpper() ) )
                    {

                        this.grdRateTypes.Row = i;
                        isFound = true;
                        return;
                    }
                }

                if (!isFound)
                {
                    for (i = 1; i <= this.grdRateTypes.Rows - 1; i++)
                    {
                        if (this.grdRateTypes.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                        ||
                        this.grdRateTypes.get_TextMatrix(i, 2).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.grdRateTypes.Row = i;
                            isFound = true;
                            return;
                        }

                    }
                }

                MessageBox.Show("No matching record found.");
            }

        }

        private int findItemInDataset(string key1, string key2)
        {
            DataRow drRateType;
            int i;

            i = 0;
            foreach (DataRow tempLoopVar_drRateType in oRateType.Tables[0].Rows)
            {
                drRateType = tempLoopVar_drRateType;
                if (drRateType["RoomID"].ToString() == key1 && drRateType["RateCode"].ToString() == key2)
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

        private bool hasChanges()
        {
            if (this.Text.IndexOf("*") > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*********************************************************
             * Purpose: Ready for new transaction
             *********************************************************/
        private void setOperationMode(OperationMode a_OperationMode)
        {
            mOperationMode = a_OperationMode;
        }


        #endregion

        #region " EVENTS "
        private void RateTypeUI_Load(object sender, System.EventArgs e)
        {
            if (load() == true)
            {
                if ( oRateType != null)
                {
                    object obj = (object)oRateType;
                    oDataSetBinder.BindControls(this, ref obj, new ArrayList());

                    populateDataGrid(oRateType.Tables[0]);
                }
                this.cboRateCode.Enabled = false;
                this.cboRoomTypeCode.Enabled = false;
                this.cboRoomID.Enabled = false;
                oControlListener.Listen(this);
            }

			setActionButtonStates(true);
        }
        private System.Collections.Generic.IList<Room> oRoom;
        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            // Set operation mode to ADD
            setOperationMode(OperationMode.ADD);

            // Disable control listeners for all controls in the form
            oControlListener.StopListen(this);

            // Suspend binding context for all controls
            this.BindingContext[oRateType.Tables[0]].SuspendBinding();

            oRateCodeFacade = new RateCodeFacade();
            //oRoomFacade = new RoomFacade();
            this.cboRateCode.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboRoomID.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboRateCode.DataSource = oRateCodeFacade.getRateCodesList();
            //oRoom = oRoomFacade.getRoomList("");
            this.cboRoomID.DataSource = oRoom;
            this.cboRoomID.DisplayMember = "RoomId";
            oRoomTypeFacade = new RoomTypeFacade();
            this.cboRoomTypeCode.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboRoomTypeCode.DataSource = oRoomTypeFacade.getRoomTypesList("");

			this.cboRoomTypeCode.DisplayMember = "RoomTypeCode";

			
            // Set action button states
            setActionButtonStates(false);

            // Enable combo boxes
            this.cboRoomTypeCode.Enabled = true;
            this.cboRateCode.Enabled = true;
            this.cboRoomID.Enabled = true;
            // Set focus to Currency code textbox
            this.cboRoomTypeCode.Focus();

			this.nudRateAmount.Text = "0.00";
			this.cboHasBreakfast.Text = "Y";
			this.nudBreakfastAmount.Text = "0.00";

			try
			{
				int _row = this.grdRateTypes.Row;

				this.cboRoomTypeCode.Text = this.grdRateTypes.get_TextMatrix(_row, 0);
				this.cboRateCode.Text = this.grdRateTypes.get_TextMatrix(_row, 2);
                this.cboRoomID.Text = this.grdRateTypes.get_TextMatrix(_row, 1);
			}
			catch { }

        }

        private void RateTypeUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                //if (MessageBox.Show("Save changes made to Rate Type '" + this.cboRateCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (MessageBox.Show("Save changes made to Rate Type '" + this.cboRoomID.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    assignEntityValues();
                    update();
                }
                else
                {
                    this.BindingContext[oRateType.Tables[0]].CancelCurrentEdit();
                    this.Text = "Rate Types";
                }
            }
        }

        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {
            if (isRequiredEntriesFilled())
            {
                assignEntityValues();

                switch (mOperationMode)
                {
                    case OperationMode.ADD:
                        if (insert() > 0)
                        {
                            MessageBox.Show("Item successfully added.", "Rate Type", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdRateTypes.Rows++;
                            this.grdRateTypes.set_TextMatrix(this.grdRateTypes.Rows - 1, 0, oRateType.RoomTypeCode);
                            this.grdRateTypes.set_TextMatrix(this.grdRateTypes.Rows - 1, 1, oRateType.RoomID);
                            this.grdRateTypes.set_TextMatrix(this.grdRateTypes.Rows - 1, 2, oRateType.RateCode);
                            this.grdRateTypes.set_TextMatrix(this.grdRateTypes.Rows - 1, 3, oRateType.RateAmount.ToString() );

                            // >> Resume Binding
                            this.BindingContext[oRateType.Tables[0]].ResumeBinding();
                            this.Text = "Rate Types";

                            //mode = "";
                            this.cboRateCode.Enabled = false;
                            this.cboRoomTypeCode.Enabled = false;
                            this.cboRoomID.Enabled = false;
                            setActionButtonStates(true);
                            oControlListener.Listen(this);
                        }
                        else
                        {
                            MessageBox.Show("No rows added", "Database Insert Error");
                        }

                        break;
                    case OperationMode.EDIT:
                        if (update() > 0)
                        {
                            MessageBox.Show("Item successfully updated.", "RateType", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdRateTypes.set_TextMatrix(this.grdRateTypes.Row, 3, this.nudRateAmount.Text);

                            this.BindingContext[oRateType.Tables[0]].ResumeBinding();


                            this.Text = "Rate Types";
                            this.cboRateCode.Enabled = false;
                            this.cboRoomTypeCode.Enabled = false;

                            setActionButtonStates(true);
                            oControlListener.Listen(this);

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
                MessageBox.Show("Please input RateType code!", "Save Error");
                this.cboRateCode.Focus();
                this.cboRoomID.Focus();
                return;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                if (this.grdRateTypes.Rows > 1)
                {
                    this.grdRateTypes.Row = 1;
                }
            }
            else
            {
                this.BindingContext[oRateType.Tables[0]].CancelCurrentEdit();
            }
            this.BindingContext[oRateType.Tables[0]].ResumeBinding();

            int _currentRow = grdRateTypes.Row;
            grdRateTypes.Select(0, 0);
            grdRateTypes.Select(_currentRow, 0);
            this.Text = "Rate Types";

            this.cboRateCode.Enabled = false;
            this.cboRoomTypeCode.Enabled = false;
            this.cboRoomID.Enabled = false;
            setActionButtonStates(true);
            oControlListener.Listen(this);
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            this.oControlListener.StopListen(this);
            //if (MessageBox.Show("Are you certain you want to Rate Type '" + this.grdRateTypes.get_TextMatrix(this.grdRateTypes.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (MessageBox.Show("Are you certain you want to Rate Type '" + this.grdRateTypes.get_TextMatrix(this.grdRateTypes.Row, 1) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (delete() > 0)
                {
                    this.grdRateTypes.RemoveItem(this.grdRateTypes.Row);
                }
                else
                {
                    MessageBox.Show("No rows deleted", "Database Update Error");
                }
            }
            this.oControlListener.Listen(this);
        }

        private void RateTypeUI_TextChanged(object sender, System.EventArgs e)
        {
            if (this.Text.IndexOf('*') > 0)
            {
                setOperationMode(OperationMode.EDIT);
                setActionButtonStates(false);
            }
            else
            {
                setActionButtonStates(true);
            }
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            oControlListener.StopListen(this);
            this.pnlSearch.Visible = true;
            this.txtSearch.Text = "";
            this.txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();
            }
        }

        private void grdRateTypes_Click(System.Object sender, System.EventArgs e)
        {
            bindRowToControls();
        }

        private void grdRateTypes_RowColChange(object sender, System.EventArgs e)
        {
            bindRowToControls();
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

        private void picClose_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnCloseSearch_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            searchItem();
        }
		
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRoomID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string _room = cboRoomID.Text;
            //foreach (Room _oRoom in oRoom)
            //{
            //    if (_oRoom.RoomId == _room)
            //    {
            //        cboRoomTypeCode.Text = _oRoom.RoomTypecode;
            //    }
            //}
            txtRoomDescription.Text = cboRoomID.SelectedValue.GetType().GetProperty("RoomDescription").GetValue(cboRoomID.SelectedValue, null).ToString();
            cboRoomTypeCode.Text = cboRoomID.SelectedValue.GetType().GetProperty("RoomTypecode").GetValue(cboRoomID.SelectedValue, null).ToString();
        }

	}
}
