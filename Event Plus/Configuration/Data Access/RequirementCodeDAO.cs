using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

//added by Genny - Apr. 25, 2008
//for the Sales Module
namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class RequirementCodeDAO
    {
        private RequirementCode oRequirements;
        public RequirementCodeDAO()
        { }

        public DataTable getRequirements()
        {
            string sql = "select * from requirement_header where `status`='ACTIVE'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Requirement");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Requirement Header

        public string insertRequirementCode(object reqCode)
        {
            string requirementID = "";
            string desc = reqCode.GetType().GetProperty("Description").GetValue(reqCode, null).ToString();
            string transactionCode = reqCode.GetType().GetProperty("TransactionCode").GetValue(reqCode, null).ToString();

            string sql = "call spInsertRequirementHeader('" + desc + "','" + transactionCode + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                object lastInsertID = cmd.ExecuteScalar();

                requirementID = lastInsertID.ToString();
                return requirementID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateRequirement(RequirementCode reqCode)
        {
            int rows = 0;
            string requirementID = reqCode.GetType().GetProperty("Requirement_Code").GetValue(reqCode, null).ToString();
            string desc = reqCode.GetType().GetProperty("Description").GetValue(reqCode, null).ToString();
            string transactionCode = reqCode.GetType().GetProperty("TransactionCode").GetValue(reqCode, null).ToString();

            string sql = "call spUpdateRequirement('" + requirementID + "','" + desc + "','" + transactionCode + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                rows = cmd.ExecuteNonQuery();

                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteRequirement(string reqID)
        {
            string sql = "Call spDeleteRequirement('" + reqID + "','" + GlobalVariables.gLoggedOnUser + "'," + GlobalVariables.gHotelId + ")";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Requirement Details

        public DataTable getDetailsForRequirements(string requirementCode)
        {
            string sql = "call spGetDetailsForRequirements('" + requirementCode + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Requirements");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertRequirementDetails(RequirementCode requirementDetail)
        {
            string reqID = requirementDetail.GetType().GetProperty("Requirement_Code").GetValue(requirementDetail, null).ToString();
            string desc = requirementDetail.GetType().GetProperty("Description").GetValue(requirementDetail, null).ToString();

            string sql = "call spInsertRequirementDetail(" + reqID + ",'" + desc + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteRequirementDetails(string requirementID)
        {
            string sql = "delete from requirement_details where requirementID='" + requirementID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
