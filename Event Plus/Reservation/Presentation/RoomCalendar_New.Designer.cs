namespace Jinisys.Hotel.Reservation.Presentation
{
	partial class RoomCalendar_New
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomCalendar_New));
            this.tcAllRooms = new System.Windows.Forms.TabControl();
            this.tabRooms = new System.Windows.Forms.TabPage();
            this.grdRooms = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabFunction = new System.Windows.Forms.TabPage();
            this.grdFunctions = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.nudWeeks = new System.Windows.Forms.NumericUpDown();
            this.lblWeekToDisplay = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.Label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnMark = new System.Windows.Forms.Button();
            this.tipCalendar = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoom = new System.Windows.Forms.Button();
            this.txtSearchRoom = new System.Windows.Forms.TextBox();
            this.grbHeader = new System.Windows.Forms.GroupBox();
            this.tipHoverInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tipHoverFunction = new System.Windows.Forms.ToolTip(this.components);
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.tcAllRooms.SuspendLayout();
            this.tabRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRooms)).BeginInit();
            this.tabFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFunctions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeeks)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAllRooms
            // 
            this.tcAllRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcAllRooms.Controls.Add(this.tabRooms);
            this.tcAllRooms.Controls.Add(this.tabFunction);
            this.tcAllRooms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAllRooms.Location = new System.Drawing.Point(6, 81);
            this.tcAllRooms.Name = "tcAllRooms";
            this.tcAllRooms.SelectedIndex = 0;
            this.tcAllRooms.Size = new System.Drawing.Size(841, 534);
            this.tcAllRooms.TabIndex = 2;
            this.tcAllRooms.SelectedIndexChanged += new System.EventHandler(this.tcAllRooms_SelectedIndexChanged);
            // 
            // tabRooms
            // 
            this.tabRooms.Controls.Add(this.grdRooms);
            this.tabRooms.Location = new System.Drawing.Point(4, 23);
            this.tabRooms.Name = "tabRooms";
            this.tabRooms.Padding = new System.Windows.Forms.Padding(3);
            this.tabRooms.Size = new System.Drawing.Size(833, 507);
            this.tabRooms.TabIndex = 0;
            this.tabRooms.Text = "Rooms     ";
            this.tabRooms.UseVisualStyleBackColor = true;
            this.tabRooms.Click += new System.EventHandler(this.tabRooms_Click);
            // 
            // grdRooms
            // 
            this.grdRooms.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.grdRooms.AllowEditing = false;
            this.grdRooms.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.grdRooms.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdRooms.ColumnInfo = resources.GetString("grdRooms.ColumnInfo");
            this.grdRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRooms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRooms.Location = new System.Drawing.Point(3, 3);
            this.grdRooms.Name = "grdRooms";
            this.grdRooms.Rows.DefaultSize = 17;
            this.grdRooms.Size = new System.Drawing.Size(827, 501);
            this.grdRooms.StyleInfo = resources.GetString("grdRooms.StyleInfo");
            this.grdRooms.TabIndex = 0;
            this.grdRooms.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdRooms_AfterSelChange);
            this.grdRooms.MouseHoverCell += new System.EventHandler(this.grid_MouseHoverCell);
            this.grdRooms.Click += new System.EventHandler(this.grdRooms_Click);
            this.grdRooms.DoubleClick += new System.EventHandler(this.grdRooms_DoubleClick);
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.grdFunctions);
            this.tabFunction.Location = new System.Drawing.Point(4, 23);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.Padding = new System.Windows.Forms.Padding(3);
            this.tabFunction.Size = new System.Drawing.Size(833, 507);
            this.tabFunction.TabIndex = 1;
            this.tabFunction.Text = "Function     ";
            this.tabFunction.UseVisualStyleBackColor = true;
            this.tabFunction.Click += new System.EventHandler(this.tabFunction_Click);
            // 
            // grdFunctions
            // 
            this.grdFunctions.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.grdFunctions.AllowEditing = false;
            this.grdFunctions.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.grdFunctions.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdFunctions.ColumnInfo = resources.GetString("grdFunctions.ColumnInfo");
            this.grdFunctions.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFunctions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFunctions.Location = new System.Drawing.Point(3, 3);
            this.grdFunctions.Name = "grdFunctions";
            this.grdFunctions.Rows.DefaultSize = 17;
            this.grdFunctions.Size = new System.Drawing.Size(827, 501);
            this.grdFunctions.StyleInfo = resources.GetString("grdFunctions.StyleInfo");
            this.grdFunctions.TabIndex = 0;
            this.grdFunctions.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdFunctions_AfterSelChange);
            this.grdFunctions.MouseHoverCell += new System.EventHandler(this.grid_MouseHoverCell);
            this.grdFunctions.Click += new System.EventHandler(this.grdFunctions_Click);
            this.grdFunctions.DoubleClick += new System.EventHandler(this.grdFunctions_DoubleClick);
            // 
            // cboRoomType
            // 
            this.cboRoomType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoomType.Items.AddRange(new object[] {
            "ALL"});
            this.cboRoomType.Location = new System.Drawing.Point(631, 14);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(199, 22);
            this.cboRoomType.TabIndex = 1;
            this.cboRoomType.SelectedIndexChanged += new System.EventHandler(this.cboRoomType_SelectedIndexChanged);
            // 
            // Label12
            // 
            this.Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(561, 18);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(67, 14);
            this.Label12.TabIndex = 0;
            this.Label12.Text = "Room Type :";
            // 
            // nudWeeks
            // 
            this.nudWeeks.Location = new System.Drawing.Point(382, 15);
            this.nudWeeks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeeks.Name = "nudWeeks";
            this.nudWeeks.Size = new System.Drawing.Size(43, 20);
            this.nudWeeks.TabIndex = 3;
            this.nudWeeks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWeeks.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudWeeks.ValueChanged += new System.EventHandler(this.nudWeeks_ValueChanged);
            // 
            // lblWeekToDisplay
            // 
            this.lblWeekToDisplay.AutoSize = true;
            this.lblWeekToDisplay.Location = new System.Drawing.Point(284, 18);
            this.lblWeekToDisplay.Name = "lblWeekToDisplay";
            this.lblWeekToDisplay.Size = new System.Drawing.Size(95, 14);
            this.lblWeekToDisplay.TabIndex = 2;
            this.lblWeekToDisplay.Text = "Weeks to display :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(73, 15);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.CloseUp += new System.EventHandler(this.dtpStartDate_CloseUp);
            this.dtpStartDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpStartDate_KeyPress);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(10, 18);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(60, 14);
            this.Label10.TabIndex = 1;
            this.Label10.Text = "Start date :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 22);
            this.label15.TabIndex = 194;
            this.label15.Text = "Room Calendar";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Label5);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.Label4);
            this.panel1.Controls.Add(this.Label7);
            this.panel1.Controls.Add(this.Label8);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Location = new System.Drawing.Point(388, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 29);
            this.panel1.TabIndex = 195;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(37, 7);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(42, 14);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "Vacant";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(13, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(20, 20);
            this.Label1.TabIndex = 7;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.GreenYellow;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(100, 5);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(20, 20);
            this.Label2.TabIndex = 9;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(124, 7);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(68, 14);
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Out of Order";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(290, 5);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(20, 20);
            this.Label4.TabIndex = 8;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.SystemColors.Control;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(226, 7);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(56, 14);
            this.Label7.TabIndex = 14;
            this.Label7.Text = "Confirmed";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(314, 7);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(51, 14);
            this.Label8.TabIndex = 13;
            this.Label8.Text = "Tentative";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Aqua;
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(202, 5);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(20, 20);
            this.Label3.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(779, 625);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 202;
            this.btnClose.Text = "C&lose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(448, 625);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 31);
            this.btnPrint.TabIndex = 201;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.Location = new System.Drawing.Point(337, 625);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(105, 31);
            this.btnSetup.TabIndex = 200;
            this.btnSetup.Text = "Setup page";
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(6, 625);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(66, 31);
            this.btnRemove.TabIndex = 199;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(152, 625);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(66, 31);
            this.btnDone.TabIndex = 196;
            this.btnDone.Text = "Done";
            this.btnDone.Visible = false;
            this.btnDone.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnMark
            // 
            this.btnMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMark.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMark.Location = new System.Drawing.Point(80, 625);
            this.btnMark.Name = "btnMark";
            this.btnMark.Size = new System.Drawing.Size(66, 31);
            this.btnMark.TabIndex = 197;
            this.btnMark.Text = "Mark";
            this.btnMark.Click += new System.EventHandler(this.btnMark_Click);
            // 
            // tipCalendar
            // 
            this.tipCalendar.AutoPopDelay = 6000;
            this.tipCalendar.InitialDelay = 500;
            this.tipCalendar.IsBalloon = true;
            this.tipCalendar.ReshowDelay = 100;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearch.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.nav_right;
            this.btnSearch.Location = new System.Drawing.Point(820, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSearch.TabIndex = 205;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tipCalendar.SetToolTip(this.btnSearch, "Find Next");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomOut.ForeColor = System.Drawing.Color.DimGray;
            this.btnZoomOut.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.zoom_out1;
            this.btnZoomOut.Location = new System.Drawing.Point(814, 72);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(29, 28);
            this.btnZoomOut.TabIndex = 5;
            this.tipCalendar.SetToolTip(this.btnZoomOut, "Click to Zoom Out");
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoom.FlatAppearance.BorderSize = 0;
            this.btnZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoom.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoom.ForeColor = System.Drawing.Color.DimGray;
            this.btnZoom.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.zoom_in1;
            this.btnZoom.Location = new System.Drawing.Point(783, 72);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(29, 28);
            this.btnZoom.TabIndex = 4;
            this.tipCalendar.SetToolTip(this.btnZoom, "Click to Zoom In");
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // txtSearchRoom
            // 
            this.txtSearchRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchRoom.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchRoom.Location = new System.Drawing.Point(717, 8);
            this.txtSearchRoom.Name = "txtSearchRoom";
            this.txtSearchRoom.Size = new System.Drawing.Size(99, 20);
            this.txtSearchRoom.TabIndex = 204;
            this.txtSearchRoom.Text = "Search Room No.";
            this.txtSearchRoom.Enter += new System.EventHandler(this.txtSearchRoom_Enter);
            this.txtSearchRoom.Leave += new System.EventHandler(this.txtSearchRoom_Leave);
            this.txtSearchRoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchRoom_KeyPress);
            this.txtSearchRoom.TextChanged += new System.EventHandler(this.txtSearchRoom_TextChanged);
            // 
            // grbHeader
            // 
            this.grbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbHeader.Controls.Add(this.cboRoomType);
            this.grbHeader.Controls.Add(this.Label10);
            this.grbHeader.Controls.Add(this.nudWeeks);
            this.grbHeader.Controls.Add(this.dtpStartDate);
            this.grbHeader.Controls.Add(this.lblWeekToDisplay);
            this.grbHeader.Controls.Add(this.Label12);
            this.grbHeader.Location = new System.Drawing.Point(6, 28);
            this.grbHeader.Name = "grbHeader";
            this.grbHeader.Size = new System.Drawing.Size(841, 43);
            this.grbHeader.TabIndex = 206;
            this.grbHeader.TabStop = false;
            // 
            // tipHoverInfo
            // 
            this.tipHoverInfo.AutoPopDelay = 6000;
            this.tipHoverInfo.InitialDelay = 500;
            this.tipHoverInfo.IsBalloon = true;
            this.tipHoverInfo.ReshowDelay = 100;
            // 
            // tipHoverFunction
            // 
            this.tipHoverFunction.AutoPopDelay = 6000;
            this.tipHoverFunction.InitialDelay = 500;
            this.tipHoverFunction.IsBalloon = true;
            this.tipHoverFunction.ReshowDelay = 100;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(79, 43);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // RoomCalendar_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(854, 668);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchRoom);
            this.Controls.Add(this.grbHeader);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnMark);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnZoom);
            this.Controls.Add(this.tcAllRooms);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEndDate);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RoomCalendar_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Calendar";
            this.Activated += new System.EventHandler(this.RoomCalendar_New_Activated);
            this.Load += new System.EventHandler(this.RoomCalendar_New_Load);
            this.tcAllRooms.ResumeLayout(false);
            this.tabRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRooms)).EndInit();
            this.tabFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFunctions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeeks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbHeader.ResumeLayout(false);
            this.grbHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tcAllRooms;
		private System.Windows.Forms.TabPage tabRooms;
		private System.Windows.Forms.TabPage tabFunction;
		private C1.Win.C1FlexGrid.C1FlexGrid grdRooms;
		private C1.Win.C1FlexGrid.C1FlexGrid grdFunctions;
		private System.Windows.Forms.Button btnZoomOut;
		internal System.Windows.Forms.ComboBox cboRoomType;
		private System.Windows.Forms.Button btnZoom;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.NumericUpDown nudWeeks;
		internal System.Windows.Forms.Label lblWeekToDisplay;
		internal System.Windows.Forms.DateTimePicker dtpStartDate;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnPrint;
		internal System.Windows.Forms.Button btnSetup;
		internal System.Windows.Forms.Button btnRemove;
		internal System.Windows.Forms.Button btnDone;
		internal System.Windows.Forms.Button btnMark;
		private System.Windows.Forms.ToolTip tipCalendar;
		private System.Windows.Forms.TextBox txtSearchRoom;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.GroupBox grbHeader;
		private System.Windows.Forms.ToolTip tipHoverInfo;
		private System.Windows.Forms.ToolTip tipHoverFunction;
        internal System.Windows.Forms.DateTimePicker dtpEndDate;
	}
}