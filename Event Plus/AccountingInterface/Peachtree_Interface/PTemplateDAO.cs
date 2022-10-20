using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PTemplateDAO
    {

        public static DataTable getAllPTemplates()
        {
            string query = "call spPeachtree_GetAllPTemplates()";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable tempTable = new DataTable("peachtree_templates");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataTable getAllTemplates()
        {
            string _sql = "call spPeachtree_GetAllPTemplates()";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable tempTable = new DataTable("peachtree_templates");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable getPTemplateFields(string pTemplateID)
        {
            string query = "call spPeachtree_GetPTemplateFields('" + pTemplateID + "')";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable tempTable = new DataTable("peachtree_templates");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataTable getTemplateFields(int pTemplateID)
        {
            string query = "call spPeachtree_GetPTemplateFields(" + pTemplateID + ")";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable tempTable = new DataTable("peachtree_templates");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void updateTemplates(int pTemplateID, int pStatus)
        {
            string _sql = "call spPeachtree_updateTemplates('" + pTemplateID + "','" + pStatus + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateFieldTemplates(int pTemlateID, string pStatusFlag)
        {
            string _sql = "call spPeachtree_updateFieldTemplates('" + pTemlateID + "','" + pStatusFlag + "','" + GlobalVariables.gLoggedOnUser +  "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertTemplate(object poPTemplate)
        {
            string _name = poPTemplate.GetType().GetProperty("Name").GetValue(poPTemplate, null).ToString();
            string _description = poPTemplate.GetType().GetProperty("Description").GetValue(poPTemplate, null).ToString();
            string _outputExtension = poPTemplate.GetType().GetProperty("OutputExtension").GetValue(poPTemplate, null).ToString();

            string _sql = "call spPeachtree_insertTemplates('" + _name + "','" + _description + "','" + _outputExtension + "','" + GlobalVariables.gLoggedOnUser + "')";

            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertTemplateFields(object poPTemplateField)
        {
            string _template = poPTemplateField.GetType().GetProperty("TemplateID").GetValue(poPTemplateField, null).ToString();
            string _field = poPTemplateField.GetType().GetProperty("Name").GetValue(poPTemplateField, null).ToString();
            string _description = poPTemplateField.GetType().GetProperty("Description").GetValue(poPTemplateField, null).ToString();

            string _sql = "call spPeachtree_insertTemplateFields('" + _template + "','" + _field + "','" + _description + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
