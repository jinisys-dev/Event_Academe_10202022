
using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using SAPbobsCOM;

namespace Jinisys.Hotel.BusinessSharedClasses
{

	public class GlobalVariables
	{
		public static object gMDI;

		public static int gHotelId = 1;
		public static int gTerminalID;

		public static string gLoggedOnUser;
		public static object goUser;

		public static string gUserDesignation;

		public static object goSupervisor;
		public static string gLoggedSupervisor;

		public static MySqlConnection gPersistentConnection;
		public static MySqlConnection gConnectionForBackGroundWorker;
        public static MySqlConnection gPOSConnection;
		public static MySqlConnection gCallAcctgConnection;
        public static MySqlConnection gHouseKeepingConnection;
        
		public static string gDateFormat = "{0:dd-MMM-yyyy}";


        public static DateTime gExpiryDate = DateTime.Parse("12/30/2008"); // for Demo Versions only
    
        /* 
         * Added for Open/Close Shift purposes (Cash Flow Control)
         */
        public static bool gCashDrawerOpen;
        public static int gShiftCode;

		/*
         * Addded to resolve conflict between postingdate and audit date
         */
        public static string gAuditDate;

        /* for REPORT IMAGE optimization
         * load REPORT IMAGE upon Main.start()
         */
        public static byte[] gReportImage = null;

		public static IList<Country> gCountryList = null;

		///
		public static string APP_VERSION = "1.0.0";
		public static string APP_BUILD_NO = "918";

        public static string APP_CHECK_DIGIT = "1100";
        public static string APP_LICENSE_KEY = "";

        //Kevin Oliveros
        public static Company goSAPCompany;
        public static bool goIsConnectedToBackOffice;
 
	}

    public enum OperationMode { Add, Edit, View };

    /* newly added jrom 16-Nov-2006
     * for Reservation Modes...
     */
    public enum ReservationOperationMode
    {
        EarlyCheckIn,
        NewGuestReservation,
        NewChildFolio,
        QuickReservation,
        ViewFolioInformation,
        ViewChildFolio,
		ViewFolioFromCalendar,
        NewShareFolio,
        NonStaying,
		WaitList
    };

    public enum AccountType { Personal, Corporate };

    public enum PaymentMode
    {
        Cash,
        CreditCard,
        Charge,
        Cheque,
        XDeal,
        Others
    }

    public enum ReservationPurpose
    {
        Personal,
        Tourist,
        Business,
        Convention,
        Balikbayan,
        Party
    }

    // Gene 2013-11-15
    public enum EventStatus
    {
        ONGOING,
        TENTATIVE,
        WAITLIST,
        CONFIRMED,
        CANCELLED,
        CLOSED
    }

    public enum ReservationType
    {
        NEW,
        OLD
    }


    public class GlobalFunctions
    {


		/***************************************************************************
		 * 
		 * MySQL's ESCAPE CHARACTERS
        
		\0  An ASCII 0 (NUL) character. 
		\'  A single quote (''') character. 
		\"  A double quote ('"') character. 
		\b  A backspace character. 
		\n  A newline (linefeed) character. 
		\r  A carriage return character. 
		\t  A tab character. 
		\Z  ASCII 26 (Control-Z). This character can be encoded as '\Z' to allow you to work around the problem that ASCII 26 stands for END-OF-FILE on Windows. (ASCII 26 causes problems if you try to use mysql db_name < file_name.) 
		\\  A backslash ('\') character. 
		\%  A '%' character. See note following table. 
		\_  A '_' character. See note following table. 

		 * SO FAR ONLY Single Quote(') creates a bug if included in the text field
		 */
		///////////////////////////////////////////////////////////////////////////

        public static string addSlashes(string pStr)
        {
            string _newStr = pStr;

            //_newStr = _newStr.Replace("\\", "\\\\");
            _newStr = _newStr.Replace("\"", "\\\"");
            _newStr = _newStr.Replace("\'", "\\\'");

            return _newStr;
        }

        ///added by JC 9.25.09 to lock folioID inorder to resolved lockwait timeout.
        public static void protectFolioID(string pFolioID, ref MySqlTransaction pTrans ) 
        {
            string _sql = "start transaction; select folioid from folio where folioid = '" + pFolioID + "' limit 1 for update ";
            MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
            _cmd.Transaction = pTrans;
            try
            {
                _cmd.ExecuteScalar();
            }
            catch
            {
                throw new Exception("Folio has been updated by another user.");
            }
        }

        public static string removeQuotes(string pStr)
        {
            string _str = pStr.Replace('\'', '`');
            _str = _str.Replace(';',',');
            return _str;
        }

    }

}
