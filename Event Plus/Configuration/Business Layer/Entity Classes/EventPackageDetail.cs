using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class EventPackageDetail
    {
        private int mPackageID;
        public int PackageID
        {
            get { return mPackageID; }
            set { mPackageID = value; }
        }

        private int mTransactionCode;
        public int TransactionCode
        {
            get { return mTransactionCode; }
            set { mTransactionCode = value; }
        }

        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = GlobalFunctions.removeQuotes(value); }
        }

        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }

        private string mRequirementHeader;
        public string RequirementHeader
        {
            get { return mRequirementHeader; }
            set { mRequirementHeader = value; }
        }

        private string mRequirementDetail;
        public string RequirementDetail
        {
            get { return mRequirementDetail; }
            set { mRequirementDetail = value; }
        }

        private string mSubAccount;
        public string SubAccount
        {
            get { return mSubAccount; }
            set { mSubAccount = value; }
        }
    }
}
