using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	public partial class ContactsUI : Form
	{
		public ContactsUI()
		{
			InitializeComponent();

			this.txtContactId.Text = "AUTO";
			this.cboContactType.SelectedIndex = 1;
		}


		private int lContactId = 0;
		private string mMode = "ADD";
		public ContactsUI(int pContactId)
		{
			InitializeComponent();

			lContactId = pContactId;

			this.txtContactId.Text = lContactId.ToString();
			mMode = "EDIT";
		}

		private void ContactsUI_Load(object sender, EventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private ContactFacade lContactFacade;
		private void txtContactId_TextChanged(object sender, EventArgs e)
		{
			if (txtContactId.Text != "AUTO")
			{
				lContactFacade = new ContactFacade();
				Contact mContact = lContactFacade.getContactById(lContactId);

				if (mContact != null)
				{
					this.txtContactNumber.Text = mContact.ContactNumber;

					this.txtContactName.Text = mContact.ContactName;
					this.cboContactType.Text = mContact.ContactType;

					this.txtFullName.Text = mContact.FullName;
					this.txtDesignation.Text = mContact.Designation;
					this.txtCompany.Text = mContact.Company;
					this.txtAddress.Text = mContact.Address;
					this.txtEmailAddress.Text = mContact.EmailAddress;
					this.txtRemarks.Text = mContact.Remarks;


				}

			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			lContactFacade = new ContactFacade();
			Contact mContact = new Contact();
			setupContactInformation(ref mContact);

			try
			{
				switch (mMode)
				{
					case "ADD":
						lContactFacade.addNewContact(mContact);

						MessageBox.Show("Transaction successful.\r\nNew contact added.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						break;
					case "EDIT":
						mContact.Id = lContactId;
						lContactFacade.updateContact(mContact);

						MessageBox.Show("Transaction successful.\r\nContact info updated.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						break;
					default:
						break;
				}
			}
			catch(Exception ex)
			{
				if(ex.Message.ToUpper().Contains("DUPLICATE"))
				{
					MessageBox.Show("Transaction failed.\r\nContact number already exist.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void setupContactInformation(ref Contact mContact)
		{
			
			mContact.ContactNumber = this.txtContactNumber.Text;

			mContact.ContactName = this.txtContactName.Text;
			mContact.ContactType = this.cboContactType.Text;

			mContact.FullName = this.txtFullName.Text;
			mContact.Designation = this.txtDesignation.Text;
			mContact.Company = this.txtCompany.Text;
			mContact.Address = this.txtAddress.Text;
			mContact.EmailAddress = this.txtEmailAddress.Text;
			mContact.Remarks = this.txtRemarks.Text;


		}

	}
}