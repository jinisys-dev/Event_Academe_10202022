using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Integrations.DataAccesObjects;

namespace Integrations.BusinessObjects.Entity_Layer
{
    public class SAP
    {
        public SAP()
        {
        }
        SAPDAO loSAPDAO = new SAPDAO();
        public DataTable getGLAccountsMapping()
        {
            return loSAPDAO.getGLAccountsMapping();
        }
        public void deleteTransactionCodes()
        {
            loSAPDAO.deleteTransaction();
        }
        public void saveTransCodeWithGLAccounts(string pTransactionCode, string pTransactionName, string pGLAccountCode, string pGLCostCentreAccount)
        {
            loSAPDAO.saveTransCodeWithGLAccounts(pTransactionCode, pTransactionName, pGLAccountCode,pGLCostCentreAccount);
        }

    }
}
