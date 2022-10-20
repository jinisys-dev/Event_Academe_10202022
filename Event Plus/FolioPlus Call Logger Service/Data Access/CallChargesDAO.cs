
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using MySql.Data.MySqlClient;

using System.Threading;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using Jinisys.FolioPlusCallLogger.BusinessLayer;
using System.Configuration;

namespace Jinisys.FolioPlusCallLogger.DataAccessLayer
{
    public class CallChargesDAO : IDisposable
    {

        public CallChargesDAO()
        {
        }

        private MySqlConnection localConnection;
        public CallChargesDAO(MySqlConnection connection)
        {
            localConnection = connection;
        }

        private CallCharge oCallCharge;
        public CallCharge GetCallCharges()
        {
            try
            {
                oCallCharge = new CallCharge();
                MySqlCommand cmd = new MySqlCommand("call spGetCalls()", localConnection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(oCallCharge, "Calls");

                return oCallCharge;

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Folio Plus Call Logger", "@GetCallCharges() " + ex.Message + "\r\n " + DateTime.Now);
                return null;
            }
        }

        public int InsertCallCharges(CallCharge oCallCharge)
        {
            /* this is to test whether oCallCharge has records needed to 
             * be posted at Folio Plus...
             */
			DataTable dtTest = new DataTable();
            try
            {
                dtTest = oCallCharge.Tables[0];
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Folio Plus Call Logger", "@InsertCallCharges() Table is empty." + ex.Message + "\r\n" + DateTime.Now);
                return 0;
            }


			foreach (DataRow dtRow in dtTest.Rows)
            {
                MySqlTransaction myTrans = localConnection.BeginTransaction();
                try
                {
                    PostToFolioTransaction(dtRow, ref myTrans);

                    myTrans.Commit();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Folio Plus Call Logger", "@InsertCallCharges()" + ex.Message + "\r\n" + DateTime.Now);
                    myTrans.Rollback();
                }
            }
            return 0;
        }

        private Company oCompany;
        private Folio oFolio;
        private CompanyFacade oCompanyFacade;
        private FolioFacade oFolioFacade;
        private Folio GetFolioInfo(string folioId)
        {
            try
            {
                oFolio = new Folio();
                GlobalVariables.gPersistentConnection = localConnection;
                oFolioFacade = new FolioFacade();
                oFolio = oFolioFacade.GetFolio(folioId);

                switch (oFolio.FolioType)
                {
                    case "DEPENDENT":

                        oCompany = new Company();
                        oCompanyFacade = new CompanyFacade();
                        oCompany = oCompanyFacade.getCompanyInfo(oFolio.MasterFolio);

                        oFolio.CompanyID = oCompany.CompanyId;
                        break;
                }

                return oFolio;

            }
            catch (Exception)
            {
            }
            return null;
        }

        private FolioTransactionFacade oFolioTransactionFacade;
        private FolioTransaction oFolioTransaction;
        private FolioTransactions oFolioTransCollection;
        private TransactionCode callTranCode;
		private TransactionCode_SubAccount callTranCodeSubAccount;

        private bool PostToFolioTransaction(DataRow dtRow, ref MySqlTransaction myTrans)
        {
            MySqlCommand updateCommand = null;

            GlobalVariables.gPersistentConnection = localConnection;

            string localNumber = dtRow["extension"].ToString();

            MySqlCommand folioCommand = new MySqlCommand("call spGetFolioToCharge('" + localNumber + "','1')", localConnection);
            folioCommand.Transaction = myTrans;
            object fId = folioCommand.ExecuteScalar();

            if (fId == null)
            {
                // updates all Logs that have no Folio associated with it as POSTED..
                updateCommand = new MySqlCommand("call spUpdateLog(" + dtRow["CallNumber"].ToString() + ")", localConnection);
                updateCommand.Transaction = myTrans;
                updateCommand.ExecuteNonQuery();
                return true;
            }

            string folioId = fId.ToString();
            oFolio = GetFolioInfo(folioId);

            callTranCode = GetCallTranCode(dtRow["CallType"].ToString());

			oFolioTransaction = new FolioTransaction();
            AssignFolioTransValues(oFolioTransaction, dtRow, oFolio);

            oFolioTransCollection = new FolioTransactions();
            ApplyPackage(oFolioTransaction, dtRow);

            ApplyRouting(oFolioTransaction, oFolio);

            ApplyPrivileges(oFolioTransaction);

            // > saves in database
            if (oFolioTransCollection.Count == 0)
            {
                oFolioTransCollection.Add(oFolioTransaction);
            }

            // > saves in database
			//EventLog.WriteEntry("Posting " + oFolioTransCollection.Count + " trans to Folio " + oFolio.FolioID, "Call Logger Service stopped at " + DateTime.Now);

            oFolioTransactionFacade = new FolioTransactionFacade();
            oFolioTransactionFacade.InsertFolioTransaction(oFolioTransCollection, ref myTrans);


            // ============================================================================================

            // >> UPDATE LOGS in CALLMGTSYSTEM
            updateCommand = new MySqlCommand("call spUpdateLog(" + dtRow["CallNumber"].ToString() + ")", localConnection);
            updateCommand.Transaction = myTrans;
            updateCommand.ExecuteNonQuery();

            return true;
        }

		private void AssignFolioTransValues(FolioTransaction poFolioTransaction, DataRow dtRow, Folio oGuestFolio)
        {
            try
            {

                bool _inclusiveGovTax = true;
                bool _inclusiveLocalTax = true;
                bool _inclusiveServiceCharge = true;

                decimal _govtTaxPercent = 0;
                decimal _localTaxPercent = 0;
                decimal _serviceChargePercent = 0;

                decimal _govtTaxAmount = 0;
                decimal _localTaxAmount = 0;
                decimal _serviceChargeAmount = 0;


                poFolioTransaction.HotelID = GlobalVariables.gHotelId;
                poFolioTransaction.TransactionDate = DateTime.Now;
                poFolioTransaction.FolioID = oGuestFolio.FolioID;
                poFolioTransaction.SubFolio = "A";
                poFolioTransaction.AccountID = oGuestFolio.AccountID;

                poFolioTransaction.TransactionCode = callTranCode.TranCode;
                poFolioTransaction.ReferenceNo = dtRow["CallNumber"].ToString();

                //TransactionSourceDocument transSourc = (TransactionSourceDocument)this.cboTransSource.SelectedItem;
                poFolioTransaction.TransactionSource = callTranCode.DefaultTransactionSource;

           
                //sample Memo: Telephone Charge - IDD/NDD (0322599391 11:03:00)
                string _memo = callTranCode.Memo;
                if (callTranCodeSubAccount != null)
                {
                    _memo += " - " + callTranCodeSubAccount.SubAccountCode;
                }
                _memo += "(" + dtRow["Digits"].ToString() + "  " + dtRow["CallTime"].ToString() + ")";


                poFolioTransaction.Memo = _memo;
               
           

                poFolioTransaction.AcctSide = callTranCode.AcctSide;
                poFolioTransaction.CurrencyCode = "Php";
                poFolioTransaction.ConversionRate = 1;
                poFolioTransaction.CurrencyAmount = decimal.Parse(dtRow["cost"].ToString());

                poFolioTransaction.Discount = 0;

                // BaseAmount = Currency Amount * Exchange Rate
                decimal _baseAmount = poFolioTransaction.CurrencyAmount * poFolioTransaction.ConversionRate;

                poFolioTransaction.BaseAmount = _baseAmount;
                poFolioTransaction.GrossAmount = _baseAmount;


                // deduct discount b4 applying Tax & Service Charge
                _baseAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount;



                //// if has SubAccount use SubAccount settings for Govt Tax
                //// else use TransactionCode settings for Govt Tax
                if (callTranCodeSubAccount == null)
                {
                    _inclusiveGovTax = callTranCode.GovtTaxInclusive == 1 ? true : false;
                    _inclusiveLocalTax = callTranCode.LocalTaxInclusive == 1 ? true : false;
                    _inclusiveServiceCharge = callTranCode.ServiceChargeInclusive == 1 ? true : false;

                    _govtTaxPercent = callTranCode.GovtTax / 100;
                    _localTaxPercent = callTranCode.LocalTax / 100;
                    _serviceChargePercent = callTranCode.ServiceCharge / 100;

                }
                else
                {
                    _inclusiveGovTax = callTranCodeSubAccount.GovernmentTaxInclusive == 1 ? true : false;
                    _inclusiveLocalTax = callTranCodeSubAccount.LocalTaxInclusive == 1 ? true : false;
                    _inclusiveServiceCharge = callTranCodeSubAccount.ServiceChargeInclusive == 1 ? true : false;

                    _govtTaxPercent = callTranCodeSubAccount.GovernmentTax / 100;
                    _localTaxPercent = callTranCodeSubAccount.LocalTax / 100;
                    _serviceChargePercent = callTranCodeSubAccount.ServiceCharge / 100;
                }

                //>> get Total Inclusive Charges
                decimal _totalInclusive = 0;
                if (_inclusiveGovTax)
                {
                    _totalInclusive += _govtTaxPercent;
                }

                if (_inclusiveLocalTax)
                {
                    _totalInclusive += _localTaxPercent;
                }

                if (_inclusiveServiceCharge)
                {
                    _totalInclusive += _serviceChargePercent;
                }
                //>> end get Total Inclusive Charges

                decimal _amountAfterDeductInclusiveCharges = _baseAmount / (1 + _totalInclusive);

                //>> compute Government Tax
                if (_govtTaxPercent > 0)
                {
                    if (_inclusiveGovTax)
                    {
                        _govtTaxAmount = _amountAfterDeductInclusiveCharges * _govtTaxPercent;
                    }
                    else
                    {
                        _govtTaxAmount = _baseAmount * _govtTaxPercent;
                    }
                }
                //>> end compute Government Tax

                //>> compute Local Tax
                if (_localTaxPercent > 0)
                {
                    if (_inclusiveLocalTax)
                    {
                        _localTaxAmount = _amountAfterDeductInclusiveCharges * _localTaxPercent;
                    }
                    else
                    {
                        _localTaxAmount = _baseAmount * _localTaxPercent;
                    }
                }
                //>> end compute Local Tax


                //>> compute Service Charge
                if (_serviceChargePercent > 0)
                {
                    if (_inclusiveServiceCharge)
                    {
                        _serviceChargeAmount = _amountAfterDeductInclusiveCharges * _serviceChargePercent;
                    }
                    else
                    {
                        _serviceChargeAmount = _baseAmount * _serviceChargePercent;
                    }
                }
                //>> end compute Service Charge


                poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

                poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount;

                poFolioTransaction.NetBaseAmount = _amountAfterDeductInclusiveCharges;
                poFolioTransaction.GovernmentTax = _govtTaxAmount;
                poFolioTransaction.LocalTax = _localTaxAmount;
                poFolioTransaction.ServiceCharge = _serviceChargeAmount;

                poFolioTransaction.GovernmentTaxInclusive = _inclusiveGovTax == true ? 1 : 0;
                poFolioTransaction.LocalTaxInclusive = _inclusiveLocalTax == true ? 1 : 0;
                poFolioTransaction.ServiceChargeInclusive = _inclusiveServiceCharge == true ? 1 : 0;

                // deduct Meal Amount on NetBaseAmount
                poFolioTransaction.MealAmount = 0;
                poFolioTransaction.NetBaseAmount -= poFolioTransaction.MealAmount;



                poFolioTransaction.RouteSequence = "";
                poFolioTransaction.SourceFolio = "";
                poFolioTransaction.SourceSubFolio = "";
                poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
                poFolioTransaction.CreatedBy = GlobalVariables.gLoggedOnUser;

                // new, Jrom, April 26, 2008
                // Golden prince requirement

                poFolioTransaction.CreditCardNo = "";
                poFolioTransaction.ChequeNo = "";
                poFolioTransaction.AccountName = "";
                poFolioTransaction.BankName = "";
                poFolioTransaction.ChequeDate = "2001-01-01";
                poFolioTransaction.FOCGrantedBy = "";

                poFolioTransaction.CreditCardType = "";
                poFolioTransaction.ApprovalSlip = "";
                poFolioTransaction.SubAccount = "";
                poFolioTransaction.CreditCardExpiry = "2001-01-01";

                poFolioTransaction.AdjustmentFlag = "0";

            }
            catch (Exception ex)
            {
                throw new Exception("Error @ AssignFolioTransValues: Error Message: " + ex.Message);
            }

        }

        // >> APPLY PACKAGE
        private FolioPackage oPackage;
        private void ApplyPackage(FolioTransaction oFolioTrans, DataRow dtRow)
        {
            try
            {
                Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gPersistentConnection = localConnection;


                oFolioFacade = new FolioFacade();
                oPackage = new FolioPackage();
                oPackage = oFolioFacade.GetFolioTransPackage(oFolioTrans.FolioID, oFolioTrans.TransactionCode);

                if (oPackage != null)
                {
                    FolioTransaction with_1 = oFolioTrans;
                    with_1.BaseAmount = System.Convert.ToDecimal(dtRow["cost"]);

                    if (oPackage.Basis == "A")
                    {
                        oFolioTrans.Discount = oPackage.AmountOff;
                    }
                    else
                    {
                        oFolioTrans.Discount = with_1.BaseAmount * oPackage.PercentOff;
                    }

                    with_1.BaseAmount = with_1.BaseAmount - with_1.Discount;

                    with_1.GovernmentTax = System.Convert.ToDecimal(callTranCode.GovtTax);
                    if (System.Convert.ToDouble(with_1.GovernmentTax) > 0.0)
                    {
                        with_1.GovernmentTax = System.Convert.ToDecimal(ComputeTaxSrvCharge(System.Convert.ToDouble(with_1.BaseAmount), System.Convert.ToDouble(with_1.GovernmentTax)));
                    }

                    with_1.LocalTax = System.Convert.ToDecimal(callTranCode.LocalTax);
                    if (System.Convert.ToDouble(with_1.LocalTax) > 0.0)
                    {
                        with_1.LocalTax = System.Convert.ToDecimal(ComputeTaxSrvCharge(System.Convert.ToDouble(with_1.BaseAmount - with_1.GovernmentTax), System.Convert.ToDouble(with_1.LocalTax)));
                    }

                    with_1.ServiceCharge = System.Convert.ToDecimal(callTranCode.ServiceCharge);
                    if (System.Convert.ToDouble(with_1.ServiceCharge) > 0.0)
                    {
                        with_1.ServiceCharge = System.Convert.ToDecimal(ComputeTaxSrvCharge(System.Convert.ToDouble(with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax), System.Convert.ToDouble(with_1.ServiceCharge)));
                    }

                    with_1.NetBaseAmount = with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax - with_1.ServiceCharge;

                }
            }
            catch (Exception)
            {
                //MsgBox("No Package was applied..")
            }
        }

        private FolioRoutingCollection oFolioRoutingCollection;

        private void ApplyRouting(FolioTransaction oFTrans, Folio oFolio)
        {
            oFolioRoutingCollection = new FolioRoutingCollection();
            oFolioRoutingCollection = oFolioFacade.GetFolioTransRouting(oFTrans.FolioID, oFTrans.TransactionCode);

            // >> this is used in Routing
            decimal originalAmountForRouting = oFTrans.BaseAmount;

            FolioRouting oRouting;
            foreach (FolioRouting tempLoopVar_oRouting in oFolioRoutingCollection)
            {
                oRouting = tempLoopVar_oRouting;
                if (oRouting.PercentCharged > 0 || oRouting.AmountCharged > 0)
                {

                    FolioTransaction oFolioTrans = new FolioTransaction();
                    oFolioTrans.HotelID = oFTrans.HotelID;
                    oFolioTrans.FolioID = oFolio.FolioID;
                    oFolioTrans.AccountID = oFolio.AccountID;
                    oFolioTrans.TransactionCode = oFTrans.TransactionCode;
                    oFolioTrans.ReferenceNo = oFTrans.ReferenceNo;
                    oFolioTrans.TransactionSource = "AUTO-POST";
                    oFolioTrans.Memo = oFTrans.Memo;
                    oFolioTrans.AcctSide = oFTrans.AcctSide;
                    oFolioTrans.CurrencyCode = oFTrans.CurrencyCode;
                    oFolioTrans.ConversionRate = oFTrans.ConversionRate;
                    oFolioTrans.CurrencyAmount = oFTrans.CurrencyAmount;
                    oFolioTrans.BaseAmount = oFTrans.BaseAmount;
                    oFolioTrans.Discount = oFTrans.Discount;

                    oFolioTrans.GovernmentTax = oFTrans.GovernmentTax;
                    oFolioTrans.LocalTax = oFTrans.LocalTax;
                    oFolioTrans.ServiceCharge = oFTrans.ServiceCharge;

                    oFolioTrans.NetBaseAmount = oFTrans.NetBaseAmount;
                    oFolioTrans.TerminalID = oFTrans.TerminalID;
                    oFolioTrans.CreatedBy = oFTrans.CreatedBy;


                    if (oRouting.PercentCharged > 0)
                    {
                        oFolioTrans.CurrencyAmount = oFolioTrans.CurrencyAmount * (oRouting.PercentCharged / 100);
                        oFolioTrans.BaseAmount = oFolioTrans.BaseAmount * (oRouting.PercentCharged / 100);

                        oFolioTrans.GovernmentTax = oFolioTrans.GovernmentTax * (oRouting.PercentCharged / 100);
                        oFolioTrans.LocalTax = oFolioTrans.LocalTax * (oRouting.PercentCharged / 100);
                        oFolioTrans.ServiceCharge = oFolioTrans.ServiceCharge * (oRouting.PercentCharged / 100);
                        oFolioTrans.NetBaseAmount = oFolioTrans.NetBaseAmount * (oRouting.PercentCharged / 100);
                    }
                    else
                    {
                        // checks if amount is > originalAmountForRouting 
                        if (originalAmountForRouting > oRouting.AmountCharged)
                        {
                            originalAmountForRouting -= oRouting.AmountCharged;
                        }
                        else
                        {
                            oRouting.AmountCharged = originalAmountForRouting;
                            originalAmountForRouting = 0;
                        }

                        oFolioTrans.CurrencyAmount = oRouting.AmountCharged;
                        oFolioTrans.BaseAmount = oRouting.AmountCharged;
                        oFolioTrans.GovernmentTax = (decimal)ComputeTaxSrvCharge((double)oRouting.AmountCharged, (double)oTranCode.GovtTax);
                        oFolioTrans.LocalTax = (decimal)ComputeTaxSrvCharge((double)oRouting.AmountCharged, (double)oTranCode.LocalTax);
                        oFolioTrans.ServiceCharge = (decimal)ComputeTaxSrvCharge((double)oRouting.AmountCharged, (double)oTranCode.ServiceCharge);
                        oFolioTrans.NetBaseAmount = oRouting.AmountCharged - (oFolioTrans.GovernmentTax + oFolioTrans.LocalTax + oFolioTrans.ServiceCharge);
                    }


                    // KUNG NAA CYA MASTER FOLIO(DEPENDENT CYA) DERITSO SA 
                    // IYA MASTER FOLIO ANG TRANSACTION SA 
                    // SUB-FOLIO B., IF INDEPENDENT THEN NAA CYA 
                    // SUB-FOLIO B TRANS, IYAHA GHAPON ANG
                    // TRANSACTION PERO, SA SUB-FOLIO B.
                    oFolioTrans.SubFolio = oRouting.SubFolio;
                    if (oFolioTrans.SubFolio == "B")
                    {
                        oFolioTrans.AccountID = (oFolio.CompanyID == "") ? oFolio.AccountID : oFolio.CompanyID;
                        oFolioTrans.FolioID = (oFolio.MasterFolio == "") ? oFolio.FolioID : oFolio.MasterFolio;
                        oFolioTrans.SubFolio = (oFolio.MasterFolio == "") ? "B" : "A";
                        oFolioTrans.SourceFolio = oFolio.FolioID;
                        //oFolioTrans.SourceSubFolio = "B";
                        oFolioTrans.Discount = oFolioTrans.Discount;
                    }
                    else
                    {
                        oFolioTrans.AccountID = oFolio.AccountID;
                        if (oFolio.MasterFolio != "")
                        {
                            oFolioTrans.Discount = 0;
                        }
                        else
                        {
                            oFolioTrans.Discount = oFolioTrans.Discount;
                        }
                    }

                    oFolioTransCollection.Add(oFolioTrans);

                }
            }
        }

        private void ApplyPrivileges(FolioTransaction oFolioTrans)
        {
            try
            {
                Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gPersistentConnection = localConnection;

                oFolioFacade = new FolioFacade();

                if (oFolioTransCollection.Count == 0)
                {
                    oFolioTransCollection.Add(oFolioTrans);
                }

                FolioTransaction fTrans;
                foreach (FolioTransaction tempLoopVar_fTrans in oFolioTransCollection)
                {
                    fTrans = tempLoopVar_fTrans;

                    DataRow dtPrivileges = oFolioFacade.GetFolioTransPrivilege(ref fTrans);

                    if (dtPrivileges != null)
                    {
                        double disc;
                        if ((string)dtPrivileges["Basis"] == "A")
                        {
                            disc = System.Convert.ToDouble(dtPrivileges["AmountOff"]);
                        }
                        else
                        {
                            disc = System.Convert.ToDouble(fTrans.BaseAmount * System.Convert.ToDecimal(dtPrivileges["PercentOff"].ToString()));
                        }

                        fTrans.BaseAmount = System.Convert.ToDecimal(System.Convert.ToDouble(fTrans.BaseAmount) - disc);
                        fTrans.Discount = System.Convert.ToDecimal(System.Convert.ToDouble(fTrans.Discount) + disc);

                        fTrans.GovernmentTax = System.Convert.ToDecimal(callTranCode.GovtTax);
                        if (System.Convert.ToDouble(fTrans.GovernmentTax) > 0.0)
                        {
                            fTrans.GovernmentTax = System.Convert.ToDecimal(ComputeTaxSrvCharge(System.Convert.ToDouble(fTrans.BaseAmount), System.Convert.ToDouble(fTrans.GovernmentTax)));
                        }

                        fTrans.LocalTax = System.Convert.ToDecimal(callTranCode.LocalTax);
                        if (System.Convert.ToDouble(fTrans.LocalTax) > 0.0)
                        {
                            fTrans.LocalTax = System.Convert.ToDecimal(ComputeTaxSrvCharge(System.Convert.ToDouble(fTrans.BaseAmount - fTrans.GovernmentTax), System.Convert.ToDouble(fTrans.LocalTax)));
                        }

                        fTrans.ServiceCharge = System.Convert.ToDecimal(callTranCode.ServiceCharge);
                        if (System.Convert.ToDouble(fTrans.ServiceCharge) > 0.0)
                        {
                            fTrans.ServiceCharge = System.Convert.ToDecimal(ComputeTaxSrvCharge(System.Convert.ToDouble(fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax), System.Convert.ToDouble(fTrans.ServiceCharge)));
                        }

                        fTrans.NetBaseAmount = fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax - fTrans.ServiceCharge;

                    }
                }

            }
            catch (Exception)
            {
                //MsgBox("No Privilege was applied..")
            }
        }

        private double ComputeTaxSrvCharge(double BaseAmount, double Tax)
        {
            double TaxAmount;

            TaxAmount = BaseAmount - (BaseAmount / (1 + Tax));
            //TaxAmount = BaseAmount * Tax;

            return TaxAmount;
        }

        private TransactionCode oTranCode;
        public TransactionCode GetCallTranCode(string trans)
        {
            try
            {
				string _localCallTranCode = ConfigurationManager.AppSettings.Get("TranCodeLocalCall");
				string _nddCallTranCode = ConfigurationManager.AppSettings.Get("TranCodeNDDCall");
				string _iddCallTranCode = ConfigurationManager.AppSettings.Get("TranCodeIDDCall");

				string _localCallTranCodeSubAccount = ConfigurationManager.AppSettings.Get("TranCodeLocalCallSubAccount");
				string _nddCallTranCodeSubAccount = ConfigurationManager.AppSettings.Get("TranCodeNDDCallSubAccount");
				string _iddCallTranCodeSubAccount = ConfigurationManager.AppSettings.Get("TranCodeIDDCallSubAccount");


				TransactionCodeFacade oTranCodeFacade = new TransactionCodeFacade();
				TransactionCode_SubAccountFacade oTranCodeSubAccountFacade = new TransactionCode_SubAccountFacade();
                oTranCode = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode();

				
                MySqlDataAdapter dataAdapter = null;
                switch (trans.ToUpper())
                {
                    case "LOCAL":

                        //dataAdapter = new MySqlDataAdapter("call spGetTranCodeLocalCall('1')", localConnection);
						oTranCode = oTranCodeFacade.getTransactionCode(_localCallTranCode);

						try
						{
							callTranCodeSubAccount = oTranCodeSubAccountFacade.getTransactionSubAccount(_localCallTranCode, _localCallTranCodeSubAccount);
						}
						catch
						{ }

                        break;
                    case "NDD":

                        //dataAdapter = new MySqlDataAdapter("call spGetTranCodeNDDCall('1')", localConnection);
						oTranCode = oTranCodeFacade.getTransactionCode(_nddCallTranCode);

						try
						{
							callTranCodeSubAccount = oTranCodeSubAccountFacade.getTransactionSubAccount(_localCallTranCode, _nddCallTranCodeSubAccount);
						}
						catch
						{ }

                        break;
                    case "IDD":

                        //dataAdapter = new MySqlDataAdapter("call spGetTranCodeLongDistanceCall('1')", localConnection);
						oTranCode = oTranCodeFacade.getTransactionCode(_iddCallTranCode);
						
						try
						{
							callTranCodeSubAccount = oTranCodeSubAccountFacade.getTransactionSubAccount(_localCallTranCode, _iddCallTranCodeSubAccount);
						}
						catch
						{ }

                        break;
                }

                //dataAdapter.Fill(oTranCode, "TranCode");
                //dataAdapter.Dispose();

				//oTranCode.TranCode = oTranCode.Tables[0].Rows[0]["TranCode"].ToString();
				//oTranCode.TranTypeId = oTranCode.Tables[0].Rows[0]["TranTypeId"].ToString();
				////oTranCode.AcctGroupId = oTranCode.Tables[0].Rows[0]["AcctGroupId"].ToString();
				//oTranCode.Memo = oTranCode.Tables[0].Rows[0]["Memo"].ToString();
				//oTranCode.AcctSide = oTranCode.Tables[0].Rows[0]["AcctSide"].ToString();
				//oTranCode.ServiceCharge = decimal.Parse(oTranCode.Tables[0].Rows[0]["ServiceCharge"].ToString());
				//oTranCode.GovtTax = decimal.Parse(oTranCode.Tables[0].Rows[0]["GovtTax"].ToString());
				//oTranCode.LocalTax = decimal.Parse(oTranCode.Tables[0].Rows[0]["LocalTax"].ToString());

                return oTranCode;
				
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Folio Plus Call Logger", "EXCEPTION: @ GetCallTranCode() " + ex.Message + "\r\n" + DateTime.Now);
                return null;
            }

        }

        #region "iDisposable"
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                localConnection = null;
            }
            // Free your own state (unmanaged objects).
            // Set large fields to null.
        }

        ~CallChargesDAO()
        {
            // Simply call Dispose(False).
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}