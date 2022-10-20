using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;


namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class DatasetBinder
	{
		
		public DatasetBinder()
		{
			
		}
		private Collection ControlsToBind = new Collection();
		private static ArrayList Except;
		public void BindControls(Control FormControl, ref object obj, ArrayList Except)
		{
			System.Windows.Forms.Control ctrl;
			foreach (System.Windows.Forms.Control tempLoopVar_ctrl in FormControl.Controls)
			{
				ctrl = tempLoopVar_ctrl;
				if (IsExempted(ctrl, Except) == false)
				{
					BindControl(ref ctrl, Except,ref obj);
				}
			}
			Bind(ref obj);
		} 
		private bool IsExempted(Control ctrl, ArrayList collection)
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
		private void BindControl(ref Control ctrl, ArrayList ExemptedControl, ref object obj)
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
								BindControl(ref ctrl1, Except, ref obj);
							}
						}
						else
						{
							if (IsExempted(ctrl1, Except) == false)
							{
								ControlsToBind.Add(ctrl1, null, null, null);
							}
						}
					}
				}
				else
				{
					if (IsExempted(ctrl, Except) == false)
					{
						ControlsToBind.Add(ctrl, null, null, null);
					}
				}
			}
			else
			{
				if (IsExempted(ctrl, Except) == false)
				{
					ControlsToBind.Add(ctrl, null, null, null);
				}
			}
			
		}
		private void Bind(ref object obj)
		{
			Control control;
			foreach (Control tempLoopVar_control in ControlsToBind)
			{
				control = tempLoopVar_control;
				AddBinding(control, obj);
			}
		}
		private void AddBinding(Control control, object obj)
		{
			DataSet ds = (DataSet)obj;

			DataTable dataTable;
			string Tablename;

			foreach (DataTable dtTable in ds.Tables)
			{
				dataTable = dtTable;
				Tablename = dataTable.TableName;
				if (control is DataGrid)
				{
					control.DataBindings.Add(new Binding("DataSource", obj, dtTable.TableName));
					return;
				}
				DataColumn DataColumn;
				foreach (DataColumn tempLoopVar_DataColumn in dtTable.Columns)
				{
					DataColumn = tempLoopVar_DataColumn;
					if (control.Name.Substring(3).ToLower() == DataColumn.ColumnName.ToLower())
					{
						
						switch (control.Name.Substring(0, 3).ToLower())
						{
							case "txt":
								
								control.DataBindings.Add(new Binding("Text", dtTable, DataColumn.ColumnName));
								break;
								
							case "cbo":
								
								control.DataBindings.Add(new Binding("Text", dtTable, DataColumn.ColumnName));
								break;
								
							case "dtp":
								
								control.DataBindings.Add(new Binding("Text", dtTable, DataColumn.ColumnName));
								break;
								
							case "nud":
								control.DataBindings.Add(new Binding("Text", dtTable, DataColumn.ColumnName));
								break;

							case "lbl":
								control.DataBindings.Add(new Binding("Text", dtTable, DataColumn.ColumnName));
								break;

                            case "chk":
                                control.DataBindings.Add(new Binding("Checked", dtTable, DataColumn.ColumnName));
                                break;
						}
						
						return;
					}
				}
				
			}
			
		}
		
	}
}
