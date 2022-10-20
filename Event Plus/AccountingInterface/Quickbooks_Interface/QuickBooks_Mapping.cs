using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Jinisys.Hotel.AccountingInterface.Quickbooks_Interface
{
    public class QuickBooks_Mapping
    {
        #region getters and setters

        private string mGLAccount;
        public string GLACCOUNT
        {
            get { return mGLAccount; }
            set { mGLAccount = value; }
        }

        private string mTransactionCode;
        public string TRANSACTIONCODE
        {
            get { return mTransactionCode; }
            set { mTransactionCode = value; }
        }

        private string mMappingType;
        public string MAPPINGTYPE
        {
            get { return mMappingType; }
            set { mMappingType = value; }
        }

        #endregion getters and setters

        #region methods

        public void insertMapping(QuickBooks_Mapping pMapping, string pUser)
        {
            QuickBooks_MappingDAO _dao = new QuickBooks_MappingDAO();
            try
            {
                _dao.insertMapping(pMapping, pUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error Location"))
                {
                    throw ex;
                }
                else
                {
                    throw new Exception(ex.Message + "\nError Location: " + this.ToString());
                }
            }
        }

        public DataTable getTransactionCodes()
        {
            QuickBooks_MappingDAO _dao = new QuickBooks_MappingDAO();
            try
            {
                DataTable _dataTable = _dao.getTransactionCodes();
                return _dataTable;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error Location"))
                {
                    throw ex;
                }
                else
                {
                    throw new Exception(ex.Message + "\nError Location: " + this.ToString());
                }
            }
        }

        public DataTable getMappingList()
        {
            QuickBooks_MappingDAO _dao = new QuickBooks_MappingDAO();
            try
            {
                DataTable _dataTable = _dao.getMapping();
                return _dataTable;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error Location"))
                {
                    throw ex;
                }
                else
                {
                    throw new Exception(ex.Message + "\nError Location: " + this.ToString());
                }
            }
        }

        #endregion methods
    }
}
