using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class ContractAmendmentFacade
    {
        private ContractAmendmentDAO loContractAmendmentDAO;
        public ContractAmendmentFacade()
        {
        }

        public void saveAmendment(ref ContractAmendments _oAmendments)
        {
            loContractAmendmentDAO = new ContractAmendmentDAO();
            loContractAmendmentDAO.saveAmendment(ref _oAmendments);
        }

        public DataTable getAmendments(string pFolioID)
        {
            loContractAmendmentDAO = new ContractAmendmentDAO();
            return loContractAmendmentDAO.getAmendments(pFolioID);
        }

        public bool deleteAmendment(string ID)
        {
            loContractAmendmentDAO = new ContractAmendmentDAO();
            return loContractAmendmentDAO.deleteAmendment(ID);
        }

        public bool deleteAmendments(string pAmendmentID, string pFolioID)
        {
            loContractAmendmentDAO = new ContractAmendmentDAO();
            return loContractAmendmentDAO.deleteAmendments(pAmendmentID, pFolioID);
        }
    }
}
