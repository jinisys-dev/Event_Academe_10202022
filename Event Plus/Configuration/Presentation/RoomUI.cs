/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/


using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public class RoomUI : Jinisys.Hotel.UIFramework.MiscellaneousUI, ClassMaintenanceInterface
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
        internal System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnPlot;
        internal System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.TextBox txtTelephoneNo;
        public System.Windows.Forms.TextBox txtRoomID;
        public System.Windows.Forms.Label Label13;
        public System.Windows.Forms.GroupBox gbxSmokingType;
        public System.Windows.Forms.CheckBox chkSmokingType;
        public System.Windows.Forms.GroupBox gbxAdjacency;
        public System.Windows.Forms.ComboBox cboAdjRight;
        public System.Windows.Forms.ComboBox cboAdjLeft;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.GroupBox gbxLocation;
        public System.Windows.Forms.TextBox txtFloor;
        public System.Windows.Forms.ComboBox cboDirFacing;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.GroupBox gbxAmenities;
		internal System.Windows.Forms.ListView lvwAmenities;
		public System.Windows.Forms.Label Label15;
        public System.Windows.Forms.GroupBox gbxRoomImg;
        public System.Windows.Forms.PictureBox picRoomImg;
        internal System.Windows.Forms.TextBox txtRoomImage;
		public System.Windows.Forms.GroupBox GroupBox3;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label14;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.PictureBox picRoomImageLarge;
        internal System.Windows.Forms.OpenFileDialog ofdPickRoomImage;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        public System.Windows.Forms.CheckBox chkWindows;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal Panel pnlSearch;
        private Label label6;
        internal Label picClose;
        internal Label Label16;
        internal Label label8;
        internal Button btnCloseSearch;
        internal Button btnFind;
        internal TextBox txtSearch;
        internal Button btnClose;
		public CheckBox chkBedSplittable;
		private ComboBox cboRoomTypeCode;
		private ComboBox cboNoOfChild;
		private ComboBox cboNoOfAdult;
		private ComboBox cboNoOfBeds;
		private ComboBox cboMaxOccupants;
		private ComboBox cboShareType;
        public TextBox txtRoomDescription;
        public Label label17;
        private TextBox txtRoomArea;
        private Label label18;
        internal Button btnCombinations;
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdRooms;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomUI));
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnCombinations = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.btnPlot = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.gbxAmenities = new System.Windows.Forms.GroupBox();
this.lvwAmenities = new System.Windows.Forms.ListView();
this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
this.Label15 = new System.Windows.Forms.Label();
this.txtRoomArea = new System.Windows.Forms.TextBox();
this.label18 = new System.Windows.Forms.Label();
this.txtTelephoneNo = new System.Windows.Forms.TextBox();
this.txtRoomID = new System.Windows.Forms.TextBox();
this.Label13 = new System.Windows.Forms.Label();
this.gbxSmokingType = new System.Windows.Forms.GroupBox();
this.chkBedSplittable = new System.Windows.Forms.CheckBox();
this.chkSmokingType = new System.Windows.Forms.CheckBox();
this.chkWindows = new System.Windows.Forms.CheckBox();
this.gbxAdjacency = new System.Windows.Forms.GroupBox();
this.cboAdjRight = new System.Windows.Forms.ComboBox();
this.cboAdjLeft = new System.Windows.Forms.ComboBox();
this.Label4 = new System.Windows.Forms.Label();
this.Label2 = new System.Windows.Forms.Label();
this.gbxLocation = new System.Windows.Forms.GroupBox();
this.txtFloor = new System.Windows.Forms.TextBox();
this.cboDirFacing = new System.Windows.Forms.ComboBox();
this.Label9 = new System.Windows.Forms.Label();
this.Label10 = new System.Windows.Forms.Label();
this.gbxRoomImg = new System.Windows.Forms.GroupBox();
this.picRoomImg = new System.Windows.Forms.PictureBox();
this.txtRoomImage = new System.Windows.Forms.TextBox();
this.GroupBox3 = new System.Windows.Forms.GroupBox();
this.txtRoomDescription = new System.Windows.Forms.TextBox();
this.label17 = new System.Windows.Forms.Label();
this.cboShareType = new System.Windows.Forms.ComboBox();
this.cboNoOfChild = new System.Windows.Forms.ComboBox();
this.cboNoOfAdult = new System.Windows.Forms.ComboBox();
this.cboNoOfBeds = new System.Windows.Forms.ComboBox();
this.cboMaxOccupants = new System.Windows.Forms.ComboBox();
this.cboRoomTypeCode = new System.Windows.Forms.ComboBox();
this.Label12 = new System.Windows.Forms.Label();
this.Label11 = new System.Windows.Forms.Label();
this.Label14 = new System.Windows.Forms.Label();
this.Label5 = new System.Windows.Forms.Label();
this.Label3 = new System.Windows.Forms.Label();
this.Label7 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.picRoomImageLarge = new System.Windows.Forms.PictureBox();
this.ofdPickRoomImage = new System.Windows.Forms.OpenFileDialog();
this.grdRooms = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label6 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.label8 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.gbxCommands.SuspendLayout();
this.GroupBox1.SuspendLayout();
this.gbxAmenities.SuspendLayout();
this.gbxSmokingType.SuspendLayout();
this.gbxAdjacency.SuspendLayout();
this.gbxLocation.SuspendLayout();
this.gbxRoomImg.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.picRoomImg)).BeginInit();
this.GroupBox3.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.picRoomImageLarge)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.grdRooms)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnCombinations);
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Controls.Add(this.btnPlot);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Location = new System.Drawing.Point(5, 440);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(713, 46);
this.gbxCommands.TabIndex = 24;
this.gbxCommands.TabStop = false;
// 
// btnCombinations
// 
this.btnCombinations.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCombinations.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCombinations.Location = new System.Drawing.Point(258, 10);
this.btnCombinations.Name = "btnCombinations";
this.btnCombinations.Size = new System.Drawing.Size(103, 31);
this.btnCombinations.TabIndex = 32;
this.btnCombinations.Text = "Combine Rooms";
this.btnCombinations.Click += new System.EventHandler(this.btnCombinations_Click);
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(641, 10);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 31;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(6, 10);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 25;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(503, 10);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 29;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(434, 10);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 28;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(572, 10);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 30;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// btnPlot
// 
this.btnPlot.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnPlot.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnPlot.Location = new System.Drawing.Point(75, 10);
this.btnPlot.Name = "btnPlot";
this.btnPlot.Size = new System.Drawing.Size(126, 31);
this.btnPlot.TabIndex = 26;
this.btnPlot.Text = "&Plot Room Coords";
this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(365, 10);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 27;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// GroupBox1
// 
this.GroupBox1.Controls.Add(this.gbxAmenities);
this.GroupBox1.Controls.Add(this.txtRoomArea);
this.GroupBox1.Controls.Add(this.label18);
this.GroupBox1.Controls.Add(this.txtTelephoneNo);
this.GroupBox1.Controls.Add(this.txtRoomID);
this.GroupBox1.Controls.Add(this.Label13);
this.GroupBox1.Controls.Add(this.gbxSmokingType);
this.GroupBox1.Controls.Add(this.gbxAdjacency);
this.GroupBox1.Controls.Add(this.gbxLocation);
this.GroupBox1.Controls.Add(this.gbxRoomImg);
this.GroupBox1.Controls.Add(this.GroupBox3);
this.GroupBox1.Controls.Add(this.Label1);
this.GroupBox1.Location = new System.Drawing.Point(225, -1);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(493, 444);
this.GroupBox1.TabIndex = 1;
this.GroupBox1.TabStop = false;
// 
// gbxAmenities
// 
this.gbxAmenities.Controls.Add(this.lvwAmenities);
this.gbxAmenities.Controls.Add(this.Label15);
this.gbxAmenities.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.gbxAmenities.Location = new System.Drawing.Point(171, 210);
this.gbxAmenities.Name = "gbxAmenities";
this.gbxAmenities.Size = new System.Drawing.Size(316, 180);
this.gbxAmenities.TabIndex = 17;
this.gbxAmenities.TabStop = false;
// 
// lvwAmenities
// 
this.lvwAmenities.CheckBoxes = true;
this.lvwAmenities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader4});
this.lvwAmenities.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lvwAmenities.FullRowSelect = true;
this.lvwAmenities.GridLines = true;
this.lvwAmenities.Location = new System.Drawing.Point(8, 22);
this.lvwAmenities.Name = "lvwAmenities";
this.lvwAmenities.Size = new System.Drawing.Size(300, 143);
this.lvwAmenities.TabIndex = 20;
this.lvwAmenities.UseCompatibleStateImageBehavior = false;
this.lvwAmenities.View = System.Windows.Forms.View.Details;
this.lvwAmenities.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwAmenities_ItemChecked);
// 
// ColumnHeader1
// 
this.ColumnHeader1.Text = "ID";
this.ColumnHeader1.Width = 53;
// 
// ColumnHeader4
// 
this.ColumnHeader4.Text = "NAME";
this.ColumnHeader4.Width = 227;
// 
// Label15
// 
this.Label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label15.ForeColor = System.Drawing.Color.Black;
this.Label15.Location = new System.Drawing.Point(8, 8);
this.Label15.Name = "Label15";
this.Label15.Size = new System.Drawing.Size(127, 16);
this.Label15.TabIndex = 13;
this.Label15.Text = "Amenities";
// 
// txtRoomArea
// 
this.txtRoomArea.Location = new System.Drawing.Point(75, 419);
this.txtRoomArea.Name = "txtRoomArea";
this.txtRoomArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
this.txtRoomArea.Size = new System.Drawing.Size(100, 20);
this.txtRoomArea.TabIndex = 93;
// 
// label18
// 
this.label18.AutoSize = true;
this.label18.Location = new System.Drawing.Point(9, 422);
this.label18.Name = "label18";
this.label18.Size = new System.Drawing.Size(62, 14);
this.label18.TabIndex = 92;
this.label18.Text = "Area (sqm)";
// 
// txtTelephoneNo
// 
this.txtTelephoneNo.BackColor = System.Drawing.SystemColors.Info;
this.txtTelephoneNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtTelephoneNo.Location = new System.Drawing.Point(76, 391);
this.txtTelephoneNo.MaxLength = 15;
this.txtTelephoneNo.Name = "txtTelephoneNo";
this.txtTelephoneNo.Size = new System.Drawing.Size(99, 20);
this.txtTelephoneNo.TabIndex = 16;
// 
// txtRoomID
// 
this.txtRoomID.BackColor = System.Drawing.SystemColors.Info;
this.txtRoomID.Enabled = false;
this.txtRoomID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtRoomID.Location = new System.Drawing.Point(66, 20);
this.txtRoomID.MaxLength = 11;
this.txtRoomID.Name = "txtRoomID";
this.txtRoomID.Size = new System.Drawing.Size(93, 20);
this.txtRoomID.TabIndex = 2;
this.txtRoomID.TextChanged += new System.EventHandler(this.txtRoomID_TextChanged);
// 
// Label13
// 
this.Label13.BackColor = System.Drawing.Color.Transparent;
this.Label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label13.ForeColor = System.Drawing.Color.Black;
this.Label13.Location = new System.Drawing.Point(9, 393);
this.Label13.Name = "Label13";
this.Label13.Size = new System.Drawing.Size(59, 16);
this.Label13.TabIndex = 91;
this.Label13.Text = "Phone No.";
// 
// gbxSmokingType
// 
this.gbxSmokingType.Controls.Add(this.chkBedSplittable);
this.gbxSmokingType.Controls.Add(this.chkSmokingType);
this.gbxSmokingType.Controls.Add(this.chkWindows);
this.gbxSmokingType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.gbxSmokingType.Location = new System.Drawing.Point(209, 391);
this.gbxSmokingType.Name = "gbxSmokingType";
this.gbxSmokingType.Size = new System.Drawing.Size(278, 45);
this.gbxSmokingType.TabIndex = 20;
this.gbxSmokingType.TabStop = false;
// 
// chkBedSplittable
// 
this.chkBedSplittable.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.chkBedSplittable.Location = new System.Drawing.Point(173, 16);
this.chkBedSplittable.Name = "chkBedSplittable";
this.chkBedSplittable.Size = new System.Drawing.Size(99, 20);
this.chkBedSplittable.TabIndex = 23;
this.chkBedSplittable.Text = "Bed Splittable";
// 
// chkSmokingType
// 
this.chkSmokingType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.chkSmokingType.Location = new System.Drawing.Point(16, 16);
this.chkSmokingType.Name = "chkSmokingType";
this.chkSmokingType.Size = new System.Drawing.Size(72, 20);
this.chkSmokingType.TabIndex = 21;
this.chkSmokingType.Text = "Smoking";
// 
// chkWindows
// 
this.chkWindows.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.chkWindows.Location = new System.Drawing.Point(96, 16);
this.chkWindows.Name = "chkWindows";
this.chkWindows.Size = new System.Drawing.Size(72, 20);
this.chkWindows.TabIndex = 22;
this.chkWindows.Text = "Windows";
// 
// gbxAdjacency
// 
this.gbxAdjacency.Controls.Add(this.cboAdjRight);
this.gbxAdjacency.Controls.Add(this.cboAdjLeft);
this.gbxAdjacency.Controls.Add(this.Label4);
this.gbxAdjacency.Controls.Add(this.Label2);
this.gbxAdjacency.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.gbxAdjacency.Location = new System.Drawing.Point(6, 298);
this.gbxAdjacency.Name = "gbxAdjacency";
this.gbxAdjacency.Size = new System.Drawing.Size(159, 87);
this.gbxAdjacency.TabIndex = 13;
this.gbxAdjacency.TabStop = false;
this.gbxAdjacency.Text = "Adjacency";
// 
// cboAdjRight
// 
this.cboAdjRight.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cboAdjRight.Location = new System.Drawing.Point(64, 50);
this.cboAdjRight.MaxLength = 15;
this.cboAdjRight.Name = "cboAdjRight";
this.cboAdjRight.Size = new System.Drawing.Size(77, 22);
this.cboAdjRight.TabIndex = 17;
// 
// cboAdjLeft
// 
this.cboAdjLeft.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cboAdjLeft.Location = new System.Drawing.Point(64, 21);
this.cboAdjLeft.MaxLength = 14;
this.cboAdjLeft.Name = "cboAdjLeft";
this.cboAdjLeft.Size = new System.Drawing.Size(76, 22);
this.cboAdjLeft.TabIndex = 16;
// 
// Label4
// 
this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label4.Location = new System.Drawing.Point(12, 52);
this.Label4.Name = "Label4";
this.Label4.Size = new System.Drawing.Size(32, 17);
this.Label4.TabIndex = 4;
this.Label4.Text = "Right";
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(12, 23);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(33, 17);
this.Label2.TabIndex = 2;
this.Label2.Text = "Left";
// 
// gbxLocation
// 
this.gbxLocation.Controls.Add(this.txtFloor);
this.gbxLocation.Controls.Add(this.cboDirFacing);
this.gbxLocation.Controls.Add(this.Label9);
this.gbxLocation.Controls.Add(this.Label10);
this.gbxLocation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.gbxLocation.Location = new System.Drawing.Point(6, 210);
this.gbxLocation.Name = "gbxLocation";
this.gbxLocation.Size = new System.Drawing.Size(159, 84);
this.gbxLocation.TabIndex = 10;
this.gbxLocation.TabStop = false;
this.gbxLocation.Text = "Location";
// 
// txtFloor
// 
this.txtFloor.BackColor = System.Drawing.SystemColors.Info;
this.txtFloor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtFloor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtFloor.ForeColor = System.Drawing.Color.Black;
this.txtFloor.Location = new System.Drawing.Point(64, 19);
this.txtFloor.MaxLength = 10;
this.txtFloor.Name = "txtFloor";
this.txtFloor.Size = new System.Drawing.Size(85, 20);
this.txtFloor.TabIndex = 11;
// 
// cboDirFacing
// 
this.cboDirFacing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboDirFacing.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cboDirFacing.ItemHeight = 14;
this.cboDirFacing.Items.AddRange(new object[] {
            "EAST",
            "WEST",
            "NORTH",
            "SOUTH"});
this.cboDirFacing.Location = new System.Drawing.Point(64, 46);
this.cboDirFacing.MaxLength = 12;
this.cboDirFacing.Name = "cboDirFacing";
this.cboDirFacing.Size = new System.Drawing.Size(88, 22);
this.cboDirFacing.TabIndex = 15;
// 
// Label9
// 
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.Location = new System.Drawing.Point(11, 48);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(50, 17);
this.Label9.TabIndex = 4;
this.Label9.Text = "Direction";
// 
// Label10
// 
this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label10.Location = new System.Drawing.Point(11, 24);
this.Label10.Name = "Label10";
this.Label10.Size = new System.Drawing.Size(33, 17);
this.Label10.TabIndex = 2;
this.Label10.Text = "Floor";
// 
// gbxRoomImg
// 
this.gbxRoomImg.Controls.Add(this.picRoomImg);
this.gbxRoomImg.Controls.Add(this.txtRoomImage);
this.gbxRoomImg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.gbxRoomImg.Location = new System.Drawing.Point(311, 17);
this.gbxRoomImg.Name = "gbxRoomImg";
this.gbxRoomImg.Size = new System.Drawing.Size(174, 192);
this.gbxRoomImg.TabIndex = 87;
this.gbxRoomImg.TabStop = false;
this.gbxRoomImg.Text = "Room Image";
// 
// picRoomImg
// 
this.picRoomImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.picRoomImg.Cursor = System.Windows.Forms.Cursors.Hand;
this.picRoomImg.Location = new System.Drawing.Point(13, 23);
this.picRoomImg.Name = "picRoomImg";
this.picRoomImg.Size = new System.Drawing.Size(147, 156);
this.picRoomImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
this.picRoomImg.TabIndex = 16;
this.picRoomImg.TabStop = false;
this.picRoomImg.MouseLeave += new System.EventHandler(this.picRoomImg_MouseLeave);
this.picRoomImg.Click += new System.EventHandler(this.picRoomImg_Click);
this.picRoomImg.MouseHover += new System.EventHandler(this.picRoomImg_MouseHover);
// 
// txtRoomImage
// 
this.txtRoomImage.Location = new System.Drawing.Point(43, 28);
this.txtRoomImage.Name = "txtRoomImage";
this.txtRoomImage.Size = new System.Drawing.Size(81, 20);
this.txtRoomImage.TabIndex = 17;
this.txtRoomImage.TextChanged += new System.EventHandler(this.txtRoomImage_TextChanged);
// 
// GroupBox3
// 
this.GroupBox3.Controls.Add(this.txtRoomDescription);
this.GroupBox3.Controls.Add(this.label17);
this.GroupBox3.Controls.Add(this.cboShareType);
this.GroupBox3.Controls.Add(this.cboNoOfChild);
this.GroupBox3.Controls.Add(this.cboNoOfAdult);
this.GroupBox3.Controls.Add(this.cboNoOfBeds);
this.GroupBox3.Controls.Add(this.cboMaxOccupants);
this.GroupBox3.Controls.Add(this.cboRoomTypeCode);
this.GroupBox3.Controls.Add(this.Label12);
this.GroupBox3.Controls.Add(this.Label11);
this.GroupBox3.Controls.Add(this.Label14);
this.GroupBox3.Controls.Add(this.Label5);
this.GroupBox3.Controls.Add(this.Label3);
this.GroupBox3.Controls.Add(this.Label7);
this.GroupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox3.Location = new System.Drawing.Point(6, 45);
this.GroupBox3.Name = "GroupBox3";
this.GroupBox3.Size = new System.Drawing.Size(297, 164);
this.GroupBox3.TabIndex = 3;
this.GroupBox3.TabStop = false;
this.GroupBox3.Text = "Room Type";
// 
// txtRoomDescription
// 
this.txtRoomDescription.BackColor = System.Drawing.SystemColors.Info;
this.txtRoomDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtRoomDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtRoomDescription.Location = new System.Drawing.Point(85, 23);
this.txtRoomDescription.MaxLength = 30;
this.txtRoomDescription.Name = "txtRoomDescription";
this.txtRoomDescription.Size = new System.Drawing.Size(206, 20);
this.txtRoomDescription.TabIndex = 92;
// 
// label17
// 
this.label17.BackColor = System.Drawing.Color.Transparent;
this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label17.ForeColor = System.Drawing.Color.Black;
this.label17.Location = new System.Drawing.Point(12, 25);
this.label17.Name = "label17";
this.label17.Size = new System.Drawing.Size(70, 16);
this.label17.TabIndex = 93;
this.label17.Text = "Description";
// 
// cboShareType
// 
this.cboShareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboShareType.FormattingEnabled = true;
this.cboShareType.Items.AddRange(new object[] {
            "",
            "SHAREABLE",
            "NON-SHAREABLE"});
this.cboShareType.Location = new System.Drawing.Point(98, 133);
this.cboShareType.Name = "cboShareType";
this.cboShareType.Size = new System.Drawing.Size(144, 22);
this.cboShareType.TabIndex = 89;
// 
// cboNoOfChild
// 
this.cboNoOfChild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboNoOfChild.FormattingEnabled = true;
this.cboNoOfChild.Location = new System.Drawing.Point(240, 105);
this.cboNoOfChild.Name = "cboNoOfChild";
this.cboNoOfChild.Size = new System.Drawing.Size(51, 22);
this.cboNoOfChild.TabIndex = 88;
// 
// cboNoOfAdult
// 
this.cboNoOfAdult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboNoOfAdult.FormattingEnabled = true;
this.cboNoOfAdult.Location = new System.Drawing.Point(240, 79);
this.cboNoOfAdult.Name = "cboNoOfAdult";
this.cboNoOfAdult.Size = new System.Drawing.Size(51, 22);
this.cboNoOfAdult.TabIndex = 87;
// 
// cboNoOfBeds
// 
this.cboNoOfBeds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboNoOfBeds.FormattingEnabled = true;
this.cboNoOfBeds.Location = new System.Drawing.Point(98, 105);
this.cboNoOfBeds.Name = "cboNoOfBeds";
this.cboNoOfBeds.Size = new System.Drawing.Size(51, 22);
this.cboNoOfBeds.TabIndex = 86;
// 
// cboMaxOccupants
// 
this.cboMaxOccupants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboMaxOccupants.FormattingEnabled = true;
this.cboMaxOccupants.Location = new System.Drawing.Point(98, 79);
this.cboMaxOccupants.Name = "cboMaxOccupants";
this.cboMaxOccupants.Size = new System.Drawing.Size(51, 22);
this.cboMaxOccupants.TabIndex = 85;
// 
// cboRoomTypeCode
// 
this.cboRoomTypeCode.BackColor = System.Drawing.SystemColors.Info;
this.cboRoomTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboRoomTypeCode.FormattingEnabled = true;
this.cboRoomTypeCode.Location = new System.Drawing.Point(85, 49);
this.cboRoomTypeCode.Name = "cboRoomTypeCode";
this.cboRoomTypeCode.Size = new System.Drawing.Size(206, 22);
this.cboRoomTypeCode.TabIndex = 84;
// 
// Label12
// 
this.Label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label12.Location = new System.Drawing.Point(11, 82);
this.Label12.Name = "Label12";
this.Label12.Size = new System.Drawing.Size(85, 16);
this.Label12.TabIndex = 83;
this.Label12.Text = "Max Occupants";
// 
// Label11
// 
this.Label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label11.Location = new System.Drawing.Point(11, 54);
this.Label11.Name = "Label11";
this.Label11.Size = new System.Drawing.Size(64, 17);
this.Label11.TabIndex = 31;
this.Label11.Text = "Room Type";
// 
// Label14
// 
this.Label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label14.Location = new System.Drawing.Point(11, 108);
this.Label14.Name = "Label14";
this.Label14.Size = new System.Drawing.Size(71, 16);
this.Label14.TabIndex = 20;
this.Label14.Text = "No. Of Beds";
// 
// Label5
// 
this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label5.Location = new System.Drawing.Point(200, 82);
this.Label5.Name = "Label5";
this.Label5.Size = new System.Drawing.Size(40, 17);
this.Label5.TabIndex = 40;
this.Label5.Text = "Adult";
// 
// Label3
// 
this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label3.Location = new System.Drawing.Point(200, 108);
this.Label3.Name = "Label3";
this.Label3.Size = new System.Drawing.Size(40, 17);
this.Label3.TabIndex = 38;
this.Label3.Text = "Child";
// 
// Label7
// 
this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label7.Location = new System.Drawing.Point(11, 136);
this.Label7.Name = "Label7";
this.Label7.Size = new System.Drawing.Size(70, 16);
this.Label7.TabIndex = 4;
this.Label7.Text = "Share Type";
// 
// Label1
// 
this.Label1.BackColor = System.Drawing.Color.Transparent;
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.ForeColor = System.Drawing.Color.Black;
this.Label1.Location = new System.Drawing.Point(9, 22);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(52, 16);
this.Label1.TabIndex = 81;
this.Label1.Text = "Room Id";
// 
// picRoomImageLarge
// 
this.picRoomImageLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.picRoomImageLarge.Cursor = System.Windows.Forms.Cursors.Hand;
this.picRoomImageLarge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.picRoomImageLarge.Location = new System.Drawing.Point(718, 83);
this.picRoomImageLarge.Name = "picRoomImageLarge";
this.picRoomImageLarge.Size = new System.Drawing.Size(314, 265);
this.picRoomImageLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
this.picRoomImageLarge.TabIndex = 127;
this.picRoomImageLarge.TabStop = false;
this.picRoomImageLarge.Visible = false;
// 
// ofdPickRoomImage
// 
this.ofdPickRoomImage.Filter = "JPEG (*.jpg)|*.jpg|GIF (*.gif)|*.gif|Bitmap (*.bmp)|*.bmp|All files (*.*)|*.*";
this.ofdPickRoomImage.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdPickRoomImage_FileOk);
// 
// grdRooms
// 
this.grdRooms.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdRooms.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.grdRooms.BackColorSel = System.Drawing.SystemColors.Info;
this.grdRooms.Cols = 2;
this.grdRooms.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:52;Caption:\"Room\";TextAlign:LeftCenter;TextAlignFixe" +
    "d:CenterCenter;}\t1{Width:95;Caption:\"Room Type\";TextAlign:LeftCenter;TextAlignFi" +
    "xed:CenterCenter;}\t";
this.grdRooms.ExtendLastCol = true;
this.grdRooms.FixedCols = 0;
this.grdRooms.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdRooms.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdRooms.ForeColorSel = System.Drawing.Color.Black;
this.grdRooms.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdRooms.Location = new System.Drawing.Point(6, 4);
this.grdRooms.Name = "grdRooms";
this.grdRooms.NodeClosedPicture = null;
this.grdRooms.NodeOpenPicture = null;
this.grdRooms.OutlineCol = -1;
this.grdRooms.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdRooms.Size = new System.Drawing.Size(214, 438);
this.grdRooms.StyleInfo = resources.GetString("grdRooms.StyleInfo");
this.grdRooms.TabIndex = 0;
this.grdRooms.TreeColor = System.Drawing.Color.DarkGray;
this.grdRooms.Click += new System.EventHandler(this.grdRooms_Click);
this.grdRooms.RowColChange += new System.EventHandler(this.grdRooms_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label6);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.label8);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(-244, 177);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 191;
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
// label8
// 
this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label8.Location = new System.Drawing.Point(16, 42);
this.label8.Name = "label8";
this.label8.Size = new System.Drawing.Size(141, 15);
this.label8.TabIndex = 4;
this.label8.Text = "Input Search string here";
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
// RoomUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(722, 491);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.picRoomImageLarge);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.grdRooms);
this.Controls.Add(this.gbxCommands);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "RoomUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Room";
this.Load += new System.EventHandler(this.RoomUI_Load);
this.Closing += new System.ComponentModel.CancelEventHandler(this.RoomUI_Closing);
this.TextChanged += new System.EventHandler(this.RoomUI_TextChanged);
this.gbxCommands.ResumeLayout(false);
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
this.gbxAmenities.ResumeLayout(false);
this.gbxSmokingType.ResumeLayout(false);
this.gbxAdjacency.ResumeLayout(false);
this.gbxLocation.ResumeLayout(false);
this.gbxLocation.PerformLayout();
this.gbxRoomImg.ResumeLayout(false);
this.gbxRoomImg.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.picRoomImg)).EndInit();
this.GroupBox3.ResumeLayout(false);
this.GroupBox3.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.picRoomImageLarge)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.grdRooms)).EndInit();
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

        private bool isLoaded = false;
             
        private DatasetBinder oDataSetBinder;
        private ControlListener oControlListener;
        
        private Amenity oAmenity;
        private AmenityFacade oAmenityFacade;
        private Room oRoom;
        private RoomFacade oRoomFacade;

        #endregion

        #region " CONSTRUCTORS "

        // >> Constructor for Room with db connection
        public RoomUI()
        {
            InitializeComponent();
            
            oDataSetBinder = new DatasetBinder();
            oControlListener = new ControlListener();
        }

        #endregion

        #region " METHODS "

     
        private void setOperationMode(OperationMode a_OperationMode)
        {
            mOperationMode = a_OperationMode;
        }

        /*********************************************************
          * Purpose: Check if control has a valid value
          *********************************************************/
        private bool isRequiredEntriesFilled()
        {
			//if (this.txtRoomID.Text.Trim().Length > 0 &&
			//    this.txtRoomTypeCode.Text.Trim().Length > 0 &&
			//    this.txtFloor.Text.Trim().Length > 0 )
			//{
                //return true;
			//}
			//else
			//{
			//    return false;
			//}

            if (txtFloor.Text.Length < 1)
            {
                MessageBox.Show("Please enter room floor", "Folio Plus - Room Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFloor.Focus();
                return false;
            }
            try
            {
                int.Parse(txtFloor.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid floor number", "Folio Plus - Room Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFloor.Focus();
                return false;
            }
            if (txtRoomArea.Text.Length > 0)
            {
                try
                {
                    decimal.Parse(txtRoomArea.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a valid amount for area", "Folio Plus - Room Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRoomArea.Focus();
                    return false;
                }
            }
            else
            {
                txtRoomArea.Text = "0";
            }
            return true;
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
            this.btnCombinations.Enabled = state;

        }


        /*********************************************************
        * Purpose: Populate record to Grid Control
        *********************************************************/
        public bool populateDataGrid(DataTable a_Currency)
        {
            try
            {
                int i = 0;
                this.grdRooms.Rows = 1;

                foreach (DataRow dRow in oRoom.Tables[0].Rows)
                {

                    i = this.grdRooms.Rows;
                    this.grdRooms.Rows++;

                    this.grdRooms.set_TextMatrix(i, 0, dRow["RoomId"].ToString());
                    this.grdRooms.set_TextMatrix(i, 1, dRow["RoomTypeCode"].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Populating Data Grid.");
                return false;
            }
        }

        // >> Loads Amenities of select room
        private bool loadRoomAmenity( string a_RoomId )
        {
            try
            {
                oAmenity = new Amenity();
                oAmenityFacade = new AmenityFacade();

                oAmenity = (Amenity)oAmenityFacade.loadObject();
                loadToListView(oAmenity.Tables[0], this.lvwAmenities);

                oAmenity = oAmenityFacade.getRoomAmenities( a_RoomId );
				DataTable _dtRoomAmenities = oAmenity.Tables["RoomAmenities"];

				
				foreach(ListViewItem _lvwItem in this.lvwAmenities.Items)
				{
					foreach (DataRow _dRow in _dtRoomAmenities.Rows)
					{
						if(_lvwItem.Text == _dRow["AmenityId"].ToString())
						{
							_lvwItem.Checked = true;
						}
					}
				}
               
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        // >> Binds Selected Data Row Info to Form Controls
        private bool bindRowToControls()
        {
            try
            {
                if (btnSave.Visible == true)
                {
                    if (hasChanges())
                    {
                        if (MessageBox.Show("Save changes made to Room '" + this.txtRoomID.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            assignEntityValues();
                            update();
                        }
                        else
                        {
                            this.BindingContext[oRoom.Tables[0]].CancelCurrentEdit();
                            this.Text = "Rooms";
                        }
                    }

                    oControlListener.StopListen(this);

                    this.BindingContext[oRoom.Tables["Rooms"]].Position = findItemInDataset(this.grdRooms.get_TextMatrix(this.grdRooms.Row, 0));

                    loadRoomAmenity(this.txtRoomID.Text);

                    return true;
                }
                else
                {
                    MessageBox.Show("You are not authorized to save changes to this form!", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if ( this.pnlSearch.Visible == false && isLoaded == true )
                {
                    oControlListener.Listen(this);
                }
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

        private bool assignEntityValues()
        {
            oRoom.RoomId = this.txtRoomID.Text;
            oRoom.HotelID = GlobalVariables.gHotelId;
			oRoom.RoomTypecode = this.cboRoomTypeCode.Text;
            oRoom.Floor = this.txtFloor.Text;
            oRoom.Windows = this.chkWindows.CheckState == CheckState.Checked ? "1" : "0";
            oRoom.DirFacing = this.cboDirFacing.Text;
            oRoom.AdjLeft = this.cboAdjLeft.Text;
            oRoom.AdjRight = this.cboAdjRight.Text;
            oRoom.RoomImage = this.txtRoomImage.Text;
            oRoom.SmokingType = this.chkSmokingType.CheckState == CheckState.Checked ? "1" : "0";
            oRoom.BedSplittable = this.chkBedSplittable.CheckState == CheckState.Checked ? "1" : "0";
            oRoom.TelephoneNo = this.txtTelephoneNo.Text;
            oRoom.CreatedBy = GlobalVariables.gLoggedOnUser;
            oRoom.UpdatedBy = GlobalVariables.gLoggedOnUser;
            oRoom.RoomArea = decimal.Parse(txtRoomArea.Text);
            /* FP-SCR-00139 #1 [07.20.2010]
             * added additional field for description/name of room */
            oRoom.RoomDescription = this.txtRoomDescription.Text;
            /* end of SCR-00139 */

            // room amenities
			AmenityCollection amenities = new AmenityCollection();
			foreach (ListViewItem _lvwItem in this.lvwAmenities.Items)
			{
				if (_lvwItem.Checked)
				{
					Amenity mAmenity = new Amenity();
					mAmenity.AmenityId = _lvwItem.Text;

					amenities.Add(mAmenity);
				}
			}
			oRoom.Amenities = amenities;

            return true;
        }

        // >> UPDATES CURRENT DAY ROOM STATUS
        private bool updateCurrentDayRoomStatus()
        {
            Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
            MethodInfo[] objMethods = objectType.GetMethods();

            foreach (MethodInfo method in objMethods)
            {
                if (method.Name.ToUpper() == "plotCurrentDayRoomStatus".ToUpper())
                {
                    method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);
                }
            }
            return true;
        }

        // >> Show Image of Room
        private bool showRoomImage()
        {
			if (this.txtRoomImage.Text.Trim().Length > 0)
			{
				try
				{
					System.Drawing.Image img;
					img = System.Drawing.Image.FromFile(this.txtRoomImage.Text);
					this.picRoomImg.Image = img;
				}
				catch (Exception)
				{
					this.picRoomImg.Image = null;
				}
			}
			else
			{
				this.picRoomImg.Image = null;
			}

            return true;
        }

       
        // >> Show Look Up UI for Room Type
        private bool showRoomTypeLookUpUI()
        {
            RoomLookUp oRoomLookUp = new RoomLookUp("RoomTypes");

            oRoomLookUp.MdiParent = this.MdiParent;
            oRoomLookUp.Show();

            return true;
        }

        // >> Displays Room Id in Amenities List
        private bool showAmenityRoomID()
        {
            //this.lblRoomAmenity.Text = "Amenities-" + this.txtRoomID.Text;

            if (mOperationMode == OperationMode.ADD)
            {
                this.txtTelephoneNo.Text = this.txtRoomID.Text;
            }

            return true;
        }

        // >> Displays Dialog to Select Room Image
        private bool selectRoomImage()
        {
            ofdPickRoomImage.ShowDialog();
            return true;
        }

        // >> Transfers file location to textbox
        private bool getFileLocation()
        {
            this.txtRoomImage.Text = ofdPickRoomImage.FileName;
            return true;
        }

        // >> Loads Amenities to ListView
        private bool loadToListView(DataTable dt, System.Windows.Forms.ListView lvw)
        {
            int i;
            lvw.Items.Clear();
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ListViewItem lst = new ListViewItem(dt.Rows[i][0].ToString());
                lst.SubItems.Add(dt.Rows[i][1].ToString());

                lvw.Items.Add(lst);
            }
            return true;
        }

        // >> Removes Room Amenity
        private bool removeRoomAmenity()
        {
			//try
			//{
			//    if ( mOperationMode == OperationMode.ADD )
			//    {
			//        ListViewItem lst = new ListViewItem(this.lvwRoomAmenities.SelectedItems[0].Text);
			//        lst.SubItems.Add(this.lvwRoomAmenities.SelectedItems[0].SubItems[1].Text);

			//        this.lvwAmenities.Items.Add(lst);

			//        this.lvwRoomAmenities.Items[this.lvwRoomAmenities.SelectedIndices[0]].Remove();
			//    }
			//    else
			//    {
			//        string roomId = this.txtRoomID.Text;
			//        string amenityId = this.lvwRoomAmenities.SelectedItems[0].Text;
			//        oRoomFacade.deleteRoomAmenity(roomId, amenityId);

			//        loadRoomAmenity( this.txtRoomID.Text );
			//    }
			    return true;
			//}
			//catch (Exception)
			//{
			//    MessageBox.Show("Please select an Amenity on the list...");
			//    return false;
			//}
        }

        private void plotRoomCoordinate()
        {
            FloorLayoutUI oFloorLayoutUI = new FloorLayoutUI(this.txtRoomID.Text, GlobalVariables.gHotelId.ToString(), this.txtFloor.Text);
            oFloorLayoutUI.MdiParent = this.MdiParent;
            oFloorLayoutUI.Show();
        }

        /// <summary>
        /// Search the List(grid) starting from the selected Row down
        /// if Not Found then start the Search again from the top..
        /// </summary>
        private void searchItem()
        {
            bool isFound = false;

            if (!this.txtSearch.Text.Equals(""))
            {
                int i = 0;
                for (i = this.grdRooms.Row + 1; i <= this.grdRooms.Rows - 1; i++)
                {
                    if (this.grdRooms.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                        ||
                        this.grdRooms.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                    {

                        this.grdRooms.Row = i;
                        isFound = true;
                        return;
                    }
                }

                if (!isFound)
                {
                    for (i = 1; i <= this.grdRooms.Rows - 1; i++)
                    {
                        if (this.grdRooms.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                        ||
                        this.grdRooms.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.grdRooms.Row = i;
                            isFound = true;
                            return;
                        }

                    }
                }

                MessageBox.Show("No matching record found.");
            }

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
            foreach (DataRow drRoom in oRoom.Tables[0].Rows)
            {
                if (drRoom["RoomId"].ToString() == key)
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

        #endregion

        #region   MaintenanceUIInterface Members

        /********************************************************
        * Purpose: Retrieve data from the database
        *********************************************************/
        public bool load()
        {
            try
            {
                oRoomFacade = new RoomFacade();
                oRoom = new Room();
                oRoom = (Room)oRoomFacade.loadObject();

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
                oRoomFacade = new RoomFacade();
                rowsAdded = oRoomFacade.insertObject(ref oRoom);
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
                oRoomFacade = new RoomFacade();
                rowsAffected = oRoomFacade.updateObject(ref oRoom);
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        /********************************************************
        * Purpose: Mark existing item as DELETED
        *********************************************************/
        public int delete()
        {
            try
            {
                int rowsAffected = 0;
                oRoomFacade = new RoomFacade();
                assignEntityValues();

                rowsAffected = oRoomFacade.deleteObject(ref oRoom);
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region " EVENTS "

        private void RoomUI_Load(object sender, System.EventArgs e)
        {
            mOperationMode = OperationMode.EDIT ;


			RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();
			RoomType _oRoomType = (RoomType)_oRoomTypeFacade.loadObject();

			DataTable _dtTemp = _oRoomType.Tables[0];
			
            this.cboRoomTypeCode.DataSource = _dtTemp;
			this.cboRoomTypeCode.DisplayMember = "RoomTypeCode";

			this.cboMaxOccupants.DataSource = _dtTemp;
			this.cboMaxOccupants.DisplayMember = "MaxOccupants";

			this.cboNoOfBeds.DataSource = _dtTemp;
			this.cboNoOfBeds.DisplayMember = "NoOfBeds";

			this.cboNoOfAdult.DataSource = _dtTemp;
			this.cboNoOfAdult.DisplayMember = "NoOfAdult";

			this.cboNoOfChild.DataSource = _dtTemp;
			this.cboNoOfChild.DisplayMember = "NoOfChild";

            //this.cboShareType.DataSource = _dtTemp;
            //this.cboShareType.DisplayMember = "ShareType";


            if (load() == true)
            {
                if ( oRoom != null )
                {
                    
                    object obj = (object)oRoom;
                    oDataSetBinder.BindControls(this, ref obj, new ArrayList());

                    populateDataGrid(oRoom.Tables[0]);
                    loadRoomAmenity( this.txtRoomID.Text );

                }

                this.txtRoomID.Enabled = false;
                
                oControlListener.Listen(this);

                isLoaded = true;
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
            this.BindingContext[oRoom.Tables[0]].SuspendBinding();

            // Set action button states
            setActionButtonStates(false);

            // Enable Currency code textbox
            this.txtRoomID.Enabled = true;

            
			foreach(ListViewItem _lvwItem in lvwAmenities.Items)
			{
				_lvwItem.Checked = false;
			}


            // Set focus to Currency code textbox
            this.cboRoomTypeCode.SelectedIndex = 0;
            this.txtRoomID.Focus();
            
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
                            // >> insert room amenities
                            //foreach (ListViewItem _lvwItem in lvwAmenities.Items)
                            //{
                            //    if (_lvwItem.Checked)
                            //    {
                            //        oRoomFacade.addRoomAmenity(oRoom.RoomId, _lvwItem.Text);
                            //    }
                            //}

                            MessageBox.Show("Item successfully added.", "Room", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdRooms.Rows += 1;
                            this.grdRooms.set_TextMatrix(this.grdRooms.Rows - 1, 0, oRoom.RoomId);
                            this.grdRooms.set_TextMatrix(this.grdRooms.Rows - 1, 1, oRoom.RoomTypecode);

                            this.cboAdjLeft.DataSource = null;
                            this.cboAdjRight.DataSource = null;

                            this.BindingContext[oRoom.Tables[0]].ResumeBinding();
                            this.Text = "Rooms";

                            //updates The left side panel of the Main Form
                            updateCurrentDayRoomStatus();

                            //mode = "";
                            this.txtRoomID.Enabled = false;

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
                            MessageBox.Show("Item successfully updated.", "Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdRooms.set_TextMatrix(this.grdRooms.Row, 1, oRoom.RoomTypecode);

                            this.BindingContext[oRoom.Tables[0]].ResumeBinding();
                            this.Text = "Rooms";
                            this.txtRoomID.Enabled = false;

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
                MessageBox.Show("Please required information!", "Save Error");
                this.txtRoomID.Focus();
                return;
            }
        }

        private void txtRoomImage_TextChanged(System.Object sender, System.EventArgs e)
        {
            showRoomImage();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                if (this.grdRooms.Rows > 1)
                {
                    this.grdRooms.Row = 1;
                }
            }
            else
            {
                this.BindingContext[oRoom.Tables[0]].CancelCurrentEdit();
            }

            this.BindingContext[oRoom.Tables[0]].ResumeBinding();

            this.Text = "Rooms";
            this.txtRoomID.Enabled = false;

            setActionButtonStates(true);
            oControlListener.Listen(this);
        }

        private void picRoomTypeLookUp_Click(System.Object sender, System.EventArgs e)
        {
            showRoomTypeLookUpUI();
        }

        private void txtRoomID_TextChanged(System.Object sender, System.EventArgs e)
        {
            showAmenityRoomID();
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            this.oControlListener.StopListen(this);
            if (MessageBox.Show("Are you certain you want to remove Room '" + this.txtRoomID.Text + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (delete() > 0)
                {
                    this.grdRooms.RemoveItem(this.grdRooms.Row);
                }
                else
                {
                    MessageBox.Show("No rows deleted", "Database Update Error");
                }
            }
            this.oControlListener.Listen(this);
        }

        private void picRoomImg_Click(System.Object sender, System.EventArgs e)
        {
            selectRoomImage();
        }

        private void ofdPickRoomImage_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            getFileLocation();
        }

		//private void btnRemove_Click(System.Object sender, System.EventArgs e)
		//{
		//    try
		//    {
		//        if (mOperationMode == OperationMode.ADD )
		//        {
		//            ListViewItem lst = new ListViewItem();
		//            lst = (ListViewItem)this.lvwRoomAmenities.SelectedItems[0].Clone();
                    
		//            this.lvwAmenities.Items.Add(lst);
		//            this.lvwRoomAmenities.Items[this.lvwRoomAmenities.SelectedIndices[0]].Remove();
		//        }
		//        else
		//        {
		//            string roomId = this.txtRoomID.Text;
		//            string amenityId = this.lvwRoomAmenities.SelectedItems[0].Text;

		//            oRoomFacade.deleteRoomAmenity(roomId, amenityId);

		//            loadRoomAmenity( this.txtRoomID.Text );
		//        }
		//    }
		//    catch (Exception)
		//    {
		//        MessageBox.Show("Please select an Amenity on the list...");
		//    }
		//}

		//private void btnAdd_Click(System.Object sender, System.EventArgs e)
		//{
		//    try
		//    {
		//        if ( mOperationMode == OperationMode.ADD )
		//        {
		//            ListViewItem lst = new ListViewItem();
		//            lst = (ListViewItem)this.lvwAmenities.SelectedItems[0].Clone();

		//            this.lvwRoomAmenities.Items.Add(lst);
		//            this.lvwAmenities.Items[ this.lvwAmenities.SelectedIndices[0] ].Remove();

					
		//        }
		//        else
		//        {
		//            string roomId = this.txtRoomID.Text;
		//            string amenityId = this.lvwAmenities.SelectedItems[0].Text;

		//            oRoomFacade.addRoomAmenity(roomId,amenityId);

		//            loadRoomAmenity( this.txtRoomID.Text );

		//        }
		//    }
		//    catch (ArgumentOutOfRangeException)
		//    {
		//        MessageBox.Show("Please select an Amenity on the list...");
		//    }
		//}

        private void btnPlot_Click(System.Object sender, System.EventArgs e)
        {
            plotRoomCoordinate();
        }

        private void RoomUI_TextChanged(object sender, System.EventArgs e)
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

        private void RoomUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                if (MessageBox.Show("Save changes made to Room '" + this.txtRoomID.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (btnSave.CanFocus == true)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        MessageBox.Show("You are not authorized to save changes to this form!", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    this.BindingContext[oRoom.Tables[0]].CancelCurrentEdit();
                    this.Text = "Rooms";
                }
            }
        }

        private void picRoomImg_MouseHover(object sender, System.EventArgs e)
        {
            if (!(this.picRoomImg.Image == null))
            {
                this.picRoomImageLarge.Image = this.picRoomImg.Image;
                this.picRoomImageLarge.Visible = true;

				this.picRoomImageLarge.Location = new System.Drawing.Point(229, 83);
            }
        }

        private void picRoomImg_MouseLeave(object sender, System.EventArgs e)
        {
            this.picRoomImageLarge.Visible = false;
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
			this.pnlSearch.Left = (this.Width / 2) - (this.pnlSearch.Width / 2);
			this.pnlSearch.Top = (this.Height / 2) - (this.pnlSearch.Height / 2);

            this.pnlSearch.Visible = true;
            this.txtSearch.Focus();
            this.txtSearch.SelectAll();
        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();
            }
        }

        private void grdRooms_Click(System.Object sender, System.EventArgs e)
        {
            bindRowToControls();
        }

        private void grdRooms_RowColChange(object sender, EventArgs e)
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

        private void RoomUI_Closing(object sender, EventArgs e)
        {

            if (hasChanges())
            {
                if (MessageBox.Show("Save changes made to Room '" + this.txtRoomID.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (btnSave.CanFocus == true)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        MessageBox.Show("You are not authorized to save changes to this form!", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    this.BindingContext[oRoom.Tables[0]].CancelCurrentEdit();
                    this.Text = "Rooms";
                }
            }
        }

        #endregion

        #region "---------------------------- For LookUp Purposes ------------------------"
        // >> Room Type
        private static string mRoomTypeCode;
        public static string RoomTypeCode
        {
            set
            {
                mRoomTypeCode = value;
            }
        }
        private static int mMaxOccupants;
        public static int MaxOccupants
        {
            set
            {
                mMaxOccupants = value;
            }
        }
        private static int mNoOfBeds;
        public static int NoOfBeds
        {
            set
            {
                mNoOfBeds = value;
            }
        }
        private static int mNoOfAdult;
        public static int NoOfAdult
        {
            set
            {
                mNoOfAdult = value;
            }
        }
        private static int mNoOfChild;
        public static int NoOfChild
        {
            set
            {
                mNoOfChild = value;
            }
        }
        private static string mShareType;
        public static string ShareType
        {
            set
            {
                mShareType = value;
            }
        }

		//private void RoomUI_Activated(object sender, System.EventArgs e)
		//{
		//    if (mRoomTypeCode != null)
		//    {
		//        this.cboRoomTypeCode.Text = mRoomTypeCode;
		//        txtMaxOccupants.Text = mMaxOccupants.ToString();
		//        txtNoOfBeds.Text = mNoOfBeds.ToString();
		//        txtNoOfAdult.Text = mNoOfAdult.ToString();
		//        txtNoOfChild.Text = mNoOfChild.ToString();
		//        this.txtShareType.Text = mShareType;
		//        this.txtFloor.Focus();
		//    }
		//}
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void btnRoomTypeLookUp_Click(object sender, EventArgs e)
		{
			showRoomTypeLookUpUI();
		}

		private void lvwAmenities_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			// to enable Control Listener
			string _temp = this.txtRoomID.Text;
			this.txtRoomID.Text = "";
			this.txtRoomID.Text = _temp;
            
		}
        RoomCombinationsUI lRoomCombinationUI;
        private void btnCombinations_Click(object sender, EventArgs e)
        {
            lRoomCombinationUI = new RoomCombinationsUI();
            lRoomCombinationUI.setLocalRoom(grdRooms.GetData(grdRooms.Row,0).ToString(),  grdRooms.GetData(grdRooms.Row,1).ToString());
            lRoomCombinationUI.MdiParent = this.MdiParent;
            lRoomCombinationUI.Show();
        }
       
        

    }
}
