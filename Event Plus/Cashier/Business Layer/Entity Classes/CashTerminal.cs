
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;


namespace Jinisys.Hotel.Cashier.BusinessLayer
{
    public class CashTerminal : DataSet
    {
        

        private int mTerminalId;
        public int TerminalId
        {
            get
            {
                return mTerminalId;
            }
            set
            {
                mTerminalId = value;
            }
        }

        private string mTerminal;
        public string Terminal
        {
            get
            {
                return mTerminal;
            }
            set
            {
                mTerminal = value;
            }
        }


        private string mCashierId;
        public string CashierId
        {
            get
            {
                return mCashierId;
            }
            set
            {
                mCashierId = value;
            }
        }


        private string mShiftCode;
        public string ShiftCode
        {
            get
            {
                return mShiftCode;
            }
            set
            {
                mShiftCode = value;
            }
        }


        private double mOpeningBalance;
        public double OpeningBalance
        {
            get
            {
                return mOpeningBalance;
            }
            set
            {
                mOpeningBalance = value;
            }
        }


        private double mOpeningAdjustment;
        public double OpeningAdjustment
        {
            get
            {
                return mOpeningAdjustment;
            }
            set
            {
                mOpeningAdjustment = value;
            }
        }


        private double mBeginningBalance;
        public double BeginningBalance
        {
            get
            {
                return mBeginningBalance;
            }
            set
            {
                mBeginningBalance = value;
            }
        }


        private double mChargeInAmount;
        public double ChargeInAmount
        {
            get
            {
                return mChargeInAmount;
            }
            set
            {
                mChargeInAmount = value;
            }
        }


        private double mCash;
        public double Cash
        {
            get
            {
                return mCash;
            }
            set
            {
                mCash = value;
            }
        }


        private double mCreditCard;
        public double CreditCard
        {
            get
            {
                return mCreditCard;
            }
            set
            {
                mCreditCard = value;
            }
        }


        private double mCheque;
        public double Cheque
        {
            get
            {
                return mCheque;
            }
            set
            {
                mCheque = value;
            }
        }


        private double mOthers;
        public double Others
        {
            get
            {
                return mOthers;
            }
            set
            {
                mOthers = value;
            }
        }


        private double mAdjustment;
        public double Adjustment
        {
            get
            {
                return mAdjustment;
            }
            set
            {
                mAdjustment = value;
            }
        }


        private double mAmountRemitted;
        public double AmountRemitted
        {
            get
            {
                return mAmountRemitted;
            }
            set
            {
                mAmountRemitted = value;
            }
        }


        private double mNetAmount;
        public double NetAmount
        {
            get
            {
                return mNetAmount;
            }
            set
            {
                mNetAmount = value;
            }
        }


        private string mStatus;
        public string Status
        {
            get
            {
                return mStatus;
            }
            set
            {
                mStatus = value;
            }
        }


        private string mRemarks;
        public string Remarks
        {
            get
            {
                return mRemarks;
            }
            set
            {
                mRemarks = value;
            }
        }


        //===================================================
        // newly added entities
        //===================================================
        private int mgHotelId;
        public int HotelID
        {
            get
            {
                return mgHotelId;
            }
            set
            {
                mgHotelId = value;
            }
        }

        private DateTime mCreateTime;
        public DateTime CreateTime
        {
            get
            {
                return mCreateTime;
            }
            set
            {
                mCreateTime = value;
            }
        }

        private string mCreatedBy;
        public string CreatedBy
        {
            get
            {
                return mCreatedBy;
            }
            set
            {
                mCreatedBy = value;
            }
        }

        private DateTime mUpdateTime;
        public DateTime UpdateTime
        {
            get
            {
                return mUpdateTime;
            }
            set
            {
                mUpdateTime = value;
            }
        }

        private string mUpdatedBy;
        public string UpdatedBy
        {
            get
            {
                return mUpdatedBy;
            }
            set
            {
                mUpdatedBy = value;
            }
        }


    }
}