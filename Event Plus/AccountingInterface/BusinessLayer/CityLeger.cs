using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.AccountingInterface.BusinessLayer
{
    public class CityLeger
    {
        public CityLeger()
        { 
        }

        private int mId;
        public int Id
        {
            get 
			{ 
				return this.mId; 
			}
            set 
			{ 
				mId = value; 
			}
        }

        private string mAcctID;
        public string AcctID
        {
            get 
			{ 
				return this.mAcctID; 
			}
            set 
			{
				this.mAcctID = value; 
			}
        }

        private string mDate;
        public string Date
        {
            get 
			{
				return this.mDate; 
			}
            set 
			{
				this.mDate = value; 
			}
        }

        private string mRefno;
        public string Refno
        {
            get 
			{
				return this.mRefno;
			}
            set 
			{
				this.mRefno = value;
			}
        }

        private double mDebit;
        public double Debit
        {
            get 
			{
				return this.mDebit; 
			}
            set 
			{
				this.mDebit = value; 
			}
        }

        private double mCredit;
        public double Credit
        {
            get 
			{
				return this.mCredit; 
			}
            set 
			{
				this.mCredit = value; 
			}
        }

        private string mRefFolio;
        public string RefFolio
        {
            get 
			{
				return this.mRefFolio; 
			}
            set 
			{
				this.mRefFolio = value; 
			}
        }

        private string mSubFolio;
        public string SubFolio
        {
            get 
			{
				return this.mSubFolio; 
			}
            set 
			{
				this.mSubFolio = value; 
			}
        }

        private int mHotelId;
        public int HotelId
        {
            get 
			{
				return this.mHotelId; 
			}
			set 
			{ 
				this.mHotelId = value;
			}
        }

        private string mCreatedBy;
        public string CreatedBy
        {
            get 
			{
				return this.mCreatedBy; 
			}
            set 
			{
				this.mCreatedBy = value; 
			}
        }

        private string mUpdatedBy;
        public string UpdatedBy
        {
            get 
			{
				return this.mUpdatedBy; 
			}
            set 
			{
				this.mUpdatedBy = value;
			}
        }

        private string mPosttoAcctng;
        public string PosttoAcctng
        {
            get 
			{
				return this.mPosttoAcctng; 
			}
            set 
			{
				this.mPosttoAcctng = value; 
			}
        }

        private string mClosed;
        public string Closed
        {
            get 
			{
				return this.mClosed; 
			}
            set 
			{
				this.mClosed = value; 
			}
        }


    }
}
