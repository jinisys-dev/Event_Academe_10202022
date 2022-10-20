using System;
using System.Collections;

using System.Data;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.AccountingInterface.SAP_Interface
{
    public class Folio_GLAccountMapping
    {
        private string _TranCode;
        public string TranCode
        {
            set { this._TranCode = value; }
            get { return this._TranCode; }
        }

        private string _GLAccountID;
        public string GLAccountID
        {
            set { this._GLAccountID = value; }
            get { return this._GLAccountID; }
        }

        private int _LineNo;
        public int LineNo
        {
            set { this._LineNo = value; }
            get { return this._LineNo; }
        }

        private string _AmountColumnInFolioTrans;
        public string AmountColumnInFolioTrans
        {
            set { this._AmountColumnInFolioTrans = value; }
            get { return this._AmountColumnInFolioTrans; }
        }

        private string _CostCenterCode;
        public string CostCenterCode
        {
            set { this._CostCenterCode = value; }
            get { return this._CostCenterCode; }
        }


        private string _StatuFlag;
        public string StatuFlag
        {
            set { this._StatuFlag = value; }
            get { return this._StatuFlag; }
        }

        private string _CreatedBy;
        public string CreatedBy
        {
            set { this._CreatedBy = value; }
            get { return this._CreatedBy; }
        }


        private DateTime _CreatedDate;
        public DateTime CreatedDate
        {
            set { this._CreatedDate = value; }
            get { return this._CreatedDate; }
        }

        private string _UpdatedBy;
        public string UpdatedBy
        {
            set { this._UpdatedBy = value; }
            get { return this._UpdatedBy; }
        }

        private DateTime _UpdatedDate;
        public DateTime UpdatedDate
        {
            set { this._UpdatedDate = value; }
            get { return this._UpdatedDate; }
        }



        public static ArrayList getTransactionCodeMapping(string pTranCode, MySqlConnection connection)
        {
            DataTable temp = Folio_GLAccountMappingDAO.getTransactionCodeMapping(pTranCode, connection);

            ArrayList arrTranCodeMapping = new ArrayList();
            foreach (DataRow row in temp.Rows)
            {
                Folio_GLAccountMapping oMap = new Folio_GLAccountMapping();
                oMap.TranCode = row["TranCode"].ToString();
                oMap.GLAccountID = row["GLAccountID"].ToString();
                oMap.LineNo = int.Parse(row["LineNo"].ToString());
                oMap.AmountColumnInFolioTrans = row["AmountColumnInFolioTrans"].ToString();
                oMap.CostCenterCode = row["CostCenterCode"].ToString();
                oMap.StatuFlag = row["StatuFlag"].ToString();
                oMap.CreatedBy = row["CreatedBy"].ToString();
                oMap.CreatedDate = DateTime.Parse( row["CreatedDate"].ToString() );
                oMap.UpdatedBy = row["UpdatedBy"].ToString();
                oMap.UpdatedDate = DateTime.Parse( row["UpdatedDate"].ToString() );


                arrTranCodeMapping.Add(oMap);
            }


            return arrTranCodeMapping;
        }

        public static ArrayList getAllFolioGLaccountMapping(MySqlConnection connection)
        {
            DataTable temp = Folio_GLAccountMappingDAO.getFolioGLMapping(connection);

            ArrayList arrTranCodeMapping = new ArrayList();
            foreach (DataRow row in temp.Rows)
            {
                Folio_GLAccountMapping oMap = new Folio_GLAccountMapping();
                oMap.TranCode = row["TranCode"].ToString();
                oMap.GLAccountID = row["GLAccountID"].ToString();
                oMap.LineNo = int.Parse(row["LineNo"].ToString());
                oMap.AmountColumnInFolioTrans = row["AmountColumnInFolioTrans"].ToString();
                oMap.CostCenterCode = row["CostCenterCode"].ToString();
                oMap.StatuFlag = row["StatuFlag"].ToString();
                oMap.CreatedBy = row["CreatedBy"].ToString();
                oMap.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                oMap.UpdatedBy = row["UpdatedBy"].ToString();
                oMap.UpdatedDate = DateTime.Parse(row["UpdatedDate"].ToString());


                arrTranCodeMapping.Add(oMap);
            }


            return arrTranCodeMapping;
        }
    }
}
