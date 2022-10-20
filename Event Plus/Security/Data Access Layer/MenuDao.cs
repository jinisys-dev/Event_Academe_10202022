using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.BusinessLayer;


namespace Jinisys.Hotel.Security
{
	namespace DataAccessLayer
	{
		public class MenuDao
		{
			
			
			private MySqlConnection localConnection;
			public MenuDao(MySqlConnection connection)
			{
				localConnection = connection;
			}
			
			
			public MenuCollection GetRoleMenus(string roleName, int hotelId)
			{
				try
				{
					DataTable dtTable = new DataTable();

					string _sqlStr = "call spGetRoleMenus('" 
										   + roleName + "','" 
										   + hotelId + "')";

					MySqlDataAdapter dtAdapter = new MySqlDataAdapter(_sqlStr, localConnection);
					dtAdapter.Fill(dtTable);
					dtAdapter.Dispose();
					
					MenuCollection oMenuCollection = new MenuCollection();
					
					DataRow dtRow;
					foreach (DataRow tempLoopVar_dtRow in dtTable.Rows)
					{
						dtRow = tempLoopVar_dtRow;
						SystemMenu oMenu = new SystemMenu();
						oMenu.MenuName = dtRow["Menu"].ToString();
						oMenu.Enable = (dtRow["Enable"].ToString() == "1") ? true : false;
                        if (oMenu.Enable == true)
                        {
                            oMenuCollection.Add(oMenu);
                        }
					}
					
					return oMenuCollection;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: @ GetRoleMenus() " + ex.Message);
					return null;
				}
				
			}
			
			
		
		}
	}
}
