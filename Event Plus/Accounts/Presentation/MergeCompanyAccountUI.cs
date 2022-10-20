using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Jinisys.Hotel.Accounts.BusinessLayer;

namespace Jinisys.Hotel.Accounts.Presentation
{
	public partial class MergeCompanyAccountUI : Form
	{
		public MergeCompanyAccountUI()
		{
			InitializeComponent();
		}

		private void grdGuest_Click(object sender, EventArgs e)
		{
			try
			{
				if (grdAccounts.Col == 0)
					grdAccounts.EditCell();
			}
			catch
			{
			}
		}

		private void grdGuest_DoubleClick(object sender, EventArgs e)
		{
			int row = 1;

			if (this.txtCompanyId.Text == "")
			{
				try
				{
					row = this.grdAccounts.Row;
				}
				catch
				{

				}

				this.txtCompanyId.Text = this.grdAccounts.get_TextMatrix(row, 1);
				this.txtCompanyName.Text = this.grdAccounts.get_TextMatrix(row, 2);
				this.txtCompanyCode.Text = this.grdAccounts.get_TextMatrix(row, 3);

				this.grdAccounts.RemoveItem(row);
			}
		}

		private void btnMerge_Click(object sender, EventArgs e)
		{
			if (this.txtCompanyId.Text.Trim().Length <= 0)
				return;

			DialogResult rsp = MessageBox.Show("Merge account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (rsp == DialogResult.Yes)
			{
				try
				{
					oCompanyFacade = new CompanyFacade();

					string newAccountId = this.txtCompanyId.Text;

					for (int i = 1; i < this.grdAccounts.Rows; i++)
					{

						C1.Win.C1FlexGrid.CheckEnum chk = this.grdAccounts.GetCellCheck(i, 0);

						if (chk == C1.Win.C1FlexGrid.CheckEnum.Checked)
						{
							string oldAccountId = this.grdAccounts.get_TextMatrix(i, 1);

							oCompanyFacade.mergeCompanyAccount(newAccountId, oldAccountId);
						}
					}

					MessageBox.Show("Transaction successful.\r\nAccounts successfully merged.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			loadData();
			this.txtCompanyId.Text = "";
			this.txtCompanyCode.Text = "";
			this.txtCompanyName.Text = "";
		}

		private CompanyFacade oCompanyFacade;
		private Company oCompany;
		private void loadData()
		{
			oCompanyFacade = new CompanyFacade();
			oCompany = oCompanyFacade.getCompanyAccountsData();

			DataView dtView = oCompany.Tables[0].DefaultView;

			grdAccounts.Rows = dtView.Count + 1;
			int i = 1;
			foreach (DataRowView dtRow in dtView)
			{
				this.grdAccounts.set_TextMatrix(i, 1, dtRow["companyid"].ToString());
				this.grdAccounts.set_TextMatrix(i, 2, dtRow["Companycode"].ToString());
				this.grdAccounts.set_TextMatrix(i, 3, dtRow["companyname"].ToString());
				this.grdAccounts.set_TextMatrix(i, 4, dtRow["CREATETIME"].ToString());
				this.grdAccounts.set_TextMatrix(i, 5, dtRow["CREATEDBY"].ToString());

				this.grdAccounts.SetCellCheck(i, 0, C1.Win.C1FlexGrid.CheckEnum.Unchecked);
				i++;
			}
		}

		private void MergeCompanyAccountUI_Load(object sender, EventArgs e)
		{
			loadData();
		}

	}
}