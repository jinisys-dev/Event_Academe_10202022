using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.AccountingInterface.Navision_Interface
{
    namespace BusinessLayer
    {
        public class Sales_Header
        {
            private string mDocumentType;
            public string DocumentType
            {
                get { return mDocumentType; }
                set { mDocumentType = value; }
            }

            private string mSelltoCustomerNo;
            public string SelltoCustomerNo
            {
                get { return mSelltoCustomerNo; }
                set { mSelltoCustomerNo = value; }
            }

            private string mNo;
            public string No
            {
                get { return mNo; }
                set { mNo = value; }
            }

            private string mBilltoCustomerNo;
            public string BilltoCustomerNo
            {
                get { return mBilltoCustomerNo; }
                set { mBilltoCustomerNo = value; }
            }

            private string mBilltoName;
            public string BilltoName
            {
                get { return mBilltoName; }
                set { mBilltoName = value; }
            }

            private string mBilltoName2;
            public string BilltoName2
            {
                get { return mBilltoName2; }
                set { mBilltoName2 = value; }
            }

            private string mBilltoAddress;
            public string BilltoAddress
            {
                get { return mBilltoAddress; }
                set { mBilltoAddress = value; }
            }

            private string mBilltoAddress2;
            public string BilltoAddress2
            {
                get { return mBilltoAddress2; }
                set { mBilltoAddress2 = value; }
            }

            private string mBilltoCity;
            public string BilltoCity
            {
                get { return mBilltoCity; }
                set { mBilltoCity = value; }
            }

            private string mBilltoContact;
            public string BilltoContact
            {
                get { return mBilltoContact; }
                set { mBilltoContact = value; }
            }

            private string mYourReference;
            public string YourReference
            {
                get { return mYourReference; }
                set { mYourReference = value; }
            }

            private string mShiptoCode;
            public string ShiptoCode
            {
                get { return mShiptoCode; }
                set { mShiptoCode = value; }
            }

            private string mShiptoName;
            public string ShiptoName
            {
                get { return mShiptoName; }
                set { mShiptoName = value; }
            }

            private string mShiptoName2;
            public string ShiptoName2
            {
                get { return mShiptoName2; }
                set { mShiptoName2 = value; }
            }

            private string mShiptoAddress;
            public string ShiptoAddress
            {
                get { return mShiptoAddress; }
                set { mShiptoAddress = value; }
            }

            private string mShiptoAddress2;
            public string ShiptoAddress2
            {
                get { return mShiptoAddress2; }
                set { mShiptoAddress2 = value; }
            }

            private string mShiptoCity;
            public string ShiptoCity
            {
                get { return mShiptoCity; }
                set { mShiptoCity = value; }
            }

            private string mShiptoContact;
            public string ShiptoContact
            {
                get { return mShiptoContact; }
                set { mShiptoContact = value; }
            }

            private string mOrderDate;
            public string OrderDate
            {
                get { return mOrderDate; }
                set { mOrderDate = value; }
            }

            private string mPostingDate;
            public string PostingDate
            {
                get { return mPostingDate; }
                set { mPostingDate = value; }
            }

            private string mShipmentDate;
            public string ShipmentDate
            {
                get { return mShipmentDate; }
                set { mShipmentDate = value; }
            }

            private string mPostingDescription;
            public string PostingDescription
            {
                get { return mPostingDescription; }
                set { mPostingDescription = value; }
            }

            private string mPaymentTermsCode;
            public string PaymentTermsCode
            {
                get { return mPaymentTermsCode; }
                set { mPaymentTermsCode = value; }
            }

            private string mDueDate;
            public string DueDate
            {
                get { return mDueDate; }
                set { mDueDate = value; }
            }

            private double mPaymentDiscount;
            public double PaymentDiscount
            {
                get { return mPaymentDiscount; }
                set { mPaymentDiscount = value; }
            }

            private string mPmtDiscountDate;
            public string PmtDiscountDate
            {
                get { return mPmtDiscountDate; }
                set { mPmtDiscountDate = value; }
            }

            private string mShipmentMethodCode;
            public string ShipmentMethodCode
            {
                get { return mShipmentMethodCode; }
                set { mShipmentMethodCode = value; }
            }

            private string mLocationCode;
            public string LocationCode
            {
                get { return mLocationCode; }
                set { mLocationCode = value; }
            }

            private string mShortcutDimension1Code;
            public string ShortcutDimension1Code
            {
                get { return mShortcutDimension1Code; }
                set { mShortcutDimension1Code = value; }
            }

            private string mShortcutDimension2Code;
            public string ShortcutDimension2Code
            {
                get { return mShortcutDimension2Code; }
                set { mShortcutDimension2Code = value; }
            }

            private string mCustomerPostingGroup;
            public string CustomerPostingGroup
            {
                get { return mCustomerPostingGroup; }
                set { mCustomerPostingGroup = value; }
            }

            private string mCurrencyCode;
            public string CurrencyCode
            {
                get { return mCurrencyCode; }
                set { mCurrencyCode = value; }
            }

            private double mCurrencyFactor;
            public double CurrencyFactor
            {
                get { return mCurrencyFactor; }
                set { mCurrencyFactor = value; }
            }

            private string mCustomerPriceGroup;
            public string CustomerPriceGroup
            {
                get { return mCustomerPriceGroup; }
                set { mCustomerPriceGroup = value; }
            }

            private int mPricesIncludingVAT;
            public int PricesIncludingVAT
            {
                get { return mPricesIncludingVAT; }
                set { mPricesIncludingVAT = value; }
            }

            private string mInvoiceDiscCode;
            public string InvoiceDiscCode
            {
                get { return mInvoiceDiscCode; }
                set { mInvoiceDiscCode = value; }
            }

            private string mCustomerDiscGroup;
            public string CustomerDiscGroup
            {
                get { return mCustomerDiscGroup; }
                set { mCustomerDiscGroup = value; }
            }

            private string mLanguageCode;
            public string LanguageCode
            {
                get { return mLanguageCode; }
                set { mLanguageCode = value; }
            }

            private string mSalespersonCode;
            public string SalespersonCode
            {
                get { return mSalespersonCode; }
                set { mSalespersonCode = value; }
            }

            private string mOrderClass;
            public string OrderClass
            {
                get { return mOrderClass; }
                set { mOrderClass = value; }
            }

            private int mComment;
            public int Comment
            {
                get { return mComment; }
                set { mComment = value; }
            }

            private Int32 mNoPrinted;
            public Int32 NoPrinted
            {
                get { return mNoPrinted; }
                set { mNoPrinted = value; }
            }

            private string mOnHold;
            public string OnHold
            {
                get { return mOnHold; }
                set { mOnHold = value; }
            }

            private string mAppliestoDocType;
            public string AppliestoDocType
            {
                get { return mAppliestoDocType; }
                set { mAppliestoDocType = value; }
            }

            private string mAppliestoDocNo;
            public string AppliestoDocNo
            {
                get { return mAppliestoDocNo; }
                set { mAppliestoDocNo = value; }
            }

            private string mBalAccountNo;
            public string BalAccountNo
            {
                get { return mBalAccountNo; }
                set { mBalAccountNo = value; }
            }

            private string mJobNo;
            public string JobNo
            {
                get { return mJobNo; }
                set { mJobNo = value; }
            }

            private int mShip;
            public int Ship
            {
                get { return mShip; }
                set { mShip = value; }
            }

            private int mInvoice;
            public int Invoice
            {
                get { return mInvoice; }
                set { mInvoice = value; }
            }

            private double mAmount;
            public double Amount
            {
                get { return mAmount; }
                set { mAmount = value; }
            }

            private double mAmountIncludingVAT;
            public double AmountIncludingVAT
            {
                get { return mAmountIncludingVAT; }
                set { mAmountIncludingVAT = value; }
            }

            private string mShippingNo;
            public string ShippingNo
            {
                get { return mShippingNo; }
                set { mShippingNo = value; }
            }

            private string mPostingNo;
            public string PostingNo
            {
                get { return mPostingNo; }
                set { mPostingNo = value; }
            }

            private string mLastShippingNo;
            public string LastShippingNo
            {
                get { return mLastShippingNo; }
                set { mLastShippingNo = value; }
            }

            private string mLastPostingNo;
            public string LastPostingNo
            {
                get { return mLastPostingNo; }
                set { mLastPostingNo = value; }
            }

            private string mVATRegistrationNo;
            public string VATRegistrationNo
            {
                get { return mVATRegistrationNo; }
                set { mVATRegistrationNo = value; }
            }

            private int mCombineShipments;
            public int CombineShipments
            {
                get { return mCombineShipments; }
                set { mCombineShipments = value; }
            }

            private string mReasonCode;
            public string ReasonCode
            {
                get { return mReasonCode; }
                set { mReasonCode = value; }
            }

            private string mGenBusPostingGroup;
            public string GenBusPostingGroup
            {
                get { return mGenBusPostingGroup; }
                set { mGenBusPostingGroup = value; }
            }

            private int mEU3PartyTrade;
            public int EU3PartyTrade
            {
                get { return mEU3PartyTrade; }
                set { mEU3PartyTrade = value; }
            }

            private string mTransactionType;
            public string TransactionType
            {
                get { return mTransactionType; }
                set { mTransactionType = value; }
            }

            private string mTransportMethod;
            public string TransportMethod
            {
                get { return mTransportMethod; }
                set { mTransportMethod = value; }
            }

            private string mVATCountryCode;
            public string VATCountryCode
            {
                get { return mVATCountryCode; }
                set { mVATCountryCode = value; }
            }

            private string mSelltoCustomerName;
            public string SelltoCustomerName
            {
                get { return mSelltoCustomerName; }
                set { mSelltoCustomerName = value; }
            }

            private string mSelltoCustomerName2;
            public string SelltoCustomerName2
            {
                get { return mSelltoCustomerName2; }
                set { mSelltoCustomerName2 = value; }
            }

            private string mSelltoAddress;
            public string SelltoAddress
            {
                get { return mSelltoAddress; }
                set { mSelltoAddress = value; }
            }

            private string mSelltoAddress2;
            public string SelltoAddress2
            {
                get { return mSelltoAddress2; }
                set { mSelltoAddress2 = value; }
            }

            private string mSelltoCity;
            public string SelltoCity
            {
                get { return mSelltoCity; }
                set { mSelltoCity = value; }
            }

            private string mSelltoContact;
            public string SelltoContact
            {
                get { return mSelltoContact; }
                set { mSelltoContact = value; }
            }

            private string mBilltoPostCode;
            public string BilltoPostCode
            {
                get { return mBilltoPostCode; }
                set { mBilltoPostCode = value; }
            }

            private string mBilltoCounty;
            public string BilltoCounty
            {
                get { return mBilltoCounty; }
                set { mBilltoCounty = value; }
            }

            private string mBilltoCountryCode;
            public string BilltoCountryCode
            {
                get { return mBilltoCountryCode; }
                set { mBilltoCountryCode = value; }
            }

            private string mSelltoPostCode;
            public string SelltoPostCode
            {
                get { return mSelltoPostCode; }
                set { mSelltoPostCode = value; }
            }

            private string mSelltoCounty;
            public string SelltoCounty
            {
                get { return mSelltoCounty; }
                set { mSelltoCounty = value; }
            }

            private string mSelltoCountryCode;
            public string SelltoCountryCode
            {
                get { return mSelltoCountryCode; }
                set { mSelltoCountryCode = value; }
            }

            private string mShiptoPostCode;
            public string ShiptoPostCode
            {
                get { return mShiptoPostCode; }
                set { mShiptoPostCode = value; }
            }

            private string mShiptoCounty;
            public string ShiptoCounty
            {
                get { return mShiptoCounty; }
                set { mShiptoCounty = value; }
            }

            private string mShiptoCountryCode;
            public string ShiptoCountryCode
            {
                get { return mShiptoCountryCode; }
                set { mShiptoCountryCode = value; }
            }

            private string mBalAccountType;
            public string BalAccountType
            {
                get { return mBalAccountType; }
                set { mBalAccountType = value; }
            }

            private string mExitPoint;
            public string ExitPoint
            {
                get { return mExitPoint; }
                set { mExitPoint = value; }
            }

            private int mCorrection;
            public int Correction
            {
                get { return mCorrection; }
                set { mCorrection = value; }
            }

            private string mDocumentDate;
            public string DocumentDate
            {
                get { return mDocumentDate; }
                set { mDocumentDate = value; }
            }

            private string mExternalDocumentNo;
            public string ExternalDocumentNo
            {
                get { return mExternalDocumentNo; }
                set { mExternalDocumentNo = value; }
            }

            private string mArea;
            public string Area
            {
                get { return mArea; }
                set { mArea = value; }
            }

            private string mTransactionSpecification;
            public string TransactionSpecification
            {
                get { return mTransactionSpecification; }
                set { mTransactionSpecification = value; }
            }

            private string mPaymentMethodCode;
            public string PaymentMethodCode
            {
                get { return mPaymentMethodCode; }
                set { mPaymentMethodCode = value; }
            }

            private string mShippingAgentCode;
            public string ShippingAgentCode
            {
                get { return mShippingAgentCode; }
                set { mShippingAgentCode = value; }
            }

            private string mPackageTrackingNo;
            public string PackageTrackingNo
            {
                get { return mPackageTrackingNo; }
                set { mPackageTrackingNo = value; }
            }

            private string mNoSeries;
            public string NoSeries
            {
                get { return mNoSeries; }
                set { mNoSeries = value; }
            }

            private string mPostingNoSeries;
            public string PostingNoSeries
            {
                get { return mPostingNoSeries; }
                set { mPostingNoSeries = value; }
            }

            private string mShippingNoSeries;
            public string ShippingNoSeries
            {
                get { return mShippingNoSeries; }
                set { mShippingNoSeries = value; }
            }

            private string mTaxAreaCode;
            public string TaxAreaCode
            {
                get { return mTaxAreaCode; }
                set { mTaxAreaCode = value; }
            }

            private int mTaxLiable;
            public int TaxLiable
            {
                get { return mTaxLiable; }
                set { mTaxLiable = value; }
            }

            private string mVATBusPostingGroup;
            public string VATBusPostingGroup
            {
                get { return mVATBusPostingGroup; }
                set { mVATBusPostingGroup = value; }
            }

            private string mReserve;
            public string Reserve
            {
                get { return mReserve; }
                set { mReserve = value; }
            }

            private string mAppliestoID;
            public string AppliestoID
            {
                get { return mAppliestoID; }
                set { mAppliestoID = value; }
            }

            private double mVATBaseDiscount;
            public double VATBaseDiscount
            {
                get { return mVATBaseDiscount; }
                set { mVATBaseDiscount = value; }
            }

            private string mStatus;
            public string Status
            {
                get { return mStatus; }
                set { mStatus = value; }
            }

            private string mInvoiceDiscountCalculation;
            public string InvoiceDiscountCalculation
            {
                get { return mInvoiceDiscountCalculation; }
                set { mInvoiceDiscountCalculation = value; }
            }

            private double mInvoiceDiscountValue;
            public double InvoiceDiscountValue
            {
                get { return mInvoiceDiscountValue; }
                set { mInvoiceDiscountValue = value; }
            }

            private int mSendICDocument;
            public int SendICDocument
            {
                get { return mSendICDocument; }
                set { mSendICDocument = value; }
            }

            private string mICStatus;
            public string ICStatus
            {
                get { return mICStatus; }
                set { mICStatus = value; }
            }

            private string mSelltoICPartnerCode;
            public string SelltoICPartnerCode
            {
                get { return mSelltoICPartnerCode; }
                set { mSelltoICPartnerCode = value; }
            }

            private string mBilltoICPartnerCode;
            public string BilltoICPartnerCode
            {
                get { return mBilltoICPartnerCode; }
                set { mBilltoICPartnerCode = value; }
            }

            private string mICDirection;
            public string ICDirection
            {
                get { return mICDirection; }
                set { mICDirection = value; }
            }

            private Int32 mNoofArchivedVersions;
            public Int32 NoofArchivedVersions
            {
                get { return mNoofArchivedVersions; }
                set { mNoofArchivedVersions = value; }
            }

            private Int32 mDocNoOccurrence;
            public Int32 DocNoOccurrence
            {
                get { return mDocNoOccurrence; }
                set { mDocNoOccurrence = value; }
            }

            private string mCampaignNo;
            public string CampaignNo
            {
                get { return mCampaignNo; }
                set { mCampaignNo = value; }
            }

            private string mSelltoCustomerTemplateCode;
            public string SelltoCustomerTemplateCode
            {
                get { return mSelltoCustomerTemplateCode; }
                set { mSelltoCustomerTemplateCode = value; }
            }

            private string mSelltoContactNo;
            public string SelltoContactNo
            {
                get { return mSelltoContactNo; }
                set { mSelltoContactNo = value; }
            }

            private string mBilltoContactNo;
            public string BilltoContactNo
            {
                get { return mBilltoContactNo; }
                set { mBilltoContactNo = value; }
            }

            private string mBilltoCustomerTemplateCode;
            public string BilltoCustomerTemplateCode
            {
                get { return mBilltoCustomerTemplateCode; }
                set { mBilltoCustomerTemplateCode = value; }
            }

            private string mOpportunityNo;
            public string OpportunityNo
            {
                get { return mOpportunityNo; }
                set { mOpportunityNo = value; }
            }

            private string mResponsibilityCenter;
            public string ResponsibilityCenter
            {
                get { return mResponsibilityCenter; }
                set { mResponsibilityCenter = value; }
            }

            private string mShippingAdvice;
            public string ShippingAdvice
            {
                get { return mShippingAdvice; }
                set { mShippingAdvice = value; }
            }

            private int mCompletelyShipped;
            public int CompletelyShipped
            {
                get { return mCompletelyShipped; }
                set { mCompletelyShipped = value; }
            }

            private Int32 mPostingfromWhseRef;
            public Int32 PostingfromWhseRef
            {
                get { return mPostingfromWhseRef; }
                set { mPostingfromWhseRef = value; }
            }

            private string mLocationFilter;
            public string LocationFilter
            {
                get { return mLocationFilter; }
                set { mLocationFilter = value; }
            }

            private string mRequestedDeliveryDate;
            public string RequestedDeliveryDate
            {
                get { return mRequestedDeliveryDate; }
                set { mRequestedDeliveryDate = value; }
            }

            private string mPromisedDeliveryDate;
            public string PromisedDeliveryDate
            {
                get { return mPromisedDeliveryDate; }
                set { mPromisedDeliveryDate = value; }
            }

            private string mShippingTime;
            public string ShippingTime
            {
                get { return mShippingTime; }
                set { mShippingTime = value; }
            }

            private string mOutboundWhseHandlingTime;
            public string OutboundWhseHandlingTime
            {
                get { return mOutboundWhseHandlingTime; }
                set { mOutboundWhseHandlingTime = value; }
            }

            private string mShippingAgentServiceCode;
            public string ShippingAgentServiceCode
            {
                get { return mShippingAgentServiceCode; }
                set { mShippingAgentServiceCode = value; }
            }

            private int mLateOrderShipping;
            public int LateOrderShipping
            {
                get { return mLateOrderShipping; }
                set { mLateOrderShipping = value; }
            }

            private string mDateFilter;
            public string DateFilter
            {
                get { return mDateFilter; }
                set { mDateFilter = value; }
            }

            private int mReceive;
            public int Receive
            {
                get { return mReceive; }
                set { mReceive = value; }
            }

            private string mReturnReceiptNo;
            public string ReturnReceiptNo
            {
                get { return mReturnReceiptNo; }
                set { mReturnReceiptNo = value; }
            }

            private string mReturnReceiptNoSeries;
            public string ReturnReceiptNoSeries
            {
                get { return mReturnReceiptNoSeries; }
                set { mReturnReceiptNoSeries = value; }
            }

            private string mLastReturnReceiptNo;
            public string LastReturnReceiptNo
            {
                get { return mLastReturnReceiptNo; }
                set { mLastReturnReceiptNo = value; }
            }

            private int mServiceMgtDocument;
            public int ServiceMgtDocument
            {
                get { return mServiceMgtDocument; }
                set { mServiceMgtDocument = value; }
            }

            private string mExpirationDate;
            public string ExpirationDate
            {
                get { return mExpirationDate; }
                set { mExpirationDate = value; }
            }

            private string mCPStatus;
            public string CPStatus
            {
                get { return mCPStatus; }
                set { mCPStatus = value; }
            }

            private int mAutoCreated;
            public int AutoCreated
            {
                get { return mAutoCreated; }
                set { mAutoCreated = value; }
            }

            private string mLoginID;
            public string LoginID
            {
                get { return mLoginID; }
                set { mLoginID = value; }
            }

            private string mWebSiteCode;
            public string WebSiteCode
            {
                get { return mWebSiteCode; }
                set { mWebSiteCode = value; }
            }

            private int mAllowLineDisc;
            public int AllowLineDisc
            {
                get { return mAllowLineDisc; }
                set { mAllowLineDisc = value; }
            }

            private int mGetShipmentUsed;
            public int GetShipmentUsed
            {
                get { return mGetShipmentUsed; }
                set { mGetShipmentUsed = value; }
            }

            private int mAdjustment;
            public int Adjustment
            {
                get { return mAdjustment; }
                set { mAdjustment = value; }
            }

            private int mBASAdjustment;
            public int BASAdjustment
            {
                get { return mBASAdjustment; }
                set { mBASAdjustment = value; }
            }

            private string mAdjustmentAppliesto;
            public string AdjustmentAppliesto
            {
                get { return mAdjustmentAppliesto; }
                set { mAdjustmentAppliesto = value; }
            }

            private string mWHTBusinessPostingGroup;
            public string WHTBusinessPostingGroup
            {
                get { return mWHTBusinessPostingGroup; }
                set { mWHTBusinessPostingGroup = value; }
            }

            private string mTaxDocumentType;
            public string TaxDocumentType
            {
                get { return mTaxDocumentType; }
                set { mTaxDocumentType = value; }
            }

            private int mPrintedTaxDocument;
            public int PrintedTaxDocument
            {
                get { return mPrintedTaxDocument; }
                set { mPrintedTaxDocument = value; }
            }

            private int mPostedTaxDocument;
            public int PostedTaxDocument
            {
                get { return mPostedTaxDocument; }
                set { mPostedTaxDocument = value; }
            }

            private int mTaxDocumentMarked;
            public int TaxDocumentMarked
            {
                get { return mTaxDocumentMarked; }
                set { mTaxDocumentMarked = value; }
            }

            private string mDateReceived;
            public string DateReceived
            {
                get { return mDateReceived; }
                set { mDateReceived = value; }
            }

            private TimeSpan mTimeReceived;
            public TimeSpan TimeReceived
            {
                get { return mTimeReceived; }
                set { mTimeReceived = value; }
            }

            private int mBizTalkRequestforSalesQte;
            public int BizTalkRequestforSalesQte
            {
                get { return mBizTalkRequestforSalesQte; }
                set { mBizTalkRequestforSalesQte = value; }
            }

            private int mBizTalkSalesOrder;
            public int BizTalkSalesOrder
            {
                get { return mBizTalkSalesOrder; }
                set { mBizTalkSalesOrder = value; }
            }

            private string mDateSent;
            public string DateSent
            {
                get { return mDateSent; }
                set { mDateSent = value; }
            }

            private TimeSpan mTimeSent;
            public TimeSpan TimeSent
            {
                get { return mTimeSent; }
                set { mTimeSent = value; }
            }

            private int mBizTalkSalesQuote;
            public int BizTalkSalesQuote
            {
                get { return mBizTalkSalesQuote; }
                set { mBizTalkSalesQuote = value; }
            }

            private int mBizTalkSalesOrderCnfmn;
            public int BizTalkSalesOrderCnfmn
            {
                get { return mBizTalkSalesOrderCnfmn; }
                set { mBizTalkSalesOrderCnfmn = value; }
            }

            private string mCustomerQuoteNo;
            public string CustomerQuoteNo
            {
                get { return mCustomerQuoteNo; }
                set { mCustomerQuoteNo = value; }
            }

            private string mCustomerOrderNo;
            public string CustomerOrderNo
            {
                get { return mCustomerOrderNo; }
                set { mCustomerOrderNo = value; }
            }

            private int mBizTalkDocumentSent;
            public int BizTalkDocumentSent
            {
                get { return mBizTalkDocumentSent; }
                set { mBizTalkDocumentSent = value; }
            }


            private IList<Sales_Line> mSalesLineList;
            public IList<Sales_Line> SalesLineList
            {
                get { return mSalesLineList; }
                set { mSalesLineList = value; }
            }


            TransactionCode oTransactionCode;
            TransactionCodeFacade oTransactionCodeFacade = new TransactionCodeFacade();

            public void createSalesLine(FolioTransaction oFolioTransaction)
            {
                IList<Sales_Line> oSalesLineList = new List<Sales_Line>();
                oTransactionCode = new TransactionCode();

                oTransactionCode = oTransactionCodeFacade.getTransactionCode(oFolioTransaction.TransactionCode);

                Sales_Line oSalesLine = new Sales_Line();
                oSalesLine.DocumentType = "Invoice";
                oSalesLine.SelltoCustomerNo = oFolioTransaction.AccountID;
                oSalesLine.DocumentNo = this.No;
                oSalesLine.LineNo = 10000;
                oSalesLine.Type = "G/L Account";
                oSalesLine.No = "6961";                 // should be replace by GoverntmentTax.oTransactionCode.DebitSideMemo
                oSalesLine.LocationCode = "";
                oSalesLine.PostingGroup = "";
                oSalesLine.ShipmentDate = "{ts '2001-01-25 00:00:00'}";
                oSalesLine.Description = "Room Sales";   // should be replaced by oTransactionCode.DebitSideMemo
                oSalesLine.Description2 = "";
                oSalesLine.UnitofMeasure = "Day";
                oSalesLine.Quantity = 1;
                oSalesLine.OutstandingQuantity = 1;
                oSalesLine.QtytoInvoice = 1;
                oSalesLine.QtytoShip = 1;
                oSalesLine.UnitPrice = double.Parse((oFolioTransaction.NetBaseAmount + oFolioTransaction.Discount) + "" );
                oSalesLine.UnitCost_LCY = 0;
                oSalesLine.VAT = 0;
                oSalesLine.LineDiscount = 0;
                oSalesLine.LineDiscountAmount = 0;
                oSalesLine.Amount = 0;
                oSalesLine.AmountIncludingVAT = 0;
                oSalesLine.AllowInvoiceDisc = 0;
                oSalesLine.GrossWeight = 0;
                oSalesLine.NetWeight = 0;
                oSalesLine.UnitsperParcel = 0;
                oSalesLine.UnitVolume = 0;
                oSalesLine.AppltoItemEntry = 0;
                oSalesLine.ShortcutDimension1Code = "";
                oSalesLine.ShortcutDimension2Code = "";
                oSalesLine.CustomerPriceGroup = "";
                oSalesLine.JobNo = "";
                oSalesLine.AppltoJobEntry = 0;
                oSalesLine.PhaseCode = "";
                oSalesLine.TaskCode = "";
                oSalesLine.StepCode = "";
                oSalesLine.JobAppliestoID = "";
                oSalesLine.ApplyandClose_Job = 0;
                oSalesLine.WorkTypeCode = "";
                oSalesLine.OutstandingAmount = double.Parse((oFolioTransaction.NetBaseAmount + oFolioTransaction.Discount) + "");
                oSalesLine.QtyShippedNotInvoiced = 0;
                oSalesLine.ShippedNotInvoiced = 0;
                oSalesLine.QuantityShipped = 0;
                oSalesLine.QuantityInvoiced = 0;
                oSalesLine.ShipmentNo = "0";
                oSalesLine.ShipmentLineNo = 0;
                oSalesLine.Profit = 0;
                oSalesLine.BilltoCustomerNo = oFolioTransaction.AccountID;
                oSalesLine.InvDiscountAmount = 0;
                oSalesLine.PurchaseOrderNo = "0";
                oSalesLine.PurchOrderLineNo = 0;
                oSalesLine.DropShipment = 0;
                oSalesLine.GenBusPostingGroup = "NATIONAL";
                oSalesLine.GenProdPostingGroup = "NO VAT";
                oSalesLine.VATCalculationType = "Normal VAT";
                oSalesLine.TransactionType = "";
                oSalesLine.TransportMethod = "";
                oSalesLine.AttachedtoLineNo = 0;
                oSalesLine.ExitPoint = "";
                oSalesLine.Area = "";
                oSalesLine.TransactionSpecification = "";
                oSalesLine.TaxAreaCode = "";
                oSalesLine.TaxLiable = 0;
                oSalesLine.TaxGroupCode = "";
                oSalesLine.VATBusPostingGroup = "NATIONAL";
                oSalesLine.VATProdPostingGroup = "NO VAT";
                oSalesLine.CurrencyCode = "";
                oSalesLine.OutstandingAmount_LCY = double.Parse((oFolioTransaction.NetBaseAmount + oFolioTransaction.Discount) + "");
                oSalesLine.ShippedNotInvoiced_LCY = 0;
                oSalesLine.ReservedQuantity = 0;
                oSalesLine.Reserve = "Never";
                oSalesLine.BlanketOrderNo = "";
                oSalesLine.BlanketOrderLineNo = 0;
                oSalesLine.VATBaseAmount = 0;
                oSalesLine.UnitCost = 0;
                oSalesLine.SystemCreatedEntry = 0;
                oSalesLine.LineAmount = double.Parse((oFolioTransaction.NetBaseAmount + oFolioTransaction.Discount) + "");
                oSalesLine.VATDifference = 0;
                oSalesLine.InvDiscAmounttoInvoice = 0;
                oSalesLine.VATIdentifier = "NO VAT";
                oSalesLine.ICPartnerRefType = "";
                oSalesLine.ICPartnerReference = "";
                oSalesLine.VariantCode = "";
                oSalesLine.BinCode = "";
                oSalesLine.QtyperUnitofMeasure = 1;
                oSalesLine.Planned = 0;
                oSalesLine.UnitofMeasureCode = "DAY";
                oSalesLine.Quantity_Base = 1;
                oSalesLine.OutstandingQty_Base = 1;
                oSalesLine.QtytoInvoice_Base = 1;
                oSalesLine.QtytoShip_Base = 1;
                oSalesLine.QtyShippedNotInvd_Base = 0;
                oSalesLine.QtyShipped_Base = 0;
                oSalesLine.QtyInvoiced_Base = 0;
                oSalesLine.ReservedQty_Base = 0;
                //oSalesLine.FAPostingDate = "";
                oSalesLine.DepreciationBookCode = "";
                oSalesLine.DepruntilFAPostingDate = 0;
                oSalesLine.DuplicateinDepreciationBook = "";
                oSalesLine.UseDuplicationList = 0;
                oSalesLine.ResponsibilityCenter = "";
                oSalesLine.OutofStockSubstitution = 0;
                oSalesLine.SubstitutionAvailable = 0;
                oSalesLine.OriginallyOrderedNo = "0";
                oSalesLine.OriginallyOrderedVarCode = "0";
                oSalesLine.CrossReferenceNo = "";
                oSalesLine.UnitofMeasure_CrossRef = "";
                oSalesLine.CrossReferenceType = "";
                oSalesLine.CrossReferenceTypeNo = "";
                oSalesLine.ItemCategoryCode = "";
                oSalesLine.Nonstock = 0;
                oSalesLine.PurchasingCode = "";
                oSalesLine.ProductGroupCode = "";
                oSalesLine.SpecialOrder = 0;
                oSalesLine.SpecialOrderPurchaseNo = "";
                oSalesLine.SpecialOrderPurchLineNo = 0;
                oSalesLine.WhseOutstandingQty_Base = 0;
                oSalesLine.CompletelyShipped = 0;
                //oSalesLine.RequestedDeliveryDate = "";
                //oSalesLine.PromisedDeliveryDate = "";
                oSalesLine.ShippingTime = "";
                oSalesLine.OutboundWhseHandlingTime = "";
                oSalesLine.PlannedDeliveryDate = "{ts '2001-01-25 00:00:00'}";
                oSalesLine.PlannedShipmentDate = "{ts '2001-01-25 00:00:00'}";
                oSalesLine.ShippingAgentCode = "";
                oSalesLine.ShippingAgentServiceCode = "";
                oSalesLine.AllowItemChargeAssignment = 0;
                oSalesLine.QtytoAssign = 0;
                oSalesLine.QtyAssigned = 0;
                oSalesLine.ReturnQtytoReceive = 0;
                oSalesLine.ReturnQtytoReceive_Base = 0;
                oSalesLine.ReturnQtyRcdNotInvd = 0;
                oSalesLine.RetQtyRcdNotInvd_Base = 0;
                oSalesLine.ReturnRcdNotInvd = 0;
                oSalesLine.ReturnRcdNotInvd_LCY = 0;
                oSalesLine.ReturnQtyReceived = 0;
                oSalesLine.ReturnQtyReceived_Base = 0;
                oSalesLine.ApplfromItemEntry = 0;
                oSalesLine.ServiceContractNo = "";
                oSalesLine.ServiceOrderNo = "";
                oSalesLine.ServiceItemNo = "";
                oSalesLine.AppltoServiceEntry = 0;
                oSalesLine.ServiceItemLineNo = 0;
                oSalesLine.ServPriceAdjmtGrCode = "";
                oSalesLine.BOMItemNo = "";
                oSalesLine.ReturnReceiptNo = "";
                oSalesLine.ReturnReceiptLineNo = 0;
                oSalesLine.ReturnReasonCode = "";
                oSalesLine.AllowLineDisc = 1;
                oSalesLine.CustomerDiscGroup = "";
                //oSalesLine.ServicePostingDate = "";
                oSalesLine.WHTBusinessPostingGroup = "";
                oSalesLine.WHTProductPostingGroup = "";
                oSalesLine.WHTAbsorbBase = 0;

                oSalesLineList.Add(oSalesLine);

                // for GOV'T TAX
                if (oFolioTransaction.GovernmentTax > 0)
                {
                    Sales_Line oSalesLine_GovtTax = new Sales_Line();
                    oSalesLine_GovtTax.DocumentType = "Invoice";
                    oSalesLine_GovtTax.SelltoCustomerNo = oFolioTransaction.AccountID;
                    oSalesLine_GovtTax.DocumentNo = this.No;
                    oSalesLine_GovtTax.LineNo = 20000;
                    oSalesLine_GovtTax.Type = "G/L Account";
                    oSalesLine_GovtTax.No = "5610";                 // should be replace by GoverntmentTax.oTransactionCode.DebitSideMemo
                    oSalesLine_GovtTax.LocationCode = "";
                    oSalesLine_GovtTax.PostingGroup = "";
                    oSalesLine_GovtTax.ShipmentDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_GovtTax.Description = "Government Tax 12%";   // should be replaced by oTransactionCode.DebitSideMemo
                    oSalesLine_GovtTax.Description2 = "";
                    oSalesLine_GovtTax.UnitofMeasure = "Day";
                    oSalesLine_GovtTax.Quantity = 1;
                    oSalesLine_GovtTax.OutstandingQuantity = 1;
                    oSalesLine_GovtTax.QtytoInvoice = 1;
                    oSalesLine_GovtTax.QtytoShip = 1;
                    oSalesLine_GovtTax.UnitPrice = double.Parse(oFolioTransaction.GovernmentTax.ToString());
                    oSalesLine_GovtTax.UnitCost_LCY = 0;
                    oSalesLine_GovtTax.VAT = 100;               // since FULL VAT
                    oSalesLine_GovtTax.LineDiscount = 0;
                    oSalesLine_GovtTax.LineDiscountAmount = 0;
                    oSalesLine_GovtTax.Amount = 0;
                    oSalesLine_GovtTax.AmountIncludingVAT = 0;
                    oSalesLine_GovtTax.AllowInvoiceDisc = 0;
                    oSalesLine_GovtTax.GrossWeight = 0;
                    oSalesLine_GovtTax.NetWeight = 0;
                    oSalesLine_GovtTax.UnitsperParcel = 0;
                    oSalesLine_GovtTax.UnitVolume = 0;
                    oSalesLine_GovtTax.AppltoItemEntry = 0;
                    oSalesLine_GovtTax.ShortcutDimension1Code = "";
                    oSalesLine_GovtTax.ShortcutDimension2Code = "";
                    oSalesLine_GovtTax.CustomerPriceGroup = "";
                    oSalesLine_GovtTax.JobNo = "";
                    oSalesLine_GovtTax.AppltoJobEntry = 0;
                    oSalesLine_GovtTax.PhaseCode = "";
                    oSalesLine_GovtTax.TaskCode = "";
                    oSalesLine_GovtTax.StepCode = "";
                    oSalesLine_GovtTax.JobAppliestoID = "";
                    oSalesLine_GovtTax.ApplyandClose_Job = 0;
                    oSalesLine_GovtTax.WorkTypeCode = "";
                    oSalesLine_GovtTax.OutstandingAmount = double.Parse((oFolioTransaction.GovernmentTax*2) + "");
                    oSalesLine_GovtTax.QtyShippedNotInvoiced = 0;
                    oSalesLine_GovtTax.ShippedNotInvoiced = 0;
                    oSalesLine_GovtTax.QuantityShipped = 0;
                    oSalesLine_GovtTax.QuantityInvoiced = 0;
                    oSalesLine_GovtTax.ShipmentNo = "0";
                    oSalesLine_GovtTax.ShipmentLineNo = 0;
                    oSalesLine_GovtTax.Profit = 0;
                    oSalesLine_GovtTax.BilltoCustomerNo = oFolioTransaction.AccountID;
                    oSalesLine_GovtTax.InvDiscountAmount = 0;
                    oSalesLine_GovtTax.PurchaseOrderNo = "0";
                    oSalesLine_GovtTax.PurchOrderLineNo = 0;
                    oSalesLine_GovtTax.DropShipment = 0;
                    oSalesLine_GovtTax.GenBusPostingGroup = "NATIONAL";
                    oSalesLine_GovtTax.GenProdPostingGroup = "NO VAT";
                    oSalesLine_GovtTax.VATCalculationType = "Full VAT";
                    oSalesLine_GovtTax.TransactionType = "";
                    oSalesLine_GovtTax.TransportMethod = "";
                    oSalesLine_GovtTax.AttachedtoLineNo = 0;
                    oSalesLine_GovtTax.ExitPoint = "";
                    oSalesLine_GovtTax.Area = "";
                    oSalesLine_GovtTax.TransactionSpecification = "";
                    oSalesLine_GovtTax.TaxAreaCode = "";
                    oSalesLine_GovtTax.TaxLiable = 0;
                    oSalesLine_GovtTax.TaxGroupCode = "";
                    oSalesLine_GovtTax.VATBusPostingGroup = "NATIONAL";
                    oSalesLine_GovtTax.VATProdPostingGroup = "FULL";
                    oSalesLine_GovtTax.CurrencyCode = "";
                    oSalesLine_GovtTax.OutstandingAmount_LCY = double.Parse((oFolioTransaction.GovernmentTax*2) + "");
                    oSalesLine_GovtTax.ShippedNotInvoiced_LCY = 0;
                    oSalesLine_GovtTax.ReservedQuantity = 0;
                    oSalesLine_GovtTax.Reserve = "Never";
                    oSalesLine_GovtTax.BlanketOrderNo = "";
                    oSalesLine_GovtTax.BlanketOrderLineNo = 0;
                    oSalesLine_GovtTax.VATBaseAmount = 0;
                    oSalesLine_GovtTax.UnitCost = 0;
                    oSalesLine_GovtTax.SystemCreatedEntry = 0;
                    oSalesLine_GovtTax.LineAmount = double.Parse(oFolioTransaction.GovernmentTax.ToString());
                    oSalesLine_GovtTax.VATDifference = 0;
                    oSalesLine_GovtTax.InvDiscAmounttoInvoice = 0;
                    oSalesLine_GovtTax.VATIdentifier = "FULL";
                    oSalesLine_GovtTax.ICPartnerRefType = "";
                    oSalesLine_GovtTax.ICPartnerReference = "";
                    oSalesLine_GovtTax.VariantCode = "";
                    oSalesLine_GovtTax.BinCode = "";
                    oSalesLine_GovtTax.QtyperUnitofMeasure = 1;
                    oSalesLine_GovtTax.Planned = 0;
                    oSalesLine_GovtTax.UnitofMeasureCode = "DAY";
                    oSalesLine_GovtTax.Quantity_Base = 1;
                    oSalesLine_GovtTax.OutstandingQty_Base = 1;
                    oSalesLine_GovtTax.QtytoInvoice_Base = 1;
                    oSalesLine_GovtTax.QtytoShip_Base = 1;
                    oSalesLine_GovtTax.QtyShippedNotInvd_Base = 0;
                    oSalesLine_GovtTax.QtyShipped_Base = 0;
                    oSalesLine_GovtTax.QtyInvoiced_Base = 0;
                    oSalesLine_GovtTax.ReservedQty_Base = 0;
                    //oSalesLine_GovtTax.FAPostingDate = "";
                    oSalesLine_GovtTax.DepreciationBookCode = "";
                    oSalesLine_GovtTax.DepruntilFAPostingDate = 0;
                    oSalesLine_GovtTax.DuplicateinDepreciationBook = "";
                    oSalesLine_GovtTax.UseDuplicationList = 0;
                    oSalesLine_GovtTax.ResponsibilityCenter = "";
                    oSalesLine_GovtTax.OutofStockSubstitution = 0;
                    oSalesLine_GovtTax.SubstitutionAvailable = 0;
                    oSalesLine_GovtTax.OriginallyOrderedNo = "0";
                    oSalesLine_GovtTax.OriginallyOrderedVarCode = "0";
                    oSalesLine_GovtTax.CrossReferenceNo = "";
                    oSalesLine_GovtTax.UnitofMeasure_CrossRef = "";
                    oSalesLine_GovtTax.CrossReferenceType = "";
                    oSalesLine_GovtTax.CrossReferenceTypeNo = "";
                    oSalesLine_GovtTax.ItemCategoryCode = "";
                    oSalesLine_GovtTax.Nonstock = 0;
                    oSalesLine_GovtTax.PurchasingCode = "";
                    oSalesLine_GovtTax.ProductGroupCode = "";
                    oSalesLine_GovtTax.SpecialOrder = 0;
                    oSalesLine_GovtTax.SpecialOrderPurchaseNo = "";
                    oSalesLine_GovtTax.SpecialOrderPurchLineNo = 0;
                    oSalesLine_GovtTax.WhseOutstandingQty_Base = 0;
                    oSalesLine_GovtTax.CompletelyShipped = 0;
                    //oSalesLine_GovtTax.RequestedDeliveryDate = "";
                    //oSalesLine_GovtTax.PromisedDeliveryDate = "";
                    oSalesLine_GovtTax.ShippingTime = "";
                    oSalesLine_GovtTax.OutboundWhseHandlingTime = "";
                    oSalesLine_GovtTax.PlannedDeliveryDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_GovtTax.PlannedShipmentDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_GovtTax.ShippingAgentCode = "";
                    oSalesLine_GovtTax.ShippingAgentServiceCode = "";
                    oSalesLine_GovtTax.AllowItemChargeAssignment = 0;
                    oSalesLine_GovtTax.QtytoAssign = 0;
                    oSalesLine_GovtTax.QtyAssigned = 0;
                    oSalesLine_GovtTax.ReturnQtytoReceive = 0;
                    oSalesLine_GovtTax.ReturnQtytoReceive_Base = 0;
                    oSalesLine_GovtTax.ReturnQtyRcdNotInvd = 0;
                    oSalesLine_GovtTax.RetQtyRcdNotInvd_Base = 0;
                    oSalesLine_GovtTax.ReturnRcdNotInvd = 0;
                    oSalesLine_GovtTax.ReturnRcdNotInvd_LCY = 0;
                    oSalesLine_GovtTax.ReturnQtyReceived = 0;
                    oSalesLine_GovtTax.ReturnQtyReceived_Base = 0;
                    oSalesLine_GovtTax.ApplfromItemEntry = 0;
                    oSalesLine_GovtTax.ServiceContractNo = "";
                    oSalesLine_GovtTax.ServiceOrderNo = "";
                    oSalesLine_GovtTax.ServiceItemNo = "";
                    oSalesLine_GovtTax.AppltoServiceEntry = 0;
                    oSalesLine_GovtTax.ServiceItemLineNo = 0;
                    oSalesLine_GovtTax.ServPriceAdjmtGrCode = "";
                    oSalesLine_GovtTax.BOMItemNo = "";
                    oSalesLine_GovtTax.ReturnReceiptNo = "";
                    oSalesLine_GovtTax.ReturnReceiptLineNo = 0;
                    oSalesLine_GovtTax.ReturnReasonCode = "";
                    oSalesLine_GovtTax.AllowLineDisc = 1;
                    oSalesLine_GovtTax.CustomerDiscGroup = "";
                    //oSalesLine_GovtTax.ServicePostingDate = "";
                    oSalesLine_GovtTax.WHTBusinessPostingGroup = "";
                    oSalesLine_GovtTax.WHTProductPostingGroup = "";
                    oSalesLine_GovtTax.WHTAbsorbBase = 0;

                    oSalesLineList.Add(oSalesLine_GovtTax);
                }


                // for LOCAL TAX
                if (oFolioTransaction.LocalTax > 0)
                {
                    Sales_Line oSalesLine_LocalTax = new Sales_Line();
                    oSalesLine_LocalTax.DocumentType = "Invoice";
                    oSalesLine_LocalTax.SelltoCustomerNo = oFolioTransaction.AccountID;
                    oSalesLine_LocalTax.DocumentNo = this.No;
                    oSalesLine_LocalTax.LineNo = 20000;
                    oSalesLine_LocalTax.Type = "G/L Account";
                    oSalesLine_LocalTax.No = "5610";                 // should be replace by GoverntmentTax.oTransactionCode.DebitSideMemo
                    oSalesLine_LocalTax.LocationCode = "";
                    oSalesLine_LocalTax.PostingGroup = "";
                    oSalesLine_LocalTax.ShipmentDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_LocalTax.Description = "Government Tax 12%";   // should be replaced by oTransactionCode.DebitSideMemo
                    oSalesLine_LocalTax.Description2 = "";
                    oSalesLine_LocalTax.UnitofMeasure = "Day";
                    oSalesLine_LocalTax.Quantity = 1;
                    oSalesLine_LocalTax.OutstandingQuantity = 1;
                    oSalesLine_LocalTax.QtytoInvoice = 1;
                    oSalesLine_LocalTax.QtytoShip = 1;
                    oSalesLine_LocalTax.UnitPrice = double.Parse(oFolioTransaction.LocalTax.ToString());
                    oSalesLine_LocalTax.UnitCost_LCY = 0;
                    oSalesLine_LocalTax.VAT = 0;
                    oSalesLine_LocalTax.LineDiscount = 0;
                    oSalesLine_LocalTax.LineDiscountAmount = 0;
                    oSalesLine_LocalTax.Amount = 0;
                    oSalesLine_LocalTax.AmountIncludingVAT = 0;
                    oSalesLine_LocalTax.AllowInvoiceDisc = 0;
                    oSalesLine_LocalTax.GrossWeight = 0;
                    oSalesLine_LocalTax.NetWeight = 0;
                    oSalesLine_LocalTax.UnitsperParcel = 0;
                    oSalesLine_LocalTax.UnitVolume = 0;
                    oSalesLine_LocalTax.AppltoItemEntry = 0;
                    oSalesLine_LocalTax.ShortcutDimension1Code = "";
                    oSalesLine_LocalTax.ShortcutDimension2Code = "";
                    oSalesLine_LocalTax.CustomerPriceGroup = "";
                    oSalesLine_LocalTax.JobNo = "";
                    oSalesLine_LocalTax.AppltoJobEntry = 0;
                    oSalesLine_LocalTax.PhaseCode = "";
                    oSalesLine_LocalTax.TaskCode = "";
                    oSalesLine_LocalTax.StepCode = "";
                    oSalesLine_LocalTax.JobAppliestoID = "";
                    oSalesLine_LocalTax.ApplyandClose_Job = 0;
                    oSalesLine_LocalTax.WorkTypeCode = "";
                    oSalesLine_LocalTax.OutstandingAmount = double.Parse(oFolioTransaction.LocalTax.ToString());
                    oSalesLine_LocalTax.QtyShippedNotInvoiced = 0;
                    oSalesLine_LocalTax.ShippedNotInvoiced = 0;
                    oSalesLine_LocalTax.QuantityShipped = 0;
                    oSalesLine_LocalTax.QuantityInvoiced = 0;
                    oSalesLine_LocalTax.ShipmentNo = "0";
                    oSalesLine_LocalTax.ShipmentLineNo = 0;
                    oSalesLine_LocalTax.Profit = 0;
                    oSalesLine_LocalTax.BilltoCustomerNo = oFolioTransaction.AccountID;
                    oSalesLine_LocalTax.InvDiscountAmount = 0;
                    oSalesLine_LocalTax.PurchaseOrderNo = "0";
                    oSalesLine_LocalTax.PurchOrderLineNo = 0;
                    oSalesLine_LocalTax.DropShipment = 0;
                    oSalesLine_LocalTax.GenBusPostingGroup = "NATIONAL";
                    oSalesLine_LocalTax.GenProdPostingGroup = "NO VAT";
                    oSalesLine_LocalTax.VATCalculationType = "Normal VAT";
                    oSalesLine_LocalTax.TransactionType = "";
                    oSalesLine_LocalTax.TransportMethod = "";
                    oSalesLine_LocalTax.AttachedtoLineNo = 0;
                    oSalesLine_LocalTax.ExitPoint = "";
                    oSalesLine_LocalTax.Area = "";
                    oSalesLine_LocalTax.TransactionSpecification = "";
                    oSalesLine_LocalTax.TaxAreaCode = "";
                    oSalesLine_LocalTax.TaxLiable = 0;
                    oSalesLine_LocalTax.TaxGroupCode = "";
                    oSalesLine_LocalTax.VATBusPostingGroup = "NATIONAL";
                    oSalesLine_LocalTax.VATProdPostingGroup = "NO VAT";
                    oSalesLine_LocalTax.CurrencyCode = "";
                    oSalesLine_LocalTax.OutstandingAmount_LCY = double.Parse(oFolioTransaction.LocalTax.ToString());
                    oSalesLine_LocalTax.ShippedNotInvoiced_LCY = 0;
                    oSalesLine_LocalTax.ReservedQuantity = 0;
                    oSalesLine_LocalTax.Reserve = "Never";
                    oSalesLine_LocalTax.BlanketOrderNo = "";
                    oSalesLine_LocalTax.BlanketOrderLineNo = 0;
                    oSalesLine_LocalTax.VATBaseAmount = 0;
                    oSalesLine_LocalTax.UnitCost = 0;
                    oSalesLine_LocalTax.SystemCreatedEntry = 0;
                    oSalesLine_LocalTax.LineAmount = double.Parse(oFolioTransaction.LocalTax.ToString());
                    oSalesLine_LocalTax.VATDifference = 0;
                    oSalesLine_LocalTax.InvDiscAmounttoInvoice = 0;
                    oSalesLine_LocalTax.VATIdentifier = "NO VAT";
                    oSalesLine_LocalTax.ICPartnerRefType = "";
                    oSalesLine_LocalTax.ICPartnerReference = "";
                    oSalesLine_LocalTax.VariantCode = "";
                    oSalesLine_LocalTax.BinCode = "";
                    oSalesLine_LocalTax.QtyperUnitofMeasure = 1;
                    oSalesLine_LocalTax.Planned = 0;
                    oSalesLine_LocalTax.UnitofMeasureCode = "DAY";
                    oSalesLine_LocalTax.Quantity_Base = 1;
                    oSalesLine_LocalTax.OutstandingQty_Base = 1;
                    oSalesLine_LocalTax.QtytoInvoice_Base = 1;
                    oSalesLine_LocalTax.QtytoShip_Base = 1;
                    oSalesLine_LocalTax.QtyShippedNotInvd_Base = 0;
                    oSalesLine_LocalTax.QtyShipped_Base = 0;
                    oSalesLine_LocalTax.QtyInvoiced_Base = 0;
                    oSalesLine_LocalTax.ReservedQty_Base = 0;
                    //oSalesLine_LocalTax.FAPostingDate = "";
                    oSalesLine_LocalTax.DepreciationBookCode = "";
                    oSalesLine_LocalTax.DepruntilFAPostingDate = 0;
                    oSalesLine_LocalTax.DuplicateinDepreciationBook = "";
                    oSalesLine_LocalTax.UseDuplicationList = 0;
                    oSalesLine_LocalTax.ResponsibilityCenter = "";
                    oSalesLine_LocalTax.OutofStockSubstitution = 0;
                    oSalesLine_LocalTax.SubstitutionAvailable = 0;
                    oSalesLine_LocalTax.OriginallyOrderedNo = "0";
                    oSalesLine_LocalTax.OriginallyOrderedVarCode = "0";
                    oSalesLine_LocalTax.CrossReferenceNo = "";
                    oSalesLine_LocalTax.UnitofMeasure_CrossRef = "";
                    oSalesLine_LocalTax.CrossReferenceType = "";
                    oSalesLine_LocalTax.CrossReferenceTypeNo = "";
                    oSalesLine_LocalTax.ItemCategoryCode = "";
                    oSalesLine_LocalTax.Nonstock = 0;
                    oSalesLine_LocalTax.PurchasingCode = "";
                    oSalesLine_LocalTax.ProductGroupCode = "";
                    oSalesLine_LocalTax.SpecialOrder = 0;
                    oSalesLine_LocalTax.SpecialOrderPurchaseNo = "";
                    oSalesLine_LocalTax.SpecialOrderPurchLineNo = 0;
                    oSalesLine_LocalTax.WhseOutstandingQty_Base = 0;
                    oSalesLine_LocalTax.CompletelyShipped = 0;
                    //oSalesLine_LocalTax.RequestedDeliveryDate = "";
                    //oSalesLine_LocalTax.PromisedDeliveryDate = "";
                    oSalesLine_LocalTax.ShippingTime = "";
                    oSalesLine_LocalTax.OutboundWhseHandlingTime = "";
                    oSalesLine_LocalTax.PlannedDeliveryDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_LocalTax.PlannedShipmentDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_LocalTax.ShippingAgentCode = "";
                    oSalesLine_LocalTax.ShippingAgentServiceCode = "";
                    oSalesLine_LocalTax.AllowItemChargeAssignment = 0;
                    oSalesLine_LocalTax.QtytoAssign = 0;
                    oSalesLine_LocalTax.QtyAssigned = 0;
                    oSalesLine_LocalTax.ReturnQtytoReceive = 0;
                    oSalesLine_LocalTax.ReturnQtytoReceive_Base = 0;
                    oSalesLine_LocalTax.ReturnQtyRcdNotInvd = 0;
                    oSalesLine_LocalTax.RetQtyRcdNotInvd_Base = 0;
                    oSalesLine_LocalTax.ReturnRcdNotInvd = 0;
                    oSalesLine_LocalTax.ReturnRcdNotInvd_LCY = 0;
                    oSalesLine_LocalTax.ReturnQtyReceived = 0;
                    oSalesLine_LocalTax.ReturnQtyReceived_Base = 0;
                    oSalesLine_LocalTax.ApplfromItemEntry = 0;
                    oSalesLine_LocalTax.ServiceContractNo = "";
                    oSalesLine_LocalTax.ServiceOrderNo = "";
                    oSalesLine_LocalTax.ServiceItemNo = "";
                    oSalesLine_LocalTax.AppltoServiceEntry = 0;
                    oSalesLine_LocalTax.ServiceItemLineNo = 0;
                    oSalesLine_LocalTax.ServPriceAdjmtGrCode = "";
                    oSalesLine_LocalTax.BOMItemNo = "";
                    oSalesLine_LocalTax.ReturnReceiptNo = "";
                    oSalesLine_LocalTax.ReturnReceiptLineNo = 0;
                    oSalesLine_LocalTax.ReturnReasonCode = "";
                    oSalesLine_LocalTax.AllowLineDisc = 1;
                    oSalesLine_LocalTax.CustomerDiscGroup = "";
                    //oSalesLine_LocalTax.ServicePostingDate = "";
                    oSalesLine_LocalTax.WHTBusinessPostingGroup = "";
                    oSalesLine_LocalTax.WHTProductPostingGroup = "";
                    oSalesLine_LocalTax.WHTAbsorbBase = 0;

                    oSalesLineList.Add(oSalesLine_LocalTax);
                }



                // for SERVICE CHARGE
                if (oFolioTransaction.ServiceCharge > 0)
                {
                    Sales_Line oSalesLine_ServiceCharge = new Sales_Line();
                    oSalesLine_ServiceCharge.DocumentType = "Invoice";
                    oSalesLine_ServiceCharge.SelltoCustomerNo = oFolioTransaction.AccountID;
                    oSalesLine_ServiceCharge.DocumentNo = this.No;
                    oSalesLine_ServiceCharge.LineNo = 40000;
                    oSalesLine_ServiceCharge.Type = "G/L Account";
                    oSalesLine_ServiceCharge.No = "5960";                 // should be replace by GoverntmentTax.oTransactionCode.DebitSideMemo
                    oSalesLine_ServiceCharge.LocationCode = "";
                    oSalesLine_ServiceCharge.PostingGroup = "";
                    oSalesLine_ServiceCharge.ShipmentDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_ServiceCharge.Description = "Government Tax 12%";   // should be replaced by oTransactionCode.DebitSideMemo
                    oSalesLine_ServiceCharge.Description2 = "";
                    oSalesLine_ServiceCharge.UnitofMeasure = "Day";
                    oSalesLine_ServiceCharge.Quantity = 1;
                    oSalesLine_ServiceCharge.OutstandingQuantity = 1;
                    oSalesLine_ServiceCharge.QtytoInvoice = 1;
                    oSalesLine_ServiceCharge.QtytoShip = 1;
                    oSalesLine_ServiceCharge.UnitPrice = double.Parse(oFolioTransaction.ServiceCharge.ToString());
                    oSalesLine_ServiceCharge.UnitCost_LCY = 0;
                    oSalesLine_ServiceCharge.VAT = 0;
                    oSalesLine_ServiceCharge.LineDiscount = 0;
                    oSalesLine_ServiceCharge.LineDiscountAmount = 0;
                    oSalesLine_ServiceCharge.Amount = 0;
                    oSalesLine_ServiceCharge.AmountIncludingVAT = 0;
                    oSalesLine_ServiceCharge.AllowInvoiceDisc = 0;
                    oSalesLine_ServiceCharge.GrossWeight = 0;
                    oSalesLine_ServiceCharge.NetWeight = 0;
                    oSalesLine_ServiceCharge.UnitsperParcel = 0;
                    oSalesLine_ServiceCharge.UnitVolume = 0;
                    oSalesLine_ServiceCharge.AppltoItemEntry = 0;
                    oSalesLine_ServiceCharge.ShortcutDimension1Code = "";
                    oSalesLine_ServiceCharge.ShortcutDimension2Code = "";
                    oSalesLine_ServiceCharge.CustomerPriceGroup = "";
                    oSalesLine_ServiceCharge.JobNo = "";
                    oSalesLine_ServiceCharge.AppltoJobEntry = 0;
                    oSalesLine_ServiceCharge.PhaseCode = "";
                    oSalesLine_ServiceCharge.TaskCode = "";
                    oSalesLine_ServiceCharge.StepCode = "";
                    oSalesLine_ServiceCharge.JobAppliestoID = "";
                    oSalesLine_ServiceCharge.ApplyandClose_Job = 0;
                    oSalesLine_ServiceCharge.WorkTypeCode = "";
                    oSalesLine_ServiceCharge.OutstandingAmount = double.Parse(oFolioTransaction.ServiceCharge.ToString());
                    oSalesLine_ServiceCharge.QtyShippedNotInvoiced = 0;
                    oSalesLine_ServiceCharge.ShippedNotInvoiced = 0;
                    oSalesLine_ServiceCharge.QuantityShipped = 0;
                    oSalesLine_ServiceCharge.QuantityInvoiced = 0;
                    oSalesLine_ServiceCharge.ShipmentNo = "0";
                    oSalesLine_ServiceCharge.ShipmentLineNo = 0;
                    oSalesLine_ServiceCharge.Profit = 0;
                    oSalesLine_ServiceCharge.BilltoCustomerNo = oFolioTransaction.AccountID;
                    oSalesLine_ServiceCharge.InvDiscountAmount = 0;
                    oSalesLine_ServiceCharge.PurchaseOrderNo = "0";
                    oSalesLine_ServiceCharge.PurchOrderLineNo = 0;
                    oSalesLine_ServiceCharge.DropShipment = 0;
                    oSalesLine_ServiceCharge.GenBusPostingGroup = "NATIONAL";
                    oSalesLine_ServiceCharge.GenProdPostingGroup = "NO VAT";
                    oSalesLine_ServiceCharge.VATCalculationType = "Normal VAT";
                    oSalesLine_ServiceCharge.TransactionType = "";
                    oSalesLine_ServiceCharge.TransportMethod = "";
                    oSalesLine_ServiceCharge.AttachedtoLineNo = 0;
                    oSalesLine_ServiceCharge.ExitPoint = "";
                    oSalesLine_ServiceCharge.Area = "";
                    oSalesLine_ServiceCharge.TransactionSpecification = "";
                    oSalesLine_ServiceCharge.TaxAreaCode = "";
                    oSalesLine_ServiceCharge.TaxLiable = 0;
                    oSalesLine_ServiceCharge.TaxGroupCode = "";
                    oSalesLine_ServiceCharge.VATBusPostingGroup = "NATIONAL";
                    oSalesLine_ServiceCharge.VATProdPostingGroup = "NO VAT";
                    oSalesLine_ServiceCharge.CurrencyCode = "";
                    oSalesLine_ServiceCharge.OutstandingAmount_LCY = double.Parse(oFolioTransaction.ServiceCharge.ToString());
                    oSalesLine_ServiceCharge.ShippedNotInvoiced_LCY = 0;
                    oSalesLine_ServiceCharge.ReservedQuantity = 0;
                    oSalesLine_ServiceCharge.Reserve = "Never";
                    oSalesLine_ServiceCharge.BlanketOrderNo = "";
                    oSalesLine_ServiceCharge.BlanketOrderLineNo = 0;
                    oSalesLine_ServiceCharge.VATBaseAmount = 0;
                    oSalesLine_ServiceCharge.UnitCost = 0;
                    oSalesLine_ServiceCharge.SystemCreatedEntry = 0;
                    oSalesLine_ServiceCharge.LineAmount = double.Parse(oFolioTransaction.ServiceCharge.ToString());
                    oSalesLine_ServiceCharge.VATDifference = 0;
                    oSalesLine_ServiceCharge.InvDiscAmounttoInvoice = 0;
                    oSalesLine_ServiceCharge.VATIdentifier = "NO VAT";
                    oSalesLine_ServiceCharge.ICPartnerRefType = "";
                    oSalesLine_ServiceCharge.ICPartnerReference = "";
                    oSalesLine_ServiceCharge.VariantCode = "";
                    oSalesLine_ServiceCharge.BinCode = "";
                    oSalesLine_ServiceCharge.QtyperUnitofMeasure = 1;
                    oSalesLine_ServiceCharge.Planned = 0;
                    oSalesLine_ServiceCharge.UnitofMeasureCode = "DAY";
                    oSalesLine_ServiceCharge.Quantity_Base = 1;
                    oSalesLine_ServiceCharge.OutstandingQty_Base = 1;
                    oSalesLine_ServiceCharge.QtytoInvoice_Base = 1;
                    oSalesLine_ServiceCharge.QtytoShip_Base = 1;
                    oSalesLine_ServiceCharge.QtyShippedNotInvd_Base = 0;
                    oSalesLine_ServiceCharge.QtyShipped_Base = 0;
                    oSalesLine_ServiceCharge.QtyInvoiced_Base = 0;
                    oSalesLine_ServiceCharge.ReservedQty_Base = 0;
                    //oSalesLine_ServiceCharge.FAPostingDate = "";
                    oSalesLine_ServiceCharge.DepreciationBookCode = "";
                    oSalesLine_ServiceCharge.DepruntilFAPostingDate = 0;
                    oSalesLine_ServiceCharge.DuplicateinDepreciationBook = "";
                    oSalesLine_ServiceCharge.UseDuplicationList = 0;
                    oSalesLine_ServiceCharge.ResponsibilityCenter = "";
                    oSalesLine_ServiceCharge.OutofStockSubstitution = 0;
                    oSalesLine_ServiceCharge.SubstitutionAvailable = 0;
                    oSalesLine_ServiceCharge.OriginallyOrderedNo = "0";
                    oSalesLine_ServiceCharge.OriginallyOrderedVarCode = "0";
                    oSalesLine_ServiceCharge.CrossReferenceNo = "";
                    oSalesLine_ServiceCharge.UnitofMeasure_CrossRef = "";
                    oSalesLine_ServiceCharge.CrossReferenceType = "";
                    oSalesLine_ServiceCharge.CrossReferenceTypeNo = "";
                    oSalesLine_ServiceCharge.ItemCategoryCode = "";
                    oSalesLine_ServiceCharge.Nonstock = 0;
                    oSalesLine_ServiceCharge.PurchasingCode = "";
                    oSalesLine_ServiceCharge.ProductGroupCode = "";
                    oSalesLine_ServiceCharge.SpecialOrder = 0;
                    oSalesLine_ServiceCharge.SpecialOrderPurchaseNo = "";
                    oSalesLine_ServiceCharge.SpecialOrderPurchLineNo = 0;
                    oSalesLine_ServiceCharge.WhseOutstandingQty_Base = 0;
                    oSalesLine_ServiceCharge.CompletelyShipped = 0;
                    //oSalesLine_ServiceCharge.RequestedDeliveryDate = "";
                    //oSalesLine_ServiceCharge.PromisedDeliveryDate = "";
                    oSalesLine_ServiceCharge.ShippingTime = "";
                    oSalesLine_ServiceCharge.OutboundWhseHandlingTime = "";
                    oSalesLine_ServiceCharge.PlannedDeliveryDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_ServiceCharge.PlannedShipmentDate = "{ts '2001-01-25 00:00:00'}";
                    oSalesLine_ServiceCharge.ShippingAgentCode = "";
                    oSalesLine_ServiceCharge.ShippingAgentServiceCode = "";
                    oSalesLine_ServiceCharge.AllowItemChargeAssignment = 0;
                    oSalesLine_ServiceCharge.QtytoAssign = 0;
                    oSalesLine_ServiceCharge.QtyAssigned = 0;
                    oSalesLine_ServiceCharge.ReturnQtytoReceive = 0;
                    oSalesLine_ServiceCharge.ReturnQtytoReceive_Base = 0;
                    oSalesLine_ServiceCharge.ReturnQtyRcdNotInvd = 0;
                    oSalesLine_ServiceCharge.RetQtyRcdNotInvd_Base = 0;
                    oSalesLine_ServiceCharge.ReturnRcdNotInvd = 0;
                    oSalesLine_ServiceCharge.ReturnRcdNotInvd_LCY = 0;
                    oSalesLine_ServiceCharge.ReturnQtyReceived = 0;
                    oSalesLine_ServiceCharge.ReturnQtyReceived_Base = 0;
                    oSalesLine_ServiceCharge.ApplfromItemEntry = 0;
                    oSalesLine_ServiceCharge.ServiceContractNo = "";
                    oSalesLine_ServiceCharge.ServiceOrderNo = "";
                    oSalesLine_ServiceCharge.ServiceItemNo = "";
                    oSalesLine_ServiceCharge.AppltoServiceEntry = 0;
                    oSalesLine_ServiceCharge.ServiceItemLineNo = 0;
                    oSalesLine_ServiceCharge.ServPriceAdjmtGrCode = "";
                    oSalesLine_ServiceCharge.BOMItemNo = "";
                    oSalesLine_ServiceCharge.ReturnReceiptNo = "";
                    oSalesLine_ServiceCharge.ReturnReceiptLineNo = 0;
                    oSalesLine_ServiceCharge.ReturnReasonCode = "";
                    oSalesLine_ServiceCharge.AllowLineDisc = 1;
                    oSalesLine_ServiceCharge.CustomerDiscGroup = "";
                    //oSalesLine_ServiceCharge.ServicePostingDate = "";
                    oSalesLine_ServiceCharge.WHTBusinessPostingGroup = "";
                    oSalesLine_ServiceCharge.WHTProductPostingGroup = "";
                    oSalesLine_ServiceCharge.WHTAbsorbBase = 0;

                    oSalesLineList.Add(oSalesLine_ServiceCharge);
                }

                this.mSalesLineList = oSalesLineList;
            }
        }
    }
}