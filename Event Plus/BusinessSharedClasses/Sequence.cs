
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.BusinessSharedClasses
{
    public class Sequence
    {

        public Sequence()
        {
            lLocalConnection = GlobalVariables.gPersistentConnection;
        }

        public Sequence(MySqlConnection myConnection)
        {
            lLocalConnection = myConnection;
        }

        private MySqlConnection lLocalConnection;

        public string getSequenceId(string pPrefix, int pLength, string pTableName)
        {
            // update tablename for new ID Number
            //string _strSql = "update " + pTableName + " set id = last_insert_id(id+1)";
            string _strSql = "update " + pTableName + " set id = last_insert_id(id+1) where transactionCode=''";
            MySqlCommand _insertCommand;

            try
            {
                _insertCommand = new MySqlCommand(_strSql, GlobalVariables.gPersistentConnection);
                _insertCommand.ExecuteNonQuery();
            }
            catch
            {
                _strSql = "update " + pTableName + " set id = last_insert_id(id+1)"; 
                _insertCommand = new MySqlCommand(_strSql, GlobalVariables.gPersistentConnection);
                _insertCommand.ExecuteNonQuery();
            }

            // get the last insert id
            _strSql = "Select last_insert_id() as id;";
            _insertCommand = new MySqlCommand(_strSql,
                                               GlobalVariables.gPersistentConnection);
            //_insertCommand.Fill(dtTable);

            long id;
            id = long.Parse(_insertCommand.ExecuteScalar().ToString());

            string _trailingZero = "";

            for (int i = 0; i <= (pLength - 1 - pPrefix.Length); i++)
            {
                _trailingZero += "0";
            }

            string _newId;
            _newId = pPrefix + string.Format("{0:" + _trailingZero + "}", id);
            return _newId;

        }

        // this is added for POS function
        public long GetSequenceLongId(string pTableName)
        {

            MySqlCommand _insertCommand;

            try
            {
                _insertCommand = new MySqlCommand("update " + pTableName + " set id = last_insert_id(id+1) where transactioncode=''", lLocalConnection);
                _insertCommand.ExecuteNonQuery();
            }
            catch
            {
                _insertCommand = new MySqlCommand("update " + pTableName + " set id = last_insert_id(id+1)", lLocalConnection);
                _insertCommand.ExecuteNonQuery();
            }
            
            _insertCommand = new MySqlCommand("Select last_insert_id() as id;", lLocalConnection);


            long _id = 0;

            _id = long.Parse(_insertCommand.ExecuteScalar().ToString());

            return _id;
        }

        //added for getting different auto-sequence ids for different transaction code
        public string GetSequenceLongId(string pTableName, string pTransactionCode)
        {

            MySqlCommand _insertCommand = new MySqlCommand("update " + pTableName + " set id = last_insert_id(id+1) where transactioncode='" + pTransactionCode + "'", lLocalConnection);

            _insertCommand.ExecuteNonQuery();
            _insertCommand = new MySqlCommand("Select last_insert_id() as id from " + pTableName + " where transactioncode='" + pTransactionCode + "';", lLocalConnection);

            string _id = "";

            try
            {
                _id = _insertCommand.ExecuteScalar().ToString();
            }
            catch
            {
                _id = "";
            }

            return _id;
        }
    }
}
