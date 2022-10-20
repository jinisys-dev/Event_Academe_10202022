using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.NightAudit.DataAccessLayer
{
    public class PostRoomChargesDAO
    {


        public PostRoomChargesDAO()
        {

        }

        // >> Get All Rooms OCCUPIED
        public DataTable GetRoomsToCharge(DateTime postingDate)
        {
            DataTable dtRoomCharge = new DataTable();
            try
            {
                string _query = "";
                if (bool.Parse(ConfigVariables.gPostRoomChargeForFunctionRoom) == true)
                {
                    _query = "call spGetRoomsToCharge('" + string.Format("{0:yyyy-MM-dd}", postingDate) + "','" + GlobalVariables.gHotelId + "')";
                }
                else
                {
                    _query = "call spGetIndividualRoomsToCharge('" + string.Format("{0:yyyy-MM-dd}", postingDate) + "','" + GlobalVariables.gHotelId + "')";
                }

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(dtRoomCharge);
                dataAdapter.Dispose();

                return dtRoomCharge;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetRoomsToCharge() " + ex.Message);
                return null;
            }
            finally
            {
                dtRoomCharge.Dispose();
            }
        }

        //>>get all folios to be charged that has no rooms
        public DataTable getFoliosToCharge(DateTime postingDate)
        {
            DataTable dtFolioCharge = new DataTable();
            try
            {
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter("call spGetFoliosToCharge('" + string.Format("{0:yyyy-MM-dd}", postingDate) + "'," + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                _dataAdapter.Fill(dtFolioCharge);
                _dataAdapter.Dispose();

                return dtFolioCharge;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetRoomToCharge() " + ex.Message);
                return null;
            }
            finally
            {
                dtFolioCharge.Dispose();
            }
        }

        public DataTable GetRoomsToCharge(DateTime postingDate, string folioID)
        {
            DataTable dtRoomCharge = new DataTable();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetRoomToCharge('" + string.Format("{0:yyyy-MM-dd}", postingDate) + "','" + GlobalVariables.gHotelId + "','" + folioID + "')", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(dtRoomCharge);
                dataAdapter.Dispose();

                return dtRoomCharge;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetRoomToCharge() " + ex.Message);
                return null;
            }
            finally
            {
                dtRoomCharge.Dispose();
            }
        }

        // >> Get "Room Charge" transactioncode
        private Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode oTranCode;
        public Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode GetRoomChargeTranCode()
        {
            try
            {
                oTranCode = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode();

				string _sqlStr = "call spGetRoomChargeTranCode('" + 
									   GlobalVariables.gHotelId 
									   + "')";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(oTranCode, "TranCode");
                dataAdapter.Dispose();

				DataTable _dtTemp = oTranCode.Tables[0];
				DataRow _dRow = _dtTemp.Rows[0];

				oTranCode.TranCode = _dRow["tranCode"].ToString();
				oTranCode.TranTypeId = _dRow["tranTypeId"].ToString();
				oTranCode.Memo = _dRow["memo"].ToString();
				oTranCode.AcctSide = _dRow["acctSide"].ToString();
				oTranCode.ServiceCharge = decimal.Parse( _dRow["serviceCharge"].ToString() );
				oTranCode.ServiceChargeInclusive = int.Parse( _dRow["serviceChargeInclusive"].ToString() );
				oTranCode.GovtTax = decimal.Parse( _dRow["govtTax"].ToString() );
				oTranCode.GovtTaxInclusive = int.Parse( _dRow["govtTaxInclusive"].ToString() );
				oTranCode.LocalTax = decimal.Parse( _dRow["localTax"].ToString() );
				oTranCode.LocalTaxInclusive = int.Parse( _dRow["localTaxInclusive"].ToString() );
				oTranCode.DefaultTransactionSource = _dRow["defaultTransactionSource"].ToString();
				oTranCode.DefaultAmount = decimal.Parse( _dRow["defaultAmount"].ToString() );
				oTranCode.WarningAmount = decimal.Parse( _dRow["warningAmount"].ToString() );
				oTranCode.DepartmentId = _dRow["departmentId"].ToString();
				oTranCode.Ledger = _dRow["ledger"].ToString();
				oTranCode.DebitSide = _dRow["debitSide"].ToString();
				oTranCode.CreditSide = _dRow["creditSide"].ToString();
				
                return oTranCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetRoomChargeTranCode()" + ex.Message);
                return null;
            }
        }

        public void SetRoomAsCharged(string Room, DateTime postingDate)
        {
            MySqlCommand updateCommand;

            try
            {
                updateCommand = new MySqlCommand("call spSetRoomAsCharged('" + Room + "','" + string.Format("{0:yyyy-MM-dd}", postingDate) + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                updateCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @ SetRoomAsCharged()" + ex.Message);
            }
        }

        public DataTable getChargedRecurringCharges(string pFolioID, DateTime pPostingDate, string pTransactionCode)
        {
            try
            {
                DataTable _dataTable = new DataTable();
                string _sql = "call spGetChargedRecurringCharges('" + pFolioID + "'," + GlobalVariables.gHotelId + ",'" + string.Format("{0:yyyy-MM-dd}", pPostingDate) + "','" + pTransactionCode + "')";
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);

                _dataAdapter.Fill(_dataTable);
                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getNonAuditCharges(string pFolioId)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetFolioTransactionsNonAuditCharges('" + pFolioId + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool postFolioTransactions(string pFolioId)
        {
            try
            {
                MySqlCommand _update = new MySqlCommand("call spSetTransactionsToAudit(" + GlobalVariables.gHotelId + ",'" + pFolioId + "')", GlobalVariables.gPersistentConnection);
                try
                {
                    int _rowsAffected = _update.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _update.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool isFromPackageAndIsPosted(string folioid, string transactionCode, string memo, string date)
        {
            try
            {
                DataTable _isPosted = new DataTable();
                string sql = "select *, packagePosted from foliorecurringcharge, event_booking_info where foliorecurringcharge.folioid='" + folioid + "' and transactioncode='" + transactionCode +
                    "' and memo ='" + memo + "' and '" + date + "'>=date(fromdate) and '" + date + "'<=date(todate) and packageid!=0 and foliorecurringcharge.folioid=event_booking_info.folioid and packageposted!=0";
                MySqlDataAdapter _adapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                _adapter.Fill(_isPosted);

                if (_isPosted.Rows.Count > 0 && _isPosted != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getGroupRecurringCharges()
        {
            try
            {
                DataTable dataTableRecurringCharges = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectGroupFolioRecurringCharges('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

                dataAdapter.Fill(dataTableRecurringCharges);


                return dataTableRecurringCharges;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Group Recurring Charges Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }


        // >> Get share folio
        public ArrayList getShareFolioIds(string a_MasterFolioId )
        {
            DataTable shares = new DataTable();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetShareFolioIds('" + a_MasterFolioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(shares);
                dataAdapter.Dispose();

                ArrayList folioIds = new ArrayList();
                foreach (DataRow dtRow in shares.Rows)
                { 
                    folioIds.Add(dtRow["FolioId"]);
                }

                return folioIds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getShareFolioIds() " + ex.Message);
                return null;
            }
        }


        public bool PostFolioTransactions(string a_gAuditDate)
        {
            try
            {

                MySqlCommand updateFolioTransactions = new MySqlCommand("call spSetFolioTransactionToAudited('" + a_gAuditDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                updateFolioTransactions.ExecuteNonQuery();


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PostFolioTransactions Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }


		// GET ROOMS to be TRANSFERRED
		public DataTable getRoomsToBeTransferred()
		{
			DataTable _tempData = new DataTable();

			try 
			{
				DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
				string _strNextAuditDate = string.Format("{0:yyyy-MM-dd}",_auditDate.AddDays(1));

				string _sqlStr = "call spGetRoomsToTransfer('" + 
					                   _strNextAuditDate + "')";

				MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtSelect.Fill(_tempData);


				return _tempData;

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		// GET ROOMS TRANSFER DESTINATION
		public DataTable getRoomsDestinationForTransfer()
		{
			DataTable _tempData = new DataTable();

			try
			{
				DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
				string _strNextAuditDate = string.Format("{0:yyyy-MM-dd}",_auditDate.AddDays(1));


				string _sqlStr = "call spGetRoomsDestinationForTransfer('" +
									   _strNextAuditDate + "')";

				MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtSelect.Fill(_tempData);


				return _tempData;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


    }
}