using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;

namespace Jinisys.Hotel.Accounts.DataAccessLayer
{
	
		public class AgentDAO 
		{
            private MySqlConnection localConnection;
            private string loggedUser;
            private int hotelId;
            private Agent oAgent;
			public AgentDAO()
            {
                localConnection = GlobalVariables.gPersistentConnection;
                hotelId = GlobalVariables.gHotelId;
                loggedUser = GlobalVariables.gLoggedOnUser;
                oAgent = new Agent();
            }
            public AgentCommissionCollection getAgentCommissions(string a_AccountID)
			{
				MySqlDataAdapter dataAdaptAgentCommission;
				MySqlCommand selectCommand;
				DataTable dataAgentCommission;
				try
				{
					AgentCommissionCollection agentCommColl = new AgentCommissionCollection();
				
					selectCommand = new MySqlCommand("spGetAgentCommissions", GlobalVariables.gPersistentConnection);
					selectCommand.CommandType = CommandType.StoredProcedure;
					MySqlParameter paramAccountID = new MySqlParameter();

                    ParameterHelper paramHelper = new ParameterHelper();
                    paramHelper.AddParameters(paramAccountID, "pAccountid", ParameterDirection.Input, DbType.String, a_AccountID, selectCommand);

					dataAgentCommission = new DataTable("Agentcommission");
					dataAdaptAgentCommission = new MySqlDataAdapter(selectCommand);
					dataAdaptAgentCommission.Fill(dataAgentCommission);

				    foreach (DataRow dtRow in dataAgentCommission.Rows)
					{
						
						AgentCommission AgentComm = new AgentCommission(a_AccountID, dtRow["trancode"].ToString(), Convert.ToDouble(dtRow["percentcommission"]));
						agentCommColl.Add(AgentComm);
					}
					return agentCommColl;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Exception:getAgentCommissions-> " + ex.Message);
                    return null;
				}
			}

			public Agent getAgentInfo(int a_Accountid)
			{
				oAgent = new Agent();
                try
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetAgentinfo(\'" + a_Accountid + "\')", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(oAgent, "Agent");

                    return oAgent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception:getAgentInfo-> " + ex.Message);
                    return null;
                }
			}

			public Agent getAgentAccounts()
			{
                try
                {
				    Agent oAgent = new Agent();

				    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetAgents()", GlobalVariables.gPersistentConnection);
				    dataAdapter.Fill(oAgent, "Agent");

				    return oAgent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception:getAgentAccounts-> " + ex.Message);
                    return null;
                }
			}

            public DataTable getAgents()
            {
                DataTable dtAgents = new DataTable("Agents");
                try
                {
                    string strQuery = "select * from agents where hotel_id=" + hotelId + " order by agency";

                    MySqlDataAdapter dtaSelect = new MySqlDataAdapter(strQuery, localConnection);
                    dtaSelect.Fill(dtAgents);

                    return dtAgents;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public string insertNewAgent(object a_Agent)
            {
                try
                {
                    string AgentId = "";
                    string address = a_Agent.GetType().GetProperty("Address").GetValue(a_Agent, null).ToString();
                    string agency = a_Agent.GetType().GetProperty("Agency").GetValue(a_Agent, null).ToString();
                    string contactNo = a_Agent.GetType().GetProperty("ContactNumber").GetValue(a_Agent, null).ToString();
                    string contactPerson = a_Agent.GetType().GetProperty("ContactPerson").GetValue(a_Agent, null).ToString();

                    string strQuery = "call spInsertAgent('" + address
                                      + "','" + agency + "','" + contactNo
                                      + "','" + contactPerson + "','" + hotelId + "','" + loggedUser + "')";

                    MySqlCommand insertCommand = new MySqlCommand(strQuery, localConnection);
                    object objLastInsertId = insertCommand.ExecuteScalar();

                    AgentId = objLastInsertId.ToString();

                    return AgentId;

                }
                catch (Exception ex)
                {
                    throw (ex);
                }


            }


            public int updateAgentInfo(object a_Agent)
            {
                int rowsAffected = 0;
                try
                {
                    string AgentId = a_Agent.GetType().GetProperty("AgentID").GetValue(a_Agent, null).ToString();
                    string address = a_Agent.GetType().GetProperty("Address").GetValue(a_Agent, null).ToString();
                    string agency = a_Agent.GetType().GetProperty("Agency").GetValue(a_Agent, null).ToString();
                    string contactNo = a_Agent.GetType().GetProperty("ContactNumber").GetValue(a_Agent, null).ToString();
                    string contactPerson = a_Agent.GetType().GetProperty("ContactPerson").GetValue(a_Agent, null).ToString();

                    string strQuery = "call spUpdateAgent('" + AgentId + "','" + address
                                      + "','" + agency + "','" + contactNo
                                      + "','" + contactPerson + "','" + loggedUser
                                      + "','" + hotelId + "')";

                    MySqlCommand updateCommand = new MySqlCommand(strQuery, localConnection);
                    rowsAffected = updateCommand.ExecuteNonQuery();

                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }


            }


            public int deleteAgent(string a_AgentId)
            {
                int rowsAffected = 0;
                try
                {

                    string strQuery = "call spDeleteAgent('" + a_AgentId
                                      + "','" + loggedUser
                                      + "','" + hotelId + "')";

                    MySqlCommand deleteCommand = new MySqlCommand(strQuery, localConnection);
                    rowsAffected = deleteCommand.ExecuteNonQuery();

                    return rowsAffected;

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
		}
	}
	

