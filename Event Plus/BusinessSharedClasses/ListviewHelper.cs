using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;


namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class ListViewItemComparer : IComparer
	{
		
		
		private int col;
		public ListViewItemComparer()
		{
			col = 0;
		}
		public ListViewItemComparer(int column)
		{
			col = column;
		}
		
		public int Compare(object x, object y)
		{
			return String.Compare(((ListViewItem) x).SubItems[col].Text, ((ListViewItem) y).SubItems[col].Text);
		}
	}
	
	public class ListviewHelper
	{
		
		public ListviewHelper()
		{
			
		}
		
		public void LoadDataToListview(DataTable dt, ListView listView)
		{
			try
			{
				DataRow vDataRow;
				DataColumn vDataColumn;
				listView.Clear();
				foreach (DataColumn tempLoopVar_vDataColumn in dt.Columns)
				{
					vDataColumn = tempLoopVar_vDataColumn;
					ColumnHeader vColumnHeader = new ColumnHeader();
					vColumnHeader.Text = vDataColumn.ColumnName;
					listView.Columns.Add(vColumnHeader);
				}
				foreach (DataRow tempLoopVar_vDataRow in dt.Rows)
				{
					vDataRow = tempLoopVar_vDataRow;
					int Cols;
					
					ListViewItem vListViewItem = new ListViewItem();
					vListViewItem.Text = vDataRow[0].ToString();
					
					for (Cols = 1; Cols <= dt.Columns.Count - 1; Cols++)
					{
						
						ListViewItem.ListViewSubItem vListViewSubItem = new ListViewItem.ListViewSubItem();
						if (Information.IsDBNull(vDataRow[Cols]) == false)
						{
							if (Information.IsDate(vDataRow[Cols].ToString()) == false)
							{
								vListViewSubItem.Text = vDataRow[Cols].ToString();
							}
							else
							{
								vListViewSubItem.Text = Strings.Format(System.Convert.ToDateTime(vDataRow[Cols].ToString()), "MM/dd/yyyy");
							}
						}
						else
						{
							vListViewSubItem.Text = "";
						}
						vListViewItem.SubItems.Add(vListViewSubItem);
					}
					listView.Items.Add(vListViewItem);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		
		public void formatColumnListviewWidth(string widths, ListView lvw)
		{
			ArrayList columnWidth = new ArrayList();
			string[] columnValue = widths.Split('|');
			string x;
			int column = 0;
			foreach (string tempLoopVar_x in columnValue)
			{
				x = tempLoopVar_x;
				lvw.Columns[column].Width = System.Convert.ToInt32(x);
				column++;
			}
		}
	}
}
