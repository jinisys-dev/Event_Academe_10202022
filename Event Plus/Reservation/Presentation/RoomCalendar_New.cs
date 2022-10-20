using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Collections;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Services.BusinessLayer;
using System.Reflection;

namespace Jinisys.Hotel.Reservation.Presentation
{
	public partial class RoomCalendar_New : Form
	{

		#region "CONSTRUCTOR"

		private FolioFacade oFolioFacade;
        private int lFunctionTabIndex = 1;
		//>> Default Constructor
		//   lOperationMode = BLOCKING
		public RoomCalendar_New()
		{
			InitializeComponent();

			initializeGridViewRowStyles();

			oFolioFacade = new FolioFacade();
			oGuestFolio = oFolioFacade.getGuestForToolTipCalendar();
            oCompanyFolio = (DataTable)oFolioFacade.GetType().GetMethod("getCompanyFoliosForToolTip").Invoke(oFolioFacade, null);

			lRoomFacade = new RoomFacade();
			lRoomTypeFacade = new RoomTypeFacade();

			this.WindowState = FormWindowState.Maximized;

			this.dtpStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			lCalendarDateTime = this.dtpStartDate.Value.Date;

			Room _oRooms = (Room)lRoomFacade.loadObject();
			Room _oFunction = (Room)lRoomFacade.loadObject();

			if (_oRooms == null || _oFunction == null)
				return;

			dtvRooms = _oRooms.Tables[0].DefaultView;
			dtvFunction = _oFunction.Tables[0].DefaultView;

			getAllRoomTypes();
			this.cboRoomType.SelectedIndex = 0;

			setupRooms();
			setupFunction();

			setUpRoomCalendarDates();
			plotRoomEventsToGrid();

			setUpFunctionCalendarDates();
			plotFunctionEventsToGrid();

            if (ConfigVariables.gIsEMMOnly == "true")
            {
                this.btnMark.Hide();
                this.btnRemove.Hide();
            }
		}

		public RoomCalendar_New(string pOperationMode)
		{
			InitializeComponent();

			initializeGridViewRowStyles();

			oFolioFacade = new FolioFacade();
			oGuestFolio = oFolioFacade.getGuestForToolTipCalendar();
            oCompanyFolio = (DataTable)oFolioFacade.GetType().GetMethod("getCompanyFoliosForToolTip").Invoke(oFolioFacade, null);

			lRoomFacade = new RoomFacade();
			lRoomTypeFacade = new RoomTypeFacade();

			lOperationMode = pOperationMode;

			this.dtpStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			lCalendarDateTime = this.dtpStartDate.Value.Date;

			Room _oRooms = (Room)lRoomFacade.loadObject();
			Room _oFunction = (Room)lRoomFacade.loadObject();

			if (_oRooms == null || _oFunction == null)
				return;

			dtvRooms = _oRooms.Tables[0].DefaultView;
			dtvFunction = _oFunction.Tables[0].DefaultView;

			getAllRoomTypes();
			this.cboRoomType.SelectedIndex = 0;

			setupRooms();
			setupFunction();

			setUpRoomCalendarDates();
			plotRoomEventsToGrid();

			setUpFunctionCalendarDates();
			plotFunctionEventsToGrid();
		}

		public RoomCalendar_New(string pOperationMode, DateTime startDate, int noOfWeeks, string roomType, object poCurrentFolioSchedule)
		{
			InitializeComponent();

			initializeGridViewRowStyles();

			oFolioFacade = new FolioFacade();
			oGuestFolio = oFolioFacade.getGuestForToolTipCalendar();
            oCompanyFolio = (DataTable)oFolioFacade.GetType().GetMethod("getCompanyFoliosForToolTip").Invoke(oFolioFacade, null);

			lRoomFacade = new RoomFacade();
			lRoomTypeFacade = new RoomTypeFacade();

			lOperationMode = pOperationMode;


			this.dtpStartDate.Value = startDate;
			lCalendarDateTime = this.dtpStartDate.Value.Date;
			this.nudWeeks.Value = noOfWeeks;
			
			Room _oRooms = (Room)lRoomFacade.loadObject();
			Room _oFunction = (Room)lRoomFacade.loadObject();

			if (_oRooms == null || _oFunction == null)
				return;

			dtvRooms = _oRooms.Tables[0].DefaultView;
			dtvFunction = _oFunction.Tables[0].DefaultView;

			getAllRoomTypes();
			this.cboRoomType.Text = roomType;
			//this.cboRoomType.SelectedIndex = 0;

			setupRooms();
			setupFunction();

			setUpRoomCalendarDates();
			plotRoomEventsToGrid();

			setUpFunctionCalendarDates();
			plotFunctionEventsToGrid();

			if (poCurrentFolioSchedule != null && lOperationMode != "WAIT LIST")
			{
				loScheduleCollection = (IList<Schedule>)poCurrentFolioSchedule;

				//should block current schedule here
				plotCurrentFolioScheduleToGrid(loScheduleCollection);
			}

            if (pOperationMode == "ENGINEERING JOB")
            {
                this.btnRemove.Hide();
            }

            if (pOperationMode == "BLOCKING")
            {
                this.btnRemove.Hide();
                this.btnMark.Hide();
            }

		}

		private IList<Schedule> loScheduleCollection = new List<Schedule>();
		Label lbl = null;
		public IList<Schedule> launchCalendarWizard(Label pLabel)
		{
			
			lbl = pLabel;

			this.WindowState = FormWindowState.Normal;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			setButtonState(true, true, true, false, false);

			base.ShowDialog();

			if (hasClickDoneButton)
			{
				return loScheduleCollection;
			}
			else
			{
				return null;
			}

		}


	
		// for GROUP BLOCKING
		private Folio lGroupFolio;
		private EventRoomRequirementFacade loRoomRequirementFacade;
		private GenericList<EventRoomRequirements> loEventRoomRequirements;

		public RoomCalendar_New(string pOperationMode, 
								DateTime pStartDate,
                                DateTime pEndDate,
								int pNoOfWeeks,
								string pRoomType,
								string pGroupFolioID)
		{
			InitializeComponent();

			initializeGridViewRowStyles();

			oFolioFacade = new FolioFacade();
			oGuestFolio = oFolioFacade.getGuestForToolTipCalendar();
            oCompanyFolio = (DataTable)oFolioFacade.GetType().GetMethod("getCompanyFoliosForToolTip").Invoke(oFolioFacade, null);

			lRoomFacade = new RoomFacade();
			lRoomTypeFacade = new RoomTypeFacade();

			lOperationMode = pOperationMode;

			lGroupFolio = oFolioFacade.GetFolio(pGroupFolioID);

			//this.dtpStartDate.Value = pStartDate;
			try 
			{
				this.dtpStartDate.Value = pStartDate;
                this.dtpEndDate.Value = pEndDate;
            }
			catch
			{
				this.dtpStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
                this.dtpEndDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			}
			
			lCalendarDateTime = this.dtpStartDate.Value.Date;
			this.nudWeeks.Value = pNoOfWeeks;

			Room _oRooms = (Room)lRoomFacade.loadObject();
			Room _oFunction = (Room)lRoomFacade.loadObject();

			if (_oRooms == null || _oFunction == null)
				return;

			dtvRooms = _oRooms.Tables[0].DefaultView;
			dtvFunction = _oFunction.Tables[0].DefaultView;

			getAllRoomTypes();
			this.cboRoomType.Text = pRoomType;

			setupRooms();
			setupFunction();

			setUpRoomCalendarDates();
			plotRoomEventsToGrid();

			setUpFunctionCalendarDates();
			plotFunctionEventsToGrid();

			

			loRoomRequirementFacade = new EventRoomRequirementFacade();
			loEventRoomRequirements = new GenericList<EventRoomRequirements>();
			loEventRoomRequirements = loRoomRequirementFacade.getRoomRequirements(pGroupFolioID);


			//disallow double-click on Reservation
			this.grdRooms.DoubleClick -= new System.EventHandler(this.grdRooms_DoubleClick);
			
		}


		public void launchCalendarForGroupBlocking(Label pLabel)
		{

			lbl = pLabel;

			this.WindowState = FormWindowState.Normal;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			setButtonState(true, true, true, false, false);

			base.ShowDialog();

			//if (hasClickDoneButton)
			//{
			//    return loScheduleCollection;
			//}
			//else
			//{
			//    return null;
			//}

		}

		#endregion

		#region "VARIABLES"

		private CellStyle csNormalStyle = null;
		private CellStyle csSundayStyle = null;
		private CellStyle csReservationStyle = null;
		private CellStyle csInHouseStyle = null;
		private CellStyle csBlockedStyle = null;
		private CellStyle csEngineeringStyle = null;
		private CellStyle csFixedStyle = null;
		private CellStyle csRowSelectedStyel = null;
		private CellStyle csShareStyle = null;
        private CellStyle csDirtyStyle = null;

		private RoomFacade lRoomFacade;
		private DataView dtvRooms;
		private DataView dtvFunction;
		private RoomTypeFacade lRoomTypeFacade;
		private ArrayList loRoomEventCollectionForPlotting;
		private ArrayList loFunctionEventCollectionForPlotting;
		private RoomBlockFacade oRoomBlockFacade;
		private RoomBlockCollection oRoomBlockCollection;
		private string lOperationMode = "BLOCKING";
		private bool isFormLoaded = false;

		private DataTable oGuestFolio = null;
        private DataTable oCompanyFolio = null;
		private bool viewFolioORBlockingInfo = false;

		private DateTime lCalendarDateTime;
		#endregion

		#region "HIGLIGHTING"

		public void deSelectRange()
		{
            //deselect all rows
            for (int i = 3; i < this.grdRooms.Rows.Count; i++)
            {
                this.grdRooms.SetCellStyle(i, 1, csFixedStyle);
            }
            //deselect all columns
            for (int i = 2; i < this.grdRooms.Cols.Count; i++)
            {
                this.grdRooms.SetCellStyle(2, i, csFixedStyle);
            }
		}

		public void deSelectRangeFunction()
		{
			//deselect all rows
			
			for (int i = 3; i < this.grdFunctions.Rows.Count; i++)
			{
				this.grdFunctions.SetCellStyle(i, 1, csFixedStyle);
			}
			//deselect all columns
			for (int i = 2; i < this.grdFunctions.Cols.Count; i++)
			{
				this.grdFunctions.SetCellStyle(2, i, csFixedStyle);
			}

		}

		private void grdRooms_AfterSelChange(object sender, RangeEventArgs e)
		{
			deSelectRange();

			CellRange _range = this.grdRooms.Selection;

			int _startRow = _range.r1;
			int _endRow = _range.r2;

			int _startCol = _range.c1;
			int _endCol = _range.c2;

			if (_startCol % 2 == 1)
				_startCol--;

			if (_endCol % 2 == 0)
				_endCol++;

			if (_startRow < 0 || _startCol < 0)
				return;

            for (int i = _startRow; i <= _endRow; i++)
            {
                this.grdRooms.SetCellStyle(i, 1, csRowSelectedStyel);
            }

            for (int i = _startCol; i <= _endCol; i++)
            {
                this.grdRooms.SetCellStyle(2, i, csRowSelectedStyel);
            }

		}

		


		#endregion

		#region "SEARCH ROOM NO"

		private void txtSearchRoom_Enter(object sender, EventArgs e)
		{
			this.txtSearchRoom.ForeColor = Color.Black;
			this.txtSearchRoom.BorderStyle = BorderStyle.FixedSingle;
			if (this.txtSearchRoom.Text == "Search Room No.")
			{
				this.txtSearchRoom.Text = "";
			}
		}

		private void txtSearchRoom_Leave(object sender, EventArgs e)
		{
			this.txtSearchRoom.ForeColor = Color.Gray;
			this.txtSearchRoom.BorderStyle = BorderStyle.None;
			if (txtSearchRoom.Text.Trim().Length <= 0)
			{
				this.txtSearchRoom.Text = "Search Room No.";
				this.btnSearch.Enabled = false;
			}
		}

		private void txtSearchRoom_TextChanged(object sender, EventArgs e)
		{
			if (txtSearchRoom.Text.Trim().Length <= 0)
			{
				this.btnSearch.Enabled = false;
			}
			else
			{
				this.btnSearch.Enabled = true;
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string _roomToSearch = this.txtSearchRoom.Text;

            for (int i = 3; i < this.grdRooms.Rows.Count; i++)
            {
                string _roomNo = this.grdRooms.GetDataDisplay(i, 1);

                if (_roomNo == _roomToSearch)
                {
                    this.grdRooms.Select(i, 1, true);
                    this.tcAllRooms.SelectedIndex = 0;
                    return;
                }
            }

			for (int i = 4; i < this.grdFunctions.Rows.Count; i++)
			{
				string _roomNo = this.grdFunctions.GetDataDisplay(i, 1);

				if (_roomNo == _roomToSearch)
				{ 
					this.grdFunctions.Select(i, 1, true);
                    this.tcAllRooms.SelectedIndex = lFunctionTabIndex;
                    this.grdFunctions.Row = i;
					return;
				}
			}

		}

		private void txtSearchRoom_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				btnSearch_Click(sender, new EventArgs());
			}
		}

		#endregion

		#region "ROOMS"

		private void setupRooms()
		{

			this.grdRooms.Rows.Count = 3;

			//>> Rows MONTH & YEAR, DAYNAME, DATE
			this.grdRooms.Rows.Fixed = 3;

			//>> Columns ROOMTYPES, ROOMS
			this.grdRooms.Cols.Fixed = 2;

			this.grdRooms.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;

			//>> set merge First Row (MONTH,YEAR and DAYNAME)
			this.grdRooms.Rows[0].AllowMerging = true;
			this.grdRooms.Rows[1].AllowMerging = true;
			this.grdRooms.Rows[2].AllowMerging = true;

			this.grdRooms.Cols[0].AllowMerging = true;
			this.grdRooms.Cols[1].AllowMerging = true;

			this.grdRooms.Cols.DefaultSize = 20;
			this.grdRooms.Cols[0].Width = 70;
			this.grdRooms.Cols[1].Width = 50;

			this.grdRooms.SetData(0, 0, "Type");
			this.grdRooms.SetData(1, 0, "Type");
			this.grdRooms.SetData(2, 0, "Type");
			this.grdRooms.SetData(0, 1, "Rooms");
			this.grdRooms.SetData(1, 1, "Rooms");
			this.grdRooms.SetData(2, 1, "Rooms");

			if (dtvRooms == null)
				return;

			dtvRooms.RowStateFilter = DataViewRowState.OriginalRows;
			
			string _roomType = this.cboRoomType.Text;
			string _rowFilterCondition = "";
			switch (_roomType)
			{ 
				case "":
				case "ALL":
					_rowFilterCondition = "roomSuperType <> 'FUNCTION'";
					break;
				case "FUNCTION":
					//_rowFilterCondition = "roomTypeCode <> 'FUNCTION'";
					break;
				default:
                    _rowFilterCondition = "roomSuperType <> 'FUNCTION' AND roomTypeCode = '" + _roomType + "'";
					break;
			}

			dtvRooms.RowFilter = _rowFilterCondition;

			dtvRooms.Sort = "roomTypeCode";
			this.grdRooms.Rows.Count = dtvRooms.Count + 3;
			int i = 3;
			foreach (DataRowView _dtrView in dtvRooms)
			{
				this.grdRooms.SetData(i, 0, _dtrView["roomTypeCode"].ToString());
				this.grdRooms.SetData(i, 1, _dtrView["roomId"].ToString());

                if (_dtrView["cleaningstatus"].ToString() == "DIRTY")
                    this.grdRooms.SetCellStyle(i, 1, csDirtyStyle);
                //else
                //    this.grdRooms.CellBackColor = SystemColors.Control;

				this.grdRooms.Rows[i].AllowMerging = true;
				i++;
			}

		}

        //jlo 8-10-10
        //added to determine room is function
        /// <summary>
        /// This will determine if a room type is a function room or not
        /// </summary>
        /// <param name="pRoomType">string : Room type to be checked</param>
        /// <returns>boolean</returns>
        private bool isFunctionRoom(string pRoomType)
        {
            foreach (RoomType _rType in ilRoomTypeList)
            {
                if (pRoomType == _rType.RoomTypeCode && _rType.RoomSuperType == "FUNCTION")
                {
                    return true;
                }
            }
            return false;

        }

		//>> overload method for Room Setup per Room Type
		private void setupRooms(string pRoomType)
		{

			this.grdRooms.Rows.Count = 3;
			//this.grdRooms.Cols.Count = 2;

			//>> Rows MONTH & YEAR, DAYNAME, DATE
			this.grdRooms.Rows.Fixed = 3;

			//>> Columns ROOMTYPES, ROOMS
			this.grdRooms.Cols.Fixed = 2;

			this.grdRooms.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;

			//>> set merge First Row (MONTH,YEAR and DAYNAME)
			this.grdRooms.Rows[0].AllowMerging = true;
			this.grdRooms.Rows[1].AllowMerging = true;
			this.grdRooms.Rows[2].AllowMerging = true;

			this.grdRooms.Cols[0].AllowMerging = true;
			this.grdRooms.Cols[1].AllowMerging = true;

			this.grdRooms.Cols.DefaultSize = 20;
			this.grdRooms.Cols[0].Width = 70;
			this.grdRooms.Cols[1].Width = 40;

			this.grdRooms.SetData(0, 0, "Type");
			this.grdRooms.SetData(1, 0, "Type");
			this.grdRooms.SetData(2, 0, "Type");
			this.grdRooms.SetData(0, 1, "Rooms");
			this.grdRooms.SetData(1, 1, "Rooms");
			this.grdRooms.SetData(2, 1, "Rooms");

			if (dtvRooms == null)
				return;

			dtvRooms.RowStateFilter = DataViewRowState.OriginalRows;
            dtvRooms.RowFilter = "roomSuperType <> 'FUNCTION' "
							   + "AND roomTypeCode = '" + pRoomType + "'";

			dtvRooms.Sort = "roomId";
			this.grdRooms.Rows.Count = dtvRooms.Count + 3;
			int i = 3;
			foreach (DataRowView _dtrView in dtvRooms)
			{
				this.grdRooms.SetData(i, 0, _dtrView["roomTypeCode"].ToString());
				this.grdRooms.SetData(i, 1, _dtrView["roomId"].ToString());

				this.grdRooms.Rows[i].AllowMerging = true;
				i++;
			}
		}

		private void setUpRoomCalendarDates()
		{
			// multiply by 2 since we cater 2RoomEvent per Day
			int _numberOfCols = (int)(this.nudWeeks.Value * 7) * 2;

			this.grdRooms.Cols.Count = _numberOfCols + 2;
			//this.grdFunctions.Cols.Count = _numberOfCols + 2;

			DateTime _startDate = this.dtpStartDate.Value.AddDays(-1);
			int _day = 0;

			for (_day = 2; _day <= _numberOfCols; _day = _day + 2)
			{
				if (_day % 2 == 0)
				{

					DateTime forLoopDate = _startDate.AddDays(_day / 2);

					string monthAndYear = forLoopDate.ToString("MMMM , yyyy");
					//>> ROOMS
					this.grdRooms.SetData(0, _day, monthAndYear);
					this.grdRooms.SetData(0, _day + 1, monthAndYear);

					//>> FUNCTIONS
					//this.grdFunctions.SetData(0, _day, monthAndYear);
					//this.grdFunctions.SetData(0, _day + 1, monthAndYear);


					// for Day prefix(S M T W T F S)
					if (forLoopDate.DayOfWeek == DayOfWeek.Sunday)
					{
						string _dayNameStart = forLoopDate.DayOfWeek.ToString().Substring(0, 2);

						//>> ROOMS
						this.grdRooms.SetData(1, _day, _dayNameStart);
						this.grdRooms.SetData(1, _day + 1, _dayNameStart);

						this.grdRooms.SetCellStyle(1, _day, csSundayStyle);

						
					}
					else
					{
						string _dayNameStart = forLoopDate.DayOfWeek.ToString().Substring(0, 1);

						//>> ROOMS
						this.grdRooms.SetData(1, _day, _dayNameStart);
						this.grdRooms.SetData(1, _day + 1, _dayNameStart);

					}

					//for DATE [ROOMS]
					this.grdRooms.SetData(2, _day, forLoopDate.Day.ToString());
					this.grdRooms.SetData(2, _day + 1, forLoopDate.Day.ToString());


					//for DATE [FUNCTIONS]
					//this.grdFunctions.SetData(2, _day, forLoopDate.Day.ToString());
					//this.grdFunctions.SetData(2, _day + 1, forLoopDate.Day.ToString());

				}
			}
		}
		private void initializeRoomEventsCollection()
		{
            DateTime _startDate = this.dtpStartDate.Value.Date.AddDays(-1);
			double _weekValue = (double)nudWeeks.Value;

			string _strStartDate = _startDate.ToString("yyyy-MM-dd");
			double _noOfDays = _weekValue * 7;
			string _strEndDate = _startDate.AddDays(_noOfDays).ToString("yyyy-MM-dd");

			CalendarFacade oCalendarFacade = new CalendarFacade();
			DataTable _dtRoomEvents = oCalendarFacade.getRoomEventsForPlotting(_strStartDate, _strEndDate);

			loRoomEventCollectionForPlotting = new ArrayList();
			ArrayList oTempRoomEventCollectionForPlotting = new ArrayList();

			DataView _dtTempView = _dtRoomEvents.DefaultView;
			_dtTempView.RowStateFilter = DataViewRowState.OriginalRows;
            _dtTempView.RowFilter = "roomSuperType <> 'FUNCTION'";

			//>> load All RoomEvents to Temp Collection & Collection for Plotting to grid
			foreach (DataRowView _dRow in _dtTempView)
			{
				RoomEventCollection oRoomEventCollection = new RoomEventCollection();

				string _guestName = _dRow["GuestName"].ToString();
				string _companyName = _dRow["Company"].ToString();
				string _groupName = _dRow["GroupName"].ToString();
				string _folioType = _dRow["FolioType"].ToString();
				string _eventDate = _dRow["EventDate"].ToString();
				string _roomId = _dRow["RoomId"].ToString();
				string _eventType = _dRow["EventType"].ToString();
				//>> if no associated folio then Room is Out Of Order
				if (_guestName == "")
				{
					_guestName = "ENGINEERING JOB";
				}

				string _eventId = _dRow["EventId"].ToString();
				string _transferFlag = _dRow["TransferFlag"].ToString();

				string _startTime = _dRow["startTime"].ToString();
				string _endTime = _dRow["endTime"].ToString();
				string _roomType = _dRow["roomTypeCode"].ToString();

				oRoomEventCollection.EventType = _eventType;
				oRoomEventCollection.FromDate = DateTime.Parse(_eventDate);
				oRoomEventCollection.ToDate = DateTime.Parse(_eventDate);
				oRoomEventCollection.RoomID = _roomId;
				oRoomEventCollection.EventOwner = _guestName + "               ( " + _eventId + " ) ";
				oRoomEventCollection.TransferFlag = _transferFlag;

				oRoomEventCollection.StartTime = _startTime;
				oRoomEventCollection.EndTime = _endTime;
				oRoomEventCollection.RoomType = _roomType;
				oRoomEventCollection.FolioId = _eventId;

				oTempRoomEventCollectionForPlotting.Add(oRoomEventCollection);
				loRoomEventCollectionForPlotting.Add(oRoomEventCollection);

			}//end foreach

			//>> Merge Same ROomEvents [Room Schedule]
			int c = 0;
			for (int i = 0; i < oTempRoomEventCollectionForPlotting.Count; i++)
			{
				if (i > 0)
				{
					RoomEventCollection _oPreviousRoomEvent = (RoomEventCollection)oTempRoomEventCollectionForPlotting[i - 1];
					RoomEventCollection _oCurrentRoomEvent = (RoomEventCollection)oTempRoomEventCollectionForPlotting[i];

					if (_oCurrentRoomEvent.EventType == _oPreviousRoomEvent.EventType &&
						 _oCurrentRoomEvent.RoomID == _oPreviousRoomEvent.RoomID &&
						 _oCurrentRoomEvent.EventOwner == _oPreviousRoomEvent.EventOwner &&
						 _oPreviousRoomEvent.TransferFlag == "0")
					{
						//update current RoomEvent ToDate 
						RoomEventCollection _oPreviousRoomEventForPlotting = (RoomEventCollection)loRoomEventCollectionForPlotting[c - 1];

						//Folio _tempFolio = oFolioFacade.GetFolioBasicInfo(_oPreviousRoomEventForPlotting.FolioId);

						//int _dateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oPreviousRoomEventForPlotting.ToDate, _oCurrentRoomEvent.FromDate);

						//if (_tempFolio.Todate.Date >= _oCurrentRoomEvent.FromDate.Date &&
						//if(_tempFolio.FolioID == _oCurrentRoomEvent.FolioId)
						//{
							//check if continouos date or not
							// added March 11, 2009
							//if (_dateDiff < 2)
							//{

								_oPreviousRoomEventForPlotting.ToDate = _oCurrentRoomEvent.FromDate;

								//remove from Room Events for Plotting
								loRoomEventCollectionForPlotting.RemoveAt(c);

								c--;
							//}
						//}

					}

				}
				c++;
			}

		}

		private void plotRoomEventsToGrid()
		{

			initializeRoomEventsCollection();
			initializeRoomBlockCollection();

			DateTime startDate = this.dtpStartDate.Value.Date;

			foreach (RoomEventCollection _oRoomSchedule in loRoomEventCollectionForPlotting)
			{
				if (_oRoomSchedule.RoomType != "FUNCTION")
				{
					int row = -1;
					int col = 2;
					int lastCol = col;
					int gridCols = this.grdRooms.Cols.Count - 1;

					//find rowNumber in ROOM LIST
					for (int i = 3; i < this.grdRooms.Rows.Count; i++)
					{
						string _roomNo = this.grdRooms.GetDataDisplay(i, 1);
						if (_roomNo == _oRoomSchedule.RoomID)
						{
							row = i;
							break;
						}
					}// end for

					// if CANT FIND ROOM NUMBER IN LIST
					// dont proceed
					// jerome, april 23, 2008
					if (row > -1)
					{
						int fromToDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oRoomSchedule.FromDate.Date, _oRoomSchedule.ToDate.Date);
						int _fromDateCalendarDateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, startDate, _oRoomSchedule.FromDate.Date);


						// added by: Jerome, April 23, 2008
						// if difference from RoomEventFromDate versus Calendar Start Date
						// is lesser than 0, start at column 2;
						// else starts at column 3
						if (_fromDateCalendarDateDiff < 0)
						{
                            if (_oRoomSchedule.ToDate.Date >= startDate.Date)
                            {
                                col = 2;
                                _fromDateCalendarDateDiff = Math.Abs(_fromDateCalendarDateDiff);
                                //col += _fromDateCalendarDateDiff * 2;

                                lastCol = col + (fromToDiff * 2) - (_fromDateCalendarDateDiff * 2);
                            }
                            else
                            {
                                continue;
                            }
						}
						else
						{
							col = 3;
							col += _fromDateCalendarDateDiff * 2;

							lastCol = col + (fromToDiff * 2) - 1;


							//to block till the last column if Folio.ToDate > Calendary EndDate
							if (lastCol == (gridCols - 1))
							{
								
								int days = (int)this.nudWeeks.Value;
								days = days * 7;
								days = days - 1;//inclusive dates

								Folio tempFolio = oFolioFacade.GetFolioBasicInfo(_oRoomSchedule.FolioId);


								DateTime calendarEndDate = startDate.AddDays(days);
								int _toDateCalendarEndDateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, calendarEndDate, tempFolio.Todate.Date);

								if (_toDateCalendarEndDateDiff > 0)
								{
									lastCol++;
								}
								
							}
						}


						//checks if lastColumn is greater than Grid Columns
						// if so, lastColumn gets Grid Columns
						if (lastCol > gridCols)
						{
							lastCol = gridCols;
						}
						if (lastCol < col)
						{
							lastCol = col;
						}

						// plots IN CALENDAR
						for (int c = col; c <= lastCol; c++)
						{
							string owner = _oRoomSchedule.EventOwner;
							string _cellText = this.grdRooms.GetDataDisplay(row, c);
							//this.grdRooms.Select(row, c);

							if (_cellText != "")
							{
								if (owner.IndexOf(_cellText) == -1)
								{
									CellStyle cStyle = getCellStyle("share");

									owner = _cellText + " \\ " + _oRoomSchedule.EventOwner;
									this.grdRooms.SetData(row, c, owner);
									this.grdRooms.SetUserData(row, c, _oRoomSchedule.FolioId);

									this.grdRooms.SetCellStyle(row, c, cStyle);

								}
							}
							else
							{
								CellStyle cStyle = getCellStyle(_oRoomSchedule.EventType);

								this.grdRooms.SetData(row, c, owner);
								this.grdRooms.SetUserData(row, c, _oRoomSchedule.FolioId);

								this.grdRooms.SetCellStyle(row, c, cStyle);

							}

						}// endOfForLoop

					}//end if (row > -1)

				}//end if (_oRoomSchedule.RoomType != "FUNCTION")

			}//end foreach (RoomEventCollection)

			plotRoomBlocks();

		}

		private void plotRoomBlocks()
		{

           
			//>> plot RoomBlocks
			DateTime calStartDate = this.dtpStartDate.Value;
			foreach (RoomBlock oRoomBlock in oRoomBlockCollection)
			{
				//RoomEventC = tempLoopVar_RoomEventC;
				int row = -1;
				int col = 2;
				int lastCol = 0;
				int gridCols = this.grdRooms.Cols.Count - 1;

				//find rowNumber in ROOM LIST
				for (int i = 3; i < this.grdRooms.Rows.Count; i++)
				{
					string gridRoomNo = this.grdRooms.GetDataDisplay(i, 1);
					if (gridRoomNo == oRoomBlock.RoomID)
					{
						row = i;
						break;
					}
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
						col = 2;
						_fromDateCalendarDateDiff = Math.Abs(_fromDateCalendarDateDiff);
						//col += _fromDateCalendarDateDiff * 2;

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
						string owner = oRoomBlock.Reason;
						this.grdRooms.SetData(row, c, owner);
						this.grdRooms.SetUserData(row, c, oRoomBlock.BlockID);

						CellStyle _style = this.getCellStyle("BLOCKING");
						this.grdRooms.SetCellStyle(row, c, _style);
					}// endOfForLoop
				}
			}

		}

		#endregion

		#region "FUNCTIONS"

		private void setupFunction()
		{
			this.grdFunctions.Rows.Count = 4;

			this.grdFunctions.Rows.Fixed = 4;
			this.grdFunctions.Cols.Fixed = 2;


			//>> Columns ROOMTYPES, ROOMS
			this.grdFunctions.Cols.Fixed = 2;

			this.grdFunctions.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;

			//>> set merge First Row (MONTH,YEAR and DAYNAME)
			this.grdFunctions.Rows[0].AllowMerging = true;

			this.grdFunctions.Rows[1].AllowMerging = true;
			this.grdFunctions.Rows[2].AllowMerging = true;
			this.grdFunctions.Rows[3].AllowMerging = true;

			this.grdFunctions.Cols[0].AllowMerging = true;
			this.grdFunctions.Cols[1].AllowMerging = true;

			this.grdFunctions.Cols.DefaultSize = 17;
			this.grdFunctions.Cols[0].Width = 60;
			this.grdFunctions.Cols[1].Width = 40;

			this.grdFunctions.SetData(0, 0, "Type");
			this.grdFunctions.SetData(1, 0, "Type");
			this.grdFunctions.SetData(2, 0, "Type");
			this.grdFunctions.SetData(0, 1, "Rooms");
			this.grdFunctions.SetData(1, 1, "Rooms");
			this.grdFunctions.SetData(2, 1, "Rooms");
			if (dtvFunction == null)
				return;

			dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
            dtvFunction.RowFilter = "roomSuperType like '%FUNCTION%'";

			dtvFunction.Sort = "roomTypeCode";
			this.grdFunctions.Rows.Count = dtvFunction.Count + 4;
			int i = 4;
			foreach (DataRowView _dtrView in dtvFunction)
			{
				this.grdFunctions.SetData(i, 0, _dtrView["roomTypeCode"].ToString());
				this.grdFunctions.SetData(i, 1, _dtrView["roomId"].ToString());

				i++;
			}
		}

        private void setupFunction(string pRoomType)
        {
            this.grdFunctions.Rows.Count = 4;

            this.grdFunctions.Rows.Fixed = 4;
            this.grdFunctions.Cols.Fixed = 2;


            //>> Columns ROOMTYPES, ROOMS
            this.grdFunctions.Cols.Fixed = 2;

            this.grdFunctions.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;

            //>> set merge First Row (MONTH,YEAR and DAYNAME)
            this.grdFunctions.Rows[0].AllowMerging = true;

            this.grdFunctions.Rows[1].AllowMerging = true;
            this.grdFunctions.Rows[2].AllowMerging = true;
            this.grdFunctions.Rows[3].AllowMerging = true;

            this.grdFunctions.Cols[0].AllowMerging = true;
            this.grdFunctions.Cols[1].AllowMerging = true;

            this.grdFunctions.Cols.DefaultSize = 17;
            this.grdFunctions.Cols[0].Width = 60;
            this.grdFunctions.Cols[1].Width = 40;

            this.grdFunctions.SetData(0, 0, "Type");
            this.grdFunctions.SetData(1, 0, "Type");
            this.grdFunctions.SetData(2, 0, "Type");
            this.grdFunctions.SetData(0, 1, "Rooms");
            this.grdFunctions.SetData(1, 1, "Rooms");
            this.grdFunctions.SetData(2, 1, "Rooms");

            if (dtvFunction == null)
                return;

            dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
            dtvFunction.RowFilter = "roomSuperType like '%FUNCTION%'"
                                  + "AND roomTypeCode = '" + pRoomType + "'";

            dtvFunction.Sort = "roomId";

            this.grdFunctions.Rows.Count = dtvFunction.Count + 4;
            int i = 4;
            foreach (DataRowView _dtrView in dtvFunction)
            {
                this.grdFunctions.SetData(i, 0, _dtrView["roomTypeCode"].ToString());
                this.grdFunctions.SetData(i, 1, _dtrView["roomId"].ToString());

                i++;
            }
        }
		private void setUpFunctionCalendarDates()
		{

			int _numberOfDays = (int)this.nudWeeks.Value;
			int _numberOfCols = _numberOfDays * 24;


			this.grdFunctions.Cols.Count = _numberOfCols + 2;

			DateTime _startDate = this.dtpStartDate.Value.AddDays(-1);

			int _day = 1;
			for (int _col = 2; _col <= _numberOfCols; _col = _col + 24)
			{
				if (_col % 2 == 0)
				{

					DateTime forLoopDate = _startDate.AddDays(_day);

					string monthAndYear = forLoopDate.ToString("MMMM , yyyy");
					int hCol = 0;
					int hour = 0;
					for (hCol = _col; hCol < (_col + 24); hCol++)
					{
						this.grdFunctions.SetData(0, hCol, monthAndYear);

						// for Day prefix(S M T W T F S)
						if (forLoopDate.DayOfWeek == DayOfWeek.Sunday)
						{
							string _dayNameStart = forLoopDate.DayOfWeek.ToString();


							this.grdFunctions.SetData(1, hCol, _dayNameStart);
							this.grdFunctions.SetCellStyle(1, hCol, csSundayStyle);

						}
						else
						{
							string _dayNameStart = forLoopDate.DayOfWeek.ToString();
							this.grdFunctions.SetData(1, hCol, _dayNameStart);
						}

						//>> Numeric Date
						this.grdFunctions.SetData(2, hCol, forLoopDate.Day.ToString());

						//>> hours
						this.grdFunctions.SetData(3, hCol, hour.ToString("00"));

						hour++;
					}

				}
				_day++;

			}
		}

		private void initializeFunctionEventsCollection()
		{

			DateTime _startDate = this.dtpStartDate.Value.Date.AddDays(-1);
			double _weekValue = (double)nudWeeks.Value;

			string _strStartDate = _startDate.ToString("yyyy-MM-dd");
			double _noOfDays = _weekValue * 7;
			string _strEndDate = _startDate.AddDays(_noOfDays).ToString("yyyy-MM-dd");

			CalendarFacade oCalendarFacade = new CalendarFacade();
			DataTable _dtRoomEvents = oCalendarFacade.getRoomEventsForPlotting(_strStartDate, _strEndDate);

			loFunctionEventCollectionForPlotting = new ArrayList();
            ArrayList oTempRoomEventCollectionForPlotting = new ArrayList();

			DataView _dtTempView = _dtRoomEvents.DefaultView;
			_dtTempView.RowStateFilter = DataViewRowState.OriginalRows;
            _dtTempView.RowFilter = "roomSuperType like '%FUNCTION%' and foliostatus <> 'WAIT LIST'";

			//>> load All RoomEvents to Temp Collection & Collection for Plotting to grid
			foreach (DataRowView _dRow in _dtTempView)
			{
				RoomEventCollection oRoomEventCollection = new RoomEventCollection();

				string _guestName = _dRow["GuestName"].ToString();
				string _companyName = _dRow["Company"].ToString();
				string _groupName = _dRow["GroupName"].ToString();
				string _folioType = _dRow["FolioType"].ToString();
				string _eventDate = _dRow["EventDate"].ToString();
				string _roomId = _dRow["RoomId"].ToString();
				string _eventType = _dRow["EventType"].ToString();
                //>> if no associated folio then Room is Out Of Order
                if (_eventType == "ENGINEERING JOB")
                {
                    _groupName = "ENGINEERING JOB";
                }
				string _eventId = _dRow["EventId"].ToString();
				string _transferFlag = _dRow["TransferFlag"].ToString();

				string _startTime = _dRow["startTime"].ToString();
				string _endTime = _dRow["endTime"].ToString();
				string _roomType = _dRow["roomTypeCode"].ToString();

				oRoomEventCollection.EventType = _eventType;
				oRoomEventCollection.FromDate = DateTime.Parse(_eventDate);
				oRoomEventCollection.ToDate = DateTime.Parse(_eventDate);
				oRoomEventCollection.RoomID = _roomId;
				oRoomEventCollection.EventOwner = _groupName + " - " + _companyName;
				oRoomEventCollection.TransferFlag = _transferFlag;

				oRoomEventCollection.StartTime = _startTime;
				oRoomEventCollection.EndTime = _endTime;
				oRoomEventCollection.RoomType = _roomType;
				oRoomEventCollection.FolioId = _eventId;


                oTempRoomEventCollectionForPlotting.Add(oRoomEventCollection);
				loFunctionEventCollectionForPlotting.Add(oRoomEventCollection);

			}//end foreach

            //>> Merge Same ROomEvents [Room Schedule]
            int c = 0;
            for (int i = 0; i < oTempRoomEventCollectionForPlotting.Count; i++)
            {
                if (i > 0 && oTempRoomEventCollectionForPlotting[i].GetType().GetProperty("EventType").GetValue(oTempRoomEventCollectionForPlotting[i],null).ToString() == "ENGINEERING JOB")
                {
                    RoomEventCollection _oPreviousRoomEvent = (RoomEventCollection)oTempRoomEventCollectionForPlotting[i - 1];
                    RoomEventCollection _oCurrentRoomEvent = (RoomEventCollection)oTempRoomEventCollectionForPlotting[i];

                    if (_oCurrentRoomEvent.EventType == _oPreviousRoomEvent.EventType &&
                         _oCurrentRoomEvent.RoomID == _oPreviousRoomEvent.RoomID &&
                         _oCurrentRoomEvent.EventOwner == _oPreviousRoomEvent.EventOwner &&
                         _oPreviousRoomEvent.TransferFlag == "0")
                    {
                        //update current RoomEvent ToDate 
                        RoomEventCollection _oPreviousRoomEventForPlotting = (RoomEventCollection)loFunctionEventCollectionForPlotting[c - 1];

                        //Folio _tempFolio = oFolioFacade.GetFolioBasicInfo(_oPreviousRoomEventForPlotting.FolioId);

                        //int _dateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oPreviousRoomEventForPlotting.ToDate, _oCurrentRoomEvent.FromDate);

                        //if (_tempFolio.Todate.Date >= _oCurrentRoomEvent.FromDate.Date &&
                        //if(_tempFolio.FolioID == _oCurrentRoomEvent.FolioId)
                        //{
                        //check if continouos date or not
                        // added March 11, 2009
                        //if (_dateDiff < 2)
                        //{

                        _oPreviousRoomEventForPlotting.ToDate = _oCurrentRoomEvent.FromDate;

                        //remove from Room Events for Plotting
                        loFunctionEventCollectionForPlotting.RemoveAt(c);

                        c--;
                        //}
                        //}

                    }

                }
                c++;
            }
		}

		private void plotFunctionEventsToGrid()
		{

			initializeFunctionEventsCollection();


			DateTime gridStartDate = this.dtpStartDate.Value.Date;
			DateTime gridEndDate = this.dtpStartDate.Value.AddDays((int)this.nudWeeks.Value).Date;

            CalendarFacade oCalendarFacade = new CalendarFacade();
            string _str = "";
            try
            {
                foreach (RoomEventCollection _oRoomSchedule in loFunctionEventCollectionForPlotting)
                {
                    //if (_oRoomSchedule.RoomType == "FUNCTION")
                    //{
                    int row = -1;
                    int col = 2;
                    int lastCol = 2;
                    int gridCols = this.grdFunctions.Cols.Count - 1;

                    _str  = _oRoomSchedule.RoomID+" "+
                        _oRoomSchedule.FolioId+" "+
                        _oRoomSchedule.EventType+" "+
                        _oRoomSchedule.FromDate+" "+
                        _oRoomSchedule.ToDate+" "+
                        _oRoomSchedule.EventOwner+" ";


                    //_str = _oRoomSchedule.FolioId.ToString() + "-" + _oRoomSchedule.RoomID + " ";

                    //find rowNumber in ROOM LIST
                    for (int i = 3; i < this.grdFunctions.Rows.Count; i++)
                    {
                        string gridRoomNo = this.grdFunctions.GetDataDisplay(i, 1);
                        if (gridRoomNo == _oRoomSchedule.RoomID)
                        {
                            row = i;
                            break;
                        }
                    }// end for

                    // if CANT FIND ROOM NUMBER IN LIST
                    // dont proceed
                    // jerome, April 23, 2008
                    if (row > -1)
                    {
                        int _diffFromDate = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, gridStartDate, _oRoomSchedule.FromDate);
                        int _diffToDate = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oRoomSchedule.FromDate, gridEndDate);

                        if (_diffFromDate >= 0 && _diffToDate >= 0)
                        {
                            DateTime _startTime = DateTime.Parse(_oRoomSchedule.StartTime);
                            DateTime _endTime = DateTime.Parse(_oRoomSchedule.EndTime);


                            int _diffFromDateVSCalendarDate = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, gridStartDate, _oRoomSchedule.FromDate);

                            col = col + (_diffFromDateVSCalendarDate * 24);

                            int _diffHourStart = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Hour, DateTime.Parse("00:00:00"), _startTime);
                            col += _diffHourStart;
                            int _diffHourEnd = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Hour, _startTime, _endTime);

                            // if ends in midnight/dawn
                            if (_diffHourEnd < 0)
                            {
                                _diffHourEnd = _diffHourEnd * -1;
                                _diffHourEnd -= 12;
                            }

                            lastCol = col + _diffHourEnd;

                            int _diffFromDateVSToDate = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oRoomSchedule.FromDate, _oRoomSchedule.ToDate);
                            if (_oRoomSchedule.EventType == "ENGINEERING JOB")
                            {
                                lastCol += (_diffFromDateVSToDate * 24);
                            }

                            if (lastCol > gridCols)
                            {
                                lastCol = gridCols;
                            }

                            // plots IN CALENDAR
                            for (int c = col; c <= lastCol; c++)
                            {
                                string owner = _oRoomSchedule.EventOwner;
                                string _cellText = this.grdFunctions.GetDataDisplay(row, c);
                                //this.grdRooms.Select(row, c);

                                if (_cellText != "")
                                {
                                    if (owner.IndexOf(_cellText) == -1)
                                    {
                                        CellStyle cStyle = getCellStyle("share");

                                        owner = _cellText + " \\ " + _oRoomSchedule.EventOwner;
                                        this.grdFunctions.SetData(row, c, owner);
                                        this.grdFunctions.SetUserData(row, c, _oRoomSchedule.FolioId);

                                        this.grdFunctions.SetCellStyle(row, c, cStyle);

                                    }
                                }
                                else
                                {
                                    CellStyle cStyle;
                                    if (_oRoomSchedule.EventType == "RESERVATION")
                                    {
                                        cStyle = getCellStyle(oFolioFacade.getFolioStatus(_oRoomSchedule.FolioId));
                                    }
                                    else
                                    {
                                        cStyle = getCellStyle(_oRoomSchedule.EventType);
                                    }

                                    this.grdFunctions.SetData(row, c, owner);
                                    this.grdFunctions.SetCellStyle(row, c, cStyle);
                                    this.grdFunctions.SetUserData(row, c, _oRoomSchedule.FolioId);

                                    this.grdFunctions.Rows[row].AllowMerging = true;
                                }


                                //Kevin L Oliveros 2014-05-02
                                CellStyle _cStyle = grdRooms.Styles.Add("Brown");
                                _cStyle.BackColor = Color.BurlyWood;


                                int _rowMerge = -1;
                                DataTable _dtRoomEvents = oCalendarFacade.getMergeRoomsForPlotting("", _oRoomSchedule.RoomID, _oRoomSchedule.FolioId);
                                foreach (DataRow _row in _dtRoomEvents.Rows)
                                {
                                    string _roomID = _row["RoomMergeID"].ToString();
                                    for (int i = 3; i < this.grdFunctions.Rows.Count; i++)
                                    {
                                        string gridRoomNo = this.grdFunctions.GetDataDisplay(i, 1);
                                        if (gridRoomNo == _roomID)
                                        {
                                            _rowMerge = i;
                                            break;
                                        }
                                    }// end for
                                    this.grdFunctions.SetData(_rowMerge, c, _oRoomSchedule.RoomID + "-MERGE");
                                    this.grdFunctions.SetCellStyle(_rowMerge, c, _cStyle);
                                    this.grdFunctions.SetUserData(_rowMerge, c, _oRoomSchedule.FolioId);
                                    this.grdFunctions.Rows[_rowMerge].AllowMerging = true;
                                }
                            }// endOfForLoop
                        }
                    }//end if (row > -1)
                    //}//end if (_oRoomSchedule.RoomType == "FUNCTION")
                }//end foreach (RoomEventCollection)
            }
            catch(Exception ex)
            {
               //MessageBox.Show(_str + "   " + ex.Message);
            }
			plotFunctionBlocks();

		}

        public void plotMergeFunctionEvents(string RoomID, string PrDSD )
        {
		

            //loFunctionEventCollectionForPlotting = new ArrayList();
            //ArrayList oTempRoomEventCollectionForPlotting = new ArrayList();

            //DataView _dtTempView = _dtRoomEvents.DefaultView;
            //_dtTempView.RowStateFilter = DataViewRowState.OriginalRows;
            //_dtTempView.RowFilter = "roomSuperType like '%FUNCTION%' and foliostatus <> 'WAIT LIST'";

            //for (int i = 3; i < this.grdFunctions.Rows.Count; i++)
            //{
            //    string gridRoomNo = this.grdFunctions.GetDataDisplay(i, 1);
            //    if (gridRoomNo == _oRoomSchedule.RoomID)
            //    {
            //        row = i;
            //        break;
            //    }
            //}// end for

        }

      

		private void plotFunctionBlocks()
		{

			//>> plot RoomBlocks
			DateTime calStartDate = this.dtpStartDate.Value;
			foreach (RoomBlock oRoomBlock in oRoomBlockCollection)
			{
				//RoomEventC = tempLoopVar_RoomEventC;
				int row = -1;
				int col = 2;
				int lastCol = 0;
				int gridCols = this.grdFunctions.Cols.Count - 1;

				//find rowNumber in ROOM LIST
				for (int i = 4; i < this.grdFunctions.Rows.Count; i++)
				{
					string gridRoomNo = this.grdFunctions.GetDataDisplay(i, 1);
					if (gridRoomNo == oRoomBlock.RoomID)
					{
						row = i;
						break;
					}
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
						col += _fromDateCalendarDateDiff;

						lastCol = col + (fromToDiff * 24) - (_fromDateCalendarDateDiff);
					}
					else
					{
						col = 3;
						col += (_fromDateCalendarDateDiff * 24);

						lastCol = col + (fromToDiff * 24) - 1;
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
						string owner = oRoomBlock.Reason;
						this.grdFunctions.SetData(row, c, owner);

						CellStyle _style = this.getCellStyle("BLOCKING");
						this.grdFunctions.SetCellStyle(row, c, _style);
						this.grdFunctions.SetUserData(row, c, oRoomBlock.BlockID);

						this.grdFunctions.Rows[row].AllowMerging = true;
					}// endOfForLoop
				}
			}
		}

		#endregion

		#region "METHODS"

		private void initializeGridViewRowStyles()
		{
			csNormalStyle = this.grdRooms.Styles["Normal"];
			csSundayStyle = this.grdRooms.Styles["sundayStyle"];
			csReservationStyle = this.grdRooms.Styles["reservation"];
			csInHouseStyle = this.grdRooms.Styles["inhouse"];
			csBlockedStyle = this.grdRooms.Styles["blocking"];
			csEngineeringStyle = this.grdRooms.Styles["engineering"];
			csFixedStyle = this.grdRooms.Styles["Fixed"];
			csRowSelectedStyel = this.grdRooms.Styles["rowSelected"];
			csShareStyle = this.grdRooms.Styles["share"];
            csDirtyStyle = this.grdRooms.Styles["dirty"];

		}

		public void initializeRoomBlockCollection()
		{

			oRoomBlockFacade = new RoomBlockFacade();

			DateTime _startDate = this.dtpStartDate.Value.Date.AddDays(-1);
			double _weekValue = (double)nudWeeks.Value;

			string _strStartDate = _startDate.ToString("yyyy-MM-dd");
			double _noOfDays = _weekValue * 7;
			string _strEndDate = _startDate.AddDays(_noOfDays).ToString("yyyy-MM-dd");

			oRoomBlockCollection = oRoomBlockFacade.getRoomBlocks(_strStartDate, _strEndDate);

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

		private CellStyle getCellStyle(string eventtype)
		{
			switch (eventtype.ToUpper())
			{
				case "BLOCKING":
				case "GROUP_BLOCKING":
					return csBlockedStyle;
                case "TENTATIVE":
				case "RESERVATION":
					return csReservationStyle;
                case "CONFIRMED":
				case "IN HOUSE":
					return csInHouseStyle;

				case "ENGINEERING JOB":
					return csEngineeringStyle;

				case "SHARE":
					return csShareStyle;

				default:
					return csBlockedStyle;

			}
		}
        private IList<RoomType> ilRoomTypeList;
		private void getAllRoomTypes()
		{
			ilRoomTypeList = lRoomTypeFacade.getRoomTypesList("");
			//>> load all room types to combo box
			//>> Combo Box has 1 current record "ALL"
			foreach (RoomType _oRoomType in ilRoomTypeList)
			{
				this.cboRoomType.Items.Add(_oRoomType.RoomTypeCode);
			}

			this.cboRoomType.MaxDropDownItems = ilRoomTypeList.Count + 1;

		}

		private void plotCurrentFolioScheduleToGrid(IList<Schedule> poFolioSchedule)
		{
			DateTime startDate = this.dtpStartDate.Value.Date;

			foreach (Schedule oRoomSchedule in poFolioSchedule)
			{
				if (oRoomSchedule.RoomType != "FUNCTION")
				{
					int row = -1;
					int col = 2;
					int lastCol = 0;
					int gridCols = this.grdRooms.Cols.Count - 1;

					//find rowNumber in ROOM LIST
					for (int i = 3; i < this.grdRooms.Rows.Count; i++)
					{
						string _roomNo = this.grdRooms.GetDataDisplay(i, 1);
						if (_roomNo == oRoomSchedule.RoomID)
						{
							row = i;
							this.grdRooms.Row = i;
							break;
						}
					}// end for

					// if CANT FIND ROOM NUMBER IN LIST
					// dont proceed
					// jerome, april 23, 2008
					if (row > -1)
					{
						int fromToDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, oRoomSchedule.FromDate.Date, oRoomSchedule.ToDate.Date);
						int _fromDateCalendarDateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, startDate, oRoomSchedule.FromDate.Date);


						// added by: Jerome, April 23, 2008
						// if difference from RoomEventFromDate versus Calendar Start Date
						// is lesser than 0, start at column 2;
						// else starts at column 3
						if (_fromDateCalendarDateDiff < 0)
						{
							col = 2;
							_fromDateCalendarDateDiff = Math.Abs(_fromDateCalendarDateDiff);
							//col += _fromDateCalendarDateDiff * 2;

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

							string _cellText = this.grdRooms.GetDataDisplay(row, c);
							string owner = _cellText;
							if (_cellText == "")
							{
								owner = lOperationMode;
							}


							if (_cellText != "")
							{
								if (owner.IndexOf(_cellText) == -1)
								{
									CellStyle cStyle = getCellStyle("share");

									owner = _cellText + " \\ " + lOperationMode;
									this.grdRooms.SetData(row, c, owner);

									this.grdRooms.SetCellStyle(row, c, cStyle);

								}
							}
							else
							{
								CellStyle cStyle = getCellStyle(lOperationMode);

								this.grdRooms.SetData(row, c, owner);
								this.grdRooms.SetCellStyle(row, c, cStyle);

							}

						}// endOfForLoop

					}//end if (row > -1)

				}//end if (_oRoomSchedule.RoomType != "FUNCTION")

			}//end foreach (RoomEventCollection)
		}


		private void showBlockReason(string pStatus)
		{
			RoomBlockCollection oRoomBlockList = new RoomBlockCollection();

			foreach (Schedule _oSchedule in loScheduleCollection)
			{
				RoomBlock _oRoomBlock = new RoomBlock();
				_oRoomBlock.BlockID = 0;
				_oRoomBlock.BlockFrom = _oSchedule.FromDate;
				_oRoomBlock.BlockTo = _oSchedule.ToDate;
				_oRoomBlock.RoomID = _oSchedule.RoomID;
				_oRoomBlock.Reason = "";

				oRoomBlockList.Add(_oRoomBlock);

			}

			Form frmReasonUI = new AddReasonUI(oRoomBlockList);
			frmReasonUI.ShowDialog();

			loScheduleCollection = new List<Schedule>();

			//>> reload form for faster operation
			Type oType = GlobalVariables.gMDI.GetType();

			Type[] types = { typeof(System.String), typeof(System.DateTime), typeof(int), typeof(System.String), typeof(object) };
			object[] paramVals = { lOperationMode, this.dtpStartDate.Value, (int)this.nudWeeks.Value, this.cboRoomType.Text, loScheduleCollection };

			MethodInfo mInfo = oType.GetMethod("reloadCalendar");
			mInfo.Invoke(GlobalVariables.gMDI, paramVals);
			this.Close();
			//>> end reload form
		}

		public void setButtonState(bool btnRemoveState,
								   bool btnMarkState,
								   bool btnDoneState,
								   bool btnSetupState,
								   bool btnPrintState)
		{
			this.btnRemove.Enabled = btnRemoveState;
			this.btnMark.Enabled = btnMarkState;
			this.btnDone.Enabled = btnDoneState;
			this.btnSetup.Enabled = btnSetupState;
			this.btnPrint.Enabled = btnPrintState;

		}

        private string showRoomInformation(string pRoomID)
        {
            try
            {
                string roomInfo = "";

                RoomFacade _oRoomFacade = new RoomFacade();
                Room _oRoom = new Room();
                _oRoom = _oRoomFacade.getRoom(pRoomID);

                roomInfo += "\r\n";
                roomInfo += "Room No.   :  " + _oRoom.RoomId + "\r\n";
                roomInfo += "Status        :  " + _oRoom.Stateflag + " " + _oRoom.CleaningStatus + "\r\n";
                roomInfo += "Room Type :  " + _oRoom.RoomTypecode + "\r\n\r\n";
                roomInfo += "Room Amenities :\r\n";

                Amenity _oAmenity = new Amenity();
                AmenityFacade _oAmenityFacade = new AmenityFacade();
                _oAmenity = _oAmenityFacade.getRoomAmenities(pRoomID);
                DataTable _dtRoomAmenities = _oAmenity.Tables["RoomAmenities"];

                foreach (DataRow _dRow in _dtRoomAmenities.Rows)
                {
                    roomInfo += "* " + _dRow["name"].ToString() + "\r\n";
                }

                return roomInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

		private string showFolioInformation(string pFolioId)
		{
			try
			{
				string folioInfo = "";

				DataView dtView = oGuestFolio.DefaultView;

				dtView.RowStateFilter = DataViewRowState.OriginalRows;
				dtView.RowFilter = "FolioId = '" + pFolioId + "'";

				foreach (DataRowView dRowView in dtView)
				{
					folioInfo += "Type\t:  " + dRowView["RoomTypeCode"] + "\r\n";

					folioInfo += "\r\n";

					folioInfo += "Guest\t:  " + dRowView["GuestName"] + "\r\n";
					folioInfo += "Rate\t:  " + string.Format("{0:#,##0.00}", Double.Parse(dRowView["Rate"].ToString())) + "\r\n";
					folioInfo += "Arrival\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["ArrivalDate"].ToString())) + "\r\n";
					folioInfo += "Depart'r\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["DepartureDate"].ToString())) + "\r\n";
					folioInfo += "Pax\t:  " + dRowView["noOfAdults"].ToString() + "\r\n\r\n";

                    folioInfo += "Event\t:  " + dRowView["groupName"] + "\r\n";
					folioInfo += "Comp.\t:  " + dRowView["CompanyName"] + "\r\n";
					folioInfo += "Folio\t:  " + dRowView["FolioType"] + "\r\n\r\n";

					folioInfo += "Source\t: " + dRowView["source"] + "\r\n";
					folioInfo += "Remarks :\r\n" + dRowView["Remarks"] + "\r\n";

					break;
				}


				return folioInfo;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Exception: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return "";
			}
		}

        private string showEngineeringInfo(string pEngineeringID)
        {
            try
            {
                string engineeringInfo = "";

                EngineeringJobFacade _oEngineeringFacade = new EngineeringJobFacade();
                DataTable _oDataTable = _oEngineeringFacade.getEngineeringJob(pEngineeringID);

                foreach (DataRow dRow in _oDataTable.Rows)
                {
                    engineeringInfo += "Type\t\t:  " + dRow["roomTypeCode"] + "\r\n";

                    engineeringInfo += "\r\n";

                    engineeringInfo += "Eng'g Job No.\t:  " + dRow["enggjobno"].ToString() + "\r\n";
                    engineeringInfo += "Job Description\t:  " + dRow["description"].ToString() + "\r\n";
                    engineeringInfo += "Start Date\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRow["startDate"].ToString())) + "\r\n";
                    engineeringInfo += "End Date\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRow["endDate"].ToString())) + "\r\n";
                    engineeringInfo += "Start Time\t:  " + string.Format("{0:hh:mm tt}", DateTime.Parse(dRow["startTime"].ToString())) + "\r\n";
                    engineeringInfo += "End Time\t:  " + string.Format("{0:hh:mm tt}", DateTime.Parse(dRow["endTime"].ToString())) + "\r\n";
                    break;
                }


                return engineeringInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private string showCompanyFolioInformation(string pFolioID)
        {
            try
            {
                string folioInfo = "";

                DataView dtView = oCompanyFolio.DefaultView;

                dtView.RowStateFilter = DataViewRowState.OriginalRows;
                dtView.RowFilter = "FolioId = '" + pFolioID + "'";

                int i = 0;
                foreach (DataRowView dRowView in dtView)
                {
                    if (i == 0)
                    {
                        folioInfo += "Type\t: " + dRowView["roomtype"] + "\r\n";
                    }
                    else
                    {
                        folioInfo += "--------------------------------\r\n";
                    }

                    folioInfo += "\r\n";

                    folioInfo += "Event \t: " + dRowView["groupname"] + "\r\n";
                    folioInfo += "Comp.\t: " + dRowView["companyname"] + "\r\n\r\n";
                    folioInfo += "Contact\t:  " + dRowView["contactperson"] + "\r\n";
                    folioInfo += "Live In\t:  " + dRowView["liveInPax"] + "\r\n";
                    folioInfo += "Live Out:  " + dRowView["liveOutPax"] + "\r\n\r\n";

                    folioInfo += "Arrival\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["ArrivalDate"].ToString())) + "\r\n";
                    folioInfo += "Depart'r\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["DepartureDate"].ToString())) + "\r\n\r\n";

                    folioInfo += "Remarks :\r\n" + dRowView["Remarks"] + "\r\n";

                    //break;
                    i++;
                }


                return folioInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

		private void reloadCalendar()
		{
			if (isFormLoaded)
			{
				switch (lOperationMode)
				{
					case "BLOCKING":

						Type oType = GlobalVariables.gMDI.GetType();

						Type[] types = { typeof(System.String), typeof(System.DateTime), typeof(int), typeof(System.String), typeof(object) };
						object[] paramVals = { lOperationMode, this.dtpStartDate.Value, (int)this.nudWeeks.Value, this.cboRoomType.Text, this.loScheduleCollection };

						MethodInfo mInfo = oType.GetMethod("reloadCalendar");
						mInfo.Invoke(GlobalVariables.gMDI, paramVals);
						this.Close();
						break;

					case "RESERVATION":
					case "IN HOUSE":
					case "ENGINEERING JOB":

						this.Hide();

						oType = lbl.FindForm().GetType();

						Type[] paramTypes = { typeof(DateTime), typeof(int), typeof(string), typeof(IList<Schedule>) };
						object[] paramValues = { this.dtpStartDate.Value, (int)this.nudWeeks.Value, this.cboRoomType.Text, loScheduleCollection };

						//object[] paramsVal = {  };
						mInfo = oType.GetMethod("loadCalendarWizard", paramTypes);
						mInfo.Invoke(lbl.FindForm(), paramValues);

						//this.Close();
						break;

					case "GROUP_BLOCKING":
						this.Hide();

						oType = lbl.FindForm().GetType();

                        Type[] paramTypesGroup = { typeof(DateTime), typeof(DateTime), typeof(int), typeof(string), typeof(string) };
						object[] paramValuesGroup = { this.dtpStartDate.Value, this.dtpEndDate.Value, (int)this.nudWeeks.Value, this.cboRoomType.Text, lGroupFolio.FolioID };

						//object[] paramsVal = {  };
						mInfo = oType.GetMethod("loadCalendarForBlocking", paramTypesGroup);
						mInfo.Invoke(lbl.FindForm(), paramValuesGroup);

						//this.Close();
						break;
				}
			}
		}

		#endregion

		#region "CONTROL EVENTS"


		private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				////>> to avoid processing this part on SelectedIndexChange upon form load
				if (isFormLoaded)
				{
					//reloadCalendar();
					string _roomType = this.cboRoomType.Text;
					switch (_roomType)
					{
						case "FUNCTION":
                            this.tcAllRooms.SelectedIndex = lFunctionTabIndex;
							break;
						case "ALL":
                             //jlo 6-10-10 emm only config
                            if (ConfigVariables.gIsEMMOnly == "true")
                            {
                                this.tcAllRooms.SelectedIndex = lFunctionTabIndex;
                                setupFunction();
                                plotFunctionEventsToGrid();
                            }
                            else
                            {
                                this.tcAllRooms.SelectedIndex = 0;
                                setupRooms();
                                plotRoomEventsToGrid();
                            }
							

							if (loScheduleCollection != null)
							{
								//should block current schedule here
								plotCurrentFolioScheduleToGrid(loScheduleCollection);
							}

							break;
						default: // show per Room Type
                            if (isFunctionRoom(_roomType))
                            {
                                this.tcAllRooms.SelectedIndex = lFunctionTabIndex;
                                setupFunction(_roomType);
                                plotFunctionEventsToGrid();
                            }
                            else
                            {
                                this.tcAllRooms.SelectedIndex = 0;
                                setupRooms(_roomType);
                                plotRoomEventsToGrid();
                            }
							

							if (loScheduleCollection != null)
							{
								//should block current schedule here
								plotCurrentFolioScheduleToGrid(loScheduleCollection);
							}

							break;
					}
				}

			}
			catch
			{ }
		}

		private void dtpStartDate_CloseUp(object sender, EventArgs e)
		{
			try
			{
				
				if (isFormLoaded)
				{
					if (this.dtpStartDate.Value.Date != lCalendarDateTime)
					{
						reloadCalendar();
					}
				}
			}
			catch
			{
				this.Close();
			}
		}

		private void dtpStartDate_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				dtpStartDate_CloseUp(sender, e);
			}
		}

		private void nudWeeks_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (isFormLoaded)
				{
					reloadCalendar();
				}
			}
			catch(Exception ex)
			{
				//throw ex;
				MessageBox.Show(ex.Message);
				//this.Close();
			}
		}

		private void RoomCalendar_New_Activated(object sender, EventArgs e)
		{
			//this.WindowState = FormWindowState.Maximized;
			if (viewFolioORBlockingInfo)
			{
				Type oType = GlobalVariables.gMDI.GetType();

				Type[] types = { typeof(System.String), typeof(System.DateTime), typeof(int), typeof(System.String), typeof(object) };
				object[] paramVals = { lOperationMode, this.dtpStartDate.Value, (int)this.nudWeeks.Value, this.cboRoomType.Text, this.loScheduleCollection};

				MethodInfo mInfo = oType.GetMethod("reloadCalendar");
				mInfo.Invoke(GlobalVariables.gMDI, paramVals);
				this.Close();
			}
			switch (lOperationMode)
			{ 
				case "BLOCKING":
				case "GROUP_BLOCKING":
					this.btnDone.Visible = false;
					break;
				default:
					this.btnDone.Visible = true;
					break;
			}
		}

		private void tcAllRooms_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcAllRooms.SelectedIndex == lFunctionTabIndex)
			{
				//this.cboRoomType.Enabled = false;

				this.lblWeekToDisplay.Text = "Days to display :";
                setButtonState(true, true, true, true, true);
				//setButtonState(false, false, false, true, true);
			}
			else
			{
				//this.cboRoomType.Enabled = true;

				this.lblWeekToDisplay.Text = "Weeks to display :";

				setButtonState(true, true, true, true, true);
			}
		}

		private void RoomCalendar_New_Load(object sender, EventArgs e)
		{
			isFormLoaded = true;

			switch (lOperationMode)
			{ 
				case "BLOCKING":
				case "GROUP_BLOCKING":
					this.btnMark.Text = "Block";
					break;
				case "RESERVATION":
					this.btnMark.Text = "Reserve";
					break;

				case "IN HOUSE":
					this.btnMark.Text = "Reserve";
					break;

				case "ENGINEERING JOB":
					this.btnMark.Text = "Plot";
					break;
			}
            //jlo 6-10-10 emm only config
            if (ConfigVariables.gIsEMMOnly == "true")
            {
                this.lFunctionTabIndex = 0;
                this.tcAllRooms.Controls.Remove(this.tabRooms);
                this.tabFunction_Click(null, null);
            }
            //jlo
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnMark_Click(object sender, EventArgs e)
		{
            try
            {
                //>> only for Rooms
                if (this.tcAllRooms.SelectedIndex == 0 && lFunctionTabIndex != 0)
                {
                    CellStyle _style = getCellStyle(lOperationMode);
                    CellRange _range = this.grdRooms.Selection;

                    //overwrite RANGE if Group Blocking
                    if (lOperationMode == "GROUP_BLOCKING")
                    {
                        _range = validateGroupRange(_range);
                        if (_range.r1 == 0 &&
                            _range.r2 == 0 &&
                            _range.c1 == 0 &&
                            _range.c2 == 0)
                        {
                            //re-assign required rooms
                            loEventRoomRequirements = new GenericList<EventRoomRequirements>();
                            loEventRoomRequirements = loRoomRequirementFacade.getRoomRequirements(lGroupFolio.FolioID);
                            return;
                        }

                    }
                    //>> END overwrite


                    //>> check if has overlap a cell that has a color;
                    for (int i = _range.r1; i <= _range.r2; i++)
                    {
                        int _lastCol = _range.c2;
                        if (_lastCol % 2 == 1)
                        {
                            _lastCol--;
                        }

                        for (int c = _range.c1; c <= _lastCol; c++)
                        {
                            CellStyle _currentStyle = this.grdRooms.GetCellStyle(i, c);
                            if (_currentStyle != null && _currentStyle.Name != csNormalStyle.Name)
                            {
                                MessageBox.Show("Transaction failed.\r\nError message: Overlapping of schedules is not allowed.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    for (int i = _range.r1; i <= _range.r2; i++)
                    {

                        string _roomNo = this.grdRooms.GetDataDisplay(i, 1);
                        string _roomType = this.grdRooms.GetDataDisplay(i, 0);

                        string monthYearStart = this.grdRooms.GetDataDisplay(0, _range.c1);
                        string dateStart = this.grdRooms.GetDataDisplay(2, _range.c1);

                        string monthYearEnd = this.grdRooms.GetDataDisplay(0, _range.c2);
                        string dateEnd = this.grdRooms.GetDataDisplay(2, _range.c2);


                        string strStartDate = monthYearStart.Insert(monthYearStart.IndexOf(","), dateStart);
                        string strEndDate = monthYearEnd.Insert(monthYearEnd.IndexOf(","), dateEnd);

                        DateTime _startDate = DateTime.Parse(strStartDate);
                        DateTime _endDate = DateTime.Parse(strEndDate);

                        //create schedule here
                        Schedule oSchedule = new Schedule();
                        oSchedule.FromDate = _startDate;
                        oSchedule.ToDate = _endDate;
                        oSchedule.RoomID = _roomNo;
                        oSchedule.RoomType = _roomType;


                        //>> check if Schedule is CONTINUOUS for INDIVIDUAL RESERVATION
                        //>> or IN HOUSE
                        if (lOperationMode == "RESERVATION" ||
                            lOperationMode == "IN HOUSE" ||
                            lOperationMode == "ENGINEERING JOB" ||
                            lOperationMode == "WAIT LIST")
                        {

                            DateTime _lastScheduleDate = _startDate;
                            foreach (Schedule _previousSchedule in loScheduleCollection)
                            {
                                _lastScheduleDate = _previousSchedule.ToDate;
                            }

                            if (_lastScheduleDate != _startDate)
                            {
                                MessageBox.Show("Transaction failed.\r\n\r\nDates should be continuous.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (lOperationMode == "WAIT LIST")
                        {
                            lOperationMode = "RESERVATION";
                        }
                        //>> end check if Schedule is CONTINUOUS for INDIVIDUAL RESERVATION
                        this.loScheduleCollection.Add(oSchedule);


                        int _lastCol = _range.c2;
                        if (_lastCol % 2 == 1)
                        {
                            _lastCol--;
                        }

                        for (int c = _range.c1; c <= _lastCol; c++)
                        {
                            this.grdRooms.SetData(i, c, lOperationMode);
                            this.grdRooms.SetCellStyle(i, c, _style);
                        }
                        this.grdRooms.Select(i, _lastCol);


                    }//>> END for (int i = _range.r1; i <= _range.r2; i++)


                    // show block reason dialog here
                    switch (lOperationMode)
                    {
                        case "BLOCKING":
                            showBlockReason("NEW");
                            break;

                        case "GROUP_BLOCKING":
                            //add user confirmation b4 saving
                            processGroupBlocking(_range);

                            break;
                    }


                }//>>END if (this.tcAllRooms.SelectedIndex == 0)
                else //for function rooms
                {
                    CellStyle _style = getCellStyle(lOperationMode);
                    CellRange _range = this.grdFunctions.Selection;

                    //overwrite RANGE if Group Blocking
                    if (lOperationMode == "GROUP_BLOCKING")
                    {
                        _range = validateGroupRange(_range);
                        if (_range.r1 == 0 &&
                            _range.r2 == 0 &&
                            _range.c1 == 0 &&
                            _range.c2 == 0)
                        {
                            //re-assign required rooms
                            loEventRoomRequirements = new GenericList<EventRoomRequirements>();
                            loEventRoomRequirements = loRoomRequirementFacade.getRoomRequirements(lGroupFolio.FolioID);
                            return;
                        }

                    }
                    //>> END overwrite


                    //>> check if has overlap a cell that has a color;
                    for (int i = _range.r1; i <= _range.r2; i++)
                    {
                        int _lastCol = _range.c2;
                        //if (_lastCol % 2 == 1)
                        //{
                        //    _lastCol--;
                        //}

                        for (int c = _range.c1; c <= _lastCol; c++)
                        {
                            CellStyle _currentStyle = this.grdFunctions.GetCellStyle(i, c);
                            if (_currentStyle != null && _currentStyle.Name != csNormalStyle.Name)
                            {
                                MessageBox.Show("Transaction failed.\r\nError message: Overlapping of schedules in not allowed.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    for (int i = _range.r1; i <= _range.r2; i++)
                    {

                        string _roomNo = this.grdFunctions.GetDataDisplay(i, 1);
                        string _roomType = this.grdFunctions.GetDataDisplay(i, 0);

                        string monthYearStart = this.grdFunctions.GetDataDisplay(0, _range.c1);
                        string dateStart = this.grdFunctions.GetDataDisplay(2, _range.c1);

                        string monthYearEnd = this.grdFunctions.GetDataDisplay(0, _range.c2);
                        string dateEnd = this.grdFunctions.GetDataDisplay(2, _range.c2);


                        string strStartDate = monthYearStart.Insert(monthYearStart.IndexOf(","), dateStart);
                        string strEndDate = monthYearEnd.Insert(monthYearEnd.IndexOf(","), dateEnd);

                        DateTime _startDate = DateTime.Parse(strStartDate);
                        DateTime _endDate = DateTime.Parse(strEndDate);

                        string _strStartTime = this.grdFunctions.GetDataDisplay(3, _range.c1);
                        string _strEndTime = this.grdFunctions.GetDataDisplay(3, _range.c2);

                        DateTime _startTime = DateTime.Parse(_strStartTime + ":00");
                        DateTime _endTime = DateTime.Parse(_strEndTime + ":00");

                        //create schedule here
                        Schedule oSchedule = new Schedule();
                        oSchedule.FromDate = _startDate;
                        oSchedule.ToDate = _endDate;
                        oSchedule.RoomID = _roomNo;
                        oSchedule.RoomType = _roomType;
                        oSchedule.StartTime = _startTime;
                        oSchedule.EndTime = _endTime;

                        //>> check if Schedule is CONTINUOUS for INDIVIDUAL RESERVATION
                        //>> or IN HOUSE
                        if (lOperationMode == "RESERVATION" ||
                            lOperationMode == "IN HOUSE" ||
                            lOperationMode == "ENGINEERING JOB" ||
                            lOperationMode == "WAIT LIST")
                        {

                            DateTime _lastScheduleDate = _startDate;
                            foreach (Schedule _previousSchedule in loScheduleCollection)
                            {
                                _lastScheduleDate = _previousSchedule.ToDate;
                            }

                            if (_lastScheduleDate != _startDate)
                            {
                                MessageBox.Show("Transaction failed.\r\n\r\nDates should be continuous.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (lOperationMode == "WAIT LIST")
                        {
                            lOperationMode = "RESERVATION";
                        }
                        //>> end check if Schedule is CONTINUOUS for INDIVIDUAL RESERVATION
                        this.loScheduleCollection.Add(oSchedule);


                        int _lastCol = _range.c2;
                        //if (_lastCol % 2 == 1)
                        //{
                        //    _lastCol--;
                        //}

                        for (int c = _range.c1; c <= _lastCol; c++)
                        {
                            this.grdFunctions.SetData(i, c, lOperationMode);
                            this.grdFunctions.SetCellStyle(i, c, _style);
                        }
                        this.grdRooms.Select(i, _lastCol);


                    }//>> END for (int i = _range.r1; i <= _range.r2; i++)


                    // show block reason dialog here
                    switch (lOperationMode)
                    {
                        case "BLOCKING":
                            showBlockReason("NEW");
                            break;

                        case "GROUP_BLOCKING":
                            //add user confirmation b4 saving
                            processGroupBlocking(_range);

                            break;
                    }

                }
            }
            catch {}
		}

		private void processGroupBlocking(CellRange _range)
		{

			string roomsSelected = "";
			for (int i = _range.r1; i <= _range.r2; i++)
			{
				if (i == _range.r2)
				{
					if (roomsSelected != "")
					{ // remove last ', '
						roomsSelected = roomsSelected.Substring(0, roomsSelected.Length - 2);
						roomsSelected += " and " + this.grdRooms.GetDataDisplay(i, 1);
					}
					else
					{
						roomsSelected = this.grdRooms.GetDataDisplay(i, 1);
					}

				}
				else
				{
					roomsSelected += this.grdRooms.GetDataDisplay(i, 1) + ", ";
				}
			}

			string lblRoom = "room ";
			if (_range.r2 > _range.r1)
			{
				lblRoom = "rooms ";
			}
			DialogResult rsp = MessageBox.Show("Are you sure you want to block " + lblRoom + "  " + roomsSelected + "  for this event? ",
											   "Event Plus",
											   MessageBoxButtons.YesNoCancel,
											   MessageBoxIcon.Question);

			switch (rsp)
			{
				case DialogResult.Yes:
					//save to EventRooms Table & RoomBlocking
					RoomBlockCollection oRoomBlockCollection = new RoomBlockCollection();

					int blockid = oRoomBlockFacade.getNextBlockNo();
					string blockReason = lGroupFolio.GroupName + " [" + lGroupFolio.FolioID + "]";

					
					foreach (Schedule oSchedule in loScheduleCollection)
					{

						RoomBlock roomblock = new RoomBlock();
						roomblock.BlockID = blockid;
						roomblock.RoomID = oSchedule.RoomID;
                        //roomblock.BlockFrom = lGroupFolio.FromDate;
                        //roomblock.BlockTo = lGroupFolio.Todate;
                        roomblock.BlockFrom = dtpStartDate.Value;
                        roomblock.BlockTo = dtpEndDate.Value;
						roomblock.FolioID = lGroupFolio.FolioID;
						roomblock.Reason = blockReason;

						oRoomBlockCollection.Add(roomblock);

					}

					oRoomBlockCollection.AddBlockID(blockid);
					oRoomBlockCollection.AddReason(blockReason);
					oRoomBlockFacade.SaveRoomBlock(oRoomBlockCollection);

					//save to Event_Rooms
					EventRoomRequirementFacade oEventRoomRequirementFacade = new EventRoomRequirementFacade();

					foreach (EventRoomRequirements eventRoom in loEventRoomRequirements)
					{
						oEventRoomRequirementFacade.updateTotalBlockedRooms(
													 lGroupFolio.FolioID,
													 eventRoom.RoomType,
													 eventRoom.BlockedRooms);

					}
					

					updateCurrentDayRoomStatus();

					reloadCalendar();

					break;

				case DialogResult.No:
					this.Close();
					break;
				case DialogResult.Cancel:
					for (int i = _range.r1; i <= _range.r2; i++)
					{
						for (int c = _range.c1; c <= _range.c2; c++)
						{
							this.grdRooms.SetData(i, c, "");
							this.grdRooms.SetCellStyle(i, c, csNormalStyle);
						}
					}
					//re-assign required rooms
					loEventRoomRequirements = new GenericList<EventRoomRequirements>();
					loEventRoomRequirements = loRoomRequirementFacade.getRoomRequirements(lGroupFolio.FolioID);
					break;
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
			catch// (Exception ex)
			{
				//MessageBox.Show("Transaction"ex.Message);
			}
		}

		//added March 7, 2009
		// for Manual Room Blocking [per event]
		private CellRange validateGroupRange(CellRange pRange)
		{
			CellRange invalidRange =new CellRange();
			invalidRange.r1 = 0;
			invalidRange.r2 = 0;
			invalidRange.c1 = 0;
			invalidRange.c2 = 0;

			CellRange newRange = new CellRange();
			newRange.r1 = pRange.r1;
			newRange.r2 = pRange.r2;

			for (int i = pRange.r1; i <= pRange.r2; i++)
			{
				string roomType = this.grdRooms.GetDataDisplay(i, 0);
				string roomNo = this.grdRooms.GetDataDisplay(i, 1);

				//search roomtype from Required Rooms
				bool foundRoomType = false;
                bool hasExceed = false;
				foreach (EventRoomRequirements oEventRooms in loEventRoomRequirements)
				{
					if (oEventRooms.RoomType == roomType)
					{
						foundRoomType = true;
                        if (oEventRooms.NumberOfRooms < oEventRooms.BlockedRooms + 1)
                        {
                            hasExceed = true;
                            break;
                        }
                    }
				}
				

				if (!foundRoomType)
				{
					MessageBox.Show("Invalid selection for Group Reservation.\r\n\r\nError message: RoomType selected not found on required rooms." , "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return invalidRange;
				}

                if (hasExceed)
                {
                    MessageBox.Show("Invalid selection for Group Reservation.\r\n\r\nError message: Blocked rooms already exceeded number of rooms required.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return invalidRange;
                }

				// if selected whole row
				// create schedule base on Group Folio schedule 
				if (pRange.c1 == 2 && pRange.c2 == this.grdRooms.Cols.Count - 1)
				{
					int startCol = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, this.dtpStartDate.Value.Date, dtpStartDate.Value.Date);
					if (startCol > 0)
					{
						newRange.c1 = 3 + (startCol * 2);
					}
					else
					{
						newRange.c1 = 3;
					}


                    //int endCol = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, lGroupFolio.FromDate.Date, lGroupFolio.Todate.Date);
                    int endCol = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dtpStartDate.Value.Date, dtpEndDate.Value.Date);

					newRange.c2 = newRange.c1 + (endCol * 2);

					newRange.c2--;

				}
				else // create schedule base on Range selected
				{
					newRange.c1 = pRange.c1;
					newRange.c2 = pRange.c2;
				}

			}

			//check for invalid
			if (newRange.c1 == newRange.c2)
			{
				return invalidRange;
			}
			if (newRange.c1 < 2 || newRange.c2 > this.grdRooms.Cols.Count)
			{
				MessageBox.Show("Invalid selection.\r\nEvent date should be shown on the calendar for plotting.",
									"Event Plus",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);

				return invalidRange;
			}

			//check for invalid date selection
			for (int i = newRange.r1; i <= newRange.r2; i++)
			{

				string _roomNo = this.grdRooms.GetDataDisplay(i, 1);
				string _roomType = this.grdRooms.GetDataDisplay(i, 0);

				string monthYearStart = this.grdRooms.GetDataDisplay(0, newRange.c1);
				string dateStart = this.grdRooms.GetDataDisplay(2, newRange.c1);

				string monthYearEnd = this.grdRooms.GetDataDisplay(0, newRange.c2);
				string dateEnd = this.grdRooms.GetDataDisplay(2, newRange.c2);


				string strStartDate = monthYearStart.Insert(monthYearStart.IndexOf(","), dateStart);
				string strEndDate = monthYearEnd.Insert(monthYearEnd.IndexOf(","), dateEnd);

				DateTime _startDate = DateTime.Parse(strStartDate);
				DateTime _endDate = DateTime.Parse(strEndDate);


				if (_startDate.ToString("dd-MM-yyyy") != dtpStartDate.Value.ToString("dd-MM-yyyy") ||
                    _endDate.ToString("dd-MM-yyyy") != dtpEndDate.Value.ToString("dd-MM-yyyy"))
				{

					MessageBox.Show("Invalid selection.\r\nDate selection is not valid for this event.",
									"Event Plus",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);

					return invalidRange;
				}

			}


			for (int i = newRange.r1; i <= newRange.r2; i++)
			{
				string roomType = this.grdRooms.GetDataDisplay(i, 0);
				string roomNo = this.grdRooms.GetDataDisplay(i, 1);

				//search roomtype from Required Rooms
				foreach (EventRoomRequirements oEventRooms in loEventRoomRequirements)
				{
					if ( oEventRooms.RoomType == roomType )
					{
						
						oEventRooms.BlockedRooms++;
						break;
					}
				}

			}

			foreach (EventRoomRequirements oEventRooms in loEventRoomRequirements)
			{
				if (oEventRooms.BlockedRooms > oEventRooms.NumberOfRooms)
				{
					MessageBox.Show("Invalid selection.\r\nSelected Rooms exceed required rooms for room type '" + oEventRooms.RoomType + "'.", 
									"Event Plus", 
									MessageBoxButtons.OK, 
									MessageBoxIcon.Error);

					newRange.r1 = 0;
					newRange.r2 = 0;
					newRange.c1 = 0;
					newRange.c2 = 0;

					return newRange;
				}
			}



			return newRange;

		}

		bool hasClickDoneButton = false;
		private void btnOK_Click(object sender, EventArgs e)
		{

			hasClickDoneButton = true;

			//create Room Schedule here
			switch (lOperationMode)
			{
                case "WAIT LIST":
				case "RESERVATION":
				case "IN HOUSE":
				case "ENGINEERING JOB":
					this.Close();
					break;

				case "BLOCKING":
				case "GROUP_BLOCKING":
					this.Close();
					break;
			}


		}

		private void grdRooms_DoubleClick(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			try
			{
				CellRange _range = this.grdRooms.GetMergedRange(this.grdRooms.Row, this.grdRooms.Col);
				CellStyle _style = _range.Style;

				string _id = _range.UserData.ToString();

				switch (_style.BackColor.Name)
				{
					case "Brown": //>> Blocked Rooms

						int blockid = int.Parse(_id);
						Form frmReasonUI = new AddReasonUI(blockid);
						frmReasonUI.Text = "View Blocking Details";
						frmReasonUI.ShowDialog(this);

						viewFolioORBlockingInfo = true;

						break;

					case "DodgerBlue": //>> Reserved Rooms
					case "Cyan": //>> Occupied Rooms
						try
						{
							if (lOperationMode == "RESERVATION" ||
								lOperationMode == "IN HOUSE")
							{
								return;
							}


							string _folioId = _id;

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

									//viewFromCalendar = true;
									break;

								case "CORPORATE":
								case "GROUP":
                                    //_oGroupReservationUI = new GroupReservationUI(_oFolio.FolioID);
                                    //_oGroupReservationUI.MdiParent = this.MdiParent;
                                    //_oGroupReservationUI.Show();

                                    ReservationUI _oReservationUI = new ReservationUI(_oFolio.FolioID);
                                    _oReservationUI.MdiParent = this.MdiParent;
                                    _oReservationUI.Show();

									//viewFromCalendar = true;
									break;

								case "DEPENDENT":
									_oGroupReservationUI = new GroupReservationUI(_oFolio.MasterFolio);
									_oGroupReservationUI.MdiParent = this.MdiParent;
									_oGroupReservationUI.Show();

									//viewFromCalendar = true;
									break;
							}

							viewFolioORBlockingInfo = true;
						}
						catch { }

						break; // end "Reserved"


					case "Lime": // Out of Order Rooms

						break; //>> end "Out of Order Rooms"


					default:
						break;
				}

			}
			catch (Exception) { }
			finally
			{
				this.Cursor = Cursors.Default;
			}

		}

		//please add configuration [SHOW_TOOLTIP_ON_HOVER = YES/NO]
		private void grid_MouseHoverCell(object sender, EventArgs e)
		{
            C1FlexGrid hoverGrid = (C1FlexGrid)sender;

			//try
			//{
			//    CellRange _range = hoverGrid.GetMergedRange(hoverGrid.MouseRow, hoverGrid.MouseCol);
			//    CellStyle _style = _range.Style;


			//    string _id = _range.UserData.ToString();
			//    string _roomId = hoverGrid.GetDataDisplay(hoverGrid.Row, 1);

			//    string _title = "";
			//    string _folioInfo = "";
			//    switch (_style.BackColor.Name)
			//    {
			//        case "DodgerBlue":
			//            _title = "Reserved Room " + _roomId;
			//            _folioInfo = showFolioInformation(_id);

			//            break;
			//        case "Cyan":
			//            _title = "Occupied Room " + _roomId;
			//            _folioInfo = showFolioInformation(_id);
			//            break;

			//        case "Silver":
			//            _title = "Conflict Room Schedule " + _roomId;
			//            _folioInfo = showFolioInformation(_id);
			//            break;

			//    }

			//    tipHoverInfo.ToolTipTitle = _title;
			//    tipHoverInfo.SetToolTip(hoverGrid, _folioInfo);
			//    tipHoverInfo.ToolTipIcon = ToolTipIcon.Info;

			//}
			//catch { }

            try
            {
                CellRange _range = hoverGrid.GetMergedRange(hoverGrid.MouseRow, hoverGrid.MouseCol);
                CellStyle _style = _range.Style;
                string _roomId = hoverGrid.GetDataDisplay(hoverGrid.MouseRow, 1);
                string _title = "";

                if (hoverGrid.MouseCol == 1 && hoverGrid.MouseRow > 2 && _roomId!="")
                {
                    tipHoverInfo.Active = true;
                    _title = "Room Details ";
                    string _roomInfo = showRoomInformation(_roomId);
                    tipHoverInfo.ToolTipTitle = _title;
                    tipHoverInfo.SetToolTip(hoverGrid, _roomInfo);
                    tipHoverInfo.ToolTipIcon = ToolTipIcon.Info;
                    tipHoverInfo.AutomaticDelay = 100;
                }
                else
                {
                    tipHoverInfo.Active = false;
                }
            }
            catch { }

		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			try
			{
				oRoomBlockFacade = new RoomBlockFacade();
                string _roomId = "";
                string _roomType = "";
                CellRange _range;

                if (tcAllRooms.SelectedIndex == lFunctionTabIndex)
                {
                    _roomId = this.grdFunctions.GetDataDisplay(this.grdFunctions.Row, 1);
                    _roomType = this.grdFunctions.GetDataDisplay(this.grdFunctions.Row, 0);
                    _range = this.grdFunctions.Selection;
                }
                else
                {
                    _roomId = this.grdRooms.GetDataDisplay(this.grdRooms.Row, 1);
                    _roomType = this.grdRooms.GetDataDisplay(this.grdRooms.Row, 0);
                    _range = this.grdRooms.Selection;
                }

				
				CellStyle _style = _range.Style;

				if (_style.BackColor.Name == csBlockedStyle.BackColor.Name)
				{

					int _blockID = int.Parse(_range.UserData.ToString());

					IList<RoomBlock> oRoomBlockCollection = oRoomBlockFacade.getRoomBlockInfoById(_blockID.ToString());
					RoomBlock oRoomBlock = oRoomBlockCollection[0];

					DialogResult rsp = MessageBox.Show("Are you sure you want to remove blocking from Room " + _roomId + "?",
													   "Event Plus",
													   MessageBoxButtons.YesNo,
													   MessageBoxIcon.Question);

					if (rsp == DialogResult.Yes)
					{
						
						oRoomBlockFacade.DeleteRoomBlock(_blockID, _roomId);

						//>>for those rooms that are blocked by a group
						//>>if under a group, decrement the number of blocked rooms
						try
						{

							//string roomType = this.vsGrid.get_TextMatrix(vsGrid.Row, 0);
							//string folioID = blockName.Substring(blockName.IndexOf('[') + 1, 12);
							EventRoomRequirementFacade _oRoomRequirementsFacade = new EventRoomRequirementFacade();
							_oRoomRequirementsFacade.updateNumberOfBlockedRooms(oRoomBlock.FolioID, _roomType, 1);
						}
						catch { }

					}
				}
                else if (_style.BackColor.Name == csReservationStyle.BackColor.Name)
                {

                    string _id = _range.UserData.ToString();

                    Folio _oFolio = new Folio();
                    FolioFacade _oFolioFacade = new FolioFacade();

                    _oFolio = _oFolioFacade.GetFolio(_id);

                    if (_oFolio.FolioType != "DEPENDENT")
                    {
                        if (MessageBox.Show("Are you sure you want to set this reservation to Wait List?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool hasBalance = false;

                            decimal balance = 0;
                            foreach (SubFolio subF in _oFolio.SubFolios)
                            {
                                subF.Ledger = _oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                                balance = subF.Ledger.BalanceNet;
                                if (balance != 0)
                                {
                                    hasBalance = true;
                                }
                            }

                            if (hasBalance)
                            {
                                if (bool.Parse(ConfigVariables.gAllowDeAllocateWithBalance) == true)
                                {
                                    DialogResult rsp = MessageBox.Show("Guest still has unsettled account.\r\nDo you want to continue?", "Event Plus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (rsp == DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Cannot de-allocate room.\r\nGuest still has unsettled account.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            foreach (Schedule _oSchedule in _oFolio.Schedule)
                            {
                                _oSchedule.RoomID = "";
                                _oSchedule.BreakFast = "N";
                                _oSchedule.Rate = 0;
                            }
                            _oFolio.Status = "WAIT LIST";

                            _oFolioFacade.updateFolio(_oFolio);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("This will cancel the blocking for " + _oFolio.GroupName + ".\r\nDo you want to continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool hasBalance = false;

                            decimal balance = 0;
                            foreach (SubFolio subF in _oFolio.SubFolios)
                            {
                                subF.Ledger = _oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                                balance = subF.Ledger.BalanceNet;
                                if (balance != 0)
                                {
                                    hasBalance = true;
                                }
                            }

                            if (hasBalance)
                            {
                                if (bool.Parse(ConfigVariables.gAllowDeAllocateWithBalance) == true)
                                {
                                    DialogResult rsp = MessageBox.Show("Guest still has unsettled account.\r\nDo you want to continue?", "Event Plus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (rsp == DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Cannot de-allocate room.\r\nGuest still has unsettled account.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            string masterFolioID = _oFolio.MasterFolio;
                            string folioID = _oFolio.FolioID;

                            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
                            //_oFolio = new Folio();
                            _oFolio.Status = "DELETED";
                            _oFolio.FolioID = folioID;
                            _oFolio.UpdateTime = DateTime.Now;
                            _oFolioFacade.updateFolio(_oFolio);
                            _oRoomEventFacade.CancelRoomEvents(_oFolio.FolioID, "RESERVATION", "CANCELLED");

                            //>>for those rooms that are blocked by a group
                            //>>if under a group, decrement the number of blocked rooms
                            try
                            {
                                string RoomID = _roomId;
                                string roomType = _roomType;
                                EventRoomRequirementFacade _oRoomRequirementsFacade = new EventRoomRequirementFacade();
                                _oRoomRequirementsFacade.updateNumberOfBlockedRooms(masterFolioID, roomType, 1);
                            }
                            catch { }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Transaction failed.\r\nError message: Only blocked/reserved rooms are allowed to be removed.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
			catch //(Exception ex)
			{
				//MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			reloadCalendar();
		}


		private void grdRooms_Click(object sender, EventArgs e)
		{
			C1FlexGrid hoverGrid = (C1FlexGrid)sender;

            try
            {
                CellRange _range = hoverGrid.GetMergedRange(hoverGrid.MouseRow, hoverGrid.MouseCol);
                CellStyle _style = _range.Style;

                string _id = _range.UserData.ToString();
                string _roomId = hoverGrid.GetDataDisplay(hoverGrid.Row, 1);

                string _title = "";
                string _folioInfo = "";
                switch (_style.BackColor.Name)
                {
                    case "DodgerBlue":
                        _title = "Reserved Room " + _roomId;
                        _folioInfo = showFolioInformation(_id);

                        break;
                    case "Cyan":
                        _title = "Occupied Room " + _roomId;
                        _folioInfo = showFolioInformation(_id);
                        break;

                    case "Silver":
                        _title = "Conflict Room Schedule " + _roomId;
                        _folioInfo = showFolioInformation(_id);
                        break;

                    case "Lime":
                        _title = "Engineering Job " + _roomId;
                        _folioInfo = showEngineeringInfo(_id);
                        break;
                }

                tipHoverInfo.Active = true;
                tipHoverInfo.ToolTipTitle = _title;
                tipHoverInfo.SetToolTip(hoverGrid, _folioInfo);
                tipHoverInfo.ToolTipIcon = ToolTipIcon.Info;
            }
            catch { }
		}

		private void btnZoom_Click(object sender, EventArgs e)
		{
			//ROOMS
			int _col = this.grdRooms.Cols[2].WidthDisplay;

			// setup COLWIDTH for dates
			for (int c = 2; c <= this.grdRooms.Cols.Count - 1; c++)
			{
				this.grdRooms.Cols[c].Width = _col + 5;
			}

			//FUNCTIONS
			int _colFunc = this.grdFunctions.Cols[2].WidthDisplay;

			// setup COLWIDTH for dates
			for (int c = 2; c <= this.grdFunctions.Cols.Count - 1; c++)
			{
				this.grdFunctions.Cols[c].Width = _col + 5;
			}

		}

		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			//ROOMS
			int _col = this.grdRooms.Cols[2].WidthDisplay;
			// setup COLWIDTH for dates
			for (int c = 2; c <= this.grdRooms.Cols.Count - 1; c++)
			{
				this.grdRooms.Cols[c].Width = _col - 5;
			}

			//FUNCTIONS
			int _colFunc = this.grdFunctions.Cols[2].WidthDisplay;

			// setup COLWIDTH for dates
			for (int c = 2; c <= this.grdFunctions.Cols.Count - 1; c++)
			{
				this.grdFunctions.Cols[c].Width = _col - 5;
			}

		}


		#endregion

		private void btnSetup_Click(object sender, EventArgs e)
		{
			printGrid();
		}
		private void btnPrint_Click(object sender, EventArgs e)
		{
			printGrid();
		}

		public void printGrid()
		{
			C1.Win.C1FlexGrid.PrintGridFlags flags = C1.Win.C1FlexGrid.PrintGridFlags.FitToPage;
			flags = C1.Win.C1FlexGrid.PrintGridFlags.ShowPageSetupDialog;

			string header = "";
			string footer = "";

			header = "Room Availability as of " + DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToShortTimeString()).ToString();
			footer = "Powered by Event Plus Event Management System © 2010. All rights reserved.\r\nJinisys Softwares, Cebu City.Tel Nos. 63.32.232.0485. www.broadnet.biz";
			this.grdRooms.PrintGrid(@"c:\RoomAvailability.doc", flags, header, footer);

		}

		private void grdFunctions_DoubleClick(object sender, EventArgs e)
		{

			this.Cursor = Cursors.WaitCursor;

			try
			{
				CellRange _range = this.grdFunctions.GetMergedRange(this.grdFunctions.Row, this.grdFunctions.Col);
				CellStyle _style = _range.Style;

				string _id = _range.UserData.ToString();

				switch (_style.BackColor.Name)
				{
					case "Brown": //>> Blocked Rooms

						int blockid = int.Parse(_id);
						Form frmReasonUI = new AddReasonUI(blockid);
						frmReasonUI.Text = "View Blocking Details";
						frmReasonUI.ShowDialog(this);

						viewFolioORBlockingInfo = true;

						break;

					case "DodgerBlue": //>> Reserved Rooms
					case "Cyan": //>> Occupied Rooms
						try
						{
							if (lOperationMode == "RESERVATION" ||
								lOperationMode == "IN HOUSE")
							{
								return;
							}


							string _folioId = _id;

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

									//viewFromCalendar = true;
									break;

								case "CORPORATE":
								case "GROUP":
                                    //_oGroupReservationUI = new GroupReservationUI(_oFolio.FolioID);
                                    //_oGroupReservationUI.MdiParent = this.MdiParent;
                                    //_oGroupReservationUI.Show();

                                    //_oGroupReservationUI.FormClosed -= new System.Windows.Forms.FormClosedEventHandler(_oGroupReservationUI.GroupReservationUI_FormClosed);

                                    ReservationUI _oReservationUI = new ReservationUI(_oFolio.FolioID);
                                    _oReservationUI.MdiParent = this.MdiParent;
                                    _oReservationUI.Show();

									//_oGroupReservationUI.FormClosed -= new System.Windows.Forms.FormClosedEventArgs(_oGroupReservationUI.GroupReservationUI_Closed);
									//viewFromCalendar = true;
									break;

								case "DEPENDENT":
									_oGroupReservationUI = new GroupReservationUI(_oFolio.MasterFolio);
									_oGroupReservationUI.MdiParent = this.MdiParent;
									_oGroupReservationUI.Show();

									//viewFromCalendar = true;
									break;
							}

							viewFolioORBlockingInfo = true;
						}
						catch { }

						break; // end "Reserved"


					case "Lime": // Out of Order Rooms

						break; //>> end "Out of Order Rooms"


					default:
						break;
				}

			}
			catch (Exception) { }
			finally
			{
				this.Cursor = Cursors.Default;
			}

		}

        private void grdFunctions_Click(object sender, EventArgs e)
        {
            C1FlexGrid hoverGrid = (C1FlexGrid)sender;

            try
            {
                CellRange _range = hoverGrid.GetMergedRange(hoverGrid.MouseRow, hoverGrid.MouseCol);
                CellStyle _style = _range.Style;


                string _id = _range.UserData.ToString();
                string _roomId = hoverGrid.GetDataDisplay(hoverGrid.Row, 1);

                string _title = "";
                string _folioInfo = "";
                switch (_style.BackColor.Name)
                {
                    case "DodgerBlue":
                        _title = "Reserved Room " + _roomId;
                        _folioInfo = showCompanyFolioInformation(_id);

                        break;
                    case "Cyan":
                        _title = "Occupied Room " + _roomId;
                        _folioInfo = showCompanyFolioInformation(_id);
                        break;

                    case "Silver":
                        _title = "Conflict Room Schedule " + _roomId;
                        _folioInfo = showCompanyFolioInformation(_id);
                        break;

                }

                tipHoverInfo.ToolTipTitle = _title;
                tipHoverInfo.SetToolTip(hoverGrid, _folioInfo);
                tipHoverInfo.ToolTipIcon = ToolTipIcon.Info;

            }
            catch { }
        }

        private void tabFunction_Click(object sender, EventArgs e)
        {
            this.lblWeekToDisplay.Text = "Days to display :";
        }

        private void tabRooms_Click(object sender, EventArgs e)
        {
            this.lblWeekToDisplay.Text = "Weeks to display :";
        }

        private void grdFunctions_AfterSelChange(object sender, RangeEventArgs e)
        {
            deSelectRangeFunction();

            CellRange _range = this.grdFunctions.Selection;

            int _startRow = _range.r1;
            int _endRow = _range.r2;

            int _startCol = _range.c1;
            int _endCol = _range.c2;

            if (_startCol % 2 == 1)
                _startCol--;

            if (_endCol % 2 == 0)
                _endCol++;

            if (_startRow < 0 || _startCol < 0)
                return;

            for (int i = _startRow; i <= _endRow; i++)
            {
                this.grdFunctions.SetCellStyle(i, 1, csRowSelectedStyel);
            }

            for (int i = _startCol; i <= _endCol; i++)
            {
                this.grdFunctions.SetCellStyle(2, i, csRowSelectedStyel);
            }
        }

	
	}
}