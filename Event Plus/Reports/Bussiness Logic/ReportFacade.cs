using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.IO;

using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.Reports.DataAccessLayer;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Cashier;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Housekeeping_and_Engineering;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.NonGuestTransactions;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reports.Presentation.Housekeeping;
using System.Collections.Generic;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Statistics;
using System.Reflection;


namespace Jinisys.Hotel.Reports.BusinessLayer
{
    public class ReportFacade
    {
        private ReportDAO loReportDAO;
        private DataSet lDatasetReport;
        public ReportFacade()
        {
            loReportDAO = new ReportDAO();
        }


        public DataTable getRangeFolioTransactions(string pFrom, string pTo)
        {
            try
            {
                loReportDAO = new ReportDAO();
                return loReportDAO.getRangeFolioTransactions(pFrom, pTo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportFacade.getRangeFolioTransactions\r\n" + ex.Message);
            }
        }

        // >> For SUBREPORT
        public void setSubReport(ref ReportDocument poCrReportDoc, DataTable poDataSource, bool pShouldBeView)
        {
            ReportDocument subRepDoc;

            Section crSection;
            Sections crSections;
            ReportObject crReportObject;
            ReportObjects crReportObjects;
            SubreportObject crSubReportObject;

            crSections = poCrReportDoc.ReportDefinition.Sections;

            foreach (Section tempLoopVar_crSection in crSections)
            {
                crSection = tempLoopVar_crSection;
                crReportObjects = crSection.ReportObjects;
                foreach (ReportObject tempLoopVar_crReportObject in crReportObjects)
                {
                    crReportObject = tempLoopVar_crReportObject;
                    if (crReportObject.Kind == ReportObjectKind.SubreportObject && crReportObject.Name.ToUpper().Contains(poDataSource.TableName.ToUpper()))
                    {
                        //If you find a subreport, typecast the reportobject to a subreport object
                        crSubReportObject = (SubreportObject)crReportObject;

                        //Open the subreport
                        if (pShouldBeView == true)
                        {
                            subRepDoc = crSubReportObject.OpenSubreport(crSubReportObject.SubreportName);

                            setDatabaseLogOn();
                            foreach (Table _oTables in subRepDoc.Database.Tables)
                            {
                                _oTables.ApplyLogOnInfo(logOnInfo);
                            }

                            try
                            {
                                subRepDoc.SetDataSource(poDataSource);
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        //// >> GROUP BILLING
        //public GroupBill GetGroupBill(ref string folioId)
        //{
        //    try
        //    {
        //        ReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

        //        dtReport = new DataSet();
        //        dtReport = ReportDAO.GetGroupBill(folioId);

        //        GroupBill GroupBill = new GroupBill();
        //        GroupBill.Database.Tables[0].SetDataSource(dtReport.Tables["FolioTransactions"]);

        //        setSubReport(GroupBill, dtReport.Tables["DependentFolios"]);

        //        GroupBill.SetParameterValue(0, folioId);

        //        return GroupBill;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("EXCEPTION: @ GetGroupBill() " + ex.Message);
        //        return null;
        //    }

        //}

        // >> GROUP BILLING
        //jlo 9-17-2010
        /// <summary>
        /// Gets room utilization set
        /// </summary>
        /// <param name="pStartDate">start date of report</param>
        /// <param name="pEndDate">end date of report</param>
        /// <returns>datatable of room utilization</returns>
        public DataTable getRoomUtilization(DateTime pStartDate, DateTime pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getRoomUtilization(pStartDate, pEndDate);
        }

        //jlo 7-30-2010
        public CompanyFolioBillPICC getCompanyBill_PICC(string pFolioId, string pEventName, DateTime pEventDate, string pName, string pRefNo, string pAccountID, string pRemarks, string pComptrollersInfo, bool pWithNoPayments)
        {
            CompanyFolioBillPICC _companyBill = new CompanyFolioBillPICC();
            try
            {
                loReportDAO = new ReportDAO();
                DataTable _dt = new DataTable();
                if (pWithNoPayments)
                {
                    _dt = loReportDAO.getCompanyBill_PICCCharges(pFolioId);
                }
                else
                {
                    _dt = loReportDAO.getCompanyBill_PICC(pFolioId);
                }
                int _countCD = 0, _countPAY = 0;
                //manipulte data here
                foreach (DataRow _dRow in _dt.Rows)
                {
                    //part of package
                    if (_dRow["acctSide"].ToString() == "DEBIT")
                    {
                        //i just used foliotype as dummy container
                        _dRow["foliotype"] = "I. CHARGES";
                        _countCD++;
                    }
                    else //non package part
                    {
                        _dRow["foliotype"] = "II. PAYMENT/S MADE";
                        _countPAY++;
                    }

                    //removed memo manipulation
                    //Clark 08.12.2011
                    //
                    //string[] _subMemo = _dRow["memo"].ToString().Split('/');
                    //if (_subMemo.Length > 1 && _dRow["transactioncode"].ToString() == ConfigVariables.gRoomChargeTransactionCode)
                    //{
                    //    //corrected the room charge memo
                    //    //Clark 08.12.2011
                    //    //_dRow["memo"] = " / " + _subMemo[1] + "\n" + _subMemo[0];
                    //    _dRow["memo"] = _subMemo[0] + " / " + _subMemo[1];
                    //}
                    //else
                    //{
                    //    //removed the new line character before the memo
                    //    //Clark 08.12.2011
                    //    // _dRow["memo"] = "\n" + _dRow["memo"];
                    //    _dRow["memo"] = _dRow["memo"];
                    //}
                }

                if (_countCD == 0)
                {
                    DataRow _row = _dt.NewRow();
                    _row["foliotype"] = "I. CHARGES";
                    _dt.Rows.Add(_row);
                }
                if (_countPAY == 0 && !pWithNoPayments)
                {
                    DataRow _row = _dt.NewRow();
                    _row["foliotype"] = "II. PAYMENT/S MADE";
                    _dt.Rows.Add(_row);
                }

                DataTable _subDtContact = loReportDAO.getContactPersons(pFolioId, GlobalVariables.gHotelId, pAccountID);
                _companyBill.OpenSubreport("ContactPersonSubReport.rpt").SetDataSource(_subDtContact);
                _companyBill.Database.Tables[0].SetDataSource(_dt);
                _companyBill.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                _companyBill.SetParameterValue(0, pEventName);
                _companyBill.SetParameterValue(1, pEventDate);
                _companyBill.SetParameterValue(2, GlobalVariables.gLoggedOnUser);
                _companyBill.SetParameterValue(3, ConfigVariables.gSalesExecutiveManager);
                _companyBill.SetParameterValue(4, pName);
                _companyBill.SetParameterValue(5, pFolioId);
                _companyBill.SetParameterValue(6, ConfigVariables.gReportTin);
                _companyBill.SetParameterValue(7, pRefNo);
                _companyBill.SetParameterValue(8, pRemarks);
                _companyBill.SetParameterValue(9, pWithNoPayments);
                _companyBill.SetParameterValue(10, pComptrollersInfo);

                return _companyBill;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportFacade.getCompanyBill_PICC\r\n" + ex.Message);
            }
        }

        //jlo 9-21-2010
        /// <summary>
        /// Gets the datatable containing event orders for a specific date and room
        /// </summary>
        /// <param name="pFolioID">folio ID</param>
        /// <param name="pRemarks">combination of room and date</param>
        /// <param name="pHotelID">hotel id</param>
        /// <returns>datable of event orders</returns>
        public DataTable getEventOrder(string pFolioID, string pRemarks, int pHotelID)
        {
            return loReportDAO.getEventOrder(pFolioID, pRemarks, GlobalVariables.gHotelId);
        }

        //jlo 9-23-10
        /// <summary>
        /// Gets the DataTable of payments for event order
        /// </summary>
        /// <param name="pFolioID">folio id</param>
        /// <param name="pHotelID">hotel id</param>
        /// <returns>datatable</returns>
        public DataTable getPayments(string pFolioID, int pHotelID)
        {
            return loReportDAO.getPayments(pFolioID, pHotelID);
        }

        //jlo 9-22-10
        /// <summary>
        /// Gets the event officers of a folio
        /// </summary>
        /// <param name="pFolioID">folio id</param>
        /// <param name="pHotelID">hotel id</param>
        /// <returns></returns>
        public DataTable getEventOfficers(string pFolioID, int pHotelID)
        {
            return loReportDAO.getEventOfficer(pFolioID, pHotelID);
        }
        //jlo
        /// <summary>
        /// Generates the registration form designed by PICC
        /// </summary>
        /// <param name="poFolio">folio id</param>
        /// <param name="poEventBookingInfo">booking info object</param>
        /// <returns>groupregistrationform</returns>
        public GroupRegistrationForm_PICC getGroupRegistration(Object poFolio, Object poEventBookingInfo,string[] pList)
        {
            loReportDAO = new ReportDAO();
            string _refNo = poFolio.GetType().GetProperty("ReferenceNo").GetValue(poFolio, null).ToString();
            string _folioID = poFolio.GetType().GetProperty("FolioID").GetValue(poFolio, null).ToString();
            string _source = poFolio.GetType().GetProperty("Source").GetValue(poFolio, null).ToString();
            string _clientType = poFolio.GetType().GetProperty("AccountType").GetValue(poFolio, null).ToString();
            string _status = poFolio.GetType().GetProperty("Status").GetValue(poFolio, null).ToString();
            string _eventName = poFolio.GetType().GetProperty("GroupName").GetValue(poFolio, null).ToString();
            DateTime _fromDate = DateTime.Parse(poFolio.GetType().GetProperty("FromDate").GetValue(poFolio, null).ToString());
            DateTime _toDate = DateTime.Parse(poFolio.GetType().GetProperty("Todate").GetValue(poFolio, null).ToString());
            DateTime _createTime = DateTime.Now;

            // event organizer
            // Clark 08.11.2011
            object _oCompany = poFolio.GetType().GetProperty("Company").GetValue(poFolio, null);
            object _oGuest = poFolio.GetType().GetProperty("Guest").GetValue(poFolio, null);
            string _eventOrganizer;
            if (_oCompany != null)
            {
                _eventOrganizer = _oCompany.GetType().GetProperty("CompanyName").GetValue(_oCompany, null).ToString();
            }
            else
            {
                _eventOrganizer = _oGuest.GetType().GetProperty("AccountName").GetValue(_oGuest, null).ToString();
            }


            try
            {
                _createTime = DateTime.Parse(poFolio.GetType().GetProperty("CreateTime").GetValue(poFolio, null).ToString());
            }
            catch { }

            string _eventDate = "";
            if (_fromDate.Date == _toDate.Date)
            {
                _eventDate = string.Format("{0:MMMM dd, yyyy}", _fromDate);
            }
            else
            {
                _eventDate = string.Format("{0:MMMM dd, yyyy}", _fromDate) + " - " + string.Format("{0:MMMM dd, yyyy}", _toDate);
            }
            int _hotelID = int.Parse(poFolio.GetType().GetProperty("HotelID").GetValue(poFolio, null).ToString());
            string _eventType = poEventBookingInfo.GetType().GetProperty("EventType").GetValue(poEventBookingInfo, null).ToString();
            string _targetMarket = poFolio.GetType().GetProperty("Purpose").GetValue(poFolio, null).ToString();
            string _remarks = poFolio.GetType().GetProperty("Remarks").GetValue(poFolio, null).ToString();
            string _accountID = poFolio.GetType().GetProperty("CompanyID").GetValue(poFolio,null).ToString();
            string _marketingOfficer = poFolio.GetType().GetProperty("Sales_Executive").GetValue(poFolio, null).ToString();
            DataTable _user = loReportDAO.getUser(_marketingOfficer);
            string _marketingOfficerFullName = "";
            if (_user.Rows.Count > 0)
            {
                foreach (DataRow _dRow in _user.Rows)
                {
                    _marketingOfficerFullName = _dRow["FirstName"].ToString() + " " + _dRow["LastName"].ToString();
                }
            }
            else
            {
                _marketingOfficerFullName = _marketingOfficer;
            }
            DataTable _dtEventOfficers = loReportDAO.getEventOfficer(_folioID, _hotelID);
            string _eventOfficers = "";
            if (_dtEventOfficers.Rows.Count > 0)
            {
                foreach (DataRow _dRow in _dtEventOfficers.Rows)
                {
                    _eventOfficers = _eventOfficers + _dRow["firstName"] + " " + _dRow["lastName"] + " ; ";
                }
                _eventOfficers = _eventOfficers.Substring(0, _eventOfficers.Length - 3);
            }

            GroupRegistrationForm_PICC _groupRegistration = new GroupRegistrationForm_PICC();
            try
            {
                DataTable _dt = loReportDAO.getGroupReservationForm(_folioID, _hotelID);
                DataTable _subDtContact = loReportDAO.getContactPersons(_folioID, _hotelID, _accountID);
                int _index =0;
                DataTable _TempContact = new DataTable();
                _TempContact = _subDtContact.Copy();
                _TempContact.Clear();
                bool _Flag = false;
                foreach (DataRow row in _subDtContact.Rows)
                { 
                   
                        foreach (string _str in pList)
                        {
                            if (_Flag == false)
                            {
                                if (row["contactID"].ToString() == _str)
                                {
                                    //_subDtContact.Rows.RemoveAt(_index);
                                    //_subDtContact.Rows.Remove(row);
                                    _TempContact.ImportRow(row);
                                    _Flag = true;
                                }
                            }
                        }
                        _Flag = false;
                        _index++;
                }
                _subDtContact = _TempContact;

                DataTable _subDtReq = loReportDAO.getOtherRequirements(_folioID);
                _groupRegistration.OpenSubreport("ContactPersonSubReport.rpt").SetDataSource(_subDtContact);
                _groupRegistration.OpenSubreport("OtherRequirementsSubReport.rpt").SetDataSource(_subDtReq);
                _groupRegistration.Database.Tables[0].SetDataSource(_dt);
                _groupRegistration.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                _groupRegistration.SetParameterValue(0, _refNo);  //ref no
                _groupRegistration.SetParameterValue(1, _folioID);  //folio id
                _groupRegistration.SetParameterValue(2, _source); //source
                _groupRegistration.SetParameterValue(3, _clientType); //client type
                _groupRegistration.SetParameterValue(4, _status);//status
                _groupRegistration.SetParameterValue(5, _eventName); //event name
                _groupRegistration.SetParameterValue(6, _eventDate); //event date
                _groupRegistration.SetParameterValue(7, _eventType); //event type
                _groupRegistration.SetParameterValue(8, _targetMarket); //targetsegment
                _groupRegistration.SetParameterValue(9, _remarks); // remarks
                _groupRegistration.SetParameterValue(10, _marketingOfficerFullName); //marketing officer
                _groupRegistration.SetParameterValue(11, _eventOfficers); //eventofficers
                _groupRegistration.SetParameterValue(12, string.Format("{0:MMMM dd, yyy}",_createTime));
                _groupRegistration.SetParameterValue(13, _eventOrganizer); //event organizer
                return _groupRegistration;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro @ReportFacade.getGroupRegistration\r\n" + ex.Message);
            }
        }
        //jlo 9-21-2010
        /// <summary>
        /// gets the data for event order sub report
        /// </summary>
        /// <param name="pFolioID">folio id</param>
        /// <param name="pRoomID">room id</param>
        /// <param name="pDate">date</param>
        /// <param name="pHotelID">hotel id</param>
        /// <returns></returns>
        public DataTable getEventOrderSubReport(string pFolioID, string pRoomID,DateTime pDate, int pHotelID)
        {
            return loReportDAO.getEventOrderSubReport(pFolioID, pRoomID, pDate, pHotelID);
        }

        public DataTable getRoomTypes(int pHotelID)
        {
            return loReportDAO.getRoomTypes(pHotelID);
        }

        public DataTable getRoomTypesCalendarEvents(int pHotelID)
        {
            return loReportDAO.getRoomTypesCalendarEvents(pHotelID);
        }

        public DataTable getContactPersons(string pFolioID, int pHotelID, string pAccountID)
        {
            return loReportDAO.getContactPersons(pFolioID, pHotelID, pAccountID);
        }

        public DataTable getSummaryOfCharges(string pFolioID, string pHotelID)
        {
            return loReportDAO.getSummaryOfCharges(pFolioID, pHotelID);
        }

        public CompanyFolioBill getCompanyBill(string pFolioId)
        {
            CompanyFolioBill companyBill = new CompanyFolioBill();

            try
            {
                loReportDAO = new ReportDAO();

                lDatasetReport = new DataSet();
                lDatasetReport = loReportDAO.getCompanyBill(pFolioId);
                lDatasetReport.EnforceConstraints = false;

                DataTable dtTable = new DataTable();
                dtTable = lDatasetReport.Tables["FolioTransactions"];
                if (dtTable.Rows.Count <= 0)
                {
                    DataRow _dataRow;
                    _dataRow = dtTable.NewRow();
                    dtTable.Rows.Add(_dataRow);
                    dtTable.Columns.Add("FolioID");
                }

                //cityLedgerReport.SetDataSource(dtTable);
                companyBill.Database.Tables[0].SetDataSource(dtTable);
                companyBill.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                companyBill.Database.Tables[2].SetDataSource(lDatasetReport.Tables["FolioPackages"]);

                object user = (object)Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser;
                companyBill.SetParameterValue(0, user);

                //setSubReport(companyBill, dtReport.Tables["DependentFolios"]);
                //companyBill.SetParameterValue(0, folioId);

                return companyBill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetGroupBill() " + ex.Message);
                return null;
            }

        }

        // >> CHECK IN
        public ReportDocument getGuestInformation(string pFolioId)
        {
            ReportDocument guestInformationReport;
            string rptDoc = ConfigVariables.gRegistrationForm;

            switch (rptDoc.ToUpper())
            {
                case "BAHURA":
                    guestInformationReport = new RegistrationCard_Bahura();
                    break;
                case "KORESCO_HALF":
                    guestInformationReport = new RegistrationCard_Koresco_Half();
                    break;

                default:
                    guestInformationReport = new PrintGuestInformation();
                    break;
            }


            //PrintGuestInformation PrintGuestInformation = new PrintGuestInformation();
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getGuestInformation(pFolioId);

                //PrintGuestInformation.SetDataSource(dtReport.Tables[0]);

                guestInformationReport.Database.Tables[0].SetDataSource(dtTable);
                guestInformationReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                string strFile = Application.StartupPath + "\\registration.txt";
                StreamReader streamREader = new StreamReader(strFile);
                string _registrationText = streamREader.ReadToEnd();
                streamREader.Close();

                object user = (object)Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser;
                guestInformationReport.SetParameterValue(0, user);
                guestInformationReport.SetParameterValue(1, _registrationText);
                return guestInformationReport;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetGuestInformation() " + ex.Message);
                return null;
            }
        }

        // >> CLOSE SHIFT
        public ReportDocument getCashierTransaction(string pTerminalId, string pCashierId, string pShiftCode)
        {
            try
            {
                loReportDAO = new ReportDAO();


                DataTable dt = loReportDAO.getCashierTransaction(pTerminalId, pCashierId, pShiftCode);

                //CashierCheckOutReport CashierCheckOutReport = new CashierCheckOutReport();
                ReportDocument CashierCheckOutReport = new CashierCheckOutReport();

                CashierCheckOutReport.Database.Tables[0].SetDataSource(dt);
                CashierCheckOutReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                DataTable dtSubReport = loReportDAO.getCashierVoidTransaction(pTerminalId, pCashierId, pShiftCode);
                setSubReport(ref CashierCheckOutReport, dtSubReport, true);


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                CashierCheckOutReport.SetParameterValue(0, date);


                return CashierCheckOutReport;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetCashierTransaction() " + ex.Message);
                return null;
            }
        }

        // >> In House Guests List
        public InHouseGuestsList getInHouseGuests()
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getInHouseGuests();

                InHouseGuestsList inHouseGuests = new InHouseGuestsList();
                //InHouseGuests.SetDataSource(dtReport.Tables[0]);
                inHouseGuests.Database.Tables[0].SetDataSource(dtTable);
                inHouseGuests.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = inHouseGuests;
                setSubReport(ref rpt, loReportDAO.getInHouseGroups(), true);

                DateTime date = DateTime.Parse(GlobalVariables.gAuditDate);
                inHouseGuests.SetParameterValue(0, date);

                return inHouseGuests;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetInHouseGuests() " + ex.Message);
                return null;
            }
        }

        public DataTable getParamInHouseGuests(DateTime pDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getParamInHouseGuests(pDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetInHouseGuests() " + ex.Message);
                return null;
            }
        }

        public DataTable getParamInHouseGroups(DateTime pDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getParamInHouseGroups (pDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getParamInHouseGroups() " + ex.Message);
                return null;
            }
        }

        // >> Guest Ledger Report
        public GuestLedgerReport getGuestLedger(DateTime poReportDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getGuestLedger(poReportDate);

                GuestLedgerReport guestLedgerReport = new GuestLedgerReport();
                //guestLedgerReport.SetDataSource(dtReport.Tables[0]);
                guestLedgerReport.Database.Tables[0].SetDataSource(dtTable);
                guestLedgerReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy hh:mm:ss tt}", poReportDate);
                guestLedgerReport.SetParameterValue(0, date);

                return guestLedgerReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getGuestLedger() " + ex.Message);
                return null;
            }
        }

        public RoomAvailability getRoomAvailability()
        {
            try
            {

                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getRoomAvailability();

                RoomAvailability roomAvailability = new RoomAvailability();
                //RoomAvailability.SetDataSource(dtReport.Tables[0]);
                roomAvailability.Database.Tables[0].SetDataSource(dtTable);
                roomAvailability.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                roomAvailability.SetParameterValue(0, date);


                return roomAvailability;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetRoomAvailability() " + ex.Message);
                return null;
            }
        }

        // >> ROOM TRANSFER
        public RoomTransferReport getRoomTransferReport()
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getGuestTransfer();

                RoomTransferReport roomTransferReport = new RoomTransferReport();
                //RoomTransferReport.SetDataSource(dtReport.Tables[0]);
                roomTransferReport.Database.Tables[0].SetDataSource(dtTable);
                roomTransferReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1));
                roomTransferReport.SetParameterValue(0, date);

                return roomTransferReport;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetRoomTransfer() " + ex.Message);
                return null;
            }
        }

        public IndividualGuestBill getIndividualGuestBill(string pFolioId, string pSubFolio)
        {
            bool _showReportHeader = bool.Parse(ConfigVariables.gShowReportHeaderOnGuestStatement);
            bool _showRemarks = bool.Parse(ConfigVariables.gShowRemarksOnGuestStatement);
            
            loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
            lDatasetReport = new DataSet();
            lDatasetReport = loReportDAO.getFolioTransactions(pFolioId, pSubFolio);

            IndividualGuestBill individualGuestBill = new IndividualGuestBill();

            DataTable dtMain;
            dtMain = lDatasetReport.Tables["Main"];

            //>> remove Remarks [override]
            if (!_showRemarks)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    dtMain.Rows[i]["Remarks"] = "";
                }
                dtMain.AcceptChanges();
            }
            //>>


            individualGuestBill.Database.Tables[0].SetDataSource(dtMain);

            //>>if using Pre-Printed Form, dont show Report Header
            if (_showReportHeader)
            {
                individualGuestBill.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
            }
            else
            {
                individualGuestBill.Database.Tables[1].SetDataSource(new DataTable());
            }
            //>>


            ReportDocument rpt = individualGuestBill;
            setSubReport(ref rpt, lDatasetReport.Tables["SubReport"], true);
            setSubReport(ref rpt, loReportDAO.getJoiners(pFolioId), true);


            object obj = (object)Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser;
            individualGuestBill.SetParameterValue(0, obj);

            return individualGuestBill;

            //individualGuestBill.Database.Tables[0].SetDataSource(lDatasetReport.Tables["Main"]);
            //individualGuestBill.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

            //ReportDocument rpt = individualGuestBill;
            //setSubReport(ref rpt, lDatasetReport.Tables["SubReport"], true);
            //setSubReport(ref rpt, loReportDAO.getJoiners(pFolioId), true);


            //object obj = (object)Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser;
            //individualGuestBill.SetParameterValue(0, obj);

            ////individualGuestBill.Section5.ReportObjects["remarks1"].Dispose();

            //return individualGuestBill;
            ////}
            ////catch (Exception ex)
            ////{
            ////	MessageBox.Show("EXCEPTION: @ GetIndividualGuestBill() " + ex.Message);
            ////	return null;
            ////}
        }

        public IndividualGuestBillWithoutTax getIndividualGuestBillWithoutTax(string pFolioId, string pSubFolio)
        {
            bool _showReportHeader = bool.Parse(ConfigVariables.gShowReportHeaderOnGuestStatement);
            bool _showRemarks = bool.Parse(ConfigVariables.gShowRemarksOnGuestStatement);

            loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
            lDatasetReport = new DataSet();
            lDatasetReport = loReportDAO.getFolioTransactions(pFolioId, pSubFolio);

            IndividualGuestBillWithoutTax individualGuestBill = new IndividualGuestBillWithoutTax();

            DataTable dtMain;
            dtMain = lDatasetReport.Tables["Main"];

            //>> remove Remarks [override]
            if (!_showRemarks)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    dtMain.Rows[i]["Remarks"] = "";
                }
                dtMain.AcceptChanges();
            }
            //>>


            individualGuestBill.Database.Tables[0].SetDataSource(dtMain);

            //>>if using Pre-Printed Form, dont show Report Header
            if (_showReportHeader)
            {
                individualGuestBill.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
            }
            else
            {
                individualGuestBill.Database.Tables[1].SetDataSource(new DataTable());
            }
            //>>


            ReportDocument rpt = individualGuestBill;
            setSubReport(ref rpt, lDatasetReport.Tables["SubReport"], true);
            setSubReport(ref rpt, loReportDAO.getJoiners(pFolioId), true);


            object obj = (object)Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser;
            individualGuestBill.SetParameterValue(0, obj);

            return individualGuestBill;

            //individualGuestBill.Database.Tables[0].SetDataSource(lDatasetReport.Tables["Main"]);
            //individualGuestBill.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

            //ReportDocument rpt = individualGuestBill;
            //setSubReport(ref rpt, lDatasetReport.Tables["SubReport"], true);
            //setSubReport(ref rpt, loReportDAO.getJoiners(pFolioId), true);


            //object obj = (object)Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser;
            //individualGuestBill.SetParameterValue(0, obj);

            ////individualGuestBill.Section5.ReportObjects["remarks1"].Dispose();

            //return individualGuestBill;
            ////}
            ////catch (Exception ex)
            ////{
            ////	MessageBox.Show("EXCEPTION: @ GetIndividualGuestBill() " + ex.Message);
            ////	return null;
            ////}
        }

        public AllIndividualFolio getAllIndividualFolio()
        {
            try
            {

                loReportDAO = new ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getAllFolio();

                AllIndividualFolio individualGuestBill = new AllIndividualFolio();

                individualGuestBill.Database.Tables[0].SetDataSource(dtTable);
                individualGuestBill.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                individualGuestBill.SetParameterValue(0, GlobalVariables.gLoggedOnUser);
                return individualGuestBill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getAllIndividualFolio() " + ex.Message);
                return null;
            }
        }

        // >> Room Status
        public RoomStatusReport getRoomCleaningStatus()
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getRoomCleaningStatus();

                RoomStatusReport roomStatusReport = new RoomStatusReport();
                //RoomStatusReport.SetDataSource(dtReport.Tables[0]);
                roomStatusReport.Database.Tables[0].SetDataSource(dtTable);
                roomStatusReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                roomStatusReport.SetParameterValue(0, date);

                return roomStatusReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetRoomCleaningStatus() " + ex.Message);
                return null;
            }
        }

        // >> Housekeeping Jobs
        public HousekeepingJobReport getHousekeepingJobs(DateTime pReportDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getHousekeepingJobs(pReportDate);

                HousekeepingJobReport housekeepingJobReport = new HousekeepingJobReport();

                housekeepingJobReport.Database.Tables[0].SetDataSource(dtTable);
                housekeepingJobReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                housekeepingJobReport.SetParameterValue(0, date);


                return housekeepingJobReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetHousekeepingJobs() " + ex.Message);
                return null;
            }
        }

        public SalesSummary getSalesSummary(string poTransactionDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getSalesSummary(poTransactionDate);

                // use dataview here to apply sorting since we use UNION in 
                // stored procedure Jerome, May 15, 2008
                DataView dtView = dtTable.DefaultView;
                dtView.Sort = "AcctSide desc";

                SalesSummary salesSummary = new SalesSummary();

                salesSummary.Database.Tables[0].SetDataSource(dtView);
                salesSummary.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(poTransactionDate));
                salesSummary.SetParameterValue(0, date);

                return salesSummary;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetSalesSummay() " + ex.Message);
                return null;
            }
        }

        //>>for Sales Executive Report
        public SalesExecutiveReport getSalesExecutiveReport(string pReportDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getCancelledReservation(pReportDate);

                SalesExecutiveReport salesExecutiveReport = new SalesExecutiveReport();
                salesExecutiveReport.Database.Tables[1].SetDataSource(dtTable);
                salesExecutiveReport.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                try
                {
                    ReportDocument rpt = salesExecutiveReport;

                    object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pReportDate));
                    salesExecutiveReport.SetParameterValue(0, date);
                }
                catch
                {
                    salesExecutiveReport.SetParameterValue(0, "");
                }

                return salesExecutiveReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ cancelledReservation() " + ex.Message);
                return null;
            }
        }

        //>>for Sales Executive reports
        public DataTable getDateRangeSalesExecutive(string pStartDate, string pEndDate, string pSalesExec)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeSalesExecutiveReport(pStartDate, pEndDate, pSalesExec);
        }

        public DataTable getMonthlySalesExecutive(int pMonth, int pYear, string pSalesExec)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlySalesExecutiveReport(pMonth, pYear, pSalesExec);
        }

        public DataTable getAnnualSalesExecutive(int pYear, string pSalesExec)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualSalesExecutiveReport(pYear, pSalesExec);
        }

        //>>for Sales Production Reports
        public DataTable getDateRangeSalesProductionReport(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeSalesProductReport(pStartDate, pEndDate);
        }

        public DataTable getMonthlySalesProductionReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlySalesProductionReport(pMonth, pYear);
        }

        public DataTable getAnnualSalesProductionReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualSalesProductionReport(pYear);
        }

        //>>for Drivers Commission Reports
        public DataTable getDateRangeDriversCommissionsReport(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeDriversCommissionReport(pStartDate, pEndDate);
        }

        public DataTable getMonthlyDriversCommissionReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyDriversCommissionReport(pMonth, pYear);
        }

        public DataTable getAnnualDriversCommissionReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualDriversCommissionReport(pYear);
        }

        public TransactionRegisterReport getTransactionRegisterReport()
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getTransactionRegisterReport();

                TransactionRegisterReport transRegister = new TransactionRegisterReport();
                //transRegister.SetDataSource(dtReport.Tables["TransactionRegister"]);
                transRegister.Database.Tables[0].SetDataSource(dtTable);
                transRegister.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                transRegister.SetParameterValue(0, date);

                return transRegister;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getTransactionRegisterReport() " + ex.Message);
                return null;
            }
        }

        public AccountingAdjustmentsReport getAdjustmentTransactionsReport()
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getAdjustmentTransactionsReport();

                AccountingAdjustmentsReport _oAdjustment = new AccountingAdjustmentsReport();
                _oAdjustment.Database.Tables[0].SetDataSource(dtTable);
                _oAdjustment.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                _oAdjustment.SetParameterValue(0, date);

                return _oAdjustment;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getAdjustmentTransactionsReport() " + ex.Message);
                return null;
            }
        }

        // no of pax
        public DataTable getNoOfPax(string pDate, string pFilter)
        {
            try
            {
                loReportDAO = new ReportDAO();
                return loReportDAO.getNoOfPax(pDate, pFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getNoOfPax() " + ex.Message);
                return null;
            }
        }

        public CityTransferTransactions getCityTransferTransactions()
        {
            try
            {
                DataTable dtTable = new DataTable();
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                dtTable = loReportDAO.getCityTransferTransactions();

                CityTransferTransactions cityTransferTransactions = new CityTransferTransactions();
                //cityTransferTransactions.SetDataSource(dtTable);
                cityTransferTransactions.Database.Tables[0].SetDataSource(dtTable);
                cityTransferTransactions.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd, MMM. dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                cityTransferTransactions.SetParameterValue(0, date);


                return cityTransferTransactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getCityLedger() " + ex.Message);
                return null;
            }
        }

        public DataTable getInhouseGuestsForecast(string pReportDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getInhouseGuestsForecast(pReportDate);
        }

        public CashierCheckOutReport getAllCashierTransactions(string pAuditDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                DataTable dt = loReportDAO.getAllCashierTransactions(pAuditDate);

                CashierCheckOutReport cashierCheckOutReport = new CashierCheckOutReport();
                //CashierCheckOutReport.SetDataSource(dt);
                cashierCheckOutReport.Database.Tables[0].SetDataSource(dt);
                cashierCheckOutReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pAuditDate));
                object user = (object)Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser;

                cashierCheckOutReport.SetParameterValue(0, date);
                cashierCheckOutReport.SetParameterValue(1, user);


                return cashierCheckOutReport;


            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetCashierTransaction() " + ex.Message);
                return null;
            }
        }

        public ReportDocument getAllCashierShiftTransaction(string pAuditDate, string pReportType)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                DataTable dt = loReportDAO.getAllCashierShiftTransaction(pAuditDate, pReportType);

                ReportDocument allCashierTransactions = new AllCashierShiftReport();
                //allCashierTransactions.SetDataSource(dt);
                allCashierTransactions.Database.Tables[0].SetDataSource(dt);
                allCashierTransactions.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                //DataTable dtSubReport = loReportDAO.getAllCashierShiftVoidTransaction(pAuditDate, pReportType);
                //setSubReport(ref allCashierTransactions, dtSubReport, true);

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pAuditDate));
                allCashierTransactions.SetParameterValue(0, date);

                return allCashierTransactions;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetCashierTransaction() " + ex.Message);
                return null;
            }
        }

        public OccupancyForecastReport getOccupancyForecast(DataTable poDataTableReport, string pDate)
        {
            try
            {
                OccupancyForecastReport occupancyForecast = new OccupancyForecastReport();
                //allCashierTransactions.SetDataSource(dt);
                occupancyForecast.Database.Tables[0].SetDataSource(poDataTableReport);
                occupancyForecast.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                occupancyForecast.SetParameterValue(0, pDate);

                return occupancyForecast;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getOccupancyForecast() " + ex.Message);
                return null;
            }
        }

        #region "CITY LEDGER"
        public CityLedgerReport getCityLedger()
        {
            try
            {
                DataTable dtTable = new DataTable();
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                dtTable = loReportDAO.getCityLedger();

                CityLedgerReport cityLedgerReport = new CityLedgerReport();
                //cityLedgerReport.SetDataSource(dtTable);
                cityLedgerReport.Database.Tables[0].SetDataSource(dtTable);
                cityLedgerReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd, MMM. dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                cityLedgerReport.SetParameterValue(0, date);


                return cityLedgerReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getCityLedger() " + ex.Message);
                return null;
            }
        }

        public CityLedgerReport getCityLedgerDate(string pDate)
        {
            try
            {
                DataTable dtTable = new DataTable(pDate);
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                dtTable = loReportDAO.getCityLedgerDate(pDate);

                CityLedgerReport cityLedgerReport = new CityLedgerReport();
                //cityLedgerReport.SetDataSource(dtTable);
                cityLedgerReport.Database.Tables[0].SetDataSource(dtTable);
                cityLedgerReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd, MMM. dd, yyyy}", DateTime.Parse(pDate));
                cityLedgerReport.SetParameterValue(0, date);


                return cityLedgerReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getCityLedgerDate() " + ex.Message);
                return null;
            }
        }


        #endregion

        #region "TRANSACTION REGISTER"

        public DataTable getParamTransactionRegisterReport(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getParamTransactionRegisterReport(pStartDate, pEndDate);
        }

        public DataTable getMonthlyTransactionRegisterReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyTransactionRegisterReport(pMonth, pYear);
        }

        public DataTable getAnnualTransactionRegisterReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualTransactionRegisterReport(pYear);
        }

        public TransactionRegisterReport getTransactionRegisterReportDate(string pDate)
        {
            try
            {
                DataTable dtTable = new DataTable();
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                dtTable = loReportDAO.getParamTransactionRegisterReport(pDate, pDate);

                DataView _dtView = dtTable.DefaultView;
                _dtView.Sort = "ReferenceType asc";

                TransactionRegisterReport trans = new TransactionRegisterReport();
                //trans.SetDataSource(dtTable);
                trans.Database.Tables[0].SetDataSource(_dtView);
                trans.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd, MMM. dd, yyyy}", DateTime.Parse(pDate));
                trans.SetParameterValue(0, date);


                return trans;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getTransactionRegisterReportDate() " + ex.Message);
                return null;
            }
        }

        #endregion

        #region "DAILY TRANSACTIONS REPORT"

        public DailyTransactionsReport getDailyTransactions()
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getDailyTransactions();

                DailyTransactionsReport dailyTransactionsReport = new DailyTransactionsReport();
                //DailyTransactionsReport.SetDataSource(dtReport.Tables[0]);
                dailyTransactionsReport.Database.Tables[0].SetDataSource(dtTable);
                dailyTransactionsReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                dailyTransactionsReport.SetParameterValue(0, date);

                return dailyTransactionsReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetDailyTransactions() " + ex.Message);
                return null;
            }
        }

        public DailyTransactionsReport getDailyTransactionsDate(string pDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getDailyTransactionsDate(pDate);

                DailyTransactionsReport dailyTransactionsReport = new DailyTransactionsReport();
                //DailyTransactionsReport.SetDataSource(dtReport.Tables[0]);
                dailyTransactionsReport.Database.Tables[0].SetDataSource(dtTable);
                dailyTransactionsReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pDate));
                dailyTransactionsReport.SetParameterValue(0, date);

                return dailyTransactionsReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetDailyTransactions() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyTransactionsReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyTransactionsReport(pMonth, pYear);
        }

        public DataTable getAnnualTransactions(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualTransactions(pYear);
        }

        public DataTable getTransactionsDateRange(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getTransactionsDateRange(pStartDate, pEndDate);
        }


        #endregion

        #region "SALES SUMMARY"

        public DataTable getMonthlySalesSummary(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlySalesSummary(pMonth, pYear);
        }

        public DataTable getMonthlySalesRevenue(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlySalesRevenue(pMonth, pYear);
        }

        public DataTable getAnnualSalesSummary(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualSalesSummary(pYear);
        }

        public DataTable getDateRangeSalesSummary(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeSalesSummary(pStartDate, pEndDate);
        }


        public SalesReport getSalesReport()
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getSalesReport(DateTime.Parse(GlobalVariables.gAuditDate));

                SalesReport salesReport = new SalesReport();
                salesReport.Database.Tables[0].SetDataSource(dtTable);
                salesReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                salesReport.SetParameterValue(0, date);

                return salesReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetSalesReport() " + ex.Message);
                return null;
            }
        }

        public SalesReport getDailySalesReport(string pDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getDailySalesReport(pDate);

                SalesReport salesReport = new SalesReport();
                salesReport.Database.Tables[0].SetDataSource(dtTable);
                salesReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", pDate);
                salesReport.SetParameterValue(0, date);

                return salesReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetSalesReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlySalesReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlySalesReport(pMonth, pYear);
        }

        public DataTable getAnnualSalesReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualSalesReport(pYear);
        }

        public DataTable getDateRangeSalesReport(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeSalesReport(pStartDate, pEndDate);
        }


        #endregion

        #region "CITY TRANSFER"

        public DataTable getParamCityTransferTransactions(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getParamCityTransferTransactions(pStartDate, pEndDate);
        }

        public DataTable getMonthlyCityTransferTransactions(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyCityTransferTransactions(pMonth, pYear);
        }

        public DataTable getAnnualCityTransferTransactions(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualCityTransferTransactions(pYear);
        }

        #endregion

        #region "CASHIER SHIFT REPORTS"

        public DataTable getMonthlyCashierShiftReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyCashierShiftReport(pMonth, pYear);
        }

        public DataTable getAnnualCashierShiftReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualCashierShiftReport(pYear);
        }

        public DataTable getDateRangeCashierShiftReport(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeCashierShiftReport(pStartDate, pEndDate);
        }


        #endregion

        #region "ACTUAL GUEST ARRIVAL"

        public ActualGuestArrival getActualArrivalReport(string pReportDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getActualGuestsArrival(pReportDate);

                ActualGuestArrival actualGuestArrival = new ActualGuestArrival();
                setDatabaseLogOn();
                foreach (Table _oTables in actualGuestArrival.Database.Tables)
                {
                    _oTables.ApplyLogOnInfo(logOnInfo);
                }

                actualGuestArrival.Database.Tables[0].SetDataSource(dtTable);
                actualGuestArrival.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = actualGuestArrival;
                setSubReport(ref rpt, loReportDAO.getActualGroupArrival(pReportDate), true);

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pReportDate));
                actualGuestArrival.SetParameterValue(0, date);
                return actualGuestArrival;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualArrivalReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyActualArrivalReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyActualGuestsArrival(pMonth, pYear);
        }

        public DataTable getAnnualActualArrivalReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualActualGuestsArrival(pYear);
        }

        public DataTable getDateRangeActualArrivalReport(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeActualGuestsArrival(pStartDate, pEndDate);
        }

        #endregion

        #region "ACTUAL GUEST DEPARTURE"

        public ActualGuestDeparture getActualDepartureReport(string pReportDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getActualGuestsDeparture(pReportDate);

                ActualGuestDeparture actualGuestDeparture = new ActualGuestDeparture();

                setDatabaseLogOn();
                foreach (Table _oTables in actualGuestDeparture.Database.Tables)
                {
                    _oTables.ApplyLogOnInfo(logOnInfo);
                }

                DataTable dtImages = new DataTable("Images");
                dtImages = CrystalReportAddons.reportHeader();

                actualGuestDeparture.Database.Tables[0].SetDataSource(dtTable);
                actualGuestDeparture.Database.Tables[1].SetDataSource(dtImages);

                ReportDocument rpt = actualGuestDeparture;
                setSubReport(ref rpt, loReportDAO.getActualGroupDeparture(pReportDate), true);

                //ReportDocument rpt = actualGuestDeparture;
                //setSubReport(ref rpt, loReportDAO.getGroupGuestsDeparture(pReportDate), true);
                
                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pReportDate));
                actualGuestDeparture.SetParameterValue(0, date);


                return actualGuestDeparture;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualDepartureReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyActualDepartureReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyActualGuestsDeparture(pMonth, pYear);
        }

        public DataTable getAnnualActualDepartureReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualActualGuestsDeparture(pYear);
        }

        public DataTable getDateRangeActualDepartureReport(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeActualGuestsDeparture(pStartDate, pEndDate);
        }


        #endregion

        #region "EXPECTED GUEST ARRIVAL"

        public ExpectedArrivalReport getExpectedArrivalReport(string pReportDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getExpectedGuestsArrival(pReportDate);

                ExpectedArrivalReport guestArrivalReport = new ExpectedArrivalReport();
                //GuestArrivalReport.SetDataSource(dtReport.Tables[0]);
                guestArrivalReport.Database.Tables[0].SetDataSource(dtTable);
                guestArrivalReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = guestArrivalReport;
                setSubReport(ref rpt, loReportDAO.getGroupGuestsArrival(pReportDate), true);

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pReportDate));
                guestArrivalReport.SetParameterValue(0, date);

                return guestArrivalReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public ExpectedArrivalReport getMonthlyExpectedArrivalReport(int pMonth, int pYear)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getMonthlyExpectedGuestsArrival(pMonth, pYear);

                ExpectedArrivalReport guestArrivalReport = new ExpectedArrivalReport();
                //GuestArrivalReport.SetDataSource(dtReport.Tables[0]);
                guestArrivalReport.Database.Tables[0].SetDataSource(dtTable);
                guestArrivalReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = guestArrivalReport;
                setSubReport(ref rpt, loReportDAO.getMonthlyGroupGuestsArrival(pMonth, pYear), true);

                string reportParam = "for the Month of  " + System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(pMonth) + "   " + pYear.ToString();
                guestArrivalReport.SetParameterValue(0, reportParam);

                return guestArrivalReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public ExpectedArrivalReport getAnnualExpectedGuestArrivalReport(int pYear)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getAnnualExpectedGuestsArrival(pYear);

                ExpectedArrivalReport guestArrivalReport = new ExpectedArrivalReport();
                //GuestArrivalReport.SetDataSource(dtReport.Tables[0]);
                guestArrivalReport.Database.Tables[0].SetDataSource(dtTable);
                guestArrivalReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = guestArrivalReport;
                setSubReport(ref rpt, loReportDAO.getAnnualGroupGuestsArrival(pYear), true);

                string reportParam = "for the Year of  " + pYear.ToString();
                guestArrivalReport.SetParameterValue(0, reportParam);

                return guestArrivalReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public ExpectedArrivalReport getDateRangeExpectedGuestArrivalReport(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getDateRangeExpectedGuestsArrival(pStartDate, pEndDate);

                ExpectedArrivalReport guestArrivalReport = new ExpectedArrivalReport();
                //GuestArrivalReport.SetDataSource(dtReport.Tables[0]);
                guestArrivalReport.Database.Tables[0].SetDataSource(dtTable);
                guestArrivalReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = guestArrivalReport;
                setSubReport(ref rpt, loReportDAO.getDateRangeGroupGuestsArrival(pStartDate, pEndDate), true);

                string reportParam = "From " + DateTime.Parse(pStartDate).ToString("dd-MMM-yy") + "  to  " + DateTime.Parse(pEndDate).ToString("dd-MMM-yy");
                guestArrivalReport.SetParameterValue(0, reportParam);

                return guestArrivalReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsArrival() " + ex.Message);
                return null;
            }
        }

        //public DataTable getMonthlyExpectedGuestArrivalReport(int pMonth, int pYear)
        //{
        //    loReportDAO = new ReportDAO();
        //    return loReportDAO.getMonthlyExpectedGuestsArrival(pMonth, pYear);
        //}

        //public DataTable getAnnualExpectedGuestArrivalReport(int pYear)
        //{
        //    loReportDAO = new ReportDAO();
        //    return loReportDAO.getAnnualExpectedGuestsArrival(pYear);
        //}

        //public DataTable getDateRangeExpectedGuestArrivalReport(string pStartDate, string pEndDate)
        //{
        //    loReportDAO = new ReportDAO();
        //    return loReportDAO.getDateRangeExpectedGuestsArrival(pStartDate, pEndDate);
        //}

        #endregion

        #region "EXPECTED GUEST DEPARTURE"

        // >> Exptected Guests Departure
        public ExpectedDepartureReport getExpectedDepartureReport(string pReportDate)
        {
            try
            {

                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getExpectedGuestsDeparture(pReportDate);

                ExpectedDepartureReport expectDepartureReport = new ExpectedDepartureReport();
                expectDepartureReport.Database.Tables[0].SetDataSource(dtTable);
                expectDepartureReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = expectDepartureReport;
                setSubReport(ref rpt, loReportDAO.getGroupGuestsDeparture(pReportDate), true);

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pReportDate));
                expectDepartureReport.SetParameterValue(0, date);

                return expectDepartureReport;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsDeparture() " + ex.Message);
                return null;
            }

        }

        public ExpectedDepartureReport getMonthlyExpectedGuestDepartureReport(int pMonth, int pYear)
        {
            try
            {

                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getMonthlyExpectedGuestsDeparture(pMonth, pYear);

                ExpectedDepartureReport expectDepartureReport = new ExpectedDepartureReport();
                expectDepartureReport.Database.Tables[0].SetDataSource(dtTable);
                expectDepartureReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = expectDepartureReport;
                setSubReport(ref rpt, loReportDAO.getMonthlyGroupGuestsDeparture(pMonth, pYear), true);

                string reportParam = "for the Month of  " + System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(pMonth) + "   " + pYear.ToString();
                expectDepartureReport.SetParameterValue(0, reportParam);

                return expectDepartureReport;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsDeparture() " + ex.Message);
                return null;
            }

        }

        public ExpectedArrivalReport getAnnualExpectedGuestDepartureReport(int pYear)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getAnnualExpectedGuestsDeparture(pYear);

                ExpectedArrivalReport guestArrivalReport = new ExpectedArrivalReport();
                //GuestArrivalReport.SetDataSource(dtReport.Tables[0]);
                guestArrivalReport.Database.Tables[0].SetDataSource(dtTable);
                guestArrivalReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = guestArrivalReport;
                setSubReport(ref rpt, loReportDAO.getAnnualGroupGuestsDeparture(pYear), true);

                string reportParam = "for the Year of  " + pYear.ToString();
                guestArrivalReport.SetParameterValue(0, reportParam);

                return guestArrivalReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public ExpectedArrivalReport getDateRangeExpectedGuestDepartureReport(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getDateRangeExpectedGuestsDeparture(pStartDate, pEndDate);

                ExpectedArrivalReport guestArrivalReport = new ExpectedArrivalReport();
                //GuestArrivalReport.SetDataSource(dtReport.Tables[0]);
                guestArrivalReport.Database.Tables[0].SetDataSource(dtTable);
                guestArrivalReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                ReportDocument rpt = guestArrivalReport;
                setSubReport(ref rpt, loReportDAO.getDateRangeGroupGuestsDeparture(pStartDate, pEndDate), true);

                string reportParam = "From " + DateTime.Parse(pStartDate).ToString("dd-MMM-yy") + "  to  " + DateTime.Parse(pEndDate).ToString("dd-MMM-yy");
                guestArrivalReport.SetParameterValue(0, reportParam);

                return guestArrivalReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetExpectedGuestsArrival() " + ex.Message);
                return null;
            }
        }

        //public DataTable getMonthlyExpectedGuestDepartureReport(int pMonth, int pYear)
        //{
        //    loReportDAO = new ReportDAO();
        //    return loReportDAO.getMonthlyExpectedGuestsDeparture(pMonth, pYear);
        //}

        //public DataTable getAnnualExpectedGuestDepartureReport(int pYear)
        //{
        //    loReportDAO = new ReportDAO();
        //    return loReportDAO.getAnnualExpectedGuestsDeparture(pYear);
        //}

        //public DataTable getDateRangeExpectedGuestDepartureReport(string pStartDate, string pEndDate)
        //{
        //    loReportDAO = new ReportDAO();
        //    return loReportDAO.getDateRangeExpectedGuestsDeparture(pStartDate, pEndDate);
        //}

        #endregion

        #region "CANCELLED RESERVATIONS"

        public DataTable getCancelledGroups(string pReportDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getCancelledGroups(pReportDate);
        }

        public CancelledReservationReport getCancelledReservation(string pReportDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getCancelledReservation(pReportDate);

                CancelledReservationReport cancelledReservation = new CancelledReservationReport();
                cancelledReservation.Database.Tables[0].SetDataSource(dtTable);
                cancelledReservation.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                try
                {
                    ReportDocument rpt = cancelledReservation;
                    setSubReport(ref rpt, loReportDAO.getCancelledGroups(pReportDate), true);
                    
                    object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pReportDate));
                    cancelledReservation.SetParameterValue(0, date);
                }
                catch
                {
                    cancelledReservation.SetParameterValue(0, "");
                }

                return cancelledReservation;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ cancelledReservation() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyCancelledReservations(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyCancelledReservations(pMonth, pYear);
        }

        public DataTable getAnnualCancelledReservations(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualCancelledReservations(pYear);
        }

        public DataTable getDateRangeCancelledReservations(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeCancelledReservations(pStartDate, pEndDate);
        }


        #endregion

        #region "VOIDED TRANSACTIONS"


        // void transactions
        public VoidedTransactionsReport getVoidedTransactionsReport(string pReportDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dt = new DataTable();

                dt = loReportDAO.getVoidedTransactionsReport(pReportDate);
                VoidedTransactionsReport transRegister = new VoidedTransactionsReport();
                //transRegister.SetDataSource(dt);
                transRegister.Database.Tables[0].SetDataSource(dt);
                transRegister.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());


                object date = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pReportDate));
                transRegister.SetParameterValue(0, date);

                return transRegister;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getVoidedTransactionsReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyVoidTransactionsReport(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyVoidTransactions(pMonth, pYear);
        }

        public DataTable getAnnualVoidTransactionsReport(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualVoidTransactions(pYear);
        }

        public DataTable getDateRangeVoidTransactions(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeVoidTransactions(pStartDate, pEndDate);
        }

        #endregion

        #region "ROOM OCCUPANCY"

        public RoomOccupancyReport getRoomOccupancy(DateTime pReportDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getRoomOccupancy(pReportDate);

                RoomOccupancyReport roomOccupancyReport = new RoomOccupancyReport();
                roomOccupancyReport.Database.Tables[0].SetDataSource(dtTable);
                roomOccupancyReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", pReportDate);
                roomOccupancyReport.SetParameterValue(0, date);

                return roomOccupancyReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ roomOccupancyReport() " + ex.Message);
                return null;
            }
        }


        public DataTable getRoomOccupancyGraph(string pDate)
        {
            try
            {
                loReportDAO = new ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getRoomOccupancyGraph(pDate);

                //RoomOccupancyGraph roomOccupancyGraph = new RoomOccupancyGraph();
                //roomOccupancyGraph.Database.Tables[1].SetDataSource(dtTable);
                //roomOccupancyGraph.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());


                //object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", a_Date);
                //roomOccupancyGraph.SetParameterValue(0, date);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getRoomOccupancyGraph() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyRoomOccupancyGraph(int pMonth, int pYear)
        {
            try
            {
                loReportDAO = new ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getMonthlyRoomOccupancyGraph(pMonth, pYear);

                //RoomOccupancyGraph roomOccupancyGraph = new RoomOccupancyGraph();
                //roomOccupancyGraph.Database.Tables[1].SetDataSource(dtTable);
                //roomOccupancyGraph.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());


                //object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", a_Date);
                //roomOccupancyGraph.SetParameterValue(0, date);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getRoomOccupancyGraph() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualRoomOccupancyGraph(int pYear)
        {
            try
            {
                loReportDAO = new ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getAnnualRoomOccupancyGraph(pYear);

                //RoomOccupancyGraph roomOccupancyGraph = new RoomOccupancyGraph();
                //roomOccupancyGraph.Database.Tables[1].SetDataSource(dtTable);
                //roomOccupancyGraph.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                //object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", a_Date);
                //roomOccupancyGraph.SetParameterValue(0, date);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getRoomOccupancyGraph() " + ex.Message);
                return null;
            }
        }

        public DataTable getDateRangeRoomOccupancyGraph(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getDateRangeRoomOccupancyGraph(pStartDate, pEndDate);

                //RoomOccupancyGraph roomOccupancyGraph = new RoomOccupancyGraph();
                //roomOccupancyGraph.Database.Tables[1].SetDataSource(dtTable);
                //roomOccupancyGraph.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                //object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", a_Date);
                //roomOccupancyGraph.SetParameterValue(0, date);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getRoomOccupancyGraph() " + ex.Message);
                return null;
            }
        }

        #endregion

        #region "ENGINEERING JOB REPORTS"

        public OutOfOrderRooms getOutOfOrderRooms(string pDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getOutOfOrderRooms(pDate);

                OutOfOrderRooms outOfOrderRooms = new OutOfOrderRooms();
                outOfOrderRooms.Database.Tables[0].SetDataSource(dtTable);
                outOfOrderRooms.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pDate));
                outOfOrderRooms.SetParameterValue(0, date);

                return outOfOrderRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetOutOfOrderRooms() " + ex.Message);
                return null;
            }

        }

        public DataTable getMonthlyOutOfOrderRooms(int pMonth, int pYear)
        {
            try
            {
                loReportDAO = new ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getMonthlyOutOfOrderRooms(pMonth, pYear);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getMonthlyOutOfOrderRooms() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualOutOfOrderRooms(int pYear)
        {
            try
            {
                loReportDAO = new ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getAnnualOutOfOrderRooms(pYear);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getAnnualOutOfOrderRooms() " + ex.Message);
                return null;
            }
        }

        public DataTable getDateRangeOutOfOrderRooms(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new ReportDAO();

                DataTable dtTable = new DataTable();
                dtTable = loReportDAO.getDateRangeOutOfOrderRooms(pStartDate, pEndDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getDateRangeOutOfOrderRooms() " + ex.Message);
                return null;
            }
        }


        #endregion


        #region " CHANGES LOGS "


        public DataTable getChangesLog(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getChangesLog(pStartDate, pEndDate);
        }

        public DataTable searchChangesLog(string pSearchText, string pSearchCriteria)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.searchChangesLog(pSearchText, pSearchCriteria);
        }

        #endregion


        public DataTable getExpectedArrivalForOccupancyForecast(string pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getExpectedArrivalForOccupancyForecast(pDate);
        }

        public DataTable getExpectedDepartureForOccupancyForecast(string pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getExpectedDepartureForOccupancyForecast(pDate);
        }

        public DataTable getExpectedInHouseForOccupancyForecast(string pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getExpectedInHouseForOccupancyForecast(pDate);
        }

        public int getRoomCount()
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getRoomCount();
        }


        #region "NonGuestTransactions"

        public NonGuestChargesReport getDateRangeNonGuestChargesTransactions(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                DataTable dt = loReportDAO.getDateRangeNonGuestChargesTransactions(pStartDate, pEndDate);

                NonGuestChargesReport nonGuestChargesTransactions = new NonGuestChargesReport();
                nonGuestChargesTransactions.Database.Tables[0].SetDataSource(dt);
                nonGuestChargesTransactions.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                string startDate = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pStartDate));
                string endDate = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pEndDate));

                object paramDate = "for the period " + startDate + "  to  " + endDate;

                nonGuestChargesTransactions.SetParameterValue(0, paramDate);

                return nonGuestChargesTransactions;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetCashierTransaction() " + ex.Message);
                return null;
            }
        }

        public NonGuestPaymentsReport getDateRangeNonGuestPaymentsTransactions(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                DataTable dt = loReportDAO.getDateRangeNonGuestPaymentsTransactions(pStartDate, pEndDate);

                NonGuestPaymentsReport nonGuestPaymentsTransactions = new NonGuestPaymentsReport();
                nonGuestPaymentsTransactions.Database.Tables[0].SetDataSource(dt);
                nonGuestPaymentsTransactions.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                string startDate = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pStartDate));
                string endDate = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pEndDate));

                object paramDate = "for the period " + startDate + "  to  " + endDate;

                nonGuestPaymentsTransactions.SetParameterValue(0, paramDate);

                return nonGuestPaymentsTransactions;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetCashierTransaction() " + ex.Message);
                return null;
            }
        }

        public NonGuestPaidOutReport getDateRangeNonGuestPaidOutTransactions(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();

                DataTable dt = loReportDAO.getDateRangeNonGuestPaidOutTransactions(pStartDate, pEndDate);

                NonGuestPaidOutReport nonGuestPaidOutTransactions = new NonGuestPaidOutReport();
                nonGuestPaidOutTransactions.Database.Tables[0].SetDataSource(dt);
                nonGuestPaidOutTransactions.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                string startDate = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pStartDate));
                string endDate = string.Format("{0:ddd. MMMM dd, yyyy}", DateTime.Parse(pEndDate));

                object paramDate = "for the period " + startDate + "  to  " + endDate;

                nonGuestPaidOutTransactions.SetParameterValue(0, paramDate);

                return nonGuestPaidOutTransactions;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetCashierTransaction() " + ex.Message);
                return null;
            }
        }


        #endregion

        #region EVENT MANAGEMENT
        //>>by Genny

        TableLogOnInfo logOnInfo;
        private void setDatabaseLogOn()
        {
            logOnInfo = new TableLogOnInfo();
            //TableLogOnInfo logOnInfo = new TableLogOnInfo();
            string con = ConfigurationManager.AppSettings.Get("connection");
            string[] split ={ ";", "=" };
            string[] strCon = con.Split(split, StringSplitOptions.RemoveEmptyEntries);

            logOnInfo.ConnectionInfo.ServerName = strCon[1];
            logOnInfo.ConnectionInfo.UserID = strCon[3];
            logOnInfo.ConnectionInfo.Password = strCon[5];
            logOnInfo.ConnectionInfo.DatabaseName = strCon[7];
            logOnInfo.ConnectionInfo.Type = ConnectionInfoType.CRQE;

            //logOnInfos.Add(logOnInfo);
        }

        //>>Banquet Event Contract
        public BanquetEventContract getBanquetEventContract(string pFolioID)
        {
            loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
            lDatasetReport = new DataSet();
            lDatasetReport = loReportDAO.getBanquetEventContract(pFolioID);

            BanquetEventContract eventContract = new BanquetEventContract();
            setDatabaseLogOn();
            foreach (Table _oTables in eventContract.Database.Tables)
            {
                _oTables.ApplyLogOnInfo(logOnInfo);
            }

            eventContract.Database.Tables[1].SetDataSource(lDatasetReport.Tables["Main"]);
            eventContract.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

            ReportDocument rpt = eventContract;
            setSubReport(ref rpt, loReportDAO.getWeddingDetailsSheet(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getBanquetDetails(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getBanquetMeals(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getBanquetRooms(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getMealRequirements(pFolioID), true);

            return eventContract;
        }

        //>>Alpa Event Contract
        public AlpaEventContract getAlpaEventContract(string pFolioID)
        {
            loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
            lDatasetReport = new DataSet();
            lDatasetReport = loReportDAO.getBanquetEventContract(pFolioID);

            AlpaEventContract eventContract = new AlpaEventContract();
            setDatabaseLogOn();
            foreach (Table _oTables in eventContract.Database.Tables)
            {
                _oTables.ApplyLogOnInfo(logOnInfo);
            }

            eventContract.Database.Tables[1].SetDataSource(lDatasetReport.Tables["Main"]);
            eventContract.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

            ReportDocument rpt = eventContract;
            setSubReport(ref rpt, loReportDAO.getFolioEventRequirements(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getSummarizedMealRequirements(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getEventTransactions(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getRoomBlockingRequirements(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getGroupRequirements(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getEventArrangements(pFolioID, "ExtraHour"), true);
            setSubReport(ref rpt, loReportDAO.getEventArrangements(pFolioID, "BillingArrangement"), true);
            setSubReport(ref rpt, loReportDAO.getEventArrangements(pFolioID, "HardCopy"), true);
            setSubReport(ref rpt, loReportDAO.getEventArrangements(pFolioID, "SoftCopy"), true);

            //string strFile = ConfigVariables.gContractPath;
            //StreamReader streamREader = new StreamReader(strFile);
            //string _contractText = streamREader.ReadToEnd();
            //streamREader.Close();

            //_contractText = _contractText.Replace("**groupname**", "Sample event");
            //_contractText = _contractText.Replace("**hotel**", "Alpa City Suites");

            //eventContract.SetParameterValue("contractText", _contractText);

            return eventContract;
        }

        public Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.ContractAmendments getContractAmendments(string pFolioID)
        {
            loReportDAO = new ReportDAO();

            Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.ContractAmendments _oContractAmendments = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.ContractAmendments();
            _oContractAmendments.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
            _oContractAmendments.Database.Tables[1].SetDataSource(loReportDAO.getBookingSheet(pFolioID));
            _oContractAmendments.Database.Tables[2].SetDataSource(loReportDAO.getContractAmendments(pFolioID));

            return _oContractAmendments;
        }

        public SystemChanges getSystemChanges(string pFolioID)
        {
            loReportDAO = new ReportDAO();

            SystemChanges _oSystemChanges = new SystemChanges();
            DataTable _changesLog = loReportDAO.searchChangesLog(pFolioID, "remarks");
            DataView _dtView = _changesLog.DefaultView;
            _dtView.Sort = "DATE_CHANGED ASC";

            string[] _changesLogTables = ConfigVariables.gAmendmentsChangesLogTables.Split(',');
            if (_changesLogTables.Length > 1)
            {
                string _filter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
                for (int i = 1; i < _changesLogTables.Length; i++)
                {
                    _filter = _filter + " or TABLE_NAME = '" + _changesLogTables[i] + "'";
                }
                _dtView.RowFilter = _filter;
            }
            else if (_changesLogTables.Length == 1)
            {
                _dtView.RowFilter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
            }

            _changesLog = _dtView.ToTable();
            foreach (DataRow _dRow in _changesLog.Rows)
            {
                _dRow["remarks"] = _dRow["remarks"].ToString().Split(':')[0];
            }

            _oSystemChanges.Database.Tables[0].SetDataSource(_changesLog);
            _oSystemChanges.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
            _oSystemChanges.Database.Tables[2].SetDataSource(loReportDAO.getBookingSheet(pFolioID));

            return _oSystemChanges;
        }

        public BookingSheet getBookingSheet(string pFolioID, string pMaintenanceCondition)
        {
            loReportDAO = new ReportDAO();
            DataTable dTable = new DataTable();
            dTable = loReportDAO.getBookingSheet(pFolioID);

            BookingSheet bookingSheet = new BookingSheet();
            //setDatabaseLogOn();
            //foreach (Table _oTables in bookingSheet.Database.Tables)
            //{
            //    _oTables.ApplyLogOnInfo(logOnInfo);
            //}

            bookingSheet.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
            bookingSheet.Database.Tables[1].SetDataSource(loReportDAO.getBookingSheet(pFolioID));

            ReportDocument rpt = bookingSheet;

            //setSubReport(ref rpt, loReportDAO.getBookingSheet(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getWeddingDetailsSheet(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getFoodBevSheet(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getMealRequirements(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getRoomRequirements(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getEventRequirementsForMaintenance(pFolioID, pMaintenanceCondition), true);
            setSubReport(ref rpt, loReportDAO.getEventArrangements(pFolioID, "Department"), true);
            //setSubReport(ref rpt, lDatasetReport.Tables["RoomRequirement"], true);

            return bookingSheet;
        }

        public RoomReservationContract getRoomReservationContract(string pFolioID)
        {
            loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
            lDatasetReport = new DataSet();
            lDatasetReport = loReportDAO.getBanquetEventContract(pFolioID);

            RoomReservationContract roomReservationContract = new RoomReservationContract();
            setDatabaseLogOn();
            foreach (Table _oTables in roomReservationContract.Database.Tables)
            {
                _oTables.ApplyLogOnInfo(logOnInfo);
            }

            roomReservationContract.Database.Tables[1].SetDataSource(lDatasetReport.Tables["Main"]);
            roomReservationContract.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

            ReportDocument rpt = roomReservationContract;
            setSubReport(ref rpt, loReportDAO.getBanquetDetails(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getBanquetMeals(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getBanquetRooms(pFolioID), true);
            setSubReport(ref rpt, loReportDAO.getMealRequirements(pFolioID), true);

            return roomReservationContract;
        }

        public PartyTermsAndConditions getBanquetTermsAndConditions(string pFolioID, string pEventName, string pHotel)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                lDatasetReport = new DataSet();
                lDatasetReport = loReportDAO.getBanquetEventContract(pFolioID);

                PartyTermsAndConditions partyTermsAndConditions = new PartyTermsAndConditions();
                partyTermsAndConditions.Database.Tables[1].SetDataSource(lDatasetReport.Tables["Main"]);
                partyTermsAndConditions.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                string strFile = Application.StartupPath + "\\contract.txt";
                //string strFile = ConfigVariables.gContractPath;
                StreamReader streamREader = new StreamReader(strFile);
                string _contractText = streamREader.ReadToEnd();
                streamREader.Close();

                _contractText = _contractText.Replace("**groupname**", pEventName.ToUpper());
                _contractText = _contractText.Replace("**hotel**", pHotel.ToUpper());

                partyTermsAndConditions.SetParameterValue("contractText", _contractText);

                return partyTermsAndConditions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                
            }
        }

        public PartyTermsAndConditions getRoomTermsAndConditions(string pFolioID, string pEventName, string pHotel)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                lDatasetReport = new DataSet();
                lDatasetReport = loReportDAO.getBanquetEventContract(pFolioID);

                PartyTermsAndConditions partyTermsAndConditions = new PartyTermsAndConditions();
                partyTermsAndConditions.Database.Tables[1].SetDataSource(lDatasetReport.Tables["Main"]);
                partyTermsAndConditions.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                string strFile = Application.StartupPath + "\\roomcontract.txt";
                //string strFile = ConfigVariables.gContractPath;
                StreamReader streamREader = new StreamReader(strFile);
                string _contractText = streamREader.ReadToEnd();
                streamREader.Close();

                _contractText = _contractText.Replace("**groupname**", pEventName.ToUpper());
                _contractText = _contractText.Replace("**hotel**", pHotel.ToUpper());

                partyTermsAndConditions.SetParameterValue("contractText", _contractText);

                return partyTermsAndConditions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        public DataTable getDailySalesSummary(string pDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = loReportDAO.getSalesSummary(pDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getDailyRevenue(string pStartDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = loReportDAO.getDailyRevenue(pStartDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getDailyTotalMealAmount(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = loReportDAO.getDailyTotalMealAmount(pStartDate, pEndDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMonthlyTotalMealAmount(int pMonth, int pYear)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = loReportDAO.getMonthlyTotalMealAmount(pMonth, pYear);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAnnualTotalMealAmount(int pYear)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = loReportDAO.getAnnualTotalMealAmount(pYear);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //jlo 9-25-10
        /// <summary>
        /// Gets the report for calendar of events
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <param name="pHotelID">hotel id</param>
        /// <param name="pStatus">status</param>
        /// <returns></returns>
        public DataTable getReportCalenderOfEvents(DateTime pStartDate, DateTime pEndDate, int pHotelID, string pStatus)
        {
            return loReportDAO.getReportCalenderOfEvents(pStartDate, pEndDate, pHotelID, pStatus);
        }

        public DataTable getReportWeeklyScedules(DateTime pStartDate, DateTime pEndDate)
        {
            return loReportDAO.getReportWeeklyScedules(pStartDate, pEndDate);
        }

        public DataTable getEventTypes(int pHotelID)
        {
            return loReportDAO.getEventTypes(pHotelID);
        }

        public DataTable getGroupBooking(string pFieldName,int pHotelID)
        {
            return loReportDAO.getGroupBooking(pFieldName, pHotelID);
        }

        public DataTable getUser(string pUserId)
        {
            return loReportDAO.getUser(pUserId);
        }

        //jlo 9-30-10
        /// <summary>
        /// Get Lost Business Datatable
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <param name="pHotelId">hotel id</param>
        /// <returns>datatable</returns>
        public DataTable getLostBusiness(DateTime pStartDate, DateTime pEndDate, int pHotelId)
        {
            return loReportDAO.getLostBusiness(pStartDate, pEndDate, pHotelId);
        }

        //jlo 10-1-10
        /// <summary>
        /// Gets the list of bookings and inquires
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <param name="pHotelId">hotel id</param>
        /// <returns>DataTAble</returns>
        public DataTable getBookingInquiries(DateTime pStartDate, DateTime pEndDate, int pHotelId)
        {
            return loReportDAO.getBookingInquiries(pStartDate, pEndDate, pHotelId);
        }

        public DataTable getSalesSummaryForRevenue(string pDate)
        {
            try
            {
                loReportDAO = new Jinisys.Hotel.Reports.DataAccessLayer.ReportDAO();
                DataTable dtTable = loReportDAO.getSalesSummaryForRevenue(pDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region "SALES SUMMARY BY SUB-ACCOUNT"


        public DataTable getDailySalesSummaryBySubAccount(string pDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable = loReportDAO.getSalesSummaryBySubAccount(pDate);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable getMonthlySalesSummaryBySubAccount(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlySalesSummaryBySubAccount(pMonth, pYear);
        }

        public DataTable getAnnualSalesSummaryBySubAccount(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualSalesSummaryBySubAccount(pYear);
        }

        #endregion


        #region " RESERVATIONS REPORT [FOR HOTEL REVENUE] "

        public void postHotelRevenue(string pDate)
        {
            loReportDAO = new ReportDAO();
            loReportDAO.postHotelRevenue(pDate);
        }

        public DataTable getHotelRevenue(string pStartDate, string pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getHotelRevenue(pStartDate, pEndDate);
        }

        public DataTable getMonthlyHotelRevenue(int pStartMonth, int pEndMonth, int pStartYear, int pEndYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyHotelRevenue(pStartMonth, pEndMonth, pStartYear, pEndYear);
        }

        public DataTable getAnnualHotelRevenue(int pStartYear, int pEndYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualHotelRevenue(pStartYear, pEndYear);
        }

        public DataTable getColumnsForHotelRevenue()
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getColumnsForHotelRevenue();
        }

        public DataTable getDailyReservationSummary(string pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyReservationSummary(pDate);

        }

        public DataTable getDailyCancelledNoShowReservations(DateTime pDate, DateTime pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyCancelledNoShowReservations(pDate, pEndDate);

        }

        public DataTable getMonthlyCancelledNoShowReservations(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyCancelledNoShowReservations(pMonth, pYear);
        }

        public DataTable getAnnualCancelledNoShowReservations(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualCancelledNoShowReservations(pYear);
        }


        public DataTable getDailyReservationsByAccountType(DateTime pDate, DateTime pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyReservationsByAccountType(pDate, pEndDate);

        }

        public DataTable getMonthlyReservationsByAccountType(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyReservationsByAccountType(pMonth, pYear);
        }

        public DataTable getAnnualReservationsByAccountType(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualReservationsByAccountType(pYear);
        }



        #endregion

        #region "RESERVATION SOURCE SUMMARY"


        public DataTable getDailyReservationSummaryBySource(DateTime pDate, DateTime pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyReservationSummaryBySource(pDate, pEndDate);
        }


        public DataTable getMonthlyReservationSummaryBySource(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyReservationSummaryBySource(pMonth, pYear);

        }


        public DataTable getAnnualReservationSummaryBySource(int pYear)
        {

            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualReservationSummaryBySource(pYear);

        }


        #endregion

        #region "WALKIN / PERSONAL & CORPORATE"


        public DataTable getDailyWalkinPersonalFolio(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyWalkinPersonalFolio(pDate);
        }


        public DataTable getMonthlyWalkinPersonalFolio(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyWalkinPersonalFolio(pMonth, pYear);

        }


        public DataTable getAnnualWalkinPersonalFolio(int pYear)
        {

            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualWalkinPersonalFolio(pYear);

        }


        public DataTable getDailyWalkinCorporateFolio(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyWalkinCorporateFolio(pDate);
        }


        public DataTable getMonthlyWalkinCorporateFolio(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyWalkinCorporateFolio(pMonth, pYear);

        }


        public DataTable getAnnualWalkinCorporateFolio(int pYear)
        {

            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualWalkinCorporateFolio(pYear);

        }



        #endregion


        #region "AVERAGE ROOM RATE"

        public DataTable getDailyAverageRoomRate(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return this.loReportDAO.getDailyAverageRoomRate(pDate);

        }

        public DataTable getMonthlyAverageRoomRate(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return this.loReportDAO.getMonthlyAverageRoomRate(pMonth, pYear);

        }

        public DataTable getAnnualAverageRoomRate(int pYear)
        {
            loReportDAO = new ReportDAO();
            return this.loReportDAO.getAnnualAverageRoomRate(pYear);

        }

        #endregion


        #region "AVERAGE ROOM RATE PER GUEST"

        public DataTable getDailyAverageRoomRatePerGuest(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return this.loReportDAO.getDailyAverageRoomRatePerGuest(pDate);

        }

        public DataTable getMonthlyAverageRoomRatePerGuest(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return this.loReportDAO.getMonthlyAverageRoomRatePerGuest(pMonth, pYear);

        }

        public DataTable getAnnualAverageRoomRatePerGuest(int pYear)
        {
            loReportDAO = new ReportDAO();
            return this.loReportDAO.getAnnualAverageRoomRatePerGuest(pYear);

        }

        #endregion


        #region "GUEST A/R"

        public DataTable getDailyGuestAR(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyGuestAR(pDate);
        }

        public DataTable getMonthlyGuestAR(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyGuestAR(pDate);
        }

        public DataTable getAnnualGuestAR(DateTime pLastYearDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualGuestAR(pLastYearDate);
        }


        #endregion



        #region "Total Functions"

        public int getDailyTotalFunctions(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyTotalFunctions(pDate);
        }

        public int getMonthlyTotalFunctions(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyTotalFunctions(pMonth, pYear);
        }

        public int getAnnualTotalFunctions(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualTotalFunctions(pYear);
        }

        #endregion



        #region "Rooms Stay-Over"

        public int getDailyTotalRoomStayOver(DateTime pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyTotalRoomStayOver(pDate);
        }

        public int getMonthlyTotalRoomStayOver(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyTotalRoomStayOver(pMonth, pYear);
        }

        public int getAnnualTotalRoomStayOver(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualTotalRoomStayOver(pYear);
        }

        #endregion


        public double getExpectedRoomSalesOccupancyForecast(string _queryDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getExpectedRoomSalesOccupancyForecast(_queryDate);
        }

        public double getActualRoomSalesOccupancyForecast(string _queryDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getActualRoomSalesOccupancyForecast(_queryDate);
        }


        public DataTable getRooms()
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getRooms();
        }

        #region "Room Revenue"

        public RoomRevenueReport getRoomRevenuePerDayReport(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                RoomRevenueReport roomRevenueReport = new RoomRevenueReport();
                //allCashierTransactions.SetDataSource(dt);
                roomRevenueReport.Database.Tables[1].SetDataSource(loReportDAO.getRoomRevenuePerDateRange(pStartDate, pEndDate));
                roomRevenueReport.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                roomRevenueReport.SetParameterValue(0, "From " + pStartDate + " to " + pEndDate);

                return roomRevenueReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getRoomRevenuePerDay(string pDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getRoomRevenuePerDay(pDate);
        }

        public DataTable getRoomRevenuePerMonth(int pMonth, int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getRoomRevenuePerMonth(pMonth, pYear);
        }

        public DataTable getRoomRevenuePerYear(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getRoomRevenuePerYear(pYear);
        }

        #endregion

        #region "FROM HOUSEKEEPING SYSTEM"


        public HousekeepingReport HK_GetHousekeepingReport(string fromDate, string toDate)
        {
            try
            {

                DataTable _temp = loReportDAO.HK_GetHousekeepingReport(fromDate, toDate);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }

                HousekeepingReport obj = new HousekeepingReport();
                //obj.SetDataSource();
                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);


                obj.SetParameterValue(0, "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(fromDate)) + " to " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(toDate)));
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @GetHousekeepingReport():" + ex.Message); return null;
            }
        }

        public HKReportByHousekeeper HK_GetHousekeepingReportByHousekeepers(string fromDate, string toDate)
        {
            try
            {
                DataTable _temp = loReportDAO.HK_GetHousekeepingReportByHousekeepers(fromDate, toDate);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }


                HKReportByHousekeeper obj = new HKReportByHousekeeper();
                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);

                obj.SetParameterValue(0, "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(fromDate)) + " to " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(toDate)));
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @GetHousekeepingReportByHousekeepers():" + ex.Message); return null;
            }
        }

        public DataTable HK_GetCategories()
        {
            return loReportDAO.HK_GetCategories();
        }

        public MinibarItemsList HK_GetMinibarItemsList(int CategoryID)
        {
            MinibarItemsList obj = new MinibarItemsList();

            DataTable _temp = loReportDAO.HK_GetMinibarItemsList(CategoryID);
            DataTable _rptHeader = CrystalReportAddons.reportHeader();

            if (_temp.Rows.Count == 0)
            {
                DataRow _newRow = _temp.NewRow();
                _temp.Rows.Add(_newRow);
            }

            obj.Database.Tables[0].SetDataSource(_temp);
            obj.Database.Tables[1].SetDataSource(_rptHeader);


            return obj;
        }

        public rptMinibarSalesRange HK_GetMinibarSalesReport(string fromDate, string toDate)
        {
            try
            {
                rptMinibarSalesRange obj = new rptMinibarSalesRange();

                DataTable _temp = loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }

                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);

                //obj.SetDataSource(loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate));
                obj.SetParameterValue("Period", "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(fromDate)) + " to " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(toDate)));
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @GetHousekeepingReportByHousekeepers():" + ex.Message); return null;
            }
        }

        public MinibarSalesByHousekeeper HK_GetMinibarSalesReportByHousekeeper(string fromDate, string toDate)
        {
            try
            {
                MinibarSalesByHousekeeper obj = new MinibarSalesByHousekeeper();

                DataTable _temp = loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }

                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);

                //obj.SetDataSource(loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate));
                obj.SetParameterValue("Period", "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(fromDate)) + " to " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(toDate)));
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @GetMinibarSalesReportByHousekeeper():" + ex.Message); return null;
            }
        }

        public MinibarSalesByRoom HK_GetMinibarSalesReportByRoom(string fromDate, string toDate)
        {
            try
            {
                MinibarSalesByRoom obj = new MinibarSalesByRoom();

                DataTable _temp = loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }

                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);

                //obj.SetDataSource(loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate));
                obj.SetParameterValue("Period", "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(fromDate)) + " to " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(toDate)));
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @GetMinibarSalesReportByRoom():" + ex.Message); return null;
            }
        }

        public MinibarSalesByCategory HK_GetMinibarSalesReportByCategory(string fromDate, string toDate)
        {
            try
            {
                MinibarSalesByCategory obj = new MinibarSalesByCategory();

                DataTable _temp = loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }

                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);

                //obj.SetDataSource(loReportDAO.HK_ReportMinibarSalesRange(fromDate, toDate));
                obj.SetParameterValue("Period", "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(fromDate)) + " to " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(toDate)));
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @GetMinibarSalesReportByCategory():" + ex.Message); return null;
            }
        }

        public HousekeepingSummary HK_GetHousekeeperSummary(string fromDate, string toDate)
        {
            try
            {
                HousekeepingSummary obj = new HousekeepingSummary();

                DataTable _temp = loReportDAO.HK_GetHousekeeperSummary(fromDate, toDate);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }

                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);


                //obj.SetDataSource(loReportDAO.HK_GetHousekeeperSummary(fromDate, toDate));
                obj.SetParameterValue(0, "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(fromDate)) + " to " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(toDate)));
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @GetHousekeeperSummary():" + ex.Message); return null;
            }
        }

        #endregion

        // >> High balance guests
        public HighBalanceGuestReport getHighBalanceGuests(DateTime pReportDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable;
                dtTable = loReportDAO.getHighBalanceGuests(pReportDate);

                HighBalanceGuestReport oHighBalanceGuests = new HighBalanceGuestReport();

                oHighBalanceGuests.Database.Tables[1].SetDataSource(dtTable);
                oHighBalanceGuests.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                object date = (object)string.Format("{0:ddd. MMMM dd, yyyy}", pReportDate);
                oHighBalanceGuests.SetParameterValue(0, date);

                return oHighBalanceGuests;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getHighBalanceGuests() " + ex.Message);
                return null;
            }
        }

		public DataTable getTransactionCodes()
		{
			loReportDAO = new ReportDAO();
			return loReportDAO.getTransactionCodes();
		}

		public DataTable getDailyHotelRevenue(DateTime startDate, DateTime endDate)
		{

			loReportDAO = new ReportDAO();

			DataTable dtTable = loReportDAO.getDailyHotelRevenue(startDate, endDate);

			return dtTable;
		}

        public DataTable getGroupedRoomingList()
        {
            loReportDAO = new ReportDAO();
            DataTable dtTable = loReportDAO.getGroupedRoomingList();

            return dtTable;
        }

        public RoomingList getRoomingList(string pFolioID)
        {
            try
            {

                DataTable _temp = loReportDAO.getRoomingList(pFolioID);
                DataTable _rptHeader = CrystalReportAddons.reportHeader();

                if (_temp.Rows.Count == 0)
                {
                    DataRow _newRow = _temp.NewRow();
                    _temp.Rows.Add(_newRow);
                }

                RoomingList obj = new RoomingList();
                //obj.SetDataSource();
                obj.Database.Tables[0].SetDataSource(_temp);
                obj.Database.Tables[1].SetDataSource(_rptHeader);
                obj.SetParameterValue(0, "Report for " + string.Format("{0:MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate)));

                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @getRoomingList():" + ex.Message); return null;
            }
        }

        //>> for Nationality Report
        public NationalityReport getNationalityReport(string pStartDate, string pEndDate)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable;
                dtTable = loReportDAO.getNationalityReport(pStartDate, pEndDate);

                NationalityReport oNationalityReport = new NationalityReport();

                oNationalityReport.Database.Tables[1].SetDataSource(dtTable);
                oNationalityReport.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                oNationalityReport.SetParameterValue(0, DateTime.Parse(pStartDate));
                oNationalityReport.SetParameterValue(1, DateTime.Parse(pEndDate));

                return oNationalityReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @getNationalityReport():" + ex.Message);
                return null;
            }
        }

        public DataTable getSalesAndMarketingRevenueReport(DateTime startDate, DateTime endDate)
        {

            loReportDAO = new ReportDAO();

            DataTable dtTable = loReportDAO.getSalesAndMarketingRevenueReport(startDate, endDate);

            return dtTable;
        }

        //>>for Statement of Account
        public StatementOfAccount getStatementOfAccount(string pFolioID)
        {
            try
            {
                loReportDAO = new ReportDAO();
                DataTable dtTable;
                dtTable = loReportDAO.getStatementOfAccount(pFolioID);

                StatementOfAccount oStatementOfAccountReport = new StatementOfAccount();

                oStatementOfAccountReport.Database.Tables[1].SetDataSource(dtTable);
                oStatementOfAccountReport.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                string strFile = Application.StartupPath + "\\statementOfAccount.txt";
                //string strFile = ConfigVariables.gContractPath;
                StreamReader streamREader = new StreamReader(strFile);
                string _statementText = streamREader.ReadToEnd();
                streamREader.Close();

                oStatementOfAccountReport.SetParameterValue("statementOfAccountText", _statementText);

                return oStatementOfAccountReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @getStatementOfAccountReport():" + ex.Message);
                return null;
            }
        }

        public DataTable getDailyStatisticalReport(string pDate, string pSortType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDailyStatisticalReport(pDate, pSortType);
        }

        public DataTable getMonthlyStatisticalReport(int pMonth, int pYear, string pSortType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyStatisticalReport(pMonth, pYear, pSortType);
        }

        public DataTable getAnnualStatisticalReport(int pYear, string pSortType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualStatisticalReport(pYear, pSortType);
        }

        public DataTable getDateRangeStatisticalReport(string pStartDate, string pEndDate, string pSortType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getDateRangeStatisticalReport(pStartDate, pEndDate, pSortType);
        }

        public DataTable getMonthlyRangeMarketSegment(int pStartMonth, int pStartYear, int pEndMonth, int pEndYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyRangeMarketSegment(pStartMonth, pStartYear, pEndMonth, pEndYear);
        }

        public DataTable getAnnualMarketSegment(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualMarketSegment(pYear);
        }

        public DataTable getTotalCountForPreviousYears(int pMonth, int pYear, string pType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getTotalCountForPreviousYears(pMonth, pYear, pType);
        }

        public DataTable getMonthlyRangeMarketSegmentPerRoomType(int pStartMonth, int pStartYear, int pEndMonth, int pEndYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getMonthlyRangeMarketSegmentPerRoomType(pStartMonth, pStartYear, pEndMonth, pEndYear);
        }

        public DataTable getAnnualMarketSegmentPerRoomType(int pYear)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAnnualMarketSegmentPerRoomType(pYear);
        }

        public DataTable getTotalCountForPreviousYearsPerRoomType(int pMonth, int pYear, string pType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getTotalCountForPreviousYearsPerRoomType(pMonth, pYear, pType);
        }

        //EMP-SCR-00165
        /// <summary>
        /// Gets the Annual Events and Revenue Report
        /// </summary>
        /// <param name="pYear">Sets the year to be retrieved</param>
        /// <returns>DataTable</returns>
        public DataTable getAnnualEventsAndRevenueReport(int pYear)
        {
            try
            {
                loReportDAO = new ReportDAO();
                return loReportDAO.getAnnualEventsAndRevenueReport(pYear);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end of EMP-SCR-00165

        //EMP-SCR-
        /// <summary>
        /// Gets the Annual Market Segment Report
        /// </summary>
        /// <param name="pYear">Sets the year to be retrieved</param>
        /// <returns>DataTable</returns>
        public DataTable getAnnualMarketSegmentReport(int pYear)
        {
            try
            {
                loReportDAO = new ReportDAO();
                return loReportDAO.getAnnualMarketSegmentReport(pYear);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end of EMP-SCR-


        public DataTable getRoomIds()
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getRoomIds();
        }

        public DataTable getEvents(DateTime pStartDate, DateTime pEndDate)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getEvents(pStartDate, pEndDate);
        }

        public Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation.EventAttendance getEventAttendance(string pFolioID)
        {
            loReportDAO = new ReportDAO();
            DataTable _dt = loReportDAO.getEventAttendance(pFolioID);
            Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation.EventAttendance oEventAttendance = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation.EventAttendance();
            DataRow _dRow = _dt.Rows[0];

            string _strFile = Application.StartupPath + "\\eventAttendance.txt";
            StreamReader streamREader = new StreamReader(_strFile);
            string _eventNotes = streamREader.ReadToEnd();
            streamREader.Close();

            oEventAttendance.SetParameterValue( 0, _dRow["groupName"]);
            oEventAttendance.SetParameterValue( 1, _dRow["eventDate"]);
            oEventAttendance.SetParameterValue( 2, _dRow["ReferenceNo"]);
            oEventAttendance.SetParameterValue( 3, _dRow["GeographicalScope"]);
            oEventAttendance.SetParameterValue( 4, _dRow["ForeignParticipants"]);
            oEventAttendance.SetParameterValue( 5, _dRow["LocalParticipants"]);
            oEventAttendance.SetParameterValue( 6, _dRow["ForeignBased"]);
            oEventAttendance.SetParameterValue( 7, _dRow["LocalBased"]);
            oEventAttendance.SetParameterValue( 8, _dRow["NoOfVisitors"]);
            oEventAttendance.SetParameterValue( 9, _dRow["ActualAttendees"]);
            oEventAttendance.SetParameterValue( 10, _dRow["marketSegment"]);
            oEventAttendance.SetParameterValue( 11, _dRow["Remarks"]);
            oEventAttendance.SetParameterValue( 12, _eventNotes);

            return oEventAttendance;
        }

        public AccountReport getAccountReport(string pAccountID, string pCategory)
        {
            loReportDAO = new ReportDAO();
            DataTable _account = loReportDAO.getAccountReport(pAccountID);
            DataTable _events = loReportDAO.getEventOrganized(pAccountID);
            DataTable _user = loReportDAO.getUser(GlobalVariables.gLoggedOnUser);
            string _preparedBy = "";
            if (_user.Rows.Count > 0)
            {
                foreach (DataRow _dRow in _user.Rows)
                {
                    _preparedBy = _dRow["FirstName"].ToString() + " " + _dRow["LastName"].ToString();
                }
            }
            else
            {
                _preparedBy = GlobalVariables.gLoggedOnUser;
            }

            AccountReport oAccountReport = new AccountReport();
            oAccountReport.Database.Tables[0].SetDataSource(_account);
            oAccountReport.Database.Tables[1].SetDataSource(_events);

            oAccountReport.SetParameterValue(0, _preparedBy);
            oAccountReport.SetParameterValue(1, pCategory);

            return oAccountReport;
        }

        public AccountReport2 getAccountReport2(string pFolioID, string pAccountID)
        {
            loReportDAO = new ReportDAO();
            DataTable _accountEvent = loReportDAO.getAccountEvent(pFolioID);
            DataTable _incumbentOfficers = loReportDAO.getIncumbentOfficers(pFolioID);
            DataTable _contactPersons = loReportDAO.getContactPersons(pFolioID, GlobalVariables.gHotelId, pAccountID);

            AccountReport2 oAccountReport2 = new AccountReport2();

            oAccountReport2.OpenSubreport("IncumbetSubReport.rpt").SetDataSource(_incumbentOfficers);
            oAccountReport2.OpenSubreport("ContactSubReport.rpt").SetDataSource(_contactPersons);
            oAccountReport2.Database.Tables[0].SetDataSource(_accountEvent);

            return oAccountReport2;
        }

        public bool exportLetterOfProposal(string pFileName, string pFolioId ,DataTable _dt,string pOrganizerID,string pOrganizerName)
        {
            object _missing = System.Reflection.Missing.Value;
            Word.Application wordApp = new Word.ApplicationClass();
            Word.Document aDoc = null;

            Jinisys.Hotel.Reservation.BusinessLayer.Folio _oFolio = new Folio();


            string _organizerID = pOrganizerID;
            string _organizerName = pOrganizerName;

            DataTable _lop = loReportDAO.getLOP(pFolioId);

            if (File.Exists(Application.StartupPath + "\\LOP.doc"))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;
                object path = Application.StartupPath + "\\LOP.doc";
                aDoc = wordApp.Documents.Open(ref path, ref _missing,
                        ref readOnly, ref _missing, ref _missing, ref _missing,
                        ref _missing, ref _missing, ref _missing, ref _missing,
                        ref _missing, ref isVisible, ref _missing, ref _missing,
                        ref _missing, ref _missing);

                aDoc.Activate();
                this.FindAndReplace(wordApp, "<date>", string.Format("{0:MMMM dd, yyyy}",DateTime.Now));
                if (_dt.Rows.Count > 0)
                {
                    this.FindAndReplace(wordApp, "<individual>", _dt.Rows[0]["individual"]);
                    this.FindAndReplace(wordApp, "<designation>", _dt.Rows[0]["designation"]);
                    this.FindAndReplace(wordApp, "<company>", _dt.Rows[0]["company"]);
                    this.FindAndReplace(wordApp, "<address1>", _dt.Rows[0]["address1"]);
                    this.FindAndReplace(wordApp, "<address2>", _dt.Rows[0]["address2"]);
                    this.FindAndReplace(wordApp, "<telephone>", _dt.Rows[0]["telephone"]);
                    this.FindAndReplace(wordApp, "<email>", _dt.Rows[0]["email"]);
                    this.FindAndReplace(wordApp, "<dear>", _dt.Rows[0]["dear"]);
                    this.FindAndReplace(wordApp, "<event>", _dt.Rows[0]["event"]);
                    this.FindAndReplace(wordApp, "<wordamount>", _dt.Rows[0]["wordamount"]);
                    this.FindAndReplace(wordApp, "<contractamount>", _dt.Rows[0]["contractamount"]);
                    this.FindAndReplace(wordApp, "<50%Date>", _dt.Rows[0]["50%Date"]);
                    this.FindAndReplace(wordApp, "<lastDate>", _dt.Rows[0]["lastDate"]);
                    this.FindAndReplace(wordApp, "<conforme>", _dt.Rows[0]["conforme"]);
                    this.FindAndReplace(wordApp, "<eventid>", pFolioId);
                    this.FindAndReplace(wordApp, "<companyid>", _organizerID);
                    this.FindAndReplace(wordApp, "<companyname>", _organizerName);
                }
                else
                {
                    this.FindAndReplace(wordApp, "<individual>", "");
                    this.FindAndReplace(wordApp, "<designation>", "");
                    this.FindAndReplace(wordApp, "<company>", "");
                    this.FindAndReplace(wordApp, "<address1>", "");
                    this.FindAndReplace(wordApp, "<address2>", "");
                    this.FindAndReplace(wordApp, "<telephone>", "");
                    this.FindAndReplace(wordApp, "<email>", "");
                    this.FindAndReplace(wordApp, "<dear>", "");
                    this.FindAndReplace(wordApp, "<event>", "");
                    this.FindAndReplace(wordApp, "<wordamount>", "");
                    this.FindAndReplace(wordApp, "<contractamount>", "");
                    this.FindAndReplace(wordApp, "<50%Date>", "");
                    this.FindAndReplace(wordApp, "<lastDate>", "");
                    this.FindAndReplace(wordApp, "<conforme>", "");
                    this.FindAndReplace(wordApp, "<eventid>", pFolioId);
                    this.FindAndReplace(wordApp, "<companyid>", _organizerID);
                    this.FindAndReplace(wordApp, "<companyname>", _organizerName);
                }
                if (_lop.Rows.Count > 0)
                {
                    this.FindAndReplace(wordApp, "<eventDate>", _lop.Rows[0]["eventDate"]);
                    this.FindAndReplace(wordApp, "<rooms>", _lop.Rows[0]["Rooms"]);
                    this.FindAndReplace(wordApp, "<marketingofficer>", _lop.Rows[0]["mo"]);
                }
                else
                {
                    this.FindAndReplace(wordApp, "<eventDate>", "");
                    this.FindAndReplace(wordApp, "<rooms>", "");
                    this.FindAndReplace(wordApp, "<marketingofficer>", "");
                }
            }
            else
            {
                MessageBox.Show("Template for LOP does not exist.");
                return false;
            }
              
 
            object _save = pFileName;
            try
            {
                aDoc.SaveAs(ref _save, ref _missing, ref _missing, ref _missing,
                    ref _missing, ref _missing, ref _missing, ref _missing,
                    ref _missing, ref _missing, ref _missing, ref _missing,
                    ref _missing, ref _missing, ref _missing, ref _missing);
            }
            catch
            {
                MessageBox.Show("There was a problem saving the document. Unable to overwrite file (in use).", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            aDoc.Close(ref _missing, ref _missing, ref _missing);
            return true;
        }

        public bool exportHistoricalEventsAndRevenue(C1.Win.C1FlexGrid.C1FlexGrid pGrid,string pFileName, string pType, string pFromDate, string pToDate)
        {

            Excel.Application excelApp = null;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;

            try
            {
                excelApp = new Excel.Application();
                string templatePath = Application.StartupPath + "\\Historical No. of Events & Revenue.xlt";
                string OutputPath = pFileName + ".xls";
                templatePath = Path.GetFullPath(templatePath);
                OutputPath = Path.GetFullPath(OutputPath);
                xlBook = (Excel.Workbook)excelApp.Workbooks.Open(templatePath, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);

                pFromDate = DateTime.Parse(pFromDate + "-01-01").Year.ToString();
                loadDataNoOfEvents(pGrid, ref excelApp, pFromDate, pToDate, "EVENTS");
                loadDataRevenue(pGrid, ref excelApp, pFromDate, pToDate, "REVENUE");

                //loadDataNotable(ref excelApp, pFromDate, pToDate, "NOTABLE");
                //loadDataNoOfEventsPerYearMonth(ref excelApp, pFromDate, pToDate, "EVENTS");
                //loadDataRevenuePerYearMonth(ref excelApp, pFromDate, pToDate, "REVENUE");
                //loadDataEventsAndRevenueWoGraph(ref excelApp, pFromDate, pToDate, "EVENTS AND REVENUE");

                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                xlSheet.Name = "No Of Events(" + pFromDate + "-" + pToDate + ")";

                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(2);
                xlSheet.Name = "Revenue(" + pFromDate + "-" + pToDate + ")";


                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(3);
                xlSheet.Name = "SIGNIFICANT EVENT(" + pFromDate + "-" + pToDate + ")";

                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(6);
                xlSheet.Name = "(" + pFromDate + "-" + pToDate + ") WO Graphs";

                object oFilename = OutputPath;
                object oFileFormat = Excel.XlFileFormat.xlWorkbookNormal;
                object oPassword = Missing.Value;
                object oWriteResPassword = Missing.Value;
                object oReadOnlyRecommended = false;
                object oCreateBackup = false;

                Excel.XlSaveAsAccessMode AccessMode = Excel.XlSaveAsAccessMode.xlNoChange;
                object oConflictResolution = false;
                object oAddToMru = true;
                object oTextCodepage = Missing.Value;
                object oTextVisualLayout = Missing.Value;
                object oSaveChanges = true;
                object oRouteWorkbook = Missing.Value;

                excelApp.DisplayAlerts = false;
                xlBook.SaveAs(oFilename, oFileFormat, oPassword, oWriteResPassword, oReadOnlyRecommended, oCreateBackup, AccessMode, oConflictResolution, oAddToMru, oTextCodepage, oTextVisualLayout, new object());
                xlBook.Close(oSaveChanges, oFilename, oRouteWorkbook);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return true;
        }

        public void loadDataNoOfEvents(C1.Win.C1FlexGrid.C1FlexGrid pGrid,ref Excel.Application pExcelApp, string pFromDate, string pToDate, string pType)
        {

            Excel.Worksheet worksheet = (Excel.Worksheet)pExcelApp.Worksheets[1];
            worksheet.Select(true);
            DateTime _from = DateTime.Parse(pFromDate + "-01-01");
            DateTime _to = DateTime.Parse(pToDate + "-12-31");
            DateTime _dt;
            int i = 3;
            Excel.Range xlRange = worksheet.get_Range("N1", Missing.Value);
            //object[,] values = (object[,])xlRange.Value2;
            int _row = 4;
            int _col = 2;
            int _rowMonth = 1;
            int _rowWH = 5;
            DataTable dtCSV = loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, pType);
            //worksheet.Cells.SetColumnWidth(1, 17.5);
            int _colLenght = pGrid.Cols.Count;

            foreach(C1.Win.C1FlexGrid.Row _rowGrid in pGrid.Rows)
            {
                _col = 2;
                for (int _i = 0; _i < _colLenght; _i++)
                {
                    pExcelApp.Cells[_row, _col] = _rowGrid[_i].ToString();
                    _col++;
                }
                _row++;
                
            }


            //for (_dt = _from; _dt.Year <= _to.AddYears(1).Year; _dt = _dt.AddYears(1), i++)
            //{
            //    row = 5;
            //    pExcelApp.Cells[row - 1, i] = _dt.Year.ToString();
            //    for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
            //    {
            //        pExcelApp.Cells[_row + 5, i - 1] = dtCSV.Rows[_row][i - 3].ToString();
            //    }

            //}

            for (int _cnt = _colLenght+2; _cnt <29 ; _cnt++)
            {
                ((Microsoft.Office.Interop.Excel.Range)pExcelApp.Cells[1, _cnt]).EntireColumn.ColumnWidth = 0;
            }

            pExcelApp.Cells[2, 2] = "(" + pFromDate + "-" + pToDate + ")";
            pExcelApp.Cells[4, 31] = "Average(" + pFromDate + "-" + pToDate + ")";
            //pExcelApp.Cells[18, 16] = (i - 3) + "";

        }

        public void loadDataRevenue(C1.Win.C1FlexGrid.C1FlexGrid pGrid, ref Excel.Application pExcelApp, string pFromDate, string pToDate, string pType)
        {

            Excel.Worksheet worksheet = (Excel.Worksheet)pExcelApp.Worksheets[2];
            worksheet.Select(true);
            DateTime _from = DateTime.Parse(pFromDate + "-01-01");
            DateTime _to = DateTime.Parse(pToDate + "-12-31");
            DateTime _dt;
            int i = 3;
            Excel.Range xlRange = worksheet.get_Range("N1", Missing.Value);
            //object[,] values = (object[,])xlRange.Value2;
            int _row = 4;
            int _col = 1;
            int _rowMonth = 1;
            int _rowWH = 5;
            DataTable dtCSV = loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, pType);
            //worksheet.Cells.SetColumnWidth(1, 17.5);
            int _colLenght = pGrid.Cols.Count;

            foreach (C1.Win.C1FlexGrid.Row _rowGrid in pGrid.Rows)
            {
                _col = 1;
                for (int _i = 0; _i < _colLenght; _i++)
                {
                    pExcelApp.Cells[_row, _col] = _rowGrid[_i].ToString();
                    _col++;
                }
                _row++;

            }


            //for (_dt = _from; _dt.Year <= _to.AddYears(1).Year; _dt = _dt.AddYears(1), i++)
            //{
            //    row = 5;
            //    pExcelApp.Cells[row - 1, i] = _dt.Year.ToString();
            //    for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
            //    {
            //        pExcelApp.Cells[_row + 5, i - 1] = dtCSV.Rows[_row][i - 3].ToString();
            //    }

            //}

            for (int _cnt = _colLenght + 2; _cnt < 29; _cnt++)
            {
                ((Microsoft.Office.Interop.Excel.Range)pExcelApp.Cells[1, _cnt]).EntireColumn.ColumnWidth = 0;
            }

            pExcelApp.Cells[2, 1] = "(" + pFromDate + "-" + pToDate + ")";
            pExcelApp.Cells[4, 15] = "Average(" + pFromDate + "-" + pToDate + ")";
            // pExcelApp.Cells[18, 15] = (i - 3) + "";
        }

        public void loadDataNotable(ref Excel.Application pExcelApp, string pFromDate, string pToDate, string pType)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)pExcelApp.Worksheets[3];
            worksheet.Select(true);

            DateTime _from = DateTime.Parse(pToDate + "-01-01").AddYears(-10);
            DateTime _to = DateTime.Parse(pToDate + "-12-31").AddYears(1);
            DateTime _dt;
            int i = 0;
            Excel.Range xlRange = worksheet.get_Range("A3", "C14");
            object[,] values = (object[,])xlRange.Value2;
            int row = 4;
            int _rowMonth = 1;
            int _rowWH = 5;

            DataTable dtCSV = loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, pType);
            for (; i < 3; i++)
            {
                for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
                {
                    pExcelApp.Cells[_row + 4, i + 1] = dtCSV.Rows[_row][i].ToString();
                }
            }
            pExcelApp.Cells[1, 1] = "SIGNIFICANT EVENTS HELD IN(" + pFromDate + "-" + pToDate + ")";
            pExcelApp.Cells[4, 16] = "Average(" + pFromDate + "-" + pToDate + ")";
            //pExcelApp.Cells[18, 16] = (i - 3) + "";
        }

        public void loadDataNoOfEventsPerYearMonth(ref Excel.Application pExcelApp, string pFromDate, string pToDate, string pType)
        {

            Excel.Worksheet worksheet = (Excel.Worksheet)pExcelApp.Worksheets[7];
            worksheet.Select(true);

            DateTime _from = DateTime.Parse(pToDate + "-01-01").AddYears(-10);
            DateTime _to = DateTime.Parse(pToDate + "-12-31").AddYears(-1);
            DateTime _dt;
            int i = 1;
            Excel.Range xlRange = worksheet.get_Range("A2", "K16");
            object[,] values = (object[,])xlRange.Value2;

            int row = 3;
            int _rowMonth = 1;
            int _rowWH = 5;
            DataTable dtCSV = loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, pType);

            for (_dt = _from; _dt.Year <= _to.Year; _dt = _dt.AddYears(1), i++)
            {
                row = 3;

                for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
                {
                    pExcelApp.Cells[_row + 3, i] = dtCSV.Rows[_row][i - 1].ToString();
                }
                if (_dt.Year == _to.Year) break;
                pExcelApp.Cells[row - 1, i + 1] = _dt.Year.ToString();
            }

            worksheet = (Excel.Worksheet)pExcelApp.Worksheets[8];
            worksheet.Select(true);
            _from = DateTime.Parse(pToDate + "-01-01").AddYears(-10);
            _to = DateTime.Parse(pToDate + "-12-31").AddYears(-1);
            i = 1;
            row = 3;


            for (_dt = _from; _dt.Year <= _to.Year; _dt = _dt.AddYears(1), i++)
            {
                row = 3;

                for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
                {
                    pExcelApp.Cells[_row + 3, i] = dtCSV.Rows[_row][i - 1].ToString();
                }

                if (_dt.Year == _to.Year) break;
                pExcelApp.Cells[row - 1, i + 1] = _dt.Year.ToString();
            }
            // pExcelApp.Cells[2, 2] = "(" + pFromDate + "-" + pToDate + ")";
            // pExcelApp.Cells[4, 16] = "Average(" + pFromDate + "-" + pToDate + ")";
        }
        public void loadDataRevenuePerYearMonth(ref Excel.Application pExcelApp, string pFromDate, string pToDate, string pType)
        {

            Excel.Worksheet worksheet = (Excel.Worksheet)pExcelApp.Worksheets[9];
            worksheet.Select(true);

            DateTime _from = DateTime.Parse(pToDate + "-01-01").AddYears(-10);
            DateTime _to = DateTime.Parse(pToDate + "-12-31").AddYears(-1);
            DateTime _dt;
            int i = 1;
            Excel.Range xlRange = worksheet.get_Range("A2", "K16");
            object[,] values = (object[,])xlRange.Value2;

            int row = 3;
            int _rowMonth = 1;
            int _rowWH = 5;
            DataTable dtCSV = loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, pType);
            for (_dt = _from; _dt.Year <= _to.Year; _dt = _dt.AddYears(1), i++)
            {
                row = 3;


                for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
                {
                    pExcelApp.Cells[_row + 3, i] = dtCSV.Rows[_row][i - 1].ToString();
                }

                if (_dt.Year == _to.Year) break;
                pExcelApp.Cells[row - 1, i + 1] = _dt.Year.ToString();
            }


            worksheet = (Excel.Worksheet)pExcelApp.Worksheets[10];
            worksheet.Select(true);
            _from = DateTime.Parse(pToDate + "-01-01").AddYears(-10);
            _to = DateTime.Parse(pToDate + "-12-31").AddYears(-1);
            i = 1;
            row = 3;
            _rowMonth = 1;
            _rowWH = 5;

            for (_dt = _from; _dt.Year <= _to.Year; _dt = _dt.AddYears(1), i++)
            {
                row = 3;

                for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
                {
                    pExcelApp.Cells[_row + 3, i] = dtCSV.Rows[_row][i - 1].ToString();
                }
                if (_dt.Year == _to.Year) break;
                pExcelApp.Cells[row - 1, i + 1] = _dt.Year.ToString();
            }
            // pExcelApp.Cells[2, 2] = "(" + pFromDate + "-" + pToDate + ")";
            // pExcelApp.Cells[4, 16] = "Average(" + pFromDate + "-" + pToDate + ")";
        }

        public void loadDataEventsAndRevenueWoGraph(ref Excel.Application pExcelApp, string pFromDate, string pToDate, string pType)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)pExcelApp.Worksheets[6];
            worksheet.Select(true);

            DateTime _from = DateTime.Parse(pToDate + "-01-01").AddYears(-10);
            DateTime _to = DateTime.Parse(pToDate + "-12-31");
            DateTime _dt;
            int i = 2;

            int row = 4;
            DataTable dtCSV = loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, "EVENTS");
            for (_dt = _from; _dt.Year <= _to.Year; _dt = _dt.AddYears(1), i++)
            {
                row = 4;

                for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
                {
                    pExcelApp.Cells[_row + 4, i - 1] = dtCSV.Rows[_row][i - 2].ToString();
                }
                if (_dt.Year == _to.Year) break;
                pExcelApp.Cells[row - 1, i] = _dt.Year.ToString();
            }
            i = 2;
            row = 21;
            dtCSV = loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, "REVENUE");
            for (_dt = _from; _dt.Year <= _to.Year; _dt = _dt.AddYears(1), i++)
            {
                row = 4;

                for (int _row = 0; _row < dtCSV.Rows.Count; _row++)
                {
                    pExcelApp.Cells[_row + 21, i - 1] = dtCSV.Rows[_row][i - 2].ToString();
                }
                if (_dt.Year == _to.Year) break;
                pExcelApp.Cells[row - 1, i] = _dt.Year.ToString();
            }


            //pExcelApp.Cells[2, 2] = "(" + pFromDate + "-" + pToDate + ")";
            pExcelApp.Cells[1, 1] = "HISTORICAL NO. OF EVENTS AND REVENUE (" + pFromDate + "-" + pToDate + ")";
        }


        private void FindAndReplace(Word.Application WordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            WordApp.Selection.Find.Execute(ref findText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiacritics, ref matchAlefHamza,
                ref matchControl);
        }

        public DataTable getReportMemorandum(string pFolioID ,string pFromDate ,string pToDate, string pFilterData)
        {
            DataTable _ResultData = new DataTable();
            ReportDAO _reportDAO = new ReportDAO();
            _ResultData = _reportDAO.getReportMemorandum(pFolioID, pFromDate, pToDate, pFilterData);
            return _ResultData; 
        }
        public EndorsementForm getEndorsementForm(string pFolioID)
        {
            loReportDAO = new ReportDAO();
            EndorsementForm _endorsementForm = new EndorsementForm();
            ReservationsFacade _oReservationFacade = new ReservationsFacade();
            DataTable _dt = _oReservationFacade.GetGuestsList("folio.folioID='"+pFolioID+"'");
            DataTable _subContact  = new DataTable();
            EventEndorsement _oEventEndorsement = new EventEndorsement();
            
            foreach (DataRow _dtRow in _dt.Rows)
			{

                string _folioId = _dtRow["folioID"].ToString();
                string _folioType = _dtRow["foliotype"].ToString().ToUpper();
                string _companyName = _dtRow["CompanyName"].ToString();
                string _eventName = _dtRow["groupName"].ToString();


                DateTime _fromDate = DateTime.Parse(_dtRow["fromdate"].ToString());
                DateTime _todate = DateTime.Parse(_dtRow["todate"].ToString());

                string _guestAccountID = _dtRow["accountID"].ToString();
                string _guestName = _dtRow["GuestName"].ToString();
                string _guestAccountType = _dtRow["account_type"].ToString();
                string _guestConcierge = _dtRow["concierge"].ToString();
                string _guestRemarks = _dtRow["remark"].ToString();
                decimal _guestThreshold = 0;
                string _timeOfEvent = _dtRow["TimeOfEvent"].ToString();
                decimal.TryParse(_dtRow["THRESHOLD_VALUE"].ToString(), out _guestThreshold);
               
               
                string _rooms = "";
                ScheduleFacade _oScheduleFacade = new ScheduleFacade();
                switch (_folioType)
                {
                    case "JOINER":
                        _rooms = _oScheduleFacade.GetRoomFromSchedules(_folioId);
                        break;
                    default:
                        _rooms = _oScheduleFacade.GetRoomFromSchedules(_folioId);
                        break;
                }
                
                string _contactList=  "";
                _subContact = getContactPersons(_folioId, GlobalVariables.gHotelId, _guestAccountID);
                foreach(DataRow _row in _subContact.Rows)
                {
                    _contactList = _row["firstName"].ToString() +" "+_row["lastName"].ToString()+", ";
                }

                DataTable _dtEndorsement = _oEventEndorsement.getEventEndorsement(_folioId,GlobalVariables.gHotelId.ToString());
                double _contractAmount = 0;
                double.TryParse(_dtEndorsement.Rows[0]["contractAmount"].ToString(), out _contractAmount);

                _endorsementForm.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
                _endorsementForm.SetParameterValue(0, _dtRow["eventOfficers"].ToString());
                _endorsementForm.SetParameterValue(1, _eventName);
                _endorsementForm.SetParameterValue(2, _folioType);
                _endorsementForm.SetParameterValue(3, _fromDate.ToString("MMMM dd,yyyy") + " - " + _todate.ToString("MMMM dd,yyyy"));
                _endorsementForm.SetParameterValue(4, _rooms);
                _endorsementForm.SetParameterValue(5, _contactList);//_contactList);//Contact Persons
                _endorsementForm.SetParameterValue(6, _companyName);
                _endorsementForm.SetParameterValue(7, "");//contact numbers
                _endorsementForm.SetParameterValue(8, _dtEndorsement.Rows[0]["letterOfProposal"].ToString());//proposal letter
                _endorsementForm.SetParameterValue(9, _dtRow["sales_Executive"].ToString());
                _endorsementForm.SetParameterValue(10, "");//assistant Marketing director
                _endorsementForm.SetParameterValue(11,pFolioID);
                _endorsementForm.SetParameterValue(12, _contractAmount);
                _endorsementForm.SetParameterValue(13,(_contractAmount*.25));
                _endorsementForm.SetParameterValue(14,(_contractAmount * .50));
                _endorsementForm.SetParameterValue(15,(_contractAmount * .25));
                _endorsementForm.SetParameterValue(16, _dtEndorsement.Rows[0]["letterOfAgreement"].ToString());

                _endorsementForm.SetParameterValue(17,(_dtEndorsement.Rows[0]["letterOfAgreement"].ToString()=="PICKUP")? string.Format("{0:yyy-MM-dd}",_dtEndorsement.Rows[0]["pickupDate"]):"");
                _endorsementForm.SetParameterValue(18, (_dtEndorsement.Rows[0]["letterOfAgreement"].ToString() == "SENT") ? string.Format("{0:yyy-MM-dd}", _dtEndorsement.Rows[0]["sentToClientDate"]) : "");
                _endorsementForm.SetParameterValue(19, (_dtEndorsement.Rows[0]["letterOfAgreement"].ToString() == "RETURNED") ? string.Format("{0:yyy-MM-dd}", _dtEndorsement.Rows[0]["signedDate"]) : "");
             
            }
            return _endorsementForm;
        }
        public DataTable generateTopClientsReport(DateTime pFrom,DateTime pTo,string pMarketSegment,int pNumList)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getReporTopClients(pFrom, pTo, pMarketSegment, pNumList);
        }
        public HistoricalNoOfEventsAndRevenueReport getHistoricalEventsAndRevenue(string pFromDate,string pToDate)
        {
            HistoricalNoOfEventsAndRevenueReport _rptHistoricalEventsAndRevenue = new HistoricalNoOfEventsAndRevenueReport();
            return _rptHistoricalEventsAndRevenue;
        }
        public DataTable getHistoricalEventsAndRevenue(string pFromDate,string pToDate,string pType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getHistoricalEventsAndRevenue(pFromDate, pToDate, pType);
        }
        public DataTable getHistoricalReportsCategory()
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getHistoricalReportsCategory();
        }
        public DataTable getAccoutTypeDetails(string pFromDate,string pToDate , string pMarketSegment,string pClientType)
        {
            loReportDAO = new ReportDAO();
            return loReportDAO.getAccoutTypeDetails(pFromDate,pToDate,pMarketSegment,pClientType);
        }
    }
}

