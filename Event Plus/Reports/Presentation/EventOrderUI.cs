using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class EventOrderUI : Form
    {
        private static string EVENT_ORDER = "Event Order";
        private Object loFolio;
        private IList<string> loRooms;
        private DateTime lStartDate;
        private DateTime lEndDate;
        private ReportFacade loReportFacade;
        private string lOrganizer;
        private decimal lPax;
        private string lEventType;
        private decimal lContingencyAmount = 0;
        private decimal lVat = 0;
        private decimal lTotalCharges = 0;
        private decimal lRoomAmount = 0;
        private string lBalance = "";
        //Gene - 9/8/2011
        private decimal lRefund = 0;
        public EventOrderUI(Object pFolio, IList<string> pRooms, DateTime pStartDate, DateTime pEndDate, string pOrganizer,decimal pPax, string pEventType)
        {
            loFolio = pFolio;
            loRooms = pRooms;
            lStartDate = pStartDate;
            lEndDate = pEndDate;
            lOrganizer = pOrganizer;
            lPax = pPax;
            lEventType = pEventType;
            InitializeComponent();
        }

        private void EventOrder_Load(object sender, EventArgs e)
        {
            dtpDate.MaxDate = lEndDate;
            dtpDate.MinDate = lStartDate;
            cboRooms.DataSource = loRooms;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string _toBeGenerated = EventOrderUI.EVENT_ORDER;
            switch(_toBeGenerated)
            {
                case "Event Order":
                    generateEventOrder();
                    break;
                default :
                    break;
            }
        }
        private void generateEventOrder()
        {
            loReportFacade = new ReportFacade();
            string _folioID = loFolio.GetType().GetProperty("FolioID").GetValue(loFolio, null).ToString();
            string _packageID = "";
            EventPackageFacade _package = new EventPackageFacade();

            _packageID = loFolio.GetType().GetProperty("PackageID").GetValue(loFolio, null).ToString();
             if(_packageID!="0") {
                _packageID = "PACKAGE : " + _package.getEventPackage(_packageID).Description;
            }
            else
            {
                _packageID = "NON-PACKAGE";
            }
            string _eventOfficers = getEventOfficer(_folioID);
            string _refNo = "";
            try
            {
                _refNo = loFolio.GetType().GetProperty("ReferenceNo").GetValue(loFolio, null).ToString();
            }
            catch
            {
                _refNo = "";
            }

            string _eventName = loFolio.GetType().GetProperty("GroupName").GetValue(loFolio, null).ToString();
            string _accountID = loFolio.GetType().GetProperty("CompanyID").GetValue(loFolio, null).ToString();  

            Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.EventOrder _oEventOrder = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.EventOrder();
            DataTable _dt = new DataTable();
            DataTable _subReport = new DataTable();
            DataTable _subContact = new DataTable();
            DataTable _subPayments = new DataTable();
            string _remarks = cboRooms.Text + " : " + string.Format("{0:dd-MMM-yyyy}", dtpDate.Value);
            _dt = loReportFacade.getEventOrder(_folioID, _remarks, GlobalVariables.gHotelId);
            string _roomId = cboRooms.Text.Split('[')[0].Trim();
            getContractAmount(_folioID);

            _subReport = loReportFacade.getEventOrderSubReport(_folioID, _roomId, dtpDate.Value, GlobalVariables.gHotelId);
            _subContact = loReportFacade.getContactPersons(_folioID, GlobalVariables.gHotelId,_accountID);
            _subPayments = loReportFacade.getPayments(_folioID, GlobalVariables.gHotelId);


          //  decimal _packageAmount = decimal.Parse(lTotalRecurredChargePackage.ToString());
            decimal _roomRatesAmount = 0;
            decimal _mealRatesAmount = 0;

            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
            GenericList<RoomEvents> _oRoomEventsList = _oRoomEventFacade.getChildFoliosRoomEvents(_folioID);
            foreach (RoomEvents _oRoomEvent in _oRoomEventsList)
            {
                _roomRatesAmount += _oRoomEvent.RoomRate;
            }

            //foreach (TreeNode _treeNode in treeFoodBev.Nodes)
            //{
            //    if (_treeNode.Parent == null)
            //    {
            EventFoodRequirementsFacade _oFoodRequirementsFacade = new EventFoodRequirementsFacade();
            GenericList<EventFoodRequirements> _oFoodRequirementsList = _oFoodRequirementsFacade.getFoodRequirements(_folioID);
            foreach (EventFoodRequirements _oEventFoodRequirements in _oFoodRequirementsList)
            {
                _mealRatesAmount += _oEventFoodRequirements.TotalMealCost * (decimal)_oEventFoodRequirements.Pax;
            }
            //  
            double _payments = 0;
            foreach(DataRow _row in _subPayments.Rows)
           {
                try
                {
                 _payments += double.Parse(_row["netAmount"].ToString());
                      
                }
                catch
                {
                  _payments += 0;
                }
            }
          
            lBalance = Convert.ToString(double.Parse(lTotalCharges.ToString()) - _payments);
            _oEventOrder.OpenSubreport("EventOrderSubReport.rpt").SetDataSource(_subReport);
            _oEventOrder.OpenSubreport("EVentOrderSubContactPersons.rpt").SetDataSource(_subContact);
            _oEventOrder.OpenSubreport("EventOrderSubPayments.rpt").SetDataSource(_subPayments);
            _oEventOrder.Database.Tables[0].SetDataSource(_dt);
            _oEventOrder.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
            _oEventOrder.SetParameterValue(0, _eventOfficers);
            _oEventOrder.SetParameterValue(1, _refNo);
            _oEventOrder.SetParameterValue(2, _eventName);
            _oEventOrder.SetParameterValue(3, lOrganizer);
            _oEventOrder.SetParameterValue(4, cboRooms.Text);
            _oEventOrder.SetParameterValue(5, dtpDate.Value);
            _oEventOrder.SetParameterValue(6, lPax);
            _oEventOrder.SetParameterValue(7, lEventType);
            _oEventOrder.SetParameterValue(8, lTotalCharges);
            _oEventOrder.SetParameterValue(9, lContingencyAmount);
            _oEventOrder.SetParameterValue(10, lVat);
            _oEventOrder.SetParameterValue(11, lRoomAmount);

            //_oEventOrder.SetParameterValue(12, string.Format("{0:MMMM dd,yyyy hh:mm tt}", dtpTime.Value));
            
            // Gene - 9/8/2011
            _oEventOrder.SetParameterValue(13, lRefund);
            _oEventOrder.SetParameterValue(14, lBalance);
            _oEventOrder.SetParameterValue(15, _packageID);
            _oEventOrder.SetParameterValue(16, _mealRatesAmount);

            Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            _oReportViewer.rptViewer.ReportSource = _oEventOrder;
            _oReportViewer.MdiParent = this.MdiParent;
            _oReportViewer.Show();
            EventOrderFacade _eventOrder = new EventOrderFacade();

            try
            {
                _eventOrder.saveEventOrderView(_folioID, GlobalVariables.gLoggedOnUser, GlobalVariables.gHotelId.ToString());
            }
            catch
            {
            }
        }
        private string getEventOfficer(string pFolioID)
        {
            DataTable _dt = loReportFacade.getEventOfficers(pFolioID, GlobalVariables.gHotelId);
            if (_dt.Rows.Count < 1)
            {
                return "";
            }
            else if (_dt.Rows.Count == 1)
            {
                return (_dt.Rows[0]["firstName"].ToString() + " " + _dt.Rows[0]["lastName"].ToString());
            }
            else
            {
                string _eventOfficers = "";
                foreach (DataRow _dRow in _dt.Rows)
                {
                    _eventOfficers = _eventOfficers + ", " + _dRow["firstName"].ToString() +" " + _dRow["lastName"].ToString();
                }
                return _eventOfficers.Substring(1);
            }
        }
        private void getContractAmount(string pFolioID)
        {
            DataTable _dt = loReportFacade.getSummaryOfCharges(pFolioID, GlobalVariables.gHotelId.ToString());

            if (_dt.Rows.Count > 0)
            {
                lTotalCharges = decimal.Parse(_dt.Rows[0]["contractAmount"].ToString());
                lContingencyAmount = decimal.Parse(_dt.Rows[0]["amount"].ToString());
                lVat = decimal.Parse(_dt.Rows[0]["vat"].ToString());
                lRoomAmount = decimal.Parse(_dt.Rows[0]["roomAmount"].ToString());
                lRefund = decimal.Parse(_dt.Rows[0]["refund"].ToString());
               
            }

            
        }
    }
}