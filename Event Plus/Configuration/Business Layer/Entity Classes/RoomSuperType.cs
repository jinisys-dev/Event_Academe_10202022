using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.ConfigurationHotel
{
    public class RoomSuperTypes : DataSet
    {
        /* FP-SCR-00139 #2 [07.21.2010]
         * added for creating a room super type */

        public RoomSuperTypes()
        { }

        private string mRoomSuperType;
        public string RoomSuperType
        {
            get { return mRoomSuperType; }
            set { mRoomSuperType = value; }
        }

        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = GlobalFunctions.removeQuotes(value); }
        }

        private string mStateFlag;
        public string StateFlag
        {
            get { return mStateFlag; }
            set { mStateFlag = value; }
        }

        private int mgHotelId;
        public int HotelID
        {
            get
            {
                return mgHotelId;
            }
            set
            {
                mgHotelId = value;
            }
        }

        private DateTime mCreateTime;
        public DateTime CreateTime
        {
            get
            {
                return mCreateTime;
            }
            set
            {
                mCreateTime = value;
            }
        }

        private string mCreatedBy;
        public string CreatedBy
        {
            get
            {
                return mCreatedBy;
            }
            set
            {
                mCreatedBy = value;
            }
        }

        private DateTime mUpdateTime;
        public DateTime UpdateTime
        {
            get
            {
                return mUpdateTime;
            }
            set
            {
                mUpdateTime = value;
            }
        }

        private string mUpdatedBy;
        public string UpdatedBy
        {
            get
            {
                return mUpdatedBy;
            }
            set
            {
                mUpdatedBy = value;
            }
        }
    }
}
