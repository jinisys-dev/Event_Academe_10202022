//jlo 9-25-2010
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Excel = Microsoft.Office.Interop.Excel;

namespace Jinisys.Hotel.Reports.Presentation
{

    public partial class CalendarOfEventsUI : Form
    {
        #region "VARIABLES"
        private ReportFacade loReportFacade;
        private DataTable loCalendarOfEvents;
        #endregion

        public CalendarOfEventsUI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalendarOfEventsUI_Load(object sender, EventArgs e)
        {
            loReportFacade = new ReportFacade();
            DateTime _now = DateTime.Now;
            cboMonth.SelectedIndex = _now.Month - 1;
            cboMonthYear.Text = _now.Year.ToString();
            cboYear.Text = _now.Year.ToString();
            loadCalendarOfEvents();
            loadToGrid();
            setButtons();
        }
        DateTime lStartDate, lEndDate;
        private void loadCalendarOfEvents()
        {
            try
            {
                
                if (cboMonth.Text != "" && cboMonthYear.Text != "" && cboYear.Text != "")
                {
                    if (rdoMonthly.Checked)
                    {
                        int _month = cboMonth.SelectedIndex + 1;
                        lStartDate = DateTime.Parse(cboMonthYear.Text + "-" + _month.ToString() + "-01");
                        lEndDate = DateTime.Parse(cboMonthYear.Text + "-" + _month.ToString() + "-" + DateTime.DaysInMonth(int.Parse(cboMonthYear.Text), _month));
                    }
                    else if (rdoYearly.Checked)
                    {
                        lStartDate = DateTime.Parse(cboYear.Text + "-01-01");
                        lEndDate = DateTime.Parse(cboYear.Text + "-12-31");
                    }
                    else
                    {
                        lStartDate = dtpFrom.Value;
                        lEndDate = dtpTo.Value;
                    }
                    loCalendarOfEvents = loReportFacade.getReportCalenderOfEvents(lStartDate, lEndDate, GlobalVariables.gHotelId, cboStatus.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events\r\n" + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadToGrid()
        {
            /* Gene
             * 02-Mar-12
             * Added new column, folioID
             */
            /***
             * 0 - referenceNo
             * 1 - bookingDate
             * 2 - folioID
             * 3 - clientType
             * 4 - source
             * 5 - date
             * 6 - time
             * 7 - venue
             * 8 - eventTitle
             * 9 - organizer
             * 10 - noofpaxguaranteed
             * 11 - contractAmount
             * 12 - marketsegment
             * 13 - eventtype
             * 14 - status
             * 15 - mo
             * 16 - eo
             ***/
            try
            {
                gridCalendarOfEvents.Rows.Count = 1;
                ProgressForm progress = new ProgressForm();
                if (loCalendarOfEvents != null && loCalendarOfEvents.Rows.Count > 0)
                {
                    gridCalendarOfEvents.Rows.Count = loCalendarOfEvents.Rows.Count + 1;
                    int count = loCalendarOfEvents.Rows.Count + 1;
                    progress = new ProgressForm(count, "Loading Calendar of Events......");
                    progress.Height = 27;
                    progress.Show();
                    int _row = 1;
                     foreach (DataRow _dRow in loCalendarOfEvents.Rows)
                    {
                        gridCalendarOfEvents.SetData(_row, 0, _dRow["referenceNo"].ToString());
                        /* Gene                         
                         * 02-Mar-12
                         * folioID
                         */
                        gridCalendarOfEvents.SetData(_row, 1, _dRow["folioID"].ToString());
                        gridCalendarOfEvents.SetData(_row, 2, _dRow["bookingDate"].ToString());
                        gridCalendarOfEvents.SetData(_row, 3, _dRow["clientType"].ToString());

                         
                        gridCalendarOfEvents.SetData(_row, 4, _dRow["source"].ToString());
                        gridCalendarOfEvents.SetData(_row, 5, _dRow["date"].ToString());
                       // gridCalendarOfEvents.SetData(_row, 6, _dRow["time"].ToString());
                        gridCalendarOfEvents.SetData(_row, 6, new string(Encoding.ASCII.GetChars((byte[])_dRow["time"])));
                        gridCalendarOfEvents.SetData(_row, 7, _dRow["venue"].ToString());
                        gridCalendarOfEvents.SetData(_row, 8, _dRow["eventTitle"].ToString());
                        gridCalendarOfEvents.SetData(_row, 9, _dRow["organizer"].ToString());
                        gridCalendarOfEvents.SetData(_row, 10, _dRow["noofpaxguaranteed"].ToString());
                        gridCalendarOfEvents.SetData(_row, 11, _dRow["LocalParticipants"].ToString());
                        gridCalendarOfEvents.SetData(_row, 12, _dRow["ForeignParticipants"].ToString());
                        gridCalendarOfEvents.SetData(_row, 13, _dRow["NoOfVisitors"].ToString());
                        gridCalendarOfEvents.SetData(_row, 14, _dRow["ForeignBased"].ToString());
                        gridCalendarOfEvents.SetData(_row, 15, _dRow["LocalBased"].ToString());
                        gridCalendarOfEvents.SetData(_row, 16, _dRow["GeographicalScope"].ToString());
                        gridCalendarOfEvents.SetData(_row, 17, _dRow["contractAmount"].ToString());
                        gridCalendarOfEvents.SetData(_row, 18, _dRow["marketsegment"].ToString());
                        gridCalendarOfEvents.SetData(_row, 19, _dRow["eventtype"].ToString());
                        gridCalendarOfEvents.SetData(_row, 20, _dRow["status"].ToString());
                        gridCalendarOfEvents.SetData(_row, 21, _dRow["mo"].ToString());
                        gridCalendarOfEvents.SetData(_row, 22, _dRow["eo"].ToString());
                        _row++;
                        progress.updateProgress(_row);
                    }
                    progress.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events in grid\r\n" + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void rdoRange_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void cboMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                gridCalendarOfEvents.Rows.Count = 1;
                loCalendarOfEvents = null;
                return;
            }
            dtpTo.MinDate = dtpFrom.Value;
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("From date should be less than to date", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            loadCalendarOfEvents();
            loadToGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (loCalendarOfEvents == null && loCalendarOfEvents.Rows.Count < 1)
                return;

            try
            {
                string strFileName = "Calendar of Events (" + string.Format("{0:dd-MMM-yyyy}",lStartDate) +" to " + string.Format("{0:dd-MMM-yyyy}",lEndDate) + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;
                DataTable _roomTypes = loReportFacade.getRoomTypesCalendarEvents(GlobalVariables.gHotelId);
                DataTable _eventTypes = loReportFacade.getEventTypes(GlobalVariables.gHotelId);
                DataTable _marketSegment = loReportFacade.getGroupBooking("MarketSegment", GlobalVariables.gHotelId);
                DataTable _bookingSource = loReportFacade.getGroupBooking("BookingSource", GlobalVariables.gHotelId);
                DialogResult _result = sfdExport.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                    ProgressForm progress = new ProgressForm();
                    int count = gridCalendarOfEvents.Rows.Count + 1;
                    progress = new ProgressForm(count, "Exporting Event List......");
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
                    //----
                    int rowCount = 1;
                    int[] _confirmed = new int[_roomTypes.Rows.Count];
                    int[] _tentative = new int[_roomTypes.Rows.Count];
                    decimal[] _confirmedRev = new decimal[_roomTypes.Rows.Count];
                    decimal[] _tentativeRev = new decimal[_roomTypes.Rows.Count];
                    int _roomtypeCounter = 0;
                    int _counter = 1;
                    //loops per room type
                    xlWorkSheet.Cells[rowCount, 1] = "CALENDAR OF EVENTS from " + string.Format("{0:dd-MMM-yyyy}", lStartDate) + " to " + string.Format("{0:dd-MMM-yyyy}", lEndDate);
                    rowCount++;
                    foreach (DataRow _roomType in _roomTypes.Rows)
                    {   
                        xlWorkSheet.Cells[rowCount, 1] = _roomType["roomtypecode"].ToString();
                        xlWorkSheet.get_Range("A" + rowCount, "A" + rowCount).Font.Bold = true;
                        rowCount++;
                        _counter = rowCount;
                        /* 02-Mar-12
                         * Added new Header "FOLIO ID"
                         * rearranged the columns
                         */
                        //create headers
                        xlWorkSheet.Cells[rowCount, 1] = "REF NO.";
                        /* Gene
                         * 02-Mar-12
                         */
                        //xlWorkSheet.Cells[rowCount, 2] = "FOLIO ID";
                        //xlWorkSheet.Cells[rowCount, 3] = "BOOKING DATE";
                        //xlWorkSheet.Cells[rowCount, 4] = "CLIENT TYPE";
                        //xlWorkSheet.Cells[rowCount, 5] = "SOURCE";
                        //xlWorkSheet.Cells[rowCount, 6] = "DATE";
                        //xlWorkSheet.Cells[rowCount, 7] = "TIME";
                        //xlWorkSheet.Cells[rowCount, 8] = "VENUE";
                        //xlWorkSheet.Cells[rowCount, 9] = "EVENT TITLE";
                        //xlWorkSheet.Cells[rowCount, 10] = "COMPANY/ORGANIZER";
                        //xlWorkSheet.Cells[rowCount, 11] = "EXPECTED NO. OF PARTICIPANTS";
                        //xlWorkSheet.Cells[rowCount, 12] = "NO. OF LOCAL PARTICIPANTS";
                        //xlWorkSheet.Cells[rowCount, 13] = "NO. OF FOREIGN PARTICIPANTS";
                        //xlWorkSheet.Cells[rowCount, 14] = "NO. OF TRADE VISITORS TO TRADE FAIRS/EXHIBITIONS";
                        //xlWorkSheet.Cells[rowCount, 15] = "NO. OF EXHIBITORS (FOREIGN)";
                        //xlWorkSheet.Cells[rowCount, 16] = "NO. OF EXHIBITORS (LOCAL)";
                        //xlWorkSheet.Cells[rowCount, 17] = "GEOGRAPHICAL SCOPE";
                        //xlWorkSheet.Cells[rowCount, 18] = "ESTIMATED REVENUE";
                        //xlWorkSheet.Cells[rowCount, 19] = "MARKET SEGMENT";
                        //xlWorkSheet.Cells[rowCount, 20] = "EVENT TYPE";
                        //xlWorkSheet.Cells[rowCount, 21] = "STATUS";
                        //xlWorkSheet.Cells[rowCount, 22] = "MO";
                        //xlWorkSheet.Cells[rowCount, 23] = "EO";
                        xlWorkSheet.Cells[rowCount, 2] = "FOLIO ID";
                        xlWorkSheet.Cells[rowCount, 3] = "BOOKING DATE";
                        xlWorkSheet.Cells[rowCount, 4] = "CLIENT TYPE";
                        xlWorkSheet.Cells[rowCount, 5] = "SOURCE";
                        xlWorkSheet.Cells[rowCount, 6] = "DATE";
                        xlWorkSheet.Cells[rowCount, 7] = "TIME";
                        xlWorkSheet.Cells[rowCount, 8] = "VENUE";
                        xlWorkSheet.Cells[rowCount, 9] = "EVENT TITLE";
                        xlWorkSheet.Cells[rowCount, 10] = "COMPANY/ORGANIZER";
                        xlWorkSheet.Cells[rowCount, 11] = "EXPECTED NO. OF PARTICIPANTS";                        
                        xlWorkSheet.Cells[rowCount, 12] = "ESTIMATED REVENUE";
                        xlWorkSheet.Cells[rowCount, 13] = "MARKET SEGMENT";
                        xlWorkSheet.Cells[rowCount, 14] = "EVENT TYPE";
                        xlWorkSheet.Cells[rowCount, 15] = "STATUS";
                        xlWorkSheet.Cells[rowCount, 16] = "MO";
                        xlWorkSheet.Cells[rowCount, 17] = "EO";
                        xlWorkSheet.Cells[rowCount, 18] = "NO. OF LOCAL PARTICIPANTS";
                        xlWorkSheet.Cells[rowCount, 19] = "NO. OF FOREIGN PARTICIPANTS";
                        xlWorkSheet.Cells[rowCount, 20] = "NO. OF TRADE VISITORS TO TRADE FAIRS/EXHIBITIONS";
                        xlWorkSheet.Cells[rowCount, 21] = "NO. OF EXHIBITORS (FOREIGN)";
                        xlWorkSheet.Cells[rowCount, 22] = "NO. OF EXHIBITORS (LOCAL)";
                        xlWorkSheet.Cells[rowCount, 23] = "GEOGRAPHICAL SCOPE";
                        rowCount++;
                        //end

                        _confirmedRev[_roomtypeCounter] = 0;
                        _confirmed[_roomtypeCounter] = 0;
                        _tentativeRev[_roomtypeCounter] = 0;
                        _tentative[_roomtypeCounter] = 0;
                        //loops per data
                        foreach (DataRow _dRow in loCalendarOfEvents.Rows)
                        {
                            if (_dRow["roomtype"].ToString().Contains(_roomType["roomtypecode"].ToString()))
                            {
                                //loops columns
                                /* Gene
                                 * 02-Mar-12
                                 * changed number of columns from 22 to 23 because of added column, folioID
                                 * changed dRow[_col] to dRow[_col-1] to include the folioID
                                 */
                                for (int _col = 1; _col <= 23; _col++)
                                {
                                    /* Gene
                                     * 02-Mar-12
                                     */
                                    // Old Code
                                    //if (_col == 17)
                                    if (_col == 12)
                                    {
                                        xlWorkSheet.Cells[rowCount, _col] = string.Format("{0:###,###,###,##0.00}", decimal.Parse(_dRow[_col - 1].ToString()));
                                    }
                                    if (_col ==7 )
                                    {
                                        xlWorkSheet.Cells[rowCount, _col] = new string(Encoding.ASCII.GetChars((byte[])_dRow[_col - 1]));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[rowCount, _col] = _dRow[_col - 1].ToString();
                                    }
                                }
                                rowCount++;
                                progress.updateProgress(rowCount);
                                if (_dRow["status"].ToString() == "CONFIRMED")
                                {
                                    _confirmed[_roomtypeCounter]++;
                                    _confirmedRev[_roomtypeCounter] = _confirmedRev[_roomtypeCounter] + decimal.Parse(_dRow["contractAmount"].ToString());
                                }
                                if (_dRow["status"].ToString() == "TENTATIVE")
                                {
                                    _tentative[_roomtypeCounter]++;
                                    _tentativeRev[_roomtypeCounter] = _tentativeRev[_roomtypeCounter] + decimal.Parse(_dRow["contractAmount"].ToString());
                                }
                            }
                        }
                        //borders
                        xlWorkSheet.get_Range("A" + _counter, _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + (rowCount-1)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                        xlWorkSheet.get_Range("A" + _counter, _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + (rowCount-1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //end borders

                        rowCount++;
                        xlWorkSheet.Cells[rowCount, 1] = "CONFIRMED EVENT/S:";
                        xlWorkSheet.Cells[rowCount, 6] = _confirmed[_roomtypeCounter];
                        xlWorkSheet.Cells[rowCount, 11] = string.Format("{0:###,###,###,##0.00}", _confirmedRev[_roomtypeCounter]);
                        rowCount++;
                        xlWorkSheet.Cells[rowCount, 1] = "TENTATIVE EVENT/S:";
                        xlWorkSheet.Cells[rowCount, 6] = _tentative[_roomtypeCounter];
                        xlWorkSheet.Cells[rowCount, 11] = string.Format("{0:###,###,###,##0.00}", _tentativeRev[_roomtypeCounter]);
                        rowCount++;
                        xlWorkSheet.Cells[rowCount, 1] = "TOTAL NUMBER OF EVENTS";
                        xlWorkSheet.Cells[rowCount, 6] = _confirmed[_roomtypeCounter] + _tentative[_roomtypeCounter];
                        xlWorkSheet.Cells[rowCount, 10] = "TOTAL ESTIMATED REVENUE";
                        xlWorkSheet.Cells[rowCount, 11] = string.Format("{0:###,###,###,##0.00}", _confirmedRev[_roomtypeCounter] + _tentativeRev[_roomtypeCounter]);
                        _roomtypeCounter++;
                        rowCount = rowCount + 2;
                    }

                    //format
                    xlWorkSheet.Cells[rowCount, 2] = "SUMMARY: " + string.Format("{0:dd-MMM-yyyy}", lStartDate) + " to " + string.Format("{0:dd-MMM-yyyy}", lEndDate) + " BOOKED EVENTS";
                    xlWorkSheet.get_Range("A" + rowCount, _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + rowCount).Merge(Type.Missing);
                    xlWorkSheet.get_Range("A" + rowCount, _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + rowCount).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A" + rowCount, _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + rowCount).Font.Bold = true;
                    //end

                    rowCount++;
                    int _summaryStart = rowCount;
                    string _strRoomTypes = "";
                    int _totalEvents = 0;
                    decimal _totalConfirmedRev = 0;
                    decimal _totalTentativeRev = 0;
                    for (int i = 0; i < _roomTypes.Rows.Count; i++)
                    {
                        rowCount = _summaryStart;
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 2)] = _roomTypes.Rows[i]["roomtypecode"].ToString();
                        _strRoomTypes = _roomTypes.Rows[i]["roomtypecode"].ToString() + ", ";
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 1] + rowCount, _letterAddress[(i * 4) + 1] + rowCount).Font.Bold = true;
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 1] + rowCount, _letterAddress[(i * 4) + 4] + rowCount).Merge(Type.Missing);
                        rowCount = rowCount + 2;
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 3)] = "CONFIRMED";
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 4)] = "TENTATIVE";
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 5)] = "TOTAL";
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 2] + rowCount, _letterAddress[(i * 4) + 4] + (rowCount + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 1] + rowCount, _letterAddress[(i * 4) + 4] + (rowCount + 2)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                        rowCount++;
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 2)] = "No. of Events";
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 3)] = _confirmed[i];
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 4)] = _tentative[i];
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 5)] = _confirmed[i] + _tentative[i];
                        _totalEvents = _totalEvents + _confirmed[i] + _tentative[i];
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 2] + rowCount, _letterAddress[(i * 4) + 4] + (rowCount + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        rowCount++;
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 2)] = "Revenue";
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 3)] = string.Format("{0:###,###,###,##0.00}", _confirmedRev[i]);
                        _totalConfirmedRev = _totalConfirmedRev + _confirmedRev[i];
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 4)] = string.Format("{0:###,###,###,##0.00}", _tentativeRev[i]);
                        _totalTentativeRev = _totalTentativeRev + _tentativeRev[i];
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 5)] = string.Format("{0:###,###,###,##0.00}", _confirmedRev[i] + _tentativeRev[i]);
                        rowCount++;
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 2)] = "Market Segment";
                        rowCount++;
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 1] + rowCount, _letterAddress[(i * 4) + 3] + (rowCount + _marketSegment.Rows.Count - 1)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 1] + rowCount, _letterAddress[(i * 4) + 3] + (rowCount + _marketSegment.Rows.Count - 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        foreach (DataRow _dRow in _marketSegment.Rows)
                        {
                            xlWorkSheet.Cells[rowCount, ((i * 4) + 2)] = _dRow["Value"].ToString();
                            xlWorkSheet.Cells[rowCount, ((i * 4) + 3)] = getSummary("marketsegment", _dRow["Value"].ToString(), "CONFIRMED", _roomTypes.Rows[i]["roomtypecode"].ToString(),loCalendarOfEvents);
                            xlWorkSheet.Cells[rowCount, ((i * 4) + 4)] = getSummary("marketsegment", _dRow["Value"].ToString(), "TENTATIVE", _roomTypes.Rows[i]["roomtypecode"].ToString(),loCalendarOfEvents);
                            rowCount++;
                        }
                        xlWorkSheet.Cells[rowCount, ((i * 4) + 2)] = "Event Type";
                        rowCount++;
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 1] + rowCount, _letterAddress[(i * 4) + 3] + (rowCount - 1 + _eventTypes.Rows.Count)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                        xlWorkSheet.get_Range(_letterAddress[(i * 4) + 1] + rowCount, _letterAddress[(i * 4) + 3] + (rowCount - 1 + _eventTypes.Rows.Count)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        
                        foreach (DataRow _dRow in _eventTypes.Rows)
                        {
                            xlWorkSheet.Cells[rowCount, ((i * 4) + 2)] = _dRow["eventType"].ToString();
                            xlWorkSheet.Cells[rowCount, ((i * 4) + 3)] = getSummary("eventtype", _dRow["eventType"].ToString(), "CONFIRMED", _roomTypes.Rows[i]["roomtypecode"].ToString(), loCalendarOfEvents);
                            xlWorkSheet.Cells[rowCount, ((i * 4) + 4)] = getSummary("eventtype", _dRow["eventType"].ToString(), "TENTATIVE", _roomTypes.Rows[i]["roomtypecode"].ToString(), loCalendarOfEvents);
                            rowCount++;
                        }
                    }
                    
                    //grand total
                    xlWorkSheet.get_Range(_letterAddress[(_roomTypes.Rows.Count * 4) + 1] + _summaryStart, _letterAddress[(_roomTypes.Rows.Count * 4) + 1] + (_summaryStart + 13)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = "GRAND TOTAL";
                    xlWorkSheet.get_Range(_letterAddress[(_roomTypes.Rows.Count * 4) + 1] + _summaryStart, _letterAddress[(_roomTypes.Rows.Count * 4) + 1] + _summaryStart).Font.Bold = true;
                    _summaryStart++;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = _strRoomTypes.Substring(0, _strRoomTypes.Length - 2);
                    xlWorkSheet.get_Range(_letterAddress[(_roomTypes.Rows.Count * 4) + 1] + (_summaryStart - 1), _letterAddress[(_roomTypes.Rows.Count * 4) + 1] + _summaryStart).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _summaryStart = _summaryStart + 2;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = "No. of Events";
                    _summaryStart++;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = _totalEvents;
                    _summaryStart = _summaryStart + 2;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = "Confirmed Events";
                    _summaryStart++;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = string.Format("{0:###,###,###,##0.00}", _totalConfirmedRev);
                    _summaryStart = _summaryStart + 2;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = "Tentative Events";
                    _summaryStart++;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = string.Format("{0:###,###,###,##0.00}", _totalTentativeRev);
                    _summaryStart = _summaryStart + 2;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = "Total";
                    _summaryStart++;
                    xlWorkSheet.Cells[_summaryStart, (_roomTypes.Rows.Count * 4) + 2] = string.Format("{0:###,###,###,##0.00}", _totalConfirmedRev + _totalTentativeRev);
                    //end

                    rowCount++;
                    _summaryStart = rowCount;
                    for(int i = 0; i < _roomTypes.Rows.Count; i++)
                    {
                        rowCount = _summaryStart;
                        xlWorkSheet.Cells[rowCount, (i + 4)] = _roomTypes.Rows[i]["roomtypecode"].ToString();
                        rowCount++;
                        foreach (DataRow _dRow in _bookingSource.Rows)
                        {
                            xlWorkSheet.Cells[rowCount, 2] = _dRow["Value"].ToString();
                            xlWorkSheet.Cells[rowCount, (i + 4)] = getSummary("source", _dRow["Value"].ToString(), "", _roomTypes.Rows[i]["roomtypecode"].ToString(), loCalendarOfEvents);
                            xlWorkSheet.Cells[rowCount, (4 + _roomTypes.Rows.Count)] = getSummary("source", _dRow["Value"].ToString(), "", "", loCalendarOfEvents);
                            rowCount++;
                        }
                    }
                    xlWorkSheet.Cells[_summaryStart, (4 + _roomTypes.Rows.Count)] = "TOTAL";
                    progress.Close();

                    //format
                    xlWorkSheet.get_Range("A1", _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + "1").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A1", _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + "1").EntireColumn.AutoFit();
                    xlWorkSheet.get_Range("A1", _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + "1").Font.Bold = true;
                    xlWorkSheet.get_Range("A1", _letterAddress[gridCalendarOfEvents.Cols.Count - 1] + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range(_letterAddress[3] + _summaryStart, _letterAddress[(4 + _roomTypes.Rows.Count)] + (rowCount - 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rowCount = rowCount + 2;
                    xlWorkSheet.Cells[rowCount, 9] = "Prepared by";
                    rowCount++;
                    DataTable _user = loReportFacade.getUser(GlobalVariables.goUser.GetType().GetProperty("UserId").GetValue(GlobalVariables.goUser, null).ToString());
                    xlWorkSheet.Cells[rowCount, 9] = _user.Rows[0]["FirstName"].ToString() + " " + _user.Rows[0]["LastName"].ToString();
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 9] = string.Format("{0:MMMM dd, yyyy}", DateTime.Now);
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
                MessageBox.Show("Error at importing to excel\r\n" + ex.Message,"Event Management Plus",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private int getSummary(string pColumn, string pValue, string pStatus, string pRoomType, DataTable pCalendarEvents)
        {
            DataView _dv = pCalendarEvents.DefaultView;
            _dv.RowFilter = "";
            if (pColumn != "source")
            {
                _dv.RowFilter = pColumn + "='" + pValue + "' and status = '" + pStatus + "' and roomtype like '%" + pRoomType + "%'";
            }
            else
            {
                _dv.RowFilter = pColumn + "='" + pValue + "' and roomtype like '%" + pRoomType + "%'";
            }
            return _dv.Count;
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
    }
}