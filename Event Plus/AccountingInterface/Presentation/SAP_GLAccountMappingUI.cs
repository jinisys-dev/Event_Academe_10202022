using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class SAP_GLAccountMappingUI : Form
    {
        public SAP_GLAccountMappingUI()
        {
            InitializeComponent();
            NewForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AccountingInterface.SAP_Interface.Folio_GLAccountMapping _oGLAccountMapping = new Jinisys.Hotel.AccountingInterface.SAP_Interface.Folio_GLAccountMapping();
            _oGLAccountMapping.AmountColumnInFolioTrans = this.txtColFolioTrans.Text;
            _oGLAccountMapping.CostCenterCode = this.txtCostCenterCode.Text;
            _oGLAccountMapping.CreatedBy = this.txtCreatedBy.Text;
            _oGLAccountMapping.CreatedDate = DateTime.Parse(this.txtCreatedDate.Text);
            _oGLAccountMapping.GLAccountID = this.txtGLAccountID.Text;
            _oGLAccountMapping.LineNo = int.Parse(this.txtLineNo.Text);
            _oGLAccountMapping.StatuFlag = this.txtStatusFlag.Text;
            _oGLAccountMapping.TranCode = this.txtTransactionCode.Text;
            _oGLAccountMapping.UpdatedBy = this.txtUpdatedBy.Text;
            _oGLAccountMapping.UpdatedDate = DateTime.Parse(this.txtUpdatedDate.Text);

            AccountingInterface.SAP_Interface.Folio_GLAccountMappingDAO _oGLAccountMappingDAO = new Jinisys.Hotel.AccountingInterface.SAP_Interface.Folio_GLAccountMappingDAO();
            _oGLAccountMappingDAO.saveFolioMapping(_oGLAccountMapping);

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