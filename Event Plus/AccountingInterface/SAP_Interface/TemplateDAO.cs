using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.AccountingInterface.SAP_Interface
{
    public class TemplateDAO
    {

        public static DataTable getAllTemplates(MySqlConnection connection)
        {
            string query = "call spSAP_GetAllTemplates()";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable tempTable = new DataTable("sap_templates");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable getTemplateFields(int pTemplateID, MySqlConnection connection)
        {
            string query = "call spSAP_GetTemplateFields(" + pTemplateID + ")";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable tempTable = new DataTable("sap_templates");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
