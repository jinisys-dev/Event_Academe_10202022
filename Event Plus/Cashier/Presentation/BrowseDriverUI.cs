using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.Cashier.Presentation
{
	public partial class BrowseDriverUI : Form
	{
		public BrowseDriverUI()
		{
			InitializeComponent();
		}

		private Driver selectedDriver = null;
		private IList<Driver> ilDrivers;
		private DriverFacade oDriverFacade;
		private void BrowseDriverUI_Load(object sender, EventArgs e)
		{
			oDriverFacade = new DriverFacade();
			ilDrivers = oDriverFacade.getDrivers();

			//int i = 1;
			foreach (Driver driver in ilDrivers)
			{
				DataGridViewRow row = new DataGridViewRow();
				object[] obj = { driver.DriverId, driver.LicenseNumber,driver.LastName,driver.FirstName, driver.TotalCommission};
				row.CreateCells(this.dtgDrivers,obj);


				this.dtgDrivers.Rows.Add(row);
				//this.dtgDrivers.Rows[i].Cells[0].Value = driver.DriverId;
				//this.dtgDrivers.Rows[i].Cells[1].Value = driver.LicenseNumber;
				//this.dtgDrivers.Rows[i].Cells[2].Value = driver.LastName;
				//this.dtgDrivers.Rows[i].Cells[3].Value = driver.FirstName;

			}

			this.cboSearchCriteria.SelectedIndex = 0;
		}

		int curRow = 0;
		private void btnSearch_Click(object sender, EventArgs e)
        {
            curRow = dtgDrivers.SelectedRows[0].Index;
			deselectAll();

			int criteriaIndex = this.cboSearchCriteria.SelectedIndex;

            int row = 0;
            //try
            //{
            //    row = this.dtgDrivers.CurrentRow.Index;
            //    //if (row == 0)
            //    //    row = curRow;
            //    if (row > 0 || row == curRow)
            //        row += 1;
            //}
            //catch
            //{ }

			for(int i = row + 1; i < this.dtgDrivers.RowCount ; i++)
			{
				string cellValue = this.dtgDrivers.Rows[i].Cells[criteriaIndex].Value.ToString();
				string searchValue = this.txtSearch.Text.ToUpper();

				if (cellValue.ToUpper().Contains(searchValue))
				{

					this.dtgDrivers.Rows[i].Selected = true;
					curRow = i;
					return;
				}
			}

			// only reach here if not found from CURRENT CURSOR POSITION - DOWN
			for (int i = 0; i < this.dtgDrivers.RowCount; i++)
			{
				string cellValue = this.dtgDrivers.Rows[i].Cells[criteriaIndex].Value.ToString();
				string searchValue = this.txtSearch.Text.ToUpper();

				if (cellValue.ToUpper().Contains(searchValue))
				{
					this.dtgDrivers.Rows[i].Selected = true;
					curRow = i;
					return;
				}
			}

			MessageBox.Show("No matching record found.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void deselectAll()
		{
			int rows = this.dtgDrivers.RowCount;
			for (int i = 0; i < rows; i++)
			{
				this.dtgDrivers.Rows[i].Selected = false;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string driverId = this.dtgDrivers.Rows[curRow].Cells[0].Value.ToString();

			foreach (Driver driver in ilDrivers)
			{
				if (driver.DriverId == driverId)
				{
					selectedDriver = driver;
					this.Close();
				}

			}
		}

		public Driver showDialog(Form parent)
		{
			base.ShowDialog(parent);

			return selectedDriver;
		}

		private void dtgDrivers_DoubleClick(object sender, EventArgs e)
		{
			this.btnOK_Click(sender, e);
		}

		private void dtgDrivers_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnOK_Click(sender, e);
			}
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnSearch_Click(sender, new EventArgs());
			}
		}

		private void dtgDrivers_SelectionChanged(object sender, EventArgs e)
		{
			curRow = this.dtgDrivers.CurrentRow.Index;
		}
	}
}