using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.Accounts.BusinessLayer
{
	    public class AccountPrivilegesFacade
		{
		    private AccountPrivilegesDAO oAccountPrivilegesDAO;
			public AccountPrivilegesFacade(){}

			public int saveAccountPrivileges(ref AccountPrivileges oAccountPrivileges)
			{
                int rowsAffected = 0;
				oAccountPrivilegesDAO = new AccountPrivilegesDAO();
				rowsAffected= oAccountPrivilegesDAO.saveAccountPrivileges(oAccountPrivileges);
                return rowsAffected;
			}

			public int updateAccountPrivileges(AccountPrivileges oAccountPrivileges)
			{
                int rowsAffected = 0;
				oAccountPrivilegesDAO = new AccountPrivilegesDAO();
				rowsAffected= oAccountPrivilegesDAO.saveAccountPrivileges(oAccountPrivileges);
                return rowsAffected;
			}

			public DataTable getAccountPrivileges(string accid)
			{
				oAccountPrivilegesDAO = new AccountPrivilegesDAO();
				return oAccountPrivilegesDAO.getAccountPrivileges(accid);
			}

			public DataTable getPrivileges()
			{
				oAccountPrivilegesDAO = new AccountPrivilegesDAO();
				return oAccountPrivilegesDAO.getPrivileges();
			}

			public DataTable getAccounts()
			{
				oAccountPrivilegesDAO = new AccountPrivilegesDAO();
				return oAccountPrivilegesDAO.getAccounts();
			}
		
		}
	}

