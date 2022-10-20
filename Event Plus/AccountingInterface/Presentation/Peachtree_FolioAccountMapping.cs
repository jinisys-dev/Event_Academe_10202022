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
    public partial class Peachtree_FolioAccountMapping : Form
    {
        public Peachtree_FolioAccountMapping()
        {
            InitializeComponent();
            loadComboBoxes();
        }

        private void loadComboBoxes()
        {
            try
            {
                cboTransactionCode.DataSource = getTransactionCodes();
                cboTransactionCode.DisplayMember = "tranCode";
                cboTransactionCode.ValueMember = "tranCode";

                cboAccountID.DataSource = getGLAccounts();
                cboAccountID.DisplayMember = "accountID";
                cboAccountID.ValueMember = "accountID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when retreiving transaction codes. Exception: " + ex.Message, "Fech Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable getTransactionCodes()
        {
            PFolio_GLAccountMapping _GLAccountMapping = new PFolio_GLAccountMapping();
            try
            {
                DataTable _dataTable = _GLAccountMapping.getTransactionCodes();
                return _dataTable;
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

        private DataTable getGLAccounts()
        {
            PFolio_GLAccountMapping _GLAccountMapping = new PFolio_GLAccountMapping();
            try
            {
                DataTable _dataTable = _GLAccountMapping.getGLAccounts();
                return _dataTable;
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

        private void insertAccountMapping()
        {
            PFolio_GLAccountMapping _GLAccountMapping = new PFolio_GLAccountMapping();
            try
            {
                _GLAccountMapping.insertAccountMapping(cboAccountID.Text, cboTransactionCode.Text, cboMappingType.Text);
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
            try
            {
                insertAccountMapping();
                MessageBox.Show("New account mapping saved successfully!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult _result = MessageBox.Show("Would you like to add more?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_result == DialogResult.Yes)
                {
                }
                else
                {
                    this.Close();
                    Peachtree_IntegrationSetup _GLAccountMapping = new Peachtree_IntegrationSetup();
                    _GLAccountMapping.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when saving new account mapping. Exception: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] _row = getGLAccounts().Select("accountID = '" + cboAccountID.Text + "'");
                lblPeachtree.Text = _row[0]["description"].ToString();
            }
            catch { }
        }

        private void cboTransactionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] _row = getTransactionCodes().Select("tranCode = '" + cboTransactionCode.Text + "'");
                lblFolio.Text = _row[0]["memo"].ToString();
            }
            catch { }
        }
    }
}