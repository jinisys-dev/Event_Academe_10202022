using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class OccupancyForecastUI : Form
    {
        public OccupancyForecastUI()
        {
            InitializeComponent();
        }


        private void OccupancyForecastUI_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
            dtpEndDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
            initializeGrid();
        }

      
        private void initializeGrid()
        {
            this.vsGrid.Cols.Count = 13;
            this.vsGrid.Cols.Fixed = 1;
            this.vsGrid.Rows.Fixed = 2;
			this.vsGrid.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

            this.vsGrid.SetData(0, 0, "DATE");
			this.vsGrid.SetData(1, 0, "DATE");
			this.vsGrid.Cols[0].AllowMerging = true;
			

            //this.vsGrid.SetData(0, 1, "ARRIVAL");
            //this.vsGrid.SetData(0, 2, "ARRIVAL");
            //this.vsGrid.SetData(1, 1, "No. of Rooms");
            //this.vsGrid.SetData(1, 2, "No. of Pax");

            //this.vsGrid.SetData(0, 3, "DEPARTURE");
            //this.vsGrid.SetData(0, 4, "DEPARTURE");
            //this.vsGrid.SetData(1, 3, "No. of Rooms");
            //this.vsGrid.SetData(1, 4, "No. of Pax");

            //this.vsGrid.SetData(0, 5, "IN HOUSE");
            //this.vsGrid.SetData(0, 6, "IN HOUSE");
            //this.vsGrid.SetData(1, 5, "No. of Rooms");
            //this.vsGrid.SetData(1, 6, "No. of Pax");

            //this.vsGrid.SetData(0, 7, "OCCUPANCY");
            //this.vsGrid.SetData(1, 7, "PERCENTAGE");

            //this.vsGrid.SetData(0, 8, "ROOM");
            //this.vsGrid.SetData(1, 8, "SALES");

            this.vsGrid.SetData(0, 1, "ARRIVAL");
			this.vsGrid.SetData(0, 2, "ARRIVAL");
            this.vsGrid.SetData(0, 3, "ARRIVAL");
            this.vsGrid.SetData(1, 1, "No. of Rooms");
            this.vsGrid.SetData(1, 2, "No. of Func.");
            this.vsGrid.SetData(1, 3, "No. of Pax");

            this.vsGrid.SetData(0, 4, "WAIT LIST");
            this.vsGrid.SetData(1, 4, "WAIT LIST");

			this.vsGrid.SetData(0, 5, "DEPARTURE");
			this.vsGrid.SetData(0, 6, "DEPARTURE");
            this.vsGrid.SetData(0, 7, "DEPARTURE");
			this.vsGrid.SetData(1, 5, "No. of Rooms");
            this.vsGrid.SetData(1, 6, "No. of Func.");
			this.vsGrid.SetData(1, 7, "No. of Pax");

			this.vsGrid.SetData(0, 8, "IN HOUSE");
			this.vsGrid.SetData(0, 9, "IN HOUSE");
            this.vsGrid.SetData(0, 10, "IN HOUSE");
			this.vsGrid.SetData(1, 8, "No. of Rooms");
            this.vsGrid.SetData(1, 9, "No. of Groups");
			this.vsGrid.SetData(1, 10, "No. of Pax");

			this.vsGrid.SetData(0, 11, "OCCUPANCY");
			this.vsGrid.SetData(1, 11, "PERCENTAGE");

			this.vsGrid.SetData(0, 12, "ROOM");
			this.vsGrid.SetData(1, 12, "SALES");
			
			this.vsGrid.Rows[0].AllowMerging = true;
			for (int c = 0; c < this.vsGrid.Cols.Count; c++)
			{
				this.vsGrid.Cols[c].TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
			}
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string startDate = string.Format("{0:yyyy-MM-dd}", dtpStartDate.Value);
            string endDate = string.Format("{0:yyyy-MM-dd}", dtpEndDate.Value);

            long dif = BusinessSharedClasses.DateTimeClass.DateDiff(Jinisys.Hotel.BusinessSharedClasses.DateTimeClass.DateInterval.Day, dtpStartDate.Value, dtpEndDate.Value);
            if (dif < 0)
            {
                MessageBox.Show("Transaction failed.\r\n\r\nInvalid date.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //int runningTotalDepartureRooms = 0;
            //int runningTotalDeparturePax = 0;

            dif++;
            this.vsGrid.Rows.Count = (int)dif  + 2;
            for (int i = 0; i < dif; i++)
            { 
                string _date = string.Format("{0:MM/dd}",dtpStartDate.Value.AddDays(i));
                this.vsGrid.SetData(i + 2, 0, _date);

				DateTime _qDate = dtpStartDate.Value.AddDays(i).Date;
				string _queryDate = string.Format("{0:yyyy-MM-dd}", _qDate);
				


                // expected Arrivals
                ReportFacade oReportFacade = new ReportFacade();
                DataTable expectedArrival = oReportFacade.getExpectedArrivalForOccupancyForecast(_queryDate);

                string _roomsArrival = "0";
                string _paxArrival = "0";
                string _funcArrival = "0";
                string _waitList = "0";
                try
                {
                    _roomsArrival =  expectedArrival.Rows[0]["Rooms"].ToString();
                }
                catch { }
                try
                {
                    _paxArrival = expectedArrival.Rows[0]["Pax"].ToString();
                }
                catch { }
                try
                {
                    _funcArrival = expectedArrival.Rows[0]["functionRoom"].ToString();
                }
                catch { }
                try
                {
                    _waitList = expectedArrival.Rows[0]["waitList"].ToString();
                }
                catch { }

                
                //this.vsGrid.SetData(i + 2, 1,_roomsArrival);
                //this.vsGrid.SetData(i + 2, 2, _paxArrival);

                this.vsGrid.SetData(i + 2, 1, _roomsArrival);
                this.vsGrid.SetData(i + 2, 2, _funcArrival);
                this.vsGrid.SetData(i + 2, 3, _paxArrival);
                this.vsGrid.SetData(i + 2, 4, _waitList);

                // expected departures
                DataTable expectedDeparture = oReportFacade.getExpectedDepartureForOccupancyForecast(_queryDate);

                string _roomsDeparture = "0";
                string _paxDeparture = "0";
                string _funcDeparture = "0";
                try
                {
                    _roomsDeparture = expectedDeparture.Rows[0]["Rooms"].ToString();
                }
                catch { }
                try
                {
                    _paxDeparture = expectedDeparture.Rows[0]["Pax"].ToString();
                }
                catch { }
                try
                {
                    _funcDeparture = expectedDeparture.Rows[0]["functionRoom"].ToString();
                }
                catch { }
                //runningTotalDepartureRooms = int.Parse(_roomsDeparture);
                //runningTotalDeparturePax = int.Parse(_paxDeparture);

				this.vsGrid.SetData(i + 2, 5, _roomsDeparture);
                this.vsGrid.SetData(i + 2, 6, _funcDeparture);
				this.vsGrid.SetData(i + 2, 7, _paxDeparture);

                // inhouse
                DataTable expectedInHouse = oReportFacade.getExpectedInHouseForOccupancyForecast(_queryDate);

                int _roomsInHouse = 0;
                int _paxInHouse = 0;
                int _funcInHouse = 0;
                try
                {
                    _roomsInHouse = int.Parse(expectedInHouse.Rows[0]["Rooms"].ToString());
                }
                catch { }
                try
                {
                    _paxInHouse = int.Parse(expectedInHouse.Rows[0]["Pax"].ToString());
                }
                catch { }
                try
                {
                    _funcInHouse = int.Parse(expectedInHouse.Rows[0]["functionRoom"].ToString());
                }
                catch { }
                _roomsInHouse -= int.Parse(_roomsDeparture);
                _paxInHouse -= int.Parse(_paxDeparture);


				this.vsGrid.SetData(i + 2, 8, _roomsInHouse.ToString());
                this.vsGrid.SetData(i + 2, 9, _funcInHouse.ToString());
				this.vsGrid.SetData(i + 2, 10, _paxInHouse.ToString());

                int roomCount = oReportFacade.getRoomCount();

                double percentOccupancy = ((double)_roomsInHouse / (double)roomCount) * 100;

				this.vsGrid.SetData(i + 2, 11, percentOccupancy.ToString("N") + " %");


				DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
				long _diff = 0;
				_diff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _qDate,_auditDate);

				double _roomSales = 0;
				if (_diff > 0)
				{
					_roomSales = oReportFacade.getActualRoomSalesOccupancyForecast(_queryDate);
				}
				else
				{
					_roomSales = oReportFacade.getExpectedRoomSalesOccupancyForecast(_queryDate);
				}

				this.vsGrid.SetData(i + 2, 12, _roomSales.ToString("N"));


            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ////this.MdiParent.Cursor = Cursors.WaitCursor;

			this.btnView_Click(sender, e);

            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("Date");

            dtReport.Columns.Add("ArrivalRoom",typeof(System.Int32));
            dtReport.Columns.Add("ArrivalFunction", typeof(System.Int32));
            dtReport.Columns.Add("ArrivalPax", typeof(System.Int32));

            dtReport.Columns.Add("DepartureRoom", typeof(System.Int32));
            dtReport.Columns.Add("DepartureFunction", typeof(System.Int32));
            dtReport.Columns.Add("DeparturePax", typeof(System.Int32));

            dtReport.Columns.Add("InHouseRoom", typeof(System.Int32));
            dtReport.Columns.Add("InHouseGroup", typeof(System.Int32));
            dtReport.Columns.Add("InHousePax", typeof(System.Int32));

            dtReport.Columns.Add("PercentOccupancy", typeof(System.Double));
			dtReport.Columns.Add("RoomSales", typeof(System.Double));

            int row = this.vsGrid.Rows.Count - 2;
            for (int i = 0; i < row; i++)
            {
                DataRow newRow = dtReport.NewRow();
                newRow["Date"] = this.vsGrid.GetDataDisplay(i + 2, 0);

				newRow["ArrivalRoom"] = this.vsGrid.GetDataDisplay(i + 2, 1);
                newRow["ArrivalFunction"] = this.vsGrid.GetDataDisplay(i + 2, 2);
				newRow["ArrivalPax"] = this.vsGrid.GetDataDisplay(i + 2, 3);

				newRow["DepartureRoom"] = this.vsGrid.GetDataDisplay(i + 2, 5);
                newRow["DepartureFunction"] = this.vsGrid.GetDataDisplay(i + 2, 6);
				newRow["DeparturePax"] = this.vsGrid.GetDataDisplay(i + 2, 7);

				newRow["InHouseRoom"] = this.vsGrid.GetDataDisplay(i + 2, 8);
                newRow["InHouseGroup"] = this.vsGrid.GetDataDisplay(i + 2, 9);
				newRow["InHousePax"] = this.vsGrid.GetDataDisplay(i + 2, 10);
				
                newRow["PercentOccupancy"] = this.vsGrid.GetDataDisplay(i + 2, 11).Substring(0, this.vsGrid.GetDataDisplay(i + 2, 11).Length - 2);
				newRow["RoomSales"] = this.vsGrid.GetDataDisplay(i + 2, 12);


                dtReport.Rows.Add(newRow);

            }
            string paramDate = "for the period " + this.dtpStartDate.Value.ToShortDateString() + "  to  " + this.dtpEndDate.Value.ToShortDateString();



            // pass datatable to report document
            ReportFacade oReportFacade = new ReportFacade();
            ReportViewer rptViewerUI = new ReportViewer();
            rptViewerUI.rptViewer.ReportSource = oReportFacade.getOccupancyForecast(dtReport,paramDate);
            rptViewerUI.MdiParent = this.MdiParent;
            rptViewerUI.Show();


        }

        private void OccupancyForecastUI_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}