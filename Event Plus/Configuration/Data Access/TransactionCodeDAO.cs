
using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class TransactionCodeDAO
    {
        private TransactionCode loTransactionCode;

        public TransactionCodeDAO()
        {
        }

        public DataTable getCharges(int hotelID)
        {
            try
            {
                DataTable chargesTable = new DataTable("PackageDetails");
                MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spDisplayCharges('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );
                dtAdapter.Fill(chargesTable);

                return chargesTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public TransactionCode getTransactionCode(string TransCode)
        {
            try
            {
				DataTable _dtResult = new DataTable();

                loTransactionCode = new TransactionCode();

				string _strQuery = "call spGetTransactionCode('" + 
										 TransCode + "','" + 
										 GlobalVariables.gHotelId + "')";


                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( _strQuery, GlobalVariables.gPersistentConnection );
				dataAdapter.Fill( _dtResult );

				DataRow _dRow = _dtResult.Rows[0];

				loTransactionCode.TranCode = _dRow["TranCode"].ToString();
				loTransactionCode.TranTypeId = _dRow["TranTypeId"].ToString();
				loTransactionCode.Memo = _dRow["Memo"].ToString();
				loTransactionCode.AcctSide = _dRow["AcctSide"].ToString();
				loTransactionCode.ServiceCharge = decimal.Parse( _dRow["ServiceCharge"].ToString() );
				loTransactionCode.ServiceChargeInclusive = int.Parse( _dRow["ServiceChargeInclusive"].ToString() );
				loTransactionCode.GovtTax = decimal.Parse(_dRow["GovtTax"].ToString());
				loTransactionCode.GovtTaxInclusive = int.Parse( _dRow["GovtTaxInclusive"].ToString() );
				loTransactionCode.LocalTax = decimal.Parse(_dRow["LocalTax"].ToString());
				loTransactionCode.LocalTaxInclusive = int.Parse( _dRow["LocalTaxInclusive"].ToString() );
				loTransactionCode.DefaultTransactionSource = _dRow["DefaultTransactionSource"].ToString();
				loTransactionCode.DefaultAmount = decimal.Parse(_dRow["DefaultAmount"].ToString());
				loTransactionCode.WarningAmount = decimal.Parse(_dRow["WarningAmount"].ToString());
				loTransactionCode.DepartmentId = _dRow["DepartmentId"].ToString();
				loTransactionCode.Ledger = _dRow["Ledger"].ToString();
				loTransactionCode.DebitSide = _dRow["DebitSide"].ToString();
				loTransactionCode.CreditSide = _dRow["CreditSide"].ToString();
				loTransactionCode.HotelID = int.Parse( _dRow["HotelId"].ToString() );
				loTransactionCode.CreateTime = DateTime.Parse( _dRow["CreateTime"].ToString() );
				loTransactionCode.CreatedBy = _dRow["CreatedBy"].ToString();
				loTransactionCode.UpdateTime = DateTime.Parse( _dRow["UpdateTime"].ToString() );
				loTransactionCode.UpdatedBy = _dRow["UpdatedBy"].ToString();
			

                return loTransactionCode;
            }
            catch (Exception ex)
            {
				throw ex;
                //MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                //return null;
            }
        }

        public object loadObject()
        {
            try
            {
                loTransactionCode = new TransactionCode();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectTransactionCodes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );
                dataAdapter.Fill(loTransactionCode, "Transaction Codes");

                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = loTransactionCode.Tables[0].Columns["TranCode"];
                loTransactionCode.Tables[0].PrimaryKey = primaryKey;

                return loTransactionCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public DataTable getTransactionCodes()
        {
            try
            {
                loTransactionCode = new TransactionCode();

                //MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetTransactionCodesWithSubAccounts('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectTransactionCodes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection); DataTable dTable = new DataTable("Transaction Codes");
                dataAdapter.Fill(dTable);

                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertObject(ref TransactionCode a_TransactionCode)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand insertCommand = new MySqlCommand("call spInsertTransactionCode('" +
                                                                a_TransactionCode.TranCode + "','" +
                                                                a_TransactionCode.TranTypeId + "','" +
                                                                a_TransactionCode.Memo + "','" +
                                                                a_TransactionCode.AcctSide + "','" +
                                                                a_TransactionCode.ServiceCharge + "'," +
                                                                a_TransactionCode.ServiceChargeInclusive + ",'" +
                                                                a_TransactionCode.GovtTax + "'," +
                                                                a_TransactionCode.GovtTaxInclusive + ",'" +
                                                                a_TransactionCode.LocalTax + "'," +
                                                                a_TransactionCode.LocalTaxInclusive + ",'" +
                                                                a_TransactionCode.DefaultTransactionSource + "','" +
                                                                a_TransactionCode.DefaultAmount + "','" +
                                                                a_TransactionCode.WarningAmount + "','" +
                                                                a_TransactionCode.DepartmentId + "','" +
                                                                a_TransactionCode.Ledger + "','" +
                                                                a_TransactionCode.DebitSide + "','" +
                                                                a_TransactionCode.CreditSide + "','" +
                                                                a_TransactionCode.HotelID + "','" +
                                                                a_TransactionCode.CreatedBy
                                                                + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = insertCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    insertDataRow(ref a_TransactionCode);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");

                return 0;
            }
        }

        public int updateObject(ref TransactionCode a_TransactionCode)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spUpdateTransactionCode('" +
																   a_TransactionCode.TranCode + "','" +
																   a_TransactionCode.TranTypeId + "','" +
																   a_TransactionCode.Memo + "','" +
																   a_TransactionCode.AcctSide + "','" +
																   a_TransactionCode.ServiceCharge + "'," +
																   a_TransactionCode.ServiceChargeInclusive + ",'" +
																   a_TransactionCode.GovtTax + "'," +
																   a_TransactionCode.GovtTaxInclusive + ",'" +
																   a_TransactionCode.LocalTax + "'," +
																   a_TransactionCode.LocalTaxInclusive + ",'" +
																   a_TransactionCode.DefaultTransactionSource + "','" +
																   a_TransactionCode.DefaultAmount + "','" +
																   a_TransactionCode.WarningAmount + "','" +
																   a_TransactionCode.DepartmentId + "','" +
																   a_TransactionCode.Ledger + "','" +
																   a_TransactionCode.DebitSide + "','" +
																   a_TransactionCode.CreditSide + "','" +
																   a_TransactionCode.HotelID + "','" +
																   a_TransactionCode.UpdatedBy
																   + "')", GlobalVariables.gPersistentConnection);
                
				rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    updateDataRow(ref a_TransactionCode);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public int deleteObject(ref TransactionCode a_TransactionCode)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand deleteCommand = new MySqlCommand("call spDeleteTransactionCode('" + a_TransactionCode.TranCode + "','" + GlobalVariables.gLoggedOnUser + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    deleteDataRow(ref a_TransactionCode);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public void insertDataRow(ref TransactionCode a_TransactionCode)
        {
            try
            {
                DataRow dataRow = a_TransactionCode.Tables["Transaction Codes"].NewRow();

                dataRow["TranCode"] = a_TransactionCode.TranCode;
                dataRow["TranTypeId"] = a_TransactionCode.TranTypeId;
                
                dataRow["Memo"] = a_TransactionCode.Memo;
                dataRow["AcctSide"] = a_TransactionCode.AcctSide;
                
                dataRow["ServiceCharge"] = a_TransactionCode.ServiceCharge;
				dataRow["ServiceChargeInclusive"] = a_TransactionCode.ServiceChargeInclusive;

                dataRow["GovtTax"] = a_TransactionCode.GovtTax;
				dataRow["GovtTaxInclusive"] = a_TransactionCode.GovtTaxInclusive;

                dataRow["LocalTax"] = a_TransactionCode.LocalTax;
				dataRow["LocalTaxInclusive"] = a_TransactionCode.LocalTaxInclusive;

				dataRow["DefaultTransactionSource"] = a_TransactionCode.DefaultTransactionSource;
                dataRow["DefaultAmount"] = a_TransactionCode.DefaultAmount;
                dataRow["WarningAmount"] = a_TransactionCode.WarningAmount;

				dataRow["DepartmentId"] = a_TransactionCode.DepartmentId;
				dataRow["Ledger"] = a_TransactionCode.Ledger;
				dataRow["DebitSide"] = a_TransactionCode.DebitSide;
				dataRow["CreditSide"] = a_TransactionCode.CreditSide;

                dataRow["createdby"] = a_TransactionCode.CreatedBy;
                dataRow["createtime"] = DateTime.Now;
                dataRow["updatetime"] = DateTime.Now;
                dataRow["updatedby"] = a_TransactionCode.CreatedBy;

                a_TransactionCode.Tables["Transaction Codes"].Rows.Add(dataRow);
                a_TransactionCode.Tables["Transaction Codes"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Data Row Exception");
            }
        }

        public void updateDataRow(ref TransactionCode a_TransactionCode)
        {
            try
            {
                DataRow dataRow = a_TransactionCode.Tables["Transaction Codes"].Rows.Find(a_TransactionCode.TranCode);

                dataRow.BeginEdit();
				dataRow["TranCode"] = a_TransactionCode.TranCode;
				dataRow["TranTypeId"] = a_TransactionCode.TranTypeId;

				dataRow["Memo"] = a_TransactionCode.Memo;
				dataRow["AcctSide"] = a_TransactionCode.AcctSide;

				dataRow["ServiceCharge"] = a_TransactionCode.ServiceCharge;
				dataRow["ServiceChargeInclusive"] = a_TransactionCode.ServiceChargeInclusive;

				dataRow["GovtTax"] = a_TransactionCode.GovtTax;
				dataRow["GovtTaxInclusive"] = a_TransactionCode.GovtTaxInclusive;

				dataRow["LocalTax"] = a_TransactionCode.LocalTax;
				dataRow["LocalTaxInclusive"] = a_TransactionCode.LocalTaxInclusive;

				dataRow["DefaultTransactionSource"] = a_TransactionCode.DefaultTransactionSource;
				dataRow["DefaultAmount"] = a_TransactionCode.DefaultAmount;
				dataRow["WarningAmount"] = a_TransactionCode.WarningAmount;

				dataRow["DepartmentId"] = a_TransactionCode.DepartmentId;
				dataRow["Ledger"] = a_TransactionCode.Ledger;
				dataRow["DebitSide"] = a_TransactionCode.DebitSide;
				dataRow["CreditSide"] = a_TransactionCode.CreditSide;

				dataRow["createdby"] = a_TransactionCode.CreatedBy;
				dataRow["createtime"] = DateTime.Now;
				dataRow["updatetime"] = DateTime.Now;
				dataRow["updatedby"] = a_TransactionCode.UpdatedBy;

                dataRow.EndEdit();
                dataRow.AcceptChanges();
                a_TransactionCode.Tables["Transaction Codes"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Row Exception");
            }
        }

        public void deleteDataRow(ref TransactionCode a_TransactionCode)
        {
            try
            {
                DataRow row = a_TransactionCode.Tables["Transaction Codes"].Rows.Find(a_TransactionCode.TranCode);
                a_TransactionCode.Tables["Transaction Codes"].Rows.Remove(row);
                a_TransactionCode.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Data Row Exception");
            }
        }

    }
}