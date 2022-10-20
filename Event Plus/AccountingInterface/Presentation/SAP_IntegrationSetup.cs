using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.AccountingInterface.SAP_Interface;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class SAP_IntegrationSetup : Form
    {
        public SAP_IntegrationSetup()
        {
            InitializeComponent();
        }

        private void SAP_IntegrationSetup_Load(object sender, EventArgs e)
        {

            loadGLAccounts();

            loadTemplates();

            loadGLAccountMapping();
        }

        private void loadTemplates()
        {

            Template[] arrTemplates = Template.getAllTemplates();

            this.tvwTemplates.Nodes.Clear();
            foreach (Template oTemplate in arrTemplates)
            {
                TreeNode nod = new TreeNode();
                nod.Text = oTemplate.Name;
                nod.Checked = true;
                nod.Tag = oTemplate.ID;

                foreach (TemplateField oField in oTemplate.Fields)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Text = oField.Name;
                    subNode.Tag = oField.ID;

                    nod.Nodes.Add(subNode);
                }
                this.tvwTemplates.Nodes.Add(nod);
            }
        }

        public void loadGLAccounts()
        {
            ArrayList arrGLAccount = GLaccount.getAllGLAccounts();

            this.lvwGLAccounts.Items.Clear();
            foreach (GLaccount oGLAccount in arrGLAccount)
            {
                ListViewItem item = new ListViewItem();
                item.Text = oGLAccount.pAccountID;
                item.SubItems.Add(oGLAccount.pDescription);
                item.SubItems.Add(oGLAccount.pCostCenterCode);
                item.SubItems.Add(oGLAccount.pAccountNature);

                this.lvwGLAccounts.Items.Add(item);
            }
        }

        private void loadGLAccountMapping()
        {
            ArrayList arrGLToFolioMapping = Folio_GLAccountMapping.getAllFolioGLaccountMapping(GlobalVariables.gPersistentConnection);

            this.lvwGLMapping.Items.Clear();
            foreach (Folio_GLAccountMapping oMapping in arrGLToFolioMapping)
            {
                ListViewItem item = new ListViewItem();
                item.Text = oMapping.TranCode;
                item.SubItems.Add(oMapping.GLAccountID);
                item.SubItems.Add(oMapping.LineNo.ToString());
                item.SubItems.Add(oMapping.AmountColumnInFolioTrans);
                item.SubItems.Add(oMapping.CostCenterCode);

                this.lvwGLMapping.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAP_GLAccounts sap_GLAccount = new SAP_GLAccounts();
            sap_GLAccount.MdiParent = this.MdiParent;
            sap_GLAccount.ShowDialog();
        }

        private void tsmAddNew_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabControl.TabPages[0])
            {
                
            }
        }

        private void lvwGLMapping_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            this.lvwGLMapping.StartEditing(txtInput, e.Item, e.SubItem);
            txtInput.Visible = true;
        }

        private void lvwGLAccounts_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            this.lvwGLAccounts.StartEditing(txtInput, e.Item, e.SubItem);
            txtInput.Visible = true;
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (this.tabControl.SelectedTab == tabControl.TabPages[0])
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GLaccountDAO _oGlDAO = new GLaccountDAO();
                    _oGlDAO.DeleteGLAccount(this.lvwGLAccounts.SelectedItems[0].Text);
                }
            }
            else if (this.tabControl.SelectedTab == tabControl.TabPages[1])
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Folio_GLAccountMappingDAO _oGLMapping = new Folio_GLAccountMappingDAO();
                    _oGLMapping.DeleteGLAccountMapping(this.lvwGLMapping.SelectedItems[0].Text, this.lvwGLMapping.SelectedItems[0].SubItems[1].Text);
                }
            }

            loadGLAccountMapping();
            loadGLAccounts();
            loadTemplates();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[2];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SAP_GLAccountMappingUI _oMappingUI = new SAP_GLAccountMappingUI();
            _oMappingUI.MdiParent = this.MdiParent;
            _oMappingUI.ShowDialog();
        }
    }
}