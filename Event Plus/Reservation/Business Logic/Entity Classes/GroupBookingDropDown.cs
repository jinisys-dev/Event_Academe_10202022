using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class GroupBookingDropDown
    {
        public GroupBookingDropDown()
        { }


        private int mID;
        public int ID
        {
            set { this.mID = value; }
            get { return this.mID; }
        }

        private string mFieldName;
        public string FieldName
        {
            set { this.mFieldName = GlobalFunctions.removeQuotes(value); }
            get { return this.mFieldName; }
        }

        private string mValue;
        public string Value
        {
            set { this.mValue = GlobalFunctions.removeQuotes(value); }
            get { return this.mValue; }
        }

    }
}
