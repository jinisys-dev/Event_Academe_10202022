using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class NationalityReport : Form
    {
        public NationalityReport()
        {
            InitializeComponent();
        }

        public DataTable loDataTable = new DataTable();
        public Reports.BusinessLayer.ReportFacade loReportFacade;

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value);
            string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpEndDate.Value);
            
            loReportFacade = new Jinisys.Hotel.Reports.BusinessLayer.ReportFacade();
            this.crpViewer.ReportSource = loReportFacade.getNationalityReport(startDate, endDate);

            if (this.crpViewer.ReportSource != null)
            {
                this.crpViewer.Show();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.crpViewer.PrintReport();
        }
    }
}