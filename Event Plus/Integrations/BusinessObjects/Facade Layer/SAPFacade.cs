using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Integrations.BusinessObjects.Entity_Layer;

namespace Integrations.BusinessObjects.Facade_Layer
{
    public class SAPFacade
    {
        SAP loSAP; 
        
        public SAPFacade()
        {

        }
        
        public DataTable getGLAccountsMapping()
        {
            loSAP = new SAP();
            return loSAP.getGLAccountsMapping();            
        }
        public void saveTransactionMapping(C1.Win.C1FlexGrid.C1FlexGrid pGrid)
        {
            loSAP = new SAP();
            loSAP.deleteTransactionCodes();
            foreach (C1.Win.C1FlexGrid.Row _row in pGrid.Rows)
            {
                if (_row.Index == 0)
                {
                    continue;
                }
                loSAP.saveTransCodeWithGLAccounts(_row["TransactionCode"].ToString(),
                                                    _row["FolioTransactionFieldName"].ToString(),
                                                    _row["GLAccountCode"].ToString(),
                                                    "0");// _row["GLCostCenterAccount"].ToString());
                
                //_row[""]
            }
        }
    }
}
