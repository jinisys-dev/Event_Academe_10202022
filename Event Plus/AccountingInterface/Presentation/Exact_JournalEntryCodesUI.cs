using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class Exact_JournalEntryCodesUI : Form
	{

		ControlListener oControlListener = new ControlListener();
		string _operationMode = "EDIT";

		public Exact_JournalEntryCodesUI()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void JournalEntryCodesUI_ExactGlobe_Load(object sender, EventArgs e)
		{
			loadDataToListView();

			this.JournalEntryCodesUI_ExactGlobe_TextChanged(this, new EventArgs());
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				eJournalEntryCode oJournalEntryCode = new eJournalEntryCode();

				oJournalEntryCode.pJournalEntryCode = this.txtJournalEntryCode.Text;
				oJournalEntryCode.pDescription = this.txtDescription.Text;
				//oJournalEntryCode.pStatusFlag = this.txtStatusFlag.Text;
				oJournalEntryCode.pCreatedBy = this.txtCreatedBy.Text;
				//oJournalEntryCode.pCreatedDate = this.txtCreatedDate.Text;
				//oJournalEntryCode.pUpdatedBy = this.txtUpdatedBy.Text;
				//oJournalEntryCode.pUpdatedDate = this.txtUpdatedDate.Text;

				JournalEntryCodeDAO oJournalEntryCodeDAO = new JournalEntryCodeDAO(GlobalVariables.gPersistentConnection);
				if (_operationMode == "ADD")
				{
					oJournalEntryCodeDAO.SaveNewJournalEntryCode(oJournalEntryCode);

					MessageBox.Show("Transaction successful. (1) Cost Center added.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					oJournalEntryCodeDAO.UpdatJournalEntryCode(oJournalEntryCode);

					this.Text = this.Text.Replace("*", "");

					MessageBox.Show("Transaction successful. Cost Center updated.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				loadDataToListView();

				_operationMode = "EDIT";
				oControlListener.Listen(this);

				
				this.lvwJournalEntryCodes_SelectedIndexChanged(this, new EventArgs());
				btnCancel_Click(this, new EventArgs());

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed. Error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 
		}

		DataTable tblJournalEntryCodes;
		private void loadDataToListView()
		{
			JournalEntryCodeDAO oJournalEntryCodeDAO = new JournalEntryCodeDAO(GlobalVariables.gPersistentConnection);
			tblJournalEntryCodes = oJournalEntryCodeDAO.getAllJournalEntryCodes(GlobalVariables.gHotelId);

			this.lvwJournalEntryCodes.Items.Clear();
			for (int i = 0; i < tblJournalEntryCodes.Rows.Count; i++)
			{
				string _statusFlag = tblJournalEntryCodes.Rows[i]["StatusFlag"].ToString();

				ListViewItem item = new ListViewItem();
				item.Text = tblJournalEntryCodes.Rows[i]["JournalEntryCode"].ToString();
				item.SubItems.Add(tblJournalEntryCodes.Rows[i]["Description"].ToString());
				item.SubItems.Add(_statusFlag);
				item.SubItems.Add(tblJournalEntryCodes.Rows[i]["CreatedBy"].ToString());
				item.SubItems.Add(tblJournalEntryCodes.Rows[i]["CreatedDate"].ToString());
				item.SubItems.Add(tblJournalEntryCodes.Rows[i]["UpdatedBy"].ToString());
				item.SubItems.Add(tblJournalEntryCodes.Rows[i]["UpdatedDate"].ToString());

				
				if (_statusFlag == "DELETED")
				{
					item.BackColor = Color.Silver;
				}
				else
				{
					item.BackColor = Color.White;
				}

				this.lvwJournalEntryCodes.Items.Add(item);
			}

			if (this.lvwJournalEntryCodes.Items.Count > 0)
			{
				this.lvwJournalEntryCodes.Items[0].Selected = true;
			}

			oControlListener.Listen(this);

		}

		private void ClearForm()
		{
			oControlListener.StopListen(this);

			this.txtJournalEntryCode.Text = "";
			this.txtDescription.Text = "";
			this.txtStatusFlag.Text = "ACTIVE";
			this.txtCreatedDate.Text = DateTime.Now.ToLongDateString();
			this.txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
			this.txtUpdatedDate.Text = DateTime.Now.ToLongDateString();
			this.txtUpdatedBy.Text = GlobalVariables.gLoggedOnUser;
			this.txtJournalEntryCode.Focus();

			_operationMode = "ADD";
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			ClearForm();

			this.btnDelete.Enabled = false;
			this.btnNew.Enabled = false;
			this.btnClose.Enabled = false;

			this.btnSave.Enabled = true;
			this.btnCancel.Enabled = true;

		}

		private void JournalEntryCodesUI_ExactGlobe_TextChanged(object sender, EventArgs e)
		{
			if (this.Text.Contains("*"))
			{
				this.btnDelete.Enabled = false;
				this.btnNew.Enabled = false;
				this.btnClose.Enabled = false;

				this.btnSave.Enabled = true;
				this.btnCancel.Enabled = true;

			}
			else
			{
				this.btnDelete.Enabled = true;
				this.btnNew.Enabled = true;
				this.btnClose.Enabled = true;

				this.btnSave.Enabled = false;
				this.btnCancel.Enabled = false;
			}
		}

		private void lvwJournalEntryCodes_SelectedIndexChanged(object sender, EventArgs e)
		{
			oControlListener.StopListen(this);

			try
			{
				string _journalEntryCode = this.lvwJournalEntryCodes.SelectedItems[0].Text;


				foreach (DataRow row in tblJournalEntryCodes.Rows)
				{
					if (row["JournalEntryCode"].ToString() == _journalEntryCode)
					{
						this.txtJournalEntryCode.Text = _journalEntryCode;
						this.txtDescription.Text = row["Description"].ToString();
						this.txtStatusFlag.Text = row["StatusFlag"].ToString();
						this.txtCreatedDate.Text = row["CreatedDate"].ToString();
						this.txtCreatedBy.Text = row["CreatedBy"].ToString();
						this.txtUpdatedDate.Text = row["UpdatedDate"].ToString();
						this.txtUpdatedBy.Text = row["UpdatedBy"].ToString();

						break;
					}

				}
			}
			catch { }


			oControlListener.Listen(this);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{

			this.lvwJournalEntryCodes_SelectedIndexChanged(this, new EventArgs());
			this.Text = this.Text.Replace("*", "");



			this.btnDelete.Enabled = true;
			this.btnNew.Enabled = true;
			this.btnClose.Enabled = true;

			this.btnSave.Enabled = false;
			this.btnCancel.Enabled = false;
		}

		private void txtStatusFlag_TextChanged(object sender, EventArgs e)
		{
			if (this.txtStatusFlag.Text == "DELETED")
			{
				this.btnSetActive.Visible = true;
			}
			else
			{
				this.btnSetActive.Visible = false;
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult rsp = MessageBox.Show("Delete selected journal entry code?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (rsp == DialogResult.Yes)
			{
				eJournalEntryCode oJournalEntryCode = new eJournalEntryCode();

				oJournalEntryCode.pJournalEntryCode = this.txtJournalEntryCode.Text;
				oJournalEntryCode.pUpdatedBy = this.txtUpdatedBy.Text;

				JournalEntryCodeDAO oJournalEntryCodeDAO = new JournalEntryCodeDAO(GlobalVariables.gPersistentConnection);
				oJournalEntryCodeDAO.DeleteJournalEntryCode(oJournalEntryCode);

				loadDataToListView();
			}
		}

		private void btnSetActive_Click(object sender, EventArgs e)
		{
			this.txtStatusFlag.Text = "ACTIVE";
		} 

	}
}