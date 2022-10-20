using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;
namespace Jinisys.Hotel.Accounts.DataAccessLayer
{
    public class ContactPersonDAO
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
        public DataTable getContactPersons(string pFolioID, int pHotelID, string pAccountID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetContactPersons('" + pFolioID + "','" + pHotelID.ToString() + "','" + pAccountID + "')", GlobalVariables.gPersistentConnection);
            
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.getContactPersons\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
            return null;

        }

        public DataTable getContactPersons(string pAccountID, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetAccountContacts('" + pAccountID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.getContactPersons\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public string save(Object obj , ref MySqlTransaction pTrans)
        {
            this.loadAttributes(obj);
            MySqlCommand _command = new MySqlCommand("call spInsertContactPerson('" + lLastName + 
                                                                                "','" + lFirstName +
                                                                                "','" + lMiddleName +
                                                                                "','" + lDesignation +
                                                                                "','" + lPersonType +
                                                                                "','" + lAddress +
                                                                                "','" + lTelNo +
                                                                                "','" + lMobileNo +
                                                                                "','" + lFaxNo +
                                                                                "','" + lEmail +
                                                                                "','" + lFolioID +
                                                                                "','" + lAccountID +
                                                                                "','" + lHotelID +
                                                                                "','" + GlobalVariables.gLoggedOnUser +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lBirthDate) +
                                                                                "')",GlobalVariables.gPersistentConnection);
            try
            {
                _command.Transaction = pTrans;
                Object _obj = _command.ExecuteScalar();
                try
                {
                    return _obj.ToString();
                }
                catch
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.save()\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }

        public void update(Object obj, ref MySqlTransaction pTrans)
        {
            this.loadAttributes(obj);
            MySqlCommand _update = new MySqlCommand("call spUpdateContactPerson('" + lContactID +
                                                                                "','" + lLastName + 
                                                                                "','" + lFirstName +
                                                                                "','" + lMiddleName +
                                                                                "','" + lDesignation +
                                                                                "','" + lPersonType +
                                                                                "','" + lAddress +
                                                                                "','" + lTelNo +
                                                                                "','" + lMobileNo +
                                                                                "','" + lFaxNo +
                                                                                "','" + lEmail +
                                                                                "','" + lFolioID +
                                                                                "','" + lAccountID +
                                                                                "','" + lHotelID +
                                                                                "','" + GlobalVariables.gLoggedOnUser +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lBirthDate) +
                                                                                "')",GlobalVariables.gPersistentConnection);
            try
            {
                _update.Transaction = pTrans;
                _update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.update\r\n" + ex.Message);
            }
            finally
            {
                _update.Dispose();
            }
        }   

        public void deleteContactPersons(string pAccountID, string pHotelID, ref MySqlTransaction pTrans)
        {
            MySqlCommand _command = new MySqlCommand("call spDeleteContactPersons('" + pAccountID +"','" + pHotelID +"','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ ContactPersonDAO.deleteContactPersons\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }

        public DataTable getPersonType()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetGroupBookingDropDown()", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                if (_dt.Rows.Count > 0)
                {
                    DataView _oDataView = _dt.DefaultView;
                    _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                    _oDataView.RowFilter = "fieldname = 'PersonType'";
                    _dt = _oDataView.ToTable();
                }
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.getPersonType\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
            
        }
    }
}
