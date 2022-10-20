using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class PackageHeader : DataSet
    {


        public PackageHeader()
        {
        }
        private string mPackageID;
        public string PackageID
        {
            get
            {
                return this.mPackageID;
            }
            set
            {
                this.mPackageID = value;
            }
        }
        private string mDescription;
        public string Description
        {
            get
            {
                return this.mDescription;
            }
            set
            {
                this.mDescription = value;
            }
        }
        private DateTime mFromDate;
        public DateTime FromDate
        {
            get
            {
                return this.mFromDate;
            }
            set
            {
                this.mFromDate = value;
            }
        }
        private DateTime mToDate;
        public DateTime ToDate
        {
            get
            {
                return this.mToDate;
            }
            set
            {
                this.mToDate = value;
            }
        }
        private string mDaysApplied;
        public string DaysApplied
        {
            get
            {
                return this.mDaysApplied;
            }
            set
            {
                this.mDaysApplied = value;
            }
        }
        private IList<PackageDetail> mPackageDetailCollection;
		public IList<PackageDetail> PackageDetails
        {
            get
            {
                return mPackageDetailCollection;
            }
            set
            {
                mPackageDetailCollection = value;
            }
        }
    }

}
