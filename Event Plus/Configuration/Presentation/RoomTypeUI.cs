/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/


using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public class RoomTypeUI : Jinisys.Hotel.UIFramework.Maintenance2UI, ClassMaintenanceInterface
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
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.ComboBox cboShareType;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtRoomTypeCode;
        internal System.Windows.Forms.NumericUpDown nudMaxOccupants;
        internal System.Windows.Forms.NumericUpDown nudNoOfBeds;
        internal System.Windows.Forms.NumericUpDown nudNoOfAdult;
        internal System.Windows.Forms.NumericUpDown nudNoOfChild;
        internal Button btnSearch;
        internal Panel pnlSearch;
        private Label label4;
        internal Label picClose;
        internal Label Label16;
        internal Label Label6;
        internal Button btnCloseSearch;
        internal Button btnFind;
        internal TextBox txtSearch;
        internal Button btnClose;
        internal ComboBox cboRoomSuperType;
        public Label label3;
        private Label label7;
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdRoomTypes;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
			{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomTypeUI));
this.txtRoomTypeCode = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.GroupBox3 = new System.Windows.Forms.GroupBox();
this.cboRoomSuperType = new System.Windows.Forms.ComboBox();
this.label3 = new System.Windows.Forms.Label();
this.nudMaxOccupants = new System.Windows.Forms.NumericUpDown();
this.cboShareType = new System.Windows.Forms.ComboBox();
this.Label1 = new System.Windows.Forms.Label();
this.Label10 = new System.Windows.Forms.Label();
this.Label5 = new System.Windows.Forms.Label();
this.Label9 = new System.Windows.Forms.Label();
this.Label8 = new System.Windows.Forms.Label();
this.nudNoOfBeds = new System.Windows.Forms.NumericUpDown();
this.nudNoOfAdult = new System.Windows.Forms.NumericUpDown();
this.nudNoOfChild = new System.Windows.Forms.NumericUpDown();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.grdRoomTypes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label4 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.label7 = new System.Windows.Forms.Label();
this.GroupBox3.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudMaxOccupants)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudNoOfBeds)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudNoOfAdult)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudNoOfChild)).BeginInit();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdRoomTypes)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// txtRoomTypeCode
// 
this.txtRoomTypeCode.BackColor = System.Drawing.SystemColors.Info;
this.txtRoomTypeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtRoomTypeCode.Enabled = false;
this.txtRoomTypeCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtRoomTypeCode.Location = new System.Drawing.Point(105, 52);
this.txtRoomTypeCode.MaxLength = 50;
this.txtRoomTypeCode.Name = "txtRoomTypeCode";
this.txtRoomTypeCode.Size = new System.Drawing.Size(181, 20);
this.txtRoomTypeCode.TabIndex = 2;
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(14, 55);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(75, 13);
this.Label2.TabIndex = 112;
this.Label2.Text = "Room Type";
// 
// GroupBox3
// 
this.GroupBox3.Controls.Add(this.label7);
this.GroupBox3.Controls.Add(this.cboRoomSuperType);
this.GroupBox3.Controls.Add(this.label3);
this.GroupBox3.Controls.Add(this.nudMaxOccupants);
this.GroupBox3.Controls.Add(this.Label8);
this.GroupBox3.Controls.Add(this.txtRoomTypeCode);
this.GroupBox3.Controls.Add(this.Label2);
this.GroupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox3.Location = new System.Drawing.Point(226, 4);
this.GroupBox3.Name = "GroupBox3";
this.GroupBox3.Size = new System.Drawing.Size(304, 314);
this.GroupBox3.TabIndex = 1;
this.GroupBox3.TabStop = false;
// 
// cboRoomSuperType
// 
this.cboRoomSuperType.BackColor = System.Drawing.SystemColors.Info;
this.cboRoomSuperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboRoomSuperType.Location = new System.Drawing.Point(105, 24);
this.cboRoomSuperType.Name = "cboRoomSuperType";
this.cboRoomSuperType.Size = new System.Drawing.Size(181, 22);
this.cboRoomSuperType.TabIndex = 113;
// 
// label3
// 
this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label3.Location = new System.Drawing.Point(14, 28);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(71, 17);
this.label3.TabIndex = 114;
this.label3.Text = "Group";
// 
// nudMaxOccupants
// 
this.nudMaxOccupants.Location = new System.Drawing.Point(105, 78);
this.nudMaxOccupants.Name = "nudMaxOccupants";
this.nudMaxOccupants.Size = new System.Drawing.Size(48, 20);
this.nudMaxOccupants.TabIndex = 3;
this.nudMaxOccupants.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// cboShareType
// 
this.cboShareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboShareType.Items.AddRange(new object[] {
            "SHAREABLE",
            "NON-SHAREABLE"});
this.cboShareType.Location = new System.Drawing.Point(374, 269);
this.cboShareType.Name = "cboShareType";
this.cboShareType.Size = new System.Drawing.Size(134, 22);
this.cboShareType.TabIndex = 7;
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(283, 273);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(73, 17);
this.Label1.TabIndex = 46;
this.Label1.Text = "Share Type";
// 
// Label10
// 
this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label10.Location = new System.Drawing.Point(294, 252);
this.Label10.Name = "Label10";
this.Label10.Size = new System.Drawing.Size(71, 17);
this.Label10.TabIndex = 48;
this.Label10.Text = "No of Child";
// 
// Label5
// 
this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label5.Location = new System.Drawing.Point(294, 197);
this.Label5.Name = "Label5";
this.Label5.Size = new System.Drawing.Size(62, 17);
this.Label5.TabIndex = 21;
this.Label5.Text = "No of Beds";
// 
// Label9
// 
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.Location = new System.Drawing.Point(294, 225);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(73, 17);
this.Label9.TabIndex = 46;
this.Label9.Text = "No of Adult";
// 
// Label8
// 
this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label8.Location = new System.Drawing.Point(14, 79);
this.Label8.Name = "Label8";
this.Label8.Size = new System.Drawing.Size(89, 17);
this.Label8.TabIndex = 21;
this.Label8.Text = "Max Occupants";
// 
// nudNoOfBeds
// 
this.nudNoOfBeds.Location = new System.Drawing.Point(385, 194);
this.nudNoOfBeds.Name = "nudNoOfBeds";
this.nudNoOfBeds.Size = new System.Drawing.Size(48, 20);
this.nudNoOfBeds.TabIndex = 4;
this.nudNoOfBeds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// nudNoOfAdult
// 
this.nudNoOfAdult.Location = new System.Drawing.Point(385, 222);
this.nudNoOfAdult.Name = "nudNoOfAdult";
this.nudNoOfAdult.Size = new System.Drawing.Size(48, 20);
this.nudNoOfAdult.TabIndex = 5;
this.nudNoOfAdult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// nudNoOfChild
// 
this.nudNoOfChild.Location = new System.Drawing.Point(385, 250);
this.nudNoOfChild.Name = "nudNoOfChild";
this.nudNoOfChild.Size = new System.Drawing.Size(48, 20);
this.nudNoOfChild.TabIndex = 6;
this.nudNoOfChild.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(7, 319);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(523, 48);
this.gbxCommands.TabIndex = 8;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(450, 11);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 14;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(170, 11);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 10;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(6, 11);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 9;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(310, 11);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 12;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(240, 11);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 11;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(380, 11);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 13;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// grdRoomTypes
// 
this.grdRoomTypes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdRoomTypes.BackColorSel = System.Drawing.SystemColors.Info;
this.grdRoomTypes.Cols = 1;
this.grdRoomTypes.ColumnInfo = "1,0,0,0,0,85,Columns:0{Width:139;Caption:\"Room Type\";TextAlign:LeftCenter;TextAli" +
    "gnFixed:CenterCenter;}\t";
this.grdRoomTypes.ExtendLastCol = true;
this.grdRoomTypes.FixedCols = 0;
this.grdRoomTypes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdRoomTypes.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdRoomTypes.ForeColorSel = System.Drawing.Color.Black;
this.grdRoomTypes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdRoomTypes.Location = new System.Drawing.Point(7, 10);
this.grdRoomTypes.Name = "grdRoomTypes";
this.grdRoomTypes.NodeClosedPicture = null;
this.grdRoomTypes.NodeOpenPicture = null;
this.grdRoomTypes.OutlineCol = -1;
this.grdRoomTypes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdRoomTypes.Size = new System.Drawing.Size(214, 308);
this.grdRoomTypes.StyleInfo = resources.GetString("grdRoomTypes.StyleInfo");
this.grdRoomTypes.TabIndex = 0;
this.grdRoomTypes.TreeColor = System.Drawing.Color.DarkGray;
this.grdRoomTypes.Click += new System.EventHandler(this.grdRoomTypes_Click);
this.grdRoomTypes.RowColChange += new System.EventHandler(this.grdRoomTypes_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label4);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.Label6);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(7, 106);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 15;
this.pnlSearch.Visible = false;
// 
// label4
// 
this.label4.BackColor = System.Drawing.Color.Transparent;
this.label4.Enabled = false;
this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label4.Location = new System.Drawing.Point(200, 99);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(48, 47);
this.label4.TabIndex = 6;
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
this.btnCloseSearch.TabIndex = 18;
this.btnCloseSearch.Text = "&Close";
this.btnCloseSearch.UseVisualStyleBackColor = false;
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
this.btnFind.TabIndex = 17;
this.btnFind.Text = "&Find";
this.btnFind.UseVisualStyleBackColor = false;
// 
// txtSearch
// 
this.txtSearch.BackColor = System.Drawing.SystemColors.Info;
this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F);
this.txtSearch.Location = new System.Drawing.Point(16, 62);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 22);
this.txtSearch.TabIndex = 16;
// 
// label7
// 
this.label7.AutoSize = true;
this.label7.ForeColor = System.Drawing.Color.Red;
this.label7.Location = new System.Drawing.Point(68, 252);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(172, 14);
this.label7.TabIndex = 115;
this.label7.Text = "there are hidden object under";
this.label7.Visible = false;
// 
// RoomTypeUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(538, 375);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.GroupBox3);
this.Controls.Add(this.gbxCommands);
this.Controls.Add(this.grdRoomTypes);
this.Controls.Add(this.cboShareType);
this.Controls.Add(this.Label5);
this.Controls.Add(this.Label1);
this.Controls.Add(this.Label10);
this.Controls.Add(this.nudNoOfChild);
this.Controls.Add(this.nudNoOfAdult);
this.Controls.Add(this.Label9);
this.Controls.Add(this.nudNoOfBeds);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "RoomTypeUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Room Type";
this.Closing += new System.ComponentModel.CancelEventHandler(this.RoomTypeUI_Closing);
this.TextChanged += new System.EventHandler(this.RoomTypeUI_TextChanged);
this.Load += new System.EventHandler(this.RoomTypeUI_Load);
this.GroupBox3.ResumeLayout(false);
this.GroupBox3.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudMaxOccupants)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudNoOfBeds)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudNoOfAdult)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudNoOfChild)).EndInit();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdRoomTypes)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.ResumeLayout(false);

			}

        #endregion

        /// <summary>
        /// Local Variables are Camel Casing ( ex. camelCasing )
        /// Variables prefixed by "o" is an Object Instance ( ex. oCurrencyCode )
        /// </summary>
        #region " VARIABLES/CONSTANTS "

        enum OperationMode { ADD, EDIT };
        private OperationMode mOperationMode;

        private ControlListener oControlListener;
        private DatasetBinder oDatasetBinder;

        private RoomType oRoomType;
        private RoomTypeFacade oRoomTypeFacade;

        #endregion

        #region " CONSTRUCTORS "


        public RoomTypeUI()
        {
            InitializeComponent();

            oControlListener = new ControlListener();
            oDatasetBinder = new DatasetBinder();

        }

        #endregion

        #region " METHODS "

        /********************************************************
           * Purpose: Retrieve data from the database
           *********************************************************/
        public bool load()
        {
            try
            {
                oRoomTypeFacade = new RoomTypeFacade();
                oRoomType = new RoomType();
                oRoomType = (RoomType)oRoomTypeFacade.loadObject();
                return true;
            }
            catch (Exception)
            {
                return false;
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
                oRoomTypeFacade = new RoomTypeFacade();
                rowsAdded = oRoomTypeFacade.insertObject(ref oRoomType);
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
                oRoomTypeFacade = new RoomTypeFacade();
                rowsAffected = oRoomTypeFacade.updateObject(ref oRoomType);
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }

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

        private bool bindRowToControls()
        {
            try
            {
                if (hasChanges())
                {
                    if (MessageBox.Show("Save changes made to Room Type '" + this.txtRoomTypeCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        this.BindingContext[oRoomType.Tables[0]].CancelCurrentEdit();
                        this.Text = "Room Types";
                    }
                }

                oControlListener.StopListen(this);
                this.BindingContext[oRoomType.Tables["RoomTypes"]].Position = findItemInDataset(this.grdRoomTypes.get_TextMatrix(this.grdRoomTypes.Row, 0));


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

        private bool assignEntityValues()
        {
            oRoomType.RoomTypeCode = this.txtRoomTypeCode.Text;
            oRoomType.MaxOccupants = int.Parse(this.nudMaxOccupants.Text);
            oRoomType.NoOfBeds = int.Parse(this.nudNoOfBeds.Text);
            oRoomType.NoofAdult = int.Parse(this.nudNoOfAdult.Text);
            oRoomType.NoofChild = int.Parse(this.nudNoOfChild.Text);
            oRoomType.ShareType = this.cboShareType.Text;
            oRoomType.HotelID = GlobalVariables.gHotelId;
            oRoomType.CreatedBy = GlobalVariables.gLoggedOnUser;
            oRoomType.UpdatedBy = GlobalVariables.gLoggedOnUser;

            /* FP-SCR-00139 #2 [07.20.2010]
             * add additional field to get room's super type */
            oRoomType.RoomSuperType = this.cboRoomSuperType.Text;

            return true;
        }

        /*********************************************************
         * Purpose: Mark existing item as DELETED                *
         *********************************************************/
        public int delete()
        {
            try
            {
                int rowsAffected = 0;
                oRoomTypeFacade = new RoomTypeFacade();
                assignEntityValues();

                rowsAffected = oRoomTypeFacade.deleteObject(ref oRoomType);
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
            if (this.txtRoomTypeCode.Text.Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // >> Limits textbox to numbers only
        private bool numOnly(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }

            return true;

        }

        /// <summary>
        /// Searches the Item-Key in the Dataset and returns the Index of the Item...
        /// </summary>
        /// <param name="key"> string "key" usually the unique index </param>
        /// <returns> integer (index) </returns>
        private int findItemInDataset(string key)
        {
            int i;

            i = 0;
            foreach (DataRow drGuest in oRoomType.Tables[0].Rows)
            {
                if (drGuest["RoomTypeCode"].ToString() == key)
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
         * Purpose: Populate record to Grid Control
         *********************************************************/
        public bool populateDataGrid(DataTable a_RoomType)
        {
            int i = 0;
            try
            {
                this.grdRoomTypes.Rows = 1;

                foreach (DataRow dRow in a_RoomType.Rows)
                {
                    i = this.grdRoomTypes.Rows;
                    this.grdRoomTypes.Rows++;

                    this.grdRoomTypes.set_TextMatrix(i, 0, dRow[0].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Populating Data Grid.");
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

        private void RoomTypeUI_Load(object sender, System.EventArgs e)
        {
            
            oControlListener.StopListen(this);
            
            if (load() == true)
            {
                
                if (!oRoomType.Equals(null))
                {
                    object obj = (object)oRoomType;

                    loadRoomSuperTypes();
                    oDatasetBinder.BindControls(this, ref obj, new ArrayList());
                    
                    populateDataGrid(oRoomType.Tables[0]);
                    
                    
                    
                }                
                this.txtRoomTypeCode.Enabled = false;
                oControlListener.Listen(this);
            }
            
            setActionButtonStates(true);
            
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            // Set operation mode to ADD
            setOperationMode(OperationMode.ADD);

            // Disable control listeners for all controls in the form
            oControlListener.StopListen(this);

            // Suspend binding context for all controls
            this.BindingContext[oRoomType.Tables[0]].SuspendBinding();

            // Set action button states
            setActionButtonStates(false);

            // Enable Currency code textbox
            this.txtRoomTypeCode.Enabled = true;

            // Set focus to Currency code textbox
            this.txtRoomTypeCode.Focus();

            this.nudMaxOccupants.Text = "0";
            this.nudNoOfAdult.Text = "0";
            this.nudNoOfBeds.Text = "0";
            this.nudNoOfChild.Text = "0";

        }

        private void RoomTypeUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                if (MessageBox.Show("Save changes made to Room Type '" + this.txtRoomTypeCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    assignEntityValues();
                    update();
                }
                else
                {
                    this.BindingContext[oRoomType.Tables[0]].CancelCurrentEdit();
                    this.Text = "Room Types";
                }
            }
        }

        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {
            if (isRequiredEntriesFilled())
            {
                assignEntityValues();

                /* FP - SCR - 00139 #3
                /  checks whether system is used for EMM only */
                if (!cboRoomSuperType.Text.Contains("FUNCTION") && bool.Parse(ConfigVariables.gIsEMMOnly) == true)
                {
                    MessageBox.Show("Room Type not supported.\nPlease contact system administrator for details.", "Room Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /* end of SCR -00139 */

                switch (mOperationMode)
                {
                    case OperationMode.ADD:
                        if (insert() > 0)
                        {
                            MessageBox.Show("Item successfully added.", "Room Type", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdRoomTypes.Rows++;
                            this.grdRoomTypes.set_TextMatrix(this.grdRoomTypes.Rows - 1, 0, oRoomType.RoomTypeCode);

                            // >> Resume Binding
                            this.BindingContext[oRoomType.Tables[0]].ResumeBinding();
                            this.Text = "Room Types";

                            //mode = "";
                            this.txtRoomTypeCode.Enabled = false;

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
                            MessageBox.Show("Item successfully updated.", "Room Types", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.BindingContext[oRoomType.Tables[0]].ResumeBinding();
                            this.Text = "Room Types";
                            this.txtRoomTypeCode.Enabled = false;
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
                MessageBox.Show("Please input currency code!", "Save Error");
                this.txtRoomTypeCode.Focus();
                return;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                if (this.grdRoomTypes.Rows > 1)
                {
                    this.grdRoomTypes.Row = 1;
                }
            }
            else
            {
                this.BindingContext[oRoomType.Tables[0]].CancelCurrentEdit();
            }

            this.BindingContext[oRoomType.Tables[0]].ResumeBinding();

            this.Text = "Room Types";
            this.txtRoomTypeCode.Enabled = false;

            setActionButtonStates(true);
            oControlListener.Listen(this);
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            this.oControlListener.StopListen(this);
            if (MessageBox.Show("Are you certain you want to remove Room Type '" + this.txtRoomTypeCode.Text + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (delete() > 0)
                {
                    this.grdRoomTypes.RemoveItem(this.grdRoomTypes.Row);
                }
                else
                {
                    MessageBox.Show("No rows deleted", "Database Update Error");
                }
            }
            this.oControlListener.Listen(this);
        }

        private void RoomTypeUI_TextChanged(object sender, System.EventArgs e)
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

        private void grdRoomTypes_Click(System.Object sender, System.EventArgs e)
        {
            bindRowToControls();
        }

        private void grdRoomTypes_RowColChange(object sender, System.EventArgs e)
        {
            bindRowToControls();
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

        /* FP-SCR-00139 #2 [07.20.2010]
         * loads all Room Super Types */
        private void loadRoomSuperTypes()
        {
            RoomSuperTypeFacade _oRoomSuperTypeFacade = new RoomSuperTypeFacade();
            DataTable _oDataTable = _oRoomSuperTypeFacade.getRoomSuperTypes();

            foreach (DataRow _dRow in _oDataTable.Rows)
            {
                cboRoomSuperType.Items.Add(_dRow["RoomSuperType"].ToString());
            }
        }
    }
}	
