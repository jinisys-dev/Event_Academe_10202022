using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class HistoricalEventsAndRevenue : Form
    {
        public HistoricalEventsAndRevenue()
        {
            InitializeComponent();
        }
        ReportFacade loReportFacade = new ReportFacade();

        private void btnShow_Click(object sender, EventArgs e) 
        {
            try
            {
                // fillGridHAndR(); 
                gridEventsRevenue.DataSource = loReportFacade.getHistoricalEventsAndRevenue(nudYearFrom.Text, nudYearTo.Text, cboTyp.SelectedValue.ToString());
            }
            catch
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            svDialogEventsAndRevenue.Filter = "Excel File|*.xls";
            svDialogEventsAndRevenue.ShowDialog();
        }

        private void HistoricalEventsAndRevenue_Load(object sender, EventArgs e)
        {
            loadCategory();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void svDialogEventsAndRevenue_FileOk(object sender, CancelEventArgs e)
        {

            try
            {
                loReportFacade.exportHistoricalEventsAndRevenue(gridEventsRevenue, svDialogEventsAndRevenue.FileName, cboTyp.SelectedValue.ToString(), nudYearFrom.Text, nudYearTo.Value.ToString());
                //DataTable _dt = loReportFacade.getHistoricalReportsCategory();

                //foreach (DataRow _row in _dt.Rows)
                //{
                //    gridEventsRevenue.DataSource = loReportFacade.getHistoricalEventsAndRevenue(nudYearFrom.Text, nudYearTo.Text, _row["description"].ToString());
                //    gridEventsRevenue.SaveExcel(svDialogEventsAndRevenue.FileName, _row["description"].ToString(), C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
                //}
            }
            catch
            {

            }

        }
        private void fillGridHAndR()
        {
            DataTable _dtResult = loReportFacade.getHistoricalEventsAndRevenue(nudYearFrom.Text, nudYearTo.Value.ToString(), "");

            DateTime _from = DateTime.Parse(nudYearFrom.Text + "-01-01");
            DateTime _to = DateTime.Parse(nudYearTo.Value.ToString() + "-01-01");
            DateTime _dt;
            int i=1;
            gridEventsRevenue.SetData(0, 0,"Months");

            for (_dt = _from; _dt <= _to; _dt = _dt.AddYears(1), i++)
            {
                //C1.Win.C1FlexGrid.Column _col = new C1.Win.C1FlexGrid.Column;
                //_col.Caption = "Month";
                gridEventsRevenue.Cols.Add();
                gridEventsRevenue.SetData(0, i,_dt.Year.ToString());
            }
        }

        private void loadCategory()
        {
            try
            {
                cboTyp.DataSource = loReportFacade.getHistoricalReportsCategory();
                cboTyp.DisplayMember = "Description";
                cboTyp.ValueMember   = "Description";
            }
            catch
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nudYearFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nudYearTo.Value < nudYearFrom.Value)
            {
                nudYearTo.Value = nudYearFrom.Value;
            }
        }

    }
}