using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
//using ExcelInterop = Microsoft.Office.Interop.Excel;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.AccountingInterface.Navision_Interface.BusinessLayer;
using Jinisys.Hotel.AccountingInterface.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess;
using Jinisys.Hotel.Security.Presentation;
using Jinisys.Hotel.AccountingInterface.SAP_Interface;
using Jinisys.Hotel.AccountingInterface.Peachtree_Interface;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{


    public partial class PostToAccountingUI : Form
    {
        public PostToAccountingUI()
        {
            InitializeComponent();
        }

        private BackOfficeConfig loBackOfficeConfig;
        private BackOfficeConfigFacade loBackOfficeConfigFacade;

        #region "EVENTS"

        private void PostToAccountingUI_Load(object sender, EventArgs e)
        {

            DateTime currentAuditDate = DateTime.Parse(GlobalVariables.gAuditDate);
            DateTime startDate = currentAuditDate.AddDays(-1);

            this.dtpDateToBePosted.Value = startDate;

            loBackOfficeConfig = new BackOfficeConfig();
            loBackOfficeConfigFacade = new BackOfficeConfigFacade();
            try
            {
                loBackOfficeConfig = loBackOfficeConfigFacade.getBackOfficeConfig();

                this.txtBackOfficeName.Text = loBackOfficeConfig.BackOfficeName;
                this.txtVersion.Text = loBackOfficeConfig.BackOfficeVersion;
                this.txtSchedule.Text = loBackOfficeConfig.PostingSchedule;
                this.txtConnectionStr.Text = loBackOfficeConfig.ConnectionString;
            }
            catch
            {
                MessageBox.Show("No current integrated backoffice configuration found.\r\nPlease setup now.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            bool includePosted = true;
            if (chkIncludePostedTrans.Checked)
            {
                includePosted = true;
            }
            else
            {
                includePosted = false;
            }
            DialogResult _rsp = MessageBox.Show("Post unposted folio transaction to " + this.txtBackOfficeName.Text + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_rsp == DialogResult.No)
            {
                return;
            }


            this.Cursor = Cursors.WaitCursor;

            Navision_Interface_Facade oNavisionInterfaceFacade = new Navision_Interface_Facade();
            string _backOffice = "";
            try
            {

                _backOffice = loBackOfficeConfig.BackOfficeName;

                switch (_backOffice)
                {
                    case "NONE":
                        { break; }

                    case "NAVISION":
                        {
                            oNavisionInterfaceFacade.PostToNavision(loBackOfficeConfig.ConnectionString);
                            break;
                        }
                    case "ORACLE":
                        writeToOracleEntryLoader();
                        break;

                    case "Exact-Globe":
                    case "EXACT-GLOBE":
                        exportToExactGlobe();
                        break;

                    case "SAP-Business 1":
                        exportToSAP();

                        break;
                    case "PeachTree":

                        DialogResult res;

                        ////Export Chart of Accounts
                        //res = MessageBox.Show("Export Chart of Accounts?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (res == DialogResult.Yes)
                        //{
                        //    exportChart();
                        //}

                        //Export Transactions
                        res = MessageBox.Show("Export Transactions?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportFolioTransactions(includePosted);
                        }

                        res = MessageBox.Show("Export Resto Transactions?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(res == DialogResult.Yes)
                        {
                            exportRestoTransactions(includePosted);
                        }

                        res = MessageBox.Show("Export Credit Card and City Transfers?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportCreditCardAndCityTransfers(includePosted);
                        }

                        res = MessageBox.Show("Export Non-Guest Transactions?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportNonGuestTransactions(includePosted);
                        }

                        res = MessageBox.Show("Export Payments?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportFolioReceipts(includePosted);
                        }

                        res = MessageBox.Show("Export Non-Guest Payments?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportNonGuestReceipts(includePosted);
                        }

                        res = MessageBox.Show("Export Hotel Transactions?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportGeneralLedger(includePosted);
                        }

                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error posting to " + _backOffice + ".\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnExportDebtors_Click(object sender, EventArgs e)
        {
            string _backOffice = "";
            try
            {

                _backOffice = loBackOfficeConfig.BackOfficeName;

                switch (_backOffice)
                {
                    case "NONE":
                        { break; }

                    case "NAVISION":
                        {
                            //oNavisionInterfaceFacade.PostToNavision(loBackOfficeConfig.ConnectionString);
                            break;
                        }
                    case "ORACLE":
                        //writeToOracleEntryLoader();
                        break;

                    case "EXACT-GLOBE":
                        exportExactCustomers();
                        break;

                    case "SAP-Business 1":
                        exportSAPCustomers();
                        break;

                    case "PeachTree":
                        DialogResult res;

                        //Export Customers
                        res = MessageBox.Show("Export Customer list from " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy") + "?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportClients("Customers");
                        }

                        //Export Companies
                        res = MessageBox.Show("Export Company list from " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy") + "?", "Confirm Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            exportClients("Companies");
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error posting to " + _backOffice + ".\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnChangePostingDate_Click(object sender, EventArgs e)
        {
            this.dtpDateToBePosted.Enabled = true;
        }

        #endregion

        #region "EXPORT"
        //Method Export to Excel (.txt) File ( tab separated )
        public void CreateCSVFile(DataTable dt, string strFilePath)
        {

            StreamWriter sw = new StreamWriter(strFilePath, false);

            int iColCount = dt.Columns.Count;

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }


                    if (i < iColCount - 1)
                    {
                        sw.Write("\t");
                    }
                }

                sw.Write(sw.NewLine);
            }


            sw.Close();


        }

        //Method Export to Excel (.csv) File( comma separated )
        public void CreateCSVFile2(DataTable dt, string strFilePath)
        {

            StreamWriter sw = new StreamWriter(strFilePath, false);

            int iColCount = dt.Columns.Count;

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }


                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.Write(sw.NewLine);
            }


            sw.Close();


        }
        #endregion

        #region "ORACLE"
        private void writeToOracleEntryLoader()
        {
            this.Cursor = Cursors.WaitCursor;


            //ExcelInterop.Application _oExcel = null;
            //// test if Environment has Excel Application
            //_oExcel = new ExcelInterop.Application();
            //// See if the Excel Application Object was successfully constructed
            //if (_oExcel == null)
            //{
            //    MessageBox.Show("ERROR: Excel couldn't be started.\r\\nPosting aborted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //_oExcel.DisplayAlerts = false;


            //try
            //{
            //    DataTable _dtFolioTransactions = loBackOfficeConfigFacade.getUnpostedFolioTransactions();

            //    // Here is the call to Open a Workbook in Excel
            //    // It uses most of the default values (except for the read-only which we set to true)
            //    //using ExcelInterop = Microsoft.Office.Interop.Excel;
            //    string _fileName = this.txtConnectionStr.Text;

            //    ExcelInterop.ApplicationClass oExcelClass = new ExcelInterop.ApplicationClass();
            //    ExcelInterop.WorkbookClass _workBook = (ExcelInterop.WorkbookClass)oExcelClass.Workbooks.Open(_fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            //    // get the collection of sheets in the workbook
            //    ExcelInterop.Sheets _sheets = _workBook.Worksheets;
            //    // get the first and only worksheet from the collection of worksheets
            //    ExcelInterop.Worksheet _worksheet = (ExcelInterop.Worksheet)_sheets.get_Item(2);


            //    int _count = _dtFolioTransactions.Rows.Count;

            //    // write excel values
            //    int i = 16;
            //    foreach(DataRow _dRow in _dtFolioTransactions.Rows)
            //    {
            //        ArrayList strList = new ArrayList();
            //        strList.Add("O");
            //        strList.Add("FSA");
            //        strList.Add("2141");
            //        strList.Add("21411");
            //        strList.Add("000");
            //        strList.Add("000");
            //        strList.Add("00000");
            //        strList.Add("000");
            //        if (_dRow["AcctSide"].ToString() == "DEBIT")
            //        {
            //            strList.Add(_dRow["BaseAmount"].ToString());
            //            strList.Add("");
            //        }
            //        else
            //        {
            //            strList.Add("");
            //            strList.Add(_dRow["BaseAmount"].ToString());
            //        }


            //        ExcelInterop.Range _range = _worksheet.get_Range("B" + i.ToString(), "K" + i.ToString());
            //        _range.Cells.Value2 = strList.ToArray();

            //        i++;
            //        // insert new row
            //        _worksheet.get_Range("B" + i.ToString(), "K" + i.ToString()).Insert(ExcelInterop.XlInsertShiftDirection.xlShiftDown, null);
            //    }

            //    _workBook.Save();
            //    //theWorkbook.Close(ExcelInterop.XlSaveAction.xlSaveChanges, fileName, ExcelInterop.XlRoutingSlipDelivery.xlAllAtOnce);
            //    //theWorkbook.SaveAs(fileName, theWorkbook.FileFormat, null,null,null,null,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, null, null,null,null,null);
            //    //theWorkbook.Close(ExcelInterop.XlSaveAction.xlSaveChanges, fileName, null);
            //    _oExcel.Quit();

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //theWorkbook.Close("Yes", fileName, "");
            //    _oExcel.Quit();
            //}

            this.Cursor = Cursors.Default;
            this.Close();
        }
        #endregion

        #region "EXACT"
        public string lExactAdjustmentAccount = "";

        private void exportToExactGlobe()
        {

            lExactAdjustmentAccount = ConfigVariables.gExactAdjustmentAccount;

            if (this.chkIncludePostedTrans.Checked)
            {
                string _priv = "Export POSTED transactions to Exact Globe";

                VerifyUserUI oVerifyUserUI = new VerifyUserUI(_priv);
                if (!oVerifyUserUI.showDialog())
                {
                    // exit if not authorized
                    return;
                }

            }


            DataTable tblExactData = new DataTable();

            DataColumn col1 = new DataColumn("LineNo", typeof(int));
            DataColumn col2 = new DataColumn("ItemType", typeof(string));
            DataColumn col3 = new DataColumn("JournalNo", typeof(string));
            DataColumn col4 = new DataColumn("Period", typeof(int));
            DataColumn col5 = new DataColumn("Year", typeof(int));
            DataColumn col6 = new DataColumn("EntryNo", typeof(string));
            DataColumn col7 = new DataColumn("YourReferenceNo", typeof(string));
            DataColumn col8 = new DataColumn("Date", typeof(string));
            DataColumn col9 = new DataColumn("GLCode", typeof(string));
            DataColumn col10 = new DataColumn("CustomerNo", typeof(string));
            DataColumn col11 = new DataColumn("ReferenceNo", typeof(string));
            DataColumn col12 = new DataColumn("Amount", typeof(decimal));
            DataColumn col13 = new DataColumn("Blank1", typeof(string));
            DataColumn col14 = new DataColumn("Currency", typeof(string));
            DataColumn col15 = new DataColumn("Col1", typeof(string));
            DataColumn col16 = new DataColumn("ColB", typeof(string));
            DataColumn col17 = new DataColumn("Col0", typeof(string));
            DataColumn col18 = new DataColumn("Date1", typeof(string));
            DataColumn col19 = new DataColumn("Date2", typeof(string));
            DataColumn col20 = new DataColumn("Blank2", typeof(string));
            DataColumn col21 = new DataColumn("Blank3", typeof(string));
            DataColumn col22 = new DataColumn("Blank4", typeof(string));
            DataColumn col23 = new DataColumn("Blank5", typeof(string));
            DataColumn col24 = new DataColumn("Blank6", typeof(string));
            DataColumn col25 = new DataColumn("CostCenter", typeof(string));
            DataColumn col26 = new DataColumn("Blank7", typeof(string));
            DataColumn col27 = new DataColumn("Blank8", typeof(string));
            DataColumn col28 = new DataColumn("Blank9", typeof(string));
            DataColumn col29 = new DataColumn("Blank10", typeof(string));
            DataColumn col30 = new DataColumn("Blank11", typeof(string));
            DataColumn col31 = new DataColumn("Blank12", typeof(string));
            DataColumn col32 = new DataColumn("Blank13", typeof(string));


            tblExactData.Columns.Add(col1);
            tblExactData.Columns.Add(col2);
            tblExactData.Columns.Add(col3);
            tblExactData.Columns.Add(col4);
            tblExactData.Columns.Add(col5);
            tblExactData.Columns.Add(col6);
            tblExactData.Columns.Add(col7);
            tblExactData.Columns.Add(col8);
            tblExactData.Columns.Add(col9);
            tblExactData.Columns.Add(col10);
            tblExactData.Columns.Add(col13);
            tblExactData.Columns.Add(col11);
            tblExactData.Columns.Add(col12);
            tblExactData.Columns.Add(col20);
            tblExactData.Columns.Add(col14);

            tblExactData.Columns.Add(col15);
            tblExactData.Columns.Add(col16);
            tblExactData.Columns.Add(col17);
            tblExactData.Columns.Add(col18);
            tblExactData.Columns.Add(col19);

            tblExactData.Columns.Add(col21);
            tblExactData.Columns.Add(col22);
            tblExactData.Columns.Add(col23);
            tblExactData.Columns.Add(col24);
            tblExactData.Columns.Add(col26);
            tblExactData.Columns.Add(col27);

            tblExactData.Columns.Add(col25);

            tblExactData.Columns.Add(col28);
            tblExactData.Columns.Add(col29);
            tblExactData.Columns.Add(col30);
            tblExactData.Columns.Add(col31);
            tblExactData.Columns.Add(col32);

            TransactionCodeMappingDAO oTransactionCodeMappingDAO = new TransactionCodeMappingDAO(GlobalVariables.gPersistentConnection);

            DateTime startDate = this.dtpDateToBePosted.Value;
            DateTime endDate = startDate;

            bool includePostedTrans = this.chkIncludePostedTrans.Checked;

            DataTable temp = oTransactionCodeMappingDAO.getUnpostedDailyHotelRevenueForExact(startDate, endDate, includePostedTrans);
            DataView dtView = temp.DefaultView;
            dtView.Sort = "TransactionDate, TransactionCode, GuestName";


            foreach (DataRowView row in dtView)
            {

                string _tranCode = row["transactionCode"].ToString();

                DataTable tblTranCodeMapping = oTransactionCodeMappingDAO.getTransactionCodeMapping(GlobalVariables.gHotelId, _tranCode);


                if (tblTranCodeMapping != null)
                {
                    int i = 0;
                    foreach (DataRow tmRow in tblTranCodeMapping.Rows)
                    {

                        //line 0
                        DataRow _newRow = tblExactData.NewRow();

                        DateTime _tranDate = DateTime.Parse(row["transactionDate"].ToString());
                        string _costCenterCode = tmRow["CostCenterCode"].ToString();

                        //int _lineNo = int.Parse(tmRow["LineNo"].ToString() ); 

                        _newRow[col1] = i;
                        _newRow[col2] = "V";
                        _newRow[col3] = 301;
                        _newRow[col4] = _tranDate.Month;
                        _newRow[col5] = _tranDate.Year;
                        _newRow[col6] = "";
                        _newRow[col7] = row["ReferenceNo"].ToString();
                        _newRow[col8] = _tranDate.ToString("ddMMyyyy");
                        _newRow[col9] = tmRow["Exact_GLAccountID"].ToString();

                        string _accountID = row["AccountID"].ToString();
                        //1  = WALK-IN CUSTOMER 
                        if (_accountID.Length > 2)
                        {
                            try
                            {
                                _newRow[col10] = int.Parse(_accountID.Substring(2));
                            }
                            catch
                            {
                                _newRow[col10] = "1";
                            }
                        }
                        else
                        {
                            _newRow[col10] = "1";
                        }


                        _newRow[col13] = "";
                        _newRow[col11] = "";

                        decimal _amount = decimal.Parse(row[tmRow["AmountColumnInFolioTrans"].ToString()].ToString());

                        _newRow[col12] = _amount.ToString("N3");
                        _newRow[col20] = "";

                        _newRow[col14] = "PHP";

                        if (i == 0)
                        {
                            _newRow[col15] = "";
                        }
                        else
                        {
                            _newRow[col15] = "1";
                        }


                        if (i == 0)
                        {
                            _newRow[col16] = "B";
                        }
                        else
                        {
                            _newRow[col16] = "";
                        }

                        if (i == 0)
                        {
                            _newRow[col17] = "0";
                        }
                        else
                        {
                            _newRow[col17] = "";
                        }


                        _newRow[col18] = _tranDate.ToString("ddMMyyyy");
                        _newRow[col19] = _tranDate.ToString("ddMMyyyy");


                        if (i == 0)
                        {
                            _newRow[col21] = "";
                        }
                        else
                        {
                            _newRow[col21] = "0";
                        }

                        if (i == 0)
                        {
                            _newRow[col22] = "";
                        }
                        else
                        {
                            _newRow[col22] = "0";
                        }

                        _newRow[col23] = "";

                        string _memo = row["Memo"].ToString();
                        _memo = _memo.Replace(",", " ");
                        _memo = _memo.Replace(";", "-");

                        _newRow[col24] = _memo;

                        if (i == 0)
                        {
                            _newRow[col26] = "B";
                        }
                        else
                        {
                            _newRow[col26] = "";
                        }

                        _newRow[col27] = "";

                        if (i == 0)
                        {
                            _newRow[col25] = "";
                        }
                        else
                        {
                            if (_costCenterCode == "ROOMNO")
                            {
                                _newRow[col25] = "0" + row["RoomID"].ToString();
                            }
                            else
                            {
                                _newRow[col25] = _costCenterCode;
                            }
                        }

                        _newRow[col28] = "";

                        if (i == 0)
                        {
                            _newRow[col29] = "";
                        }
                        else
                        {
                            _newRow[col29] = "0";
                        }


                        _newRow[col30] = "";
                        _newRow[col31] = "";


                        if (_amount > 0)
                        {
                            if (i == 0)
                            {
                                _newRow[col32] = "N";
                            }
                            else
                            {
                                _newRow[col32] = "K";
                            }
                        }
                        else
                        {
                            if (i == 0)
                            {
                                _newRow[col32] = "N";
                            }
                            else
                            {
                                _newRow[col32] = "C";
                            }
                        }


                        tblExactData.Rows.Add(_newRow);

                        i++;

                    }//end inner for


                }//end for


            }


            try
            {
                sfdExport.Filter = "CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = "Revenue Report - " + startDate.ToString("MMMddyyyy");

                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    string filelocation = sfdExport.FileName;

                    //check Total for each ENTRY
                    // to fix 0.001 difference
                    if (lExactAdjustmentAccount != "")
                    {
                        checkTransactionsTotal(tblExactData);
                    }

                    CreateCSVFile(tblExactData, filelocation);


                    //set posted
                    oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);


                    MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void checkTransactionsTotal(DataTable tblExactData)
        {

            decimal _maxAllowedOverwrite = decimal.Parse("0.01");

            int rowNum = 0;
            int adjustAtRowNum = 0;

            decimal _totalFromEntry = 0;
            decimal _actualAmount = 0;
            foreach (DataRow row in tblExactData.Rows)
            {


                decimal _amount = decimal.Parse(row["Amount"].ToString());

                int _lineNo = int.Parse(row["LineNo"].ToString());

                if (row["GLCode"].ToString() == lExactAdjustmentAccount)
                {
                    adjustAtRowNum = rowNum;
                }

                if (_lineNo == 0)
                {
                    // compare values
                    if (rowNum > 0)
                    {
                        if (_actualAmount != _totalFromEntry)
                        {
                            decimal _difference = _actualAmount - _totalFromEntry;

                            decimal _amountToAdjust = decimal.Parse(tblExactData.Rows[adjustAtRowNum]["Amount"].ToString());
                            _amountToAdjust += _difference;

                            //overwrite

                            if (Math.Abs(_difference) < _maxAllowedOverwrite)
                            {
                                tblExactData.Rows[adjustAtRowNum]["Amount"] = _amountToAdjust;
                            }
                        }
                        _actualAmount = 0;
                        _totalFromEntry = 0;
                    }

                    _actualAmount = _amount;
                }
                else
                {
                    _totalFromEntry += _amount;
                }


                rowNum++;

            }
            // for last entry
            // compare values
            if (rowNum > 0)
            {
                if (_actualAmount != _totalFromEntry)
                {
                    decimal _difference = _actualAmount - _totalFromEntry;

                    decimal _amountToAdjust = decimal.Parse(tblExactData.Rows[adjustAtRowNum]["Amount"].ToString());
                    _amountToAdjust += _difference;

                    //overwrite    0.001      < 0.01
                    if (Math.Abs(_difference) < _maxAllowedOverwrite)
                    {
                        tblExactData.Rows[adjustAtRowNum]["Amount"] = _amountToAdjust;
                    }
                }
            }


        }

        private void exportExactCustomers()
        {

            try
            {
                DataTable tblExactDebtors = new DataTable();

                DataColumn col1 = new DataColumn("CustomerCoe", typeof(string));
                DataColumn col2 = new DataColumn("Name", typeof(string));
                DataColumn col3 = new DataColumn("Address", typeof(string));
                DataColumn col4 = new DataColumn("col4", typeof(string));
                DataColumn col5 = new DataColumn("col5", typeof(string));
                DataColumn col6 = new DataColumn("col6", typeof(string));
                DataColumn col7 = new DataColumn("Country", typeof(string));
                DataColumn col8 = new DataColumn("col8", typeof(string));
                DataColumn col9 = new DataColumn("Currency", typeof(string));
                DataColumn col10 = new DataColumn("TelephoneNo", typeof(string));
                DataColumn col11 = new DataColumn("col11", typeof(string));
                DataColumn col12 = new DataColumn("col12", typeof(string));
                DataColumn col13 = new DataColumn("col13", typeof(string));
                DataColumn col14 = new DataColumn("col14", typeof(string));
                DataColumn col15 = new DataColumn("col15", typeof(string));
                DataColumn col16 = new DataColumn("col16", typeof(string));
                DataColumn col17 = new DataColumn("col17", typeof(string));
                DataColumn col18 = new DataColumn("col18", typeof(string));
                DataColumn col19 = new DataColumn("col19", typeof(string));
                DataColumn col20 = new DataColumn("col20", typeof(string));
                DataColumn col21 = new DataColumn("col21", typeof(string));
                DataColumn col22 = new DataColumn("col22", typeof(string));
                DataColumn col23 = new DataColumn("col23", typeof(string));
                DataColumn col24 = new DataColumn("col24", typeof(string));
                DataColumn col25 = new DataColumn("col25", typeof(string));
                DataColumn col26 = new DataColumn("col26", typeof(string));
                DataColumn col27 = new DataColumn("col27", typeof(string));
                DataColumn col28 = new DataColumn("col28", typeof(string));
                DataColumn col29 = new DataColumn("col29", typeof(string));
                DataColumn col30 = new DataColumn("col30", typeof(string));
                DataColumn col31 = new DataColumn("col31", typeof(string));
                DataColumn col32 = new DataColumn("col32", typeof(string));
                DataColumn col33 = new DataColumn("col33", typeof(string));
                DataColumn col34 = new DataColumn("col34", typeof(string));
                DataColumn col35 = new DataColumn("col35", typeof(string));
                DataColumn col36 = new DataColumn("col36", typeof(string));
                DataColumn col37 = new DataColumn("col37", typeof(string));
                DataColumn col38 = new DataColumn("col38", typeof(string));
                DataColumn col39 = new DataColumn("col39", typeof(string));
                DataColumn col40 = new DataColumn("col40", typeof(string));
                DataColumn col41 = new DataColumn("col41", typeof(string));
                DataColumn col42 = new DataColumn("col42", typeof(string));
                DataColumn col43 = new DataColumn("col43", typeof(string));
                DataColumn col44 = new DataColumn("col44", typeof(string));
                DataColumn col45 = new DataColumn("col45", typeof(string));
                DataColumn col46 = new DataColumn("col46", typeof(string));
                DataColumn col47 = new DataColumn("col47", typeof(string));
                DataColumn col48 = new DataColumn("col48", typeof(string));
                DataColumn col49 = new DataColumn("col49", typeof(string));
                DataColumn col50 = new DataColumn("col50", typeof(string));
                DataColumn col51 = new DataColumn("col51", typeof(string));
                DataColumn col52 = new DataColumn("col52", typeof(string));
                DataColumn col53 = new DataColumn("col53", typeof(string));



                tblExactDebtors.Columns.Add(col1);
                tblExactDebtors.Columns.Add(col2);
                tblExactDebtors.Columns.Add(col3);
                tblExactDebtors.Columns.Add(col4);
                tblExactDebtors.Columns.Add(col5);
                tblExactDebtors.Columns.Add(col6);
                tblExactDebtors.Columns.Add(col7);
                tblExactDebtors.Columns.Add(col8);
                tblExactDebtors.Columns.Add(col9);
                tblExactDebtors.Columns.Add(col10);
                tblExactDebtors.Columns.Add(col11);
                tblExactDebtors.Columns.Add(col12);
                tblExactDebtors.Columns.Add(col13);
                tblExactDebtors.Columns.Add(col14);
                tblExactDebtors.Columns.Add(col15);
                tblExactDebtors.Columns.Add(col16);
                tblExactDebtors.Columns.Add(col17);
                tblExactDebtors.Columns.Add(col18);
                tblExactDebtors.Columns.Add(col19);
                tblExactDebtors.Columns.Add(col20);
                tblExactDebtors.Columns.Add(col21);
                tblExactDebtors.Columns.Add(col22);
                tblExactDebtors.Columns.Add(col23);
                tblExactDebtors.Columns.Add(col24);
                tblExactDebtors.Columns.Add(col25);
                tblExactDebtors.Columns.Add(col26);
                tblExactDebtors.Columns.Add(col27);
                tblExactDebtors.Columns.Add(col28);
                tblExactDebtors.Columns.Add(col29);
                tblExactDebtors.Columns.Add(col30);
                tblExactDebtors.Columns.Add(col31);
                tblExactDebtors.Columns.Add(col32);
                tblExactDebtors.Columns.Add(col33);
                tblExactDebtors.Columns.Add(col34);
                tblExactDebtors.Columns.Add(col35);
                tblExactDebtors.Columns.Add(col36);
                tblExactDebtors.Columns.Add(col37);
                tblExactDebtors.Columns.Add(col38);
                tblExactDebtors.Columns.Add(col39);
                tblExactDebtors.Columns.Add(col40);
                tblExactDebtors.Columns.Add(col41);
                tblExactDebtors.Columns.Add(col42);
                tblExactDebtors.Columns.Add(col43);
                tblExactDebtors.Columns.Add(col44);
                tblExactDebtors.Columns.Add(col45);
                tblExactDebtors.Columns.Add(col46);
                tblExactDebtors.Columns.Add(col47);
                tblExactDebtors.Columns.Add(col48);
                tblExactDebtors.Columns.Add(col49);
                tblExactDebtors.Columns.Add(col50);
                tblExactDebtors.Columns.Add(col51);
                tblExactDebtors.Columns.Add(col52);
                tblExactDebtors.Columns.Add(col53);

                DateTime currentAuditDate = DateTime.Parse(GlobalVariables.gAuditDate);
                DateTime pExportDate = this.dtpDateToBePosted.Value;

                //get customer data from table "guests"
                TransactionCodeMappingDAO oTransactionCodeMappingDAO = new TransactionCodeMappingDAO(GlobalVariables.gPersistentConnection);
                DataTable tblGuests = oTransactionCodeMappingDAO.getExactNewGuests(pExportDate);


                foreach (DataRow row in tblGuests.Rows)
                {

                    DataRow _newRow = tblExactDebtors.NewRow();

                    string _accountId = row["accountID"].ToString();

                    _newRow[col1] = int.Parse(_accountId.Substring(2));

                    string _firstName = row["firstName"].ToString();
                    string _lastName = row["lastName"].ToString();

                    _firstName = _firstName.Replace(",", " ");
                    _firstName = _firstName.Replace(";", "-");

                    _lastName = _lastName.Replace(",", " ");
                    _lastName = _lastName.Replace(";", "-");

                    string _fullname = _firstName + " " + _lastName;
                    if (_fullname.Length > 45)
                    {
                        _fullname = _fullname.Substring(0, 45);
                    }

                    _newRow[col2] = _fullname;

                    _newRow[col7] = "PH";//row["country"].ToString().Substring(0, 2);


                    _newRow[col9] = "PHP";

                    string _telephoneNo = row["TelephoneNo"].ToString();
                    _telephoneNo = _telephoneNo.Replace(",", " ");
                    _telephoneNo = _telephoneNo.Replace(";", "-");
                    if (_telephoneNo.Length > 25)
                    {
                        _telephoneNo = _telephoneNo.Substring(0, 25);
                    }

                    _newRow[col10] = _telephoneNo;

                    _newRow[col12] = "--";
                    _newRow[col13] = "M";

                    _newRow[col14] = "MR";
                    _newRow[col16] = "--";
                    _newRow[col22] = "B";
                    _newRow[col25] = "0";
                    _newRow[col26] = "CA";
                    _newRow[col28] = "0";
                    _newRow[col29] = "J";
                    _newRow[col30] = "00";
                    _newRow[col31] = "N";
                    _newRow[col36] = "0";
                    _newRow[col39] = "EN";

                    _newRow[col53] = " ";


                    tblExactDebtors.Rows.Add(_newRow);

                }

                sfdExport.Filter = "CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = "Debtors - " + pExportDate.ToString("MMMddyyyy");

                try
                {
                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {

                        CreateCSVFile(tblExactDebtors, sfdExport.FileName);


                        //update tables
                        // set POSTED flag = 1;


                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region "SAP"
        private void exportToSAP()
        {
            if (this.chkIncludePostedTrans.Checked)
            {
                string _priv = "Export POSTED transactions to SAP";

                VerifyUserUI oVerifyUserUI = new VerifyUserUI(_priv);
                if (!oVerifyUserUI.showDialog())
                {
                    // exit if not authorized
                    return;
                }
            }


            Template[] arrTemplates = Template.getAllTemplates();
            DataTable[] arrTables = new DataTable[arrTemplates.Length];

            //>> create DataTable for export
            int c = 0;
            foreach (Template oTemplate in arrTemplates)
            {
                arrTables[c] = new DataTable();

                foreach (SAP_Interface.TemplateField oField in oTemplate.Fields)
                {
                    DataColumn col = new DataColumn(oField.Name, typeof(string));

                    arrTables[c].Columns.Add(col);

                }

                c++;
            }

            //create first 2 rows
            c = 0;
            foreach (Template oTemplate in arrTemplates)
            {

                DataRow row = arrTables[c].NewRow();
                DataRow row2 = arrTables[c].NewRow();

                foreach (SAP_Interface.TemplateField oField in oTemplate.Fields)
                {
                    row[oField.Name] = oField.Name;
                    row2[oField.Name] = oField.Description;
                }

                arrTables[c].Rows.Add(row);
                arrTables[c].Rows.Add(row2);

                arrTables[c].AcceptChanges();
                c++;
            }



            //create Template Entries

            Template tInvoiceDetailRoom = null;
            int invoiceDetailRoomIndex = 0;

            Template tInvoiceHeaderRoom = null;
            int invoiceHeaderRoomIndex = 0;

            Template tInvoiceDetailInventory = null;
            int invoiceDetailInventoryIndex = 0;

            Template tInvoiceHeaderInventory = null;
            int invoiceHeaderInventoryIndex = 0;

            Template tPaymentAccounts = null;
            int paymentAccountsIndex = 0;

            Template tPaymentCheques = null;
            int paymentChequesIndex = 0;

            Template tPaymentCreditCard = null;
            int paymentCreditIndex = 0;

            Template tPaymentHeader = null;
            int paymentHeaderIndex = 0;

            Template tPaymentInvoice = null;
            int paymentInvoiceIndex = 0;

            Template tPaymentCash = null;
            int paymentCashIndex = 0;

            c = 0;
            foreach (Template oTemplate in arrTemplates)
            {

                switch (oTemplate.Name)
                {
                    case "AR Invoice Header - Item":
                        tInvoiceHeaderInventory = oTemplate;
                        invoiceHeaderInventoryIndex = c;
                        break;

                    case "AR Invoice Detail - Item":
                        tInvoiceDetailInventory = oTemplate;
                        invoiceDetailInventoryIndex = c;
                        break;

                    case "AR Invoice Header - Room":
                        tInvoiceHeaderRoom = oTemplate;
                        invoiceHeaderRoomIndex = c;
                        break;

                    case "AR Invoice Detail - Room":
                        tInvoiceDetailRoom = oTemplate;
                        invoiceDetailRoomIndex = c;
                        break;

                    case "Payments - Header":
                        tPaymentHeader = oTemplate;
                        paymentHeaderIndex = c;
                        break;

                    case "Payments - Accounts":
                        tPaymentAccounts = oTemplate;
                        paymentAccountsIndex = c;
                        break;

                    case "Payments - Checks":
                        tPaymentCheques = oTemplate;
                        paymentChequesIndex = c;
                        break;

                    case "Payments - Credit Cards":
                        tPaymentCreditCard = oTemplate;
                        paymentCreditIndex = c;
                        break;

                    case "Payments - Invoices":
                        tPaymentInvoice = oTemplate;
                        paymentInvoiceIndex = c;
                        break;

                    case "Payments - Cash":
                        tPaymentCash = oTemplate;
                        paymentCashIndex = c;
                        break;
                }
                c++;
            }


            TransactionCodeMappingDAO oTransactionCodeMappingDAO = new TransactionCodeMappingDAO(GlobalVariables.gPersistentConnection);

            DateTime startDate = this.dtpDateToBePosted.Value;
            DateTime endDate = startDate;

            bool includePostedTrans = this.chkIncludePostedTrans.Checked;

            #region "HOTEL CHARGES"
            //>>for Hotel Revenues
            DataTable tempData = oTransactionCodeMappingDAO.getUnpostedDailyHotelRevenueForExact(startDate, endDate, includePostedTrans);
            DataView dtView = tempData.DefaultView;
            dtView.Sort = "TransactionDate, TransactionCode, FolioID";
            string _folioID = "";

            DataTable dtInvoiceHeaderRoom = null;
            DataTable dtInvoiceDetailRoom = null;

            int idx = 1;
            foreach (DataRowView row in dtView)
            {

                string _tranCode = row["transactionCode"].ToString();

                ArrayList tblTranCodeMapping = Folio_GLAccountMapping.getTransactionCodeMapping(_tranCode, GlobalVariables.gPersistentConnection);


                //for AR Invoice Header - Room and AR Invoice Detail - Room
                if (tblTranCodeMapping.Count > 0)
                {

                    //int i = 0;
                    foreach (Folio_GLAccountMapping oMap in tblTranCodeMapping)
                    {

                        //invoiceHeader-Room
                        if (oMap.LineNo == 0)
                        {

                            //create dataTable Template
                            if (invoiceHeaderRoomIndex > 0)
                            {
                                dtInvoiceHeaderRoom = arrTables[invoiceHeaderRoomIndex];

                                DataRow hNewRow = dtInvoiceHeaderRoom.NewRow();
                                foreach (SAP_Interface.TemplateField oField in tInvoiceHeaderRoom.Fields)
                                {

                                    if (oField.StatusFlag == "ACTIVE")
                                    {
                                        string _fieldName = oField.Name.Trim();
                                        switch (_fieldName)
                                        {
                                            case "RecordKey":
                                                hNewRow[oField.Name] = idx;
                                                break;

                                            case "DocType":
                                                hNewRow[oField.Name] = "dDocument_Service"; //fixed
                                                break;

                                            case "DocDate":
                                            case "DocDueDate":
                                            case "TaxDate":
                                                DateTime dtTemp = DateTime.Parse(row[oField.Field_In_Folio].ToString());
                                                hNewRow[oField.Name] = dtTemp.ToString("yyyyMMdd");
                                                break;

                                            case "SalesPersonCode": //todo: should be dynamic
                                                hNewRow[oField.Name] = "1";
                                                break;

                                            case "_":
                                            case "":
                                                hNewRow[oField.Name] = "";
                                                break;
                                            default:
                                                if (oField.Field_In_Folio != "")
                                                {
                                                    hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                                }
                                                break;
                                        }
                                    }

                                }

                                dtInvoiceHeaderRoom.Rows.Add(hNewRow);

                            }

                        }
                        else //invoiceDetail-Room
                        {
                            if (invoiceDetailRoomIndex > 0)
                            {

                                dtInvoiceDetailRoom = arrTables[invoiceDetailRoomIndex];

                                DataRow hNewRow = dtInvoiceDetailRoom.NewRow();
                                foreach (SAP_Interface.TemplateField oField in tInvoiceDetailRoom.Fields)
                                {

                                    if (oField.StatusFlag == "ACTIVE")
                                    {

                                        string _fieldName = oField.Name.Trim();
                                        switch (_fieldName)
                                        {
                                            case "RecordKey":
                                                hNewRow[oField.Name] = idx;
                                                break;

                                            case "LineNum":
                                                hNewRow[oField.Name] = oMap.LineNo - 1;
                                                break;

                                            case "CostingCode":
                                                if (oMap.CostCenterCode.ToUpper() == "ROOMNO")
                                                {
                                                    hNewRow[oField.Name] = row["RoomID"].ToString();
                                                }
                                                else
                                                {
                                                    hNewRow[oField.Name] = oMap.CostCenterCode;
                                                }

                                                break;
                                            case "LineTotal":
                                                hNewRow[oField.Name] = row[oMap.AmountColumnInFolioTrans].ToString();
                                                break;
                                            case "SalesPersonCode": //to be dynamic
                                                hNewRow[oField.Name] = "2";
                                                break;

                                            case "AccountCode":
                                                hNewRow[oField.Name] = oMap.GLAccountID;
                                                break;

                                            case "VatGroup":
                                                hNewRow[oField.Name] = "x0";
                                                break;

                                            case "_":
                                            case "":
                                                hNewRow[oField.Name] = "";
                                                break;
                                            default:
                                                if (oField.Field_In_Folio != "")
                                                {
                                                    hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                                }
                                                break;
                                        }
                                    }

                                }

                                dtInvoiceDetailRoom.Rows.Add(hNewRow);

                            }


                        }

                    }//end inner for


                }//end for

                idx++;
            }


            if (dtInvoiceHeaderRoom != null)
            {

                try
                {
                    sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                    sfdExport.FileName = "Invoice Header Room - " + startDate.ToString("MMMddyyyy");

                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {
                        string filelocation = sfdExport.FileName;

                        CreateCSVFile(dtInvoiceHeaderRoom, filelocation);

                        //set posted [set posted below]
                        //oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }
            else
            {
                //MessageBox.Show("Transaction failed.\r\nEither all transactions for the selected date have been posted or zero transactions.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (dtInvoiceDetailRoom != null)
            {
                //invoice detail - room
                try
                {
                    sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                    sfdExport.FileName = "Invoice Detail Room - " + startDate.ToString("MMMddyyyy");

                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {
                        string filelocation = sfdExport.FileName;

                        CreateCSVFile(dtInvoiceDetailRoom, filelocation);


                        //set posted
                        oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);


                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

            }
            //<<end of Hotel Revenues
            #endregion

            #region "HOTEL PAYMENTS"
            //>>for Hotel Payments
            DataTable tempPaymentData = oTransactionCodeMappingDAO.getUnpostedDailyHotelPaymentsForSAP(startDate, endDate, includePostedTrans);

            DataTable dtPaymentsHeader = null;
            DataTable dtPaymentsAccount = null;
            DataTable dtPaymentsCreditCard = null;
            DataTable dtPaymentsCheque = null;
            DataTable dtPaymentsCash = null;
            DataTable dtPaymentsInvoices = null;

            int idxPaymentHeader = 1;

            //>> for Payments - Accounts
            #region PAYMENTS - ACCOUNTS
            //DataView dtPaymentAccountView = tempPaymentData.DefaultView;
            //dtPaymentAccountView.RowStateFilter = DataViewRowState.OriginalRows;
            //dtPaymentAccountView.RowFilter = "trantypeid = 9";
            //dtPaymentAccountView.Sort = "TransactionDate, TransactionCode, GuestName";

            //int idxPaymentAcct = 1;
            //foreach (DataRowView row in dtPaymentAccountView)
            //{
            //    dtPaymentsAccount = arrTables[paymentAccountsIndex];

            //    DataRow hNewRow = dtPaymentsAccount.NewRow();
            //    foreach (SAP_Interface.TemplateField oField in tPaymentAccounts.Fields)
            //    {

            //        if (oField.StatusFlag == "ACTIVE")
            //        {
            //            string _fieldName = oField.Name.Trim();
            //            switch (_fieldName)
            //            {
            //                case "RecordKey":
            //                    hNewRow[oField.Name] = idxPaymentHeader;
            //                    break;

            //                case "LineNum":
            //                    hNewRow[oField.Name] = "1"; //fixed
            //                    break;

            //                case "AccountCode":
            //                    hNewRow[oField.Name] = row["accountid"].ToString();
            //                    break;
            //                case "Description":
            //                    hNewRow[oField.Name] = row["memo"].ToString();
            //                    break;

            //                case "SumPaid":
            //                    hNewRow[oField.Name] = row["netbaseamount"].ToString();
            //                    break;

            //                case "_":
            //                case "":
            //                    hNewRow[oField.Name] = "";
            //                    break;
            //                default:
            //                    if (oField.Field_In_Folio != "")
            //                    {
            //                        hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                    }
            //                    break;
            //            }
            //        }

            //    }

            //    dtPaymentsAccount.Rows.Add(hNewRow);
            //    idxPaymentAcct++;

            //    //>>for Payment Header
            //    dtPaymentsHeader = arrTables[paymentHeaderIndex];
            //    DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
            //    foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
            //    {
            //        if (oField.StatusFlag == "ACTIVE")
            //        {
            //            string _fieldName = oField.Name.Trim();
            //            switch (_fieldName)
            //            {
            //                case "RecordKey":
            //                    hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
            //                    break;

            //                case "CardCode":
            //                    hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
            //                    break;

            //                case "DocDate":
            //                    DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
            //                    break;

            //                case "DocNum":
            //                    hPaymentHeaderRow[oField.Name] = "";
            //                    break;

            //                case "Reference2":
            //                    hPaymentHeaderRow[oField.Name] = row["TransactionSource"].ToString() + row["ReferenceNo"].ToString();
            //                    break;

            //                case "CounterReference":
            //                    hPaymentHeaderRow[oField.Name] = row["TransactionSource"].ToString() + row["ReferenceNo"].ToString();
            //                    break;

            //                case "Remarks":
            //                    hPaymentHeaderRow[oField.Name] = row["Memo"].ToString();
            //                    break;

            //                case "TaxDate":
            //                    DateTime tmpChequeDate = DateTime.Parse(row["chequeDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
            //                    break;

            //                case "DocTotal":
            //                    hPaymentHeaderRow[oField.Name] = row["netBaseAmount"].ToString();
            //                    break;

            //                case "_":
            //                case "":
            //                    hPaymentHeaderRow[oField.Name] = "";
            //                    break;
            //                default:
            //                    if (oField.Field_In_Folio != "")
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                    }
            //                    break;
            //            }
            //        }
            //    }

            //    dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
            //    //<<end Payment Header
            //}

            //if (dtPaymentsAccount != null)
            //{
            //    //payments - accounts
            //    try
            //    {
            //        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            //        sfdExport.FileName = "Payment-Accounts - " + startDate.ToString("MMMddyyyy");

            //        if (sfdExport.ShowDialog() == DialogResult.OK)
            //        {
            //            string filelocation = sfdExport.FileName;

            //            CreateCSVFile(dtPaymentsAccount, filelocation);

            //            //set posted
            //            oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

            //            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //}
            #endregion

            //>> for Payments - Checks
            #region PAYMENTS - CHEQUES
            DataView dtPaymentChecks = tempPaymentData.DefaultView;
            dtPaymentChecks.RowStateFilter = DataViewRowState.OriginalRows;
            dtPaymentChecks.RowFilter = "trantypeid = 5";
            dtPaymentChecks.Sort = "TransactionDate, TransactionCode, GuestName";

            int idxPaymentCheque = 1;
            foreach (DataRowView row in dtPaymentChecks)
            {
                //>>for Cheque Template
                dtPaymentsCheque = arrTables[paymentChequesIndex];
                DataRow hNewRow = dtPaymentsCheque.NewRow();
                foreach (SAP_Interface.TemplateField oField in tPaymentCheques.Fields)
                {

                    if (oField.StatusFlag == "ACTIVE")
                    {
                        string _fieldName = oField.Name.Trim();
                        switch (_fieldName)
                        {
                            case "RecordKey":
                                hNewRow[oField.Name] = idxPaymentHeader;
                                break;

                            case "LineNum":
                                hNewRow[oField.Name] = "0"; //fixed
                                break;

                            case "AccountNum": //for customer id
                                string custID = row["accountid"].ToString();
                                hNewRow[oField.Name] = custID;
                                break;

                            case "CheckAccount":
                                string glAcct = oTransactionCodeMappingDAO.getSAPGLAccount("2200");
                                hNewRow[oField.Name] = glAcct; //"161016"; //to be dynamic: get from gl accounts
                                break;

                            case "DueDate":
                                DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
                                hNewRow[oField.Name] = temp.ToString("yyyyMMdd");
                                break;

                            case "_":
                            case "":
                                hNewRow[oField.Name] = "";
                                break;
                            default:
                                if (oField.Field_In_Folio != "")
                                {
                                    hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                }
                                break;
                        }
                    }

                }

                dtPaymentsCheque.Rows.Add(hNewRow);
                idxPaymentCheque++;
                //<<end Cheques Template

                //>>for Payment Header
                dtPaymentsHeader = arrTables[paymentHeaderIndex];
                DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
                foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        string _fieldName = oField.Name.Trim();
                        switch (_fieldName)
                        {
                            case "RecordKey":
                                hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
                                break;

                            case "CardCode"://for customerid
                                hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
                                break;

                            case "DocDate":
                                DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
                                hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
                                break;

                            case "Reference2":
                                string refNo = row["ReferenceNo"].ToString();
                                if (refNo.Length > 8)
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
                                }
                                else
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo;
                                }
                                break;

                            case "CounterReference":
                                refNo = row["ReferenceNo"].ToString();
                                if (refNo.Length > 8)
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
                                }
                                else
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo;
                                } break;

                            case "TaxDate":
                                DateTime tmpChequeDate = DateTime.Parse(row["chequeDate"].ToString());
                                hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
                                break;

                            case "_":
                            case "":
                                hPaymentHeaderRow[oField.Name] = "";
                                break;
                            default:
                                if (oField.Field_In_Folio != "")
                                {
                                    hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                }
                                break;
                        }
                    }
                }

                dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
                idxPaymentHeader++;
                //<<end Payment Header
            }

            if (dtPaymentsCheque != null)
            {
                //payments - cheques
                try
                {
                    sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                    sfdExport.FileName = "Payment-Cheques - " + startDate.ToString("MMMddyyyy");

                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {
                        string filelocation = sfdExport.FileName;

                        CreateCSVFile(dtPaymentsCheque, filelocation);

                        //set posted
                        oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

            }
            #endregion

            //>> for Payments - Credit Cards
            #region PAYMENTS - CREDIT CARDS
            DataView dtPaymentCreditCards = tempPaymentData.DefaultView;
            dtPaymentCreditCards.RowStateFilter = DataViewRowState.OriginalRows;
            dtPaymentCreditCards.RowFilter = "trantypeid = 4";
            dtPaymentCreditCards.Sort = "TransactionDate, TransactionCode, GuestName";

            int idxPaymentCredit = 1;
            foreach (DataRowView row in dtPaymentCreditCards)
            {
                dtPaymentsCreditCard = arrTables[paymentCreditIndex];

                DataRow hNewRow = dtPaymentsCreditCard.NewRow();
                foreach (SAP_Interface.TemplateField oField in tPaymentCreditCard.Fields)
                {

                    if (oField.StatusFlag == "ACTIVE")
                    {
                        string _fieldName = oField.Name.Trim();
                        switch (_fieldName)
                        {
                            case "RecordKey":
                                hNewRow[oField.Name] = idxPaymentHeader;
                                break;

                            case "LineNum":
                                hNewRow[oField.Name] = "1"; //fixed
                                break;

                            case "CardValidUntil":
                                DateTime temp = DateTime.Parse(row["creditCardExpiry"].ToString());
                                hNewRow[oField.Name] = temp.ToString("yyyyMMdd");
                                break;

                            case "CreditAcct":
                                string glAccount = oTransactionCodeMappingDAO.getSAPGLAccount("2100");
                                hNewRow[oField.Name] = glAccount; //"140090";//to be checked for gl accounting codes for credit card
                                break;

                            case "CreditCard":
                                hNewRow[oField.Name] = /*row["BankName"].ToString();*/ "1"; //to be check numbering/NAME for credit card types: 1 for mastercard
                                break;

                            case "NumOfPayments":
                                hNewRow[oField.Name] = "1";//static
                                break;

                            case "VoucherNum":
                                string refNo = row["ReferenceNo"].ToString();
                                if (refNo.Length > 8)
                                {
                                    hNewRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
                                }
                                else
                                {
                                    hNewRow[oField.Name] = refNo;
                                }
                                break;

                            case "_":
                            case "":
                                hNewRow[oField.Name] = "";
                                break;
                            default:
                                if (oField.Field_In_Folio != "")
                                {
                                    hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                }
                                break;
                        }
                    }

                }

                dtPaymentsCreditCard.Rows.Add(hNewRow);
                idxPaymentCredit++;

                //>>for Payment Header
                dtPaymentsHeader = arrTables[paymentHeaderIndex];
                DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
                foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        string _fieldName = oField.Name.Trim();
                        switch (_fieldName)
                        {
                            case "RecordKey":
                                hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
                                break;

                            case "CardCode"://for customer id
                                hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
                                break;

                            case "DocDate":
                                DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
                                hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
                                break;

                            case "Reference2":
                                string refNo = row["ReferenceNo"].ToString();
                                if (refNo.Length > 8)
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
                                }
                                else
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo;
                                }
                                break;

                            case "CounterReference":
                                refNo = row["ReferenceNo"].ToString();
                                if (refNo.Length > 8)
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
                                }
                                else
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo;
                                }
                                break;

                            case "TaxDate":
                                DateTime tmpChequeDate = DateTime.Parse(row["chequeDate"].ToString());
                                hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
                                break;

                            case "_":
                            case "":
                                hPaymentHeaderRow[oField.Name] = "";
                                break;
                            default:
                                if (oField.Field_In_Folio != "")
                                {
                                    hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                }
                                break;
                        }
                    }
                }

                dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
                idxPaymentHeader++;
                //<<end Payment Header
            }

            if (dtPaymentsCreditCard != null)
            {
                //payments - credit card
                try
                {
                    sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                    sfdExport.FileName = "Payment-Credit Card - " + startDate.ToString("MMMddyyyy");

                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {
                        string filelocation = sfdExport.FileName;

                        CreateCSVFile(dtPaymentsCreditCard, filelocation);

                        //set posted
                        oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

            }
            #endregion

            //>> for Payments - Cash
            #region PAYMENTS - CASH
            DataView dtPaymentCash = tempPaymentData.DefaultView;
            dtPaymentCash.RowStateFilter = DataViewRowState.OriginalRows;
            dtPaymentCash.RowFilter = "trantypeid = 3";
            dtPaymentCash.Sort = "TransactionDate, TransactionCode, GuestName";

            int idxPaymentCash = 1;
            foreach (DataRowView row in dtPaymentCash)
            {
                //>>for Payment Header
                dtPaymentsHeader = arrTables[paymentHeaderIndex];
                DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
                foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        string _fieldName = oField.Name.Trim();
                        switch (_fieldName)
                        {
                            case "RecordKey":
                                hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
                                break;

                            case "CardCode"://for customer id
                                hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
                                break;

                            case "CashSum":
                                hPaymentHeaderRow[oField.Name] = row["netBaseAmount"].ToString();
                                break;

                            case "DocDate":
                                DateTime temp = DateTime.Parse(row["transactionDate"].ToString());
                                hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
                                break;

                            case "Reference2":
                                string refNo = row["ReferenceNo"].ToString();
                                if (refNo.Length > 8)
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
                                }
                                else
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo;
                                }
                                break;

                            case "CounterReference":
                                refNo = row["ReferenceNo"].ToString();
                                if (refNo.Length > 8)
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
                                }
                                else
                                {
                                    hPaymentHeaderRow[oField.Name] = refNo;
                                }
                                break;

                            case "TaxDate":
                                DateTime tmpChequeDate = DateTime.Parse(row["transactionDate"].ToString());
                                hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
                                break;

                            case "_":
                            case "":
                                hPaymentHeaderRow[oField.Name] = "";
                                break;
                            default:
                                if (oField.Field_In_Folio != "")
                                {
                                    hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                }
                                break;
                        }
                    }
                }

                dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
                idxPaymentHeader++;
                //<<end Payment Header
            }

            if (dtPaymentsCash != null)
            {
                //payments - cash
                try
                {
                    sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                    sfdExport.FileName = "Payment-Cash - " + startDate.ToString("MMMddyyyy");

                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {
                        string filelocation = sfdExport.FileName;

                        CreateCSVFile(dtPaymentsCash, filelocation);

                        //set posted
                        oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

            }
            #endregion

            //>>for Payment Header
            if (dtPaymentsHeader != null)
            {
                //payments - header
                try
                {
                    sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                    sfdExport.FileName = "Payment_Header - " + startDate.ToString("MMMddyyyy");

                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {
                        string filelocation = sfdExport.FileName;

                        CreateCSVFile(dtPaymentsHeader, filelocation);

                        //set posted
                        oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }
            //<<end Payment header
            #endregion

            #region "INVENTORY"

            if (bool.Parse(ConfigVariables.gRestoConnected) == true)
            {
                DataTable tempInventoryData = oTransactionCodeMappingDAO.getRestoDataHeaderForSAP(startDate, endDate);

                DataTable dtInventoryHeader = null;
                DataTable dtInventoryDetail = null;

                int idxInventoryheader = 1;

                foreach (DataRow row in tempInventoryData.Rows)
                {
                    int idxInventoryDetail = 0;
                    dtInventoryHeader = arrTables[invoiceHeaderInventoryIndex];

                    DataRow hNewRow = dtInventoryHeader.NewRow();
                    foreach (SAP_Interface.TemplateField oField in tInvoiceHeaderInventory.Fields)
                    {

                        if (oField.StatusFlag == "ACTIVE")
                        {
                            DateTime dtTemp = DateTime.Parse(row["order_date"].ToString());
                            string _fieldName = oField.Name.Trim();
                            switch (_fieldName)
                            {
                                case "RecordKey":
                                    hNewRow[oField.Name] = idxInventoryheader;
                                    break;

                                case "CardCode"://for customer id
                                    hNewRow[oField.Name] = row["customerID"].ToString();
                                    break;

                                case "Comments":
                                    hNewRow[oField.Name] = row["comments"].ToString();
                                    break;

                                case "DocDate":
                                    hNewRow[oField.Name] = dtTemp.ToString("yyyyMMdd");
                                    break;

                                case "DocDueDate":
                                    hNewRow[oField.Name] = dtTemp.ToString("yyyyMMdd");
                                    break;

                                case "DocType":
                                    hNewRow[oField.Name] = "dDocument_Items";
                                    break;

                                case "SalesPersonCode":
                                    hNewRow[oField.Name] = "2";
                                    break;

                                case "TaxDate":
                                    hNewRow[oField.Name] = dtTemp.ToString("yyyyMMdd");
                                    break;

                                case "NumAtCard":
                                    hNewRow[oField.Name] = row["order_id"].ToString();
                                    break;

                                case "_":
                                case "":
                                    hNewRow[oField.Name] = "";
                                    break;
                                default:
                                    if (oField.Field_In_Folio != "")
                                    {
                                        hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
                                    }
                                    break;
                            }
                        }

                    }

                    //>>for Inventory Detail
                    DataTable tempInventoryDetail = oTransactionCodeMappingDAO.getRestoDataDetailsForSAP(row["Order_ID"].ToString());

                    foreach (DataRow _rowDetail in tempInventoryDetail.Rows)
                    {
                        dtInventoryDetail = arrTables[invoiceDetailInventoryIndex];

                        DataRow hNewRowDetail = dtInventoryDetail.NewRow();
                        foreach (SAP_Interface.TemplateField oFieldDetail in tInvoiceDetailInventory.Fields)
                        {
                            if (oFieldDetail.StatusFlag == "ACTIVE")
                            {
                                string _fieldName = oFieldDetail.Name.Trim();
                                switch (_fieldName)
                                {
                                    case "RecordKey":
                                        hNewRowDetail[oFieldDetail.Name] = idxInventoryheader;
                                        break;

                                    case "LineNum":
                                        hNewRowDetail[oFieldDetail.Name] = idxInventoryDetail;
                                        break;

                                    case "CostingCode":
                                        hNewRowDetail[oFieldDetail.Name] = "FOODBEV";
                                        break;

                                    case "ItemCode":
                                        hNewRowDetail[oFieldDetail.Name] = _rowDetail["item_id"].ToString();
                                        break;

                                    case "ItemDescription":
                                        hNewRowDetail[oFieldDetail.Name] = _rowDetail["Description"].ToString();
                                        break;

                                    case "LineTotal":
                                        hNewRowDetail[oFieldDetail.Name] = _rowDetail["amount"].ToString();
                                        break;

                                    case "Quantity":
                                        hNewRowDetail[oFieldDetail.Name] = _rowDetail["quantity"].ToString();
                                        break;

                                    case "SalesPersonCode":
                                        hNewRowDetail[oFieldDetail.Name] = "2";
                                        break;

                                    case "WarehouseCode":
                                        hNewRowDetail[oFieldDetail.Name] = "2";
                                        break;

                                    case "_":
                                    case "":
                                        hNewRowDetail[oFieldDetail.Name] = "";
                                        break;
                                    default:
                                        if (oFieldDetail.Field_In_Folio != "")
                                        {
                                            hNewRowDetail[oFieldDetail.Name] = row[oFieldDetail.Field_In_Folio].ToString();
                                        }
                                        break;
                                }
                            }
                        }
                        idxInventoryDetail++;
                        dtInventoryDetail.Rows.Add(hNewRowDetail);
                    }//<<end inventory detail

                    idxInventoryheader++;
                    dtInventoryHeader.Rows.Add(hNewRow);
                }//>>end inventory header

                if (dtInventoryHeader != null)
                {
                    try
                    {
                        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                        sfdExport.FileName = "Invoice Header Item - " + startDate.ToString("MMMddyyyy");

                        if (sfdExport.ShowDialog() == DialogResult.OK)
                        {
                            string filelocation = sfdExport.FileName;

                            CreateCSVFile(dtInventoryHeader, filelocation);

                            //set posted [set posted below]
                            //oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

                            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }
                }
                else
                {
                    MessageBox.Show("Transaction failed.\r\nEither all transactions for the selected date have been posted or zero transactions.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtInventoryDetail != null)
                {
                    //invoice detail - room
                    try
                    {
                        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
                        sfdExport.FileName = "Invoice Detail Item - " + startDate.ToString("MMMddyyyy");

                        if (sfdExport.ShowDialog() == DialogResult.OK)
                        {
                            string filelocation = sfdExport.FileName;

                            CreateCSVFile(dtInventoryDetail, filelocation);


                            //set posted
                            oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);


                            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }

                }
            }

            #endregion
        }

        private void exportSAPCustomers()
        {

            //>> Setup Table
            Template[] arrTemplates = Template.getAllTemplates();

            DataTable tblCustomer = new DataTable();
            DataTable tblCustomerAddress = new DataTable();


            //create first 2 rows
            Template cTemplate = null;
            Template aTemplate = null;


            foreach (Template oTemplate in arrTemplates)
            {
                switch (oTemplate.ID)
                {
                    case 5: //customers
                        cTemplate = oTemplate;

                        foreach (SAP_Interface.TemplateField oField in oTemplate.Fields)
                        {
                            DataColumn col = new DataColumn(oField.Name, typeof(string));
                            tblCustomer.Columns.Add(col);
                        }
                        break;
                    case 6: //customer address
                        aTemplate = oTemplate;

                        foreach (SAP_Interface.TemplateField oField in oTemplate.Fields)
                        {
                            DataColumn col = new DataColumn(oField.Name, typeof(string));

                            tblCustomerAddress.Columns.Add(col);

                        }
                        break;
                }//end switch
            }//end foreach


            //customer
            DataRow row = tblCustomer.NewRow();
            DataRow row2 = tblCustomer.NewRow();
            foreach (SAP_Interface.TemplateField oField in cTemplate.Fields)
            {
                row[oField.Name] = oField.Name;
                row2[oField.Name] = oField.Description;
            }
            tblCustomer.Rows.Add(row);
            tblCustomer.Rows.Add(row2);
            tblCustomer.AcceptChanges();


            //customer address
            row = tblCustomerAddress.NewRow();
            row2 = tblCustomerAddress.NewRow();
            foreach (SAP_Interface.TemplateField oField in aTemplate.Fields)
            {
                row[oField.Name] = oField.Name;
                row2[oField.Name] = oField.Description;
            }
            tblCustomerAddress.Rows.Add(row);
            tblCustomerAddress.Rows.Add(row2);
            tblCustomerAddress.AcceptChanges();



            //fill data here
            DateTime currentAuditDate = DateTime.Parse(GlobalVariables.gAuditDate);
            DateTime pExportDate = this.dtpDateToBePosted.Value;

            //get customer data from table "guests"
            TransactionCodeMappingDAO oTransactionCodeMappingDAO = new TransactionCodeMappingDAO(GlobalVariables.gPersistentConnection);
            DataTable tblGuests = oTransactionCodeMappingDAO.getSAPNewGuests(pExportDate);


            int ctr = 1;
            foreach (DataRow guestRow in tblGuests.Rows)
            {
                DataRow cRow = tblCustomer.NewRow();
                DataRow aRow = tblCustomerAddress.NewRow();

                foreach (SAP_Interface.TemplateField oField in cTemplate.Fields)
                {
                    switch (oField.Name)
                    {
                        case "RecordKey":
                            cRow[oField.Name] = ctr;
                            break;
                        case "CardType":
                            cRow[oField.Name] = "cCustomer";
                            break;

                        case "_":
                        case "":
                            cRow[oField.Name] = "";
                            break;

                        default:
                            if (oField.Field_In_Folio != "")
                            {
                                cRow[oField.Name] = guestRow[oField.Field_In_Folio].ToString();
                            }
                            break;
                    }

                }

                foreach (SAP_Interface.TemplateField oField in aTemplate.Fields)
                {
                    switch (oField.Name)
                    {
                        case "RecordKey":
                            aRow[oField.Name] = ctr;
                            break;
                        case "LineNum":
                            aRow[oField.Name] = 0;
                            break;
                        case "AddressName":
                            aRow[oField.Name] = "Work";
                            break;
                        default:
                            //aRow[oField.Name] = guestRow[oField.Field_In_Folio].ToString();
                            break;
                    }

                }

                tblCustomer.Rows.Add(cRow);
                tblCustomer.AcceptChanges();
                tblCustomerAddress.Rows.Add(aRow);
                tblCustomerAddress.AcceptChanges();

                ctr++;
            }


            //customer
            sfdExport.Filter = "Text Files (*.txt)|*.TXT";
            sfdExport.FileName = "Customers - " + pExportDate.ToString("MMMddyyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {

                    CreateCSVFile(tblCustomer, sfdExport.FileName);

                    MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //customer address
            sfdExport.Filter = "Text Files (*.txt)|*.TXT";
            sfdExport.FileName = "Customer Address - " + pExportDate.ToString("MMMddyyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {

                    CreateCSVFile(tblCustomerAddress, sfdExport.FileName);

                    MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }
        #endregion

        #region "PEACHTREE"
        private void exportClients(string option)
        {
            //>> Setup Table
            PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
            DataTable tblClients = new DataTable();

            //create first row (Column Header)
            PTemplate cTemplate = null;
            string strValue = "";

            foreach (PTemplate oPTemplate in arrTemplates)
            {
                if (oPTemplate.Generate)
                {
                    if (oPTemplate.Name.ToLower().Contains("customer"))
                    {
                        cTemplate = oPTemplate;

                        foreach (PTemplateField oField in oPTemplate.Fields)
                        {
                            if (oField.StatusFlag == "ACTIVE")
                            {
                                DataColumn col = new DataColumn(oField.Name, typeof(string));
                                tblClients.Columns.Add(col);
                            }
                        }
                    }
                }
            }

            DataRow row = tblClients.NewRow();

            foreach (PTemplateField oField in cTemplate.Fields)
            {
                if (oField.StatusFlag == "ACTIVE")
                {
                    row[oField.Name] = oField.Name;
                }
            }
            tblClients.Rows.Add(row);
            tblClients.AcceptChanges();
            //end (Column Header)

            //fill data (Fill Rows with Customer Info)
            DateTime currentAuditDate = DateTime.Parse(GlobalVariables.gAuditDate);
            DateTime pExportDate = this.dtpDateToBePosted.Value;

            PTransactionCodeMapping oTransactionCodeMappingDAO = new PTransactionCodeMapping();
            DataTable tblClientsInfo = oTransactionCodeMappingDAO.getPeachtreeNewClients(pExportDate, option);


            foreach (DataRow infoRow in tblClientsInfo.Rows)
            {
                DataRow cRow = tblClients.NewRow();

                foreach (Peachtree_Interface.PTemplateField oField in cTemplate.Fields)
                {
                    strValue = "";
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        switch (oField.Name)
                        {
                            case "Customer ID":
                                cRow[oField.Name] = infoRow["accountid"];
                                break;
                            case "Customer Name":
                                cRow[oField.Name] = infoRow["lastname"].ToString().Trim().Replace(',', ' ') + "  " + infoRow["firstname"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "Bill to Contact Last Name":
                                cRow[oField.Name] = infoRow["lastname"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "Bill to Address-Line One":
                                cRow[oField.Name] = infoRow["street"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "Bill to City":
                                cRow[oField.Name] = infoRow["city"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "Bill to Zip":
                                cRow[oField.Name] = infoRow["zip"];
                                break;
                            case "Bill to Country":
                                cRow[oField.Name] = infoRow["country"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "Telephone 1":
                                cRow[oField.Name] = infoRow["TelephoneNo"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "Telephone 2":
                                cRow[oField.Name] = infoRow["MobileNo"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "Fax Number":
                                cRow[oField.Name] = infoRow["FaxNo"].ToString().Trim().Replace(',', ' ');
                                break;
                            case "G/L Sales Account":
                                cRow[oField.Name] = infoRow["GLAccount"];
                                break;
                            case "Charge Finance Charges":
                                break;
                            case "Use Receipt Settings":
                                cRow[oField.Name] = "TRUE";
                                break;
                            case "Customer Since Date":
                                cRow[oField.Name] = DateTime.Parse(infoRow["createtime"].ToString()).ToString("MM/dd/yyyy");
                                break;
                        }
                    }

                }
                tblClients.Rows.Add(cRow);
                tblClients.AcceptChanges();
            }


            //Export to Excel (.csv) file
            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = option + " " + pExportDate.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(tblClients, sfdExport.FileName);
                    MessageBox.Show(option + " exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportChart()
        {
            //>> Setup Table
            PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
            DataTable tblChart = new DataTable();

            //create first row (Column Header)
            PTemplate cTemplate = null;

            foreach (PTemplate oPTemplate in arrTemplates)
            {
                switch (oPTemplate.ID)
                {
                    case 2:
                        cTemplate = oPTemplate;

                        foreach (PTemplateField oField in oPTemplate.Fields)
                        {
                            DataColumn col = new DataColumn(oField.Name, typeof(string));
                            tblChart.Columns.Add(col);
                        }
                        break;
                }
            }

            DataRow row = tblChart.NewRow();

            foreach (PTemplateField oField in cTemplate.Fields)
            {
                row[oField.Name] = oField.Name;
            }
            tblChart.Rows.Add(row);
            tblChart.AcceptChanges();
            //end (Column Header)

            //fill data (Fill Rows with GL Accounts)

            //Export to Excel (.csv) file
            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Chart of Accounts";
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(tblChart, sfdExport.FileName);
                    MessageBox.Show("Chart of Accounts exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportTransactions()
        {
            if (this.chkIncludePostedTrans.Checked)
            {
                //string _priv = "Export POSTED transactions to SAP";

                //VerifyUserUI oVerifyUserUI = new VerifyUserUI(_priv);
                //if (!oVerifyUserUI.showDialog())
                //{
                //    // exit if not authorized
                //    return;
                //}
            }

            PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
            DataTable[] arrTables = new DataTable[arrTemplates.Length];

            //>> create DataTable for export
            int c = 0;
            foreach (PTemplate oTemplate in arrTemplates)
            {
                arrTables[c] = new DataTable();

                foreach (PTemplateField oField in oTemplate.Fields)
                {
                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                    arrTables[c].Columns.Add(col);
                }
                c++;
            }

            //fill 1st row with the Column Headers
            c = 0;
            foreach (PTemplate oTemplate in arrTemplates)
            {
                DataRow row = arrTables[c].NewRow();
                foreach (PTemplateField oField in oTemplate.Fields)
                {
                    row[oField.Name] = oField.Name;
                }
                arrTables[c].Rows.Add(row);
                arrTables[c].AcceptChanges();
                c++;
            }

            //create Template Entries
            PTemplate tSalesTransactions = null;
            int salesTransactionsIndex = 0;

            PTemplate tReceiptTransactions = null;
            int receiptTransactionsIndex = 0;

            c = 0;
            foreach (PTemplate oTemplate in arrTemplates)
            {
                switch (oTemplate.Name)
                {
                    case "SALES TRANSACTIONS":
                        tSalesTransactions = oTemplate;
                        salesTransactionsIndex = c;
                        break;

                    case "RECEIPT TRANSACTIONS":
                        tReceiptTransactions = oTemplate;
                        receiptTransactionsIndex = c;
                        break;
                }
                c++;
            }

            TransactionCodeMappingDAO oTransactionCodeMappingDAO = new TransactionCodeMappingDAO(GlobalVariables.gPersistentConnection);
            DateTime startDate = this.dtpDateToBePosted.Value;
            DateTime endDate = startDate;

            bool includePostedTrans = this.chkIncludePostedTrans.Checked;

            #region "Sales Transactions"
            //>>for Hotel Revenues
            DataTable tempData = oTransactionCodeMappingDAO.getUnpostedDailyHotelRevenueForPeachtree(startDate, endDate, includePostedTrans);
            DataView dtView = tempData.DefaultView;
            dtView.Sort = "TransactionDate, FolioID";

            // <-start
            //string[] fId = new string[dtView.Count];
            //int[] fIdx = new int[dtView.Count];
            //string tempFolio = "";

            //int ctr1 = 0;
            //int ctr2 = 1;

            //fId[ctr1] = dtView[0].ToString();
            //foreach (DataRowView dRow in dtView)
            //{
            //    tempFolio = dRow["FolioID"].ToString();
            //    if (fId[ctr1] != tempFolio)
            //    {
            //        ctr1++;
            //        fId[ctr1] = tempFolio;
            //        fIdx[ctr1] = ctr2;
            //        ctr2 = 1;
            //    }
            //    else
            //    {                    
            //        ctr2++;
            //    }
            //} 
            // <-end

            DataTable dtSalesTransactions = null;

            string strValue = "";
            foreach (DataRowView row in dtView)
            {
                string _tranCode = row["transactionCode"].ToString();
                ArrayList tblTranCodeMapping = Folio_GLAccountMapping.getTransactionCodeMapping(_tranCode, GlobalVariables.gPersistentConnection);
                //for Sales Transactions
                if (tblTranCodeMapping.Count > 0)
                {
                    foreach (Folio_GLAccountMapping oMap in tblTranCodeMapping)
                    {
                        dtSalesTransactions = arrTables[salesTransactionsIndex];

                        DataRow hNewRow = dtSalesTransactions.NewRow();
                        foreach (PTemplateField oField in tSalesTransactions.Fields)
                        {
                            strValue = "";
                            if (oField.StatusFlag == "ACTIVE")
                            {
                                string _fieldName = oField.Name.Trim();
                                switch (_fieldName)
                                {
                                    case "Credit Memo":
                                    case "Quote":
                                    case "Drop Ship":
                                    case "Note Prints After Line Items":
                                    case "Stmt Note Prints Before Ref":
                                    case "Beginning Balance Transaction":
                                    case "Apply To Sales Order":
                                        hNewRow[oField.Name] = "FALSE";
                                        break;

                                    case "Apply to Invoice Distribution":
                                    case "SO/Proposal Distribution":
                                    case "Weight":
                                    case "Recur Number":
                                    case "Recur Frequency":
                                        hNewRow[oField.Name] = "0";
                                        break;

                                    case "Ship Via":
                                        hNewRow[oField.Name] = "None";
                                        break;

                                    case "Date":
                                        strValue = DateTime.Parse(row[oField.Field_In_Folio].ToString()).ToString("MM/dd/yyyy");
                                        hNewRow[oField.Name] = strValue;
                                        break;

                                    case "Accounts Receivable Account":
                                        hNewRow[oField.Name] = "11000-00";
                                        break;

                                    case "Amount":
                                        hNewRow[oField.Name] = row[oMap.AmountColumnInFolioTrans].ToString();
                                        break;

                                    default:
                                        if (oField.Field_In_Folio != "")
                                        {
                                            strValue = row[oField.Field_In_Folio].ToString();
                                            strValue = strValue.Replace(',', ' ');
                                            hNewRow[oField.Name] = strValue;
                                        }
                                        break;
                                }
                            }
                        }
                        dtSalesTransactions.Rows.Add(hNewRow);
                    }//end inner foreach
                }//end foreach
            }

            if (dtSalesTransactions != null)
            {
                try
                {
                    sfdExport.Filter = "Comma Separated (*.csv)|*.CSV";
                    sfdExport.FileName = "Sales Transactions - " + startDate.ToString("MMMddyyyy");

                    if (sfdExport.ShowDialog() == DialogResult.OK)
                    {
                        string filelocation = sfdExport.FileName;
                        CreateCSVFile2(dtSalesTransactions, filelocation);
                        //set posted
                        oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);
                        MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //<<end of Hotel Revenues
            #endregion

            #region "HOTEL PAYMENTS"
            ////>>for Hotel Payments
            //DataTable tempPaymentData = oTransactionCodeMappingDAO.getUnpostedDailyHotelPaymentsForSAP(startDate, endDate, includePostedTrans);

            //DataTable dtPaymentsHeader = null;
            //DataTable dtPaymentsAccount = null;
            //DataTable dtPaymentsCreditCard = null;
            //DataTable dtPaymentsCheque = null;
            //DataTable dtPaymentsCash = null;
            //DataTable dtPaymentsInvoices = null;

            //int idxPaymentHeader = 1;

            ////>> for Payments - Accounts
            //#region PAYMENTS - ACCOUNTS
            ////DataView dtPaymentAccountView = tempPaymentData.DefaultView;
            ////dtPaymentAccountView.RowStateFilter = DataViewRowState.OriginalRows;
            ////dtPaymentAccountView.RowFilter = "trantypeid = 9";
            ////dtPaymentAccountView.Sort = "TransactionDate, TransactionCode, GuestName";

            ////int idxPaymentAcct = 1;
            ////foreach (DataRowView row in dtPaymentAccountView)
            ////{
            ////    dtPaymentsAccount = arrTables[paymentAccountsIndex];

            ////    DataRow hNewRow = dtPaymentsAccount.NewRow();
            ////    foreach (SAP_Interface.TemplateField oField in tPaymentAccounts.Fields)
            ////    {

            ////        if (oField.StatusFlag == "ACTIVE")
            ////        {
            ////            string _fieldName = oField.Name.Trim();
            ////            switch (_fieldName)
            ////            {
            ////                case "RecordKey":
            ////                    hNewRow[oField.Name] = idxPaymentHeader;
            ////                    break;

            ////                case "LineNum":
            ////                    hNewRow[oField.Name] = "1"; //fixed
            ////                    break;

            ////                case "AccountCode":
            ////                    hNewRow[oField.Name] = row["accountid"].ToString();
            ////                    break;
            ////                case "Description":
            ////                    hNewRow[oField.Name] = row["memo"].ToString();
            ////                    break;

            ////                case "SumPaid":
            ////                    hNewRow[oField.Name] = row["netbaseamount"].ToString();
            ////                    break;

            ////                case "_":
            ////                case "":
            ////                    hNewRow[oField.Name] = "";
            ////                    break;
            ////                default:
            ////                    if (oField.Field_In_Folio != "")
            ////                    {
            ////                        hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            ////                    }
            ////                    break;
            ////            }
            ////        }

            ////    }

            ////    dtPaymentsAccount.Rows.Add(hNewRow);
            ////    idxPaymentAcct++;

            ////    //>>for Payment Header
            ////    dtPaymentsHeader = arrTables[paymentHeaderIndex];
            ////    DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
            ////    foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
            ////    {
            ////        if (oField.StatusFlag == "ACTIVE")
            ////        {
            ////            string _fieldName = oField.Name.Trim();
            ////            switch (_fieldName)
            ////            {
            ////                case "RecordKey":
            ////                    hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
            ////                    break;

            ////                case "CardCode":
            ////                    hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
            ////                    break;

            ////                case "DocDate":
            ////                    DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
            ////                    hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
            ////                    break;

            ////                case "DocNum":
            ////                    hPaymentHeaderRow[oField.Name] = "";
            ////                    break;

            ////                case "Reference2":
            ////                    hPaymentHeaderRow[oField.Name] = row["TransactionSource"].ToString() + row["ReferenceNo"].ToString();
            ////                    break;

            ////                case "CounterReference":
            ////                    hPaymentHeaderRow[oField.Name] = row["TransactionSource"].ToString() + row["ReferenceNo"].ToString();
            ////                    break;

            ////                case "Remarks":
            ////                    hPaymentHeaderRow[oField.Name] = row["Memo"].ToString();
            ////                    break;

            ////                case "TaxDate":
            ////                    DateTime tmpChequeDate = DateTime.Parse(row["chequeDate"].ToString());
            ////                    hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
            ////                    break;

            ////                case "DocTotal":
            ////                    hPaymentHeaderRow[oField.Name] = row["netBaseAmount"].ToString();
            ////                    break;

            ////                case "_":
            ////                case "":
            ////                    hPaymentHeaderRow[oField.Name] = "";
            ////                    break;
            ////                default:
            ////                    if (oField.Field_In_Folio != "")
            ////                    {
            ////                        hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            ////                    }
            ////                    break;
            ////            }
            ////        }
            ////    }

            ////    dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
            ////    //<<end Payment Header
            ////}

            ////if (dtPaymentsAccount != null)
            ////{
            ////    //payments - accounts
            ////    try
            ////    {
            ////        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            ////        sfdExport.FileName = "Payment-Accounts - " + startDate.ToString("MMMddyyyy");

            ////        if (sfdExport.ShowDialog() == DialogResult.OK)
            ////        {
            ////            string filelocation = sfdExport.FileName;

            ////            CreateCSVFile(dtPaymentsAccount, filelocation);

            ////            //set posted
            ////            oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

            ////            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////            this.Close();
            ////        }
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////        return;
            ////    }

            ////}
            //#endregion

            ////>> for Payments - Checks
            //#region PAYMENTS - CHEQUES
            //DataView dtPaymentChecks = tempPaymentData.DefaultView;
            //dtPaymentChecks.RowStateFilter = DataViewRowState.OriginalRows;
            //dtPaymentChecks.RowFilter = "trantypeid = 5";
            //dtPaymentChecks.Sort = "TransactionDate, TransactionCode, GuestName";

            //int idxPaymentCheque = 1;
            //foreach (DataRowView row in dtPaymentChecks)
            //{
            //    //>>for Cheque Template
            //    dtPaymentsCheque = arrTables[paymentChequesIndex];
            //    DataRow hNewRow = dtPaymentsCheque.NewRow();
            //    foreach (SAP_Interface.TemplateField oField in tPaymentCheques.Fields)
            //    {

            //        if (oField.StatusFlag == "ACTIVE")
            //        {
            //            string _fieldName = oField.Name.Trim();
            //            switch (_fieldName)
            //            {
            //                case "RecordKey":
            //                    hNewRow[oField.Name] = idxPaymentHeader;
            //                    break;

            //                case "LineNum":
            //                    hNewRow[oField.Name] = "0"; //fixed
            //                    break;

            //                case "AccountNum": //for customer id
            //                    string custID = row["accountid"].ToString();
            //                    hNewRow[oField.Name] = custID;
            //                    break;

            //                case "CheckAccount":
            //                    string glAcct = oTransactionCodeMappingDAO.getSAPGLAccount("2200");
            //                    hNewRow[oField.Name] = glAcct; //"161016"; //to be dynamic: get from gl accounts
            //                    break;

            //                case "DueDate":
            //                    DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
            //                    hNewRow[oField.Name] = temp.ToString("yyyyMMdd");
            //                    break;

            //                case "_":
            //                case "":
            //                    hNewRow[oField.Name] = "";
            //                    break;
            //                default:
            //                    if (oField.Field_In_Folio != "")
            //                    {
            //                        hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                    }
            //                    break;
            //            }
            //        }

            //    }

            //    dtPaymentsCheque.Rows.Add(hNewRow);
            //    idxPaymentCheque++;
            //    //<<end Cheques Template

            //    //>>for Payment Header
            //    dtPaymentsHeader = arrTables[paymentHeaderIndex];
            //    DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
            //    foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
            //    {
            //        if (oField.StatusFlag == "ACTIVE")
            //        {
            //            string _fieldName = oField.Name.Trim();
            //            switch (_fieldName)
            //            {
            //                case "RecordKey":
            //                    hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
            //                    break;

            //                case "CardCode"://for customerid
            //                    hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
            //                    break;

            //                case "DocDate":
            //                    DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
            //                    break;

            //                case "Reference2":
            //                    string refNo = row["ReferenceNo"].ToString();
            //                    if (refNo.Length > 8)
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
            //                    }
            //                    else
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo;
            //                    }
            //                    break;

            //                case "CounterReference":
            //                    refNo = row["ReferenceNo"].ToString();
            //                    if (refNo.Length > 8)
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
            //                    }
            //                    else
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo;
            //                    } break;

            //                case "TaxDate":
            //                    DateTime tmpChequeDate = DateTime.Parse(row["chequeDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
            //                    break;

            //                case "_":
            //                case "":
            //                    hPaymentHeaderRow[oField.Name] = "";
            //                    break;
            //                default:
            //                    if (oField.Field_In_Folio != "")
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                    }
            //                    break;
            //            }
            //        }
            //    }

            //    dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
            //    idxPaymentHeader++;
            //    //<<end Payment Header
            //}

            //if (dtPaymentsCheque != null)
            //{
            //    //payments - cheques
            //    try
            //    {
            //        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            //        sfdExport.FileName = "Payment-Cheques - " + startDate.ToString("MMMddyyyy");

            //        if (sfdExport.ShowDialog() == DialogResult.OK)
            //        {
            //            string filelocation = sfdExport.FileName;

            //            CreateCSVFile(dtPaymentsCheque, filelocation);

            //            //set posted
            //            oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

            //            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //return;
            //    }

            //}
            //#endregion

            ////>> for Payments - Credit Cards
            //#region PAYMENTS - CREDIT CARDS
            //DataView dtPaymentCreditCards = tempPaymentData.DefaultView;
            //dtPaymentCreditCards.RowStateFilter = DataViewRowState.OriginalRows;
            //dtPaymentCreditCards.RowFilter = "trantypeid = 4";
            //dtPaymentCreditCards.Sort = "TransactionDate, TransactionCode, GuestName";

            //int idxPaymentCredit = 1;
            //foreach (DataRowView row in dtPaymentCreditCards)
            //{
            //    dtPaymentsCreditCard = arrTables[paymentCreditIndex];

            //    DataRow hNewRow = dtPaymentsCreditCard.NewRow();
            //    foreach (SAP_Interface.TemplateField oField in tPaymentCreditCard.Fields)
            //    {

            //        if (oField.StatusFlag == "ACTIVE")
            //        {
            //            string _fieldName = oField.Name.Trim();
            //            switch (_fieldName)
            //            {
            //                case "RecordKey":
            //                    hNewRow[oField.Name] = idxPaymentHeader;
            //                    break;

            //                case "LineNum":
            //                    hNewRow[oField.Name] = "1"; //fixed
            //                    break;

            //                case "CardValidUntil":
            //                    DateTime temp = DateTime.Parse(row["creditCardExpiry"].ToString());
            //                    hNewRow[oField.Name] = temp.ToString("yyyyMMdd");
            //                    break;

            //                case "CreditAcct":
            //                    string glAccount = oTransactionCodeMappingDAO.getSAPGLAccount("2100");
            //                    hNewRow[oField.Name] = glAccount; //"140090";//to be checked for gl accounting codes for credit card
            //                    break;

            //                case "CreditCard":
            //                    hNewRow[oField.Name] = /*row["BankName"].ToString();*/ "1"; //to be check numbering/NAME for credit card types: 1 for mastercard
            //                    break;

            //                case "NumOfPayments":
            //                    hNewRow[oField.Name] = "1";//static
            //                    break;

            //                case "VoucherNum":
            //                    string refNo = row["ReferenceNo"].ToString();
            //                    if (refNo.Length > 8)
            //                    {
            //                        hNewRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
            //                    }
            //                    else
            //                    {
            //                        hNewRow[oField.Name] = refNo;
            //                    }
            //                    break;

            //                case "_":
            //                case "":
            //                    hNewRow[oField.Name] = "";
            //                    break;
            //                default:
            //                    if (oField.Field_In_Folio != "")
            //                    {
            //                        hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                    }
            //                    break;
            //            }
            //        }

            //    }

            //    dtPaymentsCreditCard.Rows.Add(hNewRow);
            //    idxPaymentCredit++;

            //    //>>for Payment Header
            //    dtPaymentsHeader = arrTables[paymentHeaderIndex];
            //    DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
            //    foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
            //    {
            //        if (oField.StatusFlag == "ACTIVE")
            //        {
            //            string _fieldName = oField.Name.Trim();
            //            switch (_fieldName)
            //            {
            //                case "RecordKey":
            //                    hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
            //                    break;

            //                case "CardCode"://for customer id
            //                    hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
            //                    break;

            //                case "DocDate":
            //                    DateTime temp = DateTime.Parse(row["chequeDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
            //                    break;

            //                case "Reference2":
            //                    string refNo = row["ReferenceNo"].ToString();
            //                    if (refNo.Length > 8)
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
            //                    }
            //                    else
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo;
            //                    }
            //                    break;

            //                case "CounterReference":
            //                    refNo = row["ReferenceNo"].ToString();
            //                    if (refNo.Length > 8)
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
            //                    }
            //                    else
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo;
            //                    }
            //                    break;

            //                case "TaxDate":
            //                    DateTime tmpChequeDate = DateTime.Parse(row["chequeDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
            //                    break;

            //                case "_":
            //                case "":
            //                    hPaymentHeaderRow[oField.Name] = "";
            //                    break;
            //                default:
            //                    if (oField.Field_In_Folio != "")
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                    }
            //                    break;
            //            }
            //        }
            //    }

            //    dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
            //    idxPaymentHeader++;
            //    //<<end Payment Header
            //}

            //if (dtPaymentsCreditCard != null)
            //{
            //    //payments - credit card
            //    try
            //    {
            //        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            //        sfdExport.FileName = "Payment-Credit Card - " + startDate.ToString("MMMddyyyy");

            //        if (sfdExport.ShowDialog() == DialogResult.OK)
            //        {
            //            string filelocation = sfdExport.FileName;

            //            CreateCSVFile(dtPaymentsCreditCard, filelocation);

            //            //set posted
            //            oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

            //            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //return;
            //    }

            //}
            //#endregion

            ////>> for Payments - Cash
            //#region PAYMENTS - CASH
            //DataView dtPaymentCash = tempPaymentData.DefaultView;
            //dtPaymentCash.RowStateFilter = DataViewRowState.OriginalRows;
            //dtPaymentCash.RowFilter = "trantypeid = 3";
            //dtPaymentCash.Sort = "TransactionDate, TransactionCode, GuestName";

            //int idxPaymentCash = 1;
            //foreach (DataRowView row in dtPaymentCash)
            //{
            //    //>>for Payment Header
            //    dtPaymentsHeader = arrTables[paymentHeaderIndex];
            //    DataRow hPaymentHeaderRow = dtPaymentsHeader.NewRow();
            //    foreach (SAP_Interface.TemplateField oField in tPaymentHeader.Fields)
            //    {
            //        if (oField.StatusFlag == "ACTIVE")
            //        {
            //            string _fieldName = oField.Name.Trim();
            //            switch (_fieldName)
            //            {
            //                case "RecordKey":
            //                    hPaymentHeaderRow[oField.Name] = idxPaymentHeader;
            //                    break;

            //                case "CardCode"://for customer id
            //                    hPaymentHeaderRow[oField.Name] = row["accountID"].ToString();
            //                    break;

            //                case "CashSum":
            //                    hPaymentHeaderRow[oField.Name] = row["netBaseAmount"].ToString();
            //                    break;

            //                case "DocDate":
            //                    DateTime temp = DateTime.Parse(row["transactionDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = temp.ToString("yyyyMMdd");
            //                    break;

            //                case "Reference2":
            //                    string refNo = row["ReferenceNo"].ToString();
            //                    if (refNo.Length > 8)
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
            //                    }
            //                    else
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo;
            //                    }
            //                    break;

            //                case "CounterReference":
            //                    refNo = row["ReferenceNo"].ToString();
            //                    if (refNo.Length > 8)
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo.Substring(refNo.Length - 8, 8);
            //                    }
            //                    else
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = refNo;
            //                    }
            //                    break;

            //                case "TaxDate":
            //                    DateTime tmpChequeDate = DateTime.Parse(row["transactionDate"].ToString());
            //                    hPaymentHeaderRow[oField.Name] = tmpChequeDate.ToString("yyyyMMdd");
            //                    break;

            //                case "_":
            //                case "":
            //                    hPaymentHeaderRow[oField.Name] = "";
            //                    break;
            //                default:
            //                    if (oField.Field_In_Folio != "")
            //                    {
            //                        hPaymentHeaderRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                    }
            //                    break;
            //            }
            //        }
            //    }

            //    dtPaymentsHeader.Rows.Add(hPaymentHeaderRow);
            //    idxPaymentHeader++;
            //    //<<end Payment Header
            //}

            //if (dtPaymentsCash != null)
            //{
            //    //payments - cash
            //    try
            //    {
            //        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            //        sfdExport.FileName = "Payment-Cheques - " + startDate.ToString("MMMddyyyy");

            //        if (sfdExport.ShowDialog() == DialogResult.OK)
            //        {
            //            string filelocation = sfdExport.FileName;

            //            CreateCSVFile(dtPaymentsCash, filelocation);

            //            //set posted
            //            oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

            //            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //return;
            //    }

            //}
            //#endregion

            ////>>for Payment Header
            //if (dtPaymentsHeader != null)
            //{
            //    //payments - header
            //    try
            //    {
            //        sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            //        sfdExport.FileName = "Payment_Header - " + startDate.ToString("MMMddyyyy");

            //        if (sfdExport.ShowDialog() == DialogResult.OK)
            //        {
            //            string filelocation = sfdExport.FileName;

            //            CreateCSVFile(dtPaymentsHeader, filelocation);

            //            //set posted
            //            oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

            //            MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //return;
            //    }
            //}
            ////<<end Payment header
            //#endregion

            //#region "INVENTORY"

            //if (bool.Parse(ConfigVariables.gRestoConnected) == true)
            //{
            //    DataTable tempInventoryData = oTransactionCodeMappingDAO.getRestoDataHeaderForSAP(startDate, endDate);

            //    DataTable dtInventoryHeader = null;
            //    DataTable dtInventoryDetail = null;

            //    int idxInventoryheader = 1;

            //    foreach (DataRow row in tempInventoryData.Rows)
            //    {
            //        int idxInventoryDetail = 0;
            //        dtInventoryHeader = arrTables[invoiceHeaderInventoryIndex];

            //        DataRow hNewRow = dtInventoryHeader.NewRow();
            //        foreach (SAP_Interface.TemplateField oField in tInvoiceHeaderInventory.Fields)
            //        {

            //            if (oField.StatusFlag == "ACTIVE")
            //            {
            //                DateTime dtTemp = DateTime.Parse(row["order_date"].ToString());
            //                string _fieldName = oField.Name.Trim();
            //                switch (_fieldName)
            //                {
            //                    case "RecordKey":
            //                        hNewRow[oField.Name] = idxInventoryheader;
            //                        break;

            //                    case "CardCode"://for customer id
            //                        hNewRow[oField.Name] = row["customerID"].ToString();
            //                        break;

            //                    case "Comments":
            //                        hNewRow[oField.Name] = row["comments"].ToString();
            //                        break;

            //                    case "DocDate":
            //                        hNewRow[oField.Name] = dtTemp.ToString("yyyyMMdd");
            //                        break;

            //                    case "DocDueDate":
            //                        hNewRow[oField.Name] = dtTemp.ToString("yyyyMMdd");
            //                        break;

            //                    case "DocType":
            //                        hNewRow[oField.Name] = "dDocument_Items";
            //                        break;

            //                    case "SalesPersonCode":
            //                        hNewRow[oField.Name] = "2";
            //                        break;

            //                    case "TaxDate":
            //                        hNewRow[oField.Name] = dtTemp.ToString("yyyyMMdd");
            //                        break;

            //                    case "NumAtCard":
            //                        hNewRow[oField.Name] = row["order_id"].ToString();
            //                        break;

            //                    case "_":
            //                    case "":
            //                        hNewRow[oField.Name] = "";
            //                        break;
            //                    default:
            //                        if (oField.Field_In_Folio != "")
            //                        {
            //                            hNewRow[oField.Name] = row[oField.Field_In_Folio].ToString();
            //                        }
            //                        break;
            //                }
            //            }

            //        }

            //        //>>for Inventory Detail
            //        DataTable tempInventoryDetail = oTransactionCodeMappingDAO.getRestoDataDetailsForSAP(row["Order_ID"].ToString());

            //        foreach (DataRow _rowDetail in tempInventoryDetail.Rows)
            //        {
            //            dtInventoryDetail = arrTables[invoiceDetailInventoryIndex];

            //            DataRow hNewRowDetail = dtInventoryDetail.NewRow();
            //            foreach (SAP_Interface.TemplateField oFieldDetail in tInvoiceDetailInventory.Fields)
            //            {
            //                if (oFieldDetail.StatusFlag == "ACTIVE")
            //                {
            //                    string _fieldName = oFieldDetail.Name.Trim();
            //                    switch (_fieldName)
            //                    {
            //                        case "RecordKey":
            //                            hNewRowDetail[oFieldDetail.Name] = idxInventoryheader;
            //                            break;

            //                        case "LineNum":
            //                            hNewRowDetail[oFieldDetail.Name] = idxInventoryDetail;
            //                            break;

            //                        case "CostingCode":
            //                            hNewRowDetail[oFieldDetail.Name] = "FOODBEV";
            //                            break;

            //                        case "ItemCode":
            //                            hNewRowDetail[oFieldDetail.Name] = _rowDetail["item_id"].ToString();
            //                            break;

            //                        case "ItemDescription":
            //                            hNewRowDetail[oFieldDetail.Name] = _rowDetail["Description"].ToString();
            //                            break;

            //                        case "LineTotal":
            //                            hNewRowDetail[oFieldDetail.Name] = _rowDetail["amount"].ToString();
            //                            break;

            //                        case "Quantity":
            //                            hNewRowDetail[oFieldDetail.Name] = _rowDetail["quantity"].ToString();
            //                            break;

            //                        case "SalesPersonCode":
            //                            hNewRowDetail[oFieldDetail.Name] = "2";
            //                            break;

            //                        case "WarehouseCode":
            //                            hNewRowDetail[oFieldDetail.Name] = "2";
            //                            break;

            //                        case "_":
            //                        case "":
            //                            hNewRowDetail[oFieldDetail.Name] = "";
            //                            break;
            //                        default:
            //                            if (oFieldDetail.Field_In_Folio != "")
            //                            {
            //                                hNewRowDetail[oFieldDetail.Name] = row[oFieldDetail.Field_In_Folio].ToString();
            //                            }
            //                            break;
            //                    }
            //                }
            //            }
            //            idxInventoryDetail++;
            //            dtInventoryDetail.Rows.Add(hNewRowDetail);
            //        }//<<end inventory detail

            //        idxInventoryheader++;
            //        dtInventoryHeader.Rows.Add(hNewRow);
            //    }//>>end inventory header

            //    if (dtInventoryHeader != null)
            //    {
            //        try
            //        {
            //            sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            //            sfdExport.FileName = "Invoice Header Item - " + startDate.ToString("MMMddyyyy");

            //            if (sfdExport.ShowDialog() == DialogResult.OK)
            //            {
            //                string filelocation = sfdExport.FileName;

            //                CreateCSVFile(dtInventoryHeader, filelocation);

            //                //set posted [set posted below]
            //                //oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);

            //                MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                this.Close();
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            //return;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Transaction failed.\r\nEither all transactions for the selected date have been posted or zero transactions.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if (dtInventoryDetail != null)
            //    {
            //        //invoice detail - room
            //        try
            //        {
            //            sfdExport.Filter = "Tab Delimited (*.txt)|*.TXT";
            //            sfdExport.FileName = "Invoice Detail Item - " + startDate.ToString("MMMddyyyy");

            //            if (sfdExport.ShowDialog() == DialogResult.OK)
            //            {
            //                string filelocation = sfdExport.FileName;

            //                CreateCSVFile(dtInventoryDetail, filelocation);


            //                //set posted
            //                oTransactionCodeMappingDAO.flagTransactionAsPosted(startDate, endDate);


            //                MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                this.Close();
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            //MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            //return;
            //        }

            //    }
            //}

            #endregion
        }

        private void exportFolioTransactions(bool includePosted)
        {
            PTransactionCodeMapping oTransactionMapping = new PTransactionCodeMapping();
            DataTable _transactionsDataTable = oTransactionMapping.getFolioTransactions(dtpDateToBePosted.Value.Date, includePosted);
            //Export to Excel (.csv) filed
            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Folio Transactions " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(_transactionsDataTable, sfdExport.FileName);
                    MessageBox.Show("Folio transactions exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportCreditCardAndCityTransfers(bool includePosted)
        {
            PTransactionCodeMapping oTransactionMapping = new PTransactionCodeMapping();
            DataTable _transactionsDataTable = oTransactionMapping.getCreditCardAndCityTransfers(dtpDateToBePosted.Value.Date, includePosted);
            //Export to Excel (.csv) filed
            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Credit Card and City Transfers " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(_transactionsDataTable, sfdExport.FileName);
                    MessageBox.Show("Credit card and city transfers exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportRestoTransactions(bool includePosted)
        {
            PTransactionCodeMapping oTransactionMapping = new PTransactionCodeMapping();
            DataTable _transactionsDataTable = oTransactionMapping.getRestoTransactions(dtpDateToBePosted.Value.Date, includePosted);
            //Export to Excel (.csv) filed
            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Resto Transactions " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(_transactionsDataTable, sfdExport.FileName);
                    MessageBox.Show("Resto transactions exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportFolioReceipts(bool includePosted)
        {
            PTransactionCodeMapping oTransactionMapping = new PTransactionCodeMapping();
            DataTable _receiptsDataTable = oTransactionMapping.getFolioReceipts(dtpDateToBePosted.Value.Date, includePosted);

            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Receipts " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(_receiptsDataTable, sfdExport.FileName);
                    MessageBox.Show("Sales receipts exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportNonGuestTransactions(bool includePosted)
        {
            PTransactionCodeMapping oTransactionMapping = new PTransactionCodeMapping();
            DataTable _transactionsDataTable = oTransactionMapping.getNonGuestTransactions(dtpDateToBePosted.Value.Date, includePosted);
            //Export to Excel (.csv) filed
            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Non-Guest Transactions " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(_transactionsDataTable, sfdExport.FileName);
                    MessageBox.Show("Sales non-guest transactions exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportNonGuestReceipts(bool includePosted)
        {
            PTransactionCodeMapping oTransactionMapping = new PTransactionCodeMapping();
            DataTable _receiptsDataTable = oTransactionMapping.getNonGuestReceipts(dtpDateToBePosted.Value.Date, includePosted);

            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Non-Guest Receipts " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(_receiptsDataTable, sfdExport.FileName);
                    MessageBox.Show("Sales receipts exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void exportGeneralLedger(bool includePosted)
        {
            PTransactionCodeMapping oTransactionMapping = new PTransactionCodeMapping();
            DataTable _transactionsDataTable = oTransactionMapping.getHotelTransactions(dtpDateToBePosted.Value.Date, includePosted);
            //Export to Excel (.csv) filed
            sfdExport.Filter = "CSV (Comma delimited) (*.csv)|*.CSV";
            sfdExport.FileName = "Hotel Transactions " + dtpDateToBePosted.Value.ToString("MM-dd-yyyy");
            try
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile2(_transactionsDataTable, sfdExport.FileName);
                    MessageBox.Show("Hotel transactions exported successfully.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion "PEACHTREE"
    }
}