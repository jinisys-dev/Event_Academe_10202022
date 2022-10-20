using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class TransactionTypeDAO
    {

        private TransactionType oTransactionType;

        public TransactionTypeDAO()
        {
        }

        public object loadObject()
        {
            try
            {
                oTransactionType = new TransactionType();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectTransactionTypes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(oTransactionType, "TransactionTypes");

                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = oTransactionType.Tables["TransactionTypes"].Columns["TranTypeId"];
                oTransactionType.Tables["TransactionTypes"].PrimaryKey = primaryKey;

                return oTransactionType;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public int insertObject(ref TransactionType a_TransactionType)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand insertCommand = new MySqlCommand("call spInsertTranType('" + a_TransactionType.TranTypeId + "','" + a_TransactionType.TranType + "','" + a_TransactionType.AcctGroup + "','" + a_TransactionType.HotelID + "','" + a_TransactionType.CreatedBy + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    insertDataRow(ref a_TransactionType);
                    return rowsAffected;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");

                return 0;
            }
        }

        public int updateObject(ref TransactionType a_TransactionType)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand updateCommand = new MySqlCommand("call spUpdateTranType('" + a_TransactionType.TranTypeId + "','" + a_TransactionType.TranType + "','" + a_TransactionType.AcctGroup + "','" + a_TransactionType.UpdatedBy + "','" + a_TransactionType.HotelID + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    updateDataRow(ref a_TransactionType);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public int deleteObject(ref TransactionType a_TransactionType)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand deleteCommand = new MySqlCommand("call spDeleteTranType('" + a_TransactionType.TranTypeId + "','" + a_TransactionType.UpdatedBy + "','" + a_TransactionType.HotelID + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = deleteCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    deleteDataRow(ref a_TransactionType);
                    return rowsAffected;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public void insertDataRow(ref TransactionType a_TransactionType)
        {
            try
            {
                DataRow dataRow = a_TransactionType.Tables[0].NewRow();
                dataRow["TranTypeId"] = a_TransactionType.TranTypeId;
                dataRow["TranType"] = a_TransactionType.TranType;
                dataRow["AcctGroup"] = a_TransactionType.AcctGroup;
                dataRow["CreatedBy"] = a_TransactionType.CreatedBy;
                dataRow["createtime"] = DateTime.Now;
                dataRow["updatedby"] = a_TransactionType.CreatedBy;
                dataRow["updatetime"] = DateTime.Now;

                a_TransactionType.Tables[0].Rows.Add(dataRow);
                a_TransactionType.Tables[0].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Data Row Exception");
            }
        }

        public void updateDataRow(ref TransactionType a_TransactionType)
        {
            try
            {
                DataRow dataRow = a_TransactionType.Tables[0].Rows.Find(a_TransactionType.TranTypeId);
                dataRow.BeginEdit();

                dataRow["TranTypeId"] = a_TransactionType.TranTypeId;
                dataRow["TranType"] = a_TransactionType.TranType;
                dataRow["AcctGroup"] = a_TransactionType.AcctGroup;
                dataRow["updatedby"] = a_TransactionType.UpdatedBy;
                dataRow["updatetime"] = DateTime.Now;

                dataRow.EndEdit();
                dataRow.AcceptChanges();
                a_TransactionType.Tables["TransactionTypes"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Row Exception");
            }
        }

        public void deleteDataRow(ref TransactionType a_TransactionType)
        {
            try
            {
                DataRow row = a_TransactionType.Tables[0].Rows.Find(a_TransactionType.TranTypeId);
                a_TransactionType.Tables[0].Rows.Remove(row);
                a_TransactionType.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Data Row Exception");
            }
        }

    }
}
