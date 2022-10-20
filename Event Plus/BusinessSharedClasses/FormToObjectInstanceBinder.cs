using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class FormToObjectInstanceBinder
	{
		
		public static string username;
		public static string pw;
		public static string connectionString;
		private static object mObjectInstance;
		//Private Shared objectType As Type
		private static PropertyInfo[] propertyInfos;
		private static ArrayList Except;
		public static void clearTextboxes(System.Windows.Forms.Control WindowsControl)
		{
			System.Windows.Forms.Control ctrl;
			foreach (System.Windows.Forms.Control tempLoopVar_ctrl in WindowsControl.Controls)
			{
				ctrl = tempLoopVar_ctrl;
				clearText(ctrl);
			}
		}
		private static void clearText(Control ctrl)
		{
			Control ctrl1;
			foreach (Control tempLoopVar_ctrl1 in ctrl.Controls)
			{
				ctrl1 = tempLoopVar_ctrl1;
				if (!(ctrl1 is TextBox || ctrl1 is ComboBox))
				{
					clearText(ctrl1);
				}
				else
				{
					ctrl1.Text = "";
				}
			}
		}
		public static void BindControls(Control FormControl, object obj, ArrayList Except)
		{
			mObjectInstance = obj;
			Type objectType = obj.GetType();
			propertyInfos = objectType.GetProperties();
			
			System.Windows.Forms.Control ctrl;
			foreach (System.Windows.Forms.Control tempLoopVar_ctrl in FormControl.Controls)
			{
				ctrl = tempLoopVar_ctrl;
				if (IsExempted(ctrl, Except) == false)
				{
					BindControl(ctrl, Except);
				}
			}
			
		}
		private static bool IsExempted(Control ctrl, ArrayList collection)
		{
			Control control;
			foreach (Control tempLoopVar_control in collection)
			{
				control = tempLoopVar_control;
				if (control == ctrl)
				{
					return true;
				}
			}
			return false;
		}
		private static void BindControl(Control ctrl, ArrayList ExemptedControl)
		{
			Control ctrl1;
			Except = ExemptedControl;
			if (!(ctrl is DataGrid || ctrl is NumericUpDown))
			{
				if (ctrl.Controls.Count >= 1)
				{
					foreach (Control tempLoopVar_ctrl1 in ctrl.Controls)
					{
						ctrl1 = tempLoopVar_ctrl1;
						
						if (!(ctrl1 is TextBox || ctrl1 is ComboBox || ctrl1 is PictureBox || ctrl1 is DateTimePicker || ctrl1 is ListBox || ctrl1 is ListView || ctrl1 is NumericUpDown || ctrl1 is CheckBox))
						{
							if (IsExempted(ctrl1, Except) == false)
							{
								BindControl(ctrl1, Except);
							}
						}
						else
						{
							if (IsExempted(ctrl1, Except) == false)
							{
								Bind(ctrl1);
							}
						}
					}
				}
				else
				{
					if (IsExempted(ctrl, Except) == false)
					{
						Bind(ctrl);
					}
				}
			}
			else
			{
				if (IsExempted(ctrl, Except) == false)
				{
					Bind(ctrl);
				}
			}
		}
		private static void Bind(Control ctrl)
		{
			switch (ctrl.Name.Substring(0, 3).ToString().ToLower())
			{
				case "txt":
					ctrl.Text = GetObjectInstancePropertyValue(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)).ToString();
					try
					{
						ctrl.DataBindings.Add(new Binding("Text", mObjectInstance, ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)));
					}
					catch (Exception)
					{
					}
					break;
					
				case "cbo":
					ctrl.Text = GetObjectInstancePropertyValue(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)).ToString();
					try
					{
						ctrl.DataBindings.Add(new Binding("Text", mObjectInstance, ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)));
					}
					catch (Exception)
					{
					}
					break;
					
				case "dtp":
					
					ctrl.Text = GetObjectInstancePropertyValue(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)).ToString();
					try
					{
						ctrl.DataBindings.Add(new Binding("Text", mObjectInstance, ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)));
					}
					catch (Exception)
					{
					}
					break;
				case "grd":
					
					DataGrid dtgrid;
					dtgrid = (DataGrid) ctrl;
					BindGrid(dtgrid, (DataTable)GetDataSource(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)) );
					break;
				case "lst":
					
					ListBox lstbox;
					lstbox = (ListBox) ctrl;
					//BindListBox(lstbox, GetDataSource(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)));
					break;
				case "lvw":
					ListView lvw;
					lvw = (ListView)ctrl;
					BindListView(lvw, (DataTable)GetDataSource(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)));
					break;
				case "rdo":
					
					string PropertyName = ctrl.Name.Substring(3, ctrl.Name.Length - 4);
					string propertyValue = GetObjectInstancePropertyValue(PropertyName).ToString();
					if ("rdo" + PropertyName.ToLower() + propertyValue.ToLower() == ctrl.Name.ToLower())
					{
						RadioButton rdo = (RadioButton)ctrl;
						BindRadioButton(rdo);
					}
					break;
				case "pic":
					
					System.Drawing.Image image;

					try
					{
						PictureBox pct = (PictureBox) ctrl;
						image = System.Drawing.Image.FromFile(GetObjectInstancePropertyValue(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)).ToString());
						BindImageToPictureBox(pct, image);
					}
					catch (Exception)
					{
						PictureBox pct = (PictureBox) ctrl;
						BindImageToPictureBox(pct, null);
					}
					break;
				case "nud":
					NumericUpDown nud;
					nud = (NumericUpDown) ctrl;
					BindNumericDropDown(nud, System.Convert.ToInt32(GetObjectInstancePropertyValue(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3))));
					break;
				case "chk":
					CheckBox chk;
					chk = (CheckBox)ctrl;
					BindCheckBox(chk, (int)GetObjectInstancePropertyValue(ctrl.Name.Substring(ctrl.Name.Length - ctrl.Name.Length - 3, ctrl.Name.Length - 3)));
					break;
			}
		}
		private static void BindCheckBox(CheckBox ctrl, int flag)
		{
			if (flag == 0)
			{
				ctrl.Checked = true;
			}
			else
			{
				ctrl.Checked = false;
			}
		}
		private static void BindImageToPictureBox(System.Windows.Forms.PictureBox PictureBox, System.Drawing.Image image)
		{
			PictureBox.Image = image;
			PictureBox.Refresh();
		}
		private static void BindNumericDropDown(NumericUpDown Ctrl, int value)
		{
			Ctrl.Value = value;
		}
		private static void BindRadioButton(RadioButton ctrl)
		{
			ctrl.Checked = true;
		}
		private static void BindListView(ListView ListView, DataTable DataSource)
		{
//			ListView.Items.Clear();
//			ListView.View = View.Details;
//			ListView.LabelEdit = true;
//			ListView.AllowColumnReorder = true;
//			ListView.FullRowSelect = true;
//			ListView.GridLines = true;
//			ListView.Sorting = SortOrder.Ascending;
//			int i;
//			DataColumn DataSourceColumn;
//			if (DataSource != null)
//			{
//				foreach (DataColumn tempLoopVar_DataSourceColumn in DataSource.Columns)
//				{
//					DataSourceColumn = tempLoopVar_DataSourceColumn;
//					ColumnHeader ColHeader = new ColumnHeader();
//					ColHeader.Text = DataSourceColumn.ColumnName;
//					ColHeader.TextAlign = HorizontalAlignment.Left;
//					ColHeader.Width = ColHeader.Text.Length * 5;
//					ListView.Columns.Add(ColHeader);
//				}
//				DataRow DataSourceRow;
//				if (DataSource != null)
//				{
//					for (i = 0; i <= DataSource.Rows.Count - 1; i++)
//					{
//						DataSourceRow = DataSource.Rows[i];
//						ListViewItem lst = new ListViewItem(DataSourceRow[0].ToString());
//						int x;
//						for (x = 1; x <= DataSourceRow.ItemArray.GetUpperBound(0); x++)
//						{
//							if (! (DataSourceRow[x]) is DBNull)
//							{
//								if (! (DataSourceRow[x]) is System.DateTime)
//								{
//									lst.SubItems.Add(DataSourceRow[x]);
//								}
//								else
//								{
//									lst.SubItems.Add(DataSourceRow[x].ToString());
//								}
//							}
//							else
//							{
//								lst.SubItems.Add("");
//							}
//						}
//						ListView.Items.Add(lst);
//					}
//				}
//			}
//			ListView.Refresh();
		}
		private static void BindGrid(DataGrid control, DataTable datasource)
		{
			control.DataSource = datasource;
		}
		private static void BindListBox(ListControl control, DataTable datasource)
		{
			control.DataSource = datasource;
			control.DisplayMember = datasource.Columns[0].ColumnName.ToLower();
		}
		private static object GetDataSource(string ObjectName)
		{
			PropertyInfo propertyInfo;
			foreach (PropertyInfo tempLoopVar_propertyInfo in propertyInfos)
			{
				propertyInfo = tempLoopVar_propertyInfo;
				if (ObjectName.ToLower() == propertyInfo.Name.ToLower())
				{
					return propertyInfo.GetValue(mObjectInstance, null);
				}
			}
			return null;
		}
		private static object GetObjectInstancePropertyValue(string ObjectName)
		{
			PropertyInfo propertyInfo;
			foreach (PropertyInfo tempLoopVar_propertyInfo in propertyInfos)
			{
				propertyInfo = tempLoopVar_propertyInfo;
				if (ObjectName.ToLower() == propertyInfo.Name.ToLower())
				{
					return propertyInfo.GetValue(mObjectInstance, null);
				}
			}
			return null;
		}
		private static object GetObjectInstanceProperty(string ObjectName)
		{
			PropertyInfo propertyInfo;
			foreach (PropertyInfo tempLoopVar_propertyInfo in propertyInfos)
			{
				propertyInfo = tempLoopVar_propertyInfo;
				if (ObjectName.ToLower() == propertyInfo.Name.ToLower())
				{
					return propertyInfo.Name;
				}
			}
			return null;
		}
		public static void LoadDataToListview(DataTable dt, ListView listView, string Flag)
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
					if (Information.IsDate(vDataRow[0]) && Flag == "")
					{
						vListViewItem.Text = Strings.Format(System.Convert.ToDateTime(vDataRow[0].ToString()), "MM/dd/yyyy");
					}
					else
					{
						vListViewItem.Text = vDataRow[0].ToString();
					}
					
					for (Cols = 1; Cols <= dt.Columns.Count - 1; Cols++)
					{
						
						ListViewItem.ListViewSubItem vListViewSubItem = new ListViewItem.ListViewSubItem();
						if (Information.IsDBNull(vDataRow[Cols]) == false)
						{
							if (Information.IsDate(vDataRow[Cols].ToString()))
							{
								vListViewSubItem.Text = Strings.Format(System.Convert.ToDateTime(vDataRow[Cols].ToString()), "MM/dd/yyyy");
								if (vListViewSubItem.Text == "01/01/0001" && Flag != "")
								{
									vListViewSubItem.Text = vDataRow[Cols].ToString();
								}
							}
							else
							{
								vListViewSubItem.Text = vDataRow[Cols].ToString();
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
		
		public static void LoadDataToListview(DataTable dt, ListView listView, string[] FieldNames)
		{
			try
			{
				listView.Items.Clear();
				//For Each ColName In FieldNames
				//    Dim vColumnHeader As New ColumnHeader
				//    vColumnHeader.Text = ColName
				//    listView.Columns.Add(vColumnHeader)
				//Next
				DataRow vDataRow;
				foreach (DataRow tempLoopVar_vDataRow in dt.Rows)
				{
					vDataRow = tempLoopVar_vDataRow;
					int cols;
					ListViewItem vListViewItem = null;
					for (cols = 0; cols <= FieldNames.GetUpperBound(0); cols++)
					{
						
						if (cols == 0)
						{
							vListViewItem = new ListViewItem();
							if (! Information.IsDBNull(vDataRow[FieldNames[cols]]))
							{
								vListViewItem.Text = vDataRow[FieldNames[cols]].ToString();
							}
							else
							{
								vListViewItem.Text = "";
							}
						}
						else
						{
							vListViewItem.SubItems.Add(vDataRow[FieldNames[cols]].ToString());
						}
						
					}
					

					listView.Items.Add(vListViewItem);
					
				}
				
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		public static void BindInputControlToObject(ref Control aControl, object obj)
		{
			Type ty = obj.GetType();
			foreach (Control vControl in aControl.Controls)
			{
				if (vControl is TextBox || vControl is ComboBox || vControl is DateTimePicker || vControl is NumericUpDown || vControl is Label)
				{
					
					PropertyInfo[] pInfo = ty.GetProperties();
					PropertyInfo info;
					foreach (PropertyInfo tempLoopVar_info in pInfo)
					{
						info = tempLoopVar_info;
						if (info.Name.ToUpper() == Strings.Right(vControl.Name, vControl.Name.Length - 3).ToUpper())
						{
                            object ob = info.GetValue(obj, null);

                            if (ob != null)
                            {
                                try
                                {
                                    vControl.Text = info.GetValue(obj, null).ToString();
                                }
                                //catch (ArgumentOutOfRangeException ex)
                                //{
                                //    vControl.Text = DateTime.Now.Date.ToString();
                                //}
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                break;
                            }       
						}
					}
				}
                else if (vControl is Panel || vControl is GroupBox || vControl is TabControl || vControl is TabPage)
				{
                    Control mControl = vControl;
					BindInputControlToObject(ref mControl, obj);
				}
			}
		}
		
		public static void BindObjectToInputControls(Control aControl, object obj)
		{
			Control vControl;
			Type ty = obj.GetType();
			PropertyInfo[] pInfo = ty.GetProperties();
			PropertyInfo info;
			
			foreach (Control tempLoopVar_vControl in aControl.Controls)
			{
				vControl = tempLoopVar_vControl;
				if (vControl is TextBox || vControl is ComboBox || vControl is DateTimePicker || vControl is NumericUpDown)
				{
					
					foreach (PropertyInfo tempLoopVar_info in pInfo)
					{
						info = tempLoopVar_info;
						if (info.Name.ToUpper() == Strings.Right(vControl.Name, vControl.Name.Length - 3).ToUpper())
						{
							if (info.CanWrite)
							{
								//MsgBox(info.PropertyType.ToString & " " & info.Name)
								if (info.PropertyType.ToString() == "System.Int32")
								{
									info.SetValue(obj, System.Convert.ToInt32(vControl.Text), null);
									//  MsgBox(info.Name & " " & UCase(Strings.Right(vControl.Name, Len(vControl.Name) - 3)))
								}
								else if (info.PropertyType.ToString() == "System.DateTime")
								{
									if (vControl.Text != "")
									{
										info.SetValue(obj, System.Convert.ToDateTime(vControl.Text), null);
									}
									//    MsgBox(info.Name & " " & UCase(Strings.Right(vControl.Name, Len(vControl.Name) - 3)))
								}
								else if (info.PropertyType.ToString() == "System.Double")
								{
									info.SetValue(obj, System.Convert.ToDouble(vControl.Text), null);
									//      MsgBox(info.Name & " " & UCase(Strings.Right(vControl.Name, Len(vControl.Name) - 3)))
								}
								else if (info.PropertyType.ToString() == "System.String")
								{
									info.SetValue(obj,vControl.Text, null);
									//     MsgBox(info.Name & " " & UCase(Strings.Right(vControl.Name, Len(vControl.Name) - 3)))
									// Exit For
								}
							}
							
						}
					}
				}
				else if (vControl is Panel || vControl is GroupBox || vControl is TabControl)
				{
					//   MsgBox(vControl.Name)
					BindObjectToInputControls(vControl, obj);
				}
			}
		}
	}
	
}
