using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    class EventEndorsementDAO
    {
        private string lFolioID;
        private string lLetterOfProposal;
        private decimal lContractAmount;
        private DateTime lDueDate1;
        private DateTime lDueDate2;
        private DateTime lDueDate3;
        private string lLetterOfAgreement;
        private DateTime lPickupDate;
        private DateTime lSentToClientDate;
        private DateTime lSignedDate;
        private int lHotelID;
        private string lConcessions;
        private string lGiveaways;
        private string lRemarks;

        private void loadAttributes(Object poEventEndorsement)
        {
            try
            {
                lFolioID = poEventEndorsement.GetType().GetProperty("FolioID").GetValue(poEventEndorsement, null).ToString();
                lLetterOfProposal = poEventEndorsement.GetType().GetProperty("LetterOfProposal").GetValue(poEventEndorsement, null).ToString();
                lContractAmount = decimal.Parse(poEventEndorsement.GetType().GetProperty("ContractAmount").GetValue(poEventEndorsement, null).ToString());
                lDueDate1 = DateTime.Parse(poEventEndorsement.GetType().GetProperty("DueDate1").GetValue(poEventEndorsement, null).ToString());
                lDueDate2 = DateTime.Parse(poEventEndorsement.GetType().GetProperty("DueDate2").GetValue(poEventEndorsement, null).ToString());
                lDueDate3 = DateTime.Parse(poEventEndorsement.GetType().GetProperty("DueDate3").GetValue(poEventEndorsement, null).ToString());
                lLetterOfAgreement = poEventEndorsement.GetType().GetProperty("LetterOfAgreement").GetValue(poEventEndorsement, null).ToString();
                lPickupDate = DateTime.Parse(poEventEndorsement.GetType().GetProperty("PickupDate").GetValue(poEventEndorsement, null).ToString());
                lSentToClientDate = DateTime.Parse(poEventEndorsement.GetType().GetProperty("SentToClientDate").GetValue(poEventEndorsement, null).ToString());
                lSignedDate = DateTime.Parse(poEventEndorsement.GetType().GetProperty("SignedDate").GetValue(poEventEndorsement, null).ToString());
                lHotelID = int.Parse(poEventEndorsement.GetType().GetProperty("HotelID").GetValue(poEventEndorsement, null).ToString());
                lConcessions = poEventEndorsement.GetType().GetProperty("Concessions").GetValue(poEventEndorsement, null).ToString();
                lGiveaways = poEventEndorsement.GetType().GetProperty("Giveaways").GetValue(poEventEndorsement, null).ToString();
                lRemarks = poEventEndorsement.GetType().GetProperty("Remarks").GetValue(poEventEndorsement, null).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ContactPersonDAO.loadAttributes\r\n" + ex.Message);
            }
        }

        public void save(Object obj, ref MySqlTransaction pTrans)
        {
            loadAttributes(obj);
            MySqlCommand _command = new MySqlCommand("call spInsertEventEndorsement('" + lFolioID +
                                                                                "','" + lLetterOfProposal +
                                                                                "','" + string.Format("{0:#####0.#0}",lContractAmount) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lDueDate1) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lDueDate2) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lDueDate3) +
                                                                                "','" + lLetterOfAgreement +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lPickupDate) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lSentToClientDate) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}",lSignedDate) +
                                                                                "','" + lHotelID.ToString() +
                                                                                "','" + lConcessions +
                                                                                "','" + lGiveaways +
                                                                                "','" + lRemarks +
                                                                                "','" + GlobalVariables.gLoggedOnUser + "')" , GlobalVariables.gPersistentConnection);

            try
            {
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw new Exception("Error @EventEndorsementDAO.save\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }

        public void update(Object obj, ref MySqlTransaction pTrans)
        {
            loadAttributes(obj);
            MySqlCommand _command = new MySqlCommand("call spUpdateEventEndorsement('" + lFolioID +
                                                                                "','" + lLetterOfProposal +
                                                                                "','" + string.Format("{0:#####0.#0}", lContractAmount) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}", lDueDate1) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}", lDueDate2) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}", lDueDate3) +
                                                                                "','" + lLetterOfAgreement +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}", lPickupDate) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}", lSentToClientDate) +
                                                                                "','" + string.Format("{0:yyyy-MM-dd}", lSignedDate) +
                                                                                "','" + lHotelID.ToString() +
                                                                                "','" + lConcessions +
                                                                                "','" + lGiveaways +
                                                                                "','" + lRemarks + 
                                                                                "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);

            try
            {
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventEndorsementDAO.update\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }

        public DataTable getEventEndorsement(string pFolioID, string pHotelID)
        {
            DataTable _dt = new DataTable();

            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventEndorsement('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventEndorsementDAO.getEventEndorsement\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public void saveEMDAction(string pFolioID, string pAction, int pHotelID, ref MySqlTransaction pTrans)
        {
            MySqlCommand _command = new MySqlCommand("call spInsertEventEMDAction('" + pFolioID + "','" + pAction + "','" + pHotelID.ToString() + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventEndorsementDAO.saveEMDAction\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }

        public void deleteEMDActions(string pFolioID, int pHotelID, ref MySqlTransaction pTrans)
        {
            MySqlCommand _command = new MySqlCommand("call spDeleteEventEMDAction('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventEndorsementDAO.deleteEMDActions\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }
        public DataTable getEMDActions(string pFolioID, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventEMDActions('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventEndorsementDAO.getEMDActions\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
    }
}
