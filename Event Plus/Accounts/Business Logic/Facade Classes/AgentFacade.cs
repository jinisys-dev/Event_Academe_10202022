using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.Accounts.BusinessLayer
{
	
		public class AgentFacade 
		{
            AgentDAO oAgentDAO;
            public AgentFacade(){}

            public object getAgentCommissions(string a_AccountId)
			{
                oAgentDAO = new AgentDAO();
                return oAgentDAO.getAgentCommissions(a_AccountId);
			}

			public Agent getAgentAccounts()
			{
                oAgentDAO = new AgentDAO();
                return oAgentDAO.getAgentAccounts();
			}

			public Agent getAgentInfo(int accountid)
			{
				oAgentDAO = new AgentDAO();
				return oAgentDAO.getAgentInfo(accountid);
			}

            private DataTable oAgent;
            public IList<Agent> getAgents()
            {
                oAgentDAO = new AgentDAO();

                oAgent = oAgentDAO.getAgents();
                IList<Agent> ilAgents = new List<Agent>();


                foreach (DataRow dRow in oAgent.Rows)
                {
                    Agent Agent = new Agent();

                    Agent.Address = dRow["Address"].ToString();
                    Agent.Agency = dRow["Agency"].ToString();
                    Agent.AgentID = dRow["AgentID"].ToString();
                    Agent.ContactNumber = dRow["ContactNumber"].ToString();
                    Agent.ContactPerson = dRow["ContactPerson"].ToString();

                    ilAgents.Add(Agent);
                }
                return ilAgents;
            }

            // passes parameters a_Agent = new Agent
            // and a_IlAgent = the List of Agents maintained within this instance
            public void insertNewAgent(Agent a_Agent, ref IList<Agent> a_IlAgents)
            {
                string AgentId = "";

                try
                {
                    oAgentDAO = new AgentDAO();
                    AgentId = oAgentDAO.insertNewAgent((object)a_Agent);

                    // add to IList ilAgents
                    a_Agent.AgentID = AgentId;
                    a_IlAgents.Add(a_Agent);

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }


            // passes parameters a_Agent = new Agent and
            // a_IlAgent = the List of Agents maintained within this instance
            public void updateAgentInfo(Agent a_Agent, ref IList<Agent> a_IlAgents)
            {
                try
                {
                    oAgentDAO = new AgentDAO();
                    oAgentDAO.updateAgentInfo((object)a_Agent);

                    // add to IList ilAgents
                    foreach (Agent Agent in a_IlAgents)
                    {
                        if (Agent.AgentID == a_Agent.AgentID)
                        {
                            Agent.Address = a_Agent.Address;
                            Agent.Agency = a_Agent.Agency;
                            Agent.AgentID = a_Agent.AgentID;
                            Agent.ContactNumber = a_Agent.ContactNumber;
                            Agent.ContactPerson = a_Agent.ContactPerson;

                            break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }

            public void deleteAgent(string a_AgentId, ref IList<Agent> a_IlAgents)
            {
                try
                {
                    oAgentDAO = new AgentDAO();
                    oAgentDAO.deleteAgent(a_AgentId);

                    // add to IList ilAgents
                    foreach (Agent Agent in a_IlAgents)
                    {
                        if (Agent.AgentID == a_AgentId)
                        {

                            a_IlAgents.Remove(Agent);

                            break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
		}
	
	
}
