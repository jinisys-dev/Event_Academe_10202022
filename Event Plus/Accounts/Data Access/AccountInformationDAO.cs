using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Accounts.DataAccessLayer
{
    public class AccountInformationDAO
    {
        private string lAccountID;
        private int lHotelID;
        private string lAffiliations;
        private string lOfficeOfficers;
        private string lNatureOfBusiness;
        private string lPillarsOfOrganization;
        private DateTime lAnniversary;

        private void loadAttributes(Object poAccountInformation)
        {
            try
            {
                lAccountID = poAccountInformation.GetType().GetProperty("AccountID").GetValue(poAccountInformation, null).ToString();
                lHotelID = int.Parse(poAccountInformation.GetType().GetProperty("HotelID").GetValue(poAccountInformation, null).ToString());
                lAffiliations = poAccountInformation.GetType().GetProperty("Affiliations").GetValue(poAccountInformation, null).ToString();
                lOfficeOfficers = poAccountInformation.GetType().GetProperty("OfficeOfficers").GetValue(poAccountInformation, null).ToString();
                lNatureOfBusiness = poAccountInformation.GetType().GetProperty("NatureOfBusiness").GetValue(poAccountInformation, null).ToString();
                lPillarsOfOrganization = poAccountInformation.GetType().GetProperty("PillarsOfOrganization").GetValue(poAccountInformation, null).ToString();
                lAnniversary = DateTime.Parse(poAccountInformation.GetType().GetProperty("Anniversary").GetValue(poAccountInformation, null).ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.loadAttributes\r\n" + ex.Message);
            }
        }

        public void save(Object poAccountInformation, ref MySqlTransaction pTrans)
        {
            loadAttributes(poAccountInformation);
            MySqlCommand _save = new MySqlCommand("call spInsertAccountInformation('" + lAccountID + "','" + lHotelID + "','" + lAffiliations + "','" + lOfficeOfficers + "','" + lNatureOfBusiness + "','" + lPillarsOfOrganization + "','" + string.Format("{0:yyyy-MM-dd}", lAnniversary) + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _save.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ AccountInformationDAO.save\r\n" + ex.Message);
            }
            finally
            {
                _save.Dispose();
            }
        }

        public void update(Object poAccountInformation, ref MySqlTransaction pTrans)
        {
            loadAttributes(poAccountInformation);
            MySqlCommand _update = new MySqlCommand("call spUpdateAccountInformation('" + lAccountID + "','" + lHotelID + "','" + lAffiliations + "','" + lOfficeOfficers + "','" + lNatureOfBusiness + "','" + lPillarsOfOrganization + "','" + string.Format("{0:yyyy-MM-dd}", lAnniversary) + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @AccountInformationDAO.update\r\n" + ex.Message);
            }
            finally
            {
                _update.Dispose();
            }
        }

        public DataTable getAccountInformation(string pAccountID, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetAccountInformation('" + pAccountID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @AccountInformationDAO.getAccountInformation\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
    }
}
