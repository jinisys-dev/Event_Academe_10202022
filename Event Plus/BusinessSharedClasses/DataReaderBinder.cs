using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class DataReaderBinder
	{
		
		public void BinderReaderToEntity(MySql.Data.MySqlClient.MySqlDataReader dataReader, ref object obj)
		{
            try
            {
                PropertyInfo[] pinfo = obj.GetType().GetProperties();
                PropertyInfo info;

                while (dataReader.Read())
                {
                    for (int i = 0; i <= dataReader.FieldCount - 1; i++)
                    {
                        foreach (PropertyInfo tempLoopVar_info in pinfo)
                        {
                            info = tempLoopVar_info;
                            if (info.Name.ToLower() == dataReader.GetName(i).ToLower())
                            {
                                if (!Information.IsDBNull(dataReader[info.Name.ToString()]))
                                {
                                    //MsgBox(dataReader(info.Name.ToString) & " = " & dataReader(info.Name.ToString).GetType.ToString)
                                    //MsgBox(info.Name.ToString & "=" & info.GetType.ToString)
                                    info.SetValue(obj, dataReader[info.Name.ToString()], null);
                                    //MsgBox(info.GetValue(obj, Nothing))
                                    break;
                                }
                            }
                        }
                    }
                }
                dataReader.Close();
            }
            finally
            {
                dataReader.Close();
            }
           
		}
	}
	
}
