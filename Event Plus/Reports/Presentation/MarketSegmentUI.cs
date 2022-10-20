using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;


using C1.Win.C1FlexGrid;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class MarketSegmentUI : Form
    {
        public MarketSegmentUI()
        {
            InitializeComponent();
            setupGrid();
        }

        private string lSummaryHeader;
        private void setupGrid()
        {
            GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

            DataTable _oDtDropDownValues = oGroupBookingFacade.getDetailsForDropDown();
            DataView _oDataView = _oDtDropDownValues.DefaultView;

            //market segment
            _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
            _oDataView.RowFilter = "fieldname = 'MarketSegment'";

            int _count = _oDataView.Count;
            flex.Cols.Count = (_count * 2) + 3;

            // outline tree
            flex.Tree.Column = 0;
            flex.Tree.Style = TreeStyleFlags.Simple;
            flex.AllowMerging = AllowMergingEnum.Nodes;

            flex.SetData(0, 0, "MONTH");
            flex.SetData(1, 0, "MONTH");

            int _ctr = 1;
            foreach (DataRowView _oView in _oDataView)
            {
                flex.SetData(0, _ctr, _oView["Value"].ToString());
                flex.SetData(0, _ctr + 1, _oView["Value"].ToString());

                flex.SetData(1, _ctr, "# Of Events");
                flex.Cols[_ctr].Name = _oView["Value"].ToString() + " # Of Events";
                flex.SetData(1, _ctr + 1, "Revenue");
                flex.Cols[_ctr + 1].Name = _oView["Value"].ToString() + " Revenue";

                _ctr += 2;
            }

            flex.SetData(0, _ctr, "TOTAL");
            flex.SetData(0, _ctr + 1, "TOTAL");
            flex.SetData(1, _ctr, "# Of Events");
            flex.Cols[_ctr].Name = "Total Events";
            flex.SetData(1, _ctr + 1, "Revenue");
            flex.Cols[_ctr + 1].Name = "Total Revenue";

            //merging of fixed rows and columns
            flex.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
            flex.Cols[0].AllowMerging = flex.Cols[1].AllowMerging = true;
            flex.Rows[0].AllowMerging = flex.Rows[1].AllowMerging = true;
            flex.Cols[0].AllowMerging = flex.Rows[0].AllowMerging = true;

            foreach (C1.Win.C1FlexGrid.Column _oCol in flex.Cols)
            {
                if (_oCol.Index == 0)
                {
                    flex.Cols[_oCol.Index].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
                }
                else
                {
                    flex.Cols[_oCol.Index].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                }
                flex.Cols[_oCol.Index].TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            }

            // other
            flex.AllowResizing = AllowResizingEnum.Columns;
            flex.SelectionMode = SelectionModeEnum.Cell;

            //setup rows
            ConfigurationHotel.BusinessLayer.RoomTypeFacade _oRoomTypeFacade = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.RoomTypeFacade();
            ConfigurationHotel.BusinessLayer.RoomType _oRoomType = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.RoomType();
            _oRoomType = (ConfigurationHotel.BusinessLayer.RoomType)_oRoomTypeFacade.loadObject();

            /* Gene
             * 29-Feb-12
             */
            DataView _oRoomTypeView = _oRoomType.Tables[0].DefaultView;
            _oRoomTypeView.RowFilter = "roomtypecode = 'MAIN COMPLEX' or roomtypecode = 'PICC FORUM'";

            int _rowCount = 0;
            /* Gene
             * 29-Feb-12
             */
            //Old Code
            //foreach (DataRow drGuest in _oRoomType.Tables[0].Rows)
            foreach (DataRow drGuest in _oRoomTypeView.ToTable().Rows)
            {
                _rowCount++;
            }
            //17 original instead of 18
            flex.Rows.Count = (_rowCount * 15) + 17;

            _rowCount = 2;
            /* Gene
             * 29-Feb-12
             */
            //Old Code
            //foreach (DataRow _oRowRoomType in _oRoomType.Tables[0].Rows)
            foreach (DataRow _oRowRoomType in _oRoomTypeView.ToTable().Rows)
            {
                flex.SetData(_rowCount, 0, _oRowRoomType["RoomTypeCode"].ToString());
                flex.Rows[_rowCount].IsNode = true;
                flex.Rows[_rowCount].Node.Level = 0;
                flex.Rows[_rowCount].Style = flex.Styles["RoomType"];

                for (int i = 1; i <= 12; i++)
                {
                    flex[_rowCount + i, 0] = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i - 1].ToUpper();
                    flex.Rows[_rowCount + i].IsNode = true;
                    flex.Rows[_rowCount + i].Node.Level = 1;

                    flex.Rows[_rowCount + i].UserData = _oRowRoomType["RoomTypeCode"].ToString();
                }

                flex.SetData(_rowCount + 13, 0, "TOTAL");
                flex.Rows[_rowCount + 13].IsNode = true;
                flex.Rows[_rowCount + 13].Node.Level = 0;
                flex.Rows[_rowCount + 13].Style = flex.Styles["Total"];
                flex.Rows[_rowCount + 13].UserData = _oRowRoomType["RoomTypeCode"].ToString();

                flex.SetData(_rowCount + 14, 0, " ");
                flex.Rows[_rowCount + 14].IsNode = true;
                flex.Rows[_rowCount + 14].Node.Level = 0;
                flex.Rows[_rowCount + 14].Style = flex.Styles["Percentage"];
                flex.Rows[_rowCount + 14].UserData = _oRowRoomType["RoomTypeCode"].ToString();

                _rowCount += 15;
                lSummaryHeader += _oRowRoomType["RoomTypeCode"].ToString() + ", ";
            }

            //for summary
            flex.SetData(_rowCount, 0, lSummaryHeader);
            flex.Rows[_rowCount].IsNode = true;
            flex.Rows[_rowCount].Node.Level = 0;
            flex.Rows[_rowCount].Style = flex.Styles["RoomType"];

            for (int i = 1; i <= 12; i++)
            {
                flex[_rowCount + i, 0] = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i - 1].ToUpper();
                flex.Rows[_rowCount + i].IsNode = true;
                flex.Rows[_rowCount + i].Node.Level = 1;

                flex.Rows[_rowCount + i].UserData = lSummaryHeader;
            }

            flex.SetData(_rowCount + 13, 0, "TOTAL");
            flex.Rows[_rowCount + 13].IsNode = true;
            flex.Rows[_rowCount + 13].Node.Level = 0;
            flex.Rows[_rowCount + 13].Style = flex.Styles["Total"];
            flex.Rows[_rowCount + 13].UserData = lSummaryHeader;

            flex.SetData(_rowCount + 14, 0, " ");
            flex.Rows[_rowCount + 14].IsNode = true;
            flex.Rows[_rowCount + 14].Node.Level = 0;
            flex.Rows[_rowCount + 14].Style = flex.Styles["Percentage"];
            flex.Rows[_rowCount + 14].UserData = lSummaryHeader;

            flex.AutoSizeCols();
        }

        private void MarketSegmentUI_Load(object sender, EventArgs e)
        {
            txtHeader.Text = "PICC MAIN COMPLEX & THE FORUM \n" + DateTime.Now.ToString("yyyy") + " MARKET SEGMENT";
            dtpEndDate.Value = DateTime.Now;
        }

        Jinisys.Hotel.BusinessSharedClasses.ProgressForm _oForm = null;
        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (C1.Win.C1FlexGrid.Row _gridRow in flex.Rows)
                {
                    if (_gridRow.Index > 1)
                    {
                        foreach (C1.Win.C1FlexGrid.Column _oColumn in flex.Cols)
                        {
                            if (_oColumn.Index > 0)
                            {
                                flex[_gridRow.Index, _oColumn.Index] = 0;
                            }
                        }
                    }
                }

                Reports.BusinessLayer.ReportFacade _oReportFacade = new Jinisys.Hotel.Reports.BusinessLayer.ReportFacade();
                DataTable _oData = _oReportFacade.getAnnualMarketSegmentReport(dtpEndDate.Value.Year);

                _oForm = new Jinisys.Hotel.BusinessSharedClasses.ProgressForm(flex.Rows.Count * flex.Cols.Count * 2, "Computing Totals for Market Segment");
                _oForm.Height = 27;
                _oForm.Show();
                int _curProgress = 1;

                foreach (DataRow _oRow in _oData.Rows)
                {
                    foreach (C1.Win.C1FlexGrid.Row _gridRow in flex.Rows)
                    {
                        if (_gridRow.Index > 1 && _gridRow.UserData != null)
                        {
                            string _str = flex[_gridRow.Index, 0].ToString().ToUpper();
                            string _month = _oRow["CurrentMonth"].ToString().ToUpper();
                            string _userData = _gridRow.UserData.ToString().ToUpper();
                            if (_userData == _oRow["ROOMTYPE"].ToString()
                                && _str == _month)
                            {
                                flex[_gridRow.Index, _oRow["MarketSegment"].ToString() + " # Of Events"] = _oRow["NoOfEvents"].ToString();
                                flex[_gridRow.Index, _oRow["MarketSegment"].ToString() + " Revenue"] = string.Format("{0:###,###,##0.00}", _oRow["TotalRevenue"]);
                            }
                        }
                        _curProgress++;
                        _oForm.updateProgress(_curProgress);
                    }
                }
                
                showTotalsAndSummary(_curProgress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MarketSegmentUI_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog _saveDialog = new SaveFileDialog();
            _saveDialog.DefaultExt = "xls";
            _saveDialog.FileName = "*.xls";
            _saveDialog.AddExtension = true;
            if (_saveDialog.ShowDialog() != DialogResult.OK)
                return;

            C1.Win.C1FlexGrid.FileFlags _flags = (chkIncludeHeader.Checked) ? C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells : C1.Win.C1FlexGrid.FileFlags.None;
            flex.SaveGrid(_saveDialog.FileName, C1.Win.C1FlexGrid.FileFormatEnum.Excel, _flags);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (cboPrintType.Text)
            {
                case "Actual Size":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ActualSize, txtHeader.Text, txtFooter.Text);
                    break;

                case "Extend Last Column":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ExtendLastCol, txtHeader.Text, txtFooter.Text);
                    break;

                case "Fit to Page":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.FitToPage, txtHeader.Text, txtFooter.Text);
                    break;

                case "Fit to Page Width":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.FitToPageWidth, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Highlight":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ShowHighlight, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Page Setup Dialog":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ShowPageSetupDialog, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Page Preview Dialog":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog, txtHeader.Text, txtFooter.Text);
                    break;

                case "Show Print Dialog":
                    flex.PrintGrid("Market Segment Report", C1.Win.C1FlexGrid.PrintGridFlags.ShowPrintDialog, txtHeader.Text, txtFooter.Text);
                    break;
            }
            pnlPrint.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlPrint.Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pnlPrint.Visible = true;
            txtFooter.Text = "as of " + DateTime.Now;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpEndDate_ValueChanged(this, new EventArgs());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showTotalsAndSummary(int _curProgress)
        {
            double _totalSum = 0;
            //summary for each column totals
            foreach (C1.Win.C1FlexGrid.Column _col in flex.Cols)
            {
                _totalSum = 0;
                double _sumJanuary = 0;
                double _sumFebruary = 0;
                double _sumMarch = 0;
                double _sumApril = 0;
                double _sumMay = 0;
                double _sumJune = 0;
                double _sumJuly = 0;
                double _sumAugust = 0;
                double _sumSeptember = 0;
                double _sumOctober = 0;
                double _sumNovember = 0;
                double _sumDecember = 0;

                double _total = 0;
                if (_col.Index > 0)
                {
                    for (int i = flex.Rows.Fixed; i < flex.Rows.Count; i++)
                    {
                        switch (flex.GetDataDisplay(i, 0))
                        {
                            case "JANUARY":
                                try
                                {
                                    _sumJanuary += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumJanuary += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumJanuary;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumJanuary);
                                    }
                                    //flex.SetData(i, _col.Index, _sumJanuary);
                                }
                                break;

                            case "FEBRUARY":
                                try
                                {
                                    _sumFebruary += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumFebruary += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumFebruary;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumFebruary);
                                    }
                                    //flex.SetData(i, _col.Index, _sumFebruary);
                                }
                                break;

                            case "MARCH":
                                try
                                {
                                    _sumMarch += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumMarch += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumMarch;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumMarch);
                                    }
                                    //flex.SetData(i, _col.Index, _sumMarch);
                                }
                                break;

                            case "APRIL":
                                try
                                {
                                    _sumApril += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumApril += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumApril;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumApril);
                                    }
                                    //flex.SetData(i, _col.Index, _sumApril);
                                }
                                break;

                            case "MAY":
                                try
                                {
                                    _sumMay += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumMay += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumMay;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumMay);
                                    }
                                    //flex.SetData(i, _col.Index, _sumMay);
                                }
                                break;

                            case "JUNE":
                                try
                                {
                                    _sumJune += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumJune += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumJune;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumJune);
                                    }
                                    //flex.SetData(i, _col.Index, _sumJune);
                                }
                                break;

                            case "JULY":
                                try
                                {
                                    _sumJuly += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumJuly += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumJuly;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumJuly);
                                    }
                                    //flex.SetData(i, _col.Index, _sumJuly);
                                }
                                break;

                            case "AUGUST":
                                try
                                {
                                    _sumAugust += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumAugust += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumAugust;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumAugust);
                                    }
                                    //flex.SetData(i, _col.Index, _sumAugust);
                                }
                                break;

                            case "SEPTEMBER":
                                try
                                {
                                    _sumSeptember += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumSeptember += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumSeptember;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumSeptember);
                                    }
                                    //flex.SetData(i, _col.Index, _sumSeptember);
                                }
                                break;

                            case "OCTOBER":
                                try
                                {
                                    _sumOctober += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumOctober += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumOctober;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumOctober);
                                    }
                                    //flex.SetData(i, _col.Index, _sumOctober);
                                }
                                break;

                            case "NOVEMBER":
                                try
                                {
                                    _sumNovember += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumNovember += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumNovember;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumNovember);
                                    }
                                    //flex.SetData(i, _col.Index, +_sumNovember);
                                }
                                break;

                            case "DECEMBER":
                                try
                                {
                                    _sumDecember += double.Parse(flex.GetDataDisplay(i, _col.Index));
                                }
                                catch
                                {
                                    _sumDecember += 0;
                                }

                                if (flex.Rows[i].UserData.ToString() == lSummaryHeader)
                                {
                                    if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                    {
                                        flex[i, _col.Index] = _sumDecember;
                                    }
                                    else
                                    {
                                        flex[i, _col.Index] = string.Format("{0:###,###,##0.00}", _sumDecember);
                                    }
                                    //flex.SetData(i, _col.Index, _sumDecember);
                                }
                                break;
                        }
                        ////for total per room type

                        string _rowHeader = flex.GetDataDisplay(i, 0);
                        if (flex.Rows[i].IsNode && !(flex.GetDataDisplay(i, 0) == "TOTAL" || flex.GetDataDisplay(i, 0) == " " || flex.GetDataDisplay(i, 0) == ""))
                        {
                            Node node = flex.Rows[i].Node;
                            if (node.Level == 0)
                            {
                                CellRange range = node.GetCellRange();
                                
                                double sum = flex.Aggregate(AggregateEnum.Sum, range.r1, _col.Index, range.r2, _col.Index, AggregateFlags.None);
                                _totalSum = _totalSum + sum;

                                if (flex.GetDataDisplay(1, _col.Index).Contains("# Of Events"))
                                {
                                    if (_rowHeader == lSummaryHeader)
                                    {
                                        flex[range.r2 + 1, _col.Index] = string.Format("{0:###,###,##0}", _totalSum);
                                    }
                                    else
                                    {
                                        flex[range.r2 + 1, _col.Index] = string.Format("{0:###,###,##0}", sum);
                                    }
                                }
                                else
                                {
                                    if (_rowHeader == lSummaryHeader)
                                    {
                                        flex[range.r2 + 1, _col.Index] = string.Format("{0:###,###,##0.00}", _totalSum);
                                    }
                                    else
                                    {
                                        flex[range.r2 + 1, _col.Index] = string.Format("{0:###,###,##0.00}", sum);
                                    }
                                }
                            }
                        }
                        _curProgress++;
                        _oForm.updateProgress(_curProgress);
                    }
                }
            }
            //end summary for each column totals

            //summary for each row totals
            foreach (C1.Win.C1FlexGrid.Row _gridRow in flex.Rows)
            {
                double _totalEvents = 0;
                double _totalRevenue = 0;
                if (_gridRow.Index > 1)
                {
                    if (flex.Rows[_gridRow.Index].Node.Level != 0 || flex.GetDataDisplay(_gridRow.Index, 0) == "TOTAL")
                    {
                        foreach (C1.Win.C1FlexGrid.Column _gridColumn in flex.Cols)
                        {
                            //for total per row
                            if (flex.GetDataDisplay(1, _gridColumn.Index) == "# Of Events")
                            {
                                try
                                {
                                    _totalEvents += double.Parse(flex.GetDataDisplay(_gridRow.Index, _gridColumn.Index));
                                }
                                catch
                                {
                                    _totalEvents += 0;
                                    flex.SetData(_gridRow.Index, _gridColumn.Index, 0);
                                }
                            }
                            else if (flex.GetDataDisplay(1, _gridColumn.Index) == "Revenue")
                            {
                                try
                                {
                                    _totalRevenue += double.Parse(flex.GetDataDisplay(_gridRow.Index, _gridColumn.Index));
                                }
                                catch
                                {
                                    _totalRevenue += 0;
                                    flex.SetData(_gridRow.Index, _gridColumn.Index, 0.00);
                                }
                            }
                            //end total per row
                        }

                        flex.SetData(_gridRow.Index, "Total Events", string.Format("{0:#,###,##0}", _totalEvents));
                        flex.SetData(_gridRow.Index, "Total Revenue", string.Format("{0:#,###,##0.00}", _totalRevenue));
                    }
                }
                _curProgress++;
                _oForm.updateProgress(_curProgress);
            }
            //end summary for each row totals

            flex.AutoSizeCols();
            _oForm.Close();
            _oForm.Dispose();
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
    }
}