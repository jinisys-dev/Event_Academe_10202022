using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.AccountingInterface.Peachtree_Interface;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class Peachtree_GLAccounts : Form
    {
        public Peachtree_GLAccounts()
        {
            InitializeComponent();
        }

        private PFolio_GLAccountMapping initializeGLAccount()
        {
            PFolio_GLAccountMapping _oGLAccount = new PFolio_GLAccountMapping();
            _oGLAccount.ACCOUNTID = GlobalFunctions.addSlashes(this.txtAccountID.Text);
            _oGLAccount.DESCRIPTION = GlobalFunctions.addSlashes(this.txtDescription.Text);
            _oGLAccount.TYPE = GlobalFunctions.addSlashes(this.cboType.Text);
            return _oGLAccount;
        }

        private void insertGLAccount()
        {
            PFolio_GLAccountMapping _oGLAccountMapping = new PFolio_GLAccountMapping();
            try
            {
                _oGLAccountMapping.insertGLAccount(initializeGLAccount());
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtAccountID.Text == "")
            {
                MessageBox.Show("Account ID must not be blank.", "Blank Account ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (this.cboType.Text == "")
            {
                MessageBox.Show("Account Type must not be blank.", "Blank Account Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    insertGLAccount();
                    MessageBox.Show("New GL Account saved successfully!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Peachtree_IntegrationSetup _GLAccountMapping = new Peachtree_IntegrationSetup();
                    _GLAccountMapping.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred when saving new GL Account. Exception: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}