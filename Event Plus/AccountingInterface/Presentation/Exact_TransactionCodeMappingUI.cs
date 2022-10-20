using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;
using Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class Exact_TransactionCodeMappingUI : Form
	{
		public Exact_TransactionCodeMappingUI()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void TransactionCodeMappingUI_ExactGlobe_Load(object sender, EventArgs e)
		{
			loadTransactionCodes();
		}

		private void loadTransactionCodes()
		{
			TransactionCodeFacade oTransactionCodeFacade = new TransactionCodeFacade();
			DataSet odsTranCodes = (DataSet)oTransactionCodeFacade.loadObject();

			DataTable tempTable = odsTranCodes.Tables[0];

			
			this.cboTransactionCode.DisplayMember = "tranCode";
			this.cboTransactionCode.ValueMember = "tranCode";
			this.cboTransactionCode.DataSource = tempTable;

			
			this.cboDescription.DisplayMember = "memo";
			this.cboDescription.ValueMember = "memo";
			this.cboDescription.DataSource = tempTable;

		}

		private void cboTransactionCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			//get journal entries
			string _TranCode = this.cboTransactionCode.SelectedValue.ToString();

			this.lvwJournalEntries.Items.Clear();

			TransactionCodeMappingDAO oTransactionCodeMappingDAO = new TransactionCodeMappingDAO(GlobalVariables.gPersistentConnection);
			DataTable tempTable = oTransactionCodeMappingDAO.getTransactionCodeMapping(GlobalVariables.gHotelId, _TranCode);

			
			foreach (DataRow row in tempTable.Rows)
			{
				ListViewItem item = new ListViewItem();
				item.Text = row["LineNo"].ToString();
				item.SubItems.Add(row["Exact_GLAccountID"].ToString());
				item.SubItems.Add(row["Description"].ToString());
				item.SubItems.Add(row["AmountColumnInFolioTrans"].ToString());
				item.SubItems.Add(row["CostCenterCode"].ToString());
				item.SubItems.Add(row["JournalEntryCode"].ToString());

				this.lvwJournalEntries.Items.Add(item);
			}

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string _TranCode = this.cboTransactionCode.SelectedValue.ToString();
			string _TranCodeDesciption = this.cboDescription.SelectedValue.ToString();

			int _nextLineNo = this.lvwJournalEntries.Items.Count + 1;
			Exact_NewEntryTransactionCodeMappingUI oNewEntry_TransactionCodeMapping_ExactGlobeUI = new Exact_NewEntryTransactionCodeMappingUI(_TranCode, _TranCodeDesciption, _nextLineNo);
			oNewEntry_TransactionCodeMapping_ExactGlobeUI.ShowDialog();


			cboTransactionCode_SelectedIndexChanged(sender, e);
		}

	}
}