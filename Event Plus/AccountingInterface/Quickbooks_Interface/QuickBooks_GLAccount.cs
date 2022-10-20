using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Jinisys.Hotel.AccountingInterface.Quickbooks_Interface
{
    public class QuickBooks_GLAccount
    {
        #region getters and setters

        private string mName;
        public string NAME
        {
            get { return mName; }
            set { mName = value; }
        }

        private string mType;
        public string TYPE
        {
            get { return mType; }
            set { mType = value; }
        }

        #endregion getters and setters

        #region methods

        public void insertGLAccount(QuickBooks_GLAccount poGLAccount, string pUser)
        {
            QuickBooks_GLAccountDAO _dao = new QuickBooks_GLAccountDAO();
            try
            {
                _dao.insertGLAccount(poGLAccount, pUser);
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

        public DataTable getGLAccounts()
        {
            QuickBooks_GLAccountDAO _dao = new QuickBooks_GLAccountDAO();
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
                    throw new Exception(ex.Message + "\nError Location: " + this.ToString());
                }
            }
        }

        #endregion methods
    }
}
