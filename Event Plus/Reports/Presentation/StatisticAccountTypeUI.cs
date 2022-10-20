using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;



namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class StatisticAccountTypeUI : Form
    {
        public StatisticAccountTypeUI()
        {
            InitializeComponent();
        }

        ReportFacade loReportFacade = new ReportFacade();

        private void StatisticAccountTypeUI_Load(object sender, EventArgs e)
        {
            loadMarketSegment();
        }

        private void btnShow_Click(object sender, EventArgs e)
        
        {
            try
            {
                gridResult.DataSource = loReportFacade.getAccoutTypeDetails(nudFrom.Value.ToString(), nudTo.Value.ToString(), cboMarketSegment.Text, cboClientType.Text);
            }
            catch
            {

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            sfdExportToExcel.Filter = "Excel files (*.xls)|*.xls";
            sfdExportToExcel.ShowDialog();
        }

        private void loadMarketSegment()
        {
            GroupBookingDropDownFacade _BookingFacade = new GroupBookingDropDownFacade();
            DataTable _oDataTable = _BookingFacade.getSpecificFieldName("MarketSegment");

            cboMarketSegment.Items.Clear();
            cboMarketSegment.Items.Add("ALL");
            foreach (DataRow _oRow in _oDataTable.Rows)
            {
                cboMarketSegment.Items.Add(_oRow["value"].ToString().ToUpper());
            }


            DataTable _oDataTableAccountType = _BookingFacade.getSpecificFieldName("AccountType");

            cboClientType.Items.Clear();
            cboClientType.Items.Add("ALL");
            foreach (DataRow _oRow in _oDataTableAccountType.Rows)
            {
                cboClientType.Items.Add(_oRow["value"].ToString().ToUpper());
            }

        }

        private void sfdExportToExcel_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                gridResult.SaveExcel(cboClientType.Text + "-" + sfdExportToExcel.FileName);
            }
            catch
            {
            }
        }

    }
}