using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Accounts.BusinessLayer
{
	    public class GuestFacade 
		{
            private Guest oGuest ;
            private GuestDAO oGuestDAO;

		    public GuestFacade()
			{
                oGuest = new Guest();
			}
			
			public Guest insertGuestNoDataTable(Guest a_Guest)
			{
				oGuestDAO = new GuestDAO();
				oGuestDAO.insertGuestNoDataTable(a_Guest);
				return null;
			}
           
			public Guest getGuests()
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.getGuests();
			}

            public DataTable getGuestAccounts()
            {
                oGuestDAO = new GuestDAO();
                return oGuestDAO.getGuestAccounts();
            }

            public DataTable getGuestAccount(string fname, string lnam)
            {
                oGuestDAO = new GuestDAO();
                return oGuestDAO.getGuestAccount(fname, lnam);
            }

			//public DataTable getGuestsAsDataTable()
			//{
			//    oGuestDAO = new GuestDAO();
			//    return oGuestDAO.getGuestsAsDataTable();
			//}

			public Guest getGuestsByCriteria(string a_FirstName, string a_LastName)
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.getGuestsByCriteria(a_FirstName, a_LastName);
			}

            public bool checkIfGuestNameExists(string pFirstname, string pLastname)
            {
                oGuestDAO = new GuestDAO();
                return oGuestDAO.checkIfGuestNameExists(pFirstname, pLastname);
            }
			
			public bool insertGuest(ref Guest a_Guest)
			{
                bool success = false;

				try
				{
					oGuestDAO = new GuestDAO();
					success = oGuestDAO.insertGuest(ref a_Guest);

					return success;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			
			public int deleteGuest(string a_accountId, ref Guest a_Guest)
			{
                int rowsAffected = 0;
				oGuestDAO = new GuestDAO();
				rowsAffected=oGuestDAO.deleteGuest(a_accountId, a_Guest);

                return rowsAffected;
			}
			
			public bool updateGuest( ref Guest a_Guest )
			{
				bool isSuccessful = false;

				oGuestDAO = new GuestDAO();
				isSuccessful = oGuestDAO.updateGuest(ref a_Guest );

				return isSuccessful;
			}

			public Guest filterGuestRecordRefName(string a_Lastname, string a_Firstname, string a_Middlename)
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.filterGuestRecordRefName(a_Lastname, a_Firstname, a_Middlename);
			}
			
			public Guest searchAccountByName(ref Guest a_Guest)
			{
                oGuestDAO = new GuestDAO();
                return oGuestDAO.searchAccountName(ref a_Guest);
			}

			public Guest displayListofGuest()
			{
                oGuestDAO = new GuestDAO();
                return oGuestDAO.displayListOfGuest();
			}

			public Guest filterGuestRecord(string a_fld, string a_tbl, string a_whr)
			{
                oGuestDAO = new GuestDAO();
                return oGuestDAO.filterGuestRecord(a_fld, a_tbl, a_whr);
			}

			public Guest getGuestRecord(string a_guestID)
			{
					oGuestDAO = new GuestDAO();
					return oGuestDAO.getGuestRecord(a_guestID);
			}

			public string getGuestID(int a_accountid)
			{
                oGuestDAO = new GuestDAO();
                return oGuestDAO.getGuestID(a_accountid);
			}

			public Guest getGuestRecordRefName(string a_firstname, string a_lastname, string a_MI)
			{
                oGuestDAO = new GuestDAO();
                return oGuestDAO.getGuestRecordRefName(a_firstname, a_lastname, a_MI);
			}

			public Guest searchGuestRecordRefName(string a_firstname, string a_lastname, string a_MI)
			{
                oGuestDAO = new GuestDAO();
                return oGuestDAO.searchGuestRecordRefName(a_firstname, a_lastname, a_MI);
			}

			public void setNoOfVisits(string a_guestID)
			{
				oGuestDAO = new GuestDAO();
				oGuestDAO.setNoOfVisits(a_guestID);
			}

			public string getGuestID(string a_FIRSTNAME, string a_LASTNAME, string a_middlename)
			{
                oGuestDAO = new GuestDAO();
                return oGuestDAO.getGuestID(a_FIRSTNAME, a_LASTNAME, a_middlename);
			}

			public Guest updateGuestNoDataTable(Guest a_Guest)
			{
				oGuestDAO = new GuestDAO();
				oGuestDAO.updateGuestNoDataTable(a_Guest);
				return null;
			}
			
			// >> 20 May 2006
			public void getAccountPrivileges(string pAccountId, ref Guest a_Guest)
			{
				oGuestDAO = new GuestDAO();

				a_Guest.AccountPrivileges = oGuestDAO.getAccountPrivileges(pAccountId);
			}
		
			public int updateAccountTotalSales(string a_AccountId, double a_Amount)
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.updateAccountTotalSales(a_AccountId, a_Amount);
			}


			public void mergeGuestAccount(string a_NewAccountId, string a_OldAccountId)
			{
				Guest newGuest = this.getGuestRecord(a_NewAccountId);
				Guest oldGuest = this.getGuestRecord(a_OldAccountId);

				oGuestDAO = new GuestDAO();

				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
				try
				{
					oGuestDAO.UpdateFolio_Merge(a_NewAccountId, a_OldAccountId, ref trans);
					for (int i = 1; i <= oldGuest.NoOfVisits; i++)
					{
						this.setNoOfVisits(a_NewAccountId);
					}
					this.updateAccountTotalSales(a_NewAccountId, oldGuest.TOTAL_SALES_CONTRIBUTION);

					//oGuestDAO.deleteGuest(a_OldAccountId, oldGuest);
					trans.Commit();
				}
				catch(Exception ex)
				{
					trans.Rollback();
					throw (ex);
				}


			}


			public IList<Guest> getGuestList()
			{
				oGuestDAO = new GuestDAO();
				IList<Guest> _oGuestList = new List<Guest>();
				DataTable _dtGuest = this.getGuests().Tables[0];

                foreach (DataRow _dRow in _dtGuest.Rows)
                {
                    Guest _newGuest = new Guest();


                    _newGuest.AccountId = _dRow["AccountId"].ToString();
                    _newGuest.AccountName = _dRow["AccountName"].ToString();
                    _newGuest.Title = _dRow["Title"].ToString();
                    _newGuest.LastName = _dRow["LastName"].ToString();
                    _newGuest.FirstName = _dRow["FirstName"].ToString();
                    _newGuest.MiddleName = _dRow["MiddleName"].ToString();
                    _newGuest.Sex = _dRow["Sex"].ToString();
                    _newGuest.Citizenship = _dRow["Citizenship"].ToString();
                    _newGuest.PassportId = _dRow["PassportId"].ToString();
                    _newGuest.GuestImage = _dRow["GuestImage"].ToString();
                    _newGuest.TelephoneNo = _dRow["TelephoneNo"].ToString();
                    _newGuest.MobileNo = _dRow["MobileNo"].ToString();
                    _newGuest.FaxNo = _dRow["FaxNo"].ToString();
                    _newGuest.Street = _dRow["Street"].ToString();
                    _newGuest.City = _dRow["City"].ToString();
                    _newGuest.Country = _dRow["Country"].ToString();
                    _newGuest.Zip = _dRow["Zip"].ToString();
                    _newGuest.EmailAddress = _dRow["EmailAddress"].ToString();
                    _newGuest.Memo = _dRow["Memo"].ToString();
                    _newGuest.Concierge = _dRow["Concierge"].ToString();
                    _newGuest.Remark = _dRow["Remark"].ToString();
                    _newGuest.NoOfVisits = int.Parse(_dRow["NoOfVisits"].ToString());
                    _newGuest.HotelID = int.Parse(_dRow["HotelID"].ToString());
                    _newGuest.CreateTime = DateTime.Parse(_dRow["CreateTime"].ToString());
                    _newGuest.CreatedBy = _dRow["CreatedBy"].ToString();
                    _newGuest.UpdateTime = DateTime.Parse(_dRow["UpdateTime"].ToString());
                    _newGuest.UpdatedBy = _dRow["UpdatedBy"].ToString();

                    _newGuest.AccountPrivileges = oGuestDAO.getAccountPrivileges(_newGuest.AccountId);

                    _newGuest.BIRTH_DATE = DateTime.Parse(_dRow["BIRTH_DATE"].ToString());
                    _newGuest.ACCOUNT_TYPE = _dRow["ACCOUNT_TYPE"].ToString();
                    _newGuest.CARD_NO = _dRow["Card_No"].ToString();
                    _newGuest.THRESHOLD_VALUE = double.Parse(_dRow["THRESHOLD_VALUE"].ToString());
                    _newGuest.TOTAL_SALES_CONTRIBUTION = double.Parse(_dRow["TOTAL_SALES_CONTRIBUTION"].ToString());
                    _newGuest.CreditCardType = _dRow["CreditCardType"].ToString();
                    _newGuest.CreditCardNo = _dRow["CreditCardNo"].ToString();

                    _newGuest.CreditCardExpiry = _dRow["CreditCardExpiry"].ToString();
                    //_newGuest.CompanyID = _dRow["companyID"].ToString();

                    _oGuestList.Add(_newGuest);
                }


				return _oGuestList;
			}





			public DataTable getGuestsAsDataTable()
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.getGuestsAsDataTable();
			}

			public DataTable getGuestRecordAsDataTableByAccountID(string pAccountID)
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.getGuestRecordAsDataTableByAccountID(pAccountID);
			}

			public DataTable getGuestRecordAsDataTableByName(string pLastName, string pFirstName)
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.getGuestRecordAsDataTableByName(pLastName, pFirstName);
			}

			public DataTable getGuestsAsDataTableByNameUsingLike(string pLastName, string pFirstName)
			{
				oGuestDAO = new GuestDAO();
				return oGuestDAO.getGuestsAsDataTableByNameUsingLike(pLastName, pFirstName);
			}


		}
	
}
