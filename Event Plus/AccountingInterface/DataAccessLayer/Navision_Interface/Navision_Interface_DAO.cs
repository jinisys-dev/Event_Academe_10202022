using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.AccountingInterface.Navision_Interface.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.Navision_Interface.Data_Access
{
    class Navision_Interface_DAO
    {

        public Navision_Interface_DAO(string pConnectionString)
        {
            //localConnection = GlobalVariables.PersistentConnection;
			openNavisionDatabaseConnection(pConnectionString);
        }

        #region "NAVISION INTEGRATION"

        private OdbcConnection lOdbcConnection = null;

        // open Navision-Database Connection
		private void openNavisionDatabaseConnection(string pConnectionString)
        {
            try
            {
				lOdbcConnection = new OdbcConnection(pConnectionString);
                lOdbcConnection.Open();
            }
            catch (Exception ex)
            {
                throw(new Exception("Navision Database connection could not be initialized.\r\nException: " + ex.Message));
            }
        }


        // INSERT [SALES HEADER]
        public void Navision_InsertSalesHeader(Sales_Header poSalesHeader)
        {
            string sqlStr = "insert into \"Sales Header\"(";
            sqlStr += "\"Document Type\","; //System.String ,
            sqlStr += "\"Sell-to Customer No_\","; //System.String ,
            sqlStr += "\"No_\","; //System.String ,
            sqlStr += "\"Bill-to Customer No_\","; //System.String ,
            sqlStr += "\"Bill-to Name\","; //System.String ,
            sqlStr += "\"Bill-to Name 2\","; //System.String ,
            sqlStr += "\"Bill-to Address\","; //System.String ,
            sqlStr += "\"Bill-to Address 2\","; //System.String ,
            sqlStr += "\"Bill-to City\","; //System.String ,
            sqlStr += "\"Bill-to Contact\","; //System.String ,
            sqlStr += "\"Your Reference\","; //System.String ,
            sqlStr += "\"Ship-to Code\","; //System.String ,
            sqlStr += "\"Ship-to Name\","; //System.String ,
            sqlStr += "\"Ship-to Name 2\","; //System.String ,
            sqlStr += "\"Ship-to Address\","; //System.String ,
            sqlStr += "\"Ship-to Address 2\","; //System.String ,
            sqlStr += "\"Ship-to City\","; //System.String ,
            sqlStr += "\"Ship-to Contact\","; //System.String ,
            sqlStr += "\"Order Date\","; //System.DateTime ,
            sqlStr += "\"Posting Date\","; //System.DateTime ,
            sqlStr += "\"Shipment Date\","; //System.DateTime ,
            sqlStr += "\"Posting Description\","; //System.String ,
            sqlStr += "\"Payment Terms Code\","; //System.String ,
            sqlStr += "\"Due Date\","; //System.DateTime ,
            sqlStr += "\"Payment Discount %\","; //System.Double ,
            sqlStr += "\"Pmt_ Discount Date\","; //System.DateTime ,
            sqlStr += "\"Shipment Method Code\","; //System.String ,
            sqlStr += "\"Location Code\","; //System.String ,
            sqlStr += "\"Shortcut Dimension 1 Code\","; //System.String ,
            sqlStr += "\"Shortcut Dimension 2 Code\","; //System.String ,
            sqlStr += "\"Customer Posting Group\","; //System.String ,
            sqlStr += "\"Currency Code\","; //System.String ,
            sqlStr += "\"Currency Factor\","; //System.Double ,
            sqlStr += "\"Customer Price Group\","; //System.String ,
            sqlStr += "\"Prices Including VAT\","; //System.Boolean ,
            sqlStr += "\"Invoice Disc_ Code\","; //System.String ,
            sqlStr += "\"Customer Disc_ Group\","; //System.String ,
            sqlStr += "\"Language Code\","; //System.String ,
            sqlStr += "\"Salesperson Code\","; //System.String ,
            sqlStr += "\"Order Class\","; //System.String ,
            sqlStr += "\"Comment\","; //System.Boolean ,
            sqlStr += "\"No_ Printed\","; //System.Int32 ,
            sqlStr += "\"On Hold\","; //System.String ,
            sqlStr += "\"Applies-to Doc_ Type\","; //System.String ,
            sqlStr += "\"Applies-to Doc_ No_\","; //System.String ,
            sqlStr += "\"Bal_ Account No_\","; //System.String ,
            sqlStr += "\"Job No_\","; //System.String ,
            sqlStr += "\"Ship\","; //System.Boolean ,
            sqlStr += "\"Invoice\","; //System.Boolean ,
            sqlStr += "\"Amount\","; //System.Double ,
            sqlStr += "\"Amount Including VAT\","; //System.Double ,
            sqlStr += "\"Shipping No_\","; //System.String ,
            sqlStr += "\"Posting No_\","; //System.String ,
            sqlStr += "\"Last Shipping No_\","; //System.String ,
            sqlStr += "\"Last Posting No_\","; //System.String ,
            sqlStr += "\"VAT Registration No_\","; //System.String ,
            sqlStr += "\"Combine Shipments\","; //System.Boolean ,
            sqlStr += "\"Reason Code\","; //System.String ,
            sqlStr += "\"Gen_ Bus_ Posting Group\","; //System.String ,
            sqlStr += "\"EU 3-Party Trade\","; //System.Boolean ,
            sqlStr += "\"Transaction Type\","; //System.String ,
            sqlStr += "\"Transport Method\","; //System.String ,
            sqlStr += "\"VAT Country Code\","; //System.String ,
            sqlStr += "\"Sell-to Customer Name\","; //System.String ,
            sqlStr += "\"Sell-to Customer Name 2\","; //System.String ,
            sqlStr += "\"Sell-to Address\","; //System.String ,
            sqlStr += "\"Sell-to Address 2\","; //System.String ,
            sqlStr += "\"Sell-to City\","; //System.String ,
            sqlStr += "\"Sell-to Contact\","; //System.String ,
            sqlStr += "\"Bill-to Post Code\","; //System.String ,
            sqlStr += "\"Bill-to County\","; //System.String ,
            sqlStr += "\"Bill-to Country Code\","; //System.String ,
            sqlStr += "\"Sell-to Post Code\","; //System.String ,
            sqlStr += "\"Sell-to County\","; //System.String ,
            sqlStr += "\"Sell-to Country Code\","; //System.String ,
            sqlStr += "\"Ship-to Post Code\","; //System.String ,
            sqlStr += "\"Ship-to County\","; //System.String ,
            sqlStr += "\"Ship-to Country Code\","; //System.String ,
            sqlStr += "\"Bal_ Account Type\","; //System.String ,
            sqlStr += "\"Exit Point\","; //System.String ,
            sqlStr += "\"Correction\","; //System.Boolean ,
            sqlStr += "\"Document Date\","; //System.DateTime ,
            sqlStr += "\"External Document No_\","; //System.String ,
            sqlStr += "\"Area\","; //System.String ,
            sqlStr += "\"Transaction Specification\","; //System.String ,
            sqlStr += "\"Payment Method Code\","; //System.String ,
            sqlStr += "\"Shipping Agent Code\","; //System.String ,
            sqlStr += "\"Package Tracking No_\","; //System.String ,
            sqlStr += "\"No_ Series\","; //System.String ,
            sqlStr += "\"Posting No_ Series\","; //System.String ,
            sqlStr += "\"Shipping No_ Series\","; //System.String ,
            sqlStr += "\"Tax Area Code\","; //System.String ,
            sqlStr += "\"Tax Liable\","; //System.Boolean ,
            sqlStr += "\"VAT Bus_ Posting Group\","; //System.String ,
            sqlStr += "\"Reserve\","; //System.String ,
            sqlStr += "\"Applies-to ID\","; //System.String ,
            sqlStr += "\"VAT Base Discount %\","; //System.Double ,
            sqlStr += "\"Status\","; //System.String ,
            sqlStr += "\"Invoice Discount Calculation\","; //System.String ,
            sqlStr += "\"Invoice Discount Value\","; //System.Double ,
            sqlStr += "\"Send IC Document\","; //System.Boolean ,
            sqlStr += "\"IC Status\","; //System.String ,
            sqlStr += "\"Sell-to IC Partner Code\","; //System.String ,
            sqlStr += "\"Bill-to IC Partner Code\","; //System.String ,
            sqlStr += "\"IC Direction\","; //System.String ,
            sqlStr += "\"No_ of Archived Versions\","; //System.Int32 ,
            sqlStr += "\"Doc_ No_ Occurrence\","; //System.Int32 ,
            sqlStr += "\"Campaign No_\","; //System.String ,
            sqlStr += "\"Sell-to Customer Template Code\","; //System.String ,
            sqlStr += "\"Sell-to Contact No_\","; //System.String ,
            sqlStr += "\"Bill-to Contact No_\","; //System.String ,
            sqlStr += "\"Bill-to Customer Template Code\","; //System.String ,
            sqlStr += "\"Opportunity No_\","; //System.String ,
            sqlStr += "\"Responsibility Center\","; //System.String ,
            sqlStr += "\"Shipping Advice\","; //System.String ,
            sqlStr += "\"Completely Shipped\","; //System.Boolean ,
            sqlStr += "\"Posting from Whse_ Ref_\","; //System.Int32 ,
            sqlStr += "\"Location Filter\","; //System.String ,
            sqlStr += "\"Requested Delivery Date\","; //System.DateTime ,
            sqlStr += "\"Promised Delivery Date\","; //System.DateTime ,
            sqlStr += "\"Shipping Time\","; //System.String ,
            sqlStr += "\"Outbound Whse_ Handling Time\","; //System.String ,
            sqlStr += "\"Shipping Agent Service Code\","; //System.String ,
            sqlStr += "\"Late Order Shipping\","; //System.Boolean ,
            sqlStr += "\"Date Filter\","; //System.DateTime ,
            sqlStr += "\"Receive\","; //System.Boolean ,
            sqlStr += "\"Return Receipt No_\","; //System.String ,
            sqlStr += "\"Return Receipt No_ Series\","; //System.String ,
            sqlStr += "\"Last Return Receipt No_\","; //System.String ,
            sqlStr += "\"Service Mgt_ Document\","; //System.Boolean ,
            sqlStr += "\"Expiration Date\","; //System.DateTime ,
            sqlStr += "\"CP Status\","; //System.String ,
            sqlStr += "\"Auto Created\","; //System.Boolean ,
            sqlStr += "\"Login ID\","; //System.String ,
            sqlStr += "\"Web Site Code\","; //System.String ,
            sqlStr += "\"Allow Line Disc_\","; //System.Boolean ,
            sqlStr += "\"Get Shipment Used\","; //System.Boolean ,
            sqlStr += "\"Adjustment\","; //System.Boolean ,
            sqlStr += "\"BAS Adjustment\","; //System.Boolean ,
            sqlStr += "\"Adjustment Applies-to\","; //System.String ,
            sqlStr += "\"WHT Business Posting Group\","; //System.String ,
            sqlStr += "\"Tax Document Type\","; //System.String ,
            sqlStr += "\"Printed Tax Document\","; //System.Boolean ,
            sqlStr += "\"Posted Tax Document\","; //System.Boolean ,
            sqlStr += "\"Tax Document Marked\","; //System.Boolean ,
            sqlStr += "\"Date Received\","; //System.DateTime ,
            //sqlStr += "\"Time Received\","; //System.TimeSpan ,
            sqlStr += "\"BizTalk Request for Sales Qte_\","; //System.Boolean ,
            sqlStr += "\"BizTalk Sales Order\","; //System.Boolean ,
            sqlStr += "\"Date Sent\","; //System.DateTime ,
            //sqlStr += "\"Time Sent\","; //System.TimeSpan ,
            sqlStr += "\"BizTalk Sales Quote\","; //System.Boolean ,
            sqlStr += "\"BizTalk Sales Order Cnfmn_\","; //System.Boolean ,
            sqlStr += "\"Customer Quote No_\","; //System.String ,
            sqlStr += "\"Customer Order No_\","; //System.String ,
            sqlStr += "\"BizTalk Document Sent\")"; //System.Boolean ,


            sqlStr += " values('" + poSalesHeader.DocumentType + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoCustomerNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.No + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoCustomerNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoName + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoName2 + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoAddress + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoAddress2 + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoCity + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoContact + "',"; //System.String
            sqlStr += "'" + poSalesHeader.YourReference + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoName + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoName2 + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoAddress + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoAddress2 + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoCity + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoContact + "',"; //System.String
            sqlStr += "" + poSalesHeader.OrderDate + ","; //System.DateTime
            sqlStr += "" + poSalesHeader.PostingDate + ","; //System.DateTime
            sqlStr += "" + poSalesHeader.ShipmentDate + ","; //System.DateTime
            sqlStr += "'" + poSalesHeader.PostingDescription + "',"; //System.String
            sqlStr += "'" + poSalesHeader.PaymentTermsCode + "',"; //System.String
            sqlStr += "" + poSalesHeader.DueDate + ","; //System.DateTime
            sqlStr += "" + poSalesHeader.PaymentDiscount + ","; //System.Double
            sqlStr += "" + poSalesHeader.PmtDiscountDate + ","; //System.DateTime
            sqlStr += "'" + poSalesHeader.ShipmentMethodCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.LocationCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShortcutDimension1Code + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShortcutDimension2Code + "',"; //System.String
            sqlStr += "'" + poSalesHeader.CustomerPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesHeader.CurrencyCode + "',"; //System.String
            sqlStr += "" + poSalesHeader.CurrencyFactor + ","; //System.Double
            sqlStr += "'" + poSalesHeader.CustomerPriceGroup + "',"; //System.String
            sqlStr += "" + poSalesHeader.PricesIncludingVAT + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.InvoiceDiscCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.CustomerDiscGroup + "',"; //System.String
            sqlStr += "'" + poSalesHeader.LanguageCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SalespersonCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.OrderClass + "',"; //System.String
            sqlStr += "" + poSalesHeader.Comment + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.NoPrinted + ","; //System.Int32
            sqlStr += "'" + poSalesHeader.OnHold + "',"; //System.String
            sqlStr += "'" + poSalesHeader.AppliestoDocType + "',"; //System.String
            sqlStr += "'" + poSalesHeader.AppliestoDocNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BalAccountNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.JobNo + "',"; //System.String
            sqlStr += "" + poSalesHeader.Ship + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.Invoice + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.Amount + ","; //System.Double
            sqlStr += "" + poSalesHeader.AmountIncludingVAT + ","; //System.Double
            sqlStr += "'" + poSalesHeader.ShippingNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.PostingNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.LastShippingNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.LastPostingNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.VATRegistrationNo + "',"; //System.String
            sqlStr += "" + poSalesHeader.CombineShipments + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.ReasonCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.GenBusPostingGroup + "',"; //System.String
            sqlStr += "" + poSalesHeader.EU3PartyTrade + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.TransactionType + "',"; //System.String
            sqlStr += "'" + poSalesHeader.TransportMethod + "',"; //System.String
            sqlStr += "'" + poSalesHeader.VATCountryCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoCustomerName + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoCustomerName2 + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoAddress + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoAddress2 + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoCity + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoContact + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoPostCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoCounty + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoCountryCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoPostCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoCounty + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoCountryCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoPostCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoCounty + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShiptoCountryCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BalAccountType + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ExitPoint + "',"; //System.String
            sqlStr += "" + poSalesHeader.Correction + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.DocumentDate + ","; //System.DateTime
            sqlStr += "'" + poSalesHeader.ExternalDocumentNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.Area + "',"; //System.String
            sqlStr += "'" + poSalesHeader.TransactionSpecification + "',"; //System.String
            sqlStr += "'" + poSalesHeader.PaymentMethodCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShippingAgentCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.PackageTrackingNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.NoSeries + "',"; //System.String
            sqlStr += "'" + poSalesHeader.PostingNoSeries + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShippingNoSeries + "',"; //System.String
            sqlStr += "'" + poSalesHeader.TaxAreaCode + "',"; //System.String
            sqlStr += "" + poSalesHeader.TaxLiable + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.VATBusPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesHeader.Reserve + "',"; //System.String
            sqlStr += "'" + poSalesHeader.AppliestoID + "',"; //System.String
            sqlStr += "" + poSalesHeader.VATBaseDiscount + ","; //System.Double
            sqlStr += "'" + poSalesHeader.Status + "',"; //System.String
            sqlStr += "'" + poSalesHeader.InvoiceDiscountCalculation + "',"; //System.String
            sqlStr += "" + poSalesHeader.InvoiceDiscountValue + ","; //System.Double
            sqlStr += "" + poSalesHeader.SendICDocument + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.ICStatus + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoICPartnerCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoICPartnerCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ICDirection + "',"; //System.String
            sqlStr += "" + poSalesHeader.NoofArchivedVersions + ","; //System.Int32
            sqlStr += "" + poSalesHeader.DocNoOccurrence + ","; //System.Int32
            sqlStr += "'" + poSalesHeader.CampaignNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoCustomerTemplateCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.SelltoContactNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoContactNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.BilltoCustomerTemplateCode + "',"; //System.String
            sqlStr += "'" + poSalesHeader.OpportunityNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ResponsibilityCenter + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShippingAdvice + "',"; //System.String
            sqlStr += "" + poSalesHeader.CompletelyShipped + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.PostingfromWhseRef + ","; //System.Int32
            sqlStr += "'" + poSalesHeader.LocationFilter + "',"; //System.String
            sqlStr += "" + poSalesHeader.RequestedDeliveryDate + ","; //System.DateTime
            sqlStr += "" + poSalesHeader.PromisedDeliveryDate + ","; //System.DateTime
            sqlStr += "'" + poSalesHeader.ShippingTime + "',"; //System.String
            sqlStr += "'" + poSalesHeader.OutboundWhseHandlingTime + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ShippingAgentServiceCode + "',"; //System.String
            sqlStr += "" + poSalesHeader.LateOrderShipping + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.DateFilter + ","; //System.DateTime
            sqlStr += "" + poSalesHeader.Receive + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.ReturnReceiptNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.ReturnReceiptNoSeries + "',"; //System.String
            sqlStr += "'" + poSalesHeader.LastReturnReceiptNo + "',"; //System.String
            sqlStr += "" + poSalesHeader.ServiceMgtDocument + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.ExpirationDate + ","; //System.DateTime
            sqlStr += "'" + poSalesHeader.CPStatus + "',"; //System.String
            sqlStr += "" + poSalesHeader.AutoCreated + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.LoginID + "',"; //System.String
            sqlStr += "'" + poSalesHeader.WebSiteCode + "',"; //System.String
            sqlStr += "" + poSalesHeader.AllowLineDisc + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.GetShipmentUsed + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.Adjustment + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.BASAdjustment + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.AdjustmentAppliesto + "',"; //System.String
            sqlStr += "'" + poSalesHeader.WHTBusinessPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesHeader.TaxDocumentType + "',"; //System.String
            sqlStr += "" + poSalesHeader.PrintedTaxDocument + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.PostedTaxDocument + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.TaxDocumentMarked + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.DateReceived + ","; //System.DateTime
            //sqlStr += "'" + oSalesHeader.TimeReceived + "',"; //System.TimeSpan
            sqlStr += "" + poSalesHeader.BizTalkRequestforSalesQte + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.BizTalkSalesOrder + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.DateSent + ","; //System.DateTime
            //sqlStr += "'" + oSalesHeader.TimeSent + "',"; //System.TimeSpan
            sqlStr += "" + poSalesHeader.BizTalkSalesQuote + ","; //System.Boolean
            sqlStr += "" + poSalesHeader.BizTalkSalesOrderCnfmn + ","; //System.Boolean
            sqlStr += "'" + poSalesHeader.CustomerQuoteNo + "',"; //System.String
            sqlStr += "'" + poSalesHeader.CustomerOrderNo + "',"; //System.String
            sqlStr += "" + poSalesHeader.BizTalkDocumentSent + ")"; //System.Boolean


            //MessageBox.Show(sqlStr);
            try
            {
                OdbcCommand _insertCommand = new OdbcCommand(sqlStr, lOdbcConnection);
                int _rowsAffected = _insertCommand.ExecuteNonQuery();

                foreach (Sales_Line oSalesLine in poSalesHeader.SalesLineList)
                {
                    Navision_InsertSalesLine(oSalesLine);
                }
                //MessageBox.Show("Transaction successful. (1) Sales header added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lOdbcConnection.Close();
                throw (new Exception("Transaction failed.\r\nException:" + ex.Message));
            }

            
        }

        //insert SALES LINE
        public void Navision_InsertSalesLine(Sales_Line poSalesLine)
        {
            string sqlStr = "insert into \"Sales Line\"(";
            sqlStr += "\"Document Type\","; //System.String ,
            sqlStr += "\"Sell-to Customer No_\","; //System.String ,
            sqlStr += "\"Document No_\","; //System.String ,
            sqlStr += "\"Line No_\","; //System.Int32 ,
            sqlStr += "\"Type\","; //System.String ,
            sqlStr += "\"No_\","; //System.String ,
            sqlStr += "\"Location Code\","; //System.String ,
            sqlStr += "\"Posting Group\","; //System.String ,
            sqlStr += "\"Shipment Date\","; //System.DateTime ,
            sqlStr += "\"Description\","; //System.String ,
            sqlStr += "\"Description 2\","; //System.String ,
            sqlStr += "\"Unit of Measure\","; //System.String ,
            sqlStr += "\"Quantity\","; //System.Double ,
            sqlStr += "\"Outstanding Quantity\","; //System.Double ,
            sqlStr += "\"Qty_ to Invoice\","; //System.Double ,
            sqlStr += "\"Qty_ to Ship\","; //System.Double ,
            sqlStr += "\"Unit Price\","; //System.Double ,
            sqlStr += "\"Unit Cost (LCY)\","; //System.Double ,
            sqlStr += "\"VAT %\","; //System.Double ,
            sqlStr += "\"Line Discount %\","; //System.Double ,
            sqlStr += "\"Line Discount Amount\","; //System.Double ,
            sqlStr += "\"Amount\","; //System.Double ,
            sqlStr += "\"Amount Including VAT\","; //System.Double ,
            sqlStr += "\"Allow Invoice Disc_\","; //System.Boolean ,
            sqlStr += "\"Gross Weight\","; //System.Double ,
            sqlStr += "\"Net Weight\","; //System.Double ,
            sqlStr += "\"Units per Parcel\","; //System.Double ,
            sqlStr += "\"Unit Volume\","; //System.Double ,
            sqlStr += "\"Appl_-to Item Entry\","; //System.Int32 ,
            sqlStr += "\"Shortcut Dimension 1 Code\","; //System.String ,
            sqlStr += "\"Shortcut Dimension 2 Code\","; //System.String ,
            sqlStr += "\"Customer Price Group\","; //System.String ,
            sqlStr += "\"Job No_\","; //System.String ,
            sqlStr += "\"Appl_-to Job Entry\","; //System.Int32 ,
            sqlStr += "\"Phase Code\","; //System.String ,
            sqlStr += "\"Task Code\","; //System.String ,
            sqlStr += "\"Step Code\","; //System.String ,
            sqlStr += "\"Job Applies-to ID\","; //System.String ,
            sqlStr += "\"Apply and Close (Job)\","; //System.Boolean ,
            sqlStr += "\"Work Type Code\","; //System.String ,
            sqlStr += "\"Outstanding Amount\","; //System.Double ,
            sqlStr += "\"Qty_ Shipped Not Invoiced\","; //System.Double ,
            sqlStr += "\"Shipped Not Invoiced\","; //System.Double ,
            sqlStr += "\"Quantity Shipped\","; //System.Double ,
            sqlStr += "\"Quantity Invoiced\","; //System.Double ,
            sqlStr += "\"Shipment No_\","; //System.String ,
            sqlStr += "\"Shipment Line No_\","; //System.Int32 ,
            sqlStr += "\"Profit %\","; //System.Double ,
            sqlStr += "\"Bill-to Customer No_\","; //System.String ,
            sqlStr += "\"Inv_ Discount Amount\","; //System.Double ,
            sqlStr += "\"Purchase Order No_\","; //System.String ,
            sqlStr += "\"Purch_ Order Line No_\","; //System.Int32 ,
            sqlStr += "\"Drop Shipment\","; //System.Boolean ,
            sqlStr += "\"Gen_ Bus_ Posting Group\","; //System.String ,
            sqlStr += "\"Gen_ Prod_ Posting Group\","; //System.String ,
            sqlStr += "\"VAT Calculation Type\","; //System.String ,
            sqlStr += "\"Transaction Type\","; //System.String ,
            sqlStr += "\"Transport Method\","; //System.String ,
            sqlStr += "\"Attached to Line No_\","; //System.Int32 ,
            sqlStr += "\"Exit Point\","; //System.String ,
            sqlStr += "\"Area\","; //System.String ,
            sqlStr += "\"Transaction Specification\","; //System.String ,
            sqlStr += "\"Tax Area Code\","; //System.String ,
            sqlStr += "\"Tax Liable\","; //System.Boolean ,
            sqlStr += "\"Tax Group Code\","; //System.String ,
            sqlStr += "\"VAT Bus_ Posting Group\","; //System.String ,
            sqlStr += "\"VAT Prod_ Posting Group\","; //System.String ,
            sqlStr += "\"Currency Code\","; //System.String ,
            sqlStr += "\"Outstanding Amount (LCY)\","; //System.Double ,
            sqlStr += "\"Shipped Not Invoiced (LCY)\","; //System.Double ,
            sqlStr += "\"Reserved Quantity\","; //System.Double ,
            sqlStr += "\"Reserve\","; //System.String ,
            sqlStr += "\"Blanket Order No_\","; //System.String ,
            sqlStr += "\"Blanket Order Line No_\","; //System.Int32 ,
            sqlStr += "\"VAT Base Amount\","; //System.Double ,
            sqlStr += "\"Unit Cost\","; //System.Double ,
            sqlStr += "\"System-Created Entry\","; //System.Boolean ,
            sqlStr += "\"Line Amount\","; //System.Double ,
            sqlStr += "\"VAT Difference\","; //System.Double ,
            sqlStr += "\"Inv_ Disc_ Amount to Invoice\","; //System.Double ,
            sqlStr += "\"VAT Identifier\","; //System.String ,
            sqlStr += "\"IC Partner Ref_ Type\","; //System.String ,
            sqlStr += "\"IC Partner Reference\","; //System.String ,
            sqlStr += "\"Variant Code\","; //System.String ,
            sqlStr += "\"Bin Code\","; //System.String ,
            sqlStr += "\"Qty_ per Unit of Measure\","; //System.Double ,
            sqlStr += "\"Planned\","; //System.Boolean ,
            sqlStr += "\"Unit of Measure Code\","; //System.String ,
            sqlStr += "\"Quantity (Base)\","; //System.Double ,
            sqlStr += "\"Outstanding Qty_ (Base)\","; //System.Double ,
            sqlStr += "\"Qty_ to Invoice (Base)\","; //System.Double ,
            sqlStr += "\"Qty_ to Ship (Base)\","; //System.Double ,
            sqlStr += "\"Qty_ Shipped Not Invd_ (Base)\","; //System.Double ,
            sqlStr += "\"Qty_ Shipped (Base)\","; //System.Double ,
            sqlStr += "\"Qty_ Invoiced (Base)\","; //System.Double ,
            sqlStr += "\"Reserved Qty_ (Base)\","; //System.Double ,
            //sqlStr += "\"FA Posting Date\","; //System.DateTime ,
            sqlStr += "\"Depreciation Book Code\","; //System.String ,
            sqlStr += "\"Depr_ until FA Posting Date\","; //System.Boolean ,
            sqlStr += "\"Duplicate in Depreciation Book\","; //System.String ,
            sqlStr += "\"Use Duplication List\","; //System.Boolean ,
            sqlStr += "\"Responsibility Center\","; //System.String ,
            sqlStr += "\"Out-of-Stock Substitution\","; //System.Boolean ,
            sqlStr += "\"Substitution Available\","; //System.Boolean ,
            sqlStr += "\"Originally Ordered No_\","; //System.String ,
            sqlStr += "\"Originally Ordered Var_ Code\","; //System.String ,
            sqlStr += "\"Cross-Reference No_\","; //System.String ,
            sqlStr += "\"Unit of Measure (Cross Ref_)\","; //System.String ,
            sqlStr += "\"Cross-Reference Type\","; //System.String ,
            sqlStr += "\"Cross-Reference Type No_\","; //System.String ,
            sqlStr += "\"Item Category Code\","; //System.String ,
            sqlStr += "\"Nonstock\","; //System.Boolean ,
            sqlStr += "\"Purchasing Code\","; //System.String ,
            sqlStr += "\"Product Group Code\","; //System.String ,
            sqlStr += "\"Special Order\","; //System.Boolean ,
            sqlStr += "\"Special Order Purchase No_\","; //System.String ,
            sqlStr += "\"Special Order Purch_ Line No_\","; //System.Int32 ,
            sqlStr += "\"Whse_ Outstanding Qty_ (Base)\","; //System.Double ,
            sqlStr += "\"Completely Shipped\","; //System.Boolean ,
            //sqlStr += "\"Requested Delivery Date\","; //System.DateTime ,
            //sqlStr += "\"Promised Delivery Date\","; //System.DateTime ,
            sqlStr += "\"Shipping Time\","; //System.String ,
            sqlStr += "\"Outbound Whse_ Handling Time\","; //System.String ,
            sqlStr += "\"Planned Delivery Date\","; //System.DateTime ,
            sqlStr += "\"Planned Shipment Date\","; //System.DateTime ,
            sqlStr += "\"Shipping Agent Code\","; //System.String ,
            sqlStr += "\"Shipping Agent Service Code\","; //System.String ,
            sqlStr += "\"Allow Item Charge Assignment\","; //System.Boolean ,
            sqlStr += "\"Qty_ to Assign\","; //System.Double ,
            sqlStr += "\"Qty_ Assigned\","; //System.Double ,
            sqlStr += "\"Return Qty_ to Receive\","; //System.Double ,
            sqlStr += "\"Return Qty_ to Receive (Base)\","; //System.Double ,
            sqlStr += "\"Return Qty_ Rcd_ Not Invd_\","; //System.Double ,
            sqlStr += "\"Ret_ Qty_ Rcd_ Not Invd_(Base)\","; //System.Double ,
            sqlStr += "\"Return Rcd_ Not Invd_\","; //System.Double ,
            sqlStr += "\"Return Rcd_ Not Invd_ (LCY)\","; //System.Double ,
            sqlStr += "\"Return Qty_ Received\","; //System.Double ,
            sqlStr += "\"Return Qty_ Received (Base)\","; //System.Double ,
            sqlStr += "\"Appl_-from Item Entry\","; //System.Int32 ,
            sqlStr += "\"Service Contract No_\","; //System.String ,
            sqlStr += "\"Service Order No_\","; //System.String ,
            sqlStr += "\"Service Item No_\","; //System.String ,
            sqlStr += "\"Appl_-to Service Entry\","; //System.Int32 ,
            sqlStr += "\"Service Item Line No_\","; //System.Int32 ,
            sqlStr += "\"Serv_ Price Adjmt_ Gr_ Code\","; //System.String ,
            sqlStr += "\"BOM Item No_\","; //System.String ,
            sqlStr += "\"Return Receipt No_\","; //System.String ,
            sqlStr += "\"Return Receipt Line No_\","; //System.Int32 ,
            sqlStr += "\"Return Reason Code\","; //System.String ,
            sqlStr += "\"Allow Line Disc_\","; //System.Boolean ,
            sqlStr += "\"Customer Disc_ Group\","; //System.String ,
            //sqlStr += "\"Service Posting Date\","; //System.DateTime ,
            sqlStr += "\"WHT Business Posting Group\","; //System.String ,
            sqlStr += "\"WHT Product Posting Group\","; //System.String ,
            sqlStr += "\"WHT Absorb Base\")"; //System.Double ,


            sqlStr += "values('" + poSalesLine.DocumentType + "',"; //System.String
            sqlStr += "'" + poSalesLine.SelltoCustomerNo + "',"; //System.String
            sqlStr += "'" + poSalesLine.DocumentNo + "',"; //System.String
            sqlStr += "" + poSalesLine.LineNo + ","; //System.Int32
            sqlStr += "'" + poSalesLine.Type + "',"; //System.String
            sqlStr += "'" + poSalesLine.No + "',"; //System.String
            sqlStr += "'" + poSalesLine.LocationCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.PostingGroup + "',"; //System.String
            sqlStr += "" + poSalesLine.ShipmentDate + ","; //System.DateTime
            sqlStr += "'" + poSalesLine.Description + "',"; //System.String
            sqlStr += "'" + poSalesLine.Description2 + "',"; //System.String
            sqlStr += "'" + poSalesLine.UnitofMeasure + "',"; //System.String
            sqlStr += "" + poSalesLine.Quantity + ","; //System.Double
            sqlStr += "" + poSalesLine.OutstandingQuantity + ","; //System.Double
            sqlStr += "" + poSalesLine.QtytoInvoice + ","; //System.Double
            sqlStr += "" + poSalesLine.QtytoShip + ","; //System.Double
            sqlStr += "" + poSalesLine.UnitPrice + ","; //System.Double
            sqlStr += "" + poSalesLine.UnitCost_LCY + ","; //System.Double
            sqlStr += "" + poSalesLine.VAT + ","; //System.Double
            sqlStr += "" + poSalesLine.LineDiscount + ","; //System.Double
            sqlStr += "" + poSalesLine.LineDiscountAmount + ","; //System.Double
            sqlStr += "" + poSalesLine.Amount + ","; //System.Double
            sqlStr += "" + poSalesLine.AmountIncludingVAT + ","; //System.Double
            sqlStr += "" + poSalesLine.AllowInvoiceDisc + ","; //System.Boolean
            sqlStr += "" + poSalesLine.GrossWeight + ","; //System.Double
            sqlStr += "" + poSalesLine.NetWeight + ","; //System.Double
            sqlStr += "" + poSalesLine.UnitsperParcel + ","; //System.Double
            sqlStr += "" + poSalesLine.UnitVolume + ","; //System.Double
            sqlStr += "" + poSalesLine.AppltoItemEntry + ","; //System.Int32
            sqlStr += "'" + poSalesLine.ShortcutDimension1Code + "',"; //System.String
            sqlStr += "'" + poSalesLine.ShortcutDimension2Code + "',"; //System.String
            sqlStr += "'" + poSalesLine.CustomerPriceGroup + "',"; //System.String
            sqlStr += "'" + poSalesLine.JobNo + "',"; //System.String
            sqlStr += "" + poSalesLine.AppltoJobEntry + ","; //System.Int32
            sqlStr += "'" + poSalesLine.PhaseCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.TaskCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.StepCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.JobAppliestoID + "',"; //System.String
            sqlStr += "" + poSalesLine.ApplyandClose_Job + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.WorkTypeCode + "',"; //System.String
            sqlStr += "" + poSalesLine.OutstandingAmount + ","; //System.Double
            sqlStr += "" + poSalesLine.QtyShippedNotInvoiced + ","; //System.Double
            sqlStr += "" + poSalesLine.ShippedNotInvoiced + ","; //System.Double
            sqlStr += "" + poSalesLine.QuantityShipped + ","; //System.Double
            sqlStr += "" + poSalesLine.QuantityInvoiced + ","; //System.Double
            sqlStr += "'" + poSalesLine.ShipmentNo + "',"; //System.String
            sqlStr += "" + poSalesLine.ShipmentLineNo + ","; //System.Int32
            sqlStr += "" + poSalesLine.Profit + ","; //System.Double
            sqlStr += "'" + poSalesLine.BilltoCustomerNo + "',"; //System.String
            sqlStr += "" + poSalesLine.InvDiscountAmount + ","; //System.Double
            sqlStr += "'" + poSalesLine.PurchaseOrderNo + "',"; //System.String
            sqlStr += "" + poSalesLine.PurchOrderLineNo + ","; //System.Int32
            sqlStr += "" + poSalesLine.DropShipment + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.GenBusPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesLine.GenProdPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesLine.VATCalculationType + "',"; //System.String
            sqlStr += "'" + poSalesLine.TransactionType + "',"; //System.String
            sqlStr += "'" + poSalesLine.TransportMethod + "',"; //System.String
            sqlStr += "" + poSalesLine.AttachedtoLineNo + ","; //System.Int32
            sqlStr += "'" + poSalesLine.ExitPoint + "',"; //System.String
            sqlStr += "'" + poSalesLine.Area + "',"; //System.String
            sqlStr += "'" + poSalesLine.TransactionSpecification + "',"; //System.String
            sqlStr += "'" + poSalesLine.TaxAreaCode + "',"; //System.String
            sqlStr += "" + poSalesLine.TaxLiable + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.TaxGroupCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.VATBusPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesLine.VATProdPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesLine.CurrencyCode + "',"; //System.String
            sqlStr += "" + poSalesLine.OutstandingAmount_LCY + ","; //System.Double
            sqlStr += "" + poSalesLine.ShippedNotInvoiced_LCY + ","; //System.Double
            sqlStr += "" + poSalesLine.ReservedQuantity + ","; //System.Double
            sqlStr += "'" + poSalesLine.Reserve + "',"; //System.String
            sqlStr += "'" + poSalesLine.BlanketOrderNo + "',"; //System.String
            sqlStr += "" + poSalesLine.BlanketOrderLineNo + ","; //System.Int32
            sqlStr += "" + poSalesLine.VATBaseAmount + ","; //System.Double
            sqlStr += "" + poSalesLine.UnitCost + ","; //System.Double
            sqlStr += "" + poSalesLine.SystemCreatedEntry + ","; //System.Boolean
            sqlStr += "" + poSalesLine.LineAmount + ","; //System.Double
            sqlStr += "" + poSalesLine.VATDifference + ","; //System.Double
            sqlStr += "" + poSalesLine.InvDiscAmounttoInvoice + ","; //System.Double
            sqlStr += "'" + poSalesLine.VATIdentifier + "',"; //System.String
            sqlStr += "'" + poSalesLine.ICPartnerRefType + "',"; //System.String
            sqlStr += "'" + poSalesLine.ICPartnerReference + "',"; //System.String
            sqlStr += "'" + poSalesLine.VariantCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.BinCode + "',"; //System.String
            sqlStr += "" + poSalesLine.QtyperUnitofMeasure + ","; //System.Double
            sqlStr += "" + poSalesLine.Planned + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.UnitofMeasureCode + "',"; //System.String
            sqlStr += "" + poSalesLine.Quantity_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.OutstandingQty_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.QtytoInvoice_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.QtytoShip_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.QtyShippedNotInvd_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.QtyShipped_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.QtyInvoiced_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.ReservedQty_Base + ","; //System.Double
            //sqlStr += "" + oSalesLine.FAPostingDate + ","; //System.DateTime
            sqlStr += "'" + poSalesLine.DepreciationBookCode + "',"; //System.String
            sqlStr += "" + poSalesLine.DepruntilFAPostingDate + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.DuplicateinDepreciationBook + "',"; //System.String
            sqlStr += "" + poSalesLine.UseDuplicationList + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.ResponsibilityCenter + "',"; //System.String
            sqlStr += "" + poSalesLine.OutofStockSubstitution + ","; //System.Boolean
            sqlStr += "" + poSalesLine.SubstitutionAvailable + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.OriginallyOrderedNo + "',"; //System.String
            sqlStr += "'" + poSalesLine.OriginallyOrderedVarCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.CrossReferenceNo + "',"; //System.String
            sqlStr += "'" + poSalesLine.UnitofMeasure_CrossRef + "',"; //System.String
            sqlStr += "'" + poSalesLine.CrossReferenceType + "',"; //System.String
            sqlStr += "'" + poSalesLine.CrossReferenceTypeNo + "',"; //System.String
            sqlStr += "'" + poSalesLine.ItemCategoryCode + "',"; //System.String
            sqlStr += "" + poSalesLine.Nonstock + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.PurchasingCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.ProductGroupCode + "',"; //System.String
            sqlStr += "" + poSalesLine.SpecialOrder + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.SpecialOrderPurchaseNo + "',"; //System.String
            sqlStr += "" + poSalesLine.SpecialOrderPurchLineNo + ","; //System.Int32
            sqlStr += "" + poSalesLine.WhseOutstandingQty_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.CompletelyShipped + ","; //System.Boolean
            //sqlStr += "" + oSalesLine.RequestedDeliveryDate + ","; //System.DateTime
            //sqlStr += "" + oSalesLine.PromisedDeliveryDate + ","; //System.DateTime
            sqlStr += "'" + poSalesLine.ShippingTime + "',"; //System.String
            sqlStr += "'" + poSalesLine.OutboundWhseHandlingTime + "',"; //System.String
            sqlStr += "" + poSalesLine.PlannedDeliveryDate + ","; //System.DateTime
            sqlStr += "" + poSalesLine.PlannedShipmentDate + ","; //System.DateTime
            sqlStr += "'" + poSalesLine.ShippingAgentCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.ShippingAgentServiceCode + "',"; //System.String
            sqlStr += "" + poSalesLine.AllowItemChargeAssignment + ","; //System.Boolean
            sqlStr += "" + poSalesLine.QtytoAssign + ","; //System.Double
            sqlStr += "" + poSalesLine.QtyAssigned + ","; //System.Double
            sqlStr += "" + poSalesLine.ReturnQtytoReceive + ","; //System.Double
            sqlStr += "" + poSalesLine.ReturnQtytoReceive_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.ReturnQtyRcdNotInvd + ","; //System.Double
            sqlStr += "" + poSalesLine.RetQtyRcdNotInvd_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.ReturnRcdNotInvd + ","; //System.Double
            sqlStr += "" + poSalesLine.ReturnRcdNotInvd_LCY + ","; //System.Double
            sqlStr += "" + poSalesLine.ReturnQtyReceived + ","; //System.Double
            sqlStr += "" + poSalesLine.ReturnQtyReceived_Base + ","; //System.Double
            sqlStr += "" + poSalesLine.ApplfromItemEntry + ","; //System.Int32
            sqlStr += "'" + poSalesLine.ServiceContractNo + "',"; //System.String
            sqlStr += "'" + poSalesLine.ServiceOrderNo + "',"; //System.String
            sqlStr += "'" + poSalesLine.ServiceItemNo + "',"; //System.String
            sqlStr += "" + poSalesLine.AppltoServiceEntry + ","; //System.Int32
            sqlStr += "" + poSalesLine.ServiceItemLineNo + ","; //System.Int32
            sqlStr += "'" + poSalesLine.ServPriceAdjmtGrCode + "',"; //System.String
            sqlStr += "'" + poSalesLine.BOMItemNo + "',"; //System.String
            sqlStr += "'" + poSalesLine.ReturnReceiptNo + "',"; //System.String
            sqlStr += "" + poSalesLine.ReturnReceiptLineNo + ","; //System.Int32
            sqlStr += "'" + poSalesLine.ReturnReasonCode + "',"; //System.String
            sqlStr += "" + poSalesLine.AllowLineDisc + ","; //System.Boolean
            sqlStr += "'" + poSalesLine.CustomerDiscGroup + "',"; //System.String
            //sqlStr += "" + oSalesLine.ServicePostingDate + ","; //System.DateTime
            sqlStr += "'" + poSalesLine.WHTBusinessPostingGroup + "',"; //System.String
            sqlStr += "'" + poSalesLine.WHTProductPostingGroup + "',"; //System.String
            sqlStr += "" + poSalesLine.WHTAbsorbBase + ")"; //System.Double




            try
            {
                OdbcCommand _insertCommand = new OdbcCommand(sqlStr, lOdbcConnection);
                int _rowsAffected = _insertCommand.ExecuteNonQuery();

                //MessageBox.Show("Transaction successful. (1) Sales header added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw (new Exception("Transaction failed.\r\nException:" + ex.Message));
            }


        }

        // INSERT [GEN. JOURNAL LINE]
        public void Navision_InsertGenJournalLine(Gen_Journal_Line poGenJournalLine)
        {
            string sqlStr = "insert into \"Gen. Journal Line\"(";
            sqlStr += "\"Journal Template Name\", "; //System.String
            sqlStr += "\"Line No_\", "; //System.Int32
            sqlStr += "\"Account Type\", "; //System.String
            sqlStr += "\"Account No_\", "; //System.String
            sqlStr += "\"Posting Date\", "; //System.DateTime
            sqlStr += "\"Document Type\", "; //System.String
            sqlStr += "\"Document No_\", "; //System.String
            sqlStr += "\"Description\", "; //System.String
            sqlStr += "\"VAT %\", "; //System.Double
            sqlStr += "\"Bal_ Account No_\", "; //System.String
            sqlStr += "\"Currency Code\", "; //System.String
            sqlStr += "\"Amount\", "; //System.Double
            sqlStr += "\"Debit Amount\", "; //System.Double
            sqlStr += "\"Credit Amount\", "; //System.Double
            sqlStr += "\"Amount (LCY)\", "; //System.Double
            sqlStr += "\"Balance (LCY)\", "; //System.Double
            sqlStr += "\"Currency Factor\", "; //System.Double
            sqlStr += "\"Sales/Purch_ (LCY)\", "; //System.Double
            sqlStr += "\"Profit (LCY)\", "; //System.Double
            sqlStr += "\"Inv_ Discount (LCY)\", "; //System.Double
            sqlStr += "\"Bill-to/Pay-to No_\", "; //System.String
            sqlStr += "\"Posting Group\", "; //System.String
            sqlStr += "\"Shortcut Dimension 1 Code\", "; //System.String
            sqlStr += "\"Shortcut Dimension 2 Code\", "; //System.String
            sqlStr += "\"Salespers_/Purch_ Code\", "; //System.String
            sqlStr += "\"Source Code\", "; //System.String
            sqlStr += "\"System-Created Entry\", "; //System.Boolean
            sqlStr += "\"On Hold\", "; //System.String
            sqlStr += "\"Applies-to Doc_ Type\", "; //System.String
            sqlStr += "\"Applies-to Doc_ No_\", "; //System.String
            sqlStr += "\"Due Date\", "; //System.DateTime
            sqlStr += "\"Pmt_ Discount Date\", "; //System.DateTime
            sqlStr += "\"Payment Discount %\", "; //System.Double
            sqlStr += "\"Job No_\", "; //System.String
            sqlStr += "\"Quantity\", "; //System.Double
            sqlStr += "\"VAT Amount\", "; //System.Double
            sqlStr += "\"VAT Posting\", "; //System.String
            sqlStr += "\"Payment Terms Code\", "; //System.String
            sqlStr += "\"Applies-to ID\", "; //System.String
            sqlStr += "\"Business Unit Code\", "; //System.String
            sqlStr += "\"Journal Batch Name\", "; //System.String
            sqlStr += "\"Reason Code\", "; //System.String
            sqlStr += "\"Recurring Method\", "; //System.String
            sqlStr += "\"Expiration Date\", "; //System.DateTime
            sqlStr += "\"Recurring Frequency\", "; //System.String
            sqlStr += "\"Allocated Amt_ (LCY)\", "; //System.Double
            sqlStr += "\"Gen_ Posting Type\", "; //System.String
            sqlStr += "\"Gen_ Bus_ Posting Group\", "; //System.String
            sqlStr += "\"Gen_ Prod_ Posting Group\", "; //System.String
            sqlStr += "\"VAT Calculation Type\", "; //System.String
            sqlStr += "\"EU 3-Party Trade\", "; //System.Boolean
            sqlStr += "\"Allow Application\", "; //System.Boolean
            sqlStr += "\"Bal_ Account Type\", "; //System.String
            sqlStr += "\"Bal_ Gen_ Posting Type\", "; //System.String
            sqlStr += "\"Bal_ Gen_ Bus_ Posting Group\", "; //System.String
            sqlStr += "\"Bal_ Gen_ Prod_ Posting Group\", "; //System.String
            sqlStr += "\"Bal_ VAT Calculation Type\", "; //System.String
            sqlStr += "\"Bal_ VAT %\", "; //System.Double
            sqlStr += "\"Bal_ VAT Amount\", "; //System.Double
            sqlStr += "\"Bank Payment Type\", "; //System.String
            sqlStr += "\"VAT Base Amount\", "; //System.Double
            sqlStr += "\"Bal_ VAT Base Amount\", "; //System.Double
            sqlStr += "\"Correction\", "; //System.Boolean
            sqlStr += "\"Check Printed\", "; //System.Boolean
            sqlStr += "\"Document Date\", "; //System.DateTime
            sqlStr += "\"External Document No_\", "; //System.String
            sqlStr += "\"Source Type\", "; //System.String
            sqlStr += "\"Source No_\", "; //System.String
            sqlStr += "\"Posting No_ Series\", "; //System.String
            sqlStr += "\"Tax Area Code\", "; //System.String
            sqlStr += "\"Tax Liable\", "; //System.Boolean
            sqlStr += "\"Tax Group Code\", "; //System.String
            sqlStr += "\"Use Tax\", "; //System.Boolean
            sqlStr += "\"Bal_ Tax Area Code\", "; //System.String
            sqlStr += "\"Bal_ Tax Liable\", "; //System.Boolean
            sqlStr += "\"Bal_ Tax Group Code\", "; //System.String
            sqlStr += "\"Bal_ Use Tax\", "; //System.Boolean
            sqlStr += "\"VAT Bus_ Posting Group\", "; //System.String
            sqlStr += "\"VAT Prod_ Posting Group\", "; //System.String
            sqlStr += "\"Bal_ VAT Bus_ Posting Group\", "; //System.String
            sqlStr += "\"Bal_ VAT Prod_ Posting Group\", "; //System.String
            sqlStr += "\"Additional-Currency Posting\", "; //System.String
            sqlStr += "\"FA Add_-Currency Factor\", "; //System.Double
            sqlStr += "\"Source Currency Code\", "; //System.String
            sqlStr += "\"Source Currency Amount\", "; //System.Double
            sqlStr += "\"Source Curr_ VAT Base Amount\", "; //System.Double
            sqlStr += "\"Source Curr_ VAT Amount\", "; //System.Double
            sqlStr += "\"VAT Base Discount %\", "; //System.Double
            sqlStr += "\"VAT Amount (LCY)\", "; //System.Double
            sqlStr += "\"VAT Base Amount (LCY)\", "; //System.Double
            sqlStr += "\"Bal_ VAT Amount (LCY)\", "; //System.Double
            sqlStr += "\"Bal_ VAT Base Amount (LCY)\", "; //System.Double
            sqlStr += "\"Reversing Entry\", "; //System.Boolean
            sqlStr += "\"Allow Zero-Amount Posting\", "; //System.Boolean
            sqlStr += "\"Ship-to/Order Address Code\", "; //System.String
            sqlStr += "\"VAT Difference\", "; //System.Double
            sqlStr += "\"Bal_ VAT Difference\", "; //System.Double
            sqlStr += "\"IC Partner Code\", "; //System.String
            sqlStr += "\"IC Direction\", "; //System.String
            sqlStr += "\"IC Partner G/L Acc_ No_\", "; //System.String
            sqlStr += "\"IC Partner Transaction No_\", "; //System.Int32
            sqlStr += "\"Sell-to/Buy-from No_\", "; //System.String
            sqlStr += "\"VAT Registration No_\", "; //System.String
            sqlStr += "\"Country Code\", "; //System.String
            sqlStr += "\"Campaign No_\", "; //System.String
            sqlStr += "\"Prod_ Order No_\", "; //System.String
            sqlStr += "\"FA Posting Date\", "; //System.DateTime
            sqlStr += "\"FA Posting Type\", "; //System.String
            sqlStr += "\"Depreciation Book Code\", "; //System.String
            sqlStr += "\"Salvage Value\", "; //System.Double
            sqlStr += "\"No_ of Depreciation Days\", "; //System.Int32
            sqlStr += "\"Depr_ until FA Posting Date\", "; //System.Boolean
            sqlStr += "\"Depr_ Acquisition Cost\", "; //System.Boolean
            sqlStr += "\"Maintenance Code\", "; //System.String
            sqlStr += "\"Insurance No_\", "; //System.String
            sqlStr += "\"Budgeted FA No_\", "; //System.String
            sqlStr += "\"Duplicate in Depreciation Book\", "; //System.String
            sqlStr += "\"Use Duplication List\", "; //System.Boolean
            sqlStr += "\"FA Reclassification Entry\", "; //System.Boolean
            sqlStr += "\"FA Error Entry No_\", "; //System.Int32
            sqlStr += "\"Index Entry\", "; //System.Boolean
            sqlStr += "\"Value Entry No_\", "; //System.Int32
            sqlStr += "\"Adjustment\", "; //System.Boolean
            sqlStr += "\"BAS Adjustment\", "; //System.Boolean
            sqlStr += "\"Adjustment Applies-to\", "; //System.String
            sqlStr += "\"Adjmt_ Entry No_\", "; //System.Int32
            sqlStr += "\"BAS Doc_ No_\", "; //System.String
            sqlStr += "\"BAS Version\", "; //System.Int32
            sqlStr += "\"Financialy Voided Cheque\", "; //System.Boolean
            sqlStr += "\"Bank Branch No_\", "; //System.String
            sqlStr += "\"Bank Account No_\", "; //System.String
            sqlStr += "\"Customer/Vendor Bank\", "; //System.String
            sqlStr += "\"WHT Business Posting Group\", "; //System.String
            sqlStr += "\"WHT Product Posting Group\", "; //System.String
            sqlStr += "\"WHT Absorb Base\", "; //System.Double
            sqlStr += "\"WHT Entry No_\", "; //System.Int32
            sqlStr += "\"WHT Report Line No_\", "; //System.String
            sqlStr += "\"Skip WHT\", "; //System.Boolean
            sqlStr += "\"Certificate Printed\", "; //System.Boolean
            sqlStr += "\"WHT Payment\", "; //System.Boolean
            sqlStr += "\"Actual Vendor No_\", "; //System.String
            sqlStr += "\"Is WHT\", "; //System.Boolean
            sqlStr += "\"VAT Base (ACY)\", "; //System.Double
            sqlStr += "\"VAT Amount (ACY)\", "; //System.Double
            sqlStr += "\"Amount Including VAT (ACY)\", "; //System.Double
            sqlStr += "\"Amount (ACY)\", "; //System.Double
            sqlStr += "\"VAT Difference (ACY)\", "; //System.Double
            sqlStr += "\"Vendor Exchange Rate (ACY)\", "; //System.Double
            sqlStr += "\"Post Dated Check\", "; //System.Boolean
            sqlStr += "\"Check No_\", "; //System.String
            sqlStr += "\"Interest Amount\", "; //System.Double
            sqlStr += "\"Interest Amount (LCY)\")"; //System.Double


            sqlStr += " values('" + poGenJournalLine.JournalTemplateName + "',";//System.String
            sqlStr += "" + poGenJournalLine.LineNo + ",";//System.Int32
            sqlStr += "'" + poGenJournalLine.AccountType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.AccountNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.PostingDate + ",";//System.DateTime
            sqlStr += "'" + poGenJournalLine.DocumentType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.DocumentNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.Description + "',";//System.String
            sqlStr += "" + poGenJournalLine.VAT + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.BalAccountNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.CurrencyCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.Amount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.DebitAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.CreditAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.Amount_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.Balance_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.CurrencyFactor + ",";//System.Double
            sqlStr += "" + poGenJournalLine.Sales_Purch_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.Profit_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.InvDiscount_LCY + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.Billto_PaytoNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.PostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.ShortcutDimension1Code + "',";//System.String
            sqlStr += "'" + poGenJournalLine.ShortcutDimension2Code + "',";//System.String
            sqlStr += "'" + poGenJournalLine.Salespers_PurchCode + "',";//System.String
            sqlStr += "'" + poGenJournalLine.SourceCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.SystemCreatedEntry + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.OnHold + "',";//System.String
            sqlStr += "'" + poGenJournalLine.AppliestoDocType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.AppliestoDocNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.DueDate + ",";//System.DateTime
            sqlStr += "" + poGenJournalLine.PmtDiscountDate + ",";//System.DateTime
            sqlStr += "" + poGenJournalLine.PaymentDiscount + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.JobNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.Quantity + ",";//System.Double
            sqlStr += "" + poGenJournalLine.VATAmount + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.VATPosting + "',";//System.String
            sqlStr += "'" + poGenJournalLine.PaymentTermsCode + "',";//System.String
            sqlStr += "'" + poGenJournalLine.AppliestoID + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BusinessUnitCode + "',";//System.String
            sqlStr += "'" + poGenJournalLine.JournalBatchName + "',";//System.String
            sqlStr += "'" + poGenJournalLine.ReasonCode + "',";//System.String
            sqlStr += "'" + poGenJournalLine.RecurringMethod + "',";//System.String
            sqlStr += "" + poGenJournalLine.ExpirationDate + ",";//System.DateTime
            sqlStr += "'" + poGenJournalLine.RecurringFrequency + "',";//System.String
            sqlStr += "" + poGenJournalLine.AllocatedAmt_LCY + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.GenPostingType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.GenBusPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.GenProdPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.VATCalculationType + "',";//System.String
            sqlStr += "" + poGenJournalLine.EU3PartyTrade + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.AllowApplication + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.BalAccountType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BalGenPostingType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BalGenBusPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BalGenProdPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BalVATCalculationType + "',";//System.String
            sqlStr += "" + poGenJournalLine.BalVAT + ",";//System.Double
            sqlStr += "" + poGenJournalLine.BalVATAmount + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.BankPaymentType + "',";//System.String
            sqlStr += "" + poGenJournalLine.VATBaseAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.BalVATBaseAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.Correction + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.CheckPrinted + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.DocumentDate + ",";//System.DateTime
            sqlStr += "'" + poGenJournalLine.ExternalDocumentNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.SourceType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.SourceNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.PostingNoSeries + "',";//System.String
            sqlStr += "'" + poGenJournalLine.TaxAreaCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.TaxLiable + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.TaxGroupCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.UseTax + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.BalTaxAreaCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.BalTaxLiable + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.BalTaxGroupCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.BalUseTax + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.VATBusPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.VATProdPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BalVATBusPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BalVATProdPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.AdditionalCurrencyPosting + "',";//System.String
            sqlStr += "" + poGenJournalLine.FAAddCurrencyFactor + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.SourceCurrencyCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.SourceCurrencyAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.SourceCurrVATBaseAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.SourceCurrVATAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.VATBaseDiscount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.VATAmount_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.VATBaseAmount_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.BalVATAmount_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.BalVATBaseAmount_LCY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.ReversingEntry + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.AllowZeroAmountPosting + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.Shipto_OrderAddressCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.VATDifference + ",";//System.Double
            sqlStr += "" + poGenJournalLine.BalVATDifference + ",";//System.Double
            sqlStr += "'" + poGenJournalLine.ICPartnerCode + "',";//System.String
            sqlStr += "'" + poGenJournalLine.ICDirection + "',";//System.String
            sqlStr += "'" + poGenJournalLine.ICPartnerG_LAccNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.ICPartnerTransactionNo + ",";//System.Int32
            sqlStr += "'" + poGenJournalLine.Sellto_BuyfromNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.VATRegistrationNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.CountryCode + "',";//System.String
            sqlStr += "'" + poGenJournalLine.CampaignNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.ProdOrderNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.FAPostingDate + ",";//System.DateTime
            sqlStr += "'" + poGenJournalLine.FAPostingType + "',";//System.String
            sqlStr += "'" + poGenJournalLine.DepreciationBookCode + "',";//System.String
            sqlStr += "" + poGenJournalLine.SalvageValue + ",";//System.Double
            sqlStr += "" + poGenJournalLine.NoofDepreciationDays + ",";//System.Int32
            sqlStr += "" + poGenJournalLine.DepruntilFAPostingDate + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.DeprAcquisitionCost + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.MaintenanceCode + "',";//System.String
            sqlStr += "'" + poGenJournalLine.InsuranceNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BudgetedFANo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.DuplicateinDepreciationBook + "',";//System.String
            sqlStr += "" + poGenJournalLine.UseDuplicationList + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.FAReclassificationEntry + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.FAErrorEntryNo + ",";//System.Int32
            sqlStr += "" + poGenJournalLine.IndexEntry + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.ValueEntryNo + ",";//System.Int32
            sqlStr += "" + poGenJournalLine.Adjustment + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.BASAdjustment + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.AdjustmentAppliesto + "',";//System.String
            sqlStr += "" + poGenJournalLine.AdjmtEntryNo + ",";//System.Int32
            sqlStr += "'" + poGenJournalLine.BASDocNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.BASVersion + ",";//System.Int32
            sqlStr += "" + poGenJournalLine.FinancialyVoidedCheque + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.BankBranchNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.BankAccountNo + "',";//System.String
            sqlStr += "'" + poGenJournalLine.Customer_VendorBank + "',";//System.String
            sqlStr += "'" + poGenJournalLine.WHTBusinessPostingGroup + "',";//System.String
            sqlStr += "'" + poGenJournalLine.WHTProductPostingGroup + "',";//System.String
            sqlStr += "" + poGenJournalLine.WHTAbsorbBase + ",";//System.Double
            sqlStr += "" + poGenJournalLine.WHTEntryNo + ",";//System.Int32
            sqlStr += "'" + poGenJournalLine.WHTReportLineNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.SkipWHT + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.CertificatePrinted + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.WHTPayment + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.ActualVendorNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.IsWHT + ",";//System.Boolean
            sqlStr += "" + poGenJournalLine.VATBase_ACY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.VATAmount_ACY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.AmountIncludingVAT_ACY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.Amount_ACY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.VATDifference_ACY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.VendorExchangeRate_ACY + ",";//System.Double
            sqlStr += "" + poGenJournalLine.PostDatedCheck + ",";//System.Boolean
            sqlStr += "'" + poGenJournalLine.CheckNo + "',";//System.String
            sqlStr += "" + poGenJournalLine.InterestAmount + ",";//System.Double
            sqlStr += "" + poGenJournalLine.InterestAmount_LCY + ")";//System.Double



            try
            {
                OdbcCommand _insertCommand = new OdbcCommand(sqlStr, lOdbcConnection);
                int _rowsAffected = _insertCommand.ExecuteNonQuery();

                //MessageBox.Show("Transaction successful. (1) Sales header added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lOdbcConnection.Close();
                throw (new Exception("Transaction failed.\r\nException:" + ex.Message));
            }

        }


        #endregion

   
    }
}
