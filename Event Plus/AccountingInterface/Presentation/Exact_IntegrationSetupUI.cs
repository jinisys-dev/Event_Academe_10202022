using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class Exact_IntegrationSetupUI : Form
	{
		public Exact_IntegrationSetupUI()
		{
			InitializeComponent();
		}

		private void IntegrationSetupUI_ExactGlobe_Load(object sender, EventArgs e)
		{

		}

		private void btnTranCodeGLAccount_Click(object sender, EventArgs e)
		{
			Exact_TransactionCodeMappingUI oTransactionCodeMappingUI_ExactGlobe = new Exact_TransactionCodeMappingUI();
			oTransactionCodeMappingUI_ExactGlobe.ShowDialog();
		}

		private void btnCostCenters_Click(object sender, EventArgs e)
		{
			Exact_CostCenterUI oCostCenterUI_ExactGlobe = new Exact_CostCenterUI();
			oCostCenterUI_ExactGlobe.ShowDialog();
		}

		private void btnJournalEntryCodes_Click(object sender, EventArgs e)
		{
			Exact_JournalEntryCodesUI oJournalEntryCodesUI_ExactGlobe = new Exact_JournalEntryCodesUI();
			oJournalEntryCodesUI_ExactGlobe.ShowDialog();
		}

		private void btnGLAccounts_Click(object sender, EventArgs e)
		{
			Exact_GLchartOfAccounts oGLchartOfAccounts_ExactGlobe = new Exact_GLchartOfAccounts();
			oGLchartOfAccounts_ExactGlobe.ShowDialog();
		}
	}
}