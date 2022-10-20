using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Services.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Reflection;
using Jinisys.Hotel.UIFramework;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.Presentation;

using System.Collections.Generic;

namespace Jinisys.Hotel.Services.Presentation
{
        public class EngineeringJobUI : Maintenance2UI
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

            private System.ComponentModel.IContainer components;

            //Required by the Windows Form Designer
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			public System.Windows.Forms.TextBox txtRoomNo;
			public System.Windows.Forms.TextBox TextBox1;
			public System.Windows.Forms.PictureBox PictureBox1;
			public System.Windows.Forms.GroupBox GroupBox1;
			internal System.Windows.Forms.Label Label5;
			public System.Windows.Forms.TextBox txtEnggServiceID;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.TextBox txtServiceName;
			internal System.Windows.Forms.TextBox txtEnggJobNo;
            public System.Windows.Forms.TextBox txtAssignedPerson;
			public System.Windows.Forms.Label Label6;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Panel Panel1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ColumnHeader ColumnHeader3;
			internal System.Windows.Forms.ListView lvwEnggJobs;
			internal System.Windows.Forms.Button btnSearch;
			internal System.Windows.Forms.Panel pnlSearch;
			internal System.Windows.Forms.Label Label9;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.Label Label16;
			public System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.Button btnViewRoomCalendar;
			internal System.Windows.Forms.TextBox txtRoomId;
			public System.Windows.Forms.DateTimePicker dtpEndTime;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.DateTimePicker dtpStartTime;
			public System.Windows.Forms.Label Label8;
			public System.Windows.Forms.Label Label7;
			internal System.Windows.Forms.Label Label4;
            internal Button btnBrowse;
            private ImageList imgIcon;
            public Label label10;
            internal Button btnClose;
			public DateTimePicker dtpEndDate;
			public DateTimePicker dtpStartDate;
			internal System.Windows.Forms.Label picClose;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineeringJobUI));
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.label10 = new System.Windows.Forms.Label();
                this.btnBrowse = new System.Windows.Forms.Button();
                this.imgIcon = new System.Windows.Forms.ImageList(this.components);
                this.Label5 = new System.Windows.Forms.Label();
                this.txtEnggJobNo = new System.Windows.Forms.TextBox();
                this.txtAssignedPerson = new System.Windows.Forms.TextBox();
                this.txtEnggServiceID = new System.Windows.Forms.TextBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.txtServiceName = new System.Windows.Forms.TextBox();
                this.Label6 = new System.Windows.Forms.Label();
                this.Panel1 = new System.Windows.Forms.Panel();
                this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
                this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
                this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
                this.Label3 = new System.Windows.Forms.Label();
                this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
                this.Label8 = new System.Windows.Forms.Label();
                this.Label7 = new System.Windows.Forms.Label();
                this.Label4 = new System.Windows.Forms.Label();
                this.txtRoomId = new System.Windows.Forms.TextBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.btnViewRoomCalendar = new System.Windows.Forms.Button();
                this.gbxCommands = new System.Windows.Forms.GroupBox();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnSearch = new System.Windows.Forms.Button();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnNew = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnDelete = new System.Windows.Forms.Button();
                this.lvwEnggJobs = new System.Windows.Forms.ListView();
                this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.pnlSearch = new System.Windows.Forms.Panel();
                this.picClose = new System.Windows.Forms.Label();
                this.Label9 = new System.Windows.Forms.Label();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.Label16 = new System.Windows.Forms.Label();
                this.GroupBox1.SuspendLayout();
                this.Panel1.SuspendLayout();
                this.gbxCommands.SuspendLayout();
                this.pnlSearch.SuspendLayout();
                this.SuspendLayout();
                // 
                // GroupBox1
                // 
                this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
                this.GroupBox1.Controls.Add(this.label10);
                this.GroupBox1.Controls.Add(this.btnBrowse);
                this.GroupBox1.Controls.Add(this.Label5);
                this.GroupBox1.Controls.Add(this.txtEnggJobNo);
                this.GroupBox1.Controls.Add(this.txtAssignedPerson);
                this.GroupBox1.Controls.Add(this.txtEnggServiceID);
                this.GroupBox1.Controls.Add(this.Label1);
                this.GroupBox1.Controls.Add(this.txtServiceName);
                this.GroupBox1.Controls.Add(this.Label6);
                this.GroupBox1.Controls.Add(this.Panel1);
                this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.GroupBox1.Location = new System.Drawing.Point(221, -3);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(306, 346);
                this.GroupBox1.TabIndex = 8;
                this.GroupBox1.TabStop = false;
                // 
                // label10
                // 
                this.label10.BackColor = System.Drawing.Color.Transparent;
                this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label10.Location = new System.Drawing.Point(10, 72);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(75, 17);
                this.label10.TabIndex = 73;
                this.label10.Text = "Description";
                // 
                // btnBrowse
                // 
                this.btnBrowse.BackColor = System.Drawing.SystemColors.Control;
                this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnBrowse.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnBrowse.ImageIndex = 0;
                this.btnBrowse.ImageList = this.imgIcon;
                this.btnBrowse.Location = new System.Drawing.Point(158, 39);
                this.btnBrowse.Name = "btnBrowse";
                this.btnBrowse.Size = new System.Drawing.Size(30, 27);
                this.btnBrowse.TabIndex = 72;
                this.btnBrowse.UseVisualStyleBackColor = false;
                this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
                // 
                // imgIcon
                // 
                this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
                this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
                this.imgIcon.Images.SetKeyName(0, "Find_ico_6.ico");
                // 
                // Label5
                // 
                this.Label5.Location = new System.Drawing.Point(10, 16);
                this.Label5.Name = "Label5";
                this.Label5.Size = new System.Drawing.Size(81, 16);
                this.Label5.TabIndex = 64;
                this.Label5.Text = "Job No.";
                // 
                // txtEnggJobNo
                // 
                this.txtEnggJobNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtEnggJobNo.Location = new System.Drawing.Point(103, 16);
                this.txtEnggJobNo.MaxLength = 11;
                this.txtEnggJobNo.Name = "txtEnggJobNo";
                this.txtEnggJobNo.Size = new System.Drawing.Size(100, 20);
                this.txtEnggJobNo.TabIndex = 1;
                // 
                // txtAssignedPerson
                // 
                this.txtAssignedPerson.BackColor = System.Drawing.SystemColors.Info;
                this.txtAssignedPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtAssignedPerson.Location = new System.Drawing.Point(103, 106);
                this.txtAssignedPerson.MaxLength = 30;
                this.txtAssignedPerson.Multiline = true;
                this.txtAssignedPerson.Name = "txtAssignedPerson";
                this.txtAssignedPerson.Size = new System.Drawing.Size(194, 19);
                this.txtAssignedPerson.TabIndex = 4;
                // 
                // txtEnggServiceID
                // 
                this.txtEnggServiceID.BackColor = System.Drawing.SystemColors.Info;
                this.txtEnggServiceID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtEnggServiceID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtEnggServiceID.Location = new System.Drawing.Point(103, 43);
                this.txtEnggServiceID.MaxLength = 11;
                this.txtEnggServiceID.Multiline = true;
                this.txtEnggServiceID.Name = "txtEnggServiceID";
                this.txtEnggServiceID.Size = new System.Drawing.Size(51, 19);
                this.txtEnggServiceID.TabIndex = 2;
                // 
                // Label1
                // 
                this.Label1.BackColor = System.Drawing.Color.Transparent;
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.Location = new System.Drawing.Point(10, 47);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(75, 17);
                this.Label1.TabIndex = 48;
                this.Label1.Text = "Eng\'g Service";
                // 
                // txtServiceName
                // 
                this.txtServiceName.BackColor = System.Drawing.Color.White;
                this.txtServiceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtServiceName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtServiceName.Location = new System.Drawing.Point(103, 69);
                this.txtServiceName.MaxLength = 20;
                this.txtServiceName.Multiline = true;
                this.txtServiceName.Name = "txtServiceName";
                this.txtServiceName.Size = new System.Drawing.Size(160, 19);
                this.txtServiceName.TabIndex = 3;
                // 
                // Label6
                // 
                this.Label6.Location = new System.Drawing.Point(10, 108);
                this.Label6.Name = "Label6";
                this.Label6.Size = new System.Drawing.Size(94, 17);
                this.Label6.TabIndex = 49;
                this.Label6.Text = "Person Assigned";
                // 
                // Panel1
                // 
                this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.Panel1.Controls.Add(this.dtpEndDate);
                this.Panel1.Controls.Add(this.dtpStartDate);
                this.Panel1.Controls.Add(this.dtpEndTime);
                this.Panel1.Controls.Add(this.Label3);
                this.Panel1.Controls.Add(this.dtpStartTime);
                this.Panel1.Controls.Add(this.Label8);
                this.Panel1.Controls.Add(this.Label7);
                this.Panel1.Controls.Add(this.Label4);
                this.Panel1.Controls.Add(this.txtRoomId);
                this.Panel1.Controls.Add(this.Label2);
                this.Panel1.Controls.Add(this.btnViewRoomCalendar);
                this.Panel1.Location = new System.Drawing.Point(8, 136);
                this.Panel1.Name = "Panel1";
                this.Panel1.Size = new System.Drawing.Size(290, 198);
                this.Panel1.TabIndex = 68;
                // 
                // dtpEndDate
                // 
                this.dtpEndDate.Checked = false;
                this.dtpEndDate.CustomFormat = "MMM dd, yyyy";
                this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpEndDate.Location = new System.Drawing.Point(180, 66);
                this.dtpEndDate.Name = "dtpEndDate";
                this.dtpEndDate.Size = new System.Drawing.Size(94, 20);
                this.dtpEndDate.TabIndex = 65;
                // 
                // dtpStartDate
                // 
                this.dtpStartDate.Checked = false;
                this.dtpStartDate.CustomFormat = "MMM dd, yyyy";
                this.dtpStartDate.Enabled = false;
                this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpStartDate.Location = new System.Drawing.Point(44, 66);
                this.dtpStartDate.Name = "dtpStartDate";
                this.dtpStartDate.Size = new System.Drawing.Size(94, 20);
                this.dtpStartDate.TabIndex = 64;
                this.dtpStartDate.Value = new System.DateTime(2006, 1, 24, 15, 15, 0, 0);
                // 
                // dtpEndTime
                // 
                this.dtpEndTime.Checked = false;
                this.dtpEndTime.CustomFormat = "hh:mm:ss tt";
                this.dtpEndTime.Enabled = false;
                this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpEndTime.Location = new System.Drawing.Point(159, 132);
                this.dtpEndTime.Name = "dtpEndTime";
                this.dtpEndTime.ShowUpDown = true;
                this.dtpEndTime.Size = new System.Drawing.Size(94, 20);
                this.dtpEndTime.TabIndex = 55;
                // 
                // Label3
                // 
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label3.Location = new System.Drawing.Point(156, 68);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(35, 17);
                this.Label3.TabIndex = 60;
                this.Label3.Text = "To";
                // 
                // dtpStartTime
                // 
                this.dtpStartTime.Checked = false;
                this.dtpStartTime.CustomFormat = "hh:mm:ss tt";
                this.dtpStartTime.Enabled = false;
                this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpStartTime.Location = new System.Drawing.Point(14, 132);
                this.dtpStartTime.Name = "dtpStartTime";
                this.dtpStartTime.ShowUpDown = true;
                this.dtpStartTime.Size = new System.Drawing.Size(94, 20);
                this.dtpStartTime.TabIndex = 54;
                this.dtpStartTime.Value = new System.DateTime(2006, 1, 24, 15, 15, 0, 0);
                // 
                // Label8
                // 
                this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label8.Location = new System.Drawing.Point(159, 116);
                this.Label8.Name = "Label8";
                this.Label8.Size = new System.Drawing.Size(53, 17);
                this.Label8.TabIndex = 61;
                this.Label8.Text = "End Time";
                // 
                // Label7
                // 
                this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label7.Location = new System.Drawing.Point(12, 116);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(66, 17);
                this.Label7.TabIndex = 58;
                this.Label7.Text = "Start Time";
                // 
                // Label4
                // 
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label4.Location = new System.Drawing.Point(9, 68);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(35, 17);
                this.Label4.TabIndex = 59;
                this.Label4.Text = "From";
                // 
                // txtRoomId
                // 
                this.txtRoomId.BackColor = System.Drawing.SystemColors.Info;
                this.txtRoomId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtRoomId.Enabled = false;
                this.txtRoomId.Location = new System.Drawing.Point(82, 17);
                this.txtRoomId.MaxLength = 11;
                this.txtRoomId.Name = "txtRoomId";
                this.txtRoomId.Size = new System.Drawing.Size(81, 20);
                this.txtRoomId.TabIndex = 53;
                this.txtRoomId.TextChanged += new System.EventHandler(this.txtRoomId_TextChanged);
                // 
                // Label2
                // 
                this.Label2.Location = new System.Drawing.Point(16, 19);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(58, 17);
                this.Label2.TabIndex = 52;
                this.Label2.Text = "Room No";
                // 
                // btnViewRoomCalendar
                // 
                this.btnViewRoomCalendar.BackColor = System.Drawing.SystemColors.Control;
                this.btnViewRoomCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnViewRoomCalendar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnViewRoomCalendar.Location = new System.Drawing.Point(175, 12);
                this.btnViewRoomCalendar.Name = "btnViewRoomCalendar";
                this.btnViewRoomCalendar.Size = new System.Drawing.Size(102, 31);
                this.btnViewRoomCalendar.TabIndex = 51;
                this.btnViewRoomCalendar.Text = "&Plot Schedule";
                this.btnViewRoomCalendar.UseVisualStyleBackColor = false;
                this.btnViewRoomCalendar.Click += new System.EventHandler(this.btnViewRoomCalendar_Click);
                // 
                // gbxCommands
                // 
                this.gbxCommands.Controls.Add(this.btnClose);
                this.gbxCommands.Controls.Add(this.btnSearch);
                this.gbxCommands.Controls.Add(this.btnSave);
                this.gbxCommands.Controls.Add(this.btnNew);
                this.gbxCommands.Controls.Add(this.btnCancel);
                this.gbxCommands.Controls.Add(this.btnDelete);
                this.gbxCommands.Location = new System.Drawing.Point(3, 344);
                this.gbxCommands.Name = "gbxCommands";
                this.gbxCommands.Size = new System.Drawing.Size(526, 46);
                this.gbxCommands.TabIndex = 18;
                this.gbxCommands.TabStop = false;
                // 
                // btnClose
                // 
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(454, 10);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 191;
                this.btnClose.Text = "C&lose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnSearch
                // 
                this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSearch.Location = new System.Drawing.Point(178, 10);
                this.btnSearch.Name = "btnSearch";
                this.btnSearch.Size = new System.Drawing.Size(66, 31);
                this.btnSearch.TabIndex = 10;
                this.btnSearch.Text = "&Search";
                this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
                // 
                // btnSave
                // 
                this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSave.Location = new System.Drawing.Point(316, 10);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(66, 31);
                this.btnSave.TabIndex = 8;
                this.btnSave.Text = "Save";
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnNew
                // 
                this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnNew.Location = new System.Drawing.Point(247, 10);
                this.btnNew.Name = "btnNew";
                this.btnNew.Size = new System.Drawing.Size(66, 31);
                this.btnNew.TabIndex = 5;
                this.btnNew.Text = "New";
                this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCancel.Location = new System.Drawing.Point(385, 10);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(66, 31);
                this.btnCancel.TabIndex = 9;
                this.btnCancel.Text = "Cancel";
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnDelete
                // 
                this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnDelete.Location = new System.Drawing.Point(5, 10);
                this.btnDelete.Name = "btnDelete";
                this.btnDelete.Size = new System.Drawing.Size(66, 31);
                this.btnDelete.TabIndex = 4;
                this.btnDelete.Text = "Delete";
                this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                // 
                // lvwEnggJobs
                // 
                this.lvwEnggJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader2,
            this.ColumnHeader3});
                this.lvwEnggJobs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lvwEnggJobs.FullRowSelect = true;
                this.lvwEnggJobs.GridLines = true;
                this.lvwEnggJobs.Location = new System.Drawing.Point(3, 2);
                this.lvwEnggJobs.Name = "lvwEnggJobs";
                this.lvwEnggJobs.Size = new System.Drawing.Size(214, 341);
                this.lvwEnggJobs.TabIndex = 185;
                this.lvwEnggJobs.UseCompatibleStateImageBehavior = false;
                this.lvwEnggJobs.View = System.Windows.Forms.View.Details;
                this.lvwEnggJobs.SelectedIndexChanged += new System.EventHandler(this.lvwEnggJobs_SelectedIndexChanged);
                // 
                // ColumnHeader2
                // 
                this.ColumnHeader2.Text = "ID";
                this.ColumnHeader2.Width = 82;
                // 
                // ColumnHeader3
                // 
                this.ColumnHeader3.Text = "Service Name";
                this.ColumnHeader3.Width = 112;
                // 
                // pnlSearch
                // 
                this.pnlSearch.BackColor = System.Drawing.SystemColors.Info;
                this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.pnlSearch.Controls.Add(this.picClose);
                this.pnlSearch.Controls.Add(this.Label9);
                this.pnlSearch.Controls.Add(this.txtSearch);
                this.pnlSearch.Controls.Add(this.Label16);
                this.pnlSearch.Location = new System.Drawing.Point(14, 153);
                this.pnlSearch.Name = "pnlSearch";
                this.pnlSearch.Size = new System.Drawing.Size(271, 105);
                this.pnlSearch.TabIndex = 186;
                this.pnlSearch.Visible = false;
                // 
                // picClose
                // 
                this.picClose.BackColor = System.Drawing.Color.SteelBlue;
                this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
                this.picClose.Location = new System.Drawing.Point(247, 4);
                this.picClose.Name = "picClose";
                this.picClose.Size = new System.Drawing.Size(18, 16);
                this.picClose.TabIndex = 5;
                this.picClose.Click += new System.EventHandler(this.Close_Click);
                // 
                // Label9
                // 
                this.Label9.Location = new System.Drawing.Point(11, 38);
                this.Label9.Name = "Label9";
                this.Label9.Size = new System.Drawing.Size(240, 15);
                this.Label9.TabIndex = 4;
                this.Label9.Text = "Input Search String here";
                // 
                // txtSearch
                // 
                this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtSearch.Location = new System.Drawing.Point(11, 62);
                this.txtSearch.Name = "txtSearch";
                this.txtSearch.Size = new System.Drawing.Size(248, 22);
                this.txtSearch.TabIndex = 3;
                this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
                // 
                // Label16
                // 
                this.Label16.BackColor = System.Drawing.Color.SteelBlue;
                this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                this.Label16.Image = ((System.Drawing.Image)(resources.GetObject("Label16.Image")));
                this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Label16.Location = new System.Drawing.Point(1, 1);
                this.Label16.Name = "Label16";
                this.Label16.Size = new System.Drawing.Size(267, 21);
                this.Label16.TabIndex = 0;
                this.Label16.Text = "      Search";
                this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // EngineeringJobUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(530, 396);
                this.Controls.Add(this.pnlSearch);
                this.Controls.Add(this.lvwEnggJobs);
                this.Controls.Add(this.GroupBox1);
                this.Controls.Add(this.gbxCommands);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "EngineeringJobUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "Engineering Job";
                this.Closing += new System.ComponentModel.CancelEventHandler(this.EngineeringJobUI_Closing);
                this.TextChanged += new System.EventHandler(this.EngineeringJobUI_TextChanged);
                this.Load += new System.EventHandler(this.EngineeringJobUI_Load);
                this.GroupBox1.ResumeLayout(false);
                this.GroupBox1.PerformLayout();
                this.Panel1.ResumeLayout(false);
                this.Panel1.PerformLayout();
                this.gbxCommands.ResumeLayout(false);
                this.pnlSearch.ResumeLayout(false);
                this.pnlSearch.PerformLayout();
                this.ResumeLayout(false);

			}
			
			#endregion

            #region Variables and Constants

           
            private OperationMode mOperationMode;

            private ControlListener oControlListener;
            private DatasetBinder oDataSetBinder;

            private EngineeringJob oEngineeringJob ;
            private EngineeringJobFacade oEngineeringJobFacade;
            private RoomFacade oRoomFacade ;
            private Sequence oSequence = new Sequence();
            private RoomEventFacade oRoomEventFacade;


            #endregion

            #region Constructor

                public EngineeringJobUI()
			    {
                    oControlListener = new ControlListener();
                    oDataSetBinder = new DatasetBinder();
                    oEngineeringJob = new EngineeringJob();
                    oEngineeringJobFacade = new EngineeringJobFacade();
                    oRoomFacade = new RoomFacade();
                    oRoomEventFacade = new RoomEventFacade();

				    InitializeComponent();
                }

                #endregion

            #region  Methods
			
		        private void populateDataGrid()
                {
                    int i;
                    for (i = 0; i <= oEngineeringJob.Tables[0].Rows.Count - 1; i++)
                    {
                        ListViewItem lst = new ListViewItem(oEngineeringJob.Tables[0].Rows[i]["EnggJobNo"].ToString());
                        lst.SubItems.Add(oEngineeringJob.Tables[0].Rows[i]["ServiceName"].ToString());

                        this.lvwEnggJobs.Items.Add(lst);
                    }
                }

                private void setOperationMode(OperationMode a_OperationMode)
                {
                    mOperationMode = a_OperationMode;
                }
    			
		        private bool hasChanges()
                {
                    if (this.Text.IndexOf("*") > 0)
                        return true;
                    else
                        return false;
                }

			    private void bindRowToControls()
			    {
				    try
				    {
					    oControlListener.StopListen(this);
					    this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].Position = findItemInDataSet(this.lvwEnggJobs.SelectedItems[0].Text);
    				
					    oControlListener.Listen(this);
				    }
				    catch (Exception){}
			    }
    			
		        private bool isRequiredEntriesFilled()
                {
                    if (this.txtEnggJobNo.Text.Length == 0 || this.txtEnggServiceID.Text.Length == 0 || this.txtAssignedPerson.Text.Length == 0 || this.txtRoomId.Text.Length == 0) return false;
                    return true;

                }

                private void assignEntityValues()
                {
                    #region
                    //-->For saving
                    //oEngineeringJob.EnggJobNo = this.txtEnggJobNo.Text;
                    //oEngineeringJob.EnggServiceId = System.Convert.ToInt32(this.txtEnggServiceID.Text);
                    //oEngineeringJob.ServiceName = this.txtServiceName.Text;
                    //oEngineeringJob.AssignedPerson = this.txtAssignedPerson.Text;
                    //oEngineeringJob.RoomId = this.txtRoomId.Text;
                    //oEngineeringJob.StartDate = Strings.Format(System.Convert.ToDateTime(this.txtStartDate.Text), "dd-MM-yyyy");
                    //oEngineeringJob.EndDate = Strings.Format(System.Convert.ToDateTime(this.txtEndDate.Text), "dd-MM-yyyy");
                    //oEngineeringJob.StartTime = Strings.Format(this.dtpStartTime.Value, "hh:mm:ss tt");
                    //oEngineeringJob.EndTime = Strings.Format(this.dtpEndTime.Value, "hh:mm:ss tt");
                    //oEngineeringJob.gHotelId = GlobalVariables.gHotelId;
                    //oEngineeringJob.CreatedBy = GlobalVariables.gLoggedOnUser;
                    #endregion

                    oEngineeringJob.EnggJobNo = this.txtEnggJobNo.Text;
                    oEngineeringJob.EnggServiceId = System.Convert.ToInt32(this.txtEnggServiceID.Text);
                    oEngineeringJob.ServiceName = this.txtServiceName.Text;
                    oEngineeringJob.AssignedPerson = this.txtAssignedPerson.Text;
                    oEngineeringJob.RoomId = this.txtRoomId.Text;
					oEngineeringJob.StartDate = this.dtpStartDate.Value.ToString("yyyy-MM-dd");//string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(this.txtStartDate.Text));
					oEngineeringJob.EndDate = this.dtpEndDate.Value.ToString("yyyy-MM-dd");//string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(this.txtEndDate.Text));
                    oEngineeringJob.StartTime = string.Format("{0:hh:mm:ss tt}",dtpStartTime.Value );
                    oEngineeringJob.EndTime = string.Format("{0:hh:mm:ss tt}",dtpEndTime.Value);
                    oEngineeringJob.gHotelId = GlobalVariables.gHotelId;
                    oEngineeringJob.UpdatedBy = GlobalVariables.gLoggedOnUser;
                }
    				
		        private void insertRoomEvents()
			    {
					MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

					try
					{
						oRoomEventFacade = new RoomEventFacade();

						for (int i = 0; i <= DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(oEngineeringJob.StartDate), DateTime.Parse(oEngineeringJob.EndDate)); i++)
						{
							Jinisys.Hotel.Reservation.BusinessLayer.RoomEvents oRoomEvent = new RoomEvents();
							oRoomEvent.Eventid = oEngineeringJob.EnggJobNo;
							oRoomEvent.RoomID = oEngineeringJob.RoomId;
							oRoomEvent.EventDate = Convert.ToDateTime(oEngineeringJob.StartDate).AddDays(i);
							oRoomEvent.EventType = "ENGINEERING JOB";
							oRoomEvent.HotelID = GlobalVariables.gHotelId;
							oRoomEvent.CreatedBy = GlobalVariables.gLoggedOnUser;
                            oRoomEvent.StartEventTime = DateTime.Parse(oEngineeringJob.StartTime);
                            oRoomEvent.EndEventTime = DateTime.Parse(oEngineeringJob.EndTime);

							oRoomEventFacade.saveRoomEvent(oRoomEvent, ref _oTrans);

						}

						_oTrans.Commit();
					}
					catch(Exception ex)
					{
						_oTrans.Rollback();
						throw ex;
					}
			    }
    			
			    private void setActionButtonStates(bool a_stat)
			    {
    				
				    btnDelete.Enabled = a_stat;
				    btnNew.Enabled = a_stat;
				    btnSave.Enabled = ! a_stat;
				    btnCancel.Enabled = ! a_stat;
			    }
    		
                private int findItemInDataSet(string a_key)
                {
                int i=0;
                    foreach (DataRow drRoom in oEngineeringJob.Tables[0].Rows)
                    {
                       
                        if ((string)drRoom["EnggJobNo"] == a_key)
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

                private void updateCurrentRoomDayStatus()
                {
                    Type objectType = GlobalVariables.gMDI.GetType();
                    MethodInfo[] objMethods = objectType.GetMethods();
                    foreach (MethodInfo method in objMethods)
                    {
                     
                        if (method.Name.ToUpper() == "plotCurrentDayRoomStatus".ToUpper())
                        {
                            method.Invoke(GlobalVariables.gMDI, null);
                        }
                    }
                }

			    #endregion

            #region Data Access Methods

                public bool load()
                {
                    try
                    {
                        oRoomFacade = new RoomFacade();
                        oEngineeringJobFacade = new EngineeringJobFacade();
                        oEngineeringJob = new EngineeringJob();
                        oEngineeringJob = oEngineeringJobFacade.getEngineeringJob();
                        
                        return true;
                    }
                    catch (Exception) { return false; }
                }

                public int insert()
                {
                    try
                    {
                        int rowsAffected=0;
                        oEngineeringJobFacade = new EngineeringJobFacade();
                        rowsAffected = oEngineeringJobFacade.insertEngineeringJob(ref oEngineeringJob);
                        return rowsAffected;
			        }
                    catch (Exception) { return 0; }
                }

                public int update()
                {
                    try
                    {
                        int rowsAffected = 0;
                        oEngineeringJobFacade = new EngineeringJobFacade();
                        rowsAffected = oEngineeringJobFacade.updateEngineeringJob(ref oEngineeringJob);
                        return rowsAffected;
                    }
                    catch (Exception) { return 0; }
                }

                public int delete()
                {
                    try
                    {
                        int rowsAffected = 0;
                        oEngineeringJobFacade = new EngineeringJobFacade();
                        rowsAffected = oEngineeringJobFacade.deleteEngineeringJob(ref oEngineeringJob);
                        return rowsAffected;
                    }
                    catch (Exception) { return 0; }
                }

            #endregion

            #region Events

                private void EngineeringJobUI_Load(object sender, System.EventArgs e)
                {
                    if (load() == true)
                    {

                        if (oEngineeringJob != null)
                        {
                            System.Windows.Forms.Control temp_SystemWindowsFormsControl = this;
                            object temp_object = oEngineeringJob;
                            oDataSetBinder.BindControls(temp_SystemWindowsFormsControl, ref temp_object, new ArrayList());
                            populateDataGrid();
                        }
                        oControlListener.Listen(this);
                    }

					setActionButtonStates(true);

                }

                private void btnNew_Click(System.Object sender, System.EventArgs e)
                {
                    setOperationMode(OperationMode.Add);
                    dtpEndDate.Enabled = false;

                    oControlListener.StopListen(this);

                    this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].SuspendBinding();

                    oSequence = new Sequence( );
                  
                    this.txtEnggJobNo.Text = oSequence.getSequenceId("Eng-", 12, "seq_EnggJob");
                    this.txtEnggServiceID.Focus();

					this.dtpStartTime.Value = DateTime.Parse("08:00 AM");
					this.dtpEndTime.Value = DateTime.Parse("05:00 PM");

                    setActionButtonStates(false);
                }

                private void EngineeringJobUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
                {
                    if (hasChanges() == true)
                    {
                        if (MessageBox.Show("Save changes made to Engineering Job \'" + this.txtEnggJobNo.Text + "\'", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            //removed because lacks checker
                            //if (update() > 0)
                            //{
                            //    this.lvwEnggJobs.Items[findItemInDataSet(this.txtEnggJobNo.Text)].SubItems[1].Text = oEngineeringJob.ServiceName;

                            //    insertRoomEvents();
                            //    this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].ResumeBinding();
                            //    this.Text = "Engineering Jobs";

                            //    oControlListener.Listen(this);
                            //    updateCurrentRoomDayStatus();

                            //}
                            //else
                            //{
                            //    MessageBox.Show("No rows updated", "Database Update Error");
                            //}
                            btnSave_Click(null, null);
                        }
                        else
                        {
                            this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].CancelCurrentEdit();
                            this.Text = "Engineering Jobs";

                        }
                    }
                }

                private void btnSave_Click(System.Object sender, System.EventArgs e)
                {
                    if (isRequiredEntriesFilled())
                    {
                        assignEntityValues();

                        //jlo 7-13-2010 for S.A.
                        DateTime dateStart = DateTime.Parse(oEngineeringJob.StartDate.Replace('-', '/'));
                        DateTime dateEnd = DateTime.Parse(oEngineeringJob.EndDate.Replace('-', '/'));
                        int _dateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dateStart, dateEnd);
                        if (_dateDiff < 0)
                        {
                            MessageBox.Show("Error Saving\r\nInvalid schedule, date from should be less than the date to", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            return;
                        }
                        int eventNo = 0;
                        for (int d = 0; d <= _dateDiff; d++)
                        {
                            String eventDate = "";
                            eventDate = string.Format("{0:yyyy-MM-dd}", dateStart.AddDays(d));
                            eventNo = oRoomEventFacade.CheckConflict(oEngineeringJob.RoomId, eventDate, oEngineeringJob.EndDate, oEngineeringJob.EnggJobNo);
                            if (eventNo != 0)
                            {
                                break;
                            }
                        }
                        if (eventNo != 0)
                        {
                            MessageBox.Show("Error Saving\r\nSchedule input overlaps other schedule on day : " + dateStart, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //end

                        switch (mOperationMode)
                        {

                            case OperationMode.Add:
                                if (insert() > 0)
                                {
                                    ListViewItem lst = new ListViewItem(oEngineeringJob.EnggJobNo);
                                    lst.SubItems.Add(oEngineeringJob.ServiceName);
                                    this.lvwEnggJobs.Items.Add(lst);

                                    insertRoomEvents();
                                    this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].ResumeBinding();
                                    this.Text = "Engineering Jobs";
                                    setActionButtonStates(true);

                                    oControlListener.Listen(this);

                                    updateCurrentRoomDayStatus();
                                 }
                                else
                                {
                                    MessageBox.Show("No rows added", "Database Insert Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                                break;
                            case OperationMode.Edit:
								if (this.txtEnggJobNo.Text == "")
								{
									MessageBox.Show("No rows updated.\r\n\r\nTo add an Engineering Job, please click New button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									return;
								}

                                if (update() > 0)
                                {
                                    this.lvwEnggJobs.Items[findItemInDataSet(this.txtEnggJobNo.Text)].SubItems[1].Text = oEngineeringJob.ServiceName;

                                    insertRoomEvents();
                                    this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].ResumeBinding();
                                    this.Text = "Engineering Jobs";

                                    oControlListener.Listen(this);
                                    updateCurrentRoomDayStatus();

                                }
                                else
                                {
                                    MessageBox.Show("No rows updated", "Database Update Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                break;
                            default:
                                MessageBox.Show("Invalid operation mode", "Abort operation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please input necessary field(s)","Housekeeping",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtAssignedPerson.Focus();
                        return;
                    }
                    dtpEndDate.Enabled = true;
                }

                private void btnCancel_Click(System.Object sender, System.EventArgs e)
                {
                    if (mOperationMode.Equals(OperationMode.Add))
                    {
                        if (this.lvwEnggJobs.Items.Count > 0)
                        {
                            this.lvwEnggJobs.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].CancelCurrentEdit();

                    }

                    this.BindingContext[oEngineeringJob.Tables["EngineeringJobs"]].ResumeBinding();

                    this.Text = "Engineering Jobs";
                    setActionButtonStates(true);

                    oControlListener.Listen(this);
                    dtpEndDate.Enabled = true;
                }

                private void btnDelete_Click(System.Object sender, System.EventArgs e)
                {
                    if (MessageBox.Show("Delete Engineering Job for Room \'" + this.txtRoomId.Text + "\'", "Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {

                        this.Text = "Engineering Jobs";

                        oControlListener.StopListen(this);
                        //oEngineeringJob.EnggJobNo = this.txtEnggJobNo.Text;
                        //oEngineeringJob.gHotelId = GlobalVariables.gHotelId;
                        //oEngineeringJob.UpdatedBy = GlobalVariables.gLoggedOnUser;
                        assignEntityValues();

                        if (delete() > 0)
                        {
                            this.lvwEnggJobs.SelectedItems[0].Remove();

                            if (this.lvwEnggJobs.Items.Count > 0)
                            {
                                this.lvwEnggJobs.Items[0].Selected = true;
                            }

                            oControlListener.Listen(this);
                            updateCurrentRoomDayStatus();
                        }
                    }

                    if (lvwEnggJobs.Items.Count == 0)
                    {
                        clearText();
                    }
                }

                private void EngineeringJobUI_TextChanged(object sender, System.EventArgs e)
                {
                    if (this.Text.IndexOf("*") > 0)
                    {
                        setOperationMode(OperationMode.Edit);
                        setActionButtonStates(false);
                    }
                    else
                    {
                        setActionButtonStates(true);
                    }
                }

            private void clearText()
            {
                oControlListener.StopListen(this);
                foreach (Control ctrl in this.GroupBox1.Controls)
                {
                    if (ctrl is TextBox)
                        ctrl.Text = "";
                }
                dtpEndDate.Enabled = false;
                oControlListener.Listen(this);
            }

                private void btnViewRoomCalendar_Click(System.Object sender, System.EventArgs e)
                {
                    if (this.txtEnggJobNo.Text.Trim().Length != 0)
                    {
						DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);


                        //loadCalendarUI(this.txtEnggJobNo.Text, "Engineering Job", ref this.txtStartDate, ref this.txtEndDate, ref this.txtRoomId, "ALL", DateTime.Now.Date, 4);
						loadCalendarWizard(_auditDate, 5, "ALL");
                    }
                    else
                    {
                       MessageBox.Show("Please click New Button before viewing calendar","Click Button");
                        this.txtEnggJobNo.Focus();
                    }
                }

                RoomCalendarUI roomCalendarUI;
                public void loadCalendarUI(string a_EngJobNo, string a_Mode, ref TextBox a_txtStartDate, ref TextBox a_txtEndDate, ref TextBox a_RoomId, string a_RoomType, DateTime a_StartDate, int a_NoOfWeeks )
                {
                    TextBox rTxtStartDate = a_txtStartDate;
                    TextBox rTxtEndDate = a_txtEndDate;
                    TextBox rTxtRoomId = a_RoomId;

                    roomCalendarUI = new RoomCalendarUI(a_EngJobNo, a_Mode, ref rTxtStartDate, ref rTxtEndDate, ref rTxtRoomId, a_RoomType, a_StartDate, a_NoOfWeeks);
                    roomCalendarUI.MdiParent = this.MdiParent;
                    roomCalendarUI.Show();
                }



                private void btnSearch_Click(System.Object sender, System.EventArgs e)
                {

                    this.oControlListener.StopListen(this);
                    this.pnlSearch.Visible = true;
                    this.txtSearch.Focus();
                }

                private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                    if (e.KeyChar == '\r')
                    {
                        this.lvwEnggJobs.Focus();

                        deselectItem();

                        for (int i = 0; i <= this.lvwEnggJobs.Items.Count - 1; i++)
                        {
                            if (this.lvwEnggJobs.Items[i].SubItems[1].Text.Contains(this.txtSearch.Text.ToUpper()) || this.lvwEnggJobs.Items[i].Text.Contains(this.txtSearch.Text.ToUpper() ))
                            {

                                this.lvwEnggJobs.Items[i].Selected = true;

                                this.pnlSearch.Visible = false;

                                this.oControlListener.Listen(this);
                                return;
                            }
                        }
                    }
                }

                private void Close_Click(System.Object sender, System.EventArgs e)
                {
                    this.pnlSearch.Visible = false;
                }

                private void txtRoomId_TextChanged(System.Object sender, System.EventArgs e)
                {
                    this.dtpStartTime.Enabled = true;
                    this.dtpEndTime.Enabled = true;
                }

                private void lvwEnggJobs_SelectedIndexChanged(System.Object sender, System.EventArgs e)
                {
                    bindRowToControls();
                }

                private void deselectItem()
                {
                    for (int i = 0; i <= this.lvwEnggJobs.Items.Count - 1; i++)
                    {
                        this.lvwEnggJobs.Items[i].Selected = false;
                    }
                }

                #endregion

            private void btnBrowse_Click(object sender, EventArgs e)
            {
                ServicesLookUpUI servicesLookUpUI = new ServicesLookUpUI(this.txtEnggServiceID, this.txtServiceName);

                servicesLookUpUI.MdiParent = this.MdiParent;
                servicesLookUpUI.Show();
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			public void loadCalendarWizard(DateTime pStartDate, int pNoOfWeeks, string pRoomType)
			{

				string _operationMode = "ENGINEERING JOB";
				
				IList<Schedule> _oScheduleCollection = new List<Schedule>();

				RoomCalendar_New oRoomCalendarUI = new RoomCalendar_New(_operationMode, pStartDate, pNoOfWeeks, pRoomType, _oScheduleCollection);
				_oScheduleCollection = oRoomCalendarUI.launchCalendarWizard(this.Label1);

				if (_oScheduleCollection == null)
				{
					return;
				}

				if (_oScheduleCollection.Count <= 0)
				{
					return;
				}
				Schedule oSched = _oScheduleCollection[0];

				this.txtRoomId.Text = oSched.RoomID;
				this.dtpStartDate.Value = oSched.FromDate;
				this.dtpEndDate.Value = oSched.ToDate;
                if (ConfigVariables.gIsEMMOnly == "true")
                {
                    this.dtpStartTime.Value = oSched.StartTime;
                    this.dtpEndTime.Value = oSched.EndTime;
                }
			
			}

        }
	}

