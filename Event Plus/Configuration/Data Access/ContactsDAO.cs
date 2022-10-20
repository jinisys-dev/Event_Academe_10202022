

using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccess
{
	public class ContactsDAO
	{


		MySqlConnection lConnection = null;
		public ContactsDAO()
		{
			lConnection = GlobalVariables.gPersistentConnection;
		}

		public DataTable loadContacts()
		{
			try
			{
				DataTable _tempData = new DataTable();
				string _sqlStr = "call spSelectContacts('" 
									   + GlobalVariables.gHotelId + "')";

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(_tempData);
				dataAdapter.Dispose();

				return _tempData;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public int addNewContact(object pContact)
		{
			int _newId = 0;

			try
			{

				//int _id = int.Parse(pContact.GetType().GetProperty("Id").GetValue(pContact, null).ToString());
				string _contactNumber = pContact.GetType().GetProperty("ContactNumber").GetValue(pContact, null).ToString();
				string _contactName = pContact.GetType().GetProperty("ContactName").GetValue(pContact, null).ToString();
				string _contactType = pContact.GetType().GetProperty("ContactType").GetValue(pContact, null).ToString();
				string _fullName = pContact.GetType().GetProperty("FullName").GetValue(pContact, null).ToString();

				string _designation = pContact.GetType().GetProperty("Designation").GetValue(pContact, null).ToString();
				string _company = pContact.GetType().GetProperty("Company").GetValue(pContact, null).ToString();
				string _address = pContact.GetType().GetProperty("Address").GetValue(pContact, null).ToString();
				string _emailAddress = pContact.GetType().GetProperty("EmailAddress").GetValue(pContact, null).ToString();
				string _remarks = pContact.GetType().GetProperty("Remarks").GetValue(pContact, null).ToString();


				string _sqlStr = "call spInsertContact('" 
										+ _contactNumber + "','"
										+ _contactType + "','"
										+ _contactName + "','"
										+ _fullName + "','"
										+ _designation + "','"
										+ _company + "','"
										+ _address + "','"
										+ _emailAddress + "','"
										+ _remarks + "','"
										+ GlobalVariables.gLoggedOnUser + "','"
										+ GlobalVariables.gHotelId + "')";

				MySqlCommand _insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				object obj = _insertCommand.ExecuteScalar();

				if (obj == null)
				{
					throw new Exception("No rows affected");
				}
				_newId = int.Parse( obj.ToString() );

				return _newId;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int updateContact(object pContact)
		{
			try
			{

				int _id = int.Parse(pContact.GetType().GetProperty("Id").GetValue(pContact, null).ToString());
				string _contactNumber = pContact.GetType().GetProperty("ContactNumber").GetValue(pContact, null).ToString();
				string _contactName = pContact.GetType().GetProperty("ContactName").GetValue(pContact, null).ToString();
				string _contactType = pContact.GetType().GetProperty("ContactType").GetValue(pContact, null).ToString();
				string _fullName = pContact.GetType().GetProperty("FullName").GetValue(pContact, null).ToString();

				string _designation = pContact.GetType().GetProperty("Designation").GetValue(pContact, null).ToString();
				string _company = pContact.GetType().GetProperty("Company").GetValue(pContact, null).ToString();
				string _address = pContact.GetType().GetProperty("Address").GetValue(pContact, null).ToString();
				string _emailAddress = pContact.GetType().GetProperty("EmailAddress").GetValue(pContact, null).ToString();
				string _remarks = pContact.GetType().GetProperty("Remarks").GetValue(pContact, null).ToString();
				

				string _sqlStr = "call spUpdateContact(" + _id + ",'" 
											+ _contactNumber + "','"
											+ _contactType + "','"
											+ _contactName + "','"
											+ _fullName + "','"
											+ _designation + "','"
											+ _company + "','"
											+ _address + "','"
											+ _emailAddress + "','"
											+ _remarks + "','"
											+ GlobalVariables.gLoggedOnUser + "','"
											+ GlobalVariables.gHotelId + "')";

				MySqlCommand _updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				int _rowAffected = _updateCommand.ExecuteNonQuery();

				if (_rowAffected == 0)
				{
					throw new Exception("No rows affected");
				}

				return _rowAffected;

			}
			catch(Exception ex)
			{
				throw ex;
			}

		}

		public int deleteContact(int pContactId)
		{
			int _rowsAffected = 0;
			try {

				string _sqlStr = "call spDeleteContact('" + pContactId + "')";

				MySqlCommand _deleteCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				_rowsAffected = _deleteCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw new Exception("No rows affected.");
				}


				return _rowsAffected;

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

	}
}