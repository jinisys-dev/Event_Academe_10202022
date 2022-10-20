using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.BusinessSharedClasses;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class RoomHistoryUI : Form
    {
        public RoomHistoryUI()
        {
            InitializeComponent();
        }


        //private Room oRoom;

        private RoomFacade oRoomFacade;
        private FolioFacade oFolioFacade;
        private DataView dtView;
        private DataView dtViewHousekeeper;
        private DataView dtViewEngineeringJobs;
        private void RoomHistoryUI_Load(object sender, EventArgs e)
        {
            ArrayList roomList = new ArrayList();
            //oRoom = new Room();
            oRoomFacade = new RoomFacade();

            roomList = oRoomFacade.getRoomIDs();


            this.grdRoomList.Rows.Count = roomList.Count + 1;
            for (int i = 0; i < roomList.Count; i++)
            {
                this.grdRoomList.SetData(i+1, 0, roomList[i].ToString());
                //this.grdRoomHistory.set_RowHeight(_ctr+1, 24);
            }

            oFolioFacade = new FolioFacade();
            dtView = oFolioFacade.getRoomHistory().DefaultView;
            dtViewHousekeeper = oFolioFacade.getRoomHousekeeperHistory().DefaultView;
            dtViewEngineeringJobs = oFolioFacade.getEngineeringJobsHistory().DefaultView;

            grdRoomList.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 0);
            grdRoomList_RowColChange(sender, e);

            if (ConfigVariables.gIsEMMOnly == "true")
            {
                tabRoomHistory.Controls.Remove(tabHousekeeper);
            }
        }


        private void grdRoomList_RowColChange(object sender, EventArgs e)
        {
            string roomId = "";

            try
            {
                roomId = this.grdRoomList.GetDataDisplay(this.grdRoomList.Row, 0);


                //MessageBox.Show(roomId);
                if (dtView != null)
                {
                    loadAccomodationList(roomId);
                    loadHousekeepersList(roomId);
                    loadEngineeringJobsList(roomId);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Description: " + ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private object loadAccomodationList(string a_RoomId)
        {
            string filterValue = a_RoomId;

            dtView.RowStateFilter = DataViewRowState.OriginalRows;
            dtView.RowFilter = "RoomId = '" + filterValue + "'" ;

            DataRowView dtr;
            this.grdRoomHistory.Rows.Count = dtView.Count + 1;
            int i = 1;
            foreach (DataRowView tempLoopVar_dtr in dtView)
            {
                dtr = tempLoopVar_dtr;
                this.grdRoomHistory.SetData(i,0,dtr["FolioId"].ToString());
                this.grdRoomHistory.SetData(i, 1, dtr["GuestsName"].ToString());
                this.grdRoomHistory.SetData(i, 2, dtr["FromDate"].ToString());
                this.grdRoomHistory.SetData(i, 3, dtr["ToDate"].ToString());
                this.grdRoomHistory.SetData(i, 4, dtr["Status"].ToString());
                
                i++;
            }
            grdRoomHistory.AutoSizeCols();
            return null;
        }

        private object loadHousekeepersList(string a_RoomId)
        {
            string filterValue = a_RoomId;

            dtViewHousekeeper.RowStateFilter = DataViewRowState.OriginalRows;
            dtViewHousekeeper.RowFilter = "RoomId = '" + filterValue + "'";

            DataRowView dtr;
            this.grdHousekeepers.Rows.Count = dtViewHousekeeper.Count + 1;
            int i = 1;
            foreach (DataRowView tempLoopVar_dtr in dtViewHousekeeper)
            {
                dtr = tempLoopVar_dtr;
                this.grdHousekeepers.SetData(i, 0, dtr["Housekeeper"].ToString());
                this.grdHousekeepers.SetData(i, 1, dtr["housekeepingdate"].ToString());
                this.grdHousekeepers.SetData(i, 2, dtr["starttime"].ToString());
                this.grdHousekeepers.SetData(i, 3, dtr["endtime"].ToString());
                this.grdHousekeepers.SetData(i, 4, dtr["elapsedtime"].ToString() + " min.");
                this.grdHousekeepers.SetData(i, 5, dtr["memo"].ToString());
                this.grdHousekeepers.SetData(i, 6, dtr["updatedby"].ToString());

                i++;
            }
            grdHousekeepers.AutoSizeCols();
            return null;
        }

        private object loadEngineeringJobsList(string pRoomID)
        {
            string filterValue = pRoomID;

            dtViewEngineeringJobs.RowStateFilter = DataViewRowState.OriginalRows;
            dtViewEngineeringJobs.RowFilter = "RoomId = '" + filterValue + "'";

            DataRowView dtr;
            this.grdEngineeringJobs.Rows.Count = dtViewEngineeringJobs.Count + 1;
            int i = 1;
            foreach (DataRowView tempLoopVar_dtr in dtViewEngineeringJobs)
            {
                dtr = tempLoopVar_dtr;
                this.grdEngineeringJobs.SetData(i, 0, dtr["servicename"].ToString());
                this.grdEngineeringJobs.SetData(i, 1, dtr["assignedperson"].ToString());
                this.grdEngineeringJobs.SetData(i, 2, dtr["startdate"].ToString());
                this.grdEngineeringJobs.SetData(i, 3, dtr["enddate"].ToString());
                this.grdEngineeringJobs.SetData(i, 4, dtr["starttime"].ToString());
                this.grdEngineeringJobs.SetData(i, 5, dtr["endtime"].ToString());

                i++;
            }
            grdEngineeringJobs.AutoSizeCols();
            return null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdRoomHistory_DoubleClick(object sender, EventArgs e)
        {

        }

        public void viewFolioDetails(string a_FolioId)
        {
            try
            {
                //this.MdiParent.Cursor = Cursors.WaitCursor;
                Jinisys.Hotel.Reports.BusinessLayer.ReportFacade oReportFacade = new Jinisys.Hotel.Reports.BusinessLayer.ReportFacade();
                Jinisys.Hotel.Reports.Presentation.ReportViewer ViewBillUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                ViewBillUI.MdiParent = this.MdiParent;
                ViewBillUI.rptViewer.ReportSource = oReportFacade.getIndividualGuestBill(a_FolioId, "A");
                ViewBillUI.Show();

                //this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ viewFolioDetails() " + ex.Message);
            }
        }

		private void RoomHistoryUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

        private void btnFolio_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfigVariables.gIsEMMOnly == "true")
                {
                    string _folioID = grdRoomHistory.GetDataDisplay(grdRoomHistory.Row, 0).ToString();
                    GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_folioID);
                    _oGroupReservationUI.MdiParent = this.MdiParent;
                    _oGroupReservationUI.Show();

                    this.Close();

                    return;
                }
                else
                {
                    string folioId = this.grdRoomHistory.GetDataDisplay(this.grdRoomHistory.Row, 0);

                    viewFolioDetails(folioId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Description: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
      
            if (DateTime.Parse(dtpTo.Text) < DateTime.Parse(dtpFrom.Text))
            {
                dtpFrom.Text = dtpTo.Text; 
            }

            string roomId = this.grdRoomList.GetDataDisplay(this.grdRoomList.Row, 0);
            getDateRange(roomId);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(dtpFrom.Text) > DateTime.Parse(dtpTo.Text))
            {
                dtpTo.Text = dtpFrom.Text;
            }
            string roomId = this.grdRoomList.GetDataDisplay(this.grdRoomList.Row, 0);
            getDateRange(roomId);
        }

        public void getDateRange(string pRoomID)
        {
            string filterValue = "";

            string _fromDate = DateTime.Parse(dtpFrom.Text).ToString();
            string _toDate = DateTime.Parse(dtpTo.Text).ToString();

            dtView.RowStateFilter = DataViewRowState.OriginalRows;
            dtView.RowFilter = "RoomId = '" + pRoomID + "' AND ((ToDate >= '" + _fromDate + "' AND  ToDate <= '" + _toDate + "')"+
                                                         "AND (FromDate >= '" + _fromDate + "' AND  FromDate <= '" + _toDate + "'))";
            DataRowView dtr;
            this.grdRoomHistory.Rows.Count = dtView.Count + 1;
            int i = 1;
            foreach (DataRowView tempLoopVar_dtr in dtView)
            {
                dtr = tempLoopVar_dtr;
                this.grdRoomHistory.SetData(i, 0, dtr["FolioId"].ToString());
                this.grdRoomHistory.SetData(i, 1, dtr["GuestsName"].ToString());
                this.grdRoomHistory.SetData(i, 2, dtr["FromDate"].ToString());
                this.grdRoomHistory.SetData(i, 3, dtr["ToDate"].ToString());
                this.grdRoomHistory.SetData(i, 4, dtr["Status"].ToString());

                i++;
            }
            grdRoomHistory.AutoSizeCols();
      
        }

    }
}