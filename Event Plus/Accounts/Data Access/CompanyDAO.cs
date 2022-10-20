using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.Accounts.DataAccessLayer
{
        public class CompanyDAO 
		{
            private Company oCompany ;
			private DataReaderToDatasetConverter oDateSetConverter ;
			private ParameterHelper oParameterHelper ;
			private DataReaderBinder oDataReaderBinder;
			private DataReaderToDatasetConverter oDatasetConverter ;

			public CompanyDAO()
            {
                oCompany = new Company();
                oDateSetConverter = new DataReaderToDatasetConverter();
                oParameterHelper = new ParameterHelper();
                oDataReaderBinder = new DataReaderBinder();
                oDatasetConverter = new DataReaderToDatasetConverter();
            }

		    public Company getCompanyAccountsData()
			{
				
				oCompany = new Company();
				try
				{
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectCompany('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
					
					dataAdapter.Fill(oCompany, "CompanyAccounts");
					dataAdapter.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oCompany.Tables["CompanyAccounts"].Columns["CompanyId"];
					oCompany.Tables["CompanyAccounts"].PrimaryKey = primaryKey;
					
					return oCompany;
					
				}
				catch (Exception ex)
				{
                    MessageBox.Show("EXCEPTION: @ GetCompanyAccountsData() " + ex.Message);
					return null;
				}
			}
			
			public int insertObject(ref Company a_Company)
			{
				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				try
				{
                    int rowsAffected = 0;
                    string strInsert = "call spInsertCompanyAccount('" + a_Company.CompanyId
                                        + "','" + a_Company.CompanyCode
                                        + "','" + a_Company.CompanyName
                                        + "','" + a_Company.CompanyURL
                                        + "','" + a_Company.ContactPerson
                                        + "','" + a_Company.Designation
                                        + "','" + a_Company.Street1
                                        + "','" + a_Company.City1
                                        + "','" + a_Company.Country1
                                        + "','" + a_Company.Zip1
                                        + "','" + a_Company.Street2
                                        + "','" + a_Company.City2
                                        + "','" + a_Company.Country2
                                        + "','" + a_Company.Zip2
                                        + "','" + a_Company.Street3
                                        + "','" + a_Company.City3
                                        + "','" + a_Company.Country3
                                        + "','" + a_Company.Zip3
                                        + "','" + a_Company.Email1
                                        + "','" + a_Company.Email2
                                        + "','" + a_Company.Email3
                                        + "','" + a_Company.ContactNumber1
                                        + "','" + a_Company.ContactNumber2
                                        + "','" + a_Company.ContactNumber3
                                        + "','" + a_Company.ContactType1
                                        + "','" + a_Company.ContactType2
                                        + "','" + a_Company.ContactType3
                                        + "','" + GlobalVariables.gHotelId.ToString() 
                                        + "','" + GlobalVariables.gLoggedOnUser 
										+ "','" + a_Company.ACCOUNT_TYPE 
                                        + "','" + a_Company.CARD_NO 
										+ "'," + a_Company.THRESHOLD_VALUE 
                                        + "," + a_Company.NO_OF_VISIT 
										+ "," + a_Company.TOTAL_SALES_CONTRIBUTION 
                                        + "," + a_Company.X_DEAL_AMOUNT
                                        + ",'" + a_Company.Remarks 
                                        + "','" + a_Company.TIN + "')";

					MySqlCommand commandInsert = new MySqlCommand(strInsert, GlobalVariables.gPersistentConnection);
					commandInsert.Transaction = trans;

                    try
                    {
                        // save Privileges
                        if (a_Company.AccountPrivileges != null)
                            savePrivileges(a_Company, ref trans);

                        //save account information
                        if (a_Company.AccountInformation != null)
                            a_Company.AccountInformation.save(ref trans);

                        //save contactpersons
                        if (a_Company.ContactPersons != null)
                        {
                            ContactPerson _cp = new ContactPerson();
                            _cp.deleteContactPersons(a_Company.CompanyId, GlobalVariables.gHotelId.ToString(), ref trans);
                            foreach (ContactPerson _contactPerson in a_Company.ContactPersons)
                            {
                                _contactPerson.save(ref trans);
                            }
                        }
                    }
                    catch { }

                    rowsAffected = commandInsert.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(ref a_Company);
                    }

					trans.Commit();
                    return rowsAffected;
			    }
				catch (Exception ex)
				{
					trans.Rollback();
                    MessageBox.Show("EXCEPTION: @ insertObject() " + ex.Message);
					return 0;
				}
			
            }

            public Company FilterGuestRecord(string a_fld, string a_tbl, string a_whr)
			{
			    MySqlCommand filterGuestCommand = new MySqlCommand("Select " + a_fld + " from " + a_tbl + a_whr, GlobalVariables.gPersistentConnection);
				MySqlDataReader dataReaderCompany = filterGuestCommand.ExecuteReader();

				DataSet temp_SystemDataDataSet = oCompany;
                oDatasetConverter.convertDataReaderToDataSet(dataReaderCompany, "Company", temp_SystemDataDataSet);
				dataReaderCompany.Close();

				return oCompany;
				
			}

			public int deleteObject(string a_CompanyId, Company a_Company)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand deleteCommand = new MySqlCommand("call spDeleteCompany(\'" + a_CompanyId + "\',\'" + GlobalVariables.gHotelId + "\',\'" + GlobalVariables.gLoggedOnUser + "\')", GlobalVariables.gPersistentConnection);
					rowsAffected=deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        deleteDataRow(a_CompanyId, a_Company);
                    }
                    return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show("EXCEPTION: @ deleteObject " + ex.Message);
					return 0;
				}
			}
         
			public int updateObject(object a_PrimaryKeyVal, ref Company a_Company)
			{
				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				try
				{
                    int rowsAffected = 0;

					string strUpdate = "call spUpdateCompanyAccount('" + a_Company.CompanyId 
										+ "','" + a_Company.CompanyCode + "','" + a_Company.CompanyName 
										+ "','" + a_Company.CompanyURL + "','" + a_Company.ContactPerson 
										+ "','" + a_Company.Designation + "','" + a_Company.Street1 
										+ "','" + a_Company.City1 + "','" + a_Company.Country1 
										+ "','" + a_Company.Zip1 + "','" + a_Company.Street2 
										+ "','" + a_Company.City2 + "','" + a_Company.Country2 
										+ "','" + a_Company.Zip2 + "','" + a_Company.Street3 
										+ "','" + a_Company.City3 + "','" + a_Company.Country3 
										+ "','" + a_Company.Zip3 + "','" + a_Company.Email1 
										+ "','" + a_Company.Email2 + "','" + a_Company.Email3 
										+ "','" + a_Company.ContactNumber1 + "','" + a_Company.ContactNumber2 
										+ "','" + a_Company.ContactNumber3 + "','" + a_Company.ContactType1 
										+ "','" + a_Company.ContactType2 + "','" + a_Company.ContactType3 
										+ "','" + GlobalVariables.gLoggedOnUser + "','" + GlobalVariables.gHotelId
										+ "','" + a_Company.ACCOUNT_TYPE + "','" + a_Company.CARD_NO
										+ "'," + a_Company.THRESHOLD_VALUE + "," + a_Company.X_DEAL_AMOUNT + ",'" + a_Company.Remarks +"','" + a_Company.TIN + "')";

					MySqlCommand updateCommand = new MySqlCommand(strUpdate, GlobalVariables.gPersistentConnection);

					updateCommand.Transaction = trans;
					rowsAffected = updateCommand.ExecuteNonQuery();
                   
					// save Privileges
                    if (a_Company.AccountPrivileges != null)
                    {
                        // THIS SECTION WILL NOT BE EXECUTED IN EVENT+. ONLY FOLIO+. UNABLE TO INSERT ACCOUNT PRIVILEGES IN EVENT+.
                        savePrivileges(a_Company, ref trans);
                    }

                    //save account information
                    if (a_Company.AccountInformation != null)
                        a_Company.AccountInformation.update(ref trans);

                    //save contactpersons
                    if (a_Company.ContactPersons != null)
                    {
                        // THIS SECTION WILL NOT BE EXECUTED IN EVENT+. ONLY FOLIO+. UNABLE TO INSERT CONTACT IN EVENT+.
                        ContactPerson _cp = new ContactPerson();
                        _cp.deleteContactPersons(a_Company.CompanyId, GlobalVariables.gHotelId.ToString(), ref trans);
                        foreach (ContactPerson _contactPerson in a_Company.ContactPersons)
                        {
                            _contactPerson.save(ref trans);
                        }
                    }

                    if (rowsAffected > 0)
                    {
                        if (a_Company.Tables.Count > 0)
                        {
                            updateDataRow(a_PrimaryKeyVal, a_Company);
                        }
                    }

                    trans.Commit();

					return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show("EXCEPTION: @ updatecompany() " + ex.Message);
					return 0;
				}
			}
           
			public Company getCompanyAccounts()
			{
				try
                {
				    oCompany = new Company();
				    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spDisplayCompanyAccounts()", GlobalVariables.gPersistentConnection);
    				
				    dataAdapter.Fill(oCompany, "Company");
				    dataAdapter.Dispose();
				    return oCompany;
				}
                catch(Exception ex)
                {
                    MessageBox.Show("EXCEPTION: @ getCompanyAccounts() " + ex.Message);
                    return null;
                }

			}
			
            public Company getCompanyAccount(string a_Companyid)
            {
                try
                {
                    Company oCompany = new Company();

                    MySqlCommand selectCommand = new MySqlCommand("call spGetCompanyAccount('" + a_Companyid + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                    //getCompanyAccountCommand.CommandType = CommandType.StoredProcedure;

                    //MySqlParameter companyidparam = new MySqlParameter();
                    //MySqlParameter paramCompanyCode = new MySqlParameter();
                    //MySqlParameter paramHotelID = new MySqlParameter();

                    //ParameterHelper paramHelper = new ParameterHelper();
                    //paramHelper.AddParameters(companyidparam, "pCompanyid", ParameterDirection.Input, DbType.String, a_Companyid, getCompanyAccountCommand);
                    //paramHelper.AddParameters(paramCompanyCode, "pCompanyCode", ParameterDirection.Input, DbType.String, a_CompanyCode, getCompanyAccountCommand);
                    //paramHelper.AddParameters(paramHotelID, "pHotelid", ParameterDirection.Input, DbType.Int64, GlobalVariables.gHotelId.ToString(), getCompanyAccountCommand);


                    MySqlDataReader guestDataReader = selectCommand.ExecuteReader();

                    Object tmp = oCompany;
                    oDataReaderBinder.BinderReaderToEntity(guestDataReader, ref tmp);
                    guestDataReader.Close();

                    return oCompany;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION: @ getCompanyAccount() " + ex.Message);
                    return null;
                }


            }

            public bool getCompanyByName(string comp_name)
            {
                try
                {
                    oCompany = new Company();

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetCompanyByName(\'" + comp_name + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(oCompany, "Company");
                    if (oCompany.Tables[0].Rows.Count > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ getCompanyByName() " + ex.Message);
                    return false;
                }

            }

			public Company getCompanyInfo(string a_FolioId)
			{
				try
				{
					oCompany = new Company();
					
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetCompanyInfo(\'" + a_FolioId + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oCompany, "Company");
					
					oCompany.CompanyId = oCompany.Tables[0].Rows[0]["companyId"].ToString();
					oCompany.CompanyCode = oCompany.Tables[0].Rows[0]["companyCode"].ToString();
					oCompany.CompanyName = oCompany.Tables[0].Rows[0]["companyName"].ToString();
					oCompany.CompanyURL = oCompany.Tables[0].Rows[0]["companyUrl"].ToString();
					oCompany.ContactPerson = oCompany.Tables[0].Rows[0]["contactPerson"].ToString();
					oCompany.Designation = oCompany.Tables[0].Rows[0]["Designation"].ToString();
					
					return oCompany;
				}
				catch
				{
					//MessageBox.Show("EXCEPTION : @ GetCompanyAccount() " + ex.Message);
                    return null;
				}
			
			}

            private void insertDataRow(ref Company a_Company)
            {
                try
                {
                    DataRow dataRow = a_Company.Tables[0].NewRow();
                    dataRow["CompanyId"] = a_Company.CompanyId;
                    dataRow["CompanyName"] = a_Company.CompanyName;
                    dataRow["CompanyCode"] = a_Company.CompanyCode;
                    dataRow["CompanyURL"] = a_Company.CompanyURL;
                    dataRow["ContactPerson"] = a_Company.ContactPerson;
                    dataRow["Designation"] = a_Company.Designation;
                    dataRow["Street1"] = a_Company.Street1;
                    dataRow["City1"] = a_Company.City1;
                    dataRow["Country1"] = a_Company.Country1;
                    dataRow["Zip1"] = a_Company.Zip1;
                    dataRow["Street2"] = a_Company.Street2;
                    dataRow["City2"] = a_Company.City2;
                    dataRow["Country2"] = a_Company.Country2;
                    dataRow["Zip2"] = a_Company.Zip2;
                    dataRow["Street3"] = a_Company.Street3;
                    dataRow["City3"] = a_Company.City3;
                    dataRow["Country3"] = a_Company.Country3;
                    dataRow["Zip3"] = a_Company.Zip3;
                    dataRow["Email1"] = a_Company.Email1;
                    dataRow["Email2"] = a_Company.Email2;
                    dataRow["Email3"] = a_Company.Email3;
                    dataRow["ContactNumber1"] = a_Company.ContactNumber1;
                    dataRow["ContactNumber2"] = a_Company.ContactNumber2;
                    dataRow["ContactNumber3"] = a_Company.ContactNumber3;
                    dataRow["ContactType1"] = a_Company.ContactType1;
                    dataRow["ContactType2"] = a_Company.ContactType2;
                    dataRow["ContactType3"] = a_Company.ContactType3;
					dataRow["Remarks"] = a_Company.Remarks;
                    dataRow["ACCOUNT_TYPE"] = a_Company.ACCOUNT_TYPE;
                    dataRow["CARD_NO"] = a_Company.CARD_NO;
                    dataRow["THRESHOLD_VALUE"] = a_Company.THRESHOLD_VALUE;
                    dataRow["NO_OF_VISIT"] = a_Company.NO_OF_VISIT;
                    dataRow["TOTAL_SALES_CONTRIBUTION"] = a_Company.TOTAL_SALES_CONTRIBUTION;
                    dataRow["X_DEAL_AMOUNT"] = a_Company.X_DEAL_AMOUNT;
                    dataRow["CREATETIME"] = a_Company.CreateTime;

                    a_Company.Tables["CompanyAccounts"].Rows.Add(dataRow);
                }
                catch (Exception) { }
            }

            private void updateDataRow(object a_PrimaryKeyVal, Company a_Company)
            {
                DataRow dataRow = a_Company.Tables["CompanyAccounts"].Rows.Find(a_PrimaryKeyVal);
                dataRow.BeginEdit();

                dataRow["CompanyId"] = a_Company.CompanyId;
                dataRow["CompanyName"] = a_Company.CompanyName;
                dataRow["CompanyCode"] = a_Company.CompanyCode;
                dataRow["CompanyURL"] = a_Company.CompanyURL;
                dataRow["ContactPerson"] = a_Company.ContactPerson;
                dataRow["Designation"] = a_Company.Designation;
                dataRow["Street1"] = a_Company.Street1;
                dataRow["City1"] = a_Company.City1;
                dataRow["Country1"] = a_Company.Country1;
                dataRow["Zip1"] = a_Company.Zip1;
                dataRow["Street2"] = a_Company.Street2;
                dataRow["City2"] = a_Company.City2;
                dataRow["Country2"] = a_Company.Country2;
                dataRow["Zip2"] = a_Company.Zip2;
                dataRow["Street3"] = a_Company.Street3;
                dataRow["City3"] = a_Company.City3;
                dataRow["Country3"] = a_Company.Country3;
                dataRow["Zip3"] = a_Company.Zip3;
                dataRow["Email1"] = a_Company.Email1;
                dataRow["Email2"] = a_Company.Email2;
                dataRow["Email3"] = a_Company.Email3;
                dataRow["ContactNumber1"] = a_Company.ContactNumber1;
                dataRow["ContactNumber2"] = a_Company.ContactNumber2;
                dataRow["ContactNumber3"] = a_Company.ContactNumber3;
                dataRow["ContactType1"] = a_Company.ContactType1;
                dataRow["ContactType2"] = a_Company.ContactType2;
                dataRow["ContactType3"] = a_Company.ContactType3;
				dataRow["Remarks"] = a_Company.Remarks;
                dataRow["ACCOUNT_TYPE"] = a_Company.ACCOUNT_TYPE;
                dataRow["CARD_NO"] = a_Company.CARD_NO;
                dataRow["THRESHOLD_VALUE"] = a_Company.THRESHOLD_VALUE;
                dataRow["NO_OF_VISIT"] = a_Company.NO_OF_VISIT;
                dataRow["TOTAL_SALES_CONTRIBUTION"] = a_Company.TOTAL_SALES_CONTRIBUTION;
                dataRow["X_DEAL_AMOUNT"] = a_Company.X_DEAL_AMOUNT;
                dataRow["CREATETIME"] = a_Company.CreateTime;

                dataRow.EndEdit();
                dataRow.AcceptChanges();
                a_Company.Tables["CompanyAccounts"].AcceptChanges();
            }

            private void deleteDataRow(string a_CompanyId, Company a_Company)
            {
                DataRow row = a_Company.Tables["CompanyAccounts"].Rows.Find(a_CompanyId);
                a_Company.Tables["CompanyAccounts"].Rows.Remove(row);
                a_Company.AcceptChanges();
            }

			public void savePrivileges(Company a_Company, ref MySqlTransaction trans)
			{
				// saves privileges
				string strDeletePrivs = "call spDeleteAccountPrivileges('" + a_Company.CompanyId + "','" + GlobalVariables.gHotelId + "')";
				MySqlCommand deleteCommand = new MySqlCommand(strDeletePrivs, GlobalVariables.gPersistentConnection);
				deleteCommand.Transaction = trans;
				deleteCommand.ExecuteNonQuery();

				foreach (PrivilegeHeader privilege in a_Company.AccountPrivileges)
				{
					try
					{
						
						string strPrivInsert = "call spInsertAccountPrivilege(" + GlobalVariables.gHotelId + ",'" + a_Company.CompanyId
												+ "','" + privilege.PrivilegeID + "','" + GlobalVariables.gLoggedOnUser + "')";

						MySqlCommand insertPrivileges = new MySqlCommand(strPrivInsert, GlobalVariables.gPersistentConnection);
						insertPrivileges.Transaction = trans;

						insertPrivileges.ExecuteNonQuery();
					}
					catch { }
				}
			}

			public int updateAccountTotalSales(string a_AccountId, double a_Amount)
			{
				try
				{
					int rowsAffected = 0;

					string strUpdate = "call spUpdateCompanyAccountTotalSales('" + a_AccountId
										+ "'," + a_Amount + ",'" + GlobalVariables.gHotelId
										+ "')";

					MySqlCommand updateCommand = new MySqlCommand(strUpdate, GlobalVariables.gPersistentConnection);
					rowsAffected = updateCommand.ExecuteNonQuery();

					return rowsAffected;
				}
				catch (Exception ex)
				{
					throw (ex);
				}

			}

			public int setNoOfVisits(string a_CompanyId)
			{
				try
				{
					int rowsAffected = 0;

					string strUpdate = "call spSetCompanyNoOfVisits('" + a_CompanyId
										   + "','" + GlobalVariables.gHotelId + "')";

					MySqlCommand updateCommand = new MySqlCommand(strUpdate, GlobalVariables.gPersistentConnection);
					rowsAffected = updateCommand.ExecuteNonQuery();

					return rowsAffected;
				}
				catch (Exception ex)
				{
					throw (ex);
				}


			}

			public int deductXDealAmount(string a_CompanyId, double a_Amount)
			{
				try
				{
					int rowsAffected = 0;

					string strUpdate = "call spDeductCompanyXDealAmount('" + a_CompanyId
										   + "'," + a_Amount 
										   + ",'" + GlobalVariables.gHotelId + "')";

					MySqlCommand updateCommand = new MySqlCommand(strUpdate, GlobalVariables.gPersistentConnection);
					rowsAffected = updateCommand.ExecuteNonQuery();

					return rowsAffected;
				}
				catch (Exception ex)
				{
					throw (ex);
				}


			}

			public void UpdateFolio_Merge(string a_NewAccount, string a_OldAccount, ref MySqlTransaction a_Trans)
			{
				try
				{
					string strQuery = "call spUpdateFolio_MergeCompany('" + a_NewAccount
									  + "','" + a_OldAccount + "'," + GlobalVariables.gHotelId + ")";

					MySqlCommand updateCommandFolio = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					updateCommandFolio.Transaction = a_Trans;
					updateCommandFolio.ExecuteNonQuery();


					strQuery = "call spUpdateFolioLedger_MergeCompany('" + a_NewAccount
								+ "','" + a_OldAccount + "'," + GlobalVariables.gHotelId + ")";

					MySqlCommand updateCommandFolioLedger = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					updateCommandFolioLedger.Transaction = a_Trans;
					updateCommandFolioLedger.ExecuteNonQuery();


					strQuery = "call spUpdateFolioTransactions_MergeCompany('" + a_NewAccount
							    + "','" + a_OldAccount + "'," + GlobalVariables.gHotelId + ")";

					MySqlCommand updateCommandFolioTrans = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					updateCommandFolioTrans.Transaction = a_Trans;

					updateCommandFolioTrans.ExecuteNonQuery();

					strQuery = "call spDeleteCompany('" + a_OldAccount + "','" + GlobalVariables.gHotelId 
						        + "','" + GlobalVariables.gLoggedOnUser + "')";
					MySqlCommand deleteCommand = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					deleteCommand.Transaction = a_Trans;
					deleteCommand.ExecuteNonQuery();

				}

				catch (Exception ex)
				{
					throw (ex);
				}
			}

			public IList<PrivilegeHeader> getAccountPrivileges(string pAccountId)
			{
				try
				{
					IList<PrivilegeHeader> oAccountPrivileges = new List<PrivilegeHeader>();
					
					DataTable dtPrivileges = new DataTable();

					MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetAccountPrivileges('" + pAccountId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
					dtAdapter.Fill(dtPrivileges);


					foreach (DataRow dtRow in dtPrivileges.Rows)
					{

						PrivilegeHeader oPrivilege = new PrivilegeHeader();

						oPrivilege.PrivilegeID = dtRow["PrivilegeID"].ToString();
						oPrivilege.Description = dtRow["Description"].ToString();
						oPrivilege.DaysApplied = dtRow["DaysApplied"].ToString();
						oPrivilege.CreatedBy = dtRow["CreatedBy"].ToString();
						oPrivilege.CreatedDate = dtRow["CreatedDate"].ToString();

						oAccountPrivileges.Add(oPrivilege);
					}
					
					//a_Company.AccountPrivileges = oAccountPrivileges;
					return oAccountPrivileges;

				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: @ GetAccountPrivileges() " + ex.Message);
					return null;
				}
			}




			public DataTable getCompanyAsDataTable()
			{

				try
				{
					DataTable company = new DataTable("company");
					string query = "call spSelectCompany('"
									+ GlobalVariables.gHotelId + "')";

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);

					dataAdapter.Fill(company);
					dataAdapter.Dispose();

					return company;

				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}

			//transferred here for SPEED optimization
			public DataTable getCompanyAsDataTableByCompanyID(string pCompanyID)
			{
				try
				{
					DataTable tempTable = new DataTable();

					string query = "call spSelectCompanyByCompanyID('"
									+ pCompanyID + "','" + GlobalVariables.gHotelId + "')";

					MySqlDataAdapter dataAdapterGuest = new MySqlDataAdapter(query,
															GlobalVariables.gPersistentConnection);

					dataAdapterGuest.Fill(tempTable);
					dataAdapterGuest.Dispose();


					return tempTable;
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}


			//transferred here for SPEED optimization
			public DataTable getCompanyInfoAsDataTableByName(string pCompanyName)
			{
				try
				{
					DataTable tempTable = new DataTable();

					string query = "call spSelectCompanyByName('"
									+ pCompanyName + "','"
									+ GlobalVariables.gHotelId + "')";

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(
														query,
														GlobalVariables.gPersistentConnection);

					dataAdapter.Fill(tempTable);
					dataAdapter.Dispose();


					return tempTable;
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}

			public DataTable getCompanyInfoAsDataTableByNameUsingLike(string pCompanyName)
			{
				try
				{
					DataTable tempTable = new DataTable();

					string query = "call spSelectCompanyByNameUsingLike('"
									+ pCompanyName + "','"
									+ GlobalVariables.gHotelId + "')";

					MySqlDataAdapter dataAdapterGuest = new MySqlDataAdapter(query,
															GlobalVariables.gPersistentConnection);

					dataAdapterGuest.Fill(tempTable);
					dataAdapterGuest.Dispose();


					return tempTable;
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}
            public DataTable getCompanyJournal(string pCompanyName)
            {
                try
                {
                    DataTable tempTable = new DataTable();

                    string query = "call spGetCompanyJournal('"
                                    + pCompanyName + "','"
                                    + GlobalVariables.gHotelId + "')";

                    MySqlDataAdapter dataAdapterGuest = new MySqlDataAdapter(query,
                                                            GlobalVariables.gPersistentConnection);

                    dataAdapterGuest.Fill(tempTable);
                    dataAdapterGuest.Dispose();


                    return tempTable;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public void insertCompanyJournal(string pCompanyID, string pRemarks, DateTime pDate)
            {
                try
                {
                    int rowsAffected = 0;

                    string strUpdate = "call spInsertCompanyJournal('" + pCompanyID
                                        + "','" + pRemarks + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pDate) + "','" + GlobalVariables.gLoggedOnUser + "','" + GlobalVariables.gHotelId
                                        + "')";

                    MySqlCommand updateCommand = new MySqlCommand(strUpdate, GlobalVariables.gPersistentConnection);
                    rowsAffected = updateCommand.ExecuteNonQuery();

                 
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public void deleteCompanyJournal(string pCompanyID)
            {
                try
                {
                    int rowsAffected = 0;

                    string strDelete = "call spDeleteCompanyJournal('" + pCompanyID+"')";

                    MySqlCommand updateCommand = new MySqlCommand(strDelete, GlobalVariables.gPersistentConnection);
                    rowsAffected = updateCommand.ExecuteNonQuery();

                  
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
		


	}
}
