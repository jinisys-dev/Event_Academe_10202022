using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace DataAccessLayer
	{
		public class CurrencyCodeDAO 
		{
			
			
			private CurrencyCode oCurrencyCode;
			public CurrencyCodeDAO()
			{
			}

            public object loadObject()
			{
				try
				{
					oCurrencyCode = new CurrencyCode();
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("Call spSelectCurrencyCodes(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oCurrencyCode, "CurrencyCode");
					dataAdapter.Dispose();
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oCurrencyCode.Tables["CurrencyCode"].Columns["currencycode"];
					oCurrencyCode.Tables["CurrencyCode"].PrimaryKey = primaryKey;
					return oCurrencyCode;
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Retrieve Rows Exception");
					return null;
				}
			}
			
			public int insertObject(ref CurrencyCode currencyCode)
			{
				try
				{
                    int rowsAffected = 0;
					string sql = "Call spInsertCurrencyCode('" + currencyCode.CurCode + "','" + currencyCode.Currency + "'," + currencyCode.ConversionRate + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                    MySqlCommand insertCommand = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                    rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(currencyCode);
                    }
                    return rowsAffected;
                }
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Database Update Exception");

					return 0;
				}
			}

            public int updateObject(ref CurrencyCode currencyCode)
			{
				try
				{
                    int rowsAffected = 0;
					string sql = "Call spupdateCurrencyCode('" + currencyCode.CurCode + "','" + currencyCode.Currency + "'," + currencyCode.ConversionRate + ",'" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')";
                    MySqlCommand updateCommand = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                    rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        updateDataRow(currencyCode);
                    }

                        return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Database Update Exception");
					return 0;
				}
			}
            public int deleteObject(CurrencyCode a_CurrencyCode)
			{
				try
				{
                    int rowsAffected = 0;
                    string sql = "Call spdeleteCurrencyCode('" + a_CurrencyCode.CurCode + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                    MySqlCommand deleteCommand = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
					rowsAffected=deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        deleteDataRow(a_CurrencyCode);
                    }
					return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Database Update Exception");
					return 0;
				}
			}

            public void insertDataRow(CurrencyCode a_CurrencyCode)
            {
                try
                {
                    DataRow dRow = a_CurrencyCode.Tables["CurrencyCode"].NewRow();
                    dRow["currencycode"] = a_CurrencyCode.CurCode;
                    dRow["currency"] = a_CurrencyCode.Currency;
                    dRow["conversionrate"] = a_CurrencyCode.ConversionRate;

                    a_CurrencyCode.Tables["CurrencyCode"].Rows.Add(dRow);
                    a_CurrencyCode.Tables["CurrencyCode"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Data Row Exception");
                }
            }


            public void updateDataRow(CurrencyCode a_CurrencyCode)
            {
                try
                {
                    DataRow dRow = a_CurrencyCode.Tables["CurrencyCode"].Rows.Find(a_CurrencyCode.CurCode);
                    dRow.BeginEdit();
                    dRow["currency"] = a_CurrencyCode.Currency;
                    dRow["conversionrate"] = a_CurrencyCode.ConversionRate;
                    dRow.EndEdit();

                    dRow.AcceptChanges();
                    a_CurrencyCode.Tables["CurrencyCode"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Data Row Exception");
                }
            }

            public void deleteDataRow(CurrencyCode a_CurrencyCode)
            {
                try
                {
                    object primaryKeyVal = new object();
                    primaryKeyVal = a_CurrencyCode.CurCode;

                    DataRow row = a_CurrencyCode.Tables["CurrencyCode"].Rows.Find(primaryKeyVal);
                    a_CurrencyCode.Tables["CurrencyCode"].Rows.Remove(row);
                    a_CurrencyCode.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Data Row Exception");
                }
            }
		}
	}
	
}
