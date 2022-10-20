using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.AccountingInterface.Quickbooks_Interface;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class Quickbooks_IntegrationSetup : Form
    {
        public Quickbooks_IntegrationSetup()
        {
            InitializeComponent();
            fillGrid();
        }

        #region listeners

        private void tsbAddAccount_Click(object sender, EventArgs e)
        {
            QuickBooks_AddGLAccount _add = new QuickBooks_AddGLAccount();
            _add.ShowDialog(this);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbAddMapping_Click(object sender, EventArgs e)
        {
            Quickbooks_AddMapping _add = new Quickbooks_AddMapping();
            _add.ShowDialog(this);
        }

        private void tsbRefreshMapping_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbDeleteMapping_Click(object sender, EventArgs e)
        {

        }

        #endregion listeners

        private void fillGrid()
        {
            QuickBooks_GLAccount _glAccount = new QuickBooks_GLAccount();
            gridGLAccounts.Rows.Count = 1;
            try
            {
                DataTable _dataTable = _glAccount.getGLAccounts();
                foreach (DataRow _row in _dataTable.Rows)
                {
                    gridGLAccounts.Rows.Count++;
                    gridGLAccounts.SetData(gridGLAccounts.Rows.Count - 1, gridGLAccounts.Cols["name"].Index, _row["name"]);
                    gridGLAccounts.SetData(gridGLAccounts.Rows.Count - 1, gridGLAccounts.Cols["type"].Index, _row["type"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while displaying GL accounts. Exception: " + ex.Message, "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillAccountMapping()
        {
            QuickBooks_Mapping _mapping = new QuickBooks_Mapping();
            gridMapping.Rows.Count = 1;
            try
            {
                DataTable _dataTable = _mapping.getMappingList();
                foreach (DataRow _row in _dataTable.Rows)
                {
                    gridMapping.Rows.Count++;
                    gridMapping.SetData(gridMapping.Rows.Count - 1, gridMapping.Cols["glAccount"].Index, _row["glAccount"]);
                    gridMapping.SetData(gridMapping.Rows.Count - 1, gridMapping.Cols["transactionCode"].Index, _row["transactionCode"]);
                    gridMapping.SetData(gridMapping.Rows.Count - 1, gridMapping.Cols["type"].Index, _row["mappingType"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while displaying GL accounts. Exception: " + ex.Message, "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Quickbooks_IntegrationSetup_Activated(object sender, EventArgs e)
        {
            fillGrid();
            fillAccountMapping();
        }
    }
}