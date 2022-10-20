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
    public class EventPackageFacade
    {
        public EventPackageFacade()
        { }

        private EventPackageDAO loEventPackageDAO;

        public double getEventPackageAmount(string packageID)
        {
            loEventPackageDAO = new EventPackageDAO();
            return loEventPackageDAO.getEventPackageAmount(packageID);
        }

        public void saveEventPackage(ref EventPackageHeader poEventPackageHeader, ref GenericList<EventPackageHeader> pEventPackageHeaderList)
        {
            string _packageID = "";

            try
            {
                loEventPackageDAO = new EventPackageDAO();
                _packageID = loEventPackageDAO.saveEventPackage(poEventPackageHeader);

                poEventPackageHeader.PackageID = int.Parse(_packageID);
                pEventPackageHeaderList.Add(poEventPackageHeader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateEventPackage(EventPackageHeader poEventPackageHeader, ref GenericList<EventPackageHeader> pEventPackageHeaderList)
        {
            try
            {
                loEventPackageDAO = new EventPackageDAO();
                loEventPackageDAO.updateEventPackage(poEventPackageHeader);

                foreach (EventPackageHeader _oEventPackageHeader in pEventPackageHeaderList)
                {
                    if (_oEventPackageHeader.PackageID == poEventPackageHeader.PackageID)
                    {
                        _oEventPackageHeader.DaysApplied = poEventPackageHeader.DaysApplied;
                        _oEventPackageHeader.Description = poEventPackageHeader.Description;
                        _oEventPackageHeader.EventType = poEventPackageHeader.EventType;
                        _oEventPackageHeader.PackageAmount = poEventPackageHeader.PackageAmount;
                        _oEventPackageHeader.MaximumPax = poEventPackageHeader.MaximumPax;
                        _oEventPackageHeader.MinimumPax = poEventPackageHeader.MinimumPax;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEventPackage(string pPackageID, ref GenericList<EventPackageHeader> pEventPackageHeaderList)
        {
            try
            {
                loEventPackageDAO = new EventPackageDAO();
                loEventPackageDAO.deleteEventPackage(pPackageID);

                foreach (EventPackageHeader _oEventPackageHeader in pEventPackageHeaderList)
                {
                    if (int.Parse(pPackageID) == _oEventPackageHeader.PackageID)
                    {
                        pEventPackageHeaderList.Remove(_oEventPackageHeader);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenericList<EventPackageHeader> getEventPackages()
        {
            GenericList<EventPackageHeader> _eventPackageHeaderList = new GenericList<EventPackageHeader>();
            loEventPackageDAO = new EventPackageDAO();
            DataTable _dataTable = loEventPackageDAO.getEventPackages();

            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventPackageHeader _oEventPackageHeader = new EventPackageHeader();
                _oEventPackageHeader.DaysApplied = int.Parse(_dataRow["daysApplied"].ToString());
                _oEventPackageHeader.Description = _dataRow["description"].ToString();
                _oEventPackageHeader.EventType = _dataRow["eventType"].ToString();
                _oEventPackageHeader.PackageAmount = double.Parse(_dataRow["packageAmount"].ToString());
                _oEventPackageHeader.PackageID = int.Parse(_dataRow["packageID"].ToString());
                _oEventPackageHeader.MinimumPax = int.Parse(_dataRow["MinimumPax"].ToString());
                _oEventPackageHeader.MaximumPax = int.Parse(_dataRow["MaximumPax"].ToString());

                _eventPackageHeaderList.Add(_oEventPackageHeader);
            }

            return _eventPackageHeaderList;
        }

        public EventPackageHeader getEventPackage(string pPackageID)
        {
            loEventPackageDAO = new EventPackageDAO();
            DataTable _dataTable = loEventPackageDAO.getEventPackage(pPackageID);

            EventPackageHeader _oEventPackageHeader = new EventPackageHeader();
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                _oEventPackageHeader.DaysApplied = int.Parse(_dataRow["daysApplied"].ToString());
                _oEventPackageHeader.Description = _dataRow["description"].ToString();
                _oEventPackageHeader.EventType = _dataRow["eventType"].ToString();
                _oEventPackageHeader.PackageAmount = double.Parse(_dataRow["packageAmount"].ToString());
                _oEventPackageHeader.PackageID = int.Parse(_dataRow["packageID"].ToString());
                _oEventPackageHeader.MinimumPax = int.Parse(_dataRow["MinimumPax"].ToString());
                _oEventPackageHeader.MaximumPax = int.Parse(_dataRow["MaximumPax"].ToString());
            }

            return _oEventPackageHeader;
        }
    }
}
