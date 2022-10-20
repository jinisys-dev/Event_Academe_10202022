using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class ContractAmendments
    {
        private int mID;
        public int ID
        {
            set { mID = value; }
            get { return mID; }
        }

        private string mAmendmentID;
        public string AmendmentID
        {
            get { return mAmendmentID; }
            set { mAmendmentID = value; }
        }

        private string mFolioID;
        public string FolioID
        {
            get { return mFolioID; }
            set { mFolioID = value; }
        }

        private string mOldValue;
        public string OldValue
        {
            get { return mOldValue; }
            set { mOldValue = GlobalFunctions.removeQuotes(value); }
        }

        private string mNewValue;
        public string NewValue
        {
            get { return mNewValue; }
            set { mNewValue = GlobalFunctions.removeQuotes(value); }
        }
    }
}
