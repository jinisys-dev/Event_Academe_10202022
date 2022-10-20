using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class ParameterHelper
	{
		
		public ParameterHelper()
		{
			
		}
		public void AddParameters(DataSet obj, ArrayList ExemptedFields, MySqlCommand Command, string TableName)
		{
			
			System.Data.DataColumn dataColumn;
			PropertyInfo[] propertyInfos;
			Type objectType = obj.GetType();
			propertyInfos = objectType.GetProperties();
			foreach (System.Data.DataColumn tempLoopVar_dataColumn in obj.Tables[TableName].Columns)
			{
				dataColumn = tempLoopVar_dataColumn;
				if (! ExemptedFields.Contains(dataColumn.ColumnName.ToLower()))
				{
					PropertyInfo pInfo;
					foreach (PropertyInfo tempLoopVar_pInfo in propertyInfos)
					{
						pInfo = tempLoopVar_pInfo;
						if (dataColumn.ColumnName.ToLower() == pInfo.Name.ToLower())
						{
							MySqlParameter param = Command.CreateParameter();
							param.ParameterName = "p" + dataColumn.ColumnName;
							param.SourceColumn = dataColumn.ColumnName;
							param.Value = pInfo.GetValue(obj, null);
							param.Direction = ParameterDirection.Input;
							Command.Parameters.Add(param);
							
						}
					}
				}
			}
		}
		//uses datatable
		public void AddParameters(DataSet obj, ArrayList ExemptedFields, MySqlCommand Command, DataTable dt)
		{
			System.Data.DataColumn dataColumn;
			PropertyInfo[] propertyInfos;
			Type objectType = obj.GetType();
			propertyInfos = objectType.GetProperties();
			foreach (System.Data.DataColumn tempLoopVar_dataColumn in dt.Columns)
			{
				dataColumn = tempLoopVar_dataColumn;
				if (! ExemptedFields.Contains(dataColumn.ColumnName.ToLower()))
				{
					PropertyInfo pInfo;
					foreach (PropertyInfo tempLoopVar_pInfo in propertyInfos)
					{
						pInfo = tempLoopVar_pInfo;
						if (dataColumn.ColumnName.ToLower() == pInfo.Name.ToLower())
						{
							MySqlParameter param = Command.CreateParameter();
							param.ParameterName = "p" + dataColumn.ColumnName;
							param.SourceColumn = dataColumn.ColumnName;
							param.Value = pInfo.GetValue(obj, null);
							param.Direction = ParameterDirection.Input;
							Command.Parameters.Add(param);
						}
					}
				}
			}
		}
		
		public void AddParameters(MySqlParameter parameter, string name, ParameterDirection direction, DbType dbtype, string value, MySqlCommand command)
		{
			
			parameter.ParameterName = name;
			parameter.Direction = direction;
			parameter.DbType = dbtype;
			parameter.Value = value;
			command.Parameters.Add(parameter);
		}
	}
	
	
}
