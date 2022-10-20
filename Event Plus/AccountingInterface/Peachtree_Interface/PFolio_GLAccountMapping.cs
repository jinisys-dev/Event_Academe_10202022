using System;
using System.Collections;

using System.Data;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PFolio_GLAccountMapping
    {
        #region getters and setters

        private string mAccountID;
        public string ACCOUNTID
        {
            get { return mAccountID; }
            set { mAccountID = value; }
        }

        private string mDescription;
        public string DESCRIPTION
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        private string mType;
        public string TYPE
        {
            get { return mType; }
            set { mType = value; }
        }

        private string mStatus;
        public string STATUS
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        #endregion getters and setters

        #region methods

        public void insertGLAccount(PFolio_GLAccountMapping poGLAccount)
        {
            PFolio_GLAccountMappingDAO _dao = new PFolio_GLAccountMappingDAO();
            try
            {
                _dao.insertGLAccount(poGLAccount);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error Location"))
                {
                    throw ex;
                }
                else
                {
                    throw new Exception(ex.Message + " Error Location: " + this.ToString());
                }
            }
        }

        public void deleteGLAccount(string pAccountID)
        {
            PFolio_GLAccountMappingDAO _dao = new PFolio_GLAccountMappingDAO();
            try
            {
                _dao.deleteGLAccount(pAccountID);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error Location"))
                {
                    throw ex;
                }
                else
                {
                    throw new Exception(ex.Message + " Error Location: " + this.ToString());
                }
            }
        }

        public DataTable getGLAccounts()
        {
            PFolio_GLAccountMappingDAO _dao = new PFolio_GLAccountMappingDAO();
            try
            {
                DataTable _dataTable = _dao.getGLAccounts();
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
                    throw new Exception(ex.Message + " Error Location: " + this.ToString());
                }
            }
        }

        public DataTable getTransactionCodes()
        {
            PFolio_GLAccountMappingDAO _dao = new PFolio_GLAccountMappingDAO();
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
                    throw new Exception(ex.Message + " Error Location: " + this.ToString());
                }
            }
        }

        public void insertAccountMapping(string pAccountID, string pTransactionCode, string pMappingType)
        {
            PFolio_GLAccountMappingDAO _dao = new PFolio_GLAccountMappingDAO();
            try
            {
                _dao.insertAccountMapping(pAccountID, pTransactionCode, pMappingType);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error Location"))
                {
                    throw ex;
                }
                else
                {
                    throw new Exception(ex.Message + " Error Location: " + this.ToString());
                }
            }
        }

        public DataTable getAccountMapping()
        {
            PFolio_GLAccountMappingDAO _dao = new PFolio_GLAccountMappingDAO();
            try
            {
                DataTable _dataTable = _dao.getAccountMapping();
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
                    throw new Exception(ex.Message + " Error Location: " + this.ToString());
                }
            }
        }

        public void deleteMapping(string pTransactionCode, string pGLAccount)
        {
            PFolio_GLAccountMappingDAO _dao = new PFolio_GLAccountMappingDAO();
            try
            {
                _dao.deleteMapping(pTransactionCode, pGLAccount);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error Location"))
                {
                    throw ex;
                }
                else
                {
                    throw new Exception(ex.Message + " Error Location: " + this.ToString());
                }
            }
        }


        #endregion methods
    }
}
