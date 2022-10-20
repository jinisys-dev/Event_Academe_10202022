using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	
		public class DepartmentFacade
		{
			private DepartmentDAO oDepartmentDAO;
			public DepartmentFacade()
			{
		    }

			public int insertObject(Department a_Department)
			{
                int rowsAffected = 0;
                oDepartmentDAO = new DepartmentDAO();
				rowsAffected=oDepartmentDAO.insertObject(a_Department);
                return rowsAffected;
			}

			public int  updateObject(ref Department a_Department)
			{
                int rowsAffected = 0;
                oDepartmentDAO = new DepartmentDAO();
                rowsAffected = oDepartmentDAO.updateObject(ref a_Department);
                return rowsAffected;
			}

			public int deleteObject(Department a_Department)
			{
                int rowsAffected = 0;
                oDepartmentDAO = new DepartmentDAO();
                rowsAffected= oDepartmentDAO.deleteObject(a_Department);
                return rowsAffected;
			}

			public object loadObject()
			{
                oDepartmentDAO = new DepartmentDAO();
                return oDepartmentDAO.loadObject();
			}
		}
	
}
