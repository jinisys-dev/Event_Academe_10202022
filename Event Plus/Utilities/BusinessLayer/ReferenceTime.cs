using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.Utilities.BusinessLayer
{
    public class ReferenceTime
    {
        private string mRefTime;
        private int mMin;
        private int mMax;
        public string RefTime
        {
            get
            {
                return mRefTime;
            }
            set
            {
                mRefTime = value;
            }

        }
        public int Minimum
        {
            get
            {
                return mMin;
            }
            set
            {
                mMin = value;
            }
        }
        public int Maximum
        {
            get
            {
                return mMax;
            }
            set
            {
                mMax = value;
            }
        }
    }
}
