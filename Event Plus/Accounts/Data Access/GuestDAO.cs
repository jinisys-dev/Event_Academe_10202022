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
	    public class GuestDAO 
		{
            private Guest loGuest;
			//private DataReaderToDatasetConverter oDataSetConverter;
			//private ParameterHelper oParameterHelper;
			//private DataReaderBinder oDataReaderBinder;

		    public GuestDAO()
			{
				//oDataSetConverter = new DataReaderToDatasetConverter();
				//oParameterHelper = new ParameterHelper();
				//oDataReaderBinder = new DataReaderBinder();
			}

			public void savePrivileges(Guest a_Guest, ref MySqlTransaction trans)
			{
				// saves privileges
				string strDeletePrivs = "call spDeleteAccountPrivileges('" + a_Guest.AccountId + "','" + GlobalVariables.gHotelId + "')";
				MySqlCommand deleteCommand = new MySqlCommand(strDeletePrivs, GlobalVariables.gPersistentConnection);
				deleteCommand.Transaction = trans;
				deleteCommand.ExecuteNonQuery();

				if (a_Guest.AccountPrivileges != null)
				{
					foreach (PrivilegeHeader privilege in a_Guest.AccountPrivileges)
					{
						try
						{

							string strPrivInsert = "call spInsertAccountPrivilege(" + GlobalVariables.gHotelId + ",'" + a_Guest.AccountId
													+ "','" + privilege.PrivilegeID + "','" + GlobalVariables.gLoggedOnUser + "')";

							MySqlCommand insertPrivileges = new MySqlCommand(strPrivInsert, GlobalVariables.gPersistentConnection);
							insertPrivileges.Transaction = trans;

							insertPrivileges.ExecuteNonQuery();
						}
						catch { }
					}
				}
			}

	    	public bool updateGuest(ref Guest a_Guest)
			{
				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				bool success = false;

				try
				{
					

					string strUpdate = "call spUpdateGuest('" + a_Guest.AccountId + "','" +
																a_Guest.AccountName.Trim() + "','" + 
																a_Guest.Title + "','" +
																a_Guest.LastName.Trim() + "','" +
																a_Guest.FirstName.Trim() + "','" +
																a_Guest.MiddleName.Trim() + "','" + 
																a_Guest.Sex + "','" + 
																a_Guest.Street + "','" + 
																a_Guest.City + "','" + 
																a_Guest.Country + "','" + 
																a_Guest.Zip + "','" + 
																a_Guest.EmailAddress + "','" + 
																a_Guest.Citizenship + "','" + 
																a_Guest.PassportId + "','" + 
																a_Guest.TelephoneNo + "','" + 
																a_Guest.MobileNo + "','" + 
																a_Guest.FaxNo + "','" + 
																a_Guest.GuestImage + "','" + 
																a_Guest.Memo + "','" + 
																a_Guest.Concierge + "','" + 
																a_Guest.Remark + "','" + 
																a_Guest.HotelID + "','" + 
																a_Guest.UpdatedBy + "','" + 
																string.Format("{0:yyyy-MM-dd}",a_Guest.BIRTH_DATE) + "','" + 
																a_Guest.ACCOUNT_TYPE +"','" +
																a_Guest.CARD_NO + "'," +
																a_Guest.THRESHOLD_VALUE + ",'" +
																a_Guest.CreditCardType + "','" +
																a_Guest.CreditCardNo + "','" +
																a_Guest.CreditCardExpiry + "','" +
																a_Guest.TaxExempted + "')";


                    MySqlCommand updateCommand = new MySqlCommand(strUpdate, GlobalVariables.gPersistentConnection);
					updateCommand.Transaction = trans;

					// saves privileges
					savePrivileges(a_Guest, ref trans);

                    //saves account information
                    if (a_Guest.AccountInformation != null)
                        a_Guest.AccountInformation.update(ref trans);

                    //save contact persons
                    if (a_Guest.ContactPersons != null)
                    {
                        ContactPerson _cp = new ContactPerson();
                        _cp.deleteContactPersons(a_Guest.AccountId, GlobalVariables.gHotelId.ToString(), ref trans);
                        foreach (ContactPerson _contactPerson in a_Guest.ContactPersons)
                        {
                            _contactPerson.save(ref trans);
                        }
                    }


					int rowsAffected = updateCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						success = true;

						if (a_Guest.Tables.Count > 0)
						{

							updateDataRow(a_Guest);
						}
					}
					else
					{
						success = false;
					}

					
					trans.Commit();

                    return success;
                }
				catch (Exception ex)
				{
					trans.Rollback();
					throw ex;
				}
			}
           
			public string getGuestID(string a_FIRSTNAME, string a_LASTNAME, string a_middlename)
			{
                string guestid = "";

				ParameterHelper oParameterHelper = new ParameterHelper();
				Guest oGuest = new Guest();
				
				MySqlCommand guestCommand = new MySqlCommand("spSearchGuestRefName", GlobalVariables.gPersistentConnection);
				guestCommand.CommandType = CommandType.StoredProcedure;
				MySqlParameter paramFName = new MySqlParameter();
				MySqlParameter paramLName = new MySqlParameter();
				MySqlParameter paramMI = new MySqlParameter();

                ParameterHelper paramHelper = new ParameterHelper();

                paramHelper.AddParameters(paramFName, "pfirstname", ParameterDirection.Input, DbType.String, a_FIRSTNAME, guestCommand);
                paramHelper.AddParameters(paramLName, "plastname", ParameterDirection.Input, DbType.String, a_LASTNAME, guestCommand);
                paramHelper.AddParameters(paramMI, "pmiddlename", ParameterDirection.Input, DbType.String, a_middlename, guestCommand);
				
				MySqlDataReader guestDataReader = guestCommand.ExecuteReader();
				
				
				while (guestDataReader.Read())
				{
					guestid = guestDataReader.GetValue(0).ToString();
				}
				guestDataReader.Close();
				
				return guestid;
			}

			public string getGuestID(int a_accountid)
			{
				
				MySqlCommand guestCommand = new MySqlCommand("spGetAccountID", GlobalVariables.gPersistentConnection);
				guestCommand.CommandType = CommandType.StoredProcedure;
				MySqlParameter paramAccountID = new MySqlParameter();

                ParameterHelper paramHelper = new ParameterHelper();
                paramHelper.AddParameters(paramAccountID, "pAccountID", ParameterDirection.Input, DbType.String, a_accountid.ToString(), guestCommand);
				
				MySqlDataReader guestDataReader = guestCommand.ExecuteReader();
				string guestID = "";
				while (guestDataReader.Read())
				{
					guestID = guestDataReader.GetValue(0).ToString();
				}
				guestDataReader.Close();
				
				return guestID;
				
			}

			public Guest displayListOfGuest()
			{
                try
                {
                    Guest oGuest = new Guest();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spDisplayListOfGuest(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                    dataAdapter.Fill(oGuest, "Guests");
                    dataAdapter.Dispose();

                    return oGuest;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ displayListOfGuest() " + ex.Message);
                    return null;
                }
            }

            public DataTable getGuestAccounts()
            {
                try
                {
                    DataTable _oDataTable = new DataTable();
                    MySqlDataAdapter dataAdapterGuest = new MySqlDataAdapter("call spSelectGuests(\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);

                    dataAdapterGuest.Fill(_oDataTable);
                    dataAdapterGuest.Dispose();

                    return _oDataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ GetGuests() " + ex.Message);
                    return null;
                }
            }

            public DataTable getGuestAccount(string fname, string lname)
            {
                try
                {
                    string query = "select * from guests where stateflag <> 'DELETED' and hotelid = " + GlobalVariables.gHotelId + " and lastname like '" + lname + "%' and firstname like '" + fname + "%'";
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);

                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

			public Guest getGuests()
			{
				try
				{
					loGuest = new Guest();
					
					MySqlDataAdapter dataAdapterGuest = new MySqlDataAdapter("call spSelectGuests(\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
					
					dataAdapterGuest.Fill(loGuest, "Guests");
					dataAdapterGuest.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = loGuest.Tables["Guests"].Columns["AccountId"];
					loGuest.Tables["Guests"].PrimaryKey = primaryKey;
					
					return loGuest;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION : @ GetGuests() " + ex.Message);
					return null;
				}
			}


			//public DataTable getGuestsAsDataTable()
			//{
			//    try
			//    {
			//        DataTable tempTable = new DataTable();

			//        MySqlDataAdapter dataAdapterGuest = new MySqlDataAdapter("call spSelectGuests(\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);

			//        dataAdapterGuest.Fill(tempTable);
			//        dataAdapterGuest.Dispose();


			//        return tempTable;
			//    }
			//    catch (Exception ex)
			//    {
			//        MessageBox.Show("EXCEPTION : @ GetGuests() " + ex.Message);
			//        return null;
			//    }
			//}

			public Guest getGuestsByCriteria(string a_FName, string a_LName)
			{
                try
                {
                    loGuest = new Guest();

                    string str;
                    str = "call spGetGuestByCriteria (\'" + a_LName + "%\',\'" + a_FName + "%\')";
                    MySqlDataAdapter dataAdapterGuest = new MySqlDataAdapter(str, GlobalVariables.gPersistentConnection);

                    dataAdapterGuest.Fill(loGuest, "GuestByCriteria");
                    dataAdapterGuest.Dispose();

                    DataColumn[] primaryKey = new DataColumn[1];
                    primaryKey[0] = loGuest.Tables["GuestByCriteria"].Columns["AccountId"];
                    loGuest.Tables["GuestByCriteria"].PrimaryKey = primaryKey;
                    return loGuest;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ getGuestsByCriteria() " + ex.Message);
                    return null;
                }
				
			}

			public Guest getGuestList()
			{
                try
                {
                    Guest oGuest = new Guest();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectGuests(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                    dataAdapter.Fill(oGuest, "Guests");
                    dataAdapter.Dispose();

                    return oGuest;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ getGuestList() " + ex.Message);
                    return null;
                }
			}
			
			public Guest searchGuestRecordRefName(string a_firstname, string a_lastname, string a_MI)
			{
                try
                {
                    //ParameterHelper oParameterHelper = new ParameterHelper();
                    Guest oGuest = new Guest();

					string query = "call spSearchGuestRefName('" 
											+ a_firstname + "','" 
											+ a_lastname + "','" 
											+ a_MI + "')";

					//MySqlCommand guestCommand = new MySqlCommand("spSearchGuestRefName", GlobalVariables.gPersistentConnection);
					//guestCommand.CommandType = CommandType.StoredProcedure;

					//MySqlParameter paramFName = new MySqlParameter();
					//MySqlParameter paramLName = new MySqlParameter();
					//MySqlParameter paramMI = new MySqlParameter();

					//ParameterHelper paramHelper = new ParameterHelper();
					//paramHelper.AddParameters(paramFName, "pfirstname", ParameterDirection.Input, DbType.String, a_firstname, guestCommand);
					//paramHelper.AddParameters(paramLName, "plastname", ParameterDirection.Input, DbType.String, a_lastname, guestCommand);
					//paramHelper.AddParameters(paramMI, "pmiddlename", ParameterDirection.Input, DbType.String, a_MI, guestCommand);

					MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
					adapter.Fill(oGuest, "Guests");
					//MySqlDataReader guestDataReader = guestCommand.ExecuteReader();

					//System.Data.DataSet temp_SystemDataDataSet = oGuest;
					//oDataSetConverter.convertDataReaderToDataSet(guestDataReader, "Guests", temp_SystemDataDataSet);
					//guestDataReader.Close();

                    return oGuest;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ getGuestList() " + ex.Message);
                    return null;
                }
			}

			public Guest getGuestRecordRefName(string a_firstname, string a_lastname, string a_MI)
			{
                try
                {
                    //ParameterHelper oParameterHelper = new ParameterHelper();
					Guest oGuest = new Guest();

					string query = "call spSearchGuestRefName('"
											+ a_firstname + "','"
											+ a_lastname + "','"
											+ a_MI + "')";


					MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
					adapter.Fill(oGuest, "Guests");


                    return oGuest;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ getGuestRecordRefName() " + ex.Message);
                    return null;
                }
			}

			public Guest getGuestRecord(string a_guestID)
			{
				Guest oGuest = new Guest();

				
                try
                {
                ParameterHelper oParameterHelper = new ParameterHelper();
          
					string query = "call spGetGuestRecord('" 
											+ a_guestID + "'," 
											+ GlobalVariables.gHotelId + ")";

					//MySqlCommand guestCommand = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
					//guestCommand.CommandType = CommandType.Text;
					//MySqlDataReader guestDataReader = guestCommand.ExecuteReader();

					//object tmp = (object)oGuest;
					//oDataReaderBinder.BinderReaderToEntity(guestDataReader, ref tmp);
					//guestDataReader.Close();

					MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
					adapter.Fill(oGuest, "GuestRecord");

					try
					{
						DataRow _dRow = oGuest.Tables[0].Rows[0];

						oGuest.AccountId = _dRow["AccountId"].ToString();
						oGuest.AccountName = _dRow["AccountName"].ToString();
						oGuest.Title = _dRow["Title"].ToString();
						oGuest.LastName = _dRow["LastName"].ToString();
						oGuest.FirstName = _dRow["FirstName"].ToString();
						oGuest.MiddleName = _dRow["MiddleName"].ToString();
						oGuest.Sex = _dRow["Sex"].ToString();
						oGuest.Citizenship = _dRow["Citizenship"].ToString();
						oGuest.PassportId = _dRow["PassportId"].ToString();
						oGuest.GuestImage = _dRow["GuestImage"].ToString();
						oGuest.TelephoneNo = _dRow["TelephoneNo"].ToString();
						oGuest.MobileNo = _dRow["MobileNo"].ToString();
						oGuest.FaxNo = _dRow["FaxNo"].ToString();
						oGuest.Street = _dRow["Street"].ToString();
						oGuest.City = _dRow["City"].ToString();
						oGuest.Country = _dRow["Country"].ToString();
						oGuest.Zip = _dRow["Zip"].ToString();
						oGuest.EmailAddress = _dRow["EmailAddress"].ToString();
						oGuest.Memo = _dRow["Memo"].ToString();
						oGuest.Concierge = _dRow["Concierge"].ToString();
						oGuest.Remark = _dRow["Remark"].ToString();
						oGuest.NoOfVisits = int.Parse(_dRow["NoOfVisits"].ToString());
						oGuest.HotelID = int.Parse(_dRow["HotelID"].ToString());
						oGuest.CreateTime = DateTime.Parse(_dRow["CreateTime"].ToString());
						oGuest.CreatedBy = _dRow["CreatedBy"].ToString();
						oGuest.UpdateTime = DateTime.Parse(_dRow["UpdateTime"].ToString());
						oGuest.UpdatedBy = _dRow["UpdatedBy"].ToString();

						//oGuest.AccountPrivileges = oGuestDAO.getAccountPrivileges(oGuest.AccountId);

						oGuest.BIRTH_DATE = DateTime.Parse(_dRow["BIRTH_DATE"].ToString());
						oGuest.ACCOUNT_TYPE = _dRow["ACCOUNT_TYPE"].ToString();
						oGuest.CARD_NO = _dRow["Card_No"].ToString();
						oGuest.THRESHOLD_VALUE = double.Parse(_dRow["THRESHOLD_VALUE"].ToString());
						oGuest.TOTAL_SALES_CONTRIBUTION = double.Parse(_dRow["TOTAL_SALES_CONTRIBUTION"].ToString());
						oGuest.CreditCardType = _dRow["CreditCardType"].ToString();
						oGuest.CreditCardNo = _dRow["CreditCardNo"].ToString();

						oGuest.CreditCardExpiry = _dRow["CreditCardExpiry"].ToString();
					}
					catch
					{ }

                    return oGuest;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ getGuestRecord() " + ex.Message);
                    return null;
                }
            }

			public Guest searchAccountName(ref Guest a_Guest)
			{
                try
                {
					string query = "call spSearchAccountName('"
											+ a_Guest.AccountName + ")";

					MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
					adapter.Fill(a_Guest, "Guests");

					//MySqlCommand searchAccountCommand = new MySqlCommand("spSearchAccountName", GlobalVariables.gPersistentConnection);
					//searchAccountCommand.CommandType = CommandType.StoredProcedure;

					//MySqlParameter paramAccountName = new MySqlParameter();

					//oParameterHelper.AddParameters(paramAccountName, "pAccountName", ParameterDirection.Input, DbType.String, a_Guest.AccountName, searchAccountCommand);

					//MySqlDataReader dataReaderGuest = searchAccountCommand.ExecuteReader();
					//System.Data.DataSet temp_SystemDataDataSet = a_Guest;
					//oDataSetConverter.convertDataReaderToDataSet(dataReaderGuest, "Guests", temp_SystemDataDataSet);

					//dataReaderGuest.Close();

                    return a_Guest;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ searchAccountName() " + ex.Message);
                    return null;
                }
			}

			public Guest filterGuestRecord(string a_fld, string a_tbl, string a_whr)
			{

                try
                {
					loGuest = new Guest();

					string query = "Select " + a_fld + " from " + a_tbl + a_whr;

					MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
					adapter.Fill(loGuest, "Guests");

					//MySqlCommand filterGuestCommand = new MySqlCommand(, GlobalVariables.gPersistentConnection);

					//MySqlDataReader dataReaderGuest = filterGuestCommand.ExecuteReader();
					//System.Data.DataSet temp_SystemDataDataSet = oGuest;
					//oDataSetConverter.convertDataReaderToDataSet(dataReaderGuest, "Guests", temp_SystemDataDataSet);
					//dataReaderGuest.Close();
                    return loGuest;

                }
                catch(Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ filterGuestRecord() " + ex.Message);
                    return null;
                }
				
			}

			public int insertGuestNoDataTable(Guest a_Guest)
			{

				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				try
				{
                    int rowsAffected = 0;
					string cmdText = "call spInsertGuest('" + 
										   a_Guest.AccountId + "','" +
										   a_Guest.AccountName.Trim() + "','" + 
										   a_Guest.Title + "','" + 
										   a_Guest.LastName.Trim() + "','" +
										   a_Guest.FirstName.Trim() + "','" +
										   a_Guest.MiddleName.Trim() + "','" + 
										   a_Guest.Sex + "','" + 
										   a_Guest.Street + "','" + 
										   a_Guest.City + "','" + 
										   a_Guest.Country + "','" + 
										   a_Guest.Zip + "','" + 
										   a_Guest.EmailAddress + "','" + 
										   a_Guest.Citizenship + "','" + 
										   a_Guest.PassportId + "','" + 
										   a_Guest.TelephoneNo + "','" + 
										   a_Guest.MobileNo + "','" + 
										   a_Guest.FaxNo + "','" + 
										   a_Guest.GuestImage + "'," + 
										   a_Guest.NoOfVisits + ",'" + 
										   a_Guest.Memo + "','" + 
										   a_Guest.Concierge + "','" + 
										   a_Guest.Remark + "'," + 
										   a_Guest.HotelID + ",'" + 
										   a_Guest.CreatedBy + "','" + 
										   string.Format("{0:yyyy-MM-dd}", a_Guest.BIRTH_DATE) + "','" + 
										   a_Guest.ACCOUNT_TYPE + "','" + 
										   a_Guest.CARD_NO + "'," + 
										   a_Guest.THRESHOLD_VALUE + "," + 
										   a_Guest.TOTAL_SALES_CONTRIBUTION + ",'" + 
										   a_Guest.CreditCardType + "','" + 
										   a_Guest.CreditCardNo + "','" + 
										   a_Guest.CreditCardExpiry + "','" +
										   a_Guest.TaxExempted + "')";

					MySqlCommand guestCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
					guestCommand.Transaction = trans;
					rowsAffected = guestCommand.ExecuteNonQuery();

					// saves Privileges
					savePrivileges(a_Guest, ref trans);

					trans.Commit();
                    return rowsAffected;
					
				}
				catch (Exception ex)
				{
					trans.Rollback();
                    MessageBox.Show("EXCEPTION : @ insertGuestNoDataTable() " + ex.Message);
                    return 0;
				}
				
			
			}

			public Guest updateGuestNoDataTable(Guest a_Guest)
			{
				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

                try
                {
					string strUpdateGuest = "call spUpdateGuest('" + a_Guest.AccountId + "','" +
																	 a_Guest.AccountName.Trim() + "','" + 
																	 a_Guest.Title + "','" +
																	 a_Guest.LastName.Trim() + "','" +
																	 a_Guest.FirstName.Trim() + "','" +
																	 a_Guest.MiddleName.Trim() + "','" + 
																	 a_Guest.Sex + "','" + 
																	 a_Guest.Street + "','" + 
																	 a_Guest.City + "','" + 
																	 a_Guest.Country + "','" + 
																	 a_Guest.Zip + "','" + 
																	 a_Guest.EmailAddress + "','" + 
																	 a_Guest.Citizenship + "','" + 
																	 a_Guest.PassportId + "','" + 
																	 a_Guest.TelephoneNo + "','" + 
																	 a_Guest.MobileNo + "','" + 
																	 a_Guest.FaxNo + "','" + 
																	 a_Guest.GuestImage + "','" + 
																	 a_Guest.Memo + "','" + 
																	 a_Guest.Concierge + "','" + 
																	 a_Guest.Remark + "','" + 
																	 GlobalVariables.gHotelId + "','" + 
																	 GlobalVariables.gLoggedOnUser + "','" + 
																	 string.Format("{0:yyyy-MM-dd}", a_Guest.BIRTH_DATE) + "','" + 
																	 a_Guest.ACCOUNT_TYPE + "','" + 
																	 a_Guest.CARD_NO + "'," +
																	 a_Guest.THRESHOLD_VALUE + ",'" + 
																	 a_Guest.CreditCardType + "','" +
																	 a_Guest.CreditCardNo + "','" +
																	 a_Guest.CreditCardExpiry + "','" +
																	 a_Guest.TaxExempted + "')";

					MySqlCommand guestCommand = new MySqlCommand(strUpdateGuest, GlobalVariables.gPersistentConnection);
					guestCommand.Transaction = trans;

					guestCommand.ExecuteNonQuery();
					// saves Privileges
					//savePrivileges(a_Guest, ref trans);

					trans.Commit();

                    return a_Guest;
                }
                catch (Exception ex)
                {
					trans.Rollback();
                    MessageBox.Show("EXCEPTION : @ updateGuestNoDataTable() " + ex.Message);
                    return null;
                }
				
			}
			
			public Guest filterGuestRecordRefName(string a_Lastname, string a_Firstname, string a_Middlename)
			{
                try
                {
                    Guest oGuest = new Guest();

                    MySqlDataAdapter filterGuestAdapter = new MySqlDataAdapter("call spGetGuestRefName(\'" + a_Lastname + "\',\'" + a_Firstname + "\',\'" + a_Middlename + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                    filterGuestAdapter.Fill(oGuest, "Guests");
                    filterGuestAdapter.Dispose();
                    return oGuest;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION : @ filterGuestRecordRefName() " + ex.Message);
                    return null;
                }
			}
			
			public int setNoOfVisits(string a_guestID)
			{
                try
                {
                    int rowsAffected=0;

					string strUpdate = "call spSetNoOfVisits('" + a_guestID 
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

            public bool checkIfGuestNameExists(string pFirstname, string pLastname)
            {
                try
                {
                    string strQuery = "select * from guests where firstname='" + pFirstname + "' and lastname='" + pLastname + "'";
                    MySqlDataAdapter dtAdapter = new MySqlDataAdapter(strQuery, GlobalVariables.gPersistentConnection);
                    DataTable dtTable = new DataTable();
                    dtAdapter.Fill(dtTable);

                    if (dtTable.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

			public bool insertGuest(ref Guest a_Guest)
			{

				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
				bool isSuccessful = false;

				try
                {
                    

					string strInsert = "call spInsertGuest('" + 
						                     a_Guest.AccountId + "','" +
											 a_Guest.AccountName.Trim() + "','" + 
											 a_Guest.Title + "','" +
											 a_Guest.LastName.Trim() + "','" +
											 a_Guest.FirstName.Trim() + "','" +
											 a_Guest.MiddleName.Trim() + "','" + 
											 a_Guest.Sex + "','" + 
											 a_Guest.Street + "','" + 
											 a_Guest.City + "','" + 
											 a_Guest.Country + "','" + 
											 a_Guest.Zip + "','" + 
											 a_Guest.EmailAddress + "','" + 
											 a_Guest.Citizenship + "','" + 
											 a_Guest.PassportId + "','" + 
											 a_Guest.TelephoneNo + "','" + 
											 a_Guest.MobileNo + "','" + 
											 a_Guest.FaxNo + "','" + 
											 a_Guest.GuestImage + "','" + 
											 a_Guest.Memo + "','" + 
											 a_Guest.Concierge + "','" + 
											 a_Guest.Remark + "','" + 
											 a_Guest.HotelID + "','" + 
											 a_Guest.CreatedBy + "','" + 
											 string.Format("{0:yyyy-MM-dd}", a_Guest.BIRTH_DATE) + "','" + 
											 a_Guest.ACCOUNT_TYPE + "','" + 
											 a_Guest.CARD_NO + "'," + 
											 a_Guest.THRESHOLD_VALUE + "," +
											 a_Guest.TOTAL_SALES_CONTRIBUTION + ",'" +
										     a_Guest.CreditCardType + "','" +
										     a_Guest.CreditCardNo + "','" +
											 a_Guest.CreditCardExpiry + "','" +
										     a_Guest.TaxExempted + "','" +
                                             string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_Guest.CreateTime) + "')";

				    MySqlCommand insertCommand = new MySqlCommand(strInsert, GlobalVariables.gPersistentConnection);
					insertCommand.Transaction = trans;

                    int rowsAffected = insertCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						isSuccessful = true;
					}
					else
					{
						isSuccessful = false;
					}

					// save privileges
					savePrivileges(a_Guest, ref trans);

                    //save account information
                    if (a_Guest.AccountInformation != null)
                        a_Guest.AccountInformation.save(ref trans);

                    //save contact persons
                    if (a_Guest.ContactPersons != null)
                    {
                        ContactPerson _cp = new ContactPerson();
                        _cp.deleteContactPersons(a_Guest.AccountId, GlobalVariables.gHotelId.ToString(), ref trans);
                        foreach (ContactPerson _contactPerson in a_Guest.ContactPersons)
                        {
                            _contactPerson.save(ref trans);
                        }
                    }


                    if (a_Guest.Tables.Count > 0)
                    {
                        DataRow dataRow = a_Guest.Tables[0].NewRow();
                        dataRow["AccountId"] = a_Guest.AccountId;
                        dataRow["AccountName"] = a_Guest.AccountName;
                        dataRow["Title"] = a_Guest.Title;
                        dataRow["LastName"] = a_Guest.LastName;
                        dataRow["FirstName"] = a_Guest.FirstName;
                        dataRow["MiddleName"] = a_Guest.MiddleName;
                        dataRow["Street"] = a_Guest.Street;
                        dataRow["City"] = a_Guest.City;
                        dataRow["Country"] = a_Guest.Country;
                        dataRow["Zip"] = a_Guest.Zip;
                        dataRow["EmailAddress"] = a_Guest.EmailAddress;
                        dataRow["Sex"] = a_Guest.Sex;
                        dataRow["Citizenship"] = a_Guest.Citizenship;
                        dataRow["PassportId"] = a_Guest.PassportId;
                        dataRow["TelephoneNo"] = a_Guest.TelephoneNo;
                        dataRow["MobileNo"] = a_Guest.MobileNo;
                        dataRow["FaxNo"] = a_Guest.FaxNo;
                        dataRow["GuestImage"] = a_Guest.GuestImage;
                        dataRow["memo"] = a_Guest.Memo;
                        dataRow["Concierge"] = a_Guest.Concierge;
                        dataRow["Remark"] = a_Guest.Remark;
                        dataRow["NoOfVisits"] = a_Guest.NoOfVisits;
						//dataRow["FAMILY_FRIEND"] = a_Guest.FAMILY_FRIEND;
						dataRow["BIRTH_DATE"] = a_Guest.BIRTH_DATE;
						dataRow["ACCOUNT_TYPE"] = a_Guest.ACCOUNT_TYPE;

						dataRow["CARD_NO"] = a_Guest.CARD_NO;
						dataRow["THRESHOLD_VALUE"] = a_Guest.THRESHOLD_VALUE;
						dataRow["TOTAL_SALES_CONTRIBUTION"] = a_Guest.TOTAL_SALES_CONTRIBUTION;

						dataRow["CreditCardType"] = a_Guest.CreditCardType;
						dataRow["CreditCardNo"] = a_Guest.CreditCardNo;
						dataRow["CreditCardExpiry"] = a_Guest.CreditCardExpiry;

                        a_Guest.Tables[0].Rows.Add(dataRow);

						a_Guest.AcceptChanges();
                    }

					trans.Commit();
					return isSuccessful;
                }
				catch(Exception ex)
                {
					trans.Rollback();
					throw ex;
                }
			}
			
			public int deleteGuest(string a_accountId, Guest a_Guest)
			{
				try
				{
                    int rowsAffected = 0;
					
					string strDeletePrivs = "call spDeleteAccountPrivileges('" + a_Guest.AccountId + "','" + GlobalVariables.gHotelId + "')";
					MySqlCommand deletePrivCommand = new MySqlCommand(strDeletePrivs, GlobalVariables.gPersistentConnection);
					deletePrivCommand.ExecuteNonQuery();


					MySqlCommand deleteCommand = new MySqlCommand("call spDeleteGuest('" + a_accountId + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
					rowsAffected=deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        deleteDataRow(a_accountId, a_Guest);

                    return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show("EXCEPTION : @ deleteGuest() " + ex.Message);
					return 0;
				}
			}

            private void deleteDataRow(string a_accountId, Guest a_Guest)
            {
                DataRow row = a_Guest.Tables["Guests"].Rows.Find(a_accountId);
                a_Guest.Tables["Guests"].Rows.Remove(row);
                a_Guest.AcceptChanges();

            }
			// >> 20 May 2006
			public void getAccountPrivileges(string a_accountId,ref Guest a_Guest)
			{
				try
				{
					IList<PrivilegeHeader> oAccountPrivileges = new List<PrivilegeHeader>();
                    
					//AccountPrivileges oAccountPrivileges = new AccountPrivileges();
					DataTable dtPrivileges = new DataTable();
					
					
					MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetAccountPrivileges('" + a_accountId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
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
					
					a_Guest.AccountPrivileges = oAccountPrivileges;
				}
				catch (Exception ex)
				{
                    MessageBox.Show("EXCEPTION: @ GetAccountPrivileges() " + ex.Message);
				}
			}
			
			// >> 20 May 2006
			//public DataTable getAccountPrivileges(string a_accountId)
			//{
			//    try
			//    {
			//        AccountPrivileges oAccountPrivileges = new AccountPrivileges();
			//        DataTable dtPrivileges = new DataTable();
			//        MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetAccountPrivileges('" + a_accountId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
			//        dtAdapter.Fill(dtPrivileges);
			//        dtAdapter.Dispose();
					
			//        return dtPrivileges;
			//    }
			//    catch (Exception ex)
			//    {
			//        MessageBox.Show("EXCEPTION: @ getAccountPrivileges() " + ex.Message);
			//        return null;
                   
			//    }
				
			//}

            private void updateDataRow(Guest a_Guest)
            {
				string _primaryKey = a_Guest.AccountId;

				DataRow dataRow = a_Guest.Tables["Guests"].Rows.Find(_primaryKey);

                dataRow.BeginEdit();
				dataRow["AccountName"] = a_Guest.AccountName.Trim();
                dataRow["Title"] = a_Guest.Title;
				dataRow["LastName"] = a_Guest.LastName.Trim();
				dataRow["FirstName"] = a_Guest.FirstName.Trim();
				dataRow["MiddleName"] = a_Guest.MiddleName.Trim();
                dataRow["Sex"] = a_Guest.Sex;
                dataRow["Street"] = a_Guest.Street;
                dataRow["City"] = a_Guest.City;
                dataRow["Country"] = a_Guest.Country;
                dataRow["Zip"] = a_Guest.Zip;
                dataRow["EmailAddress"] = a_Guest.EmailAddress;
                dataRow["Citizenship"] = a_Guest.Citizenship;
                dataRow["PassportId"] = a_Guest.PassportId;
                dataRow["TelephoneNo"] = a_Guest.TelephoneNo;
                dataRow["MobileNo"] = a_Guest.MobileNo;
                dataRow["FaxNo"] = a_Guest.FaxNo;
                dataRow["GuestImage"] = a_Guest.GuestImage;
                dataRow["Concierge"] = a_Guest.Concierge;
                dataRow["Remark"] = a_Guest.Remark;
                dataRow["Memo"] = a_Guest.Memo;
                dataRow["TaxExempted"] = a_Guest.TaxExempted;
				//dataRow["FAMILY_FRIEND"] = a_Guest.FAMILY_FRIEND;
				dataRow["BIRTH_DATE"] = a_Guest.BIRTH_DATE;
				dataRow["ACCOUNT_TYPE"] = a_Guest.ACCOUNT_TYPE;
                //dataRow["CompanyID"] = a_Guest.CompanyID;

                dataRow.EndEdit();
                dataRow.AcceptChanges();
                a_Guest.Tables["Guests"].AcceptChanges();
            }

			public int updateAccountTotalSales(string a_AccountId, double a_Amount)
			{
				try
				{
					int rowsAffected = 0;

					string strUpdate = "call spUpdateGuestAccountTotalSales('" + a_AccountId
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

			public void UpdateFolio_Merge(string a_NewAccount, string a_OldAccount, ref MySqlTransaction a_Trans)
			{
				try
				{
					string strQuery = "call spUpdateFolio_Merge('" + a_NewAccount 
									  + "','" + a_OldAccount + "'," + GlobalVariables.gHotelId + ")";

					MySqlCommand updateCommandFolio = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					updateCommandFolio.Transaction = a_Trans;
					updateCommandFolio.ExecuteNonQuery();


					strQuery = "call spUpdateFolioLedger_Merge('" + a_NewAccount
									  + "','" + a_OldAccount + "'," + GlobalVariables.gHotelId + ")";

					MySqlCommand updateCommandFolioLedger = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					updateCommandFolioLedger.Transaction = a_Trans;
					updateCommandFolioLedger.ExecuteNonQuery();


					strQuery = "call spUpdateFolioTransactions_Merge('" + a_NewAccount
									  + "','" + a_OldAccount + "'," + GlobalVariables.gHotelId + ")";

					MySqlCommand updateCommandFolioTrans = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					updateCommandFolioTrans.Transaction = a_Trans;

					updateCommandFolioTrans.ExecuteNonQuery();

					strQuery = "call spDeleteGuest('" + a_OldAccount + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')";
					MySqlCommand deleteCommand = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
					deleteCommand.Transaction = a_Trans;
					deleteCommand.ExecuteNonQuery();

				}

				catch(Exception ex)
				{
					throw (ex);
				}
			}

			public IList<PrivilegeHeader> getAccountPrivileges(string pAccountId)
			{
				try
				{
					IList<PrivilegeHeader> oAccountPrivileges = new List<PrivilegeHeader>();

					//AccountPrivileges oAccountPrivileges = new AccountPrivileges();
					DataTable dtPrivileges = new DataTable();


					MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetAccountPrivileges('" + pAccountId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
					dtAdapter.Fill(dtPrivileges);

					PrivilegeFacade _oPrivilegeFacade = new PrivilegeFacade();
					foreach (DataRow dtRow in dtPrivileges.Rows)
					{
						PrivilegeHeader oPrivilege = new PrivilegeHeader();

						oPrivilege.PrivilegeID = dtRow["PrivilegeID"].ToString();
						oPrivilege.Description = dtRow["Description"].ToString();
						oPrivilege.DaysApplied = dtRow["DaysApplied"].ToString();
						oPrivilege.CreatedBy = dtRow["CreatedBy"].ToString();
						oPrivilege.CreatedDate = dtRow["CreatedDate"].ToString();


						oPrivilege.PrivilegeDetails = _oPrivilegeFacade.getPrivilegeDetails(oPrivilege.PrivilegeID);

						oAccountPrivileges.Add(oPrivilege);
					}

					return oAccountPrivileges;
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}




			//transferred here for SPEED optimization
			public DataTable getGuestsAsDataTable()
			{
				try
				{
					DataTable tempTable = new DataTable();

					string query = "call spSelectGuests('"
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

			//transferred here for SPEED optimization
			public DataTable getGuestRecordAsDataTableByAccountID(string pAccountID)
			{
				try
				{
					DataTable tempTable = new DataTable();

					string query = "call spSelectGuestByAccountID('"
									+ pAccountID + "','" + GlobalVariables.gHotelId + "')";

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
			public DataTable getGuestRecordAsDataTableByName(
															string pLastName,
															string pFirstName)
			{
				try
				{
					DataTable tempTable = new DataTable();

					string query = "call spSelectGuestByName('"
									+ pLastName + "','"
									+ pFirstName + "','"
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

			public DataTable getGuestsAsDataTableByNameUsingLike(
															string pLastName,
															string pFirstName)
			{
				try
				{
					DataTable tempTable = new DataTable();

					string query = "call spSelectGuestByNameUsingLike('"
									+ pLastName + "','"
									+ pFirstName + "','"
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
		


        }
	
	
}
