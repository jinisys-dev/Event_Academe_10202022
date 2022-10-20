using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.AccountingInterface.Peachtree_Interface;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class Peachtree_IntegrationSetup : Form
    {
        public Peachtree_IntegrationSetup()
        {
            InitializeComponent();
            refresh();
            
        }

        private void refresh()
        {
            writeGLAccountsToGrid();
            gridPeachtreeAccounts.AutoSizeCols();
            gridPeachtreeAccounts.AutoSizeRows();
            writeMappingToGrid();
            gridAccountMapping.AutoSizeCols();
            gridAccountMapping.AutoSizeRows();
            loadTemplates();
        }

        private void writeGLAccountsToGrid()
        {
            gridPeachtreeAccounts.Rows.Count = 1;
            try
            {
                if (gridPeachtreeAccounts.Rows.Count <= 1)
                {
                    foreach (DataRow _row in getGLAccounts().Rows)
                    {
                        gridPeachtreeAccounts.Rows.Count++;
                        gridPeachtreeAccounts.SetData(gridPeachtreeAccounts.Rows.Count - 1, gridPeachtreeAccounts.Cols["accountID"].Index, _row["accountID"]);
                        gridPeachtreeAccounts.SetData(gridPeachtreeAccounts.Rows.Count - 1, gridPeachtreeAccounts.Cols["description"].Index, _row["description"]);
                        gridPeachtreeAccounts.SetData(gridPeachtreeAccounts.Rows.Count - 1, gridPeachtreeAccounts.Cols["type"].Index, _row["type"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when fetching PeachTree GL Accounts. Exception: " + ex.Message, "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void writeMappingToGrid()
        {
            gridAccountMapping.Rows.Count = 1;
            try
            {
                if (gridAccountMapping.Rows.Count <= 1)
                {
                    foreach (DataRow _row in getAccountMapping().Rows)
                    {
                        gridAccountMapping.Rows.Count++;
                        gridAccountMapping.SetData(gridAccountMapping.Rows.Count - 1, gridAccountMapping.Cols["glAccount"].Index, _row["accountID"]);
                        gridAccountMapping.SetData(gridAccountMapping.Rows.Count - 1, gridAccountMapping.Cols["glDescription"].Index, _row["description"]);
                        gridAccountMapping.SetData(gridAccountMapping.Rows.Count - 1, gridAccountMapping.Cols["transactionCode"].Index, _row["transactionCode"]);
                        gridAccountMapping.SetData(gridAccountMapping.Rows.Count - 1, gridAccountMapping.Cols["folioDescription"].Index, _row["memo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when fetching account mapping. Exception: " + ex.Message, "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadTemplates()
        {
            PTemplate[] arrTemplates = PTemplate.getAllPTemplates();
            this.tvwTemplates.Nodes.Clear();
            foreach (PTemplate oTemplate in arrTemplates)
            {
                TreeNode nod = new TreeNode();
                nod.Text = oTemplate.Name;
                if (oTemplate.Generate)
                {
                    nod.Checked = true;
                }
                else
                {
                    nod.Checked = false;
                }
                
                nod.Tag = oTemplate.ID;

                foreach (PTemplateField oField in oTemplate.Fields)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Text = oField.Name;
                    subNode.Tag = oField.ID;
                    if (oField.StatusFlag == "ACTIVE")
                    {
                        subNode.Checked = true;
                    }
                    else
                    {
                        subNode.Checked = false;
                    }
                    nod.Nodes.Add(subNode);
                }
                this.tvwTemplates.Nodes.Add(nod);
            }
        }

        private DataTable getGLAccounts()
        {
            PFolio_GLAccountMapping _GLAccountMapping = new PFolio_GLAccountMapping();
            try
            {
                DataTable _glAccountsDataTable = _GLAccountMapping.getGLAccounts();
                return _glAccountsDataTable;
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

        private DataTable getAccountMapping()
        {
            PFolio_GLAccountMapping _GLAccountMapping = new PFolio_GLAccountMapping();
            try
            {
                DataTable _glMappingDataTable = _GLAccountMapping.getAccountMapping();
                return _glMappingDataTable;
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

        private void updateMapping()
        {
            PTemplate _oPTemplate = new PTemplate();
            foreach (TreeNode node in tvwTemplates.Nodes)
            {
                if (node.Checked)
                {
                    _oPTemplate.updateTemplates(int.Parse(node.Tag.ToString()), "ACTIVE");
                    foreach (TreeNode subNode in node.Nodes)
                    {
                        if (subNode.Checked)
                        {
                            _oPTemplate.updateFieldTemplates(int.Parse(subNode.Tag.ToString()), "ACTIVE");
                        }
                        else
                        {
                            _oPTemplate.updateFieldTemplates(int.Parse(subNode.Tag.ToString()), "INACTIVE");
                        }
                    }
                }
                else
                {
                    _oPTemplate.updateTemplates(int.Parse(node.Tag.ToString()), "INACTIVE");
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            Peachtree_GLAccounts _GLAccounts = new Peachtree_GLAccounts();
            _GLAccounts.ShowDialog(this);
            this.Close();
        }

        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            Peachtree_FolioAccountMapping _FolioAccountMapping = new Peachtree_FolioAccountMapping();
            _FolioAccountMapping.ShowDialog(this);
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult _result;
            PFolio_GLAccountMapping _GLAccountMapping = new PFolio_GLAccountMapping();
            string _glAccount = gridPeachtreeAccounts.GetDataDisplay(gridPeachtreeAccounts.Row, gridPeachtreeAccounts.Cols["accountID"].Index);
            _result = MessageBox.Show("Are you sure you want to delete " + _glAccount + "?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_result == DialogResult.Yes)
            {
                _GLAccountMapping.deleteGLAccount(_glAccount);
                MessageBox.Show("GL Account deleted!", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                writeGLAccountsToGrid();
            }
        }

        private void btnSaveTemplateSettings_Click(object sender, EventArgs e)
        {
            try
            {
                updateMapping();
                MessageBox.Show("Template settings successfully saved.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when saving template settings. Exception: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewTemplate_Click(object sender, EventArgs e)
        {
            Peachtree_Templates _Peachtree_Templates = new Peachtree_Templates();
            _Peachtree_Templates.ShowDialog(this);
            this.Close();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult _result;
            PFolio_GLAccountMapping _GLAccountMapping = new PFolio_GLAccountMapping();
            string _transactionCode = gridAccountMapping.GetDataDisplay(gridAccountMapping.Row, gridAccountMapping.Cols["transactionCode"].Index);
            string _glAccount = gridAccountMapping.GetDataDisplay(gridAccountMapping.Row, gridAccountMapping.Cols["glAccount"].Index);
            _result = MessageBox.Show("Are you sure you want to delete " + _glAccount + "?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_result == DialogResult.Yes)
            {
                _GLAccountMapping.deleteMapping(_transactionCode, _glAccount);
                MessageBox.Show("Account Mapping Deleted", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                writeMappingToGrid();
            }
        }
    }
}