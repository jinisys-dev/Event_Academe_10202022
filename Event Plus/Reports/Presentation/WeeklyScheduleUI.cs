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
    public partial class WeeklyScheduleUI : Form
    {
        public WeeklyScheduleUI()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpWeeklyFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime _date = dtpWeeklyFrom.Value;
        
            if (_date.DayOfWeek != DayOfWeek.Monday)
            {
                //MessageBox.Show("Start date should be a Monday.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                switch (_date.DayOfWeek)
                {
                    case DayOfWeek.Tuesday :
                        _date = _date.AddDays(-1);
                        break;
                    case DayOfWeek.Wednesday :
                        _date = _date.AddDays(-2);
                        break;
                    case DayOfWeek.Thursday :
                        _date = _date.AddDays(-3);
                        break;
                    case DayOfWeek.Friday :
                        _date = _date.AddDays(-4);
                        break;
                    case DayOfWeek.Saturday :
                        _date = _date.AddDays(-5);
                        break;
                    case DayOfWeek.Sunday :
                        _date = _date.AddDays(-6);
                        break;
                }

                dtpWeeklyFrom.Value = _date;
            }

            dtpWeeklyTo.Value = _date.AddDays(6);
            gridWeeklySchedule.SetData(0, 1, string.Format("{0: dd ddd}", _date));
            gridWeeklySchedule.SetData(0, 2, string.Format("{0: dd ddd}", _date.AddDays(1)));
            gridWeeklySchedule.SetData(0, 3, string.Format("{0: dd ddd}", _date.AddDays(2)));
            gridWeeklySchedule.SetData(0, 4, string.Format("{0: dd ddd}", _date.AddDays(3)));
            gridWeeklySchedule.SetData(0, 5, string.Format("{0: dd ddd}", _date.AddDays(4)));
            gridWeeklySchedule.SetData(0, 6, string.Format("{0: dd ddd}", _date.AddDays(5)));
            gridWeeklySchedule.SetData(0, 7, string.Format("{0: dd ddd}", _date.AddDays(6)));

            loadSchedules();
        }

        DataTable loWeeklySchedules;
        private void loadSchedules()
        {
            ReportFacade _oReportFacade = new ReportFacade();
            loWeeklySchedules = _oReportFacade.getReportWeeklyScedules(dtpWeeklyFrom.Value, dtpWeeklyTo.Value);

            gridWeeklySchedule.Row = 0;
            gridWeeklySchedule.Rows.Count = 1;

            if (loWeeklySchedules.Rows.Count > 0)
            {
                int _row = 1;
                // Gene - 9/12/2011
                // removed
                //foreach (DataRow _dRow in loWeeklySchedules.Rows)
                //{
                //    gridWeeklySchedule.Rows.Count++;
                //    gridWeeklySchedule.SetData(_row, 0, _dRow["venue"].ToString());
                //    DateTime _date;
                //    DateTime.TryParse(_dRow["EVENTDATE"].ToString(), out _date);

                //    TimeSpan _ts = _date.Date.Subtract(dtpWeeklyFrom.Value.Date);
                //    int _col = Convert.ToInt32(Math.Floor(_ts.TotalDays));

                //    gridWeeklySchedule.SetData(_row, _col + 1, _dRow["groupName"].ToString() + " " + _dRow["startTime"] + "-" + _dRow["endTime"]);

                //    _row++;
                    
                //}
                //******************************************************

                //Gene - 9/12/2011
                // added
                DataRow _dRow = loWeeklySchedules.NewRow();

                for(int i = 0; i<loWeeklySchedules.Rows.Count; i++)
                {
                    _dRow = loWeeklySchedules.Rows[i];
                    gridWeeklySchedule.Rows.Count = _row + 1;
                    gridWeeklySchedule.SetData(_row, 0, _dRow["venue"].ToString());
                    DateTime _date;
                    DateTime.TryParse(_dRow["EVENTDATE"].ToString(), out _date);

                    TimeSpan _ts = _date.Date.Subtract(dtpWeeklyFrom.Value.Date);
                    int _col = Convert.ToInt32(Math.Floor(_ts.TotalDays));

                    gridWeeklySchedule.SetData(_row, _col + 1, _dRow["groupName"].ToString() + " " + _dRow["startTime"] + "-" + _dRow["endTime"]);

                    if (i < loWeeklySchedules.Rows.Count - 1)
                    {
                        if ((loWeeklySchedules.Rows[i + 1]["startTime"] + "-" + loWeeklySchedules.Rows[i + 1]["endTime"] != _dRow["startTime"] + "-" + _dRow["endTime"]) || (loWeeklySchedules.Rows[i + 1]["venue"].ToString() != _dRow["venue"].ToString()))
                            _row++;
                    }
                    else
                        _row++;
                }
                //*******************************************************
            }

            gridWeeklySchedule.AutoSizeCols();
       
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (gridWeeklySchedule.Rows.Count == 1)
                return;

            if (loWeeklySchedules == null && loWeeklySchedules.Rows.Count < 1)
                return;

            try
            {
                string strFileName = "Weekly Schedule of Events (" + string.Format("{0:dd-MMM-yyyy}", dtpWeeklyFrom.Value) + " to " + string.Format("{0:dd-MMM-yyyy}", dtpWeeklyTo.Value) + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;
                DialogResult _result = sfdExport.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                    ProgressForm progress = new ProgressForm();
                    int count = gridWeeklySchedule.Rows.Count;
                    int _counter = 0;
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

                    //row
                    int _rowCount = 1;
                    //

                    xlWorkSheet.Cells[_rowCount, 1] = "WEEKLY SCHEDULE OF EVENTS";
                    _rowCount++;
                    xlWorkSheet.Cells[_rowCount, 1] =  "For the week : " + string.Format("{0:dd-MMM-yyyy}", dtpWeeklyFrom.Value) + " to " + string.Format("{0:dd-MMM-yyyy}", dtpWeeklyTo.Value);
                    xlWorkSheet.get_Range("A1", _letterAddress[7] + "1").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A1", _letterAddress[7] + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A1", _letterAddress[7] + "1").Font.Bold = true;
                    xlWorkSheet.get_Range("A2", _letterAddress[7] + "2").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A2", _letterAddress[7] + "2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A2", _letterAddress[7] + "2").Font.Italic = true;
                    xlWorkSheet.get_Range("A1", _letterAddress[7] + "2").Borders.Weight = Excel.XlBorderWeight.xlThin;
                    _rowCount++;

                    //headers
                    xlWorkSheet.Cells[_rowCount, 1] = "AREA/S";
                    xlWorkSheet.get_Range(_letterAddress[0] + _rowCount, _letterAddress[0] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_rowCount, 2] = string.Format("{0:dd ddd}",dtpWeeklyFrom.Value);
                    xlWorkSheet.get_Range(_letterAddress[1] + _rowCount, _letterAddress[1] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_rowCount, 3] = string.Format("{0:dd ddd}", dtpWeeklyFrom.Value.AddDays(1));
                    xlWorkSheet.get_Range(_letterAddress[2] + _rowCount, _letterAddress[2] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_rowCount, 4] = string.Format("{0:dd ddd}", dtpWeeklyFrom.Value.AddDays(2));
                    xlWorkSheet.get_Range(_letterAddress[3] + _rowCount, _letterAddress[3] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_rowCount, 5] = string.Format("{0:dd ddd}", dtpWeeklyFrom.Value.AddDays(3));
                    xlWorkSheet.get_Range(_letterAddress[4] + _rowCount, _letterAddress[4] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_rowCount, 6] = string.Format("{0:dd ddd}", dtpWeeklyFrom.Value.AddDays(4));
                    xlWorkSheet.get_Range(_letterAddress[5] + _rowCount, _letterAddress[5] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_rowCount, 7] = string.Format("{0:dd ddd}", dtpWeeklyFrom.Value.AddDays(5));
                    xlWorkSheet.get_Range(_letterAddress[6] + _rowCount, _letterAddress[6] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.Cells[_rowCount, 8] = string.Format("{0:dd ddd}", dtpWeeklyFrom.Value.AddDays(6));
                    xlWorkSheet.get_Range(_letterAddress[0] + _rowCount, _letterAddress[7] + _rowCount).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    xlWorkSheet.get_Range(_letterAddress[0] + _rowCount, _letterAddress[7] + _rowCount).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range(_letterAddress[0] + _rowCount, _letterAddress[7] + _rowCount).Font.Bold = true;
                    //
                    _rowCount++;

                    string _previousEvent = "";
                    int _previousRow = _rowCount;

                    //foreach (DataRow _dRow in loWeeklySchedules.Rows)
                    //{
                    //DateTime _date;
                    //DateTime.TryParse(_dRow["EVENTDATE"].ToString(), out _date);

                    //TimeSpan _ts = _date.Date.Subtract(dtpWeeklyFrom.Value.Date);
                    //int _col = Convert.ToInt32(Math.Floor(_ts.TotalDays));
                    //_col = _col + 2;
                    ////border per row
                    //xlWorkSheet.get_Range(_letterAddress[_col - 1] + _rowCount, _letterAddress[_col - 1] + (_rowCount + 4)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //for (int i = 0; i < 8; i++)
                    //{
                    //    xlWorkSheet.get_Range(_letterAddress[i] + _rowCount, _letterAddress[i] + (_rowCount + 4)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                    //}
                    ////end

                    //xlWorkSheet.Cells[_rowCount, _col] = _dRow["groupName"].ToString();
                    //xlWorkSheet.get_Range(_letterAddress[_col - 1] + _rowCount, _letterAddress[_col - 1] + _rowCount).Font.Bold = true;
                    //xlWorkSheet.get_Range(_letterAddress[_col - 1] + _rowCount, _letterAddress[_col - 1] + _rowCount).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //xlWorkSheet.Cells[_rowCount + 1, _col] = _dRow["startTime"].ToString() + "-" + _dRow["endTime"].ToString();
                    //xlWorkSheet.Cells[_rowCount + 2, _col] = _dRow["activity"].ToString();
                    //xlWorkSheet.Cells[_rowCount + 3, _col] = "Assigned Personnel";
                    //xlWorkSheet.Cells[_rowCount + 4, _col] = _dRow["eo"].ToString();
                    //xlWorkSheet.get_Range("A" + _rowCount, "A" + (_rowCount + 4)).Merge(Type.Missing);

                    //if (_previousEvent != _dRow["venue"].ToString().ToString())
                    //{
                    //    xlWorkSheet.Cells[_rowCount, 1] = _dRow["venue"].ToString();

                    //    //Gene - 9/9/2011
                    //    xlWorkSheet.get_Range("A" + _rowCount, "A" + _rowCount).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //    _previousEvent = _dRow["venue"].ToString();
                    //    _previousRow = _rowCount;
                    //    _previousSchedule = _dRow["startTime"].ToString() + "-" + _dRow["endTime"].ToString();
                    //}
                    //else
                    //{
                    //    xlWorkSheet.get_Range("A" + _previousRow, "A" + _rowCount).Merge(Type.Missing);
                    //    xlWorkSheet.get_Range("A" + _previousRow, "A" + _rowCount).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //}

                    //_rowCount = _rowCount + 5;
                    //_counter++;
                    //progress.updateProgress(_counter);
                    //}

                    DataRow _dRow = loWeeklySchedules.NewRow();

                    for (int _dataRowCount = 0; _dataRowCount < loWeeklySchedules.Rows.Count; _dataRowCount++)
                    {
                        _dRow = loWeeklySchedules.Rows[_dataRowCount];
                        DateTime _date;
                        DateTime.TryParse(_dRow["EVENTDATE"].ToString(), out _date);

                        TimeSpan _ts = _date.Date.Subtract(dtpWeeklyFrom.Value.Date);
                        int _col = Convert.ToInt32(Math.Floor(_ts.TotalDays));
                        _col = _col + 2;
                        //border per row
                        xlWorkSheet.get_Range(_letterAddress[_col - 1] + _rowCount, _letterAddress[_col - 1] + (_rowCount + 4)).Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int i = 0; i < 8; i++)
                        {
                            xlWorkSheet.get_Range(_letterAddress[i] + _rowCount, _letterAddress[i] + (_rowCount + 4)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                        }
                        //end

                        xlWorkSheet.Cells[_rowCount, _col] = _dRow["groupName"].ToString();
                        xlWorkSheet.get_Range(_letterAddress[_col - 1] + _rowCount, _letterAddress[_col - 1] + _rowCount).Font.Bold = true;
                        xlWorkSheet.get_Range(_letterAddress[_col - 1] + _rowCount, _letterAddress[_col - 1] + _rowCount).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        xlWorkSheet.Cells[_rowCount + 1, _col] = _dRow["startTime"].ToString() + "-" + _dRow["endTime"].ToString();
                        xlWorkSheet.Cells[_rowCount + 2, _col] = _dRow["activity"].ToString();
                        xlWorkSheet.Cells[_rowCount + 3, _col] = "Assigned Personnel";
                        xlWorkSheet.Cells[_rowCount + 4, _col] = _dRow["eo"].ToString();
                        xlWorkSheet.get_Range("A" + _rowCount, "A" + (_rowCount + 4)).Merge(Type.Missing);

                        if (_previousEvent != _dRow["venue"].ToString().ToString())
                        {
                            xlWorkSheet.Cells[_rowCount, 1] = _dRow["venue"].ToString();

                            //Gene - 9/9/2011
                            xlWorkSheet.get_Range("A" + _rowCount, "A" + _rowCount).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            _previousEvent = _dRow["venue"].ToString();
                            _previousRow = _rowCount;
                        }
                        else
                        {
                            xlWorkSheet.get_Range("A" + _previousRow, "A" + _rowCount).Merge(Type.Missing);
                            xlWorkSheet.get_Range("A" + _previousRow, "A" + _rowCount).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        }

                        if (_dataRowCount < loWeeklySchedules.Rows.Count - 1)
                        {
                            if ((loWeeklySchedules.Rows[_dataRowCount + 1]["startTime"] + "-" + loWeeklySchedules.Rows[_dataRowCount + 1]["endTime"] != _dRow["startTime"] + "-" + _dRow["endTime"]) || (loWeeklySchedules.Rows[_dataRowCount + 1]["venue"].ToString() != _dRow["venue"].ToString()))
                                _rowCount = _rowCount + 5;
                        }
                        else
                            _rowCount = _rowCount + 5;

                        _counter++;
                        progress.updateProgress(_counter);
                    }

                    xlWorkSheet.get_Range("A1", _letterAddress[7] + "1").EntireColumn.AutoFit();
                    progress.Close();

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
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                    }

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    MessageBox.Show("Export Successful.");
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
    }
}