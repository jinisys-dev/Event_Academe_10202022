using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.Presentation
{
	public partial class EndorsementListUI : Form
	{
		public EndorsementListUI()
		{
			InitializeComponent();

			//this.grdEndorsementList.AutoSizeRows(0,0,0,0,0, C1.Win.C1FlexGrid.AutoSizeFlags.);
			
		}

		private EndorsementFacade lEndorsementFacade;
		

		private void loadData()
		{
			lEndorsementFacade = new EndorsementFacade();

			DataTable _tempData = lEndorsementFacade.getAllEndorsements();

			DateTime _startDateTime = DateTime.Parse(this.dtpDate.Value.ToString("yyyy-MM-dd") + " 00:00:00");
			DateTime _endDateTime = DateTime.Parse(this.dtpDate.Value.ToString("yyyy-MM-dd") + " 23:59:59");

			DataView _tempView = _tempData.DefaultView;
			_tempView.RowStateFilter = DataViewRowState.OriginalRows;
			_tempView.RowFilter = "logDate >= #" + _startDateTime + "# and logDate <= #" + _endDateTime + "#";

			//this.grdEndorsementList.DataSource = _temp;
			this.grdEndorsementList.Rows.Count = _tempView.Count + 1;
			int i = 1;
			foreach (DataRowView _dRow in _tempView)
			{
				string _statusFlag = _dRow["statusFlag"].ToString();

				this.grdEndorsementList.SetData(i, 0, i);
				this.grdEndorsementList.SetData(i, 1, _dRow["logDate"]);
				this.grdEndorsementList.SetData(i, 2, _dRow["shiftCode"]);
				this.grdEndorsementList.SetData(i, 3, _dRow["loggedUser"]);
				this.grdEndorsementList.SetData(i, 4, _dRow["endorsementDescription"]);
				this.grdEndorsementList.SetData(i, 5, _statusFlag);
				this.grdEndorsementList.SetData(i, 6, _dRow["acknowledgedBy"]);
				this.grdEndorsementList.SetData(i, 7, _dRow["endorsementRemarks"]);
				this.grdEndorsementList.SetData(i, 8, _dRow["id"]);

				if (_statusFlag == "ACKNOWLEDGED")
				{
					this.grdEndorsementList.Rows[i].Style = this.grdEndorsementList.Styles["Acknowledge"];
				}
				else
				{
					this.grdEndorsementList.Rows[i].Style = this.grdEndorsementList.Styles["Normal"];
				}

				i++;
			}

			this.grdEndorsementList.AutoSizeRows();
			this.grdEndorsementList.AutoSizeCols();

		}

		private void EndorsementListUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			loadData();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			EndorsementUI oEndorsementUI = new EndorsementUI();
			oEndorsementUI.ShowDialog();

			loadData();
		}

		private void btnAcknowledge_Click(object sender, EventArgs e)
		{
			string _strId = this.grdEndorsementList.GetDataDisplay(this.grdEndorsementList.Row, 8);

			int _id = int.Parse(_strId);


			EndorsementUI oEndorsementUI = new EndorsementUI(_id, "ACKNOWLEDGED");
			oEndorsementUI.ShowDialog();

			loadData();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			grdEndorsementList_DoubleClick(sender, e);
		}

		private void grdEndorsementList_DoubleClick(object sender, EventArgs e)
		{
			string _strId = this.grdEndorsementList.GetDataDisplay(this.grdEndorsementList.Row, 8);

			int _id = int.Parse(_strId);

			EndorsementUI oEndorsementUI = new EndorsementUI(_id, "EDIT");
			oEndorsementUI.ShowDialog();

			loadData();
		}

		private void dtpDate_ValueChanged(object sender, EventArgs e)
		{
			loadData();
		}

		private void EndorsementListUI_Load(object sender, EventArgs e)
		{
			this.dtpDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
		}

		private void grdEndorsementList_RowColChange(object sender, EventArgs e)
		{
			int _row = this.grdEndorsementList.Row;
			if (_row > 0)
			{
				string _statusFlag = this.grdEndorsementList.GetDataDisplay(_row, 5);

				if (_statusFlag == "ACKNOWLEDGED")
				{
					this.btnEdit.Text = "&View";
					this.btnAcknowledge.Enabled = false;
				}
				else
				{
					this.btnEdit.Text = "&Edit";
					this.btnAcknowledge.Enabled = true;
				}
			}
		}


	}
}