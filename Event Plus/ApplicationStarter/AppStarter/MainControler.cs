//using System.Collections.Specialized;
//using System.Diagnostics;
//using System.Data;
//using System.Drawing;
//using System.Collections;
//using System.IO;
using System;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Reflection;
using System.Configuration;
using ApplicationStarter.Presentation;

namespace ApplicationStarter
{
	public class MainController
    {

        #region "VARIABLES"

        private static Form lHotelMainUI;
		private static string lConnectionString;

        #endregion

        [STAThread]
		public static void Main()
		{
            // Riyadh 05/13/2015
            // Removed for Academe
            //getConnectionString();
            //>>

            // Riyadh 05/13/2015
            // Added for Academe
            DatabasePicker oDatabasePicker = new DatabasePicker();
            Application.Run(oDatabasePicker);

            lConnectionString = oDatabasePicker.getConnectionString();
            oDatabasePicker.Dispose();
            //>>


            Assembly _newAssembly;
            Type _type;

            _newAssembly = Assembly.LoadFrom(ConfigurationManager.AppSettings.Get("AppManagerAssembly"));
            _type = _newAssembly.GetType("Jinisys.Hotel.ApplicationManager.Presentation.MDIMainUI");

            Type[] _param = {typeof(System.String)};
            ConstructorInfo _ci = _type.GetConstructor(_param);
            object[] _oParamVal = { lConnectionString };

            lHotelMainUI = _ci.Invoke(_oParamVal) as Form;
            
            GlobalVariables.gMDI = lHotelMainUI;
            Application.EnableVisualStyles();
            // start Application
            Application.Run(lHotelMainUI);

		}
		
		private static void getConnectionString()
		{
			try
			{
                string _connStr = ConfigurationManager.AppSettings.Get("connection");
				lConnectionString = _connStr;
			}

			catch (Exception ex)
			{
				MessageBox.Show("Exception: " + ex.Message,"Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
	
	
}
