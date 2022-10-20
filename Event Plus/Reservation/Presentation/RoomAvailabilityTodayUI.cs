using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class RoomAvailabilityTodayUI : Form
    {
        public RoomAvailabilityTodayUI()
        {
            InitializeComponent();
        }

        private void RoomAvailabilityUI_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }


        CalendarFacade oCalendarFacade;
        RoomFacade oRoomFacade;
        private void RoomAvailabilityUI_Load(object sender, EventArgs e)
        {
            //this.dtpFromDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			int tempNumDays = (int)this.nudDays.Value;


            int numDays = 7;
            try
            {
                numDays = int.Parse(ConfigVariables.gShowRoomAvailabilityDays);
            }
            catch
            { }

			this.nudDays.Value = numDays;

			//this.dtpToDate.Value = this.dtpFromDate.Value.AddDays(numDays);

			this.chkShowAtStartUp.Checked = ConfigVariables.gShowRoomAvailabilityAtStartUp == "YES" ? true : false ;


			if (tempNumDays == numDays)
			{
				nudDays_ValueChanged(this, e);
			}
			
        }

        private void showAvailability()
        {
            //this.MdiParent.Cursor = Cursors.WaitCursor;

            oRoomFacade = new RoomFacade();
            oCalendarFacade = new CalendarFacade();

            DataSet dsRooms = (DataSet)oRoomFacade.loadObject();
            DataTable oRooms = dsRooms.Tables[0];

			// filter all ROOMS ONLY
			DataView dtvRooms = oRooms.DefaultView;
			dtvRooms.RowStateFilter = DataViewRowState.OriginalRows;
			dtvRooms.RowFilter = "RoomTypeCode <> 'FUNCTION'";


            DataTable roomAvailability = new DataTable("RoomAvailability");
            roomAvailability.Columns.Add("RoomID", typeof(System.String));
            roomAvailability.Columns.Add("RoomType", typeof(System.String));
            roomAvailability.Columns.Add("Status", typeof(System.String));
			//roomAvailability.Columns.Add("RateAmount", typeof(System.decimal));
            roomAvailability.Columns.Add("Days", typeof(System.String));
			


            DateTime fromDate = this.dtpFromDate.Value.Date;
            DateTime toDate = this.dtpToDate.Value.Date;
			long dif = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, fromDate, toDate) ;

            
            //foreach (DataRow drowRooms in oRooms.Rows)
			foreach (DataRowView drowRooms in dtvRooms)
            {
                bool availableOnFromDate = false;
                int availableDays = 0;
                string roomId = drowRooms["roomid"].ToString();
				string roomType = drowRooms["roomtypecode"].ToString(); ;
				
                for (int i = 0; i < dif; i++)
                {
                    string paramDate = string.Format("{0:yyyy-MM-dd}", fromDate.AddDays(i));

					DataTable dtNxtAvailability = oCalendarFacade.getRoomEventByRoomForAvailability(paramDate, roomId);

                    bool isAvailable = true;
                    foreach (DataRow dRow in dtNxtAvailability.Rows)
                    {
						string _tempEventType = dRow["eventtype"].ToString();
                        if ( _tempEventType != "" )
                        {
                            isAvailable = false;
                            break;
                        } // end inner if

                    }// end foreach

                    if (isAvailable)
                    {
                        if (i == 0)
                            availableOnFromDate = true;

                        availableDays++;
                    }
                    else
                    {
                        break;
                    }
                }//end for

                // add to ROOM AVAILABILITY TABLE
                if (availableOnFromDate)
                {
                    DataRow newRow = roomAvailability.NewRow();
                    newRow["RoomID"] = roomId;
                    newRow["RoomType"] = drowRooms["roomtypecode"].ToString();
                    newRow["Status"] = drowRooms["stateflag"].ToString().Substring(0,1) + drowRooms["cleaningstatus"].ToString().Substring(0,1);
                    newRow["Days"] = availableDays.ToString();
					//newRow["RateAmount"] = drowRooms["rateamount"].ToString();

                    roomAvailability.Rows.Add(newRow);
                }
              
            }
            //this.grdAvailability.Rows = roomAvailability.Rows.Count + 1;
            
            int ctr = 1;
            int rowCount = roomAvailability.Rows.Count;
            int div = rowCount / 3;
            if ((rowCount % 3) > 0)
                div++;

            this.grdAvailability.Rows = div + 1;
            int div2 = div + div;
            int row = 1;
            int col = 0;

			DataView dtvRoomAvailability = roomAvailability.DefaultView;
			//dtvRoomAvailability.RowStateFilter = DataViewRowState.OriginalRows;
			//dtvRoomAvailability.RowFilter
			dtvRoomAvailability.Sort = "RoomType, RoomID";

            //foreach (DataRow _dRow in roomAvailability.Rows)
			foreach (DataRowView dRow in dtvRoomAvailability)
            {
                string _roomID = dRow["RoomID"].ToString();
                string _roomType = dRow["RoomType"].ToString();
                string _status = dRow["Status"].ToString();
                string _daysAvailable = dRow["Days"].ToString();

                int intDaysAvailable = int.Parse(_daysAvailable);
                switch (intDaysAvailable)
                { 
                    case 1:
                        _daysAvailable = "1 DAY";
                        break;
                    case 7:
                        _daysAvailable = "1 WEEK";
                        break;
                    default:
                        _daysAvailable += " DAYS";
                        break;
                }

                // this is for Columns [3 columns]
                if (ctr > div)
                {
                    // 3rd Column
                    if (ctr > div2)
                    {
                        if (col != 10)
                        {
                            row = 1;
                            col = 10;
                        }
                    }
                    else // 2nd column
                    {
                        if (col != 5) // only gets in here
                        {
                            row = 1;
                            col = 5;
                        }
                    }
                }
                this.grdAvailability.set_TextMatrix(row, 0 + col, _roomID);
                this.grdAvailability.set_TextMatrix(row, 1 + col, _roomType);
                this.grdAvailability.set_TextMatrix(row, 2 + col, _status);
                this.grdAvailability.set_TextMatrix(row, 3 + col, _daysAvailable);

                this.grdAvailability.Select(row, 0 + col);
                if (_status == "VD" || _status == "OD")
                    this.grdAvailability.CellBackColor = Color.Red;
                else
                    this.grdAvailability.CellBackColor = Color.White;

                ctr++;
                row++;
            }

            this.grdAvailability.AllowSelection = false;
         
            this.MdiParent.Cursor = Cursors.Default;

			if (this.grdAvailability.Rows > 1)
			{
				this.grdAvailability.Select(0, 0);
			}
        }

        private void RoomAvailabilityUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            string showAtStartUp = this.chkShowAtStartUp.Checked ? "YES" : "NO";
            if (showAtStartUp != ConfigVariables.gShowRoomAvailabilityAtStartUp)
            {
                try
                {
                    //updates table value SHOW_ROOM_AVAILABILITY_AT_START_UP
                    ConfigVariables.updateConfigKeyValue("SHOW_ROOM_AVAILABILITY_AT_START_UP", showAtStartUp);
                    ConfigVariables.gShowRoomAvailabilityAtStartUp = showAtStartUp;

                }
                catch
                { }
            }
        }

		private void nudDays_ValueChanged(object sender, EventArgs e)
		{
			this.dtpFromDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);

			int numDays = (int)this.nudDays.Value;
			
			this.dtpToDate.Value = this.dtpFromDate.Value.AddDays(numDays);

			showAvailability();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			nudDays_ValueChanged(sender, e);
		}
        
    }

}