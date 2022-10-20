
using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using System.Collections.Generic;

using C1.Win.C1FlexGrid;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public class RoomCalendarUI : Jinisys.Hotel.UIFramework.TransactionUI
	{
        private int _colWidth = int.Parse(ConfigVariables.gDefaultRoomCalendarColWidth);

		#region " Windows Form Designer generated lCode "

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
        //Do not modify it using the lCode editor.
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnMark;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.DateTimePicker dtpStartDate;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.NumericUpDown nudWeeks;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.ComboBox cboRoomType;
        internal System.Windows.Forms.Button btnUnblock;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txt;
        private Button btnZoom;
		internal Label label15;
		private Button btnZoomOut;
        public System.Windows.Forms.Label Label14;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomCalendarUI));
this.GroupBox2 = new System.Windows.Forms.GroupBox();
this.btnZoomOut = new System.Windows.Forms.Button();
this.cboRoomType = new System.Windows.Forms.ComboBox();
this.btnZoom = new System.Windows.Forms.Button();
this.Label12 = new System.Windows.Forms.Label();
this.nudWeeks = new System.Windows.Forms.NumericUpDown();
this.Label11 = new System.Windows.Forms.Label();
this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
this.Label10 = new System.Windows.Forms.Label();
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.vsGrid = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlLegend = new System.Windows.Forms.Panel();
this.Label5 = new System.Windows.Forms.Label();
this.txt = new System.Windows.Forms.TextBox();
this.Label1 = new System.Windows.Forms.Label();
this.Label14 = new System.Windows.Forms.Label();
this.Label2 = new System.Windows.Forms.Label();
this.Label13 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.Label4 = new System.Windows.Forms.Label();
this.Label7 = new System.Windows.Forms.Label();
this.Label8 = new System.Windows.Forms.Label();
this.Label3 = new System.Windows.Forms.Label();
this.Label9 = new System.Windows.Forms.Label();
this.btnOK = new System.Windows.Forms.Button();
this.btnMark = new System.Windows.Forms.Button();
this.btnClear = new System.Windows.Forms.Button();
this.btnUnblock = new System.Windows.Forms.Button();
this.btnSetup = new System.Windows.Forms.Button();
this.btnPrint = new System.Windows.Forms.Button();
this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
this.btnClose = new System.Windows.Forms.Button();
this.label15 = new System.Windows.Forms.Label();
this.GroupBox2.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudWeeks)).BeginInit();
this.GroupBox1.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.vsGrid)).BeginInit();
this.pnlLegend.SuspendLayout();
this.SuspendLayout();
// 
// GroupBox2
// 
this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
this.GroupBox2.Controls.Add(this.btnZoomOut);
this.GroupBox2.Controls.Add(this.cboRoomType);
this.GroupBox2.Controls.Add(this.btnZoom);
this.GroupBox2.Controls.Add(this.Label12);
this.GroupBox2.Controls.Add(this.nudWeeks);
this.GroupBox2.Controls.Add(this.Label11);
this.GroupBox2.Controls.Add(this.dtpStartDate);
this.GroupBox2.Controls.Add(this.Label10);
this.GroupBox2.Location = new System.Drawing.Point(4, 28);
this.GroupBox2.Name = "GroupBox2";
this.GroupBox2.Size = new System.Drawing.Size(835, 39);
this.GroupBox2.TabIndex = 4;
this.GroupBox2.TabStop = false;
// 
// btnZoomOut
// 
this.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
this.btnZoomOut.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnZoomOut.ForeColor = System.Drawing.Color.DimGray;
this.btnZoomOut.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.zoom_out1;
this.btnZoomOut.Location = new System.Drawing.Point(426, 12);
this.btnZoomOut.Name = "btnZoomOut";
this.btnZoomOut.Size = new System.Drawing.Size(24, 21);
this.btnZoomOut.TabIndex = 5;
this.btnZoomOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
this.btnZoomOut.UseVisualStyleBackColor = true;
this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
// 
// cboRoomType
// 
this.cboRoomType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
this.cboRoomType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cboRoomType.Items.AddRange(new object[] {
            "ALL",
            "DELUXE",
            "SINGLE",
            "decimal",
            "SUITE"});
this.cboRoomType.Location = new System.Drawing.Point(622, 12);
this.cboRoomType.Name = "cboRoomType";
this.cboRoomType.Size = new System.Drawing.Size(205, 22);
this.cboRoomType.TabIndex = 1;
this.cboRoomType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboRoomType_KeyPress);
this.cboRoomType.DropDownClosed += new System.EventHandler(this.cboRoomType_DropDownClosed);
// 
// btnZoom
// 
this.btnZoom.BackColor = System.Drawing.Color.Transparent;
this.btnZoom.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
this.btnZoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
this.btnZoom.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnZoom.ForeColor = System.Drawing.Color.DimGray;
this.btnZoom.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.zoom_in1;
this.btnZoom.Location = new System.Drawing.Point(398, 12);
this.btnZoom.Name = "btnZoom";
this.btnZoom.Size = new System.Drawing.Size(24, 21);
this.btnZoom.TabIndex = 4;
this.btnZoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
this.btnZoom.UseVisualStyleBackColor = true;
this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
// 
// Label12
// 
this.Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
this.Label12.Location = new System.Drawing.Point(552, 16);
this.Label12.Name = "Label12";
this.Label12.Size = new System.Drawing.Size(64, 14);
this.Label12.TabIndex = 0;
this.Label12.Text = "RoomType";
// 
// nudWeeks
// 
this.nudWeeks.Location = new System.Drawing.Point(320, 13);
this.nudWeeks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
this.nudWeeks.Name = "nudWeeks";
this.nudWeeks.Size = new System.Drawing.Size(40, 20);
this.nudWeeks.TabIndex = 3;
this.nudWeeks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.nudWeeks.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
this.nudWeeks.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nudWeeks_MouseUp);
// 
// Label11
// 
this.Label11.Location = new System.Drawing.Point(280, 15);
this.Label11.Name = "Label11";
this.Label11.Size = new System.Drawing.Size(40, 16);
this.Label11.TabIndex = 2;
this.Label11.Text = "Weeks";
// 
// dtpStartDate
// 
this.dtpStartDate.Location = new System.Drawing.Point(64, 13);
this.dtpStartDate.Name = "dtpStartDate";
this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
this.dtpStartDate.TabIndex = 0;
this.dtpStartDate.DropDown += new System.EventHandler(this.dtpStartDate_DropDown);
this.dtpStartDate.CloseUp += new System.EventHandler(this.dtpStartDate_CloseUp);
// 
// Label10
// 
this.Label10.Location = new System.Drawing.Point(8, 15);
this.Label10.Name = "Label10";
this.Label10.Size = new System.Drawing.Size(80, 16);
this.Label10.TabIndex = 1;
this.Label10.Text = "Start Date";
// 
// GroupBox1
// 
this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
this.GroupBox1.Controls.Add(this.vsGrid);
this.GroupBox1.Controls.Add(this.pnlLegend);
this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox1.Location = new System.Drawing.Point(4, 63);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(835, 541);
this.GroupBox1.TabIndex = 6;
this.GroupBox1.TabStop = false;
// 
// vsGrid
// 
this.vsGrid.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.vsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
this.vsGrid.Cols = 11;
this.vsGrid.ColumnInfo = "11,2,0,0,0,85,Columns:2{Width:20;}\t";

this.vsGrid.FixedCols = 2;
this.vsGrid.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.vsGrid.GridColor = System.Drawing.Color.Black;
this.vsGrid.GridColorFixed = System.Drawing.Color.Black;
this.vsGrid.GridLines = C1.Win.C1FlexGrid.Classic.GridStyleSettings.flexGridInset;
this.vsGrid.Location = new System.Drawing.Point(4, 42);
this.vsGrid.Name = "vsGrid";
this.vsGrid.NodeClosedPicture = null;
this.vsGrid.NodeOpenPicture = null;
this.vsGrid.OutlineCol = -1;
this.vsGrid.Size = new System.Drawing.Size(826, 493);
this.vsGrid.StyleInfo = resources.GetString("vsGrid.StyleInfo");
this.vsGrid.TabIndex = 18;
this.vsGrid.TreeColor = System.Drawing.Color.DarkGray;
this.vsGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vsGrid_MouseDown);
this.vsGrid.SelChange += new System.EventHandler(this.vsGrid_SelChange);
this.vsGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vsGrid_MouseUp);
this.vsGrid.DoubleClick += new System.EventHandler(this.vsGrid_DoubleClick);
// 
// pnlLegend
// 
this.pnlLegend.Controls.Add(this.Label5);
this.pnlLegend.Controls.Add(this.txt);
this.pnlLegend.Controls.Add(this.Label1);
this.pnlLegend.Controls.Add(this.Label14);
this.pnlLegend.Controls.Add(this.Label2);
this.pnlLegend.Controls.Add(this.Label13);
this.pnlLegend.Controls.Add(this.Label6);
this.pnlLegend.Controls.Add(this.Label4);
this.pnlLegend.Controls.Add(this.Label7);
this.pnlLegend.Controls.Add(this.Label8);
this.pnlLegend.Controls.Add(this.Label3);
this.pnlLegend.Controls.Add(this.Label9);
this.pnlLegend.Location = new System.Drawing.Point(2, 7);
this.pnlLegend.Name = "pnlLegend";
this.pnlLegend.Size = new System.Drawing.Size(829, 37);
this.pnlLegend.TabIndex = 19;
// 
// Label5
// 
this.Label5.BackColor = System.Drawing.SystemColors.Control;
this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label5.Location = new System.Drawing.Point(92, 8);
this.Label5.Name = "Label5";
this.Label5.Size = new System.Drawing.Size(46, 16);
this.Label5.TabIndex = 4;
this.Label5.Text = "Block";
this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// txt
// 
this.txt.BackColor = System.Drawing.SystemColors.Info;
this.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.txt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txt.ForeColor = System.Drawing.SystemColors.WindowFrame;
this.txt.Location = new System.Drawing.Point(553, 4);
this.txt.Name = "txt";
this.txt.ReadOnly = true;
this.txt.Size = new System.Drawing.Size(272, 25);
this.txt.TabIndex = 16;
this.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// Label1
// 
this.Label1.BackColor = System.Drawing.Color.Brown;
this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(68, 7);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(20, 20);
this.Label1.TabIndex = 1;
// 
// Label14
// 
this.Label14.BackColor = System.Drawing.SystemColors.Control;
this.Label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label14.Location = new System.Drawing.Point(463, 8);
this.Label14.Name = "Label14";
this.Label14.Size = new System.Drawing.Size(93, 17);
this.Label14.TabIndex = 17;
this.Label14.Text = "Date Range:";
this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// Label2
// 
this.Label2.BackColor = System.Drawing.Color.GreenYellow;
this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(140, 7);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(20, 20);
this.Label2.TabIndex = 2;
// 
// Label13
// 
this.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.Label13.Location = new System.Drawing.Point(460, 2);
this.Label13.Name = "Label13";
this.Label13.Size = new System.Drawing.Size(368, 30);
this.Label13.TabIndex = 9;
// 
// Label6
// 
this.Label6.BackColor = System.Drawing.SystemColors.Control;
this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label6.Location = new System.Drawing.Point(164, 8);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(71, 16);
this.Label6.TabIndex = 5;
this.Label6.Text = "Engineering";
this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// Label4
// 
this.Label4.BackColor = System.Drawing.Color.DodgerBlue;
this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label4.Location = new System.Drawing.Point(356, 7);
this.Label4.Name = "Label4";
this.Label4.Size = new System.Drawing.Size(20, 20);
this.Label4.TabIndex = 2;
// 
// Label7
// 
this.Label7.BackColor = System.Drawing.SystemColors.Control;
this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label7.Location = new System.Drawing.Point(284, 8);
this.Label7.Name = "Label7";
this.Label7.Size = new System.Drawing.Size(66, 16);
this.Label7.TabIndex = 6;
this.Label7.Text = "Occupied";
this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// Label8
// 
this.Label8.BackColor = System.Drawing.SystemColors.Control;
this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label8.Location = new System.Drawing.Point(376, 9);
this.Label8.Name = "Label8";
this.Label8.Size = new System.Drawing.Size(72, 16);
this.Label8.TabIndex = 5;
this.Label8.Text = "Reservation";
this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// Label3
// 
this.Label3.BackColor = System.Drawing.Color.Aqua;
this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label3.Location = new System.Drawing.Point(260, 7);
this.Label3.Name = "Label3";
this.Label3.Size = new System.Drawing.Size(20, 20);
this.Label3.TabIndex = 3;
// 
// Label9
// 
this.Label9.BackColor = System.Drawing.SystemColors.Control;
this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.Location = new System.Drawing.Point(3, 2);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(457, 30);
this.Label9.TabIndex = 7;
this.Label9.Text = "  Legend:";
this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// btnOK
// 
this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
this.btnOK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnOK.Location = new System.Drawing.Point(224, 609);
this.btnOK.Name = "btnOK";
this.btnOK.Size = new System.Drawing.Size(66, 31);
this.btnOK.TabIndex = 9;
this.btnOK.Text = "Done";
this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
// 
// btnMark
// 
this.btnMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
this.btnMark.Cursor = System.Windows.Forms.Cursors.Hand;
this.btnMark.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnMark.Location = new System.Drawing.Point(80, 609);
this.btnMark.Name = "btnMark";
this.btnMark.Size = new System.Drawing.Size(66, 31);
this.btnMark.TabIndex = 10;
this.btnMark.Text = "Mark";
this.btnMark.Click += new System.EventHandler(this.btnMark_Click);
// 
// btnClear
// 
this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
this.btnClear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnClear.Location = new System.Drawing.Point(152, 609);
this.btnClear.Name = "btnClear";
this.btnClear.Size = new System.Drawing.Size(66, 31);
this.btnClear.TabIndex = 11;
this.btnClear.Text = "Clear";
this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
// 
// btnUnblock
// 
this.btnUnblock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
this.btnUnblock.Cursor = System.Windows.Forms.Cursors.Hand;
this.btnUnblock.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnUnblock.Location = new System.Drawing.Point(6, 609);
this.btnUnblock.Name = "btnUnblock";
this.btnUnblock.Size = new System.Drawing.Size(66, 31);
this.btnUnblock.TabIndex = 12;
this.btnUnblock.Text = "Remove";
this.btnUnblock.Click += new System.EventHandler(this.btnUnblock_Click);
// 
// btnSetup
// 
this.btnSetup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
this.btnSetup.Cursor = System.Windows.Forms.Cursors.Hand;
this.btnSetup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSetup.Location = new System.Drawing.Point(334, 609);
this.btnSetup.Name = "btnSetup";
this.btnSetup.Size = new System.Drawing.Size(105, 31);
this.btnSetup.TabIndex = 13;
this.btnSetup.Text = "Setup page";
this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
// 
// btnPrint
// 
this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
this.btnPrint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnPrint.Location = new System.Drawing.Point(445, 609);
this.btnPrint.Name = "btnPrint";
this.btnPrint.Size = new System.Drawing.Size(105, 31);
this.btnPrint.TabIndex = 14;
this.btnPrint.Text = "Print";
this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
// 
// btnClose
// 
this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnClose.Location = new System.Drawing.Point(773, 609);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 191;
this.btnClose.Text = "C&lose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// label15
// 
this.label15.AutoSize = true;
this.label15.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label15.Location = new System.Drawing.Point(5, 7);
this.label15.Name = "label15";
this.label15.Size = new System.Drawing.Size(143, 22);
this.label15.TabIndex = 192;
this.label15.Text = "Room Calendar";
// 
// RoomCalendarUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(848, 647);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.btnPrint);
this.Controls.Add(this.btnSetup);
this.Controls.Add(this.GroupBox2);
this.Controls.Add(this.btnUnblock);
this.Controls.Add(this.btnClear);
this.Controls.Add(this.btnOK);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.btnMark);
this.Controls.Add(this.label15);
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.MinimizeBox = false;
this.Name = "RoomCalendarUI";
this.Text = "Room Calendar";
this.Load += new System.EventHandler(this.RoomCalendarUI_Load);
this.Activated += new System.EventHandler(this.RoomCalendarUI_Activated);
this.GroupBox2.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.nudWeeks)).EndInit();
this.GroupBox1.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.vsGrid)).EndInit();
this.pnlLegend.ResumeLayout(false);
this.pnlLegend.PerformLayout();
this.ResumeLayout(false);
this.PerformLayout();

        }

        #endregion


		#region "VARIABLES/CONSTANTS"


		private ArrayList roomIDs;
		private RoomFacade oRoomFacade;
		private Color blockColor = new Color();
		private ArrayList RoomEventCollections = new ArrayList(); //General copy of  RoomeventCollections
		//The genetal copy of RoomeventCollections serves as the container of all
		//roomEventCollection including those that are saved already in the database
		//this is used to make sure that dates roomeventcollection are simultaneous in terms of date.
		private ArrayList LocalRoomeventCollections = new ArrayList(); //Local copy of RoomeventCollections
		//The local roomevent collection is the container of all roomeventcollection
		//when the the UI is started, excluding those that are saved in the database.
		//this collection holds the roomevents objects to be saved to the database
		private string EventID;
		private string OperationMode;
		private ListView lvwStayInformation;
		private RoomBlockCollection oRoomBlockCollection;
		private RoomBlockFacade oRoomBlockFacade;
		private CalendarFacade oCalendarFacade;
		private Calendar oCalendar = new Calendar();
		private DateTime startDate;
		private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic vsGrid;
		internal Button btnSetup;
		internal Button btnPrint;
		internal Button btnClose;
		public Label Label9;
		private Panel pnlLegend;
		private SaveFileDialog saveFileDialog1;


		// >> Constructor for Engineering Job
		private string mEnggJobNo;
		private TextBox mStartDate;
		private TextBox mEndDate;
		private TextBox mRoomId;


		private RoomEventCollection oRoomEventCollection = new RoomEventCollection();

		Form loCallingForm = null;
		C1FlexGrid lGrdFolioSchedule = null;

		//Constructor for editing operation
		private string EventType;
		private object rmType;

		#endregion


		#region "CONSTRUCTORS"


		public RoomCalendarUI()
		{
			InitializeComponent();
			//PopulateRoomsAndDatesInGrid();
		}

		public RoomCalendarUI(string FolioId, string mode)
		{

			EventID = FolioId;
			OperationMode = mode;
			this.blockColor = getColor(OperationMode);
			this.Text = OperationMode;
			InitializeComponent();
			PopulateRoomsAndDatesInGrid();
			HidePrintButtons();

		}

		public RoomCalendarUI(string EnggJobNo, string mode, ref TextBox startDate, ref TextBox endDate, ref TextBox RoomId, string rmType, DateTime sDate, int noOfWeeks)
		{
			InitializeComponent();
			HidePrintButtons();
			OperationMode = mode;
			this.blockColor = getColor(OperationMode);
			this.Text = OperationMode;

			mStartDate = startDate;
			mEndDate = endDate;
			mRoomId = RoomId;
			mEnggJobNo = EnggJobNo;
			this.btnClear.Enabled = false;
			this.btnUnblock.Enabled = false;

			this.dtpStartDate.Value = sDate;
			this.startDate = this.dtpStartDate.Value;

			PopulateRoomsAndDatesInGrid(rmType);
		}

		public RoomCalendarUI(string FolioId, string mode, C1FlexGrid pGrdFolioSchedule, string rmType, DateTime sDate, int noOfWeeks, Form pCallingForm)
		{

			loCallingForm = pCallingForm;
			lGrdFolioSchedule = pGrdFolioSchedule;

			EventID = FolioId;
			OperationMode = mode;
			InitializeComponent();
			HidePrintButtons();
			startDate = sDate;

			this.nudWeeks.Value = noOfWeeks;
			this.dtpStartDate.Value = startDate;

			PopulateRoomsAndDatesInGrid(rmType);
			initializedRoomEventCollection();


			if (mode == "VIEW CALENDAR")
			{
				this.btnOK.Text = "Close";
				this.btnMark.Enabled = false;
				this.btnClear.Enabled = false;
			}

			this.blockColor = this.getColor(OperationMode);
			this.btnMark.Text = "Reserve";
			this.Text = OperationMode;

			//ListViewItem listViewItem;
			//foreach (ListViewItem tempLoopVar_listViewItem in lvwStayInformation.Items)
			//{
			//    listViewItem = tempLoopVar_listViewItem;
			//    selectRoom(listViewItem.Text, listViewItem.SubItems[2].Text, listViewItem.SubItems[3].Text);
			//}

			oCalendarFacade = new CalendarFacade();
			this.cboRoomType.Text = rmType;
		}

		public RoomCalendarUI(string FolioId, string mode, ListView lvwStayInfo, string EvntType, string rmType, DateTime sDate, int noOfWeeks)
		{
			lvwStayInformation = lvwStayInfo;
			EventID = FolioId;
			// Guest = folioOwner
			OperationMode = mode;
			EventType = EvntType.ToUpper();
			InitializeComponent();
			HidePrintButtons();
			startDate = sDate;
			this.nudWeeks.Value = noOfWeeks;
			this.dtpStartDate.Value = startDate;
			PopulateRoomsAndDatesInGrid(rmType);
			initializedRoomEventCollection();
			plotData(RoomEventCollections);


			this.blockColor = this.getColor(OperationMode);
			this.btnMark.Text = "Reserve";
			this.Text = OperationMode;
			ListViewItem listViewItem;
			foreach (ListViewItem tempLoopVar_listViewItem in lvwStayInformation.Items)
			{
				listViewItem = tempLoopVar_listViewItem;
				selectRoom(listViewItem.Text, listViewItem.SubItems[2].Text, listViewItem.SubItems[3].Text);
			}
			oCalendarFacade = new Jinisys.Hotel.Reservation.BusinessLayer.CalendarFacade();
			this.cboRoomType.Text = rmType;
		}

		// for BLOCKING
		public RoomCalendarUI(string mode)
		{
			OperationMode = mode;
			InitializeComponent();
			//HidePrintButtons();
			this.dtpStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			startDate = this.dtpStartDate.Value;
			PopulateRoomsAndDatesInGrid();

			this.btnMark.Text = OperationMode;
			blockColor = getColor(OperationMode);
			this.btnMark.Text = "Block";
			this.Text = "Room Calendar";
			this.btnOK.Enabled = false;
			this.btnClear.Enabled = false;
			oCalendarFacade = new Jinisys.Hotel.Reservation.BusinessLayer.CalendarFacade();

		}

		// constructor to SOLVE slow re-show of Grid
		public RoomCalendarUI(string mode, object roomType, int numOfWeeks, DateTime startD)
		{
			OperationMode = mode;
			rmType = roomType.ToString();

			InitializeComponent();
			//HidePrintButtons();
			this.nudWeeks.Value = numOfWeeks;
			startDate = startD;
			this.dtpStartDate.Value = startDate;
			PopulateRoomsAndDatesInGrid(roomType.ToString());

			this.btnMark.Text = OperationMode;
			blockColor = getColor(OperationMode);
			this.btnMark.Text = "Block";
			this.Text = "Room Calendar";
			this.btnOK.Enabled = false;
			this.btnClear.Enabled = false;
			oCalendarFacade = new Jinisys.Hotel.Reservation.BusinessLayer.CalendarFacade();

			this.cboRoomType.Text = roomType.ToString();
		}

		// constructor for ROOM AVAILABILITY
		public RoomCalendarUI(int noOfWeeks, DateTime startDate)
		{
			InitializeComponent();
			this.Text = "Room Availability";
			OperationMode = "room availability";
			if (noOfWeeks != 0 && startDate != null)
			{
				this.nudWeeks.Value = noOfWeeks;
				this.dtpStartDate.Value = startDate;
			}


			PopulateDates(true);
			initializedGrid(true);
			plotOccupancy();
			PlotBlockRooms();
			ExcludeExpectedDepartures();
			this.btnUnblock.Enabled = false;
			this.btnMark.Enabled = false;
			this.btnClear.Enabled = false;
			this.btnOK.Enabled = false;
			this.cboRoomType.Visible = false;
			this.Label12.Visible = false;
			this.txt.Visible = false;
			this.Label14.Visible = false;

			this.pnlLegend.Visible = false;
			this.vsGrid.Dock = DockStyle.Fill;

			this.blockColor = Color.Brown;

		}

		#endregion


        private void selectRoom(string roomid,string from ,string to)
        {
            if (from == "" || to == "")
                return;
            int row = -1;
			int col = 2;
			int lastCol = 0;
			int gridCols = this.vsGrid.Cols - 2;
			//find rowNumber in ROOM LIST
			for (int i = 3; i < this.vsGrid.Rows; i++)
			{
				string gridRoomNo = this.vsGrid.get_TextMatrix(i, 1);
				if (gridRoomNo == roomid)
					row = i;
			} // end for


            if (row == -1)
                return;

            vsGrid.Select(row, 0);
            vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
            vsGrid.CellBackColor = Color.Coral;
            vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;

			int fromToDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(from).Date, DateTime.Parse(to).Date);
			int _fromDateCalendarDateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, this.dtpStartDate.Value.Date, DateTime.Parse(from).Date);

			// added by: Jerome, April 23, 2008
			// if difference from RoomEventFromDate versus Calendar Start Date
			// is lesser than 0, start at column 2;
			// else starts at column 3
			if (_fromDateCalendarDateDiff < 0)
			{
				col = 0;
				_fromDateCalendarDateDiff = Math.Abs(_fromDateCalendarDateDiff);
				col += _fromDateCalendarDateDiff * 2;

				lastCol = col + (fromToDiff * 2) - (_fromDateCalendarDateDiff * 2);
			}
			else
			{
				col = 3;
				col += _fromDateCalendarDateDiff * 2;

				lastCol = col + (fromToDiff * 2) - 1;
			}


			//checks if lastColumn is greater than Grid Columns
			// if so, lastColumn gets Grid Columns
			if (lastCol > gridCols)
			{
				lastCol = gridCols;
			}


				//int lastCol;
				//if ((column + ((int)(DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(from).Date, DateTime.Parse(to).Date) * 2)) - 1) <= this.vsGrid.Cols - 1)
				//{
				//    lastCol = column + ((int)(DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(from).Date, DateTime.Parse(to).Date) * 2)) - 1;
				//}
				//else
				//{
				//    lastCol = this.vsGrid.Cols - 1;
				//}
				//if (lastCol % 2 == 0)
				//{
				//    lastCol--;
				//}

				//if (lastCol < column)
				//{
				//    lastCol = column;
				//}
                try
                {
                    vsGrid.Select(row, col, row, lastCol);
                    vsGrid.CellForeColor = Color.Black;
                    vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
                    vsGrid.CellBackColor = getColor("RESERVATION");
                    vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;
                }
                  
                catch (Exception)
                {
                 
                }
                    
            
        }

        private void HidePrintButtons()
        {
            this.btnPrint.Visible = false;
            this.btnSetup.Visible = false;
        }

        private void ExcludeExpectedDepartures()
        {

            // revised by jrom [ dec 12, 2007 ]
            // excludes expected for all dates.
            
            oCalendarFacade = new CalendarFacade();
            DateTime dateTo = this.dtpStartDate.Value.AddDays((double)(this.nudWeeks.Value * 7));

            int endCount = int.Parse(DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, this.dtpStartDate.Value, dateTo).ToString());

            for (int i = 0; i < endCount; i++)
            {
                DataTable oExpectedCheckouts = oCalendarFacade.GetSpectedDepartures(string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(i)));
                DataTable dtExpectedCheckIn = oCalendarFacade.GetSpectedArrivals(string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(i)));

                // remove from ExpectedCheckOutList if 
                // room is present in expected arrivals
                foreach (DataRow ciRow in dtExpectedCheckIn.Rows)
                {
                    string _roomIdToLook = ciRow["roomid"].ToString();

                    foreach (DataRow dRow in oExpectedCheckouts.Rows)
                    {
                        if (dRow["roomid"].ToString() == _roomIdToLook)
                        {
                            oExpectedCheckouts.Rows.Remove(dRow);
                            break;
                        }
                    }

                }

                foreach (DataRow dr in oExpectedCheckouts.Rows)
                {
                    for (int row = 3; row <= this.vsGrid.Rows - 1; row++)
                    {
                        bool isBreak = false;

                        for (int col = 1; col <= this.vsGrid.Cols - 1; col++)
                        {

                            if (this.vsGrid.get_TextMatrix(row, 0) == dr["roomtype"].ToString())
                            {
                                if (this.dtpStartDate.Value.AddDays(col - 1).Date == DateTime.Parse(dr["todate"].ToString()).Date)
                                {
                                    int vacant = int.Parse(this.vsGrid.get_TextMatrix(row, col)) + 1;
                                    this.vsGrid.set_TextMatrix(row, col, vacant.ToString());

                                    isBreak = true;
                                    break;
                                }
                            }
                        }
                        if (isBreak)
                            break;
                    }
                }
            }

        }
        private ArrayList CountedRooms = new ArrayList();
        private void plotOccupancy()
        {
            
            oRoomBlockFacade = new RoomBlockFacade();
            DateTime dateTo = this.dtpStartDate.Value.AddDays((double)(this.nudWeeks.Value * 7));
            DataTable oOccupiedRooms = oRoomBlockFacade.GetRoomTypeDateOccupied(string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value), string.Format("{0:yyyy-MM-dd}",dateTo));

            foreach (DataRow dr in oOccupiedRooms.Rows)
            {
                for (int row = 3; row <= this.vsGrid.Rows - 1; row++)
                {
                    for(int col = 1;col <=this.vsGrid.Cols-1;col++)
                    {
                    
                        if (this.vsGrid.get_TextMatrix(row, 0) == dr["roomtypecode"].ToString())
                        {
                            if (this.dtpStartDate.Value.AddDays(col - 1).Date == DateTime.Parse(dr["eventdate"].ToString()).Date)
                            {
                                CountedRoom cntdRm = new CountedRoom();
                                cntdRm.roomid = dr["roomID"].ToString();
                                cntdRm.date= this.dtpStartDate.Value.Date.AddDays(col-1);
                                if(CountedRooms.IndexOf(cntdRm)==-1)
                                {
                                    int vacant = int.Parse(this.vsGrid.get_TextMatrix(row,col)) - 1;
                                    this.vsGrid.set_TextMatrix(row,col,vacant.ToString());
                                    
                                    CountedRooms.Add(cntdRm);
                                }
                            }
                        }
                    }
                }
            }
        }
        private struct CountedRoom
        {
            public String roomid;
            public DateTime date;
        }

        // till here
        //added by  jun mar 02-20-07
        //---------------------------------------

        private void PlotBlockRooms()
        {
			string _dateFrom = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value);
			double _diff = (double)this.nudWeeks.Value * 7;
			string _dateTo = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(_diff));

			DataTable BlockedRooms = oRoomBlockFacade.getRoomBlocks(_dateFrom, _dateTo, true);
            foreach (DataRow dr in BlockedRooms.Rows)
            {
				//for (int col = 1; col <= this.vsGrid.Cols - 1; col++)

				// we start at Column 2 since we have ROOMTYPES & ROOM NOS at cols 0,1
                for (int col = 1; col <= this.vsGrid.Cols - 1; col++)
                {
                    for (int row = 3; row <= this.vsGrid.Rows - 1; row++)
                    {

                        if (dr["roomtype"].ToString() == this.vsGrid.get_TextMatrix(row, 0))
                        {
                            DateTime DateToCheck = this.dtpStartDate.Value.AddDays(col - 1).Date;
                            DateTime BlockFrom = DateTime.Parse(dr["blockfrom"].ToString());
                            DateTime BlockTo = DateTime.Parse(dr["blockto"].ToString());
                            int noOfDays = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, BlockFrom, BlockTo);
                            for (int i = 0; i <= noOfDays - 1; i++)
                            {
                                DateTime DateFromBlocking = BlockFrom.AddDays(i).Date;
                                if (DateToCheck == DateFromBlocking)
                                {
                                    CountedRoom cntdRm = new CountedRoom();
                                    cntdRm.roomid = dr["roomID"].ToString();
                                    cntdRm.date = this.dtpStartDate.Value.Date.AddDays(col - 1);
                                    if (CountedRooms.IndexOf(cntdRm) == -1)
                                    {
                                        int Vacant = int.Parse(this.vsGrid.get_TextMatrix(row, col)) - 1;
                                        this.vsGrid.set_TextMatrix(row, col, Vacant.ToString());
                                        CountedRooms.Add(cntdRm);
                                    }

                                }
                            }


                        }
                    }

                }
            }
        }
        //--------------------------------------------------till here
        public void PopulateRoomsAndDatesInGrid()
        {
            initializedGrid();
            PopulateDates();

            populateRoomEvents();
            plotData();
            plotBlocks1();
        }

        private void PopulateRoomsAndDatesInGrid(string roomTypeCode)
        {

            initializedGrid(roomTypeCode);
            PopulateDates();
            populateRoomEvents();
            plotData();
            plotBlocks1();
        }

        private void initializedRoomEventCollection()
        {
           // ListViewItem _listViewItem = null;
            try
            {
				//foreach (ListViewItem lvwItem in lvwStayInformation.Items)
				//{

				//    RoomEventCollection RoomeventCollection = new RoomEventCollection();
				//    int d;
				//    int ctr = 0;
				//    RoomeventCollection.RoomID = lvwItem.Text;
				//    RoomeventCollection.FromDate = System.Convert.ToDateTime(lvwItem.SubItems[2].Text).Date;
				//    RoomeventCollection.ToDate = System.Convert.ToDateTime(lvwItem.SubItems[3].Text).Date;
				//    RoomeventCollection.EventType = EventType;
				//    for (d = 0; d <= ( DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(lvwItem.SubItems[2].Text) , DateTime.Parse(lvwItem.SubItems[3].Text) ) ); d++)
				//    {
				//        RoomEvents roomevent = new RoomEvents();
				//        roomevent.RoomID = lvwItem.Text;
				//        roomevent.Eventid = EventID;
				//        if (lvwItem.SubItems[6].Text == "")
				//        {
				//            roomevent.RoomRate = decimal.Parse(lvwItem.SubItems[6].Text);
				//        }
				//        else
				//        {
				//            roomevent.RoomRate = 0;
				//        }
				//        roomevent.EventDate = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", DateTime.Parse(lvwItem.SubItems[2].Text).AddDays(ctr)));
				//        RoomeventCollection.Add(roomevent);
				//        ctr++;
				//    }

				//    RoomEventCollections.Add(RoomeventCollection);
				//}
				int _rows = lGrdFolioSchedule.Rows.Count;
				for( int i = 1 ; i < _rows ; i++ )
				{

					RoomEventCollection _oRoomEventCollection = new RoomEventCollection();
					int d;
					int ctr = 0;
					_oRoomEventCollection.RoomID = lGrdFolioSchedule.GetDataDisplay(i,0);

					if (_oRoomEventCollection.RoomID != "")
					{
						_oRoomEventCollection.FromDate = DateTime.Parse(lGrdFolioSchedule.GetDataDisplay(i, 2));
						_oRoomEventCollection.ToDate = DateTime.Parse(lGrdFolioSchedule.GetDataDisplay(i, 3));
						_oRoomEventCollection.EventType = EventType;

						string _roomRate = lGrdFolioSchedule.GetDataDisplay(i, 6);

						int _dateDiff = (int)(DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oRoomEventCollection.FromDate, _oRoomEventCollection.ToDate));
						for (d = 0; d <= _dateDiff; d++)
						{
							RoomEvents roomevent = new RoomEvents();
							roomevent.RoomID = _oRoomEventCollection.RoomID;
							roomevent.Eventid = EventID;

							if (_roomRate == "")
							{
								roomevent.RoomRate = 0;
							}
							else
							{
								roomevent.RoomRate = decimal.Parse(_roomRate);
							}

							roomevent.EventDate = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", _oRoomEventCollection.FromDate.AddDays(ctr)));
							_oRoomEventCollection.Add(roomevent);
							ctr++;

						} // end for

						RoomEventCollections.Add(_oRoomEventCollection);
						selectRoom(_oRoomEventCollection.RoomID, _oRoomEventCollection.FromDate.ToString(), _oRoomEventCollection.ToDate.ToString());
					} // end if
					else
					{
						lGrdFolioSchedule.Rows.Count = 1;
						break;
					}
				}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed. Error initializing room events. Error message : " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Room oRooms;
        private DataView dtvRooms;
        private void initializedGrid()
        {
            // multiply by 2 since we cater 2RoomEvent per Day
            int numberOfCols = (int)(this.nudWeeks.Value * 7) * 2;

            // add to cols since we have 2 fixed cols(ROOMTYPES & ROOMS)
            this.vsGrid.Cols = numberOfCols + 2;
            this.vsGrid.Rows = 3;

            this.vsGrid.FixedCols = 2;
            this.vsGrid.FixedRows = 3;

            // Room Type
            this.vsGrid.set_TextMatrix(0, 0, "Room Type");
            this.vsGrid.set_TextMatrix(1, 0, "Room Type");
            this.vsGrid.set_TextMatrix(2, 0, "Room Type");


            // Rooms
            this.vsGrid.set_TextMatrix(0, 1, "Rooms");
            this.vsGrid.set_TextMatrix(1, 1, "Rooms");
            this.vsGrid.set_TextMatrix(2, 1, "Rooms");

            this.vsGrid.MergeCells = C1.Win.C1FlexGrid.Classic.MergeSettings.flexMergeFree;
            this.vsGrid.set_MergeCol(0, true);
            this.vsGrid.set_MergeCol(1, true);

            // setup COLWIDTH for FIXED COLS
            this.vsGrid.set_ColWidth(0, 60);
            this.vsGrid.set_ColWidth(1, 40);

            // setup COLWIDTH for dates
            for (int c = 2; c <= this.vsGrid.Cols - 1; c++)
            {
                this.vsGrid.set_ColWidth(c, _colWidth);
            }

            oRoomFacade = new RoomFacade();
            oRooms = (Room)oRoomFacade.loadObject();

            dtvRooms = oRooms.Tables[0].DefaultView;
            dtvRooms.Sort = "roomtypecode"; // order by roomtypecode
            
            int index = 3;
            this.vsGrid.set_MergeRow(0, true);
            this.vsGrid.Rows += dtvRooms.Count;

            foreach (DataRowView dtrView in dtvRooms)
            { 
                this.vsGrid.set_TextMatrix(index,0, dtrView["roomtypecode"].ToString());
                this.vsGrid.set_TextMatrix(index, 1, dtrView["roomid"].ToString());

				this.vsGrid.Select(index, 1);
				if (dtrView["cleaningstatus"].ToString() == "DIRTY")
					this.vsGrid.CellBackColor = Color.Red;
				else
					this.vsGrid.CellBackColor = SystemColors.Control;

				this.vsGrid.set_MergeRow(index, true);
                index++;
            }
        }

        DataTable oRoomTypeCount = null;
        private void initializedGrid(bool forRoomavailability)
        {
            int c;
            this.vsGrid.Cols = (int)(nudWeeks.Value * 7);
            this.vsGrid.FixedCols = 1;
            this.vsGrid.FixedRows = 3;
            this.vsGrid.set_TextMatrix(0, 0, "Room Types");

            this.vsGrid.set_TextMatrix(1, 0, "Room Types");
            this.vsGrid.set_TextMatrix(2, 0, "Room Types");

            this.vsGrid.MergeCells = C1.Win.C1FlexGrid.Classic.MergeSettings.flexMergeFree;
            this.vsGrid.set_MergeCol(0, true);

            this.vsGrid.Rows = 3;
            //this.vsGrid.MergeCells = VSFlex7L.MergeSettings.flexMergeFree;

            for (c = 1; c <= this.vsGrid.Cols - 1; c++)
            {
                this.vsGrid.set_ColWidth(c, _colWidth);
             
            }
            oRoomBlockFacade = new RoomBlockFacade();
            oRoomTypeCount = oRoomBlockFacade.CountRoomTypes();

            int index;
            this.vsGrid.set_MergeRow(0, true);
            for (index = 0; index <= oRoomTypeCount.Rows.Count - 1; index++)
            {
                //this.vsGrid.AddItem( roomIDs[index].ToString(), null);
                this.vsGrid.AddItem(oRoomTypeCount.Rows[index][0].ToString(), index + 3);
                  
                foreach (DataRow dr in oRoomTypeCount.Rows)
                {
                    if (dr["roomtypecode"].ToString() == this.vsGrid.get_TextMatrix(this.vsGrid.Rows - 1,0))
                    {
                        for (c = 1; c <= this.vsGrid.Cols - 1; c++)
                        {
                            this.vsGrid.set_TextMatrix(this.vsGrid.Rows - 1,c,dr["vacant"].ToString());

                        }
                    }
                }
                this.vsGrid.set_RowHeight(this.vsGrid.Rows - 1, 50);
                this.vsGrid.Select(index + 3, 0);


                this.vsGrid.CellFontBold = true;
                this.vsGrid.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter;
            }

            for (int lstRow = vsGrid.Rows - 3; lstRow <= vsGrid.Rows - 1; lstRow++)
            {
                vsGrid.Select(lstRow, 0);

                vsGrid.CellFontBold = true;
                vsGrid.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter;
            }

        }

        private void initializedGrid(string a_RoomTypeCode)
        {

			// multiply by 2 since we cater 2RoomEvent per Day
			int numberOfCols = (int)(this.nudWeeks.Value * 7) * 2;

			// add to cols since we have 2 fixed cols(ROOMTYPES & ROOMS)
			this.vsGrid.Cols = numberOfCols + 2;
			this.vsGrid.Rows = 3;

			this.vsGrid.FixedCols = 2;
			this.vsGrid.FixedRows = 3;

			// Room Type
			this.vsGrid.set_TextMatrix(0, 0, "Room Type");
			this.vsGrid.set_TextMatrix(1, 0, "Room Type");
			this.vsGrid.set_TextMatrix(2, 0, "Room Type");


			// Rooms
			this.vsGrid.set_TextMatrix(0, 1, "Rooms");
			this.vsGrid.set_TextMatrix(1, 1, "Rooms");
			this.vsGrid.set_TextMatrix(2, 1, "Rooms");

			this.vsGrid.MergeCells = C1.Win.C1FlexGrid.Classic.MergeSettings.flexMergeFree;
			this.vsGrid.set_MergeCol(0, true);
			this.vsGrid.set_MergeCol(1, true);

			// setup COLWIDTH for FIXED COLS
			this.vsGrid.set_ColWidth(0, 60);
			this.vsGrid.set_ColWidth(1, 40);

			// setup COLWIDTH for dates
			for (int c = 2; c <= this.vsGrid.Cols - 1; c++)
			{
				this.vsGrid.set_ColWidth(c, _colWidth);
			}

			oRoomFacade = new RoomFacade();
			oRooms = (Room)oRoomFacade.loadObject();

			dtvRooms = oRooms.Tables[0].DefaultView;
			if (a_RoomTypeCode != "ALL")
			{
				dtvRooms.RowStateFilter = DataViewRowState.OriginalRows;
				dtvRooms.RowFilter = "roomtypecode='" + a_RoomTypeCode + "'";
			}

			dtvRooms.Sort = "roomtypecode"; // order by roomtypecode

			int index = 3;
			this.vsGrid.set_MergeRow(0, true);
			this.vsGrid.Rows += dtvRooms.Count;

			foreach (DataRowView dtrView in dtvRooms)
			{
				this.vsGrid.set_TextMatrix(index, 0, dtrView["roomtypecode"].ToString());
				this.vsGrid.set_TextMatrix(index, 1, dtrView["roomid"].ToString());

				this.vsGrid.Select(index, 1);
				if (dtrView["cleaningstatus"].ToString() == "DIRTY")
					this.vsGrid.CellBackColor = Color.Red;
				else
					this.vsGrid.CellBackColor = SystemColors.Control;


				this.vsGrid.set_MergeRow(index, true);
				index++;
			}

                this.cboRoomType.Text = a_RoomTypeCode;
				
			}

        public void PopulateDates()
        {
            // multiply by 2 since we cater 2RoomEvent per Day
            int numberOfCols = (int)(this.nudWeeks.Value * 7) * 2;

            // add to cols since we have 2 fixed cols(ROOMTYPES & ROOMS)
            this.vsGrid.Cols = numberOfCols + 2;

            int day;
            
            // set merge First Row (MONTH,YEAR and DAYNAME)
            this.vsGrid.set_MergeRow(1, true);
            this.vsGrid.set_MergeRow(2, true);

            startDate = this.dtpStartDate.Value.AddDays(-1);
            for (day = 2; day <= numberOfCols; day=day+2 )
            {
                if (day % 2 == 0)
                {

                    this.vsGrid.Select(1, day);
                    this.vsGrid.CellForeColor = Color.Black;

                    DateTime forLoopDate = startDate.AddDays(day / 2);

                    string monthAndYear = string.Format("{0:MMMM , yyyy}", forLoopDate);
                    this.vsGrid.set_TextMatrix(0, day, monthAndYear);
                    this.vsGrid.set_TextMatrix(0, day + 1, monthAndYear);


                    // for Day prefix(S M T W T F S)
                    if (forLoopDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        this.vsGrid.set_TextMatrix(1, day, forLoopDate.DayOfWeek.ToString().Substring(0, 2));
                        this.vsGrid.set_TextMatrix(1, day + 1, forLoopDate.DayOfWeek.ToString().Substring(0, 2));

                        this.vsGrid.Select(1, day);
                        this.vsGrid.CellForeColor = Color.Red;
                    }
                    else
                    {
                        this.vsGrid.set_TextMatrix(1, day, forLoopDate.DayOfWeek.ToString().Substring(0, 1));
                        this.vsGrid.set_TextMatrix(1, day + 1, forLoopDate.DayOfWeek.ToString().Substring(0, 1));
                    }

                    //for DATE
                    this.vsGrid.set_TextMatrix(2, day, forLoopDate.Day.ToString());
                    this.vsGrid.set_TextMatrix(2, day + 1, forLoopDate.Day.ToString());
                }
            }
        }

        //02-19-2007 this is added to cater koresco needs (jun mar)
        public void PopulateDates(bool forRoomavailability)
        {

            this.vsGrid.Cols = (int)(this.nudWeeks.Value * 7);

            int day;


            this.vsGrid.set_MergeRow(1, true);
            this.vsGrid.set_MergeRow(2, true);
            startDate = this.dtpStartDate.Value.AddDays(-1);
            for (day = 1; day <= this.vsGrid.Cols - 2; day++)
            {

                //this.vsGrid.CtlSelect(1, day, null, null);
                this.vsGrid.Select(1, day);

                //this.vsGrid.CtlSelect(1, day - 1, null, null);
                //this.vsGrid.Select(1, day - 1);


                this.vsGrid.CellForeColor = Color.Black;
                this.vsGrid.set_TextMatrix(0, day, string.Format("{0:MMMM , yyyy}", startDate.AddDays(day)));

                if (startDate.AddDays(day).DayOfWeek == DayOfWeek.Sunday)
                {
                    this.vsGrid.set_TextMatrix(1, day, string.Format("{0:dddd}", startDate.AddDays(day)).Substring(0, 2));
                    // this.vsGrid.set_TextMatrix(1, day - 1, string.Format("{0:dddd}", startDate.AddDays(day )).Substring(0, 2));
                }
                else
                {
                    this.vsGrid.set_TextMatrix(1, day, string.Format("{0:dddd}", startDate.AddDays(day)).Substring(0, 1));
                    //this.vsGrid.set_TextMatrix(1, day - 1, string.Format("{0:dddd}", startDate.AddDays(day)).Substring(0, 1));
                }
                this.vsGrid.set_TextMatrix(2, day, string.Format("{0:dd}", startDate.AddDays(day)));
                //this.vsGrid.set_TextMatrix(2, day - 1, string.Format("{0:dd}", startDate.AddDays(day )));
                if (startDate.AddDays(day).DayOfWeek == DayOfWeek.Sunday)
                {
                    //this.vsGrid.CtlSelect(1, day, null, null);
                    this.vsGrid.Select(1, day);

                    //this.vsGrid.CtlSelect(1, day - 1, null, null);
                    //  this.vsGrid.Select(1, day - 1);

                    this.vsGrid.CellForeColor = Color.Red;
                }

            }

        }//till here

        //this is added to improve performance
		public void plotBlocks1()
		{

			oRoomBlockFacade = new RoomBlockFacade();

			string _startDate = string.Format("{0:yyyy-MM-dd}", startDate);
			double _noOfDays = (double)this.nudWeeks.Value * 7;

			string _endDate = string.Format("{0:yyyy-MM-dd}", startDate.AddDays(_noOfDays));

			oRoomBlockCollection = oRoomBlockFacade.getRoomBlocks(_startDate, _endDate);

			DateTime calStartDate = this.dtpStartDate.Value;
			foreach (RoomBlock oRoomBlock in oRoomBlockCollection)
			{
				//RoomEventC = tempLoopVar_RoomEventC;
				int row = -1;
				int col = 2;
				int lastCol = 0;
				int gridCols = this.vsGrid.Cols - 1;

				//find rowNumber in ROOM LIST
				for (int i = 3; i < this.vsGrid.Rows; i++)
				{
					string gridRoomNo = this.vsGrid.get_TextMatrix(i, 1);
					if (gridRoomNo == oRoomBlock.RoomID)
						row = i;
				} // end for

				// if CANT FIND ROOM NUMBER IN LIST
				// dont proceed
				// jerome, april 23, 2008
				if (row > -1)
				{
					int fromToDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, oRoomBlock.BlockFrom, oRoomBlock.BlockTo);
					int _fromDateCalendarDateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, calStartDate, oRoomBlock.BlockFrom);


					// added by: Jerome, April 23, 2008
					// if difference from RoomEventFromDate versus Calendar Start Date
					// is lesser than 0, start at column 2;
					// else starts at column 3
					if (_fromDateCalendarDateDiff < 0)
					{
						col = 0;
						_fromDateCalendarDateDiff = Math.Abs(_fromDateCalendarDateDiff);
						col += _fromDateCalendarDateDiff * 2;

						lastCol = col + (fromToDiff * 2) - (_fromDateCalendarDateDiff * 2);
					}
					else
					{
						col = 3;
						col += _fromDateCalendarDateDiff * 2;

						lastCol = col + (fromToDiff * 2) - 1;
					}


					//checks if lastColumn is greater than Grid Columns
					// if so, lastColumn gets Grid Columns
					if (lastCol > gridCols)
					{
						lastCol = gridCols;
					}

					// plots IN CALENDAR
					for (int c = col; c <= lastCol; c++)
					{
						string owner = oRoomBlock.BlockID.ToString() + "-" + oRoomBlock.Reason;
						vsGrid.Select(row, c);

						vsGrid.set_TextMatrix(row, c, owner);
						vsGrid.CellForeColor = Color.White;
						vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
						vsGrid.CellBackColor = getColor("BLOCKING");
						vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;
					}// endOfForLoop
				}
			}

			if (oRoomBlockCollection != null)
			{
				oRoomBlockCollection.Clear();
			}
			if (progress != null)
				progress.Close();

			// parks Cursor at 3rd Row, 2nd Col.
			if (this.vsGrid.Rows > 4 && this.vsGrid.Cols > 3)
			{
				this.vsGrid.Select(3, 2);
			}//end if

		}

        // 04-26-06 this is added by jun mar
        // this is to populate roomevents ready for Plotting in the calendar
        private ArrayList RoomEventCollectionForPlotting = new ArrayList();
        
         
        // to be improved to fix logiCal bug
        private int roomeventsCount;


		// revised by: Jerome, April 23, 2008
		// added new column: ROomType
		// revise plotting of roomevents
        public void populateRoomEvents()
        {
			string _startDate = string.Format("{0:yyyy-MM-dd}", startDate);
			double _noOfDays = (double)nudWeeks.Value * 7;
			string _endDate = string.Format("{0:yyyy-MM-dd}", startDate.AddDays(_noOfDays));

			oCalendarFacade = new CalendarFacade();
			DataTable dtRoomEvents = oCalendarFacade.getRoomEventsForPlotting(_startDate, _endDate);
			
            int i = 0;
            RoomEventCollection RoomEventC = new RoomEventCollection();
            roomeventsCount += dtRoomEvents.Rows.Count;
            
            if (dtRoomEvents.Rows.Count > 0)
            {
                if (i == 0)
                {

                    RoomEventC.EventType = dtRoomEvents.Rows[0]["eventtype"].ToString();
                    RoomEventC.FromDate = DateTime.Parse(dtRoomEvents.Rows[0]["eventdate"].ToString());
                    RoomEventC.RoomID = dtRoomEvents.Rows[0]["roomid"].ToString();
					

					// used in comparing same name reservation
					// needs to be revised. should use unique identifier
					string _folioType = "INDIVIDUAL";
					try
					{
						_folioType = dtRoomEvents.Rows[0]["FolioType"].ToString();
					}
					catch{}

					string eventowner = dtRoomEvents.Rows[0]["GuestName"].ToString();

					switch (_folioType)
					{ 
						case "INDIVIDUAL":
						case "SHARE":
						case "PERSONAL":
							eventowner = dtRoomEvents.Rows[0]["GuestName"].ToString();
							break;
						case "GROUP":
						case "DEPENDENT":
						case "COMPANY":
							eventowner = dtRoomEvents.Rows[0]["GroupName"].ToString();
							break;
						default:
							break;
					}
					//string eventowner = (dtRoomEvents.Rows[i]["lastname"].ToString() == null) ? "" : (dtRoomEvents.Rows[i]["lastname"].ToString());

                    RoomEventC.EventOwner = eventowner;

					// 
					RoomEventC.TransferFlag = dtRoomEvents.Rows[0]["transferFlag"].ToString();
                    i++;

                }// end if

                while (i < dtRoomEvents.Rows.Count)
                {
                    bool thesame = false;

					// check WHAT TO SHOW IN CALENDAR (GUESTNAME, COMPANY, EVENT)
					string _folioType = "INDIVIDUAL";
					try
					{
						_folioType = dtRoomEvents.Rows[i]["FolioType"].ToString();
					}
					catch { }

					string eventowner = dtRoomEvents.Rows[i]["GuestName"].ToString();

					switch (_folioType)
					{
						case "INDIVIDUAL":
						case "SHARE":
						case "PERSONAL":
							eventowner = dtRoomEvents.Rows[i]["GuestName"].ToString();
							break;
						case "GROUP":
                        case "DEPENDENT":
						case "COMPANY":
                            eventowner = dtRoomEvents.Rows[i]["GroupName"].ToString();
                            break;
                        default:
							break;
					}
					// END check

					
					//included transfer flag for MULTIPLE room RESERVATION
					if (RoomEventC.EventType == dtRoomEvents.Rows[i]["eventtype"].ToString() &&
						RoomEventC.RoomID == dtRoomEvents.Rows[i]["roomid"].ToString() &&
						RoomEventC.EventOwner == eventowner &&
						RoomEventC.TransferFlag == "0")
					{
						thesame = true;
					}
					else
					{
						thesame = false;
					}

                    if (thesame)
                    {

						RoomEventC.TransferFlag = dtRoomEvents.Rows[i]["transferflag"].ToString();

                        if (i == dtRoomEvents.Rows.Count - 1)
                        {
							
                            RoomEventC.ToDate = DateTime.Parse(dtRoomEvents.Rows[i]["eventdate"].ToString());
							

                            RoomEventCollectionForPlotting.Add( RoomEventC );
                            return;
                        }
                        else
                        {
                            i++;
                        }

                    }
                    else
                    {
                        i--;
                        RoomEventC.ToDate = DateTime.Parse(dtRoomEvents.Rows[i]["eventdate"].ToString());
                        RoomEventCollectionForPlotting.Add( RoomEventC );

                        RoomEventC = new RoomEventCollection();
						i++;
                        if (i < dtRoomEvents.Rows.Count)
                        {
							_folioType = "INDIVIDUAL";
							try
							{
								_folioType = dtRoomEvents.Rows[i]["FolioType"].ToString();
							}
							catch { }

							string eventown = dtRoomEvents.Rows[i]["GuestName"].ToString();

							switch (_folioType)
							{
								case "INDIVIDUAL":
								case "SHARE":
								case "PERSONAL":
									eventown = dtRoomEvents.Rows[i]["GuestName"].ToString();
									break;
								case "GROUP":
								case "DEPENDENT":
								case "COMPANY":
									eventown = dtRoomEvents.Rows[i]["GroupName"].ToString();
									break;
								default:
									break;
							}
							// END check

                            //string eventown = (dtRoomEvents.Rows[_ctr]["lastname"].ToString() == null) ? "" : (dtRoomEvents.Rows[_ctr]["lastname"].ToString() + "\t\t\t\t\t#" + dtRoomEvents.Rows[_ctr]["eventid"].ToString());
                            RoomEventC.EventType = dtRoomEvents.Rows[i]["eventtype"].ToString();
                            RoomEventC.FromDate = DateTime.Parse(dtRoomEvents.Rows[i]["eventdate"].ToString());
                            RoomEventC.RoomID = dtRoomEvents.Rows[i]["roomid"].ToString();
                            RoomEventC.EventOwner = eventown;

							RoomEventC.TransferFlag = "0"; //since new Room Event

                        }
                        else
                        {
                            return;
                        }
                    }

                }
                if (i == 1)
                {
                    RoomEventCollectionForPlotting.Add( RoomEventC );
                }
            }

        }
        //till here

        private ProgressForm progress;

        // to be improved to fix logical bug
		public void plotData()
		{
			int count = roomeventsCount + RoomEventCollectionForPlotting.Count;

			if (OperationMode != "RESERVATION")
			{
				progress = new ProgressForm(count, "Plotting room events...");
				progress.Height = 27;
				progress.Show();
			}
			int progCount = 0;
			//ArrayList arrlist = new ArrayList();
			RoomEventCollection RoomEventC;

			DateTime startDate = this.dtpStartDate.Value;
			foreach (RoomEventCollection tempLoopVar_RoomEventC in RoomEventCollectionForPlotting)
			{
				RoomEventC = tempLoopVar_RoomEventC;
				int row = -1;
				int col = 2;
				int lastCol = 0;
				int gridCols = this.vsGrid.Cols - 1;

				//find rowNumber in ROOM LIST
				for (int i = 3; i < this.vsGrid.Rows; i++)
				{
					string gridRoomNo = this.vsGrid.get_TextMatrix(i, 1);
					if (gridRoomNo == RoomEventC.RoomID)
						row = i;
				} // end for

				// if CANT FIND ROOM NUMBER IN LIST
				// dont proceed
				// jerome, april 23, 2008
				if (row > -1)
				{
					int fromToDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, RoomEventC.FromDate, RoomEventC.ToDate);
					int _fromDateCalendarDateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, startDate, RoomEventC.FromDate);


					// added by: Jerome, April 23, 2008
					// if difference from RoomEventFromDate versus Calendar Start Date
					// is lesser than 0, start at column 2;
					// else starts at column 3
					if (_fromDateCalendarDateDiff < 0)
					{
						col = 0;
						_fromDateCalendarDateDiff = Math.Abs(_fromDateCalendarDateDiff);
						col += _fromDateCalendarDateDiff * 2;

						lastCol = col + (fromToDiff * 2) - (_fromDateCalendarDateDiff * 2);
					}
					else
					{
						col = 3;
						col += _fromDateCalendarDateDiff * 2;

						lastCol = col + (fromToDiff * 2) - 1;
					}


					//checks if lastColumn is greater than Grid Columns
					// if so, lastColumn gets Grid Columns
					if (lastCol > gridCols)
					{
						lastCol = gridCols;
					}

					// plots IN CALENDAR
					for (int c = col; c <= lastCol; c++)
					{
						string owner = RoomEventC.EventOwner;
						vsGrid.Select(row, c);

						if (vsGrid.get_TextMatrix(row, c) != "")
						{
							if (owner.IndexOf(vsGrid.get_TextMatrix(row, c)) == -1)
							{
								owner = vsGrid.get_TextMatrix(row, c) + "\\" + RoomEventC.EventOwner;
								vsGrid.set_TextMatrix(row, c, owner);
								vsGrid.CellForeColor = Color.Black;
								vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
								vsGrid.CellBackColor = Color.Gray;
								vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;
							}
						}
						else
						{
							vsGrid.set_TextMatrix(row, c, owner);
							vsGrid.CellForeColor = Color.Black;
							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
							vsGrid.CellBackColor = getColor(RoomEventC.EventType);
							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;
						}

					}// endOfForLoop
				}
			}

			progCount++;
			if (progress != null)
				progress.updateProgress(progCount);
		
			if (oRoomBlockCollection != null)
			{
				oRoomBlockCollection.Clear();
			}
			if (progress != null)
				progress.Close();

			// parks Cursor at first 3rd Row, 2nd Col.
			if (this.vsGrid.Rows > 4 && this.vsGrid.Cols > 3)
			{
				this.vsGrid.Select(3, 2);
			}//end if

		}
		
        public void plotData(ArrayList InitialRoomEventCollection)
        {
			DateTime startDate = this.dtpStartDate.Value;

            RoomEventCollection RoomEventC;
			foreach (RoomEventCollection tempLoopVar_RoomEventC in InitialRoomEventCollection)
			{
				RoomEventC = tempLoopVar_RoomEventC;
				int row = 0;
				int col = 2;
				int lastCol = 0;
				int gridCols = this.vsGrid.Cols - 1;

				//find rowNumber in ROOM LIST
				for (int i = 3; i < this.vsGrid.Rows; i++)
				{
					string gridRoomNo = this.vsGrid.get_TextMatrix(i, 1);
					if (gridRoomNo == RoomEventC.RoomID)
						row = i;
				} // end for

				int fromToDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, RoomEventC.FromDate, RoomEventC.ToDate);
				int _fromDateCalendarDateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, startDate, RoomEventC.FromDate);


				// added by: Jerome, April 23, 2008
				// if difference from RoomEventFromDate versus Calendar Start Date
				// is lesser than 0, start at column 2;
				// else starts at column 3
				if (_fromDateCalendarDateDiff < 0)
				{
					col = 0;
					_fromDateCalendarDateDiff = Math.Abs(_fromDateCalendarDateDiff);
					col += _fromDateCalendarDateDiff * 2;

					lastCol = col + (fromToDiff * 2) - (_fromDateCalendarDateDiff * 2);
				}
				else
				{
					col = 3;
					col += _fromDateCalendarDateDiff * 2;

					lastCol = col + (fromToDiff * 2) - 1;
				}


				//checks if lastColumn is greater than Grid Columns
				// if so, lastColumn gets Grid Columns
				if (lastCol > gridCols)
				{
					lastCol = gridCols;
				}

				// plots IN CALENDAR
				for (int c = (col + 1); c <= lastCol; c++)
				{
					string str = RoomEventC.EventOwner;
					vsGrid.Select(row, c);

					if (vsGrid.get_TextMatrix(row, c) != "")
					{
						if (str != null)
						{
							if (str.IndexOf(vsGrid.get_TextMatrix(row, c)) == -1)
							{
								str = vsGrid.get_TextMatrix(row, c) + "\\" + RoomEventC.EventOwner;
								vsGrid.set_TextMatrix(row, c, str);
								vsGrid.CellForeColor = Color.Black;
								vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
								vsGrid.CellBackColor = Color.Gray;
								vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;
							}
						}
					}
					else
					{

						vsGrid.set_TextMatrix(row, c, str);
						vsGrid.CellForeColor = Color.Black;
						vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
						vsGrid.CellBackColor = getColor(RoomEventC.EventType);
						vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;
					}

				}// endOfForLoop:
			}
			
			if (oRoomBlockCollection != null)
			{
				oRoomBlockCollection.Clear();
			}
			if (progress != null)
				progress.Close();

			// parks cursor at 3rd Row, 2nd Col
			if (this.vsGrid.Rows > 4 && this.vsGrid.Cols > 3)
			{
				this.vsGrid.Select(3, 2);
			}

		}

        private Color getColor(string eventtype)
        {
            switch (eventtype.ToUpper())
            {
                case "BLOCKING":

                    return Color.Brown;
                case "RESERVATION":

                    return Color.DodgerBlue;
                case "IN HOUSE":

                    return Color.Cyan;
                case "ENGINEERING JOB":

                    return Color.GreenYellow;
                default:
                    return Color.Brown;
            }
        }

        private string getEventType(Color blockColor)
        {
            string eventType;
            if (blockColor.Equals(Color.Brown))
            {
                eventType = "BLOCKING";
            }
            else if (blockColor.Equals(Color.DodgerBlue))
            {
                eventType = "RESERVATION";
            }
            else if (blockColor.Equals(Color.Aqua))
            {
                eventType = "IN HOUSE";
            }
            else if (blockColor.Equals(Color.GreenYellow)) //
            {
                eventType = "ENGINEERING JOB";
            }
            else
            {
                eventType = "";
            }
            return eventType;
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            btnOK_Click();
        }

        private void btnOK_Click()
        {
            switch (OperationMode.ToUpper())
            {
                case "RESERVATION":
                    if (!extendSDays)
                    {
                        setRoomEvents(EventID);
                    }
                    else
                    {
                        setExtention(EventID);
                    }
                    LocalRoomeventCollections = null;
                    RoomEventCollections = null;
                    
                    this.Close();
                    break;

                case "VIEW CALENDAR":

                    if (!extendSDays)
                    {
                        setRoomEvents(EventID);
                    }
                    else
                    {
                        setExtention(EventID);
                    }
                    LocalRoomeventCollections = null;
                    RoomEventCollections = null;
                    //Try
                    //    Dim _objectType As Type = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.MDI.GetType
                    //    Dim _objMethods As MethodInfo() = _objectType.GetMethods
                    //    Dim _method As MethodInfo
                    //    For Each _method In _objMethods
                    //        If _method.Name.ToUpper = "plotCurrentDayRoomStatus".ToUpper Then
                    //            _method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.MDI, Nothing)
                    //        End If
                    //    Next
                    //Catch ex As Exception

                    //End Try
                    this.Close();
                    break;
                case "BLOCKED":
                    break;

                case "ENGINEERING JOB":
                    this.Close();
                    break;

                //					case "VIEW CALENDAR":
                //						
                //						this.Close();
                //						break;
            }
        }

        //private string selStart;
        //private string selEnd;
        int startCol;
        int endCol;
        int rowStart;
        int rowEnd;

        private void ExchangeInt(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }
        private void ExchangeDate(ref DateTime x, ref DateTime y)
        {
            DateTime temp;
            temp = x;
            x = y;
            y = temp;
        }
        private bool isSimultaneous()
        {
            Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection roomeventCollection;

            if (RoomEventCollections.Count >= 1)
            {
                if (RoomEventCollections.Count == 1)
                {
                    roomeventCollection = (Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection)RoomEventCollections[0];
                }
                else
                {
                    roomeventCollection = (Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection)RoomEventCollections[RoomEventCollections.Count-1];
                }

                Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents roomevent;
                roomevent = roomeventCollection.LastItem;
                if (roomevent != null)
                {
                    if (string.Format("{0:MM/dd/yyyy}", roomevent.EventDate) == string.Format("{0:MM/dd/yyyy}", startDate.AddDays(startCol / 2)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

        }

        private bool isTheSameRoomSelection()
        {
            Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection roomeventCollection = null;
            if (RoomEventCollections.Count >= 1)
            {
                foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection tempLoopVar_roomeventCollection in RoomEventCollections)
                {
                    roomeventCollection = tempLoopVar_roomeventCollection;
                }
                Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents roomevent;
                roomevent = roomeventCollection.Item(roomeventCollection.Count - 1);
                if (roomevent != null)
                {
                    if (roomevent.RoomID == this.vsGrid.get_TextMatrix(rowStart, 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void AddRoomEventsToLastRoomEventsCollecton(Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection roomEventColl)
        {
            if (RoomEventCollections != null)
            {
                if (RoomEventCollections.Count >= 1)
                {
                    Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection roomEventCol = null;
                    foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection tempLoopVar_roomEventCol in RoomEventCollections)
                    {
                        roomEventCol = tempLoopVar_roomEventCol;
                    }

                    roomEventCol.Merge(roomEventColl);
                    LocalRoomeventCollections.Add( roomEventColl );
                }
                else
                {
                    RoomEventCollections.Add( roomEventColl );

                }
            }

        }
        private bool extendSDays;
		private void btnMark_Click(System.Object sender, System.EventArgs e)
		{
			switch (OperationMode.ToLower())
			{
				// when operation is individual reservation
				case "reservation":
					if (rowStart == rowEnd)
					{
						ArrayList rooms = new ArrayList();
						for (int r = rowStart; r <= rowEnd; r++)
						{
							rooms.Add(this.vsGrid.get_TextMatrix(r, 1));
						}
						int dayStart = ((startCol - 2) / 2);//allow overlapping at start date
						int dayEnd = ((endCol - 2) / 2); //allow overlapping at end date
						string sDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayStart + 1)); // add 1 to dayStart since we allow overlapping of startDate [for Conflict Check only]
						string eDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayEnd - 1)); // deduct 1 to dayEnd since we allow overlapping of endDate [for Conflick check only]
						Reservation.BusinessLayer.ReservationsFacade oReserveF = new ReservationsFacade();
						if ((oReserveF.isConflictWithRoomEvents(sDate, eDate, rooms)))
						{
							MessageBox.Show("There is an existing blocking or roomevents set by other user for this selection.\nTry Selecting any of the roomtype to refresh room calendar display.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						//check if simultaneous dates
						if (!isSimultaneous())
						{
							MessageBox.Show("Dates in the selection should be Contiguous!");
							this.vsGrid.BackColorSel = Color.Red;
							return;
						}
						if (CheckRange(rowStart, startCol, rowEnd, endCol) == false)
						{
							vsGrid.Select(rowStart, startCol, rowEnd, endCol);

							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;

							vsGrid.CellBackColor = blockColor;

							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle; ;



							//int cols;
							RoomEventCollection RoomEventCollection = new RoomEventCollection();
							RoomEventCollection.EventType = getEventType(blockColor);
							//if (endCol % 2 == 1)
							//{
							//    endCol++;
							//}
							DateTime _startDate = this.dtpStartDate.Value.AddDays(dayStart);
							DateTime _endDate = this.dtpStartDate.Value.AddDays(dayEnd);

							int _diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _startDate, _endDate);

							for (int i = 0; i <= _diff; i++)
							{
								RoomEvents RoomEvent = new RoomEvents();
								RoomEvent.Eventid = this.EventID;
								RoomEvent.EventType = getEventType(blockColor);
								RoomEvent.RoomID = this.vsGrid.get_TextMatrix(rowStart, 1);

								string eventDate = _startDate.AddDays(i).ToString();

								RoomEvent.EventDate = System.Convert.ToDateTime(eventDate);
								RoomEvent.UpdatedBy = GlobalVariables.gLoggedOnUser;
								RoomEvent.HotelID = GlobalVariables.gHotelId;
								RoomEvent.CreatedBy = GlobalVariables.gLoggedOnUser;
								RoomEventCollection.Add(RoomEvent);

							}

							extendSDays = isTheSameRoomSelection();

							if (extendSDays)
							{
								this.vsGrid.Select(rowStart, startCol - 2);

								RoomEventCollection.EventType = getEventType(this.vsGrid.CellBackColor);
								AddRoomEventsToLastRoomEventsCollecton(RoomEventCollection);
								this.vsGrid.BackColorSel = Color.Red;
								return;
							}
							RoomEventCollections.Add(RoomEventCollection);
							LocalRoomeventCollections.Add(RoomEventCollection);
						}
						else
						{
							MessageBox.Show("Transaction failed.\r\nRoom is either occupied or reserved on the date specified.", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					else
					{
						MessageBox.Show("Invalid selection for marking roomevent. Select only one Room for marking!", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					//this.vsGrid.BackColorSel = Color.Red;
					break;

				//when operation is blocking
				case "view calendar":

					if (rowStart == rowEnd)
					{

						int dayStart = ((startCol - 2) / 2);//allow overlapping at start date
						int dayEnd = ((endCol - 2) / 2); //allow overlapping at end date
						string sDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayStart));
						string eDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayEnd));


						//check if simultaneous dates
						if (!isSimultaneous())
						{
							MessageBox.Show("Dates in the selection should be Contiguous!");
							this.vsGrid.BackColorSel = Color.Red;
							return;
						}
						if (CheckRange(rowStart, startCol, rowEnd, endCol) == false)
						{
							vsGrid.Select(rowStart, startCol, rowEnd, endCol);


							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;

							vsGrid.CellBackColor = blockColor;
							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;


							DateTime _startDate = DateTime.Parse(sDate);
							DateTime _endDate = DateTime.Parse(eDate);

							int _diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _startDate, _endDate);
							RoomEventCollection RoomEventCollection = new RoomEventCollection();
							for (int i = 0; i <= _diff; i++)
							{
								RoomEvents RoomEvent = new RoomEvents();
								RoomEvent.Eventid = this.EventID;
								RoomEvent.EventType = getEventType(blockColor);
								RoomEvent.RoomID = this.vsGrid.get_TextMatrix(rowStart, 1);

								string eventDate = _startDate.AddDays(i).ToString();

								RoomEvent.EventDate = System.Convert.ToDateTime(eventDate);
								RoomEvent.UpdatedBy = GlobalVariables.gLoggedOnUser;
								RoomEvent.HotelID = GlobalVariables.gHotelId;
								RoomEvent.CreatedBy = GlobalVariables.gLoggedOnUser;
								RoomEventCollection.Add(RoomEvent);

							}


							extendSDays = isTheSameRoomSelection();

							if (extendSDays)
							{
								this.vsGrid.Select(rowStart, startCol - 2);

								RoomEventCollection.EventType = getEventType(this.vsGrid.CellBackColor);
								AddRoomEventsToLastRoomEventsCollecton(RoomEventCollection);
								this.vsGrid.BackColorSel = Color.Red;
								return;
							}
							RoomEventCollections.Add(RoomEventCollection);
							LocalRoomeventCollections.Add(RoomEventCollection);
						}
						else
						{
							MessageBox.Show("You cannot mark a room for an event if it has been scheduled already!", "Calendar");
						}
					}
					else
					{
						MessageBox.Show("Invalid selection for marking roomevent. Select only one Room for marking!", "Calendar");
					}
					//this.vsGrid.BackColorSel = Color.Red;
					break;

				//when operation is blocking
				case "blocking":

					if (oRoomBlockCollection != null)
					{
						if (oRoomBlockCollection.Count > 0)
						{
							if (MessageBox.Show("Blocking Process not complete! Click done to complete blocking.", "Unfinished Blocking Process", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
							{
								return;
							}
						}
						else
						{
							if (startCol == endCol && endCol == vsGrid.Cols - 1)
								startCol = 2;//entire row is selected using the _roomNo

							if (CheckRange(rowStart, startCol, rowEnd, endCol) == false)
							{
								// this portion is added to ensure that the blocking has no
								//conflict against roomevents even if calendar ui was not refreshed
								ArrayList rooms = new ArrayList();
								for (int r = rowStart; r <= rowEnd; r++)
								{
									// get value from vsGRID COL 1(ROOM NO) since col 0 is ROOM TYPE
									rooms.Add(this.vsGrid.get_TextMatrix(r, 1));
								}
								//int dayStart = ((startCol - 1) / 2)+1;//allow overlapping at start date
								//int dayEnd = ((endCol - 1) / 2)-1; //allow overlapping at end date

								int dayStart = ((startCol - 2) / 2);//allow overlapping at start date
								int dayEnd = ((endCol - 2) / 2); //allow overlapping at end date


								// checks if SAME DATE SELECTION
								// exit if THE SAME
								if (checkSameDateSelection())
								{
									MessageBox.Show("Transaction failed.\r\nInvalid date selection.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}


								string sDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayStart));
								string eDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayEnd));
								RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();
								if (!(oRoomBlockFacade.isConflictWithRoomEvents(sDate, eDate, rooms)))
								{
									if (!isOpen(frmReasonUI))
									{
										DateTime _blockDateFrom = this.dtpStartDate.Value.AddDays(dayStart);
										DateTime _blockDateTo = this.dtpStartDate.Value.AddDays(dayEnd);

										frmReasonUI = new AddReasonUI(oRoomBlockFacade, oRoomBlockCollection, vsGrid, _blockDateFrom, _blockDateTo, rowStart, rowEnd);
										// AddReasonUI.MdiParent = Me.MdiParent
										if (frmReasonUI.showAddReason())
										{

											if (startCol == 1 || startCol == 2)
												for (int row = rowStart; row <= rowEnd; row++)
												{
													Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
													object[] roomid = { vsGrid.get_TextMatrix(row, 1), "BLOCKING" };
													MethodInfo objMethod = objectType.GetMethod("updateCurrentDayRoomStatus");
													objMethod.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, roomid);
												}

											//reload();
											this.dtpStartDate_CloseUp(this, new EventArgs());

										}
									}
								}
								else
								{
									MessageBox.Show("There is an existing blocking or roomevents set by other user for this selection.\nTry pressing F10 to refresh room calendar display.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}

							}
							else
							{
								MessageBox.Show("There is an existing blocking or roomevents for this selection.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}

					}
					break;

				//oRoomBlockCollection.Clear()
				case "engineering job":
					if (rowStart == rowEnd)
					{
						ArrayList rooms = new ArrayList();
						for (int r = rowStart; r <= rowEnd; r++)
						{
							rooms.Add(this.vsGrid.get_TextMatrix(r, 1));
						}
						int dayStart = ((startCol - 2) / 2);//allow overlapping at start date
						int dayEnd = ((endCol - 2) / 2); //allow overlapping at end date
						string sDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayStart + 1)); // add 1 to dayStart since we allow overlapping of startDate [for Conflict Check only]
						string eDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value.AddDays(dayEnd - 1)); // deduct 1 to dayEnd since we allow overlapping of endDate [for Conflick check only]
						Reservation.BusinessLayer.ReservationsFacade oReserveF = new ReservationsFacade();
						if ((oReserveF.isConflictWithRoomEvents(sDate, eDate, rooms)))
						{
							MessageBox.Show("There is an existing blocking or roomevents set by other user for this selection.\nTry Selecting any of the roomtype to refresh room calendar display.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						//check if simultaneous dates
						if (!isSimultaneous())
						{
							MessageBox.Show("Dates in the selection should be Contiguous!");
							this.vsGrid.BackColorSel = Color.Red;
							return;
						}
						if (CheckRange(rowStart, startCol, rowEnd, endCol) == false)
						{
							vsGrid.Select(rowStart, startCol, rowEnd, endCol);
							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
							vsGrid.CellBackColor = blockColor;
							vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle; ;


							//int cols;
							RoomEventCollection RoomEventCollection = new RoomEventCollection();
							RoomEventCollection.EventType = getEventType(blockColor);

							DateTime _startDate = this.dtpStartDate.Value.AddDays(dayStart);
							DateTime _endDate = this.dtpStartDate.Value.AddDays(dayEnd);

							int _diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _startDate, _endDate);

							for (int i = 0; i <= _diff; i++)
							{
								RoomEvents RoomEvent = new RoomEvents();
								RoomEvent.Eventid = this.EventID;
								RoomEvent.EventType = getEventType(blockColor);
								RoomEvent.RoomID = this.vsGrid.get_TextMatrix(rowStart, 1);

								string eventDate = _startDate.AddDays(i).ToString();

								RoomEvent.EventDate = System.Convert.ToDateTime(eventDate);
								RoomEvent.UpdatedBy = GlobalVariables.gLoggedOnUser;
								RoomEvent.HotelID = GlobalVariables.gHotelId;
								RoomEvent.CreatedBy = GlobalVariables.gLoggedOnUser;
								RoomEventCollection.Add(RoomEvent);
							}

							extendSDays = isTheSameRoomSelection();

							if (extendSDays)
							{
								this.vsGrid.Select(rowStart, startCol - 2);

								RoomEventCollection.EventType = getEventType(this.vsGrid.CellBackColor);
								AddRoomEventsToLastRoomEventsCollecton(RoomEventCollection);
								this.vsGrid.BackColorSel = Color.Red;
								return;
							}
							RoomEventCollections.Add(RoomEventCollection);
							LocalRoomeventCollections.Add(RoomEventCollection);

							// show Start Date, End Date, Room No on Engineering Job Form
							this.mStartDate.Text = string.Format("{0:yyyy-MMM-dd}", _startDate);
							this.mEndDate.Text = string.Format("{0:yyyy-MMM-dd}", _endDate);
							this.mRoomId.Text = this.vsGrid.get_TextMatrix(rowStart, 1);

						}
						else
						{
							MessageBox.Show("Transaction failed.\r\nRoom is either occupied or reserved on the date specified.", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					else
					{
						MessageBox.Show("Invalid selection for marking roomevent. Select only one Room for marking!", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}

					break;
			}


		}

        private bool checkSameDateSelection()
        {
			//if (startCol % 2 == 0)
			//{
			//    startCol++;
			//}
			//if (endCol % 2 == 1)
			//{
			//    endCol--;
			//}

			int dayStart = ((startCol - 2) / 2);//allow overlapping at start date
			int dayEnd = ((endCol - 2) / 2); //allow overlapping at end date
			string sDate = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate).AddDays(dayStart));
			string eDate = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate).AddDays(dayEnd));

			if (sDate == eDate)
                return true;
            else
                return false;

        }
        private void refresh()
        {
            InitializeComponent();
            startDate = this.dtpStartDate.Value;
            PopulateRoomsAndDatesInGrid();

            this.btnMark.Text = OperationMode;
            blockColor = getColor(OperationMode);
            this.btnMark.Text = "Block";
            this.Text = "Blocking";
            this.btnOK.Enabled = false;
            this.btnClear.Enabled = false;
            oCalendarFacade = new Jinisys.Hotel.Reservation.BusinessLayer.CalendarFacade();
        }
        private bool CheckRange(int row1, int col1, int row2, int col2)
        {
            bool isColored = false;
            int row;
            int col;
            for (row = row1; row <= row2; row++)
            {
                for (col = col1; col <= col2; col++)
                {
                    //vsGrid.CtlSelect(row, col, null, null);
                    vsGrid.Select(row, col);

                    if (vsGrid.CellBackColor.Equals(Color.Brown) || vsGrid.CellBackColor.Equals(Color.Cyan) || vsGrid.CellBackColor.Equals(Color.Aqua) || vsGrid.CellBackColor.Equals(Color.GreenYellow) || vsGrid.CellBackColor.Equals(Color.DodgerBlue))
                    {
                        isColored = true;
                        return isColored;
                    }
                }
            }
            return isColored;
        }
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            int row;
            int col;
            for (row = rowStart; row <= rowEnd; row++)
            {
                for (col = startCol; col <= endCol; col++)
                {
                    if (col % 2 == 0)
                    {
                        RemoveRoomEvents(row, col);
                    }
                }
            }

        }
        private void RemoveRoomEvents(int row, int col)
        {
            Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection RoomEventColl;
            foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection tempLoopVar_RoomEventColl in LocalRoomeventCollections)
            {
                RoomEventColl = tempLoopVar_RoomEventColl;
                Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents roomevent;

                foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents tempLoopVar_roomevent in RoomEventColl)
                {
                    roomevent = tempLoopVar_roomevent;
                    if (roomevent.RoomID == this.vsGrid.get_TextMatrix(row, 0) && roomevent.EventDate.Date == DateTime.Parse(GlobalVariables.gAuditDate).AddDays((col - 1) / 2).Date)
                    {
                        RoomEventColl.Remove(roomevent);
                        RemoveRoomEventInGeneralCollection(roomevent);
                        //vsGrid.CtlSelect(row, col - 1, row, col);
                        vsGrid.Select(row, col - 1, row, col);

                        //vsGrid.FillStyle = VSFlex7L.FillStyleSettings.flexFillRepeat;
                        vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;

                        vsGrid.CellBackColor = Color.White;
                        //vsGrid.FillStyle = VSFlex7L.FillStyleSettings.flexFillSingle;
                        vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;

                        cleanEmptyRoomEventCollection();
                        return;
                    }
                }
            }
        }
        private void cleanEmptyRoomEventCollection()
        {
            RoomEventCollection RoomEventColl;
            int index = 1;
            foreach (RoomEventCollection tempLoopVar_RoomEventColl in RoomEventCollections)
            {
                RoomEventColl = tempLoopVar_RoomEventColl;
                if (RoomEventColl.Count == 0)
                {
                    RoomEventCollections.Remove(index);
                    cleanEmptyRoomEventCollection();
                }
                index++;
            }
            index = 1;
            foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection tempLoopVar_RoomEventColl in LocalRoomeventCollections)
            {
                RoomEventColl = tempLoopVar_RoomEventColl;
                if (RoomEventColl.Count == 0)
                {
                    LocalRoomeventCollections.Remove(index);
                    cleanEmptyRoomEventCollection();
                }
                index++;
            }
        }
        private void RemoveRoomEventInGeneralCollection(Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents Roomevent)
        {
            Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection RoomEventColl;
            foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomEventCollection tempLoopVar_RoomEventColl in RoomEventCollections)
            {
                RoomEventColl = tempLoopVar_RoomEventColl;

                Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents re;
                foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents tempLoopVar_re in RoomEventColl)
                {
                    re = tempLoopVar_re;
                    if (re.RoomID == Roomevent.RoomID && re.EventDate == Roomevent.EventDate)
                    {
                        RoomEventColl.Remove(re);
                    }
                    return;
                }

            }

        }
        
		private IList<RoomType> roomTypeCollection;
        private void RoomCalendarUI_Load(System.Object sender, System.EventArgs e)
        {
			this.vsGrid.BackColorSel = blockColor;

            RoomTypeFacade oRoomTypeFacade = new RoomTypeFacade();
            roomTypeCollection = oRoomTypeFacade.getRoomTypesList("");
            cboRoomType.Items.Clear();
            cboRoomType.Items.Add("ALL");
			foreach (RoomType _oRoomType in roomTypeCollection)
			{
				this.cboRoomType.Items.Add(_oRoomType.RoomTypeCode);
			}
			
            //Top = 0;
            //Left = 0;


        }

		private void setRoomEvents(string folioID)
		{
			RoomEventCollection roomEventCollection;
			string arrivalDate;
			string departtureDate;
			ScheduleFacade oScheduleFacade = new ScheduleFacade();

			foreach (RoomEventCollection tempLoopVar_roomEventCollection in LocalRoomeventCollections) //this is altered by jun mar to test for local copy of the collection
			{

				roomEventCollection = tempLoopVar_roomEventCollection;

				RoomEvents oRoomEvent = roomEventCollection.Item(0);
				
				arrivalDate = oRoomEvent.EventDate.ToString();
				
				//ListViewItem listViewItem = new ListViewItem(oRoomEvent.RoomID);
				int _lastRow = lGrdFolioSchedule.Rows.Count;
				lGrdFolioSchedule.Rows.Count += 1;

				// set focus not on GRID to avoid "empty-cell-on-focus bug"
				this.btnMark.Focus();

				this.lGrdFolioSchedule.SetData(_lastRow, 0, oRoomEvent.RoomID);
				lGrdFolioSchedule.SetData(_lastRow,2, oRoomEvent.EventDate);

				oRoomEvent = roomEventCollection.Item(roomEventCollection.Count - 1);
				departtureDate = oRoomEvent.EventDate.ToString();

				lGrdFolioSchedule.SetData(_lastRow, 3, oRoomEvent.EventDate);


				// UPDATE FOLIOSCHEDULE GRID ////////////////////////////////////
				RowColEventArgs rowColEventArgs = new RowColEventArgs(_lastRow, 3);
				object objForm = (object)loCallingForm;

				object[] parameters = { objForm , rowColEventArgs };
				
				// TO DATE
				loCallingForm.GetType().GetMethod("grdFolioSchedule_AfterEdit").Invoke(loCallingForm, parameters);
				
				// ROOM NO
				rowColEventArgs = new RowColEventArgs(_lastRow, 0);
				parameters[1]= rowColEventArgs;

				loCallingForm.GetType().GetMethod("grdFolioSchedule_AfterEdit").Invoke(loCallingForm, parameters);
				// end update ////////////////////////////////////////////////////

			}

		}

        private void setExtention(string folioID)
        {
            RoomEventCollection roomEventCollection;
            string arrivalDate;
            string departtureDate;
            ScheduleFacade oScheduleFacade = new ScheduleFacade();

            foreach (RoomEventCollection tempLoopVar_roomEventCollection in LocalRoomeventCollections) //this is altered by jun mar to test for local copy of the collection
            {
                roomEventCollection = tempLoopVar_roomEventCollection;
                
                Schedule oSchedule = new Schedule();
                RoomEvents oRoomEvent;

                oRoomEvent = roomEventCollection.Item(0);
                RoomTypeFacade oRoomTypeFacade = new RoomTypeFacade();

                string RoomType = oRoomTypeFacade.getRoomType( oRoomEvent.RoomID );

				
				if (this.lGrdFolioSchedule.Rows.Count < 2)
					return;

                //arrivalDate = this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[2].Text;
				int _lastRow = lGrdFolioSchedule.Rows.Count - 1;
				arrivalDate = lGrdFolioSchedule.GetDataDisplay(_lastRow, 2); ;
				

                //this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[1].Text = RoomType;
                
                oRoomEvent = roomEventCollection.Item(roomEventCollection.Count - 1);
                departtureDate = oRoomEvent.EventDate.ToString();

                //this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[3].Text = string.Format("{0:dd-MMM-yy}", DateTime.Parse(departtureDate));
				lGrdFolioSchedule.SetData(_lastRow, 3, departtureDate);

                //RateCodeFacade oRateFacade = new Jinisys.Hotel.Configuration.BusinessLayer.RateCodeFacade();
                //decimal RoomRate = (decimal)oRateFacade.getRoomRate( oRoomEvent.RoomID );

				//int days = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day,DateTime.Parse(arrivalDate),DateTime.Parse(departtureDate));
				//if (days == 0 || days == 1)
				//{
				//    days = 1;
				//}
				//else
				//{
				//    // days += 1
				//}
				////this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[4].Text = days.ToString();
				//lGrdFolioSchedule.SetData(_lastRow, 4, days);

				try
				{
					RowColEventArgs rowColEventArgs = new RowColEventArgs(_lastRow, 3);
					object objForm = (object)loCallingForm;

					object[] parameters = { objForm, rowColEventArgs };

					// TO DATE
					loCallingForm.GetType().GetMethod("grdFolioSchedule_AfterEdit").Invoke(loCallingForm, parameters);
				}
				catch
				{ 
				}

                //this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[5].Text = "No Rate Type Applied";
                //this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[6].Text = RoomRate.ToString("N");


                //decimal amount = decimal.Parse(this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[4].Text) * days;

                //this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[7].Text =  amount.ToString("N");
                //this.lvwStayInformation.Items[this.lvwStayInformation.Items.Count - 1].SubItems[8].Text = "Y";
                //this.lvwStayInformation.Refresh();
                
                //lvwStayInformation.Refresh();
				//oSchedule.FolioID = folioID;
				//oSchedule.FromDate = DateTime.Parse(arrivalDate);
				//oSchedule.ToDate = DateTime.Parse(departtureDate);
				//oSchedule.RoomID = oRoomEvent.RoomID;
				//oSchedule.HotelID = 1;
				//oSchedule.UpdatedBy = GlobalVariables.gLoggedOnUser;

                //oSchedule.Rate = (decimal)RoomRate;
                

                //oScheduleFacade.UpdateFolioSchedules(oSchedule);
            }

        }

        private void SaveRoomEvent(Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents roomEvent)
        {
			MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            RoomEventFacade oRoomEventFacade = new RoomEventFacade();
			oRoomEventFacade.saveRoomEvent(roomEvent, ref trans);

			trans.Commit();
        }

        private void dtpStartDate_CloseUp(object sender, System.EventArgs e)
        {
            if (date == this.dtpStartDate.Value)
                return;

            try
            {
				// checks if NO ROOM TYPE SELECTED
				// is so, assign ALL as default ROOMTYPECODE
				if (this.cboRoomType.Text == "")
					this.cboRoomType.Text = "ALL";

                startDate = this.dtpStartDate.Value;
                refresh(this.cboRoomType.Text, startDate, (int)this.nudWeeks.Value);
            }
            catch
            { }
        }

        private void nudWeeks_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
         
            //reload(this.cboRoomType.Text, (int)this.nudWeeks.Value);
            refresh(this.cboRoomType.Text,this.dtpStartDate.Value,(int)this.nudWeeks.Value);
        }

        private bool MouseisDown = false;

        private void vsGrid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            rowStart = this.vsGrid.RowSel;
            startCol = this.vsGrid.ColSel;
        }

        private void vsGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            rowEnd = this.vsGrid.RowSel;
            endCol = this.vsGrid.ColSel;
            if (rowStart >= rowEnd)
            {
                ExchangeInt(ref rowStart, ref rowStart);
            }
            if (startCol >= endCol)
            {
                ExchangeInt(ref startCol, ref endCol);
            }
            MouseisDown = false;
        }

        public void updateCurrentDayStausInMain()
        {
            
            Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
            MethodInfo objMethod = objectType.GetMethod("plotCurrentDayRoomStatus");
            objMethod.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);

        }

        private void btnUnblock_Click(System.Object sender, System.EventArgs e)
        {
                if (vsGrid.get_TextMatrix(vsGrid.Row, vsGrid.Col) != "")
                {
                    vsGrid.Select(vsGrid.Row, vsGrid.Col);
                    if (vsGrid.CellBackColor.Equals(Color.Brown))
                    {
                        string strToParse = this.vsGrid.get_TextMatrix(this.vsGrid.Row, this.vsGrid.Col);
                        string blockName = strToParse;
                        int BlockId = System.Convert.ToInt32(strToParse.Substring(0, strToParse.IndexOf("-")));
                        string RoomID = this.vsGrid.get_TextMatrix(vsGrid.Row, 1);
                        oRoomBlockFacade.DeleteRoomBlock(BlockId, RoomID);

                        int sCol = vsGrid.Col;
                        int start=0 ;
                        for (int x = sCol; x > 1; x--)
                        {
                            try
                            {
                                strToParse = this.vsGrid.get_TextMatrix(this.vsGrid.Row, x);
                                if (strToParse == "")
                                {
                                    if(x!=sCol)
                                        start = x+1;
                                    else
                                        start = x;
                                    break;
                                }
                                int blkid = int.Parse(strToParse.Substring(0, strToParse.IndexOf("-")));
                                if (blkid == BlockId)
                                {
                                    start = x;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception)
                            {
                               start = x+1;
                                break;
                            }
                        }
                        int end=0;
                        for (int y = sCol; y<this.vsGrid.Cols-1; y++)
                        {
                            try
                            {
                                strToParse = this.vsGrid.get_TextMatrix(this.vsGrid.Row, y);
                                if (strToParse == "")
                                {
                                    if(y!=sCol)
                                        end = y-1;
                                    else
                                        end = y;
                                    break;
                                }
                                int blkid = int.Parse(strToParse.Substring(0, strToParse.IndexOf("-")));
                                if (blkid == BlockId)
                                {
                                    end = y;
                                }
                                else
                                    break;
                            }
                            catch (Exception)
                            {
                                end = y - 1;
                                break;
                            }
                        }
                        vsGrid.Select(vsGrid.Row, start, vsGrid.Row, end);
                        for(int i = start ;i<=end;i++)
                        {
                            vsGrid.set_TextMatrix(vsGrid.Row,i,"");
                        }
                        vsGrid.CellForeColor = Color.Black;
                        vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillRepeat;
                        vsGrid.CellBackColor = Color.White;
                        vsGrid.FillStyle = C1.Win.C1FlexGrid.Classic.FillStyleSettings.flexFillSingle;

                    
                        updateCurrentDayStausInMain();

                        //>>for those rooms that are blocked by a group
                        //>>if under a group, decrement the number of blocked rooms
						try
						{
							string roomType = this.vsGrid.get_TextMatrix(vsGrid.Row, 0);
							string folioID = blockName.Substring(blockName.IndexOf('[') + 1, 12);
							EventRoomRequirementFacade _oRoomRequirementsFacade = new EventRoomRequirementFacade();
							_oRoomRequirementsFacade.updateNumberOfBlockedRooms(folioID, roomType, 1);
						}
						catch { }
                    
                    }
               


            }
           
        }

        public void reload()
        {
            Type oType = GlobalVariables.gMDI.GetType();
            MethodInfo oMethodInfo = oType.GetMethod("mnuFrontDeskRoomBlocking_Click");
            object[] obj = { new MenuItem(), new System.EventArgs() };
            oMethodInfo.Invoke(GlobalVariables.gMDI, obj);
        }
       
        private Jinisys.Hotel.Reservation.Presentation.AddReasonUI frmReasonUI;
		
        private void vsGrid_DoubleClick(object sender, System.EventArgs e)
        {
			//this.MdiParent.Cursor = Cursors.WaitCursor;

			try
			{
				vsGrid.Select(vsGrid.Row, vsGrid.Col);
				CellRange cr = vsGrid.GetMergedRange(vsGrid.Row, vsGrid.Col);
				

				Color clr = vsGrid.CellBackColor;

				switch (clr.Name)
				{
					case "Brown":

						int blockid = System.Convert.ToInt32(this.vsGrid.get_TextMatrix(this.vsGrid.Row, this.vsGrid.Col).Substring(0, this.vsGrid.get_TextMatrix(this.vsGrid.Row, this.vsGrid.Col).IndexOf("-")));
						string reason = this.vsGrid.get_TextMatrix(this.vsGrid.Row, this.vsGrid.Col).Substring(this.vsGrid.get_TextMatrix(this.vsGrid.Row, this.vsGrid.Col).IndexOf("-") + 1);

						if (!isOpen(frmReasonUI))
						{
							frmReasonUI = new Jinisys.Hotel.Reservation.Presentation.AddReasonUI(blockid);
							frmReasonUI.Text = "View Blocking Details";
							frmReasonUI.btnOk.Enabled = false;
							frmReasonUI.btnCancel.Text = "Close";
							frmReasonUI.ShowDialog(this);
						}

						break;

					case "DodgerBlue":
					case "Cyan":
						//int colNum = this.vsGrid.Col / 2;
						//if (this.vsGrid.Col % 2 == 1)
						//{
						//    colNum++;
						//}
						//colNum--;
						int colNum = cr.c1 / 2;
						

						// for first Row Selection
						if (cr.c1 == 2)
						{
							colNum = 0;
						}
						else
						{
							if (cr.c1 % 2 == 1)
							{
								colNum--;
							}
						}

						int endColNum = cr.c2 / 2;
						// for end Col Selection
						if (cr.c2 == 2)
						{
							endColNum = 0;
						}
						else
						{
							//if (cr.c2 % 2 == 1)
							//{
								endColNum--;
							//}
						}

						//colNum--;


						DateTime date = this.dtpStartDate.Value.AddDays(colNum);
						DateTime endDate = this.dtpStartDate.Value.AddDays(endColNum);

						string roomNo = this.vsGrid.get_TextMatrix(this.vsGrid.Row, 1);
						string eventType = clr.Name == "DodgerBlue" ? "RESERVATION" : "IN HOUSE";
						string paramDate = string.Format("{0:yyyy-MM-dd}", date);
						string paramEndDate = string.Format("{0:yyyy-MM-dd}", endDate);

						RoomEventFacade oRoomEventFacade = new RoomEventFacade();

						try
						{
							string _folioId = oRoomEventFacade.getRoomEventsFolioId(roomNo, paramDate,paramEndDate, eventType);

							FolioFacade _oFolioFacade = new FolioFacade();
							Folio _oFolio = _oFolioFacade.GetFolio(_folioId);

							GroupReservationUI _oGroupReservationUI;

							switch (_oFolio.FolioType)
							{ 
								case "PERSONAL":
								case "INDIVIDUAL":
								case "SHARE":
									ReservationFolioUI reservationFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioFromCalendar, _folioId);
									reservationFolioUI.MdiParent = this.MdiParent;
									reservationFolioUI.Show();

									viewFromCalendar = true;
									break;

								case "CORPORATE":
								case "GROUP":
                                    //_oGroupReservationUI = new GroupReservationUI(_oFolio.FolioID, new C1FlexGrid());
                                    //_oGroupReservationUI.MdiParent = this.MdiParent;
                                    //_oGroupReservationUI.Show();

                                    //viewFromCalendar = true;
                                    ReservationUI _oReservationUI = new ReservationUI(_oFolio.FolioID);
                                    _oReservationUI.MdiParent = this.MdiParent;
                                    _oReservationUI.Show();
									break;

								case "DEPENDENT":
									_oGroupReservationUI = new GroupReservationUI(_oFolio.MasterFolio, new C1FlexGrid());
									_oGroupReservationUI.MdiParent = this.MdiParent;
									_oGroupReservationUI.Show();

									viewFromCalendar = true;
									break;

							}
							
						}
						catch { }

						
						break;
					default:
						break;
				}

			}
			catch (Exception) { }
			finally
			{
				this.MdiParent.Cursor = Cursors.Default;
			}
        }

        private bool isOpen(System.Windows.Forms.Form frm1)
        {
            System.Windows.Forms.Form frm;
            foreach (System.Windows.Forms.Form tempLoopVar_frm in this.MdiChildren)
            {
                frm = tempLoopVar_frm;

                if (frm == frm1)
                {
                    frm.Focus();
                    return true;
                }
            }
            return false;
        }

        private void vsGrid_SelChange(object sender, System.EventArgs e)
        {
			int colEnd;
            int colStart = vsGrid.ColSel;

			if (rowStart != 0)
			{
				colEnd = colStart;

				colStart = startCol;


				DateTime dtFrom = startDate.AddDays(colStart / 2);
				DateTime dtTo = startDate.AddDays(colEnd / 2);
				if (dtFrom > dtTo)
				{

					ExchangeDate(ref dtFrom, ref  dtTo);
				}

				this.txt.Text = "From: " + string.Format(GlobalVariables.gDateFormat, dtFrom) + "    To: " + string.Format(GlobalVariables.gDateFormat, dtTo);

			}

			//try
			//{
			//    Color cellColor = vsGrid.CellBackColor;
			//    if (!cellColor.Equals(SystemColors.Window))
			//    {
			//        this.vsGrid.BackColorSel = cellColor;
			//    }
			//    else
			//    {
			//        this.vsGrid.BackColorSel = blockColor;
			//    }
			//}
			//catch { }

        }

		bool viewFromCalendar = false;
        private void RoomCalendarUI_Activated(object sender, System.EventArgs e)
        {
            RoomCalendarUI_Load(sender, e);

			if (viewFromCalendar)
			{
				string _roomType = "";

				if (this.cboRoomType.Text == "")
					_roomType = "ALL";
				else
					_roomType = this.cboRoomType.Text;

				refresh(_roomType, this.dtpStartDate.Value, (int)this.nudWeeks.Value);

				viewFromCalendar = false;
			}

			this.WindowState = FormWindowState.Maximized;
        }

        public void SaveEntry()
        {
            btnOK_Click();
        }

        private void cboRoomType_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cboRoomType.SelectedItem != null)
            {
                string txt = this.cboRoomType.SelectedItem.ToString();
                this.cboRoomType.Text = this.cboRoomType.SelectedItem.ToString();
                refresh(txt, this.dtpStartDate.Value, (int)this.nudWeeks.Value);
                this.cboRoomType.Text = txt;
            }
        }

        public void refresh(string txt,DateTime startD,int nOfWeeks)
        {
            switch (OperationMode.ToLower())
            {
                case "blocking":
                    reload(OperationMode,txt, (int)this.nudWeeks.Value,startD);
                    break;
                case "reservation":
                    //loadCalendarUI(string pFolioID,string mode,ListView pListView,string eventtype,string rmType,DateTime date)

					Type oType = lGrdFolioSchedule.FindForm().GetType(); //lvwStayInformation.FindForm().GetType();
					Type[] types = { typeof(System.String), typeof(System.String), typeof(C1FlexGrid), typeof(System.String), typeof(DateTime), typeof(System.Int32) };
					object[] paramsVal = { EventID, OperationMode, lGrdFolioSchedule, txt, startD, nOfWeeks };
                    MethodInfo mInfo = oType.GetMethod("loadCalendarUI", types);
					mInfo.Invoke(lGrdFolioSchedule.FindForm(), paramsVal);
                    this.Close();
                    break;
                case "view calendar":
					Type oType1 = lGrdFolioSchedule.FindForm().GetType();
					object[] paramsVal1 = { EventID, OperationMode, lGrdFolioSchedule, EventType, txt, startD, nOfWeeks };
                    Type[] types1 = { typeof(System.String), typeof(System.String), typeof(C1FlexGrid), typeof(System.String), typeof(System.String), typeof(DateTime), typeof(System.Int32) };
                    MethodInfo mInfo1 = oType1.GetMethod("loadCalendarUI", types1);
					mInfo1.Invoke(lGrdFolioSchedule.FindForm(), paramsVal1);
                    this.Close();
                    break;

                case "engineering job":
                   
                    Type oType2 = mStartDate.FindForm().GetType();
                    object[] paramsVal2 = { mEnggJobNo, OperationMode, mStartDate, mEndDate, mRoomId, cboRoomType.SelectedItem.ToString(), (DateTime)this.dtpStartDate.Value , (int)nudWeeks.Value };
                    Type[] types2 = { typeof(System.String), typeof(System.String), typeof(TextBox),typeof(TextBox),typeof(TextBox), typeof(System.String), typeof(System.DateTime), typeof(System.Int32) };
                    MethodInfo mInfo2 = oType2.GetMethod("loadCalendarUI");
                    mInfo2.Invoke(mStartDate.FindForm(), paramsVal2);
                    this.Close();
                    break;
                 case "room availability":
                    reload(OperationMode, null, (int)this.nudWeeks.Value, this.dtpStartDate.Value);
                    break;     
            }
        }

        public void reload(String mode, string roomtype, int noofWeeks, DateTime startD)
        {
            switch (mode.ToLower())
            {
                case "blocking":
                    rmType = (object)roomtype;
                    Type oType = GlobalVariables.gMDI.GetType();
                    MethodInfo mInfo = oType.GetMethod("reloadBlockingForm");
                    object[] param = { startD, mode, rmType, noofWeeks };
                    mInfo.Invoke(GlobalVariables.gMDI, param);
                    this.Close();
                    break;
                case "room availability":

                    Type oType1 = GlobalVariables.gMDI.GetType();
                    MethodInfo mInfo1 = oType1.GetMethod("showRoomAvailability");
                    object[] param1 = { noofWeeks, startD };
                    mInfo1.Invoke(GlobalVariables.gMDI, param1);
                    this.Close();
                    break;
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            this.vsGrid.PrintGrid(@"c:\RoomAvailability.doc", C1.Win.C1FlexGrid.PrintGridFlags.ShowPrintDialog, "Room Availability as of " + DateTime.Parse(GlobalVariables.gAuditDate).ToString(), "");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            this.vsGrid.PrintGrid(@"c:\RoomAvailability.doc", C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog, "Room Availability as of " + DateTime.Parse(GlobalVariables.gAuditDate).ToString(), "");
        }

        public void PrintGrid()
        {
            C1.Win.C1FlexGrid.PrintGridFlags flags = C1.Win.C1FlexGrid.PrintGridFlags.FitToPage;
            flags = C1.Win.C1FlexGrid.PrintGridFlags.ShowPageSetupDialog;

            string header = "";
            string footer = "";

            header = "Room Availability as of " + DateTime.Parse(GlobalVariables.gAuditDate).ToString() ;
            footer = "Powered by Folio Plus Hotel Management System © 2006. All rights reserved.\r\nJinisys Softwares, Cebu City.Tel Nos. 63.32.238.7547. www.jinisys.com";
            this.vsGrid.PrintGrid(@"c:\RoomAvailability.doc", flags, header, footer);

        }

        private DateTime date;
        private void dtpStartDate_DropDown(object sender, EventArgs e)
        {
            date = this.dtpStartDate.Value;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            int _col = vsGrid.get_ColWidth(2);
            // setup COLWIDTH for dates
            for (int c = 2; c <= this.vsGrid.Cols - 1; c++)
            {
                this.vsGrid.set_ColWidth(c, _col + 5);
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            int _col = vsGrid.get_ColWidth(2);
            // setup COLWIDTH for dates
            for (int c = 2; c <= this.vsGrid.Cols - 1; c++)
            {
                this.vsGrid.set_ColWidth(c, _col - 5);
            }
        }

    }
}
