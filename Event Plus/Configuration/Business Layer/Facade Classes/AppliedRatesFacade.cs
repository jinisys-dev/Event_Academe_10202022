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
    public class AppliedRatesFacade
    {
        public AppliedRatesFacade()
        { }

        private AppliedRatesDAO loAppliedRatesDAO;
        public void saveAppliedRates(AppliedRates poAppliedRates, ref GenericList<AppliedRates> pAppliedRatesList)
        {
            string _rateID = "";
            try
            {
                loAppliedRatesDAO = new AppliedRatesDAO();
                _rateID = loAppliedRatesDAO.saveAppliedRates(poAppliedRates);

                poAppliedRates.AppliedRateID = int.Parse(_rateID);
                pAppliedRatesList.Add(poAppliedRates);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateAppliedRates(AppliedRates poAppliedRates, ref GenericList<AppliedRates> pAppliedRatesList)
        {
            try
            {
                loAppliedRatesDAO = new AppliedRatesDAO();
                loAppliedRatesDAO.updateAppliedRates(poAppliedRates);

                foreach (AppliedRates _oAppliedRate in pAppliedRatesList)
                {
                    if (_oAppliedRate.AppliedRateID == poAppliedRates.AppliedRateID)
                    {
                        _oAppliedRate.Description = poAppliedRates.Description;
                        _oAppliedRate.NumberOfOccupants = poAppliedRates.NumberOfOccupants;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteAppliedRates(string appliedRateID, ref GenericList<AppliedRates> pAppliedRatesList)
        {
            try
            {
                loAppliedRatesDAO = new AppliedRatesDAO();
                loAppliedRatesDAO.deleteAppliedRate(appliedRateID);

                foreach (AppliedRates _oAppliedRate in pAppliedRatesList)
                {
                    if (_oAppliedRate.AppliedRateID == int.Parse(appliedRateID))
                    {
                        pAppliedRatesList.Remove(_oAppliedRate);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenericList<AppliedRates> getAppliedRates()
        {
            GenericList<AppliedRates> _appliedRatesList = new GenericList<AppliedRates>();
            loAppliedRatesDAO = new AppliedRatesDAO();
            DataTable _dtAppliedRates = loAppliedRatesDAO.getAppliedRates();

            foreach (DataRow _dataRow in _dtAppliedRates.Rows)
            {
                AppliedRates _oAppliedRates = new AppliedRates();
                _oAppliedRates.AppliedRateID = int.Parse(_dataRow["appliedRateID"].ToString());
                _oAppliedRates.Description = _dataRow["description"].ToString();
                _oAppliedRates.NumberOfOccupants = int.Parse(_dataRow["noOfOccupants"].ToString());
                _oAppliedRates.RateType = _dataRow["rateType"].ToString();

                _appliedRatesList.Add(_oAppliedRates);
            }
            return _appliedRatesList;
        }
    }
}
