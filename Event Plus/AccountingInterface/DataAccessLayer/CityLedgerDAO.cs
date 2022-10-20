using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.AccountingInterface.BusinessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;

using System.Data;

namespace Jinisys.Hotel.AccountingInterface.DataAccessLayer
{
    class CityLedgerDAO
    {
        public CityLedgerDAO()
        { }


        public bool insertCityLedger(CityLeger pCityLedger)
        {
            try
            {
				string _sqlStr = "call spInsertCityLedger('" + pCityLedger.AcctID + "','"
															+ pCityLedger.Date + "','"
															+ pCityLedger.Refno + "','"
															+ pCityLedger.Debit + "','"
															+ pCityLedger.Credit + "','"
															+ pCityLedger.RefFolio + "','"
															+ pCityLedger.SubFolio + "','"
															+ GlobalVariables.gHotelId + "','"
															+ GlobalVariables.gLoggedOnUser
														  + "')";

                MySqlCommand _insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                _insertCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
				string _errMessage = "Transaction failed.\r\nException: " + ex.Message;

				MessageBox.Show(_errMessage, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool insertCityLedgerPayment(string pAccountid, 
										    string pDate, 
											string pRefNo, 
											string pMemo, 
											double pAmountPaid, 
											double pWithHoldingTax, 
											double pDebit, 
											double pCredit)
        {
            try
            {
                string _strSql = "call spInsertPaymentLedger('" + pAccountid + "','" 
																+ pDate + "','" 
																+ pRefNo + "','" 
																+ pMemo + "','" 
																+ pAmountPaid + "','" 
																+ pWithHoldingTax + "','" 
																+ pDebit + "','" 
																+ pCredit + "','','','" 
																+ GlobalVariables.gHotelId + "','" 
																+ GlobalVariables.gLoggedOnUser 
															 + "')";

                MySqlCommand _insertCommand = new MySqlCommand(_strSql, GlobalVariables.gPersistentConnection);
                _insertCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
				string _errMessage = "Transaction failed.\r\nException: " + ex.Message;

				MessageBox.Show( _errMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }
        }

        public DataTable getCityLedgerAccounts()
        {
            try
            {
                DataTable _dtCityLedger = new DataTable("CityLedger");

                string _strSql = "call spReportCityLedger('" + GlobalVariables.gHotelId + "')";

                MySqlDataAdapter _dtAdapter = new MySqlDataAdapter( _strSql, 
																	GlobalVariables.gPersistentConnection);
                _dtAdapter.Fill(_dtCityLedger);

                return _dtCityLedger;
            }
            catch (Exception ex)
            {
				string _errMessage = "Transaction failed.\r\nException: " + ex.Message;

				MessageBox.Show(_errMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet populateCityLedgerDataset()
        {
            DataSet _dsCityLedger = new DataSet("CityLedgerDataset");

			/* 
			 * Get City Ledger Summary per Company
			 */
			DataTable _dtCityLedger = new DataTable("CityLedgers");

			string _strSql = "call spGetCityLedgerSummary()";
            MySqlDataAdapter _daCityLedger = new MySqlDataAdapter( _strSql, 
																   GlobalVariables.gPersistentConnection);

            
            _daCityLedger.Fill(_dtCityLedger);

            DataColumn[] _primary = new DataColumn[1];
            _primary[0] = _dtCityLedger.Columns[0];
            _dtCityLedger.PrimaryKey = _primary;
            _dsCityLedger.Tables.Add(_dtCityLedger);
            
			/* 
			 * Get City Ledger Details per Company
			 * 
			 * TODO: _strSql should be replaced to Stored Procedure
			 */
			DataTable _dtCityLedgerDetails = new DataTable("CityLedgerDetails");

            _strSql = "Select CityLedger.*,if(FGetGuestNameByFolioID(reffolio) is null, 'WALK IN', FGetGuestNameByFolioID(reffolio)) as `Name` from CityLedger where closed=0";
			_daCityLedger = new MySqlDataAdapter(_strSql, 
												 GlobalVariables.gPersistentConnection);

			_daCityLedger.Fill(_dtCityLedgerDetails);

            DataColumn[] _primaryDetails = new DataColumn[1];
            _primaryDetails[0] = _dtCityLedgerDetails.Columns[0];
            _dtCityLedgerDetails.PrimaryKey = _primaryDetails;
            _dsCityLedger.Tables.Add(_dtCityLedgerDetails);

			// Add Data Relationship between City Ledger and its Detail
            DataRelation _dtRelCityLedgerSummaryDetals = new DataRelation("CityLedgerSummaryDetals", _dtCityLedger.Columns[0], _dtCityLedgerDetails.Columns[1]);
            _dsCityLedger.Relations.Add(_dtRelCityLedgerSummaryDetals);

            
			/* Payment Ledger
			 * Get City Ledger Payments Details
			 * 
			 * TODO: _strSql should be replaced to Stored Procedure
			 */
			DataTable _dtPayments = new DataTable("PaymentLedger");

			_strSql = "Select  `id` ,`AcctID`,`Date`,'PAYMENT' as Name,Memo,AmountPaid,WithHoldingTax ,`refno`,`debit`,`credit`,`reffolio` ,`subfolio` ,`HOTELID`,FGetGuestNameByFolioID(`reffolio`)  from PaymentLedger where closed=0";
            _daCityLedger = new MySqlDataAdapter( _strSql ,
												  GlobalVariables.gPersistentConnection);

			_daCityLedger.Fill(_dtPayments);

			// define Primary Key in Payments DataTable
            DataColumn[] _primaryKeyPayments = new DataColumn[1];
            _primaryKeyPayments[0] = _dtPayments.Columns[0];
            _dtPayments.PrimaryKey = _primaryKeyPayments;
            _dsCityLedger.Tables.Add(_dtPayments);

			// add Data Relationship to city ledger payments
            DataRelation CityLedgerPayments = new DataRelation("CityLedgerPayments", _dtCityLedger.Columns[0], _dtPayments.Columns[1]);

            try
            {
                _dsCityLedger.Relations.Add(CityLedgerPayments);
            }
            catch { }

            return _dsCityLedger;

        }

        public bool closeAccount(string pAccountId)
        {
            MySqlTransaction _trans = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
            {
                string _sqlStr = "call spCloseCityLedgerAccount('" + pAccountId + "','" 
																   + GlobalVariables.gHotelId 
																+ "')";


				MySqlCommand _cmdCloseCityLedger = new MySqlCommand( _sqlStr, 
																	 GlobalVariables.gPersistentConnection);
                _cmdCloseCityLedger.Transaction = _trans;
                _cmdCloseCityLedger.ExecuteNonQuery();

				_sqlStr = "call spClosePaymentLedgerAccount('" + pAccountId + "','" 
															   + GlobalVariables.gHotelId 
															+ "')";

				MySqlCommand _cmdClosePaymentLedger = new MySqlCommand( _sqlStr, 
																		GlobalVariables.gPersistentConnection);
                _cmdCloseCityLedger.Transaction = _trans;
                _cmdCloseCityLedger.ExecuteNonQuery();


                _trans.Commit();
                return true;


            }
            catch (Exception ex)
            {
				string _errMessage = "Transaction failed.\r\nException: " + ex.Message;

                MessageBox.Show(_errMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _trans.Rollback();
                return false;
            }
        }

    }


}
