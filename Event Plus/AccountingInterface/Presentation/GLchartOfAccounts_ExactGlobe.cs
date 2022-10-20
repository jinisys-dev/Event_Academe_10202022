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
	public partial class GLchartOfAccounts_ExactGlobe : Form
	{

		ControlListener oControlListener = new ControlListener();
		string _operationMode = "EDIT";

		public GLchartOfAccounts_ExactGlobe()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void GLchartOfAccounts_ExactGlobe_Load(object sender, EventArgs e)
		{
			loadCostCenterCodes();
			loadDataToListView();
			

			this.GLchartOfAccounts_ExactGlobe_TextChanged(this, new EventArgs());
		}

		private void loadCostCenterCodes()
		{
			CostCenterDAO oCostCenterDAO = new CostCenterDAO(GlobalVariables.gPersistentConnection);

			DataTable tblCostCenter = oCostCenterDAO.getAllCostCenters(GlobalVariables.gHotelId);

			this.cboCostCenterCode.DisplayMember = "CostCenterCode";
			this.cboCostCenterCode.ValueMember = "CostCenterCode";
			this.cboCostCenterCode.DataSource = tblCostCenter;

		}

		DataTable tblGLAccounts;
		private void loadDataToListView()
		{
			GLaccountsDAO oGLaccountsDAO = new GLaccountsDAO(GlobalVariables.gPersistentConnection);
			tblGLAccounts = oGLaccountsDAO.getAllGLaccounts(GlobalVariables.gHotelId);

			this.lvwGLaccounts.Items.Clear();

			for (int i = 0; i < tblGLAccounts.Rows.Count; i++)
			{
				string _statusFlag = tblGLAccounts.Rows[i]["StatusFlag"].ToString();

				ListViewItem item = new ListViewItem();
				item.Text = tblGLAccounts.Rows[i]["AccountID"].ToString();
				item.SubItems.Add(tblGLAccounts.Rows[i]["Description"].ToString());
				item.SubItems.Add(tblGLAccounts.Rows[i]["CostCenterCode"].ToString());
				item.SubItems.Add(tblGLAccounts.Rows[i]["AccountNature"].ToString());
				item.SubItems.Add(_statusFlag);
				item.SubItems.Add(tblGLAccounts.Rows[i]["CreatedDate"].ToString());
				item.SubItems.Add(tblGLAccounts.Rows[i]["CreatedBy"].ToString());
				item.SubItems.Add(tblGLAccounts.Rows[i]["UpdatedDate"].ToString());
				item.SubItems.Add(tblGLAccounts.Rows[i]["UpdatedBy"].ToString());

				
				if (_statusFlag == "DELETED")
				{
					item.BackColor = Color.Silver;
				}
				else
				{
					item.BackColor = Color.White;
				}

				this.lvwGLaccounts.Items.Add(item);
			}

			if (this.lvwGLaccounts.Items.Count > 0)
			{
				this.lvwGLaccounts.Items[0].Selected = true;
			}

			oControlListener.Listen(this);

		}

		private void GLchartOfAccounts_ExactGlobe_TextChanged(object sender, EventArgs e)
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

		private void btnSetActive_Click(object sender, EventArgs e)
		{
			this.txtStatusFlag.Text = "ACTIVE";
		}

		private void lvwGLaccounts_SelectedIndexChanged(object sender, EventArgs e)
		{
			oControlListener.StopListen(this);

			try
			{
				string _accountID = this.lvwGLaccounts.SelectedItems[0].Text;


				foreach (DataRow row in tblGLAccounts.Rows)
				{
					if (row["AccountID"].ToString() == _accountID)
					{
						this.txtAccountID.Text = _accountID;
						this.txtDescription.Text = row["Description"].ToString();
						this.cboCostCenterCode.Text = row["CostCenterCode"].ToString();
						this.cboAccountNature.Text = row["AccountNature"].ToString();
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
			this.lvwGLaccounts_SelectedIndexChanged(this, new EventArgs());
			this.Text = this.Text.Replace("*", "");


			this.btnDelete.Enabled = true;
			this.btnNew.Enabled = true;
			this.btnClose.Enabled = true;

			this.btnSave.Enabled = false;
			this.btnCancel.Enabled = false;
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

		private void ClearForm()
		{
			oControlListener.StopListen(this);

			this.txtAccountID.Text = "";
			this.txtDescription.Text = "";
			this.txtStatusFlag.Text = "ACTIVE";
			this.txtCreatedDate.Text = DateTime.Now.ToLongDateString();
			this.txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
			this.txtUpdatedDate.Text = DateTime.Now.ToLongDateString();
			this.txtUpdatedBy.Text = GlobalVariables.gLoggedOnUser;

			this.txtAccountID.Focus();

			_operationMode = "ADD";
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				eGLaccounts oGLaccounts = new eGLaccounts();
				oGLaccounts.pAccountID = this.txtAccountID.Text;
				oGLaccounts.pDescription = this.txtDescription.Text;
				oGLaccounts.pCostCenterCode = this.cboCostCenterCode.Text;
				oGLaccounts.pAccountNature = this.cboAccountNature.Text;
				oGLaccounts.pStatusFlag = this.txtStatusFlag.Text;
				//oGLaccounts.pCreatedDate = this.txtCreatedDate.Text;
				oGLaccounts.pCreatedBy = GlobalVariables.gLoggedOnUser;
				//oGLaccounts.pUpdatedDate = this.txtUpdatedDate.Text;
				oGLaccounts.pUpdatedBy = GlobalVariables.gLoggedOnUser;

				GLaccountsDAO oGLaccountsDAO = new GLaccountsDAO(GlobalVariables.gPersistentConnection);
				if (_operationMode == "ADD")
				{
					oGLaccountsDAO.SaveNewGLaccounts(oGLaccounts);

					MessageBox.Show("Transaction successful. (1) Cost Center added.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					oGLaccountsDAO.UpdatGLaccounts(oGLaccounts);

					this.Text = this.Text.Replace("*", "");

					MessageBox.Show("Transaction successful. Cost Center updated.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				loadDataToListView();

				_operationMode = "EDIT";
				oControlListener.Listen(this);

				this.lvwGLaccounts_SelectedIndexChanged(this, new EventArgs());
				btnCancel_Click(this, new EventArgs());


			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed. Error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult rsp = MessageBox.Show("Delete selected cost center?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (rsp == DialogResult.Yes)
			{
				eGLaccounts oGLaccounts = new eGLaccounts();

				oGLaccounts.pAccountID = this.txtAccountID.Text;
				oGLaccounts.pUpdatedBy = this.txtUpdatedBy.Text;

				GLaccountsDAO oGLaccountsDAO = new GLaccountsDAO(GlobalVariables.gPersistentConnection);
				oGLaccountsDAO.DeleteGLAccount(oGLaccounts);

				loadDataToListView();
			}
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


	}
}