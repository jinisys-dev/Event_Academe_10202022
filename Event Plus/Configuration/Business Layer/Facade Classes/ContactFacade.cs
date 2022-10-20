using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.ConfigurationHotel.DataAccess;
using System.Data;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class ContactFacade
	{

		public ContactFacade()
		{
			
		}

		public ContactsDAO lContactDAO = null;
		public DataTable loadContacts()
		{
			lContactDAO = new ContactsDAO();
			return lContactDAO.loadContacts();
		}

		public Contact getContactById(int pContactId)
		{
			DataTable _tempTable = this.loadContacts();

			DataView dtView = _tempTable.DefaultView;
			dtView.RowStateFilter = DataViewRowState.OriginalRows;
			dtView.RowFilter = "id = " + pContactId;

			if (dtView.Count == 1)
			{
				Contact mContact = new Contact();
				mContact.Id = pContactId;
				mContact.ContactNumber = dtView[0]["contactNumber"].ToString();
				mContact.ContactName = dtView[0]["contactName"].ToString();
				mContact.ContactType = dtView[0]["contactType"].ToString();

				mContact.FullName = dtView[0]["fullName"].ToString();
				mContact.Designation = dtView[0]["designation"].ToString();
				mContact.Company = dtView[0]["company"].ToString();
				mContact.Address = dtView[0]["address"].ToString();
				mContact.EmailAddress = dtView[0]["emailAddress"].ToString();
				mContact.Remarks = dtView[0]["remarks"].ToString();


				return mContact;
			}
			else
			{
				return null;
			}

		}

		public void addNewContact(Contact pContact)
		{
			lContactDAO = new ContactsDAO();
			lContactDAO.addNewContact(pContact);
			//throw new Exception("The method or operation is not implemented.");
		}

		public void updateContact(Contact pContact)
		{
			lContactDAO = new ContactsDAO();
			lContactDAO.updateContact(pContact);
			//throw new Exception("The method or operation is not implemented.");
		}

		public int deleteContact(int pContactId)
		{
			lContactDAO = new ContactsDAO();
			return lContactDAO.deleteContact(pContactId);
		}
	}
}
