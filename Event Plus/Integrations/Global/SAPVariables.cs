using System;
using System.Collections.Generic;
using System.Text;
using SAPbobsCOM;

namespace Integrations.Global
{
        public class SAPVariables
        {
           
            public enum INVOICETYPE
            {
                SERVICE,
                ITEM
            }

            public enum PAYMENTTYPE
            {
                CASH,
                CREDITCARD,
                CHECK
            }
        }
    
}
