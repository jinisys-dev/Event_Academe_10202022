using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;
using Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class Exact_NewEntryTransactionCodeMappingUI : Form
	{
		public Exact_NewEntryTransactionCodeMappingUI(
			string pTransactionCode,
			string pTransactionDescription,
			int pNextLineNo
			)
		{
			InitializeComponent();


			this.txtTransactionCode.Text = pTransactionCode;
			this.txtTransactionDescription.Text = pTransactionDescription;
			this.nudLineNo.Value = pNextLineNo;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void NewEntry_TransactionCodeMapping_ExactGlobeUI_Load(object sender, EventArgs e)
		{
			loadComboBoxDataSource();
		}


		private void loadComboBoxDataSource()
		{

			GLaccountsDAO oGLaccountsDAO = new GLaccountsDAO(GlobalVariables.gPersistentConnection);
			DataTable tempTable = oGLaccountsDAO.getAllGLaccounts(GlobalVariables.gHotelId);

			this.cboGLAccountCode.DisplayMember = "AccountID";
			this.cboGLAccountCode.ValueMember = "AccountID";
			this.cboGLAccountCode.DataSource = tempTable;

			this.cboGLAccountDescription.DisplayMember = "Description";
			this.cboGLAccountDescription.ValueMember = "Description";
			this.cboGLAccountDescription.DataSource = tempTable;


			CostCenterDAO oCostCenterDAO = new CostCenterDAO(GlobalVariables.gPersistentConnection);
			DataTable tmpCostCenter = oCostCenterDAO.getAllCostCenters(GlobalVariables.gHotelId);

			this.cboCostCenterCode.DisplayMember = "CostCenterCode";
			this.cboCostCenterCode.ValueMember = "CostCenterCode";
			this.cboCostCenterCode.DataSource = tmpCostCenter;

			this.cboCostCenterDescription.DisplayMember = "Description";
			this.cboCostCenterDescription.ValueMember = "Description";
			this.cboCostCenterDescription.DataSource = tmpCostCenter;


			JournalEntryCodeDAO oJournalEntryCodeDAO = new JournalEntryCodeDAO(GlobalVariables.gPersistentConnection);
			DataTable tmpJournalEntryCodes = oJournalEntryCodeDAO.getAllJournalEntryCodes(GlobalVariables.gHotelId);

			this.cboJournalEntryCode.DisplayMember = "JournalEntryCode";
			this.cboJournalEntryCode.ValueMember = "JournalEntryCode";
			this.cboJournalEntryCode.DataSource = tmpJournalEntryCodes;

			this.cboJournalEntryCodeDescription.DisplayMember = "Description";
			this.cboJournalEntryCodeDescription.ValueMember = "Description";
			this.cboJournalEntryCodeDescription.DataSource = tmpJournalEntryCodes;

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (this.cboReferenceColumn.Text == "")
			{
				this.cboReferenceColumn.Focus();
				return;
			}

			try
			{
				eTransactionCodeMapping oTransactionCodeMapping = new eTransactionCodeMapping();

				oTransactionCodeMapping.pFolioPlus_TranCode = this.txtTransactionCode.Text;
				oTransactionCodeMapping.pExact_GLAccountID = this.cboGLAccountCode.SelectedValue.ToString();
				oTransactionCodeMapping.pAmountColumnInFolioTrans = this.cboReferenceColumn.Text;
				oTransactionCodeMapping.pCostCenterCode = this.cboCostCenterCode.SelectedValue.ToString();
				oTransactionCodeMapping.pJournalEntryCode = this.cboJournalEntryCode.SelectedValue.ToString();
				oTransactionCodeMapping.pLineNo = (int)this.nudLineNo.Value;

				TransactionCodeMappingDAO oTransactionCodeMappingDAO = new TransactionCodeMappingDAO(GlobalVariables.gPersistentConnection);
				oTransactionCodeMappingDAO.SaveNewTransactionCodeMapping(oTransactionCodeMapping);

				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}


		}


	}
}