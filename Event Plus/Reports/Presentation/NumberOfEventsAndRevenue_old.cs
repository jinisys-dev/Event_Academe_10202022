using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using System.IO;
using System.Web.UI;
using Jinisys.Hotel.BusinessSharedClasses;
using Excel = Microsoft.Office.Interop.Excel;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales;
using CrystalDecisions.CrystalReports.Engine;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class NumberOfEventsAndRevenue_old : Form
    {
        #region "VARIABLES"
        private DataTable loRevenue;
        private string loFromDate;
        private string loToDate;
        #endregion

        public NumberOfEventsAndRevenue_old()
        {

            InitializeComponent();
        }

        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                disableOptions();
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disableOptions()
        {
            if (rdoMonthly.Checked)
            {
                cboYearly.Enabled = false;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                cboYearTo.Enabled = false;
                cboYearFrom.Enabled = false;
            }
            else if (rdoYearly.Checked)
            {
                cboYearFrom.Enabled = false;
                cboYearTo.Enabled = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboYearly.Enabled = true;
            }
            else
            {
                cboYearFrom.Enabled = true;
                cboYearTo.Enabled = true;
                cboYearly.Enabled = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                disableOptions();
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdoDateRange_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                disableOptions();
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NumberOfEventsAndRevenue_Load(object sender, EventArgs e)
        {
            gridEventsRevenue.Rows.Count = 1;
            cboYearly.SelectedItem = DateTime.Now.Year.ToString();
            cboYearFrom.SelectedItem = DateTime.Now.Year.ToString();
            cboYearTo.SelectedItem = DateTime.Now.Year.ToString();
            disableOptions();
            //rdoMonthly.Checked = true;

            prepareGrid();
        }

        private ReportFacade loReportFacade = new ReportFacade();
        //load transactions
        private void loadTransactions()
        {
            try
            {
                if (rdoMonthly.Checked)
                {
                    //loFromDate = cboYear.Text + "-" + _month + "-01";
                    //int _lastDay = DateTime.DaysInMonth(Convert.ToInt32(cboYear.Text), _month);
                    //loToDate = cboYear.Text + "-" + _month + "-" + _lastDay;
                    loFromDate = dtpFrom.Value.Year + "-" + dtpFrom.Value.Month + "-01";
                    loToDate = dtpTo.Value.Year + "-" + dtpTo.Value.Month + "-" + DateTime.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month);
                }
                else if (rdoYearly.Checked)
                {
                    loFromDate = cboYearly.Text + "-01-01";
                    loToDate = cboYearly.Text + "-12-31";
                }
                else
                {
                    //loFromDate = string.Format("{0:yyyy-MM-dd}", dtpFrom.Value);
                    //loToDate = string.Format("{0:yyyy-MM-dd}", dtpTo.Value);
                    loFromDate = cboYearFrom.Text + "-01-01";
                    loToDate = cboYearTo.Text + "-12-31";
                }
                loRevenue = loReportFacade.getRangeFolioTransactions(loFromDate, loToDate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error @loadingTransactions \r\n" + ex.Message);
            }
        }

        //prepare grid headers
        private void prepareGrid()
        {
            try
            {
                loadTransactions();
                getDistinctTransactions();
                int _noOfCols = loTransactionList.Count + 4;
                gridEventsRevenue.Cols.Count = _noOfCols;
                gridEventsRevenue.Cols[0].Caption = "Folio Id";
                gridEventsRevenue.Cols[0].Name = "Folio Id";
                gridEventsRevenue.Cols[1].Caption = "Event Name";
                gridEventsRevenue.Cols[1].Width = 120;
                gridEventsRevenue.Cols[1].Name = "Event Name";
                gridEventsRevenue.Cols[2].Caption = "Event Date";
                gridEventsRevenue.Cols[2].Width = 65;
                gridEventsRevenue.Cols[2].Name = "Event Date";
                int _noOfDebit = lNoOfDebit + 3; //used to color debit transactions
                for (int i = 3; i < _noOfCols - 1; i++)
                {
                    gridEventsRevenue.Cols[i].Caption = loTransactionList[i - 3];
                    gridEventsRevenue.Cols[i].Name = loTransactionList[i - 3];
                    if (loTransactionList[i - 3].Length > 4)
                        gridEventsRevenue.Cols[i].Width = loTransactionList[i - 3].Length * 8;
                    else
                        gridEventsRevenue.Cols[i].Width = 60;
                    if (i < _noOfDebit)
                        gridEventsRevenue.Cols[i].StyleFixed = gridEventsRevenue.Styles["debit"];
                    else
                        gridEventsRevenue.Cols[i].StyleFixed = gridEventsRevenue.Styles["credit"];
                }
                gridEventsRevenue.Cols[_noOfCols - 1].Caption = "Total Revenue";
                gridEventsRevenue.Cols[_noOfCols - 1].StyleFixed = gridEventsRevenue.Styles["total"];
                gridEventsRevenue.Cols[_noOfCols - 1].Name = "Total Revenue";
                gridEventsRevenue.Cols[_noOfCols - 1].Width = 100;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @preparing grid\r\n" + ex.Message);
            }
        }

        //get distinct transaction headers
        private List<string> loTransactionList = new List<string>();
        private int lNoOfDebit = 0;
        private void getDistinctTransactions()
        {
            lNoOfDebit = 0;
            loTransactionList.Clear();
            if (loRevenue != null)
            {
                DataView _dv = loRevenue.DefaultView;
                _dv.Sort = "acctSide DESC, transaction ASC";
                DataTable _dt = _dv.ToTable();
                foreach (DataRow _dRow in _dt.Rows)
                {
                    if (!loTransactionList.Contains(_dRow["transaction"].ToString()))
                    {
                        loTransactionList.Add(_dRow["transaction"].ToString());
                        if (_dRow["acctSide"].ToString() == "DEBIT")
                        {
                            lNoOfDebit++;
                        }
                    }
                }
            }
        }

        //get distince folio id on the list
        private List<string> loFolioDates = new List<string>();
        private List<string> loEventNames = new List<string>();
        private List<string> getDistinctFolioIds()
        {
            List<string> _folioList = new List<string>();
            loFolioDates.Clear();
            loEventNames.Clear();
            if (loRevenue != null)
            {
                foreach (DataRow _dRow in loRevenue.Rows)
                {
                    if (!_folioList.Contains(_dRow["folioId"].ToString()))
                    {
                        _folioList.Add(_dRow["folioId"].ToString());
                        loFolioDates.Add(string.Format("{0:MM/dd/yyyy}", DateTime.Parse(_dRow["transactionDate"].ToString())));
                        loEventNames.Add(_dRow["groupName"].ToString());
                        //MessageBox.Show(_dRow["folioId"].ToString() + "-" + string.Format("{0:MM/dd/yyyy}", DateTime.Parse(_dRow["transactionDate"].ToString())) + "-" + _dRow["groupName"].ToString());
                    }
                }
            }
            return _folioList;
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void plotToGrid()
        {
            gridEventsRevenue.Rows.Count = 1;
            List<string> _folioIds = getDistinctFolioIds();

            ProgressForm progress = new ProgressForm();
            if (_folioIds.Count > 0)
            {
                this.gridEventsRevenue.Rows.Count = _folioIds.Count + 1;
                int count = _folioIds.Count + 1;
                progress = new ProgressForm(count, "Loading Event List......");
                progress.Height = 27;
                progress.Show();
            }
            int _row = 1; //grid row start at 1
            //load per row
            foreach (string _fId in _folioIds)
            {
                /**
                 * 0 - folioId
                 * 1 - event name
                 * 2 - event date
                 * last - total
                 **/
                gridEventsRevenue.SetData(_row, 0, _fId);
                string test = loEventNames[_row - 1];
                gridEventsRevenue.SetData(_row, 1, test);
                gridEventsRevenue.SetData(_row, 2, loFolioDates[_row - 1]);

                //load transactions
                int _transCol = 3;
                int _noOfDebit = lNoOfDebit + 3;
                foreach(string _transaction in loTransactionList)
                {
                    gridEventsRevenue.SetData(_row, _transCol,getTotalAmount(_fId,_transaction));
                    if (_transCol < _noOfDebit)
                        this.gridEventsRevenue.Cols[_transCol].Style = gridEventsRevenue.Styles["dcell"];
                    else
                        this.gridEventsRevenue.Cols[_transCol].Style = gridEventsRevenue.Styles["ccell"];
                    this.gridEventsRevenue.Cols[_transCol].DataType = typeof(decimal);
                    this.gridEventsRevenue.Cols[_transCol].Format = "###,###,###,##0.00";
                    _transCol++;
                }
                //total revenue
                this.gridEventsRevenue.SetData(_row, _transCol, getTotalAmount(_fId,"TOTAL"));
                this.gridEventsRevenue.Cols[_transCol].Style = gridEventsRevenue.Styles["totalcell"];
                this.gridEventsRevenue.Cols[_transCol].DataType = typeof(decimal);
                this.gridEventsRevenue.Cols[_transCol].Format = "###,###,###,##0.00";
                _row++;
                progress.updateProgress(_row);
            }
            progress.Close();
        }

        private decimal getTotalAmount(string pFolioId, string pTransaction)
        {
            DataView _dv = loRevenue.DefaultView;
            DataTable _dt;
            if (pTransaction == "TOTAL")
            {
                _dv.RowFilter = "folioId = '" + pFolioId + "' and acctSide = 'CREDIT'";
            }
            else
            {
                _dv.RowFilter = "folioId = '" + pFolioId + "' and transaction = '" + pTransaction + "'";
            }
            _dt = _dv.ToTable();
            decimal _sum = 0;
            try
            {
                _sum = Convert.ToDecimal(_dt.Compute("sum(netAmount)", ""));
            }
            catch { }
            return _sum;
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboYearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            prepareGrid();
            plotToGrid();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value < dtpFrom.Value)
            {
                MessageBox.Show("Date value should be greater than from date");
                dtpTo.Value = dtpFrom.Value;
                return;
            }
            prepareGrid();
            plotToGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpTo_Leave(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.gridEventsRevenue.Rows.Count <= 1)
            {
                return;
            }

            try
            {

                string strFileName = "Number of Events and Revenue Report (" + loFromDate + " to " + loToDate + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;

                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                    ProgressForm progress = new ProgressForm();
                    int count = this.gridEventsRevenue.Rows.Count + 1;
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

                    int rowCount = 1;
                    int colCount = 1;
                    int totalCol = this.gridEventsRevenue.Cols.Count;
                    int totalRow = this.gridEventsRevenue.Rows.Count;
                    List<decimal> _revenues = new List<decimal>();
                    decimal _totalRevenue = 0;
                    for (int row = 0; row < totalRow; row++)
                    {
                        for (int col = 0; col < totalCol; col++)
                        {
                            if (this.gridEventsRevenue.Cols[col].Visible)
                            {
                                if (row == 0)
                                {
                                    xlWorkSheet.Cells[rowCount,colCount] = xlWorkSheet.Cells.Font.Bold;
                                }
                                if (row > 0 && col > 2)
                                {
                                    decimal value = Convert.ToDecimal(this.gridEventsRevenue.GetDataDisplay(row , col).ToString());
                                    xlWorkSheet.Cells[rowCount, colCount] = string.Format("{0:###,###,###,##0.00}", value);
                                } else {
                                    string columnName = this.gridEventsRevenue.GetDataDisplay(row, col).ToString();
                                    xlWorkSheet.Cells[rowCount, colCount] = columnName;
                                }
                                try
                                {
                                    if (col == (totalCol - 1) && row > 0)
                                    {
                                        _totalRevenue += Convert.ToDecimal(gridEventsRevenue.GetDataDisplay(row, col));
                                        _revenues.Add(Convert.ToDecimal(gridEventsRevenue.GetDataDisplay(row, col)));
                                    }
                                }
                                catch { }
                                colCount++;
                            }
                        }
                        rowCount++;
                        colCount = 1;
                        progress.updateProgress(rowCount);
                    }
                    progress.Close();

                    Excel.ChartObjects charts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                    //chart size
                    Excel.ChartObject chartObj = charts.Add(50, (loRevenue.Rows.Count * 3) + 50, (loRevenue.Rows.Count * 20) + 50, (loTransactionList.Count * 30) + 60);
                    chartObj.Chart.ChartType = Excel.XlChartType.xlLineMarkers;
                    Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)chartObj.Chart.SeriesCollection(misValue);

                    for (int trans = 0; trans < loTransactionList.Count; trans++)
                    {
                        Excel.Series _transLine = seriesCollection.NewSeries();

                        _transLine.XValues = xlWorkSheet.get_Range("C2", "C" + (rowCount - 1).ToString());
                        _transLine.Values = xlWorkSheet.get_Range(_letterAddress[trans + 3] + "2", _letterAddress[trans + 3] + (rowCount - 1).ToString());
                        _transLine.Name = loTransactionList[trans];
                    }

                    chartObj.Chart.HasTitle = true; // Chart Title
                    chartObj.Chart.ChartTitle.Text = "Events and Revenue"; //Chart Title Name
                    chartObj.Chart.ChartTitle.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Maroon);
                    chartObj.Chart.ChartArea.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                    int _numberOfEvents = getDistinctFolioIds().Count;
                    decimal _averageRevenue = Convert.ToDecimal(_totalRevenue / _numberOfEvents);
                     
                  
                    //format cells
                    xlWorkSheet.get_Range("A1", _letterAddress[gridEventsRevenue.Cols.Count] + "1").EntireColumn.AutoFit();
                    xlWorkSheet.get_Range("A1", _letterAddress[gridEventsRevenue.Cols.Count] + "1").Font.Bold = true;
                    //color debit
                    xlWorkSheet.get_Range("D1", _letterAddress[lNoOfDebit + 2] + "1").Interior.ColorIndex = 18;
                    xlWorkSheet.get_Range("D2", _letterAddress[lNoOfDebit + 2] + (rowCount-1)).Interior.ColorIndex = 38;
                    //credit
                    xlWorkSheet.get_Range(_letterAddress[lNoOfDebit + 3] + "1",  _letterAddress[gridEventsRevenue.Cols.Count - 2] + "1").Interior.ColorIndex = 42;
                    xlWorkSheet.get_Range(_letterAddress[lNoOfDebit + 3] + "2", _letterAddress[gridEventsRevenue.Cols.Count - 2] + (rowCount-1)).Interior.ColorIndex = 37;
                    //total
                    xlWorkSheet.get_Range(_letterAddress[gridEventsRevenue.Cols.Count - 1] + "1", _letterAddress[gridEventsRevenue.Cols.Count - 1] + "1").Interior.ColorIndex = 45;
                    xlWorkSheet.get_Range(_letterAddress[gridEventsRevenue.Cols.Count - 1] + "2", _letterAddress[gridEventsRevenue.Cols.Count - 1] + (rowCount-1)).Interior.ColorIndex = 44;
                    //color 3 cells
                    xlWorkSheet.get_Range("A1", "C1").Interior.ColorIndex = 16;
                    xlWorkSheet.get_Range("A2", "C" + (rowCount - 1)).Interior.ColorIndex = 15;


                    //border
                    xlWorkSheet.get_Range("A1", _letterAddress[gridEventsRevenue.Cols.Count - 1] + (rowCount - 1)).get_Resize(misValue, gridEventsRevenue.Cols.Count).Borders.Weight = Excel.XlBorderWeight.xlThin;

                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 2] = "Total Events:";
                    xlWorkSheet.Cells[rowCount, 3] = _numberOfEvents;
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 2] = "Total Revenue:";
                    xlWorkSheet.Cells[rowCount, 3] = string.Format("{0:###,###,###,##0.00}",_totalRevenue);
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 2] = "Average Revenue:";
                    xlWorkSheet.Cells[rowCount, 3] = string.Format("{0:###,###,###,##0.00}", _averageRevenue);
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 2] = "Variance";
                    xlWorkSheet.Cells[rowCount, 3] = string.Format("{0:###,###,###,##0.00}", getVariance(_revenues,_averageRevenue));
                    xlWorkSheet.get_Range("C" + rowCount, "C" + rowCount).EntireColumn.AutoFit();
                    xlWorkSheet.get_Range(_letterAddress[gridEventsRevenue.Cols.Count - 1] + "1", _letterAddress[gridEventsRevenue.Cols.Count - 1] + "1").EntireColumn.AutoFit();
                    
                    try
                    {
                        xlWorkBook.SaveAs(sfdExport.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot Save/Overwrite XLS File errmsg: " + ex.ToString());
                    }
                    finally
                    {
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                    }

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

        public decimal getVariance(List<decimal> pElems, decimal pMean)
        {
            decimal _runningSum = 0;
            for (int i = 0; i < pElems.Count; i++)
            {
                _runningSum += Convert.ToDecimal(Math.Pow((Convert.ToDouble(pElems[i])) - (Convert.ToDouble(pMean)), 2));
            }

            _runningSum = (_runningSum / pElems.Count);
            return _runningSum;
        }

        private void rdoHistory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                disableOptions();
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboYearFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboYearTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboYearFrom.Text) > Convert.ToInt32(cboYearTo.Text))
                {
                    MessageBox.Show("Year to should be greater than year from");
                    return;
                }
                prepareGrid();
                plotToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            DataTable _dt = new DataTable();
            try
            {
                _dt.Columns.Add("folioId");
                _dt.Columns.Add("eventName");
                _dt.Columns.Add("eventDate", typeof(DateTime));
                _dt.Columns.Add("groupBy");
                _dt.Columns.Add("totalRevenue", typeof(decimal));

                for (int i = 1; i < gridEventsRevenue.Rows.Count; i++)
                {
                    DataRow _dRow = _dt.NewRow();
                    _dRow["folioId"] = gridEventsRevenue.GetDataDisplay(i, 0).ToString();
                    _dRow["eventName"] = gridEventsRevenue.GetDataDisplay(i, 1).ToString();
                    _dRow["totalRevenue"] = Convert.ToDecimal(gridEventsRevenue.GetDataDisplay(i, gridEventsRevenue.Cols.Count - 1).ToString());
                    _dRow["eventDate"] = DateTime.Parse(gridEventsRevenue.GetDataDisplay(i, 2).ToString());
                    if (rdoHistory.Checked)
                    {
                        _dRow["groupBy"] = DateTime.Parse(gridEventsRevenue.GetDataDisplay(i, 2).ToString()).Year;
                    }
                    else
                    {
                        _dRow["groupBy"] = string.Format("{0:MMMM}",DateTime.Parse(gridEventsRevenue.GetDataDisplay(i, 2).ToString()));
                    }
                    _dt.Rows.Add(_dRow);
                }

                //generate report
                if (_dt.Rows.Count > 0)
                {
                    NumberOfEventsAndRevenueReport _revenueReport = new NumberOfEventsAndRevenueReport();
                    ReportViewer rptViewer;

                    DataTable _sub = getSubTable(_dt);
                    _revenueReport.OpenSubreport("NumberOfEventsAndRevenueReportSub.rpt").SetDataSource(_sub);

                    _revenueReport.Database.Tables[0].SetDataSource(_dt);
                    _revenueReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                    //test _revenueReport = new test();

                    
                    //ReportDocument _rpt = _revenueReport;
                    //ReportFacade _reportFacade = new ReportFacade();
                    

                    //_reportFacade.setSubReport(ref _rpt, _sub, true);

                    _revenueReport.SetParameterValue(0, DateTime.Parse(loFromDate));
                    _revenueReport.SetParameterValue(1, DateTime.Parse(loToDate));
                    if (rdoHistory.Checked)
                    {
                        _revenueReport.SetParameterValue(2, 1);
                    }
                    else
                    {
                        _revenueReport.SetParameterValue(2, 0);
                    }




                    rptViewer = new ReportViewer();
                    rptViewer.rptViewer.ReportSource = _revenueReport;
                    rptViewer.MdiParent = this.MdiParent;
                    rptViewer.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @generating report\r\n" + ex.Message);
            }
        }

        private DataTable getSubTable(DataTable pDt)
        {
            DataTable _dt = new DataTable();
            try
            {
                _dt.Columns.Add("groupBy");
                _dt.Columns.Add("numberOfEvents");
                _dt.Columns.Add("average", typeof(decimal));
                _dt.Columns.Add("total", typeof(decimal));
                _dt.Columns.Add("variance", typeof(decimal));
                _dt.Columns.Add("difference", typeof(decimal));
                _dt.Columns.Add("perc", typeof(decimal));
                _dt.Columns.Add("inc");

                string _tempGrouper = "";
                DataRow _dRow = null;
                int _numRows = 0;
                decimal _total = 0;
                decimal _prevVar = 0;
                List<decimal> _elems = new List<decimal>();
                decimal _var = 0;
                for (int i = 0; i < pDt.Rows.Count; i++)
                {

                    if (pDt.Rows[i]["groupBy"].ToString() != _tempGrouper)
                    {

                        if (_dRow != null)
                        {

                            _dRow["numberOfEvents"] = _numRows;
                            _dRow["total"] = _total;
                            _dRow["average"] = _total / _numRows;
                            _var = getVariance(_elems, _total / _numRows);
                            if (_dt.Rows.Count < 1)
                            {
                                _dRow["difference"] = 0;
                                _dRow["perc"] = 0;
                            }
                            else
                            {
                                _dRow["difference"] = Math.Abs(_prevVar - _var);
                                if (_prevVar < _var)
                                {
                                    _dRow["perc"] = (1 - (_prevVar / _var)) * 100;
                                    _dRow["inc"] = "increase";
                                }
                                else
                                {
                                    _dRow["perc"] = (1 - (_var / _prevVar)) * 100;
                                    _dRow["inc"] = "decrease";
                                }
                            }
                            _prevVar = _var;
                            _dRow["variance"] = _prevVar;
                            _dt.Rows.Add(_dRow);
                        }

                        _dRow = _dt.NewRow();
                        _dRow["groupBy"] = pDt.Rows[i]["groupBy"].ToString();
                        _tempGrouper = pDt.Rows[i]["groupBy"].ToString();
                        _numRows = 0;
                        _total = 0;
                        _elems.Clear();

                    }
                    _numRows++;
                    _total += Convert.ToDecimal(pDt.Rows[i]["totalRevenue"]);
                    _elems.Add(Convert.ToDecimal(pDt.Rows[i]["totalRevenue"]));

                    if (i == pDt.Rows.Count - 1)
                    {

                        _dRow["numberOfEvents"] = _numRows;
                        _dRow["total"] = _total;
                        _dRow["average"] = _total / _numRows;
                        _var = getVariance(_elems, _total / _numRows);
                        if (_dt.Rows.Count < 1)
                        {
                            _dRow["difference"] = 0;
                            _dRow["perc"] = 0;
                        }
                        else
                        {
                            _dRow["difference"] = Math.Abs(_prevVar - _var);
                            if (_prevVar < _var)
                            {
                                _dRow["perc"] = (1 - (_prevVar / _var)) * 100;
                                _dRow["inc"] = "increase";
                            }
                            else
                            {
                                _dRow["perc"] = (1 - (_var / _prevVar)) * 100;
                                _dRow["inc"] = "decrease";
                            }
                        }
                        _prevVar = _var;
                        _dRow["variance"] = _prevVar;
                        _dt.Rows.Add(_dRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating sub report\r\n" + ex.Message);
            }
            return _dt;

        }
    }
}