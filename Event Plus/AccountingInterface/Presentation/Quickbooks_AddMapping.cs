using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.AccountingInterface.Quickbooks_Interface;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class Quickbooks_AddMapping : Form
    {
        public Quickbooks_AddMapping()
        {
            InitializeComponent();
            loadComboBoxes();
        }

        private void loadComboBoxes()
        {
            QuickBooks_GLAccount _glAccount = new QuickBooks_GLAccount();
            cboGLAccount.DataSource = _glAccount.getGLAccounts();
            cboGLAccount.DisplayMember = "name";
            cboGLAccount.ValueMember = "name";

            cboTransactionCode.DataSource = getTransactionCodes();
            cboTransactionCode.DisplayMember = "tranCode";
            cboTransactionCode.ValueMember = "tranCode";
        }

        private QuickBooks_Mapping initializeMapping()
        {
            QuickBooks_Mapping _mapping = new QuickBooks_Mapping();
            _mapping.GLACCOUNT = this.cboGLAccount.SelectedValue.ToString();
            _mapping.TRANSACTIONCODE = this.cboTransactionCode.SelectedValue.ToString();
            _mapping.MAPPINGTYPE = this.cboMappingType.Text;
            return _mapping;
        }

        private DataTable getTransactionCodes()
        {
            QuickBooks_Mapping _mapping = new QuickBooks_Mapping();
            DataTable _dataTable = _mapping.getTransactionCodes();
            return _dataTable;
        }

        private void insertMapping()
        {
            QuickBooks_Mapping _mapping = new QuickBooks_Mapping();
            try
            {
                _mapping.insertMapping(initializeMapping(), GlobalVariables.gLoggedOnUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                insertMapping();
                MessageBox.Show("New mapping saved successfully.", "Mapping Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred when saving new mapping. Exception: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTransactionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] _row = getTransactionCodes().Select("tranCode = '" + cboTransactionCode.Text + "'");
                lblFolioTransaction.Text = _row[0]["memo"].ToString();
            }
            catch { }
        }
    }
}