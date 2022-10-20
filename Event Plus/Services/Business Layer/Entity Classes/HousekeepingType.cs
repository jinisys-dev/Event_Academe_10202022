using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Jinisys.Hotel.Services.BusinessLayer
{
    public class HousekeepingType  : DataSet
    {
        private string mId;
        public string Id
        {
            get { return mId; }
            set { mId = value;  }
        }
        private string mName;
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        private string mCode;
        public string Code
        {
            get { return mCode; }
            set { mCode = value; }
        }

          
    }
}
