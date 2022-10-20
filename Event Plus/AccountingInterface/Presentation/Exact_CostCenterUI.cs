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
	public partial class Exact_CostCenterUI : Form
	{

		ControlListener oControlListener = new ControlListener();
		string _operationMode = "EDIT";

		public Exact_CostCenterUI()
		{
			InitializeComponent();
		}

		private void CostCenterUI_ExactGlobe_Load(object sender, EventArgs e)
		{
			loadDataToListView();

			this.CostCenterUI_ExactGlobe_TextChanged(this, new EventArgs());
		}

		DataTable tblCostCenter;
		private void loadDataToListView()
		{
			CostCenterDAO oCostCenterDAO = new CostCenterDAO(GlobalVariables.gPersistentConnection);

			tblCostCenter = oCostCenterDAO.getAllCostCenters(GlobalVariables.gHotelId);

			lvwCostCenter.Items.Clear();
			for (int i = 0; i < tblCostCenter.Rows.Count; i++)
			{
				string _statusFlag = tblCostCenter.Rows[i]["StatusFlag"].ToString();

				ListViewItem item = new ListViewItem();
				item.Text = tblCostCenter.Rows[i]["CostCenterCode"].ToString();

				item.SubItems.Add(tblCostCenter.Rows[i]["Description"].ToString());
				item.SubItems.Add(_statusFlag);
				item.SubItems.Add(tblCostCenter.Rows[i]["CreatedDate"].ToString());
				item.SubItems.Add(tblCostCenter.Rows[i]["CreatedBy"].ToString());
				item.SubItems.Add(tblCostCenter.Rows[i]["UpdatedDate"].ToString());
				item.SubItems.Add(tblCostCenter.Rows[i]["UpdatedBy"].ToString());

				if (_statusFlag == "DELETED")
				{
					item.BackColor = Color.Silver;
				}
				else
				{
					item.BackColor = Color.White;
				}

				this.lvwCostCenter.Items.Add(item);
			}
		
			if (this.lvwCostCenter.Items.Count > 0)
			{
				this.lvwCostCenter.Items[0].Selected = true;
			}

			oControlListener.Listen(this);

		}

		private void lvwCostCenter_SelectedIndexChanged(object sender, EventArgs e)
		{
			oControlListener.StopListen(this);

			try
			{
				string _costCenterCode = this.lvwCostCenter.SelectedItems[0].Text;


				foreach (DataRow row in tblCostCenter.Rows)
				{
					if (row["CostCenterCode"].ToString() == _costCenterCode)
					{
						this.txtCostCenterCode.Text = _costCenterCode;
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

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.lvwCostCenter_SelectedIndexChanged(this, new EventArgs());
			this.Text = this.Text.Replace("*", "");


			this.btnDelete.Enabled = true;
			this.btnNew.Enabled = true;
			this.btnClose.Enabled = true;

			this.btnSave.Enabled = false;
			this.btnCancel.Enabled = false;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				eCostCenter oCostcenter = new eCostCenter();
				oCostcenter.pCostCenterCode = this.txtCostCenterCode.Text;
				oCostcenter.pDescription = this.txtDescription.Text;
				oCostcenter.pStatusFlag = this.txtStatusFlag.Text;
				//oCostcenter.pCreatedDate = this.txtCreatedDate.Text;
				oCostcenter.pCreatedBy = this.txtCreatedBy.Text;
				//oCostcenter.pUpdatedDate = this.txtUpdatedDate.Text;
				oCostcenter.pUpdatedBy = this.txtUpdatedBy.Text;

				CostCenterDAO oCostCenterDAO = new CostCenterDAO(GlobalVariables.gPersistentConnection);
				if (_operationMode == "ADD")
				{
					oCostCenterDAO.SaveNewCostCenter(oCostcenter);

					MessageBox.Show("Transaction successful. (1) Cost Center added.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					oCostCenterDAO.UpdateCostCenter(oCostcenter);

					this.Text = this.Text.Replace("*", "");

					MessageBox.Show("Transaction successful. Cost Center updated.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				loadDataToListView();

				_operationMode = "EDIT";
				oControlListener.Listen(this);

				this.lvwCostCenter_SelectedIndexChanged(this, new EventArgs());
				btnCancel_Click(this,new EventArgs());


			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed. Error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 
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

			this.txtCostCenterCode.Text = "";
			this.txtDescription.Text = "";
			this.txtStatusFlag.Text = "ACTIVE";
			this.txtCreatedDate.Text = DateTime.Now.ToLongDateString();
			this.txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
			this.txtUpdatedDate.Text = DateTime.Now.ToLongDateString();
			this.txtUpdatedBy.Text = GlobalVariables.gLoggedOnUser;

			this.txtCostCenterCode.Focus();

			_operationMode = "ADD";
			
		}

		private void CostCenterUI_ExactGlobe_TextChanged(object sender, EventArgs e)
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
			DialogResult rsp = MessageBox.Show("Delete selected cost center?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (rsp == DialogResult.Yes)
			{
				eCostCenter oCostcenter = new eCostCenter();

				oCostcenter.pCostCenterCode = this.txtCostCenterCode.Text;
				oCostcenter.pUpdatedBy = this.txtUpdatedBy.Text;

				CostCenterDAO oCostCenterDAO = new CostCenterDAO(GlobalVariables.gPersistentConnection);
				oCostCenterDAO.DeleteCostCenter(oCostcenter);

				loadDataToListView();
			}
		}

		private void btnSetActive_Click(object sender, EventArgs e)
		{
			this.txtStatusFlag.Text = "ACTIVE";
		} 
	}
}