using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.Reports.BusinessLayer;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class SalesAndMarketingRevenueReportUI : Form
    {

        ArrayList defaultColumns = new ArrayList();
        private ReportFacade lReportFacade;
        string decimalFormat = "N2";
        public SalesAndMarketingRevenueReportUI()
        {

            InitializeComponent();
            decimalFormat = ConfigVariables.gDecimalFormat;

            lReportFacade = new ReportFacade();

            loadDefaultColumns();
            setupGrid();

           
        }

        private void SalesAndMarketingRevenueUI_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void loadDefaultColumns()
        {

            defaultColumns.Add("FolioId"); //FolioId
            defaultColumns.Add("NoOfAdults"); //NoOfAdult
            defaultColumns.Add("NoOfChild"); //NoOfChild

            defaultColumns.Add("1800"); //VAT
            defaultColumns.Add("1900"); //Service Charge
            defaultColumns.Add("3000"); //Debit Memo

        }


        DataTable tmpTable;
        private void setupGrid()
        {
            //set columns
            this.grdHotelRevenue.Cols.Count = 12;
            //this.grdHotelRevenue.Cols[0].Caption = "No.";
            //this.grdHotelRevenue.Cols[0].Name = "LineNo";

            this.grdHotelRevenue.Cols[0].Caption = "Folio ID";
            this.grdHotelRevenue.Cols[0].Name = "FolioId";

            this.grdHotelRevenue.Cols[1].Caption = "Company Name";
            this.grdHotelRevenue.Cols[1].Name = "CompanyName";

            this.grdHotelRevenue.Cols[2].Caption = "Guest Name";
            this.grdHotelRevenue.Cols[2].Name = "GuestName";

            this.grdHotelRevenue.Cols[3].Caption = "Room";
            this.grdHotelRevenue.Cols[3].Name = "RoomId";

            this.grdHotelRevenue.Cols[4].Caption = "Date of Stay";
            this.grdHotelRevenue.Cols[4].Name = "DateOfStay";

            this.grdHotelRevenue.Cols[5].Caption = "Total Room Nights";
            this.grdHotelRevenue.Cols[5].Name = "RoomNights";

            this.grdHotelRevenue.Cols[6].Caption = "Sales Executive";
            this.grdHotelRevenue.Cols[6].Name = "Sales_Executive";
            
            this.grdHotelRevenue.Cols[7].Caption = "Nationality";
            this.grdHotelRevenue.Cols[7].Name = "Citizenship";

            this.grdHotelRevenue.Cols[8].Caption = "Room Type";
            this.grdHotelRevenue.Cols[8].Name = "RoomType";

            this.grdHotelRevenue.Cols[9].Caption = "Rate Code";
            this.grdHotelRevenue.Cols[9].Name = "RateType";

            this.grdHotelRevenue.Cols[10].Caption = "No of Adults";
            this.grdHotelRevenue.Cols[10].Name = "NoOfAdults";

            this.grdHotelRevenue.Cols[11].Caption = "No Of Child";
            this.grdHotelRevenue.Cols[11].Name = "NoOfChild";


            this.grdHotelRevenue.Rows[0].Height = 35;


            //DataTable tmpTable;
            tmpTable = lReportFacade.getTransactionCodes();

            DataView _tempView = tmpTable.DefaultView;
            _tempView.RowFilter = "tranTypeID = '1'";

            int totalCols = 0;
            foreach (DataRowView row in _tempView)
            {
                string _tranCode = "";
                _tranCode = row["tranCode"].ToString();

                totalCols = this.grdHotelRevenue.Cols.Count;
                this.grdHotelRevenue.Cols.Add();
                this.grdHotelRevenue.Cols[totalCols].Caption = row["Memo"].ToString();
                this.grdHotelRevenue.Cols[totalCols].Name = _tranCode;
                this.grdHotelRevenue.Cols[totalCols].Format = decimalFormat;

                //for breakfast column
                if (_tranCode == "1000")
                {
                    totalCols++;

                    this.grdHotelRevenue.Cols.Add();
                    this.grdHotelRevenue.Cols[totalCols].Caption = "Breakfast Revenue";
                    this.grdHotelRevenue.Cols[totalCols].Name = "BreakfastRevenue";
                    this.grdHotelRevenue.Cols[totalCols].Format = decimalFormat;

                }
                    //for BANQUET
                else if (_tranCode == "1201")
                {
                    totalCols++;

                    this.grdHotelRevenue.Cols.Add();
                    this.grdHotelRevenue.Cols[totalCols].Caption = "Banquet Revenue";
                    this.grdHotelRevenue.Cols[totalCols].Name = "BanquetRevenue";
                    this.grdHotelRevenue.Cols[totalCols].Format = decimalFormat;

                }

            }

            totalCols = this.grdHotelRevenue.Cols.Count;
            //add column revenue & remarks

            this.grdHotelRevenue.Cols.Add();
            this.grdHotelRevenue.Cols[totalCols].Caption = "Vat";
            this.grdHotelRevenue.Cols[totalCols].Name = "GovernmentTax";
            this.grdHotelRevenue.Cols[totalCols].Format = decimalFormat;

            totalCols++;
            this.grdHotelRevenue.Cols.Add();
            this.grdHotelRevenue.Cols[totalCols].Caption = "Local Tax";
            this.grdHotelRevenue.Cols[totalCols].Name = "LocalTax";
            this.grdHotelRevenue.Cols[totalCols].Format = decimalFormat;

            totalCols++;
            this.grdHotelRevenue.Cols.Add();
            this.grdHotelRevenue.Cols[totalCols].Caption = "Service Charge";
            this.grdHotelRevenue.Cols[totalCols].Name = "ServiceCharge";
            this.grdHotelRevenue.Cols[totalCols].Format = decimalFormat;

            totalCols++;
            this.grdHotelRevenue.Cols.Add();
            this.grdHotelRevenue.Cols[totalCols].Caption = "Total Revenue";
            this.grdHotelRevenue.Cols[totalCols].Name = "TotalRevenue";
            this.grdHotelRevenue.Cols[totalCols].Format = decimalFormat;

            applyReportCustomization(defaultColumns);

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.grdHotelRevenue.Rows.Count = 1;

            DateTime startDate = this.dtpEndDate.Value;
            DateTime endDate = this.dtpStartDate.Value;

            DataTable tblReport = lReportFacade.getSalesAndMarketingRevenueReport(startDate, endDate);


            //this.grdHotelRevenue.DataSource = tblReport;

            this.grdHotelRevenue.Rows.Count = tblReport.Rows.Count + 1;
            int i = 1;
            foreach (DataRow row in tblReport.Rows)
            {


                //this.grdHotelRevenue.SetData(i, 0, i);
                foreach (DataColumn col in tblReport.Columns)
                {
                    string _colName = col.ColumnName;
                    try
                    {

                        this.grdHotelRevenue.SetData(i, _colName, row[_colName]);
                    }
                    catch { }
                }

                DateTime _fromDate = DateTime.Parse(row["fromDate"].ToString());
                DateTime _toDate = DateTime.Parse(row["toDate"].ToString());

                this.grdHotelRevenue.SetData(i, 4, _fromDate.ToString("MMM dd") + " - " + _toDate.ToString("MMM dd, yyyy"));

                i++;
            }

            showSubTotals();
            this.Cursor = Cursors.Default;
        }


        private void showSubTotals()
        {
            for (int r = 1; r < this.grdHotelRevenue.Rows.Count; r++)
            {
                decimal _total = 0;
                for (int c = 12; c < this.grdHotelRevenue.Cols.Count - 2; c++)
                {
                    string _data = this.grdHotelRevenue.GetDataDisplay(r, c);
                    decimal _temp = 0;
                    decimal.TryParse(_data, out _temp);

                    _total += _temp;

                }

                this.grdHotelRevenue.SetData(r, this.grdHotelRevenue.Cols.Count - 1, _total);
            }

            this.grdHotelRevenue.AutoSizeCols();
        }

        private void btnCustomize_Click(object sender, EventArgs e)
        {
            this.pnlCustomizeReport.Left = (this.Width / 2) - (this.pnlCustomizeReport.Width / 2);
            this.pnlCustomizeReport.Top = (this.Height / 2) - (this.pnlCustomizeReport.Height / 2);

            this.pnlCustomizeReport.Visible = true;


            this.lvwCustomizableFields.Items.Clear();
            foreach (C1.Win.C1FlexGrid.Column col in this.grdHotelRevenue.Cols)
            {

                ListViewItem lvwItem = new ListViewItem(col.Caption);
                lvwItem.SubItems.Add(col.Name);

                System.Windows.Forms.CheckBox chk = new System.Windows.Forms.CheckBox();
                chk.Tag = col.Name;
                chk.Text = col.Caption;

                if (col.Visible)
                {
                    lvwItem.Checked = true;
                }
                else
                {
                    lvwItem.Checked = false;
                }

                this.lvwCustomizableFields.Items.Add(lvwItem);

            }
        }


        private void applyReportCustomization(ArrayList defaultColumns)
        {
            foreach (C1.Win.C1FlexGrid.Column gridCol in this.grdHotelRevenue.Cols)
            {
                gridCol.Visible = true;
                
                foreach (string col in defaultColumns)
                {
                    if (gridCol.Name == col)
                    {
                        gridCol.Visible = false;
                        break;
                    }
                }
            }

        }

        private void btnApplyCustomization_Click(object sender, EventArgs e)
        {
            ArrayList selectedColumns = new ArrayList();

            foreach (ListViewItem item in this.lvwCustomizableFields.Items)
            {
                if (!item.Checked)
                {
                    selectedColumns.Add(item.SubItems[1].Text);

                }
            }

            applyReportCustomization(selectedColumns);
            this.pnlCustomizeReport.Visible = false;
        }

        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            this.pnlCustomizeReport.Visible = false;
        }

        private void pnlCustomizeReport_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlCustomizeReport.Visible)
            {
                this.pnlReport.Enabled = false;
            }
            else
            {
                this.pnlReport.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //try
            //{
                sfdExport.Filter = "Excel Files (*.xls)|*.XLS|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = "Revenue Report " + this.dtpStartDate.Value.ToString("MMMddyyyy");

                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    string filelocation = sfdExport.FileName;

                    this.grdHotelRevenue.SaveExcel(filelocation,"Sales", C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);

                    MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            //}
            //catch
            //{ }
        }

    }
}