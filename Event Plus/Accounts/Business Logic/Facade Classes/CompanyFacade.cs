using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using System.Collections.Generic;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.Accounts.BusinessLayer
{
	public class CompanyFacade
	{
		private Company oCompany;
		private CompanyDAO oCompanyDAO;

		public CompanyFacade()
		{
			oCompany = new Company();
		}
		public Company getCompanyAccountsData()
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyAccountsData();
		}
		public bool getCompanyByName(string comp_name)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyByName(comp_name);
		}

		public Company filterGuestRecord(string a_fld, string a_tbl, string a_whr)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.FilterGuestRecord(a_fld, a_tbl, a_whr);
		}

		public int insertCompanyGuest(ref Company a_Company)
		{
			int rowsAffected = 0;
			oCompanyDAO = new CompanyDAO();
			rowsAffected = oCompanyDAO.insertObject(ref a_Company);
			return rowsAffected;
		}

		public int deleteCompanyAccount(string a_companyId, Company a_Company)
		{
			int rowsAffected = 0;
			oCompanyDAO = new CompanyDAO();
			rowsAffected = oCompanyDAO.deleteObject(a_companyId, a_Company);

			return rowsAffected;
		}

		public int updateCompanyAccount(object a_primaryKeyVal, ref Company a_Company)
		{
			int rowsAffected = 0;
			oCompanyDAO = new CompanyDAO();
			rowsAffected = oCompanyDAO.updateObject(a_primaryKeyVal, ref a_Company);

			return rowsAffected;
		}

		public Company getCompanyInfo(string a_folioid)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyInfo(a_folioid);
		}

		public Company getCompanyAccounts()
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyAccounts();
		}

		//public Company getCompanyAccount(string a_accountId, string a_companyCode)
		//{
		//    oCompanyDAO = new CompanyDAO();
		//    return oCompanyDAO.getCompanyAccount(a_accountId, a_companyCode);
		//}
		public Company getCompanyAccount(string a_accountId)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyAccount(a_accountId);
		}

		// >> 20 May 2006
		public IList<PrivilegeHeader> getAccountPrivileges(string pAccountId)
		{
			PrivilegeFacade oPrivilegeFacade = new PrivilegeFacade();
			IList<PrivilegeHeader> _oAccountPrivileges;
			oCompanyDAO = new CompanyDAO();
			_oAccountPrivileges = oCompanyDAO.getAccountPrivileges(pAccountId);

			foreach (PrivilegeHeader _oPrivilegeHeader in _oAccountPrivileges)
			{
				_oPrivilegeHeader.PrivilegeDetails = oPrivilegeFacade.getPrivilegeDetails(_oPrivilegeHeader.PrivilegeID);
			}

			return _oAccountPrivileges;
		}


		public int updateAccountTotalSales(string a_AccountId, double a_Amount)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.updateAccountTotalSales(a_AccountId, a_Amount);
		}

		public int setNoOfVisits(string a_CompanyId)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.setNoOfVisits(a_CompanyId);

		}

		public int deductXDealAmount(string a_CompanyId, double a_Amount)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.deductXDealAmount(a_CompanyId, a_Amount);
		}


		public void mergeCompanyAccount(string a_NewAccountId, string a_OldAccountId)
		{
			Company newGuest = this.getCompanyAccount(a_NewAccountId);
			Company oldGuest = this.getCompanyAccount(a_OldAccountId);

			oCompanyDAO = new CompanyDAO();

			MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
			try
			{
				oCompanyDAO.UpdateFolio_Merge(a_NewAccountId, a_OldAccountId, ref trans);
				for (int i = 1; i <= oldGuest.NO_OF_VISIT; i++)
				{
					this.setNoOfVisits(a_NewAccountId);
				}
				this.updateAccountTotalSales(a_NewAccountId, oldGuest.TOTAL_SALES_CONTRIBUTION);

				trans.Commit();
			}
			catch (Exception ex)
			{
				trans.Rollback();
				throw (ex);
			}


		}

        public DataTable getCompanies()
		{
			oCompanyDAO = new CompanyDAO();
			GenericList<Company> _oCompanyList = new GenericList<Company>();
			DataTable _dtCompany = this.getCompanyAccountsData().Tables[0];

            return _dtCompany;
		}

        public GenericList<Company> getCompanyList()
        {
            oCompanyDAO = new CompanyDAO();
            GenericList<Company> _oCompanyList = new GenericList<Company>();
            DataTable _dtCompany = this.getCompanyAccountsData().Tables[0];

            foreach (DataRow _dRow in _dtCompany.Rows)
            {
                Company _newCompany = new Company();

                _newCompany.CompanyId = _dRow["CompanyId"].ToString();
                _newCompany.CompanyCode = _dRow["CompanyCode"].ToString();
                _newCompany.CompanyName = _dRow["CompanyName"].ToString();
                _newCompany.CompanyURL = _dRow["CompanyURL"].ToString();
                _newCompany.ContactPerson = _dRow["ContactPerson"].ToString();
                _newCompany.Designation = _dRow["Designation"].ToString();
                _newCompany.Street1 = _dRow["Street1"].ToString();
                _newCompany.Street2 = _dRow["Street2"].ToString();
                _newCompany.Street3 = _dRow["Street3"].ToString();
                _newCompany.City1 = _dRow["City1"].ToString();
                _newCompany.City2 = _dRow["City2"].ToString();
                _newCompany.City3 = _dRow["City3"].ToString();
                _newCompany.Country1 = _dRow["Country1"].ToString();
                _newCompany.Country2 = _dRow["Country2"].ToString();
                _newCompany.Country3 = _dRow["Country3"].ToString();
                _newCompany.Zip1 = _dRow["Zip1"].ToString();
                _newCompany.Zip2 = _dRow["Zip2"].ToString();
                _newCompany.Zip3 = _dRow["Zip3"].ToString();
                _newCompany.Email1 = _dRow["Email1"].ToString();
                _newCompany.Email2 = _dRow["Email2"].ToString();
                _newCompany.Email3 = _dRow["Email3"].ToString();
                _newCompany.ContactNumber1 = _dRow["ContactNumber1"].ToString();
                _newCompany.ContactNumber2 = _dRow["ContactNumber2"].ToString();
                _newCompany.ContactNumber3 = _dRow["ContactNumber3"].ToString();
                _newCompany.ContactType1 = _dRow["ContactType1"].ToString();
                _newCompany.ContactType2 = _dRow["ContactType2"].ToString();
                _newCompany.ContactType3 = _dRow["ContactType3"].ToString();

                //_newCompany.HotelID = _dRow["HotelID"].ToString();
                //_newCompany.CreateTime = _dRow["CompanyId"].ToString();
                //_newCompany.CreatedBy = _dRow["CompanyId"].ToString();
                //_newCompany.UpdateTime = _dRow["CompanyId"].ToString();
                //_newCompany.UpdatedBy = _dRow["CompanyId"].ToString();

                _newCompany.ACCOUNT_TYPE = _dRow["ACCOUNT_TYPE"].ToString();
                _newCompany.CARD_NO = _dRow["CARD_NO"].ToString();
                _newCompany.THRESHOLD_VALUE = double.Parse(_dRow["THRESHOLD_VALUE"].ToString());
                _newCompany.TOTAL_SALES_CONTRIBUTION = double.Parse(_dRow["TOTAL_SALES_CONTRIBUTION"].ToString());
                _newCompany.NO_OF_VISIT = int.Parse(_dRow["NO_OF_VISIT"].ToString());
                _newCompany.X_DEAL_AMOUNT = double.Parse(_dRow["X_DEAL_AMOUNT"].ToString());

                _newCompany.AccountPrivileges = this.getAccountPrivileges(_newCompany.CompanyId);

                _oCompanyList.Add(_newCompany);
            }


            return _oCompanyList;
        }



		public DataTable getCompanyAsDataTable()
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyAsDataTable();
		}

		public DataTable getCompanyAsDataTableByCompanyID(string pCompanyID)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyAsDataTableByCompanyID(pCompanyID);
		}


		public DataTable getCompanyInfoAsDataTableByName(string pCompanyName)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyInfoAsDataTableByName(pCompanyName);
		}

		public DataTable getCompanyInfoAsDataTableByNameUsingLike(string pCompanyName)
		{
			oCompanyDAO = new CompanyDAO();
			return oCompanyDAO.getCompanyInfoAsDataTableByNameUsingLike(pCompanyName);
		}
        public DataTable getCompanyJournal(string pCompanyName)
        {
            oCompanyDAO = new CompanyDAO();
            return oCompanyDAO.getCompanyJournal(pCompanyName);
        }
        public void insertCompantJournal(string pCompanyID, string pRemarks, DateTime pDate)
        {
            oCompanyDAO = new CompanyDAO();
            oCompanyDAO.insertCompanyJournal(pCompanyID, pRemarks, pDate);
        }
        public void deleteCompantJournal(string pCompanyID)
        {
            oCompanyDAO = new CompanyDAO();
            oCompanyDAO.deleteCompanyJournal(pCompanyID);          
        }
		


	}
}

