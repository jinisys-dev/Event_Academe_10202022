using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using System.Collections;
using System.IO;

using System.Web.UI.WebControls;
using System.Web.UI;


namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class HotelRevenueUI : Form
    {
        public HotelRevenueUI()
        {
            InitializeComponent();

            //initializeGridColumns();
            initializeColumns();
        }

        private void initializeColumns()
        {
            this.grdHotelRevenue.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            for (int i = 0; i < this.grdHotelRevenue.Cols.Count; i++)
            {
                this.grdHotelRevenue.Cols[i].AllowMerging = true;
            }
            for (int i = 1; i < this.grdHotelRevenue.Cols.Count; i++)
            {
                this.grdHotelRevenue.Cols[i].DataType = typeof(System.Decimal);
                this.grdHotelRevenue.Cols[i].Format = "###,###,###,##0.00";
            }


            this.grdHotelRevenue.Rows[0].AllowMerging = true;
            this.grdHotelRevenue.Rows[0].Style = this.grdHotelRevenue.Styles["mergedRow"];

            this.grdHotelRevenue.Rows[1].AllowMerging = true;
            DataTable _oDataTable = new DataTable();
            loReportFacade = new ReportFacade();
            _oDataTable = loReportFacade.getColumnsForHotelRevenue();

            this.grdHotelRevenue.Rows.Count = 2;
            this.grdHotelRevenue.Cols.Count = _oDataTable.Rows.Count;
            this.grdHotelRevenue.Cols.Fixed = 1;
            this.grdHotelRevenue.Rows.Fixed = 2;

            int _col = 0;
            foreach (DataRow _dtRow in _oDataTable.Rows)
            {
                grdHotelRevenue.SetData(0, _col, _dtRow["columnHeader"]);
                grdHotelRevenue.SetData(1, _col, _dtRow["columnDisplay"]);
                grdHotelRevenue.Cols[_col].Name = _dtRow["columnName"].ToString();
                _col++;
            }

            int _functionCol = grdHotelRevenue.Cols["FUNCTIONS"].Index;
            for (int _colCtr = _functionCol; _colCtr < grdHotelRevenue.Cols.Count; _colCtr++)
            {
                this.grdHotelRevenue.Cols[_colCtr].DataType = typeof(System.Decimal);
                this.grdHotelRevenue.Cols[_colCtr].Format = "#,###,##0.00";
            }
            this.grdHotelRevenue.AutoSizeCols();
        }

        ReportFacade loReportFacade;
        private int lTotalSalesCol = 0;
        private int lTotalPaymentsCol = 0;
        private int lTotalPaidOutsCol = 0;
        private int lTotalFOCCol = 0;

        private void initializeGridColumns()
        {
            this.grdHotelRevenue.Rows.Count = 2;
            this.grdHotelRevenue.Cols.Count = 1;
            this.grdHotelRevenue.Cols.Fixed = 1;
            this.grdHotelRevenue.Rows.Fixed = 2;

            this.grdHotelRevenue.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            //this.grdHotelRevenue.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.ColumnsUniform;

            for (int i = 0; i < this.grdHotelRevenue.Cols.Count; i++)
            {
                this.grdHotelRevenue.Cols[i].AllowMerging = true;
            }
            for (int i = 1; i < this.grdHotelRevenue.Cols.Count; i++)
            {
                this.grdHotelRevenue.Cols[i].DataType = typeof(System.Decimal);
                this.grdHotelRevenue.Cols[i].Format = "###,###,###,##0.00";
            }


            this.grdHotelRevenue.Rows[0].AllowMerging = true;
            this.grdHotelRevenue.Rows[0].Style = this.grdHotelRevenue.Styles["mergedRow"];

            this.grdHotelRevenue.Rows[1].AllowMerging = true;

            this.grdHotelRevenue.SetData(0, 0, "DATE");
            this.grdHotelRevenue.SetData(1, 0, "DATE");
            this.grdHotelRevenue.Cols.Count++;

            IList<TransactionCode> _oTransactionCode;
            TransactionCodeFacade _oTransFacade = new TransactionCodeFacade();
            _oTransactionCode = _oTransFacade.getTransactionCodeList();

            int _col = 1;
            //>> for merging room charges, extra person and room - other sales
            this.grdHotelRevenue.SetData(0, _col, "SALES");
            this.grdHotelRevenue.SetData(1, _col, "ROOM SALES");
            this.grdHotelRevenue.Cols[_col].Name = "ROOM SALES";
            _col++;
            this.grdHotelRevenue.Cols.Count++;

            //>> for sales revenue using transactioncode that are charge
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.AcctSide == "DEBIT" && _oTransCode.TranTypeId == "1"
                    && _oTransCode.TranCode != "1000" && _oTransCode.TranCode != "1001" && _oTransCode.TranCode != "1002")
                {
                    this.grdHotelRevenue.SetData(0, _col, "SALES");
                    this.grdHotelRevenue.SetData(1, _col, _oTransCode.Memo);
                    this.grdHotelRevenue.Cols[_col].Name = _oTransCode.TranCode;
                    _col++;
                    this.grdHotelRevenue.Cols.Count++;
                }
            }

            this.grdHotelRevenue.SetData(0, _col, "SALES");
            this.grdHotelRevenue.SetData(1, _col, "TOTAL SALES");
            this.grdHotelRevenue.Cols[_col].Name = "SALES";
            this.grdHotelRevenue.Cols.Count++;
            lTotalSalesCol = _col;
            _col++;

            //>> for sales revenue using transactioncode that are FOC
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.TranTypeId == "7")
                {
                    this.grdHotelRevenue.SetData(0, _col, "FOC");
                    this.grdHotelRevenue.SetData(1, _col, _oTransCode.Memo);
                    this.grdHotelRevenue.Cols[_col].Name = _oTransCode.TranCode;
                    _col++;
                    this.grdHotelRevenue.Cols.Count++;
                }
            }

            this.grdHotelRevenue.SetData(0, _col, "FOC");
            this.grdHotelRevenue.SetData(1, _col, "TOTAL FOC");
            this.grdHotelRevenue.Cols[_col].Name = "FOC SALES";
            this.grdHotelRevenue.Cols.Count++;
            lTotalFOCCol = _col;
            _col++;

            //>>Total Sales Net of FOC
            this.grdHotelRevenue.SetData(0, _col, "NET SALES");
            this.grdHotelRevenue.SetData(1, _col, "NET SALES");
            this.grdHotelRevenue.Cols[_col].Name = "NET SALES";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //TOTAL DISCOUNTS
            this.grdHotelRevenue.SetData(0, _col, "TOTAL");
            this.grdHotelRevenue.SetData(1, _col, "DISCOUNTS");
            this.grdHotelRevenue.Cols[_col].Name = "DISCOUNT";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //TOTAL LOCAL TAX
            this.grdHotelRevenue.SetData(0, _col, "TOTAL");
            this.grdHotelRevenue.SetData(1, _col, "LOCAL TAX");
            this.grdHotelRevenue.Cols[_col].Name = "LOCAL TAX";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //TOTAL GOVERNMENT TAX
            this.grdHotelRevenue.SetData(0, _col, "TOTAL");
            this.grdHotelRevenue.SetData(1, _col, "GOVERNMENT TAX");
            this.grdHotelRevenue.Cols[_col].Name = "GOVERNMENT TAX";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //TOTAL SERVICE CHARGE
            this.grdHotelRevenue.SetData(0, _col, "TOTAL");
            this.grdHotelRevenue.SetData(1, _col, "SERVICE CHARGE");
            this.grdHotelRevenue.Cols[_col].Name = "SERVICE CHARGE";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //>> for any type of payments
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.AcctSide == "CREDIT" && (_oTransCode.TranTypeId == "2" || _oTransCode.TranTypeId == "3" || _oTransCode.TranTypeId == "4" || _oTransCode.TranTypeId == "5"))
                {
                    this.grdHotelRevenue.SetData(0, _col, "PAYMENTS");
                    this.grdHotelRevenue.SetData(1, _col, _oTransCode.Memo);
                    this.grdHotelRevenue.Cols[_col].Name = _oTransCode.TranCode;
                    _col++;
                    this.grdHotelRevenue.Cols.Count++;
                }
            }
            this.grdHotelRevenue.SetData(0, _col, "PAYMENTS");
            this.grdHotelRevenue.SetData(1, _col, "TOTAL PAYMENTS");
            this.grdHotelRevenue.Cols[_col].Name = "PAYMENTS";
            this.grdHotelRevenue.Cols.Count++;
            lTotalPaymentsCol = _col;
            _col++;

            //>> for paid outs
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.TranTypeId == "8")
                {
                    IList<TransactionCode_SubAccount> _oSubAccount;
                    TransactionCode_SubAccountFacade _oTransSubAcctFacade = new TransactionCode_SubAccountFacade();
                    _oSubAccount = _oTransSubAcctFacade.loadTransactionCodeSubAccounts(_oTransCode.TranCode);

                    if (_oSubAccount.Count > 0)
                    {
                        foreach (TransactionCode_SubAccount _oTransSubAcct in _oSubAccount)
                        {
                            this.grdHotelRevenue.SetData(0, _col, "PAID OUT");
                            this.grdHotelRevenue.SetData(1, _col, _oTransSubAcct.SubAccountCode);
                            this.grdHotelRevenue.Cols[_col].Name = _oTransSubAcct.SubAccountCode;
                            _col++;
                            this.grdHotelRevenue.Cols.Count++;
                        }
                    }
                    else
                    {
                        this.grdHotelRevenue.SetData(0, _col, "PAID OUT");
                        this.grdHotelRevenue.SetData(1, _col, _oTransCode.Memo);
                        this.grdHotelRevenue.Cols[_col].Name = _oTransCode.TranCode;
                        _col++;
                        this.grdHotelRevenue.Cols.Count++;
                    }
                }
            }
            this.grdHotelRevenue.SetData(0, _col, "PAID OUT");
            this.grdHotelRevenue.SetData(1, _col, "TOTAL PAID OUTS");
            this.grdHotelRevenue.Cols[_col].Name = "PAID OUTS";
            this.grdHotelRevenue.Cols.Count++;
            lTotalPaidOutsCol = _col;
            _col++;

            // NET CASH
            this.grdHotelRevenue.SetData(0, _col, "NET CASH");
            this.grdHotelRevenue.SetData(1, _col, "NET CASH");
            this.grdHotelRevenue.Cols[_col].Name = "NET CASH";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            // CHARGE
            this.grdHotelRevenue.SetData(0, _col, "CITY LEDGER");
            this.grdHotelRevenue.SetData(1, _col, "CITY LEDGER");
            this.grdHotelRevenue.Cols[_col].Name = "4200";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //>> for break down of room sales
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.AcctSide == "DEBIT" && _oTransCode.TranTypeId == "1"
                    && (_oTransCode.TranCode == "1000" || _oTransCode.TranCode == "1001" || _oTransCode.TranCode == "1002"))
                {
                    this.grdHotelRevenue.SetData(0, _col, "ROOM SALES");
                    this.grdHotelRevenue.SetData(1, _col, _oTransCode.Memo);
                    this.grdHotelRevenue.Cols[_col].Name = _oTransCode.TranCode;
                    _col++;
                    this.grdHotelRevenue.Cols.Count++;
                }
            }

            //>>for restaurant's sub-accounts
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.TranCode == "1201")
                {
                    IList<TransactionCode_SubAccount> _oSubAccount;
                    TransactionCode_SubAccountFacade _oTransSubAcctFacade = new TransactionCode_SubAccountFacade();
                    _oSubAccount = _oTransSubAcctFacade.loadTransactionCodeSubAccounts(_oTransCode.TranCode);

                    foreach (TransactionCode_SubAccount _oTransSubAcct in _oSubAccount)
                    {
                        this.grdHotelRevenue.SetData(0, _col, "RESTAURANT SALES");
                        this.grdHotelRevenue.SetData(1, _col, _oTransSubAcct.SubAccountCode);
                        this.grdHotelRevenue.Cols[_col].Name = _oTransSubAcct.SubAccountCode;
                        _col++;
                        this.grdHotelRevenue.Cols.Count++;
                    }
                }
            }

            //>>for restaurant's FOC sub-accounts
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.TranCode == "71201")
                {
                    IList<TransactionCode_SubAccount> _oSubAccount;
                    TransactionCode_SubAccountFacade _oTransSubAcctFacade = new TransactionCode_SubAccountFacade();
                    _oSubAccount = _oTransSubAcctFacade.loadTransactionCodeSubAccounts(_oTransCode.TranCode);

                    foreach (TransactionCode_SubAccount _oTransSubAcct in _oSubAccount)
                    {
                        this.grdHotelRevenue.SetData(0, _col, "RESTAURANT FOC");
                        this.grdHotelRevenue.SetData(1, _col, _oTransSubAcct.SubAccountCode);
                        this.grdHotelRevenue.Cols[_col].Name = _oTransSubAcct.SubAccountCode;
                        _col++;
                        this.grdHotelRevenue.Cols.Count++;
                    }
                }
            }

            //>>for telephone's sub-accounts
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.TranCode == "1100")
                {
                    IList<TransactionCode_SubAccount> _oSubAccount;
                    TransactionCode_SubAccountFacade _oTransSubAcctFacade = new TransactionCode_SubAccountFacade();
                    _oSubAccount = _oTransSubAcctFacade.loadTransactionCodeSubAccounts(_oTransCode.TranCode);

                    foreach (TransactionCode_SubAccount _oTransSubAcct in _oSubAccount)
                    {
                        this.grdHotelRevenue.SetData(0, _col, "TELEPHONE SALES");
                        this.grdHotelRevenue.SetData(1, _col, _oTransSubAcct.SubAccountCode);
                        this.grdHotelRevenue.Cols[_col].Name = _oTransSubAcct.SubAccountCode;
                        _col++;
                        this.grdHotelRevenue.Cols.Count++;
                    }
                }
            }

            //>>for telephone's FOC sub-accounts
            foreach (TransactionCode _oTransCode in _oTransactionCode)
            {
                if (_oTransCode.TranCode == "71100")
                {
                    IList<TransactionCode_SubAccount> _oSubAccount;
                    TransactionCode_SubAccountFacade _oTransSubAcctFacade = new TransactionCode_SubAccountFacade();
                    _oSubAccount = _oTransSubAcctFacade.loadTransactionCodeSubAccounts(_oTransCode.TranCode);

                    foreach (TransactionCode_SubAccount _oTransSubAcct in _oSubAccount)
                    {
                        this.grdHotelRevenue.SetData(0, _col, "TELEPHONE FOC");
                        this.grdHotelRevenue.SetData(1, _col, _oTransSubAcct.SubAccountCode);
                        this.grdHotelRevenue.Cols[_col].Name = _oTransSubAcct.SubAccountCode;
                        _col++;
                        this.grdHotelRevenue.Cols.Count++;
                    }
                }
            }

            //FUNCTIONS
            this.grdHotelRevenue.SetData(0, _col, "FUNCTIONS");
            this.grdHotelRevenue.SetData(1, _col, "FUNCTIONS");
            this.grdHotelRevenue.Cols[_col].Name = "FUNCTIONS";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //OCCUPIED
            this.grdHotelRevenue.SetData(0, _col, "OCCUPIED");
            this.grdHotelRevenue.SetData(1, _col, "OCCUPIED");
            this.grdHotelRevenue.Cols[_col].Name = "TOTAL OCCUPIED";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;
            //ROOMS STAY OVER
            this.grdHotelRevenue.SetData(0, _col, "ROOMS STAY-OVER");
            this.grdHotelRevenue.SetData(1, _col, "ROOMS STAY-OVER");
            this.grdHotelRevenue.Cols[_col].Name = "ROOM STAY-OVER";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //ARRIVALS
            this.grdHotelRevenue.SetData(0, _col, "ARRIVALS");
            this.grdHotelRevenue.SetData(1, _col, "RESERVED");
            this.grdHotelRevenue.Cols[_col].Name = "RESERVE";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "ARRIVALS");
            this.grdHotelRevenue.SetData(1, _col, "WALK IN");
            this.grdHotelRevenue.Cols[_col].Name = "WALK IN";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "ARRIVALS");
            this.grdHotelRevenue.SetData(1, _col, "TOTAL ARRIVALS");
            this.grdHotelRevenue.Cols[_col].Name = "TOTAL ARRIVALS";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //RESERVATIONS
            this.grdHotelRevenue.SetData(0, _col, "RESERVATIONS");
            this.grdHotelRevenue.SetData(1, _col, "CANCELLED");
            this.grdHotelRevenue.Cols[_col].Name = "CANCELLED";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "RESERVATIONS");
            this.grdHotelRevenue.SetData(1, _col, "NO SHOW");
            this.grdHotelRevenue.Cols[_col].Name = "NO SHOW";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "RESERVATIONS");
            this.grdHotelRevenue.SetData(1, _col, "PERSONAL");
            this.grdHotelRevenue.Cols[_col].Name = "PERSONAL";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "RESERVATIONS");
            this.grdHotelRevenue.SetData(1, _col, "CORPORATE");
            this.grdHotelRevenue.Cols[_col].Name = "CORPORATE";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "RESERVATIONS");
            this.grdHotelRevenue.SetData(1, _col, "TOTAL RESERVATIONS");
            this.grdHotelRevenue.Cols[_col].Name = "TOTAL RESERVATIONS";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            _col++;
            this.grdHotelRevenue.Cols.Count++;

            // WALK IN
            this.grdHotelRevenue.SetData(0, _col, "WALK IN");
            this.grdHotelRevenue.SetData(1, _col, "INDIVIDUAL(RET)");
            this.grdHotelRevenue.Cols[_col].Name = "WALK IN OLD";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "WALK IN");
            this.grdHotelRevenue.SetData(1, _col, "INDIVIDUAL(NEW)");
            this.grdHotelRevenue.Cols[_col].Name = "WALK IN NEW";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "WALK IN");
            this.grdHotelRevenue.SetData(1, _col, "CORPORATE");
            this.grdHotelRevenue.Cols[_col].Name = "WALK IN CORPORATE";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Int32);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "AVERAGE RATES");
            this.grdHotelRevenue.SetData(1, _col, "ROOM RATE");
            this.grdHotelRevenue.Cols[_col].Name = "AVERAGEROOMRATE";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Decimal);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0.00";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            this.grdHotelRevenue.SetData(0, _col, "AVERAGE RATES");
            this.grdHotelRevenue.SetData(1, _col, "RATE/GUEST");
            this.grdHotelRevenue.Cols[_col].Name = "AVERAGEROOMRATEPERGUEST";
            this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Decimal);
            this.grdHotelRevenue.Cols[_col].Format = "#,###,##0.00";
            this.grdHotelRevenue.Cols.Count++;
            _col++;

            //this.grdHotelRevenue.SetData(0, _col, "GUEST A/R");
            //this.grdHotelRevenue.SetData(1, _col, "GUEST A/R");
            //this.grdHotelRevenue.Cols[_col].Name = "GUEST AR";
            //this.grdHotelRevenue.Cols[_col].DataType = typeof(System.Decimal);
            //this.grdHotelRevenue.Cols[_col].Format = "#,###,##0.00";
            //this.grdHotelRevenue.Cols.Count++;
            //_col++;

            this.grdHotelRevenue.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
        }

        private void HotelRevenueUI_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void HotelRevenueUI_Load(object sender, EventArgs e)
        {
            DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate + " 23:59:59");
            
            this.cboViewType.SelectedIndex = 0;
            this.dtpFromDate.Value = _auditDate;
            this.dtpToDate.Value = _auditDate;
        }

        private enum ReportType { DAILY, MONTHLY, ANNUAL, OTHERS };
        ReportType mReportType = ReportType.DAILY;

        private void btnView_Click(object sender, EventArgs e)
        {
            ////this.MdiParent.Cursor = Cursors.WaitCursor;

            //compute();
            displayValues();

            //this.MdiParent.Cursor = Cursors.Default;
            this.grdHotelRevenue.AutoSizeCols();
        }

        private void compute()
        {
            int _index = this.cboViewType.SelectedIndex;
            this.grdHotelRevenue.Rows.Count = 2;

            DateTime _from = this.dtpFromDate.Value;
            DateTime _to = this.dtpToDate.Value;

            int _diff = 1;

            switch (_index)
            {
                case 0:
                    mReportType = ReportType.OTHERS;
                    _diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _from, _to);
                    break;
                case 1:
                    mReportType = ReportType.MONTHLY;
                    _diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Month, _from, _to);
                    break;
                case 2:
                    mReportType = ReportType.ANNUAL;
                    _diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Year, _from, _to);
                    break;
            }
            this.grdHotelRevenue.Rows.Count = _diff + 3;

            int _rows = this.grdHotelRevenue.Rows.Count - 2;

            loReportFacade = new ReportFacade();
            //string _pDate = string.Format("{0:yyyy-MM-dd}", _from);
            string _pEndDate = string.Format("{0:yyyy-MM-dd}", _to);
            DataTable _dtTable = null;

            for (int i = 0; i < _rows; i++)
            {
                string _str = "";
                switch (mReportType)
                {
                    case ReportType.OTHERS:
                        string _pDate = string.Format("{0:yyyy-MM-dd}", _from.AddDays(i));

                        DataTable _dtTableReservationsSummary = loReportFacade.getDailyReservationSummary(_pDate);
                        DataTable _dtTableSales = loReportFacade.getDailyRevenue(_pDate);
                        DataTable _dtTableBySubAccount = loReportFacade.getDailySalesSummaryBySubAccount(_pDate);
                        
                        _str = string.Format("{0:dd-MMM-yyyy}", _from.AddDays(i));
                        string _colName = "";
                        string _date = string.Format("{0:yyyy-MM-dd}", _from.AddDays(i));

                        // for TRANSACTION SUMMARY
                        DataView dtViewSales = _dtTableSales.DefaultView;
                        dtViewSales.RowStateFilter = DataViewRowState.OriginalRows;
                        dtViewSales.RowFilter = "transactiondate='" + _date + "'";
                        foreach (DataRowView _dRow in dtViewSales)
                        {
                            try
                            {
                                _colName = _dRow["TransactionCode"].ToString();

                                decimal _total = decimal.Parse(_dRow["NetBaseAmount"].ToString());

                                if (_dRow["acctSide"].ToString() == "CREDIT")
                                {
                                    _total = _total * -1;
                                }
                                this.grdHotelRevenue.SetData(i + 2, _colName, _total);
                            }
                            catch { }
                        }

                        // for TRANSACTION SUMMARY BY SUBACCOUNT
                        DataView dtViewBySubAccount = _dtTableBySubAccount.DefaultView;
                        dtViewBySubAccount.RowStateFilter = DataViewRowState.OriginalRows;
                        dtViewBySubAccount.RowFilter = "transactiondate='" + _date + "'";
                        foreach (DataRowView _dRow in dtViewBySubAccount)
                        {
                            try
                            {
                                _colName = _dRow["SubAccount"].ToString();

                                decimal _total = decimal.Parse(_dRow["DEBIT"].ToString());
                                //_total += decimal.Parse(_dRow["DEBIT"].ToString());

                                if (_dRow["acctSide"].ToString() == "CREDIT")
                                {
                                    _total = _total * -1;
                                }

                                this.grdHotelRevenue.SetData(i + 2, _colName, _total);
                            }
                            catch { }
                        }

                        // FOR SUMMARY OF RESERVATION
                        DataView dtViewReservations = _dtTableReservationsSummary.DefaultView;
                        dtViewReservations.RowStateFilter = DataViewRowState.OriginalRows;
                        dtViewReservations.RowFilter = "fromdate='" + _date + "'";
                        foreach (DataRowView _dRow in dtViewReservations)
                        {
                            try
                            {
                                _colName = _dRow["description"].ToString();

                                decimal _total = decimal.Parse(_dRow["Rooms"].ToString());

                                this.grdHotelRevenue.SetData(i + 2, _colName, _total);
                            }
                            catch { }
                        }

                        //GUEST AR
                        //_dtTable = loReportFacade.getDailyGuestAR(_from.AddDays(i));

                        //foreach (DataRow _dRow in _dtTable.Rows)
                        //{
                        //    try
                        //    {

                        //        decimal _total = decimal.Parse(_dRow["BALANCE"].ToString());

                        //        this.grdHotelRevenue.SetData(i + 2, "GUEST AR", _total);
                        //    }
                        //    catch { }
                        //}



                        break;
                    case ReportType.MONTHLY:

                        _str = string.Format("{0:MMMM, yyyy}", _from.AddMonths(i));
                        int _pMonth = _from.AddMonths(i).Month;
                        int _pYear = _from.AddMonths(i).Year;

                        _dtTable = loReportFacade.getMonthlySalesRevenue(_pMonth, _pYear);

                        // for TRANSACTION SUMMARY
                        foreach (DataRow _dRow in _dtTable.Rows)
                        {
                            try
                            {
                                _colName = _dRow["TransactionCode"].ToString();

                                decimal _total = decimal.Parse(_dRow["NetBaseAmount"].ToString());
                                if (_dRow["acctSide"].ToString() == "CREDIT")
                                {
                                    _total = _total * -1;
                                }
                                this.grdHotelRevenue.SetData(i + 2, _colName, _total);
                            }
                            catch { }
                        }

                        // for TRANSACTION SUMMARY BY SUBACCOUNT
                        _dtTable = loReportFacade.getMonthlySalesSummaryBySubAccount(_pMonth, _pYear);

                        foreach (DataRow _dRow in _dtTable.Rows)
                        {
                            try
                            {
                                _colName = _dRow["SubAccount"].ToString();

                                decimal _total = decimal.Parse(_dRow["CREDIT"].ToString());
                                _total += decimal.Parse(_dRow["DEBIT"].ToString());

                                this.grdHotelRevenue.SetData(i + 2, _colName, _total);
                            }
                            catch { }
                        }

                        break;
                    case ReportType.ANNUAL:

                        _str = string.Format("{0:yyyy}", _from.AddYears(i));
                        _pYear = _from.AddYears(i).Year;

                        _dtTable = loReportFacade.getAnnualSalesSummary(_pYear);

                        // for TRANSACTION SUMMARY
                        foreach (DataRow _dRow in _dtTable.Rows)
                        {
                            try
                            {
                                _colName = _dRow["TransactionCode"].ToString();

                                decimal _total = decimal.Parse(_dRow["CREDIT"].ToString());
                                _total += decimal.Parse(_dRow["DEBIT"].ToString());

                                this.grdHotelRevenue.SetData(i + 2, _colName, _total);
                            }
                            catch { }
                        }

                        // for TRANSACTION SUMMARY BY SUBACCOUNT
                        _dtTable = loReportFacade.getAnnualSalesSummaryBySubAccount(_pYear);

                        foreach (DataRow _dRow in _dtTable.Rows)
                        {
                            try
                            {
                                _colName = _dRow["SubAccount"].ToString();

                                decimal _total = decimal.Parse(_dRow["CREDIT"].ToString());
                                _total += decimal.Parse(_dRow["DEBIT"].ToString());

                                this.grdHotelRevenue.SetData(i + 2, _colName, _total);
                            }
                            catch { }
                        }

                        break;
                }

                this.grdHotelRevenue.SetData(i + 2, 0, _str);
            }


            // FOR TOTALS
            for (int i = 2; i < _rows + 2; i++)
            {
                // TOTAL SALES
                decimal _totalSales = 0;
                for (int c = 1; c < lTotalSalesCol; c++)
                {
                    try
                    {
                        if (this.grdHotelRevenue.GetDataDisplay(i, c) != "")
                            _totalSales += decimal.Parse(this.grdHotelRevenue.GetDataDisplay(i, c));
                    }
                    catch
                    { }
                }
                this.grdHotelRevenue.SetData(i, "SALES", _totalSales);

                // TOTAL FOC SALES
                decimal _totalFOCSales = 0;
                for (int c = lTotalSalesCol + 1; c < lTotalFOCCol; c++)
                {
                    try
                    {
                        if (this.grdHotelRevenue.GetDataDisplay(i, c) != "")
                            _totalFOCSales += decimal.Parse(this.grdHotelRevenue.GetDataDisplay(i, c));
                    }
                    catch
                    { }
                }
                this.grdHotelRevenue.SetData(i, "FOC SALES", _totalFOCSales);

                // TOTAL NET SALES OF FOC
                decimal _totalNetOfFOCSales = _totalSales - _totalFOCSales;
                this.grdHotelRevenue.SetData(i, "NET SALES", _totalNetOfFOCSales);

                // TOTAL PAYMENTS
                decimal _totalPayments = 0;
                for (int c = lTotalFOCCol + 6; c < lTotalPaymentsCol; c++)
                {
                    try
                    {
                        if (this.grdHotelRevenue.GetDataDisplay(i, c) != "")
                            _totalPayments += decimal.Parse(this.grdHotelRevenue.GetDataDisplay(i, c));
                    }
                    catch
                    { }
                }
                this.grdHotelRevenue.SetData(i, "PAYMENTS", _totalPayments);

                // TOTAL PAID OUTS
                decimal _totalPaidOut = 0;
                for (int c = lTotalPaymentsCol + 1; c < lTotalPaidOutsCol; c++)
                {
                    try
                    {
                        if (this.grdHotelRevenue.GetDataDisplay(i, c) != "")
                            _totalPaidOut += decimal.Parse(this.grdHotelRevenue.GetDataDisplay(i, c));
                    }
                    catch
                    { }
                }
                this.grdHotelRevenue.SetData(i, "PAID OUTS", _totalPaidOut);


                // TOTAL ARRIVALS [WALK-IN / RESERVE]
                int _totalArrival = 0;
                int _reserve = 0;
                try
                {
                    _reserve = int.Parse(grdHotelRevenue.GetDataDisplay(i, "RESERVE"));
                }
                catch
                {
                    _reserve = 0;
                }
                int _walkIn = 0;
                try
                {
                    _walkIn = int.Parse(grdHotelRevenue.GetDataDisplay(i, "WALK IN"));
                }
                catch
                {
                    _walkIn = 0;
                }
                _totalArrival = _reserve + _walkIn;
                this.grdHotelRevenue.SetData(i, "TOTAL ARRIVALS", _totalArrival);

                // TOTAL OCCUPIED
                int _totalRoomStayOver = 0;
                try
                {
                    _totalRoomStayOver = int.Parse(grdHotelRevenue.GetDataDisplay(i, "ROOM STAY-OVER"));
                }
                catch
                {
                    _totalRoomStayOver = 0;
                }

                int _totalOccupied = 0;
                _totalOccupied = _totalArrival + _totalRoomStayOver;

                this.grdHotelRevenue.SetData(i, "TOTAL OCCUPIED", _totalOccupied);


                // NET CASH
                decimal _totalCash = 0;
                try
                {
                    if (this.grdHotelRevenue.GetDataDisplay(i, "2000") != "")
                        _totalCash += decimal.Parse(this.grdHotelRevenue.GetDataDisplay(i, "2000"));
                }
                catch
                { }

                decimal _netCash = 0;
                _netCash = _totalCash - _totalPaidOut;
                this.grdHotelRevenue.SetData(i, "NET CASH", _netCash);



                // TOTAL CANCELLED/NO SHOW RESERVATION
                //int _totalCancelledNoShow = 0;
                //for (int c = 40; c < 42; c++)
                //{
                //    try
                //    {
                //        if (this.grdHotelRevenue.GetDataDisplay(i, c) != "")
                //            _totalCancelledNoShow += int.Parse(this.grdHotelRevenue.GetDataDisplay(i, c));
                //    }
                //    catch
                //    { }
                //}

                // TOTAL RESERVATION
                //int _totalReservation = 0;
                //for (int c = 42; c < 44; c++)
                //{
                //    try
                //    {
                //        if (this.grdHotelRevenue.GetDataDisplay(i, c) != "")
                //            _totalReservation += int.Parse(this.grdHotelRevenue.GetDataDisplay(i, c));
                //    }
                //    catch
                //    { }
                //}
                //this.grdHotelRevenue.SetData(i, "TOTAL RESERVATIONS", _totalReservation);


            }

            // FILL-IN BLANK CELLS with 0.00
            for (int r = 2; r < this.grdHotelRevenue.Rows.Count; r++)
            {
                for (int c = 1; c < this.grdHotelRevenue.Cols.Count; c++)
                {
                    if (this.grdHotelRevenue.GetDataDisplay(r, c) == "")
                    {
                        this.grdHotelRevenue.SetData(r, c, "0");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void dtpToDate_ValueChanged(object sender, System.EventArgs e)
        {
            //throw new System.Exception("The method or operation is not implemented.");
            string _date = dtpToDate.Value.ToShortDateString();
            if (DateTime.Parse(_date) > DateTime.Parse(GlobalVariables.gAuditDate))
            {
                MessageBox.Show("Cannot change to desired date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpToDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
            }
        }

        private void cboViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboViewType.Text.Trim())
            {
                case "DAILY":
                    dtpFromDate.CustomFormat = "MMMM dd, yyyy";
                    dtpFromDate.Format = DateTimePickerFormat.Custom;
                    dtpToDate.CustomFormat = "MMMM dd, yyyy";
                    dtpToDate.Format = DateTimePickerFormat.Custom;
                    break;

                case "MONTHLY":
                    dtpFromDate.CustomFormat = "MMMM yyyy";
                    dtpFromDate.Format = DateTimePickerFormat.Custom;
                    dtpToDate.CustomFormat = "MMMM yyyy";
                    dtpToDate.Format = DateTimePickerFormat.Custom;
                    break;

                case "ANNUAL":
                    dtpFromDate.CustomFormat = "yyyy";
                    dtpFromDate.Format = DateTimePickerFormat.Custom;
                    dtpToDate.CustomFormat = "yyyy";
                    dtpToDate.Format = DateTimePickerFormat.Custom;
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.grdHotelRevenue.Rows.Count <= 1)
            {
                return;
            }

            try
            {
                string strFileName = "Revenue Report (" + this.dtpFromDate.Text + " to " + this.dtpToDate.Text + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;

                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    string filelocation = sfdExport.FileName;

                    DataTable reportTable = new DataTable("Revenue Report");

                    //ArrayList colNames = new ArrayList();

                    //get column names
                    int totalCol = this.grdHotelRevenue.Cols.Count;
                    int colIndex = 0;
                    for (int i = 0; i < totalCol; i++)
                    {

                        if (this.grdHotelRevenue.Cols[i].Visible)
                        {
                            //string columnName = this.grdHotelRevenue.GetDataDisplay(1, i);
                            string columnName = this.grdHotelRevenue.Cols[i].Name;

                            DataColumn col = new DataColumn(columnName);
                            colIndex++;

                            reportTable.Columns.Add(col);


                            //string paramColName = this.grdHotelRevenue.GetDataDisplay(0, i);
                            //colNames.Add(paramColName);
                        }


                    }

                    //get row values
                    int totalRow = this.grdHotelRevenue.Rows.Count;

                    for (int r = 1; r < totalRow; r++)
                    {
                        DataRow newRow = reportTable.NewRow();
                        int tempTableCol = 0;
                        for (int c = 0; c < totalCol; c++)
                        {

                            if (this.grdHotelRevenue.Cols[c].Visible)
                            {
                                if (grdHotelRevenue.GetCellStyleDisplay(r, c).ForeColor == Color.Red)
                                {
                                    newRow[tempTableCol] = "-" + this.grdHotelRevenue.GetDataDisplay(r, c);
                                }
                                else
                                {
                                    newRow[tempTableCol] = this.grdHotelRevenue.GetDataDisplay(r, c);
                                }
                                tempTableCol++;
                            }
                        }

                        reportTable.Rows.Add(newRow);
                    }

                    System.Web.UI.WebControls.DataGrid grid = new System.Web.UI.WebControls.DataGrid();
                    grid.HeaderStyle.Font.Bold = true;
                    grid.DataSource = reportTable;

                    grid.DataBind();

                    // render the DataGrid control to a file
                    using (StreamWriter sw = new StreamWriter(filelocation))
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            grid.RenderControl(hw);
                        }
                    }

                    MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void loadDateRangeRevenue(string pStartDate, string pEndDate)
        {

        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            int _index = this.cboViewType.SelectedIndex;
            DateTime _from = this.dtpFromDate.Value;
            DateTime _to = this.dtpToDate.Value;

            int _diff = 1;
            _diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _from, _to);
            int _rows = _diff + 1;
            loReportFacade = new ReportFacade();

            //>>for progress bar
            int curProgress = 0;
            ProgressForm progress = new ProgressForm();
            if (_rows > 0)
            {
                int count = _rows;
                progress = new ProgressForm(count, "Performing computation on transactions......");
                progress.Height = 27;
                progress.Show();
            }

            for (int i = 0; i < _rows; i++)
            {
                string _pDate = string.Format("{0:yyyy-MM-dd}", _from.AddDays(i));
                loReportFacade.postHotelRevenue(_pDate);

                curProgress++;
                progress.updateProgress(i);

                //break;
            }

            //MessageBox.Show("Ends at : " + DateTime.Now.ToShortTimeString());
            progress.Close();
        }

        private void displayValues()
        {
            DateTime _start = DateTime.Now;
            //>>for progress bar
            int curProgress = 0;
            ProgressForm progress = new ProgressForm();
            int _ctr = 1;

            //>>for getting the summary of sales
            if (cboViewType.Text.Trim() == "DAILY") //>>DAILY SUMMARY
            {
                grdHotelRevenue.Rows.Count = 2;
                DataTable dTable = new DataTable();
                loReportFacade = new ReportFacade();
                dTable = loReportFacade.getHotelRevenue(dtpFromDate.Value.ToString("yyyy-MM-dd"), dtpToDate.Value.ToString("yyyy-MM-dd"));

                DataTable dTableColumns = new DataTable();
                dTableColumns = loReportFacade.getColumnsForHotelRevenue();

                if (dTable.Rows.Count > 0)
                {
                    int count = dTable.Rows.Count + ((dTable.Rows.Count * grdHotelRevenue.Cols.Count) * 2); 
                    progress = new ProgressForm(count, "Retrieving data......");
                    progress.Height = 27;
                    progress.Show();
                }

                foreach (DataRow dRow in dTable.Rows)
                {
                    grdHotelRevenue.Rows.Add();
                    grdHotelRevenue.SetData(grdHotelRevenue.Rows.Count - 1, 0, dRow["transactiondate"]);

                    foreach (DataColumn dColumn in dTable.Columns)
                    {
                        foreach (DataRow dTableRows in dTableColumns.Rows)
                        {
                            if (dTableRows["mapColumn"].ToString() == dColumn.ColumnName)
                            {
                                grdHotelRevenue.SetData(grdHotelRevenue.Rows.Count - 1, dTableRows["columnName"].ToString(), dRow[dColumn]);

                                _ctr++;
                                curProgress++;
                                progress.updateProgress(_ctr);

                                break;
                            }
                        }
                    }
                }
            }
            else if (cboViewType.Text.Trim() == "MONTHLY")//>>MONTHLY SUMMARY
            {
                grdHotelRevenue.Rows.Count = 2;
                DataTable dTable = new DataTable();
                loReportFacade = new ReportFacade();
                dTable = loReportFacade.getMonthlyHotelRevenue(dtpFromDate.Value.Month, dtpToDate.Value.Month, dtpFromDate.Value.Year, dtpToDate.Value.Year);

                DataTable dTableColumns = new DataTable();
                dTableColumns = loReportFacade.getColumnsForHotelRevenue();

                //progress bar
                if (dTable.Rows.Count > 0)
                {
                    int count = dTable.Rows.Count + ((dTable.Rows.Count * grdHotelRevenue.Cols.Count) * 2);
                    progress = new ProgressForm(count, "Performing computation on transactions......");
                    progress.Height = 27;
                    progress.Show();
                }

                foreach (DataRow dRow in dTable.Rows)
                {
                    grdHotelRevenue.Rows.Add();
                    grdHotelRevenue.SetData(grdHotelRevenue.Rows.Count - 1, 0, dRow["transactiondate"]);

                    foreach (DataColumn dColumn in dTable.Columns)
                    {
                        foreach (DataRow dTableRows in dTableColumns.Rows)
                        {
                            if (dTableRows["mapColumn"].ToString() == dColumn.ColumnName)
                            {
                                grdHotelRevenue.SetData(grdHotelRevenue.Rows.Count - 1, dTableRows["columnName"].ToString(), dRow[dColumn]);

                                _ctr++;
                                curProgress++;
                                progress.updateProgress(_ctr);

                                break;
                            }
                        }
                    }
                }
            }
            else if (cboViewType.Text.Trim() == "ANNUAL")
            {
                grdHotelRevenue.Rows.Count = 2;
                DataTable dTable = new DataTable();
                loReportFacade = new ReportFacade();
                dTable = loReportFacade.getAnnualHotelRevenue(dtpFromDate.Value.Year, dtpToDate.Value.Year);

                DataTable dTableColumns = new DataTable();
                dTableColumns = loReportFacade.getColumnsForHotelRevenue();

                //progress bar
                if (dTable.Rows.Count > 0)
                {
                    int count = dTable.Rows.Count + ((dTable.Rows.Count * grdHotelRevenue.Cols.Count) * 2);
                    progress = new ProgressForm(count, "Performing computation on transactions......");
                    progress.Height = 27;
                    progress.Show();
                }

                foreach (DataRow dRow in dTable.Rows)
                {
                    grdHotelRevenue.Rows.Add();
                    grdHotelRevenue.SetData(grdHotelRevenue.Rows.Count - 1, 0, dRow["transactiondate"]);

                    foreach (DataColumn dColumn in dTable.Columns)
                    {
                        foreach (DataRow dTableRows in dTableColumns.Rows)
                        {
                            if (dTableRows["mapColumn"].ToString() == dColumn.ColumnName)
                            {
                                grdHotelRevenue.SetData(grdHotelRevenue.Rows.Count - 1, dTableRows["columnName"].ToString(), dRow[dColumn]);

                                _ctr++;
                                curProgress++;
                                progress.updateProgress(_ctr);

                                break;
                            }
                        }
                    }
                }
            }

            // get total columns
            foreach (C1.Win.C1FlexGrid.Row _row in grdHotelRevenue.Rows)
            {
                decimal _totalArrivals = 0;
                decimal _totalFOC = 0;
                decimal _totalOccupied = 0;
                decimal _totalPaidOut = 0;
                decimal _totalPayment = 0;
                decimal _totalReservations = 0;
                decimal _totalSales = 0;
                decimal _totalNetCash = 0;
                decimal _totalNetSales = 0;
                
                if (_row.Index > 1)
                {
                    foreach (C1.Win.C1FlexGrid.Column _col in grdHotelRevenue.Cols)
                    {
                        string _colHeader = grdHotelRevenue.GetData(0, _col.Index).ToString();
                        if (!_col.Name.ToUpper().StartsWith("TOTAL"))
                        {
                            switch (_colHeader)
                            {
                                case "ARRIVALS":
                                    try
                                    {
                                        _totalArrivals += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, _col.Index));
                                        //_totalOccupied += _totalArrivals;
                                    }
                                    catch
                                    {
                                        _totalArrivals += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "TOTAL ARRIVALS", _totalArrivals);
                                    break;

                                case "FOC":
                                    try
                                    {
                                        _totalFOC += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, _col.Index));
                                    }
                                    catch
                                    {
                                        _totalFOC += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "TOTAL FOC", _totalFOC);
                                    break;

                                case "OCCUPIED":
                                    try
                                    {
                                        _totalOccupied += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, _col.Index));
                                    }
                                    catch
                                    {
                                        _totalOccupied += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "OCCUPIED", _totalOccupied);
                                    break;

                                case "PAID OUT":
                                    try
                                    {
                                        _totalPaidOut += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, _col.Index));
                                    }
                                    catch
                                    {
                                        _totalPaidOut += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "TOTAL PAID OUT", _totalPaidOut);
                                    break;

                                case "PAYMENTS":
                                    try
                                    {
                                        _totalPayment += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, _col.Index));
                                    }
                                    catch
                                    {
                                        _totalPayment += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "TOTAL PAYMENTS", _totalPayment);
                                    break;

                                case "RESERVATIONS":
                                    try
                                    {
                                        _totalReservations += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, _col.Index));
                                    }
                                    catch
                                    {
                                        _totalReservations += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "TOTAL RESERVATIONS", _totalReservations);
                                    break;

                                case "SALES":
                                    try
                                    {
                                        _totalSales += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, _col.Index));
                                    }
                                    catch
                                    {
                                        _totalSales += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "TOTAL SALES", _totalSales);
                                    break;

                                case "NET CASH":
                                    try
                                    {
                                        _totalNetCash = decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, "2000")) + decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, "TOTAL PAID OUT"));
                                    }
                                    catch
                                    {
                                        _totalNetCash += 0;
                                    }

                                    grdHotelRevenue.SetData(_row.Index, "NET CASH", _totalNetCash);
                                    break;
                            }
                        }

                        _ctr++;
                        curProgress++;
                        progress.updateProgress(_ctr);
                    }

                    try
                    {
                        _totalOccupied += decimal.Parse(grdHotelRevenue.GetDataDisplay(_row.Index, "ROOMS STAY-OVER")) + _totalArrivals;
                    }
                    catch
                    {
                        _totalOccupied += 0;
                    }

                    grdHotelRevenue.SetData(_row.Index, "TOTAL OCCUPIED", _totalOccupied);
                    grdHotelRevenue.SetData(_row.Index, "NET SALES", _totalSales + _totalFOC);
                    //grdHotelRevenue.SetData(_row.Index,"ROOMS STAY-OVER", 
                }
            }

            //// FILL-IN BLANK CELLS with 0.00
            //for (int r = 2; r < this.grdHotelRevenue.Rows.Count; r++)
            //{
            //    for (int c = 1; c < this.grdHotelRevenue.Cols.Count; c++)
            //    {
            //        if (this.grdHotelRevenue.GetDataDisplay(r, c) == "")
            //        {
            //            this.grdHotelRevenue.SetData(r, c, "0");
            //        }

            //        _ctr++;
            //        curProgress++;
            //        progress.updateProgress(_ctr);
            //    }
            //}

            // TRAP NEGATIVE VALUES
            C1.Win.C1FlexGrid.CellStyle _newStyle = grdHotelRevenue.Styles.Add("negative");
            for (int r = 2; r < this.grdHotelRevenue.Rows.Count; r++)
            {
                for (int c = 1; c < this.grdHotelRevenue.Cols.Count; c++)
                {
                    if (this.grdHotelRevenue.GetDataDisplay(r, c).Contains("-"))
                    {
                        this.grdHotelRevenue.SetData(r, c, Math.Abs(decimal.Parse(this.grdHotelRevenue.GetDataDisplay(r, c))));
                        this.grdHotelRevenue.SetCellStyle(r, c, _newStyle);
                    }

                    _ctr++;
                    curProgress++;
                    progress.updateProgress(_ctr);
                }
            }

            grdHotelRevenue.AutoSizeCols();
            DateTime _end = DateTime.Now;
            progress.Close();
            //MessageBox.Show(string.Format("{0:HH:mm:ss}", (_end - _start)));
        }
    }
}