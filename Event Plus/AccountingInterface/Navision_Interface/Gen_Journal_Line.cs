using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


//using Jinisys.Hotel.Reservation.BusinessLayer;
//using Jinisys.Hotel.Configuration.BusinessLayer;


namespace Jinisys.Hotel.AccountingInterface.Navision_Interface
{
    namespace BusinessLayer
    {
        public class Gen_Journal_Line
        {
            private string mJournalTemplateName;
            public string JournalTemplateName
            {
                get { return mJournalTemplateName; }
                set { mJournalTemplateName = value; }
            }

            private Int32 mLineNo;
            public Int32 LineNo
            {
                get { return mLineNo; }
                set { mLineNo = value; }
            }

            private string mAccountType;
            public string AccountType
            {
                get { return mAccountType; }
                set { mAccountType = value; }
            }

            private string mAccountNo;
            public string AccountNo
            {
                get { return mAccountNo; }
                set { mAccountNo = value; }
            }

            private string mPostingDate;
            public string PostingDate
            {
                get { return mPostingDate; }
                set { mPostingDate = value; }
            }

            private string mDocumentType;
            public string DocumentType
            {
                get { return mDocumentType; }
                set { mDocumentType = value; }
            }

            private string mDocumentNo;
            public string DocumentNo
            {
                get { return mDocumentNo; }
                set { mDocumentNo = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = value; }
            }

            private double mVAT;
            public double VAT
            {
                get { return mVAT; }
                set { mVAT = value; }
            }

            private string mBalAccountNo;
            public string BalAccountNo
            {
                get { return mBalAccountNo; }
                set { mBalAccountNo = value; }
            }

            private string mCurrencyCode;
            public string CurrencyCode
            {
                get { return mCurrencyCode; }
                set { mCurrencyCode = value; }
            }

            private double mAmount;
            public double Amount
            {
                get { return mAmount; }
                set { mAmount = value; }
            }

            private double mDebitAmount;
            public double DebitAmount
            {
                get { return mDebitAmount; }
                set { mDebitAmount = value; }
            }

            private double mCreditAmount;
            public double CreditAmount
            {
                get { return mCreditAmount; }
                set { mCreditAmount = value; }
            }

            private double mAmount_LCY;
            public double Amount_LCY
            {
                get { return mAmount_LCY; }
                set { mAmount_LCY = value; }
            }

            private double mBalance_LCY;
            public double Balance_LCY
            {
                get { return mBalance_LCY; }
                set { mBalance_LCY = value; }
            }

            private double mCurrencyFactor;
            public double CurrencyFactor
            {
                get { return mCurrencyFactor; }
                set { mCurrencyFactor = value; }
            }

            private double mSales_Purch_LCY;
            public double Sales_Purch_LCY
            {
                get { return mSales_Purch_LCY; }
                set { mSales_Purch_LCY = value; }
            }

            private double mProfit_LCY;
            public double Profit_LCY
            {
                get { return mProfit_LCY; }
                set { mProfit_LCY = value; }
            }

            private double mInvDiscount_LCY;
            public double InvDiscount_LCY
            {
                get { return mInvDiscount_LCY; }
                set { mInvDiscount_LCY = value; }
            }

            private string mBillto_PaytoNo;
            public string Billto_PaytoNo
            {
                get { return mBillto_PaytoNo; }
                set { mBillto_PaytoNo = value; }
            }

            private string mPostingGroup;
            public string PostingGroup
            {
                get { return mPostingGroup; }
                set { mPostingGroup = value; }
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

            private string mSalespers_PurchCode;
            public string Salespers_PurchCode
            {
                get { return mSalespers_PurchCode; }
                set { mSalespers_PurchCode = value; }
            }

            private string mSourceCode;
            public string SourceCode
            {
                get { return mSourceCode; }
                set { mSourceCode = value; }
            }

            private int mSystemCreatedEntry;
            public int SystemCreatedEntry
            {
                get { return mSystemCreatedEntry; }
                set { mSystemCreatedEntry = value; }
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

            private string mDueDate;
            public string DueDate
            {
                get { return mDueDate; }
                set { mDueDate = value; }
            }

            private string mPmtDiscountDate;
            public string PmtDiscountDate
            {
                get { return mPmtDiscountDate; }
                set { mPmtDiscountDate = value; }
            }

            private double mPaymentDiscount;
            public double PaymentDiscount
            {
                get { return mPaymentDiscount; }
                set { mPaymentDiscount = value; }
            }

            private string mJobNo;
            public string JobNo
            {
                get { return mJobNo; }
                set { mJobNo = value; }
            }

            private double mQuantity;
            public double Quantity
            {
                get { return mQuantity; }
                set { mQuantity = value; }
            }

            private double mVATAmount;
            public double VATAmount
            {
                get { return mVATAmount; }
                set { mVATAmount = value; }
            }

            private string mVATPosting;
            public string VATPosting
            {
                get { return mVATPosting; }
                set { mVATPosting = value; }
            }

            private string mPaymentTermsCode;
            public string PaymentTermsCode
            {
                get { return mPaymentTermsCode; }
                set { mPaymentTermsCode = value; }
            }

            private string mAppliestoID;
            public string AppliestoID
            {
                get { return mAppliestoID; }
                set { mAppliestoID = value; }
            }

            private string mBusinessUnitCode;
            public string BusinessUnitCode
            {
                get { return mBusinessUnitCode; }
                set { mBusinessUnitCode = value; }
            }

            private string mJournalBatchName;
            public string JournalBatchName
            {
                get { return mJournalBatchName; }
                set { mJournalBatchName = value; }
            }

            private string mReasonCode;
            public string ReasonCode
            {
                get { return mReasonCode; }
                set { mReasonCode = value; }
            }

            private string mRecurringMethod;
            public string RecurringMethod
            {
                get { return mRecurringMethod; }
                set { mRecurringMethod = value; }
            }

            private string mExpirationDate;
            public string ExpirationDate
            {
                get { return mExpirationDate; }
                set { mExpirationDate = value; }
            }

            private string mRecurringFrequency;
            public string RecurringFrequency
            {
                get { return mRecurringFrequency; }
                set { mRecurringFrequency = value; }
            }

            private double mAllocatedAmt_LCY;
            public double AllocatedAmt_LCY
            {
                get { return mAllocatedAmt_LCY; }
                set { mAllocatedAmt_LCY = value; }
            }

            private string mGenPostingType;
            public string GenPostingType
            {
                get { return mGenPostingType; }
                set { mGenPostingType = value; }
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

            private int mEU3PartyTrade;
            public int EU3PartyTrade
            {
                get { return mEU3PartyTrade; }
                set { mEU3PartyTrade = value; }
            }

            private int mAllowApplication;
            public int AllowApplication
            {
                get { return mAllowApplication; }
                set { mAllowApplication = value; }
            }

            private string mBalAccountType;
            public string BalAccountType
            {
                get { return mBalAccountType; }
                set { mBalAccountType = value; }
            }

            private string mBalGenPostingType;
            public string BalGenPostingType
            {
                get { return mBalGenPostingType; }
                set { mBalGenPostingType = value; }
            }

            private string mBalGenBusPostingGroup;
            public string BalGenBusPostingGroup
            {
                get { return mBalGenBusPostingGroup; }
                set { mBalGenBusPostingGroup = value; }
            }

            private string mBalGenProdPostingGroup;
            public string BalGenProdPostingGroup
            {
                get { return mBalGenProdPostingGroup; }
                set { mBalGenProdPostingGroup = value; }
            }

            private string mBalVATCalculationType;
            public string BalVATCalculationType
            {
                get { return mBalVATCalculationType; }
                set { mBalVATCalculationType = value; }
            }

            private double mBalVAT;
            public double BalVAT
            {
                get { return mBalVAT; }
                set { mBalVAT = value; }
            }

            private double mBalVATAmount;
            public double BalVATAmount
            {
                get { return mBalVATAmount; }
                set { mBalVATAmount = value; }
            }

            private string mBankPaymentType;
            public string BankPaymentType
            {
                get { return mBankPaymentType; }
                set { mBankPaymentType = value; }
            }

            private double mVATBaseAmount;
            public double VATBaseAmount
            {
                get { return mVATBaseAmount; }
                set { mVATBaseAmount = value; }
            }

            private double mBalVATBaseAmount;
            public double BalVATBaseAmount
            {
                get { return mBalVATBaseAmount; }
                set { mBalVATBaseAmount = value; }
            }

            private int mCorrection;
            public int Correction
            {
                get { return mCorrection; }
                set { mCorrection = value; }
            }

            private int mCheckPrinted;
            public int CheckPrinted
            {
                get { return mCheckPrinted; }
                set { mCheckPrinted = value; }
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

            private string mSourceType;
            public string SourceType
            {
                get { return mSourceType; }
                set { mSourceType = value; }
            }

            private string mSourceNo;
            public string SourceNo
            {
                get { return mSourceNo; }
                set { mSourceNo = value; }
            }

            private string mPostingNoSeries;
            public string PostingNoSeries
            {
                get { return mPostingNoSeries; }
                set { mPostingNoSeries = value; }
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

            private int mUseTax;
            public int UseTax
            {
                get { return mUseTax; }
                set { mUseTax = value; }
            }

            private string mBalTaxAreaCode;
            public string BalTaxAreaCode
            {
                get { return mBalTaxAreaCode; }
                set { mBalTaxAreaCode = value; }
            }

            private int mBalTaxLiable;
            public int BalTaxLiable
            {
                get { return mBalTaxLiable; }
                set { mBalTaxLiable = value; }
            }

            private string mBalTaxGroupCode;
            public string BalTaxGroupCode
            {
                get { return mBalTaxGroupCode; }
                set { mBalTaxGroupCode = value; }
            }

            private int mBalUseTax;
            public int BalUseTax
            {
                get { return mBalUseTax; }
                set { mBalUseTax = value; }
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

            private string mBalVATBusPostingGroup;
            public string BalVATBusPostingGroup
            {
                get { return mBalVATBusPostingGroup; }
                set { mBalVATBusPostingGroup = value; }
            }

            private string mBalVATProdPostingGroup;
            public string BalVATProdPostingGroup
            {
                get { return mBalVATProdPostingGroup; }
                set { mBalVATProdPostingGroup = value; }
            }

            private string mAdditionalCurrencyPosting;
            public string AdditionalCurrencyPosting
            {
                get { return mAdditionalCurrencyPosting; }
                set { mAdditionalCurrencyPosting = value; }
            }

            private double mFAAddCurrencyFactor;
            public double FAAddCurrencyFactor
            {
                get { return mFAAddCurrencyFactor; }
                set { mFAAddCurrencyFactor = value; }
            }

            private string mSourceCurrencyCode;
            public string SourceCurrencyCode
            {
                get { return mSourceCurrencyCode; }
                set { mSourceCurrencyCode = value; }
            }

            private double mSourceCurrencyAmount;
            public double SourceCurrencyAmount
            {
                get { return mSourceCurrencyAmount; }
                set { mSourceCurrencyAmount = value; }
            }

            private double mSourceCurrVATBaseAmount;
            public double SourceCurrVATBaseAmount
            {
                get { return mSourceCurrVATBaseAmount; }
                set { mSourceCurrVATBaseAmount = value; }
            }

            private double mSourceCurrVATAmount;
            public double SourceCurrVATAmount
            {
                get { return mSourceCurrVATAmount; }
                set { mSourceCurrVATAmount = value; }
            }

            private double mVATBaseDiscount;
            public double VATBaseDiscount
            {
                get { return mVATBaseDiscount; }
                set { mVATBaseDiscount = value; }
            }

            private double mVATAmount_LCY;
            public double VATAmount_LCY
            {
                get { return mVATAmount_LCY; }
                set { mVATAmount_LCY = value; }
            }

            private double mVATBaseAmount_LCY;
            public double VATBaseAmount_LCY
            {
                get { return mVATBaseAmount_LCY; }
                set { mVATBaseAmount_LCY = value; }
            }

            private double mBalVATAmount_LCY;
            public double BalVATAmount_LCY
            {
                get { return mBalVATAmount_LCY; }
                set { mBalVATAmount_LCY = value; }
            }

            private double mBalVATBaseAmount_LCY;
            public double BalVATBaseAmount_LCY
            {
                get { return mBalVATBaseAmount_LCY; }
                set { mBalVATBaseAmount_LCY = value; }
            }

            private int mReversingEntry;
            public int ReversingEntry
            {
                get { return mReversingEntry; }
                set { mReversingEntry = value; }
            }

            private int mAllowZeroAmountPosting;
            public int AllowZeroAmountPosting
            {
                get { return mAllowZeroAmountPosting; }
                set { mAllowZeroAmountPosting = value; }
            }

            private string mShipto_OrderAddressCode;
            public string Shipto_OrderAddressCode
            {
                get { return mShipto_OrderAddressCode; }
                set { mShipto_OrderAddressCode = value; }
            }

            private double mVATDifference;
            public double VATDifference
            {
                get { return mVATDifference; }
                set { mVATDifference = value; }
            }

            private double mBalVATDifference;
            public double BalVATDifference
            {
                get { return mBalVATDifference; }
                set { mBalVATDifference = value; }
            }

            private string mICPartnerCode;
            public string ICPartnerCode
            {
                get { return mICPartnerCode; }
                set { mICPartnerCode = value; }
            }

            private string mICDirection;
            public string ICDirection
            {
                get { return mICDirection; }
                set { mICDirection = value; }
            }

            private string mICPartnerG_LAccNo;
            public string ICPartnerG_LAccNo
            {
                get { return mICPartnerG_LAccNo; }
                set { mICPartnerG_LAccNo = value; }
            }

            private Int32 mICPartnerTransactionNo;
            public Int32 ICPartnerTransactionNo
            {
                get { return mICPartnerTransactionNo; }
                set { mICPartnerTransactionNo = value; }
            }

            private string mSellto_BuyfromNo;
            public string Sellto_BuyfromNo
            {
                get { return mSellto_BuyfromNo; }
                set { mSellto_BuyfromNo = value; }
            }

            private string mVATRegistrationNo;
            public string VATRegistrationNo
            {
                get { return mVATRegistrationNo; }
                set { mVATRegistrationNo = value; }
            }

            private string mCountryCode;
            public string CountryCode
            {
                get { return mCountryCode; }
                set { mCountryCode = value; }
            }

            private string mCampaignNo;
            public string CampaignNo
            {
                get { return mCampaignNo; }
                set { mCampaignNo = value; }
            }

            private string mProdOrderNo;
            public string ProdOrderNo
            {
                get { return mProdOrderNo; }
                set { mProdOrderNo = value; }
            }

            private string mFAPostingDate;
            public string FAPostingDate
            {
                get { return mFAPostingDate; }
                set { mFAPostingDate = value; }
            }

            private string mFAPostingType;
            public string FAPostingType
            {
                get { return mFAPostingType; }
                set { mFAPostingType = value; }
            }

            private string mDepreciationBookCode;
            public string DepreciationBookCode
            {
                get { return mDepreciationBookCode; }
                set { mDepreciationBookCode = value; }
            }

            private double mSalvageValue;
            public double SalvageValue
            {
                get { return mSalvageValue; }
                set { mSalvageValue = value; }
            }

            private Int32 mNoofDepreciationDays;
            public Int32 NoofDepreciationDays
            {
                get { return mNoofDepreciationDays; }
                set { mNoofDepreciationDays = value; }
            }

            private int mDepruntilFAPostingDate;
            public int DepruntilFAPostingDate
            {
                get { return mDepruntilFAPostingDate; }
                set { mDepruntilFAPostingDate = value; }
            }

            private int mDeprAcquisitionCost;
            public int DeprAcquisitionCost
            {
                get { return mDeprAcquisitionCost; }
                set { mDeprAcquisitionCost = value; }
            }

            private string mMaintenanceCode;
            public string MaintenanceCode
            {
                get { return mMaintenanceCode; }
                set { mMaintenanceCode = value; }
            }

            private string mInsuranceNo;
            public string InsuranceNo
            {
                get { return mInsuranceNo; }
                set { mInsuranceNo = value; }
            }

            private string mBudgetedFANo;
            public string BudgetedFANo
            {
                get { return mBudgetedFANo; }
                set { mBudgetedFANo = value; }
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

            private int mFAReclassificationEntry;
            public int FAReclassificationEntry
            {
                get { return mFAReclassificationEntry; }
                set { mFAReclassificationEntry = value; }
            }

            private Int32 mFAErrorEntryNo;
            public Int32 FAErrorEntryNo
            {
                get { return mFAErrorEntryNo; }
                set { mFAErrorEntryNo = value; }
            }

            private int mIndexEntry;
            public int IndexEntry
            {
                get { return mIndexEntry; }
                set { mIndexEntry = value; }
            }

            private Int32 mValueEntryNo;
            public Int32 ValueEntryNo
            {
                get { return mValueEntryNo; }
                set { mValueEntryNo = value; }
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

            private Int32 mAdjmtEntryNo;
            public Int32 AdjmtEntryNo
            {
                get { return mAdjmtEntryNo; }
                set { mAdjmtEntryNo = value; }
            }

            private string mBASDocNo;
            public string BASDocNo
            {
                get { return mBASDocNo; }
                set { mBASDocNo = value; }
            }

            private Int32 mBASVersion;
            public Int32 BASVersion
            {
                get { return mBASVersion; }
                set { mBASVersion = value; }
            }

            private int mFinancialyVoidedCheque;
            public int FinancialyVoidedCheque
            {
                get { return mFinancialyVoidedCheque; }
                set { mFinancialyVoidedCheque = value; }
            }

            private string mBankBranchNo;
            public string BankBranchNo
            {
                get { return mBankBranchNo; }
                set { mBankBranchNo = value; }
            }

            private string mBankAccountNo;
            public string BankAccountNo
            {
                get { return mBankAccountNo; }
                set { mBankAccountNo = value; }
            }

            private string mCustomer_VendorBank;
            public string Customer_VendorBank
            {
                get { return mCustomer_VendorBank; }
                set { mCustomer_VendorBank = value; }
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

            private Int32 mWHTEntryNo;
            public Int32 WHTEntryNo
            {
                get { return mWHTEntryNo; }
                set { mWHTEntryNo = value; }
            }

            private string mWHTReportLineNo;
            public string WHTReportLineNo
            {
                get { return mWHTReportLineNo; }
                set { mWHTReportLineNo = value; }
            }

            private int mSkipWHT;
            public int SkipWHT
            {
                get { return mSkipWHT; }
                set { mSkipWHT = value; }
            }

            private int mCertificatePrinted;
            public int CertificatePrinted
            {
                get { return mCertificatePrinted; }
                set { mCertificatePrinted = value; }
            }

            private int mWHTPayment;
            public int WHTPayment
            {
                get { return mWHTPayment; }
                set { mWHTPayment = value; }
            }

            private string mActualVendorNo;
            public string ActualVendorNo
            {
                get { return mActualVendorNo; }
                set { mActualVendorNo = value; }
            }

            private int mIsWHT;
            public int IsWHT
            {
                get { return mIsWHT; }
                set { mIsWHT = value; }
            }

            private double mVATBase_ACY;
            public double VATBase_ACY
            {
                get { return mVATBase_ACY; }
                set { mVATBase_ACY = value; }
            }

            private double mVATAmount_ACY;
            public double VATAmount_ACY
            {
                get { return mVATAmount_ACY; }
                set { mVATAmount_ACY = value; }
            }

            private double mAmountIncludingVAT_ACY;
            public double AmountIncludingVAT_ACY
            {
                get { return mAmountIncludingVAT_ACY; }
                set { mAmountIncludingVAT_ACY = value; }
            }

            private double mAmount_ACY;
            public double Amount_ACY
            {
                get { return mAmount_ACY; }
                set { mAmount_ACY = value; }
            }

            private double mVATDifference_ACY;
            public double VATDifference_ACY
            {
                get { return mVATDifference_ACY; }
                set { mVATDifference_ACY = value; }
            }

            private double mVendorExchangeRate_ACY;
            public double VendorExchangeRate_ACY
            {
                get { return mVendorExchangeRate_ACY; }
                set { mVendorExchangeRate_ACY = value; }
            }

            private int mPostDatedCheck;
            public int PostDatedCheck
            {
                get { return mPostDatedCheck; }
                set { mPostDatedCheck = value; }
            }

            private string mCheckNo;
            public string CheckNo
            {
                get { return mCheckNo; }
                set { mCheckNo = value; }
            }

            private double mInterestAmount;
            public double InterestAmount
            {
                get { return mInterestAmount; }
                set { mInterestAmount = value; }
            }

            private double mInterestAmount_LCY;
            public double InterestAmount_LCY
            {
                get { return mInterestAmount_LCY; }
                set { mInterestAmount_LCY = value; }
            }


        }
    }
}