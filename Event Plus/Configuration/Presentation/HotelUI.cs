/*
 * Jinisys Softwares, Inc.
 * © 2006
 * 
 * 
*/

using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	
		public class HotelUI : Maintenance2UI, ClassMaintenanceInterface
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
			public System.Windows.Forms.Label Label1;
            internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			public System.Windows.Forms.TextBox txtHotelID;
			public System.Windows.Forms.TextBox txtHotelName;
            public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.Label Label4;
            public System.Windows.Forms.GroupBox grpMain;
            internal Panel pnlSearch;
            private Label label5;
            internal Label picClose;
            internal Label Label16;
            internal Label Label6;
            internal Button btnCloseSearch;
            internal Button btnFind;
            internal TextBox txtSearch;
            private NumericUpDown nudNoOfFloors;
            internal Button btnClose;
			private NumericUpDown nudNoOfRooms;
			public Label label8;
			public Label label7;
			private DateTimePicker dateTimePicker1;
			private C1.Win.C1FlexGrid.C1FlexGrid grdHotel;
            private Panel panel1;
            internal Button btnSearch;
			private DateTimePicker dtpCheckInTime;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotelUI));
                this.grpMain = new System.Windows.Forms.GroupBox();
                this.panel1 = new System.Windows.Forms.Panel();
                this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
                this.dtpCheckInTime = new System.Windows.Forms.DateTimePicker();
                this.nudNoOfRooms = new System.Windows.Forms.NumericUpDown();
                this.label8 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.nudNoOfFloors = new System.Windows.Forms.NumericUpDown();
                this.Label4 = new System.Windows.Forms.Label();
                this.Label3 = new System.Windows.Forms.Label();
                this.txtHotelName = new System.Windows.Forms.TextBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.Label1 = new System.Windows.Forms.Label();
                this.txtHotelID = new System.Windows.Forms.TextBox();
                this.gbxCommands = new System.Windows.Forms.GroupBox();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnDelete = new System.Windows.Forms.Button();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnNew = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.pnlSearch = new System.Windows.Forms.Panel();
                this.label5 = new System.Windows.Forms.Label();
                this.picClose = new System.Windows.Forms.Label();
                this.Label16 = new System.Windows.Forms.Label();
                this.Label6 = new System.Windows.Forms.Label();
                this.btnCloseSearch = new System.Windows.Forms.Button();
                this.btnFind = new System.Windows.Forms.Button();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.grdHotel = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.btnSearch = new System.Windows.Forms.Button();
                this.grpMain.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.nudNoOfRooms)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudNoOfFloors)).BeginInit();
                this.gbxCommands.SuspendLayout();
                this.pnlSearch.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdHotel)).BeginInit();
                this.SuspendLayout();
                // 
                // grpMain
                // 
                this.grpMain.BackColor = System.Drawing.Color.Transparent;
                this.grpMain.Controls.Add(this.panel1);
                this.grpMain.Controls.Add(this.dateTimePicker1);
                this.grpMain.Controls.Add(this.dtpCheckInTime);
                this.grpMain.Controls.Add(this.nudNoOfRooms);
                this.grpMain.Controls.Add(this.label8);
                this.grpMain.Controls.Add(this.label7);
                this.grpMain.Controls.Add(this.nudNoOfFloors);
                this.grpMain.Controls.Add(this.Label4);
                this.grpMain.Controls.Add(this.Label3);
                this.grpMain.Controls.Add(this.txtHotelName);
                this.grpMain.Controls.Add(this.Label2);
                this.grpMain.Controls.Add(this.Label1);
                this.grpMain.Controls.Add(this.txtHotelID);
                this.grpMain.Location = new System.Drawing.Point(229, 0);
                this.grpMain.Name = "grpMain";
                this.grpMain.Size = new System.Drawing.Size(310, 306);
                this.grpMain.TabIndex = 126;
                this.grpMain.TabStop = false;
                // 
                // panel1
                // 
                this.panel1.Location = new System.Drawing.Point(21, 176);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(200, 100);
                this.panel1.TabIndex = 67;
                // 
                // dateTimePicker1
                // 
                this.dateTimePicker1.CustomFormat = "hh:mm tt";
                this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dateTimePicker1.Location = new System.Drawing.Point(105, 216);
                this.dateTimePicker1.Name = "dateTimePicker1";
                this.dateTimePicker1.ShowUpDown = true;
                this.dateTimePicker1.Size = new System.Drawing.Size(76, 20);
                this.dateTimePicker1.TabIndex = 66;
                this.dateTimePicker1.Value = new System.DateTime(2008, 10, 18, 12, 44, 0, 0);
                this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
                // 
                // dtpCheckInTime
                // 
                this.dtpCheckInTime.CustomFormat = "hh:mm tt";
                this.dtpCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpCheckInTime.Location = new System.Drawing.Point(105, 177);
                this.dtpCheckInTime.Name = "dtpCheckInTime";
                this.dtpCheckInTime.ShowUpDown = true;
                this.dtpCheckInTime.Size = new System.Drawing.Size(76, 20);
                this.dtpCheckInTime.TabIndex = 65;
                this.dtpCheckInTime.Value = new System.DateTime(2008, 10, 18, 12, 44, 0, 0);
                this.dtpCheckInTime.ValueChanged += new System.EventHandler(this.dtpCheckInTime_ValueChanged);
                // 
                // nudNoOfRooms
                // 
                this.nudNoOfRooms.Location = new System.Drawing.Point(92, 117);
                this.nudNoOfRooms.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
                this.nudNoOfRooms.Name = "nudNoOfRooms";
                this.nudNoOfRooms.Size = new System.Drawing.Size(63, 20);
                this.nudNoOfRooms.TabIndex = 64;
                this.nudNoOfRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label8.Location = new System.Drawing.Point(18, 220);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(83, 14);
                this.label8.TabIndex = 63;
                this.label8.Text = "Check-Out Time";
                this.label8.Click += new System.EventHandler(this.label8_Click);
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label7.Location = new System.Drawing.Point(18, 182);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(74, 14);
                this.label7.TabIndex = 62;
                this.label7.Text = "Check-In Time";
                this.label7.Click += new System.EventHandler(this.label7_Click);
                // 
                // nudNoOfFloors
                // 
                this.nudNoOfFloors.Location = new System.Drawing.Point(92, 84);
                this.nudNoOfFloors.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
                this.nudNoOfFloors.Name = "nudNoOfFloors";
                this.nudNoOfFloors.Size = new System.Drawing.Size(63, 20);
                this.nudNoOfFloors.TabIndex = 61;
                this.nudNoOfFloors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                // 
                // Label4
                // 
                this.Label4.AutoSize = true;
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label4.Location = new System.Drawing.Point(18, 120);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(69, 14);
                this.Label4.TabIndex = 60;
                this.Label4.Text = "No of Rooms";
                // 
                // Label3
                // 
                this.Label3.AutoSize = true;
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label3.Location = new System.Drawing.Point(18, 87);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(66, 14);
                this.Label3.TabIndex = 58;
                this.Label3.Text = "No of Floors";
                // 
                // txtHotelName
                // 
                this.txtHotelName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtHotelName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtHotelName.Location = new System.Drawing.Point(92, 51);
                this.txtHotelName.MaxLength = 20;
                this.txtHotelName.Name = "txtHotelName";
                this.txtHotelName.Size = new System.Drawing.Size(204, 20);
                this.txtHotelName.TabIndex = 55;
                // 
                // Label2
                // 
                this.Label2.AutoSize = true;
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.Location = new System.Drawing.Point(18, 54);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(61, 14);
                this.Label2.TabIndex = 56;
                this.Label2.Text = "Hotel Name";
                // 
                // Label1
                // 
                this.Label1.AutoSize = true;
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.Location = new System.Drawing.Point(18, 23);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(43, 14);
                this.Label1.TabIndex = 54;
                this.Label1.Text = "Hotel ID";
                // 
                // txtHotelID
                // 
                this.txtHotelID.BackColor = System.Drawing.SystemColors.Info;
                this.txtHotelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtHotelID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtHotelID.Location = new System.Drawing.Point(92, 19);
                this.txtHotelID.MaxLength = 50;
                this.txtHotelID.Multiline = true;
                this.txtHotelID.Name = "txtHotelID";
                this.txtHotelID.Size = new System.Drawing.Size(63, 20);
                this.txtHotelID.TabIndex = 1;
                // 
                // gbxCommands
                // 
                this.gbxCommands.Controls.Add(this.btnClose);
                this.gbxCommands.Controls.Add(this.btnSearch);
                this.gbxCommands.Controls.Add(this.btnDelete);
                this.gbxCommands.Controls.Add(this.btnSave);
                this.gbxCommands.Controls.Add(this.btnNew);
                this.gbxCommands.Controls.Add(this.btnCancel);
                this.gbxCommands.Location = new System.Drawing.Point(7, 306);
                this.gbxCommands.Name = "gbxCommands";
                this.gbxCommands.Size = new System.Drawing.Size(532, 47);
                this.gbxCommands.TabIndex = 127;
                this.gbxCommands.TabStop = false;
                // 
                // btnClose
                // 
                this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                this.btnClose.Location = new System.Drawing.Point(462, 10);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 188;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnDelete
                // 
                this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnDelete.Location = new System.Drawing.Point(6, 11);
                this.btnDelete.Name = "btnDelete";
                this.btnDelete.Size = new System.Drawing.Size(66, 31);
                this.btnDelete.TabIndex = 4;
                this.btnDelete.Text = "&Delete";
                this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                // 
                // btnSave
                // 
                this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnSave.Location = new System.Drawing.Point(324, 10);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(66, 31);
                this.btnSave.TabIndex = 8;
                this.btnSave.Text = "&Save";
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnNew
                // 
                this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnNew.Location = new System.Drawing.Point(255, 10);
                this.btnNew.Name = "btnNew";
                this.btnNew.Size = new System.Drawing.Size(66, 31);
                this.btnNew.TabIndex = 5;
                this.btnNew.Text = "&New";
                this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnCancel.Location = new System.Drawing.Point(393, 10);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(66, 31);
                this.btnCancel.TabIndex = 9;
                this.btnCancel.Text = "&Cancel";
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
                this.pnlSearch.Location = new System.Drawing.Point(-172, 113);
                this.pnlSearch.Name = "pnlSearch";
                this.pnlSearch.Size = new System.Drawing.Size(251, 149);
                this.pnlSearch.TabIndex = 192;
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
                // grdHotel
                // 
                this.grdHotel.AllowEditing = false;
                this.grdHotel.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:32;Caption:\"ID\";}\t1{Width:135;Caption:\"Name\";}\t";
                this.grdHotel.ExtendLastCol = true;
                this.grdHotel.Location = new System.Drawing.Point(7, 5);
                this.grdHotel.Name = "grdHotel";
                this.grdHotel.Rows.Count = 1;
                this.grdHotel.Rows.DefaultSize = 17;
                this.grdHotel.Size = new System.Drawing.Size(216, 301);
                this.grdHotel.StyleInfo = resources.GetString("grdHotel.StyleInfo");
                this.grdHotel.TabIndex = 193;
                // 
                // btnSearch
                // 
                this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnSearch.Location = new System.Drawing.Point(186, 10);
                this.btnSearch.Name = "btnSearch";
                this.btnSearch.Size = new System.Drawing.Size(66, 31);
                this.btnSearch.TabIndex = 186;
                this.btnSearch.Text = "Searc&h";
                this.btnSearch.Visible = false;
                this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
                // 
                // HotelUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(547, 361);
                this.Controls.Add(this.grdHotel);
                this.Controls.Add(this.pnlSearch);
                this.Controls.Add(this.grpMain);
                this.Controls.Add(this.gbxCommands);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "HotelUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "System Owner";
                this.Load += new System.EventHandler(this.HotelUI_Load);
                this.TextChanged += new System.EventHandler(this.HotelUI_TextChanged);
                this.grpMain.ResumeLayout(false);
                this.grpMain.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.nudNoOfRooms)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudNoOfFloors)).EndInit();
                this.gbxCommands.ResumeLayout(false);
                this.pnlSearch.ResumeLayout(false);
                this.pnlSearch.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdHotel)).EndInit();
                this.ResumeLayout(false);

			}
			
			#endregion

			#region " VARIABLES/CONSTANTS "

            private DatasetBinder oDataSetBinder ;
			private ControlListener oControlListener;

			private HotelClass oHotel;
			private HotelFacade oHotelFacade;
            private OperationMode mOperationMode;


			#endregion

			#region " CONSTRUCTORS "

			public HotelUI()
			{
                 oDataSetBinder = new DatasetBinder();
			     oControlListener = new ControlListener();
			     InitializeComponent();
				
			}

			#endregion

			#region " METHODS "

            /*********************************************************
             * Purpose: Ready for new transaction
             *********************************************************/
		
            private void setOperationMode(OperationMode a_OperationMode)
            {
                mOperationMode = a_OperationMode;
            }

             /*********************************************************
             * Purpose: Populate record to Grid Control
             *********************************************************/
			public void populateDataInGrid()
			{
				int i;
				
				this.grdHotel.Rows.Count = 1;
				foreach (DataRow dtRow in oHotel.Tables[0].Rows)
				{
                    i = this.grdHotel.Rows.Count;
					this.grdHotel.Rows.Count++;
					
					this.grdHotel.SetData(i, 0, dtRow["HotelID"].ToString());
					this.grdHotel.SetData(i, 1, dtRow["HotelName"].ToString());
				}
			}
			
	        /*********************************************************
            * Purpose: Initialize object instance
            *********************************************************/
			private void assignEntityValues()
			{
				oHotel.HotelID = this.txtHotelID.Text;
				oHotel.HotelName = this.txtHotelName.Text;
				oHotel.NoOfFloors = int.Parse(this.nudNoOfFloors.Text);
				oHotel.NoOfRooms = System.Convert.ToInt32(this.nudNoOfRooms.Value);
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
            * Purpose: Bind row to form controls
            *********************************************************/
			private void bindRowToControls()
			{
				try
				{
                    if (hasChanges())
                    {
                        if (MessageBox.Show("Save changes made to Hotel '" + this.txtHotelID.Text + "' ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            update();
                        }
                        else
                        {
                            this.BindingContext[oHotel.Tables[0]].CancelCurrentEdit();
                            this.Text = "Hotels";
                        }
                    }

					oControlListener.StopListen(this);
					
					this.BindingContext[oHotel.Tables["Hotel"]].Position = findItemInDataset(this.grdHotel.GetDataDisplay(this.grdHotel.Row, 0));

				}
				catch (Exception)
				{ }
				finally
				{
                    if (this.pnlSearch.Visible == false)
                    { 
					    oControlListener.Listen(this);
                    }
				}
			}

           /*********************************************************
           * Purpose: Find index of selected item in Local DataSet
           *********************************************************/
			private int findItemInDataset(string a_key)
			{
				int i = 0;
				foreach (DataRow drHotel in oHotel.Tables["Hotel"].Rows)
				{
                    if (drHotel["HotelID"].ToString() == a_key)
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
			
           /********************************************************
           * Purpose: Set the state of the button
           *********************************************************/
			private void setActionButtonStates(bool a_stat)
			{
                this.btnSearch.Enabled = a_stat;
                this.btnDelete.Enabled = a_stat;
                this.btnNew.Enabled = a_stat;
                this.btnSave.Enabled = !a_stat;
                this.btnCancel.Enabled = !a_stat;
			}
            /********************************************************
            * Purpose:Search the List of HOTEL starting
            * from the Selected Row down
            * if Not Found then start the Search again from the top
            *********************************************************/
            private void searchItem()
            {
                bool isFound = false;

                if (!this.txtSearch.Text.Equals(""))
                {
                    int i = 0;
                    for (i = this.grdHotel.Row + 1; i <= this.grdHotel.Rows.Count - 1; i++)
                    {
                        if (this.grdHotel.GetDataDisplay(i, 0).ToUpper().Contains( this.txtSearch.Text.ToUpper() )
                            ||
							this.grdHotel.GetDataDisplay(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.grdHotel.Row = i;
                            isFound = true;
                            return;
                        }
                    }

                    if (!isFound)
                    {
                        for (i = 1; i <= this.grdHotel.Rows.Count - 1; i++)
                        {
							if (this.grdHotel.GetDataDisplay(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                                ||
								this.grdHotel.GetDataDisplay(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                            {

                                this.grdHotel.Row = i;
                                isFound = true;
                                return;
                            }

                        }
                    }

                    MessageBox.Show("No matching record found.");
                }

            }

            private bool isRequiredEntriesFilled()
            {
                if (this.txtHotelID.Text.Length == 0) return false;
                return true;

            }

			#endregion	

            #region " EVENTS "

			private void HotelUI_Load(System.Object sender, System.EventArgs e)
			{
                if (load() == true)
                {
                    if (!oHotel.Equals(null))
                    {
                        Control frm = this;
                        object obj = (object)oHotel;
                        oDataSetBinder.BindControls(this, ref obj, new ArrayList());

                        populateDataInGrid();
						setActionButtonStates(true);
                        this.oControlListener.Listen(this);
                    }
                }




            }
			
			private void btnDelete_Click(System.Object sender, System.EventArgs e)
			{			
                this.oControlListener.StopListen(this);
                 if (MessageBox.Show("Are you certain you want to delete Hotel " + this.txtHotelName.Text + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oControlListener.StopListen(this);
                        if (delete() > 0)
                        {
                            this.grdHotel.RemoveItem(this.grdHotel.Row);
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted", "Database Update Error");
                        }

                        this.oControlListener.Listen(this);
                }
           }

			private void btnSearch_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = true;
				this.txtSearch.Text = "";
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
			}
			
			private void btnNew_Click(System.Object sender, System.EventArgs e)
			{
				
                setOperationMode(OperationMode.Add);
                
                oControlListener.StopListen(this);

                this.BindingContext[oHotel.Tables["Hotel"]].SuspendBinding();
                
                this.txtHotelID.Enabled = true;
                this.txtHotelID.Focus();
                
                setActionButtonStates(false);
             
			}
			
			private void btnSave_Click(System.Object sender, System.EventArgs e)
			{
                if (isRequiredEntriesFilled())
                {
                    assignEntityValues();
                    switch (mOperationMode)
                    {
                        case OperationMode.Add:
                            if (insert() > 0)
                            {
                                

                                this.grdHotel.Rows.Count++;

                                this.grdHotel.SetData(this.grdHotel.Rows.Count - 1, 0, oHotel.HotelID);
								this.grdHotel.SetData(this.grdHotel.Rows.Count - 1, 1, oHotel.HotelName);

                                // >> Resume Binding
                                this.BindingContext[oHotel.Tables[0]].ResumeBinding();
                                this.Text = "Hotel";
                                this.txtHotelID.Enabled = false;

                            
                                setActionButtonStates(true);
                                oControlListener.Listen(this);

                                MessageBox.Show("Item successfully added.", "Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            }
                            else
                            {
                                MessageBox.Show("No rows added", "Database Insert Error");
                            }

                            break;
                        case OperationMode.Edit:
                            if (update() > 0)
                            {
                                this.grdHotel.SetData(this.grdHotel.Row, 1, this.txtHotelName.Text);

                                // >> Resume Binding
                                this.BindingContext[oHotel.Tables[0]].ResumeBinding();
                                this.Text = "Hotel";
                                this.txtHotelID.Enabled = false;

                            
                                setActionButtonStates(true);

                                oControlListener.Listen(this);

                                MessageBox.Show("Item successfully updated.", "Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                    MessageBox.Show("Please Input Hotel ID!", "Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtHotelID.Focus();
                    return;
                }
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
			

                if (mOperationMode.Equals(OperationMode.Add))
                {
                    if (this.grdHotel.Rows.Count > 1)
                    {
                        this.grdHotel.Row = 1;
                    }
                }
                else
                {
                    this.BindingContext[oHotel.Tables[0]].CancelCurrentEdit();
                }
                this.BindingContext[oHotel.Tables[0]].ResumeBinding();

                
                this.Text = "Hotel";
                this.txtHotelID.Enabled = false;
                setActionButtonStates(true);

                oControlListener.Listen(this);
			}

            private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    searchItem();
                }
            }

            private void picClose_Click(System.Object sender, System.EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void grdHotel_Click(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void grdHotel_RowColChange(object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void HotelUI_TextChanged(object sender, System.EventArgs e)
            {
                if (this.Text.IndexOf('*') > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    setActionButtonStates(false);
                }
                else
                {
                    setActionButtonStates(true);
                }
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

            private void btnFind_Click(object sender, EventArgs e)
            {
                searchItem();
            }

            private void btnCloseSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }


			#endregion
            
            #region MaintenanceUIInterface Members
            /********************************************************
            * Purpose: Mark existing item as DELETED
            *********************************************************/
            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oHotelFacade = new HotelFacade();
                    assignEntityValues();
                    rowsAffected=oHotelFacade.deleteObject(oHotel);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
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
                    oHotelFacade = new HotelFacade();
                    rowsAdded = oHotelFacade.insertObject(oHotel);
                    return rowsAdded;
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
                    oHotel = new HotelClass();
                    oHotelFacade = new HotelFacade();
                    oHotel = (HotelClass)oHotelFacade.loadObject();
                    return true;
                }
                catch (Exception)
                {
                    return false;
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
                    oHotelFacade = new HotelFacade();
                    rowsAffected = oHotelFacade.updateObject(ref oHotel);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }

            }

            #endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
			{

			}

			private void dtpCheckInTime_ValueChanged(object sender, EventArgs e)
			{

			}

			private void label8_Click(object sender, EventArgs e)
			{

			}

			private void label7_Click(object sender, EventArgs e)
			{

			}


        }
	
}
