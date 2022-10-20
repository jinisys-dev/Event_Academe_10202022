using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.Presentation.Report_Documents.Statistics;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using System.Configuration;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class TopClientsUI : Form
    {
        public TopClientsUI()
        {
            InitializeComponent();
        }

        private ReportFacade loReportFacade = new ReportFacade();

        private void loadMarketSegment()
        {
            AutoCompleteStringCollection values;
            GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

            DataTable _oDtDropDownValues = oGroupBookingFacade.getDetailsForDropDown();
            DataView _oDataView = _oDtDropDownValues.DefaultView;

            // Market Segment
            _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
            _oDataView.RowFilter = "fieldname = 'MarketSegment'";
            values = new AutoCompleteStringCollection();

            if (_oDataView.Count > 0)
            {
                //cboMarketSegment.Items.Clear();
                values.Add("OVERALL");
                foreach (DataRowView _dRowView in _oDataView)
                {
                    values.Add(_dRowView["Value"].ToString());
                }
                cboMarketSegment.DataSource = values;
            }


        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateTopClientsReport();
        }
        private void generateTopClientsReport()
        {
            
            TopClientsReport _rprtTopClients = new TopClientsReport();
            ReportFacade _oReportFacade = new ReportFacade();
            DataTable _dtTable = _oReportFacade.generateTopClientsReport(DateTime.Parse(dtpFromDate.Text)
                                                                        ,DateTime.Parse(dtpToDate.Text)
                                                                        , cboMarketSegment.Text
                                                                        , int.Parse(nupMaximumList.Value.ToString()));

            _rprtTopClients.Database.Tables[0].SetDataSource(_dtTable);
            _rprtTopClients.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
            _rprtTopClients.SetParameterValue(0, cboMarketSegment.Text);
            Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            _oReportViewer.rptViewer.ReportSource = _rprtTopClients;
            _oReportViewer.MdiParent = this.MdiParent;
            _oReportViewer.Show();
        }

        private void TopClientsUI_Load(object sender, EventArgs e)
        {
            loadMarketSegment();
        }
    }
}