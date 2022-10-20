using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Configuration.DataAccessLayer;
using Jinisys.Hotel.Configuration.BusinessLayer;

namespace Jinisys.Hotel.Configuration.BusinessLayer
{

		public class PrivilegeFacade
		{
            public PrivilegeFacade()
			{
			}
			private PrivilegeDAO oPrivilegeDAO;
			public int insertObject(PrivilegeHeader a_PrivilegeHeader)
			{
                int rowsAffected = 0;
                oPrivilegeDAO = new PrivilegeDAO();
                rowsAffected = oPrivilegeDAO.insertObject(a_PrivilegeHeader);
                return rowsAffected;
			}
			public int updateObject(PrivilegeHeader a_PrivilegeHeader)
			{
                int rowsAffected = 0;
                oPrivilegeDAO = new PrivilegeDAO();
                rowsAffected = oPrivilegeDAO.updateObject(ref a_PrivilegeHeader);
                return rowsAffected;
			}
          	public int deleteObject(PrivilegeHeader a_PrivilegeHeader)
			{
                int rowsAffected = 0;
                oPrivilegeDAO = new PrivilegeDAO();
				rowsAffected=oPrivilegeDAO.deleteObject(a_PrivilegeHeader);
                return rowsAffected;
			}
			public object loadObject()
			{
                oPrivilegeDAO = new PrivilegeDAO();
                return oPrivilegeDAO.loadObject();
			}
			public DataTable loadPrivilegeDetails(string a_privilegeId)
			{
                oPrivilegeDAO = new PrivilegeDAO();
				return oPrivilegeDAO.loadPrivilegeDetails(a_privilegeId);
			}
			public int deletePrivilegeDetail(string a_privilegeId, string a_trancode)
			{
                int rowsAffected = 0;
                oPrivilegeDAO = new PrivilegeDAO();
                rowsAffected = oPrivilegeDAO.deletePrivilegeDetail(a_privilegeId, a_trancode);
                return rowsAffected;
			}
		
	}
}
