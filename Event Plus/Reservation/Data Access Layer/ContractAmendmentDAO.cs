using System;
using MySql.Data;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class ContractAmendmentDAO
    {
        public ContractAmendmentDAO()
        { }

        public void saveAmendment(ref ContractAmendments _oAmendments)
        {
            MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
            {
                string strQuery = "call spInsertContractAmendment('" +
                    _oAmendments.AmendmentID + "','" +
                    _oAmendments.FolioID + "','" +
                    _oAmendments.OldValue + "','" +
                    _oAmendments.NewValue + "','" +
                    GlobalVariables.gLoggedOnUser + "'," +
                    GlobalVariables.gHotelId + ")";

                MySqlCommand cmdInsert = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
                cmdInsert.Transaction = _oTrans;
                int ID = int.Parse(cmdInsert.ExecuteScalar().ToString());
                _oAmendments.ID = ID;

                _oTrans.Commit();
            }
            catch (Exception ex)
            {
                _oTrans.Rollback();
                MessageBox.Show("Error in saving amendments.\r\nError message : " + ex.Message, "Folio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable getAmendments(string pFolioID)
        {
            try
            {
                string strQuery = "select * from ContractAmmendments where HotelID=" + GlobalVariables.gHotelId + " and FolioID = '" + pFolioID + "' and StateFlag!='DELETED'";
                DataTable dtTable = new DataTable("Amendments");
                MySqlDataAdapter dtAdapter = new MySqlDataAdapter(strQuery, GlobalVariables.gPersistentConnection);
                dtAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting amendments.\r\nError msg : " + ex.Message);
            }
        }

        public bool deleteAmendment(string ID)
        {
            try
            {
                string strQuery = "call spDeleteContractAmendment('" + ID + "')";
                MySqlCommand cmdDelete = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
                cmdDelete.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting amendment.\r\nError msg : " + ex.Message);
            }
        }

        public bool deleteAmendments(string pAmendmentID, string pFolioID)
        {
            try
            {
                string strQuery = "call spDeleteContractAmendments('" + pAmendmentID + "','" + pFolioID + "')";
                MySqlCommand cmdDelete = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
                cmdDelete.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting amendments.\r\nError msg : " + ex.Message);
            }
        }
    }
}
