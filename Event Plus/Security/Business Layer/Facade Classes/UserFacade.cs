
using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;

using System.Reflection;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		public class UserFacade
		{

			private MySqlConnection localConnection;
			public UserFacade(MySqlConnection connection)
			{
				localConnection = connection;
				
			}

			private string connectionStr;
			public UserFacade(string connectionString)
			{
				connectionStr = connectionString;
			}

			private UserDAO oUserDAO;
			public User GetUsers()
			{
				oUserDAO = new UserDAO(localConnection);
				return oUserDAO.GetUsers();
			}

            public User GetUserRolesAll()
            {
                oUserDAO = new UserDAO(localConnection);
                return oUserDAO.GetUserRolesAll();
            }

			public bool UpdateUser(ref User oUser)
			{
				oUserDAO = new UserDAO(localConnection);

				//oUserDAO.DeleteUserRoles(oUser);
				return oUserDAO.UpdateUser(oUser);
			}

			public bool InsertUser(ref User oUser)
			{
				oUserDAO = new UserDAO(localConnection);
				return oUserDAO.InsertUser(oUser);
			}

			public void DeleteUser(string UserId, ref User oUser)
			{
				oUserDAO = new UserDAO(connectionStr);
				oUserDAO.DeleteUser(UserId, oUser);
			}

			public bool RemoveUserRole(string userId, string hotelId, string RoleName)
			{
				oUserDAO = new UserDAO(localConnection);
				return oUserDAO.RemoveUserRole(userId, hotelId, RoleName);
			}

			public string GetOldPassword(User oUser)
			{
				oUserDAO = new UserDAO(localConnection);
				return oUserDAO.GetOldPassword(oUser);
			}

			public User VerifyLogin(string UserId, string Password)
			{
				oUserDAO = new UserDAO(connectionStr);
				return oUserDAO.VerifyLogin(UserId, Password);
			}

			public bool AuthenticateUser(ref User oUser)
			{
				oUserDAO = new UserDAO(localConnection);
				return oUserDAO.AuthenticateUser(oUser);
			}

			public bool changeUserPassword(User oUser)
			{
				oUserDAO = new UserDAO(localConnection);
				return oUserDAO.changeUserPassword(oUser);
			}

			DataTable dtConfig;
			public void loadConfigVariables()
			{
				try
				{
					oUserDAO = new UserDAO(localConnection);
					dtConfig = oUserDAO.loadSystemConfig();
                    
					ConfigVariables.gAutoPostNightAudit = getConfigValue("AUTO_POST_NIGHT_AUDIT");
					ConfigVariables.gBackOfficeInvoiceStart = getConfigValue("BACK_OFFICE_INVOICE_START");
					ConfigVariables.gBackOfficeName = getConfigValue("BACK_OFFICE_NAME");
					ConfigVariables.gCreditMemo = getConfigValue("CREDIT_MEMO");
					ConfigVariables.gDebitMemo = getConfigValue("DEBIT_MEMO");
					ConfigVariables.gDefaultBreakfastValue = getConfigValue("DEFAULT_BREAKFAST_VALUE");
					ConfigVariables.gDefaultCashTerminal = getConfigValue("DEFAULT_CASH_TERMINAL");
					ConfigVariables.gDefaultShiftCode = getConfigValue("DEFAULT_SHIFT_CODE");
					ConfigVariables.gDumpAccountingLogs = getConfigValue("DUMP_ACCOUNTING_LOGS");
					ConfigVariables.gDumpFileSize = getConfigValue("DUMP_FILE_SIZE");
					ConfigVariables.gDumpPath = getConfigValue("DUMP_PATH");
					ConfigVariables.gHotelID = getConfigValue("HOTEL_ID");
					ConfigVariables.gIsHousekeepingIntegrated = getConfigValue("IS_HOUSEKEEPING_INTEGRATED");
					ConfigVariables.gMaxAllowedFrontdeskDiscount = getConfigValue("MAX_ALLOWED_FRONTDESK_DISCOUNT");
					ConfigVariables.gNightAuditOverride = getConfigValue("NIGHT_AUDIT_OVERRIDE");
					ConfigVariables.gRegistrationForm = getConfigValue("REGISTRATION_FORM");
					ConfigVariables.gReportAddress1 = getConfigValue("REPORT_ADDRESS1");
					ConfigVariables.gReportAddress2 = getConfigValue("REPORT_ADDRESS2");
					ConfigVariables.gReportContactNo = getConfigValue("REPORT_CONTACT_NO");
					ConfigVariables.gReportLogo = getConfigValue("REPORT_LOGO");
					ConfigVariables.gReportOrganization = getConfigValue("REPORT_ORGANIZATION");
					ConfigVariables.gReportWebsite = getConfigValue("REPORT_WEBSITE");
                    ConfigVariables.gReportTin = getConfigValue("REPORT_TIN");
					ConfigVariables.gShowRoomAvailabilityAtStartUp = getConfigValue("SHOW_ROOM_AVAILABILITY_AT_START_UP");
					ConfigVariables.gShowRoomAvailabilityDays = getConfigValue("SHOW_ROOM_AVAILABILITY_DAYS");
					ConfigVariables.gVerifyOnChangeRate = getConfigValue("VERIFY_ON_CHANGE_RATE");
					ConfigVariables.gDefaultWalkInAccount = getConfigValue("DEFAULT_WALK_IN_ACCOUNT");
                    ConfigVariables.gAmendmentsChangesLogTables = getConfigValue("AMENDMENTS_CHANGES_LOG_TABLES");
					ConfigVariables.gAppBackground = getConfigValue("_APP_BACKGROUND");        
					ConfigVariables.gAppBuildNo = getConfigValue("_APP_BUILD_NO");
					ConfigVariables.gAppLogo = getConfigValue("_APP_LOGO");
					ConfigVariables.gAppTitle = getConfigValue("_APP_TITLE");
					ConfigVariables.gAppVersion = getConfigValue("_APP_VERSION");
                    ConfigVariables.gContingencyCode = getConfigValue("CONTINGENCY_CODE");
					ConfigVariables.gDefaultGuestThresholdValue = getConfigValue("DEFAULT_GUEST_THRESHOLD_VALUE");
					ConfigVariables.gDefaultCompanyThresholdValue = getConfigValue("DEFAULT_COMPANY_THRESHOLD_VALUE");
                    ConfigVariables.gRoomChargeTransactionCode = getConfigValue("ROOM_CHARGE_TRANSACTION_CODE");
					ConfigVariables.gDefault_Guest = getConfigValue("DEFAULT_GUEST");
					ConfigVariables.gTransactionRequiredUponCheckOut = getConfigValue("TRANSACTION_REQUIRED_UPON_CHECK_OUT");
					ConfigVariables.gMinibarSaleTransactionCode = getConfigValue("MINIBAR_SALE_TRANSACTION_CODE");

                    ConfigVariables.gDefaultGuestListFolioTypeSelected = getConfigValue("DEFAULT_FOLIO_TYPE_SELECTED");
                    ConfigVariables.gDefaultRoomCalendarColWidth = getConfigValue("DEFAULT_COL_WIDTH_CALENDAR");

					ConfigVariables.gDefaultStatusForNewReservation = getConfigValue("DEFAULT_STATUS_FOR_NEW_RESERVATION");
					ConfigVariables.gNewReservationStatusAfterPayment = getConfigValue("NEW_RESERVATION_STATUS_AFTER_PAYMENT");

                    ConfigVariables.gAutoRoomingEnabled = getConfigValue("AUTO_ROOMING_ENABLED");
                    ConfigVariables.gAllowPreviousDaysRouting = getConfigValue("ALLOW_PREVIOUS_DAYS_ROUTING");
                    ConfigVariables.gAllowDeAllocateWithBalance = getConfigValue("ALLOW_DEALLOCATE_WITH_BALANCE");

                    ConfigVariables.gShowRemarksOnGuestStatement = getConfigValue("SHOW_REMARKS_ON_GUEST_STATEMENT");
                    ConfigVariables.gShowReportHeaderOnGuestStatement = getConfigValue("SHOW_REPORT_HEADER_ON_GUEST_STATEMENT");

                    ConfigVariables.gAllowPreviousDatePosting = getConfigValue("ALLOW_PREVIOUS_DATE_POSTING");
                    ConfigVariables.gAllowFullPaymentUponCheckIn = getConfigValue("ALLOW_FULL_PAYMENT_UPON_CHECK_IN");
                    ConfigVariables.gDecimalFormat = getConfigValue("DECIMAL_FORMAT");
                    ConfigVariables.gExactAdjustmentAccount = getConfigValue("EXACT_ADJUSTMENT_ACCOUNT");

                    ConfigVariables.gIsEventManagementDisabled = getConfigValue("IS_EVENT_MANAGEMENT_DISABLED");
                    ConfigVariables.gDisableFoodOtherDetails = getConfigValue("DISABLE_FOOD_OTHER_DETAILS");
                    ConfigVariables.gIsEMMOnly = getConfigValue("IS_EMM_ONLY");
                    ConfigVariables.gGuestSOA = getConfigValue("GUEST_SOA");
                    ConfigVariables.gContractPath = getConfigValue("CONTRACT_PATH");
                    ConfigVariables.gContractType = getConfigValue("CONTRACT_TYPE");

                    ConfigVariables.gSpecialInstructionHeader = getConfigValue("SPECIAL_INSTRUCTION_HEADER");
                    ConfigVariables.gRoomInclusionHeader = getConfigValue("ROOM_INCLUSION_HEADER");
                    ConfigVariables.gFilteredHeadersForFolioInclusions = getConfigValue("FILTERED_HEADERS_FOR_INCLUSIONS");

                    ConfigVariables.gFolioPrintOutWithTax = getConfigValue("FOLIO_PRINTOUT_WITH_TAX");
                    ConfigVariables.gAllowEditMealItems = getConfigValue("ALLOW_EDIT_MEAL_ITEMS");
                    ConfigVariables.gPostRoomChargeForFunctionRoom = getConfigValue("POST_ROOM_CHARGE_FOR_FUNCTION_ROOM");
                    ConfigVariables.gSalesExecutiveManager = getConfigValue("SALES_EXECUTIVE_MANAGER");
                    ConfigVariables.gRestoConnected = getConfigValue("IS_RESTO_CONNECTED");
                    ConfigVariables.gServerUploadPath = getConfigValue("SERVER_UPLOAD_PATH");
                    ConfigVariables.gNightAuditEnabled = getConfigValue("NIGHT_AUDIT_ENABLED");
                    ConfigVariables.gCashieringEnabled = getConfigValue("CASHIERING_ENABLED");
                    ConfigVariables.gNoShowTime = getConfigValue("NO_SHOW_TIME");
                    ConfigVariables.gContingencyCode = getConfigValue("CONTINGENCY_CODE");
                    ConfigVariables.gSAPServer = getConfigValue("SAP_SERVER");
                    ConfigVariables.gSAPDBUsername = getConfigValue("SAP_DB_USERNAME");
                    ConfigVariables.gSAPDBPassword = getConfigValue("SAP_DB_PASSWORD");
                    ConfigVariables.gSAPCompanyDB = getConfigValue("SAP_COMPANY_DB");
                    ConfigVariables.gSAPUsername = getConfigValue("SAP_USERNAME");
                    ConfigVariables.gSAPPassword = getConfigValue("SAP_PASSWORD");
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}

            public void loadExpiryDate()
            {
                try
                {
                    oUserDAO = new UserDAO(localConnection);
                    string date = oUserDAO.getExpiryDate();

                    GlobalVariables.gExpiryDate = DateTime.Parse(date);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

			public void loadCountyList()
			{
				IList<Country> _oCountryList = new List<Country>();

				oUserDAO = new UserDAO(localConnection);
				DataTable _dtCountries = oUserDAO.loadCountryList();

				foreach (DataRow _dRow in _dtCountries.Rows)
				{
					Country _newCountry = new Country();
					_newCountry.CountryName = _dRow["countryName"].ToString();
					_newCountry.Nationality = _dRow["nationality"].ToString();

					_oCountryList.Add(_newCountry);
				}

				GlobalVariables.gCountryList = _oCountryList;
			}

			private string getConfigValue(string configKey)
			{
				foreach (DataRow dRow in dtConfig.Rows)
				{
					if (dRow["Key"].ToString() == configKey)
					{
						return dRow["Value"].ToString();
					}
				}
				return "";
			}

			public IList<User> getUsersList()
			{
				IList<User> _oUserList = new List<User>();
				DataTable _dtTemp = this.GetUsers().Tables[0];

				foreach (DataRow _dRow in _dtTemp.Rows)
				{
					User _newUser = new User();
					_newUser.UserId = _dRow["UserId"].ToString();
					_newUser.Password = _dRow["Password"].ToString();
					_newUser.EmployeeIdNo = _dRow["EmployeeIdNo"].ToString();
					_newUser.LastName = _dRow["LastName"].ToString();
					_newUser.FirstName = _dRow["FirstName"].ToString();
					_newUser.Department = _dRow["Department"].ToString();

					_oUserList.Add(_newUser);
				}

				return _oUserList;
			}

            public DataTable getUsersTable()
            {
                oUserDAO = new UserDAO(localConnection);
                return oUserDAO.getUsersTable();
            }

			public bool isAllowedToViewUI(Form pForm, User oUser)
			{

				string _formName = pForm.Name;
				string _moduleName = pForm.GetType().Assembly.GetName(true).Name;
                
				foreach (Role _oRole in oUser.Roles)
				{
					foreach (RoleUIPrivilege _RoleUIPrivilege in _oRole.RoleUIPrivileges)
					{
						if (_formName.ToUpper() == _RoleUIPrivilege.FormName &&
							 _moduleName.ToUpper() == _RoleUIPrivilege.Module &&
							_RoleUIPrivilege.ButtonName == "")
						{
							if (_RoleUIPrivilege.IsVisible == 1)
							{
								// show UI Buttons
								showUIButtons(pForm, _moduleName, _formName, _oRole);

								return true;
							}
						}
					}
				}


				return false;
			}

			private void showUIButtons(Form pForm, string pModuleName,string pFormName, Role pRole)
			{
				foreach (RoleUIPrivilege _roleUIPrivilege in pRole.RoleUIPrivileges)
				{
					if (_roleUIPrivilege.ButtonName != "")
					{
						if (_roleUIPrivilege.IsVisible == 0)
						{
							if (_roleUIPrivilege.FormName == pFormName.ToUpper() &&
								_roleUIPrivilege.Module == pModuleName.ToUpper())
							{
								hideButton((Control)pForm, _roleUIPrivilege.ButtonName);
							}
						}
					}
				}

			}

			private void hideButton(Control pControl, string _controlToHide)
			{
				foreach (Control _myControl in pControl.Controls)
				{
					if (_myControl is Button)
					{
						if (_myControl.Name.ToUpper() == _controlToHide)
						{
							pControl.Controls.Remove(_myControl);
							//MethodInfo method = pControl.GetType().GetMethod("").
							//pControl.Click -= btnClick;
						}
					}
					else if (_myControl is Panel ||
						_myControl is GroupBox ||
						_myControl is TabControl ||
						_myControl is FlowLayoutPanel)
					{
						hideButton(_myControl, _controlToHide);
					}
				}

			}

			public bool resetPassword(string pUserId, string pNewPassword)
			{
				int _rowsAffected = 0;

				oUserDAO = new UserDAO(GlobalVariables.gPersistentConnection);
				_rowsAffected = oUserDAO.resetPassword(pUserId, pNewPassword);

				if (_rowsAffected > 0)
				{
					return true;
				}
				else
				{
					return false;
				}

			}

            public bool assignUserInfo(ref User pUser)
            {
                oUserDAO = new UserDAO(GlobalVariables.gPersistentConnection);
                return oUserDAO.assignUserInfo(ref pUser);
            }
		}
	}
}
