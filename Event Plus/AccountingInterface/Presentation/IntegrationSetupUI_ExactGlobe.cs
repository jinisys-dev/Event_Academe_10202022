using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class IntegrationSetupUI_ExactGlobe : Form
	{
		public IntegrationSetupUI_ExactGlobe()
		{
			InitializeComponent();
		}

		private void IntegrationSetupUI_ExactGlobe_Load(object sender, EventArgs e)
		{

		}

		private void btnTranCodeGLAccount_Click(object sender, EventArgs e)
		{
			TransactionCodeMappingUI_ExactGlobe oTransactionCodeMappingUI_ExactGlobe = new TransactionCodeMappingUI_ExactGlobe();
			oTransactionCodeMappingUI_ExactGlobe.ShowDialog();
		}

		private void btnCostCenters_Click(object sender, EventArgs e)
		{
			CostCenterUI_ExactGlobe oCostCenterUI_ExactGlobe = new CostCenterUI_ExactGlobe();
			oCostCenterUI_ExactGlobe.ShowDialog();
		}

		private void btnJournalEntryCodes_Click(object sender, EventArgs e)
		{
			JournalEntryCodesUI_ExactGlobe oJournalEntryCodesUI_ExactGlobe = new JournalEntryCodesUI_ExactGlobe();
			oJournalEntryCodesUI_ExactGlobe.ShowDialog();
		}

		private void btnGLAccounts_Click(object sender, EventArgs e)
		{
			GLchartOfAccounts_ExactGlobe oGLchartOfAccounts_ExactGlobe = new GLchartOfAccounts_ExactGlobe();
			oGLchartOfAccounts_ExactGlobe.ShowDialog();
		}
	}
}