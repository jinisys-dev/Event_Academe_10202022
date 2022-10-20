using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class NumberOfEventsAndRevenue : Form
    {
        public NumberOfEventsAndRevenue()
        {
            InitializeComponent();
            loadColumnsInGrid();
        }

        private void loadColumnsInGrid()
        {
            try
            {
                RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();
                RoomType _oRoomTypes = (RoomType)_oRoomTypeFacade.loadObject();
                DataTable _oData = _oRoomTypes.Tables[0];

                grdRevenue.Cols.Count = (_oData.Rows.Count * 2) + 6;

                //1ST ROW
                int _lastCol = 2;
                grdRevenue.SetData(0, 0, "MONTH");
                grdRevenue.SetData(0, 1, "");

                for (int i = 1; i <= _oData.Rows.Count + 1; i++)
                {
                    grdRevenue.SetData(0, _lastCol, "NUMBER OF EVENTS");
                    _lastCol++;
                }

                for (int i = 1; i <= _oData.Rows.Count + 1; i++)
                {
                    grdRevenue.SetData(0, _lastCol, "REVENUE");
                    _lastCol++;
                }

                grdRevenue.SetData(0, _lastCol, "VARIANCE");
                grdRevenue.SetData(0, _lastCol + 1, "VARIANCE");
                //end of 1ST ROW

                //2ND ROW
                _lastCol = 2;
                grdRevenue.SetData(1, 0, "MONTH");
                grdRevenue.SetData(1, 1, "");

                foreach (DataRow _oRow in _oData.Rows)
                {
                    grdRevenue.SetData(1, _lastCol, _oRow[0].ToString());
                    grdRevenue.Cols[_lastCol].Name = _oRow[0].ToString() + " EVENTS";
                    _lastCol++;
                }

                grdRevenue.SetData(1, _lastCol, "TOTAL");
                grdRevenue.Cols[_lastCol].Name = "TOTAL EVENTS";
                _lastCol++;

                foreach (DataRow _oRow in _oData.Rows)
                {
                    grdRevenue.SetData(1, _lastCol, _oRow[0].ToString());
                    grdRevenue.Cols[_lastCol].Name = _oRow[0].ToString() + " REVENUE";
                    _lastCol++;
                }

                grdRevenue.SetData(1, _lastCol, "TOTAL");
                grdRevenue.Cols[_lastCol].Name = "TOTAL REVENUE";
                grdRevenue.SetData(1, _lastCol + 1, "AMOUNT");
                grdRevenue.Cols[_lastCol + 1].Name = "VARIANCE AMOUNT";
                grdRevenue.SetData(1, _lastCol + 2, "%");
                grdRevenue.Cols[_lastCol + 2].Name = "VARIANCE PERCENT";
                grdRevenue.AutoSizeCols();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //merging of fixed rows and columns
            grdRevenue.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
            grdRevenue.Cols[0].AllowMerging = grdRevenue.Cols[1].AllowMerging = true;
            grdRevenue.Rows[0].AllowMerging = grdRevenue.Rows[1].AllowMerging = true;

            grdRevenue.Cols[0].AllowMerging = grdRevenue.Rows[0].AllowMerging = true;
        }

        private void NumberOfEventsAndRevenue_Load(object sender, EventArgs e)
        {
            txtHeader.Text = "PICC MAIN COMPLEX & THE FORUM \nNUMBER OF EVENTS AND REVENUE \nActual vs Budget\nYTD " + DateTime.Now.ToString("MMMM yyyy");
            dtpEndDate.Value = DateTime.Now;
        }

        Jinisys.Hotel.BusinessSharedClasses.ProgressForm _oForm = null;
        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            grdRevenue.Rows.Count = 2;
            loadColumnsInGrid();
            grdRevenue.Rows.Count += 56;

            try
            {
                for (int i = 2; i <= grdRevenue.Rows.Count - 2; i += 4)
                {
                    grdRevenue.SetData(i, 1, "Budget");
                    grdRevenue.SetData(i + 1, 1, "Actual");
                    grdRevenue.SetData(i + 2, 1, "Yr. " + string.Format("{0:####}", dtpEndDate.Value.Year - 1));
                    grdRevenue.SetData(i + 3, 1, " ");
                }

                int ctr = 1;
                for (int i = 2; i <= grdRevenue.Rows.Count - 2; i += 4)
                {
                    if (ctr <= 12)
                    {
                        grdRevenue.SetData(i, 0, System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(ctr));
                        grdRevenue.SetData(i + 1, 0, System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(ctr));
                        grdRevenue.SetData(i + 2, 0, System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(ctr));
                        grdRevenue.SetData(i + 3, 0, " ");

                    }
                    else if (ctr == 13)
                    {
                        grdRevenue.SetData(i, 0, "YTD");
                        grdRevenue.SetData(i + 1, 0, "YTD");
                        grdRevenue.SetData(i + 2, 0, "YTD");
                        grdRevenue.SetData(i + 3, 0, " ");
                    }
                    else
                    {
                        grdRevenue.SetData(i, 0, "YEND");
                        grdRevenue.SetData(i + 1, 0, "YEND");
                        grdRevenue.SetData(i + 2, 0, "YEND");
                        grdRevenue.SetData(i + 3, 0, " ");
                    }

                    ctr++;
                }

                int _curProgress = 1;
                _curProgress = loadData(_curProgress);
                setEventsAndRevenueTotals(_curProgress);
            }
            catch { }
        }

        private int loadData(int progressCount)
        {
            DataTable _oReportData = new DataTable();
            ReportFacade _oReportFacade = new ReportFacade();
            _oReportData = _oReportFacade.getAnnualEventsAndRevenueReport(dtpEndDate.Value.Year);

            _oForm = new Jinisys.Hotel.BusinessSharedClasses.ProgressForm(grdRevenue.Rows.Count * grdRevenue.Cols.Count * 2, "Computing Totals for Events and Revenue Report");
            _oForm.Height = 27;
            _oForm.Show();

            foreach (DataRow _oRow in _oReportData.Rows)
            {
                string _curMonth = _oRow["CurrentMonth"].ToString();
                string _roomType = _oRow["RoomType"].ToString();
                int _noOfEvents = int.Parse(_oRow["NoOfEvents"].ToString());
                double _totalRevenue = 0;
                try
                {
                    _totalRevenue = double.Parse(_oRow["TotalRevenue"].ToString());
                }
                catch
                {
                    _totalRevenue = 0;
                }

                int _row = 0;
                foreach (C1.Win.C1FlexGrid.Row _gridRow in grdRevenue.Rows)
                {
                    //for styles
                    if (grdRevenue.GetDataDisplay(_gridRow.Index, 1) == "Actual"
                        && Convert.ToDateTime(grdRevenue.GetDataDisplay(_gridRow.Index,0) + " 01, 1901").Month >= DateTime.Now.Month)
                    {
                        grdRevenue.Rows[_gridRow.Index].Style = grdRevenue.Styles["ActualCurrentMonth"];
                    }
                    else if (grdRevenue.GetDataDisplay(_gridRow.Index, 1) == "Actual"
                        && Convert.ToDateTime(grdRevenue.GetDataDisplay(_gridRow.Index, 0) + " 01, 1901").Month < DateTime.Now.Month)
                    {
                        grdRevenue.Rows[_gridRow.Index].Style = grdRevenue.Styles["ActualPrevMonth"];
                    }
                    else if (grdRevenue.GetDataDisplay(_gridRow.Index, 1) == "Actual")
                    {
                        grdRevenue.Rows[_gridRow.Index].Style = grdRevenue.Styles["ActualCurrentMonth"];
                    }
                    else if (grdRevenue.GetDataDisplay(_gridRow.Index, 1).Contains("Yr. "))
                    {
                        grdRevenue.Rows[_gridRow.Index].Style = grdRevenue.Styles["PrevYear"];
                    }
                    else if (grdRevenue.GetDataDisplay(_gridRow.Index, 0).Contains("YTD") || grdRevenue.GetDataDisplay(_gridRow.Index, 0).Contains("YEND"))
                    {
                        grdRevenue.Rows[_gridRow.Index].Style = grdRevenue.Styles["YTD"];
                    }

                    string _1 = grdRevenue.GetDataDisplay(_gridRow.Index, 0).ToUpper();
                    string _2 = grdRevenue.GetDataDisplay(_gridRow.Index, 1).ToUpper();
                    int _yr = dtpEndDate.Value.Year - 1;
                    int _yr2 = int.Parse(_oRow["CurrentYear"].ToString());
                    if (grdRevenue.GetDataDisplay(_gridRow.Index, 0).ToUpper() == _curMonth.ToUpper()
                        && grdRevenue.GetDataDisplay(_gridRow.Index, 1) == "Actual"
                        && dtpEndDate.Value.Year == int.Parse(_oRow["CurrentYear"].ToString()))
                    {
                        _row = _gridRow.Index;
                        break;
                    }
                    else if (grdRevenue.GetDataDisplay(_gridRow.Index, 0).ToUpper() == _curMonth.ToUpper()
                        && grdRevenue.GetDataDisplay(_gridRow.Index, 1) == "Yr. " + string.Format("{0:####}", dtpEndDate.Value.Year - 1)
                        && dtpEndDate.Value.Year - 1 == int.Parse(_oRow["CurrentYear"].ToString()))
                    {
                        _row = _gridRow.Index;
                        break;
                    }

                    progressCount++;
                    _oForm.updateProgress(progressCount);
                }

                grdRevenue.SetData(_row, _roomType + " EVENTS", _noOfEvents);
                grdRevenue.SetData(_row, _roomType + " REVENUE", string.Format("{0:###,###,##0.00}", _totalRevenue));
            }
            return progressCount;
        }

        private void NumberOfEventsAndRevenue_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void setEventsAndRevenueTotals(int progressCount)
        {
            foreach (C1.Win.C1FlexGrid.Row _oRow in grdRevenue.Rows)
            {
                if (_oRow.Index > 1)
                {
                    //for totals
                    double _totalEvents = 0;
                    double _totalRevenue = 0;

                    foreach (C1.Win.C1FlexGrid.Column _oCol in grdRevenue.Cols)
                    {
                        if (_oCol.Name.Contains("EVENTS") && _oCol.Name != "TOTAL EVENTS")
                        {
                            double _rowEvent = 0;
                            try
                            {
                                _rowEvent = double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oCol.Index));
                            }
                            catch
                            {
                                _rowEvent = 0;
                            }

                            _totalEvents += _rowEvent;
                        }
                        else if (_oCol.Name.Contains("REVENUE") && _oCol.Name != "TOTAL REVENUE")
                        {
                            double _rowRevenue = 0;
                            try
                            {
                                _rowRevenue = double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oCol.Index));
                            }
                            catch
                            {
                                _rowRevenue = 0;
                            }

                            _totalRevenue += _rowRevenue;
                        }

                        progressCount++;
                        _oForm.updateProgress(progressCount);
                    }

                    grdRevenue.SetData(_oRow.Index, "TOTAL EVENTS", _totalEvents);
                    grdRevenue.SetData(_oRow.Index, "TOTAL REVENUE", string.Format("{0:###,###,##0.00}", _totalRevenue));
                    //end for totals
                }
            }

            computeYTDandYEND(progressCount);

            grdRevenue.AutoSizeCols();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            //SaveFileDialog _saveDialog = new SaveFileDialog();
            //_saveDialog.DefaultExt = "xls";
            //_saveDialog.FileName = "*.xls";
            //_saveDialog.AddExtension = true;
            //if (_saveDialog.ShowDialog() != DialogResult.OK)
            //    return;

            //C1.Win.C1FlexGrid.FileFlags _flags = (chkIncludeHeader.Checked) ? C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells : C1.Win.C1FlexGrid.FileFlags.None;
            //grdRevenue.SaveGrid(_saveDialog.FileName, C1.Win.C1FlexGrid.FileFormatEnum.Excel, _flags);

            try
            {
                SaveFileDialog sfdExport = new SaveFileDialog();
                string strFileName = "Number of Events & Revenue(" + string.Format("{0:yyyy}",dtpEndDate.Value) + ")";
                
                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;
                
                DialogResult _result = sfdExport.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                    ProgressForm progress = new ProgressForm();
                    int count = grdRevenue.Rows.Count + 1;
                    progress = new ProgressForm(count, "Exporting Number of Events & Revenue......");
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

                    //add report header
                    xlWorkSheet.Cells[rowCount, 1] = "NUMBER OF EVENTS & REVENUE";
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "Actual vs Budget vs " + string.Format("{0:yyyy}", dtpEndDate.Value.AddYears(-1)) + "-" + string.Format("{0:yyyy}", dtpEndDate.Value);
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "as of " + string.Format("{0:MMM dd, yyyy}", DateTime.Now);
                    rowCount++;
                    for (int _row = 0; _row < grdRevenue.Rows.Count; _row++)
                    {
                        for (int _col = 0; _col < grdRevenue.Cols.Count; _col++)
                        {
                            if ((_row + 1) % 4 != 2 || _row < 2)
                            {
                                if (_col > 4 && _row > 1)
                                {
                                    xlWorkSheet.Cells[rowCount, (_col + 1)] = string.Format("{0:###,###,###,##0.00}",grdRevenue.GetDataDisplay(_row, _col));
                                }
                                else
                                {
                                    xlWorkSheet.Cells[rowCount, (_col + 1)] = grdRevenue.GetDataDisplay(_row, _col);
                                }
                            }
                        }
                        if ((_row + 1) % 4 == 0)
                        {
                            xlWorkSheet.get_Range("B" + rowCount, _letterAddress[grdRevenue.Cols.Count - 1] + rowCount).Interior.ColorIndex = 19;
                        }
                        if ((_row + 1) % 4 == 1 && _row > 1)
                        {
                            xlWorkSheet.get_Range("B" + rowCount, _letterAddress[grdRevenue.Cols.Count - 1] + rowCount).Interior.ColorIndex = 34;
                        }
                        progress.updateProgress(rowCount);
                        rowCount++;
                    }

                    xlWorkSheet.get_Range("A1", _letterAddress[grdRevenue.Cols.Count - 1] + "1").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A2", _letterAddress[grdRevenue.Cols.Count - 1] + "2").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A3", _letterAddress[grdRevenue.Cols.Count - 1] + "3").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A1", _letterAddress[grdRevenue.Cols.Count - 1] + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A2", _letterAddress[grdRevenue.Cols.Count - 1] + "2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A3", _letterAddress[grdRevenue.Cols.Count - 1] + "3").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    xlWorkSheet.get_Range("A4", _letterAddress[grdRevenue.Cols.Count - 1] + (grdRevenue.Rows.Count + 2)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.get_Range("A1", _letterAddress[grdRevenue.Cols.Count - 1] + rowCount).EntireColumn.AutoFit();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pnlPrint.Visible = true;
            txtFooter.Text = "as of " + DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (cboPrintType.Text)
            {
                case "Actual Size":
                    grdRevenue.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ActualSize, txtHeader.Text, txtFooter.Text);
                    break;

                case "Extend Last Column":
                    grdRevenue.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ExtendLastCol, txtHeader.Text, txtFooter.Text);
                    break;

                case "Fit to Page":
                    grdRevenue.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.FitToPage, txtHeader.Text, txtFooter.Text);
                    break;

                case "Fit to Page Width":
                    grdRevenue.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.FitToPageWidth, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Highlight":
                    grdRevenue.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ShowHighlight, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Page Setup Dialog":
                    grdRevenue.PrintGrid("YTD No. of Events and Revenue", C1.Win.C1FlexGrid.PrintGridFlags.ShowPageSetupDialog, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Page Preview Dialog":
                    grdRevenue.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Print Dialog":
                    grdRevenue.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ShowPrintDialog, txtHeader.Text, txtFooter.Text);
                    break;
            }
            pnlPrint.Visible = false; 
            pnlPrint.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlPrint.Visible = false;
        }

        private void grdRevenue_EnterCell(object sender, EventArgs e)
        {
            try
            {
                string _rowHeader = grdRevenue.GetDataDisplay(grdRevenue.Row, 1);
                if (_rowHeader == "Budget")
                {
                    grdRevenue.Rows[grdRevenue.Row].AllowEditing = true;
                }
                else
                {
                    grdRevenue.Rows[grdRevenue.Row].AllowEditing = false;
                }
                grdRevenue.Cols[0].AllowEditing=false;
                grdRevenue.Cols[1].AllowEditing = false;
            
            }
            catch { }
        }

        private void grdRevenue_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //setEventsAndRevenueTotals();
            setTotalsAndVariances();
        }

        private void setTotalsAndVariances()
        {
            try
            {
                double _totalEvents = 0;
                double _totalRevenue = 0;

                foreach (C1.Win.C1FlexGrid.Column _oCol in grdRevenue.Cols)
                {
                    if (_oCol.Name.Contains("EVENTS") && _oCol.Name != "TOTAL EVENTS")
                    {
                        double _rowEvent = 0;
                        try
                        {
                            _rowEvent = double.Parse(grdRevenue.GetDataDisplay(grdRevenue.Row, _oCol.Index));
                        }
                        catch
                        {
                            _rowEvent = 0;
                        }

                        _totalEvents += _rowEvent;
                    }
                    else if (_oCol.Name.Contains("REVENUE") && _oCol.Name != "TOTAL REVENUE")
                    {
                        double _rowRevenue = 0;
                        try
                        {
                            _rowRevenue = double.Parse(grdRevenue.GetDataDisplay(grdRevenue.Row, _oCol.Index));
                        }
                        catch
                        {
                            _rowRevenue = 0;
                        }

                        _totalRevenue += _rowRevenue;
                    }
                }

                grdRevenue.SetData(grdRevenue.Row, "TOTAL EVENTS", _totalEvents);
                grdRevenue.SetData(grdRevenue.Row, "TOTAL REVENUE", string.Format("{0:###,###,##0.00}", _totalRevenue));


                //for variance
                foreach (C1.Win.C1FlexGrid.Row _oRow in grdRevenue.Rows)
                {
                    double _totalCurRevenue = 0;
                    double _totalBudgetRevenue = 0;
                    double _totalPrevRevenue = 0;

                    if (_oRow.Index > 1)
                    {
                        if (grdRevenue.GetDataDisplay(_oRow.Index, 1) == "Actual")
                        {
                            try
                            {
                                _totalCurRevenue = double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, "TOTAL REVENUE"));
                            }
                            catch
                            {
                                _totalCurRevenue = 0;
                            }

                            try
                            {
                                _totalBudgetRevenue = double.Parse(grdRevenue.GetDataDisplay(_oRow.Index - 1, "TOTAL REVENUE"));
                            }
                            catch
                            {
                                _totalBudgetRevenue = 0;
                            }

                            try
                            {
                                _totalPrevRevenue = double.Parse(grdRevenue.GetDataDisplay(_oRow.Index + 1, "TOTAL REVENUE"));
                            }
                            catch
                            {
                                _totalPrevRevenue = 0;
                            }

                            double _varianceAmountActual = _totalCurRevenue - _totalBudgetRevenue;
                            double _varianceAmountPrevious = _totalCurRevenue - _totalPrevRevenue;
                            double _variancePercentActual = 0;
                            double _variancePercentPrevious = 0;
                            if (_totalCurRevenue != 0 && _totalBudgetRevenue != 0)
                            {
                                _variancePercentActual = ((_totalCurRevenue / _totalBudgetRevenue) - 1) * 100;
                            }
                            if (_totalCurRevenue != 0 && _totalPrevRevenue != 0)
                            {
                                _variancePercentPrevious = ((_totalCurRevenue / _totalPrevRevenue) - 1) * 100;
                            }

                            grdRevenue.SetData(_oRow.Index, "VARIANCE AMOUNT", string.Format("{0:###,###,##0.00}", _varianceAmountActual));
                            grdRevenue.SetData(_oRow.Index + 1, "VARIANCE AMOUNT", string.Format("{0:###,###,##0.00}", _varianceAmountPrevious));
                            grdRevenue.SetData(_oRow.Index, "VARIANCE PERCENT", string.Format("{0:###,###,##0.00}", _variancePercentActual));
                            grdRevenue.SetData(_oRow.Index + 1, "VARIANCE PERCENT", string.Format("{0:###,###,##0.00}", _variancePercentPrevious));
                        }
                    }
                }
                //end for variance
                grdRevenue.AutoSizeCols();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpEndDate_ValueChanged(this, new EventArgs());
        }

        private void pnlPrint_VisibleChanged(object sender, EventArgs e)
        {
            if (this.pnlPrint.Visible == true)
            {
                foreach (Control _oControl in this.Controls)
                {
                    if (!(_oControl is Panel))
                    {
                        _oControl.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (Control _oControl in this.Controls)
                {
                    _oControl.Enabled = true;
                }
            }
        }

        private void computeYTDandYEND(int progressCount)
        {
            //for YTD and YEND
            foreach (C1.Win.C1FlexGrid.Column _oColumn in grdRevenue.Cols)
            {
                double _budgetYTD = 0;
                double _actualYTD = 0;
                double _prevYTD = 0;
                double _budgetYEND = 0;
                double _actualYEND = 0;
                double _prevYEND = 0;

                if (_oColumn.Index > 1)
                {
                    foreach (C1.Win.C1FlexGrid.Row _oRow in grdRevenue.Rows)
                    {
                        if (_oRow.Index > 1)
                        {
                            if (grdRevenue.GetDataDisplay(_oRow.Index, 1) == "Budget")
                            {
                                try
                                {
                                    _budgetYEND += double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oColumn.Index));
                                }
                                catch
                                {
                                    _budgetYEND += 0;
                                }

                                try
                                {
                                    if (DateTime.Parse(grdRevenue.GetDataDisplay(_oRow.Index, 0) + " 01, 2001").Month < DateTime.Now.Month)
                                    {
                                        try
                                        {
                                            _budgetYTD += double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oColumn.Index));
                                        }
                                        catch
                                        {
                                            _budgetYTD += 0;
                                        }
                                    }
                                }
                                catch { }
                            }
                            else if (grdRevenue.GetDataDisplay(_oRow.Index, 1) == "Actual")
                            {
                                try
                                {
                                    _actualYEND += double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oColumn.Index));
                                }
                                catch
                                {
                                    _actualYEND += 0;
                                }

                                try
                                {
                                    if (DateTime.Parse(grdRevenue.GetDataDisplay(_oRow.Index, 0) + " 01, 2001").Month < DateTime.Now.Month)
                                    {
                                        try
                                        {
                                            _actualYTD += double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oColumn.Index));
                                        }
                                        catch
                                        {
                                            _actualYTD += 0;
                                        }
                                    }
                                }
                                catch { }
                            }
                            else
                            {
                                try
                                {
                                    _prevYEND += double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oColumn.Index));
                                }
                                catch
                                {
                                    _prevYEND += 0;
                                }

                                try
                                {
                                    if (DateTime.Parse(grdRevenue.GetDataDisplay(_oRow.Index, 0) + " 01, 2001").Month < DateTime.Now.Month)
                                    {
                                        try
                                        {
                                            _prevYTD += double.Parse(grdRevenue.GetDataDisplay(_oRow.Index, _oColumn.Index));
                                        }
                                        catch
                                        {
                                            _prevYTD += 0;
                                        }
                                    }
                                }
                                catch { }
                            }

                            string _str = grdRevenue.GetDataDisplay(_oRow.Index, 0);
                            if (grdRevenue.GetDataDisplay(_oRow.Index, 0) == "YTD")
                            {
                                if (grdRevenue.GetDataDisplay(_oRow.Index, 1) == "Budget")
                                    grdRevenue.SetData(_oRow.Index, _oColumn.Index, string.Format("{0:###,###,##0.00}", _budgetYTD));
                                else if (grdRevenue.GetDataDisplay(_oRow.Index, 1) == "Actual")
                                    grdRevenue.SetData(_oRow.Index, _oColumn.Index, string.Format("{0:###,###,##0.00}", _actualYTD));
                                else
                                    grdRevenue.SetData(_oRow.Index, _oColumn.Index, string.Format("{0:###,###,##0.00}", _prevYTD));
                            }
                            else if (grdRevenue.GetDataDisplay(_oRow.Index, 0) == "YEND")
                            {
                                if (grdRevenue.GetDataDisplay(_oRow.Index, 1) == "Budget")
                                    grdRevenue.SetData(_oRow.Index, _oColumn.Index, string.Format("{0:###,###,##0.00}", _budgetYEND));
                                else if (grdRevenue.GetDataDisplay(_oRow.Index, 1) == "Actual")
                                    grdRevenue.SetData(_oRow.Index, _oColumn.Index, string.Format("{0:###,###,##0.00}", _actualYEND));
                                else
                                    grdRevenue.SetData(_oRow.Index, _oColumn.Index, string.Format("{0:###,###,##0.00}", _prevYEND));
                            }
                        }
                    }
                }
                progressCount++;
                _oForm.updateProgress(progressCount);
            }
            //end YTD and YEND
            _oForm.Close();
            _oForm.Dispose();
        }

        private void btnRecompute_Click(object sender, EventArgs e)
        {
            setTotalsAndVariances();
            computeYTDandYEND(5);
        }
    }
}