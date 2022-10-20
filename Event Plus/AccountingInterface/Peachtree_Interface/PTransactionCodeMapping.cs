using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PTransactionCodeMapping
    {
        public DataTable getPeachtreeNewClients(DateTime pDate, string pOption)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _dataTable = dao.getPeachtreeNewClients(pDate, pOption);
                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable getDebitTemplateFields()
        {
            PTemplateDAO _PTemplateDAO = new PTemplateDAO();
            try
            {
                DataTable _dataTable = _PTemplateDAO.getTemplateFields(3);
                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFolioTransactions(DateTime pDate, bool includePosted)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _folioTransactions = dao.getFolioTransactions(pDate, includePosted);

                //>> Setup Table
                PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
                DataTable _transactionDataTable = new DataTable();

                //create first row (Column Header)
                PTemplate tTemplate = null;

                foreach (PTemplate oPTemplate in arrTemplates)
                {
                    if (oPTemplate.Generate)
                    {
                        if (oPTemplate.Name.ToLower().Contains("sales"))
                        {
                            tTemplate = oPTemplate;

                            foreach (PTemplateField oField in oPTemplate.Fields)
                            {
                                if (oField.StatusFlag == "ACTIVE")
                                {
                                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                                    _transactionDataTable.Columns.Add(col);
                                }
                            }
                        }
                    }
                }


                DataRow row = _transactionDataTable.NewRow();

                foreach (PTemplateField oField in tTemplate.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        row[oField.Name] = oField.Name;
                    }
                }
                _transactionDataTable.Rows.Add(row);
                _transactionDataTable.AcceptChanges();

                //add data to Peachtree
                foreach (DataRow _row in _folioTransactions.Rows)
                {
                    //set transaction to posted
                    postFolioTransaction(int.Parse(_row["folioTransactionNo"].ToString()));
                    //local tax
                    DataRow _tempLocalTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["accountID"].ToString() == "")
                                    {
                                        _tempLocalTaxRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempLocalTaxRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempLocalTaxRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempLocalTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempLocalTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempLocalTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempLocalTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempLocalTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempLocalTaxRow[_field.Name] = "LOCAL TAX";
                                    break;
                                case "G/L Account":
                                    _tempLocalTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempLocalTaxRow[_field.Name] = "-" + _row["localTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempLocalTaxRow[_field.Name] = "LOCALTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempLocalTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //local tax
                    DataRow _tempGovernmentTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["accountID"].ToString() == "")
                                    {
                                        _tempGovernmentTaxRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempGovernmentTaxRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempGovernmentTaxRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempGovernmentTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempGovernmentTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempGovernmentTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempGovernmentTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVERNMENT TAX";
                                    break;
                                case "G/L Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempGovernmentTaxRow[_field.Name] = "-" + _row["governmentTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempGovernmentTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //sales
                    DataRow _tempRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["accountID"].ToString() == "")
                                    {
                                        _tempRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempRow[_field.Name] = _row["memo"].ToString().Replace(',', ' ').Trim();
                                    break;
                                case "G/L Account":
                                    _tempRow[_field.Name] = _row["salesGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempRow[_field.Name] = "-" + _row["amount"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempRow);
                    _transactionDataTable.AcceptChanges();
                }

                return _transactionDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getCreditCardAndCityTransfers(DateTime pDate, bool includePosted)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _folioTransactions = dao.getCreditCardAndCityTransfers(pDate, includePosted);

                //>> Setup Table
                PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
                DataTable _transactionDataTable = new DataTable();

                //create first row (Column Header)
                PTemplate tTemplate = null;

                foreach (PTemplate oPTemplate in arrTemplates)
                {
                    if (oPTemplate.Generate)
                    {
                        if (oPTemplate.Name.ToLower().Contains("sales"))
                        {
                            tTemplate = oPTemplate;

                            foreach (PTemplateField oField in oPTemplate.Fields)
                            {
                                if (oField.StatusFlag == "ACTIVE")
                                {
                                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                                    _transactionDataTable.Columns.Add(col);
                                }
                            }
                        }
                    }
                }


                DataRow row = _transactionDataTable.NewRow();

                foreach (PTemplateField oField in tTemplate.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        row[oField.Name] = oField.Name;
                    }
                }
                _transactionDataTable.Rows.Add(row);
                _transactionDataTable.AcceptChanges();

                //add data to Peachtree
                foreach (DataRow _row in _folioTransactions.Rows)
                {
                    //set transaction to posted
                    postFolioTransaction(int.Parse(_row["folioTransactionNo"].ToString()));
                    //local tax
                    DataRow _tempLocalTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["creditCardType"].ToString() == "")
                                    {
                                        _tempLocalTaxRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempLocalTaxRow[_field.Name] = _row["creditCardType"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempLocalTaxRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempLocalTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempLocalTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempLocalTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempLocalTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempLocalTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempLocalTaxRow[_field.Name] = "LOCAL TAX";
                                    break;
                                case "G/L Account":
                                    _tempLocalTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempLocalTaxRow[_field.Name] = "-" + _row["localTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempLocalTaxRow[_field.Name] = "LOCALTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempLocalTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //local tax
                    DataRow _tempGovernmentTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["creditCardType"].ToString() == "")
                                    {
                                        _tempGovernmentTaxRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempGovernmentTaxRow[_field.Name] = _row["creditCardType"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempGovernmentTaxRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempGovernmentTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempGovernmentTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempGovernmentTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempGovernmentTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVERNMENT TAX";
                                    break;
                                case "G/L Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempGovernmentTaxRow[_field.Name] = "-" + _row["governmentTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempGovernmentTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //sales
                    DataRow _tempRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["creditCardType"].ToString() == "")
                                    {
                                        _tempRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempRow[_field.Name] = _row["creditCardType"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempRow[_field.Name] = _row["memo"].ToString().Replace(',', ' ').Trim();
                                    break;
                                case "G/L Account":
                                    _tempRow[_field.Name] = _row["salesGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempRow[_field.Name] = "-" + _row["amount"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempRow);
                    _transactionDataTable.AcceptChanges();
                }

                return _transactionDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getRestoTransactions(DateTime pDate, bool includePosted)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _folioTransactions = dao.getRestoTransactions(pDate, includePosted);

                //>> Setup Table
                PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
                DataTable _transactionDataTable = new DataTable();

                //create first row (Column Header)
                PTemplate tTemplate = null;

                foreach (PTemplate oPTemplate in arrTemplates)
                {
                    if (oPTemplate.Generate)
                    {
                        if (oPTemplate.Name.ToLower().Contains("sales"))
                        {
                            tTemplate = oPTemplate;

                            foreach (PTemplateField oField in oPTemplate.Fields)
                            {
                                if (oField.StatusFlag == "ACTIVE")
                                {
                                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                                    _transactionDataTable.Columns.Add(col);
                                }
                            }
                        }
                    }
                }


                DataRow row = _transactionDataTable.NewRow();

                foreach (PTemplateField oField in tTemplate.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        row[oField.Name] = oField.Name;
                    }
                }
                _transactionDataTable.Rows.Add(row);
                _transactionDataTable.AcceptChanges();

                //add data to Peachtree
                foreach (DataRow _row in _folioTransactions.Rows)
                {
                    //set transaction to posted
                    postFolioTransaction(int.Parse(_row["folioTransactionNo"].ToString()));
                    //local tax
                    DataRow _tempLocalTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["accountID"].ToString() == "")
                                    {
                                        _tempLocalTaxRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempLocalTaxRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempLocalTaxRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim() + "-" + _row["ID"].ToString();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempLocalTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempLocalTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempLocalTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempLocalTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempLocalTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    _tempLocalTaxRow[_field.Name] = _row["quantity"];
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    _tempLocalTaxRow[_field.Name] = _row["itemID"];
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempLocalTaxRow[_field.Name] = "LOCAL TAX";
                                    break;
                                case "G/L Account":
                                    _tempLocalTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempLocalTaxRow[_field.Name] = "-" + _row["localTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempLocalTaxRow[_field.Name] = "LOCALTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempLocalTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //local tax
                    DataRow _tempGovernmentTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["accountID"].ToString() == "")
                                    {
                                        _tempGovernmentTaxRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempGovernmentTaxRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempGovernmentTaxRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim() + "-" + _row["ID"].ToString();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempGovernmentTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempGovernmentTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempGovernmentTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempGovernmentTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    _tempGovernmentTaxRow[_field.Name] = _row["quantity"];
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    _tempGovernmentTaxRow[_field.Name] = _row["itemID"];
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVERNMENT TAX";
                                    break;
                                case "G/L Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempGovernmentTaxRow[_field.Name] = "-" + _row["governmentTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempGovernmentTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //sales
                    DataRow _tempRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    if (_row["accountID"].ToString() == "")
                                    {
                                        _tempRow[_field.Name] = _row["companyID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        _tempRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    }
                                    break;
                                case "Invoice/CM #":
                                    _tempRow[_field.Name] = _row["folioTransactionNo"].ToString().Trim() + "-" + _row["ID"].ToString();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["amount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    _tempRow[_field.Name] = _row["quantity"];
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    _tempRow[_field.Name] = _row["itemID"];
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempRow[_field.Name] = _row["memo"].ToString().Replace(',', ' ').Trim();
                                    break;
                                case "G/L Account":
                                    _tempRow[_field.Name] = _row["salesGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempRow[_field.Name] = "-" + _row["amount"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempRow);
                    _transactionDataTable.AcceptChanges();
                }

                return _transactionDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getFolioReceipts(DateTime pDate, bool includePosted)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _folioTransactions = dao.getFolioReceipts(pDate, includePosted);

                //>> Setup Table
                PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
                DataTable _transactionDataTable = new DataTable();

                //create first row (Column Header)
                PTemplate tTemplate = null;

                foreach (PTemplate oPTemplate in arrTemplates)
                {
                    if (oPTemplate.Generate)
                    {
                        if (oPTemplate.Name.ToLower().Contains("receipts"))
                        {
                            tTemplate = oPTemplate;

                            foreach (PTemplateField oField in oPTemplate.Fields)
                            {
                                if (oField.StatusFlag == "ACTIVE")
                                {
                                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                                    _transactionDataTable.Columns.Add(col);
                                }
                            }
                        }
                    }
                }


                DataRow row = _transactionDataTable.NewRow();

                foreach (PTemplateField oField in tTemplate.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        row[oField.Name] = oField.Name;
                    }
                }
                _transactionDataTable.Rows.Add(row);
                _transactionDataTable.AcceptChanges();

                //fill receipts datatable
                foreach (DataRow _row in _folioTransactions.Rows)
                {
                    //set transaction to posted
                    postFolioTransaction(int.Parse(_row["folioTransactionNo"].ToString()));
                    //local tax
                    DataRow _temp = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Deposit Ticket ID":
                                    _temp[_field.Name] = DateTime.Parse(_row["depositTicketID"].ToString()).ToString("MM/dd/yyyy");
                                    break;
                                case "Customer ID":
                                    if (_row["accountID"].ToString() != "")
                                    {
                                        _temp[_field.Name] = _row["accountID"];
                                    }
                                    else
                                    {
                                        _temp[_field.Name] = _row["companyID"];
                                    }
                                    break;
                                case "Reference":
                                    _temp[_field.Name] = _row["folioTransactionNo"];
                                    break;
                                case "Date":
                                    _temp[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy");
                                    break;
                                case "Payment Method":
                                    _temp[_field.Name] = _row["memo"];
                                    break;
                                case "Cash Account":
                                    _temp[_field.Name] = _row["cashAccount"];
                                    break;
                                case "Cash Amount":
                                    _temp[_field.Name] = _row["netAmount"];
                                    break;
                                case "Prepayment":
                                    _temp[_field.Name] = "TRUE";
                                    break;
                                case "Vendor Receipt":
                                    _temp[_field.Name] = "FALSE";
                                    break;
                                case "Number of Distributions":
                                    _temp[_field.Name] = "1";
                                    break;
                                case "Invoice Paid":
                                    break;
                                case "G/L Account":
                                    _temp[_field.Name] = _row["glAccount"];
                                    break;
                                case "Tax Type":
                                    _temp[_field.Name] = "1";
                                    break;
                                case "Amount":
                                    _temp[_field.Name] = "-" + _row["netAmount"];
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_temp);
                    _transactionDataTable.AcceptChanges();
                }

                return _transactionDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getNonGuestTransactions(DateTime pDate, bool includePosted)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _folioNonGuestTransactions = dao.getNonGuestTransactions(pDate, includePosted);

                //>> Setup Table
                PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
                DataTable _transactionDataTable = new DataTable();

                //create first row (Column Header)
                PTemplate tTemplate = null;

                foreach (PTemplate oPTemplate in arrTemplates)
                {
                    if (oPTemplate.Generate)
                    {
                        if (oPTemplate.Name.ToLower().Contains("sales"))
                        {
                            tTemplate = oPTemplate;

                            foreach (PTemplateField oField in oPTemplate.Fields)
                            {
                                if (oField.StatusFlag == "ACTIVE")
                                {
                                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                                    _transactionDataTable.Columns.Add(col);
                                }
                            }
                        }
                    }
                }


                DataRow row = _transactionDataTable.NewRow();

                foreach (PTemplateField oField in tTemplate.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        row[oField.Name] = oField.Name;
                    }
                }
                _transactionDataTable.Rows.Add(row);
                _transactionDataTable.AcceptChanges();
                
                 //add data to Peachtree
                foreach (DataRow _row in _folioNonGuestTransactions.Rows)
                {
                    //set transaction to posted
                    postNonGuestTransaction(int.Parse(_row["transactionId"].ToString()));
                    //local tax
                    DataRow _tempLocalTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    _tempLocalTaxRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    break;
                                case "Invoice/CM #":
                                    _tempLocalTaxRow[_field.Name] = _row["transactionId"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempLocalTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempLocalTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempLocalTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["netAmount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempLocalTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempLocalTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempLocalTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempLocalTaxRow[_field.Name] = "LOCAL TAX";
                                    break;
                                case "G/L Account":
                                    _tempLocalTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempLocalTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempLocalTaxRow[_field.Name] = "-" + _row["localTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempLocalTaxRow[_field.Name] = "LOCALTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempLocalTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //local tax
                    DataRow _tempGovernmentTaxRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    _tempGovernmentTaxRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    break;
                                case "Invoice/CM #":
                                    _tempGovernmentTaxRow[_field.Name] = _row["transactionId"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempGovernmentTaxRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempGovernmentTaxRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["netAmount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempGovernmentTaxRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempGovernmentTaxRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempGovernmentTaxRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVERNMENT TAX";
                                    break;
                                case "G/L Account":
                                    _tempGovernmentTaxRow[_field.Name] = _row["taxGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempGovernmentTaxRow[_field.Name] = "0";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempGovernmentTaxRow[_field.Name] = "-" + _row["governmentTax"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    _tempGovernmentTaxRow[_field.Name] = "GOVTAX";
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempGovernmentTaxRow);
                    _transactionDataTable.AcceptChanges();
                    //sales
                    DataRow _tempRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Customer ID":
                                    _tempRow[_field.Name] = _row["accountID"].ToString().Trim();
                                    break;
                                case "Invoice/CM #":
                                    _tempRow[_field.Name] = _row["transactionId"].ToString().Trim();
                                    break;
                                case "Apply to Invoice Number":
                                    break;
                                case "Credit Memo":
                                    break;
                                case "Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Ship By":
                                    break;
                                case "Quote":
                                    break;
                                case "Quote #":
                                    break;
                                case "Quote Good Thru Date":
                                    break;
                                case "Drop Ship":
                                    break;
                                case "Ship to Name":
                                    break;
                                case "Ship to Address-Line One":
                                    break;
                                case "Ship to Address-Line Two":
                                    break;
                                case "Ship to City":
                                    break;
                                case "Ship to State":
                                    break;
                                case "Ship to Zipcode":
                                    break;
                                case "Ship to Country":
                                    break;
                                case "Customer PO":
                                    break;
                                case "Ship Via":
                                    break;
                                case "Ship Date":
                                    break;
                                case "Date Due":
                                    break;
                                case "Discount Amount":
                                    _tempRow[_field.Name] = _row["discount"];
                                    break;
                                case "Discount Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy").Trim();
                                    break;
                                case "Displayed Terms":
                                    break;
                                case "Sales Representative ID":
                                    break;
                                case "Accounts Receivable Account":
                                    _tempRow[_field.Name] = _row["transactionCode"].ToString().Trim();
                                    break;
                                case "Accounts Receivable Amount":
                                    double _total = double.Parse(_row["netAmount"].ToString()) + double.Parse(_row["localTax"].ToString()) + double.Parse(_row["governmentTax"].ToString());
                                    _tempRow[_field.Name] = _total.ToString();
                                    break;
                                case "Sales Tax ID":
                                    _tempRow[_field.Name] = "PHIL";
                                    break;
                                case "Invoice Note":
                                    break;
                                case "Note Prints After Line Items":
                                    break;
                                case "Statement Note":
                                    break;
                                case "Stmt Note Prints Before Ref":
                                    break;
                                case "Internal Note":
                                    break;
                                case "Beginning Balance Transaction":
                                    break;
                                case "Number of Distributions":
                                    _tempRow[_field.Name] = "3";
                                    break;
                                case "Invoice/CM Distribution":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "Apply to Invoice Distribution":
                                    break;
                                case "Apply To Sales Order":
                                    break;
                                case "Quantity":
                                    break;
                                case "SO/Proposal Number":
                                    break;
                                case "Item ID":
                                    break;
                                case "SO/Proposal Distribution":
                                    break;
                                case "Description":
                                    _tempRow[_field.Name] = _row["memo"].ToString().Replace(',', ' ').Trim();
                                    break;
                                case "G/L Account":
                                    _tempRow[_field.Name] = _row["salesGLCode"].ToString().Trim();
                                    break;
                                case "Unit Price":
                                    break;
                                case "Tax Type":
                                    _tempRow[_field.Name] = "1";
                                    break;
                                case "UPC / SKU":
                                    break;
                                case "Weight":
                                    break;
                                case "Amount":
                                    _tempRow[_field.Name] = "-" + _row["netAmount"].ToString().Trim();
                                    break;
                                case "Job ID":
                                    break;
                                case "Sales Tax Agency ID":
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Return Authorization":
                                    break;
                                case "Voided by Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempRow);
                    _transactionDataTable.AcceptChanges();
                }

                return _transactionDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getNonGuestReceipts(DateTime pDate, bool includePosted)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _folioTransactions = dao.getNonGuestReceipts(pDate, includePosted);

                //>> Setup Table
                PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
                DataTable _transactionDataTable = new DataTable();

                //create first row (Column Header)
                PTemplate tTemplate = null;

                foreach (PTemplate oPTemplate in arrTemplates)
                {
                    if (oPTemplate.Generate)
                    {
                        if (oPTemplate.Name.ToLower().Contains("receipts"))
                        {
                            tTemplate = oPTemplate;

                            foreach (PTemplateField oField in oPTemplate.Fields)
                            {
                                if (oField.StatusFlag == "ACTIVE")
                                {
                                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                                    _transactionDataTable.Columns.Add(col);
                                }
                            }
                        }
                    }
                }


                DataRow row = _transactionDataTable.NewRow();

                foreach (PTemplateField oField in tTemplate.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        row[oField.Name] = oField.Name;
                    }
                }
                _transactionDataTable.Rows.Add(row);
                _transactionDataTable.AcceptChanges();

                //fill receipts datatable
                foreach (DataRow _row in _folioTransactions.Rows)
                {
                    //set transaction to posted
                    postNonGuestTransaction(int.Parse(_row["transactionId"].ToString()));
                    //local tax
                    DataRow _temp = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Deposit Ticket ID":
                                    _temp[_field.Name] = DateTime.Parse(_row["depositTicketID"].ToString()).ToString("MM/dd/yyyy");
                                    break;
                                case "Customer ID":
                                    _temp[_field.Name] = _row["accountID"];
                                    break;
                                case "Reference":
                                    _temp[_field.Name] = _row["transactionId"];
                                    break;
                                case "Date":
                                    _temp[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy");
                                    break;
                                case "Payment Method":
                                    _temp[_field.Name] = _row["memo"];
                                    break;
                                case "Cash Account":
                                    _temp[_field.Name] = _row["cashAccount"];
                                    break;
                                case "Cash Amount":
                                    _temp[_field.Name] = _row["netAmount"];
                                    break;
                                case "Prepayment":
                                    _temp[_field.Name] = "TRUE";
                                    break;
                                case "Vendor Receipt":
                                    _temp[_field.Name] = "FALSE";
                                    break;
                                case "Number of Distributions":
                                    _temp[_field.Name] = "1";
                                    break;
                                case "Invoice Paid":
                                    break;
                                case "G/L Account":
                                    _temp[_field.Name] = _row["glAccount"];
                                    break;
                                case "Tax Type":
                                    _temp[_field.Name] = "1";
                                    break;
                                case "Amount":
                                    _temp[_field.Name] = "-" + _row["netAmount"];
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_temp);
                    _transactionDataTable.AcceptChanges();
                }

                return _transactionDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getHotelTransactions(DateTime pDate, bool includePosted)
        {
            PTransactionCodeMappingDAO dao = new PTransactionCodeMappingDAO();
            try
            {
                DataTable _hotelTransactions = dao.getHotelTransactions(pDate, includePosted);

                //>> Setup Table
                PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
                DataTable _transactionDataTable = new DataTable();

                //create first row (Column Header)
                PTemplate tTemplate = null;

                foreach (PTemplate oPTemplate in arrTemplates)
                {
                    if (oPTemplate.Generate)
                    {
                        if (oPTemplate.Name.ToLower().Contains("general"))
                        {
                            tTemplate = oPTemplate;

                            foreach (PTemplateField oField in oPTemplate.Fields)
                            {
                                if (oField.StatusFlag == "ACTIVE")
                                {
                                    DataColumn col = new DataColumn(oField.Name, typeof(string));
                                    _transactionDataTable.Columns.Add(col);
                                }
                            }
                        }
                    }
                }

                DataRow row = _transactionDataTable.NewRow();

                foreach (PTemplateField oField in tTemplate.Fields)
                {
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        row[oField.Name] = oField.Name;
                    }
                }
                _transactionDataTable.Rows.Add(row);
                _transactionDataTable.AcceptChanges();
                //credit
                foreach (DataRow _row in _hotelTransactions.Rows)
                {
                    //set transaction to posted
                    postNonGuestTransaction(int.Parse(_row["transactionId"].ToString()));
                    DataRow _tempRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy");
                                    break;
                                case "Reference":
                                    _tempRow[_field.Name] = _row["transactionId"];
                                    break;
                                case "Date Clear in Bank Rec":
                                    break;
                                case "Number of Distributions":
                                    _tempRow[_field.Name] = "2";
                                    break;
                                case "G/L Account":
                                    _tempRow[_field.Name] = _row["creditCode"];
                                    break;
                                case "Description":
                                    _tempRow[_field.Name] = _row["memo"];
                                    break;
                                case "Amount":
                                    _tempRow[_field.Name] = _row["netAmount"];
                                    break;
                                case "Job ID":
                                    break;
                                case "Used for Reimbursable Expenses":
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Consolidated Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempRow);
                    _transactionDataTable.AcceptChanges();
                    //debit
                    _tempRow = _transactionDataTable.NewRow();
                    foreach (PTemplateField _field in tTemplate.Fields)
                    {
                        if (_field.StatusFlag == "ACTIVE")
                        {
                            switch (_field.Name)
                            {
                                case "Date":
                                    _tempRow[_field.Name] = DateTime.Parse(_row["transactionDate"].ToString()).ToString("MM/dd/yyyy");
                                    break;
                                case "Reference":
                                    _tempRow[_field.Name] = _row["transactionId"];
                                    break;
                                case "Date Clear in Bank Rec":
                                    break;
                                case "Number of Distributions":
                                    _tempRow[_field.Name] = "2";
                                    break;
                                case "G/L Account":
                                    _tempRow[_field.Name] = _row["debitCode"];
                                    break;
                                case "Description":
                                    _tempRow[_field.Name] = _row["memo"];
                                    break;
                                case "Amount":
                                    _tempRow[_field.Name] = "-" + _row["netAmount"];
                                    break;
                                case "Job ID":
                                    break;
                                case "Used for Reimbursable Expenses":
                                    break;
                                case "Transaction Period":
                                    break;
                                case "Transaction Number":
                                    break;
                                case "Consolidated Transaction":
                                    break;
                                case "Recur Number":
                                    break;
                                case "Recur Frequency":
                                    break;
                            }
                        }
                    }
                    _transactionDataTable.Rows.Add(_tempRow);
                    _transactionDataTable.AcceptChanges();
                }
                return _transactionDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        private void postFolioTransaction(int pFolioTransactionNo)
        {
            PTransactionCodeMappingDAO _dao = new PTransactionCodeMappingDAO();
            try
            {
                _dao.postFolioTransaction(pFolioTransactionNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void postNonGuestTransaction(int pTransactionID)
        {
            PTransactionCodeMappingDAO _dao = new PTransactionCodeMappingDAO();
            try
            {
                _dao.postNonGuestTransaction(pTransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
