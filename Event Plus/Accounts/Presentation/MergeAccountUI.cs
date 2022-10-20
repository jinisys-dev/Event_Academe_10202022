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
	public partial class MergeAccountUI : Form
	{
		public MergeAccountUI()
		{
			InitializeComponent();
		}

		private void MergeAccountUI_Load(object sender, EventArgs e)
		{
			loadData();
		}


		private GuestFacade oGuestFacade;
		private Guest oGuest;
		private void loadData()
		{
			oGuestFacade = new GuestFacade();
			//oGuest = oGuestFacade.getGuestList();
			oGuest = oGuestFacade.getGuests();

			DataView dtView = oGuest.Tables[0].DefaultView;

			grdGuest.Rows = dtView.Count + 1;
			int i = 1;
			foreach (DataRowView dtRow in dtView)
			{
				this.grdGuest.set_TextMatrix(i, 1, dtRow["AccountId"].ToString());
				this.grdGuest.set_TextMatrix(i, 2, dtRow["LastName"].ToString());
				this.grdGuest.set_TextMatrix(i, 3,dtRow["FirstName"].ToString());
				this.grdGuest.set_TextMatrix(i, 4, dtRow["Citizenship"].ToString());
				this.grdGuest.set_TextMatrix(i ,5,dtRow["CREATETIME"].ToString());
				this.grdGuest.set_TextMatrix(i, 6, dtRow["CREATEDBY"].ToString());

				this.grdGuest.SetCellCheck(i, 0, C1.Win.C1FlexGrid.CheckEnum.Unchecked);				
				i++;
			}
		}

		private void grdGuest_Click(object sender, EventArgs e)
		{
			try
			{
				if (grdGuest.Col == 0)
					grdGuest.EditCell();
			}
			catch
			{ 
			}
		}

		private void grdGuest_DoubleClick(object sender, EventArgs e)
		{
			int row = 1;

			if (this.txtAccountId.Text == "")
			{
				try
				{
					row = this.grdGuest.Row;
				}
				catch
				{

				}

				this.txtAccountId.Text = this.grdGuest.get_TextMatrix(row, 1);
				this.txtFirstName.Text = this.grdGuest.get_TextMatrix(row, 2);
				this.txtLastName.Text = this.grdGuest.get_TextMatrix(row, 3);
				this.txtCitizenship.Text = this.grdGuest.get_TextMatrix(row, 4);

				this.grdGuest.RemoveItem(row);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			loadData();
			this.txtAccountId.Text = "";
			this.txtFirstName.Text = "";
			this.txtLastName.Text = "";
			this.txtCitizenship.Text = "";

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnMerge_Click(object sender, EventArgs e)
		{
			if(this.txtAccountId.Text.Trim().Length <= 0)
				return;

			DialogResult rsp = MessageBox.Show("Merge account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,  MessageBoxDefaultButton.Button2);
			if (rsp == DialogResult.Yes)
			{
				try
				{
					oGuestFacade = new GuestFacade();

					string newAccountId = this.txtAccountId.Text;

					for (int i = 1; i < this.grdGuest.Rows; i++)
					{

						C1.Win.C1FlexGrid.CheckEnum chk = this.grdGuest.GetCellCheck(i, 0);

						if (chk == C1.Win.C1FlexGrid.CheckEnum.Checked)
						{
							string oldAccountId = this.grdGuest.get_TextMatrix(i, 1);

							//MessageBox.Show(oldAccountId);
							oGuestFacade.mergeGuestAccount(newAccountId, oldAccountId);
						}
					}

					MessageBox.Show("Transaction successful.\r\nAccounts successfully merged.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message,"Error");
				}
			}
		}


	}
}
