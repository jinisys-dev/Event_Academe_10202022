using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Jinisys.FolioPlusCallLogger.BusinessLayer
{
    public class CallCharge : DataSet
    {


        private int mCallNo;
        public int CallNo
        {
            get
            {
                return mCallNo;
            }
            set
            {
                mCallNo = value;
            }
        }

        private int mTrunkNo;
        public int TrunkNo
        {
            get
            {
                return mTrunkNo;
            }
            set
            {
                mTrunkNo = value;
            }
        }

        private DateTime mCallDate;
        public DateTime CallDate
        {
            get
            {
                return mCallDate;
            }
            set
            {
                mCallDate = value;
            }
        }

        private DateTime mCallTime;
        public DateTime CallTime
        {
            get
            {
                return mCallTime;
            }
            set
            {
                mCallTime = value;
            }
        }

        private DateTime mDuration;
        public DateTime Duration
        {
            get
            {
                return mDuration;
            }
            set
            {
                mDuration = value;
            }
        }

        private decimal mCost;
        public decimal Cost
        {
            get
            {
                return mCost;
            }
            set
            {
                mCost = value;
            }
        }

        private bool mPostedToFolio;
        public bool PostedToFolio
        {
            get
            {
                return mPostedToFolio;
            }
            set
            {
                mPostedToFolio = value;
            }
        }

        //===================================================
        // newly added entities
        //===================================================
        private int mHotelId;
        public int HotelID
        {
            get
            {
                return mHotelId;
            }
            set
            {
                mHotelId = value;
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