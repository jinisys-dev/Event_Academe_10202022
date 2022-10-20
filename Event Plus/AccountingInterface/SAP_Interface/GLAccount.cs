using System;
using System.Collections;
using System.Text;
using System.Data;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.SAP_Interface
{
    
    public class GLaccount
    {
        public GLaccount()
        {
        }
        private string _AccountID;
        public string pAccountID
        {
            set
            {
                this._AccountID = value;
            }
            get
            {
                return this._AccountID;
            }
        }
        private string _Description;
        public string pDescription
        {
            set
            {
                this._Description = value;
            }
            get
            {
                return this._Description;
            }
        }
        private string _CostCenterCode;
        public string pCostCenterCode
        {
            set
            {
                this._CostCenterCode = value;
            }
            get
            {
                return this._CostCenterCode;
            }
        }
        private string _AccountNature;
        public string pAccountNature
        {
            set
            {
                this._AccountNature = value;
            }
            get
            {
                return this._AccountNature;
            }
        }
        private string _StatusFlag;
        public string pStatusFlag
        {
            set
            {
                this._StatusFlag = value;
            }
            get
            {
                return this._StatusFlag;
            }
        }
        private DateTime _CreatedDate;
        public DateTime pCreatedDate
        {
            set
            {
                this._CreatedDate = value;
            }
            get
            {
                return this._CreatedDate;
            }
        }
        private string _CreatedBy;
        public string pCreatedBy
        {
            set
            {
                this._CreatedBy = value;
            }
            get
            {
                return this._CreatedBy;
            }
        }
        private DateTime _UpdatedDate;
        public DateTime pUpdatedDate
        {
            set
            {
                this._UpdatedDate = value;
            }
            get
            {
                return this._UpdatedDate;
            }
        }
        private string _UpdatedBy;
        public string pUpdatedBy
        {
            set
            {
                this._UpdatedBy = value;
            }
            get
            {
                return this._UpdatedBy;
            }
        }

        public static ArrayList getAllGLAccounts()
        { 
            int hotelId = GlobalVariables.gHotelId;

            DataTable dtGLAccount =  GLaccountDAO.getAllGLaccounts(hotelId, GlobalVariables.gPersistentConnection);

            ArrayList arrGLAccounts = new ArrayList();

            foreach (DataRow row in dtGLAccount.Rows)
            {
                GLaccount newGLAccount = new GLaccount();
                newGLAccount.pAccountID = row["AccountID"].ToString();
                newGLAccount.pDescription = row["Description"].ToString();
                newGLAccount.pCostCenterCode = row["CostCenterCode"].ToString();
                newGLAccount.pAccountNature = row["AccountNature"].ToString();
                newGLAccount.pStatusFlag = row["StatusFlag"].ToString();
                newGLAccount.pCreatedDate = DateTime.Parse( row["CreatedDate"].ToString() );
                newGLAccount.pCreatedBy = row["CreatedBy"].ToString();
                newGLAccount.pUpdatedDate = DateTime.Parse( row["UpdatedDate"].ToString() );
                newGLAccount.pUpdatedBy = row["UpdatedBy"].ToString();

                arrGLAccounts.Add(newGLAccount);

            }


            return arrGLAccounts;

        }
        
    }
}
