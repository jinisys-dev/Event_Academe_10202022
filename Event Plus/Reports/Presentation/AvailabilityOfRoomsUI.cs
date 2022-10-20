using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using Excel = Microsoft.Office.Interop.Excel;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class AvailabilityOfRoomsUI : Form
    {
        #region "VARIABLES"
        ReportFacade loReportFacade;
        DataTable oRooms;
        DataTable oEvents;
        #endregion

        public AvailabilityOfRoomsUI()
        {
            InitializeComponent();
        }

        private void AvailabilityOfRoomsUI_Load(object sender, EventArgs e)
        {
            loReportFacade = new ReportFacade();
            DateTime _now = DateTime.Now;
            cboMonth.SelectedIndex = _now.Month - 1;
            cboYear.Text = _now.Year.ToString();
            loadAvailabilityOfRooms();
            loadToGrid();
            setButtons();
        }

        private void loadToGrid()
        {
            gridAvailabilityOfRooms.Rows.Count = 2;
            gridAvailabilityOfRooms.Cols.Count = 1;
            if (oRooms != null)
            {
                gridAvailabilityOfRooms.Rows.Count = oRooms.Rows.Count + 2;
                int _row = 2;
                foreach (DataRow _dRow in oRooms.Rows)
                {
                    gridAvailabilityOfRooms.SetData(_row, 0, _dRow["RoomID"]);
                    _row++;
                }

                TimeSpan _time = lEndDate.Subtract(lStartDate);

                // Dan
                // 2012-08-22
                int _diff = _time.Days + 1;
                //int _diff = _time.Days + 2;

                // Gene
                // 2012-01-20
                // Checks if the date range is valid
                if (_time.Days < 0)
                    return;

                gridAvailabilityOfRooms.Cols.Count = _diff + 1;

                for (int i = 1; i <= _diff; i++)
                {
                    gridAvailabilityOfRooms.SetData(0, i, lStartDate.AddDays(i - 1).DayOfWeek.ToString());
                    gridAvailabilityOfRooms.SetData(1, i, lStartDate.AddDays(i - 1).Day);
                }
            }

            if (oEvents != null && oRooms != null)
            {
                int _row = 0;
                DateTime _startDate;
                DateTime _endDate;
                int _intDateDifference = 0;
                int _intGridColumn = 0;
                foreach (DataRow _dRow in oEvents.Rows)
                {
                    if (rdoDateRange.Checked)
                    {
                        TimeSpan _ts = dtpFrom.Value.Date.Subtract(DateTime.Parse(_dRow["fromdate"].ToString()));
                        if (_ts.Days <= 0)
                        {
                            // Difference to be multiplied by negative. ToDate subtracted FromDate
                            _intDateDifference = _ts.Days * -1;
                            _intGridColumn = _intDateDifference + 1;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        TimeSpan _ts = lStartDate.Date.Subtract(DateTime.Parse(_dRow["fromdate"].ToString()));
                        if (_ts.Days <= 0)
                        {
                            // Difference to be multiplied by negative. ToDate subtracted FromDate
                            _intDateDifference = _ts.Days * -1;
                            _intGridColumn = _intDateDifference + 1;
                        }
                        else
                        {
                            return;
                        }
                    }
                    _startDate = DateTime.Parse(_dRow["fromdate"].ToString());
                    _endDate = DateTime.Parse(_dRow["todate"].ToString());
                    _row = getRoomRowNumber(_dRow["RoomID"].ToString());
                    for (int i = 0; _startDate.AddDays(i).Date <= _endDate.Date; i++)
                    {
                        try
                        {
                            if (gridAvailabilityOfRooms.GetDataDisplay(_row, i + _intGridColumn).ToString() == "")
                            {
                                gridAvailabilityOfRooms.SetData(_row, i + _intGridColumn, _dRow["groupName"].ToString());
                            }
                            else
                            {

                                if (!gridAvailabilityOfRooms.GetDataDisplay(_row, i + _intGridColumn).ToString().Contains(_dRow["groupName"].ToString()))
                                {
                                    string _stringOldGroup = gridAvailabilityOfRooms.GetDataDisplay(_row, i + _intGridColumn).ToString();
                                    gridAvailabilityOfRooms.SetData(_row, i + _intGridColumn, _stringOldGroup + ", " + _dRow["groupName"].ToString());
                                }
                                else
                                {
                                    TimeSpan _TimeSpanDifference = _startDate - lStartDate;
                                    int _intBuffer = (int)_TimeSpanDifference.TotalDays;
                                    if (!gridAvailabilityOfRooms.GetDataDisplay(_row, i + _intGridColumn).ToString().Contains(_dRow["groupName"].ToString()))
                                    {
                                        string _stringOldGroup = gridAvailabilityOfRooms.GetDataDisplay(_row, i + _intGridColumn).ToString();
                                        gridAvailabilityOfRooms.SetData(_row, i + _intGridColumn, _stringOldGroup + ", " + _dRow["groupName"].ToString());
                                    }
                                }

                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {

                        }
                    }
                }

            }
            // Daniel Balagosa
            // August 22, 2012
            // Comment below because obsolete
            /*
            if (oEvents != null && oRooms != null)
            {
                int _row = 0;
                DateTime _startDate;
                DateTime _endDate;
                int _colStart = 1;

                foreach (DataRow _dRow in oEvents.Rows)
                {
                    _startDate = DateTime.Parse(_dRow["fromdate"].ToString());
                    _endDate = DateTime.Parse(_dRow["todate"].ToString());
                    _row = getRoomRowNumber(_dRow["RoomID"].ToString());

                    if (_startDate > lStartDate)
                    {
                        // Gene
                        // 2012-01-24
                        // Removed the time in lStartDate
                        //TimeSpan _ts = _startDate.Subtract(lStartDate);
                        TimeSpan _ts = Convert.ToDateTime(_startDate.ToShortDateString()).Subtract(Convert.ToDateTime(lStartDate.ToShortDateString()));

                        _colStart = _ts.Days + 1;
                    }
                    else
                    {
                        _colStart = 1;
                        _startDate = lStartDate;
                    }

                    if (_endDate > lEndDate)
                    {
                        _endDate = lEndDate;
                    }

                    for (int i = 0; _startDate.AddDays(i).Date <= _endDate.Date; i++)
                    {
                        if(gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString() == "")
                        {
                            gridAvailabilityOfRooms.SetData(_row, _colStart + i, _dRow["groupName"].ToString());
                        }
                        else
                        {
                            // Daniel Balagosa
                            // June 22, 2012
                            // Wrong GRID.getDataDisplay() of column i
                            /* Gene
                            // * 02-Mar-12
                            // * Added condition to check if group name is already in the cell
                            // 
                            // Old Code
                            //gridAvailabilityOfRooms.SetData(_row, _colStart + i, gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString() + ", " + _dRow["groupName"].ToString());

                            if (!gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString().Contains(_dRow["groupName"].ToString()))
                            {
                                string _stringOldGroup = gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString();
                                gridAvailabilityOfRooms.SetData(_row, _colStart + i, _stringOldGroup + ", " + _dRow["groupName"].ToString());
                            }
                            else
                            {
                                TimeSpan _TimeSpanDifference = _startDate - lStartDate;
                                int _intBuffer = (int)_TimeSpanDifference.TotalDays;
                                if (!gridAvailabilityOfRooms.GetDataDisplay(_row, _intBuffer + 1).ToString().Contains(_dRow["groupName"].ToString()))
                                {
                                    gridAvailabilityOfRooms.SetData(_row, _colStart + 0, gridAvailabilityOfRooms.GetDataDisplay(_row, _intBuffer + 1).ToString() + ", " + _dRow["groupName"].ToString());
                                }
                            }

                        }
                    }
                }
            }
            */
            // END
        }

        /*
        private void loadToGrid()
        {
            gridAvailabilityOfRooms.Rows.Count = 2;
            gridAvailabilityOfRooms.Cols.Count = 1;
            if (oRooms != null)
            {
                gridAvailabilityOfRooms.Rows.Count = oRooms.Rows.Count + 2;
                int _row = 2;
                foreach (DataRow _dRow in oRooms.Rows)
                {
                    gridAvailabilityOfRooms.SetData(_row, 0, _dRow["RoomID"]);
                    _row++;
                }

                TimeSpan _time = lEndDate.Subtract(lStartDate);

                // Dan
                // 2012-08-22
                int _diff = _time.Days + 1;
                //int _diff = _time.Days + 2;

                // Gene
                // 2012-01-20
                // Checks if the date range is valid
                if (_time.Days < 0)
                    return;

                gridAvailabilityOfRooms.Cols.Count = _diff + 1;
                
                for (int i = 1; i <= _diff; i++)
                {
                    gridAvailabilityOfRooms.SetData(0, i, lStartDate.AddDays(i - 1).DayOfWeek.ToString());
                    gridAvailabilityOfRooms.SetData(1, i, lStartDate.AddDays(i - 1).Day);
                }
            }

            // Daniel Balagosa
            // August 22, 2012
            // Comment below because obsolete
            
            if (oEvents != null && oRooms != null)
            {
                int _row = 0;
                DateTime _startDate;
                DateTime _endDate;
                int _colStart = 1;

                foreach (DataRow _dRow in oEvents.Rows)
                {
                    _startDate = DateTime.Parse(_dRow["fromdate"].ToString());
                    _endDate = DateTime.Parse(_dRow["todate"].ToString());
                    _row = getRoomRowNumber(_dRow["RoomID"].ToString());

                    if (_startDate > lStartDate)
                    {
                        // Gene
                        // 2012-01-24
                        // Removed the time in lStartDate
                        //TimeSpan _ts = _startDate.Subtract(lStartDate);
                        TimeSpan _ts = Convert.ToDateTime(_startDate.ToShortDateString()).Subtract(Convert.ToDateTime(lStartDate.ToShortDateString()));

                        _colStart = _ts.Days + 1;
                    }
                    else
                    {
                        _colStart = 1;
                        _startDate = lStartDate;
                    }

                    if (_endDate > lEndDate)
                    {
                        _endDate = lEndDate;
                    }

                    for (int i = 0; _startDate.AddDays(i).Date <= _endDate.Date; i++)
                    {
                        if(gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString() == "")
                        {
                            gridAvailabilityOfRooms.SetData(_row, _colStart + i, _dRow["groupName"].ToString());
                        }
                        else
                        {
                            // Daniel Balagosa
                            // June 22, 2012
                            // Wrong GRID.getDataDisplay() of column i
                            // Gene
                            // * 02-Mar-12
                            // * Added condition to check if group name is already in the cell
                            // 
                            // Old Code
                            //gridAvailabilityOfRooms.SetData(_row, _colStart + i, gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString() + ", " + _dRow["groupName"].ToString());
                            
                            if (!gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString().Contains(_dRow["groupName"].ToString()))
                            {
                                string _stringOldGroup = gridAvailabilityOfRooms.GetDataDisplay(_row, i + 1).ToString();
                                gridAvailabilityOfRooms.SetData(_row, _colStart + i, _stringOldGroup + ", " + _dRow["groupName"].ToString());
                            }
                            else
                            {
                                TimeSpan _TimeSpanDifference = _startDate - lStartDate;
                                int _intBuffer = (int)_TimeSpanDifference.TotalDays;
                                if (!gridAvailabilityOfRooms.GetDataDisplay(_row, _intBuffer + 1).ToString().Contains(_dRow["groupName"].ToString()))
                                {
                                    gridAvailabilityOfRooms.SetData(_row, _colStart + 0, gridAvailabilityOfRooms.GetDataDisplay(_row, _intBuffer + 1).ToString() + ", " + _dRow["groupName"].ToString());
                                }
                            }

                        }
                    }
                }
            }
            

        }
        */

        private int getRoomRowNumber(string pRoomID)
        {
            int _row = 0;
            int _counter = 2;
            foreach (DataRow _dRow in oRooms.Rows)
            {
                
                if (_dRow["RoomID"].ToString() == pRoomID)
                {
                    _row = _counter;
                    break;
                }
                _counter++;
            }
            return _row;
        }

        DateTime lStartDate;
        DateTime lEndDate;
        private void loadAvailabilityOfRooms()
        {
            try
            {
                if (cboMonth.Text != "" && cboYear.Text != "")
                {
                    if (rdoMonthly.Checked)
                    {
                        int _month = cboMonth.SelectedIndex + 1;
                        lStartDate = DateTime.Parse(cboYear.Text + "-" + _month.ToString() + "-01");
                        lEndDate = DateTime.Parse(cboYear.Text + "-" + _month.ToString() + "-" + DateTime.DaysInMonth(int.Parse(cboYear.Text), _month));
                    }
                    else
                    {
                        lStartDate = dtpFrom.Value;
                        lEndDate = dtpTo.Value;
                    }

                    oRooms = loReportFacade.getRooms();
                    oEvents = loReportFacade.getEvents(lStartDate, lEndDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading availability of rooms\r\n" + ex.Message);
            }
        }

        private void setButtons()
        {
            if (rdoMonthly.Checked)
            {
                cboYear.Enabled = true;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboMonth.Enabled = true;
            }
            else
            {
                cboYear.Enabled = false;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                cboMonth.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadAvailabilityOfRooms();
            loadToGrid();
        }

        private void rdoDateRange_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadAvailabilityOfRooms();
            loadToGrid();
            
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadAvailabilityOfRooms();
            loadToGrid();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadAvailabilityOfRooms();
            loadToGrid();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            // Gene
            // 2012-01-24
            // Added try catch for invalid date range
            try
            {
                /* Gene
                 * 28-Feb-12
                 * assign first the max date before assigning the min date to avoid error
                 */
                // Old Code
                //dtpTo.MinDate = dtpFrom.Value;
                //dtpTo.MaxDate = dtpFrom.Value.AddDays(7);
                /* Gene
                 * 02-Mar-12
                 * removed the limit of dtpTo
                 */
                // New Code
                dtpTo.MinDate = dtpFrom.Value;
                dtpTo.MaxDate = dtpFrom.Value.AddDays(31);
            }
            catch
            { }

            cboYear_SelectedIndexChanged(null, null);
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            cboYear_SelectedIndexChanged(null, null);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string strFileName = "Availability of Rooms (" + string.Format("{0:dd-MMM-yyyy}", lStartDate) + " to " + string.Format("{0:dd-MMM-yyyy}", lEndDate) + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;

                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                    ProgressForm progress = new ProgressForm();
                    int count = gridAvailabilityOfRooms.Rows.Count + 1;
                    progress = new ProgressForm(count, "Exporting Availability of Rooms......");
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
                    else
                    {
                        _dateHeader = string.Format("{0:MMMM dd yyyy}", lStartDate) + "-" + string.Format("{0:MMMM dd yyyy}", lEndDate);
                        _reportType = "DATE RANGE";
                    }

                    //add report header
                    xlWorkSheet.Cells[rowCount, 1] = "PHILIPPINE INTERNATIONAL CONVENTION CENTER";
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "Reservation Unit";
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = _dateHeader;
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "AVAILABILITY OF ROOMS/AREAS FOR THE MONTH OF SEPTEMBER";
                    rowCount++;

                    //add values
                    for (int _row = 1; _row <= gridAvailabilityOfRooms.Rows.Count; _row++)
                    {
                        for (int _col = 1; _col <= gridAvailabilityOfRooms.Cols.Count; _col++)
                        {
                            xlWorkSheet.Cells[rowCount, _col] = gridAvailabilityOfRooms.GetDataDisplay(_row - 1, _col - 1);
                            if (_row > 2 && _col > 1 && gridAvailabilityOfRooms.GetDataDisplay(_row - 1, _col - 1) != "")
                            {
                                xlWorkSheet.get_Range(_letterAddress[_col -1] + rowCount,_letterAddress[_col -1] + rowCount).Interior.ColorIndex = 16;
                            }
                        }
                        rowCount++;
                        progress.updateProgress(rowCount);
                    }

                    //format
                    xlWorkSheet.get_Range("A1", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + "1").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A2", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + "2").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A3", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + "3").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A4", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + "4").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A1", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + "4").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    xlWorkSheet.get_Range("A5", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + "6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A5", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + "6").Font.Bold = true;
                    xlWorkSheet.get_Range("A7", "A" + (gridAvailabilityOfRooms.Rows.Count + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    xlWorkSheet.get_Range("A5", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + ((gridAvailabilityOfRooms.Rows.Count + 5))).Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //xlWorkSheet.get_Range("A1", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + ((gridAvailabilityOfRooms.Rows.Count + 5))).EntireColumn.AutoFit();
                    xlWorkSheet.get_Range("A1", _letterAddress[gridAvailabilityOfRooms.Cols.Count - 1] + ((gridAvailabilityOfRooms.Rows.Count + 5))).EntireColumn.WrapText = true;

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
                MessageBox.Show("Error exporting to excel\r\n" + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}