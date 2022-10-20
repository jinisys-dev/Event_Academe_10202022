using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Jinisys.Hotel.NightAudit
{
	namespace BusinessLayer
	{
        public class Audit : DataSet
        {
            private string mgAuditDate;
            private int mShiftCode;
            private string mMeridian;
            private DateTime mSystemDate;
            private string mTriggeredBy;

            public string gAuditDate
            {
                get { return mgAuditDate; }
                set { mgAuditDate = value; }
            }
            public int ShiftCode
            {
                get { return mShiftCode; }
                set { mShiftCode = value; }
            }
            public string Meridian
            {
                get { return mMeridian; }
                set { mMeridian = value; }
            }
            public DateTime SystemDate
            {
                get { return mSystemDate; }
                set { mSystemDate = value; }
            }
            public string TriggeredBy
            {
                get { return mTriggeredBy; }
                set { mTriggeredBy = value; }
            }

        }
    }
}
