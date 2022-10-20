using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.AccountingInterface.Navision_Interface.Data_Access;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;

using Jinisys.Hotel.AccountingInterface.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.Navision_Interface.BusinessLayer
{
    class Navision_Interface_Facade
    {

		public bool PostToNavision(string connectionString)
		{
			try
			{
				Navision_Interface_DAO oNavisionInterfaceDAO = new Navision_Interface_DAO(connectionString);

				BackOfficeConfigFacade oBackOfficeConfigFacade = new BackOfficeConfigFacade();
				DataTable dtTrans = oBackOfficeConfigFacade.getUnpostedFolioTransactions();

				IList<FolioTransaction> oFolioTransactions = new List<FolioTransaction>();

				foreach (DataRow dtRow in dtTrans.Rows)
				{
					FolioTransaction oFolioTrans = new FolioTransaction();

					oFolioTrans.FolioID = dtRow["FolioId"].ToString();
					oFolioTrans.AccountID = dtRow["AccountId"].ToString();
					oFolioTrans.SubFolio = dtRow["SubFolio"].ToString(); //(getFolioTransReader.GetString(22).ToString() == null) ? null : (getFolioTransReader.GetString(22));
					oFolioTrans.TransactionDate = DateTime.Parse(dtRow["TransactionDate"].ToString()); //(getFolioTransReader.GetDateTime(0).ToString() == null) ? DateTime.Parse("") : DateTime.Parse(getFolioTransReader.GetDateTime(0).ToString());
					oFolioTrans.ReferenceNo = dtRow["ReferenceNo"].ToString();  //(getFolioTransReader.GetValue(2).ToString() == null) ? "" : (getFolioTransReader.GetValue(2).ToString());
					oFolioTrans.TransactionCode = dtRow["TransactionCode"].ToString(); //(getFolioTransReader.GetValue(1).ToString() == null) ? "" : (getFolioTransReader.GetValue(1).ToString());
					oFolioTrans.Memo = dtRow["Memo"].ToString(); //(getFolioTransReader.GetValue(3).ToString() == null) ? "" : (getFolioTransReader.GetValue(3).ToString());
					oFolioTrans.AcctSide = dtRow["AcctSide"].ToString(); //(getFolioTransReader.GetValue(4).ToString() == null) ? "" : (getFolioTransReader.GetValue(4).ToString());
					oFolioTrans.CurrencyCode = dtRow["CurrencyCode"].ToString(); //(getFolioTransReader.GetValue(5).ToString() == null) ? "" : (getFolioTransReader.GetValue(5).ToString());
					oFolioTrans.ConversionRate = decimal.Parse(dtRow["ConversionRate"].ToString()); //(getFolioTransReader.GetValue(6).ToString() == null) ? 0 : decimal.Parse(getFolioTransReader.GetValue(6).ToString());
					oFolioTrans.CurrencyAmount = decimal.Parse(dtRow["CurrencyAmount"].ToString()); //(getFolioTransReader.GetValue(7).ToString() == null) ? 0 : decimal.Parse(getFolioTransReader.GetValue(7).ToString());
					oFolioTrans.BaseAmount = decimal.Parse(dtRow["BaseAmount"].ToString()); //(getFolioTransReader.GetValue(8).ToString() == null) ? 0 : decimal.Parse(getFolioTransReader.GetValue(8).ToString());
					oFolioTrans.NetBaseAmount = decimal.Parse(dtRow["NetBaseAmount"].ToString());  //(getFolioTransReader.GetDecimal(13).ToString() == null) ? 0 : (getFolioTransReader.GetDecimal(13));
					oFolioTrans.Discount = decimal.Parse(dtRow["Discount"].ToString()); //(getFolioTransReader.GetDecimal(9).ToString() == null) ? 0 : decimal.Parse(getFolioTransReader.GetDecimal(9).ToString());
					oFolioTrans.GovernmentTax = decimal.Parse(dtRow["GovernmentTax"].ToString()); //(getFolioTransReader.GetValue(11).ToString() == null) ? 0 : decimal.Parse(getFolioTransReader.GetValue(11).ToString());
					oFolioTrans.LocalTax = decimal.Parse(dtRow["LocalTax"].ToString()); //(getFolioTransReader.GetDecimal(12).ToString() == null) ? 0 : (getFolioTransReader.GetDecimal(12));
					oFolioTrans.ServiceCharge = decimal.Parse(dtRow["ServiceCharge"].ToString()); //(getFolioTransReader.GetValue(10).ToString() == null) ? 0 : (getFolioTransReader.GetDecimal(10));
					//oFolioTrans.UpdateTime = IIf(IsDBNull(getFolioTransReader.GetValue(9)), Nothing, getFolioTransReader.GetValue(9))
					oFolioTrans.RouteSequence = dtRow["RouteSequence"].ToString(); //(getFolioTransReader.GetValue(14).ToString() == null) ? "" : (getFolioTransReader.GetValue(14).ToString());
					oFolioTrans.PostToLedger = dtRow["PostToLedger"].ToString(); //(getFolioTransReader.GetValue(19).ToString() == null) ? "" : (getFolioTransReader.GetValue(19).ToString());
					oFolioTrans.UpdatedBy = dtRow["UpdatedBy"].ToString(); //(getFolioTransReader.GetValue(27).ToString() == null) ? "" : (getFolioTransReader.GetValue(27).ToString());
					oFolioTrans.PostingDate = DateTime.Parse(dtRow["PostingDate"].ToString()); //DateTime.Parse(getFolioTransReader.GetValue(28).ToString());
					oFolioTrans.AuditFlag = dtRow["AuditFlag"].ToString();//(getFolioTransReader.GetValue(29).ToString() == null) ? "" : (getFolioTransReader.GetValue(29).ToString());
					oFolioTrans.TerminalID = dtRow["TerminalId"].ToString();//(getFolioTransReader.GetValue(29).ToString() == null) ? "" : (getFolioTransReader.GetValue(29).ToString());

					oFolioTransactions.Add(oFolioTrans);
				}


				int startInvoice = int.Parse(ConfigVariables.gBackOfficeInvoiceStart);
				foreach (FolioTransaction transaction in oFolioTransactions)
				{
					Accounts.BusinessLayer.Guest oGuest = new Jinisys.Hotel.Accounts.BusinessLayer.Guest();
					Accounts.BusinessLayer.GuestFacade oGuestFacade = new Jinisys.Hotel.Accounts.BusinessLayer.GuestFacade();
					oGuest = oGuestFacade.getGuestRecord(transaction.AccountID);

					string guestName = oGuest.LastName + ", " + oGuest.FirstName;

					//Navision_Interface_DAO oNavisionInterfaceDAO = new Navision_Interface_DAO();

					if (transaction.AcctSide == "DEBIT")
					{
						Sales_Header oSalesHeader = new Sales_Header();

						oSalesHeader.DocumentType = "Invoice";
						oSalesHeader.SelltoCustomerNo = transaction.AccountID; //"I-0000000028";
						oSalesHeader.No = startInvoice.ToString();
						oSalesHeader.BilltoCustomerNo = transaction.AccountID; //"I-0000000028";//
						oSalesHeader.BilltoName = guestName;//"Bacnan, Emil";//
						oSalesHeader.BilltoName2 = "";
						oSalesHeader.BilltoAddress = "";
						oSalesHeader.BilltoAddress2 = "";
						oSalesHeader.BilltoCity = "";
						oSalesHeader.BilltoContact = "";
						oSalesHeader.YourReference = "";
						oSalesHeader.ShiptoCode = "";
						oSalesHeader.ShiptoName = guestName; //"Bacnan, Emil";//
						oSalesHeader.ShiptoName2 = "";
						oSalesHeader.ShiptoAddress = "";
						oSalesHeader.ShiptoAddress2 = "";
						oSalesHeader.ShiptoCity = "";
						oSalesHeader.ShiptoContact = "";
						oSalesHeader.OrderDate = "{ts '2001-01-25 00:00:00'}";//"1/25/2001 12:00:00 AM";
						oSalesHeader.PostingDate = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						oSalesHeader.ShipmentDate = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						oSalesHeader.PostingDescription = "Invoice " + startInvoice.ToString();
						oSalesHeader.PaymentTermsCode = "";
						oSalesHeader.DueDate = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						oSalesHeader.PaymentDiscount = 0;
						oSalesHeader.PmtDiscountDate = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						oSalesHeader.ShipmentMethodCode = "";
						oSalesHeader.LocationCode = "";
						oSalesHeader.ShortcutDimension1Code = "";
						oSalesHeader.ShortcutDimension2Code = "";
						oSalesHeader.CustomerPostingGroup = "GUEST";
						oSalesHeader.CurrencyCode = "";
						oSalesHeader.CurrencyFactor = 0;
						oSalesHeader.CustomerPriceGroup = "";
						oSalesHeader.PricesIncludingVAT = 0;
						oSalesHeader.InvoiceDiscCode = transaction.AccountID;
						oSalesHeader.CustomerDiscGroup = "";
						oSalesHeader.LanguageCode = "";
						oSalesHeader.SalespersonCode = "";
						oSalesHeader.OrderClass = "";
						oSalesHeader.Comment = 0;
						oSalesHeader.NoPrinted = 0;
						oSalesHeader.OnHold = "";
						oSalesHeader.AppliestoDocType = "";
						oSalesHeader.AppliestoDocNo = "";
						oSalesHeader.BalAccountNo = "";
						oSalesHeader.JobNo = "";
						oSalesHeader.Ship = 1;
						oSalesHeader.Invoice = 1;
						oSalesHeader.Amount = 0;
						oSalesHeader.AmountIncludingVAT = 0;
						oSalesHeader.ShippingNo = "102059";
						oSalesHeader.PostingNo = "103047";
						oSalesHeader.LastShippingNo = "";
						oSalesHeader.LastPostingNo = "";
						oSalesHeader.VATRegistrationNo = "";
						oSalesHeader.CombineShipments = 0;
						oSalesHeader.ReasonCode = "";
						oSalesHeader.GenBusPostingGroup = "NATIONAL";
						oSalesHeader.EU3PartyTrade = 0;
						oSalesHeader.TransactionType = "";
						oSalesHeader.TransportMethod = "";
						oSalesHeader.VATCountryCode = "";
						oSalesHeader.SelltoCustomerName = guestName;
						oSalesHeader.SelltoCustomerName2 = "";
						oSalesHeader.SelltoAddress = "";
						oSalesHeader.SelltoAddress2 = "";
						oSalesHeader.SelltoCity = "Manila";
						oSalesHeader.SelltoContact = "";
						oSalesHeader.BilltoPostCode = "";
						oSalesHeader.BilltoCounty = "";
						oSalesHeader.BilltoCountryCode = "";
						oSalesHeader.SelltoPostCode = "1000";
						oSalesHeader.SelltoCounty = "";
						oSalesHeader.SelltoCountryCode = "";
						oSalesHeader.ShiptoPostCode = "";
						oSalesHeader.ShiptoCounty = "";
						oSalesHeader.ShiptoCountryCode = "";
						oSalesHeader.BalAccountType = "G/L Account";
						oSalesHeader.ExitPoint = "";
						oSalesHeader.Correction = 0;
						oSalesHeader.DocumentDate = "{ts '2001-01-25 00:00:00'}";
						oSalesHeader.ExternalDocumentNo = "123";
						oSalesHeader.Area = "";
						oSalesHeader.TransactionSpecification = "";
						oSalesHeader.PaymentMethodCode = "";
						oSalesHeader.ShippingAgentCode = "";
						oSalesHeader.PackageTrackingNo = "";
						oSalesHeader.NoSeries = "S-INV";
						oSalesHeader.PostingNoSeries = "S-INV+";
						oSalesHeader.ShippingNoSeries = "S-SHPT";
						oSalesHeader.TaxAreaCode = "";
						oSalesHeader.TaxLiable = 0;
						oSalesHeader.VATBusPostingGroup = "NATIONAL";
						oSalesHeader.Reserve = "Optional";
						oSalesHeader.AppliestoID = "";
						oSalesHeader.VATBaseDiscount = 0;
						oSalesHeader.Status = "Open";
						oSalesHeader.InvoiceDiscountCalculation = "None";
						oSalesHeader.InvoiceDiscountValue = 0;
						oSalesHeader.SendICDocument = 0;
						oSalesHeader.ICStatus = "New";
						oSalesHeader.SelltoICPartnerCode = "";
						oSalesHeader.BilltoICPartnerCode = "";
						oSalesHeader.ICDirection = "Outgoing";
						oSalesHeader.NoofArchivedVersions = 0;
						oSalesHeader.DocNoOccurrence = 1;
						oSalesHeader.CampaignNo = "";
						oSalesHeader.SelltoCustomerTemplateCode = "";
						oSalesHeader.SelltoContactNo = "CT000168";
						oSalesHeader.BilltoContactNo = "CT000168";
						oSalesHeader.BilltoCustomerTemplateCode = "";
						oSalesHeader.OpportunityNo = "";
						oSalesHeader.ResponsibilityCenter = "";
						oSalesHeader.ShippingAdvice = "Partial";
						oSalesHeader.CompletelyShipped = 0;
						oSalesHeader.PostingfromWhseRef = 0;
						oSalesHeader.LocationFilter = "";
						oSalesHeader.RequestedDeliveryDate = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						oSalesHeader.PromisedDeliveryDate = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						oSalesHeader.ShippingTime = "";
						oSalesHeader.OutboundWhseHandlingTime = "";
						oSalesHeader.ShippingAgentServiceCode = "";
						oSalesHeader.LateOrderShipping = 1;
						oSalesHeader.DateFilter = "{ts '2001-01-25 00:00:00'}";// "1/1/1753 12:00:00 AM";
						oSalesHeader.Receive = 0;
						oSalesHeader.ReturnReceiptNo = "";
						oSalesHeader.ReturnReceiptNoSeries = "";
						oSalesHeader.LastReturnReceiptNo = "";
						oSalesHeader.ServiceMgtDocument = 0;
						oSalesHeader.ExpirationDate = "{ts '2001-01-25 00:00:00'}";
						oSalesHeader.CPStatus = "";
						oSalesHeader.AutoCreated = 0;
						oSalesHeader.LoginID = "";
						oSalesHeader.WebSiteCode = "";
						oSalesHeader.AllowLineDisc = 1;
						oSalesHeader.GetShipmentUsed = 0;
						oSalesHeader.Adjustment = 0;
						oSalesHeader.BASAdjustment = 0;
						oSalesHeader.AdjustmentAppliesto = "";
						oSalesHeader.WHTBusinessPostingGroup = "";
						oSalesHeader.TaxDocumentType = "";
						oSalesHeader.PrintedTaxDocument = 0;
						oSalesHeader.PostedTaxDocument = 0;
						oSalesHeader.TaxDocumentMarked = 0;
						oSalesHeader.DateReceived = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						//oSalesHeader.TimeReceived = "00:00:00";
						oSalesHeader.BizTalkRequestforSalesQte = 0;
						oSalesHeader.BizTalkSalesOrder = 0;
						oSalesHeader.DateSent = "{ts '2001-01-25 00:00:00'}";// "1/25/2001 12:00:00 AM";
						//oSalesHeader.TimeSent = "00:00:00";
						oSalesHeader.BizTalkSalesQuote = 0;
						oSalesHeader.BizTalkSalesOrderCnfmn = 0;
						oSalesHeader.CustomerQuoteNo = "";
						oSalesHeader.CustomerOrderNo = "";
						oSalesHeader.BizTalkDocumentSent = 0;


						oSalesHeader.createSalesLine(transaction);

						try
						{
							oNavisionInterfaceDAO.Navision_InsertSalesHeader(oSalesHeader);
						}
						catch (Exception ex)
						{
							throw (ex);// MessageBox.Show("Transaction failed @ Post Invoice Entry.\r\nException: " + ex.Message, "Error Posting to Navision", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//return false;
						}

					}
					else
					{
						Gen_Journal_Line oGenJournalLine = new Gen_Journal_Line();

						switch (transaction.TransactionCode)
						{
							//if (transaction.TransactionCode == "2000") // CASH PAYMENT
							//{
							case "2000": //cash payment
								oGenJournalLine.JournalTemplateName = "CASHRCPT"; //System.String
								oGenJournalLine.LineNo = startInvoice; //System.Int32
								oGenJournalLine.AccountType = "Bank Account"; //System.String
								oGenJournalLine.AccountNo = "B040"; //System.String
								oGenJournalLine.PostingDate = "{ts '2001-01-25 12:00:00'}"; //System.DateTime
								oGenJournalLine.DocumentType = "Payment"; //System.String
								oGenJournalLine.DocumentNo = "OR" + transaction.ReferenceNo;//"G02012"; //System.String UNIQUE ID
								oGenJournalLine.Description = "House Bank"; //should be TransactionCode.CREDITSIDEMEMO //System.String
								oGenJournalLine.VAT = 0; //System.Double
								oGenJournalLine.BalAccountNo = transaction.AccountID;//"I-0000000028"; //System.String
								oGenJournalLine.CurrencyCode = ""; //System.String
								oGenJournalLine.Amount = double.Parse(transaction.BaseAmount.ToString());//798; //System.Double
								oGenJournalLine.DebitAmount = double.Parse(transaction.BaseAmount.ToString());//798; //System.Double
								oGenJournalLine.CreditAmount = 0; //System.Double
								oGenJournalLine.Amount_LCY = double.Parse(transaction.BaseAmount.ToString());//"798"; //System.Double
								oGenJournalLine.Balance_LCY = 0; //System.Double
								oGenJournalLine.CurrencyFactor = 0; //System.Double
								oGenJournalLine.Sales_Purch_LCY = 0; //System.Double
								oGenJournalLine.Profit_LCY = 0; //System.Double
								oGenJournalLine.InvDiscount_LCY = 0; //System.Double
								oGenJournalLine.Billto_PaytoNo = transaction.AccountID; //System.String
								oGenJournalLine.PostingGroup = "GUEST"; //System.String
								oGenJournalLine.ShortcutDimension1Code = ""; //System.String
								oGenJournalLine.ShortcutDimension2Code = ""; //System.String
								oGenJournalLine.Salespers_PurchCode = ""; //System.String
								oGenJournalLine.SourceCode = "CASHRECJNL"; //System.String
								oGenJournalLine.SystemCreatedEntry = 0;//"False"; //System.Boolean
								oGenJournalLine.OnHold = ""; //System.String
								oGenJournalLine.AppliestoDocType = ""; //System.String
								oGenJournalLine.AppliestoDocNo = ""; //System.String
								oGenJournalLine.DueDate = "{ts '2001-01-25 12:00:00'}"; //System.DateTime
								oGenJournalLine.PmtDiscountDate = "{ts '2001-01-25 12:00:00'}"; //System.DateTime
								oGenJournalLine.PaymentDiscount = double.Parse(transaction.Discount.ToString()); //System.Double
								oGenJournalLine.JobNo = ""; //System.String
								oGenJournalLine.Quantity = 0; //System.Double
								oGenJournalLine.VATAmount = 0; //System.Double
								oGenJournalLine.VATPosting = "Automatic VAT Entry"; //System.String
								oGenJournalLine.PaymentTermsCode = ""; //System.String
								oGenJournalLine.AppliestoID = ""; //System.String
								oGenJournalLine.BusinessUnitCode = ""; //System.String
								oGenJournalLine.JournalBatchName = "BANK"; //System.String
								oGenJournalLine.ReasonCode = ""; //System.String
								oGenJournalLine.RecurringMethod = ""; //System.String
								oGenJournalLine.ExpirationDate = "{ts '2001-01-25 12:00:00'}"; //System.DateTime
								oGenJournalLine.RecurringFrequency = ""; //System.String
								oGenJournalLine.AllocatedAmt_LCY = 0; //System.Double
								oGenJournalLine.GenPostingType = ""; //System.String
								oGenJournalLine.GenBusPostingGroup = ""; //System.String
								oGenJournalLine.GenProdPostingGroup = ""; //System.String
								oGenJournalLine.VATCalculationType = "Normal VAT"; //System.String
								oGenJournalLine.EU3PartyTrade = 0;//"False"; //System.Boolean
								oGenJournalLine.AllowApplication = 1;//"True"; //System.Boolean
								oGenJournalLine.BalAccountType = "Customer"; //System.String
								oGenJournalLine.BalGenPostingType = ""; //System.String
								oGenJournalLine.BalGenBusPostingGroup = ""; //System.String
								oGenJournalLine.BalGenProdPostingGroup = ""; //System.String
								oGenJournalLine.BalVATCalculationType = "Normal VAT"; //System.String
								oGenJournalLine.BalVAT = 0; //System.Double
								oGenJournalLine.BalVATAmount = 0; //System.Double
								oGenJournalLine.BankPaymentType = ""; //System.String
								oGenJournalLine.VATBaseAmount = double.Parse(transaction.BaseAmount.ToString()); //System.Double
								oGenJournalLine.BalVATBaseAmount = double.Parse((transaction.BaseAmount * -1) + "");//"-798"; //System.Double
								oGenJournalLine.Correction = 0;//"False"; //System.Boolean
								oGenJournalLine.CheckPrinted = 0;//"False"; //System.Boolean
								oGenJournalLine.DocumentDate = "{ts '2001-01-25 12:00:00'}"; //System.DateTime
								oGenJournalLine.ExternalDocumentNo = ""; //System.String
								oGenJournalLine.SourceType = ""; //System.String
								oGenJournalLine.SourceNo = ""; //System.String
								oGenJournalLine.PostingNoSeries = ""; //System.String
								oGenJournalLine.TaxAreaCode = ""; //System.String
								oGenJournalLine.TaxLiable = 0;// "False"; //System.Boolean
								oGenJournalLine.TaxGroupCode = ""; //System.String
								oGenJournalLine.UseTax = 0;// "False"; //System.Boolean
								oGenJournalLine.BalTaxAreaCode = ""; //System.String
								oGenJournalLine.BalTaxLiable = 0;// "False"; //System.Boolean
								oGenJournalLine.BalTaxGroupCode = ""; //System.String
								oGenJournalLine.BalUseTax = 0;// "False"; //System.Boolean
								oGenJournalLine.VATBusPostingGroup = ""; //System.String
								oGenJournalLine.VATProdPostingGroup = ""; //System.String
								oGenJournalLine.BalVATBusPostingGroup = ""; //System.String
								oGenJournalLine.BalVATProdPostingGroup = ""; //System.String
								oGenJournalLine.AdditionalCurrencyPosting = "None"; //System.String
								oGenJournalLine.FAAddCurrencyFactor = 0; //System.Double
								oGenJournalLine.SourceCurrencyCode = ""; //System.String
								oGenJournalLine.SourceCurrencyAmount = 0; //System.Double
								oGenJournalLine.SourceCurrVATBaseAmount = 0; //System.Double
								oGenJournalLine.SourceCurrVATAmount = 0; //System.Double
								oGenJournalLine.VATBaseDiscount = 0; //System.Double
								oGenJournalLine.VATAmount_LCY = 0; //System.Double
								oGenJournalLine.VATBaseAmount_LCY = double.Parse(transaction.BaseAmount.ToString());//"798"; //System.Double
								oGenJournalLine.BalVATAmount_LCY = 0; //System.Double
								oGenJournalLine.BalVATBaseAmount_LCY = double.Parse((transaction.BaseAmount * -1) + "");//"-798"; //System.Double
								oGenJournalLine.ReversingEntry = 0;//"False"; //System.Boolean
								oGenJournalLine.AllowZeroAmountPosting = 0;// "False"; //System.Boolean
								oGenJournalLine.Shipto_OrderAddressCode = ""; //System.String
								oGenJournalLine.VATDifference = 0; //System.Double
								oGenJournalLine.BalVATDifference = 0; //System.Double
								oGenJournalLine.ICPartnerCode = ""; //System.String
								oGenJournalLine.ICDirection = "Outgoing"; //System.String
								oGenJournalLine.ICPartnerG_LAccNo = ""; //System.String
								oGenJournalLine.ICPartnerTransactionNo = 0; //System.Int32
								oGenJournalLine.Sellto_BuyfromNo = transaction.AccountID;//"I-0000000028"; //System.String
								oGenJournalLine.VATRegistrationNo = ""; //System.String
								oGenJournalLine.CountryCode = ""; //System.String
								oGenJournalLine.CampaignNo = ""; //System.String
								oGenJournalLine.ProdOrderNo = ""; //System.String
								oGenJournalLine.FAPostingDate = "{ts '2001-01-25 12:00:00'}"; //System.DateTime
								oGenJournalLine.FAPostingType = ""; //System.String
								oGenJournalLine.DepreciationBookCode = ""; //System.String
								oGenJournalLine.SalvageValue = 0; //System.Double
								oGenJournalLine.NoofDepreciationDays = 0; //System.Int32
								oGenJournalLine.DepruntilFAPostingDate = 0;// "False"; //System.Boolean
								oGenJournalLine.DeprAcquisitionCost = 0;// "False"; //System.Boolean
								oGenJournalLine.MaintenanceCode = ""; //System.String
								oGenJournalLine.InsuranceNo = ""; //System.String
								oGenJournalLine.BudgetedFANo = ""; //System.String
								oGenJournalLine.DuplicateinDepreciationBook = ""; //System.String
								oGenJournalLine.UseDuplicationList = 0;// "False"; //System.Boolean
								oGenJournalLine.FAReclassificationEntry = 0;// "False"; //System.Boolean
								oGenJournalLine.FAErrorEntryNo = 0; //System.Int32
								oGenJournalLine.IndexEntry = 0;// "False"; //System.Boolean
								oGenJournalLine.ValueEntryNo = 0; //System.Int32
								oGenJournalLine.Adjustment = 0;//"False"; //System.Boolean
								oGenJournalLine.BASAdjustment = 0;// "False"; //System.Boolean
								oGenJournalLine.AdjustmentAppliesto = ""; //System.String
								oGenJournalLine.AdjmtEntryNo = 0; //System.Int32
								oGenJournalLine.BASDocNo = ""; //System.String
								oGenJournalLine.BASVersion = 0; //System.Int32
								oGenJournalLine.FinancialyVoidedCheque = 0;// "False"; //System.Boolean
								oGenJournalLine.BankBranchNo = ""; //System.String
								oGenJournalLine.BankAccountNo = ""; //System.String
								oGenJournalLine.Customer_VendorBank = ""; //System.String
								oGenJournalLine.WHTBusinessPostingGroup = ""; //System.String
								oGenJournalLine.WHTProductPostingGroup = ""; //System.String
								oGenJournalLine.WHTAbsorbBase = 0; //System.Double
								oGenJournalLine.WHTEntryNo = 0; //System.Int32
								oGenJournalLine.WHTReportLineNo = ""; //System.String
								oGenJournalLine.SkipWHT = 0;// "False"; //System.Boolean
								oGenJournalLine.CertificatePrinted = 0;// "False"; //System.Boolean
								oGenJournalLine.WHTPayment = 0;// "False"; //System.Boolean
								oGenJournalLine.ActualVendorNo = ""; //System.String
								oGenJournalLine.IsWHT = 0;// "False"; //System.Boolean
								oGenJournalLine.VATBase_ACY = 0; //System.Double
								oGenJournalLine.VATAmount_ACY = 0; //System.Double
								oGenJournalLine.AmountIncludingVAT_ACY = 0; //System.Double
								oGenJournalLine.Amount_ACY = 0; //System.Double
								oGenJournalLine.VATDifference_ACY = 0; //System.Double
								oGenJournalLine.VendorExchangeRate_ACY = 0; //System.Double
								oGenJournalLine.PostDatedCheck = 0;//"False"; //System.Boolean
								oGenJournalLine.CheckNo = ""; //System.String
								oGenJournalLine.InterestAmount = 0; //System.Double
								oGenJournalLine.InterestAmount_LCY = 0; //System.Double
								break;
							case "21000":

								//else if (transaction.TransactionCode == "2100") //CREDIT CARD
								//{
								oGenJournalLine.JournalTemplateName = "CASHRCPT"; //System.String
								oGenJournalLine.LineNo = startInvoice; //System.Int32
								oGenJournalLine.AccountType = "G/L Account"; //System.String
								oGenJournalLine.AccountNo = "2386"; //System.String
								oGenJournalLine.PostingDate = "{ts '2001-01-25 00:00:00'}"; //System.DateTime
								oGenJournalLine.DocumentType = "Payment"; //System.String
								oGenJournalLine.DocumentNo = transaction.ReferenceNo; //System.String
								oGenJournalLine.Description = "AR, Credit Cards"; //System.String
								oGenJournalLine.VAT = 0; //System.Double
								oGenJournalLine.BalAccountNo = transaction.AccountID; //System.String
								oGenJournalLine.CurrencyCode = transaction.CurrencyCode; //System.String
								oGenJournalLine.Amount = double.Parse(transaction.BaseAmount.ToString());//900; //System.Double
								oGenJournalLine.DebitAmount = double.Parse(transaction.BaseAmount.ToString());//900; //System.Double
								oGenJournalLine.CreditAmount = 0; //System.Double
								oGenJournalLine.Amount_LCY = double.Parse(transaction.BaseAmount.ToString()); //System.Double
								oGenJournalLine.Balance_LCY = 0; //System.Double
								oGenJournalLine.CurrencyFactor = 0; //System.Double
								oGenJournalLine.Sales_Purch_LCY = 0; //System.Double
								oGenJournalLine.Profit_LCY = 0; //System.Double
								oGenJournalLine.InvDiscount_LCY = 0; //System.Double
								oGenJournalLine.Billto_PaytoNo = transaction.AccountID; //System.String
								oGenJournalLine.PostingGroup = "GUEST"; //System.String
								oGenJournalLine.ShortcutDimension1Code = ""; //System.String
								oGenJournalLine.ShortcutDimension2Code = ""; //System.String
								oGenJournalLine.Salespers_PurchCode = ""; //System.String
								oGenJournalLine.SourceCode = "CASHRECJNL"; //System.String
								oGenJournalLine.SystemCreatedEntry = 0; //System.Boolean
								oGenJournalLine.OnHold = ""; //System.String
								oGenJournalLine.AppliestoDocType = ""; //System.String
								oGenJournalLine.AppliestoDocNo = ""; //System.String
								oGenJournalLine.DueDate = "{ts '2001-01-25 00:00:00'}"; //System.DateTime
								oGenJournalLine.PmtDiscountDate = "{ts '2001-01-25 00:00:00'}"; //System.DateTime
								oGenJournalLine.PaymentDiscount = double.Parse(transaction.Discount.ToString()); //System.Double
								oGenJournalLine.JobNo = ""; //System.String
								oGenJournalLine.Quantity = 0; //System.Double
								oGenJournalLine.VATAmount = 0; //System.Double
								oGenJournalLine.VATPosting = "Automatic VAT Entry"; //System.String
								oGenJournalLine.PaymentTermsCode = ""; //System.String
								oGenJournalLine.AppliestoID = ""; //System.String
								oGenJournalLine.BusinessUnitCode = ""; //System.String
								oGenJournalLine.JournalBatchName = "BANK"; //System.String
								oGenJournalLine.ReasonCode = ""; //System.String
								oGenJournalLine.RecurringMethod = ""; //System.String
								oGenJournalLine.ExpirationDate = "{ts '2001-01-25 00:00:00'}"; //System.DateTime
								oGenJournalLine.RecurringFrequency = ""; //System.String
								oGenJournalLine.AllocatedAmt_LCY = 0; //System.Double
								oGenJournalLine.GenPostingType = ""; //System.String
								oGenJournalLine.GenBusPostingGroup = ""; //System.String
								oGenJournalLine.GenProdPostingGroup = ""; //System.String
								oGenJournalLine.VATCalculationType = "Normal VAT"; //System.String
								oGenJournalLine.EU3PartyTrade = 0; //System.Boolean
								oGenJournalLine.AllowApplication = 1; //System.Boolean
								oGenJournalLine.BalAccountType = "Customer"; //System.String
								oGenJournalLine.BalGenPostingType = ""; //System.String
								oGenJournalLine.BalGenBusPostingGroup = ""; //System.String
								oGenJournalLine.BalGenProdPostingGroup = ""; //System.String
								oGenJournalLine.BalVATCalculationType = "Normal VAT"; //System.String
								oGenJournalLine.BalVAT = 0; //System.Double
								oGenJournalLine.BalVATAmount = 0; //System.Double
								oGenJournalLine.BankPaymentType = ""; //System.String
								oGenJournalLine.VATBaseAmount = double.Parse(transaction.BaseAmount.ToString()); //System.Double
								oGenJournalLine.BalVATBaseAmount = double.Parse((transaction.BaseAmount * -1) + ""); //System.Double
								oGenJournalLine.Correction = 0; //System.Boolean
								oGenJournalLine.CheckPrinted = 0; //System.Boolean
								oGenJournalLine.DocumentDate = "{ts '2001-01-25 00:00:00'}"; //System.DateTime
								oGenJournalLine.ExternalDocumentNo = transaction.FolioID; //System.String
								oGenJournalLine.SourceType = "Customer"; //System.String
								oGenJournalLine.SourceNo = transaction.AccountID; //System.String
								oGenJournalLine.PostingNoSeries = ""; //System.String
								oGenJournalLine.TaxAreaCode = ""; //System.String
								oGenJournalLine.TaxLiable = 0; //System.Boolean
								oGenJournalLine.TaxGroupCode = ""; //System.String
								oGenJournalLine.UseTax = 0; //System.Boolean
								oGenJournalLine.BalTaxAreaCode = ""; //System.String
								oGenJournalLine.BalTaxLiable = 0; //System.Boolean
								oGenJournalLine.BalTaxGroupCode = ""; //System.String
								oGenJournalLine.BalUseTax = 0; //System.Boolean
								oGenJournalLine.VATBusPostingGroup = ""; //System.String
								oGenJournalLine.VATProdPostingGroup = ""; //System.String
								oGenJournalLine.BalVATBusPostingGroup = ""; //System.String
								oGenJournalLine.BalVATProdPostingGroup = ""; //System.String
								oGenJournalLine.AdditionalCurrencyPosting = "None"; //System.String
								oGenJournalLine.FAAddCurrencyFactor = 0; //System.Double
								oGenJournalLine.SourceCurrencyCode = ""; //System.String
								oGenJournalLine.SourceCurrencyAmount = 0; //System.Double
								oGenJournalLine.SourceCurrVATBaseAmount = 0; //System.Double
								oGenJournalLine.SourceCurrVATAmount = 0; //System.Double
								oGenJournalLine.VATBaseDiscount = 0; //System.Double
								oGenJournalLine.VATAmount_LCY = 0; //System.Double
								oGenJournalLine.VATBaseAmount_LCY = double.Parse(transaction.BaseAmount.ToString()); //System.Double
								oGenJournalLine.BalVATAmount_LCY = 0; //System.Double
								oGenJournalLine.BalVATBaseAmount_LCY = double.Parse((transaction.BaseAmount * -1) + ""); //System.Double
								oGenJournalLine.ReversingEntry = 0; //System.Boolean
								oGenJournalLine.AllowZeroAmountPosting = 0; //System.Boolean
								oGenJournalLine.Shipto_OrderAddressCode = ""; //System.String
								oGenJournalLine.VATDifference = 0; //System.Double
								oGenJournalLine.BalVATDifference = 0; //System.Double
								oGenJournalLine.ICPartnerCode = ""; //System.String
								oGenJournalLine.ICDirection = "Outgoing"; //System.String
								oGenJournalLine.ICPartnerG_LAccNo = ""; //System.String
								oGenJournalLine.ICPartnerTransactionNo = 0; //System.Int32
								oGenJournalLine.Sellto_BuyfromNo = transaction.AccountID; //System.String
								oGenJournalLine.VATRegistrationNo = ""; //System.String
								oGenJournalLine.CountryCode = "PH"; //System.String
								oGenJournalLine.CampaignNo = ""; //System.String
								oGenJournalLine.ProdOrderNo = ""; //System.String
								oGenJournalLine.FAPostingDate = "{ts '2001-01-25 00:00:00'}"; //System.DateTime
								oGenJournalLine.FAPostingType = ""; //System.String
								oGenJournalLine.DepreciationBookCode = ""; //System.String
								oGenJournalLine.SalvageValue = 0; //System.Double
								oGenJournalLine.NoofDepreciationDays = 0; //System.Int32
								oGenJournalLine.DepruntilFAPostingDate = 0; //System.Boolean
								oGenJournalLine.DeprAcquisitionCost = 0; //System.Boolean
								oGenJournalLine.MaintenanceCode = ""; //System.String
								oGenJournalLine.InsuranceNo = ""; //System.String
								oGenJournalLine.BudgetedFANo = ""; //System.String
								oGenJournalLine.DuplicateinDepreciationBook = ""; //System.String
								oGenJournalLine.UseDuplicationList = 0; //System.Boolean
								oGenJournalLine.FAReclassificationEntry = 0; //System.Boolean
								oGenJournalLine.FAErrorEntryNo = 0; //System.Int32
								oGenJournalLine.IndexEntry = 0; //System.Boolean
								oGenJournalLine.ValueEntryNo = 0; //System.Int32
								oGenJournalLine.Adjustment = 0; //System.Boolean
								oGenJournalLine.BASAdjustment = 0; //System.Boolean
								oGenJournalLine.AdjustmentAppliesto = ""; //System.String
								oGenJournalLine.AdjmtEntryNo = 0; //System.Int32
								oGenJournalLine.BASDocNo = ""; //System.String
								oGenJournalLine.BASVersion = 0; //System.Int32
								oGenJournalLine.FinancialyVoidedCheque = 0; //System.Boolean
								oGenJournalLine.BankBranchNo = ""; //System.String
								oGenJournalLine.BankAccountNo = ""; //System.String
								oGenJournalLine.Customer_VendorBank = ""; //System.String
								oGenJournalLine.WHTBusinessPostingGroup = ""; //System.String
								oGenJournalLine.WHTProductPostingGroup = ""; //System.String
								oGenJournalLine.WHTAbsorbBase = 0; //System.Double
								oGenJournalLine.WHTEntryNo = 0; //System.Int32
								oGenJournalLine.WHTReportLineNo = ""; //System.String
								oGenJournalLine.SkipWHT = 0; //System.Boolean
								oGenJournalLine.CertificatePrinted = 0; //System.Boolean
								oGenJournalLine.WHTPayment = 0; //System.Boolean
								oGenJournalLine.ActualVendorNo = ""; //System.String
								oGenJournalLine.IsWHT = 0; //System.Boolean
								oGenJournalLine.VATBase_ACY = 0; //System.Double
								oGenJournalLine.VATAmount_ACY = 0; //System.Double
								oGenJournalLine.AmountIncludingVAT_ACY = 0; //System.Double
								oGenJournalLine.Amount_ACY = 0; //System.Double
								oGenJournalLine.VATDifference_ACY = 0; //System.Double
								oGenJournalLine.VendorExchangeRate_ACY = 0; //System.Double
								oGenJournalLine.PostDatedCheck = 0; //System.Boolean
								oGenJournalLine.CheckNo = ""; //System.String
								oGenJournalLine.InterestAmount = 0; //System.Double
								oGenJournalLine.InterestAmount_LCY = 0; //System.Double
								break;
							default:
								oGenJournalLine = null;
								break;
								
						}

						try
						{
							if (oGenJournalLine != null)
							{
								oNavisionInterfaceDAO = new Navision_Interface_DAO(connectionString);
								oNavisionInterfaceDAO.Navision_InsertGenJournalLine(oGenJournalLine);
							}
						}
						catch (Exception ex)
						{
							throw (ex);// MessageBox.Show("Transaction failed @ Post Gen. Journal Line.\r\nException: " + ex.Message, "Error Posting to Navision", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//return false;
						}
					}

					startInvoice++;
				}
				return true;
			}
			catch(Exception ex)
			{
				throw (ex);
			}
		}

    }
}
