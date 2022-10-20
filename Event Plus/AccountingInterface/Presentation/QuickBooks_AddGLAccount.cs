using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.AccountingInterface.Quickbooks_Interface;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class QuickBooks_AddGLAccount : Form
    {
        public QuickBooks_AddGLAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cboType.Text == "")
            {
                MessageBox.Show("Please select a GL account type.", "Blank Account Type", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                insertGLAccount();
                MessageBox.Show("GL Account saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when inserting a new GL Account. Exception: " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private QuickBooks_GLAccount initializeGLAccount()
        {
            QuickBooks_GLAccount _glAccount = new QuickBooks_GLAccount();
            _glAccount.NAME = this.txtName.Text;
            _glAccount.TYPE = this.cboType.Text;
            return _glAccount;
        }

        private void insertGLAccount()
        {
            QuickBooks_GLAccount _glAccount = new QuickBooks_GLAccount();
            try
            {
                _glAccount.insertGLAccount(initializeGLAccount(), GlobalVariables.gLoggedOnUser);
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
    }
}