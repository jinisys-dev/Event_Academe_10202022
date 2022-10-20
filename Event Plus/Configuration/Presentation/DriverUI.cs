using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	public partial class DriverUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
	{

		#region "CONSTRUCTORS"

		public DriverUI()
		{
			InitializeComponent();

			this.Text = "Drivers";
			oControlListener = new ControlListener();
		}

		#endregion

		#region "VARIABLES/CONSTANTS/OBJECTS"

		ControlListener oControlListener;
		private OperationMode mOperationMode;
		private DriverFacade oDriverFacade;
		private IList<Driver> ilDrivers;

		#endregion

		#region "METHODS"

		private void loadData()
		{
			oDriverFacade = new DriverFacade();

			ilDrivers = oDriverFacade.getDrivers();

			this.grdDrivers.Rows.Count = ilDrivers.Count + 1;
			int i = 1;
			foreach (Driver driver in ilDrivers)
			{
	
				this.grdDrivers.SetData(i, 0, driver.DriverId);
				this.grdDrivers.SetData(i, 1, driver.LastName + ", " + driver.FirstName);

				this.grdDrivers.SetData(i, 2, driver.TotalCommission.ToString("N"));

				i++;
			}

			grdDrivers_RowColChange(this, new EventArgs());

			setActionButtonStates(true);
		}

		private void viewRecord(string driverId)
		{
			foreach (Driver driver in ilDrivers)
			{
				if (driver.DriverId == driverId)
				{

					this.lblDriverId.Text = driver.DriverId;
					this.lblTotalCommission.Text = driver.TotalCommission.ToString("N");
					this.txtLicenseNumber.Text = driver.LicenseNumber;
					this.txtLastName.Text = driver.LastName;
					this.txtFirstName.Text = driver.FirstName;
					this.txtMiddleName.Text = driver.MiddleName;
                    txtBrand.Text = driver.Brand;
                    txtCarModel.Text = driver.Car_Model;
                    txtCompany.Text = driver.Company;
                    txtPlateNumber.Text = driver.Plate_Number;

                    viewGuestFolios(driverId);
                    return;
				}
			}
		}

        private void viewGuestFolios(string driverID)
        {
            grdFolios.Rows.Count = 1;
            DataTable folioTable = new DataTable();
            oDriverFacade = new DriverFacade();
            folioTable = oDriverFacade.getDriversGuestFolios(driverID);

            foreach (DataRow dRow in folioTable.Rows)
            {
                object[] items ={ dRow["referenceFolioID"], dRow["roomNumber"], dRow["GuestName"], dRow["netamount"] };
                grdFolios.AddItem(items);
            }
        }

		/********************************************************
         * Purpose: Set the state of the button
         *********************************************************/
		private void setActionButtonStates(bool a_states)
		{
			//this.btnSearch.Enabled = pStates;
			this.btnDelete.Enabled = a_states;
			this.btnNew.Enabled = a_states;
			this.btnSave.Enabled = !a_states;
			this.btnCancel.Enabled = !a_states;
			this.btnClose.Enabled = a_states;

			// set CANCEL BUTTON for this form
			// if in EDIT/ADD mode CANCEL BUTTON is btnCancel
			// else CANCEL BUTTON is btnClose
			if (a_states)
			{
				this.CancelButton = this.btnClose;
			}
			else
			{
				this.CancelButton = this.btnCancel;
			}
		}

		private void setOperationMode(OperationMode a_OperationMode)
		{
			mOperationMode = a_OperationMode;
		}

		#endregion

		#region "EVENTS"

		private void DriverUI_TextChanged(object sender, EventArgs e)
		{
			if (this.Text.IndexOf('*') > 0)
			{
				setOperationMode(OperationMode.Edit);
				setActionButtonStates(false);
			}
			else
			{
				setActionButtonStates(true);
			}
		}

		private void DriverUI_Load(object sender, EventArgs e)
		{
			loadData();
		}

		private void grdDrivers_RowColChange(object sender, EventArgs e)
		{
			oControlListener.StopListen(this);
			try
			{
				int row = this.grdDrivers.Row;
				string driverId = this.grdDrivers.GetDataDisplay(row, 0);

				viewRecord(driverId);
			}
			catch
			{ }
			finally
			{
				oControlListener.Listen(this);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{

			if (this.grdDrivers.Rows.Count > 1)
			{
				this.grdDrivers_RowColChange(this, new EventArgs());
			}


			this.Text = "Drivers";
			setActionButtonStates(true);
			oControlListener.Listen(this);

		}

		#endregion

		private void btnNew_Click(object sender, EventArgs e)
		{
			setOperationMode(OperationMode.Add);
			oControlListener.StopListen(this);

			initializeBlankForm();
			this.txtLicenseNumber.Focus();

			setActionButtonStates(false);
		}

		private void initializeBlankForm()
		{
			this.lblDriverId.Text = "AUTO";
			this.lblTotalCommission.Text = "0.00";
			this.txtLicenseNumber.Text = "";
			this.txtLastName.Text = "";
			this.txtFirstName.Text = "";
			this.txtMiddleName.Text = "";
            this.txtCompany.Text = "";
            this.txtBrand.Text = "";
            this.txtCarModel.Text = "";
            this.txtPlateNumber.Text = "";
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (checkRequiredFields())
			{
				DialogResult rsp = MessageBox.Show("Save driver information ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (rsp == DialogResult.Yes)
				{

					Driver oDriver = new Driver();
					initializeNewDriverObject(ref oDriver);

					if (mOperationMode == OperationMode.Add)
					{
						insertNewDriver(oDriver);
						
					} // else if operation mode is EDIT
					else
					{
						oDriver.DriverId = this.lblDriverId.Text;
						updateDriverInfo(oDriver);
					}

					//setActionButtonStates(true);
					this.Text = "Drivers";
					btnCancel_Click(sender, new EventArgs());
				}

			}
		}

		/* checks if all required fields are not empty
		 * returns true if all required fields are not empty
		 */ 
		private bool checkRequiredFields()
		{
			if (this.txtLicenseNumber.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Please input license number.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtLicenseNumber.Focus();
				return false;
			}

			if (this.txtLastName.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Please input driver's last name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtLastName.Focus();
				return false;
			}

			if (this.txtFirstName.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Please input driver's first name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtFirstName.Focus();
				return false;
			}

			return true;
		}

		private void initializeNewDriverObject(ref Driver a_Driver)
		{
			a_Driver.LicenseNumber = this.txtLicenseNumber.Text;
			a_Driver.LastName = this.txtLastName.Text;
			a_Driver.FirstName = this.txtFirstName.Text;
			a_Driver.MiddleName = this.txtMiddleName.Text;
			a_Driver.TotalCommission = double.Parse(this.lblTotalCommission.Text);
            a_Driver.Company = txtCompany.Text;
            a_Driver.Brand = txtBrand.Text;
            a_Driver.Car_Model = txtCarModel.Text;
            a_Driver.Plate_Number = txtPlateNumber.Text;
		}

		private void insertNewDriver(Driver a_Driver)
		{
			oDriverFacade = new DriverFacade();

			try
			{
				oDriverFacade.insertNewDriver(a_Driver, ref ilDrivers);

				int lastRow = this.grdDrivers.Rows.Count;
				this.grdDrivers.Rows.Count += 1;
				this.grdDrivers.SetData(lastRow, 0, a_Driver.DriverId);
				this.grdDrivers.SetData(lastRow, 1, a_Driver.LastName + ", " + a_Driver.FirstName);

				this.grdDrivers.Row = lastRow;
				this.grdDrivers_RowColChange(this, new EventArgs());

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void updateDriverInfo(Driver a_Driver)
		{
			oDriverFacade = new DriverFacade();

			try
			{
				oDriverFacade.updateDriverInfo(a_Driver, ref ilDrivers);

				int row = this.grdDrivers.Row;
				//this.grdDrivers.set_TextMatrix(lastRow, 0, a_Driver.DriverId);
				this.grdDrivers.SetData(row, 1, a_Driver.LastName + ", " + a_Driver.FirstName);

				//this.grdDrivers.Row = lastRow;
				this.grdDrivers_RowColChange(this, new EventArgs());

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult response = MessageBox.Show("Remove this driver from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (response == DialogResult.Yes)
			{
				oDriverFacade = new DriverFacade();

				try
				{
					string driverId = this.lblDriverId.Text;

					oDriverFacade.deleteDriver(driverId, ref ilDrivers);

					this.grdDrivers.RemoveItem(this.grdDrivers.Row);

					if (this.grdDrivers.Rows.Count > 1)
					{
						this.grdDrivers.Row = 1;
						this.grdDrivers_RowColChange(this, new EventArgs());
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}

	}
}

