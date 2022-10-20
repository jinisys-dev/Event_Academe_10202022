using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
//added by Genny - Apr. 25, 2008
//for the Sales Module
namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace BusinessLayer
    {
        public class RequirementCode : DataSet
        {
            #region "Requirement Header"
            private string mRequirementCode;
            public string Requirement_Code
            {
                get { return mRequirementCode; }
                set { mRequirementCode = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = GlobalFunctions.removeQuotes(value); }
            }

            private string mTransactionCode;
            public string TransactionCode
            {
                get { return mTransactionCode; }
                set { mTransactionCode = value; }
            }
            #endregion
        }
    }
}
