using System;
using System.Collections.Generic;
using System.Text;
using SAPbobsCOM;
using System.Data;

namespace Integration
{
    class SAPCompany
    {

        public SAPCompany()
        {

        }

        Company loCompany;
        private bool SAPConnect(string pSAPServer,string pSAPDB,string pSAPDBUser,string pSAPDBPass,string pSAPCompanyUser,string pSAPCompanyPass)
        {
            //if (txtSAPCompanyPass.Text == "" || txtSAPCompanyUser.Text == "" || txtSAPDB.Text == "" || txtSAPDBPass.Text == "" || txtSAPDBUser.Text == "" || txtSAPServer.Text == "")
            //{
            //    MessageBox.Show("Please check all fields. One or some of them are blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                int _errCode = 0;
                string _error = "";
                loCompany = new Company();
                loCompany.Server = pSAPServer;
                loCompany.DbServerType = BoDataServerTypes.dst_MSSQL2005;
                loCompany.CompanyDB = pSAPDB;
                loCompany.DbUserName = pSAPDBUser;
                loCompany.DbPassword = pSAPDBPass;
                loCompany.UserName = pSAPCompanyUser;
                loCompany.Password = pSAPCompanyPass;
                loCompany.language = BoSuppLangs.ln_English;
                loCompany.UseTrusted = false;
                //GlobalObjects.goCompany.LicenseServer = "192.168.100.48";

                try
                {
                    loCompany.Disconnect();
                }
                catch { }

                int _connected = loCompany.Connect();
                if (_connected != 0)
                {
                    loCompany.GetLastError(out _errCode, out _error);
                    throw new Exception(_error);
                }
                // getItemList();
                //populateGLAccountDataTable();

              //  MessageBox.Show("Connection to SAP server was successful.", "SAP Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;  
            }
            catch(Exception ex)
            {
                //MessageBox.Show("An error occured upon connecting to the SAP server:\n" + ex.Message, "SAP Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public void insertARInvoice(string pVendorCode,DateTime pTaxDate,DateTime pDocDuedate,string pComments,DataTable pLines)
        {
            SAPbobsCOM.Documents _oInvoice = (SAPbobsCOM.Documents)loCompany.GetBusinessObject(BoObjectTypes.oInvoices);

            _oInvoice.CardCode = pVendorCode;
            _oInvoice.DocDate = pTaxDate;
            _oInvoice.DocDueDate = pDocDuedate;
            _oInvoice.DocType = BoDocumentTypes.dDocument_Items;
            _oInvoice.HandWritten = BoYesNoEnum.tNO;
            _oInvoice.Comments = pComments;
            double _totalAmount = 0;
            try
            {
                foreach (DataRow _row in pLines.Rows)
                {
                    _oInvoice.Lines.ItemCode = _row["ItemCode"].ToString();
                    _oInvoice.Lines.Quantity = double.Parse(_row["Quantity"].ToString());
                    _oInvoice.Lines.VatGroup = _row["VatGroup"].ToString();
                    _oInvoice.Lines.UnitPrice = double.Parse(_row["UnitPrice"].ToString());
                    _oInvoice.Lines.PriceAfterVAT = double.Parse(_row["PriceAfterVAT"].ToString());
                    _oInvoice.Lines.DiscountPercent = double.Parse(_row["DiscountPercent"].ToString());
                    _oInvoice.Lines.WarehouseCode = _row["WarehouseCode"].ToString();
                    _totalAmount += double.Parse(_row["PriceAfterVAT"].ToString());
                    _oInvoice.Lines.Add();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            int _errCode = _oInvoice.Add();


            if (_errCode != 0)
            {
                int _code = 0;
                string _msg = "";

                loCompany.GetLastError(out _code, out _msg);

                //MessageBox.Show("Error : " + _code + " : " + _msg);
            }
            else
            {
                //lInvoiceNumber = loCompany.GetNewObjectKey();
                //lblStatus.Text = "Invoice Posted.";
            }
        }

        public DataTable getPayments()
        {
            DataTable _dt = new DataTable();

            


            return _dt;
        }



       
    }
}
