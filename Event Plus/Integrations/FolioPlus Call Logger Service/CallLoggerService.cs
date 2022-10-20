using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

using System.Threading;
using MySql.Data.MySqlClient;
using Jinisys.FolioPlusCallLogger.BusinessLayer;

namespace Folio_Plus_Call_Logger_Service
{
    public partial class CallLoggerService : ServiceBase
    {
        public CallLoggerService()
        {
            InitializeComponent();

            initializeAndConnectToDatabase();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            try
            {
                initializeAndConnectToDatabase();

                if (!EventLog.SourceExists("Folio Plus Call Logger"))
                {
                    EventLog.CreateEventSource("Folio Plus Call Logger", "Folio Plus Call Logger");
                }
                EventLog.WriteEntry("Folio Plus Call Logger", "Call Logger Service started at " + DateTime.Now);


                ThreadStart trStart = new ThreadStart(ChargeCalls);
                Thread tr = new Thread(trStart);
                tr.Start();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Folio Plus Call Logger", "Error upon starting service on " + DateTime.Now + " " + ex.Message);
            }

        }

        public void ChargeCalls()
        {
            //initializeAndConnectToDatabase();
			
            while (true)
            {
                CallChargesFacade oCallChargesFacade = new CallChargesFacade(localConnection);
                oCallChargesFacade.InsertCallCharges();

                Thread.Sleep(timerInterval);
            }
            
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            EventLog.WriteEntry("Folio Plus Call Logger","Call Logger Service stopped at " + DateTime.Now);
        }

        public int timerInterval = 1000;
        private MySqlConnection localConnection;
        public void initializeAndConnectToDatabase()
        {
            try
            {
                
                string connectionTxt;
                connectionTxt = System.Configuration.ConfigurationManager.AppSettings.Get("connection");
                timerInterval = int.Parse(System.Configuration.ConfigurationManager.AppSettings.Get("TimerInterval").ToString());

                MySqlConnection myDBConnection = new MySqlConnection(connectionTxt);
                myDBConnection.Open();

                localConnection = myDBConnection;
                EventLog.WriteEntry("Folio Plus Call Logger", "Call Logger Service successfully connected to database at " + DateTime.Now);

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Folio Plus Call Logger", "@initializeAndConnectToDatabase() " + ex.Message);
            }

        }

    }
}
