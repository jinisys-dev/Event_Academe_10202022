using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C1.Win.C1FlexGrid;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class StatisticalReportUI : Form
    {
        public StatisticalReportUI()
        {
            InitializeComponent();
        }

        private void rdbDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDaily.Checked == true)
            {
                dtpDaily.Enabled = true;
                dtpMonthly.Enabled = false;
                dtpAnnual.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }

            if (rdbMonthly.Checked == true)
            {
                dtpDaily.Enabled = false;
                dtpMonthly.Enabled = true;
                dtpAnnual.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }

            if (rdbYearly.Checked == true)
            {
                dtpDaily.Enabled = false;
                dtpMonthly.Enabled = false;
                dtpAnnual.Enabled = true;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }

            if (rdbDateRange.Checked == true)
            {
                dtpDaily.Enabled = false;
                dtpMonthly.Enabled = false;
                dtpAnnual.Enabled = false;
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            setupGrid("RELOAD");
        }

        private void setupGrid(string pProcess)
        {
            // set up grid layout/behavior
            //grdReport.AllowSorting = AllowSortingEnum.None;
            grdReport.AllowMerging = AllowMergingEnum.Nodes;
            grdReport.SelectionMode = SelectionModeEnum.Cell;
            grdReport.ExtendLastCol = true;
            grdReport.Cols[0].Width = grdReport.Cols.DefaultSize / 4;
            grdReport.Tree.Style = TreeStyleFlags.Simple;
            grdReport.Tree.Column = 0;

            // set up grid styles
            grdReport.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grdReport.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter;

            CellStyle _cellStyle = grdReport.Styles[CellStyleEnum.Subtotal0];
            _cellStyle.BackColor = Color.Azure;
            _cellStyle.ForeColor = Color.Black;
            _cellStyle.DataType = Type.GetType("double");
            _cellStyle.Format = "###,###,##0.00";

            // bind flex to data source
            switch(pProcess)
            {
                case "RELOAD" :
                    loDataSource = GetDataSourceOrigin();
                    grdReport.DataSource = loDataSource;
                    break;
                case "FILTER" :
                    loDataSource = GetDataSource();
                    grdReport.DataSource = loDataSource;
                    break;
            }

            //// prevent user from dragging last three columns
            //grdReport.Cols[4].AllowDragging = false;
            //grdReport.Cols[5].AllowDragging = false;
            //grdReport.Cols[6].AllowDragging = false;
        }

        private string[] lOrganizerArray;
        DataTable loDataSource;

        private DataTable GetDataSourceOrigin()
        {
            DataTable _oDataTable = new DataTable();
            ReportFacade _oReportFacade = new ReportFacade();

            string _sortType = "";
            if (rdbSource.Checked == true)
                _sortType = "Source";
            else if (rdbMarketSegment.Checked == true)
                _sortType = "Market Segment";
            else if (rdbEventType.Checked == true)
                _sortType = "Event Type";
            else if (rdbClientType.Checked == true)
                _sortType = "Client Type";

            else if (rdbOrganizer.Checked == true)
                _sortType = "Company Name";
            /* Gene
             * 28-Feb-12
             */
            else if (rdbAccountType.Checked == true)
                _sortType = "Account Type";

            if (rdbDaily.Checked == true)
            {
                _oDataTable = _oReportFacade.getDailyStatisticalReport(dtpDaily.Value.ToString("yyyy-MM-dd"), _sortType);
            }
            else if (rdbMonthly.Checked == true)
            {
                _oDataTable = _oReportFacade.getMonthlyStatisticalReport(dtpMonthly.Value.Month, dtpMonthly.Value.Year, _sortType);
            }
            else if (rdbYearly.Checked == true)
            {
                _oDataTable = _oReportFacade.getAnnualStatisticalReport(dtpAnnual.Value.Year, _sortType);
            }
            else
            {
                _oDataTable = _oReportFacade.getDateRangeStatisticalReport(dtpStartDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"), _sortType);
            }

            //add all organizers to the array
            try
            {
                lOrganizerArray = new string[_oDataTable.Rows.Count];
                int _ctr = 0;
                foreach (DataRow _dRow in _oDataTable.Rows)
                {
                    lOrganizerArray[_ctr] = _dRow["Company Name"].ToString();
                    _ctr++;
                }
            }
            catch
            {
                lOrganizerArray = null;
            }

            if (cboFilter.Text != "")
            {
                DataTable _oDataTableCopy = new DataTable();
                DataView _oDataView = _oDataTable.DefaultView;
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "`" + _sortType + "` = '" + cboFilter.Text + "'";

                _oDataTableCopy = _oDataView.ToTable();
                return _oDataTableCopy;
            }
            else
            {
                return _oDataTable;
            }

            return null;
        }

        private DataTable GetDataSource()
        {
            DataTable _oDataTable = new DataTable();
            ReportFacade _oReportFacade = new ReportFacade();

            string _sortType = "";
            if (rdbSource.Checked == true)
                _sortType = "Source";
            else if (rdbMarketSegment.Checked == true)
                _sortType = "Market Segment";
            else if (rdbEventType.Checked == true)
                _sortType = "Event Type";
            else if (rdbClientType.Checked == true)
                _sortType = "Client Type";

            else if (rdbOrganizer.Checked == true)
                _sortType = "Company Name";
            /* Gene
             * 28-Feb-12
             */
            else if (rdbAccountType.Checked == true)
                _sortType = "Account Type";
            _oDataTable = loDataSource;

            //add all organizers to the array
            try
            {
                lOrganizerArray = new string[_oDataTable.Rows.Count];
                int _ctr = 0;
                foreach (DataRow _dRow in _oDataTable.Rows)
                {
                    lOrganizerArray[_ctr] = _dRow["Company Name"].ToString();
                    _ctr++;
                }
            }
            catch
            {
                lOrganizerArray = null;
            }
            int test = _oDataTable.Rows.Count;
            
            if (cboFilter.Text != "")
            {
                DataTable _oDataTableCopy = new DataTable();
                DataView _oDataView = _oDataTable.DefaultView;
                //_oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "`" + _sortType + "` = '" + cboFilter.Text + "'";

                _oDataTableCopy = _oDataView.ToTable();
                int t = _oDataTableCopy.Rows.Count;
                return _oDataTableCopy;
            }
            else
            {
                return _oDataTable;
            }

            return null;
        }

        private void grdReport_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            // total on Revenue
            int _totalRevenue = grdReport.Cols["Total Revenue"].SafeIndex;
            string _caption = "Total for {0}";

            // calculate levels of totals
            grdReport.Subtotal(AggregateEnum.Sum, 0, 0, _totalRevenue, _caption);
            grdReport.Subtotal(AggregateEnum.Count, 0, 0, 1);
            grdReport.Tree.Show(1);
            grdReport.Tree.Sort(1, SortFlags.Descending, 0, 1);
            // autosize the grid to accommodate tree
            grdReport.AutoSizeCols(1, 0, grdReport.Rows.Count - 1, 0, 50, AutoSizeFlags.IgnoreHidden);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string _sortType = "";
            if (rdbSource.Checked == true)
                _sortType = "Source";
            else if (rdbMarketSegment.Checked == true)
                _sortType = "Market Segment";
            else if (rdbEventType.Checked == true)
                _sortType = "Event Type";
            else if (rdbClientType.Checked == true)
                _sortType = "Client Type";
            else if (rdbOrganizer.Checked == true)
                _sortType = "Company Name";
            /* Gene
             * 05-Mar-12
             */
            else if (rdbAccountType.Checked == true)
                _sortType = "Account Type";

            Report_Documents.Event_Management.StatisticalReport _oReport = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.StatisticalReport();
            ReportViewer _oReportViewer = new ReportViewer();

            _oReport.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
            _oReport.Database.Tables[1].SetDataSource(loDataSource);
            _oReport.DataDefinition.Groups[0].ConditionField = _oReport.Database.Tables[1].Fields[_sortType];
            _oReport.SetParameterValue(0, "REPORT PER " + _sortType.ToUpper());
            _oReportViewer.rptViewer.ReportSource = _oReport;
            _oReportViewer.MdiParent = this.MdiParent;
            _oReportViewer.Show();
        }

        private void rdbClientType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboFilter.Text = "";
                if (rdbSource.Checked == true)
                {
                    GroupBookingDropDownFacade _BookingFacade = new GroupBookingDropDownFacade();
                    DataTable _oDataTable = _BookingFacade.getSpecificFieldName("BookingSource");

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    foreach (DataRow _oRow in _oDataTable.Rows)
                    {
                        cboFilter.Items.Add(_oRow["value"].ToString().ToUpper());
                    }
                }

                if (rdbMarketSegment.Checked == true)
                {
                    GroupBookingDropDownFacade _BookingFacade = new GroupBookingDropDownFacade();
                    DataTable _oDataTable = _BookingFacade.getSpecificFieldName("MarketSegment");

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    foreach (DataRow _oRow in _oDataTable.Rows)
                    {
                        cboFilter.Items.Add(_oRow["value"].ToString().ToUpper());
                    }
                }

                if (rdbClientType.Checked == true)
                {
                    PrivilegeFacade _oPrivilegeFacade = new PrivilegeFacade();
                    PrivilegeHeader _oPrivilegeHeader = (PrivilegeHeader)_oPrivilegeFacade.loadObject();

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    DataTable dTable = _oPrivilegeHeader.Tables["PrivilegeHeader"];
                    for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                    {
                        cboFilter.Items.Add(dTable.Rows[i]["PrivilegeID"].ToString());
                    }

                    cboFilter.Items.Add("WALK-IN");
                    cboFilter.Items.Add("NONE");
                    cboFilter.Items.Add("");
                }

                if (rdbEventType.Checked == true)
                {
                    EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
                    IList<EventType> _oEventTypeList = _oEventTypeFacade.getEventTypes();

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    foreach (EventType _oEventType in _oEventTypeList)
                    {
                        cboFilter.Items.Add(_oEventType.Event_Type.ToUpper());
                    }
                }

                if (rdbOrganizer.Checked == true)
                {
                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    foreach (string _str in lOrganizerArray)
                    {
                        if (!cboFilter.Items.Contains(_str))
                            cboFilter.Items.Add(_str);
                    }
                }

                if (rdbAccountType.Checked == true)
                {
                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();
                    DataView _oDataView = oGroupBookingFacade.getDetailsForDropDown().DefaultView;
                    _oDataView.RowFilter = "fieldname = 'AccountType'";

                    if (_oDataView.Count > 0)
                    {
                        foreach (DataRowView _dRowView in _oDataView)
                        {
                            cboFilter.Items.Add(_dRowView["Value"].ToString());
                        }
                        
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loDataSource != null)
            {
                setupGrid("FILTER");
            }
        }

        private void StatisticalReportUI_Load(object sender, EventArgs e)
        {

        }
    }
}