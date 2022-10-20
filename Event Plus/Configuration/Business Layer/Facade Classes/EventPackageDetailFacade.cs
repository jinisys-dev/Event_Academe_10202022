using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class EventPackageDetailFacade
    {
        public EventPackageDetailFacade()
        { }

        private EventPackageDetailDAO loEventPackageDetailDAO;
        public GenericList<EventPackageDetail> getEventPackageDetails(string pPackageID)
        {
            GenericList<EventPackageDetail> _EventPackageDetailList = new GenericList<EventPackageDetail>();
            loEventPackageDetailDAO = new EventPackageDetailDAO();
            DataTable _dataTable = loEventPackageDetailDAO.getEventPackageDetail(pPackageID);
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventPackageDetail _oEventPackageDetail = new EventPackageDetail();
                _oEventPackageDetail.PackageID = int.Parse(_dataRow["packageID"].ToString());
                _oEventPackageDetail.TransactionCode = int.Parse(_dataRow["transactionCode"].ToString());
                _oEventPackageDetail.Description = _dataRow["description"].ToString();
                _oEventPackageDetail.Amount = double.Parse(_dataRow["amount"].ToString());
                _oEventPackageDetail.SubAccount = _dataRow["subAccount"].ToString();

                _EventPackageDetailList.Add(_oEventPackageDetail);
            }

            return _EventPackageDetailList;
        }

        public void saveEventPackageDetail(EventPackageDetail poEventPackageDetail)
        {
            loEventPackageDetailDAO = new EventPackageDetailDAO();
            loEventPackageDetailDAO.saveEventPackageDetail(poEventPackageDetail);
        }

        public void deleteEventPackageDetail(string pPackageID)
        {
            loEventPackageDetailDAO = new EventPackageDetailDAO();
            loEventPackageDetailDAO.deleteEventPackageDetail(pPackageID);
        }

        public GenericList<EventPackageDetail> getEventPackageRequirements(string pPackageID)
        {
            GenericList<EventPackageDetail> _eventPackageRequirementList = new GenericList<EventPackageDetail>();
            loEventPackageDetailDAO = new EventPackageDetailDAO();
            DataTable _dataTable = loEventPackageDetailDAO.getEventPackageRequirements(pPackageID);

            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventPackageDetail _eventPackageRequirement = new EventPackageDetail();
                _eventPackageRequirement.PackageID = int.Parse(_dataRow["packageID"].ToString());
                _eventPackageRequirement.RequirementHeader = _dataRow["requirementHeader"].ToString();
                _eventPackageRequirement.RequirementDetail = _dataRow["requirementDetail"].ToString();

                _eventPackageRequirementList.Add(_eventPackageRequirement);
            }
            return _eventPackageRequirementList;
        }

        public void saveEventPackageRequirements(EventPackageDetail _poEventPackageRequirement)
        {
            loEventPackageDetailDAO = new EventPackageDetailDAO();
            loEventPackageDetailDAO.saveEventPackageRequirements(_poEventPackageRequirement);
        }

        public void deleteEventPackageRequirements(string pPackageID)
        {
            loEventPackageDetailDAO = new EventPackageDetailDAO();
            loEventPackageDetailDAO.deleteEventPackageRequirements(pPackageID);
        }

        public string getSubAccountForPackage(string pDescription, string pPackageID)
        {
            loEventPackageDetailDAO = new EventPackageDetailDAO();
            return loEventPackageDetailDAO.getSubAccountForPackage(pDescription, pPackageID);
        }
    }
}
