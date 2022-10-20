using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.UI;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Excel = Microsoft.Office.Interop.Excel;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class LostBusinessUI : Form
    {
        public LostBusinessUI()
        {
            InitializeComponent();
        }
        #region "VARIABLES"
        ReportFacade loReportFacade;
        DataTable loLostBusiness;
        /* Gene
         * 3-Feb-12
         * Added dataview, will use dataview instead of datatable for filters
         */
        DataView loLostBusinessView;
        #endregion

        private void LostBusinessUI_Load(object sender, EventArgs e)
        {
            loReportFacade = new ReportFacade();
            DateTime _now = DateTime.Now;
            cboMonth.SelectedIndex = _now.Month - 1;
            cboMonthYear.Text = _now.Year.ToString();
            cboYear.Text = _now.Year.ToString();
            loadLostBusiness();
            loadToGrid();
            setButtons();

            /* Gene
             * 3-Feb-12
             * Populate cboFilter with the current selected filter type
             */
            radioButtonEvent_CheckedChanged(null, null);
        }
        DateTime lStartDate, lEndDate;
        private void loadLostBusiness()
        {
            try 
            {
                if (cboMonth.Text != "" && cboMonthYear.Text != "" && cboYear.Text != "")
                {
                    if(rdoMonthly.Checked)
                    {
                        int _month = cboMonth.SelectedIndex + 1;
                        lStartDate = DateTime.Parse(cboMonthYear.Text + "-" + _month.ToString() + "-01");
                        lEndDate = DateTime.Parse(cboMonthYear.Text + "-" + _month.ToString() + "-" + DateTime.DaysInMonth(int.Parse(cboMonthYear.Text), _month));
                    }
                    else if(rdoYearly.Checked)
                    {
                        lStartDate = DateTime.Parse(cboYear.Text + "-01-01");
                        lEndDate = DateTime.Parse(cboYear.Text + "-12-31");
                    }
                    else
                    {
                        lStartDate = dtpFrom.Value;
                        lEndDate = dtpTo.Value;
                    }
                    loLostBusiness = loReportFacade.getLostBusiness(lStartDate, lEndDate, GlobalVariables.gHotelId);

                    /* Gene
                     * 3-Feb-12
                     * Populate the dataview with loLostBusiness' defaultview
                     */
                    loLostBusinessView = loLostBusiness.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lost business report\r\n" + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadToGrid()
        {
            /**
             * 0 - event
             * 1 - venue
             * 2 - estRevenue
             * 3 - date
             * 4 - bookingDate
             * 5 - cancelDate
             * 6 - marketsegment
             * 7 - eventtype
             * 8 - type of booking
             * 9 - organizer
             * 10 - reason
             * 11 - narrative reason
             * 12 - mo
             **/

            try
            {
                gridLostBusiness.Rows.Count = 1;
                ProgressForm progress = new ProgressForm();
                if (loLostBusiness != null && loLostBusiness.Rows.Count > 0)
                {
                    gridLostBusiness.Rows.Count = loLostBusiness.Rows.Count + 1;
                    int count = loLostBusiness.Rows.Count + 1;
                    progress = new ProgressForm(count, "Loading Lost Business Report......");
                    progress.Height = 27;
                    progress.Show();
                    int _row = 1;

                    /* Gene
                     * 3-Feb-12
                     * will now use dataview instead of the datarow
                     */
                    //foreach (DataRow _dRow in loLostBusiness.Rows)
                    if (loLostBusinessView.ToTable().Rows.Count < 1)
                        gridLostBusiness.Rows.Count = 1;
                    else
                    {
                        foreach (DataRow _dRow in loLostBusinessView.ToTable().Rows)
                        {
                            gridLostBusiness.SetData(_row, 0, _dRow["event"].ToString());
                            gridLostBusiness.SetData(_row, 1, _dRow["venue"].ToString());
                            gridLostBusiness.SetData(_row, 2, string.Format("{0:###,###,###,##0.00}", decimal.Parse(_dRow["estRevenue"].ToString())));
                            gridLostBusiness.SetData(_row, 3, _dRow["date"].ToString());
                            gridLostBusiness.SetData(_row, 4, _dRow["bookingDate"].ToString());
                            gridLostBusiness.SetData(_row, 5, _dRow["cancelDate"].ToString());
                            gridLostBusiness.SetData(_row, 6, _dRow["marketsegment"].ToString());
                            gridLostBusiness.SetData(_row, 7, _dRow["eventtype"].ToString());
                            gridLostBusiness.SetData(_row, 8, _dRow["cancelBookingType"].ToString());
                            gridLostBusiness.SetData(_row, 9, _dRow["organizer"].ToString());
                            gridLostBusiness.SetData(_row, 10, _dRow["reasonType"].ToString());
                            gridLostBusiness.SetData(_row, 11, _dRow["reason"].ToString());
                            gridLostBusiness.SetData(_row, 12, _dRow["mo"].ToString());
                            _row++;
                            progress.updateProgress(_row);
                        }
                    }
                    progress.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lost business in grid\r\n" + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void setButtons()
        {
            if (rdoMonthly.Checked)
            {
                cboYear.Enabled = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboMonth.Enabled = true;
                cboMonthYear.Enabled = true;
            }
            else if (rdoYearly.Checked)
            {
                cboYear.Enabled = true;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboMonth.Enabled = false;
                cboMonthYear.Enabled = false;
            }
            else
            {
                cboYear.Enabled = false;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                cboMonth.Enabled = false;
                cboMonthYear.Enabled = false;
            }
        }

        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadLostBusiness();
            loadToGrid();
        }

        private void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadLostBusiness();
            loadToGrid();
        }

        private void rdoDateRange_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadLostBusiness();
            loadToGrid();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadLostBusiness();
            loadToGrid();
        }

        private void cboMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadLostBusiness();
            loadToGrid();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadLostBusiness();
            loadToGrid();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                gridLostBusiness.Rows.Count = 1;
                loLostBusiness = null;
                return;
            }
            dtpTo.MinDate = dtpFrom.Value;
            loadLostBusiness();
            loadToGrid();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("From date should be less than to date", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            loadLostBusiness();
            loadToGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.gridLostBusiness.Rows.Count <= 1)
            {
                return;
            }

            try
            {
                string strFileName = "LOST BUSINESS REPORT (" + string.Format("{0:dd-MMM-yyyy}", lStartDate) + " to " + string.Format("{0:dd-MMM-yyyy}", lEndDate) + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;
                
                DialogResult _result = sfdExport.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                    ProgressForm progress = new ProgressForm();
                    int count = gridLostBusiness.Rows.Count + 1;
                    progress = new ProgressForm(count, "Exporting Lost Business......");
                    progress.Height = 27;
                    progress.Show();

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlApp.ActiveWindow.DisplayGridlines = false;

                    int rowCount = 1;

                    string _dateHeader = "";
                    string _reportType = "";
                    if (rdoMonthly.Checked)
                    {
                        _dateHeader = string.Format("{0:MMMM yyyy}", lStartDate);
                        _reportType = "MONTHLY";
                    }
                    else if (rdoYearly.Checked)
                    {
                        _dateHeader = string.Format("{0:yyyy}", lStartDate);
                        _reportType = "YEARLY";
                    }
                    else
                    {
                        _dateHeader = string.Format("{0:MMMM dd yyyy}", lStartDate) + "-" + string.Format("{0:MMMM dd yyyy}", lEndDate);
                        _reportType = "DATE RANGE";
                    }

                    //add report header
                    xlWorkSheet.Cells[rowCount, 1] = "LOST BUSINESS REPORT";
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = _reportType + " SUMMARY";
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = _dateHeader;
                    rowCount++;

                    //add column headers
                    for (int _col = 1; _col <= loLostBusiness.Columns.Count; _col++)
                    {
                        xlWorkSheet.Cells[rowCount, _col] = this.gridLostBusiness.Cols[_col - 1].Name;
                    }
                    rowCount++;
                    //add values
                    foreach (DataRow _drow in loLostBusiness.Rows)
                    {
                        for (int _col = 1; _col <= loLostBusiness.Columns.Count; _col++)
                        {
                            xlWorkSheet.Cells[rowCount, _col] = _drow[_col - 1].ToString();
                        }
                        rowCount++;
                        progress.updateProgress(rowCount);
                    }

                    //format
                    xlWorkSheet.get_Range("A1", _letterAddress[gridLostBusiness.Cols.Count - 1] + "1").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A2", _letterAddress[gridLostBusiness.Cols.Count - 1] + "2").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A3", _letterAddress[gridLostBusiness.Cols.Count - 1] + "3").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A1", _letterAddress[gridLostBusiness.Cols.Count - 1] + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A2", _letterAddress[gridLostBusiness.Cols.Count - 1] + "2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A3", _letterAddress[gridLostBusiness.Cols.Count - 1] + "3").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    xlWorkSheet.get_Range("A4", _letterAddress[gridLostBusiness.Cols.Count - 1] + (rowCount - 1)).Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //summary
                    int _events = 0;
                    _events = loLostBusiness.Rows.Count;
                    decimal _sum = 0;
                    _sum = Convert.ToDecimal(loLostBusiness.Compute("sum(estRevenue)", ""));

                    /* Gene
                     * 29-Feb-12
                     */

                    GroupBookingDropDownFacade _lookupFacade = new GroupBookingDropDownFacade();
                    EventTypeFacade _oEventTypeFacade = new EventTypeFacade();

                    DataTable _marketSegments = _lookupFacade.getGroupBooking("MarketSegment");
                    DataTable _reasons = _lookupFacade.getGroupBooking("Reason");
                    GenericList<EventType> _eventTypes = _oEventTypeFacade.getEventTypes();
                                    
                    /********************************************************************/

                    xlWorkSheet.Cells[rowCount, 1] = "Total";
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Merge(Type.Missing);
                    xlWorkSheet.Cells[rowCount, 3] = _sum;
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "Total No. of Events";
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Merge(Type.Missing);
                    xlWorkSheet.Cells[rowCount, 3] = _events;                    
                    xlWorkSheet.get_Range("A1", _letterAddress[gridLostBusiness.Cols.Count - 1] + rowCount).EntireColumn.AutoFit();
                    rowCount++;

                    /* Gene
                     * 01-Mar-12
                     * Added statistics for market segments, reasons, and event types
                     */

                    rowCount++;

                    // Table Borders
                    xlWorkSheet.get_Range("A" + rowCount, "B" + (rowCount + _marketSegments.Rows.Count)).Borders.Weight = Excel.XlBorderWeight.xlThin;

                    // Header
                    xlWorkSheet.Cells[rowCount, 1] = "MARKET SEGMENTS";
                    xlWorkSheet.Cells[rowCount, 2] = "COUNT";
                    // Format Header
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Font.Bold = true;
                    rowCount++;

                    // Table Data
                    foreach (DataRow _dr in _marketSegments.Rows)
                    {                        
                        loLostBusinessView.RowFilter = "";
                        loLostBusinessView.RowFilter = "marketsegment like '" + _dr["Value"].ToString() + "'";
                        
                        xlWorkSheet.Cells[rowCount, 1] = _dr["Value"].ToString();
                        xlWorkSheet.Cells[rowCount, 2] = loLostBusinessView.ToTable().Rows.Count;

                        rowCount++;
                    }                    

                    rowCount++;

                    // Table Borders
                    xlWorkSheet.get_Range("A" + rowCount, "B" + (rowCount + _eventTypes.Count)).Borders.Weight = Excel.XlBorderWeight.xlThin;

                    // Header
                    xlWorkSheet.Cells[rowCount, 1] = "EVENT TYPES";
                    xlWorkSheet.Cells[rowCount, 2] = "COUNT";
                    // Format Header
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Font.Bold = true;
                    rowCount++;

                    foreach (EventType _et in _eventTypes)
                    {
                        loLostBusinessView.RowFilter = "";
                        loLostBusinessView.RowFilter = "eventtype like '" + _et.Event_Type + "'";

                        xlWorkSheet.Cells[rowCount, 1] = _et.Event_Type;
                        xlWorkSheet.Cells[rowCount, 2] = loLostBusinessView.ToTable().Rows.Count;

                        rowCount++;
                    }

                    rowCount++;

                    // Table Borders
                    xlWorkSheet.get_Range("A" + rowCount, "B" + (rowCount + _reasons.Rows.Count)).Borders.Weight = Excel.XlBorderWeight.xlThin;

                    // Header
                    xlWorkSheet.Cells[rowCount, 1] = "REASONS";
                    xlWorkSheet.Cells[rowCount, 2] = "COUNT";
                    // Format Header
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Font.Bold = true;
                    rowCount++;

                    foreach (DataRow _dr in _reasons.Rows)
                    {
                        loLostBusinessView.RowFilter = "";
                        loLostBusinessView.RowFilter = "reasonType like '" + _dr["Value"].ToString() + "'";

                        xlWorkSheet.Cells[rowCount, 1] = _dr["Value"].ToString();
                        xlWorkSheet.Cells[rowCount, 2] = loLostBusinessView.ToTable().Rows.Count;

                        rowCount++;
                    }

                    /*******************************************************************/

                    progress.Close();
                    try
                    {
                        xlWorkBook.SaveAs(sfdExport.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        //MessageBox.Show("File Saved", "Event Plus", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot Save/Overwrite XLS File errmsg: " + ex.ToString());
                    }
                    finally
                    {
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                    }

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at importing to excel\r\n" + ex.Message, "Event Management Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /* Gene
         * 3-Feb-12
         * Added Radio buttons for filter
         */
        private void radioButtonEvent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GroupBookingDropDownFacade _BookingFacade = new GroupBookingDropDownFacade();
                
                if (rdbMarketSegment.Checked == true)
                {
                    
                    DataTable _oDataTable = _BookingFacade.getSpecificFieldName("MarketSegment");

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    foreach (DataRow _oRow in _oDataTable.Rows)
                    {
                        cboFilter.Items.Add(_oRow["value"].ToString().ToUpper());
                    }
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

                if (rdbTypeOfBooking.Checked == true)
                {                    
                    string[] _strBookingType = _BookingFacade.getByFieldName("CancelBookingType");                    

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    for (int i = 0; i < _strBookingType.Length; i++)
                    {
                        cboFilter.Items.Add(_strBookingType.GetValue(i).ToString());
                    }
                }

                if (rdbReason.Checked == true)
                {
                    string[] _strReason = _BookingFacade.getByFieldName("Reason");

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    for (int i = 0; i < _strReason.Length; i++)
                    {
                        cboFilter.Items.Add(_strReason.GetValue(i).ToString());
                    }
                }
            }
            catch { }
        }

        /* Gene
         * 3-Feb-12
         */
        private void btnFilter_Click(object sender, EventArgs e)
        {
            loLostBusinessView.RowFilter = "";

            if (rdbMarketSegment.Checked == true)
            {                
                loLostBusinessView.RowFilter = "marketSegment Like '%" + cboFilter.Text + "%'";
            }

            if (rdbEventType.Checked == true)
            {
                loLostBusinessView.RowFilter = "eventtype Like '%" + cboFilter.Text + "%'";
            }

            if (rdbTypeOfBooking.Checked == true)
            {                    
                loLostBusinessView.RowFilter = "cancelBookingType Like '%" + cboFilter.Text + "%'";
            }

            if (rdbReason.Checked == true)
            {
                loLostBusinessView.RowFilter = "reason Like '%" + cboFilter.Text + "%'";
            }

            loadToGrid();
        }
    }
}