using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class FolioTransactionDAO
    {

        private ParameterHelper oParameterHelper;
        private FolioTransaction oFolioTransaction;
        private DataReaderToDatasetConverter oDatasetConverter;
        private DataReaderBinder oDataReaderBinder;

        public FolioTransactionDAO()
        {
            oParameterHelper = new ParameterHelper();
            oFolioTransaction = new FolioTransaction();
            oDatasetConverter = new DataReaderToDatasetConverter();
            oDataReaderBinder = new DataReaderBinder();
        }

        public FolioTransaction GetFolioTransactions()
        {
            try
            {
                FolioTransaction oFolioTransaction = new FolioTransaction();
                MySqlCommand getFolioTransCommand = new MySqlCommand("spSelectFolioTransactions", GlobalVariables.gPersistentConnection);
                getFolioTransCommand.CommandType = CommandType.StoredProcedure;
                MySqlDataReader getFolioTransReader = getFolioTransCommand.ExecuteReader();

                oDatasetConverter.convertDataReaderToDataSet(getFolioTransReader, "FolioTransactions", oFolioTransaction);
                getFolioTransReader.Close();
                return oFolioTransaction;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Folio Transactions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public FolioTransaction GetFolioTransactions(string pFolioID, DateTime pTranDate, string pTranCode)
        {
            try
            {
                FolioTransaction oFolioTransaction = new FolioTransaction();
                MySqlCommand getFolioTransCommand = new MySqlCommand("spGetFolioTransaction", GlobalVariables.gPersistentConnection);
                getFolioTransCommand.CommandType = CommandType.StoredProcedure;

                string transDate = string.Format("{0:yyyy-MM-dd hh:mm:ss tt}", pTranDate);

                MySqlParameter paramFolioID = new MySqlParameter();
                MySqlParameter paramtransactiondate = new MySqlParameter();
                MySqlParameter paramTranCode = new MySqlParameter();
                oParameterHelper.AddParameters(paramFolioID, "pFolioID", ParameterDirection.Input, DbType.String, pFolioID, getFolioTransCommand);
                oParameterHelper.AddParameters(paramtransactiondate, "ptransactiondate", ParameterDirection.Input, DbType.Date, transDate, getFolioTransCommand);
                oParameterHelper.AddParameters(paramTranCode, "pTranCode", ParameterDirection.Input, DbType.String, pTranCode, getFolioTransCommand);

                MySqlDataReader getFolioTransReader = getFolioTransCommand.ExecuteReader();

                Object tmp = oFolioTransaction;
                oDataReaderBinder.BinderReaderToEntity(getFolioTransReader, ref tmp);
                getFolioTransReader.Close();

                return oFolioTransaction;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Folio Transactions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public FolioTransaction GetFolioTransactions(string pFolioID, string pSubFolio, int pHotelId)
        {
            try
            {
                FolioTransaction _oFolioTransaction = new FolioTransaction();

				string _strQuery = "call spGetFolioTransactions('" + pFolioID 
														   + "','" + pSubFolio 
														   + "'," + pHotelId + ")";

				MySqlDataAdapter daFolioTransaction = new MySqlDataAdapter(_strQuery , GlobalVariables.gPersistentConnection);
				daFolioTransaction.Fill(_oFolioTransaction);
                
                return _oFolioTransaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Folio Transactions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public decimal GetCharges(string pFolioID)
        {
            try
            {
                MySqlCommand getChargeCommand = new MySqlCommand("CALL spGetCharges('" + pFolioID 
					                                           + "'," + GlobalVariables.gHotelId 
															   + ")", GlobalVariables.gPersistentConnection);

                getChargeCommand.CommandType = CommandType.Text;

                MySqlDataReader getChargeReader = getChargeCommand.ExecuteReader();

                decimal Charge = 0;
                while (getChargeReader.Read())
                {
                    Charge += decimal.Parse(getChargeReader.GetValue(0).ToString());
                }
                getChargeReader.Close();

                return Charge;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Charges Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool UpdateFolioTransaction( FolioTransaction poFolioTrans, ref MySqlTransaction poTransaction )
        {
            try
            {

				string strQuery = "call spUpdateFolioTransaction('" +
										   poFolioTrans.HotelID + "','" +
										   poFolioTrans.FolioID + "','" +
										   poFolioTrans.SubFolio + "','" +
										   poFolioTrans.AccountID + "','" +
										   string.Format("{0:yyyy-MM-dd}", poFolioTrans.TransactionDate) + "','" +
										   string.Format("{0:yyyy-MM-dd hh:ss:mm}", poFolioTrans.PostingDate) + "','" +
										   poFolioTrans.TransactionCode + "','" +
										   poFolioTrans.SubAccount + "','" +
										   poFolioTrans.ReferenceNo + "','" +
										   poFolioTrans.TransactionSource + "','" +
										   poFolioTrans.Memo + "','" +
										   poFolioTrans.AcctSide + "','" +
										   poFolioTrans.CurrencyCode + "','" +
										   poFolioTrans.ConversionRate + "','" +
										   poFolioTrans.CurrencyAmount + "'," +
										   poFolioTrans.BaseAmount + "," +
										   poFolioTrans.GrossAmount + "," +
										   poFolioTrans.Discount + "," +
										   poFolioTrans.ServiceCharge + "," +
										   poFolioTrans.ServiceChargeInclusive + "," +
										   poFolioTrans.GovernmentTax + "," +
										   poFolioTrans.GovernmentTaxInclusive + "," +
										   poFolioTrans.LocalTax + "," +
										   poFolioTrans.LocalTaxInclusive + "," +
										   poFolioTrans.NetBaseAmount + "," +
										   poFolioTrans.NetAmount + ",'" +
										   poFolioTrans.CreditCardNo + "','" +
										   poFolioTrans.ChequeNo + "','" +
										   poFolioTrans.AccountName + "','" +
										   poFolioTrans.BankName + "','" +
										   poFolioTrans.ChequeDate + "','" +
										   poFolioTrans.FOCGrantedBy + "','" +
										   poFolioTrans.CreditCardType + "','" +
										   poFolioTrans.ApprovalSlip + "','" +
										   poFolioTrans.CreditCardExpiry + "','" +
										   poFolioTrans.RouteSequence + "','" +
										   poFolioTrans.SourceFolio + "','" +
										   poFolioTrans.SourceSubFolio + "','" +
										   GlobalVariables.gTerminalID + "','" +
										   GlobalVariables.gShiftCode + "','" +
										   GlobalVariables.gLoggedOnUser + "','" +
                                           poFolioTrans.RoomID + "')";

				MySqlCommand updateCommand = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
                
                updateCommand.Transaction = poTransaction;
                updateCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception ("Transaction failed.\r\nError in updating folio transaction.\r\n\r\nError Description: " + ex.Message);
            }

        }

        public bool TransferFolioTransaction(string pFromFolioID, string pToFolioID, string pRouteCode, string pTrandate, ref MySqlTransaction poTransaction)
        {
            try
            {
                string tdate = string.Format("{0:yyyy-MM-dd H:mm:ss}", DateTime.Parse(pTrandate));
                MySqlCommand updateCommand = new MySqlCommand("call spTransferFolioTransaction('" + pFromFolioID 
					                                        + "','" + pToFolioID 
															+ "','" + pRouteCode 
															+ "','" + tdate 
															+ "'," + GlobalVariables.gHotelId 
															+ ")", GlobalVariables.gPersistentConnection);

                updateCommand.Transaction = poTransaction;

                updateCommand.CommandType = CommandType.Text;
                updateCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\nError in transferring folio transaction.\r\n\r\nError Description: " + ex.Message);
            }

        }

        public bool SetFolioTransactionStatus(DateTime pTransactionDate, string pTranCode, string pFolioID, string pStatus, ref MySqlTransaction poTransaction)
        {
            try
            {
                string trandate;
                MySqlCommand setStatusCommand = new MySqlCommand("spSetFolioTransactionStatus", GlobalVariables.gPersistentConnection);
                setStatusCommand.CommandType = CommandType.StoredProcedure;
                MySqlParameter paramtransactiondate = new MySqlParameter();
                MySqlParameter paramFolioID = new MySqlParameter();
                MySqlParameter paramTranCode = new MySqlParameter();
                MySqlParameter paramStatus = new MySqlParameter();

                trandate = string.Format("{0:yyyy-MM-dd H:mm:ss}", pTransactionDate);

                ParameterHelper paramHelper = new ParameterHelper();
                paramHelper.AddParameters(paramFolioID, "pfolioid", ParameterDirection.Input, DbType.String, pFolioID, setStatusCommand);
                paramHelper.AddParameters(paramTranCode, "ptrancode", ParameterDirection.Input, DbType.String, pTranCode, setStatusCommand);
                paramHelper.AddParameters(paramtransactiondate, "ptransactiondate", ParameterDirection.Input, DbType.String, trandate, setStatusCommand);
                paramHelper.AddParameters(paramStatus, "pStatus", ParameterDirection.Input, DbType.String, pStatus, setStatusCommand);

                setStatusCommand.Transaction = poTransaction;
                setStatusCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\nError in setting folio transaction status.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public bool DeleteFolioTransaction(DateTime pTransactionDate, string pTranCode, string pFolioID, ref MySqlTransaction poTransaction)
        {
            try
            {
                string trandate;
                MySqlCommand deleteCommand = new MySqlCommand("spDeleteFolioTransaction", GlobalVariables.gPersistentConnection);
                deleteCommand.CommandType = CommandType.StoredProcedure;
                MySqlParameter paramtransactiondate = new MySqlParameter();
                MySqlParameter paramFolioID = new MySqlParameter();
                MySqlParameter paramTranCode = new MySqlParameter();

                trandate = string.Format("{0:yyyy-MM-dd H:mm:ss}", pTransactionDate);

                ParameterHelper paramHelper = new ParameterHelper();
                paramHelper.AddParameters(paramFolioID, "pfolioid", ParameterDirection.Input, DbType.String, pFolioID, deleteCommand);
                paramHelper.AddParameters(paramTranCode, "ptrancode", ParameterDirection.Input, DbType.String, pTranCode, deleteCommand);
                paramHelper.AddParameters(paramtransactiondate, "ptransactiondate", ParameterDirection.Input, DbType.String, trandate, deleteCommand);

                deleteCommand.Transaction = poTransaction;
                deleteCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public DataTable GetData(string pCategory)
        {
            try
            {
                string CommandStr = "spGetLookupValue";
                MySqlCommand Command = new MySqlCommand(CommandStr, GlobalVariables.gPersistentConnection);
                Command.CommandType = CommandType.StoredProcedure;
                MySqlParameter param = new MySqlParameter("pcategory", pCategory);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                param.SourceColumn = "pcategory";
                Command.Parameters.Add(param);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
                DataTable LookUpTable = new DataTable("LookUpTable");


                DataAdapter.Fill(LookUpTable);
                return LookUpTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        private DataTable getDataToApplyCommission(string pFolioId, string pSubFolio)
        {
            DataTable dataComm;
            MySqlDataAdapter dataAdaptLedger;

            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetDataToApplyCommission('" + pFolioId 
					                                        + "','" + pSubFolio + "'," + GlobalVariables.gHotelId 
															+ ")", GlobalVariables.gPersistentConnection);


                dataAdaptLedger = new MySqlDataAdapter(selectCommand);
                dataComm = new DataTable("dataCommission");
                dataAdaptLedger.Fill(dataComm);
                return dataComm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Data To Apply Commission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private decimal getAgentCommission(string pFolioId, string pTranCode)
        {
            decimal Comm;
            try
            {

                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetCommission('" + pFolioId 
					                                        + "','" + pTranCode 
															+ "')", GlobalVariables.gPersistentConnection);

                Comm = System.Convert.ToDecimal(selectCommand.ExecuteScalar());
                return Comm;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void PostCommissionLedger(MySqlTransaction poTransaction, string pFolioId, string pSubFolio)
        {
            DataTable dataCommission = getDataToApplyCommission(pFolioId, pSubFolio);
            DataRow dtRow;
            if (dataCommission != null)
            {
                try
                {
                    foreach (DataRow tempLoopVar_dtRow in dataCommission.Rows)
                    {
                        dtRow = tempLoopVar_dtRow;
                        decimal commission;
                        decimal percentCom;
                        percentCom = getAgentCommission(pFolioId, dtRow["transactioncode"].ToString());
                        if (percentCom != 0)
                        {
                            commission = percentCom * decimal.Parse(dtRow["NetAmount"].ToString());
                            string cmdText = "call spPostComLedger('" + dtRow["AgentID"] 
								           + "','" + dtRow["transactioncode"] 
										   + "',0.00," + commission 
										   + ",'" + pFolioId + "','" + pSubFolio 
										   + "'," + GlobalVariables.gHotelId 
										   + ",'" + GlobalVariables.gLoggedOnUser + "')";
                            
                            MySqlCommand saveLedgerCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                            saveLedgerCommand.Transaction = poTransaction;
                            saveLedgerCommand.CommandType = CommandType.Text;
                            saveLedgerCommand.ExecuteNonQuery();

                            string cmdCommandTex;
                            cmdCommandTex = "call spUpdateTotalNetAgentComm(" + GlobalVariables.gHotelId + ",'" + pFolioId + "','" + pSubFolio + "'," + commission + "," + (decimal.Parse(dtRow["NetAmount"].ToString()) - commission) + ")";
                            MySqlCommand UpdatefolioLedgerCommand = new MySqlCommand(cmdCommandTex, GlobalVariables.gPersistentConnection);
                            UpdatefolioLedgerCommand.Transaction = poTransaction;
                            UpdatefolioLedgerCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Transaction failed @ Post Commission Ledger.\r\n\r\nError Description: " + ex.Message);
                }
            }
        }

        public string getLedgerType(string pTrancode)
        {
            DataTable dataLedger;
            MySqlDataAdapter dataAdaptLedger;

            try
            {
                string ledgerType = "";
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetLedgerType('" + pTrancode 
					                                        + "')", GlobalVariables.gPersistentConnection);

                dataAdaptLedger = new MySqlDataAdapter(selectCommand);
                dataLedger = new DataTable("Commission");
                dataAdaptLedger.Fill(dataLedger);
                if (dataLedger.Rows.Count > 0)
                {
                    ledgerType = dataLedger.Rows[dataLedger.Rows.Count - 1][0].ToString();
                }
                return ledgerType;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Ledger Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private string getAgent(string pFolioId)
        {
            DataTable dataFolio;
            MySqlDataAdapter dataAdaptFolio;

            try
            {
                string agent = "";
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetAgentByFolio '" + pFolioId 
					                                        + "'", GlobalVariables.gPersistentConnection);
                
                dataAdaptFolio = new MySqlDataAdapter(selectCommand);
                dataFolio = new DataTable("Agent");
                dataAdaptFolio.Fill(dataFolio);
                if (dataFolio.Rows.Count > 0)
                {
                    agent = dataFolio.Rows[dataFolio.Rows.Count - 1][0].ToString();
                }
                return agent;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Agent Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }

        private string getAccountID(string pFolioId)
        {
            DataTable dataFolio;
            MySqlDataAdapter dataAdaptFolio;

            try
            {
                int AccountID = 0;
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetAccountIDFromFolio('" + pFolioId 
					                                        + "')", GlobalVariables.gPersistentConnection);

                dataAdaptFolio = new MySqlDataAdapter(selectCommand);
                dataFolio = new DataTable("Account");
                dataAdaptFolio.Fill(dataFolio);
                if (dataFolio.Rows.Count > 0)
                {
                    AccountID = int.Parse(dataFolio.Rows[dataFolio.Rows.Count - 1][0].ToString());
                }
                return AccountID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Account Id Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private string getAgentAccountID(string pFolioId)
        {
            try
            {
                string AccountID;
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetAccountIDofAgent(" + pFolioId + ")", GlobalVariables.gPersistentConnection);

                AccountID = selectCommand.ExecuteScalar().ToString();

                return AccountID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message,"Get Account Id Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void setPosted(string pFolioId)
        {
            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand updateCommand = new MySqlCommand("call spSetPosted('" + pFolioId 
					                                        + "'," + GlobalVariables.gHotelId 
															+ ")", GlobalVariables.gPersistentConnection);

                updateCommand.CommandType = CommandType.Text;
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Post Folio Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PostToLedger(Folio poFolio)
        {
            MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
            FolioFacade oFolioFACADE = new FolioFacade();
            try
            {
                SubFolio subF = null;
                foreach (SubFolio tempLoopVar_subF in poFolio.SubFolios)
                {
                    subF = tempLoopVar_subF;
                    FolioTransactionLedger folioTransLedger;
                    subF.Ledger = oFolioFACADE.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                    folioTransLedger = subF.Ledger;
                    if (subF.SubFolio_Renamed == "A")
                    {
                        //PostSalesLedger
                        if (folioTransLedger != null)
                        {
                            if (folioTransLedger.Charges != 0)
                            {
                                PostSalesLedger(trans, folioTransLedger.AccountID, "FILLER", folioTransLedger.Charges + folioTransLedger.Discount, folioTransLedger.Discount, (folioTransLedger.Charges + folioTransLedger.Discount) - folioTransLedger.Discount, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }
                            //accounts payable ledger
                            if (folioTransLedger.GovernmentTax != 0)
                            {
                                PostAP(trans, "101", "FILLER", folioTransLedger.GovernmentTax, 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }
                            if (folioTransLedger.LocalTax != 0)
                            {
                                PostAP(trans, "102", "FILLER", folioTransLedger.LocalTax, 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }
                            //post cash ledger
                            if (folioTransLedger.PayCash != 0)
                            {
                                PostCS(trans, folioTransLedger.AccountID, "FILLER", folioTransLedger.PayCash, 0, 0, 0, folioTransLedger.PayCash, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }
                            if (folioTransLedger.PayGiftCheque != 0)
                            {
                                PostCS(trans, folioTransLedger.AccountID, "FILLER", folioTransLedger.PayGiftCheque, 0, 0, 0, folioTransLedger.PayGiftCheque, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }
                            if (folioTransLedger.PayCheque != 0)
                            {
                                PostCS(trans, folioTransLedger.AccountID, "FILLER", folioTransLedger.PayCheque, 0, 0, 0, folioTransLedger.PayCheque, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }

                            //post to deposit ledger or city ledger
                            if (folioTransLedger.BalanceForwarded != 0)
                            {
                                if (folioTransLedger.BalanceForwarded > 0)
                                {
                                    if (poFolio.FolioType != "GROUP")//added for transferring charges of company
                                    {
                                        try
                                        {
                                            decimal _amtToPost = 0;
                                            _amtToPost = getCityCharges(folioTransLedger.FolioID, subF.SubFolio_Renamed);
                                            if (_amtToPost < 0)
                                            {
                                                PostCityLedger(trans, poFolio.AccountID, "FILLER", 0, Math.Abs(_amtToPost), folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                            }
                                            else
                                            {
                                                PostCityLedger(trans, poFolio.AccountID, "FILLER", Math.Abs(_amtToPost), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                            }

                                            //PostCityLedger(trans, poFolio.AccountID, "FILLER", Math.Abs(folioTransLedger.BalanceForwarded), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            decimal _amtToPost = 0;
                                            _amtToPost = getCityCharges(folioTransLedger.FolioID, subF.SubFolio_Renamed);
                                            if (_amtToPost < 0)
                                            {
                                                PostCityLedger(trans, poFolio.CompanyID, "FILLER", 0, Math.Abs(_amtToPost), folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                            }
                                            else
                                            {
                                                PostCityLedger(trans, poFolio.CompanyID, "FILLER", Math.Abs(_amtToPost), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                            }

                                            //PostCityLedger(trans, poFolio.CompanyID, "FILLER", Math.Abs(folioTransLedger.BalanceForwarded), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                        }
                                        catch { }
                                    }
                                }
                                else
                                {
                                    PostDepositLedger(trans, folioTransLedger.AccountID, "FILLER", Math.Abs(folioTransLedger.BalanceForwarded), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                }
                            }

                            //for credit card ledgers
                            DataTable dtCreditCard = this.getBreakDownOfChargePayment(folioTransLedger.FolioID);
                            if (dtCreditCard != null)
                            {
                                DataRow dtRow;
                                foreach (DataRow tempLoopVar_dtRow in dtCreditCard.Rows)
                                {
                                    dtRow = tempLoopVar_dtRow;
                                    if (System.Convert.ToDecimal(dtRow["Amount"]) != 0)
                                    {
                                        PostCreditCardLedger(trans, dtRow["Accountid"].ToString(), "FILLER", System.Convert.ToDecimal(dtRow["Amount"]), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                    }
                                }
                            }
                        }
                    } // this was added because SUB-FOLIO B AccountID is NULL;
                    else if (subF.SubFolio_Renamed == "B")
                    {
                        if (folioTransLedger.BalanceForwarded != 0)
                        {
                            try
                            {
                                // added a condition to trap wether no accountid is supplied v
                                decimal _amtToPost = 0;
                                _amtToPost = getCityCharges(folioTransLedger.FolioID, subF.SubFolio_Renamed);
                                if (_amtToPost < 0)
                                {
                                    PostCityLedger(trans, folioTransLedger.AccountID, "FILLER", 0, Math.Abs(_amtToPost), folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                }
                                else
                                {
                                    PostCityLedger(trans, folioTransLedger.AccountID, "FILLER", Math.Abs(_amtToPost), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                }

                                //PostCityLedger(trans, folioTransLedger.AccountID, "FILLER", folioTransLedger.BalanceForwarded, 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        if (folioTransLedger.BalanceForwarded != 0)
                        {
                            try
                            {
                                // added a condition to trap wether no accountid is supplied v
                                //PostCityLedger(trans, (folioTransLedger.AccountID) == "" ? loFolio.AccountID : (folioTransLedger.AccountID), "FILLER", folioTransLedger.Charges, 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                decimal _amtToPost = 0;
                                _amtToPost = getCityCharges(folioTransLedger.FolioID, subF.SubFolio_Renamed);
                                if (_amtToPost < 0)
                                {
                                    PostCityLedger(trans, (folioTransLedger.AccountID) == "" ? poFolio.AccountID : folioTransLedger.AccountID, "FILLER", 0, Math.Abs(_amtToPost), folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                }
                                else
                                {
                                    PostCityLedger(trans, (folioTransLedger.AccountID) == "" ? poFolio.AccountID : folioTransLedger.AccountID, "FILLER", Math.Abs(_amtToPost), 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                                }

                                //PostCityLedger(trans, (folioTransLedger.AccountID) == "" ? poFolio.AccountID : folioTransLedger.AccountID, "FILLER", folioTransLedger.BalanceForwarded, 0, folioTransLedger.FolioID, folioTransLedger.SubFolio);
                            }
                            catch { }

                        }
                    }


                }
                // for Agent Commission Ledger
                PostCommissionLedger(trans, subF.Folio.FolioID, subF.SubFolio_Renamed);
                ///
                //post service lCharge
                PostServiceChargeLedger(trans, subF.Folio.FolioID, subF.SubFolio_Renamed);

                setPosted(subF.Folio.FolioID);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Post To Ledger Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        //for posting non guest city transfer transactions
        public void PostNonGuestTransCityLedger(string pAccountID, decimal pAmount, string pFolioID, ref MySqlTransaction trans)
        {
            FolioFacade oFolioFACADE = new FolioFacade();
            try
            {
                PostCityLedger(trans, pAccountID, "FILLER", Math.Abs(pAmount), 0, pFolioID.Trim(), "A");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Post To Ledger Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal getCityCharges(string pFolioID, string pSubfolio)
        {
            //>get the total charges to be charged to specific account
            string sql = "select if(acctside='DEBIT', sum(netAmount) * -1, sum(netAmount)) from foliotransactions where folioid='" + pFolioID + "' and subfolio='" + pSubfolio + "' and transactioncode='4200' group by folioid";
            MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
            decimal sum = decimal.Parse(cmd.ExecuteScalar().ToString());

            return sum;
        }

        private DataTable getBreakDownOfChargePayment(string pFolioId)
        {
            DataTable dataBreakDown;
            MySqlDataAdapter dataAdaptFolio;

            try
            {

                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetBreakDownOfChargePayment('" + pFolioId 
					                                        + "')", GlobalVariables.gPersistentConnection);

                dataAdaptFolio = new MySqlDataAdapter(selectCommand);
                dataBreakDown = new DataTable("CreditCardCo");
                dataAdaptFolio.Fill(dataBreakDown);

                return dataBreakDown;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Breakdown of Charges Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private DataTable getDataToBePostedServiceCharge(string pFolioId)
        {
            DataTable dataSrvCharges;
            MySqlDataAdapter dataAdaptFolio;

            try
            {

                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetDataToPostServiceCharge('" + pFolioId 
					                                        + "'," + GlobalVariables.gHotelId 
															+ ")", GlobalVariables.gPersistentConnection);

                dataAdaptFolio = new MySqlDataAdapter(selectCommand);
                dataSrvCharges = new DataTable("Charges");
                dataAdaptFolio.Fill(dataSrvCharges);

                return dataSrvCharges;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Post Service Charge Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private decimal getPercentServiceCharge(string pTranCode, string pDeptId)
        {
            decimal chrg;

            try
            {

                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                MySqlCommand selectCommand = new MySqlCommand("call spGetPercentSrvCharge('" + pTranCode 
					                                        + "','" + pDeptId + "'," + GlobalVariables.gHotelId 
															+ ")", GlobalVariables.gPersistentConnection);

                chrg = System.Convert.ToDecimal(selectCommand.ExecuteScalar());
                return chrg;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        private void PostServiceChargeLedger(MySqlTransaction poTrans, string pFolioId, string pSubFolio)
        {
            DataTable dataCharges = getDataToBePostedServiceCharge(pFolioId);
            DataRow dtRow;
            try
            {
                foreach (DataRow tempLoopVar_dtRow in dataCharges.Rows)
                {
                    dtRow = tempLoopVar_dtRow;
                    decimal chrg = getPercentServiceCharge(dtRow["trancode"].ToString(), dtRow["departmentId"].ToString());
                    decimal chrgAmt;

                    if (chrg != 0)
                    {
                        chrgAmt = decimal.Parse(dtRow["amount"].ToString()) * chrg;
						string cmdText = "call spPostsrvchrgledger('" + dtRow["departmentId"] 
							           + "','" + dtRow["trancode"] + "',0.00," + chrgAmt 
									   + ",'" + pFolioId + "','" + pSubFolio 
									   + "'," + GlobalVariables.gHotelId 
									   + ",'" + GlobalVariables.gLoggedOnUser + "')";

                        MySqlCommand saveLedgerCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                        saveLedgerCommand.CommandType = CommandType.Text;
                        saveLedgerCommand.Transaction = poTrans;
                        saveLedgerCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\n\r\nError Description: " + ex.Message);
            }

        }

        private void PostCityLedger(MySqlTransaction poTrans, string pAccountId, string pRefNo, decimal pDebit, decimal pCredit, string pFolio, string pSubFolio)
        {
            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                string cmdText = "call spPostCityLedger('" + pAccountId 
					           + "','" + pRefNo + "'," + pDebit 
							   + "," + pCredit + ",'" + pFolio 
							   + "','" + pSubFolio + "'," + GlobalVariables.gHotelId 
							   + ",'" + GlobalVariables.gLoggedOnUser + "','" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate)) + "')";

                MySqlCommand saveLedgerCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                saveLedgerCommand.Transaction = poTrans;
                saveLedgerCommand.CommandType = CommandType.Text;

                saveLedgerCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\nError Description: " + ex.Message);
            }

        }

        private void PostDepositLedger(MySqlTransaction poTrans, string pAccountId, string pRefNo, decimal pDebit, decimal pCredit, string pFolioId, string pSubFolio)
        {
            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                string cmdText = "call spPostDepledger('" + pAccountId 
							   + "','" + pRefNo 
					           + "'," + pDebit 
							   + "," + pCredit 
							   + ",'" + pFolioId 
							   + "','" + pSubFolio 
							   + "'," + GlobalVariables.gHotelId 
							   + ",'" + GlobalVariables.gLoggedOnUser 
							   + "','" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand saveLedgerCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                saveLedgerCommand.Transaction = poTrans;
                saveLedgerCommand.CommandType = CommandType.Text;

                saveLedgerCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed @ Post Deposit Ledger.\r\n\r\nError Description: " + ex.Message);
            }

        }

        private void PostSalesLedger(MySqlTransaction poTrans, string pAccountId, string pRefNo, decimal pDebit, decimal pCredit, decimal pNetSales, string pFolioId, string pSubFolio)
        {
            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                string cmdText = "call spPostSalesLedger('" + pAccountId + "','" + pRefNo + "'," + pDebit + "," + pCredit + "," + pNetSales + ",'" + pFolioId + "','" + pSubFolio + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand saveLedgerCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                saveLedgerCommand.Transaction = poTrans;
                saveLedgerCommand.CommandType = CommandType.Text;

                saveLedgerCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\n\r\nError Description: " + ex.Message);
            }
        }

        private void PostCreditCardLedger(MySqlTransaction poTrans, string pAccountId, string pRefNo, decimal pDebit, decimal pCredit, string pFolioId, string pSubFolio)
        {

            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                string cmdText = "call spPostCreditCardLedger('" + pAccountId 
					           + "','" + pRefNo 
							   + "'," + pDebit 
							   + "," + pCredit 
							   + ",'" + pFolioId 
							   + "','" + pSubFolio 
							   + "'," + GlobalVariables.gHotelId 
							   + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand saveLedgerCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                saveLedgerCommand.Transaction = poTrans;
                saveLedgerCommand.CommandType = CommandType.Text;
                saveLedgerCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\n\r\nError Description: " + ex.Message);
            }
        }

        private void PostAP(MySqlTransaction poTrans, string pAccountId, string pRefNo, decimal pDebit, decimal pCredit, string pFolioId, string pSubfolio)
        {
            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                string cmdText = "call spPostAP('" + pAccountId
							   + "','" + pRefNo 
							   + "'," + pDebit 
							   + "," + pCredit 
							   + ",'" + pFolioId 
							   + "','" + pSubfolio 
							   + "'," + GlobalVariables.gHotelId 
							   + ",'" + GlobalVariables.gLoggedOnUser 
							   + "')";

                MySqlCommand saveAPCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                saveAPCommand.Transaction = poTrans;
                saveAPCommand.CommandType = CommandType.Text;

                saveAPCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\n\r\nError Description: " + ex.Message);
            }
        }

        private void PostCS(MySqlTransaction trans, string pAccountId, string pRefNo, decimal pDebit, decimal pCredit, decimal pDiscount, decimal pCashCredit, decimal pCashDebit, string pFolioId, string pSubFolio)
        {
            try
            {
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }
                string cmdText = "call spPostCS('" + pAccountId 
					           + "','" + pRefNo 
							   + "'," + pDebit 
							   + "," + pCredit 
							   + "," + pDiscount 
							   + "," + pCashCredit 
							   + "," + pCashDebit 
							   + ",'" + pFolioId 
							   + "','" + pSubFolio 
							   + "'," + GlobalVariables.gHotelId 
							   + ",'" + GlobalVariables.gLoggedOnUser 
							   + "')";
                
                MySqlCommand saveLedgerCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                saveLedgerCommand.Transaction = trans;
                saveLedgerCommand.CommandType = CommandType.Text;

                saveLedgerCommand.ExecuteNonQuery();
            }
            catch /*(Exception ex)*/
            {
                //MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Post CS Ledger Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw (ex);
            }
        }

        
        public decimal GetFolioCharges(string pFolioId, string pSubFolio)
        {
            try
			{
				DataTable _dtTemp = new DataTable();

				string _sqlStr = "call spGetCharges('" + 
									   pFolioId + "','" + 
									   GlobalVariables.gHotelId + "','" + 
									   pSubFolio + "')";

                MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtSelect.Fill(_dtTemp);

				if (_dtTemp == null)
					return 0;

				if (_dtTemp.Rows.Count == 0)
					return 0;

                decimal _charge = 0;
				if (decimal.TryParse(_dtTemp.Rows[0][0].ToString(), out _charge))
				{
					// do nothing
				}

                return _charge;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Folio Charges Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return 0;
            }
        }

        public decimal GetFolioPayments(string pFolioId, string pSubFolio)
        {
            try
            {
				DataTable _dtTemp = new DataTable();

                MySqlDataAdapter _dtSelect = new MySqlDataAdapter("call spGetPayments('" + pFolioId 
					                                     + "','" + GlobalVariables.gHotelId 
														 + "','" + pSubFolio 
														 + "')", GlobalVariables.gPersistentConnection);

				_dtSelect.Fill(_dtTemp);

				if (_dtTemp == null)
					return 0;

				if (_dtTemp.Rows.Count == 0)
					return 0;


                decimal payments = 0;
				if(decimal.TryParse(_dtTemp.Rows[0][0].ToString(), out payments))
				{
					// do nothing
				}

                return payments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Folio Payments Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public string GetTranTypeId(string pTranCode)
        {
            try
            {
                MySqlCommand selectCommand = new MySqlCommand("call spGetTranTypeId('" + pTranCode 
					                                        + "','" + GlobalVariables.gHotelId 
															+ "')", GlobalVariables.gPersistentConnection);

                return selectCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get TranType Id Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public bool RefNoIfExist(string pTranCode,string pRefNo)
        {
            try
            {
                MySqlCommand selectCommand = new MySqlCommand("call spCountRefNoExistence('" + pTranCode + "','" + pRefNo + "'," +  GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                if( int.Parse(selectCommand.ExecuteScalar().ToString())>0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Reference No. Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool InsertFolioTransaction(FolioTransaction poFolioTransaction,ref MySqlTransaction poTransaction)
        {
            try
            {
                int _summaryFlag = 0;
                string _packageName = "";

                try
                {
                    _summaryFlag = poFolioTransaction.SummaryFlag;
                    _packageName = poFolioTransaction.PackageName;
                }
                catch
                {
                    _summaryFlag = 0;
                    _packageName = "";
                }

                FolioTransaction folioTrans = poFolioTransaction;
                string commandText = "call spInsertFolioTransaction('" + 
										   folioTrans.HotelID + "','" + 
										   folioTrans.FolioID + "','" + 
										   folioTrans.SubFolio + "','" + 
										   folioTrans.AccountID + "','" + 
										   string.Format("{0:yyyy-MM-dd}",folioTrans.TransactionDate) + "','" +
										   folioTrans.TransactionCode + "','" +
										   folioTrans.SubAccount + "','" + 
										   folioTrans.ReferenceNo + "','"+ 
										   folioTrans.TransactionSource + "','" + 
										   folioTrans.Memo + "','" + 
										   folioTrans.AcctSide + "','" + 
										   folioTrans.CurrencyCode + "','" + 
										   folioTrans.ConversionRate + "','" + 
										   folioTrans.CurrencyAmount + "'," + 
										   folioTrans.BaseAmount + "," +
										   folioTrans.GrossAmount + "," + 
										   folioTrans.Discount + "," + 
										   folioTrans.ServiceCharge + "," +
										   folioTrans.ServiceChargeInclusive + "," +
										   folioTrans.GovernmentTax + "," +
										   folioTrans.GovernmentTaxInclusive + "," +
										   folioTrans.LocalTax + "," +
										   folioTrans.LocalTaxInclusive + "," + 
										   folioTrans.NetBaseAmount + "," +
										   folioTrans.NetAmount + ",'" +
										   folioTrans.CreditCardNo + "','" +
										   folioTrans.ChequeNo + "','" +
										   folioTrans.AccountName + "','" +
										   folioTrans.BankName + "','" +
										   folioTrans.ChequeDate + "','" +
										   folioTrans.FOCGrantedBy + "','" + 
										   folioTrans.CreditCardType + "','" +
										   folioTrans.ApprovalSlip + "','" +
										   folioTrans.CreditCardExpiry + "','" +
										   folioTrans.RouteSequence + "','" + 
										   folioTrans.SourceFolio + "','" + 
										   folioTrans.SourceSubFolio + "','" + 
										   GlobalVariables.gTerminalID + "','" + 
										   GlobalVariables.gShiftCode + "','" + 
										   GlobalVariables.gLoggedOnUser + "'," +
                                           _summaryFlag + ",'" +
                                           _packageName + "'," + 
										   folioTrans.MealAmount + ",'" +
                                           folioTrans.AdjustmentFlag + "','" +
                                           folioTrans.RoomID + "')";

                MySqlCommand insertCommand = new MySqlCommand(commandText, GlobalVariables.gPersistentConnection);
                insertCommand.Transaction = poTransaction;
                insertCommand.ExecuteNonQuery();

                bool updateFolioLedger = false;
                updateFolioLedger = UpdateFolioLedger(poFolioTransaction, false,ref poTransaction);

                bool updateCashierShift = false;
                updateCashierShift = UpdateCashierShift(poFolioTransaction,false,ref poTransaction);

                if (updateFolioLedger && updateCashierShift)
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
                throw new Exception("Transaction failed.\r\nError in inserting folio transaction.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public bool transferFolioTransaction(FolioTransaction poFolioTransaction, ref MySqlTransaction poDbTrans)
        {
            try
            {
				string _sqlStr = "call spUpdateFolioTransactionForTransfer('" + 
					                   poFolioTransaction.FolioTransactionNo + "','" + 
									   poFolioTransaction.FolioID + "','" + 
									   poFolioTransaction.SubFolio + "','" + 
									   poFolioTransaction.AccountID + "','" + 
									   poFolioTransaction.RouteSequence + "','" + 
									   poFolioTransaction.SourceFolio + "','" + 
									   poFolioTransaction.SourceSubFolio + "','" + 
									   poFolioTransaction.UpdatedBy + "')";



				MySqlCommand insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                insertCommand.Transaction = poDbTrans;
                insertCommand.ExecuteNonQuery();

				// update DESTINATION FOLIO
                bool updateLedger = false;
				updateLedger = UpdateFolioLedger(poFolioTransaction, false, ref poDbTrans);

                bool updateCashierShift = false;
				updateCashierShift = UpdateCashierShift(poFolioTransaction, false, ref poDbTrans);


				//UPDATE ORIGIN FOLIO
				bool updateLedgerOrigin = false;
				poFolioTransaction.FolioID = poFolioTransaction.SourceFolio;
				poFolioTransaction.SubFolio = poFolioTransaction.SourceSubFolio;
				updateLedgerOrigin = UpdateFolioLedger(poFolioTransaction, true, ref poDbTrans);

				bool updateCashierShiftOrigin = false;
				updateCashierShiftOrigin = UpdateCashierShift(poFolioTransaction, true, ref poDbTrans);


                if (updateLedger && 
					updateCashierShift &&
					updateLedgerOrigin &&
					updateCashierShiftOrigin)
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
                throw new Exception("Transaction failed.\r\nError in transferring folio transaction.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public bool VoidFolioTransaction(FolioTransaction poFolioTrans, ref MySqlTransaction poTransaction)
        {
            
            try
            {
				string _sqlStr = "call spVoidFolioTransaction(" + 
									   poFolioTrans.FolioTransactionNo + ",'" + 
									   poFolioTrans.UpdatedBy + "')";

                MySqlCommand voidCommand = new MySqlCommand( _sqlStr , GlobalVariables.gPersistentConnection );
                voidCommand.Transaction = poTransaction;
                int affectedRows = voidCommand.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    bool updateLedger = false;
                    updateLedger = UpdateFolioLedger(poFolioTrans, true, ref poTransaction);

                    bool updateCashierShift = false;
                    updateCashierShift = UpdateCashierShift(poFolioTrans, true, ref poTransaction);

                    if (updateLedger && updateCashierShift)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Transaction failed.\r\nError Description: (0) Rows affected.", "Void Folio Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                else

                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed @ Void Folio Transaction.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public bool UpdateFolioLedger(FolioTransaction poFolioTransaction, bool pIsVoid,ref MySqlTransaction poTransaction)
        {
            try
            {
                FolioTransaction folioTrans = poFolioTransaction;
                string updateStr = "";

                switch (folioTrans.AcctSide)
                {
                    case "DEBIT":

						updateStr = "call " + (pIsVoid ? "spUpdateFolioLedgerChargesVOID" : "spUpdateFolioLedgerCharges") 
							                          + "('" + folioTrans.FolioID 
													  + "'," + "'" + folioTrans.HotelID 
													  + "'," + "'" + folioTrans.SubFolio 
													  + "'," + "'" + folioTrans.NetAmount
													  + "'," + "'" + folioTrans.Discount 
													  + "'," + "'" + folioTrans.GovernmentTax 
													  + "'," + "'" + folioTrans.LocalTax 
													  + "'," + "'" + folioTrans.ServiceCharge 
													  + "'," + "'" + folioTrans.UpdatedBy + "')";
                        break;

                    case "CREDIT":

                        decimal payCash = 0;
                        decimal payCard = 0;
                        decimal payCheque = 0;
                        decimal payGiftCheque = 0;
                        decimal balanceForward = 0;
						decimal discount = 0;

                        decimal localTax = folioTrans.LocalTax;
                        decimal govtTax = folioTrans.GovernmentTax;
                        decimal serviceCharge = folioTrans.ServiceCharge;

                        switch (GetTranTypeId(folioTrans.TransactionCode))
                        {
							case "1": // CHARGES

								payCash = 0;
								payCard = 0;
								payCheque = 0;
								payGiftCheque = 0;
                                balanceForward = folioTrans.BaseAmount;
								break;

                            case "2": // GIFT CHEQUE

                                payCash = 0;
                                payCard = 0;
                                payCheque = 0;
                                payGiftCheque = folioTrans.BaseAmount;
                                balanceForward = 0;
                                break;

                            case "3": // CASH

                                payCash = folioTrans.BaseAmount;
                                payCard = 0;
                                payCheque = 0;
                                payGiftCheque = 0;
                                balanceForward = 0;
                                break;

                            case "4": // CHARGE

                                payCash = 0;
                                payCard = folioTrans.BaseAmount;
                                payCheque = 0;
                                payGiftCheque = 0;
                                balanceForward = 0;
                                break;

                            case "5": // CHEQUE

                                payCash = 0;
                                payCard = 0;
                                payCheque = folioTrans.BaseAmount;
                                payGiftCheque = 0;
                                balanceForward = 0;
                                break;

                            //case "7": //COMPLIMENTARY ACCOUNTS
                            //    payCash = 0;
                            //    payCard = 0;
                            //    payCheque = 0;
                            //    payGiftCheque = 0;
                            //    balanceForward = 0;
                            //    discount = folioTrans.BaseAmount;
                            //    break;

                            case "7": //COMPLIMENTARY ACCOUNTS
                            case "9": // BALANCE FORWARD
                            case "11": // BALANCE TRANSFER

                                payCash = 0;
                                payCard = 0; 
                                payCheque = 0;
                                payGiftCheque = 0;
                                balanceForward = folioTrans.BaseAmount;
                                break;
                        }

						updateStr = "call " + (pIsVoid ? "spUpdateFolioLedgerPaymentsVOID" : "spUpdateFolioLedgerPayments ") 
							                        + "('" + folioTrans.FolioID 
													+ "'," + "'" + folioTrans.HotelID 
													+ "'," + "'" + folioTrans.SubFolio 
													+ "'," + "'" + payCash 
													+ "'," + "'" + payCard 
													+ "'," + "'" + payCheque 
													+ "'," + "'" + payGiftCheque 
													+ "'," + "'" + balanceForward
													+ "'," + "'" + discount
													+ "'," + "'" + folioTrans.UpdatedBy
                                                    + "'," + "'" + localTax
                                                    + "'," + "'" + govtTax
                                                    + "'," + "'" + serviceCharge + "')";
                        break;
                }

                MySqlCommand udpateCommand = new MySqlCommand(updateStr, GlobalVariables.gPersistentConnection);
                udpateCommand.Transaction = poTransaction;
                udpateCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed @ Update Folio Ledger.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public string getTranCodeAccountSide(string pTranCode)
        {
            try
            {
                MySqlCommand selectCommand = new MySqlCommand("call GetTranCodeAccountSide('" + pTranCode 
					                                        + "','" + GlobalVariables.gHotelId 
															+ "')", GlobalVariables.gPersistentConnection);

                return selectCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get TranCode Account Side Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public FolioTransaction GetVoidedFolioTransactions(string pFolioId)
        {
            try
            {
                oFolioTransaction = new FolioTransaction();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetVoidedFolioTransactions('" + pFolioId 
																  + "','" + GlobalVariables.gHotelId 
																  + "')", GlobalVariables.gPersistentConnection);

                dataAdapter.Fill(oFolioTransaction, "VoidedFolioTrans");

                return oFolioTransaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError Description: " + ex.Message, "Get Voided Transactions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool RecallFolioTransaction(FolioTransaction poFolioTransaction,ref MySqlTransaction poTransaction)
        {
            try
            {
				string _sqlStr = "call spRecallFolioTransaction(" + 
									   poFolioTransaction.FolioTransactionNo + ",'" +
									   poFolioTransaction.ReferenceNo + "','" + 
									   GlobalVariables.gLoggedOnUser +"')";

                MySqlCommand recallCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

                recallCommand.Transaction = poTransaction;
                recallCommand.ExecuteNonQuery();

                bool updateLedger = false;
                updateLedger = UpdateFolioLedger(poFolioTransaction, false, ref poTransaction);

                if (updateLedger)
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
                throw new Exception("Transaction failed @ Recall Folio Transaction.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public bool UpdateCashierShift(FolioTransaction poFolioTransaction, bool pIsVoid, ref MySqlTransaction poTransaction)
        {
            
            try
            {
                FolioTransaction folioTrans = poFolioTransaction;
                string updateStr = "";

                //COMMENT OUT March 18, 2008
                //to record not only CREDIT TYPE transactions
                //should include DEBIT such as REFUND
                //JEROME, Jinisys Softwares

                //if (folioTrans.AcctSide == "CREDIT")
                //{

                // BUG NO: BUG-FP-0003
                // Jerome, April 16, 2008
                // bug fixed regarding cashier shift _amount updating
                // even if Transaction Date is not today
                //updateStr = "call " + (Void ? "spUpdateCashierShiftAmountVoid" : "spUpdateCashierShiftAmount") + "('" + folioTrans.AcctSide + "','" + folioTrans.TransactionCode + "','" + folioTrans.BaseAmount + "','" + folioTrans.TerminalID + "','" + GlobalVariables.shiftCode + "','" + GlobalVariables.AuditDate + "')";
                    updateStr = "call " + (pIsVoid ? "spUpdateCashierShiftAmountVoid" : "spUpdateCashierShiftAmount") 
						      + "('" + folioTrans.AcctSide 
							  + "','" + folioTrans.TransactionCode 
							  + "','" + folioTrans.NetAmount 
							  + "','" + folioTrans.TerminalID 
							  + "','" + GlobalVariables.gShiftCode 
							  + "','" + string.Format("{0:yyyy-MM-dd}", folioTrans.TransactionDate) 
							  + "')";

                // end BUG NO: BUG-FP-0003

                    MySqlCommand udpateCommand = new MySqlCommand(updateStr, GlobalVariables.gPersistentConnection);
                    udpateCommand.Transaction = poTransaction;
                    udpateCommand.ExecuteNonQuery();
                //}

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed @ Update Cashier Shift.\r\n\r\nError Description: " + ex.Message);
            }
        }

        public int getTransactionTerminalId(FolioTransaction poFolioTransaction)
        {
            try
            {

                MySqlCommand getCommand = new MySqlCommand("call spGetTransactionTerminalId('" + GlobalVariables.gHotelId + "','" + poFolioTransaction.FolioID + "','" + poFolioTransaction.SubFolio + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}",poFolioTransaction.PostingDate) + "','" + poFolioTransaction.TransactionCode + "')", GlobalVariables.gPersistentConnection);
                object obj = getCommand.ExecuteScalar();

                int terminalId = int.Parse( obj.ToString() );
                
                return terminalId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get terminal id exception.\r\nError Description: " + ex.Message, "Void", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

		public DataTable getFolioTransactionByTransactionNo(int pFolioTransactionNo)
		{
			try
			{
				DataTable _dtFolioTransaction = new DataTable();

				string _sqlStr = "call spGetFolioTransactionByTransactionNo(" +
									   pFolioTransactionNo + ")";

				MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtSelect.Fill(_dtFolioTransaction);

				return _dtFolioTransaction;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}



		public DataTable getFolioTransactionByTransactionCodeAndReferenceNo(string pTransactionCode, string pReferenceNo)
		{
			try
			{
				DataTable _dtFolioTransaction = new DataTable();

				string _sqlStr = "call spGetFolioTransactionByTransactionCodeReferenceNo('" +
									   pTransactionCode + "','" +
									   pReferenceNo + "')";

				MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtSelect.Fill(_dtFolioTransaction);

				return _dtFolioTransaction;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

        //>>to check if folio has already room charge for the day
        public bool checkIfRoomChargeExist(string pFolioID)
        {
            try
            {
                string _query = "select * from foliotransactions where folioid='" + pFolioID + "' and transactioncode='1000' and acctside='DEBIT' and adjustmentflag!=1 and date(transactiondate)>='" + DateTime.Parse(GlobalVariables.gAuditDate).ToString("yyyy-MM-dd") + "'";
                DataTable _oDataTable = new DataTable();
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
                _oDataAdapter.Fill(_oDataTable);

                if (_oDataTable.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}