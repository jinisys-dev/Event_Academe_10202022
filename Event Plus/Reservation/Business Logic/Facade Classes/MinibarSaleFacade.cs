
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
   
        public class MinibarSaleFacade
        {
			MinibarSaleDAO oMinibarSaleDAO;
            public bool saveMinibarSale(MinibarSale poSale, bool isFolioPlusIntegrated)
            {

				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				oMinibarSaleDAO = new MinibarSaleDAO();

				try
				{
					oMinibarSaleDAO.Save(poSale, ref trans);

                    string _itemsConsumedDescription = "";
                    foreach(MinibarSalesDetail oDetail in poSale.Details)
                    {
                        _itemsConsumedDescription += oDetail.Qty + " " + oDetail.Item_Description + ", ";
                    }
                    //remove last <comma>
                    _itemsConsumedDescription = _itemsConsumedDescription.Substring(0, _itemsConsumedDescription.Length - 2);                    _itemsConsumedDescription = _itemsConsumedDescription.ToUpper();


					//return salesDAO.Save(poSale);
					if (isFolioPlusIntegrated)
					{
						// create FolioTransactionHere
						createMinibarFolioTransactionAndPost(poSale,_itemsConsumedDescription, poSale.HouseKeeper_Name, ref trans);
					}

					trans.Commit();

					return true;
				}
				catch(Exception ex)
				{
                    trans.Rollback();
					throw ex;
				}

            }

            public DataSet getSales(DateTime from, DateTime to)
            {
				oMinibarSaleDAO = new MinibarSaleDAO();
                return oMinibarSaleDAO.getSales(from, to);
            }
            public bool checkPinCode(String pincode)
            {
				oMinibarSaleDAO = new MinibarSaleDAO();
                return oMinibarSaleDAO.checkPinCode(pincode);
            }
            public bool voidSaleDetail(int transId)
            {
				oMinibarSaleDAO = new MinibarSaleDAO();
                return oMinibarSaleDAO.voidSaleDetail(transId);
            }
            public bool voidSales(int salesID)
            {
				oMinibarSaleDAO = new MinibarSaleDAO();
                return oMinibarSaleDAO.voidSales(salesID);
            }

			public void createMinibarFolioTransactionAndPost(MinibarSale poMinibarSale,string pItemsDescription,string pHousekeeperName, ref MySqlTransaction oDBTrans)
			{
				MinibarSaleDAO oMinibarSalesDAO = new MinibarSaleDAO();

				FolioTransaction oFolioTransaction = new FolioTransaction();
				FolioTransactions oFolioTransCollection = new FolioTransactions();
				FolioFacade oFolioFacade = new FolioFacade();

				string _folioId = "";
				Folio oFolio = new Folio();

				try
				{

					_folioId = oMinibarSalesDAO.getFolioIdByRoomOccupied( poMinibarSale.Room_Id );

					oFolio = oFolioFacade.GetFolio( _folioId );

				}
				catch(Exception ex)
				{
					throw ex;
				}

				//>> get MinibarSale Transaction Code
				string _strTranCode = "";
				TransactionCode _oMinibarTranCode = new TransactionCode();
				TransactionCodeFacade oTransactionCodeFacade = new TransactionCodeFacade();

                try
                {
                    _strTranCode = ConfigVariables.gMinibarSaleTransactionCode;
                    _oMinibarTranCode = oTransactionCodeFacade.getTransactionCode(_strTranCode);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

				if (oFolio != null)
				{
					decimal _amount = (decimal)poMinibarSale.Amount;

                    //FolioTransactions oFolioTransCollection = new FolioTransactions();
                    //oFolioTransaction = new FolioTransaction();
                    //loTranCode = new TransactionCode();

					//AssignFolioTransValues(oFolioTransaction, oFolio, poMinibarSale.Room_Id, _amount, _oMinibarTranCode, poMinibarSale.Id);
                    AssignFolioTransValues(oFolioTransaction, _strTranCode, oFolio, _amount, _oMinibarTranCode, pHousekeeperName); //oFolio, poMinibarSale.Room_Id, _amount, _oMinibarTranCode, poMinibarSale.Id);

                    oFolioTransaction.Memo += " (" + pItemsDescription + ") ";

					//'ApplyFolioPackage HERE''
					ApplyPackage(oFolioTransaction, _amount, _oMinibarTranCode);

					//' Apply Folio Privilege here''
					ApplyPrivileges(oFolioTransaction, oFolioTransCollection, _oMinibarTranCode);

                    
                    ApplyRouting(oFolio.FolioID, oFolioTransaction, oFolio,ref oFolioTransCollection);

					// > saves in database
					if (oFolioTransCollection.Count <= 0)
					{
						oFolioTransCollection.Add(oFolioTransaction);
						
					}

					try
					{
						foreach (FolioTransaction fTrans in oFolioTransCollection)
						{
							FolioTransactionFacade oFolioTransactionFacade = new FolioTransactionFacade();
							oFolioTransactionFacade.InsertFolioTransaction(fTrans, ref oDBTrans);
						}


						//oDBTrans.Commit();
					}
					catch(Exception ex)
					{
						//oDBTrans.Rollback();
						throw ex;
					}
				}


			}

            private void AssignFolioTransValues(FolioTransaction poFolioTransaction, string pTransactionCode, Folio oFolio, decimal pAmount, TransactionCode _oTranCode, string pHousekeeperName)
            {
                //string _strTransactionCode = this.txtTransactionCode.Text;
                //TransactionCode _oTranCode;
                //_oTranCode = oTransactionCodeFacade.getTransactionCode(pTransactionCode);

                //loTranCode = _oTranCode;

                // set mealAmount if ROOM CHARGE
                decimal _mealAmount = 0;
                
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
                poFolioTransaction.TransactionDate = DateTime.Now;//this.dtpTransactionDate.Value;
                poFolioTransaction.FolioID = oFolio.FolioID;
                poFolioTransaction.SubFolio = "A";//this.cboSubFolio.Text;
                poFolioTransaction.AccountID = oFolio.AccountID;

                poFolioTransaction.TransactionCode = pTransactionCode;
                
                    Sequence _oSequence = new Sequence();
                    //comment if statements if generic auto-sequencing
                    string _refNo = _oSequence.GetSequenceLongId("seq_autopost", pTransactionCode).ToString();
                    if (_refNo == "")
                    {
                        poFolioTransaction.ReferenceNo = _oSequence.GetSequenceLongId("seq_autopost").ToString();
                    }
                    else
                    {
                        poFolioTransaction.ReferenceNo = _refNo;
                    }
                

                //TransactionSourceDocument transSourc = (TransactionSourceDocument)this.cboTransSource.SelectedItem;
                //poFolioTransaction.TransactionSource = transSourc.Abbreviation;
                poFolioTransaction.TransactionSource = _oTranCode.DefaultTransactionSource;

                poFolioTransaction.Memo = "MINIBAR";//this.txtMemo.Text;
                //if (this.pnlSubAccount.Visible)
                //{
                //    poFolioTransaction.Memo += " - " + this.cboSubAccount.Text;
                //}
                //if (cboAcctSide.Text == "CREDIT" && grbPayment.Enabled == true)
                //{
                //    poFolioTransaction.Memo += _additionalMemo;
                //}

                poFolioTransaction.AcctSide = "DEBIT";//this.cboAcctSide.Text;
                poFolioTransaction.CurrencyCode = "PHP";//this.cboCurrencyCode.Text;
                poFolioTransaction.ConversionRate = 1;//decimal.Parse(this.cboCurrencyRate.Text);
                poFolioTransaction.CurrencyAmount = pAmount;//decimal.Parse(this.txtCurAmount.Text);

                poFolioTransaction.Discount = 0;//decimal.Parse(this.txtDiscountAmount.Text);

                // BaseAmount = Currency Amount * Exchange Rate
                decimal _baseAmount = poFolioTransaction.CurrencyAmount * poFolioTransaction.ConversionRate;

                poFolioTransaction.BaseAmount = _baseAmount;
                poFolioTransaction.GrossAmount = pAmount;//decimal.Parse(this.txtBaseAmount.Text);


                // deduct discount b4 applying Tax & Service Charge
                _baseAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount;



                //// if has SubAccount use SubAccount settings for Govt Tax
                //// else use TransactionCode settings for Govt Tax
                //if (lSubAccountSelected == null)
                //{
                    _inclusiveGovTax = _oTranCode.GovtTaxInclusive == 1 ? true : false;
                    _inclusiveLocalTax = _oTranCode.LocalTaxInclusive == 1 ? true : false;
                    _inclusiveServiceCharge = _oTranCode.ServiceChargeInclusive == 1 ? true : false;

                    _govtTaxPercent = _oTranCode.GovtTax / 100;
                    _localTaxPercent = _oTranCode.LocalTax / 100;
                    //_serviceChargePercent = _oTranCode.ServiceCharge / 100;
                    //if (_inclusiveServiceCharge == false)
                    //    _serviceChargePercent = decimal.Parse(txtServiceCharge.Text) / 100;
                    //else
                    //    _serviceChargePercent = _oTranCode.ServiceCharge / 100;

                //}
                //else
                //{
                //    _inclusiveGovTax = lSubAccountSelected.GovernmentTaxInclusive == 1 ? true : false;
                //    _inclusiveLocalTax = lSubAccountSelected.LocalTaxInclusive == 1 ? true : false;
                //    _inclusiveServiceCharge = lSubAccountSelected.ServiceChargeInclusive == 1 ? true : false;

                //    _govtTaxPercent = lSubAccountSelected.GovernmentTax / 100;
                //    _localTaxPercent = lSubAccountSelected.LocalTax / 100;
                //    //_serviceChargePercent = lSubAccountSelected.ServiceCharge / 100;
                //    if (_inclusiveServiceCharge == false)
                //        _serviceChargePercent = decimal.Parse(txtServiceCharge.Text) / 100;
                //    else
                //        _serviceChargePercent = lSubAccountSelected.ServiceCharge / 100;
                //}

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


                //>> compute Service Charge
                if (_serviceChargePercent > 0)
                {
                    if (_inclusiveServiceCharge)
                    {
                        _serviceChargeAmount = _amountAfterDeductInclusiveCharges * _serviceChargePercent;
                    }
                    else
                    {
                        _serviceChargeAmount = poFolioTransaction.BaseAmount * _serviceChargePercent;
                    }
                }
                //>> end compute Service Charge

                //>> compute Government Tax
                if (_govtTaxPercent > 0)
                {
                    if (_inclusiveGovTax)
                    {
                        _govtTaxAmount = _amountAfterDeductInclusiveCharges * _govtTaxPercent;
                    }
                    else
                    {
                        //_govtTaxAmount = _baseAmount * _govtTaxPercent;
                        _govtTaxAmount = (poFolioTransaction.BaseAmount + _serviceChargeAmount - poFolioTransaction.Discount) * _govtTaxPercent;
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
                        //_localTaxAmount = _baseAmount * _localTaxPercent;
                        _localTaxAmount = (poFolioTransaction.BaseAmount + _serviceChargeAmount - poFolioTransaction.Discount) * _localTaxPercent;
                    }
                }
                //>> end compute Local Tax

                poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

                poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount;

                poFolioTransaction.NetBaseAmount = _amountAfterDeductInclusiveCharges;
                poFolioTransaction.GovernmentTax = _govtTaxAmount;
                poFolioTransaction.LocalTax = _localTaxAmount;
                poFolioTransaction.ServiceCharge = _serviceChargeAmount;

                poFolioTransaction.GovernmentTaxInclusive = _inclusiveGovTax == true ? 1 : 0;
                poFolioTransaction.LocalTaxInclusive = _inclusiveLocalTax == true ? 1 : 0;
                poFolioTransaction.ServiceChargeInclusive = _inclusiveServiceCharge == true ? 1 : 0;

                // deduct Meal Amount on NetBaseAmount if folio has meal
                poFolioTransaction.MealAmount = _mealAmount;
                poFolioTransaction.NetBaseAmount -= poFolioTransaction.MealAmount;

                poFolioTransaction.RouteSequence = "";
                poFolioTransaction.SourceFolio = "";
                poFolioTransaction.SourceSubFolio = "";
                poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
                //poFolioTransaction.CreatedBy = GlobalVariables.gLoggedOnUser;
                poFolioTransaction.CreatedBy = pHousekeeperName;

                GlobalVariables.gLoggedOnUser = pHousekeeperName;

                // new, Jrom, April 26, 2008
                // Golden prince requirement

                poFolioTransaction.CreditCardNo = "";//this.txtPayment_CardNo.Text;
                poFolioTransaction.ChequeNo = "";//this.txtPayment_Cheque.Text;
                poFolioTransaction.AccountName = "";//this.txtPayment_Account.Text;
                poFolioTransaction.BankName = "";//this.txtPayment_Bank.Text;
                poFolioTransaction.ChequeDate = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                poFolioTransaction.FOCGrantedBy = "";//this.txtGrantedBy.Text;

                poFolioTransaction.CreditCardType = "";//this.txtCardType.Text;
                poFolioTransaction.ApprovalSlip = "";//this.txtCardApproval.Text;
                poFolioTransaction.SubAccount = "";//this.cboSubAccount.Text;
                poFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

            }


			// >> APPLY PACKAGE
			private FolioPackage oPackage;
			private void ApplyPackage(FolioTransaction poFolioTransaction, decimal Amount, TransactionCode poTransactionCode)
			{
				try
				{
					bool _inclusiveGovTax = true;
					bool _inclusiveLocalTax = true;
					bool _inclusiveServiceCharge = true;


					FolioFacade oFolioFacade = new FolioFacade();
					oPackage = new FolioPackage();
					oPackage = oFolioFacade.GetFolioTransPackage(poFolioTransaction.FolioID, poFolioTransaction.TransactionCode);

					if (oPackage != null)
					{

						//FolioTransaction _oFolioTransaction = poFolioTransaction;
						//_oFolioTransaction.BaseAmount = decimal.Parse(this.txtBaseAmount.Text);

						if (oPackage.Basis == "A")
						{
							poFolioTransaction.Discount += oPackage.AmountOff;
						}
						else
						{
							poFolioTransaction.Discount += poFolioTransaction.NetAmount * (oPackage.PercentOff / 100);
						}

						// BaseAmount = Currency Amount * Exchange Rate
						decimal _baseAmount = poFolioTransaction.BaseAmount;

						poFolioTransaction.BaseAmount = _baseAmount;
						poFolioTransaction.GrossAmount = poFolioTransaction.GrossAmount;


						// deduct discount b4 applying Tax & Service Charge
						_baseAmount = _baseAmount - poFolioTransaction.Discount;

						// compute Government Tax here (Inclusive or Exclusive)
						// if has SubAccount use SubAccount settings for Govt Tax
						// else use TransactionCode settings for Govt Tax

						if (poTransactionCode.GovtTax > 0)
						{
							decimal _govTaxPercent = poTransactionCode.GovtTax;

							decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, poTransactionCode.GovtTaxInclusive);
							poFolioTransaction.GovernmentTax = _govTaxAmount;

							if (poTransactionCode.GovtTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _govTaxAmount;

								_inclusiveGovTax = false;
							}
						}
						else
						{
							poFolioTransaction.GovernmentTax = 0;
						}




						// compute Local Tax here (Inclusive or Exclusive)
						// if has SubAccount use SubAccount settings for Govt Tax
						// else use TransactionCode settings for Local Tax

						if (poTransactionCode.LocalTax > 0)
						{
							decimal _localTaxPercent = (decimal)poTransactionCode.LocalTax;

							decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, poTransactionCode.LocalTaxInclusive);
							poFolioTransaction.LocalTax = _localTaxAmount;

							if (poTransactionCode.LocalTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _localTaxAmount;

								_inclusiveLocalTax = false;
							}
						}
						else
						{
							poFolioTransaction.LocalTax = 0;
						}





						// compute Local Tax here (Inclusive or Exclusive)
						// if has SubAccount use SubAccount settings for Govt Tax
						// else use TransactionCode settings for Local Tax
						_baseAmount = _baseAmount - poFolioTransaction.GovernmentTax - poFolioTransaction.LocalTax;


						if (poTransactionCode.ServiceCharge > 0)
						{
							if (poTransactionCode.ServiceChargeInclusive == 0)
							{
								// SUBTRACT GovtTax and LocalTax before applying Service Charge
								_baseAmount = poFolioTransaction.BaseAmount;

								_inclusiveServiceCharge = false;
							}

							decimal _serviceChargePercent = (decimal)poTransactionCode.ServiceCharge;

							decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, poTransactionCode.ServiceChargeInclusive);
							poFolioTransaction.ServiceCharge = _serviceChargeAmount;

							// add service charge to Gross Amount if exclusive
							if (poTransactionCode.ServiceChargeInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _serviceChargeAmount;

								_inclusiveServiceCharge = false;
							}
						}
						else
						{
							poFolioTransaction.ServiceCharge = 0;
						}




						poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

						poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount - poFolioTransaction.MealAmount;

						if (_inclusiveGovTax)
						{
							poFolioTransaction.NetBaseAmount -= poFolioTransaction.GovernmentTax;
						}
						if (_inclusiveLocalTax)
						{
							poFolioTransaction.NetBaseAmount -= poFolioTransaction.LocalTax;
						}

						if (_inclusiveServiceCharge)
						{
							poFolioTransaction.NetBaseAmount -= poFolioTransaction.ServiceCharge;
						}

						//poFolioTrans.RouteSequence = "";
						//poFolioTrans.SourceFolio = "";
						//poFolioTrans.SourceSubFolio = "";
						//poFolioTrans.TerminalID = GlobalVariables.gTerminalID.ToString();
						//poFolioTrans.CreatedBy = GlobalVariables.gLoggedOnUser;

						//// new, Jrom, April 26, 2008
						//// Golden prince requirement

						//poFolioTrans.CreditCardNo = this.txtPayment_CardNo.Text;
						//poFolioTrans.ChequeNo = this.txtPayment_Cheque.Text;
						//poFolioTrans.AccountName = this.txtPayment_Account.Text;
						//poFolioTrans.BankName = this.txtPayment_Bank.Text;
						//poFolioTrans.ChequeDate = string.Format("{0:yyyy-MM-dd}", this.dtpPayment_Date.Value);
						//poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;

						//poFolioTransaction.CreditCardType = this.txtCardType.Text;
						//poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
						//poFolioTransaction.SubAccount = this.cboSubAccount.Text;
						//poFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", this.dtpCardExpires.Value);


					}
				}
				catch (Exception)
				{
					//MessageBox.Show("No Package was applied..");
				}
			}

            
            private FolioRoutingCollection loFolioRoutingCollection;
            private void ApplyRouting(string pFolioID, FolioTransaction poFolioTransaction, Folio loFolio,ref FolioTransactions loFolioTransCollection)
            {
                if (loFolio.FolioType != "GROUP")
                {
                    FolioFacade loFolioFacade = new FolioFacade();

                    TransactionCodeFacade _oTransactionFacade = new TransactionCodeFacade();
                    TransactionCode _oTranCode = _oTransactionFacade.getTransactionCode(poFolioTransaction.TransactionCode);

                    loFolioTransCollection = new FolioTransactions();
                    //loFolioRoutingCollection = new FolioRoutingCollection();
                    loFolioRoutingCollection = loFolioFacade.GetFolioTransRouting(pFolioID, poFolioTransaction.TransactionCode);

                    if (loFolioRoutingCollection.Count == 0)
                        return;


                    loFolioTransCollection.Clear();

                    // >> this is used in Routing
                    //double originalAmountForRouting = poFolioTransaction.BaseAmount;
                    decimal originalAmountForRouting = poFolioTransaction.NetAmount;

                    string _tempChargeType = "P"; // P=Percent ; A=Amount
                    decimal _tempTotalAmountInRouting = 0;
                    decimal _tempTotalPercentInRouting = 0;
                    foreach (FolioRouting _oRouting in loFolioRoutingCollection)
                    {
                        if (_oRouting.PercentCharged > 0)
                        {
                            _tempTotalPercentInRouting += _oRouting.PercentCharged;
                        }
                        else if (_oRouting.AmountCharged > 0)
                        {
                            _tempTotalAmountInRouting += _oRouting.AmountCharged;
                        }

                        _tempChargeType = _oRouting.Basis;

                    }

                    // check if Routing has a total Percentage of 100
                    // if not then charge the remaining Percent to subFolio A
                    if (_tempChargeType == "P")
                    {
                        if (_tempTotalPercentInRouting < 100)
                        {
                            // we use 1 here since oRouting.PercentCharge will be multiplied by 100
                            loFolioRoutingCollection.Item(0).PercentCharged = (1 - _tempTotalPercentInRouting);
                        }
                    }

                    // check if Routing has a total Amount equal to NetAmount
                    // if not then charge the remaining amount to subFolio A
                    if (_tempChargeType == "A")
                    {

                        if (_tempTotalPercentInRouting < originalAmountForRouting)
                        {
                            loFolioRoutingCollection.Item(0).AmountCharged = (originalAmountForRouting - _tempTotalAmountInRouting);
                        }
                    }


                    foreach (FolioRouting _oRouting in loFolioRoutingCollection)
                    {
                        if (_oRouting.PercentCharged > 0 || _oRouting.AmountCharged > 0)
                        {

                            FolioTransaction _oFolioTrans = new FolioTransaction();

                            _oFolioTrans.HotelID = poFolioTransaction.HotelID;
                            _oFolioTrans.TransactionDate = poFolioTransaction.TransactionDate;
                            _oFolioTrans.FolioID = loFolio.FolioID;
                            _oFolioTrans.AccountID = loFolio.AccountID;
                            _oFolioTrans.TransactionCode = poFolioTransaction.TransactionCode;
                            _oFolioTrans.SubAccount = poFolioTransaction.SubAccount;
                            _oFolioTrans.ReferenceNo = poFolioTransaction.ReferenceNo;
                            _oFolioTrans.TransactionSource = poFolioTransaction.TransactionSource;
                            _oFolioTrans.Memo = poFolioTransaction.Memo;
                            _oFolioTrans.AcctSide = poFolioTransaction.AcctSide;
                            _oFolioTrans.CurrencyCode = poFolioTransaction.CurrencyCode;
                            _oFolioTrans.ConversionRate = poFolioTransaction.ConversionRate;
                            _oFolioTrans.CurrencyAmount = poFolioTransaction.CurrencyAmount;
                            _oFolioTrans.BaseAmount = poFolioTransaction.BaseAmount;
                            _oFolioTrans.GrossAmount = poFolioTransaction.GrossAmount;
                            _oFolioTrans.Discount = poFolioTransaction.Discount;

                            _oFolioTrans.GovernmentTax = poFolioTransaction.GovernmentTax;
                            _oFolioTrans.LocalTax = poFolioTransaction.LocalTax;
                            _oFolioTrans.ServiceCharge = poFolioTransaction.ServiceCharge;

                            //_oFolioTrans.GovernmentTax = ComputeTaxSrvCharge( _oFolioTrans.BaseAmount, poFolioTransaction.GovernmentTax, poFolioTransaction.GovernmentTaxInclusive) ;
                            //_oFolioTrans.LocalTax = ComputeTaxSrvCharge(_oFolioTrans.BaseAmount, poFolioTransaction.LocalTax, poFolioTransaction.LocalTax);
                            //_oFolioTrans.ServiceCharge = ComputeTaxSrvCharge((_oFolioTrans.BaseAmount - _oFolioTrans.GovernmentTax, poFolioTransaction.ServiceCharge, poFolioTransaction.ServiceChargeInclusive);

                            _oFolioTrans.GovernmentTaxInclusive = poFolioTransaction.GovernmentTaxInclusive;
                            _oFolioTrans.LocalTaxInclusive = poFolioTransaction.LocalTaxInclusive;
                            _oFolioTrans.ServiceChargeInclusive = poFolioTransaction.ServiceChargeInclusive;
                            _oFolioTrans.MealAmount = poFolioTransaction.MealAmount;


                            _oFolioTrans.NetBaseAmount = poFolioTransaction.NetBaseAmount;
                            _oFolioTrans.NetAmount = poFolioTransaction.NetAmount;

                            _oFolioTrans.TerminalID = poFolioTransaction.TerminalID;
                            _oFolioTrans.CreatedBy = poFolioTransaction.CreatedBy;

                            _oFolioTrans.CreditCardNo = poFolioTransaction.CreditCardNo;
                            _oFolioTrans.CreditCardExpiry = poFolioTransaction.CreditCardNo;

                            _oFolioTrans.ChequeDate = "1900-01-01";
                            _oFolioTrans.CreditCardExpiry = "1900-01-01";


                            if (_oRouting.PercentCharged > 0)
                            {
                                _oFolioTrans.Discount = _oFolioTrans.Discount * (_oRouting.PercentCharged / 100); ;
                                _oFolioTrans.CurrencyAmount = _oFolioTrans.CurrencyAmount * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.BaseAmount = _oFolioTrans.BaseAmount * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.GrossAmount = _oFolioTrans.GrossAmount * (_oRouting.PercentCharged / 100);

                                _oFolioTrans.GovernmentTax = _oFolioTrans.GovernmentTax * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.LocalTax = _oFolioTrans.LocalTax * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.ServiceCharge = _oFolioTrans.ServiceCharge * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.NetBaseAmount = _oFolioTrans.NetBaseAmount * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.MealAmount = _oFolioTrans.MealAmount * (_oRouting.PercentCharged / 100);

                                _oFolioTrans.NetAmount = _oFolioTrans.NetAmount * (_oRouting.PercentCharged / 100);
                            }
                            else
                            {
                                // checks if amount is > originalAmountForRouting 
                                if (originalAmountForRouting > _oRouting.AmountCharged)
                                {
                                    originalAmountForRouting -= _oRouting.AmountCharged;
                                }
                                else
                                {
                                    _oRouting.AmountCharged = originalAmountForRouting;
                                    originalAmountForRouting = 0;
                                }

                                // Discount = 0 since we won't be able to determine how much discount to Route
                                // to destination folio.
                                _oFolioTrans.Discount = 0;

                                _oFolioTrans.CurrencyAmount = _oRouting.AmountCharged;
                                _oFolioTrans.BaseAmount = _oRouting.AmountCharged;
                                _oFolioTrans.GrossAmount = _oRouting.AmountCharged;

                                _oFolioTrans.GovernmentTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, _oTranCode.GovtTax, _oTranCode.GovtTaxInclusive);
                                _oFolioTrans.LocalTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, _oTranCode.LocalTax, _oTranCode.LocalTaxInclusive);
                                _oFolioTrans.ServiceCharge = ComputeTaxSrvCharge(_oRouting.AmountCharged, _oTranCode.ServiceCharge, _oTranCode.ServiceChargeInclusive);
                                _oFolioTrans.NetBaseAmount = _oRouting.AmountCharged - (_oFolioTrans.GovernmentTax + _oFolioTrans.LocalTax + _oFolioTrans.ServiceCharge);
                                _oFolioTrans.NetAmount = _oRouting.AmountCharged;
                                //_oFolioTrans.NetAmount = _oRouting.AmountCharged - _oFolioTrans.Discount;

                            }


                            // KUNG NAA CYA MASTER FOLIO(DEPENDENT CYA) DERITSO SA 
                            // IYA MASTER FOLIO ANG TRANSACTION SA 
                            // SUB-FOLIO B., IF INDEPENDENT THEN NAA CYA 
                            // SUB-FOLIO B TRANS, IYAHA GHAPON ANG
                            // TRANSACTION PERO, SA SUB-FOLIO B.
                            _oFolioTrans.SubFolio = _oRouting.SubFolio;
                            if (_oFolioTrans.SubFolio == "B")
                            {
                                //_oFolioTrans.AccountID = (loFolio.CompanyID == "" || loFolio.CompanyID == "0") ? loFolio.AccountID : loFolio.CompanyID;
                                //_oFolioTrans.FolioID = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? loFolio.FolioID : loFolio.MasterFolio;
                                //_oFolioTrans.SubFolio = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? "B" : "A";
                                //_oFolioTrans.SourceFolio = loFolio.FolioID;

                                //_oFolioTrans.AccountID = poFolioTransaction.AccountID;
                                //_oFolioTrans.FolioID = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? loFolio.FolioID : loFolio.MasterFolio;
                                //_oFolioTrans.SubFolio = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? "B" : "A";

                                //_oFolioTrans.SourceFolio = loFolio.FolioID;


                                _oFolioTrans.Discount = _oFolioTrans.Discount;
                            }
                            else
                            {
                                _oFolioTrans.AccountID = loFolio.AccountID;
                                if (loFolio.MasterFolio != "")
                                {
                                    _oFolioTrans.Discount = 0;
                                }
                                else
                                {
                                    _oFolioTrans.Discount = _oFolioTrans.Discount;
                                }
                            }

                            loFolioTransCollection.Add(_oFolioTrans);
                        }
                    }
                }
            }

            private void ApplyPrivileges(FolioTransaction poFolioTrans, FolioTransactions loFolioTransCollection, TransactionCode oTranCode)
            {
                try
                {
                    FolioFacade loFolioFacade = new FolioFacade();


                    if (loFolioTransCollection.Count == 0)
                    {
                        //oFolioTrans.BaseAmount = Me.txtBaseAmount.Text
                        loFolioTransCollection.Add(poFolioTrans);
                    }

                    FolioTransaction _oFolioTransaction;
                    foreach (FolioTransaction _tempLoopVar_fTrans in loFolioTransCollection)
                    {
                        _oFolioTransaction = _tempLoopVar_fTrans;

                        DataRow _dtPrivileges = loFolioFacade.GetFolioTransPrivilege(ref _oFolioTransaction);

                        if (_dtPrivileges == null)
                            return;

                        decimal _disc = 0;
                        if ((string)_dtPrivileges["Basis"] == "A")
                        {
                            _disc = decimal.Parse(_dtPrivileges["AmountOff"].ToString());
                        }
                        else
                        {
                            _disc = _oFolioTransaction.BaseAmount * (decimal.Parse(_dtPrivileges["PercentOff"].ToString()) / 100);
                        }

                        _oFolioTransaction.BaseAmount = _oFolioTransaction.BaseAmount - _disc;
                        _oFolioTransaction.Discount = _oFolioTransaction.Discount + _disc;

                        _oFolioTransaction.GovernmentTax = oTranCode.GovtTax;
                        if (_oFolioTransaction.GovernmentTax > 0)
                        {
                            _oFolioTransaction.GovernmentTax = ComputeTaxSrvCharge(_oFolioTransaction.BaseAmount, _oFolioTransaction.GovernmentTax, _oFolioTransaction.GovernmentTaxInclusive);
                        }

                        _oFolioTransaction.LocalTax = oTranCode.LocalTax;
                        if (System.Convert.ToDouble(_oFolioTransaction.LocalTax) > 0)
                        {
                            _oFolioTransaction.LocalTax = ComputeTaxSrvCharge((_oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax), _oFolioTransaction.LocalTax, _oFolioTransaction.LocalTaxInclusive);
                        }

                        _oFolioTransaction.ServiceCharge = oTranCode.ServiceCharge;
                        if (System.Convert.ToDouble(_oFolioTransaction.ServiceCharge) > 0)
                        {
                            _oFolioTransaction.ServiceCharge = ComputeTaxSrvCharge((_oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax - _oFolioTransaction.LocalTax), _oFolioTransaction.ServiceCharge, _oFolioTransaction.ServiceChargeInclusive);
                        }

                        //fTrans.NetBaseAmount = fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax - fTrans.ServiceCharge;
                        _oFolioTransaction.NetBaseAmount = _oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax - _oFolioTransaction.LocalTax - _oFolioTransaction.ServiceCharge - _oFolioTransaction.Discount;

                    }

                }
                catch (Exception)
                {
                    //MessageBox.Show("No Privilege was applied.", "Insert Folio Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            private decimal ComputeTaxSrvCharge(decimal pBaseAmount, decimal pTaxPercent, int isInclusive)
            {
                decimal _taxAmount;

                if (isInclusive == 1)
                {
                    _taxAmount = pBaseAmount - (pBaseAmount / (1 + (pTaxPercent / 100)));
                }
                else
                {
                    _taxAmount = pBaseAmount * (pTaxPercent / 100);
                }

                return _taxAmount;
            }

            public bool isRoomOccupied(string pRoomNo)
            {
                oMinibarSaleDAO = new MinibarSaleDAO();
                object tempObj = oMinibarSaleDAO.getRoomEventByRoom(pRoomNo);

                if (tempObj == null)
                {
                    return false;
                }
                else 
                {
                    return true;
                }

            }

            //private FolioPackage loPackage;
            //private void ApplyPackage(string pFolioId, FolioTransaction poFolioTrans, TransactionCode oTranCode)
            //{
            //    bool _inclusiveGovTax = true;
            //    bool _inclusiveLocalTax = true;
            //    bool _inclusiveServiceCharge = true;


            //    try
            //    {
            //        FolioFacade _oFolioFacade = new FolioFacade();
            //        loPackage = new FolioPackage();
            //        loPackage = _oFolioFacade.GetFolioTransPackage(pFolioId, poFolioTrans.TransactionCode);

            //        if (loPackage == null)
            //            return;

            //        FolioTransaction _oFolioTransaction = poFolioTrans;
            //        //_oFolioTransaction.BaseAmount = decimal.Parse(this.txtBaseAmount.Text);

            //        if (loPackage.Basis == "A")
            //        {
            //            poFolioTrans.Discount += loPackage.AmountOff;
            //        }
            //        else
            //        {
            //            poFolioTrans.Discount += _oFolioTransaction.NetAmount * (loPackage.PercentOff / 100);
            //        }

            //        //string _strTransactionCode = poFolioTrans.TransactionCode;
            //        //TransactionCode _oTranCode;
            //        //_oTranCode = loTransactionCodeFacade.getTransactionCode(_strTransactionCode);


            //        // BaseAmount = Currency Amount * Exchange Rate
            //        decimal _baseAmount = poFolioTrans.BaseAmount;

            //        poFolioTrans.BaseAmount = _baseAmount;
            //        poFolioTrans.GrossAmount = poFolioTrans.GrossAmount;


            //        // deduct discount b4 applying Tax & Service Charge
            //        _baseAmount = _baseAmount - poFolioTrans.Discount;

            //        // compute Government Tax here (Inclusive or Exclusive)
            //        // if has SubAccount use SubAccount settings for Govt Tax
            //        // else use TransactionCode settings for Govt Tax
            //        if (lSubAccountSelected != null)
            //        {
            //            if (lSubAccountSelected.GovernmentTax > 0)
            //            {
            //                decimal _govTaxPercent = (decimal)lSubAccountSelected.GovernmentTax;

            //                decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, lSubAccountSelected.GovernmentTaxInclusive);
            //                poFolioTrans.GovernmentTax = _govTaxAmount;

            //                if (lSubAccountSelected.GovernmentTaxInclusive == 0)
            //                {
            //                    //poFolioTransaction.GrossAmount += _govTaxAmount;

            //                    _inclusiveGovTax = false;
            //                }
            //            }
            //            else
            //            {
            //                poFolioTrans.GovernmentTax = 0;
            //            }
            //        }
            //        else
            //        {
            //            if (_oTranCode.GovtTax > 0)
            //            {
            //                decimal _govTaxPercent = _oTranCode.GovtTax;

            //                decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, _oTranCode.GovtTaxInclusive);
            //                poFolioTrans.GovernmentTax = _govTaxAmount;

            //                if (_oTranCode.GovtTaxInclusive == 0)
            //                {
            //                    //poFolioTransaction.GrossAmount += _govTaxAmount;

            //                    _inclusiveGovTax = false;
            //                }
            //            }
            //            else
            //            {
            //                poFolioTrans.GovernmentTax = 0;
            //            }

            //        }


            //        // compute Local Tax here (Inclusive or Exclusive)
            //        // if has SubAccount use SubAccount settings for Govt Tax
            //        // else use TransactionCode settings for Local Tax
            //        if (lSubAccountSelected != null)
            //        {
            //            if (lSubAccountSelected.LocalTax > 0)
            //            {
            //                decimal _localTaxPercent = (decimal)lSubAccountSelected.LocalTax;

            //                decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, lSubAccountSelected.LocalTaxInclusive);
            //                poFolioTrans.LocalTax = _localTaxAmount;


            //                if (lSubAccountSelected.LocalTaxInclusive == 0)
            //                {
            //                    //poFolioTransaction.GrossAmount += _localTaxAmount;

            //                    _inclusiveLocalTax = false;
            //                }
            //            }
            //            else
            //            {
            //                poFolioTrans.LocalTax = 0;
            //            }
            //        }
            //        else
            //        {
            //            if (_oTranCode.LocalTax > 0)
            //            {
            //                decimal _localTaxPercent = (decimal)_oTranCode.LocalTax;

            //                decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, _oTranCode.LocalTaxInclusive);
            //                poFolioTrans.LocalTax = _localTaxAmount;

            //                if (_oTranCode.LocalTaxInclusive == 0)
            //                {
            //                    //poFolioTransaction.GrossAmount += _localTaxAmount;

            //                    _inclusiveLocalTax = false;
            //                }
            //            }
            //            else
            //            {
            //                poFolioTrans.LocalTax = 0;
            //            }

            //        }



            //        // compute Local Tax here (Inclusive or Exclusive)
            //        // if has SubAccount use SubAccount settings for Govt Tax
            //        // else use TransactionCode settings for Local Tax
            //        _baseAmount = _baseAmount - poFolioTrans.GovernmentTax - poFolioTrans.LocalTax;

            //        if (lSubAccountSelected != null)
            //        {
            //            if (lSubAccountSelected.ServiceCharge > 0)
            //            {
            //                if (lSubAccountSelected.ServiceChargeInclusive == 0)
            //                {
            //                    // SUBTRACT GovtTax and LocalTax before applying Service Charge
            //                    _baseAmount = poFolioTrans.BaseAmount - poFolioTrans.Discount;

            //                    _inclusiveServiceCharge = false;
            //                }

            //                decimal _serviceChargePercent = (decimal)lSubAccountSelected.ServiceCharge;

            //                decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, lSubAccountSelected.ServiceChargeInclusive);
            //                poFolioTrans.ServiceCharge = _serviceChargeAmount;

            //                // add service charge to Gross Amount if exclusive
            //                if (lSubAccountSelected.ServiceChargeInclusive == 0)
            //                {
            //                    //poFolioTransaction.GrossAmount += _serviceChargeAmount;

            //                    _inclusiveServiceCharge = false;
            //                }
            //            }
            //            else
            //            {
            //                poFolioTrans.ServiceCharge = 0;
            //            }
            //        }
            //        else
            //        {
            //            if (_oTranCode.ServiceCharge > 0)
            //            {
            //                if (_oTranCode.ServiceChargeInclusive == 0)
            //                {
            //                    // SUBTRACT GovtTax and LocalTax before applying Service Charge
            //                    _baseAmount = poFolioTrans.BaseAmount;

            //                    _inclusiveServiceCharge = false;
            //                }

            //                decimal _serviceChargePercent = (decimal)_oTranCode.ServiceCharge;

            //                decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, _oTranCode.ServiceChargeInclusive);
            //                poFolioTrans.ServiceCharge = _serviceChargeAmount;

            //                // add service charge to Gross Amount if exclusive
            //                if (_oTranCode.ServiceChargeInclusive == 0)
            //                {
            //                    //poFolioTransaction.GrossAmount += _serviceChargeAmount;

            //                    _inclusiveServiceCharge = false;
            //                }
            //            }
            //            else
            //            {
            //                poFolioTrans.ServiceCharge = 0;
            //            }

            //        }


            //        poFolioTrans.NetAmount = poFolioTrans.GrossAmount - poFolioTrans.Discount;

            //        poFolioTrans.NetBaseAmount = poFolioTrans.BaseAmount - poFolioTrans.Discount - poFolioTrans.MealAmount;
            //        if (_inclusiveGovTax)
            //        {
            //            poFolioTrans.NetBaseAmount -= poFolioTrans.GovernmentTax;
            //        }
            //        if (_inclusiveLocalTax)
            //        {
            //            poFolioTrans.NetBaseAmount -= poFolioTrans.LocalTax;
            //        }

            //        if (_inclusiveServiceCharge)
            //        {
            //            poFolioTrans.NetBaseAmount -= poFolioTrans.ServiceCharge;
            //        }

            //        //poFolioTrans.RouteSequence = "";
            //        //poFolioTrans.SourceFolio = "";
            //        //poFolioTrans.SourceSubFolio = "";
            //        //poFolioTrans.TerminalID = GlobalVariables.gTerminalID.ToString();
            //        //poFolioTrans.CreatedBy = GlobalVariables.gLoggedOnUser;

            //        //// new, Jrom, April 26, 2008
            //        //// Golden prince requirement

            //        //poFolioTrans.CreditCardNo = this.txtPayment_CardNo.Text;
            //        //poFolioTrans.ChequeNo = this.txtPayment_Cheque.Text;
            //        //poFolioTrans.AccountName = this.txtPayment_Account.Text;
            //        //poFolioTrans.BankName = this.txtPayment_Bank.Text;
            //        //poFolioTrans.ChequeDate = string.Format("{0:yyyy-MM-dd}", this.dtpPayment_Date.Value);
            //        //poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;

            //        //poFolioTransaction.CreditCardType = this.txtCardType.Text;
            //        //poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
            //        //poFolioTransaction.SubAccount = this.cboSubAccount.Text;
            //        //poFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", this.dtpCardExpires.Value);



            //    }
            //    catch (Exception)
            //    {
            //        //MessageBox.Show("No package was applied.", "Insert Folio Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}


            //private void AssignFolioTransValues(FolioTransaction poFolioTransaction, Folio oGuestFolio, string pRoomNo, decimal pAmount, TransactionCode poTransactionCode, long pReferenceNo)
            //{


            //    bool _inclusiveGovTax = true;
            //    bool _inclusiveLocalTax = true;
            //    bool _inclusiveServiceCharge = true;


            //    decimal _govtTaxPercent = 0;
            //    decimal _localTaxPercent = 0;
            //    decimal _serviceChargePercent = 0;

            //    decimal _govtTaxAmount = 0;
            //    decimal _localTaxAmount = 0;
            //    decimal _serviceChargeAmount = 0;


            //    poFolioTransaction.HotelID = GlobalVariables.gHotelId;
            //    poFolioTransaction.TransactionDate = DateTime.Parse(GlobalVariables.gAuditDate);
            //    poFolioTransaction.FolioID = oGuestFolio.FolioID;
            //    poFolioTransaction.SubFolio = "A";
            //    if (oGuestFolio.AccountID != null)
            //    {
            //        poFolioTransaction.AccountID = oGuestFolio.AccountID;
            //    }
            //    else
            //    {
            //        poFolioTransaction.AccountID = oGuestFolio.CompanyID;
            //    }

            //    poFolioTransaction.TransactionCode = poTransactionCode.TranCode;
            //    poFolioTransaction.ReferenceNo = pReferenceNo.ToString();
            //    poFolioTransaction.TransactionSource = poTransactionCode.DefaultTransactionSource;
            //    poFolioTransaction.Memo = poTransactionCode.Memo;

            //    poFolioTransaction.AcctSide = poTransactionCode.AcctSide;
            //    poFolioTransaction.CurrencyCode = "PHP";
            //    poFolioTransaction.ConversionRate = 1;
            //    poFolioTransaction.CurrencyAmount = pAmount;

            //    poFolioTransaction.Discount = 0;

            //    // BaseAmount = Currency Amount * Exchange Rate
            //    decimal _baseAmount = poFolioTransaction.CurrencyAmount * poFolioTransaction.ConversionRate;

            //    poFolioTransaction.BaseAmount = _baseAmount;
            //    poFolioTransaction.GrossAmount = pAmount;


            //    // deduct discount b4 applying Tax & Service Charge
            //    _baseAmount = _baseAmount - poFolioTransaction.Discount;


            //    _inclusiveGovTax = poTransactionCode.GovtTaxInclusive == 1 ? true : false;
            //    _inclusiveLocalTax = poTransactionCode.LocalTaxInclusive == 1 ? true : false;
            //    _inclusiveServiceCharge = poTransactionCode.ServiceChargeInclusive == 1 ? true : false;

            //    _govtTaxPercent = poTransactionCode.GovtTax / 100;
            //    _localTaxPercent = poTransactionCode.LocalTax / 100;
            //    _serviceChargePercent = poTransactionCode.ServiceCharge / 100;


            //    //>> get Total Inclusive Charges
            //    decimal _totalInclusive = 0;
            //    if (_inclusiveGovTax)
            //    {
            //        _totalInclusive += _govtTaxPercent;
            //    }

            //    if (_inclusiveLocalTax)
            //    {
            //        _totalInclusive += _localTaxPercent;
            //    }

            //    if (_inclusiveServiceCharge)
            //    {
            //        _totalInclusive += _serviceChargePercent;
            //    }
            //    //>> end get Total Inclusive Charges

            //    decimal _amountAfterDeductInclusiveCharges = _baseAmount / (1 + _totalInclusive);

            //    //>> compute Government Tax
            //    if (_govtTaxPercent > 0)
            //    {
            //        if (_inclusiveGovTax)
            //        {
            //            _govtTaxAmount = _amountAfterDeductInclusiveCharges * _govtTaxPercent;
            //        }
            //        else
            //        {
            //            _govtTaxAmount = _baseAmount * _govtTaxPercent;
            //        }
            //    }
            //    //>> end compute Government Tax

            //    //>> compute Local Tax
            //    if (_localTaxPercent > 0)
            //    {
            //        if (_inclusiveLocalTax)
            //        {
            //            _localTaxAmount = _amountAfterDeductInclusiveCharges * _localTaxPercent;
            //        }
            //        else
            //        {
            //            _localTaxAmount = _baseAmount * _localTaxPercent;
            //        }
            //    }
            //    //>> end compute Local Tax


            //    //>> compute Service Charge
            //    if (_serviceChargePercent > 0)
            //    {
            //        if (_inclusiveServiceCharge)
            //        {
            //            _serviceChargeAmount = _amountAfterDeductInclusiveCharges * _serviceChargePercent;
            //        }
            //        else
            //        {
            //            _serviceChargeAmount = _baseAmount * _serviceChargePercent;
            //        }
            //    }
            //    //>> end compute Service Charge


            //    poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

            //    poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount;

            //    poFolioTransaction.NetBaseAmount = _amountAfterDeductInclusiveCharges;
            //    poFolioTransaction.GovernmentTax = _govtTaxAmount;
            //    poFolioTransaction.LocalTax = _localTaxAmount;
            //    poFolioTransaction.ServiceCharge = _serviceChargeAmount;

            //    poFolioTransaction.GovernmentTaxInclusive = _inclusiveGovTax == true ? 1 : 0;
            //    poFolioTransaction.LocalTaxInclusive = _inclusiveLocalTax == true ? 1 : 0;
            //    poFolioTransaction.ServiceChargeInclusive = _inclusiveServiceCharge == true ? 1 : 0;


            //    poFolioTransaction.MealAmount = 0;
            //    poFolioTransaction.NetBaseAmount -= poFolioTransaction.MealAmount;

            //    poFolioTransaction.RouteSequence = "";
            //    poFolioTransaction.SourceFolio = "";
            //    poFolioTransaction.SourceSubFolio = "";
            //    poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
            //    poFolioTransaction.CreatedBy = GlobalVariables.gLoggedOnUser;

            //    // new, Jrom, April 26, 2008
            //    // Golden prince requirement

            //    poFolioTransaction.CreditCardNo = "";
            //    poFolioTransaction.ChequeNo = "";
            //    poFolioTransaction.AccountName = "";
            //    poFolioTransaction.BankName = "";
            //    poFolioTransaction.ChequeDate = "1900-01-01";
            //    poFolioTransaction.FOCGrantedBy = "";

            //    poFolioTransaction.CreditCardType = "";
            //    poFolioTransaction.ApprovalSlip = "";
            //    poFolioTransaction.SubAccount = "";
            //    poFolioTransaction.CreditCardExpiry = "1900-01-01";

            //}

            //private FolioRoutingCollection oFolioRoutingCollection;
            //private void ApplyRouting(FolioTransaction oFTrans, Folio oFolio, TransactionCode oTranCode)
            //{
            //    if (oFolio.FolioType != "GROUP")
            //    {
            //        FolioFacade oFolioFacade = new FolioFacade();
            //        FolioTransactions oFolioTransCollection = new FolioTransactions();
            //        //oFolioRoutingCollection = new FolioRoutingCollection();
            //        oFolioRoutingCollection = oFolioFacade.GetFolioTransRouting(oFTrans.FolioID, oFTrans.TransactionCode);

            //        if (oFolioRoutingCollection.Count == 0)
            //            return;


            //        //oFTrans.TransactionSource = "AUTO-POST";
            //        // >> this is used in Routing
            //        //double originalAmountForRouting = poFolioTransaction.BaseAmount;
            //        decimal originalAmountForRouting = oFTrans.NetAmount;

            //        string _tempChargeType = "P"; // P=Percent ; A=Amount
            //        decimal _tempTotalAmountInRouting = 0;
            //        decimal _tempTotalPercentInRouting = 0;
            //        foreach (FolioRouting _oRouting in oFolioRoutingCollection)
            //        {
            //            if (_oRouting.PercentCharged > 0)
            //            {
            //                _tempTotalPercentInRouting += _oRouting.PercentCharged;
            //            }
            //            else if (_oRouting.AmountCharged > 0)
            //            {
            //                _tempTotalAmountInRouting += _oRouting.AmountCharged;
            //            }

            //            _tempChargeType = _oRouting.Basis;

            //        }

            //        // check if Routing has a total Percentage of 100
            //        // if not then charge the remaining Percent to subFolio A
            //        if (_tempChargeType == "P")
            //        {
            //            if (_tempTotalPercentInRouting < 100)
            //            {
            //                // we use 1 here since oRouting.PercentCharge will be multiplied by 100
            //                oFolioRoutingCollection.Item(0).PercentCharged = (1 - _tempTotalPercentInRouting);
            //            }
            //        }

            //        // check if Routing has a total Amount equal to NetAmount
            //        // if not then charge the remaining amount to subFolio A
            //        if (_tempChargeType == "A")
            //        {

            //            if (_tempTotalPercentInRouting < originalAmountForRouting)
            //            {
            //                oFolioRoutingCollection.Item(0).AmountCharged = (originalAmountForRouting - _tempTotalAmountInRouting);
            //            }
            //        }


            //        foreach (FolioRouting _oRouting in oFolioRoutingCollection)
            //        {

            //            if (_oRouting.PercentCharged > 0 || _oRouting.AmountCharged > 0)
            //            {

            //                FolioTransaction oFolioTrans = new FolioTransaction();

            //                oFolioTrans.HotelID = oFTrans.HotelID;
            //                oFolioTrans.FolioID = oFolio.FolioID;
            //                if (oFolio.AccountID != null)
            //                {
            //                    oFolioTrans.AccountID = oFolio.AccountID;
            //                }
            //                else
            //                {
            //                    oFolioTrans.AccountID = oFolio.CompanyID;
            //                }
            //                oFolioTrans.TransactionDate = oFTrans.TransactionDate;
            //                oFolioTrans.PostingDate = oFTrans.PostingDate;
            //                oFolioTrans.TransactionCode = oFTrans.TransactionCode;
            //                oFolioTrans.ReferenceNo = oFTrans.ReferenceNo;
            //                oFolioTrans.TransactionSource = oFTrans.TransactionSource;
            //                oFolioTrans.Memo = oFTrans.Memo;
            //                oFolioTrans.AcctSide = oFTrans.AcctSide;
            //                oFolioTrans.CurrencyCode = oFTrans.CurrencyCode;
            //                oFolioTrans.ConversionRate = oFTrans.ConversionRate;
            //                oFolioTrans.CurrencyAmount = oFTrans.CurrencyAmount;
            //                oFolioTrans.BaseAmount = oFTrans.BaseAmount;
            //                oFolioTrans.GrossAmount = oFTrans.GrossAmount;
            //                oFolioTrans.MealAmount = oFTrans.MealAmount;
            //                oFolioTrans.Discount = oFTrans.Discount;

            //                oFolioTrans.GovernmentTax = oFTrans.GovernmentTax;
            //                oFolioTrans.GovernmentTaxInclusive = oFTrans.GovernmentTaxInclusive;

            //                oFolioTrans.LocalTax = oFTrans.LocalTax;
            //                oFolioTrans.LocalTaxInclusive = oFTrans.LocalTaxInclusive;

            //                oFolioTrans.ServiceCharge = oFTrans.ServiceCharge;
            //                oFolioTrans.ServiceChargeInclusive = oFTrans.ServiceChargeInclusive;


            //                oFolioTrans.NetBaseAmount = oFTrans.NetBaseAmount;
            //                oFolioTrans.NetAmount = oFTrans.NetAmount;

            //                oFolioTrans.TerminalID = oFTrans.TerminalID;
            //                oFolioTrans.CreatedBy = oFTrans.CreatedBy;


            //                oFolioTrans.SubFolio = _oRouting.SubFolio;
            //                if (_oRouting.PercentCharged > 0)
            //                {
            //                    oFolioTrans.Discount = oFolioTrans.Discount * (_oRouting.PercentCharged / 100);

            //                    oFolioTrans.CurrencyAmount = oFolioTrans.CurrencyAmount * (_oRouting.PercentCharged / 100);
            //                    oFolioTrans.BaseAmount = oFolioTrans.BaseAmount * (_oRouting.PercentCharged / 100);

            //                    oFolioTrans.GovernmentTax = oFolioTrans.GovernmentTax * (_oRouting.PercentCharged / 100);
            //                    oFolioTrans.LocalTax = oFolioTrans.LocalTax * (_oRouting.PercentCharged / 100);
            //                    oFolioTrans.ServiceCharge = oFolioTrans.ServiceCharge * (_oRouting.PercentCharged / 100);

            //                    oFolioTrans.NetBaseAmount = oFolioTrans.NetBaseAmount * (_oRouting.PercentCharged / 100);
            //                    oFolioTrans.NetAmount = oFolioTrans.NetAmount * (_oRouting.PercentCharged / 100);
            //                    oFolioTrans.GrossAmount = oFolioTrans.GrossAmount * (_oRouting.PercentCharged / 100);

            //                }
            //                else
            //                {
            //                    // checks if amount is > originalAmountForRouting 
            //                    if (originalAmountForRouting > _oRouting.AmountCharged)
            //                    {
            //                        originalAmountForRouting -= _oRouting.AmountCharged;
            //                    }
            //                    else
            //                    {
            //                        _oRouting.AmountCharged = originalAmountForRouting;
            //                        originalAmountForRouting = 0;
            //                    }

            //                    // Discount = 0 since we won't be able to determine how much discount to Route
            //                    // to destination folio.
            //                    oFolioTrans.Discount = 0;

            //                    oFolioTrans.CurrencyAmount = _oRouting.AmountCharged;
            //                    oFolioTrans.BaseAmount = _oRouting.AmountCharged;
            //                    oFolioTrans.GovernmentTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, oTranCode.GovtTax, oTranCode.GovtTaxInclusive);
            //                    oFolioTrans.LocalTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, oTranCode.LocalTax, oTranCode.LocalTaxInclusive);
            //                    oFolioTrans.ServiceCharge = ComputeTaxSrvCharge(_oRouting.AmountCharged, oTranCode.ServiceCharge, oTranCode.ServiceChargeInclusive);
            //                    oFolioTrans.NetBaseAmount = _oRouting.AmountCharged - (oFolioTrans.GovernmentTax + oFolioTrans.LocalTax + oFolioTrans.ServiceCharge);


            //                    oFolioTrans.GrossAmount = oFolioTrans.BaseAmount;
            //                    oFolioTrans.NetAmount = oFolioTrans.BaseAmount;


            //                }


            //                // KUNG NAA CYA MASTER FOLIO(DEPENDENT CYA) DERITSO SA 
            //                // IYA MASTER FOLIO ANG TRANSACTION SA 
            //                // SUB-FOLIO B., IF INDEPENDENT THEN NAA CYA 
            //                // SUB-FOLIO B TRANS, IYAHA GHAPON ANG
            //                // TRANSACTION PERO, SA SUB-FOLIO B.
            //                oFolioTrans.SubFolio = _oRouting.SubFolio;
            //                if (oFolioTrans.SubFolio == "B")
            //                {
            //                    //revised: jrom
            //                    // desc  : dli man cya makita sa folio transactions if ideritso 
            //                    //         ang iya transaction sa iya master folio,
            //                    //         ang tendency i-double charge na hinuon nila..
            //                    //         ila manualon ug insert para makita b4 i-checkout ...

            //                    //oFolioTrans.AccountID = (oFolio.CompanyID == "" || oFolio.CompanyID == "0") ? oFolio.AccountID : oFolio.CompanyID;
            //                    //oFolioTrans.FolioID = (oFolio.MasterFolio == "" || oFolio.CompanyID == "0") ? oFolio.FolioID : oFolio.MasterFolio;

            //                    oFolioTrans.AccountID = oFolio.AccountID;
            //                    oFolio.FolioID = oFolio.FolioID;
            //                    oFolioTrans.SubFolio = "B";

            //                    //oFolioTrans.SubFolio = (oFolio.MasterFolio == "" || oFolio.CompanyID == "0") ? "B" : "A";
            //                    //oFolioTrans.SourceFolio = oFolio.FolioID;
            //                    //oFolioTrans.SourceSubFolio = "A";
            //                    oFolioTrans.Discount = oFolioTrans.Discount;
            //                }
            //                else
            //                {
            //                    oFolioTrans.AccountID = oFolio.AccountID;
            //                    if (oFolio.MasterFolio != "")
            //                    {
            //                        oFolioTrans.Discount = 0;
            //                    }
            //                    else
            //                    {
            //                        oFolioTrans.Discount = oFolioTrans.Discount;
            //                    }
            //                }

            //                oFolioTrans.ChequeDate = "1900-01-01";
            //                oFolioTrans.CreditCardExpiry = "1900-01-01";


            //                oFolioTransCollection.Add(oFolioTrans);
            //            }
            //        }
            //    }
            //}

            //private void ApplyPrivileges(FolioTransaction oFolioTrans, TransactionCode _oTransactionCode)
            //{
            //    try
            //    {
            //        FolioFacade oFolioFacade = new FolioFacade();

            //        //if (oFolioTransCollection == null || oFolioTransCollection.Count == 0)
            //        //{
            //        //    oFolioTransCollection = new FolioTransactions();

            //        //    oFolioTransCollection.Add(oFolioTrans);
            //        //}

            //        //TransactionCode _oTransactionCode = GetTranCode(oFolioTrans.TransactionCode);

            //        //FolioTransaction fTrans;
            //        //foreach (FolioTransaction tempLoopVar_fTrans in oFolioTransCollection)
            //        //{

            //        FolioTransaction fTrans = oFolioTrans;
            //        //fTrans.TransactionSource = "AUTO-POST";
            //        DataRow dtPrivileges = oFolioFacade.GetFolioTransPrivilege(ref fTrans);

            //        if (dtPrivileges != null)
            //        {
            //            decimal disc = 0;
            //            if ((string)dtPrivileges["Basis"] == "A")
            //            {
            //                disc = System.Convert.ToDecimal(dtPrivileges["AmountOff"]);
            //            }
            //            else
            //            {
            //                disc = fTrans.NetAmount * System.Convert.ToDecimal(dtPrivileges["PercentOff"].ToString());
            //                disc = (disc / 100);
            //            }

            //            fTrans.Discount += disc;
            //            fTrans.NetAmount -= disc;


            //            fTrans.GovernmentTax = _oTransactionCode.GovtTax;
            //            if (fTrans.GovernmentTax > 0)
            //            {
            //                fTrans.GovernmentTax = ComputeTaxSrvCharge(fTrans.NetAmount, fTrans.GovernmentTax, _oTransactionCode.GovtTaxInclusive);
            //            }

            //            fTrans.LocalTax = _oTransactionCode.LocalTax;
            //            if (fTrans.LocalTax > 0)
            //            {
            //                fTrans.LocalTax = ComputeTaxSrvCharge((fTrans.NetAmount - fTrans.GovernmentTax), fTrans.LocalTax, _oTransactionCode.LocalTaxInclusive);
            //            }

            //            fTrans.ServiceCharge = _oTransactionCode.ServiceCharge;
            //            if (fTrans.ServiceCharge > 0)
            //            {
            //                fTrans.ServiceCharge = ComputeTaxSrvCharge((fTrans.NetAmount - fTrans.GovernmentTax - fTrans.LocalTax), fTrans.ServiceCharge, _oTransactionCode.ServiceChargeInclusive);
            //            }

            //            fTrans.NetBaseAmount = fTrans.NetAmount - fTrans.GovernmentTax - fTrans.LocalTax - fTrans.ServiceCharge - fTrans.MealAmount;

            //        }
            //        //}

            //    }
            //    catch
            //    {
            //        //MessageBox.Show("No Privilege was applied..");
            //    }
            //}

            //private decimal ComputeTaxSrvCharge(decimal pBaseAmount, decimal pTaxPercent, int isInclusive)
            //{
            //    decimal _taxAmount;

            //    if (isInclusive == 1)
            //    {
            //        _taxAmount = pBaseAmount - (pBaseAmount / (1 + (pTaxPercent / 100)));
            //    }
            //    else
            //    {
            //        _taxAmount = pBaseAmount * (pTaxPercent / 100);
            //    }

            //    return _taxAmount;
            //}

		}
    
}
