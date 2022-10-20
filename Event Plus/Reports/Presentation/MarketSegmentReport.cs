using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Excel = Microsoft.Office.Interop.Excel;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class MarketSegmentReport : Form
    {
        public MarketSegmentReport()
        {
            InitializeComponent();
        }

        private void MarketSegmentReport_Load(object sender, EventArgs e)
        {
            
        }

        DataTable loDataTable = null;
        private void setupGrid()
        {
            grdReport.AllowMerging = AllowMergingEnum.Spill;
            grdReport.SelectionMode = SelectionModeEnum.Cell;
            grdReport.ExtendLastCol = true;
            grdReport.Tree.Style = TreeStyleFlags.Simple;
            grdReport.Tree.Column = 0;

            // set up grid styles
            grdReport.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grdReport.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter;

            CellStyle _cellStyle = grdReport.Styles[CellStyleEnum.Subtotal0];
            _cellStyle.BackColor = Color.Azure;
            _cellStyle.ForeColor = Color.Black;
            _cellStyle.DataType = Type.GetType("double");
            _cellStyle.Format = "##0.00";   

            //setup data for grid
            grdReport.Rows.Count = 1;
            ReportFacade _oReportFacade = new ReportFacade();
            

            if (rdbMonthly.Checked == true)
            {
                /* Gene
                 * 2-Feb-12
                 * Check if the date range is valid
                 */
                if (dtpEndDate.Value.CompareTo(dtpStartDate.Value) < 0)
                {
                    loDataTable = null;
                    return;
                }

                if (rdbComparison.Checked == true)
                {                                        
                    loDataTable = _oReportFacade.getMonthlyRangeMarketSegment(dtpStartDate.Value.Month, dtpStartDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Year);
                    int _colCount = 4;
                    grdReport.Cols.Count = _colCount;

                    foreach (DataRow _dRow in loDataTable.Rows)
                    {
                        string _marketSegment = _dRow["Market Segment"].ToString();
                        DateTime _date = DateTime.Parse(_dRow["date"].ToString());
                        int _count = int.Parse(_dRow["Total Count"].ToString());

                        grdReport.Rows.Count++;
                        int _rowCount = grdReport.Rows.Count - 1;
                        //set column header
                        grdReport.Cols[0].Caption = "Market Segment";
                        grdReport.Cols[1].Caption = "Month";
                        grdReport.Cols[2].Caption = "Room Type";
                        grdReport.Cols[3].Caption = _date.Year.ToString();
                        grdReport.Cols[3].Name = "Total Count";

                        grdReport.SetData(grdReport.Rows.Count - 1, 0, _marketSegment); //set market segment data
                        grdReport.SetData(grdReport.Rows.Count - 1, 1, _date.ToString("MMMM")); //set date
                        grdReport.SetData(grdReport.Rows.Count - 1, 2, _dRow["Room Type"].ToString()); //set total count data
                        grdReport.SetData(grdReport.Rows.Count - 1, 3, _count); //set total count data

                        //get previous year's comparison
                        for (int _ctr = 1; _ctr <= int.Parse(nudYears.Value.ToString()); _ctr++)
                        {
                            DataTable _oPreviousYear = _oReportFacade.getTotalCountForPreviousYears(_date.Month, _date.Year - _ctr, _marketSegment);

                            if (_oPreviousYear.Rows.Count == 0 || _oPreviousYear == null)
                            {
                                if (grdReport.Cols.Count <= 3)
                                {
                                    grdReport.Cols.Count += 1;
                                    int _year = _date.Year - _ctr;
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                }
                                else
                                {
                                    try
                                    {
                                        int _year = _date.Year - _ctr;
                                        grdReport.SetData(_rowCount, _year.ToString(), "0");
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        int _year = _date.Year - _ctr;
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                    }
                                }
                            }

                            foreach (DataRow _row in _oPreviousYear.Rows)
                            {
                                if (grdReport.Cols.Count != _colCount)
                                {
                                    grdReport.Cols.Count += 1;
                                    DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                }
                                else
                                {
                                    try
                                    {
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.SetData(_rowCount, _prevDate.Year.ToString(), _row["Total Count"].ToString());
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                    }
                                }
                            }
                            _colCount = grdReport.Cols.Count;
                        }

                        //change format of date in the data row
                        _dRow["date"] = _date.ToString("MMMM yyyy");
                    }
                }
                else if (rdbRoomtype.Checked == true)
                {
                    loDataTable = _oReportFacade.getMonthlyRangeMarketSegmentPerRoomType(dtpStartDate.Value.Month, dtpStartDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Year);

                    int _colCount = 5;
                    grdReport.Cols.Count = _colCount;

                    foreach (DataRow _dRow in loDataTable.Rows)
                    {
                        string _roomType = _dRow["Room Type"].ToString();
                        string _roomID = _dRow["Room ID"].ToString();
                        DateTime _date = DateTime.Parse(_dRow["date"].ToString());
                        int _count = int.Parse(_dRow["Total Count"].ToString());

                        grdReport.Rows.Count++;
                        int _rowCount = grdReport.Rows.Count - 1;
                        //set column header
                        grdReport.Cols[0].Caption = "Room Type";
                        grdReport.Cols[1].Caption = "Room ID";
                        grdReport.Cols[2].Caption = "Market Segment";
                        grdReport.Cols[3].Caption = "Month";
                        grdReport.Cols[4].Caption = _date.Year.ToString();
                        grdReport.Cols[4].Name = "Total Count";

                        grdReport.SetData(grdReport.Rows.Count - 1, 0, _roomType); //set room type data
                        grdReport.SetData(grdReport.Rows.Count - 1, 1, _roomID); //set room id data
                        grdReport.SetData(grdReport.Rows.Count - 1, 2, _dRow["Market Segment"].ToString());
                        grdReport.SetData(grdReport.Rows.Count - 1, 3, _date.ToString("MMMM")); //set date
                        grdReport.SetData(grdReport.Rows.Count - 1, 4, _count); //set total count data

                        //get previous year's comparison
                        for (int _ctr = 1; _ctr <= int.Parse(nudYears.Value.ToString()); _ctr++)
                        {
                            DataTable _oPreviousYear = _oReportFacade.getTotalCountForPreviousYearsPerRoomType(_date.Month, _date.Year - _ctr, _roomID);

                            if (_oPreviousYear.Rows.Count == 0 || _oPreviousYear == null)
                            {
                                if (grdReport.Cols.Count <= 4)
                                {
                                    grdReport.Cols.Count += 1;
                                    int _year = _date.Year - _ctr;
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                }
                                else
                                {
                                    try
                                    {
                                        int _year = _date.Year - _ctr;
                                        grdReport.SetData(_rowCount, _year.ToString(), "0");
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        int _year = _date.Year - _ctr;
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                    }
                                }
                            }

                            foreach (DataRow _row in _oPreviousYear.Rows)
                            {
                                if (grdReport.Cols.Count != _colCount)
                                {
                                    grdReport.Cols.Count += 1;
                                    DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                }
                                else
                                {
                                    try
                                    {
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.SetData(_rowCount, _prevDate.Year.ToString(), _row["Total Count"].ToString());
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                    }
                                }
                            }
                            _colCount = grdReport.Cols.Count;
                        }
                        //change format of date in the data row
                        _dRow["date"] = _date.ToString("MMMM yyyy");
                    }
                }

                grdReport.AutoSizeCols();
                loDataTable.AcceptChanges();
            }
            else if (rdbYearly.Checked == true)
            {
                if (rdbComparison.Checked == true)
                {
                    loDataTable = _oReportFacade.getMonthlyRangeMarketSegment(1, dtpAnnual.Value.Year, 12, dtpAnnual.Value.Year);
                    int _colCount = 4;
                    grdReport.Cols.Count = _colCount;

                    foreach (DataRow _dRow in loDataTable.Rows)
                    {
                        string _marketSegment = _dRow["Market Segment"].ToString();
                        DateTime _date = DateTime.Parse(_dRow["date"].ToString());
                        int _count = int.Parse(_dRow["Total Count"].ToString());

                        grdReport.Rows.Count++;
                        int _rowCount = grdReport.Rows.Count - 1;
                        //set column header
                        grdReport.Cols[0].Caption = "Market Segment";
                        grdReport.Cols[1].Caption = "Month";
                        grdReport.Cols[2].Caption = "Room Type";
                        grdReport.Cols[3].Caption = _date.Year.ToString();
                        grdReport.Cols[3].Name = "Total Count";

                        grdReport.SetData(grdReport.Rows.Count - 1, 0, _marketSegment); //set market segment data
                        grdReport.SetData(grdReport.Rows.Count - 1, 1, _date.ToString("MMMM")); //set date
                        grdReport.SetData(grdReport.Rows.Count - 1, 2, _dRow["Room Type"].ToString()); //set total count data
                        grdReport.SetData(grdReport.Rows.Count - 1, 3, _count); //set total count data

                        //get previous year's comparison
                        for (int _ctr = 1; _ctr <= int.Parse(nudYears.Value.ToString()); _ctr++)
                        {
                            DataTable _oPreviousYear = _oReportFacade.getTotalCountForPreviousYears(_date.Month, _date.Year - _ctr, _marketSegment);

                            if (_oPreviousYear.Rows.Count == 0 || _oPreviousYear == null)
                            {
                                if (grdReport.Cols.Count <= 3)
                                {
                                    grdReport.Cols.Count += 1;
                                    int _year = _date.Year - _ctr;
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                }
                                else
                                {
                                    try
                                    {
                                        int _year = _date.Year - _ctr;
                                        grdReport.SetData(_rowCount, _year.ToString(), "0");
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        int _year = _date.Year - _ctr;
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                    }
                                }
                            }

                            foreach (DataRow _row in _oPreviousYear.Rows)
                            {
                                if (grdReport.Cols.Count != _colCount)
                                {
                                    grdReport.Cols.Count += 1;
                                    DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                }
                                else
                                {
                                    try
                                    {
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.SetData(_rowCount, _prevDate.Year.ToString(), _row["Total Count"].ToString());
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                    }
                                }
                            }
                            _colCount = grdReport.Cols.Count;
                        }

                        //change format of date in the data row
                        _dRow["date"] = _date.ToString("MMMM yyyy");
                    }
                }
                else if (rdbRoomtype.Checked == true)
                {
                    loDataTable = _oReportFacade.getMonthlyRangeMarketSegmentPerRoomType(1, dtpAnnual.Value.Year, 12, dtpAnnual.Value.Year);

                    int _colCount = 5;
                    grdReport.Cols.Count = _colCount;

                    foreach (DataRow _dRow in loDataTable.Rows)
                    {
                        string _roomType = _dRow["Room Type"].ToString();
                        string _roomID = _dRow["Room ID"].ToString();
                        DateTime _date = DateTime.Parse(_dRow["date"].ToString());
                        int _count = int.Parse(_dRow["Total Count"].ToString());

                        grdReport.Rows.Count++;
                        int _rowCount = grdReport.Rows.Count - 1;
                        //set column header
                        grdReport.Cols[0].Caption = "Room Type";
                        grdReport.Cols[1].Caption = "Room ID";
                        grdReport.Cols[2].Caption = "Market Segment";
                        grdReport.Cols[3].Caption = "Month";
                        grdReport.Cols[4].Caption = _date.Year.ToString();
                        grdReport.Cols[4].Name = "Total Count";

                        grdReport.SetData(grdReport.Rows.Count - 1, 0, _roomType); //set room type data
                        grdReport.SetData(grdReport.Rows.Count - 1, 1, _roomID); //set room id data
                        grdReport.SetData(grdReport.Rows.Count - 1, 2, _dRow["Market Segment"].ToString());
                        grdReport.SetData(grdReport.Rows.Count - 1, 3, _date.ToString("MMMM")); //set date
                        grdReport.SetData(grdReport.Rows.Count - 1, 4, _count); //set total count data

                        //get previous year's comparison
                        for (int _ctr = 1; _ctr <= int.Parse(nudYears.Value.ToString()); _ctr++)
                        {
                            DataTable _oPreviousYear = _oReportFacade.getTotalCountForPreviousYearsPerRoomType(_date.Month, _date.Year - _ctr, _roomID);

                            if (_oPreviousYear.Rows.Count == 0 || _oPreviousYear == null)
                            {
                                if (grdReport.Cols.Count <= 4)
                                {
                                    grdReport.Cols.Count += 1;
                                    int _year = _date.Year - _ctr;
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                }
                                else
                                {
                                    try
                                    {
                                        int _year = _date.Year - _ctr;
                                        grdReport.SetData(_rowCount, _year.ToString(), "0");
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        int _year = _date.Year - _ctr;
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, "0");
                                    }
                                }
                            }

                            foreach (DataRow _row in _oPreviousYear.Rows)
                            {
                                if (grdReport.Cols.Count != _colCount)
                                {
                                    grdReport.Cols.Count += 1;
                                    DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                    grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                    grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                    grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                }
                                else
                                {
                                    try
                                    {
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.SetData(_rowCount, _prevDate.Year.ToString(), _row["Total Count"].ToString());
                                    }
                                    catch
                                    {
                                        grdReport.Cols.Count += 1;
                                        DateTime _prevDate = DateTime.Parse(_row["date"].ToString());
                                        grdReport.Cols[grdReport.Cols.Count - 1].Caption = _prevDate.Year.ToString();
                                        grdReport.Cols[grdReport.Cols.Count - 1].Name = _prevDate.Year.ToString();
                                        grdReport.SetData(_rowCount, grdReport.Cols.Count - 1, _row["Total Count"].ToString());
                                    }
                                }
                            }
                            _colCount = grdReport.Cols.Count;
                        }
                        //change format of date in the data row
                        _dRow["date"] = _date.ToString("MMMM yyyy");
                    }
                }

                grdReport.AutoSizeCols();
                loDataTable.AcceptChanges();
            }
            /* Gene
             * 29-Feb-12
             */
            // Old Code
            //string str = loDataTable.Rows[0]["date"].ToString();
            string str = "";
            if (loDataTable.Rows.Count > 0)
                str = loDataTable.Rows[0]["date"].ToString();
            grdReportRefresh();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            setupGrid();
        }

        private void grdReportRefresh()
        {
            try
            {
                // total on Revenue
                int _totalCount = grdReport.Cols["Total Count"].SafeIndex;
                string _caption = "Current year Percentage for {0}";

                // calculate levels of totals
                grdReport.Subtotal(AggregateEnum.Percent, 0, 0, _totalCount, _caption);
                grdReport.Tree.Show(1);
                grdReport.Tree.Sort(1, SortFlags.Descending, 0, 1);
                // autosize the grid to accommodate tree
                grdReport.AutoSizeCols(1, 0, grdReport.Rows.Count - 1, 0, 50, AutoSizeFlags.IgnoreHidden);
            }
            catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /* Gene
             * 2-Feb-12
             * Checks if loDataTable is null
             */
            if (loDataTable == null)
                return;
            

            string _groupType = "";
            if (rdbComparison.Checked == true)
            {
                _groupType = "Market Segment";
            }
            else if (rdbRoomtype.Checked == true)
            {
                _groupType = "Room Type";
            }

            Report_Documents.Marketing_And_Sales.MarketSegmentReport _oReport = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales.MarketSegmentReport();
            ReportViewer _oReportViewer = new ReportViewer();

            _oReport.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
            _oReport.Database.Tables[1].SetDataSource(loDataTable);
            _oReport.DataDefinition.Groups[0].ConditionField = _oReport.Database.Tables[1].Fields[_groupType];
            _oReport.SetParameterValue(0, "REPORT PER " + _groupType.ToUpper());
            _oReportViewer.rptViewer.ReportSource = _oReport;
            _oReportViewer.MdiParent = this.MdiParent;
            _oReportViewer.Show();
        }

        /// <summary>
        /// Gene
        /// 02-Mar-12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (loDataTable == null)
                return;

            string strFileName = "";
            
            if (rdbMonthly.Checked == true)
            {
                strFileName = "Market Segment Report for the months of " + dtpStartDate.Value.ToString("y") + "" + " to " + dtpEndDate.Value.ToString("y");
            }
            else if (rdbYearly.Checked == true)
            {
                strFileName = "Market Segment Report for the year " + dtpAnnual.Value.Year;
            }

            sfdExportToExcel.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
            sfdExportToExcel.FileName = strFileName;
            DialogResult _result = sfdExportToExcel.ShowDialog();

            if (_result == DialogResult.OK)
            {
                string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                ProgressForm progress = new ProgressForm();
                
                progress = new ProgressForm(grdReport.Rows.Count, "Exporting Market Segment Report......");
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

                // Header
                xlWorkSheet.Cells[rowCount, 1] = strFileName.ToUpper();
                rowCount = rowCount + 2;

                for (int r = 0; r < grdReport.Rows.Count; r++)
                {
                    for (int c = 0; c < grdReport.Cols.Count; c++)
                    {
                        xlWorkSheet.Cells[rowCount, c + 1] = grdReport.GetDataDisplay(r, c);
                        if (grdReport.GetDataDisplay(r, 2).Trim() == "" && (c == grdReport.Cols.Count - 1))
                        {
                            xlWorkSheet.get_Range("A" + rowCount, "C" + rowCount).Merge(Type.Missing);
                            xlWorkSheet.get_Range("A" + rowCount, _letterAddress[c] + rowCount).Font.Bold = true;
                        }
                    }
                    rowCount++;
                }
                //borders
                xlWorkSheet.get_Range("A3", _letterAddress[grdReport.Cols.Count - 1] + (rowCount - 1)).Borders.Weight = Excel.XlBorderWeight.xlThin;                
                //end borders           

                // format header
                xlWorkSheet.get_Range("A1", _letterAddress[grdReport.Cols.Count - 1] + "1").Merge(Type.Missing);
                xlWorkSheet.get_Range("A1", _letterAddress[grdReport.Cols.Count - 1] + "1").EntireColumn.AutoFit();                
                xlWorkSheet.get_Range("A1", _letterAddress[grdReport.Cols.Count - 1] + "1").Font.Bold = true;
                xlWorkSheet.get_Range("A1", _letterAddress[grdReport.Cols.Count - 1] + "1").WrapText = true;
                xlWorkSheet.get_Range("A1", _letterAddress[grdReport.Cols.Count - 1] + "1").EntireRow.AutoFit();
                xlWorkSheet.get_Range("A1", _letterAddress[grdReport.Cols.Count - 1] + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("A1", _letterAddress[grdReport.Cols.Count - 1] + "1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                // format column header
                xlWorkSheet.get_Range("A3", _letterAddress[grdReport.Cols.Count - 1] + "3").Font.Bold = true;
                xlWorkSheet.get_Range("A3", _letterAddress[grdReport.Cols.Count - 1] + "3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                progress.Close();

                try
                {
                    xlWorkBook.SaveAs(sfdExportToExcel.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    MessageBox.Show("File Saved", "Event Plus", MessageBoxButtons.OK,MessageBoxIcon.Information);
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