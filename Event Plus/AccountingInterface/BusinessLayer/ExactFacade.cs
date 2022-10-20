using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Jinisys.Hotel.AccountingInterface.DataAccessLayer;

namespace Jinisys.Hotel.AccountingInterface.BusinessLayer
{
	public class ExactFacade
	{
		ExactDAO loExactDAO;
		public DataSet getTransactionCodesWithGLAccounts()
		{
			loExactDAO = new ExactDAO();
			return loExactDAO.getTransactionCodesWithGLAccounts();

		}


	}
}
