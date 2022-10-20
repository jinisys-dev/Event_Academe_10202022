using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Utilities.DataAccessLayer;

namespace Jinisys.Hotel.Utilities.BusinessLayer
{   
        public class BackUpFACADE
		{
	        public BackUpFACADE(){}

			public ArrayList GetDatabases()
			{
				BackUpDAO oBackUpDAO = new BackUpDAO();
				return oBackUpDAO.getDatabases();
			}
		}
	}
	

