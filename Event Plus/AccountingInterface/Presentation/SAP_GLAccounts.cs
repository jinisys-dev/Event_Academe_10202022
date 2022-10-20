using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.AccountingInterface.SAP_Interface;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class SAP_GLAccounts : Form
    {
        public SAP_GLAccounts()
        {
            InitializeComponent();
            NewForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GLaccount glAccount = new GLaccount();
            glAccount.pAccountID = txtAcctID.Text;
            glAccount.pAccountNature = txtAccountNature.Text;
            glAccount.pCostCenterCode = txtCostCenter.Text;
            glAccount.pCreatedBy = txtCreatedBy.Text;
            glAccount.pCreatedDate = DateTime.Parse(txtCreatedDate.Text);
            glAccount.pDescription = txtDescription.Text;
            glAccount.pStatusFlag = txtStatusFlag.Text;
            glAccount.pUpdatedBy = txtUpdatedBy.Text;
            glAccount.pUpdatedDate = DateTime.Parse(txtUpdatedDate.Text);

            GLaccountDAO _oGLDAO = new GLaccountDAO();
            _oGLDAO.SaveNewGLaccounts(glAccount);

            this.Close();

            SAP_IntegrationSetup _oSetupUI = new SAP_IntegrationSetup();
            _oSetupUI.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            SAP_IntegrationSetup _oSetupUI = new SAP_IntegrationSetup();
            _oSetupUI.ShowDialog();
        }

        private void NewForm()
        {
            this.txtStatusFlag.Text = "ACTIVE";
            this.txtCreatedDate.Text = DateTime.Now.ToLongDateString();
            this.txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
            this.txtUpdatedDate.Text = DateTime.Now.ToLongDateString();
            this.txtUpdatedBy.Text = GlobalVariables.gLoggedOnUser;
        }
    }
}