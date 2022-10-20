using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class Driver
	{
		public Driver()
		{
		}

		private string mDriverId;
		public string DriverId
		{
			set 
			{
				this.mDriverId = value;
			}
			get
			{
				return this.mDriverId;
			}
		}

		private string mLicenseNumber;
		public string LicenseNumber
		{
			set
			{
				this.mLicenseNumber = value;
			}
			get
			{
				return this.mLicenseNumber;
			}
		}

		private string mLastName;
		public string LastName
		{
			set
			{
				this.mLastName = value;
			}
			get
			{
				return this.mLastName;
			}
		}

		private string mFirstName;
		public string FirstName
		{
			set
			{
				this.mFirstName = value;
			}
			get
			{
				return this.mFirstName;
			}
		}

		private string mMiddleName;
		public string MiddleName
		{
			set
			{
				this.mMiddleName = value;
			}
			get
			{
				return this.mMiddleName;
			}
		}

		private double mTotalCommission;
		public double TotalCommission
		{
			set
			{
				this.mTotalCommission = value;
			}
			get
			{
				return this.mTotalCommission;
			}
		}

		private DateTime mCREATED_DATE;
		public DateTime CREATED_DATE
		{
			set
			{
				this.mCREATED_DATE = value;
			}
			get
			{
				return this.mCREATED_DATE;
			}
		}

		private string mCREATED_BY;
		public string CREATED_BY
		{
			set
			{
				this.mCREATED_BY = value;
			}
			get
			{
				return this.mCREATED_BY;
			}
		}

		private DateTime mUPDATED_DATE;
		public DateTime UPDATED_DATE
		{
			set
			{
				this.mUPDATED_DATE = value;
			}
			get
			{
				return this.mUPDATED_DATE;
			}
		}

		private string mUPDATED_BY;
		public string UPDATED_BY
		{
			set
			{
				this.mUPDATED_BY = value;
			}
			get
			{
				return this.mUPDATED_BY;
			}
		}

		private int mHOTEL_ID;
		public int HOTEL_ID
		{
			set
			{
				this.mHOTEL_ID = value;
			}
			get
			{
				return this.mHOTEL_ID;
			}
		}

        private string mCompany;

        public string Company
        {
            get { return mCompany; }
            set { mCompany = value; }
        }

        private string mBrand;
        public string Brand
        {
            get { return mBrand; }
            set { mBrand = value; }
        }

        private string mCarModel;
        public string Car_Model
        {
            get { return mCarModel; }
            set { mCarModel = value; }
        }

        private string mPlateNumber;
        public string Plate_Number
        {
            get { return mPlateNumber; }
            set { mPlateNumber = value; }
        }
	}
}
