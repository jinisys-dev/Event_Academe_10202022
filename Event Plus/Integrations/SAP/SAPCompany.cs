using System;
using System.Collections.Generic;
using System.Text;
using SAPbobsCOM;
using System.Data;
using Integrations.Global;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;

namespace Integrations
{
    public class SAPCompany
    {

        public SAPCompany()
        {

        }

        //Company loCompany;
        public bool SAPConnect(string pSAPServer, string pSAPDB, string pSAPDBUser, string pSAPDBPass, string pSAPCompanyUser, string pSAPCompanyPass)
        {
            try
            {

                int _errCode = 0;
                string _error = "";
                GlobalVariables.goSAPCompany = new Company();
                GlobalVariables.goSAPCompany.Server = pSAPServer;
                GlobalVariables.goSAPCompany.DbServerType = BoDataServerTypes.dst_MSSQL2005;
                GlobalVariables.goSAPCompany.CompanyDB = pSAPDB;
                GlobalVariables.goSAPCompany.DbUserName = pSAPDBUser;
                GlobalVariables.goSAPCompany.DbPassword = pSAPDBPass;
                GlobalVariables.goSAPCompany.UserName = pSAPCompanyUser;
                GlobalVariables.goSAPCompany.Password = pSAPCompanyPass;
                GlobalVariables.goSAPCompany.language = BoSuppLangs.ln_English;
                GlobalVariables.goSAPCompany.UseTrusted = false;
                //GlobalObjects.goCompany.LicenseServer = "192.168.100.48";

                try
                {
                    GlobalVariables.goSAPCompany.Disconnect();
                }
                catch{ }

                int _connected = GlobalVariables.goSAPCompany.Connect();
                if (_connected != 0)
                {
                    GlobalVariables.goSAPCompany.GetLastError(out _errCode, out _error);
                    //essageBox.Show(_error);
                    throw new Exception(_error);
                    return false;
               }
                GlobalVariables.goIsConnectedToBackOffice = true;
                // getItemList();
                //populateGLAccountDataTable();
                //  MessageBox.Show("Connection to SAP server was successful.", "SAP Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                GlobalVariables.goIsConnectedToBackOffice = false;
                MessageBox.Show("An error occured upon connecting to the SAP server:\n" + ex.Message, "SAP Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public void disconnectFromSAP()
        {
            try
            {
                GlobalVariables.goSAPCompany.Disconnect();
            }
            catch
            { }
        }



        public bool addARInvoice(DataTable pARInvoice, SAPVariables.INVOICETYPE pInvoiceType, string pCustomerId, DateTime pPostingDate, string pComments,string pEventID
                                ,DateTime pCreateTime ,string pReferenceNum,DateTime pFromDate,DateTime pToDate,string pGroupName, string pRoomID, string pVenue)
        {
            bool _result = true;
            int _errorCode = 0;
            string _errorMessage = "";
            int _returnCode = 0;
            //DataTable _dter = SAPRecordsetDoQuery("SELECT * FROM OACT ");

            if (!GlobalVariables.goSAPCompany.Connected)
            {
                _errorMessage = "Currently not connected to a company.";
                return false;
            }
            DataTable _dt = SAPRecordsetDoQuery("SELECT GroupCode,GroupName,GroupType,Locked,DataSource,UserSign FROM OCRG WHERE GroupName = 'Others'");//'Customers'");

            int _groupCode = 0;
            try
            {
                _groupCode = int.Parse(_dt.Rows[0][0].ToString());
            }
            catch
            {
                _groupCode = 0;
            }

            SAPbobsCOM.Recordset _oRecordset = (SAPbobsCOM.Recordset)GlobalVariables.goSAPCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
           // SAPbobsCOM.Documents _oInvoice = (SAPbobsCOM.Documents)loCompany.GetBusinessObject(BoObjectTypes.oInvoices);

            SAPbobsCOM.Documents _oDrafs = (SAPbobsCOM.Documents)GlobalVariables.goSAPCompany.GetBusinessObject(BoObjectTypes.oDrafts);
            _oDrafs.CardCode = pCustomerId;
            _oDrafs.HandWritten = BoYesNoEnum.tNO;
            _oDrafs.DocDate = pPostingDate;
            // _oInvoice.Confirmed = BoYesNoEnum.tYES;

           _oDrafs.DocObjectCode = BoObjectTypes.oInvoices; 
            _oDrafs.DocDueDate = pPostingDate;
            //_oDrafs.UserFields.Fields.Item("U_EventID").Value = pEventID;
            _oDrafs.UserFields.Fields.Item("U_Event_ID").Value = pEventID;
            _oDrafs.UserFields.Fields.Item("U_Organizer_ID").Value = pCustomerId;
            _oDrafs.UserFields.Fields.Item("U_rar_pr_number").Value = pReferenceNum;
            _oDrafs.UserFields.Fields.Item("U_contract_start").Value = string.Format("{0:MM/dd/yyyy}", pFromDate);
            _oDrafs.UserFields.Fields.Item("U_contract_end").Value = string.Format("{0:MM/dd/yyyy}", pToDate);
            _oDrafs.UserFields.Fields.Item("U_room_nos").Value = pRoomID;
            //_oDrafs.UserFields.Fields.Item("U_Venue").Value = pVenue;
            _oDrafs.UserFields.Fields.Item("U_event_name").Value = pGroupName;
   
            char[] _param = new char[1];
            _param[0] = '/';
            string[] _strRoom = pRoomID.Split(_param);
            string[] _strVenue = pVenue.Split(_param);
            for (int i = 0; i < _strRoom.Length; i++)
            {
                int _cnt = i + 1;
                _oDrafs.UserFields.Fields.Item("U_room" + _cnt).Value = _strRoom[i];
                _oDrafs.UserFields.Fields.Item("U_room" + _cnt + "Name").Value = _strVenue[i];
            }

            double _total = 0;

            if (pARInvoice.Rows.Count < 1)
            {
                return false;
            }
            if (pInvoiceType == SAPVariables.INVOICETYPE.SERVICE)
            {
                _oDrafs.DocType = BoDocumentTypes.dDocument_Service;


                for (int i = 0; i < pARInvoice.Rows.Count; i++)
                {
                    if (i > 0) _oDrafs.Lines.Add();
                    _oDrafs.Lines.SetCurrentLine(i);
                    _oDrafs.Lines.ItemDescription = pARInvoice.Rows[i]["SERVICEDESCRIPTION"].ToString();
                    _oDrafs.Lines.AccountCode = pARInvoice.Rows[i]["GLACCOUNT"].ToString();

                    double _discountPercent = 0;
                    double.TryParse(pARInvoice.Rows[i]["DISCOUNTPERCENT"].ToString(), out _discountPercent);
                    _oDrafs.Lines.DiscountPercent = _discountPercent;

                    double _lineTotal = 0;
                    double.TryParse(pARInvoice.Rows[i]["AMOUNT"].ToString(), out _lineTotal);

                  
                    if (_lineTotal >= 2500000)
                        _oDrafs.Lines.VatGroup = "O1";
                    //_oDrafs.Lines.TaxCode = "O1";
                    else
                        _oDrafs.Lines.VatGroup = "X0";

                  //  _oDrafs.Lines.TaxCode = "Exempt";
                    _oDrafs.Lines.PriceAfterVAT = _lineTotal;

                    _total += _lineTotal;
                }
            }
            
            else if (pInvoiceType == SAPVariables.INVOICETYPE.ITEM)
            {
                _oDrafs.DocType = BoDocumentTypes.dDocument_Items;

                for (int i = 0; i < pARInvoice.Rows.Count; i++)
                {

                    this.addItem(pARInvoice.Rows[i]["ITEMCODE"].ToString(), pARInvoice.Rows[i]["ITEMNAME"].ToString());
                    this.addItemStock(pARInvoice.Rows[i]["ITEMCODE"].ToString(), pARInvoice.Rows[i]["QUANTITY"].ToString(), pARInvoice.Rows[i]["WAREHOUSECODE"].ToString(), "ADDED FROM EVENT PLUS");

                    _oDrafs.Lines.SetCurrentLine(i);
                    _oDrafs.Lines.ItemCode = pARInvoice.Rows[i]["ITEMCODE"].ToString();


                    double _quantity = 0;
                    double.TryParse(pARInvoice.Rows[i]["QUANTITY"].ToString(), out _quantity);
                    _oDrafs.Lines.Quantity = _quantity;

                    double _unitPrice = 0;
                    double.TryParse(pARInvoice.Rows[i]["UNITPRICE"].ToString(), out _unitPrice);
                    _oDrafs.Lines.UnitPrice = _unitPrice;

                    double _discountPercent = 0;
                    double.TryParse(pARInvoice.Rows[i]["DISCOUNTPERCENT"].ToString(), out _discountPercent);
                    _oDrafs.Lines.DiscountPercent = _discountPercent;

                    _oDrafs.Lines.WarehouseCode = pARInvoice.Rows[i]["WAREHOUSECODE"].ToString();

                    double _lineTotal = 0;
                    double.TryParse(pARInvoice.Rows[i]["LINETOTAL"].ToString(), out _lineTotal);
                    _oDrafs.Lines.LineTotal = _lineTotal;

                    _oDrafs.Lines.PriceAfterVAT = _lineTotal;
                    _oDrafs.Lines.VatGroup = "01";
                    _oDrafs.Lines.TaxCode = "Exempt";


                    _total += _lineTotal;


                    _oDrafs.Lines.Add();

                }
            }
            else
            {
                _errorMessage = "Invalid Invoice Type.";
                throw new Exception("Invalid Invoice Type.");
            }
            _oDrafs.Comments = pComments;
            _oDrafs.DocTotal = _total;
            _returnCode = _oDrafs.Add();
            if (_returnCode != 0)
            {
                int _tempErrorCode = 0;
                string _tempErrorString = "";
                GlobalVariables.goSAPCompany.GetLastError(out _tempErrorCode, out _tempErrorString);

                _errorCode = _tempErrorCode;
                _errorMessage = _tempErrorString;
                _result = false;
                throw new Exception(_tempErrorString);
            }
            else
            {
                _oRecordset = (SAPbobsCOM.Recordset)GlobalVariables.goSAPCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                _oRecordset.DoQuery("SELECT MAX(DocEntry) FROM OINV");

                // this.LASTINSERTINVOICEID = this.RECORDSET.Fields.Item(0).Value.ToString();
                _result = true;
            }

            return _result;
        }
        public bool addUDFTableEventPlus(string eventID, string eventName, string organizerID, string organizerName, string startDate, string endDate)
        {
            try
            {
               
                //SAPbobsCOM.UserTables _oTbls = (SAPbobsCOM.UserTables)loCompany.GetBusinessObject(BoObjectTypes.oUserTables);
                SAPbobsCOM.UserTable _oUserTable = GlobalVariables.goSAPCompany.UserTables.Item("EVENTSPLUS");
                //SAPbobsCOM.UserTable _userTable = new SAPbobsCOM.UserTables("EVENTPLUS");
                _oUserTable.Code = eventID.Substring(5);
                _oUserTable.Name = eventID.Substring(5);
                _oUserTable.UserFields.Fields.Item("U_event_id").Value = eventID;
                _oUserTable.UserFields.Fields.Item("U_event_name").Value = eventName;
                _oUserTable.UserFields.Fields.Item("U_organizer_id").Value = organizerID;
                _oUserTable.UserFields.Fields.Item("U_organizer_name").Value = organizerName;
                _oUserTable.UserFields.Fields.Item("U_event_startdate").Value = startDate;
                _oUserTable.UserFields.Fields.Item("U_event_enddate").Value = endDate;

                //Kevin Oliveros
                bool _flag;
                int _result = _oUserTable.Add();
                int _error = 0;
                string _errorMessage = "";
                if (_result != 0)
                {
                    GlobalVariables.goSAPCompany.GetLastError(out _error, out _errorMessage);
                    return false;
                }
                else
                {
                     _flag = addClient(organizerID, organizerName);
                }
                return true;
            }
            catch
            {

            }
            return false;
        }
        public DataTable getARInvoiceFormat(SAPVariables.INVOICETYPE pInvoiceType)
        {
            DataTable _ARInvoiceFormat = new DataTable();

            if (pInvoiceType == SAPVariables.INVOICETYPE.SERVICE)
            {
                _ARInvoiceFormat.Columns.Add("SERVICEDESCRIPTION", typeof(string));
                _ARInvoiceFormat.Columns.Add("GLACCOUNT", typeof(string));
                _ARInvoiceFormat.Columns.Add("DISCOUNTPERCENT", typeof(double));
                _ARInvoiceFormat.Columns.Add("AMOUNT", typeof(double));
            }
            else
            {
                _ARInvoiceFormat.Columns.Add("ITEMCODE", typeof(string));
                _ARInvoiceFormat.Columns.Add("ITEMNAME", typeof(string));
                _ARInvoiceFormat.Columns.Add("QUANTITY", typeof(double));
                _ARInvoiceFormat.Columns.Add("UNITPRICE", typeof(double));
                _ARInvoiceFormat.Columns.Add("DISCOUNTPERCENT", typeof(double));
                _ARInvoiceFormat.Columns.Add("WAREHOUSECODE", typeof(string));
                _ARInvoiceFormat.Columns.Add("LINETOTAL", typeof(double));
                _ARInvoiceFormat.Columns.Add("SERIALNUMBERS", typeof(string));
            }

            return _ARInvoiceFormat;
        }


        public bool addClient(string pClientId, string pClientName)
        {
            bool _result = true;

            int _errorCode = 0;
            string _errorMessage = "";
            int _returnCode = 0;

            SAPbobsCOM.BusinessPartners _oBusinessPartner = (SAPbobsCOM.BusinessPartners)GlobalVariables.goSAPCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);

            DataTable _dt = SAPRecordsetDoQuery("SELECT GroupCode,GroupName,GroupType,Locked,DataSource,UserSign FROM OCRG WHERE GroupName ='Others' ");//='Customers'");

            int _groupCode = 0;
            
            try
            {
               _groupCode = int.Parse(_dt.Rows[0][0].ToString());
            }
            catch
            {
                _groupCode = 0;
            }
            
            if (!_oBusinessPartner.GetByKey(pClientId))
            {
                _oBusinessPartner.CardCode = pClientId;
                _oBusinessPartner.CardName = pClientName;
                //  _oBusinessPartner.CardForeignName = pClientName;
                //_oBusinessPartner.CardType = BoCardTypes.cCustomer;
                _oBusinessPartner.GroupCode = _groupCode;
                _returnCode = _oBusinessPartner.Add();
            }
            else
            {
                _oBusinessPartner.CardName = pClientName;
                _oBusinessPartner.CardForeignName = pClientName;
                _oBusinessPartner.CardType = BoCardTypes.cCustomer;
                _returnCode = _oBusinessPartner.Update();
            }

            if (_returnCode != 0)
            {
                int _tempErrorCode = 0;
                string _tempErrorString = "";
                GlobalVariables.goSAPCompany.GetLastError(out _tempErrorCode, out _tempErrorString);
                _oBusinessPartner.GroupCode = 0;
                _errorCode = _tempErrorCode;
                _errorMessage = _tempErrorString;

                _result = false;
            }
            return _result;
        }

        public bool addItemStock(string pItemCode, string pStock,string pWareHouseCode, string pComments)
        {
            bool _result = true;

            int _errorCode = 0;
            string _errorMessage = "";


            SAPbobsCOM.Documents _oInventoryGenEntry = (SAPbobsCOM.Documents)GlobalVariables.goSAPCompany.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);

         	_oInventoryGenEntry.Lines.ItemCode = pItemCode;
            _oInventoryGenEntry.Lines.Quantity = double.Parse(pStock);
            _oInventoryGenEntry.Lines.WarehouseCode = pWareHouseCode;
           	_oInventoryGenEntry.Lines.UnitPrice = 0;
            _oInventoryGenEntry.Comments = pComments;

            _errorCode = _oInventoryGenEntry.Add();
            if (_errorCode != 0)
            {
                int _tempErrorCode = 0;
                string _tempErrorString = "";
                GlobalVariables.goSAPCompany.GetLastError(out _tempErrorCode, out _tempErrorString);
              
                _errorCode = _tempErrorCode;
                _errorMessage = _tempErrorString;

                _result = false;
            }
            return _result;
        }

        public bool addItem(string pItemCode, string pItemName)
        {
            bool _result = true;

            int _errorCode = 0;
            string _errorMessage = "";
            int _returnCode = 0;

            SAPbobsCOM.Items _oItems = (SAPbobsCOM.Items)GlobalVariables.goSAPCompany.GetBusinessObject(BoObjectTypes.oItems);

            DataTable _dt = SAPRecordsetDoQuery("SELECT ItmsGrpCod,ItmsGrpNam FROM OITB WHERE ItmsGrpNam = 'Items'");

            int _groupCode = 0;
            int.TryParse(_dt.Rows[0][0].ToString(), out _groupCode);

            if (!_oItems.GetByKey(pItemCode))
            {
                //_oItems.CardCode = pClientId;
                //_oItems.CardName = pClientName;
                ////  _oBusinessPartner.CardForeignName = pClientName;
                ////_oBusinessPartner.CardType = BoCardTypes.cCustomer;
                //_oItems.GroupCode = _groupCode;

                _oItems.ItemCode = pItemCode;
                _oItems.ItemName = pItemName;
               
                _oItems.BaseUnitName = "From Event Plus";
               
                //_oItems.QuantityOnStock = 1;

                _oItems.ItemsGroupCode = _groupCode;


                _returnCode = _oItems.Add();
            }
            else
            {
                //_oItems.CardName = pClientName;
                //_oItems.CardForeignName = pClientName;
                //_oItems.CardType = BoCardTypes.cCustomer;
                //_returnCode = _oItems.Update();
            }

            if (_returnCode != 0)
            {
                int _tempErrorCode = 0;
                string _tempErrorString = "";
                GlobalVariables.goSAPCompany.GetLastError(out _tempErrorCode, out _tempErrorString);
                //_oItems.GroupCode = 0;
                _errorCode = _tempErrorCode;
                _errorMessage = _tempErrorString;

                _result = false;
            }
            return _result;

        }

        private DataTable SAPRecordsetDoQuery(string pQuery)
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("ID");
            _dt.Columns.Add("Name");

            SAPbobsCOM.Recordset _oRecordset = (SAPbobsCOM.Recordset)GlobalVariables.goSAPCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            _oRecordset.DoQuery(pQuery);

            while (!_oRecordset.EoF)
            {
                DataRow _dr = _dt.NewRow();
                _dr[0] = _oRecordset.Fields.Item(0).Value.ToString();
                _dr[1] = _oRecordset.Fields.Item(1).Value.ToString();
                _dt.Rows.Add(_dr);

                _oRecordset.MoveNext();
            }

            return _dt;
        }

        public DataTable getIncomingPayments(string pEventID)
        {

            DataTable _dtResult = new DataTable();
            SAPbobsCOM.Recordset _oRecordSet = (SAPbobsCOM.Recordset)GlobalVariables.goSAPCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); //GetObjectKeyBySingleValue(SAPbobsCOM.BoObjectTypes.oChartOfAccounts, "AcctCode", "", SAPbobsCOM.BoQueryConditions.bqc_Like);

            _oRecordSet.DoQuery("SELECT T0.[CardCode], T0.[CardName], "
                                    + " T0.[DocDate], T0.[DocDueDate], "
                                    + " T0.[DocNum], T0.[DocTotal], "
                                    + " T0.[DocEntry] [Payment#], T0.[DocDate] [Payment Date], '' ,'',T0.DocEntry,"
                                    + " T0.[CashAcct],T0.[CashSum], T0.[CashSumFC],"
                                    + " T0.[CheckAcct],T0.[CheckSum], T0.[CheckSumFC],"
                                    + "  T0.[CreditSum], T0.[CredSumFC],"
                                    + " T0.[TrsfrAcct], T0.[TrsfrSum], T0.[TrsfrSumFC],T0.[TrsfrRef]"
                                    + " FROM ORCT T0 where T0.U_Event_ID='" + pEventID + "'");// order by T2.[DocNum]  ");

            //_oRecordSet.DoQuery("SELECT T2.[CardCode], T2.[CardName], "
            //                        + " T2.[DocDate], T2.[DocDueDate], "
            //                        + " T2.[DocNum], T2.[DocTotal], "
            //                        + " T1.[DocEntry] [Payment#], T0.[DocDate] [Payment Date], T1.[SumApplied] [Paid Amount] ,T1.InvoiceId,T1.DocEntry,"
            //                        + " T0.[CashAcct],T0.[CashSum], T0.[CashSumFC],"
            //                        + " T0.[CheckAcct],T0.[CheckSum], T0.[CheckSumFC],"
            //                        + "  T0.[CreditSum], T0.[CredSumFC],"
            //                        + " T0.[TrsfrAcct], T0.[TrsfrSum], T0.[TrsfrSumFC],T0.[TrsfrRef]"
            //                        + " FROM ORCT T0  INNER JOIN RCT2 T1 ON T0.DocEntry = T1.DocNum "
            //                        + " inner join OINV T2 on T1.[DocEntry] = T2.DocEntry where T0.U_Event_ID='" + pEventID + "'");// order by T2.[DocNum]  ");


            DataTable _payments = new DataTable("Payments");

            _payments.Columns.Add("CardCode", typeof(string));
            _payments.Columns.Add("CardName", typeof(string));
            _payments.Columns.Add("DocDate", typeof(string));
            _payments.Columns.Add("DocDueDate", typeof(string));
            _payments.Columns.Add("DocNum", typeof(string));
            _payments.Columns.Add("DocTotal", typeof(string));
            _payments.Columns.Add("PaymentNum", typeof(string));
            _payments.Columns.Add("PaymentDate", typeof(string));
            _payments.Columns.Add("PaidAmount", typeof(string));
            _payments.Columns.Add("InvoiceId", typeof(string));
            _payments.Columns.Add("ReferenceInvoiceId", typeof(string));

            _payments.Columns.Add("CashAcct", typeof(string));
            _payments.Columns.Add("CashSum", typeof(string));
            _payments.Columns.Add("CashSumFC", typeof(string));
            _payments.Columns.Add("CheckAcct", typeof(string));
            _payments.Columns.Add("CheckSum", typeof(string));
            _payments.Columns.Add("CheckSumFC", typeof(string));
            _payments.Columns.Add("CreditSum", typeof(string));
            _payments.Columns.Add("CredSumFC", typeof(string));
            _payments.Columns.Add("TrsfrAcct", typeof(string));
            _payments.Columns.Add("TrsfrSum", typeof(string));
            _payments.Columns.Add("TrsfrSumFC", typeof(string));
            _payments.Columns.Add("TrsfrRef", typeof(string));

            while (!_oRecordSet.EoF)
            {
                DataRow _row = _payments.NewRow();
                _row["CardCode"] = _oRecordSet.Fields.Item(0).Value.ToString();
                _row["CardName"] = _oRecordSet.Fields.Item(1).Value.ToString();
                _row["DocDate"] = _oRecordSet.Fields.Item(2).Value.ToString();
                _row["DocDueDate"] = _oRecordSet.Fields.Item(3).Value.ToString();
                _row["DocNum"] = _oRecordSet.Fields.Item(4).Value.ToString();
                _row["DocTotal"] = _oRecordSet.Fields.Item(5).Value.ToString();
                _row["PaymentNum"] = _oRecordSet.Fields.Item(6).Value.ToString();
                _row["PaymentDate"] = _oRecordSet.Fields.Item(7).Value.ToString();
                _row["PaidAmount"] = _oRecordSet.Fields.Item(8).Value.ToString();
                _row["InvoiceId"] = _oRecordSet.Fields.Item(9).Value.ToString();
                _row["ReferenceInvoiceId"] = _oRecordSet.Fields.Item(10).Value.ToString();


                _row["CashAcct"] = _oRecordSet.Fields.Item(11).Value.ToString();
                _row["CashSum"] = _oRecordSet.Fields.Item(12).Value.ToString();
                _row["CashSumFC"] = _oRecordSet.Fields.Item(13).Value.ToString();
                _row["CheckAcct"] = _oRecordSet.Fields.Item(14).Value.ToString();
                _row["CheckSum"] = _oRecordSet.Fields.Item(15).Value.ToString();
                _row["CheckSumFC"] = _oRecordSet.Fields.Item(16).Value.ToString();
                _row["CreditSum"] = _oRecordSet.Fields.Item(17).Value.ToString();
                _row["CredSumFC"] = _oRecordSet.Fields.Item(18).Value.ToString();
                _row["TrsfrAcct"] = _oRecordSet.Fields.Item(19).Value.ToString();
                _row["TrsfrSum"] = _oRecordSet.Fields.Item(20).Value.ToString();
                _row["TrsfrSumFC"] = _oRecordSet.Fields.Item(21).Value.ToString();
                _row["TrsfrRef"] = _oRecordSet.Fields.Item(22).Value.ToString();
               
                //DataRow _row = _oGLAccounts.NewRow();
                //_oChartOfAccounts.GetByKey(_oRecordSet.Fields.Item(0).Value.ToString());
                //_row["GLACCOUNT"] = _oChartOfAccounts.Code;
                //_row["DESCRIPTION"] = _oChartOfAccounts.Name;
                _payments.Rows.Add(_row);
                _oRecordSet.MoveNext();
            }
            return _payments;
        }

        public DataTable getAllGLAccounts()
        {

            DataTable _dtResult = new DataTable();
            SAPbobsCOM.Recordset _oRecordSet = (SAPbobsCOM.Recordset)GlobalVariables.goSAPCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); //GetObjectKeyBySingleValue(SAPbobsCOM.BoObjectTypes.oChartOfAccounts, "AcctCode", "", SAPbobsCOM.BoQueryConditions.bqc_Like);

            _oRecordSet.DoQuery("SELECT * FROM OACT");// order by T2.[DocNum]  ");

            DataTable _payments = new DataTable("Payments");

            _payments.Columns.Add("AcctCode", typeof(string));
            _payments.Columns.Add("AcctName", typeof(string));

            while (!_oRecordSet.EoF)
            {
                DataRow _row = _payments.NewRow();
                _row["AcctCode"] = _oRecordSet.Fields.Item(0).Value.ToString();
                _row["AcctName"] = _oRecordSet.Fields.Item(1).Value.ToString();
            
               

                //DataRow _row = _oGLAccounts.NewRow();
                //_oChartOfAccounts.GetByKey(_oRecordSet.Fields.Item(0).Value.ToString());
                //_row["GLACCOUNT"] = _oChartOfAccounts.Code;
                //_row["DESCRIPTION"] = _oChartOfAccounts.Name;
                _payments.Rows.Add(_row);
                _oRecordSet.MoveNext();
            }
            return _payments;
        }



    }
}
