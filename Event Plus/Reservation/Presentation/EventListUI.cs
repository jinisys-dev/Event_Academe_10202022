using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class EventListUI : Form
    {
        public EventListUI()
        {
            InitializeComponent();
        }

        #region "VARIABLES"
        private DataTable loEventList;
        private ReservationsFacade loReservationFacade = new ReservationsFacade();
        private DataTable loPrintableList;
        private string lPrintToDate;
        private string lPrintFromDate;

        #endregion
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {

        }

        private void EventListUI_Load(object sender, EventArgs e)
        {
            cboMonth.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            dtpFromDate.Enabled = false;
            dtpToDate.Enabled = false;

            cboYear.SelectedItem = DateTime.Now.Year.ToString();
            loadEventList();
            plotEventListToGrid();
        }

        private void loadEventList()
        {
            string _whrcond = "foliotype = 'GROUP'";
            if (rdoDateRange.Checked)
            {
                string _startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFromDate.Value);
                string _endDate = string.Format("{0:yyyy-MM-dd}", this.dtpToDate.Value);
                _whrcond += " and ( date(folio.fromdate) >= date('" + _startDate + "') and date(folio.fromdate) <= date('" + _endDate + "') )";
                lPrintFromDate = string.Format("{0:MMM dd, yyyy}", this.dtpFromDate.Value);
                lPrintToDate = string.Format("{0:MMM dd, yyyy}", this.dtpToDate.Value);
                //lPrintFromDate = this.dtpFromDate.Value;
                //lPrintToDate = this.dtpToDate.Value;
            }
            else
            {
                int _month = cboMonth.SelectedIndex + 1;
                _whrcond += " and (month(folio.fromdate) = " + _month.ToString() + " and year(folio.fromdate) = " + cboYear.Text + ") ";
                lPrintFromDate = cboMonth.Text.ToString().Substring(0, 3) + " 01, " + cboYear.Text;
                //lPrintFromDate = DateTime.Parse(cboYear.Text + "-" + _month + "-01");
                int _lastDay = DateTime.DaysInMonth(Convert.ToInt32(cboYear.Text), _month);

                /* Gene
                 * 2-Feb-12
                 * Changed date format
                 */
                //lPrintToDate = cboYear.Text + "-" + _month + "-" + _lastDay;
                lPrintToDate = cboMonth.Text.ToString().Substring(0, 3) + " " + _lastDay + ", " + cboYear.Text;
                //lPrintToDate = _toDate;
            }

            loEventList = loReservationFacade.GetGuestsList(_whrcond);
        }

        private void plotEventListToGrid()
        {
            //grdEventList.Clear();
            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            loPrintableList = loEventList;
            if (cboStatus.Text != "ALL")
            {
                DataView _dvEventList = loEventList.DefaultView;
                _dvEventList.RowFilter = "status = '" + cboStatus.Text + "'";
                _dvEventList.Sort = "fromdate ASC";
                loPrintableList = _dvEventList.ToTable();
            }

        	this.grdEventList.Rows.Count = 1;
			//int curProgress = 0;
			ProgressForm progress = new ProgressForm();
			if (loPrintableList.Rows.Count > 0)
			{
				this.grdEventList.Rows.Count = loPrintableList.Rows.Count + 1;
                int count = loPrintableList.Rows.Count + 1;
                progress = new ProgressForm(count, "Loading Event List......");
                progress.Height = 27;
                progress.Show();
			}

			int i = 1;
			//foreach (DataRowView dtRow in dtvGetFolio)
            foreach (DataRow dtRow in loPrintableList.Rows)
            {
                string _folioId = dtRow["folioID"].ToString();
                string _eventName = dtRow["groupName"].ToString();
                string _guestName = dtRow["GuestName"].ToString();
                string _companyName = dtRow["CompanyName"].ToString();
                DateTime _fromDate = DateTime.Parse(dtRow["fromdate"].ToString());
                DateTime _todate = DateTime.Parse(dtRow["todate"].ToString());
                string _arrivalTime = string.Format("{0:hh:mm tt}", DateTime.Parse(dtRow["folioETA"].ToString()));
                string _headMarketingOfficer = dtRow["sales_Executive"].ToString();
                string _status = dtRow["status"].ToString();
                
                string _rooms = "";
                _rooms = _oScheduleFacade.GetRoomFromSchedules(_folioId);
                dtRow["foliotype"] = _rooms; 

                /*0 Folio Id
                 *1 Event Name
                 *2 Guest Name
                 *3 Company
                 *4 Start Date
                 *5 End Date 
                 *6 ETA
                 *7 Room
                 *8 Head Marketing Officer
                 *9 Status
                */
                //-------------------------[ column 0 - Folio Id ]-----------------------------------'
                this.grdEventList.SetData(i, 0, _folioId);
                //-------------------------[ column 1 - Event Name ]---------------------------------'
                this.grdEventList.SetData(i, 1, _eventName);
                //-------------------------[ column 2 - Guest Name ]---------------------------------'
                //this.grdEventList.SetData(i, 2, _guestName);
                ////-------------------------[ column 3 - Company ]------------------------------------'
                //this.grdEventList.SetData(i, 3, _companyName);
                if(_guestName!= "")
                    this.grdEventList.SetData(i, 3, _guestName);
                else
                    this.grdEventList.SetData(i, 3, _companyName);
                //-------------------------[ column 4 - Start Date ]---------------------------------'
                this.grdEventList.SetData(i, 4, _fromDate);
                //-------------------------[ column 5 - End Date ]-----------------------------------'
                this.grdEventList.SetData(i, 5, _todate);
                //-------------------------[ column 6 - ETA ]----------------------------------------'
                this.grdEventList.SetData(i, 6, _arrivalTime);
                //-------------------------[ column 7 - Room ]---------------------------------------'
                this.grdEventList.SetData(i, 7, _rooms);
                //-------------------------[ column 8 - Head Marketing Officer ]---------------------'
                this.grdEventList.SetData(i, 8, _headMarketingOfficer);
                //-------------------------[ column 9 - Status ]-------------------------------------'
                this.grdEventList.SetData(i, 9, _status);

                i++;
                progress.updateProgress(i);
            }
            progress.Close();
        }

        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMonthly.Checked)
            {
                cboMonth.Enabled = true;
                cboYear.Enabled = true;
            }
            else
            {
                cboMonth.Enabled = false;
                cboYear.Enabled = false;
            }
            loadEventList();
            plotEventListToGrid();
        }

        private void rdoDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDateRange.Checked)
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
            else
            {
                dtpToDate.Enabled = false;
                dtpFromDate.Enabled = false;
            }
            loadEventList();
            plotEventListToGrid();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                plotEventListToGrid();
            }
            catch { }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadEventList();
                plotEventListToGrid();
            }
            catch { }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadEventList();
                plotEventListToGrid();
            }
            catch { }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            loadEventList();
            plotEventListToGrid();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpToDate.Value < dtpFromDate.Value)
            {
                MessageBox.Show("To date should be greater than from date", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            loadEventList();
            plotEventListToGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ReportViewer rptViewer;
        private EventList oEventList;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (loPrintableList != null)
            {
                //DateTime _reportDate = DateTime.Parse(reportDate);

                //this.MdiParent.Cursor = Cursors.WaitCursor;

                oEventList = new EventList();


                oEventList.Database.Tables[0].SetDataSource(loPrintableList);
                oEventList.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                oEventList.SetParameterValue(0, lPrintFromDate);
                oEventList.SetParameterValue(1, lPrintToDate);
                
                rptViewer = new ReportViewer();
                rptViewer.rptViewer.ReportSource = oEventList;
                rptViewer.MdiParent = this.MdiParent;
                rptViewer.Show();


                this.MdiParent.Cursor = Cursors.Default;
                //this.Close();
            }
        }
    }
}