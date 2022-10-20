using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Accounts.DataAccessLayer
{
    class IncumbentOfficerDAO
    {
        private string lContactID;
        private string lLastName;
        private string lFirstName;
        private string lFolioID;
        private string lHotelID;
        private string lDesignation;
        private string lEmail;
        private DateTime lBirthDate;
        private string lMobileNo;
        private string lTelNo;
        private string lFaxNo;

        private void loadAttributes(Object poIncumbentOfficer)
        {
            try
            {
                lContactID = poIncumbentOfficer.GetType().GetProperty("ContactID").GetValue(poIncumbentOfficer, null).ToString();
                lLastName = poIncumbentOfficer.GetType().GetProperty("LastName").GetValue(poIncumbentOfficer, null).ToString();
                lFirstName = poIncumbentOfficer.GetType().GetProperty("FirstName").GetValue(poIncumbentOfficer, null).ToString();
                lHotelID = poIncumbentOfficer.GetType().GetProperty("HotelID").GetValue(poIncumbentOfficer, null).ToString();
                lFolioID = poIncumbentOfficer.GetType().GetProperty("FolioID").GetValue(poIncumbentOfficer, null).ToString();
                lDesignation = poIncumbentOfficer.GetType().GetProperty("Designation").GetValue(poIncumbentOfficer, null).ToString();
                lEmail = poIncumbentOfficer.GetType().GetProperty("Email").GetValue(poIncumbentOfficer, null).ToString();
                lBirthDate = DateTime.Parse(poIncumbentOfficer.GetType().GetProperty("BirthDate").GetValue(poIncumbentOfficer, null).ToString());
                lMobileNo = poIncumbentOfficer.GetType().GetProperty("MobileNo").GetValue(poIncumbentOfficer, null).ToString();
                lTelNo = poIncumbentOfficer.GetType().GetProperty("TelNo").GetValue(poIncumbentOfficer, null).ToString();
                lFaxNo = poIncumbentOfficer.GetType().GetProperty("FaxNo").GetValue(poIncumbentOfficer, null).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @IncumbentOfficerDAO.loadAttributes\r\n" + ex.Message);
            }
        }


        public void save(Object poIncumbentOfficer, ref MySqlTransaction pTrans)
        {
            loadAttributes(poIncumbentOfficer);
            MySqlCommand _command;
            string _contactID = lContactID;
            try
            {
                if (lContactID == "AUTO")
                {
                    _command = new MySqlCommand("call spInsertContactPerson('" + lLastName + "','" + lFirstName + "','','" + lDesignation + "','IncumbentOfficer','','" + lTelNo + "','" + lMobileNo + "','" + lFaxNo + "','" + lEmail + "','" + lFolioID + "','','" + lHotelID + "', '" + GlobalVariables.gLoggedOnUser + "', '" + string.Format("{0:yyyy-MM-dd}", lBirthDate) + "')", GlobalVariables.gPersistentConnection);
                    _command.Transaction = pTrans;
                    _contactID = _command.ExecuteScalar().ToString();
                }
                else
                {
                    _command = new MySqlCommand("call spUpdateContactPerson('" + lContactID + "','" + lLastName + "','" + lFirstName + "','','" + lDesignation + "','IncumbentOfficer','','" + lTelNo + "','" + lMobileNo + "','" + lFaxNo + "','" + lEmail + "','" + lFolioID + "','','" + lHotelID + "', '" + GlobalVariables.gLoggedOnUser + "', '" + string.Format("{0:yyyy-MM-dd}", lBirthDate) + "')", GlobalVariables.gPersistentConnection);
                    _command.Transaction = pTrans;
                }
                _command = new MySqlCommand("call spInsertIncumbentOfficer('" + _contactID + "','" + lFolioID + "','" + lHotelID + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @IncumbentOfficerDAO.save\r\n" + ex.Message);
            }
        }
        public DataTable getIncumbentOfficers(string pFolioID, string pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetIncumbentOfficers('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ IncumbentOfficerDAO.getIncumbentOfficers\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
        public void deleteIncumbentOfficers(string pFolioID, string pHotelID, ref MySqlTransaction pTrans)
        {
            MySqlCommand _command = new MySqlCommand("call spDeleteIncumbentOfficers('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ IncumbentOfficerDAO.deleteIncumbentOfficers\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }
    }
}
