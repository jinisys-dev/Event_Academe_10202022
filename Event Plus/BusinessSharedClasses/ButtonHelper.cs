using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;


namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class ButtonHelper
	{
		
		
		public ButtonHelper()
		{
		}
		
		public void ManageButtons(System.Windows.Forms.Control ctrl, string MODE)
		{
			Control btn; // i As Integer
			
			switch (MODE)
			{
				case "Add":
					
					foreach (Control tempLoopVar_btn in ctrl.Controls)
					{
						btn = tempLoopVar_btn;
						if (btn is Button)
						{
							if (btn.Name == "btnNew" || btn.Name == "btnDelete" || btn.Name == "btnEdit" || btn.Name == "btnUpdate")
							{
								
								btn.Enabled = false;
							}
							else
							{
								btn.Enabled = true;
							}
						}
					}
					break;
				case "Edit":
					
					foreach (Control tempLoopVar_btn in ctrl.Controls)
					{
						btn = tempLoopVar_btn;
						if (btn is Button)
						{
							if (btn.Name == "btnNew" || btn.Name == "btnDelete" || btn.Name == "btnEdit" || btn.Name == "btnSave")
							{
								
								btn.Enabled = false;
							}
							else
							{
								btn.Enabled = true;
							}
						}
					}
					break;
				case "Load":
					
					foreach (Control tempLoopVar_btn in ctrl.Controls)
					{
						btn = tempLoopVar_btn;
						if (btn is Button)
						{
							if (btn.Name == "btnNew" || btn.Name == "btnDelete" || btn.Name == "btnEdit")
							{
								
								btn.Enabled = true;
							}
							else
							{
								btn.Enabled = false;
							}
						}
					}
					break;
			}
		}
	}
	
}
