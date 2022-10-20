
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Jinisys.Hotel.Services.BusinessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.UIFramework;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using System.Reflection;
using System.Collections.Generic;

namespace Jinisys.Hotel.Services.Presentation
{

	public class HousekeepingUI : MiscellaneousUI
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
		internal System.Windows.Forms.GroupBox grb1;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.GroupBox grb2;
		public System.Windows.Forms.Label Label6;
		internal Button btnClose;
		private C1.Win.C1FlexGrid.C1FlexGrid grdRooms;
		private DateTimePicker dtpTime;
		private ComboBox cboHousekeeperId;
		private ComboBox cboLastName;
		private ComboBox cboFirstName;
		private PictureBox pct;
		private Label lblTotalDirty;
		private Label label1;
		internal Label label43;
		internal Label label24;
		public System.Windows.Forms.TextBox txtJobNo;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HousekeepingUI));
			this.grb1 = new System.Windows.Forms.GroupBox();
			this.lblTotalDirty = new System.Windows.Forms.Label();
			this.cboLastName = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.pct = new System.Windows.Forms.PictureBox();
			this.cboFirstName = new System.Windows.Forms.ComboBox();
			this.cboHousekeeperId = new System.Windows.Forms.ComboBox();
			this.txtJobNo = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.dtpTime = new System.Windows.Forms.DateTimePicker();
			this.grb2 = new System.Windows.Forms.GroupBox();
			this.grdRooms = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.grb1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pct)).BeginInit();
			this.grb2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdRooms)).BeginInit();
			this.SuspendLayout();
			// 
			// grb1
			// 
			this.grb1.Controls.Add(this.lblTotalDirty);
			this.grb1.Controls.Add(this.cboLastName);
			this.grb1.Controls.Add(this.btnClose);
			this.grb1.Controls.Add(this.btnSave);
			this.grb1.Controls.Add(this.pct);
			this.grb1.Controls.Add(this.cboFirstName);
			this.grb1.Controls.Add(this.cboHousekeeperId);
			this.grb1.Controls.Add(this.txtJobNo);
			this.grb1.Controls.Add(this.Label6);
			this.grb1.Controls.Add(this.Label9);
			this.grb1.Controls.Add(this.Label8);
			this.grb1.Controls.Add(this.Label7);
			this.grb1.Location = new System.Drawing.Point(27, 109);
			this.grb1.Name = "grb1";
			this.grb1.Size = new System.Drawing.Size(802, 111);
			this.grb1.TabIndex = 0;
			this.grb1.TabStop = false;
			// 
			// lblTotalDirty
			// 
			this.lblTotalDirty.AutoSize = true;
			this.lblTotalDirty.Location = new System.Drawing.Point(674, 80);
			this.lblTotalDirty.Name = "lblTotalDirty";
			this.lblTotalDirty.Size = new System.Drawing.Size(65, 14);
			this.lblTotalDirty.TabIndex = 194;
			this.lblTotalDirty.Text = "Dirty Rooms";
			// 
			// cboLastName
			// 
			this.cboLastName.BackColor = System.Drawing.SystemColors.Info;
			this.cboLastName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLastName.FormattingEnabled = true;
			this.cboLastName.Location = new System.Drawing.Point(113, 77);
			this.cboLastName.Name = "cboLastName";
			this.cboLastName.Size = new System.Drawing.Size(233, 22);
			this.cboLastName.TabIndex = 73;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(716, 23);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 11;
			this.btnClose.Text = "C&lose";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(643, 23);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 31);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pct
			// 
			this.pct.Image = global::Jinisys.Hotel.Services.Properties.Resources.broom1;
			this.pct.Location = new System.Drawing.Point(656, 79);
			this.pct.Name = "pct";
			this.pct.Size = new System.Drawing.Size(15, 18);
			this.pct.TabIndex = 193;
			this.pct.TabStop = false;
			// 
			// cboFirstName
			// 
			this.cboFirstName.BackColor = System.Drawing.SystemColors.Info;
			this.cboFirstName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFirstName.FormattingEnabled = true;
			this.cboFirstName.Location = new System.Drawing.Point(113, 50);
			this.cboFirstName.Name = "cboFirstName";
			this.cboFirstName.Size = new System.Drawing.Size(233, 22);
			this.cboFirstName.TabIndex = 72;
			// 
			// cboHousekeeperId
			// 
			this.cboHousekeeperId.BackColor = System.Drawing.SystemColors.Info;
			this.cboHousekeeperId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboHousekeeperId.FormattingEnabled = true;
			this.cboHousekeeperId.Location = new System.Drawing.Point(113, 23);
			this.cboHousekeeperId.Name = "cboHousekeeperId";
			this.cboHousekeeperId.Size = new System.Drawing.Size(106, 22);
			this.cboHousekeeperId.TabIndex = 71;
			// 
			// txtJobNo
			// 
			this.txtJobNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtJobNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtJobNo.Enabled = false;
			this.txtJobNo.Location = new System.Drawing.Point(513, 26);
			this.txtJobNo.MaxLength = 11;
			this.txtJobNo.Name = "txtJobNo";
			this.txtJobNo.ReadOnly = true;
			this.txtJobNo.Size = new System.Drawing.Size(106, 20);
			this.txtJobNo.TabIndex = 5;
			this.txtJobNo.Text = "AUTO";
			this.txtJobNo.Visible = false;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(427, 29);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(43, 14);
			this.Label6.TabIndex = 70;
			this.Label6.Text = "Job No.";
			this.Label6.Visible = false;
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(27, 27);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(71, 14);
			this.Label9.TabIndex = 45;
			this.Label9.Text = "Housekeeper";
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(27, 54);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(58, 14);
			this.Label8.TabIndex = 43;
			this.Label8.Text = "First Name";
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(27, 81);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(57, 14);
			this.Label7.TabIndex = 44;
			this.Label7.Text = "Last name";
			// 
			// dtpTime
			// 
			this.dtpTime.CustomFormat = "hh:mm tt";
			this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTime.Location = new System.Drawing.Point(13, 392);
			this.dtpTime.Name = "dtpTime";
			this.dtpTime.ShowUpDown = true;
			this.dtpTime.Size = new System.Drawing.Size(49, 20);
			this.dtpTime.TabIndex = 192;
			// 
			// grb2
			// 
			this.grb2.Controls.Add(this.grdRooms);
			this.grb2.Controls.Add(this.dtpTime);
			this.grb2.Location = new System.Drawing.Point(27, 220);
			this.grb2.Name = "grb2";
			this.grb2.Size = new System.Drawing.Size(802, 442);
			this.grb2.TabIndex = 6;
			this.grb2.TabStop = false;
			// 
			// grdRooms
			// 
			this.grdRooms.ColumnInfo = resources.GetString("grdRooms.ColumnInfo");
			this.grdRooms.ExtendLastCol = true;
			this.grdRooms.Location = new System.Drawing.Point(12, 18);
			this.grdRooms.Name = "grdRooms";
			this.grdRooms.Rows.DefaultSize = 17;
			this.grdRooms.Size = new System.Drawing.Size(780, 411);
			this.grdRooms.StyleInfo = resources.GetString("grdRooms.StyleInfo");
			this.grdRooms.TabIndex = 7;
			this.grdRooms.RowColChange += new System.EventHandler(this.grdRooms_RowColChange);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(27, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 22);
			this.label1.TabIndex = 9;
			this.label1.Text = "Housekeeping Jobs";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Arial", 8.25F);
			this.label24.Location = new System.Drawing.Point(63, 57);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(288, 33);
			this.label24.TabIndex = 140;
			this.label24.Text = "Housekeeping Jobs lets you keep track of your housekeepers performance.";
			// 
			// label43
			// 
			this.label43.Font = new System.Drawing.Font("Arial", 8.25F);
			this.label43.Image = ((System.Drawing.Image)(resources.GetObject("label43.Image")));
			this.label43.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.label43.Location = new System.Drawing.Point(27, 57);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(29, 30);
			this.label43.TabIndex = 141;
			// 
			// HousekeepingUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(884, 707);
			this.Controls.Add(this.label43);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grb1);
			this.Controls.Add(this.grb2);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "HousekeepingUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Housekeeping Job";
			this.Activated += new System.EventHandler(this.HousekeepingUI_Activated);
			this.Load += new System.EventHandler(this.HousekeepingJobUI_Load);
			this.grb1.ResumeLayout(false);
			this.grb1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pct)).EndInit();
			this.grb2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdRooms)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		#region Variables and Constants

		private RoomFacade oRoomFacade;
		private HouseKeepingJobFacade oHousekeepingJobFacade;
		private HousekeepingJob oHousekeepingJob;
		private HousekeepingJobs oHousekeepingJobs = new HousekeepingJobs();
		private Sequence oSequence;

		#endregion

		#region Constructor

		public HousekeepingUI()
		{
			oRoomFacade = new RoomFacade();
			oHousekeepingJobFacade = new HouseKeepingJobFacade();
			oHousekeepingJob = new HousekeepingJob();
			oSequence = new Sequence();
			InitializeComponent();
		}

		#endregion

		#region Methods

		private void loadData()
		{
			oRoomFacade = new RoomFacade();

			IList<Room> oRoomList = new List<Room>();
			oRoomList = oRoomFacade.getRoomList("");

			this.grdRooms.Rows.Count = oRoomList.Count + 1;
			int i = 1;
			int _dirtyRooms = 0;
			foreach (Room _room in oRoomList)
			{
				this.grdRooms.SetData(i, 0, _room.RoomId);

				if (_room.CleaningStatus == "DIRTY")
				{
					this.grdRooms.SetCellImage(i, 0, this.pct.Image);
					_dirtyRooms++;
				}

				i++;
			}

			//oSequence = new Sequence();
			//this.txtJobNo.Text = oSequence.getSequenceId("H-", 12, "seq_housekeepingjob");


			// load housekeepers
			HouseKeeperFacade _oHousekeeperFacade = new HouseKeeperFacade();
			HouseKeeper _housekeepers = _oHousekeeperFacade.getHouseKeeper();
			DataTable _dtTemp = _housekeepers.Tables[0];

			this.cboHousekeeperId.DataSource = _dtTemp;
			this.cboHousekeeperId.DisplayMember = "HousekeeperId";

			this.cboLastName.DataSource = _dtTemp;
			this.cboLastName.DisplayMember = "LastName";

			this.cboFirstName.DataSource = _dtTemp;
			this.cboFirstName.DisplayMember = "FirstName";

			this.lblTotalDirty.Text = "Dirty Rooms [ " + _dirtyRooms.ToString() + " ]";
		}


		private bool insertHousekeepingJobs(HousekeepingJobs poHousekeepingJobs)
		{
			try
			{
				bool flag = false;
				oHousekeepingJobFacade = new HouseKeepingJobFacade();
				flag = oHousekeepingJobFacade.appendHousekeepingJobs(poHousekeepingJobs);
				return flag;
			}
			catch (Exception)
			{
				return false;
			}
		}

		#endregion

		#region Data Access Methods
		//public bool load()
		//{
		//    try
		//    {


		//        return true;
		//    }
		//    catch (Exception) { return false; }
		//}

		//public int insert()
		//{
		//    try
		//    {
		//        int rowsAffected = 0;

		//        return rowsAffected;
		//    }
		//    catch (Exception) { return 0; }
		//}

		//public int update()
		//{
		//    try
		//    {
		//        int rowsAffected = 0;

		//        return rowsAffected;
		//    }
		//    catch (Exception)
		//    {
		//        return 0;
		//    }
		//}

		//public int delete()
		//{
		//    try
		//    {
		//        assignEntityValues();
		//        int rowsAffected = 0;

		//        return rowsAffected;
		//    }
		//    catch (Exception)
		//    {
		//        return 0;
		//    }
		//}

		#endregion

		#region Events



		private void HousekeepingJobUI_Load(object sender, System.EventArgs e)
		{
			//this.dtpTime.Value = DateTime.Parse(GlobalVariables.gAuditDate + " 7:00:00");
			loadData();
		}

		private void btnSave_Click(System.Object sender, System.EventArgs e)
		{
            HousekeepingJobs _oHouseKeepingJobList = new HousekeepingJobs();
			for (int i = 1; i < this.grdRooms.Rows.Count; i++)
			{
				HousekeepingJob _newHousekeepingJob = new HousekeepingJob();
                DateTime _startTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + this.grdRooms.GetDataDisplay(i, 2));
                DateTime _endTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + this.grdRooms.GetDataDisplay(i, 3));
                if (_endTime < _startTime)
                {
                    MessageBox.Show("Incorrect cleaning data.\n End time should not be greater than Start time. \n Please check inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

				try
				{

					_newHousekeepingJob.HousekeepingDate = DateTime.Parse(GlobalVariables.gAuditDate);
					_newHousekeepingJob.HousekeeperId = this.cboHousekeeperId.Text;
					_newHousekeepingJob.HousekeepingType = this.grdRooms.GetDataDisplay(i, 1);
					_newHousekeepingJob.RoomId = this.grdRooms.GetDataDisplay(i, 0);
					_newHousekeepingJob.StartTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + this.grdRooms.GetDataDisplay(i, 2));
					_newHousekeepingJob.EndTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + this.grdRooms.GetDataDisplay(i, 3));
					_newHousekeepingJob.Remarks = this.grdRooms.GetDataDisplay(i, 4);
					_newHousekeepingJob.IsFinished = 0;
					_newHousekeepingJob.VerifiedBy = "";
					_newHousekeepingJob.TimeVerified = DateTime.Now;
					_newHousekeepingJob.HotelId = GlobalVariables.gHotelId;


					if (_newHousekeepingJob.HousekeepingType == "" ||
						this.grdRooms.GetDataDisplay(i, 2) == "" ||
						this.grdRooms.GetDataDisplay(i, 3) == "" )
					{
						// don't add to list
					}
					else
					{

						_oHouseKeepingJobList.Add(_newHousekeepingJob);
					}
				}
				catch { }


			}


			if (insertHousekeepingJobs(_oHouseKeepingJobList) == true)
			{
				MessageBox.Show(" Transaction successful. \r\n Rooms are now clean", "Housekeeping", MessageBoxButtons.OK, MessageBoxIcon.Information);
				updateCurrentDayRoomStatus();
				this.Close();
			}

		}

		private void updateCurrentDayRoomStatus()
		{
			try
			{
				Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
				MethodInfo[] objMethods = objectType.GetMethods();
				MethodInfo method;
				foreach (MethodInfo tempLoopVar_method in objMethods)
				{
					method = tempLoopVar_method;
					if (method.Name.ToUpper() == "plotCurrentDayRoomStatus".ToUpper())
					{
						method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		#endregion


		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void grdRooms_RowColChange(object sender, EventArgs e)
		{
			if (grdRooms.Col > 0)
			{
				this.grdRooms.StartEditing(this.grdRooms.Row, this.grdRooms.Col);
			}
			else
			{
				this.grdRooms.AllowEditing = false;
			}
		}

		private void HousekeepingUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

	}
}
