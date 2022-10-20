using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;
namespace Jinisys.Hotel.Utilities.DataAccessLayer
{
    class TranslatorDAO
    {
        public TranslatorDAO() { }

        public string getTranslation(string pValue)
        {
            try
            {
                MySqlCommand _command = new MySqlCommand("call spGetTranslation('" + pValue + "')", GlobalVariables.gPersistentConnection);
                string _translatedValue = _command.ExecuteScalar().ToString();
                return _translatedValue;
            }
            catch
            {
                return pValue;
            }
        }

        public DataTable getTranslations()
        {
            DataTable _dt = new DataTable();
            try
            {
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetTranslations()", GlobalVariables.gPersistentConnection);
                _adapter.Fill(_dt);
                return _dt;
            }
            catch(Exception ex)
            {
                throw new Exception("Error @TranslatorDAO\r\n" + ex.Message);
            }
        }
    }
}
