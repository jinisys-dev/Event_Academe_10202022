using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class EventContactDAO
    {
        private string lContactID;
        private string lLastName;
        private string lFirstName;
        private string lMiddleName;
        private string lDesignation;
        private string lPersonType;
        private string lAddress;
        private string lTelNo;
        private string lMobileNo;
        private string lFaxNo;
        private string lEmail;
        private string lFolioID;
        private string lAccountID;
        private string lHotelID;
        private DateTime lBirthDate;
        private ContactPersonDAO oContactPerson = new ContactPersonDAO();
        private void loadAttributes(Object poContactPerson)
        {
            try
            {
                lContactID = poContactPerson.GetType().GetProperty("ContactID").GetValue(poContactPerson, null).ToString();
                lLastName = poContactPerson.GetType().GetProperty("LastName").GetValue(poContactPerson, null).ToString();
                lFirstName = poContactPerson.GetType().GetProperty("FirstName").GetValue(poContactPerson, null).ToString();
                lMiddleName = poContactPerson.GetType().GetProperty("MiddleName").GetValue(poContactPerson, null).ToString();
                lDesignation = poContactPerson.GetType().GetProperty("Designation").GetValue(poContactPerson, null).ToString();
                lPersonType = poContactPerson.GetType().GetProperty("PersonType").GetValue(poContactPerson, null).ToString();
                lAddress = poContactPerson.GetType().GetProperty("Address").GetValue(poContactPerson, null).ToString();
                lTelNo = poContactPerson.GetType().GetProperty("TelNo").GetValue(poContactPerson, null).ToString();
                lMobileNo = poContactPerson.GetType().GetProperty("MobileNo").GetValue(poContactPerson, null).ToString();
                lFaxNo = poContactPerson.GetType().GetProperty("FaxNo").GetValue(poContactPerson, null).ToString();
                lEmail = poContactPerson.GetType().GetProperty("Email").GetValue(poContactPerson, null).ToString();
                lFolioID = poContactPerson.GetType().GetProperty("FolioID").GetValue(poContactPerson, null).ToString();
                lAccountID = poContactPerson.GetType().GetProperty("AccountID").GetValue(poContactPerson, null).ToString();
                lHotelID = poContactPerson.GetType().GetProperty("HotelID").GetValue(poContactPerson, null).ToString();
                lBirthDate = DateTime.Parse(poContactPerson.GetType().GetProperty("BirthDate").GetValue(poContactPerson, null).ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.loadAttributes\r\n" + ex.Message);
            }
        }

        public void save(Object obj, ref MySqlTransaction pTrans)
        {
            loadAttributes(obj);
            lContactID = oContactPerson.save(obj, ref pTrans);
            MySqlCommand _save = new MySqlCommand("call spInsertEventContact('" + lContactID + "','" + lFolioID + "','" + lHotelID + "','" + lAccountID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _save.Transaction = pTrans;
                _save.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventContactDAO.save\r\n" + ex.Message);
            }
            finally
            {
                _save.Dispose();
            }
        }

        public void update(Object obj, ref MySqlTransaction pTrans)
        {
            loadAttributes(obj);
            // Review for SP
            oContactPerson.update(obj, ref pTrans);
            MySqlCommand _update = new MySqlCommand("call spInsertEventContact('" + lContactID + "','" + lFolioID + "','" + lHotelID + "','" + lAccountID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _update.Transaction = pTrans;
                _update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventContactDAO.update\r\n" + ex.Message);
            }
            finally
            {
                _update.Dispose();
            }
        }

        public void deleteEventContacts(string pFolioID, ref MySqlTransaction pTrans)
        {
            MySqlCommand _delete = new MySqlCommand("call spDeleteEventContact('" + pFolioID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _delete.Transaction = pTrans;
                _delete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventContactDAO.deleteEventContacts\r\n" + ex.Message);
            }
            finally
            {
                _delete.Dispose();
            }
        }

        public DataTable getEventContacts(string pFolioID, string pAccountID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventContacts('" + pFolioID + "','" + GlobalVariables.gHotelId + "','" + pAccountID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventContactDAO.getEventContacts\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
    }
}
