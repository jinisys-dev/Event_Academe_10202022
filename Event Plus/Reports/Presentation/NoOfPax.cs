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
    public partial class NoOfPax : Form
    {
        public NoOfPax()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ReportFacade oReportFacade;
        private DataTable dtNoOfPax;
        private void btnShow_Click(object sender, EventArgs e)
        {
            double _totalPax = 0;
            double _totalRooms = 0;

            dtNoOfPax = new DataTable();
            oReportFacade = new ReportFacade();
            string pFilter = "";
            if (chkCheckin.Checked==true)
                pFilter = "ONGOING";
            if (chkIncoming.Checked == true)
                pFilter = "CONFIRMED";
            if (chkWaitList.Checked == true)
                pFilter = "WAIT LIST";
            if (chkWaitList.Checked == true && chkIncoming.Checked == true)
                pFilter = "CONFIRMED WAIT LIST";
            if (chkIncoming.Checked == true && chkCheckin.Checked == true)
                pFilter = "CONFIRMED ONGOING";
            if (chkCheckin.Checked == true && chkWaitList.Checked == true)
                pFilter = "ONGOING WAIT LIST";

            if (chkCheckin.Checked == true && chkIncoming.Checked == true && chkWaitList.Checked == true)
                pFilter = "ALL";
             string a_Date = "";
            a_Date = string.Format("{0:yyyy-MM-dd}", this.dtpDate.Value);
            dtNoOfPax = oReportFacade.getNoOfPax(a_Date,pFilter);

            // loads all pax account in the specified date
            this.lvwViewNoOfPax.Items.Clear();
            if (dtNoOfPax != null)
            {
                foreach (DataRow dRow in dtNoOfPax.Rows)
                {
                    ListViewItem lvwItem = new ListViewItem(dRow["RoomType"].ToString());
                    lvwItem.SubItems.Add(dRow["Pax"].ToString());
                    lvwItem.SubItems.Add(dRow["Rooms"].ToString());

                    this.lvwViewNoOfPax.Items.Add(lvwItem);

                    _totalPax += double.Parse(dRow["Pax"].ToString());
                    _totalRooms += double.Parse(dRow["Rooms"].ToString());
                }
            }

            txtTotalPax.Text = _totalPax.ToString();
            txtTotalRooms.Text = _totalRooms.ToString();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            printNoOfPax();

            this.Cursor = Cursors.Default;
        }


        private Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation.NoOfPaxReport noOfPaxReport;
        // >> GROUP BILLING
        public int printNoOfPax()
        {
            try
            {
                noOfPaxReport = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation.NoOfPaxReport();
                noOfPaxReport.Database.Tables[0].SetDataSource(dtNoOfPax);
                noOfPaxReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object param = string.Format("{0:dddd MMMM dd, yyyy}",DateTime.Now);
                noOfPaxReport.SetParameterValue(0, param);

                ReportViewer rptViewer = new ReportViewer();
                rptViewer.rptViewer.ReportSource = noOfPaxReport;

                rptViewer.MdiParent = this.MdiParent;
                rptViewer.Show();

                this.Close();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ printNoOfPax() " + ex.Message);
                return 0;
            }

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDate.Value < DateTime.Parse(GlobalVariables.gAuditDate))
            {
                MessageBox.Show("Date should be greater than or equal to the current audit date. \nPlease select another date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
            }
        }

        private void NoOfPax_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
        }
    }
}