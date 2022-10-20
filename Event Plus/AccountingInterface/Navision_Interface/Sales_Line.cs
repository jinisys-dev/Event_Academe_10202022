using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Jinisys.Hotel.AccountingInterface.Navision_Interface
{
    namespace BusinessLayer
    {
        public class Sales_Line
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

            private string mDocumentNo;
            public string DocumentNo
            {
                get { return mDocumentNo; }
                set { mDocumentNo = value; }
            }

            private Int32 mLineNo;
            public Int32 LineNo
            {
                get { return mLineNo; }
                set { mLineNo = value; }
            }

            private string mType;
            public string Type
            {
                get { return mType; }
                set { mType = value; }
            }

            private string mNo;
            public string No
            {
                get { return mNo; }
                set { mNo = value; }
            }

            private string mLocationCode;
            public string LocationCode
            {
                get { return mLocationCode; }
                set { mLocationCode = value; }
            }

            private string mPostingGroup;
            public string PostingGroup
            {
                get { return mPostingGroup; }
                set { mPostingGroup = value; }
            }

            private string mShipmentDate;
            public string ShipmentDate
            {
                get { return mShipmentDate; }
                set { mShipmentDate = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = value; }
            }

            private string mDescription2;
            public string Description2
            {
                get { return mDescription2; }
                set { mDescription2 = value; }
            }

            private string mUnitofMeasure;
            public string UnitofMeasure
            {
                get { return mUnitofMeasure; }
                set { mUnitofMeasure = value; }
            }

            private double mQuantity;
            public double Quantity
            {
                get { return mQuantity; }
                set { mQuantity = value; }
            }

            private double mOutstandingQuantity;
            public double OutstandingQuantity
            {
                get { return mOutstandingQuantity; }
                set { mOutstandingQuantity = value; }
            }

            private double mQtytoInvoice;
            public double QtytoInvoice
            {
                get { return mQtytoInvoice; }
                set { mQtytoInvoice = value; }
            }

            private double mQtytoShip;
            public double QtytoShip
            {
                get { return mQtytoShip; }
                set { mQtytoShip = value; }
            }

            private double mUnitPrice;
            public double UnitPrice
            {
                get { return mUnitPrice; }
                set { mUnitPrice = value; }
            }

            private double mUnitCost_LCY;
            public double UnitCost_LCY
            {
                get { return mUnitCost_LCY; }
                set { mUnitCost_LCY = value; }
            }

            private double mVAT;
            public double VAT
            {
                get { return mVAT; }
                set { mVAT = value; }
            }

            private double mLineDiscount;
            public double LineDiscount
            {
                get { return mLineDiscount; }
                set { mLineDiscount = value; }
            }

            private double mLineDiscountAmount;
            public double LineDiscountAmount
            {
                get { return mLineDiscountAmount; }
                set { mLineDiscountAmount = value; }
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

            private int mAllowInvoiceDisc;
            public int AllowInvoiceDisc
            {
                get { return mAllowInvoiceDisc; }
                set { mAllowInvoiceDisc = value; }
            }

            private double mGrossWeight;
            public double GrossWeight
            {
                get { return mGrossWeight; }
                set { mGrossWeight = value; }
            }

            private double mNetWeight;
            public double NetWeight
            {
                get { return mNetWeight; }
                set { mNetWeight = value; }
            }

            private double mUnitsperParcel;
            public double UnitsperParcel
            {
                get { return mUnitsperParcel; }
                set { mUnitsperParcel = value; }
            }

            private double mUnitVolume;
            public double UnitVolume
            {
                get { return mUnitVolume; }
                set { mUnitVolume = value; }
            }

            private Int32 mAppltoItemEntry;
            public Int32 AppltoItemEntry
            {
                get { return mAppltoItemEntry; }
                set { mAppltoItemEntry = value; }
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

            private string mCustomerPriceGroup;
            public string CustomerPriceGroup
            {
                get { return mCustomerPriceGroup; }
                set { mCustomerPriceGroup = value; }
            }

            private string mJobNo;
            public string JobNo
            {
                get { return mJobNo; }
                set { mJobNo = value; }
            }

            private Int32 mAppltoJobEntry;
            public Int32 AppltoJobEntry
            {
                get { return mAppltoJobEntry; }
                set { mAppltoJobEntry = value; }
            }

            private string mPhaseCode;
            public string PhaseCode
            {
                get { return mPhaseCode; }
                set { mPhaseCode = value; }
            }

            private string mTaskCode;
            public string TaskCode
            {
                get { return mTaskCode; }
                set { mTaskCode = value; }
            }

            private string mStepCode;
            public string StepCode
            {
                get { return mStepCode; }
                set { mStepCode = value; }
            }

            private string mJobAppliestoID;
            public string JobAppliestoID
            {
                get { return mJobAppliestoID; }
                set { mJobAppliestoID = value; }
            }

            private int mApplyandClose_Job;
            public int ApplyandClose_Job
            {
                get { return mApplyandClose_Job; }
                set { mApplyandClose_Job = value; }
            }

            private string mWorkTypeCode;
            public string WorkTypeCode
            {
                get { return mWorkTypeCode; }
                set { mWorkTypeCode = value; }
            }

            private double mOutstandingAmount;
            public double OutstandingAmount
            {
                get { return mOutstandingAmount; }
                set { mOutstandingAmount = value; }
            }

            private double mQtyShippedNotInvoiced;
            public double QtyShippedNotInvoiced
            {
                get { return mQtyShippedNotInvoiced; }
                set { mQtyShippedNotInvoiced = value; }
            }

            private double mShippedNotInvoiced;
            public double ShippedNotInvoiced
            {
                get { return mShippedNotInvoiced; }
                set { mShippedNotInvoiced = value; }
            }

            private double mQuantityShipped;
            public double QuantityShipped
            {
                get { return mQuantityShipped; }
                set { mQuantityShipped = value; }
            }

            private double mQuantityInvoiced;
            public double QuantityInvoiced
            {
                get { return mQuantityInvoiced; }
                set { mQuantityInvoiced = value; }
            }

            private string mShipmentNo;
            public string ShipmentNo
            {
                get { return mShipmentNo; }
                set { mShipmentNo = value; }
            }

            private Int32 mShipmentLineNo;
            public Int32 ShipmentLineNo
            {
                get { return mShipmentLineNo; }
                set { mShipmentLineNo = value; }
            }

            private double mProfit;
            public double Profit
            {
                get { return mProfit; }
                set { mProfit = value; }
            }

            private string mBilltoCustomerNo;
            public string BilltoCustomerNo
            {
                get { return mBilltoCustomerNo; }
                set { mBilltoCustomerNo = value; }
            }

            private double mInvDiscountAmount;
            public double InvDiscountAmount
            {
                get { return mInvDiscountAmount; }
                set { mInvDiscountAmount = value; }
            }

            private string mPurchaseOrderNo;
            public string PurchaseOrderNo
            {
                get { return mPurchaseOrderNo; }
                set { mPurchaseOrderNo = value; }
            }

            private Int32 mPurchOrderLineNo;
            public Int32 PurchOrderLineNo
            {
                get { return mPurchOrderLineNo; }
                set { mPurchOrderLineNo = value; }
            }

            private int mDropShipment;
            public int DropShipment
            {
                get { return mDropShipment; }
                set { mDropShipment = value; }
            }

            private string mGenBusPostingGroup;
            public string GenBusPostingGroup
            {
                get { return mGenBusPostingGroup; }
                set { mGenBusPostingGroup = value; }
            }

            private string mGenProdPostingGroup;
            public string GenProdPostingGroup
            {
                get { return mGenProdPostingGroup; }
                set { mGenProdPostingGroup = value; }
            }

            private string mVATCalculationType;
            public string VATCalculationType
            {
                get { return mVATCalculationType; }
                set { mVATCalculationType = value; }
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

            private Int32 mAttachedtoLineNo;
            public Int32 AttachedtoLineNo
            {
                get { return mAttachedtoLineNo; }
                set { mAttachedtoLineNo = value; }
            }

            private string mExitPoint;
            public string ExitPoint
            {
                get { return mExitPoint; }
                set { mExitPoint = value; }
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

            private string mTaxGroupCode;
            public string TaxGroupCode
            {
                get { return mTaxGroupCode; }
                set { mTaxGroupCode = value; }
            }

            private string mVATBusPostingGroup;
            public string VATBusPostingGroup
            {
                get { return mVATBusPostingGroup; }
                set { mVATBusPostingGroup = value; }
            }

            private string mVATProdPostingGroup;
            public string VATProdPostingGroup
            {
                get { return mVATProdPostingGroup; }
                set { mVATProdPostingGroup = value; }
            }

            private string mCurrencyCode;
            public string CurrencyCode
            {
                get { return mCurrencyCode; }
                set { mCurrencyCode = value; }
            }

            private double mOutstandingAmount_LCY;
            public double OutstandingAmount_LCY
            {
                get { return mOutstandingAmount_LCY; }
                set { mOutstandingAmount_LCY = value; }
            }

            private double mShippedNotInvoiced_LCY;
            public double ShippedNotInvoiced_LCY
            {
                get { return mShippedNotInvoiced_LCY; }
                set { mShippedNotInvoiced_LCY = value; }
            }

            private double mReservedQuantity;
            public double ReservedQuantity
            {
                get { return mReservedQuantity; }
                set { mReservedQuantity = value; }
            }

            private string mReserve;
            public string Reserve
            {
                get { return mReserve; }
                set { mReserve = value; }
            }

            private string mBlanketOrderNo;
            public string BlanketOrderNo
            {
                get { return mBlanketOrderNo; }
                set { mBlanketOrderNo = value; }
            }

            private Int32 mBlanketOrderLineNo;
            public Int32 BlanketOrderLineNo
            {
                get { return mBlanketOrderLineNo; }
                set { mBlanketOrderLineNo = value; }
            }

            private double mVATBaseAmount;
            public double VATBaseAmount
            {
                get { return mVATBaseAmount; }
                set { mVATBaseAmount = value; }
            }

            private double mUnitCost;
            public double UnitCost
            {
                get { return mUnitCost; }
                set { mUnitCost = value; }
            }

            private int mSystemCreatedEntry;
            public int SystemCreatedEntry
            {
                get { return mSystemCreatedEntry; }
                set { mSystemCreatedEntry = value; }
            }

            private double mLineAmount;
            public double LineAmount
            {
                get { return mLineAmount; }
                set { mLineAmount = value; }
            }

            private double mVATDifference;
            public double VATDifference
            {
                get { return mVATDifference; }
                set { mVATDifference = value; }
            }

            private double mInvDiscAmounttoInvoice;
            public double InvDiscAmounttoInvoice
            {
                get { return mInvDiscAmounttoInvoice; }
                set { mInvDiscAmounttoInvoice = value; }
            }

            private string mVATIdentifier;
            public string VATIdentifier
            {
                get { return mVATIdentifier; }
                set { mVATIdentifier = value; }
            }

            private string mICPartnerRefType;
            public string ICPartnerRefType
            {
                get { return mICPartnerRefType; }
                set { mICPartnerRefType = value; }
            }

            private string mICPartnerReference;
            public string ICPartnerReference
            {
                get { return mICPartnerReference; }
                set { mICPartnerReference = value; }
            }

            private string mVariantCode;
            public string VariantCode
            {
                get { return mVariantCode; }
                set { mVariantCode = value; }
            }

            private string mBinCode;
            public string BinCode
            {
                get { return mBinCode; }
                set { mBinCode = value; }
            }

            private double mQtyperUnitofMeasure;
            public double QtyperUnitofMeasure
            {
                get { return mQtyperUnitofMeasure; }
                set { mQtyperUnitofMeasure = value; }
            }

            private int mPlanned;
            public int Planned
            {
                get { return mPlanned; }
                set { mPlanned = value; }
            }

            private string mUnitofMeasureCode;
            public string UnitofMeasureCode
            {
                get { return mUnitofMeasureCode; }
                set { mUnitofMeasureCode = value; }
            }

            private double mQuantity_Base;
            public double Quantity_Base
            {
                get { return mQuantity_Base; }
                set { mQuantity_Base = value; }
            }

            private double mOutstandingQty_Base;
            public double OutstandingQty_Base
            {
                get { return mOutstandingQty_Base; }
                set { mOutstandingQty_Base = value; }
            }

            private double mQtytoInvoice_Base;
            public double QtytoInvoice_Base
            {
                get { return mQtytoInvoice_Base; }
                set { mQtytoInvoice_Base = value; }
            }

            private double mQtytoShip_Base;
            public double QtytoShip_Base
            {
                get { return mQtytoShip_Base; }
                set { mQtytoShip_Base = value; }
            }

            private double mQtyShippedNotInvd_Base;
            public double QtyShippedNotInvd_Base
            {
                get { return mQtyShippedNotInvd_Base; }
                set { mQtyShippedNotInvd_Base = value; }
            }

            private double mQtyShipped_Base;
            public double QtyShipped_Base
            {
                get { return mQtyShipped_Base; }
                set { mQtyShipped_Base = value; }
            }

            private double mQtyInvoiced_Base;
            public double QtyInvoiced_Base
            {
                get { return mQtyInvoiced_Base; }
                set { mQtyInvoiced_Base = value; }
            }

            private double mReservedQty_Base;
            public double ReservedQty_Base
            {
                get { return mReservedQty_Base; }
                set { mReservedQty_Base = value; }
            }

            private string mFAPostingDate;
            public string FAPostingDate
            {
                get { return mFAPostingDate; }
                set { mFAPostingDate = value; }
            }

            private string mDepreciationBookCode;
            public string DepreciationBookCode
            {
                get { return mDepreciationBookCode; }
                set { mDepreciationBookCode = value; }
            }

            private int mDepruntilFAPostingDate;
            public int DepruntilFAPostingDate
            {
                get { return mDepruntilFAPostingDate; }
                set { mDepruntilFAPostingDate = value; }
            }

            private string mDuplicateinDepreciationBook;
            public string DuplicateinDepreciationBook
            {
                get { return mDuplicateinDepreciationBook; }
                set { mDuplicateinDepreciationBook = value; }
            }

            private int mUseDuplicationList;
            public int UseDuplicationList
            {
                get { return mUseDuplicationList; }
                set { mUseDuplicationList = value; }
            }

            private string mResponsibilityCenter;
            public string ResponsibilityCenter
            {
                get { return mResponsibilityCenter; }
                set { mResponsibilityCenter = value; }
            }

            private int mOutofStockSubstitution;
            public int OutofStockSubstitution
            {
                get { return mOutofStockSubstitution; }
                set { mOutofStockSubstitution = value; }
            }

            private int mSubstitutionAvailable;
            public int SubstitutionAvailable
            {
                get { return mSubstitutionAvailable; }
                set { mSubstitutionAvailable = value; }
            }

            private string mOriginallyOrderedNo;
            public string OriginallyOrderedNo
            {
                get { return mOriginallyOrderedNo; }
                set { mOriginallyOrderedNo = value; }
            }

            private string mOriginallyOrderedVarCode;
            public string OriginallyOrderedVarCode
            {
                get { return mOriginallyOrderedVarCode; }
                set { mOriginallyOrderedVarCode = value; }
            }

            private string mCrossReferenceNo;
            public string CrossReferenceNo
            {
                get { return mCrossReferenceNo; }
                set { mCrossReferenceNo = value; }
            }

            private string mUnitofMeasure_CrossRef;
            public string UnitofMeasure_CrossRef
            {
                get { return mUnitofMeasure_CrossRef; }
                set { mUnitofMeasure_CrossRef = value; }
            }

            private string mCrossReferenceType;
            public string CrossReferenceType
            {
                get { return mCrossReferenceType; }
                set { mCrossReferenceType = value; }
            }

            private string mCrossReferenceTypeNo;
            public string CrossReferenceTypeNo
            {
                get { return mCrossReferenceTypeNo; }
                set { mCrossReferenceTypeNo = value; }
            }

            private string mItemCategoryCode;
            public string ItemCategoryCode
            {
                get { return mItemCategoryCode; }
                set { mItemCategoryCode = value; }
            }

            private int mNonstock;
            public int Nonstock
            {
                get { return mNonstock; }
                set { mNonstock = value; }
            }

            private string mPurchasingCode;
            public string PurchasingCode
            {
                get { return mPurchasingCode; }
                set { mPurchasingCode = value; }
            }

            private string mProductGroupCode;
            public string ProductGroupCode
            {
                get { return mProductGroupCode; }
                set { mProductGroupCode = value; }
            }

            private int mSpecialOrder;
            public int SpecialOrder
            {
                get { return mSpecialOrder; }
                set { mSpecialOrder = value; }
            }

            private string mSpecialOrderPurchaseNo;
            public string SpecialOrderPurchaseNo
            {
                get { return mSpecialOrderPurchaseNo; }
                set { mSpecialOrderPurchaseNo = value; }
            }

            private Int32 mSpecialOrderPurchLineNo;
            public Int32 SpecialOrderPurchLineNo
            {
                get { return mSpecialOrderPurchLineNo; }
                set { mSpecialOrderPurchLineNo = value; }
            }

            private double mWhseOutstandingQty_Base;
            public double WhseOutstandingQty_Base
            {
                get { return mWhseOutstandingQty_Base; }
                set { mWhseOutstandingQty_Base = value; }
            }

            private int mCompletelyShipped;
            public int CompletelyShipped
            {
                get { return mCompletelyShipped; }
                set { mCompletelyShipped = value; }
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

            private string mPlannedDeliveryDate;
            public string PlannedDeliveryDate
            {
                get { return mPlannedDeliveryDate; }
                set { mPlannedDeliveryDate = value; }
            }

            private string mPlannedShipmentDate;
            public string PlannedShipmentDate
            {
                get { return mPlannedShipmentDate; }
                set { mPlannedShipmentDate = value; }
            }

            private string mShippingAgentCode;
            public string ShippingAgentCode
            {
                get { return mShippingAgentCode; }
                set { mShippingAgentCode = value; }
            }

            private string mShippingAgentServiceCode;
            public string ShippingAgentServiceCode
            {
                get { return mShippingAgentServiceCode; }
                set { mShippingAgentServiceCode = value; }
            }

            private int mAllowItemChargeAssignment;
            public int AllowItemChargeAssignment
            {
                get { return mAllowItemChargeAssignment; }
                set { mAllowItemChargeAssignment = value; }
            }

            private double mQtytoAssign;
            public double QtytoAssign
            {
                get { return mQtytoAssign; }
                set { mQtytoAssign = value; }
            }

            private double mQtyAssigned;
            public double QtyAssigned
            {
                get { return mQtyAssigned; }
                set { mQtyAssigned = value; }
            }

            private double mReturnQtytoReceive;
            public double ReturnQtytoReceive
            {
                get { return mReturnQtytoReceive; }
                set { mReturnQtytoReceive = value; }
            }

            private double mReturnQtytoReceive_Base;
            public double ReturnQtytoReceive_Base
            {
                get { return mReturnQtytoReceive_Base; }
                set { mReturnQtytoReceive_Base = value; }
            }

            private double mReturnQtyRcdNotInvd;
            public double ReturnQtyRcdNotInvd
            {
                get { return mReturnQtyRcdNotInvd; }
                set { mReturnQtyRcdNotInvd = value; }
            }

            private double mRetQtyRcdNotInvd_Base;
            public double RetQtyRcdNotInvd_Base
            {
                get { return mRetQtyRcdNotInvd_Base; }
                set { mRetQtyRcdNotInvd_Base = value; }
            }

            private double mReturnRcdNotInvd;
            public double ReturnRcdNotInvd
            {
                get { return mReturnRcdNotInvd; }
                set { mReturnRcdNotInvd = value; }
            }

            private double mReturnRcdNotInvd_LCY;
            public double ReturnRcdNotInvd_LCY
            {
                get { return mReturnRcdNotInvd_LCY; }
                set { mReturnRcdNotInvd_LCY = value; }
            }

            private double mReturnQtyReceived;
            public double ReturnQtyReceived
            {
                get { return mReturnQtyReceived; }
                set { mReturnQtyReceived = value; }
            }

            private double mReturnQtyReceived_Base;
            public double ReturnQtyReceived_Base
            {
                get { return mReturnQtyReceived_Base; }
                set { mReturnQtyReceived_Base = value; }
            }

            private Int32 mApplfromItemEntry;
            public Int32 ApplfromItemEntry
            {
                get { return mApplfromItemEntry; }
                set { mApplfromItemEntry = value; }
            }

            private string mServiceContractNo;
            public string ServiceContractNo
            {
                get { return mServiceContractNo; }
                set { mServiceContractNo = value; }
            }

            private string mServiceOrderNo;
            public string ServiceOrderNo
            {
                get { return mServiceOrderNo; }
                set { mServiceOrderNo = value; }
            }

            private string mServiceItemNo;
            public string ServiceItemNo
            {
                get { return mServiceItemNo; }
                set { mServiceItemNo = value; }
            }

            private Int32 mAppltoServiceEntry;
            public Int32 AppltoServiceEntry
            {
                get { return mAppltoServiceEntry; }
                set { mAppltoServiceEntry = value; }
            }

            private Int32 mServiceItemLineNo;
            public Int32 ServiceItemLineNo
            {
                get { return mServiceItemLineNo; }
                set { mServiceItemLineNo = value; }
            }

            private string mServPriceAdjmtGrCode;
            public string ServPriceAdjmtGrCode
            {
                get { return mServPriceAdjmtGrCode; }
                set { mServPriceAdjmtGrCode = value; }
            }

            private string mBOMItemNo;
            public string BOMItemNo
            {
                get { return mBOMItemNo; }
                set { mBOMItemNo = value; }
            }

            private string mReturnReceiptNo;
            public string ReturnReceiptNo
            {
                get { return mReturnReceiptNo; }
                set { mReturnReceiptNo = value; }
            }

            private Int32 mReturnReceiptLineNo;
            public Int32 ReturnReceiptLineNo
            {
                get { return mReturnReceiptLineNo; }
                set { mReturnReceiptLineNo = value; }
            }

            private string mReturnReasonCode;
            public string ReturnReasonCode
            {
                get { return mReturnReasonCode; }
                set { mReturnReasonCode = value; }
            }

            private int mAllowLineDisc;
            public int AllowLineDisc
            {
                get { return mAllowLineDisc; }
                set { mAllowLineDisc = value; }
            }

            private string mCustomerDiscGroup;
            public string CustomerDiscGroup
            {
                get { return mCustomerDiscGroup; }
                set { mCustomerDiscGroup = value; }
            }

            private string mServicePostingDate;
            public string ServicePostingDate
            {
                get { return mServicePostingDate; }
                set { mServicePostingDate = value; }
            }

            private string mWHTBusinessPostingGroup;
            public string WHTBusinessPostingGroup
            {
                get { return mWHTBusinessPostingGroup; }
                set { mWHTBusinessPostingGroup = value; }
            }

            private string mWHTProductPostingGroup;
            public string WHTProductPostingGroup
            {
                get { return mWHTProductPostingGroup; }
                set { mWHTProductPostingGroup = value; }
            }

            private double mWHTAbsorbBase;
            public double WHTAbsorbBase
            {
                get { return mWHTAbsorbBase; }
                set { mWHTAbsorbBase = value; }
            }

        }
    }
}