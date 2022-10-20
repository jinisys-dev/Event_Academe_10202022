using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class InHouseForeCastUI : Form
    {
        public InHouseForeCastUI()
        {
            InitializeComponent();
        }

        ReportFacade oReportFacade;
        DataTable dtInhouse = null;
        string reportDate = null;
        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }

        ReportViewer rptViewer;
        private InHouseGuestsList oInHouseGuestList;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtInhouse != null)
            {
                DateTime _reportDate = DateTime.Parse(reportDate);

                //this.MdiParent.Cursor = Cursors.WaitCursor;

                oInHouseGuestList = new InHouseGuestsList();

                oReportFacade = new ReportFacade();
                DataTable _dtInHouse = oReportFacade.getParamInHouseGuests(_reportDate);

                oInHouseGuestList.Database.Tables[0].SetDataSource(_dtInHouse);
                oInHouseGuestList.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = oInHouseGuestList;
                oReportFacade.setSubReport(ref rpt, oReportFacade.getParamInHouseGroups(_reportDate), true);

                oInHouseGuestList.SetParameterValue(0, _reportDate);

                rptViewer = new ReportViewer();
                rptViewer.rptViewer.ReportSource = oInHouseGuestList;
                rptViewer.MdiParent = this.MdiParent;
                rptViewer.Show();


                this.MdiParent.Cursor = Cursors.Default;
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void InHouseForeCastUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void InHouseForeCastUI_Load(object sender, EventArgs e)
		{
            dtpForeCastDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
            cboFilter.Text = "";
            cboFilter.Items.Clear();
            showInhouseForecast();
		}

		private void showInhouseForecast()
		{
            if (ConfigVariables.gIsEMMOnly == "true")
            {
                lblFilter.Visible = true;
                cboFilter.Visible = true;
            }
            else
            {
                lblFilter.Visible = false;
                cboFilter.Visible = false;
            }

			dtInhouse = new DataTable();
			oReportFacade = new ReportFacade();
			reportDate = string.Format("{0:yyyy-MM-dd}", this.dtpForeCastDate.Value);

			dtInhouse = oReportFacade.getInhouseGuestsForecast(reportDate);
            DataView _oDtView = dtInhouse.DefaultView;
            _oDtView.RowStateFilter = DataViewRowState.OriginalRows;
            if (cboFilter.Text != "")
            {
                _oDtView.RowFilter = "eventType = '" + cboFilter.Text + "'";
            }

            //this.grdInHouse.Rows.Count = dtInhouse.Rows.Count + 1;
            this.grdInHouse.Rows.Count = _oDtView.Count + 1;

			int i = 1;
            double _totalPax = 0;
            double _totalRooms = 0;
            double _totalWaitList = 0;
            double _totalGroups = 0;
            double _totalAttendees = 0;

            foreach (DataRowView dRowView in _oDtView)
			{
				this.grdInHouse.SetData(i, 0, dRowView["RoomId"].ToString());
				this.grdInHouse.SetData(i, 1, dRowView["GuestName"].ToString());
				this.grdInHouse.SetData(i, 2, dRowView["CompanyName"].ToString());
				this.grdInHouse.SetData(i, 3, dRowView["Folioid"].ToString());
				this.grdInHouse.SetData(i, 4, string.Format("{0:dd-MMM-yy}", DateTime.Parse(dRowView["ArrivalDate"].ToString())));
				this.grdInHouse.SetData(i, 5, string.Format("{0:dd-MMM-yy}", DateTime.Parse(dRowView["DepartureDate"].ToString())));
				this.grdInHouse.SetData(i, 6, dRowView["NoOfAdults"].ToString());
				this.grdInHouse.SetData(i, 7, string.Format("{0:#,##0.00}", double.Parse(dRowView["Rate"].ToString())));
				this.grdInHouse.SetData(i, 8, dRowView["Status"].ToString());
				this.grdInHouse.SetData(i, 9, dRowView["Remarks"].ToString());
                this.grdInHouse.SetData(i, 10, dRowView["EventType"].ToString());
                this.grdInHouse.SetData(i, 11, dRowView["totalAttendees"].ToString());

                _totalPax += double.Parse(dRowView["NoOfAdults"].ToString());

                if (dRowView["Status"].ToString() == "WAIT LIST" && dRowView["FolioType"].ToString() != "GROUP")
                {
                    _totalWaitList++;
                    _totalRooms--;
                }

                if (dRowView["FolioType"].ToString() == "GROUP")
                {
                    _totalGroups++;
                }

                if (dRowView["FolioType"].ToString() != "GROUP")
                {
                    _totalRooms++;
                }

                //newly added by genny 08.14.2010
                _totalAttendees += double.Parse(dRowView["totalAttendees"].ToString());
                if (!cboFilter.Items.Contains(dRowView["EventType"].ToString()))
                {
                    cboFilter.Items.Add(dRowView["EventType"].ToString());
                }

				i++;
			}

            txtTotalPax.Text = _totalPax.ToString();
            txtTotalRooms.Text = _totalRooms.ToString();
            txtWaitList.Text = _totalWaitList.ToString();
            txtGroups.Text = _totalGroups.ToString();
            txtAttendees.Text = _totalAttendees.ToString();
            grdInHouse.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 4, 2);
		}

		private void dtpForeCastDate_ValueChanged(object sender, EventArgs e)
		{
            cboFilter.Text = "";
            cboFilter.Items.Clear();
            showInhouseForecast();
        }

        private void showAttendees()
        {
            double _totalAttendees = 0;
            foreach (C1.Win.C1FlexGrid.Row _row in grdInHouse.Rows)
            {
                if (_row.Index != 0)
                {
                    _totalAttendees += double.Parse(grdInHouse.GetDataDisplay(_row.Index, 11));
                }
            }

            txtAttendees.Text = _totalAttendees.ToString();
        }

        private void cboFilter_TextChanged(object sender, EventArgs e)
        {
            showInhouseForecast();
            showAttendees();
        }
    }
}