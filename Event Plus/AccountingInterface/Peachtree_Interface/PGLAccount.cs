using System;
using System.Collections;
using System.Text;
using System.Data;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    
    public class PGLaccount
    {
        public PGLaccount()
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

        public static ArrayList getAllPGLAccounts()
        { 
            int hotelId = GlobalVariables.gHotelId;

            DataTable dtPGLAccount =  PGLaccountDAO.getAllPGLaccounts(hotelId, GlobalVariables.gPersistentConnection);

            ArrayList arrPGLAccounts = new ArrayList();

            foreach (DataRow row in dtPGLAccount.Rows)
            {
                PGLaccount newPGLAccount = new PGLaccount();
                newPGLAccount.pAccountID = row["AccountID"].ToString();
                newPGLAccount.pDescription = row["Description"].ToString();
                newPGLAccount.pCostCenterCode = row["CostCenterCode"].ToString();
                newPGLAccount.pAccountNature = row["AccountNature"].ToString();
                newPGLAccount.pStatusFlag = row["StatusFlag"].ToString();
                newPGLAccount.pCreatedDate = DateTime.Parse( row["CreatedDate"].ToString() );
                newPGLAccount.pCreatedBy = row["CreatedBy"].ToString();
                newPGLAccount.pUpdatedDate = DateTime.Parse( row["UpdatedDate"].ToString() );
                newPGLAccount.pUpdatedBy = row["UpdatedBy"].ToString();

                arrPGLAccounts.Add(newPGLAccount);

            }


            return arrPGLAccounts;

        }
        
    }
}
