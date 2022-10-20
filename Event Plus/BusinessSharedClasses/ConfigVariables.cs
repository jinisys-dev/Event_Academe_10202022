using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class ConfigVariables
	{
		/* Added April 17, 2008
		 * To cater all Global Variables from Config Files
		 * since config variables are transferred to db table
		 * system_config
		*/
		public static string gHotelID = "";
        public static string gNightAuditEnabled = "";
        public static string gCashieringEnabled = "";
		public static string gAutoPostNightAudit = "";
		public static string gNightAuditOverride = "";
        public static string gContingencyCode = "";
		public static string gBackOfficeInvoiceStart = "";
		public static string gBackOfficeName = "";
		public static string gCreditMemo = "";
		public static string gDebitMemo = "";
        public static string gAmendmentsChangesLogTables = "";
        public static string gRoomChargeTransactionCode = "";
		public static string gDefaultBreakfastValue = "";
		public static string gDefaultCashTerminal = "";
		public static string gDefaultShiftCode = "";

		public static string gDumpAccountingLogs = "";
		public static string gDumpFileSize = "";
		public static string gDumpPath = "";


		public static string gIsHousekeepingIntegrated = "";

		public static string gMaxAllowedFrontdeskDiscount = "";
		public static string gVerifyOnChangeRate = "";

		public static string gRegistrationForm = "";
		public static string gReportAddress1 = "";
		public static string gReportAddress2 = "";
		public static string gReportContactNo = "";
		public static string gReportLogo = "";
		public static string gReportOrganization = "";
		public static string gReportWebsite = "";
        public static string gReportTin = "";
		public static string gShowRoomAvailabilityAtStartUp = "";
		public static string gShowRoomAvailabilityDays = "";


		public static string gDefaultWalkInAccount = "";

		public static string gAppBackground = "";
		public static string gAppBuildNo = "";
		public static string gAppLogo = "";
		public static string gAppTitle = "";
		public static string gAppVersion = "";

		public static string gDefaultGuestThresholdValue = "";
		public static string gDefaultCompanyThresholdValue = "";

		public static string gDefault_Guest = "";

		public static string gTransactionRequiredUponCheckOut = "NONE";

		public static string gMinibarSaleTransactionCode = "";

		public static string gDefaultRoomCalendarColWidth = "";
		public static string gDefaultGuestListFolioTypeSelected = "";

		//added, jrom: March 6, 2009
		public static string gDefaultStatusForNewReservation = "";
		public static string gNewReservationStatusAfterPayment = "";

        //added by genny
        public static string gAutoRoomingEnabled = "";
        public static string gAllowPreviousDaysRouting = "";
        public static string gAllowDeAllocateWithBalance = "";

        public static string gShowReportHeaderOnGuestStatement = "";
        public static string gShowRemarksOnGuestStatement = "";
        
        //added by genny for folio previous versions merging
        public static string gAllowFullPaymentUponCheckIn = "true";
        public static string gAllowPreviousDatePosting = "true";
        public static string gDecimalFormat = "N2";
        public static string gExactAdjustmentAccount = "200002020";

        //added by genny for disabling event management
        public static string gIsEventManagementDisabled = "false";
        //added by jlo for emm only versions
        public static string gIsEMMOnly = "false";
        public static string gGuestSOA = "";
        //added by genny for path and type of contract
        public static string gContractPath = "";
        public static string gContractType = "";
        public static string gDisableFoodOtherDetails = "false";

        //added by genny for room inclusions and special instructions
        public static string gRoomInclusionHeader = "";
        public static string gSpecialInstructionHeader = "";
        public static string gFilteredHeadersForFolioInclusions = "";

        public static string gFolioPrintOutWithTax = "";
        public static string gAllowEditMealItems = "";
        public static string gPostRoomChargeForFunctionRoom = "";
        public static string gSalesExecutiveManager = "";
        public static string gRestoConnected = "";
        public static string gServerUploadPath = "";
        public static string gNoShowTime = "15:00:00";

        //public static string 

        public static string gSAPServer = "";
        public static string gSAPDBUsername = "";
        public static string gSAPDBPassword = "";
        public static string gSAPCompanyDB = "";
        public static string gSAPUsername = "";
        public static string gSAPPassword = "";
        
        public static void updateConfig(string pKey, string pValue, string pDescription)
		{
			try
			{

				MySqlCommand _updateCommand = new MySqlCommand("call spUpdateSystemConfig('"
																+ pKey + "','"
																+ pValue + "','"
																+ pDescription + "','"
																+ GlobalVariables.gLoggedOnUser
																+ "')", GlobalVariables.gPersistentConnection);

				_updateCommand.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public static void updateConfigKeyValue(string pKey, string pValue)
		{
			try
			{
				MySqlCommand _updateCommand = new MySqlCommand("call spUpdateSystemConfigValue('"
																	+ pKey + "','"
																	+ pValue + "','"
																	+ GlobalVariables.gLoggedOnUser
																	+ "')", GlobalVariables.gPersistentConnection);
				_updateCommand.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


	}

}
