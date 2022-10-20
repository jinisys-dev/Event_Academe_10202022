using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class CityTransferUI : Form
    {
        public CityTransferUI()
        {
            InitializeComponent();
        }

        
        private ReportFacade oReportFacade;
        private CityTransferTransactions oCityTransfer;
      
        private ReportViewer oReportViewer;
        private DataTable dtCityTransfer = null;
        private void btnShow_Click(object sender, EventArgs e)
        {

            dtCityTransfer = new DataTable();
            oReportFacade = new ReportFacade();

            string startDate = string.Format("{0:yyyy-MM-dd}",this.dtpStartDate.Value);
            string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpEndDate.Value); 

            dtCityTransfer = oReportFacade.getParamCityTransferTransactions(startDate,endDate);

            this.grdTransactions.Rows.Count = dtCityTransfer.Rows.Count + 1;

            int i = 1;
            foreach (DataRow dRow in dtCityTransfer.Rows)
            {
                this.grdTransactions.SetData(i, 0, dRow["RoomId"].ToString());
                this.grdTransactions.SetData(i, 1, dRow["GuestName"].ToString());
                this.grdTransactions.SetData(i, 2, dRow["CompanyName"].ToString());
                this.grdTransactions.SetData(i, 3, dRow["FolioId"].ToString());
                this.grdTransactions.SetData(i, 4, dRow["PostingDate"].ToString());
                this.grdTransactions.SetData(i, 5, dRow["BaseAmount"].ToString());
                this.grdTransactions.SetData(i, 6, dRow["UpdatedBy"].ToString());

                i++;
            }

            //for (int i = 1; i < this.grdTransactions.Rows.Count-1; i++)
            //{
            //    DataRow dRow = dtCityTransfer.Rows[i-1];

            //    this.grdTransactions.SetData(i, 0, dRow["RoomId"].ToString());
            //    this.grdTransactions.SetData(i, 1, dRow["GuestName"].ToString());
            //    this.grdTransactions.SetData(i, 2, dRow["CompanyName"].ToString());
            //    this.grdTransactions.SetData(i, 3, dRow["FolioId"].ToString());
            //    this.grdTransactions.SetData(i, 4, dRow["PostingDate"].ToString());
            //    this.grdTransactions.SetData(i, 5, dRow["BaseAmount"].ToString());
            //    this.grdTransactions.SetData(i, 6, dRow["UpdatedBy"].ToString());
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtCityTransfer != null)
            {
                this.Cursor = Cursors.WaitCursor;


                string a_Startdate = string.Format("{0:MMM dd, yyyy}", this.dtpStartDate.Value);
                string a_EndDate = string.Format("{0:MMM dd, yyyy}", this.dtpEndDate.Value) ;

                oReportViewer = new ReportViewer();
                oCityTransfer = new CityTransferTransactions();

                oCityTransfer.Database.Tables[0].SetDataSource(dtCityTransfer);
                oCityTransfer.Database.Tables[1].SetDataSource( CrystalReportAddons.reportHeader() );

                oCityTransfer.SetParameterValue(0, "from " + a_Startdate + " to " + a_EndDate);

                oReportViewer.rptViewer.ReportSource = oCityTransfer;
                oReportViewer.MdiParent = this.MdiParent;
                oReportViewer.Show();

                this.Cursor = Cursors.Default;
                this.Close();
            }

        }

    }
}